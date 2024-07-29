using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stigma.Tools.ProtocolBuilder.Extensions;
using Stigma.Tools.ProtocolBuilder.Models.Kinds;
using Stigma.Tools.ProtocolBuilder.Models.Symbols;
using Stigma.Tools.ProtocolBuilder.Options;
using Stigma.Tools.ProtocolBuilder.Services.Converters;
using Stigma.Tools.ProtocolBuilder.Services.Parsers;
using Stigma.Tools.ProtocolBuilder.Services.Renderers;
using Stigma.Tools.ProtocolBuilder.Storages.Regexes;
using Stigma.Tools.ProtocolBuilder.Storages.Symbols;

namespace Stigma.Tools.ProtocolBuilder.Services.Builders.Protocol;

public sealed class ProtocolBuilder : IBuilder
{
    private readonly IConverter _classConverter;
    private readonly IParser _classParser;
    private readonly IRenderer _classRenderer;
    private readonly IConverter _enumConverter;
    private readonly IParser _enumParser;
    private readonly IRenderer _enumRenderer;
    private readonly ILogger<ProtocolBuilder> _logger;
    private readonly GlobalOptions _options;
    private readonly IRegexStorage _regexStorage;
    private readonly ISymbolStorage _symbolStorage;

    public ProtocolBuilder(
        IOptions<GlobalOptions> options,
        ILogger<ProtocolBuilder> logger,
        IRegexStorage regexStorage,
        ISymbolStorage symbolStorage,
        [FromKeyedServices("enums")] IParser enumParser,
        [FromKeyedServices("class")] IParser classParser,
        [FromKeyedServices("enums")] IConverter enumConverter,
        [FromKeyedServices("class")] IConverter classConverter,
        [FromKeyedServices("enums")] IRenderer enumRenderer,
        [FromKeyedServices("class")] IRenderer classRenderer)
    {
        _options = options.Value;
        _logger = logger;
        _regexStorage = regexStorage;
        _symbolStorage = symbolStorage;
        _enumParser = enumParser;
        _classParser = classParser;
        _enumConverter = enumConverter;
        _classConverter = classConverter;
        _enumRenderer = enumRenderer;
        _classRenderer = classRenderer;
    }

    public byte Priority =>
        1;

    public void Build()
    {
        if (Directory.Exists(_options.Paths.Output))
        {
            Directory.Delete(_options.Paths.Output, true);

            _logger.LogInformation("Output directory deleted");
        }

        Directory.CreateDirectory(_options.Paths.Output);

        _logger.LogInformation("Output directory created");

        _logger.LogInformation("Searching for protocol files");

        var files = Directory
            .GetFiles(Path.Combine(_options.Paths.Input, "scripts", "com", "ankamagames", "dofus", "network"), "*.as", SearchOption.AllDirectories)
            .Where(x => x.Contains("types") || x.Contains("messages") || x.Contains("enums"))
            .ToArray();

        _logger.LogInformation("Found {Count} protocol files", files.Length);

        foreach (var filePath in files)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            _logger.LogInformation("Parsing {FileName}", fileName);

            var fileContent = File.ReadAllText(filePath);

            var symbolKind = GetSymbolKind(filePath);

            var typeSymbol = ParseTypeSymbol(CleanSource(fileContent), symbolKind);

            var classSymbol = symbolKind switch
            {
                SymbolKind.Types => _classParser.Parse(typeSymbol),
                SymbolKind.Messages => _classParser.Parse(typeSymbol),
                SymbolKind.Enums => _enumParser.Parse(typeSymbol),
                _ => throw new ArgumentOutOfRangeException()
            };

            _symbolStorage.AddClassSymbol(classSymbol);

            _logger.LogInformation("Parsed {FileName}", fileName);

            _logger.LogInformation("Converting {FileName}", fileName);

            switch (symbolKind)
            {
                case SymbolKind.Types:
                    _classConverter.Convert(classSymbol);
                    break;
                case SymbolKind.Messages:
                    _classConverter.Convert(classSymbol);
                    break;
                case SymbolKind.Enums:
                    _enumConverter.Convert(classSymbol);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _logger.LogInformation("Converted {FileName}", fileName);
        }

        foreach (var classSymbol in _symbolStorage.GetClassSymbols())
        {
            _logger.LogInformation("Rendering {FileName}", classSymbol.Type.Name);

            var rendered = classSymbol.Type.SymbolKind switch
            {
                SymbolKind.Types => _classRenderer.Render(classSymbol),
                SymbolKind.Messages => _classRenderer.Render(classSymbol),
                SymbolKind.Enums => _enumRenderer.Render(classSymbol),
                _ => throw new ArgumentOutOfRangeException()
            };

            _logger.LogInformation("Rendered {FileName}", classSymbol.Type.Name);

            var directoryPath = Path.Combine(_options.Paths.Output, classSymbol.Type.Namespace.NamespaceToPath());

            if (!Directory.Exists(directoryPath))
            {
                _logger.LogInformation("Creating directory {DirectoryPath}", directoryPath);

                Directory.CreateDirectory(directoryPath);

                _logger.LogInformation("Directory {DirectoryPath} created", directoryPath);
            }

            var filePath = Path.Combine(directoryPath, string.Concat(classSymbol.Type.Name, ".cs"));

            _logger.LogInformation("Writing {FileName}", classSymbol.Type.Name);

            File.WriteAllText(filePath, rendered);

            _logger.LogInformation("Written {FileName}", classSymbol.Type.Name);
        }
    }

