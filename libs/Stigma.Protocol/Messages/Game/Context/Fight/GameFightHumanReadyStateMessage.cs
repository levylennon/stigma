namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightHumanReadyStateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 740;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int CharacterId { get; set; }

    public required bool IsReady { get; set; }

    public GameFightHumanReadyStateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(CharacterId);
        writer.WriteBoolean(IsReady);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CharacterId = reader.ReadInt32();
        IsReady = reader.ReadBoolean();
    }
}