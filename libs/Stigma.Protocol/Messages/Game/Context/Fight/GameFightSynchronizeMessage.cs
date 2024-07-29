using Stigma.Protocol.Types.Game.Context.Fight;

namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightSynchronizeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5921;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<GameFightFighterInformations> Fighters { get; set; }

    public GameFightSynchronizeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var fightersBefore = writer.Position;
        var fightersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Fighters)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            fightersCount++;
        }

        var fightersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, fightersBefore);
        writer.WriteInt16((short)fightersCount);
        writer.Seek(SeekOrigin.Begin, fightersAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var fightersCount = reader.ReadInt16();
        var fighters = new GameFightFighterInformations[fightersCount];
        for (var i = 0; i < fightersCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<GameFightFighterInformations>(reader.ReadUInt16());
            entry.Deserialize(reader);
            fighters[i] = entry;
        }

        Fighters = fighters;
    }
}