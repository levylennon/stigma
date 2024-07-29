namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightOptionStateUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5927;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short FightId { get; set; }

    public required sbyte TeamId { get; set; }

    public required sbyte Option { get; set; }

    public required bool State { get; set; }

    public GameFightOptionStateUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(FightId);
        writer.WriteInt8(TeamId);
        writer.WriteInt8(Option);
        writer.WriteBoolean(State);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt16();
        TeamId = reader.ReadInt8();
        Option = reader.ReadInt8();
        State = reader.ReadBoolean();
    }
}