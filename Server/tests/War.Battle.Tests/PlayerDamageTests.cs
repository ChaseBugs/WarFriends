using War.BattleServer;
using War.Protocol;
using War.Protocol.Transport;

internal static class PlayerDamageTests
{
    internal static int Run(MatchManifest fixture)
    {
        int checks = 0;
        void Check(bool value, string name) { if (!value) throw new Exception(name); checks++; }
        void Reject(Action action)
        {
            try { action(); } catch (InvalidDataException) { checks++; return; }
            throw new Exception("Malformed damage authority accepted.");
        }
        var body = new PlayerCombatManifest(100, 0.5f);
        var shot = new ResolvedPlayerDamage(80, CombatDamageType.Shot, PartWeight: 2, PlayerCoefficient: 0.25f, PlayerOvertimeCoefficient: 0.75f);
        PlayerDamageResult Hit(ResolvedPlayerDamage hit) => PlayerDamage.Resolve(body, 100, hit, false, false, 1);
        Check(Hit(shot).Health == 80, "shot -> part -> player coefficient");
        Check(Hit(shot with { Overtime = true }).Health == 40, "overtime uses distinct coefficient");
        Check(Hit(shot with { Type = CombatDamageType.Flame }).Health == 20, "flame excludes player shot coefficient");
        Check(Hit(shot with { Type = CombatDamageType.Poison, Amount = 10 }).Health == 80, "poison only takes part weight");
        Check(Hit(shot with { Type = CombatDamageType.Explosion }).Health == 60, "explosion excludes shot coefficient");
        Check(Hit(shot with { Type = CombatDamageType.Shiver, HasWeapon = false, ExplosiveCoefficient = 0.1f }).Health == 84, "weaponless shiver coefficient");
        Check(Hit(shot with { Type = CombatDamageType.Explosion, HasWeapon = false, ExplosiveOvertimeCoefficient = 0.5f, Overtime = true }).Health == 20, "weaponless overtime coefficient");
        Check(!PlayerDamage.Resolve(body, 100, shot, true, false, 1).Applied, "friendKill false rejects friendly weapon");
        Check(PlayerDamage.Resolve(body, 100, shot with { FriendKill = true, FriendlyCoefficient = 0.5f }, true, false, 1).Health == 90, "friendly coefficient applied last");
        var immune = PlayerDamage.Resolve(body with { Immortal = true }, 100, shot, false, false, 1);
        Check(immune.Health == 100 && immune.Type == CombatDamageType.Immortal && immune.OriginalDamage == 20, "immortality preserves original damage");
        Check(PlayerDamage.Resolve(body with { Immortal = true }, 100, shot with { IgnoreImmortality = true }, false, false, 1).Health == 80, "trusted ignore immortality");
        var lethal = new ResolvedPlayerDamage(150, CombatDamageType.Basic, HasWeapon: false);
        var death = Hit(lethal);
        Check(death.Dead && death.Health == -50 && death.OneHit, "source retains negative lethal health");
        Check(!PlayerDamage.Resolve(body, 80, lethal, false, false, 1).OneHit, "one-hit requires full initial health");
        var dodge = PlayerDamage.Resolve(body with { NoDamageChance = 0.5f }, 100, lethal, false, false, 0.49f);
        Check(!dodge.Dead && dodge.Health == 100 && dodge.Damage == 0, "damage callback refunds before lethal check");
        Check(PlayerDamage.Resolve(body with { NoDamageChance = 0.5f }, 100, lethal, false, false, 0.5f).Dead, "dodge comparison is strict");
        Check(PlayerDamage.Resolve(body, 100, lethal, true, true, 1).Health == 100, "self damage refund");
        Check(PlayerDamage.Resolve(body with { TutorialProtection = true }, 100, lethal, false, false, 1).Health == 100, "tutorial lethal refund");
        Check(PlayerDamage.Resolve(body with { TutorialProtection = true }, 100, lethal with { Amount = 80 }, false, false, 1).Health == 20, "tutorial threshold is below twenty percent");
        var heal = new ResolvedPlayerDamage(-50, CombatDamageType.Heal, HasWeapon: false);
        Check(PlayerDamage.Resolve(body, 90, heal, false, false, 1).Health == 100, "healing upper clamp");
        Reject(() => Hit(shot with { Amount = float.NaN }));
        Reject(() => Hit(shot with { Amount = -1 }));
        Reject(() => Hit(shot with { Amount = -1, Type = CombatDamageType.Shiver }));
        Reject(() => Hit(shot with { PartWeight = float.PositiveInfinity }));
        Reject(() => Hit(shot with { Type = (CombatDamageType)99 }));
        Reject(() => PlayerDamage.Resolve(body, 101, shot, false, false, 1));
        Reject(() => PlayerDamage.Resolve(body, 100, shot, false, false, float.NaN));
        Reject(() => PlayerDamage.Validate(body with { NoDamageChance = 1.1f }));

        var players = fixture.Players.Select((p, i) => p with { Fraction = i + 1, Combat = body }).ToArray();
        var manifest = fixture with { Players = players };
        Reject(() => MatchManifest.Validate(manifest with { Players = [players[0], players[1] with { Combat = null }] }));
        var engine = new MatchEngine(manifest);
        string a = players[0].PlayerId, b = players[1].PlayerId;
        Check(engine.ApplyResolvedPlayerDamage(a, b, lethal, 1) == null, "no damage before admission/start");
        engine.Admit(a); engine.Admit(b);
        foreach (string id in new[] { a, b }) engine.Command(id, new MatchCommand { CommandId = 1, Ready = new ReadyCommand { ManifestHash = engine.ManifestHash } });
        engine.Advance(60);
        Reject(() => engine.ApplyResolvedPlayerDamage(a, b, lethal with { Amount = float.NaN }, 1));
        Check(engine.Snapshot().Players[1].Health == 100 && engine.Snapshot().Players[1].DamageRevision == 0, "rejected damage is atomic");
        Check(engine.ApplyResolvedPlayerDamage("outsider", b, lethal, 1) == null, "unresolved attacker rejected");
        engine.ApplyResolvedPlayerDamage(a, b, shot, 1);
        Check(engine.Snapshot().Players[1].Health == 80 && engine.Snapshot().Players[1].DamageRevision == 1, "server damage publishes health revision");
        var injuredSnapshot = engine.Snapshot();
        engine.ApplyResolvedPlayerDamage(a, b, lethal, 1);
        var snapshot = engine.Snapshot();
        Check(snapshot.ServerTick == injuredSnapshot.ServerTick && snapshot.StateRevision > injuredSnapshot.StateRevision, "same-tick damage snapshots ordered");
        Check(snapshot.Phase == BattlePhase.Ended && snapshot.WinnerPlayerId == a && snapshot.TerminalReason == "player-killed" && snapshot.Players[1].Dead && !snapshot.RewardEligible, "unscored death terminal");
        Check(engine.ApplyResolvedPlayerDamage(a, b, lethal, 1) == null && engine.Snapshot().Equals(snapshot), "terminal cannot damage twice");
        Check(PacketCodec.Encode(new Packet { Version = 1, SessionId = 1, Sequence = 1, MatchReply = engine.Reply(0, "state") }, new byte[32]).Length <= 1200, "health snapshot fits MTU");
        return checks;
    }
}
