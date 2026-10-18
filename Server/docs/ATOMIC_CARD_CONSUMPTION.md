# Atomic paired-result card consumption

`Card.RemoveCard` decrements one ordinary card at successful use and preserves a zero-amount row.
The self-hosted Client callback removes a card only after host acceptance. Client `UsedCards`
end-battle assertions remain telemetry; they do not authorize durable inventory mutation.

`BattleResultStore.AcceptAndReleasePairAsync` now applies confirmed ordinary-card debits in the
same MongoDB transaction as the first result insert and durable pair deletion. This is independent
of reward eligibility: consuming an owned card is not a reward grant.

## Authority and replay

The pair and frozen manifest must match the validated terminal roster and manifest digest.
Each card usage must then bind:

- An ordinary source identity already validated in terminal evidence.
- That player's frozen positive owned allocation and selected-hand identity.
- Exactly one current hand use per source identity; replenishment has no settlement provenance yet.
- Sufficient current durable quantity in the completely validated `CardManagerData` container.

Canonical source IDs are preferred. A historical class alias is supported only when the source
class has exactly one recovered identity and agrees with the terminal source ID. Ambiguous
multi-source aliases are rejected.

All consuming accounts validate before the first inventory update. Writes compare the complete
previous serialized card state; Mongo transaction conflicts retry the transaction with a new
snapshot. Insufficient or malformed authority aborts without publishing a result or releasing the
pair. Exact concurrent result replay sees the accepted result and never applies the debit again.
An existing accepted result is never retroactively charged, including historical rows.

`OrdinaryCardInventory.Read` is now the shared parser for allocation and consumption. It retains
the previous strict source-ID/shape/count checks and nonempty-Buddy rejection. Account projection
remains read-only. Debits retain untouched metadata and zero ownership rows.

## Verification

`AtomicCardConsumptionTests`, included in `--atomic-terminal-only`, runs actual native host
selection, typed `UseSlowMove` commands from both players, and terminal evidence generation.
A real Mongo change stream verifies two account updates, one result insert, and one pair delete
share the same session and transaction number. Cases also verify concurrent exact replay, one
insufficient account rolling back the entire operation, explicit test repair and retry, final-copy
consumption to a retained zero row, and missing frozen allocation rejection without any debit.

Release build passed with zero warnings/errors. `--allocation-inventory-only` passed after parser
extraction. The owned single-member Mongo replica-set run also passed the existing grant-first,
terminal-first, and 12 concurrent terminal/grant cases. Artifacts:
`.local/card-consumption-b318897cdb684e308a4493c976257b3d`.
The complete native suite was not rerun for this checkpoint.

## Remaining integration

This covers the paired result-acceptance path. Standalone result archival does not establish
account inventory authority. Historical accepted results need separate deliberate reconciliation;
replaying them cannot charge players. Buddy consumption/summoning and granted in-battle cards
need complete source and provenance contracts before they can use this path.

Normal automatic allocation, inventory reservation at admission, and coordinated fencing of
other legacy read-modify-write card operations remain open. A terminal transaction does not by
itself prevent an unrelated legacy operation from later overwriting an earlier-read blob. Normal
queue and rendered Unity gameplay proof therefore remain incomplete.
The later [conditional crafting publication](CARD_SUBSYSTEM_CONCURRENCY.md) now protects the
craft-start and crafted-card claim writers. Deposit/withdrawal and buffered inventory writers
still require their own coordinated transitions.
