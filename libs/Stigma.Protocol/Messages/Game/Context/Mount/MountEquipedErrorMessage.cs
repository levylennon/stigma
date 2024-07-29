namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountEquipedErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5963;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte ErrorType { get; set; }

    public MountEquipedErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(ErrorType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ErrorType = reader.ReadInt8();
    }
}