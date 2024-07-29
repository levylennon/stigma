using System.Buffers.Binary;
using System.Text;

namespace Stigma.Core.IO.Binary;

public sealed class BigEndianReader
{
    private readonly ReadOnlyMemory<byte> _buffer;

    public int Length =>
        _buffer.Length;

    public int Position { get; private set; }

    public int BytesAvailable =>
        Length - Position;

    public BigEndianReader(ReadOnlyMemory<byte> buffer)
    {
        _buffer = buffer;
    }

    public byte ReadUInt8()
    {
        return ReadSpan(sizeof(byte))[0];
    }

    public sbyte ReadInt8()
    {
        return (sbyte)ReadSpan(sizeof(byte))[0];
    }

    public bool ReadBoolean()
    {
        return ReadSpan(sizeof(byte))[0] is not 0;
    }

    public ushort ReadUInt16()
    {
        return BinaryPrimitives.ReadUInt16BigEndian(ReadSpan(sizeof(ushort)));
    }

    public short ReadInt16()
    {
        return BinaryPrimitives.ReadInt16BigEndian(ReadSpan(sizeof(short)));
    }

    public uint ReadUInt32()
    {
        return BinaryPrimitives.ReadUInt32BigEndian(ReadSpan(sizeof(uint)));
    }

    public int ReadInt32()
    {
        return BinaryPrimitives.ReadInt32BigEndian(ReadSpan(sizeof(int)));
    }

    public ulong ReadUInt64()
    {
        return BinaryPrimitives.ReadUInt64BigEndian(ReadSpan(sizeof(ulong)));
    }

    public long ReadInt64()
    {
        return BinaryPrimitives.ReadInt64BigEndian(ReadSpan(sizeof(long)));
    }

    public float ReadFloat()
    {
        return BinaryPrimitives.ReadSingleBigEndian(ReadSpan(sizeof(float)));
    }

    public double ReadDouble()
    {
        return BinaryPrimitives.ReadDoubleBigEndian(ReadSpan(sizeof(double)));
    }

    public ReadOnlyMemory<byte> ReadMemory(int count)
    {
        var memory = _buffer.Slice(Position, count);
        Position += count;
        return memory;
    }

    public ReadOnlyMemory<byte> ReadMemoryToEnd()
    {
        var memory = _buffer[Position..];
        Position = _buffer.Length;
        return memory;
    }

    public ReadOnlySpan<byte> ReadSpan(int count)
    {
        var span = _buffer.Span.Slice(Position, count);
        Position += count;
        return span;
    }

    public ReadOnlySpan<byte> ReadSpanToEnd()
    {
        var span = _buffer.Span[Position..];
        Position = _buffer.Length;
        return span;
    }

    public byte[] ReadBytes(int count)
    {
        var bytes = _buffer.Slice(Position, count).ToArray();
        Position += count;
        return bytes;
    }

    public byte[] ReadBytesToEnd()
    {
        var bytes = _buffer[Position..].ToArray();
        Position = _buffer.Length;
        return bytes;
    }

    public string ReadUtfBytes(int count)
    {
        return Encoding.UTF8.GetString(ReadSpan(count));
    }

    public string ReadUtf()
    {
        return ReadUtfBytes(ReadUInt16());
    }

    public string ReadBigUtf()
    {
        return ReadUtfBytes(ReadInt32());
    }

    public void Seek(SeekOrigin origin, int offset)
    {
        Position = origin switch
        {
            SeekOrigin.Begin => offset,
            SeekOrigin.Current => Position + offset,
            SeekOrigin.End => _buffer.Length - Math.Abs(offset),
            _ => throw new ArgumentOutOfRangeException(nameof(origin))
        };
    }
}