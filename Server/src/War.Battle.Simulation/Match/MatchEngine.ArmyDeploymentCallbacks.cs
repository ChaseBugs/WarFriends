namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Notifies host effects before an accepted deployment creates its first entity.</summary>
    internal event Action<int, ArmyDeploymentWave>? ArmyDeploymentStarted;

    /// <summary>Notifies host effects after the deployment's final source wait has completed.</summary>
    internal event Action<int, ArmyDeploymentWave>? ArmyDeploymentFinished;

    private void PublishArmyDeploymentStarted(Player owner)
    {
        ArmyDeploymentWave wave = owner.Army?.LastAcceptedWave ??
            throw new InvalidDataException("An accepted army deployment lost its source wave.");
        ArmyDeploymentStarted?.Invoke(owner.Definition.Fraction, wave);
    }

    private void PublishArmyDeploymentFinished(Player owner)
    {
        // Advance returns generated entities before these notifications. A skipped
        // host observation must not close the window before its final entities exist.
        foreach (ArmyDeploymentWave wave in owner.Army!.CompletedWaves)
        {
            ArmyDeploymentFinished?.Invoke(owner.Definition.Fraction, wave);
        }
    }
}
