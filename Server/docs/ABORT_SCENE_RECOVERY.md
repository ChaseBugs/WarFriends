# Aborted battle recovery and native scene loading

An Aborted battle has no winner and must not be converted into a local Forfeit.
`GameControllerOnline` now binds Aborted snapshots to a dedicated recovery path
in the original `GameController`. The implementation covers lobby, response
waiting, loading and playing without calling the generic outcome-producing stop
methods. Full rendered menu recovery remains unverified.

## Recovered flow constraints

- `GameControllerOnline.PlayerDistonnectedBeforeAfterMatch` uses the original
  cancellation notice and main-screen navigation for a peer cancelling a lobby.
- `GameController.StopGame` publishes `GameEnded(Forfeit)` and calls
  `BeanstalkServerManager.GameEnded`; it is unsuitable for server-aborted play.
- `GameControllerCoop.shouldLooseDogtagWhenQuit` becomes true when both players
  connect. A generic `Quit` cannot be treated as a harmless cancellation across
  every online controller.
- `GameController.Free(false, false)` eventually reconnects `Chat`, whose
  `Connect` still calls the Photon Chat client. Abort recovery cannot invoke
  that path unchanged in the self-hosted offline deployment.
- `GameController.LoadAndStartNewMap` runs the source map loader as a nested
  coroutine. `MapManager.Load` issues `Application.LoadLevelAsync`; stopping
  the enumerator does not cancel an already issued native operation. Resource
  cleanup must not finish first and allow that scene to activate afterwards.

## Implemented prerequisite

`MapManager.Load` now retains the actual operation in `_sceneLoadOperation`.
Previously it assigned a local variable while `loadProgress` read a different,
never assigned field. The public progress contract is unchanged; it now returns
zero before the first operation and reads the real operation afterwards.

`WaitForSceneLoadRoutine` captures and yields an outstanding operation. It also
works after the original loading enumerator has stopped, and returns immediately
when no load is pending or it has already completed. It does not initialize or
destroy a map, publish `NewLevelLoaded`, alter results or navigate the UI.
The successful source loading order and scene/prefab/script identities remain
unchanged. The recovery coordinator blocks replacement map loads and controller
changes while draining the original single active load.

## Connected recovery path

Abort subscriptions bind the original adapter, match ID, manifest hash and a
private subscription identity. Reset and OnDisable unsubscribe; OnEnable can
rebind the current owner. A delegate already captured by a multicast invocation
cannot act after its subscription has been disabled or replaced.

The controller stops gameplay/loading coroutines, resets local network status,
sets `GameCancelled` and clears the presentation outcome to None. It does not
call Quit, StopGame, FinishGame or a combat result/report endpoint. The SDK
adapter cancels pending delivery and holds its self-hosted ownership until
cleanup completes. Ordinary Leave cannot clear that guard; direct connection,
queue and reconnect calls cannot replace the cleaning-up owner. The explicit
finish operation releases it afterwards.

The recovery coroutine first lets the terminal callback unwind, then drains the
native map operation. A lobby resets the local dog-tag reservation and returns
to Menu. Other states reuse the original ordered asset release with an explicit
SelfHostedAbort reason. That branch discards even an unregistered late map
without Init, tolerates unset selected-card strings, and skips ordinary unit-use
analytics, results, account/relogin dispatch and Photon Chat reconnection. It
then resets the online controller, releases the adapter, requests the original
main screen and shows the generic localized battle-cancelled notice. Previously
charged entry costs are not refunded or reconstructed by this client path.

Late stop/finish/quit/forfeit callbacks and new match starts are guarded during
recovery, including the derived co-op and War Arena overrides. Normal teardown
retains its original timing and call order; resource release was extracted into
a named helper to keep the coroutine readable.

## Native gate

`UnitySceneLoadDrainAudit.RunAsync` uses a disposable Unity project. It creates a
small build scene with a marker, enters Play Mode, and calls the actual recovered
`MapManager.Load` against that scene. It stops the original enumerator after the
native operation is issued. Recovery must yield that same operation, preserve
valid progress, wait for the marker scene to activate and then finish without
blocking again. It now also discards both registered and unregistered tagged map
roots without calling Init, preserving an unrelated scene marker. Inactive
source managers isolate loading from account and UI
boot; no map is replaced in the active recovered project.

This gate does not prove complete Aborted recovery, map-resource cleanup, actual
menu rendering, a source Unity 5.2 run or Android behavior.

The updated Unity 2018.3 Play Mode gate passed; see
`Server/.local/UnitySceneLoadDrainAudit-abort-final.log`. Static audits retained 2,376
asset documents, 23,513 components, 288,165 references, zero missing scripts and
zero broken references. The seventeen pre-existing NGUI sprite mismatches remain
unchanged. The active scene, prefab and script GUIDs were not modified.

## Controller gate and remaining verification

`UnityAbortRecoveryRoutingAudit` passed in Play Mode for all four original
GameState values. It uses the real controller methods with account boot omitted
by a disposable Awake-only probe. Controlled adapter snapshots verify owner,
manifest and subscription rejection; blocked late outcome callbacks; suspended
delivery with ownership retained; explicit release; and reuse of the same adapter
for a fresh deliberately unanswered connection. The test stops the actual recovery
coroutine at its first yield, before resource/UI work. Its log is
`Server/.local/unity-abort-recovery-routing-reuse.log`.

The existing normal queue cancellation/disable/retry gate also passed with the
new OnDisable pairing; see
`Server/.local/UnityMatchmakingCancellationAudit-abort-final.log`.

These gates do not prove the whole recovery coroutine through the recovered
player pools, atlas restoration, menu widgets and cancellation notice. That full
graph, cleanup callback failures/retry, mode-specific mission/Arena state and
actual two-client abort cases remain work. If cleanup fails before completion,
new admission stays blocked; automatic recovery from every UI/resource exception
has not been implemented or verified. Source Unity 5.2 and Android remain
unverified. The implementation and component gates do not close B05/B31/B36 or
the overall BattleServer objective.
