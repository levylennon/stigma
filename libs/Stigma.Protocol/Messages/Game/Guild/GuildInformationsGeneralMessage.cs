namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInformationsGeneralMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5557;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Enabled { get; set; }

    public required byte Level { get; set; }

    public required double ExpLevelFloor { get; set; }

    public required double Experience { get; set; }

    public required double ExpNextLevelFloor { get; set; }

    public GuildInformationsGeneralMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Enabled);
        writer.WriteUInt8(Level);
        writer.WriteDouble(ExpLevelFloor);
        writer.WriteDouble(Experience);
        writer.WriteDouble(ExpNextLevelFloor);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Enabled = reader.ReadBoolean();
        Level = reader.ReadUInt8();
        ExpLevelFloor = reader.ReadDouble();
        Experience = reader.ReadDouble();
        ExpNextLevelFloor = reader.ReadDouble();
    }
}