namespace Stigma.Protocol.Messages.Game.Character.Replay;

public class CharacterReplayRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 167;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int CharacterId { get; set; }

    public CharacterReplayRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(CharacterId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CharacterId = reader.ReadInt32();
    }
}