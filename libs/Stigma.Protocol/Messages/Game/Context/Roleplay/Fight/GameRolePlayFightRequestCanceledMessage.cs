namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Fight;

public sealed class GameRolePlayFightRequestCanceledMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5822;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int FightId { get; set; }

    public required int SourceId { get; set; }

    public required int TargetId { get; set; }

    public GameRolePlayFightRequestCanceledMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(FightId);
        writer.WriteInt32(SourceId);
        writer.WriteInt32(TargetId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt32();
        SourceId = reader.ReadInt32();
        TargetId = reader.ReadInt32();
    }
}