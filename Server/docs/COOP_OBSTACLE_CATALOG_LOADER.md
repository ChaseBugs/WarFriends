# Server observed obstacle catalog loader

`BattleCombatContent.Load` now loads the generated fixed-step pose catalog
as part of its content snapshot. Missing, damaged or unreviewed catalog bytes
fail startup rather than becoming a fallback pose. Deployments must copy the
complete `Server/content` directory, including the compressed catalog.

The loader bounds compressed and expanded streams, checks the reviewed file
digest, recomputes the canonical content revision, binds capture/replay/source
prefab and clip identities, and verifies the skeleton digest and ordered
matrix. Exact known fields reject duplicate, missing or unknown properties.
All 221 samples must preserve contiguous IDs and the complete 17-by-13 phase
ordering. Clip identities, wraps, finite clocks/weights, override count,
ordered non-root transform indexes and finite positive scales are checked
before the catalog object is returned.

Source data remains private after construction. Skeleton and override
collections are read-only; vector/identity values are immutable; animation
requests return a deep protobuf clone with the caller's sample tick. A caller
cannot poison a later sample by mutating an earlier returned frame.

## Verified boundary

The C# loader is checked against the independent native source and replay
captures, not only against its generated JSON. All 221 selections retain their
clip clocks, weights, transform identities and observed float channel values.
Tests also reject changed bytes, oversized files, another source prefab and
out-of-domain sample IDs, and verify immutable collections and nested clip
isolation. These checks run through the normal content loader as well as the
focused command:

```powershell
dotnet run --project Server/tests/War.Battle.Tests -- --observed-obstacle-catalog-only
```

Focused combat passes 26,368 assertions. MongoDB/HTTP/protobuf/UDP smoke passes
1,143 protocol checks, 74 live checks and restart recovery with the required
compressed content present. Those tests do not open public co-op admission.

This installs the server content reader, not the pose presentation feature.
The existing origin selector still returns only a nominal internal candidate.
No protobuf schema, SDK binary, Unity actor or renderer changes here. A future
host/SDK reference must bind the loaded revision and source history; Unity must
validate its actual hierarchy and source assets, including weapon attachments,
before applying a complete override set. Controller callback parity, repeated
interruptions, supported actor styles and normal gameplay remain unfinished.
