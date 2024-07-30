namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightCarryCharacterMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5830;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public GameActionFightCarryCharacterMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
    }
}