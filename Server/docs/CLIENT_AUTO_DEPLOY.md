# Self-hosted automatic deployment

The active 1.4.0 `SpawningManagerDeathMatch.Update` owns full/semi automatic deployment.
It advances local presentation progress, preselects one affordable offered definition at 0.7,
and calls the ordinary SendUnit path at 1.0. It uses pause-excluding TimeManager delta and a
strict `now > nextTime + 1` delay. Semi-auto additionally requires source energy above its
configured threshold. These source formulas and GameVariables lookups remain unchanged.

The host must validate the resulting ordinary DeployArmy command exactly as a manual command.
It must not add a second automatic spawning loop, accept client prices or grant energy merely
because the Client's progress reached one. No new protobuf auto-mode command is inferred.

## Implemented Client boundary

- Binding a self-hosted army manager no longer erases its selected automatic mode. GameStarted
  retains the recovered full/semi choice instead of disabling both for self-hosted sessions.
- Local progress runs only with a connected, Running, unpaused host snapshot, no pending deploy
  command and a nonempty host-provided hand. Outstanding asynchronous commands cannot generate
  repeated automatic requests through this Update path.
- An accepted host deployment resets progress and the preselected candidate. Removing a candidate
  from the next host hand clears that stale candidate before it can be reused.
- Source random-selection callbacks and manual deployment authority remain unchanged. Existing
  SendUnit sends the chosen option through DeployArmyResult; no Photon call is added.

`Server/tools/UnityArmyAutoDeployAudit.cs` compiles the changed source in a disposable Unity
2018.3.0f2 project and checks the gate, selected mode preservation and stale-candidate lifecycle.
It does not run the complete Update flow, source constants, rendered UI, Android or two peers.
The disposable package manifest must be restored after the owned Editor exits; use `-noUpm`
with this installed legacy Editor to avoid its early package-manager launch failure.
The initial audit passed eight checks with Editor exit code zero at
`Server/.local/auto-deploy-unity.log`; the report is
`Server/.local/coop-geometry-project/army-auto-deploy-unity-audit.json`. The restored manifest
matches its backup SHA-256 `7212bb6d4ae5db21b4fe5d10a4a0666d1f2c63618d8277b692254dd1c2c815a3`.
The source-bound Server group passes 130 checks at
`Server/.local/client-auto-deploy-source-tests.log`. The reviewed manager source fingerprint is
`a7dffea87c5a66126ab11dbe5ff6bd2d903ca2695661484a3bb1883a19307e20`; changes are confined to
self-hosted mode preservation, dispatch gates and candidate lifecycle, not the original spawn coroutine.

## Remaining integration and acceptance

`GameControllerPVP.StartGame` now waits for BindArmyManagerRoutine through the existing
BattleResourceLoadScope before activating DeathMatch scene presentation. Initial offers are
fetched under the connected session and bound manager's generation. A replaced session,
released scene or newer binding rejects the late result before publishing offers. Generation
identity also protects reuse of the same manager instance in the same connection.

Cancelling the managed loading iterator releases only the binding it acquired. A failed
duplicate loader cannot detach an already bound owner. Session Close and manager destruction
use the same explicit UnbindArmyManager path; foreign and repeated releases are harmless.
GameStarted still runs after the managed start coroutine, preserving the original source
mode initialization order. Compilation and component ownership checks are not proof of normal
rendered battle startup or of an actual delayed network response race.

The updated component audit passes twelve checks with Editor exit code zero at
`Server/.local/army-binding-unity.log`, including foreign release, rejected duplicate loading,
subscription cleanup and exactly-once ownership generation advancement. The Server source/time
group passes 130 checks at `Server/.local/army-scene-binding-tests.log`. The current manager
fingerprint is `c834664a315867ecb1b1ea3fd53dba7d49cbe8e40706ebae7de55083231204b0`.
The original spawn coroutine remains unchanged. Normal loading failure recovery, two-Client
gameplay, delayed network responses and Android still require acceptance beyond this audit.

Then exercise both source modes through normal Unity controls: preselection at 0.7, dispatch
at one, insufficient energy, stale offer replacement, outstanding command, reconnect, resume,
terminal state and scene replacement. Verify authoritative energy and confirmed spawn counts.
Retain the recovered RandomArmySent subscriber condition unless separate Client evidence
authorizes a behavior change. Full Server regression must also be rerun after the deliberate
Client source fingerprint update; a prior process reading changed source is not a passing run.
