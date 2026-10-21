using System.Buffers;

namespace War.Infrastructure;

/// <summary>Reads a caller-owned budget and at most one excess byte; overflow has no retained result.</summary>
public static class BoundedStreamReader
{
    private const int ReadBufferBytes = 8192;

    public static async Task<byte[]?> ReadAsync(Stream stream, int maximumBytes, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(stream);
        if (maximumBytes is < 1 or int.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumBytes));
        }

        using var memory = new MemoryStream();
        byte[] buffer = ArrayPool<byte>.Shared.Rent(ReadBufferBytes);
        try
        {
            while (true)
            {
                int remaining = maximumBytes + 1 - (int)memory.Length;
                int read = await stream.ReadAsync(buffer.AsMemory(0, Math.Min(ReadBufferBytes, remaining)),
                    cancellationToken);
                if (read == 0)
                {
                    return memory.ToArray();
                }
                if (memory.Length + read > maximumBytes)
                {
                    return null;
                }
                memory.Write(buffer, 0, read);
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer, clearArray: true);
        }
    }
}
