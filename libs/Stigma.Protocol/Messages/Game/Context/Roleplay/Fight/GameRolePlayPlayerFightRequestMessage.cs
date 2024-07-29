namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Fight;

public sealed class GameRolePlayPlayerFightRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5731;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required bool Friendly { get; set; }

    public GameRolePlayPlayerFightRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(TargetId);
        writer.WriteBoolean(Friendly);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TargetId = reader.ReadInt32();
        Friendly = reader.ReadBoolean();
    }
}