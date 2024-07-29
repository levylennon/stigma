namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Npc;

public sealed class NpcGenericActionRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5898;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int NpcId { get; set; }

    public required sbyte NpcActionId { get; set; }

    public NpcGenericActionRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(NpcId);
        writer.WriteInt8(NpcActionId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        NpcId = reader.ReadInt32();
        NpcActionId = reader.ReadInt8();
    }
}