namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyUpdateLightMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6054;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public required int LifePoints { get; set; }

    public required int MaxLifePoints { get; set; }

    public required short Prospecting { get; set; }

    public required byte RegenRate { get; set; }

    public PartyUpdateLightMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
        writer.WriteInt32(LifePoints);
        writer.WriteInt32(MaxLifePoints);
        writer.WriteInt16(Prospecting);
        writer.WriteUInt8(RegenRate);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
        LifePoints = reader.ReadInt32();
        MaxLifePoints = reader.ReadInt32();
        Prospecting = reader.ReadInt16();
        RegenRate = reader.ReadUInt8();
    }
}