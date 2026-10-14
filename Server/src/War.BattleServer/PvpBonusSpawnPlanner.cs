using System.Numerics;

namespace War.BattleServer;

public sealed record PvpBonusSpawnDraw(float WeightedValue, int AreaOrder, Vector3 UnitPosition);
public sealed record PvpBonusSpawnContext(bool IsWarArena, bool IsFriendlyDeathMatch,
    int GoldBonusesCollected, bool FirstTwoWeaponsHaveLowAmmo);
public sealed record PvpBonusSpawnPlan(PvpBonusDelayedRequest Request,
    int SourceIndex, int PrefabIndex, int AreaColliderFileId, Vector3 Position);

/// <summary>
/// Makes a crate-spawn plan only after an accepted delay matures. The host
/// actor supplies its own draws and live analytics; no Client packet may do so.
/// This does not create a physical box or grant its reward.
/// </summary>
internal sealed class PvpBonusSpawnPlanner
{
    private readonly object gate = new();
    private readonly string matchId;
    private readonly Dictionary<string, (PvpBonusSide Side, int Level)> owners;
    private readonly int localDisplayLevel;
    private readonly RecoveredBattleMap map;
    private readonly PvpBonusSpawnAreaCatalog areas;
    private PvpBonusSelectionState selection;
    private readonly Dictionary<string, SavedPlan> plans = new(StringComparer.Ordinal);
    private sealed record SavedPlan(PvpBonusDelayedRequest Request,
        PvpBonusSpawnContext Context, PvpBonusSpawnPlan Result);

    internal PvpBonusSpawnPlanner(BattleCombatContent content, MatchManifest manifest,
        string localOwnerId, int maximumSelectionReceipts = 4096)
    {
        ArgumentNullException.ThrowIfNull(content);
        var admitted = MatchManifest.Validate(manifest);
        if (admitted.Mode is MatchManifest.PrototypeMode or MatchManifest.CoopMissionMode)
            throw new InvalidDataException("Bonus crate planning requires online PvP.");
        content.ValidateAllocation(admitted);
        map = content.Maps.SingleOrDefault(candidate =>
            Path.GetFileNameWithoutExtension(candidate.Source) == admitted.MapId &&
            candidate.SourceHash == admitted.MapRevision)
            ?? throw new InvalidDataException("Bonus crate map differs from the admitted match.");
        areas = content.PvpBonusSpawnAreas;
        _ = areas.ForMap(map);
        matchId = admitted.MatchId;
        owners = new Dictionary<string, (PvpBonusSide, int)>(StringComparer.Ordinal);
        foreach (var player in admitted.Players)
        {
            if (player.PlayerLevel is not int level || player.Fraction is < 1 or > 2)
                throw new InvalidDataException("Bonus crate owner needs a signed rank and source fraction.");
            owners.Add(player.PlayerId, ((PvpBonusSide)player.Fraction, level));
        }
        if (!owners.TryGetValue(localOwnerId, out var local))
            throw new InvalidDataException("Bonus crate source view has no local roster owner.");
        localDisplayLevel = local.Level + 1;
        selection = new PvpBonusSelectionState(content.PvpBonuses, maximumSelectionReceipts);
    }

    internal int LastSourceIndex { get { lock (gate) return selection.LastSourceIndex; } }
    internal int QueuedCount(PvpBonusSide side) { lock (gate) return selection.QueuedCount(side); }
    internal int PlanCount { get { lock (gate) return plans.Count; } }

    internal void EnqueueConfirmedBonus(string receiptId, string ownerId, int sourceIndex)
    {
        lock (gate)
        {
            if (!owners.TryGetValue(ownerId, out var owner))
                throw new InvalidDataException("Queued bonus owner is outside the admitted roster.");
            selection.EnqueueConfirmedBonus(receiptId, owner.Side, sourceIndex);
        }
    }

    internal PvpBonusSpawnPlan PlanMatured(PvpBonusProgressFrame frame, int maturedIndex,
        PvpBonusSpawnContext context, PvpBonusSpawnDraw draw)
    {
        ArgumentNullException.ThrowIfNull(frame);
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(draw);
        if (maturedIndex < 0 || maturedIndex >= frame.MaturedRequests.Count)
            throw new ArgumentOutOfRangeException(nameof(maturedIndex));
        var request = frame.MaturedRequests[maturedIndex];
        lock (gate)
        {
            PvpBonusDelayQueue.ValidateScope(request.MatchId, request.OwnerPlayerId);
            if (request.MatchId != matchId ||
                !owners.TryGetValue(request.OwnerPlayerId, out var owner) ||
                request.BonusOrdinal < 1 || request.IssueFrame == 0 ||
                request.IssueFrame >= frame.FrameId)
                throw new InvalidDataException("Matured bonus is outside this source view or frame.");
            var weightContext = new PvpBonusWeightContext(context.IsWarArena,
                context.IsFriendlyDeathMatch, localDisplayLevel, owner.Level,
                context.GoldBonusesCollected, context.FirstTwoWeaponsHaveLowAmmo);
            if (plans.TryGetValue(request.ReceiptId, out var previous))
            {
                if (previous.Request != request || previous.Context != context)
                    throw new InvalidDataException("Matured bonus replay changed its authority.");
                return previous.Result;
            }
            var sourceAreas = areas.ForMap(map);
            Vector3 position = areas.Position(map, draw.AreaOrder, draw.UnitPosition);
            if (!float.IsFinite(draw.WeightedValue) || draw.WeightedValue < 0)
                throw new ArgumentOutOfRangeException(nameof(draw));
            var candidate = selection.PrepareSelectionCopy(request.ReceiptId,
                owner.Side, weightContext, _ => draw.WeightedValue, out var chosen);
            // Source may fall through at the inclusive upper endpoint: it
            // retains prefab 8 but emits invalid index 9. Keep source history
            // at 9, while publishing only the actual prefab's valid index.
            var plan = new PvpBonusSpawnPlan(request, chosen.SourceIndex,
                chosen.Prefab.Index, sourceAreas[draw.AreaOrder].ColliderFileId, position);
            plans.Add(request.ReceiptId, new(request, context, plan));
            selection = candidate;
            return plan;
        }
    }
}
