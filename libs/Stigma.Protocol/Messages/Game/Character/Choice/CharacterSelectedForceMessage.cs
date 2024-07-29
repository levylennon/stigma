namespace Stigma.Protocol.Messages.Game.Character.Choice;

public sealed class CharacterSelectedForceMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6068;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public CharacterSelectedForceMessage()
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