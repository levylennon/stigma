using Stigma.Protocol.Types.Game.Startup;

namespace Stigma.Protocol.Messages.Game.Startup;

public sealed class StartupActionsListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1301;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<StartupActionAddObject> Actions { get; set; }

    public StartupActionsListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var actionsBefore = writer.Position;
        var actionsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Actions)
        {
            item.Serialize(writer);
            actionsCount++;
        }

        var actionsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, actionsBefore);
        writer.WriteInt16((short)actionsCount);
        writer.Seek(SeekOrigin.Begin, actionsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var actionsCount = reader.ReadInt16();
        var actions = new StartupActionAddObject[actionsCount];
        for (var i = 0; i < actionsCount; i++)
        {
            var entry = new StartupActionAddObject();
            entry.Deserialize(reader);
            actions[i] = entry;
        }

        Actions = actions;
    }
}