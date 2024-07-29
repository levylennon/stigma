using Stigma.Protocol.Types.Game.Paddock;

namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class GameDataPaddockObjectAddMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5990;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required PaddockItem PaddockItemDescription { get; set; }

    public GameDataPaddockObjectAddMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        PaddockItemDescription.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PaddockItemDescription = new PaddockItem();
        PaddockItemDescription.Deserialize(reader);
    }
}