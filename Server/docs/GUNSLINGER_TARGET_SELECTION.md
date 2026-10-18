# Normal Gunslinger target selection

## Recovered behavior

SoldierBehaviourGunslinger.PickTarget first calls TryPickDecoy. A selected Decoy uses its All
shot-target list. Otherwise PickRandomOpponent prefers AttackerRusher (3), then concatenates
anyUnit groups in source order (1, 3, 2, 0), and finally delegates to PickPlayerOpponent when no
unit remains. Entity selection is random within that source ordering, not nearest by distance.

Unlike Assaulter, Gunslinger requests Head transforms for an opposing unit. The base
SoldierBehaviour.PickRandomOpponent computes its random index before checking for an empty Head
list. If that list is empty it replaces the list with AllIn but retains index zero from the
empty range. A second draw from AllIn would change recovered behavior. GunslingerTargetPolicy
preserves this order, validates the empty-range result, and excludes Out transforms from AllIn.

Player fallback retains the shared Shield/body/moving-target selection policy; it is not a
universal player headshot. Selection-time Shield position is the current cover shot position.
GameShootableEntityPlayer.GetShotTargets creates a new Shield target referencing that cover's
shotPosition transform. The later Gunslinger callback retains the captured cover identity,
even if the player subsequently moves. It must not substitute a serialized player-child target.
Other selected transforms and the player's current velocity are sampled again at callback.

## Server implementation

SelectGunslingerShotTarget uses actual host registration, current infantry target poses and
normal-unit identity validation. The source entity-priority and geometry helpers are shared
with Assaulter, while its public/internal Assaulter entry points retain their identity guards.
A selected entity with unresolved geometry remains unresolved; it must not turn into permission
to attack the player. Unregistered opposing unit authority also blocks fallback unless a source
Decoy takes priority. Existing Assaulter result types are reused internally during this integration.

## Validation boundary

The focused group covers Head subset ordering, the single retained fallback index, empty and
Out-only lists, malformed identity/pose/draw rejection, and actual host deployments. Live checks
compare the selected Head identity and pose with current InfantryShotTargets, observe movement,
then remove opposing soldiers through host death cleanup and verify player fallback.

```powershell
dotnet run --project Server/tests/War.Battle.Tests -c Release --no-build -- --gunslinger-targets-only
```

The Release build passes with zero warnings/errors. The focused group passes 16 checks;
shared Assaulter target and real-volley regressions pass 29 and 110 checks respectively.
The native stand source-bound verifier also remains unchanged and passes.

These focused selector tests call the match-owned selector directly. The later
[automatic shooting path](GUNSLINGER_SHOOTING.md) now also uses it during ordinary gameplay ticks.
[Point changes](GUNSLINGER_POINT_CHANGES.md) now run through ordinary ticks. [Holster metadata](GUNSLINGER_HOLSTER.md)
is delivered through the SDK; visible weapon attachment and normal Client presentation remain open.
