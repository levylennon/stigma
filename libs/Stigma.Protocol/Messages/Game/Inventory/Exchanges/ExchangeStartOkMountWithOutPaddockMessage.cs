using Stigma.Protocol.Types.Game.Mount;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public class ExchangeStartOkMountWithOutPaddockMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5991;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<MountClientData> StabledMountsDescription { get; set; }

    public ExchangeStartOkMountWithOutPaddockMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var stabledMountsDescriptionBefore = writer.Position;
        var stabledMountsDescriptionCount = 0;
        writer.WriteInt16(0);
        foreach (var item in StabledMountsDescription)
        {
            item.Serialize(writer);
            stabledMountsDescriptionCount++;
        }

        var stabledMountsDescriptionAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, stabledMountsDescriptionBefore);
        writer.WriteInt16((short)stabledMountsDescriptionCount);
        writer.Seek(SeekOrigin.Begin, stabledMountsDescriptionAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var stabledMountsDescriptionCount = reader.ReadInt16();
        var stabledMountsDescription = new MountClientData[stabledMountsDescriptionCount];
        for (var i = 0; i < stabledMountsDescriptionCount; i++)
        {
            var entry = new MountClientData();
            entry.Deserialize(reader);
            stabledMountsDescription[i] = entry;
        }

        StabledMountsDescription = stabledMountsDescription;
    }
}