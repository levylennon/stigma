namespace Stigma.Protocol.Messages.Game.Character.Creation;

public sealed class CharacterNameSuggestionFailureMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 164;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public CharacterNameSuggestionFailureMessage()
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