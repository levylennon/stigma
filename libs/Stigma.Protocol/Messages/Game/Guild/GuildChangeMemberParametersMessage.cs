namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildChangeMemberParametersMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5549;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MemberId { get; set; }

    public required short Rank { get; set; }

    public required sbyte ExperienceGivenPercent { get; set; }

    public required uint Rights { get; set; }

    public GuildChangeMemberParametersMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(MemberId);
        writer.WriteInt16(Rank);
        writer.WriteInt8(ExperienceGivenPercent);
        writer.WriteUInt32(Rights);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MemberId = reader.ReadInt32();
        Rank = reader.ReadInt16();
        ExperienceGivenPercent = reader.ReadInt8();
        Rights = reader.ReadUInt32();
    }
}