namespace Stigma.Protocol.Messages.Game.Character.Deletion;

public sealed class CharacterDeletionRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 165;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int CharacterId { get; set; }

    public required string SecretAnswerHash { get; set; }

    public CharacterDeletionRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(CharacterId);
        writer.WriteUtf(SecretAnswerHash);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CharacterId = reader.ReadInt32();
        SecretAnswerHash = reader.ReadUtf();
    }
}