# Card pool publication

Actions 174 and 175 use the active 1.4.0 Client contract. Policy and pure transfer rules live in
`War.Backend/Legacy/Cards`; session-bound Mongo writes and receipts live in
`War.Persistence/Legacy/Cards`. No database work runs in the battle tick.

## Source authority

- `BeanstalkServerManager.DepositCards` sends `AddedCards` and `RemovedCards`. Each is a JSON object
  whose values are JSON strings containing exactly one positive Int32 `amount`.
- `CardpoolDialog.GetCardsInJson` constructs those deltas. Invalid entries reject the entire request;
  duplicates, nulls, bare numbers, negative quantities and unknown ordinary identities cannot partially
  change ownership. Opposite deltas for the same card are refused. Empty deltas are refused because
  the source caller submits only changed inventories.
- `CardpoolDialog.WithdrawCard` adds `ReputationPointsForWarcard` to the donor's displayed reputation.
  The server therefore credits the donor using the recovered Bronze/Silver/Gold rows: 5/15/45.
- `CardpoolDialog` multiplies `CardWithdrawTimer` by 60. The recovered 240 means **240 minutes**,
  or 14,400 seconds. Policy validates an exact positive minute value and multiplication bounds once
  at startup. Configured malformed policy fails startup; absent content closes these actions.
- `CardpoolRecord` offers withdrawal only on another member's row. Self-withdrawal is refused to
  prevent reputation farming; own stock returns through `RemovedCards` without reputation.
- `ServerResponseHandler.OnWithdrawCard` directly indexes `NextWithdraw` on success. The wire response
  projects the current authoritative absolute deadline, including on an old keyed replay, so a stale
  receipt cannot reset a newer cooldown in the Client.

The ordinary identity snapshot includes all 67 rarity 1/2/3 source rows. It does not equate the separate
combat host allowlist with card ownership. Buddy-card rental deposits retain their explicit unsupported
boundary. This increment validates the ordinary inventory touched by transfers; it does not claim the
complete shared progression/container validation tracked in C13.

## Transaction and conflict behavior

One snapshot/primary/majority transaction reads the actor, optional donor and current squad roster.
The pure rules validate stock, ownership, shared account/roster membership and cooldown, then compute
checked Int32 amounts, reputation and deadline. A withdrawal updates receiver inventory/cooldown,
donor stock/reputation, a squad revision fence and its receipt together. A deposit updates owned and
deposited cards together, including the existing squadless own-stock reallocation path.

Every affected account and squad write checks its read revision. The squad fence makes concurrent
leave/kick/roster changes conflict even when the membership mirror update has not yet finished.
Mongo retries a transient conflict by re-reading and recalculating; the request uses one captured
application time. A linked 30-second deadline bounds the operation, and duplicate receipt insertion
gets at most four additional transaction attempts. Invalid durable state fails closed without writes.
The separate multi-document squad membership operations still need C04's own atomic rewrite.

Receipts have no TTL and bind actor, action and canonical intent digest. Optional `OperationId`
is an exact 1-64-character ASCII letter/digit/underscore/hyphen identity. Its scope is one actor across
both actions. Explicit blank/null/malformed IDs reject; the same ID with different intent/action
rejects. Operation and audit receipt namespaces are distinct. A recorded keyed failure also replays
its original result rather than becoming a later success when state changes.

## Recovered Client retry limit

The recovered request builders do **not** supply an operation nonce. `requestId` is an action number,
not a request identity. Identical consecutive deposits may mean either two legitimate deposits or a
retry after a lost response. The server cannot distinguish these from the current fields. It does
not permanently deduplicate payloads and silently suppress legitimate deposits.

Replacement callers can send one `OperationId` per intent and retain it across retries. For an
unkeyed withdrawal, a matching success is replayed only while its exact recorded deadline equals the
actor's current active cooldown. After expiry it is a new request; this is not permanent exactly-once
delivery. Unkeyed deposits get atomic conservation and an audit receipt, but no cross-request retry
identity. C03 remains open for deliberate Client nonce integration and its HTTP retry proof. No Client
source or recovered asset was changed by this increment.

## Verification

`--legacy-card-pool-only` checks source cooldown/reputation, conservation, explicit self-withdrawal
refusal, missing roster proof, checked inventory/deposit/reputation/deadline overflow and malformed
double-encoded payloads. `--legacy-card-pool-transactions-only <replica-set-uri>` exercises real Mongo:

1. Two receivers read the same last card behind a barrier; exactly one wins after recalculation.
2. Concurrent same-key deposits, altered intent and service recreation after a lost reply.
3. Unkeyed withdrawal replay within its exact cooldown, and refusal to replay after expiry.
4. A receipt collection validator fails after account/squad writes; all affected documents roll back.
5. Donor roster removal after the read forces conflict/revalidation and refuses the transfer.

`LegacySmoke.ps1` runs both focused suites and checks the real HTTP double encoding, keyed deposit
replay, changed/empty operation identity, whole-request malformed rejection and own stock return.
Tests use the existing owned disposable replica set sequentially; they do not create a second Mongo
data directory. Successful runs discard database files and retain compact logs through `TestRun.ps1`.
