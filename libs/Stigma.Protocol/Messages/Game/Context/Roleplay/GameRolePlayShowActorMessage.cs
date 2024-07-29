using Stigma.Protocol.Types.Game.Context.Roleplay;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class GameRolePlayShowActorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5632;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required GameRolePlayActorInformations Informations { get; set; }

    public GameRolePlayShowActorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(Informations.ProtocolId);
        Informations.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Informations = DofusTypeFactory.CreateInstance<GameRolePlayActorInformations>(reader.ReadUInt16());
        Informations.Deserialize(reader);
    }
}