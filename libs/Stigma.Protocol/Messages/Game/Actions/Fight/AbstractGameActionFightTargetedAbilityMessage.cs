namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 6118;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short DestinationCellId { get; set; }

    public required sbyte Critical { get; set; }

    public required bool SilentCast { get; set; }

    public AbstractGameActionFightTargetedAbilityMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(DestinationCellId);
        writer.WriteInt8(Critical);
        writer.WriteBoolean(SilentCast);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        DestinationCellId = reader.ReadInt16();
        Critical = reader.ReadInt8();
        SilentCast = reader.ReadBoolean();
    }
}