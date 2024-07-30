using Stigma.Core.IO.Text;
using Stigma.Tools.ProtocolBuilder.Storages.Symbols;

namespace Stigma.Tools.ProtocolBuilder.Services.Builders.Factories;

public sealed class FactoryBuilder : IBuilder
{
    private readonly ISymbolStorage _symbolStorage;
    
    public byte Priority =>
        2;

    public FactoryBuilder(ISymbolStorage symbolStorage)
    {
        _symbolStorage = symbolStorage;
    }

    public void Build()
    {
        var symbols = _symbolStorage.GetClassSymbols().ToArray();

        var types = symbols
            .Where(x => !x.Type.Name.EndsWith("Message") && x.Type.Name != "ProtocolRequired");
        
        var messages = symbols
            .Where(x => x.Type.Name.EndsWith("Message") || x.Type.Name == "ProtocolRequired");

        var typeFactory = new IndentedStringBuilder()
            .AppendLine("namespace Stigma.Protocol.Types;")
            .AppendLine()
            .AppendLine("public static class DofusTypeFactory")
            .AppendLine('{')
            .Indent()
            .AppendLineIndented("public static T CreateInstance<T>(ushort id) where T : DofusType")
            .AppendLineIndented('{')
            .Indent()
            .AppendLineIndented("return id switch")
            .AppendLineIndented('{')
            .Indent();

        foreach (var type in types)
            typeFactory.AppendLineIndented("{0}.ProtocolTypeId => (T)(object)new {0}(),", string.Concat(type.Type.Namespace, ".", type.Type.Name));
        
        typeFactory
            .AppendLineIndented("_ => throw new ArgumentOutOfRangeException(nameof(id))")
            .UnIndent()
            .AppendLineIndented("};")
            .UnIndent()
            .AppendLineIndented('}')
            .UnIndent()
            .AppendLine('}');
        
        var messageFactory = new IndentedStringBuilder()
            .AppendLine("namespace Stigma.Protocol.Messages;")
            .AppendLine()
            .AppendLine("public sealed class DofusMessageFactory : IMessageFactory")
            .AppendLine('{')
            .Indent()
            .AppendLineIndented("public bool TryCreateInstance(uint id, [NotNullWhen(true)] out DofusMessage? message)")
            .AppendLineIndented('{')
            .Indent()
            .AppendLineIndented("return (message = id switch")
            .AppendLineIndented('{')
            .Indent();
        
        foreach (var message in messages)
            messageFactory.AppendLineIndented("{0}.ProtocolMessageId => new {0}(),", string.Concat(message.Type.Namespace, ".", message.Type.Name));
        
        messageFactory
            .AppendLineIndented("_ => throw new ArgumentOutOfRangeException(nameof(id))")
            .UnIndent()
            .AppendLineIndented("}) is not null;")
            .UnIndent()
            .AppendLineIndented('}')
            .UnIndent()
            .AppendLine('}');
        
        File.WriteAllText("Output/Types/DofusTypeFactory.cs", typeFactory.ToString());
        File.WriteAllText("Output/Messages/DofusMessageFactory.cs", messageFactory.ToString());
    }
}