using Stigma.Protocol.Types.Game.House;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses;

public sealed class HousePropertiesMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5734;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required HouseInformations Properties { get; set; }

    public HousePropertiesMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(Properties.ProtocolId);
        Properties.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Properties = DofusTypeFactory.CreateInstance<HouseInformations>(reader.ReadUInt16());
        Properties.Deserialize(reader);
    }
}