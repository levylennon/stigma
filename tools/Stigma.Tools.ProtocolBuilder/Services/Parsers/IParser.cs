using Stigma.Tools.ProtocolBuilder.Models.Symbols;

namespace Stigma.Tools.ProtocolBuilder.Services.Parsers;

public interface IParser
{
    ClassSymbol Parse(TypeSymbol typeSymbol);
}