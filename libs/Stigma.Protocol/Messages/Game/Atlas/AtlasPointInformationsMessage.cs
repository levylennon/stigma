using Stigma.Protocol.Types.Game.Context.Roleplay;

namespace Stigma.Protocol.Messages.Game.Atlas;

public sealed class AtlasPointInformationsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5956;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required AtlasPointsInformations Type { get; set; }

    public AtlasPointInformationsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Type.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Type = new AtlasPointsInformations();
        Type.Deserialize(reader);
    }
}