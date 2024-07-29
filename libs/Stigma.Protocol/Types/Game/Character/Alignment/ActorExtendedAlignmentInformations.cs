namespace Stigma.Protocol.Types.Game.Character.Alignment;

public sealed class ActorExtendedAlignmentInformations : ActorAlignmentInformations
{
    public new const ushort ProtocolTypeId = 202;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public ushort Honor { get; set; }

    public ushort Dishonor { get; set; }

    public bool PvpEnabled { get; set; }

    public ActorExtendedAlignmentInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt16(Honor);
        writer.WriteUInt16(Dishonor);
        writer.WriteBoolean(PvpEnabled);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Honor = reader.ReadUInt16();
        Dishonor = reader.ReadUInt16();
        PvpEnabled = reader.ReadBoolean();
    }
}