namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildCreationResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5554;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Result { get; set; }

    public GuildCreationResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Result);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Result = reader.ReadInt8();
    }
}