namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
{
    public new const ushort ProtocolTypeId = 154;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string Name { get; set; }

    public GameRolePlayNamedActorInformations()
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