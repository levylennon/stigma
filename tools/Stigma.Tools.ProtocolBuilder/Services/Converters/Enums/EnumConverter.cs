using Humanizer;
using Microsoft.Extensions.Options;
using Stigma.Tools.ProtocolBuilder.Models.Symbols;
using Stigma.Tools.ProtocolBuilder.Options;

namespace Stigma.Tools.ProtocolBuilder.Services.Converters.Enums;

public sealed class EnumConverter : IConverter
{
    private readonly GlobalOptions _options;

    public EnumConverter(IOptions<GlobalOptions> options)
    {
        _options = options.Value;
    }
    
    public void Convert(ClassSymbol classSymbol)
    {
        classSymbol.Type.Name = classSymbol.Type.Name
            .Replace("Enum", string.Empty)
            .Pluralize();

        foreach (var property in classSymbol.Properties)
        {
            property.Name = string.Join(string.Empty, property.Name.Split('_', StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLowerInvariant().Pascalize()));
        }

        classSymbol.Type.Namespace = string.Concat(_options.Namespace, ".Enums");

        if (classSymbol.Properties.Count > 0)
        {
            var firstProperty = classSymbol.Properties.First();

            classSymbol.Type.ParentName = classSymbol.Properties.All(x => x.Type == firstProperty.Type) ? firstProperty.Type : classSymbol.Type.ParentName;
        }
    }
}