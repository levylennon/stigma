namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Npc;

public sealed class NpcDialogCreationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5618;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MapId { get; set; }

    public required int NpcId { get; set; }

    public NpcDialogCreationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(MapId);
        writer.WriteInt32(NpcId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MapId = reader.ReadInt32();
        NpcId = reader.ReadInt32();
    }
}