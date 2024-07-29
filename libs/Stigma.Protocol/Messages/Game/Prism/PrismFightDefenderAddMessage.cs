using Stigma.Protocol.Types.Game.Character;

namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismFightDefenderAddMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5895;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double FightId { get; set; }

    public required CharacterMinimalPlusLookAndGradeInformations FighterMovementInformations { get; set; }

    public required bool InMain { get; set; }

    public PrismFightDefenderAddMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(FightId);
        FighterMovementInformations.Serialize(writer);
        writer.WriteBoolean(InMain);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadDouble();
        FighterMovementInformations = new CharacterMinimalPlusLookAndGradeInformations();
        FighterMovementInformations.Deserialize(reader);
        InMain = reader.ReadBoolean();
    }
}