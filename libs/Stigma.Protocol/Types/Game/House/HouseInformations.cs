namespace Stigma.Protocol.Types.Game.House;

public class HouseInformations : DofusType
{
    public new const ushort ProtocolTypeId = 111;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int HouseId { get; set; }

    public IEnumerable<int> DoorsOnMap { get; set; }

    public string OwnerName { get; set; }

    public bool IsOnSale { get; set; }

    public short ModelId { get; set; }

    public HouseInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(HouseId);
        var doorsOnMapBefore = writer.Position;
        var doorsOnMapCount = 0;
        writer.WriteInt16(0);
        foreach (var item in DoorsOnMap)
        {
            writer.WriteInt32(item);
            doorsOnMapCount++;
        }

        var doorsOnMapAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, doorsOnMapBefore);
        writer.WriteInt16((short)doorsOnMapCount);
        writer.Seek(SeekOrigin.Begin, doorsOnMapAfter);
        writer.WriteUtf(OwnerName);
        writer.WriteBoolean(IsOnSale);
        writer.WriteInt16(ModelId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        HouseId = reader.ReadInt32();
        var doorsOnMapCount = reader.ReadInt16();
        var doorsOnMap = new int[doorsOnMapCount];
        for (var i = 0; i < doorsOnMapCount; i++) doorsOnMap[i] = reader.ReadInt32();
        DoorsOnMap = doorsOnMap;
        OwnerName = reader.ReadUtf();
        IsOnSale = reader.ReadBoolean();
        ModelId = reader.ReadInt16();
    }
}