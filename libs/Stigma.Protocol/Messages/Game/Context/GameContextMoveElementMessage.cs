using Stigma.Protocol.Types.Game.Context;

namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextMoveElementMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 253;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required EntityMovementInformations Movement { get; set; }

    public GameContextMoveElementMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Movement.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Movement = new EntityMovementInformations();
        Movement.Deserialize(reader);
    }
}