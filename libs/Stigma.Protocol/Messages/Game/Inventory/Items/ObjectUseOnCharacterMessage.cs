namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectUseOnCharacterMessage : ObjectUseMessage
{
    public new const uint ProtocolMessageId = 3003;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int CharacterId { get; set; }

    public ObjectUseOnCharacterMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(CharacterId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        CharacterId = reader.ReadInt32();
    }
}