namespace Stigma.Protocol.Messages.Connection;

public sealed class IdentificationSuccessMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 22;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool HasRights { get; set; }

    public required bool WasAlreadyConnected { get; set; }

    public required string Nickname { get; set; }

    public required sbyte CommunityId { get; set; }

    public required string SecretQuestion { get; set; }

    public required double RemainingSubscriptionTime { get; set; }

    public IdentificationSuccessMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, HasRights);
        flag = BooleanByteWrapper.SetFlag(flag, 1, WasAlreadyConnected);
        writer.WriteUInt8(flag);
        writer.WriteUtf(Nickname);
        writer.WriteInt8(CommunityId);
        writer.WriteUtf(SecretQuestion);
        writer.WriteDouble(RemainingSubscriptionTime);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var flag = reader.ReadUInt8();
        HasRights = BooleanByteWrapper.GetFlag(flag, 0);
        WasAlreadyConnected = BooleanByteWrapper.GetFlag(flag, 1);
        Nickname = reader.ReadUtf();
        CommunityId = reader.ReadInt8();
        SecretQuestion = reader.ReadUtf();
        RemainingSubscriptionTime = reader.ReadDouble();
    }
}