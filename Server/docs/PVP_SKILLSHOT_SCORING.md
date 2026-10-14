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

## Runtime boundary

This catalog supplies trusted score data and composition; it does not yet
publish live score or grant bonuses. The recovered `SkillShotManager` first
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

The primitive remains unbound to live combat until every eligible callback,
manager lifetime, and authoritative scaled game clock are established. A
receipt must identify one host-confirmed death, not merely a Client command
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

This is not yet the live ScoreManager replacement. Progress gain, per-frame
decay, bonus multipliers, bonus generation, controller lifetime, and all eligible
host callbacks still need integration. No Client-supplied flags or scores are
authorized by this class. Run `--pvp-score-state-only` for the score/count ledger
checks; the complete Battle suite also includes them.
