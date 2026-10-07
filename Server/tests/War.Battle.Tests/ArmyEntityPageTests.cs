using War.Client;
using War.Protocol;

internal static class ArmyEntityPageTests
{
    internal static int Run()
    {
        int checks = 0;
        void Check(bool condition, string message)
        {
            if (!condition) throw new Exception(message);
            checks++;
        }

        void Reject(Action action, string message)
        {
            try { action(); }
            catch (InvalidOperationException) { checks++; return; }
            throw new Exception(message);
        }

        MatchArmyEntityBatch Page(ulong revision, uint count, ulong tick, bool hasMore,
            params ulong[] keys)
        {
            var page = new MatchArmyEntityBatch
            {
                Code = "entities",
                Revision = revision,
                ActiveCount = count,
                ServerTick = tick,
                HasMore = hasMore
            };
            foreach (ulong key in keys)
                page.Entities.Add(new BattleArmyEntityState { EntityKey = key });
            return page;
        }

        var first = Page(7, 5, 100, true, 1, 2, 3, 4);
        var last = Page(7, 5, 101, false, 5);
        var roster = new ArmyEntityPageAccumulator();
        roster.Add(first);
        Check(!roster.Complete && roster.Cursor == 4 && roster.Revision == 7,
            "first army page retains its cursor and roster revision");
        Reject(() => roster.Snapshot(), "An incomplete army roster was exposed.");
        roster.Add(last);
        Check(roster.Complete && roster.Snapshot().Select(row => row.EntityKey)
                  .SequenceEqual(new ulong[] { 1, 2, 3, 4, 5 }),
            "later-tick page completes one ordered five-entity roster");
        first.Entities[0].EntityKey = 99;
        Check(roster.Snapshot()[0].EntityKey == 1,
            "published roster owns copies of received entity rows");
        Reject(() => roster.Add(last), "A complete roster accepted another page.");

        void RejectSecond(MatchArmyEntityBatch second, string message)
        {
            var candidate = new ArmyEntityPageAccumulator();
            candidate.Add(Page(7, 5, 100, true, 1, 2, 3, 4));
            Reject(() => candidate.Add(second), message);
        }

        RejectSecond(Page(8, 5, 101, false, 5),
            "Army pages with different membership revisions were combined.");
        RejectSecond(Page(7, 6, 101, false, 5, 6),
            "Army pages with different active counts were combined.");
        RejectSecond(Page(7, 5, 99, false, 5),
            "Army pages with a backward server tick were combined.");
        RejectSecond(Page(7, 5, 101, false, 4),
            "Army pages repeated an entity key across the page boundary.");
        RejectSecond(Page(7, 5, 101, false),
            "A short final army page was published as complete.");

        return checks;
    }
}
