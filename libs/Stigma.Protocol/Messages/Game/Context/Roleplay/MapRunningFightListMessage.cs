using Stigma.Protocol.Types.Game.Context.Fight;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class MapRunningFightListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5743;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<FightExternalInformations> Fights { get; set; }

    public MapRunningFightListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var fightsBefore = writer.Position;
        var fightsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Fights)
        {
            item.Serialize(writer);
            fightsCount++;
        }

        var fightsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, fightsBefore);
        writer.WriteInt16((short)fightsCount);
        writer.Seek(SeekOrigin.Begin, fightsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var fightsCount = reader.ReadInt16();
        var fights = new FightExternalInformations[fightsCount];
        for (var i = 0; i < fightsCount; i++)
        {
            var entry = new FightExternalInformations();
            entry.Deserialize(reader);
            fights[i] = entry;
        }

        Fights = fights;
    }
}