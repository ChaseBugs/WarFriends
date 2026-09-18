# Fresh .NET server guidance

- Follow the owner's accepted design: ASP.NET Core backend and separate .NET battle Worker, MongoDB persistence, protobuf, native Windows/Linux processes, no Docker or Photon dependencies.
- Keep this first networking/account checkpoint distinct from a complete game implementation. Do not label the connectivity endpoint as matchmaking or award rewards from probe packets.
- Inspect current 1.4.0 client builders/parsers before implementing legacy behavior; use the generated inventory as an index, not an exhaustive semantic specification. Preserve source evidence and version distinctions.
- Keep session signing secrets in server-only `War.Infrastructure`; distribute only the portable `War.Shared` and `War.Client` dependencies to Unity.
- Database writes belong in the backend. Future inventory/reward/settlement operations require validated server authority and atomic idempotency; multi-document Mongo transitions require a replica set.
- Bound datagrams, queues, sessions, replay windows, and reassembly before adding gameplay traffic. ACK metadata alone is not reliable delivery. Do not turn arbitrary original RPCs into authoritative server commands.
- Run `dotnet build WarFriendsServer.sln`, `dotnet run --project tests/War.Protocol.Tests`, and the native Mongo smoke for networking/account changes. On Windows use `scripts/Smoke.ps1`; on Linux use `scripts/smoke.sh`. Do not claim Linux or Unity runtime verification from cross-publishing alone.
- Keep the owner's concurrent Client edits intact. Any Photon removal must preserve scene/prefab identities and be preceded by a verified replacement for each relevant behavior.
