using System.Numerics;

namespace War.BattleServer;

/// <summary>Retains one prepared source attempt until its callback and single gameplay shot finish.</summary>
internal sealed class GunslingerShotAttempt
{
    internal GunslingerPreparedAim Aim { get; }
    internal CoopInfantryShotBatch Batch { get; }
    internal GunslingerFireLoopEntry LoopEntry { get; }
    internal ulong CallbackTick { get; }
    internal ulong PollTick => GunslingerFiringClock.GameplayPollTick(CallbackTick);
    internal Quaternion StartRotation { get; }
    internal Quaternion FinalRotation { get; }
    internal GunslingerAimPrediction? Prediction { get; set; }
    internal ulong? CompletedTick { get; set; }
    internal Vector3 LastTargetPosition { get; set; }
    internal Vector3 LastTargetVelocity { get; set; }

    internal GunslingerShotAttempt(GunslingerPreparedAim aim, CoopInfantryShotBatch batch,
        (GunslingerFireLoopEntry Entry, ulong Callback) clock, (Quaternion Start, Quaternion Final) turn)
    {
        Aim = aim;
        Batch = batch;
        LoopEntry = clock.Entry;
        CallbackTick = clock.Callback;
        StartRotation = turn.Start;
        FinalRotation = turn.Final;
        LastTargetPosition = aim.Target.TransformPosition;
    }
}
