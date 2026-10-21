namespace War.Backend.Legacy.Dispatch.Composition;

/// <summary>The sole dependency-composition boundary for the legacy action graph.</summary>
public static class LegacyActionComposition
{
    public static LegacyActionRegistry Create(IServiceProvider services)
    {
        var actions = new List<LegacyActionRegistration>();
        actions.AddRange(LegacyAccountActions.Create(services));
        actions.AddRange(LegacyPlayerActions.Create(services));
        actions.AddRange(LegacyCardActions.Create(services));
        actions.AddRange(LegacySquadActions.Create(services));
        actions.AddRange(LegacyBattleActions.Create(services));
        actions.AddRange(LegacyDiagnosticActions.Create(services));
        actions.AddRange(LegacyBufferActions.Create(services));
        actions.AddRange(LegacyUnavailableActions.BufferedOnly());
        actions.AddRange(LegacyUnavailableActions.Closed());
        return new LegacyActionRegistry(actions);
    }
}
