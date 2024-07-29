namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses.Guild;

public sealed class HouseGuildRightsChangeRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5702;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required uint Rights { get; set; }

    public HouseGuildRightsChangeRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt32(Rights);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Rights = reader.ReadUInt32();
    }
}