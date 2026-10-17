# Aborted battle recovery and native scene loading

An Aborted battle has no winner and must not be converted into a local Forfeit.
The current DeathMatch bridge presents Ended results but does not yet navigate
away from an Aborted battle. Recovery must cover lobby, loading and playing
without publishing a result or reconnecting retired services.

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
unchanged. This tracks the original single active map-load model; a future abort
coordinator must prevent a new match load until recovery finishes.

## Native gate

`UnitySceneLoadDrainAudit.RunAsync` uses a disposable Unity project. It creates a
small build scene with a marker, enters Play Mode, and calls the actual recovered
`MapManager.Load` against that scene. It stops the original enumerator after the
native operation is issued. Recovery must yield that same operation, preserve
valid progress, wait for the marker scene to activate and then finish without
blocking again. Inactive source managers isolate loading from account and UI
boot; no map is replaced in the active recovered project.

This gate does not prove complete Aborted recovery, map-resource cleanup, actual
menu rendering, a source Unity 5.2 run or Android behavior.

The Unity 2018.3 Play Mode gate passed; see
`Server/.local/unity-scene-load-drain-play.log`. Static audits retained 2,376
asset documents, 23,513 components, 288,165 references, zero missing scripts and
zero broken references. The seventeen pre-existing NGUI sprite mismatches remain
unchanged. The active scene, prefab and script GUIDs were not modified.

## Remaining integration

The controller still needs an owner-bound Aborted callback, cancellation of the
old gameplay/loading continuations, native-load draining, cleanup without a
Forfeit/dog-tag mutation, and original menu navigation without Photon Chat.
Lobby and loading recovery must be verified separately from an already playing
battle, including repeated terminal delivery and a replaced match owner. The
new wait method is a prerequisite and is not yet wired to that complete path.
