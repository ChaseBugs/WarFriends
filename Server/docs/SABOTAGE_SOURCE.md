# SABOTAGE card: recovered 1.4.0 contract

This is source evidence for a **pending** BattleServer card, not a claim that
the offline Client can activate it. The scene enables `SABOTAGE` and binds
`CardSabotage`; the current Worker has no authenticated command for it.

`SabotageTargetPolicy` now implements and tests the two-draw selection over
an explicit, ordered host candidate snapshot. It is not yet called by the
match: mechanical shootable registration, card spending, damage dispatch,
protobuf, and Client wiring remain pending.

## Client behavior

`CardSabotage.UseCard` runs target selection only on the old Photon master,
then consumes the card even if there is no target. The replacement must make
the BattleServer the sole selector and consume one Backend-provisioned card
through the existing idempotent card receipt. The Client must send the card
identity and request ID, never a target or damage value.

`GameShootableEntity.GetAllMechanicalTypes()` lists, in order: `AICar`,
`AICarBuggy`, `AICarTransporter`, `Tank`, `Helicopter`,
`AssaultHelicopter`, `Drone`, `Turret`, and `Mech`. `GetRandomOpponent`
collects visible, living, opposing shootable entries in that type order and
draws one uniformly. `CardSabotage` then collects the subset whose owner is an
`AIObject`, whose shootable part is `isMain`, and whose real-time age is
strictly greater than five seconds. If that subset is nonempty, a second
uniform draw from it replaces the first choice. An empty mature subset does
**not** make the card inert: the first draw can still select a younger or
non-main mechanical entry. With no visible living opposing entry, the card
is spent without a hit.

The selected `DestroyableObject` receives one `Shot` damage operation of its
own `maxHealth`, with `isOneHit` and `ignoreImmortality` set, part index zero,
no weapon, and the activating player's ownership. This is not automatically
equivalent to deleting an entire vehicle: multi-part damage, shared health,
statistics, and death callbacks must pass through their existing host
authorities. The exact recovered random-stream order and the eligible
shootable registration set need validation before enabling the command.

## Implementation boundary

1. Pin each live mechanical family and its main/non-main shootable parts to
   the host entity registry, including visibility, owner, spawn tick, and
   source `maxHealth`. Do not infer eligibility from a Client target list.
2. Select one candidate with a bounded host random draw, then apply the
   mature-main override exactly as above. Use a single current host tick to
   compare the strict five-second threshold.
3. Send the hit through the family's normal damage/death path, publish the
   usual lifecycle events, and commit selection, card spending, and the
   replay receipt atomically. Replaying a request must not draw again.
4. Add a normal authenticated Client command, protobuf/SDK validation, and
   focused cases for each mechanical family, young fallback, mature-main
   override, no target, replay, and two-peer event agreement.

Source files: `Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardSabotage.cs`,
`GameShootableEntity.cs`, `AIObject.cs`, and `DestroyableObject.cs`; scene
identity: `Clients/ExportedProject/Assets/Scenes/MainScene.unity`.
