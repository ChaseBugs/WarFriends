using War.Backend.Hosting.Configuration;
using War.Infrastructure;

namespace War.Backend.Transport.Http;

/// <summary>Adapts captured Backend identity and HTTP headers to the shared control MAC policy.</summary>
public sealed class BattleControlAuthenticator
{
    private readonly ControlRequestAuthenticator _authentication;

    public BattleControlAuthenticator(BackendBattleOptions deployment, TimeProvider time)
    {
        _authentication = new ControlRequestAuthenticator(deployment.Keys.ControlKey!, time);
        ServerId = deployment.ServerId;
    }

    public string ServerId { get; }

    public bool IsAuthorized(HttpContext context, byte[] body, string domain)
    {
        return _authentication.IsAuthorized(context.Request.Headers["X-War-Control-Time"].ToString(),
            context.Request.Headers["X-War-Control-Mac"].ToString(), body, domain);
    }
}
