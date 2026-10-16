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

### Scene delivery preparation

`CoopOutcomeDelivery` binds the shared finish callback to one match ID, manifest
hash and local player. It validates source co-op outcomes before invoking the
callback, ignores unrelated matches and PvP states, and suppresses both repeated
delivery and synchronous reentrancy during scene reset. Running and aborted
states do not call the finish callback. A previously departed local peer does
not reopen its scene when the surviving master later finishes.

Only a successful callback marks delivery complete. An exception propagates and
permits a later retry; the future presenter must therefore make any partial
scene changes safe to retry. This helper assumes the adapter's serialized Unity
main-thread delivery and does not implement concurrent callback dispatch.

Ten additional protocol scenarios check identity isolation, replay, reentrancy,
callback failure, malformed result recovery, running/PvP exclusion and departed
peer exclusion. The Unity connection below now uses this delivery helper.

Protocol tests add ten outcome cases for success, personal departure, abort,
and malformed winner/role/star/completion/death data. The existing real runtime
fixtures now call the public SDK projection for master KIA, both role orders,
spectating-peer success, shared Forfeit and a departed peer's later result.

`UnityCoopOutcomeAudit.Run` checks fifteen scenarios in Unity Mono using freshly
built portable `War.Shared` and `War.Client` DLLs in the disposable project.
It checks recovered numeric codes, running versus final spectator results,
tick-zero death protobuf presence, common Forfeit, departed-peer finality and
invalid payload rejection. Six additional bridge scenarios exercise running
binding, unsubscribe, missed-result replay on re-enable, terminal poll replay,
immediate terminal replay during configuration and retained delivery history.
They use the actual `SelfHostedBattleClient.Apply` event path and a harmless
callback counter. They create no match, rendered scene gameplay or rewards.

The active Client now installs the audited `War.Client` and `War.Shared` DLLs,
with updated `sdk-manifest.json` hashes and unchanged plugin metadata. No
third-party DLL is replaced. `GameControllerCoop.StartGame` binds the new
`SelfHostedCoopOutcomeBridge` after the recovered mission/UI startup. Its
callback invokes the existing `FinishGameMultiplayerRPC` with the validated
source reason. `Reset` disables and destroys the bridge before base cleanup.

This preserves the received source callback's TimeManager stop, game-running
guard, reset, match-state update, reason assignment and main-controller finish
order. It does not call local `MissionSuccess` to recompute or persist host
stars. The main controller still enters its original GameOver/Beanstalk end
request and optimistic statistics path; its durable co-op settlement response
is not implemented here and a fully completed result screen is not claimed.
Private KIA/spectator presentation is also separate.

The native audit proves Editor-mode compilation and event delivery, not Play
Mode, rendered GUI or two normal Clients completing a mission. Worker co-op
admission, source result rendering and durable settlement remain separate work;
no combat/economy gate is opened here.

Windows validation: the focused combat-content executable passes 26,368
counted assertions plus the outcome/runtime fixtures. Protocol tests pass
1,061 checks, and sequential native Mongo smoke builds with zero warnings/errors,
passes 74 live MongoDB/HTTP/protobuf/UDP checks, and preserves evidence across
Worker restarts. After delivery preparation the protocol count is 1,071. The
final disposable Unity 2018.3.0f2 run passed all fifteen projection/bridge checks
and completed shutdown using the installed portable SDK binaries. A second
clean import/run retained that result. No new Linux, Android or normal
result-screen proof is claimed.
