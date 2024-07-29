using Stigma.Protocol.Types.Game.Paddock;

namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInformationsPaddocksMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5959;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte NbPaddockMax { get; set; }

    public required IEnumerable<PaddockContentInformations> PaddocksInformations { get; set; }

    public GuildInformationsPaddocksMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(NbPaddockMax);
        var paddocksInformationsBefore = writer.Position;
        var paddocksInformationsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in PaddocksInformations)
        {
            item.Serialize(writer);
            paddocksInformationsCount++;
        }

        var paddocksInformationsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, paddocksInformationsBefore);
        writer.WriteInt16((short)paddocksInformationsCount);
        writer.Seek(SeekOrigin.Begin, paddocksInformationsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        NbPaddockMax = reader.ReadInt8();
        var paddocksInformationsCount = reader.ReadInt16();
        var paddocksInformations = new PaddockContentInformations[paddocksInformationsCount];
        for (var i = 0; i < paddocksInformationsCount; i++)
        {
            var entry = new PaddockContentInformations();
            entry.Deserialize(reader);
            paddocksInformations[i] = entry;
        }

        PaddocksInformations = paddocksInformations;
    }
}