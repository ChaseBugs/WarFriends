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
        var selfBlast = new ResolvedPlayerDamage(150, CombatDamageType.Explosion,
            HasWeapon: true, FriendKill: true);
        var ownerAfterBlast = PlayerDamage.Resolve(body, 100, selfBlast, true, true, 1);
        var opponentAfterBlast = PlayerDamage.Resolve(body, 100, selfBlast, false, false, 1);
        Check(!ownerAfterBlast.Dead && ownerAfterBlast.Health == 100 &&
            opponentAfterBlast.Dead,
            "one player-owned explosion cannot kill its owner and opponent together");
        Check(PlayerDamage.Resolve(body with { TutorialProtection = true }, 100, lethal, false, false, 1).Health == 100, "tutorial lethal refund");
        Check(PlayerDamage.Resolve(body with { TutorialProtection = true }, 100, lethal with { Amount = 80 }, false, false, 1).Health == 20, "tutorial threshold is below twenty percent");
        var heal = new ResolvedPlayerDamage(-50, CombatDamageType.Heal, HasWeapon: false);
        Check(PlayerDamage.Resolve(body, 90, heal, false, false, 1).Health == 100, "healing upper clamp");
        var sourceMedkitHeal = new ResolvedPlayerDamage(-20,
            CombatDamageType.Basic, HasWeapon: false);
        Check(PlayerDamage.Resolve(body, 60, sourceMedkitHeal,
                  sameFraction: true, self: false, randomRoll: 1).Health == 80,
            "recovered medkit heals through a negative Basic damage amount");
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
        var noDamagePlayers = players.Select((p, i) => i == 1
            ? p with { Combat = body with { NoDamageChance = 1 } } : p).ToArray();
        var noDamageMatch = new MatchEngine(fixture with
            { MatchId = "source-zero-damage-player-contact", Players = noDamagePlayers });
        noDamageMatch.Admit(a); noDamageMatch.Admit(b);
        foreach (string id in new[] { a, b })
            noDamageMatch.Command(id, new MatchCommand { CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = noDamageMatch.ManifestHash } });
        noDamageMatch.Advance(60);
        var noDamageResult = noDamageMatch.ApplyResolvedPlayerDamage(a, b, shot, 0,
            confirmedProjectileImpact:true,sourcePlayerBullet:true);
        noDamageMatch.Command(b, new MatchCommand { CommandId = 2, Forfeit = new ForfeitCommand() });
        var noDamageState = noDamageMatch.TerminalEvidenceSnapshot();
        Check(noDamageResult is { Applied:true, Damage:0, Health:100 } &&
              noDamageState.Players[1].Health == 100 &&
              noDamageState.Players[0].ConfirmedPlayerBulletHits == 1 &&
              noDamageState.Players[0].ConfirmedEnemyHits == 1,
            "source-backed opposing player bullet contact counts despite a complete damage refund");

        var medkitMatch = new MatchEngine(manifest with
        {
            MatchId = "source-medkit-owner-healing"
        });
        medkitMatch.Admit(a);
        medkitMatch.Admit(b);
        foreach (string playerId in new[] { a, b })
            medkitMatch.Command(playerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = medkitMatch.ManifestHash }
            });
        medkitMatch.Advance(60);
        medkitMatch.ApplyResolvedPlayerDamage(b, a,
            new ResolvedPlayerDamage(40, CombatDamageType.Basic,
                HasWeapon: false), 1);
        Check(medkitMatch.Snapshot().Players[0].Health == 60,
            "medkit fixture begins with a server-injured owner");
        const string medkitEffectId = "81818181818181818181818181818181";
        Check(medkitMatch.TryApplyCardEffect(medkitEffectId, a,
            new WarCardEffectRequest("CardHealMeNow", System.Numerics.Vector3.Zero,
                0, 1, "MEDKIT")),
            "the recovered MEDKIT identity creates an instant owner effect");
        Check(medkitMatch.TryResolveMedkit(b, medkitEffectId) == null,
            "another player cannot resolve the owner's medkit");
        PlayerDamageResult? medkitResult = medkitMatch.TryResolveMedkit(
            a, medkitEffectId);
        Check(medkitResult is { Applied: true, Health: 80 } &&
              medkitMatch.Snapshot().Players[0].Health == 80,
            "MEDKIT heals exactly twenty percent of source maximum health");
        Check(medkitMatch.TryResolveMedkit(a, medkitEffectId) == null &&
              medkitMatch.Snapshot().Players[0].Health == 80,
            "one medkit effect cannot heal twice on the same host tick");
        var liveMatch = new MatchEngine(manifest with
        {
            MatchId = "live-medkit-owner-healing"
        });
        liveMatch.ConfigureCardSelection(["CardHealMeNow"]);
        liveMatch.ConfigureCardInventory([(a, "CardHealMeNow", 1)]);
        liveMatch.Admit(a);
        liveMatch.Admit(b);
        var medkitSelection = new SelectCardsCommand();
        medkitSelection.CardIds.Add("CardHealMeNow");
        Check(liveMatch.Command(a, new MatchCommand
        {
            CommandId = 1, SelectCards = medkitSelection
        }).Code == "cards-selected", "owner selects the trusted medkit");
        foreach (string playerId in new[] { a, b })
            liveMatch.Command(playerId, new MatchCommand
            {
                CommandId = playerId == a ? 2UL : 1UL,
                Ready = new ReadyCommand { ManifestHash = liveMatch.ManifestHash }
            });
        liveMatch.Advance(60);
        liveMatch.ApplyResolvedPlayerDamage(b, a,
            new ResolvedPlayerDamage(40, CombatDamageType.Basic, HasWeapon: false), 1);
        const string liveMedkitId = "83838383838383838383838383838383";
        var liveMedkit = new MatchCommand
        {
            CommandId = 3,
            UseMedkit = new UseMedkitCommand { RequestId = liveMedkitId }
        };
        var liveMedkitReply = liveMatch.Command(a, liveMedkit);
        Check(liveMedkitReply.Code == "medkit-healed" &&
              liveMatch.Snapshot().Players[0].Health == 80,
            "authenticated medkit command heals its owner using the host coefficient: " + liveMedkitReply.Code);
        Check(liveMatch.Command(a, liveMedkit).Code == "medkit-healed" &&
              liveMatch.Snapshot().Players[0].Health == 80,
            "transport retry replays the original medkit result without another heal");
        Check(liveMatch.Command(a, new MatchCommand
        {
            CommandId = 4,
            UseMedkit = new UseMedkitCommand { RequestId = "84848484848484848484848484848484" }
        }).Code == "medkit-unavailable", "exhausted inventory cannot heal again");
        const string healingStormEffectId = "82828282828282828282828282828282";
        Check(medkitMatch.TryApplyCardEffect(healingStormEffectId, a,
            new WarCardEffectRequest("CardHealingStorm",
                System.Numerics.Vector3.One, 0, 1, "HEALINGSTORM")) &&
              medkitMatch.TryResolveMedkit(a, healingStormEffectId) == null,
            "Healing Storm's allied-unit effect cannot be spent as a player medkit");
        return checks;
    }
}
