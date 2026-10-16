# Recovered PvP skill-shot scoring

`PvpSkillShotScoreCatalog` now imports every active MainScene skill-shot row
from `Google2u.Skillshots.SCOREMP`. Its 19 rows preserve scene definition order,
source enum flags, localization IDs, and nonnegative C# integer point values.
The source scene serializes a 0.9-second combo window; the script's one-second
default is not the active scene value.

The extracted artifact binds the exact MainScene, recovered battle-content,
sheet script, and skill-shot enum digests. Startup checks its reviewed byte
hash, exact shape, complete source flag order, unique identities, and points
before publishing live combat content. Rows remain immutable after loading.
The artifact uses LF on both Windows and Linux so its reviewed byte hash is
stable across native deployments.

For confirmed Sabotage base flags, `Kill` contributes 20 points,
`OneHitKill` 6, and `VehicleDestroyed` 20: 46 total. A Tank adds 60 for
`TankDestroyed`, producing 106. These are source base contributions; combo,
revenge, and slow-motion evidence can add other recovered rows.

Normal player-owned army deaths now add `OneHitKill` only when the root had
full health before one host-confirmed lethal damage callback, matching
`DestroyableObject.DoDamage`. A live bonus-grenade burst awards that flag to
one full-health infantry and withholds it from three weakened infantry.
Normal rifle, mine, and Bazooka full-health deaths remain unverified.

Confirmed player-bullet infantry deaths now add the source `HeadShot` flag
only when the host collision has the pinned head sphere's path and damage
weight. The recovered `EnemyController` requires a `Shot` death on part index
one; body hits and explosion deaths do not qualify. A real animated-infantry
ray verifies the classifier, but a lethal player `Fire` headshot still needs
end-to-end proof.

## Runtime boundary

This catalog supplies trusted score data and composition. Confirmed host
damage and selected player-owned deaths now publish score and streak progress;
the remaining callback families and Client presentation are incomplete. The
recovered `SkillShotManager` first
resolves kill-combo flags, then calls `ScoreManager.AddSkillshot` in scene
definition order. That call increments the local/opponent count and score,
then adds each row's float contribution to kill-streak progress. `Update`
decays progress and can generate a gameplay bonus above 100. The source also
requires match-specific `dropCreates`, rank eligibility, multipliers, and
bonus ownership/placement rules.

Normal Unity callback integration remains closed until those transitions are
host-owned. Invoking the original callback with only the new base credit
would omit other source flags and let Client progress create bonuses. Future
host progress must preserve per-row float storage, observed Mono intermediate
precision, and callback order;
the aggregate integer score must not replace that ordered float calculation.
Match outcomes and currency rewards remain under their existing authority.

Regenerate with `python Server/tools/extract_pvp_skillshot_scores.py`.
Run focused validation with
`dotnet run --project Server/tests/War.Battle.Tests -c Release -- --pvp-scores-only`.
Tests cover all source scores, base-card composition, unsupported flags,
source mismatch, immutable rows, artifact damage, and live-content binding.

## Shared kill-combo state

`PvpKillComboState` now mirrors `SkillShotManager.RecieveKill` with a bounded
replay ledger. Its source window is 0.9f; an exact repeat returns the original
flag without advancing or rewinding current history. Malformed/nonfinite time,
changed receipt time, reordered new callbacks, and exhausted receipt capacity
fail before changing accepted state.

The recovered controller calls this shared manager for a non-network,
player-owned entity death **before** the friendly/opposing score filter.
Therefore a friendly death can advance combo history without awarding points.
An army-owned death takes a different branch. Player damage-hit and bonus-box
callbacks do not call `RecieveKill`. Do not create independent per-player
histories or count all generic damage events as eligible kills.

The isolated original-method Unity 2018.3 Mono probe captured 22 samples. Only
the two `Time.time` reads are replaced with controlled float inputs; the
recovered calculation and enum are compiled directly. Large clock samples
show Mono compares promoted operands rather than a rounded float sum. The
server stores float times/window but explicitly compares in double, retaining
the source float window value. All 22 source samples match.

The primitive is connected to selected host-confirmed army deaths. Complete
eligible-callback coverage, manager lifetime, and scaled-time parity remain
open. A receipt identifies one host-confirmed death, not a Client command
that may kill several entities. This probe does not verify Unity Play Mode,
the original Unity 5.2 Android runtime, or complete game statistics.

