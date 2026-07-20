# WarFriends repository guidance

## Recovered-client sources

- Treat `Client` as the 4.9.5 resource source of truth.
- Treat `Client-Decompiled-Mono-1.6.0` as the recovered C# script, protocol, and behavioral-contract source.
- When the two versions differ, document the evidence and keep any server fallback explicit; do not invent retired live-ops prices, schedules, weights, or rewards.

## Server implementation rules

- Implement `Server` behavior from recovered client contracts and authoritative server state. Client-provided prices, rewards, scores, ownership, and progression are assertions, never authority.
- Keep every currency, item, reward, receipt, and claim transition atomic and retry-safe. Validate a nonnegative server-authored currency reward with `checkedRewardBalance` before publishing its claim or receipt marker.
- Apply that guard to direct rewards, conversion proceeds, level-up bonuses, PvP settlement components, and duplicate-item compensation; do not reintroduce one-off `balance + reward` checks.
- Preserve legitimate negative Gold or WarBucks chargeback debt, but reject non-safe-integer rewards and arithmetic overflow.
- Fail closed when authoritative combat evidence, live-event configuration, or source-backed balancing is unavailable.
- Add detailed English comments where recovered names are opaque or atomicity, replay, migration, or fallback decisions are not obvious.

## Change discipline

- Run `npm test` from `Server` for backend changes.
- Update `Server/BACKEND_FEATURES.md` and `Server/README.md` when backend behavior or a documented gap changes.
- Keep unresolved backend gaps explicit. Do not mark a feature complete while its authoritative source or external provider integration is missing.
- The worktree may contain unrelated recovered-client changes. Stage and commit only files belonging to the current increment.
