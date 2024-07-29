namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Fight;

public sealed class GameRolePlayPlayerFightFriendlyAnswerMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5732;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int FightId { get; set; }

    public required bool Accept { get; set; }

    public GameRolePlayPlayerFightFriendlyAnswerMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(FightId);
        writer.WriteBoolean(Accept);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt32();
        Accept = reader.ReadBoolean();
    }
}