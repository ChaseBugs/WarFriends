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
- Validate Player League competition mirrors (`MedalsBalance` and `Skill`), beginner tier, normal tier, and the exact zero-or-one placement counter before boot, tutorial repair, admission, ranking, or settlement; one corrupt member must abort a reward settlement before its first write.
- Validate the complete `StarterAssignmentsData` snapshot before account creation, boot projection, completion, or claim. Its deadline must be a bounded safe Unix second, only the ten recovered IDs may exist, record flags must be Boolean, and a claimed record must also be completed; corrupt deadlines must never make onboarding rewards permanently claimable.
- When a buffered starter action rejects corrupt durable onboarding state, return an expired empty `StarterAssignmentsData` error view without mutating or reserializing the damaged snapshot; one invalid action must not escape its recovered per-action RequestBuffer result.
- Validate the daily-assignment `issued`/`tomorrow`/`dayKey` tuple as one UTC cycle before rollover, gameplay mutation, or serialization. Both timestamps must be bounded safe Unix seconds and the reset/day key must be exactly derivable from issuance; a non-finite reset must never freeze one assignment day permanently.
- Validate a current-month daily-reward calendar as one ordered authority snapshot: year/month and `lastCheckDay` must describe a real UTC date, and `0 <= claimReward <= canClaim <= daysInMonth`; discard an expired prior-month snapshot before validation because it carries no claim authority forward.
- Bind each real-money purchase action to its reviewed entitlement family; sharing store-proof verification must never let a token cross into an incompatible response or grant path.
- Validate paid-VIP and subscription timestamps as nonnegative safe-integer Unix seconds at their shared boundaries. Subscription authority must remain one ordered interval (`subscribeSince <= dogTagTimerLock <= expireTime`), and a future start must never activate benefits early. A non-finite entitlement expiry must never become permanent access through JavaScript comparison behavior or an invalid durable receipt date.
- Validate the complete rental lifecycle before boot projection, loadout, Army Power, acceptance, settlement, or permanent redemption. Only source-backed weapon/unit types, 20-25% discounts, safe timestamps, and status-consistent trial/sale intervals may authorize borrowed inventory; corrupt deadlines must fail closed rather than become permanent access.
- Validate the complete Black Market set before boot projection, action-217 replay/rotation, serialization, or buffered weapon redemption. Expiry and issue cursors must be safe integers; offer identities must be unique and bounded; feature authority remains zero until the retired weighting source is recovered.
- Validate the complete visual inventory before boot projection, purchase, ownership/equip checks, paid-pack extension, or voided-purchase reversal. Timed `expiresOn` values and part counters must be bounded safe integers, saved flags and equipped slots must retain the recovered shape, and non-finite expiry must never turn a temporary cosmetic into permanent access.
- Keep account sanctions as audited server-owned records. Enforce active bans through the shared authentication path only after credential proof, evaluate temporary expiry from application time rather than TTL cleanup, return the recovered `AccountBanned` fields, and require retry-safe operator issue/revoke keys.
- Keep moderation report review transitions optimistic and append-audited: require the operator's expected status, never reopen a terminal report, and replay only an identical actor/decision/note operation.
- Keep player appeals ownership-scoped and separate from stock gameplay actions. Accept one appeal per active sanction through the current session credential, expose no private sanction fields, require optimistic append-audited review/withdrawal transitions, and revoke an accepted appeal's live sanction in the same transaction.
- Keep moderation retention explicit and operator-driven: freeze one preview timestamp for bounded export and purge, delete only terminal reports/appeals older than configured cutoffs, retain sanctions indefinitely, and publish the purge counts in the same idempotent transaction as deletion.
- Rotate `AUTH_SECRET` through the bounded fallback-key overlap documented in `Server/README.md`: keep gameplay sessions valid, verify durable password/provider digests against fallbacks only, and compare-and-set rehash a successful fallback login with the active key before retiring the old key.
- Treat each stored custom-password scrypt factor as verification authority within the bounded supported range. Raising `AUTH_SCRYPT_COST` may upgrade a successful login, but a temporary lower setting must never downgrade an already stronger digest.
- Keep ordinary offline-bot battles outside ranked settlement. Their action-64 metadata may select a durable zero-reward lifecycle only after server-owned Play Warcards eligibility is checked; client-simulated bot results must never grant or consume economy, progression, cards, rentals, achievements, assignments, leagues, or events.
- Keep production MongoDB backups authenticated and encrypted before they leave temporary local storage. Retention may delete only an old, path-confined archive/manifest pair whose database, size, and SHA-256 all validate; malformed, damaged, unrelated, or orphaned files must remain for operator review.
- Keep monitoring artifacts on the bounded metrics contract actually exported by `metricsService`. Alerts must require sustained signals and meaningful traffic where ratios are used; Redis alerts apply only to scrape targets explicitly labeled `redis_required=true`.
- Preserve legitimate negative Gold or WarBucks chargeback debt, but reject non-safe-integer rewards and arithmetic overflow.
- Fail closed when authoritative combat evidence, live-event configuration, or source-backed balancing is unavailable.
- Add detailed English comments where recovered names are opaque or atomicity, replay, migration, or fallback decisions are not obvious.

## Change discipline

- Run `npm test` from `Server` for backend changes.
- Update `Server/BACKEND_FEATURES.md` and `Server/README.md` when backend behavior or a documented gap changes.
- Keep unresolved backend gaps explicit. Do not mark a feature complete while its authoritative source or external provider integration is missing.
- The worktree may contain unrelated recovered-client changes. Stage and commit only files belonging to the current increment.
