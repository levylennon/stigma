namespace Stigma.Protocol.Types.Game.Fight;

public sealed class ProtectedEntityWaitingForHelpInfo : DofusType
{
    public new const ushort ProtocolTypeId = 186;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int TimeLeftBeforeFight { get; set; }

    public int WaitTimeForPlacement { get; set; }

    public sbyte NbPositionForDefensors { get; set; }

    public ProtectedEntityWaitingForHelpInfo()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(TimeLeftBeforeFight);
        writer.WriteInt32(WaitTimeForPlacement);
        writer.WriteInt8(NbPositionForDefensors);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TimeLeftBeforeFight = reader.ReadInt32();
        WaitTimeForPlacement = reader.ReadInt32();
        NbPositionForDefensors = reader.ReadInt8();
    }
}