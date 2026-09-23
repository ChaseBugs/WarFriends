# Player damage port (1.4.0)

`PlayerDamage.cs` ports the health transition from the active recovered Client. It is an internal simulation operation, not a network request or RPC endpoint. `MatchEngine.ApplyResolvedPlayerDamage` requires an admitted running match and a validated combat definition. The host must supply a resolved target, server-authored damage and server-owned random roll. It publishes health/death revisions and an unscored `player-killed` terminal state for this two-player prototype.

## Source order

1. `DestroyableObject.Shoot` and `Burn` multiply by the target's `shotCoeficient`. Explosion, Shiver and Poison do not take that multiplier here.
2. `DestroyableObjectpart.DoDamage` applies part `weight` and selects the owner.
3. `DestroyableObjectPlayer.DoDamage` applies the weapon's normal/overtime player coefficient for Shot, Explosion and Shiver. Weaponless Explosion/Shiver use the separate constants instead. Flame and Poison do not take these player coefficients.
4. `DestroyableObject.DoDamage` rejects same-fraction weapons without `friendKill`, then applies the friendly coefficient. It records original damage, applies immortality, computes the full-health one-hit flag and subtracts damage. Health is upper-clamped to maximum; lethal health may remain negative.
5. `PlayerController.OnDamage` may refund damage for the strict random-roll/chance comparison, self damage, or tutorial protection below 20% health. This happens before the death check. The actual refunded amount is removed from damage, matching the callback accounting in `DestroyableObject`.
6. Death is evaluated after that callback. The prototype closes a duel on a player death; this is not a port of every co-op/campaign end rule.

Enum values retain the recovered `DestroyableObject.DamageType` order. Arithmetic deliberately uses binary32 operations in source order. Malformed definitions, damage, multipliers, enum values and random samples fail before publication. Negative input is limited to the source healing paths (Heal and weaponless repair represented as Shiver); these inputs are not player-controlled.

## Boundaries

- Critical selection, spread, impact falloff, hitboxes, body-part selection, projectiles and damage ownership must be resolved upstream by the host. This module does not invent those rules.
- `PlayerCombatManifest` is trusted startup input. It is optional for existing weapon-only fixtures, and when enabled must define both opposing participants. It is not yet bound to a complete validated loadout/catalog. Numerical caps are explicit reconstruction safety limits, not recovered balance values.
- A server simulation must call the resolved-hit operation once per impact. It has no public endpoint, external hit ID or retry contract. Future projectile/event processing must own impact deduplication.
- Health fields travel in full snapshots, including `combat_enabled`, `health`, `max_health`, `dead`, and `damage_revision`. Global `state_revision` orders changes within a single tick, preventing replayed command receipts from rewinding the Unity adapter.
- The normal `FireCommand` only performs the existing static map query. It does **not** call this path until player collision authority exists. The SDK/Unity adapter can carry the new state, but original health bars, death animations and battle-controller callbacks are not yet wired to it.
- Rewards remain disabled. No Backend or Mongo settlement changes are part of this port.

`PlayerDamageTests.cs` covers coefficient/type distinctions, lethal and refunded hits, healing, malformed authority, atomic rejection, terminal immutability and snapshot size/order. These are source-derived regression fixtures, not a claim of rendered Unity combat parity.

Validation on 2026-09-19: 467 Battle assertions passed (poll-dependent count); solution build passed without warnings/errors; 1,017 protocol and 44 native Mongo/HTTP/UDP smoke checks passed. The actual Unity Mono audit now drives `SelfHostedBattleClient` through connect/ready/fire/refresh/terminal and verifies main-thread events plus rejection of same-tick stale health snapshots. This is an Editor component/transport test, not a Play Mode combat or Android proof.
