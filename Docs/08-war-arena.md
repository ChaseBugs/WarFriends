# War Arena

## Persistent run state

War Arena is a server-owned event run with lives, wins, opponents, arena ID, run count, visual
metadata, flawless count, top run, shields, and completion flags. Public fields mirror the recovered
`WarArenaData`; private battle receipts and replay records stay only in MongoDB.

## Entry

Entering validates event time and the server-configured Ticket or Gold price. The server chooses a
bounded opponent list near the player's current Army Power and persists the entry response so
retries do not charge twice or generate a different run.

## Battle lifecycle

1. A game-start action creates an Arena battle receipt with a unique battle ID.
2. `GameEnded` must refer to the active receipt.
3. A win advances the run; a loss consumes run life.
4. The receipt is replaced by a bounded settlement replay record.
5. Repeating the same battle ID returns the stored result and cannot advance twice.

Abandoned battle handling consumes life only once. Expired events roll to a new generated Arena
configuration without allowing an old receipt to claim a new-season reward.

An accepted win also advances `AchievementWinArenaBattles` in this receipt-consuming transition:
2, 10, and 100 wins award 5, 15, and 50 Tickets. Completing the configured maximum-win run without
an accepted loss advances `AchievementFlawlessHero`: 1, 3, and 10 flawless runs award 50, 150, and
250 Scraps. Because both updates happen before the immutable settlement replay is stored, retrying
`GameEnded` cannot duplicate achievement progress or rewards.

The receipt proves that the server accepted one start/end lifecycle and enum-valid result; the
stock client still reports the combat outcome. These counters therefore share the current Arena
authority boundary and do not replace the remaining authoritative combat-validation work.

## Rewards

The reconstructed server currently provides a one-time Scraps fallback at exhausted/final-win
boundaries because the original lootbox, crown, and inventory delivery tables are not authoritative.
This fallback is server-configured and idempotent.

It must be replaced when the recovered Arena loot inventory IDs and odds are available. Debug Arena
mutations remain disabled outside an explicit authenticated admin design.

## Leaderboard

Arena rankings use persistent player run results and recovered response field names. Event-history
season boards and immutable end-of-season claims are still missing.

## Key implementation files

- `Server/src/services/warArenaContract.ts`
- `Server/src/services/warArenaService.ts`
- `Server/src/handlers/warArena.ts`
