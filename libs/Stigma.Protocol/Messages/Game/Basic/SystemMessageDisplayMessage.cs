namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class SystemMessageDisplayMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 189;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool HangUp { get; set; }

    public required short MsgId { get; set; }

    public required IEnumerable<string> Parameters { get; set; }

    public SystemMessageDisplayMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(HangUp);
        writer.WriteInt16(MsgId);
        var parametersBefore = writer.Position;
        var parametersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Parameters)
        {
            writer.WriteUtf(item);
            parametersCount++;
        }

        var parametersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, parametersBefore);
        writer.WriteInt16((short)parametersCount);
        writer.Seek(SeekOrigin.Begin, parametersAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        HangUp = reader.ReadBoolean();
        MsgId = reader.ReadInt16();
        var parametersCount = reader.ReadInt16();
        var parameters = new string[parametersCount];
        for (var i = 0; i < parametersCount; i++) parameters[i] = reader.ReadUtf();
        Parameters = parameters;
    }
}