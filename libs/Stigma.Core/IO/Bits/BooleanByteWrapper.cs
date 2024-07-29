namespace Stigma.Core.IO.Bits;

public static class BooleanByteWrapper
{
    public static byte SetFlag(byte flag, byte offset, bool value)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(offset, 8, nameof(offset));

        return value ? (byte)(flag | (1 << offset)) : (byte)(flag & (byte.MaxValue - (1 << offset)));
    }

    public static bool GetFlag(byte flag, byte offset)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(offset, 8, nameof(offset));

        return (flag & (byte)(1 << offset)) is not 0;
    }
}