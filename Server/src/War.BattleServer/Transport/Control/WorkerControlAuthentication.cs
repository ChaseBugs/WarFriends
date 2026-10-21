using Microsoft.AspNetCore.Http;
using War.Infrastructure;

namespace War.BattleServer.Transport.Control;

public sealed class WorkerControlAuthentication
{
    private readonly ControlRequestAuthenticator _authentication;

    public WorkerControlAuthentication(BattleKeyConfig keys, TimeProvider time)
    {
        _authentication = new ControlRequestAuthenticator(keys.ControlKey ??
            throw new InvalidDataException("Worker control authority is not configured."), time);
    }

    public bool IsAuthorized(HttpContext context, byte[] body, string domain)
    {
        return _authentication.IsAuthorized(context.Request.Headers["X-War-Control-Time"].ToString(),
            context.Request.Headers["X-War-Control-Mac"].ToString(), body, domain);
    }
}
