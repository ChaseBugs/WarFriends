using War.Client;
using War.Protocol;

internal static class BattleProjectileRowPolicyTests
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
            bool rejected = false;
            try { action(); }
            catch (InvalidOperationException) { rejected = true; }
            Check(rejected, message);
        }

        BattleProjectileState Row(ulong id, string kind)
        {
            return new BattleProjectileState
            {
                ProjectileId = id,
                OwnerPlayerId = new string('a', 32),
                Kind = kind,
                ArmyUnitId = kind == "army-bullet" ? "ID_UNIT-SWAT" : "",
                WeaponSourceId = kind.StartsWith("shotgun-", StringComparison.Ordinal) ?
                    "Google2u.Shotgun_SPAS" : "",
                X = 1, Y = 2, Z = 3,
                VelocityX = 4, VelocityY = 5, VelocityZ = 6
            };
        }

        var emittedKinds = new[]
        {
            "grenade", "grenade-molotov", "pvp-bonus-grenade", "card-rocket",
            "card-grenadier", "army-bullet",
            "card-rocket-fake", "heavy-turret-bullet",
            "helicopter-bullet", "helicopter-fake-bullet",
            "assault-helicopter-bullet", "assault-helicopter-fake-bullet",
            "drone-bullet", "drone-fake-bullet",
            "shotgun-bullet", "shotgun-fake-bullet"
        };
        foreach (string kind in emittedKinds)
        {
            var snapshot = new MatchSnapshot();
            snapshot.Projectiles.Add(Row(1, kind));
            BattleProjectileRowPolicy.ValidateSnapshot(snapshot);
            var scan = new MatchProjectileBatch();
            scan.Projectiles.Add(Row(2, kind));
            BattleProjectileRowPolicy.ValidateScanRows(scan, 1);
            Check(true, "snapshot and scan accept Worker projectile kind: " + kind);
        }

        var duplicate = new MatchSnapshot();
        duplicate.Projectiles.Add(Row(1, "grenade"));
        duplicate.Projectiles.Add(Row(1, "drone-bullet"));
        Reject(() => BattleProjectileRowPolicy.ValidateSnapshot(duplicate),
            "snapshot rejects repeated projectile IDs");

        var unorderedScan = new MatchProjectileBatch();
        unorderedScan.Projectiles.Add(Row(3, "grenade"));
        unorderedScan.Projectiles.Add(Row(2, "grenade"));
        Reject(() => BattleProjectileRowPolicy.ValidateScanRows(unorderedScan, 1),
            "scan rejects rows behind its cursor");

        var invalid = new MatchSnapshot();
        invalid.Projectiles.Add(Row(1, "grenade"));
        void RejectChanged(Action<BattleProjectileState> change, string message)
        {
            invalid.Projectiles[0] = Row(1, "grenade");
            change(invalid.Projectiles[0]);
            Reject(() => BattleProjectileRowPolicy.ValidateSnapshot(invalid), message);
        }
        RejectChanged(row => row.OwnerPlayerId = new string('A', 32),
            "noncanonical owner is rejected");
        RejectChanged(row => row.Kind = "unrecognized-bullet",
            "unknown projectile kind is rejected");
        RejectChanged(row => row.WeaponSourceId = "Google2u.Shotgun_SPAS",
            "non-shotgun source metadata is rejected");
        RejectChanged(row => row.X = float.NaN,
            "nonfinite position is rejected");
        RejectChanged(row => row.VelocityZ = float.PositiveInfinity,
            "nonfinite velocity is rejected");
        RejectChanged(row => row.VelocityX = 10001,
            "out-of-bounds velocity is rejected");
        RejectChanged(row => row.ProjectileId = 0,
            "zero projectile identity is rejected");

        var armyIdentity = new MatchSnapshot();
        armyIdentity.Projectiles.Add(Row(1, "army-bullet"));
        armyIdentity.Projectiles[0].ArmySourceCardId = "ELITESWAT";
        BattleProjectileRowPolicy.ValidateSnapshot(armyIdentity);
        Check(true, "card army bullet retains its matching source identity");
        armyIdentity.Projectiles[0].ArmySourceCardId = "ELITESNIPER";
        Reject(() => BattleProjectileRowPolicy.ValidateSnapshot(armyIdentity),
            "card bullet cannot claim a different infantry family");
        armyIdentity.Projectiles[0].ArmySourceCardId = "";
        armyIdentity.Projectiles[0].ArmyUnitId = "ID_UNIT-";
        Reject(() => BattleProjectileRowPolicy.ValidateSnapshot(armyIdentity),
            "army bullet requires a unit identity");
        var unrelatedIdentity = new MatchSnapshot();
        unrelatedIdentity.Projectiles.Add(Row(1, "grenade"));
        unrelatedIdentity.Projectiles[0].ArmyUnitId = "ID_UNIT-SWAT";
        Reject(() => BattleProjectileRowPolicy.ValidateSnapshot(unrelatedIdentity),
            "unrelated projectile cannot carry infantry metadata");

        var badShotgun = new MatchSnapshot();
        badShotgun.Projectiles.Add(Row(1, "shotgun-bullet"));
        badShotgun.Projectiles[0].WeaponSourceId = "Google2u.Shotgun_Unknown";
        Reject(() => BattleProjectileRowPolicy.ValidateSnapshot(badShotgun),
            "shotgun requires a recovered source identity");

        var tooMany = new MatchSnapshot();
        for (ulong id = 1; id <= 129; id++)
            tooMany.Projectiles.Add(Row(id, "grenade"));
        Reject(() => BattleProjectileRowPolicy.ValidateSnapshot(tooMany),
            "snapshot cannot exceed the Worker projectile cap");

        return checks;
    }
}
