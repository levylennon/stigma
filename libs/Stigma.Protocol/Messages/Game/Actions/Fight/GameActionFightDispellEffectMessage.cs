namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
{
    public new const uint ProtocolMessageId = 6113;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int BoostUID { get; set; }

    public GameActionFightDispellEffectMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(BoostUID);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        BoostUID = reader.ReadInt32();
    }
}