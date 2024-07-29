using System.Buffers;
using System.Buffers.Binary;
using System.Text;

namespace Stigma.Core.IO.Binary;

public sealed class BigEndianWriter : IDisposable
{
    private byte[] _buffer = [];
    private bool _isBufferRented;
    private int _position;

    public int MaxPosition { get; private set; }

    public int Length =>
        _buffer.Length;

    public int Position
    {
        get => _position;
        private set
        {
            _position = value;

            if (MaxPosition < value)
                MaxPosition = value;
        }
    }

    public int BytesAvailable =>
        Length - Position;

    public Memory<byte> BufferAsMemory =>
        _buffer.AsMemory(0, MaxPosition);

    public Span<byte> BufferAsSpan =>
        _buffer.AsSpan(0, MaxPosition);

    public byte[] BufferAsArray =>
        _buffer.AsSpan(0, MaxPosition).ToArray();

    public void Dispose()
    {
        if (_isBufferRented)
        {
            ArrayPool<byte>.Shared.Return(_buffer);
            _isBufferRented = false;
        }
    }

    public void WriteUInt8(byte value)
    {
        GetSpan(sizeof(byte))[0] = value;
    }

    public void WriteInt8(sbyte value)
    {
        GetSpan(sizeof(sbyte))[0] = (byte)value;
    }

    public void WriteBoolean(bool value)
    {
        GetSpan(sizeof(bool))[0] = (byte)(value ? 1 : 0);
    }

    public void WriteUInt16(ushort value)
    {
        BinaryPrimitives.WriteUInt16BigEndian(GetSpan(sizeof(ushort)), value);
    }

    public void WriteInt16(short value)
    {
        BinaryPrimitives.WriteInt16BigEndian(GetSpan(sizeof(short)), value);
    }

    public void WriteUInt32(uint value)
    {
        BinaryPrimitives.WriteUInt32BigEndian(GetSpan(sizeof(uint)), value);
    }

    public void WriteInt32(int value)
    {
        BinaryPrimitives.WriteInt32BigEndian(GetSpan(sizeof(int)), value);
    }

    public void WriteUInt64(ulong value)
    {
        BinaryPrimitives.WriteUInt64BigEndian(GetSpan(sizeof(ulong)), value);
    }

    public void WriteInt64(long value)
    {
        BinaryPrimitives.WriteInt64BigEndian(GetSpan(sizeof(long)), value);
    }

    public void WriteFloat(float value)
    {
        BinaryPrimitives.WriteSingleBigEndian(GetSpan(sizeof(float)), value);
    }

    public void WriteDouble(double value)
    {
        BinaryPrimitives.WriteDoubleBigEndian(GetSpan(sizeof(double)), value);
    }

    public void WriteMemory(Memory<byte> value)
    {
        WriteSpan(value.Span);
    }

    public void WriteSpan(Span<byte> value)
    {
        value.CopyTo(GetSpan(value.Length));
    }

    public void WriteBytes(byte[] value)
    {
        WriteSpan(value);
    }

    public void WriteUtfBytes(string value)
    {
        WriteSpan(Encoding.UTF8.GetBytes(value));
    }

    public void WriteUtf(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        WriteUInt16((ushort)bytes.Length);
        WriteSpan(bytes);
    }

    public void WriteBigUtf(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        WriteInt32(bytes.Length);
        WriteSpan(bytes);
    }

    public void Seek(SeekOrigin origin, int offset)
    {
        switch (origin)
        {
            case SeekOrigin.Begin:
                CheckAndResizeBuffer(offset, offset);
                Position = offset;
                break;
            case SeekOrigin.Current:
                CheckAndResizeBuffer(offset);
                Position += offset;
                break;
            case SeekOrigin.End:
                Position = Length - Math.Abs(offset);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(origin));
        }
    }

    private Span<byte> GetSpan(int count)
    {
        CheckAndResizeBuffer(count);

        var span = _buffer.AsSpan(Position, count);

        Position += count;

        return span;
    }

    private void CheckAndResizeBuffer(int count, int? position = null)
    {
        position ??= Position;

        var bytesAvailable = Length - position.Value;

        if (count <= bytesAvailable)
            return;

        var currentCount = Length;
        var growBy = Math.Max(count, currentCount);

        if (count is 0)
            growBy = Math.Max(growBy, 256);

        var newCount = currentCount + growBy;

        if ((uint)newCount > int.MaxValue)
        {
            var needed = (uint)(currentCount - bytesAvailable + count);

            if (needed > Array.MaxLength)
                throw new OutOfMemoryException("The requested operation would exceed the maximum array length.");

            newCount = Array.MaxLength;
        }

        var newArray = ArrayPool<byte>.Shared.Rent(newCount);
        Array.Copy(_buffer, newArray, _buffer.Length);

        if (_isBufferRented)
            ArrayPool<byte>.Shared.Return(_buffer);

        _buffer = newArray;
        _isBufferRented = true;
    }

    public ReadOnlyMemory<byte> GetBufferAsMemory(int length)
    {
        return _buffer.AsMemory(0, length);
    }

    public ReadOnlySpan<byte> GetBufferAsSpan(int length)
    {
        return _buffer.AsSpan(0, length);
    }

    public byte[] GetBufferAsArray(int length)
    {
        return _buffer.AsSpan(0, length).ToArray();
    }
}