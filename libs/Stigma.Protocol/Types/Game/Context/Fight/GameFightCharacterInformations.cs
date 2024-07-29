using Stigma.Protocol.Types.Game.Character.Alignment;

namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class GameFightCharacterInformations : GameFightFighterNamedInformations
{
    public new const ushort ProtocolTypeId = 46;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short Level { get; set; }

    public ActorAlignmentInformations AlignmentInfos { get; set; }

    public GameFightCharacterInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(Level);
        AlignmentInfos.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Level = reader.ReadInt16();
        AlignmentInfos = new ActorAlignmentInformations();
        AlignmentInfos.Deserialize(reader);
    }
}