namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextKickMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6081;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public GameContextKickMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(TargetId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TargetId = reader.ReadInt32();
    }
}