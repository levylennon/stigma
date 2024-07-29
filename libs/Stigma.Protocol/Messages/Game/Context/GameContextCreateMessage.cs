namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextCreateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 200;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Context { get; set; }

    public GameContextCreateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Context);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Context = reader.ReadInt8();
    }
}