namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses;

public sealed class HouseKickRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5698;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public HouseKickRequestMessage()
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