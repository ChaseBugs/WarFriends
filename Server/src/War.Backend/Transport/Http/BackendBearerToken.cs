namespace War.Backend.Transport.Http;

public static class BackendBearerToken
{
    private const string Prefix = "Bearer ";

    public static string Read(HttpContext context)
    {
        string header = context.Request.Headers.Authorization.ToString();
        return header.StartsWith(Prefix, StringComparison.Ordinal) ? header[Prefix.Length..] : "";
    }
}
