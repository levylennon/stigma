using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Stigma.Tools.ProtocolBuilder.Options;
using Stigma.Tools.ProtocolBuilder.Services.Builders;
using Stigma.Tools.ProtocolBuilder.Services.Builders.Factories;
using Stigma.Tools.ProtocolBuilder.Services.Builders.Protocol;
using Stigma.Tools.ProtocolBuilder.Services.Converters;
using Stigma.Tools.ProtocolBuilder.Services.Converters.Classes;
using Stigma.Tools.ProtocolBuilder.Services.Converters.Enums;
using Stigma.Tools.ProtocolBuilder.Services.Generators;
using Stigma.Tools.ProtocolBuilder.Services.Parsers;
using Stigma.Tools.ProtocolBuilder.Services.Parsers.Classes;
using Stigma.Tools.ProtocolBuilder.Services.Parsers.Enums;
using Stigma.Tools.ProtocolBuilder.Services.Renderers;
using Stigma.Tools.ProtocolBuilder.Services.Renderers.Class;
using Stigma.Tools.ProtocolBuilder.Services.Renderers.Enums;
using Stigma.Tools.ProtocolBuilder.Storages.Identity;
using Stigma.Tools.ProtocolBuilder.Storages.Regexes;
using Stigma.Tools.ProtocolBuilder.Storages.Symbols;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((host, services) =>
    {
        services
            .Configure<GlobalOptions>(host.Configuration.GetSection("Dofus"))
            .AddKeyedSingleton<IParser, ClassParser>("class")
            .AddKeyedSingleton<IParser, EnumParser>("enums")
            .AddKeyedSingleton<IConverter, ClassConverter>("class")
            .AddKeyedSingleton<IConverter, EnumConverter>("enums")
            .AddKeyedSingleton<IRenderer, ClassRenderer>("class")
            .AddKeyedSingleton<IRenderer, EnumRenderer>("enums")
            .AddSingleton<IBuilder, FactoryBuilder>()
            .AddSingleton<IBuilder, ProtocolBuilder>()
            .AddSingleton<IIdentityStorage, IdentityStorage>()
            .AddSingleton<IRegexStorage, RegexStorage>()
            .AddSingleton<ISymbolStorage, SymbolStorage>()
            .AddSingleton<IGeneratorService, GeneratorService>();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddSerilog();
    })
    .Build()
    .Services
    .GetRequiredService<IGeneratorService>()
    .Generate();