namespace War.BattleServer;

/// <summary>Reproduces CardSickness callbacks and calculations without inventing a timed effect lease.</summary>
public sealed class SicknessSpawnWindow
{
    private const float HealthMultiplier = 0.5f;
    private const float DamageMultiplier = 0.5f;
    private readonly int _ownerFraction;
    private readonly Dictionary<int, (string UnitId, bool IsSoldier)> _definitions;
    private int? _activeOptionIndex;

    /// <summary>Whether source spawn callbacks remain subscribed.</summary>
    public bool IsArmed { get; private set; }

    /// <summary>Whether an opposing soldier definition has opened the spawn-effect window.</summary>
    public bool IsApplying => IsArmed && _activeOptionIndex.HasValue;

    /// <summary>Copies stable source definition identities for one card owner's fraction.</summary>
    public SicknessSpawnWindow(int ownerFraction, ArmyDeploymentCatalog catalog)
    {
        if (ownerFraction is not (1 or 2) || catalog == null)
        {
            throw new InvalidDataException("Sickness requires a playing fraction and recovered army definitions.");
        }

        _ownerFraction = ownerFraction;
        _definitions = catalog.Families.SelectMany(family => family.Options.Select(option =>
            (option.Index, family.UnitId, family.IsSoldier)))
            .ToDictionary(row => row.Index, row => (row.UnitId, row.IsSoldier));
    }

    /// <summary>Arms future start callbacks; re-use resets any previous active definition.</summary>
    public void Arm()
    {
        IsArmed = true;
        _activeOptionIndex = null;
    }

    /// <summary>Tracks the latest opposing soldier start, including starts overlapping an existing window.</summary>
    public void DeploymentStarted(int fraction, ArmyDeploymentWave wave)
    {
        ValidateEvent(fraction, wave);
        if (IsArmed && fraction != _ownerFraction && wave.IsSoldier)
        {
            _activeOptionIndex = wave.OptionIndex;
        }
    }

    /// <summary>Disconnects only when the remembered persistent definition finishes.</summary>
    public void DeploymentFinished(int fraction, ArmyDeploymentWave wave)
    {
        ValidateEvent(fraction, wave);
        // The Client compares reused ArmyUnitDefinition references, not a unique deployment ID.
        if (IsApplying && fraction != _ownerFraction && wave.OptionIndex == _activeOptionIndex)
        {
            Disconnect();
        }
    }

    /// <summary>Tests source AfterSpawned conditions without restricting the entity to a particular wave.</summary>
    public bool ShouldAffect(SicknessSpawnTarget target)
    {
        ArgumentNullException.ThrowIfNull(target);
        ValidateFraction(target.Fraction);
        return IsApplying && target.Fraction != _ownerFraction && target.IsEnemyController && target.CanBeFrozen;
    }

    /// <summary>Scales the grenade's AmmoSetup damage without changing its separate explosion field.</summary>
    public ArmyGrenadeDamageStats ApplyGrenadeDamage(SicknessSpawnTarget target, ArmyGrenadeDamageStats damage)
    {
        ArgumentNullException.ThrowIfNull(damage);
        if (!ShouldAffect(target))
        {
            return damage;
        }

        if (!float.IsFinite(damage.Minimum) || damage.Minimum < 0f ||
            !float.IsFinite(damage.Explosion) || damage.Explosion < damage.Minimum)
        {
            throw new InvalidDataException("Sickness requires valid current grenade damage fields.");
        }

        // ImproveAllWeapons writes AmmoSetup.damageAmount directly. It never calls
        // GrenadeAmmoSetup.ScaleDamage, which would also scale explodeDamageAmount.
        return damage with { Minimum = damage.Minimum * DamageMultiplier };
    }

    /// <summary>Copies scaled damage and refills current health to half maximum; maximum health is preserved.</summary>
    public SicknessCombatState Apply(SicknessSpawnTarget target, SicknessCombatState state)
    {
        ArgumentNullException.ThrowIfNull(state);
        if (!ShouldAffect(target))
        {
            return state;
        }

        if (!float.IsFinite(state.MaximumHealth) || state.MaximumHealth <= 0 ||
            !float.IsFinite(state.Health) || state.Health < 0 || state.Health > state.MaximumHealth ||
            state.WeaponDamage == null || state.WeaponDamage.Any(damage => !float.IsFinite(damage) || damage < 0))
        {
            throw new InvalidDataException("Sickness lacks valid current vitality or weapon damage.");
        }

        return state with
        {
            Health = state.MaximumHealth * HealthMultiplier,
            WeaponDamage = Array.AsReadOnly(state.WeaponDamage.Select(damage => damage * DamageMultiplier).ToArray()),
            IsImmortal = false,
            IsDead = false
        };
    }

    /// <summary>Removes subscriptions without restoring damage or health already applied to units.</summary>
    public void Disconnect()
    {
        IsArmed = false;
        _activeOptionIndex = null;
    }

    private void ValidateEvent(int fraction, ArmyDeploymentWave wave)
    {
        ValidateFraction(fraction);
        if (wave == null || wave.Id == 0 || wave.FinishAfterTick <= wave.StartedTick ||
            !_definitions.TryGetValue(wave.OptionIndex, out var definition) ||
            definition.UnitId != wave.UnitId || definition.IsSoldier != wave.IsSoldier)
        {
            throw new InvalidDataException("Sickness spawn event differs from recovered definition authority.");
        }
    }

    private static void ValidateFraction(int fraction)
    {
        // Source Fractions.None is zero; the recovered inequality also admits neutral EnemyController callbacks.
        if (fraction is < 0 or > 2)
        {
            throw new InvalidDataException("Unknown source spawn fraction.");
        }
    }
}
