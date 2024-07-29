using Stigma.Protocol.Messages.Game.Context.Roleplay.Lockable;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses;

public sealed class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
{
    public new const uint ProtocolMessageId = 5885;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public HouseLockFromInsideRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
    }
}