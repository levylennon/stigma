namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountEmoteIconUsedOkMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5978;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MountId { get; set; }

    public required sbyte ReactionType { get; set; }

    public MountEmoteIconUsedOkMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(MountId);
        writer.WriteInt8(ReactionType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MountId = reader.ReadInt32();
        ReactionType = reader.ReadInt8();
    }
}