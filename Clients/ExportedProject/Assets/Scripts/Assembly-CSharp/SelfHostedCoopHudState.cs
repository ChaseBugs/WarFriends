using System;
using War.Client;
using War.Protocol;

/// <summary>Reads source mission progress from the host clock without running local objective simulation.</summary>
public sealed class SelfHostedCoopHudState
{
    private const float HostTicksPerSecond = 30f;

    /// <summary>Gets the admitted match owning this view.</summary>
    public string MatchId { get; private set; }

    /// <summary>Gets the signed manifest identity owning this view.</summary>
    public string ManifestHash { get; private set; }

    /// <summary>Gets the source mission index represented by this view.</summary>
    public int MissionIndex { get; private set; }

    /// <summary>Gets the remaining host mission time in seconds.</summary>
    public float RemainingSeconds { get; private set; }

    /// <summary>Gets the complete source mission duration in seconds.</summary>
    public float DurationSeconds { get; private set; }

    /// <summary>Gets the source-specific progress ratio.</summary>
    public float Progress { get; private set; }

    /// <summary>Gets the integer argument consumed by the recovered mission HUD formatter.</summary>
    public int ObjectiveProgress { get; private set; }

    private SelfHostedCoopHudState()
    {
        MatchId = string.Empty;
        ManifestHash = string.Empty;
    }

    /// <summary>Validates a started source mission before exposing its clock or objective counters.</summary>
    public static SelfHostedCoopHudState FromSnapshot(MatchSnapshot snapshot, string localPlayerId)
    {
        CoopOutcomeProjection.ForPlayer(snapshot, localPlayerId);
        BattleCoopState mission = snapshot.Coop;
        if (string.IsNullOrEmpty(snapshot.MatchId) || string.IsNullOrEmpty(snapshot.ManifestHash) ||
            !mission.Started || mission.MissionIndex < 0 || mission.EnemyKills < 0 || mission.ObjectiveTarget < 0)
        {
            throw new InvalidOperationException("A source HUD needs a started mission with valid counters.");
        }

        var view = new SelfHostedCoopHudState
        {
            MatchId = snapshot.MatchId,
            ManifestHash = snapshot.ManifestHash,
            MissionIndex = mission.MissionIndex,
            DurationSeconds = (mission.DeadlineTick - snapshot.StartTick) / HostTicksPerSecond,
            RemainingSeconds = (mission.DeadlineTick - snapshot.ServerTick) / HostTicksPerSecond
        };
        view.ReadObjective(snapshot, localPlayerId);
        return view;
    }

    private void ReadObjective(MatchSnapshot snapshot, string localPlayerId)
    {
        BattleCoopState mission = snapshot.Coop;
        switch (mission.MissionType)
        {
            case "KillXEnemies":
                ObjectiveProgress = mission.EnemyKills;
                Progress = DivideByTarget(ObjectiveProgress, mission.ObjectiveTarget);
                break;
            case "Score":
                ObjectiveProgress = CoopScoreProjection.ForPlayer(snapshot, localPlayerId).TotalScore;
                Progress = Math.Min(1f, DivideByTarget(ObjectiveProgress, mission.ObjectiveTarget));
                break;
            case "SurviveXSeconds":
                Progress = (DurationSeconds - RemainingSeconds) / DurationSeconds;
                break;
            // BotMission inherits the base zero progress; its objective text identifies the boss.
            case "KillOpponent":
                Progress = 0f;
                break;
        }
    }

    private static float DivideByTarget(int value, int target)
    {
        if (target <= 0)
        {
            throw new InvalidOperationException("Kill and Score mission HUD targets must be positive.");
        }

        return (float)value / target;
    }
}
