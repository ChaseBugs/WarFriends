using System.Numerics;

namespace War.BattleServer;

internal sealed record AssaulterShotCallback(ulong Tick, AssaulterAimPrediction Prediction);

public sealed partial class MatchEngine
{
    private readonly Dictionary<ulong, AssaulterShotCallback> _assaulterCallbacks = [];

    /// <summary>Reads an executed host callback, separately from its previously scheduled deadline.</summary>
    internal AssaulterShotCallback? AssaulterCallback(ulong entityKey)
    {
        return _assaulterCallbacks.GetValueOrDefault(entityKey);
    }

    private void AdvanceAssaulterVolleys()
    {
        foreach (var (entityKey, volley) in _assaulterVolleys.OrderBy(row => row.Key).ToArray())
        {
            if (volley.CompletedTick.HasValue)
            {
                continue;
            }

            UpdateAssaulterShotTurn(entityKey, volley);
            if (volley.Prediction == null && tick >= volley.Attempt.CallbackTick)
            {
                ExecuteAssaulterCallback(entityKey, volley);
            }

            if (volley.Prediction == null || tick < volley.NextRoundTick)
            {
                continue;
            }

            LaunchAssaulterRound(entityKey, volley);
            if (Terminal)
            {
                return;
            }
            volley.RoundOffsets.Add(tick - volley.StartTick);
            if (volley.RoundOffsets.Count == volley.Attempt.Batch.Count)
            {
                volley.CompletedTick = tick;
                ArmyBaseShotStats shot = armyShots[entityKey];
                _assaulterAttempts[entityKey] = volley.Attempt with
                {
                    NextShotEligibleTick = NextAssaulterShotTick(shot), CompletedTick = tick
                };
            }
            else
            {
                volley.NextRoundTick = assaulterWeapon!.NextRoundEligibleTick(tick);
            }
        }
    }

    private void UpdateAssaulterShotTurn(ulong entityKey, AssaulterVolleyState volley)
    {
        ulong elapsed = tick - volley.StartTick;
        float fraction = elapsed >= AssaulterShotTurnTicks ? 1f : elapsed / (float)AssaulterShotTurnTicks;
        float eased = fraction - MathF.Sin(fraction * MathF.Tau) / MathF.Tau;
        Quaternion rotation = Quaternion.Slerp(volley.StartRotation, volley.FinalRotation, eased);
        infantryAnimations[entityKey].Facing = Vector3.Normalize(Vector3.Transform(Vector3.UnitZ, rotation));
    }

    private void ExecuteAssaulterCallback(ulong entityKey, AssaulterVolleyState volley)
    {
        AssaulterShotTarget target = volley.Attempt.Aim.Target;
        Vector3 muzzle = AssaulterVolleyMuzzle(entityKey, volley);
        Vector3 velocity = AssaulterCallbackTargetVelocity(target);
        AssaulterWeaponAimState weapon = _assaulterAimWeapons[entityKey];
        Vector3 prepared = volley.Attempt.Aim.TargetPosition;
        AssaulterAimPrediction prediction = target.IsPlayer
            ? weapon.StartPlayerShot(muzzle, prepared, velocity) : weapon.StartEntityShot(muzzle, prepared, velocity);
        volley.Prediction = prediction;
        _assaulterCallbacks[entityKey] = new AssaulterShotCallback(tick, prediction);
    }
}
