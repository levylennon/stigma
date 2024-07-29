namespace Stigma.Protocol.Messages.Game.Character.Stats;

public class CharacterLevelUpMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5670;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required byte NewLevel { get; set; }

    public CharacterLevelUpMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt8(NewLevel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        NewLevel = reader.ReadUInt8();
    }
}