Run `Server/scripts/AuditPvpCombo.ps1` to regenerate the isolated Mono fixture.
Run `--pvp-combo-only` in the Battle test executable for source comparison,
replay, clock corruption, and capacity validation.

`PvpSkillShotScoreState` now implements one player's source multiplayer score
and all 19 skill-shot counters. `SkillShotManager.AddSkillshot` visits every
matching definition and `ScoreManager.AddSkillshot` increments that row once,
including zero-point definitions. This state accepts only host-confirmed flags
and a canonical host receipt, computes changes before publishing them, and
replays the original result without recounting or rewinding accumulated score.
Changed flags, unknown bits, malformed identity, and full replay capacity fail
without awarding anything. Consumers receive a read-only counter view.

This ledger is not yet the complete live ScoreManager replacement. The
coordinator and host-confirmed player-hit path now add progress with
server-owned card multipliers, but other eligible callbacks and the normal
Unity score presentation remain open. No Client-supplied flags or scores are
authorized by this class. Run `--pvp-score-state-only` for its ledger checks;
the complete Battle suite also includes them.

## Source score-streak parameters and remaining authority

`PvpBonusProgressCoordinator.RecordConfirmedPlayerOwnedDeath` joins the shared
combo, each owner's score/count ledger, and ordered streak gain under one
confirmed death receipt. It advances combo for a friendly player-owned death
without awarding score, then includes that history on a later enemy death.
Either score or progress capacity failure leaves the combo unchanged. The
caller must establish the non-network callback, player ownership, base flags,
victim faction and scaled source game time from host evidence. Live bullet,
normal/bonus grenade, mine, Bazooka, and Sabotage army deaths now use this
transition. Grenade and other blast paths include confirmed friendly deaths
in the shared combo without scoring them. The host uses simulation ticks
divided by the manifest tick rate; those ticks stop during a self-hosted
reconnect, matching the recovered Client's `TimeManager.Pause` dialog path.
The client also changes `Time.timeScale` for SlowMotion, which the Worker has
not implemented. Exact scaled-time and cross-cause callback order remain
unverified. Client presentation remains open.

The coordinator can now prepare a detached confirmed-death transition with its
complete combo, death-replay receipt, score, and streak progress. The host may
publish that candidate only after its source death proof succeeds. A focused
test verifies that preparation and replay leave the currently published state
unchanged. Live death paths publish the prepared state only after host death
evidence; focused match tests verify a normal M320 advances the shared combo
once, while a live collected-grenade burst earns DoubleKill, TripleKill, and
MultiKill across four confirmed infantry deaths. Blast paths use the host's
ordered `ArmyDied` events rather than entity-key sorting, and reject deaths
that disagree with the pre-blast roster.

`PvpScoreStreakPolicy` is now loaded with the combat package from the reviewed
`recovered-pvp-score-streak-policy.json`. Its digest and the scene/content
bindings are checked before content publication. The regeneration tool is
`Server/tools/extract_pvp_score_streak_policy.py`.

MainScene serializes `killStreakScoreRatio: 0.075`, but `ScoreManager.Restart`
replaces it with `Constants.MultiPlayerScoreStreakRatio: 0.75`. If the selected
controller's `dropCreates` is false, Restart then assigns zero. The source
decay rate is the scene override `killsStreakProgressLoss: 1.1`, not the code
default of one. The policy exposes this ratio selection only; the caller must
establish the source eligibility rather than accept a packet's Boolean.

For normal online matches `GameControllerOnline.dropCreates` requires the local
player not to be `LevelManager.isNoob`, a present opponent, and the opponent's
`playerProperties.level` strictly above `MatchmakingEasyBotTillLevel`.
`LevelManager.isNoob` compares the local rank's display number to that same
constant after its source integer cast. The recovered Constants row is four,
and `GameLevel.displayNumber` is its zero-based index plus one. The pinned
`PvpScoreStreakPolicy.DropsCratesForOnlineView` therefore requires a local
index of at least four and an opponent index of at least five, with a present
opponent. It checks the complete 0-42 source rank domain. The reviewed policy
artifact now pins both Client methods and the Constants sheet. The allocator
carries signed zero-based `PlayerLevel` for both players, and the running
MatchEngine now advances this state with its host frame clock.
`PvpBonusProgressCoordinator.CreateForOnlineManifest`
validates the host manifest and content, selects the local/opponent roster
perspective, requires both rank indexes, and applies this gate to its single
shared source-view ratio. It rejects co-op, prototype, missing rank, and
unknown local-owner inputs.

