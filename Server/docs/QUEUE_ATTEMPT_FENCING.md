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
The normal Unity `SelfHostedMatchmakingAttempt` still calls the unscoped SDK
path; the new SDK/protobuf binaries have not been installed into its plugin
bundle yet. Distributed fencing is therefore not active in normal Unity play.

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

- Acquire and preserve one credential in normal Unity search/cancel ownership,
  install matching SDK/protobuf binaries, and audit native Play Mode cancellation
  and admission with the actual recovered adapter.
- Exercise scoped requests across real Backend process restart and the full
  two-Unity-client gameplay path, including Android and Linux runtime coverage.
- Coordinate cancellation intent with registration before a frozen manifest is
  available. A missing manifest or unavailable Worker still requires retry;
  the existing control flow does not yet guarantee a completed early pair cancel.

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
separate. No normal Unity or Linux gameplay proof is inferred from these tests.

The standard Windows and Linux smoke scripts invoke `--queue-attempts-only`
after initializing their disposable Mongo replica set. The Windows script and
standalone live queue/manifest suites pass at this checkpoint; adding the same
command to the Linux script is not Linux execution evidence. The current
protocol total is 1,307, including eight additive wire/empty-scope SDK guards.
