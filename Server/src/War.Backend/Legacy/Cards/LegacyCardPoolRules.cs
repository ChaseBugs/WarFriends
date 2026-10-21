using System.Text.Json;
using War.Persistence.Legacy.Cards;
using War.Persistence.Legacy.State;
using War.Persistence;

namespace War.Backend.Legacy.Cards;

/// <summary>Calculates conserved transfers from one transaction snapshot without performing writes.</summary>
public sealed class LegacyCardPoolRules(LegacyCardPoolPolicy policy)
{
    private static readonly JsonSerializerOptions CardOptions = LegacyCardStateOptions.Create();

    public int CurrentNextWithdraw(LegacyPlayerDocument player) => ReadCards(player).NextWithdraw;

    public LegacyCardPoolMutation Calculate(
        LegacyCardPoolSnapshot snapshot, LegacyCardPoolIntent intent, int nowUnixSeconds)
    {
        if (nowUnixSeconds < 0)
        {
            throw new InvalidDataException("Invalid card-pool application time.");
        }

        if (!policy.IsAvailable)
        {
            return Refuse(DatabaseResult.ServerMaintenance, 0);
        }

        CardManagerData cards = ReadCards(snapshot.Actor);
        ValidateDeposits(snapshot.Actor.DepositedCards);
        int previousNextWithdraw = cards.NextWithdraw;
        try
        {
            return intent.CardId == null
                ? Deposit(snapshot, intent, cards)
                : Withdraw(new Withdrawal(snapshot, intent, cards, nowUnixSeconds));
        }
        catch (OverflowException)
        {
            return Refuse(DatabaseResult.WrongPlayerData, previousNextWithdraw);
        }
    }

    private LegacyCardPoolMutation Deposit(
        LegacyCardPoolSnapshot snapshot, LegacyCardPoolIntent intent, CardManagerData cards)
    {
        if (intent.Added.Count + intent.Removed.Count == 0 ||
            intent.Added.Keys.Concat(intent.Removed.Keys).Any(id => !policy.Contains(id)) ||
            intent.Added.Keys.Intersect(intent.Removed.Keys, StringComparer.Ordinal).Any() ||
            intent.Added.Values.Concat(intent.Removed.Values).Any(amount => amount <= 0))
        {
            return Refuse(DatabaseResult.WrongPlayerData, cards.NextWithdraw);
        }

        var deposits = new Dictionary<string, int>(snapshot.Actor.DepositedCards, StringComparer.Ordinal);
        foreach ((string id, int amount) in intent.Removed)
        {
            if (deposits.GetValueOrDefault(id) < amount)
            {
                return Refuse(DatabaseResult.WrongPlayerData, cards.NextWithdraw);
            }

            SetDeposit(deposits, id, deposits[id] - amount);
            GetCard(cards, id).Amount = checked(GetCard(cards, id).Amount + amount);
        }

        foreach ((string id, int amount) in intent.Added)
        {
            SavedCardData owned = GetCard(cards, id);
            if (owned.Amount < amount)
            {
                return Refuse(DatabaseResult.WrongPlayerData, cards.NextWithdraw);
            }

            owned.Amount -= amount;
            deposits[id] = checked(deposits.GetValueOrDefault(id) + amount);
        }

        return new LegacyCardPoolMutation
        {
            Result = (int)DatabaseResult.Success,
            NextWithdraw = cards.NextWithdraw,
            ActorCards = PlayerState.Write(cards),
            ActorDeposits = deposits
        };
    }

