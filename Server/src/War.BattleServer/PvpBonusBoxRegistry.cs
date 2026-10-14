using System.Numerics;

namespace War.BattleServer;

public enum PvpBonusBoxPhase { Falling, Grounded, Collected }
public sealed record PvpBonusBoxCollectionCandidate(string BoxId, string OwnerPlayerId,
    string RecipientPlayerId, int PrefabIndex, bool Stolen, bool BoobyTrapped);
public sealed record PvpBonusBoxSnapshot(string BoxId, PvpBonusSpawnPlan Plan,
    PvpBonusBoxPhase Phase, PvpBonusBoxCollectionCandidate? Collection);

/// <summary>
/// Host-owned box identity and single-winner collection. A collection candidate
/// is not a reward; effects and currency still need authoritative settlement.
/// Physics must establish contacts and lethal damage before calling this type.
/// </summary>
internal sealed class PvpBonusBoxRegistry
{
    private readonly int maximumActiveBoxes;
    private readonly int maximumReceipts;
    private readonly object gate = new();
    private readonly string matchId;
    private readonly RecoveredBattleMap map;
    private readonly PvpBonusSpawnAreaCatalog areas;
    private readonly Dictionary<string, int> fractions = new(StringComparer.Ordinal);
    private readonly Dictionary<string, PvpBonusBoxSnapshot> boxes = new(StringComparer.Ordinal);
    private readonly Dictionary<string, string> damageReceipts = new(StringComparer.Ordinal);
    private readonly Dictionary<string, string> trapReceipts = new(StringComparer.Ordinal);
    private readonly HashSet<int> armedFractions = new();
    private int activeCount;

    internal PvpBonusBoxRegistry(BattleCombatContent content, MatchManifest manifest,
        int maximumActiveBoxes = 256, int maximumReceipts = 4096)
    {
        ArgumentNullException.ThrowIfNull(content);
        if (maximumActiveBoxes is < 1 or > 256)
            throw new ArgumentOutOfRangeException(nameof(maximumActiveBoxes));
        if (maximumReceipts is < 2 or > 4096)
            throw new ArgumentOutOfRangeException(nameof(maximumReceipts));
        this.maximumActiveBoxes = maximumActiveBoxes;
        this.maximumReceipts = maximumReceipts;
        var admitted = MatchManifest.Validate(manifest);
        if (admitted.Mode is MatchManifest.PrototypeMode or MatchManifest.CoopMissionMode)
            throw new InvalidDataException("Bonus boxes require an online PvP roster.");
        content.ValidateAllocation(admitted);
        map = content.Maps.SingleOrDefault(candidate =>
            Path.GetFileNameWithoutExtension(candidate.Source) == admitted.MapId &&
            candidate.SourceHash == admitted.MapRevision)
            ?? throw new InvalidDataException("Bonus box map differs from the admitted match.");
        areas = content.PvpBonusSpawnAreas;
        _ = areas.ForMap(map);
        matchId = admitted.MatchId;
        foreach (var player in admitted.Players)
            fractions.Add(player.PlayerId, player.Fraction);
    }

    internal int ActiveCount { get { lock (gate) return activeCount; } }
    internal int ReceiptCount { get { lock (gate) return boxes.Count +
        damageReceipts.Count + trapReceipts.Count; } }

    internal PvpBonusBoxSnapshot Register(PvpBonusSpawnPlan plan)
    {
        ArgumentNullException.ThrowIfNull(plan);
        lock (gate)
        {
            var request = plan.Request;
            ValidateReceipt(request.ReceiptId);
            PvpBonusDelayQueue.ValidateScope(request.MatchId, request.OwnerPlayerId);
            if (request.MatchId != matchId || !fractions.ContainsKey(request.OwnerPlayerId) ||
                request.BonusOrdinal < 1 || request.IssueFrame == 0 ||
                plan.PrefabIndex is < 0 or > 8 ||
                (plan.SourceIndex != plan.PrefabIndex &&
                 (plan.SourceIndex != 9 || plan.PrefabIndex != 8)))
                throw new InvalidDataException("Spawn plan lacks a valid source owner or prefab.");
            var area = areas.ForMap(map).SingleOrDefault(item =>
                item.ColliderFileId == plan.AreaColliderFileId);
            if (area == null || !Inside(plan.Position, area))
                throw new InvalidDataException("Spawn plan lies outside its reviewed map area.");
            if (boxes.TryGetValue(request.ReceiptId, out var previous))
            {
                if (previous.Plan != plan)
                    throw new InvalidDataException("Box receipt changed its spawn plan.");
                return previous;
            }
            if (trapReceipts.ContainsKey(request.ReceiptId) ||
                damageReceipts.ContainsKey(request.ReceiptId))
                throw new InvalidDataException("Box receipt conflicts with another host mutation.");
            // Reserve its eventual terminal damage receipt at spawn admission.
            if (activeCount == maximumActiveBoxes || ReservedReceipts + 2 > maximumReceipts)
                throw new InvalidOperationException("Bonus box capacity exhausted.");
            var result = new PvpBonusBoxSnapshot(request.ReceiptId, plan,
                PvpBonusBoxPhase.Falling, null);
            boxes.Add(result.BoxId, result);
            activeCount++;
            return result;
        }
    }

