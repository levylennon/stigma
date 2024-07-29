namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses.Guild;

public sealed class HouseGuildShareRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5704;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Enable { get; set; }

    public HouseGuildShareRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Enable);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Enable = reader.ReadBoolean();
    }
}