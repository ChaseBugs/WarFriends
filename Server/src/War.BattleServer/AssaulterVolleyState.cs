using System.Numerics;

namespace War.BattleServer;

/// <summary>Retains one source Corner volley and its animation/callback/round clocks.</summary>
internal sealed class AssaulterVolleyState
{
    internal AssaulterCornerAttempt Attempt { get; }
    internal CoopCornerPreparationPlan Preparation { get; }
    internal CoopCornerPreparationPlan.Clips Clips { get; }
    internal Quaternion StartRotation { get; }
    internal Quaternion FinalRotation { get; }
    internal List<ulong> RoundOffsets { get; } = [];
    internal AssaulterAimPrediction? Prediction { get; set; }
    internal ulong NextRoundTick { get; set; }
    internal ulong? CompletedTick { get; set; }
    internal ulong StartTick => Attempt.Aim.AcquisitionTick;

    internal AssaulterVolleyState(AssaulterCornerAttempt attempt, CoopCornerPreparationPlan preparation,
        CoopCornerPreparationPlan.Clips clips, (Quaternion Start, Quaternion Final) rotations)
    {
        Attempt = attempt;
        Preparation = preparation;
        Clips = clips;
        StartRotation = rotations.Start;
        FinalRotation = rotations.Final;
        NextRoundTick = CoopShotCallbackClock.FirstGameplayPollTick(attempt.CallbackTick ??
            throw new InvalidDataException("Assaulter volley has no accepted callback."));
    }
}
