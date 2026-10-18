using System.Numerics;

using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const float MortarFakeMinimumOffset = 0.5f;
    private const float MortarFakeMaximumOffset = 1f;
    private const float MortarFakeHeightOffset = 0.5f;
    private const float MortarFakeSideProbability = 0.5f;
    private readonly MortarWeaponSource? _mortarWeaponSource;
    private readonly Dictionary<ulong, MortarShotAttempt> _mortarAttempts = [];
    private readonly Dictionary<ulong, ulong> _mortarLastShotTicks = [];

    /// <summary>Reads match-owned preparation and projectile evidence for the current construction cycle.</summary>
    internal MortarShotAttempt? MortarAttempt(ulong entityKey)
    {
        return _mortarAttempts.GetValueOrDefault(entityKey);
    }

    private void AdvanceMortarShooting()
    {
        ReturnMortarWeaponsToHands();
        foreach (var (entityKey, attempt) in _mortarAttempts.OrderBy(row => row.Key).ToArray())
        {
            if (attempt.Target == null || attempt.CompletedTick.HasValue || tick < attempt.PollTick)
            {
                continue;
            }
            float cadence = (_mortarWeaponSource ??
                throw new InvalidDataException("Mortar lost its source weapon cadence.")).CadenceSeconds;
            float now = tick / (float)MatchManifest.TickRate;
            float last = _mortarLastShotTicks.GetValueOrDefault(entityKey) / (float)MatchManifest.TickRate;
            if (now <= last + cadence)
            {
                continue;
            }

            LaunchMortarMissile(entityKey, attempt);
            _mortarLastShotTicks[entityKey] = tick;
            attempt.CompletedTick = tick;
            ConsumeArmyCooldownDraw(entityKey);
        }

        AdvanceMortarFacing();
        foreach (var (entityKey, construction) in _mortarConstruction.OrderBy(row => row.Key))
        {
            if (tick >= construction.FirstFireEligibleTick && !_mortarAttempts.ContainsKey(entityKey))
            {
                PrepareMortarShot(entityKey);
            }
        }
        AdvanceMortarRelocations();
    }

    private void PrepareMortarShot(ulong entityKey)
    {
        // FireMortar freezes the weapon before target preparation and its random draws.
        CaptureMortarWeaponAttachment(entityKey);
        MortarShotTarget? target = SelectMortarShotTarget(entityKey);
        bool isFake = false;
        if (target != null)
        {
            CoopInfantryShotBatch batch = AssaulterShotBatchPolicy.Create(
                armyShots[entityKey], armyChoice, NextArmyFloat);
            if (batch.Count != 1)
            {
                throw new InvalidDataException("Ordinary Mortar no longer has its source single-shot batch.");
            }
            isFake = (batch.RealShotMask & 1) == 0;
        }
        // FireMortar starts the animation before preparation can fail. GenerateNextShootTime
        // still consumes its source draw on failed StartShooting, without authorizing a projectile.
        _mortarAttempts.Add(entityKey, new MortarShotAttempt(tick, target, isFake));
        ConsumeArmyCooldownDraw(entityKey);
    }

    private void LaunchMortarMissile(ulong entityKey, MortarShotAttempt attempt)
    {
        if (rifleCombat == null || armyCatalog == null)
        {
            throw new InvalidDataException("Mortar missile lost its collision authority.");
        }
        var entity = activeArmyEntities[entityKey];
        ArmyMortarRuntime weapon = _ordinaryMortarWeapons[entityKey];
        Vector3 target = attempt.Target!.Position;
        if (attempt.IsFake)
        {
            Vector3 sideways = Vector3.Cross(new Vector3(entity.X, entity.Y, entity.Z) - target, Vector3.UnitY);
            sideways = sideways.LengthSquared() > 0f ? Vector3.Normalize(sideways) : Vector3.Zero;
            sideways *= MortarFakeMinimumOffset +
                NextArmyFloat() * (MortarFakeMaximumOffset - MortarFakeMinimumOffset);
            if (NextArmyFloat() < MortarFakeSideProbability)
            {
                sideways = -sideways;
            }
            target += sideways + Vector3.UnitY * MortarFakeHeightOffset;
        }
        // A depleted host pool consumes the attempted source shot, never retries it as extra damage.
        if (PendingProjectileCount >= MaximumProjectiles || !EventCapacityForShot())
        {
            return;
        }
        if (projectileId == ulong.MaxValue)
        {
            throw new InvalidDataException("Mortar projectile identities exhausted.");
        }

        ulong id = ++projectileId;
        var launch = new MortarMissileLaunch
        {
            ProjectileId = id,
            SoldierEntityKey = entityKey,
            Weapon = weapon,
            TargetPosition = target,
            LaunchTick = tick,
            IsFake = attempt.IsFake
        };
        var flight = CardRocketMissileFlight.CreateMortar(launch, (from, direction, range) =>
            rifleCombat.TraceForArmyDamage(entity.OwnerPlayerId, from, direction, range));
        var missile = new ArmyCardRocketRuntime(weapon.DirectDamage, weapon.ExplosionDamage,
            weapon.Speed, weapon.PlayerBehindShieldRatio);
        rocketFlights.Add(id, flight);
        rocketLaunches.Add(id, new CardRocketLaunchAuthority(entity.OwnerPlayerId, missile,
            armyCatalog.PlayerDamagePolicy(entity.UnitId)) { Mortar = weapon });
        attempt.ProjectileId = id;
        Emit(MatchEventKind.Shot, entity.OwnerPlayerId, "", id, flight.Position, 0,
            attempt.IsFake ? "army-mortar-fake" : "army-mortar");
        stateRevision++;
    }
}
