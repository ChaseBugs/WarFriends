# Unattended prestart cancellation recovery

## Durable intent

Authenticated cancellation now records `BattlePairDocument.Cancellation` in the
same Mongo snapshot/majority transaction that captures the exact pair. A scoped
request must own its ordered player/attempt slot; legacy unscoped requests may
record an intent only for a legacy pair. The first intent is retained instead
of resetting its retry deadline on every client retry.

The record contains its requesting player/attempt, `RequestedUtc` and
`RetryAfterUtc`. It lives on the pair and has no TTL. Short-lived admission
receipts can therefore expire without deleting an outstanding cancellation.
Only accepted terminal authority releases the pair and removes its intent.
Missing fields on old pair documents mean no durable pair intent for discovery;
the service never infers cancellation just because players are absent, and does
not backfill older temporary receipt formats. If old receipts have already
expired, their original intent cannot be reconstructed from an unmarked pair.
A new authenticated cancellation can still record intent for that exact pair.

A failed or disconnected HTTP request does not roll back a committed intent.
This is deliberate: once the owner requested cancellation, recovery must not
resume that same allocation as if no cancellation had happened. Client cleanup
still requires `cancelled` or `not-queued`; Worker refusal is not a success.

## Bounded claims and execution

`BattleCancellationRecoveryService` starts with Backend and polls every five
seconds. It claims at most four due pairs per pass, using a normal Mongo index
on `Cancellation.RetryAfterUtc` and pair identity. The complete selected page is
validated before its first claim write. Validation covers full pair identity,
ordered scope ownership, UTC dates and ordered request/retry times. Discovery
also selects missing/wrong date types and impossible future dates that an
ordinary due-date predicate could hide. A malformed page is reported and stays
unmodified for operator repair; no unvalidated authority is silently reset.

A claim compares all pair identity fields and the complete observed cancellation
record before moving the retry deadline forward by exactly 60 seconds. Another
Backend cannot claim that same observed record. If the process stops, the next
Backend may take over at the half-open expiry boundary. There is no volatile
in-memory owner flag or cleanup dependency on a client bearer token.

The four claimed operations run concurrently inside one 30-second pass budget,
which is shorter than the claim window. Transport/source failures retain the
pair for a later claim. Small records written after a discovery time capture are
left for the next pass; future-date validation leaves room for that bounded
concurrency rather than treating a slightly later legitimate write as damage.
These fixed immutable intervals are reconstruction transport policy, not
recovered live-service economy or competition timing.

Recovery calls the same `BattlePairedCancellation` path as the HTTP endpoint.
It may freeze source-backed settings and recover one missing registration,
then requires actual hash-bound Worker prestart cancellation evidence. No player
grant is published. Running or conflicting Worker authority is never converted
into cancellation; its eventual legitimate terminal result remains authoritative.
Neither a claim nor a retry awards rewards, declares a winner or releases a pair.

## Evidence

`--queue-cancellation-recovery-only <MongoUri>` uses two independent stores to
verify intent survival after receipt removal, exclusive claims, exact deadline
takeover, legacy rows without an attempt array, and complete-page rejection
before any valid candidate is claimed. Corruption cases cover foreign ownership,
far-future retry dates, missing retry dates and malformed intent structure.
The standard Windows/Linux smoke scripts invoke this storage gate after their
replica-set bootstrap. Linux script inclusion is not Linux execution evidence.

The live queue fixture creates a historical expired scoped pair without its
short-lived receipt, stops Backend, commits the cancellation intent, and starts
a fresh Backend. No HTTP cancellation retry is sent. It verifies real Worker
terminal proof, matching frozen hash, no winner, no grant publication, both
players released and no recreated expired receipt. The Worker-outage extension
keeps Worker stopped beyond the complete 30-second pass budget before restoring
it, so recovery must retain authority and use the real 60-second retry claim
rather than merely finish its first in-flight request.

Full recovered UI/two-Unity-client gameplay, Android/Linux runtime, all possible
mid-instruction crash schedules and broad production completion are not inferred
from these focused native Windows tests. B31/B36 and the overall BattleServer
objective remain partial.

The native Worker-outage scenario passes with the production 60-second claim
interval unchanged: the first complete pass fails while Worker remains down,
the pair stays allocated with no result, and a later pass completes after Worker
returns. Recovery publishes no grant and does not recreate the expired receipt.
The pre-existing deferred-provisioning fixture no longer sends a cancellation
and then resumes that same pair as if cancellation had been rolled back;
outage/retention coverage now belongs to this explicit unattended scenario.
