using War.Persistence;

namespace War.Backend.Legacy.Dispatch;

/// <summary>The dispatcher needs session lookup, not access to gameplay mutations.</summary>
public interface ILegacySessionAuthentication
{
    Task<LegacyPlayerDocument?> AuthenticateAsync(LegacyRequest request, CancellationToken cancellationToken);
}
