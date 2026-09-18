using Google.Protobuf;
using War.Persistence;
using War.Protocol;

namespace War.Backend;

public static class HttpProtocol
{
    public static IResult Proto(IMessage message) => new ProtobufResult(message, 200);
    public static IResult Error(int status, string code, string message) => new ProtobufResult(new ErrorResponse { Code = code, Message = message }, status);
    public static async Task<T> Read<T>(HttpContext context, MessageParser<T> parser) where T : IMessage<T>
    {
        if (context.Request.ContentType?.Split(';')[0].Trim() != "application/x-protobuf") throw new BadHttpRequestException("Protobuf content type required.", 415);
        using var memory = new MemoryStream();
        await context.Request.Body.CopyToAsync(memory, context.RequestAborted);
        if (memory.Length > 65536) throw new BadHttpRequestException("Body too large.", 413);
        return parser.ParseFrom(memory.ToArray());
    }
    public static Task<PlayerProfile?> Player(HttpContext ctx, AccountStore store)
    {
        string header = ctx.Request.Headers.Authorization.ToString();
        return store.Authenticate(header.StartsWith("Bearer ", StringComparison.Ordinal) ? header[7..] : "", ctx.RequestAborted);
    }
    private sealed record ProtobufResult(IMessage Message, int Status) : IResult
    {
        public async Task ExecuteAsync(HttpContext context)
        {
            context.Response.StatusCode = Status;
            context.Response.ContentType = "application/x-protobuf";
            context.Response.Headers.CacheControl = "no-store";
            await context.Response.Body.WriteAsync(Message.ToByteArray(), context.RequestAborted);
        }
    }
}
