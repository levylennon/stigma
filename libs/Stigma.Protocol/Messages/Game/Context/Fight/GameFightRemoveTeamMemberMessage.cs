namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightRemoveTeamMemberMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 711;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short FightId { get; set; }

    public required sbyte TeamId { get; set; }

    public required int CharId { get; set; }

    public GameFightRemoveTeamMemberMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(FightId);
        writer.WriteInt8(TeamId);
        writer.WriteInt32(CharId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt16();
        TeamId = reader.ReadInt8();
        CharId = reader.ReadInt32();
    }
}