using War.Protocol;

namespace War.BattleServer;

/// <summary>Retains the source starting state of a corner attempt instead of restarting every look at zero.</summary>
internal sealed class CoopCornerPreparationPlan
{
    private const float FixedTickTolerance = 0.0001f;
    private readonly Clips _clips;
    private readonly float _initialLookSeconds;
    private readonly ulong _queuedFireOffset;
    private readonly StartKind _startKind;

    internal bool UsesFreshLookClock => _startKind == StartKind.FreshLook;

    private CoopCornerPreparationPlan(Clips clips, float seconds, StartKind startKind)
    {
        _clips = clips;
        _initialLookSeconds = seconds;
        _startKind = startKind;
        float remainingTicks = (clips.LookSeconds - seconds) * MatchManifest.TickRate;
        float rounded = MathF.Round(remainingTicks);
        if (startKind == StartKind.FireRestart)
        {
            _queuedFireOffset = 0;
        }
        else if (MathF.Abs(remainingTicks - rounded) <= FixedTickTolerance)
        {
            _queuedFireOffset = (ulong)rounded;
        }
        else
        {
            _queuedFireOffset = (ulong)MathF.Ceiling(remainingTicks);
        }
    }

    internal static CoopCornerPreparationPlan FromIdle(Clips clips)
    {
        ValidateClips(clips);
        return new CoopCornerPreparationPlan(clips, 0f, StartKind.FreshLook);
    }

    internal static CoopCornerPreparationPlan FromFrame(Clips clips, BattleInfantryAnimationFrame before)
    {
        ValidateClips(clips);
        ValidateBeforeFrame(before);
        // This is the recovered private ShotFromCover branch order, including enabled zero-weight states.
        foreach (BattleInfantryAnimationClip state in before.Clips)
        {
            if (state.ClipName == clips.Look)
            {
                return FromLook(clips, state.TimeSeconds);
            }
        }
        foreach (BattleInfantryAnimationClip state in before.Clips)
        {
            if (state.ClipName == clips.Fire)
            {
                return new CoopCornerPreparationPlan(clips, 0f, StartKind.FireRestart);
            }
        }
        foreach (BattleInfantryAnimationClip state in before.Clips)
        {
            if (state.ClipName == clips.Cover)
            {
                if (!float.IsFinite(state.TimeSeconds) || state.TimeSeconds < 0f ||
                    state.TimeSeconds > clips.CoverSeconds)
                {
                    throw new InvalidDataException("Invalid source cover-return phase.");
                }
                float seconds = (1f - state.TimeSeconds / clips.CoverSeconds) * clips.LookSeconds;
                return FromLook(clips, seconds);
            }
        }
        return FromIdle(clips);
    }

    internal BattleInfantryAnimationFrame Sample(ulong elapsedTicks, ulong sampleTick)
    {
        bool isFire = _startKind == StartKind.FireRestart || elapsedTicks >= _queuedFireOffset;
        float seconds = isFire
            ? (elapsedTicks - _queuedFireOffset) / (float)MatchManifest.TickRate
            : _initialLookSeconds + elapsedTicks / (float)MatchManifest.TickRate;
        var result = new BattleInfantryAnimationFrame { SampleTick = sampleTick };
        result.Clips.Add(new BattleInfantryAnimationClip
        {
            ClipName = isFire ? _clips.Fire : _clips.Look,
            TimeSeconds = seconds,
            Weight = 1f,
            Wrap = isFire ? BattleInfantryAnimationWrap.ClampForever : BattleInfantryAnimationWrap.Clamp
        });
        return result;
    }

    private static CoopCornerPreparationPlan FromLook(Clips clips, float seconds)
    {
        if (!float.IsFinite(seconds) || seconds < 0f || seconds > clips.LookSeconds)
        {
            throw new InvalidDataException("Invalid retained source look phase.");
        }
        return new CoopCornerPreparationPlan(clips, seconds, StartKind.RetainedLook);
    }

    private static void ValidateClips(Clips clips)
    {
        if ((clips.Look != "player_look_right3" || clips.Fire != "player_fire_right3") &&
            (clips.Look != "player_look_left3" || clips.Fire != "player_fire_left3") ||
            !float.IsFinite(clips.LookSeconds) || clips.LookSeconds <= 0f ||
            clips.LookSeconds * (double)MatchManifest.TickRate > ulong.MaxValue ||
            !float.IsFinite(clips.CoverSeconds) || clips.CoverSeconds <= 0f)
        {
            throw new InvalidDataException("A reviewed source corner clip pair and lengths are required.");
        }
    }

    private static void ValidateBeforeFrame(BattleInfantryAnimationFrame before)
    {
        if (before.Clips.Count is < 1 or > 2)
        {
            throw new InvalidDataException("A known prior source frame is required.");
        }
        var names = new HashSet<string>(StringComparer.Ordinal);
        double weight = 0d;
        foreach (BattleInfantryAnimationClip state in before.Clips)
        {
            BattleInfantryAnimationWrap expected = state.ClipName switch
            {
                "idle" or "idle_1" => BattleInfantryAnimationWrap.Loop,
                "player_fire_right3" or "player_fire_left3" => BattleInfantryAnimationWrap.ClampForever,
                "player_look_right3" or "player_look_left3" or "player_right_coverBack3" or
                    "player_left_coverBack3" => BattleInfantryAnimationWrap.Clamp,
                _ => BattleInfantryAnimationWrap.Unspecified
            };
            if (expected == BattleInfantryAnimationWrap.Unspecified || state.Wrap != expected ||
                !names.Add(state.ClipName) || !float.IsFinite(state.TimeSeconds) || state.TimeSeconds < 0f ||
                !float.IsFinite(state.Weight) || state.Weight is < 0f or > 1f)
            {
                throw new InvalidDataException("Invalid prior corner animation state.");
            }
            weight += state.Weight;
        }
        if (Math.Abs(weight - 1d) > FixedTickTolerance)
        {
            throw new InvalidDataException("The prior source frame must conserve its base-layer weight.");
        }
    }

    private enum StartKind
    {
        FreshLook,
        RetainedLook,
        FireRestart
    }

    internal sealed record Clips(string Look, string Fire, float LookSeconds, float CoverSeconds)
    {
        internal string Cover => Look == "player_look_right3" ? "player_right_coverBack3" : "player_left_coverBack3";
    }
}
