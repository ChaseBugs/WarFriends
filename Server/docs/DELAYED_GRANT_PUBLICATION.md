# Cancellation before delayed grant publication

A deterministic live regression now holds the HTTP response from an actual
Worker registration before `BattleMatchProvisioner` can parse it and publish its
grants. Backend HTTP cancellation runs through real Worker terminal evidence,
accepts that result and releases the exact pair. Only then is the registration
response released. This models a delayed registration completion without adding
a production test hook or fabricating Worker grants.

The old code reproduced the defect: publication returned success and inserted a
grant after accepted cancellation. The public grant lookup already refused a
missing pair, but private stale grant publication and the provisioning success
were still incorrect and could mislead a waiting queue request.

## Transactional publication

Normal Backend provisioning now calls `BattleGrantStore.PublishForActivePairAsync`.
It validates the complete grant document, then uses one Mongo client/session,
snapshot transaction and majority write concern to:

1. Read and validate the exact allocator pair and ordered roster.
2. Refuse a missing pair or a committed cancellation intent.
3. Validate the stored frozen manifest and require its digest to match the grants.
4. Increment the server-owned `GrantPublicationRevision` on that same pair.
5. Validate/replay an existing identical grant or insert the new grant document.

The pair write is deliberate. Merely reading a pair and writing a separate grant
would allow snapshot write skew. Cancellation intent and pair removal also write
that pair, so Mongo write conflicts serialize them with publication. A stopped
publication cannot commit a new grant after cancellation wins. The new revision
is nonnegative, checked against exhaustion, private to persisted allocation
state, and defaults to zero on old pair rows. It does not change a client DTO.

When the pair is no longer publishable, provisioning returns `cancelled` and the
ordinary join route emits an empty cancelled queue response. That closes search
admission; it is not invented combat outcome or reward authority. The normal
Worker/terminal acceptance path still owns the battle result. Previously
published grants remain retained historical records; delivery continues to
require an active pair.

The older unfenced `Publish` helper remains for existing trusted fixture/storage
uses. Normal `BattleMatchProvisioner` uses only the fenced operation. Its previous
complete grant validation and retry equality checks remain shared rather than
being reimplemented with weaker checks.

## Verification boundary

The delayed-response fixture first failed on the old implementation with
`A delayed registration response published a grant after accepted cancellation`.
The corrected implementation returns cancelled and leaves no new grant row.
The fixture uses a real signed Worker registration, real Backend cancellation,
a Mongo replica set and the actual provisioner. It does not proxy the entire
normal join HTTP request or force a particular interleaving inside Mongo's
transaction engine. Existing stable-grant, Backend restart, HTTP/UDP race and
unattended Worker-outage cases remain regression gates.

## Terminal acceptance publication

Backend-allocated terminal acceptance now stores the validated result and removes
the allocation in one snapshot/majority transaction. That transaction revalidates
the complete pair, frozen manifest, ordered participants and currency proof.
Grant publication writes the same pair, so concurrent transactions must serialize
or retry; there is no committed result-with-live-pair interval from this path.
An exact prior result remains replayable after allocation removal. A conflicting
result cannot release an allocation. Historical accepted-result/live-pair rows
can be repaired by an exact replay after the same authority validation.

Trusted non-allocator result storage remains separate. This does not retrofit
atomicity into direct fixture calls to the older result-store helper. Existing
native queue tests exercise normal terminal forwarding, cancellation and replay.
The delayed-registration case additionally sends two concurrent exact result
replays after pair removal and requires both to remain already accepted without
recreating an allocation. These checks do not force every internal database
interleaving. Arbitrary packet faults,
two actual Unity clients, Android/Linux runtime and full BattleServer completion
remain unverified. B05/B31/B36 and the overall objective remain partial.

The focused `--atomic-terminal-only <MongoUri>` gate creates a synthetic
prototype match, advances both admitted players to Running, and records a real
engine forfeit result. A database change stream must show the result insert and
pair delete with the same nonempty transaction identity (`lsid`, `txnNumber`).
Two concurrent exact replays must then return `already-accepted` with no pair.
Both native smoke scripts include this gate. It verifies actual database
atomic publication, not recovered weapon balance or full HTTP/UDP scheduling.

At this checkpoint the focused transaction/replay gate passed. The additional
full `--queue-live` attempt timed out during the first Worker registration
(`BackendQueueLiveTests`, before terminal acceptance); its later cases, including
the new delayed-response replay assertion, were not reached. That run is not
counted as a passing full-network regression. The earlier passing queue checks
above remain historical evidence for their earlier revision.

The Windows smoke run `Server/.local/smoke-3d21322833374811bdadda54568840bd`
passed the new transaction/replay gate, 1,322 protocol checks and 74 live
Mongo/HTTP/protobuf/UDP checks. Linux shell syntax passed; Linux runtime was
not exercised by this checkpoint.

A later full Release queue run at revision `1baef61f2` passed Backend restart,
delayed registration replay, actual HTTP/UDP races and unattended outage recovery.
See [terminal room replay](TERMINAL_ROOM_REPLAY.md) for that run's evidence and
the subsequent SDK change; the earlier timeout above remains historical.
