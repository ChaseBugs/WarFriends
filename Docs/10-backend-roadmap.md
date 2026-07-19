# Backend Implementation Roadmap

## Source of truth

The detailed, action-level tracker is `Server/BACKEND_FEATURES.md`. This document summarizes the
remaining work by gameplay dependency rather than duplicating every `DatabaseAction` row.

## Highest priority

### Improve PvP authority

- provide a Photon-compatible client path or complete the WebSocket adapter;
- add optional bot fallback for offline population;
- validate combat event order, timing, damage, and result plausibility;
- decide whether full authoritative combat simulation is required.

### Complete remaining inventory families

- non-shop visual rewards, parts, offers, and rentals;
- card reward/consumption events and server-selected card/Buddy RNG protocols;
- lootboxes and Arena crowns;
- offers, rentals, VIP, and subscriptions;
- platform-verified real-money purchase receipts and refunds.

Normal Gold/WarBucks card-pack purchase and `CardManagerData` persistence are implemented. The
stock protocol still lets the client select identities inside a server-validated rarity envelope;
see [War Cards and card packs](12-war-cards-and-card-packs.md) for the compatibility boundary.
Timed three-for-one crafting and server-selected claim results are implemented; subscription-only
instant crafting remains closed until subscriptions are authoritative. Normal squad-card deposits
and cross-player withdrawals are implemented with source capacity/reputation/cooldown rules and a
two-player MongoDB transaction. Buddy deposits now reproduce the recovered current-player snapshot
from server-owned weapon, visual, Army Power, name, and level state and enforce the exact cooldown;
the stock client still selects its random unit type locally.
Card-pool contribution reminders use the exact recovered type-28 inbox message, same-roster
authorization, and persistent daily actor/target idempotency.
Confirmed PvP settlement now validates and atomically consumes each reporter's normal/Buddy War
Cards together with both players' core rewards and the terminal match row. This also proves starter
assignment `ID_2`; detecting card plays omitted by a modified stock APK still requires live Photon
or replacement-relay event validation.
Normal PvP responses now also include the recovered `IIGFODGJBFA` `GameReward` shape, preventing
the stock result parser from dereferencing a null reward object when `Skill` is returned. The
response always includes `LevelExperience` but emits `Level` only for a real level transition, so
ordinary matches no longer trigger the client's level-up branch.
All 58 source level thresholds and Gold rewards are now extracted with rank power. Confirmed PvP
settlement applies level changes, Gold, remaining level XP, and recomputed Army Power atomically,
and persists per-player match receipts for exact finished-request replay.

## Progression and live operations

- recover production daily reward and assignment sheets;
- recover mission selection and normal reward formulas;
- deliver heroic card/part rewards through authoritative inventory;
- implement league seasons, divisions, promotion/relegation, and immutable claims;
- add versioned, signed remote configuration publication.

## Social and operations

- replace or repoint Photon Chat;
- add squad events and wars;
- add friend graph, pagination, and push delivery;
- add moderation review, sanctions, and appeals;
- extend the process-local HTTP token bucket to shared HTTP/WebSocket enforcement, then add
  metrics, tracing, backups, migrations, and admin authentication;
- coordinate WebSocket rooms across multiple server instances.

## Implementation rules

- Never report success for a gameplay mutation that is not implemented.
- Currency, item, reward, and claim changes must be atomic and idempotent.
- Match and reward logic must use server-confirmed facts.
- Preserve exact client wire fields, but do not trust client-owned values.
- Add tests for valid flow, authorization failure, stale state, malformed price, replay, and
  concurrent mutation.
- Update `Server/BACKEND_FEATURES.md` whenever an implementation status changes.
