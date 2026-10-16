# Confirmed co-op KIA presentation

## Recovered behavior

`GameControllerCoop.OnPlayerControllerKilled` distinguishes the nonmaster
player from the mission master. The peer shows reason `Kia`, sets its local
network match state to finished, shows GameOver, then waits for that animation
before switching the camera and GUI to spectator mode. It does not finish the
shared mission. `FinishGameCoopClient` notifies the master that its partner died,
releases the partner's defend point and deactivates that partner after three
real-time seconds. A master death ends the shared mission instead.

`MissionsManager.CurrentPlayerOnKilled` previously used a local physics event
and `PhotonNetwork.isMasterClient` to end a mission. That callback cannot be
authority for the self-hosted co-op path.

## Self-hosted connection

The existing outcome bridge now accepts separate local-KIA and partner-KIA
callbacks. Before choosing either callback it uses the SDK's source co-op
validation: exact roster and master role, running mission, living master,
coherent health/dead flags and an optional death tick with actual presence,
including valid tick zero. It remains bound to the scene's match and manifest.

- A dead, nondeparted peer receives the local spectator callback.
- The living master receives the partner-died callback for that same peer.
- Master death is never a private spectator transition; its shared terminal
  failure follows the existing outcome delivery path.
- Replay and synchronous callback reentrancy cannot repeat KIA presentation.
- Disable unsubscribes; re-enable replays an already received KIA snapshot.
- A later shared finish remains deliverable and suppresses later KIA callbacks.

The controller reuses the recovered local KIA UI/coroutine order and the
existing partner deactivation callback. It does not fabricate a DamageInfo
owner or a hit-by attribution from missing host data. That attribution and full
source death/ragdoll rendering still need their own authority/presentation work.

In self-hosted co-op only, the recovered local death callbacks no longer select
these outcomes or end the mission. Other transports and solo mission behavior
keep their existing path. No reward, star persistence or settlement gate opens.

## Verification boundary

`UnityCoopOutcomeAudit.Run` now has 23 Editor-mode scenarios. Eight additional
scenarios cover living versus dead peer, disable/re-enable catch-up, reentrant
and repeated KIA, subsequent shared finish, foreign-match isolation, invalid
death-tick rejection and master-side partner notification. They exercise the
actual adapter event path and bridge with harmless callback counters.

These checks compile the modified controllers and mission manager, but do not
render GameOver/Spectate, start normal co-op admission, or run two gameplay
Clients. The earlier native UDP/runtime tests establish host master-death and
peer-survival behavior separately. Protocol checks remain 1,071. Static asset
audits retain zero missing scripts and broken references; the seventeen known
NGUI selections remain unchanged. Rendered UI and durable end-request response
remain open requirements.
