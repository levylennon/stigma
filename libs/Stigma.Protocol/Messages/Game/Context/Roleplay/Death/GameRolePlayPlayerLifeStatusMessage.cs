namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Death;

public sealed class GameRolePlayPlayerLifeStatusMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5996;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte State { get; set; }

    public GameRolePlayPlayerLifeStatusMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(State);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        State = reader.ReadInt8();
    }
}