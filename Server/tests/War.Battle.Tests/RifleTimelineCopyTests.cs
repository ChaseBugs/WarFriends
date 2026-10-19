using War.BattleServer;

/// <summary>Preserves cover playback clocks while isolating a not-yet-committed shot.</summary>
internal static class RifleTimelineCopyTests
{
    internal static void Run(PlayerPoseCatalog poses)
    {
        foreach (int family in new[] { 0, 2, 4, 5, 7, 9, 10, 13, 15 })
        {
            var original = new RifleCoverTimeline(poses, family);
            foreach (double time in new[] { 0.0, 0.01, 0.2, 0.5, 0.8, 1.5 })
            {
                original.Advance(time);
                RifleCoverTimeline pending = original.Copy();
                RequireEqual(original, pending);

                RifleCoverPhase phase = original.Phase;
                RifleClipSelection selection = original.Selection;
                RifleClipLayer[] layers = original.Layers.ToArray();
                pending.Shot(false);
                if (original.Phase != phase || original.Selection != selection ||
                    !original.Layers.SequenceEqual(layers))
                {
                    throw new Exception("An uncommitted shot changed the published cover animation.");
                }

                RifleCoverTimeline continuation = original.Copy();
                if (continuation.Advance(time + 0.001) != original.Advance(time + 0.001))
                {
                    throw new Exception("A cover copy lost its queued transition or hide deadline.");
                }
                RequireEqual(original, continuation);
                original.Shot(true);
            }
        }
        Console.WriteLine("PASS: nine cover families preserve playback clocks and isolate pending shots");
    }

    private static void RequireEqual(RifleCoverTimeline expected, RifleCoverTimeline actual)
    {
        if (actual.Phase != expected.Phase || actual.Selection != expected.Selection ||
            actual.RunClip != expected.RunClip || actual.HidingWait != expected.HidingWait ||
            actual.UncoverWait != expected.UncoverWait || !actual.Layers.SequenceEqual(expected.Layers))
        {
            throw new Exception("A cover timeline copy changed its source playback state.");
        }
    }
}
