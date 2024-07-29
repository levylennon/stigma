using Stigma.Protocol.Types.Game.Character;

namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class GuildFightPlayersEnemiesListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5928;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double FightId { get; set; }

    public required IEnumerable<CharacterMinimalPlusLookInformations> PlayerInfo { get; set; }

    public GuildFightPlayersEnemiesListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(FightId);
        var playerInfoBefore = writer.Position;
        var playerInfoCount = 0;
        writer.WriteInt16(0);
        foreach (var item in PlayerInfo)
        {
            item.Serialize(writer);
            playerInfoCount++;
        }

        var playerInfoAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, playerInfoBefore);
        writer.WriteInt16((short)playerInfoCount);
        writer.Seek(SeekOrigin.Begin, playerInfoAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadDouble();
        var playerInfoCount = reader.ReadInt16();
        var playerInfo = new CharacterMinimalPlusLookInformations[playerInfoCount];
        for (var i = 0; i < playerInfoCount; i++)
        {
            var entry = new CharacterMinimalPlusLookInformations();
            entry.Deserialize(reader);
            playerInfo[i] = entry;
        }

        PlayerInfo = playerInfo;
    }
}