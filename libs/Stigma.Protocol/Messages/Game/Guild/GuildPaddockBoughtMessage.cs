namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildPaddockBoughtMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5952;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short WorldX { get; set; }

    public required short WorldY { get; set; }

    public required sbyte NbMountMax { get; set; }

    public required sbyte NbItemMax { get; set; }

    public GuildPaddockBoughtMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        writer.WriteInt8(NbMountMax);
        writer.WriteInt8(NbItemMax);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        NbMountMax = reader.ReadInt8();
        NbItemMax = reader.ReadInt8();
    }
}