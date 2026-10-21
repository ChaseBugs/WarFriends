using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Isolated host-owned BotMission vitality. A future validated impact path must
/// call ApplyHostDamage; no client command can submit damage or declare death.
/// </summary>
internal sealed class CoopBossCombatState
{
    private readonly CoopMissionEngine mission;

    public ulong EntityId => CoopMissionEngine.BossEntityId;
    public int MissionIndex { get; }
    public int DefendComponentFileId { get; }
    public Vector3 Position { get; }
    public Quaternion Rotation { get; }
    public float MaximumHealth { get; }
    public float Health { get; private set; }
    public ulong SpawnTick { get; }
    public ulong? DeathTick { get; private set; }
    public ulong CurrentTick { get; private set; }

    public CoopBossCombatState(CoopMissionEngine mission,
        CoopBotHealth health, CoopBossMapAnchors map, ulong spawnTick)
    {
        this.mission = mission ?? throw new ArgumentNullException(nameof(mission));
        ArgumentNullException.ThrowIfNull(health);
        ArgumentNullException.ThrowIfNull(map);
        if (mission.MissionType != "KillOpponent" ||
            mission.MissionIndex != health.MissionIndex ||
            mission.MapStage != map.Stage ||
            !mission.Started || mission.Outcome != MissionOutcome.InProgress ||
            spawnTick < mission.StartTick || spawnTick >= mission.DeadlineTick ||
            !float.IsFinite(health.MaximumHealth) || health.MaximumHealth < 0 ||
            map.BossStart.Fraction != 1 || !map.BossStart.Main)
            throw new InvalidDataException("Boss spawn differs from mission authority.");
        if (!mission.RegisterBoss(EntityId, spawnTick))
            throw new InvalidDataException("Boss was already registered for this mission.");

        MissionIndex = health.MissionIndex;
        DefendComponentFileId = map.BossStart.ComponentFileId;
        Position = map.BossStart.Position;
        Rotation = map.BossStart.Rotation;
        MaximumHealth = health.MaximumHealth;
        Health = MaximumHealth;
        SpawnTick = spawnTick;
        CurrentTick = spawnTick;
    }

    public bool Advance(ulong nextTick)
    {
        if (nextTick < CurrentTick)
            throw new InvalidOperationException("Boss combat tick moved backward.");
        CurrentTick = nextTick;
        return mission.AdvanceTick(nextTick);
    }

    internal bool ApplyHostDamage(float damage, ulong impactTick)
    {
        if (DeathTick.HasValue || mission.Outcome != MissionOutcome.InProgress ||
            impactTick != CurrentTick || impactTick >= mission.DeadlineTick ||
            !float.IsFinite(damage) || damage <= 0 || damage > 10_000_000)
            return false;

        float remaining = MathF.Max(0, Health - damage);
        if (remaining == 0 && !mission.ConfirmBossDeath(EntityId, impactTick))
            return false;

        Health = remaining;
        if (remaining == 0)
            DeathTick = impactTick;
        return true;
    }
}
