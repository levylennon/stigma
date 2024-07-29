using Stigma.Protocol.Types.Game.Mount;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
{
    public new const uint ProtocolMessageId = 5979;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<MountClientData> PaddockedMountsDescription { get; set; }

    public ExchangeStartOkMountMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        var paddockedMountsDescriptionBefore = writer.Position;
        var paddockedMountsDescriptionCount = 0;
        writer.WriteInt16(0);
        foreach (var item in PaddockedMountsDescription)
        {
            item.Serialize(writer);
            paddockedMountsDescriptionCount++;
        }

        var paddockedMountsDescriptionAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, paddockedMountsDescriptionBefore);
        writer.WriteInt16((short)paddockedMountsDescriptionCount);
        writer.Seek(SeekOrigin.Begin, paddockedMountsDescriptionAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        var paddockedMountsDescriptionCount = reader.ReadInt16();
        var paddockedMountsDescription = new MountClientData[paddockedMountsDescriptionCount];
        for (var i = 0; i < paddockedMountsDescriptionCount; i++)
        {
            var entry = new MountClientData();
            entry.Deserialize(reader);
            paddockedMountsDescription[i] = entry;
        }

        PaddockedMountsDescription = paddockedMountsDescription;
    }
}