# Queue attempt ownership

## Current boundary

`POST /v1/battle/queue/attempt` authenticates the account with the same account
resolver as queue admission. Its request is the existing empty protobuf
`MatchQueueRequest`; unknown fields are rejected. It returns the new protobuf
`MatchQueueAttemptGrant` containing an opaque `token` and its server-authored
`expires_unix_seconds`. The portable SDK exposes `CreateMatchQueueAttemptAsync`.

Issuance is stateless. It creates no waiting ticket, does not replace a pair,
and does not cancel another attempt. If a Unity search is cancelled while its
credential request is in flight, an unused issued token alone cannot create a
queue entry. Queue join/cancel now accept the additive protobuf
`MatchQueueRequest.attempt_token` field. The SDK has scoped join, cancel and
`FindMatchAsync` overloads which retain the same token across polling/retries.
These paths enforce attempt ownership in real Backend/Mongo/Worker tests.
The normal Unity `SelfHostedMatchmakingAttempt` now acquires one credential
before its one permitted search and uses its scoped SDK overloads for search and cleanup. Matching
SDK/protobuf binaries are installed in the active Unity plugin bundle with their
existing asset identities and updated SHA-256 manifest. Controlled native Play
Mode and real HTTP-to-Worker admission verify this integration boundary; full
recovered UI boot and two actual Unity clients remain unverified.

## Token authority

`War.Infrastructure.BattleQueueAttemptTokens` remains server-only. It derives a
purpose-specific HMAC-SHA256 key using `war/queue-attempt/v1/key` from the existing
256-bit control secret. The derived key is independent of the caller's mutable
key buffer. Neither a Unity assembly nor a response receives signing authority.
Use TLS outside explicitly permitted loopback development and never log tokens.

The canonical token is unpadded base64url for exactly 73 bytes:

| Offset | Length | Authority |
| --- | --- | --- |
| 0 | 1 | Format version 1 |
| 1 | 8 | Nonnegative server-issued Unix second, little endian |
| 9 | 16 | Canonical player's 32 hex digits decoded to bytes |
| 25 | 16 | Cryptographically random server-generated attempt identity |
| 41 | 32 | HMAC-SHA256 of the preceding 41 bytes |

No raw `Guid` byte ordering is used. Encoding is checked by exact round trip,
including unused base64 padding bits. MAC comparison uses constant-time equality.
Authentication binds owner, nonce, version and issuance time. Unknown versions,
future issuance, malformed player identity, negative/out-of-range server time,
and expiry overflow are rejected rather than normalized.

Admission uses the half-open interval `[issued, issued + 300)`. Five minutes
matches the current SDK's maximum search timeout; this is reconstruction
transport policy, not a recovered live-service gameplay rule. Both operations
consume one exact caller-provided server second. Cancellation validation can
identify an expired credential, but never makes it eligible for new admission.
This distinction will allow safe cleanup of an original pair after admission
expiry without selecting another attempt for the same account.

## Transactional queue ownership

`BattleMatchQueueStore.JoinAttemptAsync` and `CancelAttemptAsync` use the same
Mongo client, snapshot transaction and majority write concern as pair allocation.
Each ticket carries its attempt ID and signed admission deadline. Each pair
carries two attempt IDs in the same order as its two players. No participant
receives the other participant's token. Legacy rows default to no attempt scope.

`battle_queue_attempts` records the exact player/attempt identity, signed
issuance/expiry, state, optional match ID, retention deadline and revision.
States are `waiting`, `paired`, `cancelling`, `cancelled` and `closed`.
Every admission writes its receipt in the same transaction as ticket/pair
changes. A cancellation before first admission inserts the same receipt ID,
so racing first inserts or receipt updates conflict and retry rather than
publishing two ownership outcomes. A cancelled/closed attempt cannot recreate
a ticket; a paired attempt whose match was released becomes closed.

Cancellation deletes only its exact ticket or captures only its exact ordered
pair. An old request for another attempt returns `not-queued` and never selects
the player's current pair. Paired cancellation records `cancelling`, then the
existing Worker/terminal-acceptance coordinator must still prove and store the
prestart result before releasing that pair. An expired valid token may identify
its original pair but does not create a new cancellation receipt.

Replacing an expired waiting ticket closes other waiting receipts for that
player, so an older still-valid credential cannot reenter after replacement.
Receipt shape, lifetime, revision, state/match binding and ticket/pair coherence
are validated before use. Corruption is rejected rather than reset into a
fresh admission. Candidate receipt reads are bounded. Transaction operations
have a 30-second linked cancellation deadline and bounded duplicate-key retries.

Receipts have a separate `RetainUntilUtc` TTL index, exactly five minutes beyond
the signed admission expiry. This transport policy keeps tombstones past any
in-flight 30-second admission operation at the expiry boundary. The HTTP join
route captures fresh server time again immediately before the queue operation,
after asynchronous allocation/presentation checks. Pruning is cleanup, never
admission authority. Queue lifetime validation rejects retention-date overflow.
Trusted store callers must supply current server time, not replay a historical
request timestamp. Multi-process deployments must maintain coherent server clocks.

Scoped candidates pair only with scoped candidates. Legacy unscoped candidates
remain in their own pool; legacy join/cancel cannot adopt or alter scoped tickets
or pairs. This temporary compatibility partition prevents an older account-only
request from bypassing the new ownership boundary while Unity migration is open.
Unknown request fields and foreign/invalid credentials fail before allocation.
The scoped SDK overloads reject empty credentials instead of falling back to an
account-only mutation. `FindMatchAsync` maps a closed scoped attempt with an empty
match/roster tuple to cancellation; it never interprets it as a new match.

## Required remaining integration

