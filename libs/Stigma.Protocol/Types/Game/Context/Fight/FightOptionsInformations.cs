namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightOptionsInformations : DofusType
{
    public new const ushort ProtocolTypeId = 20;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public bool IsSecret { get; set; }

    public bool IsRestrictedToPartyOnly { get; set; }

    public bool IsClosed { get; set; }

    public bool IsAskingForHelp { get; set; }

    public FightOptionsInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, IsSecret);
        flag = BooleanByteWrapper.SetFlag(flag, 1, IsRestrictedToPartyOnly);
        flag = BooleanByteWrapper.SetFlag(flag, 2, IsClosed);
        flag = BooleanByteWrapper.SetFlag(flag, 3, IsAskingForHelp);
        writer.WriteUInt8(flag);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var flag = reader.ReadUInt8();
        IsSecret = BooleanByteWrapper.GetFlag(flag, 0);
        IsRestrictedToPartyOnly = BooleanByteWrapper.GetFlag(flag, 1);
        IsClosed = BooleanByteWrapper.GetFlag(flag, 2);
        IsAskingForHelp = BooleanByteWrapper.GetFlag(flag, 3);
    }
}