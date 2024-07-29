namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Fight;

public sealed class GameRolePlayAggressionMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6073;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int AttackerId { get; set; }

    public required int DefenderId { get; set; }

    public GameRolePlayAggressionMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(AttackerId);
        writer.WriteInt32(DefenderId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        AttackerId = reader.ReadInt32();
        DefenderId = reader.ReadInt32();
    }
}