namespace Stigma.Protocol.Types.Game.Context;

public sealed class EntityMovementInformations : DofusType
{
    public new const ushort ProtocolTypeId = 63;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Id { get; set; }

    public IEnumerable<sbyte> Steps { get; set; }

    public EntityMovementInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
        var stepsBefore = writer.Position;
        var stepsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Steps)
        {
            writer.WriteInt8(item);
            stepsCount++;
        }

        var stepsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, stepsBefore);
        writer.WriteInt16((short)stepsCount);
        writer.Seek(SeekOrigin.Begin, stepsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
        var stepsCount = reader.ReadInt16();
        var steps = new sbyte[stepsCount];
        for (var i = 0; i < stepsCount; i++) steps[i] = reader.ReadInt8();
        Steps = steps;
    }
}