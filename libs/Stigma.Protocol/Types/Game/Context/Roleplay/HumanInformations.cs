using Stigma.Protocol.Types.Game.Character.Restriction;
using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public class HumanInformations : DofusType
{
    public new const ushort ProtocolTypeId = 157;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public IEnumerable<EntityLook> FollowingCharactersLook { get; set; }

    public sbyte EmoteId { get; set; }

    public ushort EmoteEndTime { get; set; }

    public ActorRestrictionsInformations Restrictions { get; set; }

    public short TitleId { get; set; }

    public HumanInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var followingCharactersLookBefore = writer.Position;
        var followingCharactersLookCount = 0;
        writer.WriteInt16(0);
        foreach (var item in FollowingCharactersLook)
        {
            item.Serialize(writer);
            followingCharactersLookCount++;
        }

        var followingCharactersLookAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, followingCharactersLookBefore);
        writer.WriteInt16((short)followingCharactersLookCount);
        writer.Seek(SeekOrigin.Begin, followingCharactersLookAfter);
        writer.WriteInt8(EmoteId);
        writer.WriteUInt16(EmoteEndTime);
        Restrictions.Serialize(writer);
        writer.WriteInt16(TitleId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var followingCharactersLookCount = reader.ReadInt16();
        var followingCharactersLook = new EntityLook[followingCharactersLookCount];
        for (var i = 0; i < followingCharactersLookCount; i++)
        {
            var entry = new EntityLook();
            entry.Deserialize(reader);
            followingCharactersLook[i] = entry;
        }

        FollowingCharactersLook = followingCharactersLook;
        EmoteId = reader.ReadInt8();
        EmoteEndTime = reader.ReadUInt16();
        Restrictions = new ActorRestrictionsInformations();
        Restrictions.Deserialize(reader);
        TitleId = reader.ReadInt16();
    }
}