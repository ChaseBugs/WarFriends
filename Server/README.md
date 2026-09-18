# WarFriends server — new .NET implementation

This is a fresh implementation following `../BACKEND_DESIGN.md`, with the owner's overrides: **MongoDB, no Docker, Windows development and Linux deployment, protobuf communication, no Photon dependency in the new stack**.

The current checkpoint is executable networking and account persistence, not a complete game backend or a completed Unity migration. Read [the detailed client audit](docs/CLIENT_COMMUNICATION.md) before implementing game features.

## Structure and status

| Project | Responsibility | Current implementation |
|---|---|---|
| War.Shared | Generated protobuf contracts and portable packet codec | .NET Standard 2.0; fixed schema and bounded authenticated packets |
| War.Client | New portable client SDK | Protobuf registration/login/profile; authenticated UDP hello/ping |
| War.Backend | ASP.NET Core/.NET 10 process | Mongo account creation/login/profile, admission grants, readiness/liveness |
| War.Persistence | Official MongoDB C# driver | Unique account/session indexes; salted PBKDF2 credentials; hashed expiring bearer sessions |
| War.Infrastructure | Server-only security | Domain-separated session keys, signed expiring server-bound tickets |
| War.BattleServer | Separate .NET 10 Worker process | UDP receive queue, single-owner 30 Hz host loop, authenticated sessions and replay checks |

The battle process does no database work. It currently hosts connectivity probes, **not battles**. Its queue is capped at 512 datagrams, processing at 128 per tick, with at most 128 admitted/closed unexpired sessions. Closed-ticket tombstones expire with their original tickets. Sessions bind to the observed endpoint; reconnect/address migration requires a new grant. Probe sessions expire after 120 seconds.

Datagrams are protobuf bytes followed by a 32-byte HMAC; total size is at most 1,200 bytes. Authentication covers the exact bytes. HTTP returns the session key over TLS, while the signed admission ticket excludes that key. UDP currently provides integrity/authentication, **not encryption**. No general reliable gameplay channel, allocation, combat, chat, rewards, or anti-cheat proof is claimed. ACK fields reserve the later reliability contract; they do not implement retransmission by themselves.

Mongo is the only required data service. Accounts/session rotation each use a single atomic document write and work with local standalone Mongo. Future multi-document economy/settlement transactions will require a Mongo replica set, including a single-node replica set in development. Redis remains optional for later distributed ephemeral coordination; it is not required by this checkpoint. There is no PostgreSQL, EF Core, Docker, or Kubernetes dependency.

## Windows: verified smoke test

Install .NET 10 SDK and native MongoDB. From the repository root:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File Server/scripts/Smoke.ps1 -MongoExecutable 'C:\Program Files\MongoDB\Server\8.3\bin\mongod.exe'
```

Supply your installed mongod path, or omit the parameter if it is on PATH. This launches an isolated Mongo process on 27028, backend on 18080, and UDP host on 30080. It uses generated development secrets, checks two independent clients, stops only processes it started, restores the calling environment, and retains test data/logs under ignored `Server/.local/`. No existing database is modified.

Verified on Windows: build with zero warnings/errors, **17 targeted protocol/admission/replay assertions plus 1,000 malformed-packet fuzz checks**, and **44 live MongoDB/HTTP/protobuf/UDP assertions**, including the portable SDK. Authentication failures, duplicate accounts, old-session invalidation, tampering, replay and cross-endpoint ticket reuse are tested. These are console test executables; invoke them with `dotnet run`, not `dotnet test`.

## Manual development

`.env.example` documents configuration; .NET does not load that file automatically. In both process shells set the same randomly generated base64 32-byte `Battle__SigningKey`. Set `ASPNETCORE_ENVIRONMENT=Development` only for local HTTP testing. With native MongoDB running at localhost:27017:

```powershell
$env:ASPNETCORE_ENVIRONMENT='Development'
$env:ASPNETCORE_URLS='http://127.0.0.1:8080'
$env:Battle__SigningKey='<same generated base64 key in both shells>'
dotnet run --project Server/src/War.Backend --no-launch-profile
# Second shell, same Battle__SigningKey:
dotnet run --project Server/src/War.BattleServer --no-launch-profile
```

Protobuf endpoints: POST `/v1/accounts/register`, POST `/v1/accounts/login`, GET `/v1/player`, POST `/v1/network/connect`. Use `Content-Type: application/x-protobuf`; authenticated calls require `Authorization: Bearer <token>`. See `protocol/war.proto` and `War.Client`. These endpoints do not implement the stock client's legacy PHP/JSON contracts or its full PlayerData.

## Legacy channel for the recovered 1.4.0 client

The recovered Unity client speaks its own channel, served from `src/War.Backend/Legacy/` at
`POST /index_09_25_2015.php` (a form POST whose `requestId` selects the action) and `GET|POST
/check.php`. It runs alongside `/v1`, which stays the new protobuf API.

Implemented: the boot chain — reachability, `GetConfigurations` (157), `CreateAccount` (118),
`LoginToCustomAccount` (30), `GetPlayerData` (34), `GetAllMessages` (5) and `SetPlayerStatus` (29) —
claim-then-apply idempotent replay of the client's buffered request queue (`SendRequestBuffer` 98,
and the `Buffers` field `GetPlayerData` carries for anything the client never got an ack for) for 5
of its 27 buffered actions: `WeaponWasShown` (104), `ArmyUnitWasShown` (105), `VisualWasShown`
(191), `EquipWeapon` (116), `UpdateEquippedUnits` (1003) — and 6 catalog-free profile/presence
actions: `UpdateDeviceToken` (13), `ChangeLanguage` (150), `ChangePlayerCountry` (196),
`UpdateSettings` (165), `ChangePlayerName` (139, free first rename only), `GetPlayerInfo` (170).
Every other action returns `ServerMaintenance` and logs, because a hollow `Success` would send the
client into a handler that indexes response keys it did not receive — most remaining actions need
the Google2u price/reward/unlock sheets first. See `todo_list.md` for the complete Backend/Battle
Server checklist. This is not a playable game backend: no battles, squads, leagues, arena, or real
purchases.

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File Server/scripts/LegacySmoke.ps1 -MongoExecutable 'C:\Program Files\MongoDB\Server\8.3\bin\mongod.exe'
```

