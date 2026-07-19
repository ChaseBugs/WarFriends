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
- war cards, card packs, crafting, and squad card pool;
- lootboxes and Arena crowns;
- offers, rentals, VIP, and subscriptions;
- platform-verified real-money purchase receipts and refunds.

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
- add rate limiting, metrics, tracing, backups, migrations, and admin authentication;
- coordinate WebSocket rooms across multiple server instances.

## Implementation rules

- Never report success for a gameplay mutation that is not implemented.
- Currency, item, reward, and claim changes must be atomic and idempotent.
- Match and reward logic must use server-confirmed facts.
- Preserve exact client wire fields, but do not trust client-owned values.
- Add tests for valid flow, authorization failure, stale state, malformed price, replay, and
  concurrent mutation.
- Update `Server/BACKEND_FEATURES.md` whenever an implementation status changes.
