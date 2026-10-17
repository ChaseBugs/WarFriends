/// <summary>Uses the actual recovery methods without unrelated account boot in the disposable audit.</summary>
public sealed class AbortRecoveryControllerProbe : GameController
{
    protected override void Awake()
    {
        // The controlled audit binds its source managers explicitly instead of starting account login.
    }
}
