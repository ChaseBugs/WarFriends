using System.Numerics;
using System.Security.Cryptography;

namespace War.BattleServer;

public sealed record PvpBonusSpawnDraw(float WeightedValue, int AreaOrder, Vector3 UnitPosition);
public sealed record PvpBonusSpawnContext(bool IsWarArena, bool IsFriendlyDeathMatch,
    int GoldBonusesCollected, bool FirstTwoWeaponsHaveLowAmmo);
public sealed record PvpBonusSpawnPlan(PvpBonusDelayedRequest Request,
    int SourceIndex, int PrefabIndex, int AreaColliderFileId, Vector3 Position);
public sealed record PvpBonusCurrencyRewardQuote(string MatchId, string BoxId,
    string RecipientPlayerId, PvpBonusEffectKind Kind, int BaseDraw, int Amount);

/// <summary>
/// Makes a crate-spawn plan only after an accepted delay matures. The host
/// actor supplies its own draws and live analytics; no Client packet may do so.
/// An accepted plan also registers its host box before selection is published.
/// This does not simulate physical falling or grant its reward.
/// </summary>
internal sealed class PvpBonusSpawnPlanner
{
    private const int MaximumCurrencyQuotes = 256;
    private readonly object gate = new();
    private readonly string matchId;
    private readonly Dictionary<string, (PvpBonusSide Side, int Level)> owners;
    private readonly int localDisplayLevel;
    private readonly RecoveredBattleMap map;
    private readonly PvpBonusSpawnAreaCatalog areas;
    private readonly PvpBonusCatalog bonusCatalog;
    private PvpBonusSelectionState selection;
    private readonly PvpBonusBoxRegistry boxes;
    private readonly Dictionary<string, SavedPlan> plans = new(StringComparer.Ordinal);
    private readonly Dictionary<string, PvpBonusCurrencyRewardQuote> currencyQuotes =
        new(StringComparer.Ordinal);
    private sealed record SavedPlan(PvpBonusDelayedRequest Request,
        PvpBonusSpawnContext Context, PvpBonusSpawnPlan Result);

