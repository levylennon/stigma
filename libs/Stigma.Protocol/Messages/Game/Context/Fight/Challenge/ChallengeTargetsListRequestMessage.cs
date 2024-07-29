namespace Stigma.Protocol.Messages.Game.Context.Fight.Challenge;

public sealed class ChallengeTargetsListRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5614;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte ChallengeId { get; set; }

    public ChallengeTargetsListRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(ChallengeId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ChallengeId = reader.ReadInt8();
    }
}