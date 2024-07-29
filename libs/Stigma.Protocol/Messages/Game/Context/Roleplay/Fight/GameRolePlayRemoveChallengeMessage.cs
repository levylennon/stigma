namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Fight;

public sealed class GameRolePlayRemoveChallengeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 300;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int FightId { get; set; }

    public GameRolePlayRemoveChallengeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(FightId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt32();
    }
}