using Google.Protobuf;
using War.Client;
using War.Protocol;
using War.Shared;

internal static class SabotageKillCreditTests
{
    internal static int Run()
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }
        var credit = new MatchEvent
        {
            EventId = 1, Tick = 60, Kind = MatchEventKind.SabotageKillCredited,
            ActorId = new string('a', 32), TargetId = new string('b', 32), Reason = "sabotage",
            SabotageKill = new SabotageKillPresentation
            {
                VictimEntityKey = (2UL << 32) | 1,
                UnitId = "ID_UNIT-TANK", RequestId = new string('c', 32),
                BaseSkillShotFlags = 0x5210
            }
        };
        Check(SabotageKillPresentationPolicy.Valid(credit) &&
              MatchEvent.Parser.ParseFrom(credit.ToByteArray()).Equals(credit),
            "source Tank kill flags and attribution survive protobuf round trip");
        void Reject(Action<MatchEvent> corrupt)
        {
            var forged = credit.Clone();
            corrupt(forged);
            var consumer = new MatchEventConsumer();
            bool dispatched = false;
            consumer.EventReceived += _ => dispatched = true;
            try
            {
                consumer.Consume(new MatchEventBatch { Code = "events", LatestEventId = 1, Events = { forged } });
                throw new Exception("Forged Sabotage credit reached a Client callback.");
            }
            catch (InvalidDataException)
            {
                Check(!dispatched && consumer.LastEventId == 0,
                    "invalid credit cannot dispatch or consume its event cursor");
            }
        }
        Reject(item => item.ActorId = item.TargetId);
        Reject(item => item.SabotageKill.RequestId = "invalid");
        Reject(item => item.SabotageKill.UnitId = "ID_UNIT-ASSAULT");
        Reject(item => item.SabotageKill.BaseSkillShotFlags |= 0x20);
        Reject(item => item.SabotageKill.VictimEntityKey = 0);
        Reject(item => item.Kind = MatchEventKind.ArmyDied);
        var validConsumer = new MatchEventConsumer();
        int callbacks = 0;
        validConsumer.EventReceived += _ => callbacks++;
        var batch = new MatchEventBatch { Code = "events", LatestEventId = 1, Events = { credit } };
        Check(validConsumer.Consume(batch) == 1 && callbacks == 1 && validConsumer.LastEventId == 1,
            "valid source credit dispatches once after a successful callback");
        return checks;
    }
}
