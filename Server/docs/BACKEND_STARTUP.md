# Backend and Worker startup policy

Both hosts capture supported deployment settings before opening their listeners. Backend resolves
database syntax, rate limits, battle admission/content and legacy policy into BackendDeploymentOptions
before creating any Mongo store. Worker resolves runtime, shared keys/endpoints and worker paths into
BattleHostStartupOptions before NetworkWorker loads content or opens journals and sockets.

Invalid supported settings print a bounded configuration diagnostic and exit with code 1. Key bytes
and Mongo URI credentials are not printed. This validates configuration, not database availability:
a valid but unreachable Mongo URI still fails during the separate store-initialization phase.

## Explicit legacy mode

Source-backed gameplay requires Legacy__ContentPath to identify the reviewed recovered catalog:

```powershell
$env:Legacy__ContentPath=(Resolve-Path 'Server/content/recovered-battle-content.json').Path
```

For connectivity/profile development only, omit that path and explicitly set
Legacy__AllowCatalogFreeStartup=true. The default is false. This preserves the existing compatibility
starter values and closed catalog-dependent mutations, without making a missing production catalog
look intentional. A configured blank, padded, missing, malformed, empty or unreviewed source fails
even when catalog-free startup is enabled. The flag never suppresses a catalog error.

Legacy starter options bind once over source-backed or compatibility defaults and are validated into
the existing immutable LegacyStarterPolicy. Legacy__AllowInsecureHttp remains a separate explicit
Boolean. Neither flag changes action IDs, callback fields or server ownership of economy.

Smoke.ps1 and smoke.sh deliberately enable catalog-free mode for connectivity checks. LegacySmoke.ps1
uses the real reviewed catalog when present. Its -AllowCatalogFreeStartup switch permits the existing
refusal-only compatibility suite when the file is absent; omission otherwise fails before Mongo starts.

## Shared host constraints

War.Infrastructure/Configuration owns rules used by both executable projects:

| Setting | Supported value |
| --- | --- |
| Battle__SigningKey | Base64 decoding to exactly 32 bytes; at least one nonzero byte |
| Battle__ControlKey | Same byte constraints; must differ from the signing key |
| Battle__Port | Int32 from 1024 through 65535; default 30000 |
| Battle__ControlPort | Int32 from 1 through 65535, different from UDP; default UDP + 1 |
| Battle__ServerId | 1-64 ASCII letters, digits or hyphens; default local-1 |
| Battle__PublicHost | Valid host/IP without surrounding whitespace or control characters |
| Control/result/allocation URL | Absolute HTTP(S), positive port, no credentials, query or fragment |

Backend and the executable Worker require a control key. Lower-level embedded Worker fixtures may
omit it when they do not expose control operations. BattleKeyMaterial captures keys without retaining
IConfiguration; getters return defensive copies. Direct BattleTickets and MatchTokens construction
also applies the nonzero signing-key rule. A valid encoding is a shape check, not proof of entropy;
generate independent cryptographically random deployment keys.

Absent numeric settings use the documented defaults. Provided malformed, fractional, exponent,
overflowing or out-of-range values fail rather than selecting a fallback. Shared deployment Int32
parsing uses invariant integer syntax. Worker retains its existing fixed 30-Hz/1200-byte limits.

Backend validates Mongo__Uri syntax and Mongo__Database before constructing any client. Diagnostics
identify the setting, without including the URI or a driver exception containing credentials.

## Frozen rate and content options

RateLimiting__Api__PermitLimit defaults to 120 and RateLimiting__Auth__PermitLimit to 10. Both accept
positive Int32 values. Each WindowSeconds defaults to 60 and accepts 1-86400 seconds. One frozen
policy per limiter supplies every partition; queue capacity remains zero. Reloading configuration
does not mutate an already running policy. Review operational values before restarting a host.

Backend captures every supplied template/content path and refuses blank/padded/missing files.
Weapon-specific content requires the base combat package. When matchmaking provisioning is enabled,
the selected source catalogs and template validate eagerly before database initialization. Templates
must be bounded JSON, have the expected mode, two slots, no allocation rows, a matching ServerId and
source-backed weapon bindings. MatchmakingCompatibilityKey requires a template and uses its existing
bounded identifier alphabet. Dynamic player/loadout authority still validates at publication time;
startup validation does not replace it or complete C12/C13.

## Composition ownership

- Hosting/Configuration owns captured deployment values and startup-only source loading.
- AddBackendServices groups deferred persistence, legacy, battle/provisioning and limiter registration.
- BackendApplicationExtensions initializes stores in the original order and installs the pipeline.
- BackendRequestMiddleware preserves HTTPS policy and protobuf failure envelopes.
- BattleControlHttpClient gives the two control adapters one container-owned, disposed HttpClient.

Program.cs now composes feature endpoint maps. Modern accounts, connectivity, grant/reconnect, queue
and rematch use cases have named application owners; see
[BACKEND_HTTP_STRUCTURE.md](BACKEND_HTTP_STRUCTURE.md). Direct/buffered legacy dispatch also has
explicit typed owners; see [LEGACY_ACTION_STRUCTURE.md](LEGACY_ACTION_STRUCTURE.md).
Domain and Simulation reference neither Infrastructure nor either host.
Sharing deployment validation adds no signer, Mongo driver or configuration dependency to those
libraries or to the portable SDK. This change makes no measured speed or capacity claim.

The Backend S05 route extraction preserves these boundaries:

1. Health, account and player/network endpoint maps have feature owners, retaining
   auth/api rate-limit groups and the current protobuf failure envelope.
2. Shared modern/legacy battle-player authentication preserves canonical ID and session
   validation before admission or storage work.
3. Queue join/cancel and grant/reconnect application services have named inputs and bounded results,
   preserving transaction order, cancellation/recovery, rollback and replay.
4. Internal provision/result/allocation routes use domain-separated MAC authentication and bounded
   reads. Native HTTP reproduced C25 before its size refusal changed from 404 to 413.
5. The recovered PHP channel has its own typed direct/buffered dispatch, preserving raw action 157.

Protocol/native/legacy and Release live queue/reconnect/rematch checks verify these host extractions.
Worker composition/control now has explicit owners; see WORKER_HOST_STRUCTURE.md. Normal Unity
gameplay and full simulation-system extraction remain separate work.

## Verification

```powershell
python Server/scripts/verify_battle_checkpoint.py --suite focused --case backend-startup
python Server/scripts/verify_battle_checkpoint.py --suite focused --case startup-refusals
```

The first selector checks ten policy groups, configuration/key/template immutability, real source
starter selection, bounds, redaction and deferred DI registration. The second launches seventeen owned
Backend/Worker processes with malformed deployment settings, a deliberately blocking unreachable
Mongo URI and a 15-second deadline. Each must exit 1 with its setting diagnostic before database
initialization or outbox creation. It records stdout/stderr inside the checkpoint's managed temp
directory, which successful finalization removes.

Fast includes the pure policy group. Runtime also includes actual refusal processes, full battle
tests and optional native smoke. Console selectors exercise server processes and headless clients;
they do not verify normal Unity gameplay, Android or Linux service execution. The independent source
provenance gate V07 and ordinary GameEnded C18 remain open.