    private TypeSymbol ParseTypeSymbol(string source, SymbolKind symbolKind)
    {
        var match = _regexStorage.Match(RegexKind.Metadata, source);

        if (!match.Groups.TryGetValue("name", out var nameGroup))
            throw new Exception("Unable to find class name.");

        if (!match.Groups.TryGetValue("parent", out var parentGroup))
            throw new Exception("Unable to find parent name.");

        if (!match.Groups.TryGetValue("interface", out _))
            throw new Exception("Unable to find interface name.");

        var parentName = parentGroup.Value is "implements" ? "NetworkType" : parentGroup.Value;

        match = _regexStorage.Match(RegexKind.Namespace, source);

        if (!match.Groups.TryGetValue("name", out var packageGroup))
            throw new Exception("Unable to find package name.");

        var packageName = packageGroup
            .Value
            .Replace("com.ankamagames.dofus.network", string.Empty);

        return new TypeSymbol
        {
            Namespace = packageName,
            Name = nameGroup.Value,
            ParentName = parentName,
            Source = source,
            SymbolKind = symbolKind
        };
    }

    private string CleanSource(string src)
    {
        var source = src.Split('\n');

        for (var i = 0; i < source.Length; i++)
        {
            var line = source[i];

            if (!line.Contains("if("))
                continue;

            source[i] = string.Empty;
            var openBarakCount = 0;

            for (var subIndex = i; subIndex < source.Length; subIndex++)
            {
                if (source[subIndex].Trim() is "{")
                {
                    source[subIndex] = string.Empty;
                    openBarakCount++;
                }

                if (source[subIndex].Trim() is "}")
                {
                    source[subIndex] = string.Empty;
                    openBarakCount--;

                    if (openBarakCount <= 0)
                        break;
                }

                if (source[subIndex].Trim() is "continue;")
                    source[subIndex] = string.Empty;

                if (source[subIndex].Trim() is "return;")
                    source[subIndex] = string.Empty;

                if (_regexStorage.IsMatch(RegexKind.ThrowError, source[subIndex]))
                    source[subIndex] = string.Empty;
            }
        }

        return source
            .Where(line => line.Trim() != string.Empty)
            .Aggregate((current, line) => current + (line + (char)10));
    }

    private static SymbolKind GetSymbolKind(string path)
    {
        return path switch
        {
            _ when path.Contains("network\\types") => SymbolKind.Types,
            _ when path.Contains("network\\messages") => SymbolKind.Messages,
            _ when path.Contains("network\\enums") => SymbolKind.Enums,
            _ => throw new ArgumentOutOfRangeException(nameof(path))
        };
    }
}