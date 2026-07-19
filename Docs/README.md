# WarFriends Core Logic Documentation

This directory explains the recovered WarFriends game logic and the reconstructed backend in
English. Each document covers one system, its authoritative data, its runtime flow, its trust
boundary, and the implementation gaps that still prevent full production fidelity.

The documentation distinguishes three states:

- **Implemented**: the server persists and validates the behavior and has an exercised test path.
- **Partial**: useful logic exists, but an original client contract or authoritative input is missing.
- **Missing**: the server rejects the mutation instead of returning a false success.

## Documents

1. [Client and server architecture](01-client-server-architecture.md)
2. [Accounts and player state](02-accounts-and-player-state.md)
3. [Economy, weapons, and units](03-economy-weapons-and-units.md)
4. [Army Power calculation](04-army-power.md)
5. [PvP matchmaking and battle settlement](05-pvp-matchmaking-and-battles.md)
6. [Squads and social systems](06-squads-and-social.md)
7. [Progression, assignments, missions, and achievements](07-progression-and-missions.md)
8. [War Arena](08-war-arena.md)
9. [Versioned gameplay material database](09-gameplay-material-database.md)
10. [Backend implementation roadmap](10-backend-roadmap.md)
11. [Player visuals and decals](11-player-visuals-and-decals.md)
12. [War Cards and card packs](12-war-cards-and-card-packs.md)

## Authoritative references

- `Client-Decompiled-Mono-1.6.0`: readable C# caller and response-contract reference.
- `Client/ExportedProject`: recovered 4.9.5 scenes, serialized Google2u tables, and assets.
- `Server/src`: current backend implementation.
- `Server/BACKEND_FEATURES.md`: detailed action-by-action implementation tracker.
- `BACKEND.md`: original backend reconstruction specification.

When documentation and code disagree, treat the recovered client call path and the current
server implementation as the primary evidence, then correct the documentation.
