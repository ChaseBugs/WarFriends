# Co-op scene roles and success data

Recovered Client evidence distinguishes the source master from its assisting
peer. The signed roster is storage order; it must not silently override an
explicit `SceneMasterPlayerId`.

| Source owner | Main allied position | Normal co-op success path |
| --- | --- | --- |
| Master | First main position | `MissionSuccess` computes stars/highscore and marks `completedInCoop`. |
| Peer | Second main position | `MissionSucceededRPC` calls `MissionSuccessCoopClient`, which marks only `completedInCoopClient`. |

`MissionsManager.PlayCurrentMission` passes the master role to
`Mission.PlayMission`, which returns before master-owned setup for a peer.
`MissionsManager.OnGameStarted` and `OnAfterGameStarted` also invoke the mission
only on the master. `Mission.MissionSuccess` performs its score/star/highscore
updates before `MissionsManager.MissionSucceeded` sends the peer RPC. The peer
callback does not run the master's score calculation. See recovered
`Mission.cs`, `MissionsManager.cs` and `GameControllerCoop.GetMainPlayerPoint`
under `Clients/ExportedProject/Assets/Scripts/Assembly-CSharp`.

## Server projection

`CoopSceneRoles` resolves the signed master once per lookup and assigns source
main-point slots independently of roster order. Older isolated allocations
without the optional role retain their explicit first-roster fallback. The
runtime's start anchors, master-relative AI behavior, departure decisions and
terminal validator now use that same role definition.

The source-backed co-op protobuf state adds:

- `scene_master_player_id` (field 21): the resolved signed master identity.
- `peer_completion_player_ids` (field 22): the source peer completion marker on
  success, without stars, currency or a durable progression entitlement.

`success_scores` now contains exactly the living, non-departed master's source
score and stars. The earlier prototype calculated a row for every living ally;
that was not the recovered peer success contract. A connected KIA spectator can
still receive the source peer completion marker because its RPC callback sets
that flag without a vitality test. A departed peer is no longer in the active
mission and receives no new completion marker.

`participant_scores` remains the shared Score mission's per-ally combat
contribution ledger. Restricting final star ownership does not remove a peer's
confirmed skill-shot points or its contribution to the shared objective.

The terminal validator binds role metadata to the signed allocation, validates
both player histories, recomputes only the master's score, checks exact peer
completion ownership and requires role-correct source start anchors. Failure
and cancellation cannot carry a peer completion or success-score claim. Its
envelope, lifecycle, vitality and score checks are separated into short methods.
Historical prototype evidence missing the new role field or containing two
star rows is not silently rewritten into newly accepted source evidence.

## Tests and remaining boundary

`CoopSceneRoleTests` runs real source-scheduled kill missions with legacy
fallback, explicit first-player master and explicit second-player master. It
checks anchors, a protobuf round trip, master-only stars and peer completion,
then rejects forged master identity, peer star ownership, missing/wrong peer
completion and wrong source anchors. A separate fixture preserves completion
for a KIA peer. Existing boss fixtures now keep their declared master in their
first test actor slot; reversed storage is tested explicitly rather than
depending on the earlier incorrect slot assumption.

This is source-backed result data, not Backend progression settlement or a
normal Unity result-screen proof. The source SDK regenerates the added fields;
the owner's installed Unity plugin binaries are not replaced here. Normal
Worker co-op admission, role-aware result UI, heroic progression and master-KIA
lifecycle integration remain separate unfinished work. No combat or economy
gate is opened by these metadata changes.

Windows verification: the focused combat-content executable exits zero with
26,368 counted assertions plus the role and replay fixtures. Sequential native
Mongo smoke builds with zero warnings/errors, passes 1,051 protocol checks and
74 live MongoDB/HTTP/protobuf/UDP checks, and preserves terminal evidence across
Worker restarts. No new Linux, normal Unity result UI or heroic proof is claimed.
