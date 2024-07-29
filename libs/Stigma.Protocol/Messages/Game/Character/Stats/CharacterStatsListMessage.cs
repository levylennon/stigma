using Stigma.Protocol.Types.Game.Character.Characteristic;

namespace Stigma.Protocol.Messages.Game.Character.Stats;

public sealed class CharacterStatsListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 500;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required CharacterCharacteristicsInformations Stats { get; set; }

    public CharacterStatsListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Stats.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Stats = new CharacterCharacteristicsInformations();
        Stats.Deserialize(reader);
    }
}