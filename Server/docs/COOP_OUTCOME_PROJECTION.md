# Portable co-op outcome projection

Recovered `GameControllerCoop.FinishGameMultiplayerRPC` delegates the master's
shared result to `GameControllerOnline.FinishGameMultiplayerRPC`. That callback
sets `GameController.gameEndReason` directly; it does not derive a PvP winner.
Its recovered codes are KIA 8, MissionFailed 9 and MissionSuccess 10. A connected
peer may first show KIA/spectating and later receive the shared mission finish.
An already departed peer has ended its local game and must not be reopened by
the surviving master's later result.

`MatchOutcomeProjection.ForPlayer` now delegates source-backed co-op snapshots
to `CoopOutcomeProjection`. Its existing PvP path retains winner-based behavior.
The SDK exposes the recovered mission enum values without changing earlier
numeric values.

| Confirmed state | Local projection |
| --- | --- |
| Waiting, countdown or running | None; private KIA/spectator presentation is separate. |
| Aborted | None; cancellation is separate from a win/loss. |
| Shared mission success | MissionSuccess for connected master and peer, including a KIA spectator. |
| Master KIA or objective timeout | MissionFailed for connected players. |
| Shared master Forfeit | Forfeit for both; no PvP WinByForfeit. |
| Previously departed peer observing a later shared result | Its own Forfeit remains final. |

The projection requires canonical roster identities, the source master role,
no PvP winner, the current unscored reward boundary, coherent active/departed
membership, supported vitality/death timestamps, a valid mission clock and
matching completion flags. Successful presentation requires the master's single
star row and the distinct peer completion list. Early failure requires the
exact master-KIA boundary. These are presentation consistency checks, not a
replacement for Server catalog, combat, result-signature or settlement checks.
No wallet, mission record or star progression is mutated by the SDK.

## Validation and remaining connection

Protocol tests add ten outcome cases for success, personal departure, abort,
and malformed winner/role/star/completion/death data. The existing real runtime
fixtures now call the public SDK projection for master KIA, both role orders,
spectating-peer success, shared Forfeit and a departed peer's later result.

`UnityCoopOutcomeAudit.Run` checks nine scenarios in Unity Mono using freshly
built portable `War.Shared` and `War.Client` DLLs in the disposable project.
It checks recovered numeric codes, running versus final spectator results,
tick-zero death protobuf presence, common Forfeit, departed-peer finality and
invalid payload rejection. It creates no match, scene gameplay or rewards.

This checkpoint changes source SDK behavior. The active Client's installed
network DLLs are not replaced, and its normal co-op result-screen bridge is
still unfinished. The native audit is Editor-mode package compatibility,
not Play Mode, rendered GUI or two normal Clients completing a mission.
Worker co-op admission, source UI callbacks and durable settlement remain
separate work; no combat/economy gate is opened here.

Windows validation: the focused combat-content executable passes 26,368
counted assertions plus the outcome/runtime fixtures. Protocol tests pass
1,061 checks, and sequential native Mongo smoke builds with zero warnings/errors,
passes 74 live MongoDB/HTTP/protobuf/UDP checks, and preserves evidence across
Worker restarts. The disposable Unity 2018.3.0f2 run passed all nine projection
checks and completed shutdown using the current portable SDK binaries. No new
Linux, Android or normal result-screen proof is claimed.
