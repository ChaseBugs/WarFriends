/// <summary>Runs original atlas loaders without starting unrelated account-boot atlas work.</summary>
public sealed class AbortAtlasPreparerProbe : AtlasPreparer
{
    protected override void Awake()
    {
        // The disposable audit starts only the original game-atlas loader explicitly.
    }
}
