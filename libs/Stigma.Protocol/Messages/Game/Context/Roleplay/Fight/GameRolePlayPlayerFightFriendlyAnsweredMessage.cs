namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Fight;

public sealed class GameRolePlayPlayerFightFriendlyAnsweredMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5733;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int FightId { get; set; }

    public required int SourceId { get; set; }

    public required int TargetId { get; set; }

    public required bool Accept { get; set; }

    public GameRolePlayPlayerFightFriendlyAnsweredMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(FightId);
        writer.WriteInt32(SourceId);
        writer.WriteInt32(TargetId);
        writer.WriteBoolean(Accept);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt32();
        SourceId = reader.ReadInt32();
        TargetId = reader.ReadInt32();
        Accept = reader.ReadBoolean();
    }
}