using Stigma.Protocol.Types.Game.Context.Fight;

namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightSummonMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5825;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required GameFightFighterInformations Summon { get; set; }

    public GameActionFightSummonMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt16(Summon.ProtocolId);
        Summon.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Summon = DofusTypeFactory.CreateInstance<GameFightFighterInformations>(reader.ReadUInt16());
        Summon.Deserialize(reader);
    }
}