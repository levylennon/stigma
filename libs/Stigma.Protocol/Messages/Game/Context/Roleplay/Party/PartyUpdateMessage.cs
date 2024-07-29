using Stigma.Protocol.Types.Game.Context.Roleplay.Party;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5575;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required PartyMemberInformations MemberInformations { get; set; }

    public PartyUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        MemberInformations.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MemberInformations = new PartyMemberInformations();
        MemberInformations.Deserialize(reader);
    }
}