    private LegacyCardPoolMutation Withdraw(Withdrawal withdrawal)
    {
        LegacyCardPoolSnapshot snapshot = withdrawal.Snapshot;
        CardManagerData cards = withdrawal.Cards;
        string id = withdrawal.Intent.CardId!;
        if (!policy.Contains(id) || snapshot.Donor == null || snapshot.Donor.Id == snapshot.Actor.Id ||
            !HasSharedMembership(snapshot))
        {
            return Refuse(DatabaseResult.WrongPlayerData, cards.NextWithdraw);
        }

        ValidateDeposits(snapshot.Donor.DepositedCards);
        if (snapshot.Donor.Reputation < 0)
        {
            throw new InvalidDataException("Invalid donor reputation.");
        }

        if (cards.NextWithdraw > withdrawal.NowUnixSeconds)
        {
            return Refuse(DatabaseResult.TooSoonToActivate, cards.NextWithdraw);
        }

        int available = snapshot.Donor.DepositedCards.GetValueOrDefault(id);
        if (available <= 0)
        {
            return Refuse(DatabaseResult.WrongPlayerData, cards.NextWithdraw);
        }

        var deposits = new Dictionary<string, int>(snapshot.Donor.DepositedCards, StringComparer.Ordinal);
        SetDeposit(deposits, id, available - 1);
        SavedCardData owned = GetCard(cards, id);
        owned.Amount = checked(owned.Amount + 1);
        cards.NextWithdraw = checked(withdrawal.NowUnixSeconds + policy.CooldownSeconds);
        // CardpoolDialog credits the donor, not the player receiving the card.
        int reputation = checked(snapshot.Donor.Reputation + policy.Reputation(id));
        return new LegacyCardPoolMutation
        {
            Result = (int)DatabaseResult.Success,
            NextWithdraw = cards.NextWithdraw,
            ActorCards = PlayerState.Write(cards),
            DonorDeposits = deposits,
            DonorReputation = reputation,
            NeedsSquadFence = true
        };
    }

    private CardManagerData ReadCards(LegacyPlayerDocument player)
    {
        CardManagerData cards = new();
        if (player.Serialized.TryGetValue("CardManagerData", out string? json))
        {
            using JsonDocument document = LegacyStateJson.ParseObject(json);
            cards = JsonSerializer.Deserialize<CardManagerData>(json, CardOptions)
                ?? throw new InvalidDataException("Null card inventory.");
        }

        if (cards.CardData == null || cards.BuddyCardData == null || cards.NextWithdraw < 0 ||
            cards.NextBuddyDeposit < 0 || cards.CardData.Any(pair => !policy.Contains(pair.Key) ||
                pair.Value == null || pair.Value.Amount < 0) ||
            cards.BuddyCardData.Any(pair => pair.Value == null || pair.Value.Amount < 0))
        {
            throw new InvalidDataException("Invalid card inventory authority.");
        }

        return cards;
    }

    private void ValidateDeposits(Dictionary<string, int> deposits)
    {
        if (deposits == null || deposits.Any(pair => !policy.Contains(pair.Key) || pair.Value < 0))
        {
            throw new InvalidDataException("Invalid card-pool stock authority.");
        }
    }

    private static bool HasSharedMembership(LegacyCardPoolSnapshot snapshot)
    {
        LegacySquadDocument? squad = snapshot.Squad;
        return squad != null && squad.Members != null && squad.Id.Length > 0 &&
            snapshot.Actor.SquadId == squad.Id && snapshot.Donor!.SquadId == squad.Id &&
            squad.Members.Count(member => member.PlayerId == snapshot.Actor.Id) == 1 &&
            squad.Members.Count(member => member.PlayerId == snapshot.Donor.Id) == 1;
    }

    private static SavedCardData GetCard(CardManagerData cards, string id)
    {
        if (!cards.CardData.TryGetValue(id, out SavedCardData? card))
        {
            card = new SavedCardData();
            cards.CardData.Add(id, card);
        }

        return card;
    }

    private static void SetDeposit(Dictionary<string, int> deposits, string id, int amount)
    {
        if (amount == 0)
        {
            deposits.Remove(id);
        }
        else
        {
            deposits[id] = amount;
        }
    }

    private static LegacyCardPoolMutation Refuse(DatabaseResult result, int nextWithdraw) => new()
    {
        Result = (int)result,
        NextWithdraw = nextWithdraw
    };

    private sealed record Withdrawal(
        LegacyCardPoolSnapshot Snapshot, LegacyCardPoolIntent Intent, CardManagerData Cards, int NowUnixSeconds);
}
