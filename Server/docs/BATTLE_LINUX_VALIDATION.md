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
