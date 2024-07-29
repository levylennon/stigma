namespace Stigma.Protocol.Messages.Game.Character.Replay;

public sealed class CharacterReplayWithRenameRequestMessage : CharacterReplayRequestMessage
{
    public new const uint ProtocolMessageId = 6122;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public CharacterReplayWithRenameRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(Name);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUtf();
    }
}