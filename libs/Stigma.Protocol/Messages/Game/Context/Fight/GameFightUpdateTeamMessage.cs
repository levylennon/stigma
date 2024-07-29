using Stigma.Protocol.Types.Game.Context.Fight;

namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightUpdateTeamMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5572;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short FightId { get; set; }

    public required FightTeamInformations Team { get; set; }

    public GameFightUpdateTeamMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(FightId);
        Team.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt16();
        Team = new FightTeamInformations();
        Team.Deserialize(reader);
    }
}