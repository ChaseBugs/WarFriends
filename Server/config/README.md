# Squad Event configuration

The recovered APK contains the Squad Event wire parser but not the retired production season,
assignment, target, or reward schedule. The backend therefore keeps Squad Events disabled unless
`SQUAD_EVENT_CONFIG_PATH` points to an operator-reviewed JSON file. Copy
`squad-events.example.json` to a deployment-owned file; do not put guessed production rewards in
the repository.

Each season uses this strict shape:

```json
{
  "seasons": [
    {
      "id": "reviewed-season-id",
      "startTime": 1784505600,
      "endTime": 1785110400,
      "tiers": [
        {
          "reward": 100,
          "assignments": [
            { "id": 7, "target": 10 }
          ]
        }
      ]
    }
  ]
}
```

Times are UTC Unix seconds. Seasons may not overlap. Every tier must have the same assignment
count because the stock client definition contains one global `assignmentCount`. `reward`,
assignment `id`, target semantics, and optional numeric `param` must come from reviewed live-ops
data; the example above demonstrates syntax only and is not a recovered WarFriends season.

The current authoritative assignment allowlist is deliberately limited to recovered IDs `7`
(`WinMultiplayerMatches`) and `8` (`PlayMultiplayerMatches`). Both are derived from the durable
two-participant PvP result consensus. Other IDs depend on combat events the current relay cannot
yet prove, so configuration loading fails instead of publishing an event that can be advanced by
forged client statistics.

Configuration is loaded on first use and retained for the process lifetime. Restart the backend
after deploying a reviewed schedule. A malformed configured file fails the request instead of
silently selecting or granting guessed content.

Treat a season ID as immutable after the first squad joins. Each progress row stores a SHA-256 of
its normalized definition, and reads fail closed if an operator reuses that ID with changed tiers,
assignments, targets, or rewards. Publish corrections under a new season ID.

Confirmed PvP settlement advances only the current tier. When every assignment reaches one, the
shared `ActiveTier` advances and the same transaction creates one type-11 reward message for every
current squad member. `reward` is the exact Gold amount stored in that message; the stock client
claims it later through action `91` using only `MessageId`. Leaving the squad after completion does
not remove an already-earned message, while joining afterward does not retroactively receive one.
The final terminal value is `ActiveTier == tiers.length`, matching the client's completed-event
branch. A zero reward advances the tier without creating a misleading claimable message.

# Squad Wars scheduling

`SQUAD_WARS_ENABLED` controls the separate weekly Squad Wars competition consumed by action 124.
When enabled, `SQUAD_WARS_SEASON_DURATION_SECONDS` defaults to seven days and windows are aligned
from Monday 00:00 UTC. This calendar is reconstruction-owned policy: the 1.6.0 client proves the
wire contract and the 4.9.5 MainScene proves division/reward balancing, but neither APK contains
the retired production calendar. Change the duration only before a clean deployment; existing
season IDs and settled rows are terminal and are never rewritten or reopened. The duration must be
an exact safe integer of at least 3600 seconds and must keep every generated window inside the
recovered signed-client Unix range; invalid values fail closed instead of being rounded or clamped.

`SQUAD_WARS_SCHEDULER_INTERVAL_SECONDS` controls the maintenance polling interval and must be an
exact safe integer from 10 through 3,600 seconds. One backend node
holds a MongoDB lease while it settles expired divisions, creates deterministic type-9 result
messages, closes ended seasons (including empty seasons), and allocates the current window. Match
settlement itself adds points only for a confirmed ranked win, inside the terminal match
transaction. Action 124 and Squad detail reads derive their round from authenticated membership;
request fields cannot select another division or provide scores. During the short rollover window,
`GetPlayerData` exposes the recovered presence-only `SquadWarsProcessing` flag.

`PLAYER_LEAGUE_SCHEDULER_INTERVAL_SECONDS` uses the same exact 10-through-3,600-second boundary for
expired Player League settlement. Both competition values size their scheduler and renewable lease
from the same validated interval. Fractional, non-finite, negative, or out-of-range values fail
closed rather than being floored or clamped into a different operator policy.

# Google Play provider scheduling

All Google Play numeric scheduling settings are exact safe integers. Subscription revalidation
cadence must be 300-86,400 seconds, the subscription scheduler interval must be 30-3,600 seconds,
and its batch size must be 1-1,000 complete receipts. Initial subscription receipt creation and
later successful/retry scheduling deliberately use the same cadence, so durable polling authority
cannot disagree with the worker that consumes it. The voided-purchase scheduler interval must be
60-3,600 seconds.

Malformed, fractional, non-finite, negative, and out-of-range values fail closed. The backend never
rounds or clamps these provider controls because that would hide deployment damage and can write an
invalid or unexpectedly delayed receipt cursor. Provider features remain disabled until their
enablement flags and external Google Play credentials are explicitly configured.

# Multiplayer timeout policy

`MATCHMAKING_TIMEOUT`, `MATCH_JOIN_TIMEOUT_SECONDS`, and
`MATCH_DISCONNECT_GRACE_SECONDS` must be exact positive integer seconds. Their millisecond delay
must fit Node's 2,147,483,647-millisecond timer range; oversized Node timers fire after roughly one
millisecond and therefore cannot be accepted as long waits. The matchmaking value owns both the
local queue timer and Redis stale-queue cleanup so those lifecycle boundaries cannot drift.

`MATCH_RESULT_CONSENSUS_WAIT_MS` must be an exact integer from 0 through 15,000 milliseconds. Zero
disables the bounded first-reporter wait. Fractional, non-finite, negative, and oversized values
fail closed rather than being floored, clamped, or replaced with an undocumented fallback.

