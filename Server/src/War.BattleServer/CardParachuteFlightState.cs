using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Advances the source parachute Rigidbody at 50 Hz inside a 30 Hz host match.
/// Two consecutive geometry contacts prevent one grazing overlap from landing
/// the soldier. This is a host approximation of Unity's collision callback.
/// </summary>
internal sealed class CardParachuteFlightState
{
    private readonly CardParachutePreContactMotion motion;
    private int fixedStepCredit;
    private int consecutiveContacts;

    internal Vector3 Position => motion.Position;
    internal int FixedFrame => motion.FixedFrame;
    internal bool Landed { get; private set; }

    internal CardParachuteFlightState(Vector3 spawnPosition,
        int ownerFraction, float initialSwayPhase)
    {
        motion = new CardParachutePreContactMotion(spawnPosition,
            ownerFraction, initialSwayPhase);
    }

    internal Vector3? AdvanceHostTick(RecoveredBattleMap map,
        Func<string, bool>? dynamicEnabled = null,
        Func<int, bool>? colliderEnabled = null,
        Func<int, int, int>? runtimeLayer = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (Landed)
            throw new InvalidDataException("Parachute flight already landed.");

        fixedStepCredit += 50;
        while (fixedStepCredit >= MatchManifest.TickRate)
        {
            fixedStepCredit -= MatchManifest.TickRate;
            motion.AdvanceFixedStep();

            bool touchesScene = CardParachuteCompoundContact
                .HasNearbySceneSurface(map, motion.Position,
                    motion.Rotation, 0.005f, dynamicEnabled,
                    colliderEnabled, runtimeLayer);
            consecutiveContacts = touchesScene ? consecutiveContacts + 1 : 0;
            if (consecutiveContacts == 2)
            {
                Landed = true;
                return motion.Position;
            }
        }

        return null;
    }
}
