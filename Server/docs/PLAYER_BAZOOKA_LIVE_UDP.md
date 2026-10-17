# Live Worker to Unity bazooka presentation

The previously separate SDK and Unity component checks now have a combined
live UDP checkpoint. `LiveBazookaUnityTests` runs the production `NetworkWorker`
in the .NET test process and starts a separate disposable Unity Editor. It
issues two independently signed grants and removes the temporary grant file
on exit. Logs and the nonsensitive manifest remain under `Server/.local`.

## Encounter and observations

The fixture equips original M202 inventory index 42 in slot zero and RPG-7
index 3 in slot two. Its unscored allocation uses source City collision and
increased test-only health so the observation can finish. It bypasses Backend
allocation; its credentials and health are not production policy or an economy
settlement proof.

`UnityLiveBazookaAudit` opens MainScene and makes two independent copies of the
recovered player rig. As in the existing rifle harness, their original gameplay
writers are disabled. The actual `SelfHostedBattleClient` and
`SelfHostedDeathMatchBridge` bind the rigs and all normal presenters.
The second participant uses a separate portable SDK connection.

The peer becomes ready first; the local adapter observes it and still sends
its own Ready. After Running, the local participant holds M202 until the host
launches all four source missiles. Each reaches the production projectile
presenter and moves through more than one actual received position. Two are
real and two are harmless fake missiles.

While those missiles still fly, the local participant switches to its RPG
slot through the SDK. Both host state and the recovered inventory must select
that slot. An already-flying M202 must retain its Small model scale. The peer
then selects its own RPG and sends a typed hold, producing the fifth flight.

All five reliable impacts must reach the ordinary battle bridge, hide the
correct model and leave its source tail at the confirmed impact position.
The observation binds every flight and impact to its original weapon, real/fake
kind and authenticated sender. The peer independently reads the retained event
history; all five impact protobuf payloads must be byte-identical to Unity's
received records.

## Reproduction

Copy the seven shared/native tools listed in the
[Play Mode reproduction instructions](PLAYER_BAZOOKA_LIVE_PLAY_MODE.md#running)
into the prepared disposable project's `Assets/Editor`. That copy must already contain the current Client
integration, SDK and generated script-free missile resource. Then run:

```powershell
dotnet run --project Server/tests/War.Battle.Tests -- `
  --unity-bazooka-only "<Unity.exe>" "<disposable-project>"
```

The harness starts Unity hidden in batch mode, with no Docker or Photon
service. Its explicit stages report admission, readiness, flight, slot change
and impact-history comparison. Success requires exit code zero plus
`UNITY_LIVE_BAZOOKA_PASSED` in that run's Unity log. The reviewed final run
passed with zero build warnings/errors. The grant file was absent afterward.
The existing 1,144 protocol checks and 218 focused bazooka checks also pass.

Editor mode does not run the adapter's normal Update. The audit explicitly
calls its real `Refresh` and `DispatchEvents` methods in polling order. An
initial run that called Refresh alone correctly timed out waiting for impacts;
no host rule or event data was changed to make that run pass.

## Remaining boundary

This verifies actual UDP delivery and production adapter/bridge mesh binding
in one Editor process with two independently authenticated SDK participants.
It is not two running Unity clients, rendered pixels or normal Play Mode
input/scheduling. Application.isPlaying is false, so this run does not execute
the normal explosion sound/particle dispatch. Source tail clocks have their
separate real-frame [Play Mode comparison](PLAYER_BAZOOKA_LIFETIME.md).

MainScene is used as the recovered rig/presenter source; normal map loading,
camera/UI boot, Android, Linux Unity execution, full multiplayer modes and
Backend result/economy handoff remain unverified here. B32 and the complete
BattleServer objective remain open.

The [subsequent live Play Mode checkpoint](PLAYER_BAZOOKA_LIVE_PLAY_MODE.md)
shares this battle scenario but uses automatic adapter Update instead of manual
polling. It adds actual source sound/particle dispatch and interrupted callback
recovery, while keeping original boot/input and player rigs inactive.
