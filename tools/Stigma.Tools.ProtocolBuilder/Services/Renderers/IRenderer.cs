using Stigma.Tools.ProtocolBuilder.Models.Symbols;

namespace Stigma.Tools.ProtocolBuilder.Services.Renderers;

public interface IRenderer
{
    string Render(ClassSymbol classSymbol);
}