# Source Score-mission presentation

`ScoreMission.hudProgress`, `progress` and objective text read
`ScoreManager.scoreCoop`. The recovered manager computes that value as its local
score plus the remote player's score received through `AddCoopScoreRPC`.
`ScoreMission.UpdateMission` and `EndMission` can also use that total to trigger
local success and star calculation. A host-owned score view must not re-enable
those local authority paths.

## Host projection

`CoopScoreProjection.ForPlayer` accepts only the source `Score` mission type.
It first validates the source mission lifecycle/roles through the existing
outcome policy. It then requires exactly two nonnegative contributions in the
signed snapshot roster order. Their wide integer sum must fit the recovered
signed-int score field and exactly equal `objective_score`. Before mission
start the total must be zero. Duplicate, reordered, missing and foreign rows
cannot become HUD authority. The admitted peer's earned contribution remains
part of the shared total after departure, independently of completion flags.

The isolated host runtime already publishes these rows only for Score
missions. Other mission types do not acquire invented scores from their kill
counts, success stars or success-score rows. Their score presentation remains
separate work.

## Unity connection

`ScoreManager.ApplySelfHostedSnapshot` validates the complete score view before
assigning local and remote values. Its existing `scoreCoop` property then
returns the exact shared objective total used by the recovered Score HUD.
The normal adapter applies this view before room/outcome/snapshot callbacks.

After binding, existing self-hosted guards suppress local score assignment,
skill-shot score mutation, streak generation and both send/receive sides of
the retired Photon score delta. This guard survives disconnect until restart.
Restart rebinds the current host snapshot. No new kill-streak progress or
skill-shot count is inferred from a contribution total.

Self-hosted co-op `ScoreMission.UpdateMission` and `EndMission` defer to host
outcome delivery. Reading a completed HUD objective cannot call local
`MissionSuccess`, persist stars or choose a mission failure. Solo/legacy
mission behavior retains its existing path. Shared terminal callbacks and
the personal departure path remain separate from this score view.

## Verification and open work

Eleven portable protocol scenarios cover both local roles, malformed rows,
conservation, overflow, mission type, retained departed contribution and
prestart score rejection. The real host-credited two-ally runtime fixture also
projects its 10-point player kill plus 5-point allied-army kill through the SDK
for both players.

`UnityCoopOutcomeAudit` adds seven component checks to the existing 23 outcome
checks. These exercise the real ScoreManager, score setter/RPC rejection,
failed-publication atomicity, reversed peer view, adapter callback ordering and
disconnect behavior. They do not render the mission HUD or invoke live
gameplay, and do not establish complete Score skill-shot combat authority.

Normal Worker co-op admission, rendered mission/result UI, non-Score mission
score projection, complete combat attribution and durable settlement remain
open. The new score view opens no reward gate.

Windows validation passes 26,368 focused combat assertions plus the runtime
projection fixture, 1,082 protocol checks, 30 Unity Mono component checks and
74 live MongoDB/HTTP/protobuf/UDP smoke checks with durable restart replay.
The solution builds with zero warnings/errors. The first concurrent smoke run
hit the existing 30-second Mongo bootstrap limit; its log subsequently showed
Primary election. After the Unity/asset processes completed, a standalone
smoke retry passed without changing timeouts or bypassing checks. No new Linux,
Android, rendered mission HUD or two-Unity-client gameplay proof is claimed.
