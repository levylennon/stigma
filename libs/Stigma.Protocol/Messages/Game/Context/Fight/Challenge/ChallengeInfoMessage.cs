namespace Stigma.Protocol.Messages.Game.Context.Fight.Challenge;

public sealed class ChallengeInfoMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6022;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte ChallengeId { get; set; }

    public required int TargetId { get; set; }

    public required int BaseXpBonus { get; set; }

    public required int ExtraXpBonus { get; set; }

    public required int BaseDropBonus { get; set; }

    public required int ExtraDropBonus { get; set; }

    public ChallengeInfoMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(ChallengeId);
        writer.WriteInt32(TargetId);
        writer.WriteInt32(BaseXpBonus);
        writer.WriteInt32(ExtraXpBonus);
        writer.WriteInt32(BaseDropBonus);
        writer.WriteInt32(ExtraDropBonus);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ChallengeId = reader.ReadInt8();
        TargetId = reader.ReadInt32();
        BaseXpBonus = reader.ReadInt32();
        ExtraXpBonus = reader.ReadInt32();
        BaseDropBonus = reader.ReadInt32();
        ExtraDropBonus = reader.ReadInt32();
    }
}