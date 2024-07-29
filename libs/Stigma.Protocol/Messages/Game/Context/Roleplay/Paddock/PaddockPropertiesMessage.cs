using Stigma.Protocol.Types.Game.Paddock;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Paddock;

public sealed class PaddockPropertiesMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5824;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required PaddockInformations Properties { get; set; }

    public PaddockPropertiesMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(Properties.ProtocolId);
        Properties.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Properties = DofusTypeFactory.CreateInstance<PaddockInformations>(reader.ReadUInt16());
        Properties.Deserialize(reader);
    }
}