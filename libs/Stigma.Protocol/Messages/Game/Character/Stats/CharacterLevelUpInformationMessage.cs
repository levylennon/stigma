namespace Stigma.Protocol.Messages.Game.Character.Stats;

public sealed class CharacterLevelUpInformationMessage : CharacterLevelUpMessage
{
    public new const uint ProtocolMessageId = 6076;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public required int Id { get; set; }

    public required sbyte RelationType { get; set; }

    public CharacterLevelUpInformationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(Name);
        writer.WriteInt32(Id);
        writer.WriteInt8(RelationType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUtf();
        Id = reader.ReadInt32();
        RelationType = reader.ReadInt8();
    }
}