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

        Check(PlayerKevlar.CardMaximum(100) == 20,
            "Kevlar Up fills twenty percent of the current player maximum");
        Check(PlayerKevlar.BonusCrateMaximum(100) == 10,
            "recovered Kevlar crate fills ten percent of the current player maximum");
        Check(PvpBonusAmmoPolicy.RefilledReserve(20, 7) == 27 &&
              PvpBonusAmmoPolicy.RefilledReserve(0, 7) == 7,
            "recovered ammo crate adds one clip to reserve without changing clip ammo");
        Reject(() => PvpBonusAmmoPolicy.RefilledReserve(int.MaxValue, 7));
        Reject(() => PvpBonusAmmoPolicy.RefilledReserve(-1, 7));
        var armoredHit = PlayerKevlar.Absorb(Hit(new ResolvedPlayerDamage(25,
            CombatDamageType.Basic, HasWeapon: false)), 20, 20, 100, false);
        Check(armoredHit.Player.Health == 95 && armoredHit.RemainingKevlar == 0 &&
              !armoredHit.Player.Dead,
            "Kevlar absorbs its remaining twenty points before player death");
        var immortalArmorHit = PlayerKevlar.Absorb(PlayerDamage.Resolve(
            body with { Immortal = true }, 100,
            new ResolvedPlayerDamage(10, CombatDamageType.Basic, HasWeapon: false),
            false, false, 1), 20, 20, 100, true);
        Check(immortalArmorHit.Player.Health == 100 && immortalArmorHit.RemainingKevlar == 10,
            "source Kevlar still loses original damage while the player is immortal");
        Reject(() => PlayerKevlar.Absorb(Hit(shot), float.NaN, 20, 100, false));

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
        var kevlarMatch = new MatchEngine(manifest with { MatchId = "kevlar-up-player-damage" });
        kevlarMatch.ConfigureCardSelection(["KEVLARUP"]);
        kevlarMatch.ConfigureCardInventory([(b, "KEVLARUP", 1)]);
        kevlarMatch.Admit(a);
        kevlarMatch.Admit(b);
        var kevlarSelection = new SelectCardsCommand();
        kevlarSelection.CardIds.Add("KEVLARUP");
        Check(kevlarMatch.Command(b, new MatchCommand
        {
            CommandId = 1, SelectCards = kevlarSelection
        }).Code == "cards-selected", "player selects an allocated Kevlar Up card");
        kevlarMatch.Command(a, new MatchCommand { CommandId = 1,
            Ready = new ReadyCommand { ManifestHash = kevlarMatch.ManifestHash } });
        kevlarMatch.Command(b, new MatchCommand { CommandId = 2,
            Ready = new ReadyCommand { ManifestHash = kevlarMatch.ManifestHash } });
        kevlarMatch.Advance(60);
        var kevlarCommand = new MatchCommand { CommandId = 3,
            UseKevlarUp = new UseKevlarUpCommand
            { RequestId = "74747474747474747474747474747474" } };
        Check(kevlarMatch.Command(b, kevlarCommand).Code == "kevlar-up-applied" &&
              kevlarMatch.Command(b, kevlarCommand).Code == "kevlar-up-applied" &&
              kevlarMatch.Snapshot().Players[1].KevlarHealth == 20 &&
              kevlarMatch.Snapshot().Players[1].KevlarMaxHealth == 20,
            "authenticated Kevlar Up fills one replay-safe armor pool");
        kevlarMatch.ApplyResolvedPlayerDamage(a, b,
            new ResolvedPlayerDamage(15, CombatDamageType.Basic, HasWeapon: false), 1);
        Check(kevlarMatch.Snapshot().Players[1].Health == 100 &&
              kevlarMatch.Snapshot().Players[1].KevlarHealth == 5,
            "first player hit consumes Kevlar before health");
        kevlarMatch.ApplyResolvedPlayerDamage(a, b,
            new ResolvedPlayerDamage(10, CombatDamageType.Basic, HasWeapon: false), 1);
        Check(kevlarMatch.Snapshot().Players[1].Health == 95 &&
              kevlarMatch.Snapshot().Players[1].KevlarHealth == 0,
            "overflow damage reaches health after the remaining Kevlar breaks");
        Check(kevlarMatch.Command(b, new MatchCommand { CommandId = 4,
            UseKevlarUp = new UseKevlarUpCommand
            { RequestId = "75757575757575757575757575757575" } }).Code ==
              "kevlar-up-unavailable", "spent Kevlar Up cannot refill armor twice");
        var backstabMatch = new MatchEngine(manifest with { MatchId = "backstab-no-army" });
        backstabMatch.ConfigureCardSelection(["BACKSTAB"]);
        backstabMatch.ConfigureCardInventory([(a, "BACKSTAB", 1)]);
        backstabMatch.Admit(a);
        backstabMatch.Admit(b);
        var backstabSelection = new SelectCardsCommand();
        backstabSelection.CardIds.Add("BACKSTAB");
        Check(backstabMatch.Command(a, new MatchCommand { CommandId = 1,
            SelectCards = backstabSelection }).Code == "cards-selected",
            "player selects a source Backstab card");
        backstabMatch.Command(a, new MatchCommand { CommandId = 2,
            Ready = new ReadyCommand { ManifestHash = backstabMatch.ManifestHash } });
        backstabMatch.Command(b, new MatchCommand { CommandId = 1,
            Ready = new ReadyCommand { ManifestHash = backstabMatch.ManifestHash } });
        backstabMatch.Advance(60);
        var backstabCommand = new MatchCommand { CommandId = 3,
            UseBackstab = new UseBackstabCommand
            { RequestId = "76767676767676767676767676767676" } };
        Check(backstabMatch.Command(a, backstabCommand).Code == "backstab-no-target" &&
              backstabMatch.Command(a, backstabCommand).Code == "backstab-no-target" &&
              backstabMatch.Snapshot().CardEffects.Count(effect =>
                  effect.CardId == "CardBackstab") == 1,
            "Backstab spends once without a live opposing soldier and replays safely");
        Check(backstabMatch.Command(a, new MatchCommand { CommandId = 4,
            UseBackstab = new UseBackstabCommand
            { RequestId = "77777777777777777777777777777777" } }).Code ==
              "backstab-unavailable", "Backstab cannot spend exhausted inventory");
        var randomKevlarMatch = new MatchEngine(manifest with
            { MatchId = "random-kevlar-no-army" });
        randomKevlarMatch.ConfigureCardSelection(["RANDOMKEVLAR"]);
        randomKevlarMatch.ConfigureCardInventory([(a, "RANDOMKEVLAR", 1)]);
        randomKevlarMatch.Admit(a);
        randomKevlarMatch.Admit(b);
        var randomKevlarSelection = new SelectCardsCommand();
        randomKevlarSelection.CardIds.Add("RANDOMKEVLAR");
        Check(randomKevlarMatch.Command(a, new MatchCommand { CommandId = 1,
            SelectCards = randomKevlarSelection }).Code == "cards-selected",
            "player selects a source Random Kevlar card");
        randomKevlarMatch.Command(a, new MatchCommand { CommandId = 2,
            Ready = new ReadyCommand { ManifestHash = randomKevlarMatch.ManifestHash } });
        randomKevlarMatch.Command(b, new MatchCommand { CommandId = 1,
            Ready = new ReadyCommand { ManifestHash = randomKevlarMatch.ManifestHash } });
        randomKevlarMatch.Advance(60);
        var randomKevlarCommand = new MatchCommand { CommandId = 3,
            UseRandomKevlar = new UseRandomKevlarCommand
            { RequestId = "79797979797979797979797979797979" } };
        Check(randomKevlarMatch.Command(a, randomKevlarCommand).Code ==
                  "random-kevlar-no-target" &&
              randomKevlarMatch.Command(a, randomKevlarCommand).Code ==
                  "random-kevlar-no-target" &&
              randomKevlarMatch.Snapshot().CardEffects.Count(effect =>
                  effect.CardId == "CardRandomKevlar") == 1,
            "Random Kevlar spends once without a live allied soldier");
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
        Check(MedkitSourcePolicy.Resolve("MEDKIT")?.MaximumHealthFraction == .2f &&
              MedkitSourcePolicy.Resolve("SMALLMEDKIT")?.MaximumHealthFraction == .1f &&
              MedkitSourcePolicy.Resolve("BIGMEDKIT") is
                  { MinimumHealthFraction: .25f, MaximumHealthFraction: .35f,
                    DurationSeconds: 15 },
            "all three medikit coefficients and the timed duration come from CardConstants");
        medkitMatch.Advance(61);
        medkitMatch.ApplyResolvedPlayerDamage(b,a,
            new ResolvedPlayerDamage(20,CombatDamageType.Basic,HasWeapon:false),1);
        const string smallMedkitEffectId = "8b8b8b8b8b8b8b8b8b8b8b8b8b8b8b8b";
        Check(medkitMatch.TryApplyCardEffect(smallMedkitEffectId,a,
                  new WarCardEffectRequest("CardHealMeNowSmall",
                      System.Numerics.Vector3.Zero,0,1,"SMALLMEDKIT")) &&
              medkitMatch.TryResolveMedkit(a,smallMedkitEffectId) is
                  {Applied:true,Health:70},
            "SMALLMEDKIT heals ten percent of trusted maximum health");
        var liveMatch = new MatchEngine(manifest with
        {
            MatchId = "live-medkit-owner-healing"
        });
        liveMatch.ConfigureCardSelection(["MEDKIT"]);
        liveMatch.ConfigureCardInventory([(a, "MEDKIT", 2)]);
        liveMatch.Admit(a);
        liveMatch.Admit(b);
        var medkitSelection = new SelectCardsCommand();
        medkitSelection.CardIds.Add("MEDKIT");
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
        liveMatch.Advance(61);
        liveMatch.ApplyResolvedPlayerDamage(b, a,
            new ResolvedPlayerDamage(20, CombatDamageType.Basic, HasWeapon: false), 1);
        Check(liveMatch.Command(a, new MatchCommand
        {
            CommandId = 4,
            UseMedkit = new UseMedkitCommand { RequestId = "84848484848484848484848484848484" }
        }).Code == "medkit-healed" && liveMatch.Snapshot().Players[0].Health == 80,
            "an expired medkit releases its effect slot for another owned card");
        Check(liveMatch.Command(a, new MatchCommand
        {
            CommandId = 5,
            UseMedkit = new UseMedkitCommand { RequestId = "85858585858585858585858585858585" }
        }).Code == "medkit-unavailable", "exhausted inventory cannot heal again");
        var smallMatch = new MatchEngine(manifest with
        { MatchId = "live-small-medkit-owner-healing" });
        smallMatch.ConfigureCardSelection(["SMALLMEDKIT"]);
        smallMatch.ConfigureCardInventory([(a,"SMALLMEDKIT",1)]);
        smallMatch.Admit(a);
        smallMatch.Admit(b);
        var smallSelection = new SelectCardsCommand();
        smallSelection.CardIds.Add("SMALLMEDKIT");
        Check(smallMatch.Command(a,new MatchCommand {CommandId=1,
                  SelectCards=smallSelection}).Code=="cards-selected",
            "the small medikit requires its allocated source identity");
        smallMatch.Command(a,new MatchCommand {CommandId=2,
            Ready=new ReadyCommand {ManifestHash=smallMatch.ManifestHash}});
        smallMatch.Command(b,new MatchCommand {CommandId=1,
            Ready=new ReadyCommand {ManifestHash=smallMatch.ManifestHash}});
        smallMatch.Advance(60);
        smallMatch.ApplyResolvedPlayerDamage(b,a,
            new ResolvedPlayerDamage(40,CombatDamageType.Basic,HasWeapon:false),1);
        Check(smallMatch.Command(a,new MatchCommand {CommandId=3,
                  UseMedkit=new UseMedkitCommand
                  {RequestId="86868686868686868686868686868686",
                      SourceCardId="MEDKIT"}}).Code=="medkit-not-selected" &&
              smallMatch.Snapshot().CardActivations==0 &&
              smallMatch.Snapshot().Players[0].Health==60,
            "a MEDKIT assertion cannot spend the selected SMALLMEDKIT");
        var smallCommand=new MatchCommand {CommandId=4,
            UseMedkit=new UseMedkitCommand
            {RequestId="87878787878787878787878787878787",
                SourceCardId="SMALLMEDKIT"}};
        Check(smallMatch.Command(a,smallCommand).Code=="medkit-healed" &&
              smallMatch.Snapshot().Players[0].Health==70 &&
              smallMatch.Command(a,smallCommand).Code=="medkit-healed" &&
              smallMatch.Snapshot().Players[0].Health==70,
            "authenticated SMALLMEDKIT heals once and replays without another grant");
        var bigMatch = new MatchEngine(manifest with
        {
            MatchId = "live-big-medkit-timed-healing",
            IdleSeconds = 120
        }, combatRandom: () => .5f);
        bigMatch.ConfigureCardSelection(["BIGMEDKIT"]);
        bigMatch.ConfigureCardInventory([(a, "BIGMEDKIT", 1)]);
        bigMatch.Admit(a);
        bigMatch.Admit(b);
        var bigSelection = new SelectCardsCommand();
        bigSelection.CardIds.Add("BIGMEDKIT");
        Check(bigMatch.Command(a, new MatchCommand
        {
            CommandId = 1, SelectCards = bigSelection
        }).Code == "cards-selected", "owner selects BIGMEDKIT by its scene ID");
        bigMatch.Command(a, new MatchCommand
        {
            CommandId = 2, Ready = new ReadyCommand { ManifestHash = bigMatch.ManifestHash }
        });
        bigMatch.Command(b, new MatchCommand
        {
            CommandId = 1, Ready = new ReadyCommand { ManifestHash = bigMatch.ManifestHash }
        });
        bigMatch.Advance(60);
        bigMatch.ApplyResolvedPlayerDamage(b, a,
            new ResolvedPlayerDamage(40, CombatDamageType.Basic, HasWeapon: false), 1);
        var bigCommand = new MatchCommand
        {
            CommandId = 3,
            UseMedkit = new UseMedkitCommand
            {
                RequestId = "89898989898989898989898989898989",
                SourceCardId = "BIGMEDKIT"
            }
        };
        Check(bigMatch.Command(a, bigCommand).Code == "big-medkit-active" &&
              bigMatch.Snapshot().Players[0].Health == 60 &&
              bigMatch.Command(a, bigCommand).Code == "big-medkit-active",
            "BIGMEDKIT reserves once and does not heal immediately or on retry");
        for (ulong healingTick = 61; healingTick < 90; healingTick++)
            bigMatch.Advance(healingTick);
        Check(bigMatch.Snapshot().Players[0].Health == 60,
            "timed medikit waits for its first full second");
        bigMatch.Advance(90);
        Check(Math.Abs(bigMatch.Snapshot().Players[0].Health - 62) < .001f,
            "the fixed random draw gives two health per second");
        for (ulong healingTick = 91; healingTick <= 510; healingTick++)
            bigMatch.Advance(healingTick);
        Check(Math.Abs(bigMatch.Snapshot().Players[0].Health - 90) < .01f &&
              bigMatch.Snapshot().CardEffects.Count == 0,
            "fifteen pulses total thirty health and the effect expires: " +
            bigMatch.Snapshot().Players[0].Health + ", effects=" +
            bigMatch.Snapshot().CardEffects.Count);
        var maxHealthMatch = new MatchEngine(manifest with
        {
            MatchId = "live-max-health-card"
        });
        maxHealthMatch.ConfigureCardSelection(["MAXHEALTHINC"]);
        maxHealthMatch.ConfigureCardInventory([(a, "MAXHEALTHINC", 1)]);
        maxHealthMatch.Admit(a);
        maxHealthMatch.Admit(b);
        var maxHealthSelection = new SelectCardsCommand();
        maxHealthSelection.CardIds.Add("MAXHEALTHINC");
        Check(maxHealthMatch.Command(a, new MatchCommand
        {
            CommandId = 1, SelectCards = maxHealthSelection
        }).Code == "cards-selected", "owner selects the source max-health card");
        maxHealthMatch.Command(a, new MatchCommand
        {
            CommandId = 2,
            Ready = new ReadyCommand { ManifestHash = maxHealthMatch.ManifestHash }
        });
        maxHealthMatch.Command(b, new MatchCommand
        {
            CommandId = 1,
            Ready = new ReadyCommand { ManifestHash = maxHealthMatch.ManifestHash }
        });
        maxHealthMatch.Advance(60);
        maxHealthMatch.ApplyResolvedPlayerDamage(b, a,
            new ResolvedPlayerDamage(40, CombatDamageType.Basic,
                HasWeapon: false), 1);
        var maxHealthCommand = new MatchCommand
        {
            CommandId = 3,
            UseMaxHealth = new UseMaxHealthCommand
            {
                RequestId = "90909090909090909090909090909090"
            }
        };
        Check(maxHealthMatch.Command(a, maxHealthCommand).Code ==
                  "max-health-increased" &&
              Math.Abs(maxHealthMatch.Snapshot().Players[0].MaxHealth - 110) < .001f &&
              Math.Abs(maxHealthMatch.Snapshot().Players[0].Health - 70) < .001f,
            "scene 1.1 multiplier increases maximum and heals the same ten points");
        Check(maxHealthMatch.Command(a, maxHealthCommand).Code ==
                  "max-health-increased" &&
              Math.Abs(maxHealthMatch.Snapshot().Players[0].MaxHealth - 110) < .001f,
            "replayed MAXHEALTHINC cannot multiply maximum health twice");
        maxHealthMatch.ApplyResolvedPlayerDamage(a, a,
            new ResolvedPlayerDamage(-100, CombatDamageType.Basic,
                HasWeapon: false), 1);
        Check(Math.Abs(maxHealthMatch.Snapshot().Players[0].Health - 110) < .001f &&
              maxHealthMatch.Snapshot().Players[1].MaxHealth == 100,
            "later combat uses the owner's new maximum and leaves the opponent unchanged");
        var spongeMatch = new MatchEngine(manifest with
        {
            MatchId = "live-bullet-sponge-dodge",
            DurationSeconds = 90,
            IdleSeconds = 120
        });
        spongeMatch.ConfigureCardSelection(["BULLETHARMLESS"]);
        spongeMatch.ConfigureCardInventory([(a, "BULLETHARMLESS", 1)]);
        spongeMatch.Admit(a);
        spongeMatch.Admit(b);
        var spongeSelection = new SelectCardsCommand();
        spongeSelection.CardIds.Add("BULLETHARMLESS");
        Check(spongeMatch.Command(a, new MatchCommand
        {
            CommandId = 1, SelectCards = spongeSelection
        }).Code == "cards-selected", "owner selects BULLETHARMLESS");
        spongeMatch.Command(a, new MatchCommand
        {
            CommandId = 2, Ready = new ReadyCommand
            {
                ManifestHash = spongeMatch.ManifestHash
            }
        });
        spongeMatch.Command(b, new MatchCommand
        {
            CommandId = 1, Ready = new ReadyCommand
            {
                ManifestHash = spongeMatch.ManifestHash
            }
        });
        spongeMatch.Advance(60);
        var spongeCommand = new MatchCommand
        {
            CommandId = 3,
            UseBulletSponge = new UseBulletSpongeCommand
            {
                RequestId = "93939393939393939393939393939393"
            }
        };
        Check(spongeMatch.Command(a, spongeCommand).Code ==
                  "bullet-sponge-active" &&
              spongeMatch.Command(a, spongeCommand).Code ==
                  "bullet-sponge-active" &&
              spongeMatch.Snapshot().CardActivations == 1,
            "the card is spent once and a transport retry replays its result");
        const string spongeEffectId = "93939393939393939393939393939393";
        Check(!spongeMatch.TryResolveCardStatus(a, spongeEffectId, b),
            "self protection cannot be redirected to an opposing player");
        var spongeHit = new ResolvedPlayerDamage(10,
            CombatDamageType.Basic, HasWeapon: false);
        spongeMatch.ApplyResolvedPlayerDamage(b, a, spongeHit, .04f);
        Check(spongeMatch.Snapshot().Players[0].Health == 100,
            "a random roll below the source five percent avoids damage");
        spongeMatch.ApplyResolvedPlayerDamage(b, a, spongeHit, .05f);
        Check(spongeMatch.Snapshot().Players[0].Health == 90,
            "the five percent comparison is strict");
        spongeMatch.Advance(1860);
        spongeMatch.ApplyResolvedPlayerDamage(b, a, spongeHit, .04f);
        Check(spongeMatch.Snapshot().Players[0].Health == 80 &&
              spongeMatch.Snapshot().CardEffects.Count == 0,
            "the dodge chance ends when the sixty-second host lease expires");
        var immortalMatch = new MatchEngine(manifest with
        {
            MatchId = "live-swift-immortality",
            IdleSeconds = 120
        });
        immortalMatch.ConfigureCardSelection(["IMMORTAL"]);
        immortalMatch.ConfigureCardInventory([(a, "IMMORTAL", 1)]);
        immortalMatch.Admit(a);
        immortalMatch.Admit(b);
        var immortalSelection = new SelectCardsCommand();
        immortalSelection.CardIds.Add("IMMORTAL");
        Check(immortalMatch.Command(a, new MatchCommand
        {
            CommandId = 1, SelectCards = immortalSelection
        }).Code == "cards-selected", "owner selects source IMMORTAL identity");
        immortalMatch.Command(a, new MatchCommand
        {
            CommandId = 2, Ready = new ReadyCommand
            {
                ManifestHash = immortalMatch.ManifestHash
            }
        });
        immortalMatch.Command(b, new MatchCommand
        {
            CommandId = 1, Ready = new ReadyCommand
            {
                ManifestHash = immortalMatch.ManifestHash
            }
        });
        immortalMatch.Advance(60);
        var immortalCommand = new MatchCommand
        {
            CommandId = 3,
            UseImmortal = new UseImmortalCommand
            {
                RequestId = "94949494949494949494949494949494"
            }
        };
        Check(immortalMatch.Command(a, immortalCommand).Code ==
                  "immortal-active" &&
              immortalMatch.Command(a, immortalCommand).Code ==
                  "immortal-active" &&
              immortalMatch.Snapshot().CardActivations == 1,
            "IMMORTAL is consumed once and retries retain the first receipt");
        Check(!immortalMatch.TryResolveCardStatus(a,
                "94949494949494949494949494949494", b),
            "the owner-only card cannot be redirected to an opponent");
        PlayerDamageResult? immortalHit = immortalMatch.ApplyResolvedPlayerDamage(
            b, a, new ResolvedPlayerDamage(10,
                CombatDamageType.Basic, HasWeapon: false), 1);
        Check(immortalHit is { Applied: true, Health: 100,
                  Type: CombatDamageType.Immortal } &&
              immortalMatch.Snapshot().Players[1].Health == 100,
            "host damage honors the owner's temporary immortality only");
        immortalMatch.Advance(300);
        immortalMatch.ApplyResolvedPlayerDamage(b, a,
            new ResolvedPlayerDamage(10, CombatDamageType.Basic,
                HasWeapon: false), 1);
        Check(immortalMatch.Snapshot().Players[0].Health == 90 &&
              immortalMatch.Snapshot().CardEffects.Count == 0,
            "ordinary damage resumes at the exact eight-second expiry tick");
        Check(immortalMatch.Command(a, immortalCommand).Code ==
                  "immortal-active" &&
              immortalMatch.Snapshot().CardEffects.Count == 0,
            "an old request cannot reactivate immortality after expiry");
        var aliasMatch = new MatchEngine(manifest with {MatchId="medkit-selection-identity"});
        aliasMatch.ConfigureCardSelection(["MEDKIT","CardHealMeNow"]);
        aliasMatch.ConfigureCardInventory([(a,"MEDKIT",1)]);
        aliasMatch.Admit(a);
        aliasMatch.Admit(b);
        var wrongSelection = new SelectCardsCommand();
        wrongSelection.CardIds.Add("CardHealMeNow");
        Check(aliasMatch.Command(a,new MatchCommand {CommandId=1,
                  SelectCards=wrongSelection}).Code=="invalid-card-selection"&&
              !aliasMatch.Snapshot().Players[0].CardsSelected&&
              aliasMatch.Snapshot().CardActivations==0,
            "a class-name selection cannot replace Backend inventory bound to its source ID");
        var unitCardMatch = new MatchEngine(manifest with {MatchId="closed-unit-card-activation"});
        unitCardMatch.ConfigureCardSelection(["HEAVYDRONE"]);
        unitCardMatch.ConfigureCardInventory([(a,"HEAVYDRONE",1)]);
        unitCardMatch.Admit(a);
        unitCardMatch.Admit(b);
        var unitCardSelection = new SelectCardsCommand();
        unitCardSelection.CardIds.Add("HEAVYDRONE");
        Check(unitCardMatch.Command(a,new MatchCommand {CommandId=1,
            SelectCards=unitCardSelection}).Code=="cards-selected",
            "owner may select a trusted unit card before battle");
        unitCardMatch.Command(a,new MatchCommand {CommandId=2,
            Ready=new ReadyCommand {ManifestHash=unitCardMatch.ManifestHash}});
        unitCardMatch.Command(b,new MatchCommand {CommandId=1,
            Ready=new ReadyCommand {ManifestHash=unitCardMatch.ManifestHash}});
        unitCardMatch.Advance(60);
        var closedUnitCard = unitCardMatch.Command(a,new MatchCommand
        {
            CommandId=3,
            UseUnitCard=new UseUnitCardCommand
            {
                RequestId="b4b4b4b4b4b4b4b4b4b4b4b4b4b4b4b4",
                SourceCardId="HEAVYDRONE"
            }
        });
        Check(closedUnitCard.Code=="unit-card-unavailable"&&
              unitCardMatch.Snapshot().CardActivations==0&&
              unitCardMatch.ArmyEntityBatch(a,0,0).ActiveCount==0,
            "the typed unit-card command stays closed until host entities are authoritative");
        const string healingStormEffectId = "82828282828282828282828282828282";
        Check(medkitMatch.TryApplyCardEffect(healingStormEffectId, a,
            new WarCardEffectRequest("CardHealingStorm",
                System.Numerics.Vector3.One, 0, 1, "HEALINGSTORM")) &&
              medkitMatch.TryResolveMedkit(a, healingStormEffectId) == null,
            "Healing Storm's allied-unit effect cannot be spent as a player medkit");
        return checks;
    }
}
