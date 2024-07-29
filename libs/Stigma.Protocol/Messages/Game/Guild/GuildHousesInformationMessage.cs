using Stigma.Protocol.Types.Game.House;

namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildHousesInformationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5919;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<HouseInformationsForGuild> HousesInformations { get; set; }

    public GuildHousesInformationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var housesInformationsBefore = writer.Position;
        var housesInformationsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in HousesInformations)
        {
            item.Serialize(writer);
            housesInformationsCount++;
        }

        var housesInformationsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, housesInformationsBefore);
        writer.WriteInt16((short)housesInformationsCount);
        writer.Seek(SeekOrigin.Begin, housesInformationsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var housesInformationsCount = reader.ReadInt16();
        var housesInformations = new HouseInformationsForGuild[housesInformationsCount];
        for (var i = 0; i < housesInformationsCount; i++)
        {
            var entry = new HouseInformationsForGuild();
            entry.Deserialize(reader);
            housesInformations[i] = entry;
        }

        HousesInformations = housesInformations;
    }
}