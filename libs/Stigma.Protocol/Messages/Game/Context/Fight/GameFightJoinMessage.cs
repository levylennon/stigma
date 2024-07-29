namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightJoinMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 702;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool CanBeCancelled { get; set; }

    public required bool CanSayReady { get; set; }

    public required bool IsSpectator { get; set; }

    public required bool IsFightStarted { get; set; }

    public required int TimeMaxBeforeFightStart { get; set; }

    public required sbyte FightType { get; set; }

    public GameFightJoinMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, CanBeCancelled);
        flag = BooleanByteWrapper.SetFlag(flag, 1, CanSayReady);
        flag = BooleanByteWrapper.SetFlag(flag, 2, IsSpectator);
        flag = BooleanByteWrapper.SetFlag(flag, 3, IsFightStarted);
        writer.WriteUInt8(flag);
        writer.WriteInt32(TimeMaxBeforeFightStart);
        writer.WriteInt8(FightType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var flag = reader.ReadUInt8();
        CanBeCancelled = BooleanByteWrapper.GetFlag(flag, 0);
        CanSayReady = BooleanByteWrapper.GetFlag(flag, 1);
        IsSpectator = BooleanByteWrapper.GetFlag(flag, 2);
        IsFightStarted = BooleanByteWrapper.GetFlag(flag, 3);
        TimeMaxBeforeFightStart = reader.ReadInt32();
        FightType = reader.ReadInt8();
    }
}