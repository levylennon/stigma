using System.Diagnostics.CodeAnalysis;
using Stigma.Tools.ProtocolBuilder.Models.Symbols;

namespace Stigma.Tools.ProtocolBuilder.Storages.Symbols;

public sealed class SymbolStorage : ISymbolStorage
{
    private readonly Dictionary<string, ClassSymbol> _symbols;
    
    public SymbolStorage()
    {
        _symbols = [];
    }
    
    public void AddClassSymbol(ClassSymbol symbol)
    {
        _symbols[symbol.Type.Name] = symbol;
    }

    public bool TryGetClassSymbol(string name, [NotNullWhen(true)] out ClassSymbol? classSymbol)
    {
        return _symbols.TryGetValue(name, out classSymbol);
    }

    public IEnumerable<ClassSymbol> GetClassSymbols()
    {
        return _symbols.Values;
    }
}