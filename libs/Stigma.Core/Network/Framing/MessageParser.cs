using System.Diagnostics.CodeAnalysis;
using Stigma.Core.IO.Binary;
using Stigma.Core.Network.Factory;
using Stigma.Core.Network.Metadata;

namespace Stigma.Core.Network.Framing;

public sealed class MessageParser : IMessageParser
{
    private readonly IMessageFactory _messageFactory;

    public MessageParser(IMessageFactory messageFactory)
    {
        _messageFactory = messageFactory;
    }

    public bool TryDecodeMessage(ref Memory<byte> sequence, [NotNullWhen(true)] out DofusMessage? message)
    {
        message = null;

        var reader = new BigEndianReader(sequence);

        if (reader.BytesAvailable < 2)
            return false;

        var header = reader.ReadInt16();
        
        var messageId = (uint)(header >> 2);
        
        if (!_messageFactory.TryCreateInstance(messageId, out message))
            return false;
        
        var typeLength = header & 3;
        
        if (typeLength is < 0 or > 3)
            return false;
        
        if (reader.BytesAvailable < typeLength)
            return false;
        
        var payloadLength = 0;
        
        for (var i = typeLength - 1; i >= 0; i--, payloadLength++)
            typeLength |= reader.ReadUInt8() << (i * 8);
        
        if (typeLength - payloadLength > reader.BytesAvailable)
            return false;
        
        message.Deserialize(reader);
        sequence = sequence.Slice(reader.Position);
        return true;
    }

    public ReadOnlyMemory<byte> EncodeMessage(DofusMessage message)
    {
        using var payloadWriter = new BigEndianWriter();
        message.Serialize(payloadWriter);
        var payload = payloadWriter.BufferAsSpan;

        byte typeLength = payload.Length switch
        {
            > ushort.MaxValue => 3,
            > byte.MaxValue => 2,
            > 0 => 1,
            _ => 0
        };
        
        var header = (ushort)(message.ProtocolId << 2 | typeLength);

        using var writer = new BigEndianWriter();
        
        writer.WriteUInt16(header);
        
        switch (typeLength)
        {
            case 1:
                writer.WriteUInt8((byte)payload.Length);
                break;
            case 2:
                writer.WriteInt16((short)payload.Length);
                break;
            case 3:
                writer.WriteUInt8((byte)(payload.Length >> 16 & byte.MaxValue));
                writer.WriteInt16((short)(payload.Length & ushort.MaxValue));
                break;
            default:
                return writer.BufferAsMemory;
        }
        
        writer.WriteSpan(payload);
        
        return writer.BufferAsMemory;
    }
}