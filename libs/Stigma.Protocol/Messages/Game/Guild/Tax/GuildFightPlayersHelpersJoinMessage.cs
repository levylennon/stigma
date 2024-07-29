using Stigma.Protocol.Types.Game.Character;

namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class GuildFightPlayersHelpersJoinMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5720;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double FightId { get; set; }

    public required CharacterMinimalPlusLookInformations PlayerInfo { get; set; }

    public GuildFightPlayersHelpersJoinMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(FightId);
        PlayerInfo.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadDouble();
        PlayerInfo = new CharacterMinimalPlusLookInformations();
        PlayerInfo.Deserialize(reader);
    }
}