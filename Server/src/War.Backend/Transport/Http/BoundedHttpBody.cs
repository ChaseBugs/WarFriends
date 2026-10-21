using War.Infrastructure;

namespace War.Backend.Transport.Http;

/// <summary>Applies HTTP size policy and maps shared bounded-stream overflow to the API failure path.</summary>
public static class BoundedHttpBody
{
    public static async Task<byte[]> ReadAsync(HttpContext context, int maximumBytes)
    {
        if (maximumBytes < 1 || maximumBytes > BackendHttpPolicy.MaximumSupportedBodyBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumBytes));
        }
        if (context.Request.ContentLength > maximumBytes)
        {
            throw TooLarge();
        }

        return await BoundedStreamReader.ReadAsync(context.Request.Body, maximumBytes, context.RequestAborted)
            ?? throw TooLarge();
    }

    private static BadHttpRequestException TooLarge()
    {
        return new BadHttpRequestException("Body too large.", StatusCodes.Status413PayloadTooLarge);
    }
}
