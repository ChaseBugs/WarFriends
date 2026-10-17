using System.Net;

namespace War.Infrastructure;

/// <summary>Identifies only an exact Worker refusal saying that no registration exists.</summary>
public sealed class BattleMatchNotRegisteredException : HttpRequestException
{
    /// <summary>Keeps HTTP conflict compatibility while permitting bounded registration recovery.</summary>
    public BattleMatchNotRegisteredException()
        : base("Worker match is not registered.", null, HttpStatusCode.Conflict)
    {
    }
}
