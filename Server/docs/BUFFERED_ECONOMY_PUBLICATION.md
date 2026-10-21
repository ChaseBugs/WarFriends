# Buffered economy publication

The active 1.4.0 Client writes requests to `RequestBuffer.requests`, sends them through action 98,
and carries pending buffers through action 34 at boot. `ServerResponseHandler.ProcessBuffer` uses
action-specific success and rollback fields. Replaying only a result number loses that evidence.

## Ownership and commit

`LegacyBufferParser` validates the complete envelope before processing. `LegacyBufferProcessor`
calculates a transition without database writes. `LegacyBufferStore.ExecuteAsync` owns the MongoDB
transaction and returns the committed account plus the exact stored response.

For each action the transaction reads the current account and receipt. If an exact entry exists,
it reuses the recorded outcome. Otherwise it calculates against that account, writes all changed blobs,
balances, ArmyPower and one revision increment together, and appends the response to the receipt.
Those writes commit or roll back together. A competing write retries from a fresh snapshot, with
one captured request time and server-generated random seed reused across transaction retries.
The whole operation has a linked 30-second deadline and at most four duplicate-insert retries.

Identity binds player, buffer ID, index, action and SHA-256 of the exact serialized action/data pair.
Changing an action or payload cannot borrow a previous result. The receipt retains the complete
original response as evidence. The wire view preserves its result and identity, refreshes requested
rollback fields from the returned current account, and projects applicable delivery countdowns.
Action 34 passes the returned account to the next buffer and its final PlayerData projection.

## Client response projection

`LegacyBufferedRollback` refreshes existing failure fields for wallets, inventory, weapons, units,
army flags, cards, cosmetics and pending deliveries. It does not execute the failed action again.
An account that gained funds or items after a failed request must not be reset on screen to that
request's older snapshot. Missing legacy blobs retain their explicit empty-state path; a present
non-object blob is rejected rather than converted into fresh authority. Complete nested-state
validation remains C13 work.

`LevelManager.SetWeaponDeliveryTime` and `SetUnitDeliveryTime` add the response's `DeliveryTime`
to the Client's current timestamp. Caching that relative number verbatim can extend the countdown.
Timed upgrade receipts therefore also store the original kind, item, upgrade index and absolute
deadline. `LegacyBufferedResponse` returns remaining seconds only while that exact delivery still
matches current state, returns zero when expired, and omits the optional field for a successor or
unrelated delivery. The private metadata never becomes a Client response field. Its deadline and
the request clock must fit the recovered signed Int32 clock. Legacy timed entries without this
evidence remain refused rather than guessing a deadline.

This makes ordinary buffered purchases and their receipts atomic. Direct card deposit/withdrawal,
squad transitions, crafting, and other independently implemented writers still require their own
audit. Their remaining defects are not fixed merely by sharing a MongoDB database.

## Replay migration and retention

Old null-result claims and old result-only receipts lack enough evidence to reconstruct an outcome.
They are retained and refused with the existing per-action ServerRespondedWithError result; the
server never re-executes them or invents success/rollback state. Conflicting retries are also refused.

Startup removes TTL indexes from the buffer receipt collection. New receipts remain durable because
the recovered Client saves pending buffers across restarts and provides no authenticated maximum
replay age or acknowledgement watermark. Client-generated IDs are never interpreted as trusted time.
This policy cannot recover receipts already deleted by an earlier TTL deployment. Operators must
preserve existing receipts; future compaction needs a permanent replay fence rather than deletion.

Bounds are 256 entries per buffer, 128 characters per buffer ID, 1 MiB UTF-8 per response, and 8 MiB
of response JSON per receipt. An exhausted or malformed receipt fails before publication. These are
explicit server resource limits, not recovered production policy. Indefinite receipt retention has
an ongoing database-storage cost; it is separate from disposable `.local` test data.

## Verification and current boundaries

The native Mongo fixture checks competing purchases, simultaneous duplicate delivery, exact failed
response replay after later wallet changes, altered action/payload rejection, receipt-write failure
after the player update, historical claims, removal of old TTL indexes, 90-day-old replay, a fresh
buffer after that replay, service recreation after reply loss, and committed-account projection.
A temporary Mongo collection validator causes the receipt-write failure; no production test hook
or feature bypass is added. The fixture drops only its uniquely named test database.
Competing purchases use a barrier to force both original wallet reads before either write and assert
that the conflicting transaction actually recalculates. This does not depend on incidental scheduling.

Legacy HTTP smoke also replays every buffered outcome exercised by its fixtures, checking current
rollback state, retained identity/result fields and deadline-aware countdowns. It
rejects malformed later requests/buffers without applying earlier entries, and checks purchase plus
replay through boot. Source envelope tests cover exact count/count+1, duplicate fields/indexes,
canonical indexes, unknown/wrongly typed fields and metadata consistency.
Typed action-value readers also keep malformed strings/Boolean flags inside the per-action result.
The input and response suites cover 48 input checks, ten delivery-clock cases, seven rollback
projection cases and nine bound cosmetic replay cases. The storage suite has eight real Mongo scenarios.
The source callback oracle adds 1,188 matrix checks, 50 original producer scenarios and 151 catalog
fixture scenarios covering all 126 literal server action/result dispositions. First delivery and
replay must match current wallet/item/subsystem authority as consumed by the instrumented Client
boundaries, while preserving the canonical outcome. It uses
the unchanged recovered callback/value parser with instrumented manager/UI boundaries, without
a Unity project copy. See [LEGACY_BUFFER_CONTRACTS.md](LEGACY_BUFFER_CONTRACTS.md) for the reviewed
matrix, required BuyDecal success fields, safe historical projection and the remaining policy/runtime boundary.
Catalog rows now have immutable storage and exact numeric readers. Missing price fields and unrelated
table selection cannot silently turn into zero-cost upgrades. See
[LEGACY_CATALOG_VALIDATION.md](LEGACY_CATALOG_VALIDATION.md) for validation and the remaining release audit.
Pure replay assertions run on Windows PowerShell 5.1 and PowerShell 7: explicit object-array conversion
prevents 5.1's nested pipeline-array behavior from bypassing field inspection.

These are server transaction and protocol proofs. They do not prove all action-specific policy,
the remaining catalog/durable-state validators, full gameplay settlement, Unity/Android gameplay,
production Linux behavior, or improved network performance. See the root `todo-list.md`.
