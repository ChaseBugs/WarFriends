using System.Numerics;
using War.BattleServer;

/// <summary>Checks the recovered planar threshold and shot guard without claiming native locomotion.</summary>
internal static class EnemyPointArrivalTests
{
    internal static int Run()
    {
        const float Threshold = 0.04f;
        int assertions = 0;
        var cases = new (Vector3 Position, bool IsPreparingShot, bool Expected)[]
        {
            (Vector3.Zero, false, true),
            (new Vector3(0, 100, 0), false, true),
            (new Vector3(Threshold, 0, 0), false, false),
            (new Vector3(MathF.BitDecrement(Threshold), 0, 0), false, true),
            (new Vector3(MathF.BitIncrement(Threshold), 0, 0), false, false),
            (new Vector3(0, 0, -Threshold), false, false),
            (new Vector3(0.02f, 0, 0.02f), false, true),
            (new Vector3(0.03f, 0, 0.03f), false, false),
            (Vector3.Zero, true, false),
        };
        foreach (var probe in cases)
        {
            if (EnemyPointArrivalPolicy.HasReached(probe.Position, Vector3.Zero, probe.IsPreparingShot) !=
                probe.Expected)
            {
                throw new Exception("Enemy point arrival changed its planar threshold or pending-shot guard.");
            }
            assertions++;
        }
        foreach (Vector3 invalid in new[] { new Vector3(float.NaN), new Vector3(float.MaxValue) })
        {
            try
            {
                EnemyPointArrivalPolicy.HasReached(invalid, Vector3.Zero, false);
                throw new Exception("Invalid host arrival position was accepted.");
            }
            catch (InvalidDataException)
            {
                assertions++;
            }
        }
        return assertions;
    }
}
