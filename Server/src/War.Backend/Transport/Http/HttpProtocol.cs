using Google.Protobuf;
using War.Backend.Transport.Http;
using War.Protocol;

namespace War.Backend;

public static class HttpProtocol
{
    public static IResult Proto(IMessage message) => new ProtobufResult(message, 200);
    public static IResult Error(int status, string code, string message) => new ProtobufResult(new ErrorResponse { Code = code, Message = message }, status);
    public static async Task<T> Read<T>(HttpContext context, MessageParser<T> parser) where T : IMessage<T>
    {
        if (context.Request.ContentType?.Split(';')[0].Trim() != "application/x-protobuf") throw new BadHttpRequestException("Protobuf content type required.", 415);
        byte[] body = await BoundedHttpBody.ReadAsync(context, BackendHttpPolicy.MaximumRequestBodyBytes);
        return parser.ParseFrom(body);
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
