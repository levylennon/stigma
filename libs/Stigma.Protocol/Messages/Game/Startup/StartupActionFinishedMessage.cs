namespace Stigma.Protocol.Messages.Game.Startup;

public sealed class StartupActionFinishedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1304;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Success { get; set; }

    public required bool AutomaticAction { get; set; }

    public required int ActionId { get; set; }

    public StartupActionFinishedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Success);
        flag = BooleanByteWrapper.SetFlag(flag, 1, AutomaticAction);
        writer.WriteUInt8(flag);
        writer.WriteInt32(ActionId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var flag = reader.ReadUInt8();
        Success = BooleanByteWrapper.GetFlag(flag, 0);
        AutomaticAction = BooleanByteWrapper.GetFlag(flag, 1);
        ActionId = reader.ReadInt32();
    }
}