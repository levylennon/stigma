using Stigma.Protocol.Types.Game.Character.Choice;

namespace Stigma.Protocol.Messages.Game.Character.Choice;

public sealed class CharacterSelectedSuccessMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 153;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required CharacterBaseInformations Infos { get; set; }

    public CharacterSelectedSuccessMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Infos.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Infos = new CharacterBaseInformations();
        Infos.Deserialize(reader);
    }
}