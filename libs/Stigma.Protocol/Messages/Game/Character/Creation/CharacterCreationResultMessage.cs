namespace Stigma.Protocol.Messages.Game.Character.Creation;

public sealed class CharacterCreationResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 161;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Result { get; set; }

    public CharacterCreationResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Result);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Result = reader.ReadInt8();
    }
}