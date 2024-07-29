using Stigma.Tools.ProtocolBuilder.Models.Symbols;

namespace Stigma.Tools.ProtocolBuilder.Services.Converters;

public interface IConverter
{
    void Convert(ClassSymbol classSymbol);
}