    internal PvpBonusBoxSnapshot ConfirmStaticContact(string boxId)
    {
        lock (gate)
        {
            var box = Find(boxId);
            if (box.Phase != PvpBonusBoxPhase.Falling)
                return box;
            var grounded = box with {Phase = PvpBonusBoxPhase.Grounded};
            boxes[boxId] = grounded;
            return grounded;
        }
    }

    internal void ArmBoobyTrap(string receiptId, string ownerPlayerId)
    {
        ValidateReceipt(receiptId);
        lock (gate)
        {
            if (!fractions.TryGetValue(ownerPlayerId, out int fraction))
                throw new InvalidDataException("Booby trap owner is outside the match.");
            if (boxes.ContainsKey(receiptId) || damageReceipts.ContainsKey(receiptId))
                throw new InvalidDataException("Booby trap receipt conflicts with box authority.");
            if (trapReceipts.TryGetValue(receiptId, out string? previous))
            {
                if (previous != ownerPlayerId)
                    throw new InvalidDataException("Booby trap replay changed its owner.");
                return;
            }
            if (ReservedReceipts + 1 > maximumReceipts)
                throw new InvalidOperationException("Booby trap receipt capacity exhausted.");
            trapReceipts.Add(receiptId, ownerPlayerId);
            armedFractions.Add(fraction);
        }
    }

    internal PvpBonusBoxCollectionCandidate ConfirmDestroyed(string boxId,
        string damageReceiptId, string? attackerPlayerId)
    {
        ValidateReceipt(damageReceiptId);
        lock (gate)
        {
            var box = Find(boxId);
            string ownerId = box.Plan.Request.OwnerPlayerId;
            string recipientId = attackerPlayerId ?? ownerId;
            if (!fractions.ContainsKey(recipientId))
                throw new InvalidDataException("Box damage owner is outside the admitted roster.");
            if (boxes.ContainsKey(damageReceiptId) || trapReceipts.ContainsKey(damageReceiptId))
                throw new InvalidDataException("Damage receipt conflicts with box authority.");
            if (box.Collection is { } previous)
            {
                if (!damageReceipts.TryGetValue(damageReceiptId, out var priorBox) ||
                    priorBox != boxId || previous.RecipientPlayerId != recipientId)
                    throw new InvalidDataException("Collected box cannot choose another winner.");
                return previous;
            }
            if (damageReceipts.ContainsKey(damageReceiptId))
                throw new InvalidDataException("Damage receipt belongs to another box.");
            // Register reserved this terminal receipt before publishing the box.
            bool stolen = fractions[recipientId] != fractions[ownerId];
            bool boobyTrapped = stolen && armedFractions.Contains(fractions[ownerId]);
            var candidate = new PvpBonusBoxCollectionCandidate(boxId, ownerId,
                recipientId, box.Plan.PrefabIndex, stolen, boobyTrapped);
            damageReceipts.Add(damageReceiptId, boxId);
            boxes[boxId] = box with {Phase = PvpBonusBoxPhase.Collected, Collection = candidate};
            activeCount--;
            if (boobyTrapped) armedFractions.Remove(fractions[ownerId]);
            return candidate;
        }
    }

    internal PvpBonusBoxSnapshot Snapshot(string boxId)
    {
        lock (gate) return Find(boxId);
    }

    internal bool HasArmedBoobyTrap(string ownerPlayerId)
    {
        lock (gate)
        {
            if (!fractions.TryGetValue(ownerPlayerId, out int fraction))
                throw new InvalidDataException("Booby trap owner is outside the match.");
            return armedFractions.Contains(fraction);
        }
    }

    private PvpBonusBoxSnapshot Find(string boxId) =>
        boxes.TryGetValue(boxId, out var box)
            ? box : throw new InvalidDataException("Unknown host bonus box.");

    private int ReservedReceipts => boxes.Count * 2 + trapReceipts.Count;

    private static bool Inside(Vector3 position, PvpBonusSpawnArea area) =>
        float.IsFinite(position.X) && float.IsFinite(position.Y) && float.IsFinite(position.Z) &&
        position.X >= area.BoundsMin.X - 0.00002f && position.X <= area.BoundsMax.X + 0.00002f &&
        position.Y >= area.BoundsMin.Y - 0.00002f && position.Y <= area.BoundsMax.Y + 0.00002f &&
        position.Z >= area.BoundsMin.Z - 0.00002f && position.Z <= area.BoundsMax.Z + 0.00002f;

    private static void ValidateReceipt(string receiptId)
    {
        if (!Guid.TryParseExact(receiptId, "N", out _) || receiptId != receiptId.ToLowerInvariant())
            throw new InvalidDataException("Invalid host bonus box receipt.");
    }
}
