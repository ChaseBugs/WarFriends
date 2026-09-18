using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>
/// Main-thread Unity adapter for the self-hosted match protocol. It never creates
/// Photon rooms or grants rewards. Configure with a participant-specific grant
/// supplied by the trusted allocator (or the local validation harness).
/// </summary>
public sealed class SelfHostedBattleClient : MonoBehaviour
{
    public event Action<MatchSnapshot> StateReceived;
    public event Action<string> ConnectionError;
    public MatchSnapshot State { get; private set; }
    public bool IsConnected { get; private set; }
    private MatchConnection connection;
    private CancellationTokenSource lifetime;
    private bool polling;
    private float nextPoll;
    private bool destroyed;

    public async Task Connect(MatchConnectionGrant grant)
    {
        if (destroyed) throw new ObjectDisposedException(nameof(SelfHostedBattleClient));
        if (connection != null) throw new InvalidOperationException("This component already owns a match session.");
        connection = new MatchConnection(grant);
        lifetime = new CancellationTokenSource();
        var token = lifetime.Token;
        try
        {
            var reply = await connection.ConnectAsync(token);
            token.ThrowIfCancellationRequested();
            Apply(reply);
            IsConnected = true;
        }
        catch
        {
            Close();
            throw;
        }
    }

    public Task Ready() { return Execute(c => c.ReadyAsync(lifetime.Token)); }
    public Task Fire(Vector3 target) { return Execute(c => c.FireAsync(target.x, target.y, target.z, lifetime.Token)); }
    public Task Reload() { return Execute(c => c.ReloadAsync(lifetime.Token)); }
    public Task MoveCover(int direction) { return Execute(c => c.MoveCoverAsync(direction, lifetime.Token)); }
    public Task Forfeit() { return Execute(c => c.ForfeitAsync(lifetime.Token)); }
    public Task RetryPending() { return Execute(c => c.RetryPendingAsync(lifetime.Token)); }

    private async Task Execute(Func<MatchConnection, Task<MatchReply>> operation)
    {
        if (!IsConnected || connection == null) throw new InvalidOperationException("No self-hosted match is connected.");
        Apply(await operation(connection)); // Unity synchronization context owns state/events.
    }

    private async void Update()
    {
        if (!IsConnected || polling || Time.realtimeSinceStartup < nextPoll) return;
        polling = true;
        nextPoll = Time.realtimeSinceStartup + 0.1f;
        try { Apply(await connection.PollAsync(lifetime.Token)); }
        catch (OperationCanceledException) { }
        catch (Exception e)
        {
            if (IsConnected && ConnectionError != null) ConnectionError(e.Message);
        }
        finally { polling = false; }
    }

    private void Apply(MatchReply reply)
    {
        if (destroyed) return;
        // Replayed mutation responses intentionally contain their original state.
        // Do not rewind rendering when a newer poll snapshot already arrived.
        if (State != null && reply.Snapshot.ServerTick < State.ServerTick) return;
        State = reply.Snapshot.Clone();
        if (StateReceived != null) StateReceived(State.Clone());
    }

    private void OnDestroy() { destroyed = true; Close(); }
    private void Close()
    {
        IsConnected = false;
        if (lifetime != null) { lifetime.Cancel(); lifetime.Dispose(); lifetime = null; }
        if (connection != null) { connection.Dispose(); connection = null; }
    }
}
