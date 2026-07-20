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
HMAC, schema, unique sheet/row IDs, column counts, client-version bounds, variant/language targets,
rollout percentage, and delimiter safety before listening. Publications are evaluated in manifest
order. A rollout below 100 percent requires a player ID; pre-login requests retain their bundled
sheets. The same `sheetConfiguration` returns a three-segment no-change response.

Each `rows` entry contains cell values in exactly the same order as `columns`. The stock client
uses `/` inside each row and `;` between outer response segments, so `/` is rejected in cells and
`;` is JSON-unicode-escaped on the wire. Do not place secrets in sheets: every selected value is
sent to the game client. `SaveFuseConfigs` is intentionally not an administration route; its
client-authored debug blob is ignored and can never replace the signed operator manifest.
