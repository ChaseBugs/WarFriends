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

        var canopyRoster = new ArmyEntityPageAccumulator();
        canopyRoster.Add(Page(8, 5, 102, true, 1, 2, 3));
        canopyRoster.Add(Page(8, 5, 103, false, 4, 5));
        Check(canopyRoster.Complete && canopyRoster.Snapshot().Count == 5,
            "a three-entity canopy page completes with its next ordered page");

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
        var shortPage = new ArmyEntityPageAccumulator();
        Reject(() => shortPage.Add(Page(7, 5, 100, true, 1, 2)),
            "an undersized nonterminal canopy page was accepted");

        var falling = new BattleArmyEntityState
        {
            UnitId = "ID_UNIT-PARATROOPER",
            SourceCardId = "ELITEPARA",
            ParachuteActive = true,
            ParachuteRotation = new BattleJointRotation { W = 1 }
        };
        Check(MatchConnection.ValidParachute(falling, 60),
            "the card Paratrooper can carry a normalized flight rotation");
        falling.ParachuteRotation.W = 2;
        Check(!MatchConnection.ValidParachute(falling, 60),
            "the SDK rejects a damaged parachute rotation");
        falling.ParachuteRotation.W = 1;
        falling.SourceCardId = "";
        Check(!MatchConnection.ValidParachute(falling, 60),
            "an ordinary unit cannot claim the card parachute visual");
        falling.SourceCardId = "ELITEPARA";
        falling.ParachuteActive = false;
        Check(!MatchConnection.ValidParachute(falling, 60),
            "a landed unit cannot retain an active flight rotation");
        falling.ParachuteRotation = null;
        Check(MatchConnection.ValidParachute(falling, 60),
            "the landed card unit clears its separate flight visual");
        falling.SpawnTick = 60;
        falling.PositionTick = 61;
        falling.ParachuteLandingTick = 61;
        falling.ParachuteLandingY = 4;
        falling.ParachuteRotation = new BattleJointRotation { W = 1 };
        Check(MatchConnection.ValidParachute(falling, 61) &&
              MatchConnection.ValidParachute(falling, 150),
            "a landed canopy remains at its impact position for 90 host ticks");
        Check(!MatchConnection.ValidParachute(falling, 151),
            "the SDK rejects a canopy after the recovered three-second lifetime");
        falling.ParachuteLandingTick = 59;
        Check(!MatchConnection.ValidParachute(falling, 61),
            "landing before the card soldier spawned is invalid");

        return checks;
    }
}
