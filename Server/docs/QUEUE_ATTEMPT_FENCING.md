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
queue entry. Normal queue join/cancel still use their existing account-scoped
contracts: this checkpoint does **not** enable distributed attempt fencing.
The new SDK method/protobuf type have not been installed into the Unity plugin
bundle or connected to `SelfHostedMatchmakingAttempt` yet.

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

## Required remaining integration

1. Add a scoped request contract carrying the token and bind each waiting ticket
   and ordered pair member to its validated attempt identity.
2. In the same Mongo transaction that removes a waiting ticket or captures a pair,
   persist a cancellation receipt scoped to player and attempt. A cancellation
   arriving before its delayed join must prevent that join from creating a ticket.
3. Every join/refresh/pair publication must check that receipt under transactional
   write-conflict protection. Never select an account's newer ticket or pair
   through an older attempt, including legacy unscoped requests.
4. Retain receipts through the signed admission deadline. Pruning after that
   deadline is safe only because new joins reject the expired token. Mongo TTL
   cleanup delay must not affect authority. An expired cancellation with no
   matching original ticket/pair must not reopen admission or create unlimited
   historical receipts.
5. Serialize token acquisition/search/cancel ownership in the normal Unity
   attempt, preserve the same token through retries, install matching portable
   binaries, and test cancellation-before-join, delayed old cancellation after
   requeue, concurrent independent Backend stores, restart and expiry.

Only after those steps are proven can B31/B36 claim distributed cancellation
ownership. Registration before a frozen manifest is available, complete recovered
UI entry, two actual Unity clients and Linux gameplay remain separate open work.

## Verification

The protocol executable adds 100 checks covering ownership, exact expiry,
post-expiry cancellation identity, fresh nonces, restart/key-buffer behavior,
mutation of every token byte, noncanonical encodings, wrong key, unsupported
version and invalid time. The native authenticated queue fixture verifies token
issuance and advertised expiry, rejects unauthenticated issuance, and checks
that issuance creates neither a queue ticket nor a durable pair. These are
credential-boundary tests, not proof of the unimplemented scoped queue lifecycle.