    internal PvpBonusSpawnPlanner(BattleCombatContent content, MatchManifest manifest,
        string localOwnerId, int maximumSelectionReceipts = 4096,
        int maximumActiveBoxes = 256, int maximumBoxReceipts = 4096)
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
        bonusCatalog = content.PvpBonuses;
        QueuedBonusCardSourceCatalog.Validate(bonusCatalog);
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
        boxes = new PvpBonusBoxRegistry(content, admitted, maximumActiveBoxes, maximumBoxReceipts);
    }

    internal int LastSourceIndex { get { lock (gate) return selection.LastSourceIndex; } }
    internal string MatchId => matchId;
    internal int QueuedCount(PvpBonusSide side) { lock (gate) return selection.QueuedCount(side); }
    internal int SourceIndexForQueuedCard(string sourceCardId) =>
        QueuedBonusCardSourceCatalog.IndexFor(sourceCardId, bonusCatalog);
    internal int PlanCount { get { lock (gate) return plans.Count; } }
    internal int ActiveBoxCount { get { lock (gate) return boxes.ActiveCount; } }
    internal int BoxReceiptCount { get { lock (gate) return boxes.ReceiptCount; } }
    internal IReadOnlyList<PvpBonusCurrencyRewardQuote> CurrencyQuotes
    {
        get
        {
            lock (gate)
                return Array.AsReadOnly(currencyQuotes.Values
                    .OrderBy(quote => quote.BoxId, StringComparer.Ordinal).ToArray());
        }
    }

    internal PvpBonusBoxSnapshot BoxSnapshot(string boxId)
    {
        lock (gate) return boxes.Snapshot(boxId);
    }

    internal PvpBonusEffectIntent EffectIntent(string boxId)
    {
        lock (gate) return boxes.EffectIntent(boxId);
    }

    /// <summary>
    /// Quotes a reward only for a collected host box. The Worker chooses one
    /// integer in the source range and retains it for retries. This is not a
    /// wallet grant; Backend must commit the box receipt exactly once.
    /// </summary>
    internal PvpBonusCurrencyRewardQuote QuoteCurrencyReward(string boxId) =>
        QuoteCurrencyRewardCore(boxId, null);

    // Controlled draw for source tests; production calls the overload above.
    internal PvpBonusCurrencyRewardQuote QuoteCurrencyReward(string boxId, int baseDraw) =>
        QuoteCurrencyRewardCore(boxId, baseDraw);

    private PvpBonusCurrencyRewardQuote QuoteCurrencyRewardCore(string boxId, int? suppliedDraw)
    {
        lock (gate)
        {
            var intent = boxes.EffectIntent(boxId);
            if (intent.Kind is not (PvpBonusEffectKind.Gold or PvpBonusEffectKind.Warbucks))
                throw new InvalidOperationException("Collected box has no currency reward.");
            if (currencyQuotes.TryGetValue(boxId, out var previous))
            {
                if ((suppliedDraw.HasValue && previous.BaseDraw != suppliedDraw.Value) ||
                    previous.RecipientPlayerId != intent.RecipientPlayerId ||
                    previous.Kind != intent.Kind)
                    throw new InvalidDataException("Currency reward replay changed its authority.");
                return previous;
            }
            if (currencyQuotes.Count == MaximumCurrencyQuotes)
                throw new InvalidOperationException("PvP currency quote capacity exhausted.");

            int recipientLevel = owners[intent.RecipientPlayerId].Level;
            int minimum;
            int maximumExclusive;
            if (intent.Kind == PvpBonusEffectKind.Gold)
            {
                var range = bonusCatalog.GoldRewardRange(recipientLevel + 1);
                minimum = range.Minimum;
                maximumExclusive = range.MaximumExclusive;
            }
            else
            {
                minimum = bonusCatalog.WarbucksBaseDrawRange.Minimum;
                maximumExclusive = bonusCatalog.WarbucksBaseDrawRange.MaximumExclusive;
            }
            int baseDraw = suppliedDraw ??
                RandomNumberGenerator.GetInt32(minimum, maximumExclusive);
            if (baseDraw < minimum || baseDraw >= maximumExclusive)
                throw new ArgumentOutOfRangeException(nameof(suppliedDraw));
            int amount;
            if (intent.Kind == PvpBonusEffectKind.Gold)
            {
                amount = baseDraw;
            }
            else
            {
                amount = bonusCatalog.WarbucksRewardForBaseDraw(recipientLevel, baseDraw);
            }

            var quote = new PvpBonusCurrencyRewardQuote(matchId, boxId,
                intent.RecipientPlayerId, intent.Kind, baseDraw, amount);
            currencyQuotes.Add(boxId, quote);
            return quote;
        }
    }

    internal PvpBonusBoxSnapshot ConfirmStaticContact(string boxId)
    {
        lock (gate) return boxes.ConfirmStaticContact(boxId);
    }

    internal void ArmBoobyTrap(string receiptId, string ownerPlayerId)
    {
        lock (gate) boxes.ArmBoobyTrap(receiptId, ownerPlayerId);
    }

    internal bool HasArmedBoobyTrap(string ownerPlayerId)
    {
        lock (gate) return boxes.HasArmedBoobyTrap(ownerPlayerId);
    }

    internal PvpBonusBoxCollectionCandidate ConfirmDestroyed(string boxId,
        string damageReceiptId, string? attackerPlayerId,
        Vector3? collectionPosition = null)
    {
        lock (gate) return boxes.ConfirmDestroyed(boxId, damageReceiptId,
            attackerPlayerId, collectionPosition);
    }

    internal void EnqueueConfirmedBonus(string receiptId, string ownerId, int sourceIndex)
    {
        lock (gate)
        {
            if (!owners.TryGetValue(ownerId, out var owner))
                throw new InvalidDataException("Queued bonus owner is outside the admitted roster.");
            selection.EnqueueConfirmedBonus(receiptId, owner.Side, sourceIndex);
        }
    }

    internal bool TryEnqueueCardBonus(string receiptId, string ownerId,
        int sourceIndex, Func<bool> spendCard)
    {
        ArgumentNullException.ThrowIfNull(spendCard);
        lock (gate)
        {
            if (!owners.TryGetValue(ownerId, out var owner))
                throw new InvalidDataException("Queued card owner is outside the roster.");
            // Prepare the queue and its replay receipt before card inventory
            // changes. If spending fails, discard the candidate unchanged.
            var candidate = selection.PrepareEnqueueCopy(receiptId,
                owner.Side, sourceIndex);
            if (!spendCard()) return false;
            selection = candidate;
            return true;
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
            // Admit the actual box before committing the queue/last-index copy.
            // Full box capacity leaves the matured request retriable on replay.
            boxes.Register(plan);
            plans.Add(request.ReceiptId, new(request, context, plan));
            selection = candidate;
            return plan;
        }
    }
}
