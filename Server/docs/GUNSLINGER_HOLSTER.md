# Gunslinger holster state and protobuf projection

## Recovered behavior

SoldierBehaviourGunslinger.StartEnemyBehaviour calls SnapColt(true) after starting the ordinary
behavior. EnemyController.SwitchStateToGunslinger calls SnapColt(false) at each authored point.
After the last attempt, ReturnToPreviousStateFromShotGunSlinger schedules SnapColt(true) through
Core_BaseScript.InvokeAfter with a one-second delay. Moving to the next point takes place later;
the weapon remains holstered while walking and returns to the hand at the next point.

SoldierParts.SnapColt iterates the weapon swappers. FakeRigidBodySwapper.SnapTo reparents the
source snapPoint to coltSnap and resets its local pose/scale. Swap(false) returns that snapPoint
to NoRigidBodyObject. This source geometry contract does not justify reparenting an arbitrary
whole weapon root or drawing an invented default gun model.

## Native timing evidence

The disposable Unity 2018.3.0f2 probe calls the recovered Core_BaseScript.InvokeAfter(1f) at ticks
1, 324 and 340 with capture rate 30. Native callbacks occurred at 31, 354 and 370 respectively.
GunslingerFiringClock.HolsterTick therefore adds thirty ticks. This coroutine clock is distinct
from the animation controller's strict hide deadline, which can select elapsed tick 30 or 31.
The canonical fixture hashes its executed coroutine/probe/exporter sources and separately binds
the inspected controller/parts/swapper sources. The probe does not execute SnapColt or render a gun.
Original Unity 5.2.5 parity is not established by this observation.

## DTO and authority

| Contract | Value |
| --- | --- |
| Message | BattleArmyEntityState |
| Field | is_colt_holstered, field number 45, protobuf bool |
| C# property | IsColtHolstered |
| True identity | Ordinary ID_UNIT-GUNSLINGER with an empty source_card_id |
| Omitted/default | False; all other unit/card identities must keep it false |
| Authority | Host lifecycle only; no Client command writes this field |

The host publishes current attachment state with the paged roster, like other time-varying pose
metadata. A holster transition does not alter damage, bullet speed, inventory, or roster membership.
Death removes both current attachment state and pending callbacks. The SDK rejects a true flag on
other unit identities and preserves the field through protobuf. Updated portable War.Shared and
War.Client binaries are installed in the active Client networking plugin directory.

## Validation and remaining boundary

The focused group passes 16 checks: three native callback times and fixture identity, protobuf
round trip and SDK identity guards, actual spawn/arrival/final-shot/timer/movement/rearrival state,
and cancellation of a pending callback on authoritative death.

```powershell
python -B Server/tools/verify_gunslinger_holster_observation.py --check
dotnet run --project Server/tests/War.Battle.Tests -c Release --no-build -- --gunslinger-holster-only
```

Protocol tests pass 1,360 checks. Native Windows MongoDB/HTTP/protobuf/UDP smoke passes 74 checks
with independent clients and restart/replay coverage. Live UDP roster regression passes 21 checks,
and shared combat regression passes 26,395 assertions. The solution builds with zero warnings/errors.

Visible holstering remains incomplete. SelfHostedInfantryPresenter's current default creation
path copies a body without selecting a weapon. Its existing appearance resolver is Assaulter-specific.
A reviewed Gunslinger inventory/model selection and script-free snapPoint/coltSnap binding must
be connected before this flag can display the actual source weapon. This checkpoint updates the
Server, protocol and SDK, not that renderer or normal battle-controller wiring. Unity scene/prefab
identities and the owner's concurrent library changes are preserved. Linux runtime, original-Unity
validation and the full default Battle suite were not rerun. See the
[feature checklist](BATTLE_SERVER_FEATURES.md).
