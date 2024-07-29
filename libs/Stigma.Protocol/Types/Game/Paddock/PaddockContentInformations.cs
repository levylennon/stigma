namespace Stigma.Protocol.Types.Game.Paddock;

public sealed class PaddockContentInformations : PaddockInformations
{
    public new const ushort ProtocolTypeId = 183;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int MapId { get; set; }

    public IEnumerable<MountInformationsForPaddock> MountsInformations { get; set; }

    public PaddockContentInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(MapId);
        var mountsInformationsBefore = writer.Position;
        var mountsInformationsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in MountsInformations)
        {
            item.Serialize(writer);
            mountsInformationsCount++;
        }

        var mountsInformationsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, mountsInformationsBefore);
        writer.WriteInt16((short)mountsInformationsCount);
        writer.Seek(SeekOrigin.Begin, mountsInformationsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MapId = reader.ReadInt32();
        var mountsInformationsCount = reader.ReadInt16();
        var mountsInformations = new MountInformationsForPaddock[mountsInformationsCount];
        for (var i = 0; i < mountsInformationsCount; i++)
        {
            var entry = new MountInformationsForPaddock();
            entry.Deserialize(reader);
            mountsInformations[i] = entry;
        }

        MountsInformations = mountsInformations;
    }
}