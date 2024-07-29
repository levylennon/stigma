using Stigma.Protocol.Types.Game.Prism;

namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismAlignmentBonusResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5842;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required AlignmentBonusInformations AlignmentBonus { get; set; }

    public PrismAlignmentBonusResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        AlignmentBonus.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        AlignmentBonus = new AlignmentBonusInformations();
        AlignmentBonus.Deserialize(reader);
    }
}