using Stigma.Tools.ProtocolBuilder.Services.Builders;

namespace Stigma.Tools.ProtocolBuilder.Services.Generators;

public sealed class GeneratorService : IGeneratorService
{
    private readonly IEnumerable<IBuilder> _builders;

    public GeneratorService(IEnumerable<IBuilder> builders)
    {
        _builders = builders;
    }

    public void Generate()
    {
        foreach (var builder in _builders.OrderBy(x => x.Priority)) builder.Build();
    }
}