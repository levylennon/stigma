using Stigma.Protocol.Types.Game.Fight;

namespace Stigma.Protocol.Types.Game.Guild.Tax;

public sealed class TaxCollectorInformationsInWaitForHelpState : TaxCollectorInformations
{
    public new const ushort ProtocolTypeId = 166;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }

    public TaxCollectorInformationsInWaitForHelpState()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        WaitingForHelpInfo.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        WaitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
        WaitingForHelpInfo.Deserialize(reader);
    }
}