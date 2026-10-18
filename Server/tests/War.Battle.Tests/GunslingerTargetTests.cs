using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks source Head preference and live normal-unit selection before firing integration.</summary>
internal static class GunslingerTargetTests
{
    private const string UnitId = "ID_UNIT-GUNSLINGER";
    private const int HeadType = 8;
    private const int BodyType = 1;
    private const int OutType = 4;
    private const ulong SpawnTick = 61;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        int checks = CheckHeadPreference();
        checks += CheckHeadlessFallback();
        checks += CheckRejectedAuthority();
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        checks += CheckLiveSelection(content);
        return checks;
    }

    private static int CheckHeadPreference()
    {
        DroneShotTarget body = Target(1, BodyType);
        DroneShotTarget firstHead = Target(2, HeadType);
        DroneShotTarget secondHead = Target(3, HeadType);
        int draws = 0;
        DroneShotTarget? selected = GunslingerTargetPolicy.SelectShotTarget(
            [body, firstHead, Target(4, OutType), secondHead], count =>
            {
                draws++;
                Require(count == 2, "Gunslinger Head draw included Body or Out transforms.");
                return 1;
            });
        return Require(selected == secondHead && draws == 1,
            "Gunslinger did not draw once from the serialized Head subset.");
    }

    private static int CheckHeadlessFallback()
    {
        DroneShotTarget firstBody = Target(1, BodyType);
        int draws = 0;
        int ChooseEmpty(int count)
        {
            draws++;
            Require(count == 0, "A headless fallback redrew from AllIn instead of retaining index zero.");
            return 0;
        }

        DroneShotTarget? selected = GunslingerTargetPolicy.SelectShotTarget(
            [Target(2, OutType), firstBody, Target(3, BodyType)], ChooseEmpty);
        int checks = Require(selected == firstBody && draws == 1,
            "A headless Gunslinger opponent did not retain the first AllIn transform.");
        checks += Require(GunslingerTargetPolicy.SelectShotTarget([Target(2, OutType)], ChooseEmpty) == null,
            "A Gunslinger selected an Out-only opponent transform.");
        checks += Require(GunslingerTargetPolicy.SelectShotTarget([], ChooseEmpty) == null,
            "A Gunslinger invented a transform for an empty source list.");
        return checks;
    }

    private static int CheckRejectedAuthority()
    {
        DroneShotTarget head = Target(1, HeadType);
        int checks = Reject(() => GunslingerTargetPolicy.SelectShotTarget([head], _ => 1));
        checks += Reject(() => GunslingerTargetPolicy.SelectShotTarget([head, head], _ => 0));
        checks += Reject(() => GunslingerTargetPolicy.SelectShotTarget(
            [head with { Position = new Vector3(float.NaN) }], _ => 0));
        checks += Reject(() => GunslingerTargetPolicy.SelectShotTarget([Target(1, BodyType)], _ => -1));
        return checks;
    }

    private static int CheckLiveSelection(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId);
        Deploy(host, OwnerId);
        host.Advance(SpawnTick);
        ulong attacker = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.First().EntityKey;
        AssaulterShotTarget player = Select(host, attacker);
        int checks = Require(player.IsPlayer && player.OwnerPlayerId == OpponentId,
            "A Gunslinger without opposing units did not use the source player fallback.");

        Deploy(host, OpponentId);
        host.Advance(SpawnTick + 1);
        BattleArmyEntityState[] opponents = host.ArmyEntityBatch(OpponentId, 0, 0).Entities
            .Where(entity => entity.OwnerPlayerId == OpponentId).ToArray();
        checks += Require(opponents.Length > 0, "Ordinary deployment did not create opposing Gunslingers.");
        checks += CheckCurrentHead(host, attacker, opponents);
        Vector3 previousHeadPosition = Select(host, attacker).TransformPosition;
        host.Advance(SpawnTick + 2);
        checks += CheckCurrentHead(host, attacker, opponents);
        checks += Require(Select(host, attacker).TransformPosition != previousHeadPosition,
            "A walking Gunslinger opponent retained a stale spawn Head position.");
        foreach (BattleArmyEntityState opponent in opponents)
        {
            checks += Require(host.ConfirmArmyDeath(opponent.EntityKey, false),
                "The Gunslinger target fixture failed authoritative opponent cleanup.");
        }

        AssaulterShotTarget fallback = Select(host, attacker);
        checks += Require(fallback.IsPlayer && fallback.OwnerPlayerId == OpponentId,
            "Removed infantry remained selectable or friendly units blocked player fallback.");
        checks += Reject(() => host.SelectGunslingerShotTarget(ulong.MaxValue));
        return checks;
    }

    private static int CheckCurrentHead(MatchEngine host, ulong attacker,
        IReadOnlyList<BattleArmyEntityState> opponents)
    {
        AssaulterShotTarget selected = Select(host, attacker);
        BattleArmyEntityState opponent = opponents.Single(row =>
            selected.EntityId == "army:" + row.EntityKey.ToString(System.Globalization.CultureInfo.InvariantCulture));
        DroneShotTarget head = host.InfantryShotTargets(opponent.EntityKey)?.Single(row => row.Type == HeadType) ??
            throw new InvalidOperationException("Live Gunslinger opponent lost its sampled source Head.");
        return Require(!selected.IsPlayer && selected.OwnerPlayerId == OpponentId &&
            selected.TransformFileId == head.TransformFileId && selected.TransformPosition == head.Position &&
            selected.ShotTargetType == HeadType,
            "Live Gunslinger selection did not preserve the current opposing Head transform.");
    }

    private static void Deploy(MatchEngine host, string playerId)
    {
        int option = host.ArmyBatch(playerId).OptionIndexes.First();
        Require(host.Command(playerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The Gunslinger target fixture failed ordinary deployment.");
    }

    private static AssaulterShotTarget Select(MatchEngine host, ulong attacker)
    {
        return host.SelectGunslingerShotTarget(attacker) ??
            throw new InvalidOperationException("A live Gunslinger fixture lost its selectable source transform.");
    }

    private static DroneShotTarget Target(int identity, int type)
    {
        return new DroneShotTarget(identity, type, new Vector3(identity, 0f, 0f));
    }

    private static int Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return 1;
        }

        throw new InvalidOperationException("Invalid Gunslinger target authority was accepted.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
}