Each matching definition adds `(float)points * ratio * bonusMultiplier` to the
player's progress. `CardScorestreakBooster` assigns its own player's multiplier;
`CardScoreStreakKiller` assigns the opponent's multiplier. They overwrite this
field and restore one on removal; assuming multiplicative stacking would change
the source behavior. MainScene's STREAKBOOST row sets 1.25 for 60 seconds.
CRATEBLOCKER sets zero for 60 seconds, overriding its class default of 0.8;
therefore using that default would incorrectly permit progress gain. These
these serialized identities and parameters are now bound to the host's two
score multiplier card commands.

`PvpScoreMultiplierState` now holds the two source values and 60-second timers
for a two-player match. STREAKBOOST targets its owner and CRATEBLOCKER targets
the opponent. Card use assigns a value instead of multiplying the previous
one; a card whose timer reached zero resets its target to one on the next
Update, matching each recovered Card script. The state rejects unknown owners,
unknown cards, repeated active uses, and malformed game deltas.
The coordinator advances a copy of those timers with each staged PvP frame.
`MatchEngine.ApplyResolvedPlayerDamage` now prepares its host-confirmed hit
score using the coordinator's current multiplier, with no multiplier argument
at that live call site. A source-fixture overload still takes an explicit
multiplier for isolated tests. `UseScoreMultiplierCommand` accepts only the
two source card IDs. The Worker checks the authenticated owner, signed card
selection and stock, records a retry-stable request receipt, spends the card,
and then applies the host-owned multiplier. The normal Unity `CardManager`
uses this command for both cards during a self-hosted match and does not run
their Photon gameplay methods. `SelfHostedDeathMatchBridge` now paints both
players' original timed HUD icons from the host's card-effect snapshot using
local NGUI calls; it never invokes the recovered icon methods that send Photon
RPCs. This presentation has compiled in a disposable Unity project but still
needs normal two-Client Play Mode observation. Other eligible skill-shot
callbacks remain open before live score-streak gameplay is complete.

During a running source Update, decay occurs first and the value is clamped to
zero. Only `progress > 100` generates a bonus, subtracting 100 once; exactly 100
does not qualify, and a large value is not drained with a loop. GenerateNewBonus
schedules SpawnBonus after 1.5 seconds. Its probability selection excludes the
shared last index and uses owner-specific queues. This policy does not implement
frame precision, bonus selection, crate spawning, or an authoritative game
clock. Those remain required before score progress can affect live gameplay.

## Source progress state

`PvpScoreStreakProgress` now provides the per-player gain and Update transition.
It iterates matching score definitions in source order, retaining the float
assignment boundary after each row. Its arithmetic is compared bit-for-bit to
an isolated Unity 2018.3 Mono compilation of the original `AddSkillshot` and
`Update` methods. The fixture covers 13 cases in both local/opponent branches:
ordinary gain, booster, blocker, no-crate mode, exact/above threshold, decay
before threshold, large progress, paused game, clamp, fractional arithmetic,
and subnormal decay preserving the original negative-zero bits. The last case
required a strict below-zero Clamp comparison instead of Math.Max.
Only the three Update delta-time reads use a controlled clock; dependency stubs
record GenerateNewBonus calls without spawning real objects. This is neither
full Play Mode proof nor original Unity 5.2 Android precision proof.

Confirmed gains have bounded immutable receipts. Repeating an old receipt
returns the original progress result without restoring it over newer state;
changed flags or multiplier fail. Public gain accepts only the MainScene values
zero, one, and 1.25. Effect ownership and expiry must be established by the host
before calling this method, never inferred from a Client packet.

Frame IDs start at one and must be consecutive. The latest frame can replay
only with identical delta-time bits and running state, without another decay
or bonus request. Older/out-of-order frames are rejected. Running frames decay
first, clamp to zero, then request at most one bonus only above 100. Paused
frames do neither. Bonus ordinals count requests, not spawned/collected crates;
no economy or achievement mutation follows from this state.
The future spawn dispatcher must consume each match/player/bonus ordinal only
once, since an exact frame replay deliberately returns its original result.

Run `Server/scripts/AuditPvpProgress.ps1` to regenerate
`unity-pvp-progress-reference.json`; run the Battle executable with
`--pvp-progress-only` for source comparison and state/replay checks.
The state is partially wired into MatchEngine: host-confirmed player hits and
the running PvP frame clock now use it. Full eligible skill-shot callbacks,
original manager lifetime, crate selection/ownership/collection, and Unity
projection remain required.
