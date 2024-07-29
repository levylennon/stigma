using System.Diagnostics.CodeAnalysis;
using Stigma.Tools.ProtocolBuilder.Models.Symbols;

namespace Stigma.Tools.ProtocolBuilder.Storages.Symbols;

public interface ISymbolStorage
{
    void AddClassSymbol(ClassSymbol symbol);

    bool TryGetClassSymbol(string name, [NotNullWhen(true)] out ClassSymbol? classSymbol);

    IEnumerable<ClassSymbol> GetClassSymbols();
}