# Challenge lifetime policy

`CHALLENGE_TTL_SECONDS` must be an exact safe integer from 60 through 604,800 seconds. It becomes
the durable `expiresAt` interval for each newly created challenge inbox row. Fractional, non-finite,
negative, and out-of-range values fail closed instead of being floored, clamped, or replaced with a
hidden 24-hour lifetime. Existing challenge rows remain valid against their own bounded one-minute-
to-seven-day interval because those rows do not retain the deployment policy version that created
them.

# Player-authored abuse limits

`OUTGOING_MESSAGES_PER_MINUTE` must be an exact safe integer from 1 through 1,000, and
`REPORT_MAX_PER_HOUR` must be an exact safe integer from 1 through 100. These values authorize an
attempt only after its shared MongoDB fixed-window counter is atomically reserved. Fractional,
non-finite, zero, negative, and oversized settings fail closed instead of being floored, clamped,
or replaced with a hidden default. Durable counters saturate one step above their global maximum,
so changing from one valid deployment limit to another does not invalidate an in-flight window.

# Squad Chat policy

The replacement `/hub` Squad Chat has four exact safe-integer controls. `SQUAD_CHAT_HISTORY_LIMIT`
must be 1-100 messages (the recovered default is three), `SQUAD_CHAT_RETENTION_DAYS` must be 1-365
whole days, `SQUAD_CHAT_MESSAGES_PER_MINUTE` must be 1-1,000 attempts, and
`SQUAD_CHAT_MAX_LENGTH` must be 1-2,048 characters. Fractional, non-finite, zero, negative, and
oversized settings fail closed instead of being defaulted or clamped.

Chat rate reservations use the shared durable fixed-window authority under a separate HMAC key
domain from direct/challenge inbox traffic. This keeps the quotas independent while making
concurrent sends across backend nodes compete for one atomic counter. Retention remains encoded in
each row, so historical messages validate their own one-to-365-day lifetime after policy changes.

# Limited-time Event Assignment configuration

`EVENT_ASSIGNMENT_CONFIG_PATH` controls the separate `EventAssignmentManager` daily calendar used
by actions 222/223. It is not a Squad Event. Empty means no config is sent at boot and both claims
fail closed. Copy `event-assignments.example.json` to deployment-owned storage and replace every
example value with reviewed live-ops data; the repository example demonstrates syntax only.

Events use half-open UTC Unix windows. Both endpoints must be exact UTC-midnight boundaries, and
`assignments` must contain exactly one entry for every day in the window because the recovered
client chooses the row with `(Midnight - startTime) / 86400`. Events cannot overlap. The only
recovered assignment implementation is `type: "xmas"` (destroy winter bonus boxes).

Supported daily reward types match the recovered GameReward factory: `0` WarBucks, `1` Gold, `5`
Scraps, `8` Player Visual, `15` Arena Tickets, and `17` unit Elite Parts. Visual rewards require
`amount: 1` and a source-catalog `event`/`assignment` visual in `param`; Elite Parts require a
source player-unit name. Milestones must be strictly increasing and must use visual type `8`,
because the recovered milestone UI unconditionally casts each reward to `GameRewardPlayerVisual`.

The client echoes reward fields during claims, but they never select what is granted. The server
derives the current day, target, event points, reward, and next milestone from the configured event,
then commits reward inventory and claim state together. Each player state stores a SHA-256 of the
normalized event definition and fails closed if the same event ID changes after initialization.

The claim foundation does not trust the stock `EventAssignmentUpdate` value: that number comes
from the phone's local destroyed-box counter. A pure confirmed-progress transition exists for a
future authoritative battle relay, but no current production request calls it. Therefore deploying
a schedule makes claims correct but not naturally completable until trusted box telemetry is added.

# Signed remote Google2u sheets

`remote-configuration.example.json` documents the operator manifest accepted by
`GetConfigurations`. Copy it to an untracked deployment path, define a stable independent
`REMOTE_CONFIGURATION_SIGNING_SECRET` of at least 32 characters, then run:

```powershell
npm run sign:remote-config -- config/remote-configuration.json
```

Set `REMOTE_CONFIGURATION_MANIFEST_PATH` to that signed file and restart. Startup verifies the
HMAC, exact root/publication/sheet fields, unique sheet/row IDs and case-insensitive language
selectors, column counts, signed-client-safe integer version bounds, actual finite numeric 0-100
rollout percentage, and delimiter safety before listening. Unknown typo fields and coercible values
such as `"50"`, `false`, or `null` are rejected even when the manifest was signed. Publications are
evaluated in manifest order, so a specific selector may intentionally precede a wider fallback.
The language wildcard must stand alone, and two publications may not declare the same canonical
variant/language/build/rollout targeting envelope: an exact duplicate would make a manifest reorder
change live balancing. A rollout below 100 percent requires a player ID; pre-login requests
retain their bundled sheets. A ranged publication also requires one canonical numeric replacement-
client `ClientVersion`/`clientVersion`; the stock dotted `Version` is not an integer build. The same
`sheetConfiguration` returns a three-segment no-change response.

Each `rows` entry contains cell values in exactly the same order as `columns`. The stock client
uses `/` inside each row and `;` between outer response segments, so `/` is rejected in cells and
`;` is JSON-unicode-escaped on the wire. Do not place secrets in sheets: every selected value is
sent to the game client. `SaveFuseConfigs` is intentionally not an administration route; its
client-authored debug blob is ignored and can never replace the signed operator manifest.
