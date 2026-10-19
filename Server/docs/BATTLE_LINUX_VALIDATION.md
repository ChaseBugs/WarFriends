# Linux Battle validation

This checkpoint validates the Battle test executable on Linux. It is separate
from a production-host rollout, Android gameplay and complete co-op authority.

## Environment

- Validation date: 2026-10-17.
- Gameplay source checkpoint: `eb35c6b71`, with the test publication fix below.
- Execution: Ubuntu 22.04.5 LTS under WSL2, x86-64 Linux.
- Build SDK: .NET 10.0.401 on Windows.
- Published runtime: self-contained .NET and ASP.NET Core 10.0.12, `linux-x64`.
- No Docker and no installed Linux .NET runtime required for this executable.

## Test publication fix

The test executable references Backend and BattleServer assemblies. A normal
publish previously failed with `NETSDK1152`: both referenced applications tried
to publish their appsettings files, and the direct/transitive Worker references
contributed duplicate runtime metadata.

`War.Battle.Tests.csproj` now sets
`_GetChildProjectCopyToPublishDirectoryItems=false`. The .NET SDK's publish target
therefore leaves referenced applications' content with those applications;
assembly dependencies and runtime-pack assets still resolve normally. The test
executable owns its own configuration, deps file and runtimeconfig file. This
does not suppress duplicate-file errors or alter either production app project.

The inspected fresh publication retains `War.Backend.dll`, `War.BattleServer.dll`,
`War.Shared.dll` and the test's own deps/runtimeconfig. Referenced appsettings
files are absent. The self-contained executable starts and runs actual Worker
tests inside Linux, rather than merely cross-compiling.

## Reproduce

From the repository root, publish to a new output directory:

```powershell
dotnet publish Server/tests/War.Battle.Tests/War.Battle.Tests.csproj `
  -c Release -r linux-x64 --self-contained true `
  -o Server/.local/linux-battle-validation
```

For WSL, use the installed distribution's actual name and repository mount path:

```powershell
wsl --distribution Ubuntu-22.04-AGE --cd /mnt/e/Github/Mobile/WarFriends `
  --exec /mnt/e/Github/Mobile/WarFriends/Server/.local/linux-battle-validation/War.Battle.Tests
