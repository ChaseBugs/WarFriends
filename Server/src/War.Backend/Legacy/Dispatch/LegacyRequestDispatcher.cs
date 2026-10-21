using War.Persistence;

namespace War.Backend.Legacy.Dispatch;

/// <summary>Owns the session boundary; feature handlers never decide whether to bypass it.</summary>
public sealed class LegacyRequestDispatcher
{
    private readonly LegacyActionRegistry _registry;
    private readonly ILegacySessionAuthentication _authentication;
    private readonly ILogger<LegacyRequestDispatcher> _logger;

    public LegacyRequestDispatcher(LegacyActionRegistry registry, ILegacySessionAuthentication authentication,
        ILogger<LegacyRequestDispatcher> logger)
    {
        _registry = registry;
        _authentication = authentication;
        _logger = logger;
    }

    public async Task<IResult> DispatchAsync(LegacyRequest request, CancellationToken cancellationToken)
    {
        LegacyActionRegistration registration = _registry.Get(request.Action);
        if (registration.AnonymousHandler != null)
        {
            return await registration.AnonymousHandler(request, cancellationToken);
        }

        LegacyPlayerDocument? player;
        try
        {
            player = await _authentication.AuthenticateAsync(request, cancellationToken);
        }
        catch (InvalidDataException exception)
        {
            _logger.LogError(exception, "Refused invalid stored legacy authentication authority.");
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }

        if (player == null)
        {
            return LegacyResponse.Failure(DatabaseResult.InvalidToken);
        }

        if (registration.SessionHandler != null)
        {
            return await registration.SessionHandler(request, player, cancellationToken);
        }

        // Buffered-only operations cannot bypass the receipt, transaction and rollback protocol.
        _logger.LogWarning("Legacy action {Action} ({Id}) is closed on the direct HTTP channel.",
            request.Action, (int)request.Action);
        return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
    }
}
