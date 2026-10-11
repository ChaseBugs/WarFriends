namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private sealed class BigMedkitHealing
    {
        public required string OwnerPlayerId { get; init; }
        public required float FractionPerPulse { get; init; }
        public required ulong ExpiresTick { get; init; }
        public required ulong NextPulseTick { get; set; }
    }

    private readonly Dictionary<string, BigMedkitHealing> bigMedkits =
        new(StringComparer.Ordinal);

    private void StartBigMedkit(string effectId, string ownerPlayerId, float fraction)
    {
        // CardHealMeNowBig picks one random 25-35% coefficient when used.
        // Its base class spreads that coefficient across BigMedKitTime (15 s).
        ulong durationTicks = 15UL * MatchManifest.TickRate;
        bigMedkits.Add(effectId, new BigMedkitHealing
        {
            OwnerPlayerId = ownerPlayerId,
            FractionPerPulse = fraction / 15f,
            NextPulseTick = checked(tick + MatchManifest.TickRate),
            ExpiresTick = checked(tick + durationTicks)
        });
    }

    private void AdvanceBigMedkits()
    {
        foreach (var (effectId, healing) in bigMedkits.ToArray())
        {
            var owner = Find(healing.OwnerPlayerId);
            if (owner?.Admitted != true || owner.Dead || owner.Definition.Combat == null ||
                !cardEffects.TryGet(effectId, out _))
            {
                bigMedkits.Remove(effectId);
                continue;
            }

            while (healing.NextPulseTick <= tick &&
                   healing.NextPulseTick <= healing.ExpiresTick)
            {
                float amount = owner.Definition.Combat.MaxHealth *
                    healing.FractionPerPulse;
                ApplyResolvedPlayerDamage(healing.OwnerPlayerId,
                    healing.OwnerPlayerId,
                    new ResolvedPlayerDamage(-amount,
                        CombatDamageType.Basic, HasWeapon: false), 1, false);
                healing.NextPulseTick += MatchManifest.TickRate;
            }
        }
    }
}
