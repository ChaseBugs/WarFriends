using War.Persistence;
using War.Persistence.Legacy.DogTags;

namespace War.Backend.Legacy.DogTags;

/// <summary>Preserves source debt/VIP semantics while widening arithmetic before checking wire bounds.</summary>
public static class LegacyDogTagRules
{
    /// <summary>Rebases a validated base tuple without mutating the stored account.</summary>
    public static LegacyDogTagSnapshot Project(
        LegacyPlayerDocument player, int now, LegacyDogTagPolicy? policy = null)
    {
        LegacyDogTagAuthority.ValidateStored(player, now);
        if (policy != null && player.DogTagMax != policy.MaximumSeconds)
        {
            throw new InvalidDataException("Stored dog-tag capacity differs from the immutable source policy.");
        }

        long elapsed = (long)now - player.DogTagLastUpdate;
        int seconds = (int)Math.Min((long)player.DogTagSeconds + elapsed, player.DogTagMax);
        return new LegacyDogTagSnapshot(seconds, now, player.DogTagMax);
    }

    /// <summary>Plans source-priced refill; full and insufficient states remain read-only.</summary>
    public static LegacyDogTagMutation Refill(LegacyPlayerDocument player, LegacyDogTagPolicy policy, int now)
    {
        LegacyDogTagSnapshot snapshot = Project(player, now, policy);
        long bonus = player.Vip > now ? policy.VipBonusSeconds : 0;
        long maximum = (long)snapshot.MaximumSeconds + bonus;
        long available = Math.Clamp((long)snapshot.Seconds + bonus, 0, maximum);
        if (available == maximum)
        {
            return new(LegacyDogTagOutcome.Unchanged, snapshot.Seconds, now, player.Gold);
        }

        long price = policy.RefillPrice((int)(available / policy.RefillSeconds));
        if (price < 0)
        {
            throw new InvalidDataException("Dog-tag refill selected a negative source price.");
        }

        return player.Gold < price
            ? new(LegacyDogTagOutcome.NotEnoughGold, snapshot.Seconds, now, player.Gold)
            : new(LegacyDogTagOutcome.Applied, snapshot.MaximumSeconds, now, player.Gold - price);
    }

    /// <summary>Plans one penalty while retaining debt and refusing signed-Int32 underflow.</summary>
    public static LegacyDogTagMutation Pay(LegacyPlayerDocument player, LegacyDogTagPolicy policy, int now)
    {
        LegacyDogTagSnapshot snapshot = Project(player, now, policy);
        long seconds = (long)snapshot.Seconds - policy.RefillSeconds;
        if (seconds < int.MinValue)
        {
            throw new InvalidDataException("Dog-tag penalty debt exceeds the recovered signed-Int32 domain.");
        }

        // DogTagManager.PayOneDogTag preserves negative base seconds. Only display/price clamps to zero.
        return new(LegacyDogTagOutcome.Applied, (int)seconds, now, player.Gold);
    }
}