Verified on Windows against live MongoDB: **75 assertions** covering the exact wire shapes the
shipped client parses — the DynamoDB AttributeValue encoding of `Player`/`PlayerData`, bare
top-level `Result`/`Time`, the `"ok"` probe body, the semicolon-delimited configuration stream,
session rotation, rejection of stale/forged/cross-bound tokens, buffered-request idempotency
(replaying the same buffer id/index returns the recorded result rather than re-applying it, for
both the direct `SendRequestBuffer` path and buffers carried on `GetPlayerData`), and the
`GetPlayerInfo` case where the client indexes a top-level response key directly and so requires an
explicit JSON `null` rather than an omitted key for an unknown player.
`docs/CLIENT_COMMUNICATION.md`
records the evidence for each shape.

To point the client at this server, change only the host in its `BeanstalkUrlCreator`; the paths
already match. Configure starter state under `Legacy:Starter` — it is authoritative, and the
client's own `StartingGold`/`StartingWarbucks` assertions are discarded. Serving the legacy channel
over plain HTTP requires `Legacy__AllowInsecureHttp=true` and logs a warning; it exposes
credentials and session tokens, so use it only on an isolated offline network.

## Linux without containers

Install the .NET 10 runtime and MongoDB natively. A Linux smoke script is provided:

```bash
bash Server/scripts/smoke.sh
# Override MONGOD if the executable is not on PATH.
```

It also needs curl and openssl. Linux-x64 publish succeeded from Windows:

```sh
dotnet publish Server/src/War.Backend -c Release -r linux-x64 --self-contained false -o Server/artifacts/linux/backend
dotnet publish Server/src/War.BattleServer -c Release -r linux-x64 --self-contained false -o Server/artifacts/linux/battle
```

Native Linux execution has not been tested in this Windows session. Copy artifacts to `/opt/warfriends/backend` and `/opt/warfriends/battle`; the `deploy/*.service` files are systemd templates for a dedicated unprivileged `warfriends` user. Supply restricted `/etc/warfriends/backend.env` and `battle.env` files. Do not copy development secrets.

Production must use HTTPS. The backend rejects non-HTTPS game requests outside Development. Configure Kestrel with a real certificate using `ASPNETCORE_URLS=https://0.0.0.0:8443` plus `Kestrel__Certificates__Default__Path`/`Password`, or explicitly configure a trusted proxy/TLS arrangement before deployment. Forwarded headers are not trusted by default. Keep Mongo private and authenticated. Set `Battle__PublicHost` to the advertised host, `Battle__BindAddress` to the appropriate local interface, and open only the chosen UDP port. Health endpoints are `/health/live` and `/health/ready`.

## Unity integration boundary

`War.Client` and `War.Shared` target .NET Standard 2.0 and are tested by the smoke client. Unity integration requires the .NET 4.x/compatible .NET Standard profile and the matching Google.Protobuf dependencies; the original Unity 5.2 legacy profile is not compatible. Do not copy arbitrary dependency versions into the currently recovered project.

No client scenes, prefabs, scripts, or Photon DLLs were removed or altered in this server checkpoint. The SDK is ready for an isolated Unity integration scene; replacing the existing game's 165 RPC definitions and 398 view attachments requires the staged migration in the audit. Neither a successful console handshake nor a Linux publish proves Unity gameplay compatibility.

## Design references

- [Official MongoDB C# driver](https://www.mongodb.com/docs/drivers/csharp/current/get-started/)
- [Protobuf C# generated code](https://protobuf.dev/reference/csharp/csharp-generated/)
- [Microsoft: native Linux hosting with systemd](https://learn.microsoft.com/en-au/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-8.0)

Package versions are pinned in project files and NuGet lockfiles. Keep `War.Infrastructure` server-only; it contains ticket-signing capability and must not be distributed with Unity.