```

Keep the executable under the repository tree for this test suite's recovered
content discovery. It uses temporary loopback UDP sockets and temporary result
stores. Require terminal exit zero and the final complete Battle assertion
summary; a publication success or partial PASS line is insufficient.

## Verified boundary

The complete executable exited zero and reported 143,124 Battle engine,
admission, portable SDK, map geometry and real two-peer UDP assertions. Poll
counts can vary between runs. The capacity scenario completed 60 rounds of
32 concurrent match polls over 8.00 seconds, with round p95 37.1 ms and maximum
41.4 ms. Recent co-op point changes, reservation conservation, emitted-projectile
retention/eviction and player damage ratio checks are included in this run.

The Windows full solution build with the publication fix also passed with zero
warnings and errors. Linux MongoDB smoke remains a separate unverified check
for this checkpoint.

These timings describe the WSL test environment, not a production-host service
level. This pass does not certify normal Unity scene rendering,
Android, all game modes or Backend economy settlement.

## Current-source regression on 2026-10-19

This later checkpoint uses Ubuntu 22.04.5 WSL2 x86-64 and self-contained .NET/ASP.NET Core
10.0.12 publications at `.local/linux-protocol-audit` and `.local/linux-battle-audit`.
The protocol executable exits zero, including its 1,360-check protocol/admission/replay group.
Focused Linux groups pass 46 bilateral army-perk checks, 24 starter host checks, 130 source army
wave checks and 14,326 Mortar indicator/pool checks. The latter two also pass on Windows.

The first broad run rejects a stale deployment-manager fingerprint. Review of c830ce762 to
104f27751 confirms only retired-binding response guards changed, with Spawn unchanged. The
whole-file guard remains enforced with the reviewed current digest. A subsequent broad run
rejects old Mortar reference provenance. Rather than bypassing that check, the unchanged Unity
probe is rerun against the actual active prefab and Weapon source; all ten input hashes match,
and both complete scenario records are identical. The static pool extractor also changes only
its source provenance. See [clock review](BATTLE_CLOCKS.md) and
[actual Unity recapture](MORTAR_INDICATOR.md) for the exact digests and scope.

Because the pool provenance revision participates in the package digest, all four local match
templates receive freshly computed package identities. No pool capacity, return timing,
manifest gameplay field or admission policy is changed by this refresh. Old package identities
are not silently treated as current. The current Windows native smoke exits zero at
`.local/smoke-ba06b64298054e3fa0d237c355fc659d`, including 74 MongoDB/HTTP/protobuf/UDP checks,
transactional terminal/card acceptance, cancellation and restart evidence. That Mongo-backed
Windows run must not be described as Linux MongoDB validation.

The final complete Linux executable exits **zero** with **264,545** battle engine, admission,
portable SDK, map geometry and real two-peer UDP assertions. Its complete log is
`.local/linux-battle-current.log`; the earlier failure before the Mortar refresh is retained at
`.local/linux-battle-before-mortar-refresh.log`. The capacity interval completes 61 rounds of
32 concurrent polls over 8.14 seconds, p95 37.9 ms and maximum 38.2 ms. These are WSL observations,
not production service guarantees. The run retains explicit diagnostic-only physics/navigation
comparisons and does not establish exact original Unity physics or presentation equivalence.

Linux production deployment, Linux MongoDB integration, Android, rendered normal-match entry
under the new default, results and rematch remain separate acceptance gates. The latest
normal-Editor attempt is recorded in [the admission policy](ADMISSION_POLICY.md); successful
account boots and a native full-suite pass do not close its Editor startup failure.

## Native Linux Mongo integration on 2026-10-19

This later run closes the Linux Mongo smoke gap above, not the remaining game acceptance gates.
Ubuntu 22.04.5 WSL executes self-contained linux-x64 Backend, Worker, protocol tests,
Battle tests and SmokeClient from `.local/linux-integration/<project-name>`.
MongoDB 8.0.34 runs natively with an isolated replica set and data on the Linux filesystem.
No Docker, system-wide SDK installation, or existing database is used.

The official Ubuntu 22.04 x86-64 archive is
`https://fastdl.mongodb.org/linux/mongodb-linux-x86_64-ubuntu2204-8.0.34.tgz`;
its verified SHA-256 is `8eef2a821651ac20f732b6636731a51b407675674ced8d7f1f1578ebc7aced43`.
See the [official tarball instructions](https://www.mongodb.com/docs/v8.0/tutorial/install-mongodb-on-ubuntu-tarball/).

Publish each of `War.Backend`, `War.BattleServer`, `War.Battle.Tests`, `War.Protocol.Tests`,
and `War.SmokeClient` with `dotnet publish <project.csproj> -c Release -r linux-x64
--self-contained true -o Server/.local/linux-integration/<project-name>`.
Then, from a Linux shell at the repository root:

```bash
MONGOD="$PWD/Server/.local/linux-mongodb-8.0.34/bin/mongod" \
PUBLISHED_ROOT="$PWD/Server/.local/linux-integration" \
SMOKE_RUN_ROOT=/root/warfriends-smoke \
HTTP_PORT=28080 MONGO_PORT=29028 BATTLE_PORT=31080 CONTROL_PORT=31081 \
bash Server/scripts/smoke.sh
```

Use a writable native Linux `SMOKE_RUN_ROOT` for your account; `/root` reflects this WSL user.
Omit `PUBLISHED_ROOT` to use the original installed-SDK build mode. Port inputs are validated
before startup. The script owns, stops, and reaps only its own service children.

The first run passed transaction tests but failed service readiness with empty host logs.
Explicit per-host `contentRoot` fixed startup; a direct Worker probe then immediately reached
key validation, and the complete rerun passed. This scopes configuration loading/watchers to
each application rather than the repository. Backend publication also exposed `NETSDK1152`:
referenced Worker settings and executable metadata collided with the Backend's own files.
Backend now excludes child-project publish content while retaining referenced assemblies.
Its published appsettings hash matches its source and only its own runtimeconfig is present.

The final smoke exits **zero**, including replica-set election, queue/cancellation recovery,
atomic terminal/card/pair publication, 25 prestart orderings, 22 command acknowledgements,
the protocol executable (including 1,360 protocol/admission/replay checks), and **74 live
MongoDB/HTTP/protobuf/UDP checks with two independent clients**. The complete output is
`.local/linux-native-mongo-smoke-fixed.log`. Service logs are copied to
`.local/linux-mongo-backend.log` and `.local/linux-mongo-worker.log`; the native run directory
is `/root/warfriends-smoke/smoke-PiS5rt2F`. The ordinary solution build also passes with zero
warnings/errors. This is not Linux restart/fault parity with the larger Windows smoke,
production-host installation, wallet settlement, normal Unity gameplay, or Android acceptance.
