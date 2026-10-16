namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const int MaximumDiagnosticFlights = 64;
    private const int MaximumDiagnosticResults = 64;
    private readonly Dictionary<ulong, CoopInfantryRoundIntent> _diagnosticRoundOrigins = [];

    internal int DiagnosticRoundOriginCount => _diagnosticRoundOrigins.Count;

    internal CoopInfantryRoundIntent? DiagnosticRoundOrigin(ulong projectileId)
    {
        return _diagnosticRoundOrigins.GetValueOrDefault(projectileId);
    }

    private CoopInfantryRoundIntent? FindDiagnosticRound(CoopDiagnosticFlightResult result)
    {
        CoopInfantryRoundIntent? round = DiagnosticRoundOrigin(result.ProjectileId);
        return round?.EnemyEntityId == result.EnemyEntityId ? round : null;
    }
}
