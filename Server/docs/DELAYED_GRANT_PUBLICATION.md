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

This checkpoint concerns cancellation winning publication. It does not claim all
normal combat-terminal/result-write races, arbitrary packet faults, two actual
Unity clients, Android/Linux runtime or full BattleServer completion. B05/B31/B36
and the overall objective remain partial.
