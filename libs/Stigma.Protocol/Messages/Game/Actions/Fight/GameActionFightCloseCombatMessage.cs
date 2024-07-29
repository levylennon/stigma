namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
{
    public new const uint ProtocolMessageId = 6116;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int WeaponGenericId { get; set; }

    public GameActionFightCloseCombatMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(WeaponGenericId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        WeaponGenericId = reader.ReadInt32();
    }
}