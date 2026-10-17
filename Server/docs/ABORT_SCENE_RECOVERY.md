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
then resets the online controller, requests the original main screen, waits for
its completed transition and shows the generic localized battle-cancelled notice.
The adapter is released only after that notice is visible or acknowledged; see
[the original modal gate](ABORT_NOTICE_UI.md). Previously
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

The original cancellation notice now has a separate Play Mode animation/input
gate and an inspected graphics-camera capture. These component gates do not
prove the whole recovery coroutine through the recovered player pools, atlas
restoration and main-screen widgets. That full
graph, cleanup callback failures/retry, mode-specific mission/Arena state and
actual two-client abort cases remain work. If cleanup fails before completion,
new admission stays blocked; automatic recovery from every UI/resource exception
has not been implemented or verified. Source Unity 5.2 and Android remain
unverified. The implementation and component gates do not close B05/B31/B36 or
the overall BattleServer objective.

## Inactive map discard

The original tag search only returns active objects. The expanded native audit
reproduced an unregistered map surviving cleanup after deactivation; see
`Server/.local/unity-abort-inactive-map-baseline.log`. Stopping/draining a loader
is not sufficient evidence that every remaining map is active or registered.

For Unity 5.3 and later, DiscardAbortedScene now enumerates loaded MapDefinition
components including inactive objects and requires a valid, loaded scene before
scheduling destruction. It never calls Init. This excludes persistent prefab
assets returned by Resources.FindObjectsOfTypeAll. The registered map is captured
before its original destruction so that scan does not schedule it a second time.
Normal scene teardown remains unchanged.

The native gate covers a registered active map, an unregistered active map, a
previously activated but now inactive map, and an inactive map whose Awake never
ran. Every case must destroy only the scene instance, retain an unrelated scene
marker and retain a real persistent MapDefinition prefab loaded from disk.

The Unity 5.2 compile branch retains its existing active tagged-map behavior:
that runtime has no equivalent public scene-membership API used here. Inactive
unregistered map cleanup is therefore still incomplete on the original 5.2
runtime. The 2018 native fixture does not close that compatibility gate or the
complete resource/menu recovery gate.

All four discard cases and the real interrupted native-load drain passed in
Unity 2018.3: `Server/.local/unity-abort-inactive-map-fixed.log`. At this checkpoint
the protocol executable passed 1,334 checks and the static asset audit retained
2,376 documents, 23,513 components, 288,165 references, zero missing scripts and
zero broken references. No active Client scene, prefab or meta file was changed.

## Independently hosted game-atlas loaders

Confirmed abort now invalidates the game-atlas scope before releasing resources.
Stopping only root GameController coroutines left AtlasPreparer's child loaders
running. See [scoped atlas cancellation](ABORT_ATLAS_LOADING.md) for the native
counterexample, source call chain and remaining completed-bundle verification.
Menu/common atlas work is not globally stopped by this change.
