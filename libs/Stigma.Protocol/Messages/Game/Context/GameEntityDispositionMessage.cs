using Stigma.Protocol.Types.Game.Context;

namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameEntityDispositionMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5693;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IdentifiedEntityDispositionInformations Disposition { get; set; }

    public GameEntityDispositionMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Disposition.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Disposition = new IdentifiedEntityDispositionInformations();
        Disposition.Deserialize(reader);
    }
}