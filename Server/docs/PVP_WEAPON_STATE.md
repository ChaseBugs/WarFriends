# PvP weapon state ownership

This second S07 increment extracts weapon slot membership, selection, magazine/reserve quantities
and reload/fire deadlines. It does not extract aiming, trigger/burst/minigun/sniper state, projectile
preparation/impacts, weapon damage or the remaining global frame orchestration. S07 remains open.

## Owners and boundaries

| Owner | Responsibility |
| --- | --- |
| Match/Weapons/PvpWeaponLoadout | Fixed signed slot membership, selected slot, ordered all-slot reload completion and cancellation |
| Match/Weapons/PvpWeaponSlotState | One slot's definition, clip/reserve and reload/fire deadlines, with private setters and explicit intent methods |
| MatchEngine Player adapters | Getter-only compatibility for remaining simulation and snapshot consumers |
| Engine/card/bonus adapters | Admission, target/effect authority, event capacity, preflight of every affected slot, effect publication and revisions |
| Rifle/grenade/projectile systems | Existing animation, aim, accepted-shot effects, projectile authority and damage |

The loadout builds from the already validated manifest, retaining the original single-slot fallback
when WeaponSlots is absent. It preserves manifest insertion order and exposes a cached
ReadOnlyDictionary wrapper; callers cannot add/remove signed slots. Slot state is not shared
between players or duplicate weapon identities. Selecting an unknown slot fails before changing
selection. Existing public engine/protobuf identities do not change.

## Client rules retained

- Weapon.FinishReload transfers min(clipSize - clip, reserve). A partial final reload cannot create
  ammunition. The Pistol reserve getter is int.MaxValue with an empty setter, so that sentinel is
  not decremented by reload completion.
- Existing server tick conversion remains ceil(double seconds * 30). Cadence and reload use the
  same precision and inclusive completion boundary; they are not converted through binary32 first.
- Reload completion still runs for active and inactive slots at the original frame point, after
  movement and before the following army/card phases. A reconnect pause retains simulation deadlines.
- CardAmmoBox adds ceil((float)startingAmmmoCount * 0.25f), not a percentage of current reserve.
  Every slot is validated before effect/card publication; an overflow keeps the card unspent.
- CardEmptyMag targets the first sorted signed slot, even when another is selected. Its clip setter
  cancels an old reload; a new reload starts only if reserve remains.
- CardAmmoThief targets the second sorted slot. Existing transfer policy proves actual loss/gain
  before publication. Accessing the clip setter cancels reload even when the actual clip debit is zero.
- Source bonus refill calculations remain preflighted for all slots before any reserve is replaced.

Weapon.cs, Pistol.cs, WeaponInventory.cs and the recovered card builders/actions were inspected.
Their historical hashes are recorded with the trace fixture; no Client source or asset was edited.
This preserves the reviewed rules and prior server behavior without claiming a complete V01/C13
audit of every weapon/controller formula or inactive-Unity-object callback.

## Side-effect order

ConsumeRound and ScheduleNextFire are deliberately separate. Engine accepted-shot counters,
animation/physics acceptance, projectile/event insertion and geometry acknowledgement can occur
between them. Combining those operations would change a failure boundary. Reload starts before
the existing StopShooting callback. Combat weapon selection succeeds before the selected-slot
commit, including the Disarmed forced-pistol path.

Ammo Box and bonus refill retain two phases: preflight every affected slot, then publish the
existing card/bonus authority and apply the planned quantities. Ammo Thief retains reserve debit,
conditional clip debit/reload cancellation, then receiver credit. Death keeps its previous scope:
ordinary damage clears all slot reloads; the barrel path still clears the active slot at its original
point. Terminal, event and revision publication stay with their existing engine owners.

## C29: monotonic capped grants

The previous generic internal TryResolveCardAmmo helper computed
`min(startingReserve, checked(currentReserve + grant))`. With starting reserve three, Ammo Box can
legitimately produce four; granting one more then reduced that reserve to three. It also overflowed
for valid positive grants near Int32.MaxValue, including the immutable reserve sentinel.

ApplyCappedAmmoGrant now rejects negative grant arguments, leaves already-at/above-cap reserve
unchanged, and widens addition before saturating an under-cap reserve. This preserves the existing
server-owned cap policy while preventing a grant from consuming ammo or overflowing. Source Ammo
Box/bonus/theft pricing and effect authority are not replaced by this generic helper.

The regression failed against the old arithmetic in
checkpoint-63f5451843d54d7e93b7f7389fd56dc8 and passed after correction in
checkpoint-d1bec5d6c041406da3716a1aa1c8c80d. Tests cover legitimate overfill, int.MaxValue reserve
and a near-maximum finite reserve receiving 100,000 rounds. Current production source has no caller
of TryResolveCardAmmo; this is a latent reusable-helper correction, not evidence that live players
were observed losing ammunition. The original cap's broader gameplay-policy review remains C13.

## Before/after verification

A common test-only MatchEngineTrace recorder was extracted while the original connection fixture
continued matching all nine frozen cases. Before editing weapon simulation, eight weapon scenarios
and 99 complete observations were captured twice with identical hashes. The small frozen JSON
baseline includes human-readable final phase/tick/reason and historical source provenance.

After extraction the same full snapshot/reply/event/clock bytes still match. Cases cover cadence,
finite/partial/automatic/manual reload, inactive slots, the reserve sentinel, reconnect pause,
Ammo Box replay, Empty Mag's inactive first slot, second-slot theft and the legacy single-slot
fallback. These are deterministic synthetic prototype traces, not a claim that real weapon physics
or normal Unity gameplay was exercised by this focused gate. The capture switch was removed;
normal tests cannot regenerate expected hashes.

Six state/ownership groups add duration-rounding and deadline checks, source clip-setter semantics,
overflow/preflight/conservation, immutable slot membership and compiled private-setter ownership.
The original connection traces and compiled ownership checks remain in the gate.

```powershell
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-weapons --no-build
```

The selector also runs in fast/runtime/full checkpoints. Full runtime combat and native
Mongo/HTTP/protobuf/UDP integration remain required for this simulation increment. No networking
or calculation throughput improvement is claimed from a responsibility extraction.

## Verified checkpoint

Debug and Release solution builds passed with zero warnings/errors. Release focused gates passed
the eight weapon traces/six state groups and all nine connection traces/six lifecycle groups.
checkpoint-3f65ea1ca5f94495ae20fc5ea3645db3 passed all 32 runtime/native stages, including 267,926
battle engine, admission, portable SDK, map and real two-peer UDP assertions. Full battle took
635.1 seconds. Native smoke-1ca9652d97de4a74a9b0969afb1eff74 passed in 40.4 seconds, including
74 live Mongo/HTTP/protobuf/UDP checks, and reclaimed 210,868,625 bytes after owned shutdown.

The six new/extracted C# files pass LF/width/whitespace checks and all six Client evidence hashes
are unchanged. Historical .local directories were preserved. Managed LOCALAPPDATA storage contains
932,108 bytes after retention; no test process remains. S07's remaining state owners, C13's broader
source audit, source-provenance V07 and normal Unity/Android execution retain separate gates.
