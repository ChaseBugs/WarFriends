using System.Numerics;
using War.BattleServer;

/// <summary>Checks reused component timing, pause and later root writes independently of route steering.</summary>
internal static class TransportCrewShotTurnTests
{
    internal static int Run()
    {
        const float duration = 0.2f;
        const float step = 1f / MatchManifest.TickRate;
        const float tolerance = 0.000001f;
        var tween = CoopShotRootTween.ForStartedComponent(duration);
        Quaternion target = Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.PI / 2);
        tween.Begin(Quaternion.Identity, target);
        var turn = new TransportCrewShotTurn(tween, 10);
        Quaternion first = turn.Advance(new(11, Quaternion.Identity, step));
        float factor = step / duration;
        float eased = factor - MathF.Sin(factor * MathF.Tau) / MathF.Tau;
        Require(1 - MathF.Abs(Quaternion.Dot(first, Quaternion.Slerp(Quaternion.Identity, target, eased))) < tolerance,
            "Helicopter crew invoked the one-time Start update again at its first shot.");
        Require(turn.Advance(new(12, first, 0)) == first, "Paused scaled time advanced the crew turn.");
        Quaternion root = first;
        for (ulong frame = 13; frame <= 20; frame++)
        {
            root = turn.Advance(new(frame, root, step));
        }
        Require(1 - MathF.Abs(Quaternion.Dot(root, target)) < tolerance, "Crew turn lost its completed target.");
        Quaternion external = Quaternion.CreateFromAxisAngle(Vector3.UnitY, -MathF.PI / 4);
        Require(turn.Advance(new(21, external, step)) == Quaternion.Normalize(external),
            "A disabled crew tween overwrote a later host root write.");
        Reject(() => turn.Advance(new(21, external, step)));
        Reject(() => turn.Advance(new(22, external, float.NaN)));
        Require(turn.Advance(new(22, external, 0)) == Quaternion.Normalize(external),
            "Invalid delta consumed the valid source frame.");
        return 7;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception is InvalidOperationException or InvalidDataException)
        {
            return;
        }
        throw new Exception("Invalid or repeated crew tween frame was accepted.");
    }
}
