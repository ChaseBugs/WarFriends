namespace War.Backend.Hosting;

/// <summary>The container owns the shared control-plane client and disposes it after hosted services stop.</summary>
internal sealed class BattleControlHttpClient : IDisposable
{
    private const int TimeoutSeconds = 5;

    public BattleControlHttpClient()
    {
        Client = new HttpClient { Timeout = TimeSpan.FromSeconds(TimeoutSeconds) };
    }

    internal HttpClient Client { get; }

    public void Dispose()
    {
        Client.Dispose();
    }
}
