using Stigma.Protocol.Types.Game.Context.Fight;

namespace Stigma.Protocol.Messages.Game.Context.Fight.Character;

public sealed class GameFightShowFighterMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5864;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required GameFightFighterInformations Informations { get; set; }

    public GameFightShowFighterMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(Informations.ProtocolId);
        Informations.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Informations = DofusTypeFactory.CreateInstance<GameFightFighterInformations>(reader.ReadUInt16());
        Informations.Deserialize(reader);
    }
}