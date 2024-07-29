namespace Stigma.Protocol.Messages.Game.Pvp;

public sealed class AlignmentRankUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6058;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte AlignmentRank { get; set; }

    public required bool Verbose { get; set; }

    public AlignmentRankUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(AlignmentRank);
        writer.WriteBoolean(Verbose);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        AlignmentRank = reader.ReadInt8();
        Verbose = reader.ReadBoolean();
    }
}