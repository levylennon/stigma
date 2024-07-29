namespace Stigma.Protocol.Types.Connection;

public sealed class GameServerInformations : DofusType
{
    public new const ushort ProtocolTypeId = 25;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public ushort Id { get; set; }

    public sbyte Status { get; set; }

    public sbyte Completion { get; set; }

    public bool IsSelectable { get; set; }

    public sbyte CharactersCount { get; set; }

    public GameServerInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(Id);
        writer.WriteInt8(Status);
        writer.WriteInt8(Completion);
        writer.WriteBoolean(IsSelectable);
        writer.WriteInt8(CharactersCount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadUInt16();
        Status = reader.ReadInt8();
        Completion = reader.ReadInt8();
        IsSelectable = reader.ReadBoolean();
        CharactersCount = reader.ReadInt8();
    }
}