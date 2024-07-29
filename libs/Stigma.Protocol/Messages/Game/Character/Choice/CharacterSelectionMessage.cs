namespace Stigma.Protocol.Messages.Game.Character.Choice;

public class CharacterSelectionMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 152;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public CharacterSelectionMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
    }
}