- Exercise the full two-Unity-client gameplay path, including Android and Linux
  runtime coverage, and crashes while requests/registration are still in flight.
- Complete unattended cancellation-intent recovery when every client abandons
  its request, and exercise actual in-flight registration/cancellation races.
  Missing settings/registration now recover through the cancellation coordinator;
  unavailable Worker transport or invalid source authority still requires retry.

These boundaries keep B31/B36 and the overall BattleServer objective partial.

## Verification

The protocol executable adds 100 checks covering ownership, exact expiry,
post-expiry cancellation identity, fresh nonces, restart/key-buffer behavior,
mutation of every token byte, noncanonical encodings, wrong key, unsupported
version and invalid time. The native authenticated queue fixture verifies token
issuance and advertised expiry, rejects unauthenticated issuance, and checks
that issuance creates neither a queue ticket nor a durable pair. These are
credential-boundary tests. The native `--queue-attempts-only` fixture also checks
cancellation before first join, old cancellation after requeue/pairing, legacy
refusal, replacement of expired tickets, retained/pruned receipt behavior,
corruption rejection, and 32 concurrent pairing/cancellation races across two
independent stores. `--queue-live` sends real authenticated protobuf requests,
rejects a foreign player's credential, exercises scoped SDK search/grant download,
cancels its registered Worker match, and verifies stale HTTP cancellation cannot
delete the replacement ticket. Existing manifest/result regression tests remain
separate. These service tests alone do not prove normal Unity or Linux gameplay.

The standard Windows and Linux smoke scripts invoke `--queue-attempts-only`
after initializing their disposable Mongo replica set. The Windows script and
standalone live queue/manifest suites pass at this checkpoint; adding the same
command to the Linux script is not Linux execution evidence. The current
protocol total is 1,322, including eight additive wire/empty-scope SDK guards
and 16 linked-source Unity attempt ownership checks.

## Normal Unity integration

The recovered adapter's plain C# attempt starts stateless credential issuance,
then checks local cancellation before submitting a scoped search. Search polls
and cancellation retries share the same credential and bearer token. Cancellation
while issuance is pending keeps its bounded HTTP request alive, skips admission,
and cleans up only the returned scope. A failed issuance cannot have submitted
a join, so cleanup sends no account-wide fallback. Cancellation before search
starts likewise sends no queue mutation. The original search exception remains
observable; cleanup only suppresses that issuance failure because no scope was
admitted. Existing callback ownership, delayed lobby reset and resource disposal
boundaries remain in effect.

The protocol executable compiles the exact active Unity source. It now checks
pending issuance cancellation, failed issuance, pre-search cancellation, pending
cleanup ownership, rejection of repeated searches on the same owner, rejection of unconfirmed pair cleanup and same-token retry.
The native `UnityMatchmakingCancellationAudit.RunAsync` enters actual Play Mode
and checks normal disconnect, destruction, delayed reset/disable and retained
HTTP scope. `UnityMatchScopeAudit.RunAsync` passes the ownership regression.

`--unity-bazooka-matchmaking-only` now exposes a test-only authenticated protobuf
credential endpoint as well as scoped queue/grant routes, requires exactly one
issuance and validates the same opaque credential on queue requests. The normal
Unity public matchmaking method reaches the actual UDP Worker, automatic adapter
Update and five source explosions with interrupted-callback retry. The fixture
still preallocates its Worker grant; it is not an actual Mongo allocator or
normal recovered login/menu flow. Separate service tests cover real allocator
fencing. Native results come from a disposable Unity 2018.3 project, not a Unity
5.2/Android/Linux or rendered/audible gameplay claim. Static asset audits retain
zero missing scripts/broken references and the same 17 preexisting sprite mismatches.

## Actual Backend process restart evidence

`--queue-live` now stops the real Backend process and starts a new process on the
same port/database/key configuration at three stable checkpoints:

1. An early cancellation receipt exists and another attempt has a waiting ticket.
   The cancelled credential still cannot join, while the original waiting scope
   remains usable after restart.
2. A scoped pair has registered with the running Worker and fetched a grant.
   Scoped SDK search after restart returns a protobuf-equal grant, preserving
   match/manifest identity, player views, session ID/key, expiry and signed ticket.
   An old or unscoped cancellation cannot select this pair.
3. The first pair was cancelled and a new attempt has a replacement ticket.
   After restart an old cancellation leaves the replacement alive, which pairs
   under a distinct match ID. Old cancellation still cannot capture that pair;
   its actual owner can cancel it through Worker terminal acceptance.

The fixture snapshots the complete sorted BSON documents in `battle_queue_tickets`,
`battle_pairs` and `battle_queue_attempts` immediately before stopping Backend and
again after readiness, before further queue calls. Every document, revision and
deadline must remain equal. Snapshots are bounded and never printed. Each restart
uses an actual stop/wait/start lifecycle, not a new store object or a health-check
proxy; the same existing SDK clients and credentials are reused.

This passes with native Windows Backend/Worker processes and a disposable Mongo
replica set. The test intentionally restarts at completed durable checkpoints;
it does not claim crashes during an in-flight transaction, an absent frozen
manifest, complete Unity UI boot or Linux execution. Production behavior did not
need a change for this gate. Standard protocol and smoke regressions remain
separate from this actual restart scenario.

The [interrupted preparation recovery](PAIRED_CANCELLATION_CONTROL.md) checkpoint
also covers scoped pairs before snapshot publication or Worker registration.
The coordinator freezes source-backed settings if absent, recognizes only the
exact `unknown-match` conflict for one registration attempt, then accepts actual
Worker cancellation proof before release. Native cases verify no grant publication
and no mutation of already frozen settings. Unattended recovery and in-flight
scheduling remain separate from that verified request-driven recovery.
