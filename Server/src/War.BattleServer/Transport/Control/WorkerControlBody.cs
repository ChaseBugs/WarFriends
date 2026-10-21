using Microsoft.AspNetCore.Http;
using War.Infrastructure;

namespace War.BattleServer.Transport.Control;

internal static class WorkerControlBody
{
    internal static async Task<byte[]?> ReadAsync(HttpContext context, int maximumBytes)
    {
        if (context.Request.ContentLength > maximumBytes)
        {
            return RejectOversize(context);
        }
        byte[]? body = await BoundedStreamReader.ReadAsync(context.Request.Body, maximumBytes,
            context.RequestAborted);
        return body ?? RejectOversize(context);
    }

    private static byte[]? RejectOversize(HttpContext context)
    {
        if (context.Request.Protocol.StartsWith("HTTP/1.", StringComparison.Ordinal))
        {
            context.Response.Headers.Connection = "close";
        }
        return null;
    }
}
