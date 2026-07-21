# WarFriends repository guidance

## Recovered-client sources

- Treat `Client` as the 4.9.5 resource source of truth.
- Treat `Client-Decompiled-Mono-1.6.0` as the recovered C# script, protocol, and behavioral-contract source.
- When the two versions differ, document the evidence and keep any server fallback explicit; do not invent retired live-ops prices, schedules, weights, or rewards.

## Server implementation rules

- Implement `Server` behavior from recovered client contracts and authoritative server state. Client-provided prices, rewards, scores, ownership, and progression are assertions, never authority.
- Keep every currency, item, reward, receipt, and claim transition atomic and retry-safe. Validate a nonnegative server-authored currency reward with `checkedRewardBalance` before publishing its claim or receipt marker.
- Apply that guard to direct, one-time, and tutorial rewards; conversion proceeds; level-up bonuses; PvP settlement components; and duplicate-item compensation. Do not reintroduce one-off `balance + reward` checks.
- Validate server-owned assignment, starter-assignment proof, achievement, War Arena, and Squad War eligibility/placement counters and receipt timestamps as nonnegative safe integers before comparisons, increments, or claim markers; `NaN` and `Infinity` must never satisfy a reward gate or placement through JavaScript comparison behavior.
- Bind each real-money purchase action to its reviewed entitlement family; sharing store-proof verification must never let a token cross into an incompatible response or grant path.
- Validate paid-VIP deadlines as nonnegative safe-integer Unix seconds at their shared boundary. A non-finite VIP expiry must never become permanent access through JavaScript comparison behavior.
- Keep account sanctions as audited server-owned records. Enforce active bans through the shared authentication path only after credential proof, evaluate temporary expiry from application time rather than TTL cleanup, return the recovered `AccountBanned` fields, and require retry-safe operator issue/revoke keys.
- Keep moderation report review transitions optimistic and append-audited: require the operator's expected status, never reopen a terminal report, and replay only an identical actor/decision/note operation.
- Keep player appeals ownership-scoped and separate from stock gameplay actions. Accept one appeal per active sanction through the current session credential, expose no private sanction fields, require optimistic append-audited review/withdrawal transitions, and revoke an accepted appeal's live sanction in the same transaction.
- Keep moderation retention explicit and operator-driven: freeze one preview timestamp for bounded export and purge, delete only terminal reports/appeals older than configured cutoffs, retain sanctions indefinitely, and publish the purge counts in the same idempotent transaction as deletion.
- Rotate `AUTH_SECRET` through the bounded fallback-key overlap documented in `Server/README.md`: keep gameplay sessions valid, verify durable password/provider digests against fallbacks only, and compare-and-set rehash a successful fallback login with the active key before retiring the old key.
- Treat each stored custom-password scrypt factor as verification authority within the bounded supported range. Raising `AUTH_SCRYPT_COST` may upgrade a successful login, but a temporary lower setting must never downgrade an already stronger digest.
- Keep ordinary offline-bot battles outside ranked settlement. Their action-64 metadata may select a durable zero-reward lifecycle only after server-owned Play Warcards eligibility is checked; client-simulated bot results must never grant or consume economy, progression, cards, rentals, achievements, assignments, leagues, or events.
- Preserve legitimate negative Gold or WarBucks chargeback debt, but reject non-safe-integer rewards and arithmetic overflow.
- Fail closed when authoritative combat evidence, live-event configuration, or source-backed balancing is unavailable.
- Add detailed English comments where recovered names are opaque or atomicity, replay, migration, or fallback decisions are not obvious.

## Change discipline

- Run `npm test` from `Server` for backend changes.
- Update `Server/BACKEND_FEATURES.md` and `Server/README.md` when backend behavior or a documented gap changes.
- Keep unresolved backend gaps explicit. Do not mark a feature complete while its authoritative source or external provider integration is missing.
- The worktree may contain unrelated recovered-client changes. Stage and commit only files belonging to the current increment.
