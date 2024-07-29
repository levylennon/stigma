namespace Stigma.Protocol.Messages.Game.Character.Deletion;

public sealed class CharacterDeletionErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 166;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public CharacterDeletionErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Reason = reader.ReadInt8();
    }
}