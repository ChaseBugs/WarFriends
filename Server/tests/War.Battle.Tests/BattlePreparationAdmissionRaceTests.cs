using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using War.Backend;
using War.Backend.Legacy;
using War.Persistence;
using War.Shared;

/// <summary>Forces normal queue admission to compete with a preparation transaction holding the shared fence.</summary>
internal static class BattlePreparationAdmissionRaceTests
{
    private const int GateDeadlineSeconds = 10;

    internal static async Task RunMongoAsync(string uri, string databaseName)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        CancellationToken cancellationToken = deadline.Token;
        LegacyPlayerDocument player = CreatePlayer();
        var players = new LegacyPlayerStore(uri, databaseName);
        await players.Insert(player, LegacyPlayerStore.NewPassword(), cancellationToken);
        var attempted = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ClusterConfigurator = cluster => cluster.Subscribe<CommandStartedEvent>(command =>
        {
            if (command.CommandName == "insert" && command.Command["insert"] == "battle_admission_fences")
            {
                attempted.TrySetResult(true);
            }
        });
        var queue = new BattleMatchQueueStore(new MongoClient(settings).GetDatabase(databaseName));
        await queue.Initialize(cancellationToken);
        var observed = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var release = new ManualResetEventSlim();
        var preparation = new BattleAllocationPreparationStore(uri, databaseName);
        Task preparing = Task.Run(() => preparation.PrepareAsync(player.Id, player.Revision, snapshot =>
        {
            BattleAllocationProjection allocation = BattleAllocationSource.Project(snapshot);
            observed.TrySetResult(true);
            if (!release.Wait(TimeSpan.FromSeconds(GateDeadlineSeconds), cancellationToken))
            {
                throw new TimeoutException("The preparation/admission gate was not released.");
            }
            return allocation;
        }, cancellationToken), cancellationToken);

        Task<BattlePairingResult>? admission = null;
        try
        {
            await observed.Task.WaitAsync(TimeSpan.FromSeconds(GateDeadlineSeconds), cancellationToken);
            admission = queue.Join(player.Id, "preparation-admission-race.fixture",
                DateTimeOffset.UtcNow, cancellationToken);
            await attempted.Task.WaitAsync(TimeSpan.FromSeconds(GateDeadlineSeconds), cancellationToken);
            bool hasTicket = await new MongoClient(uri).GetDatabase(databaseName)
                .GetCollection<BattleQueueTicketDocument>("battle_queue_tickets")
                .Find(ticket => ticket.PlayerId == player.Id).AnyAsync(cancellationToken);
            Require(!hasTicket && !admission.IsCompleted, "Queue admission bypassed in-flight allocation preparation.");
        }
        finally
        {
            release.Set();
        }
        await preparing;
        Require(admission != null && (await admission).Code == "waiting",
            "Queue admission did not resume after allocation preparation committed.");
        LegacyPlayerDocument current = await players.ById(player.Id, cancellationToken)
            ?? throw new InvalidDataException("The admission race account disappeared.");
        var saved = await new BattleAllocationStore(uri, databaseName).Get(player.Id, cancellationToken)
            ?? throw new InvalidDataException("Queue admission completed without prepared allocation authority.");
        BattleAllocationSource.ValidateMatchesAccount(current, saved);
        BattlePairingResult cancelled = await queue.CancelWithPairAsync(
            player.Id, DateTimeOffset.UtcNow, cancellationToken);
        Require(cancelled.Code == "cancelled",
            "The admission race waiting ticket was not cleaned up.");
        Console.WriteLine("PASS: actual queue admission waits for preparation fence and resumes with current allocation");
    }

    private static LegacyPlayerDocument CreatePlayer()
    {
        return new LegacyPlayerDocument
        {
            Id = Guid.NewGuid().ToString("N"), Name = "PreparationAdmissionRace", Locale = "en", Country = "US",
            Level = 1, CreatedUtc = DateTime.UtcNow,
            SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()),
            SessionExpiresUtc = DateTime.UtcNow.AddHours(1), Serialized = LegacyInitialLoadout.CreateSerializedState()
        };
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
