namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightStartingMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 700;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte FightType { get; set; }

    public GameFightStartingMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(FightType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightType = reader.ReadInt8();
    }
}