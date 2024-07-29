using Stigma.Protocol.Types.Game.Character.Restriction;

namespace Stigma.Protocol.Messages.Game.Initialization;

public sealed class SetCharacterRestrictionsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 170;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ActorRestrictionsInformations Restrictions { get; set; }

    public SetCharacterRestrictionsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Restrictions.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Restrictions = new ActorRestrictionsInformations();
        Restrictions.Deserialize(reader);
    }
}