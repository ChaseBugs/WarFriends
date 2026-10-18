# Source deployment wave lifecycle

`SpawningManagerDeathMatch.Spawn` invokes `onStartSpawning`, generates each unit, waits
0.3 real seconds after every iteration, and only then invokes `onFinishSpawning`. The final
unit does not finish the wave immediately. `WaitForRealSeconds.finished` uses a strict `>`
comparison, so equality with the wait deadline is not completion.

`ArmyDeploymentState` now records one immutable `ArmyDeploymentWave` per accepted deployment.
Its ID is scoped to that player's deployment state; consumers must also retain owner/fraction
identity when comparing waves across players. It records the source option, unit, start tick,
soldier-family classification, and final wait boundary. `FinishAfterTick` requires a strictly
later native tick before completion is published.

`LastAcceptedWave` changes only on successful acceptance. `ActiveWaves` includes the final wait,
and `CompletedWaves` contains only completions from the latest advance. Completion is ordered by
finish boundary and then deployment ID, independently of acceptance order. `WaveOf` retains the
source deployment while an entity remains alive and releases it when that entity is removed.
These are native host fields; no Client command can choose a deployment ID.

## Overlapping source coroutines

The prior FIFO pending queue could put a newly accepted wave's due unit behind an earlier wave's
future units. Pending entries now carry deployment IDs and sort by due tick, then acceptance ID.
Each wave retains its own final wait. Existing eligibility, energy, capacity, offer and stat rules
are unchanged. Numeric deadline/ID preflight occurs before acceptance mutates the queue.

The host continues to use its existing nine-tick spawn cadence. This change does not claim a
new original-Unity frame-time or rendered parity proof; realtime float scheduling remains a
separate fidelity boundary.

## Sickness integration requirement

`CardSickness` arms source spawn callbacks without a fixed timer. It watches enemy
`SoldierBehaviour` starts, weakens eligible spawned `EnemyController` weapons by its damage
multiplier, and calls the one-argument `RefillTo(maxHealth * multiplierMaxHealth)`. That overload
changes current health, not maximum health. `canBeFreezed` excludes Vehicle, Helicopter and
MachineGunPoint states; a soldier-family flag alone is insufficient to select victims.

The source callback checks opposing fraction while its spawning window is active; it does not
filter `AfterSpawned` by deployment identity. Overlapping enemy wave starts can replace the
remembered definition and affect which finish disconnects the callbacks. A future host consumer
must reproduce that event behavior rather than tagging only one wave's entities.

`InstanceOnPlayerDataLoaded` constructs `ArmyUnitDefinition` instances once per source SPAWNS
option and assigns their stable indexes. Later offers reuse those instances. The Sickness
`def == mUsedDefinition` comparison therefore refers to persistent option identity, not a unique
deployment occurrence. Two overlapping deployments of the same option can satisfy the same
finish comparison. Use the recovered option mapping for that rule; the new wave ID is provenance
and must not silently replace the Client's definition-reference semantics.

The new lifecycle is a prerequisite. Sickness arming, modifiers, typed protocol, Client callback,
unit presentation and inventory/terminal proof are not implemented by this checkpoint.
The later [Sickness kernel](SICKNESS_SPAWN_WINDOW.md) now provides independent callback-state
and exact health/damage calculations. It does not yet connect those calculations to host entities
or authorize a card activation.

## Verification

The final Release build passes with zero warnings/errors. `--army-waves-only` passes 12 checks:
accepted/rejected identity, overlapping due ordering, independent final waits, strict deadline
equality, finish order, retained live-entity provenance, one-time completion and removal cleanup.
The overlap fixture uses source Assaulter options and an explicit host cooldown modifier.

The existing native regression executable also completed 247,083 assertions against the updated
pending-order runtime before the final strict-completion metadata refinement and new wave test
were rebuilt. The final focused check covers that refinement; no new combined default-suite count
is claimed. The new test is registered in the default suite for subsequent runs.

Acceptance metadata does not prove a soldier was spawned or grant an achievement/reward.
Native checks and existing diagnostic physics comparisons do not establish rendered Unity parity.
