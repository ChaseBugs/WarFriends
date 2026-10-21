using War.Persistence;

namespace War.Backend.Legacy.Dispatch;

/// <summary>A named owner and one channel, with a handler whose type enforces its session boundary.</summary>
public sealed class LegacyActionRegistration
{
    public DatabaseAction Action { get; }
    public LegacyActionFeature Feature { get; }
    public LegacyActionDisposition Disposition { get; }
    public Func<LegacyRequest, CancellationToken, Task<IResult>>? AnonymousHandler { get; private init; }
    public Func<LegacyRequest, LegacyPlayerDocument, CancellationToken, Task<IResult>>? SessionHandler
    {
        get;
        private init;
    }

    private LegacyActionRegistration(
        DatabaseAction action, LegacyActionFeature feature, LegacyActionDisposition disposition)
    {
        Action = action;
        Feature = feature;
        Disposition = disposition;
    }

    public static LegacyActionRegistration Anonymous(DatabaseAction action, LegacyActionFeature feature,
        Func<LegacyRequest, CancellationToken, Task<IResult>> handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        return new(action, feature, LegacyActionDisposition.Anonymous) { AnonymousHandler = handler };
    }

    public static LegacyActionRegistration Authenticated(DatabaseAction action, LegacyActionFeature feature,
        Func<LegacyRequest, LegacyPlayerDocument, CancellationToken, Task<IResult>> handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        return new(action, feature, LegacyActionDisposition.Authenticated) { SessionHandler = handler };
    }

    public static LegacyActionRegistration Buffered(DatabaseAction action, LegacyActionFeature feature)
    {
        return new(action, feature, LegacyActionDisposition.BufferedOnly);
    }

    public static LegacyActionRegistration Closed(DatabaseAction action)
    {
        return new(action, LegacyActionFeature.Unavailable, LegacyActionDisposition.Closed);
    }
}
