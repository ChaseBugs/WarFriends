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
host progress must preserve per-row binary32 arithmetic and callback order;
the aggregate integer score must not replace that ordered float calculation.
Match outcomes and currency rewards remain under their existing authority.

Regenerate with `python Server/tools/extract_pvp_skillshot_scores.py`.
Run focused validation with
`dotnet run --project Server/tests/War.Battle.Tests -c Release -- --pvp-scores-only`.
Tests cover all source scores, base-card composition, unsupported flags,
source mismatch, immutable rows, artifact damage, and live-content binding.
