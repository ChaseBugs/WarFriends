# WarFriends backend design

## Accepted implementation overrides — 2026-09-19

The owner has requested a fresh implementation in `Server` using this design,
with **MongoDB instead of PostgreSQL**, **native Windows/Linux processes without
Docker**, **protobuf**, and replacement of both Photon networking and Photon Chat.
Keep the ASP.NET Core backend separate from the .NET battle Worker; keep database
work outside the battle loop. The implementation uses .NET 10, with portable
.NET Standard 2.0 protocol/client libraries. Redis is optional for later scale,
not a prerequisite for Windows development.

The executable first checkpoint and its limits are described in
[Server/README.md](Server/README.md). The recovered 1.4.0 client communication
audit and migration plan are in
[Server/docs/CLIENT_COMMUNICATION.md](Server/docs/CLIENT_COMMUNICATION.md).
Current hello/ping/pong networking does not mean the old Unity gameplay has
already been converted away from Photon.

The remaining sections preserve the original architectural proposal. PostgreSQL,
EF Core and container deployment recommendations below are superseded by the
owner's overrides above.

---

If both servers are in C#, use an **all-.NET architecture**.

For a WarFriends-style mobile game, this is a strong choice because your Unity client is already C#, your realtime battle is relatively small, and modern .NET networking is fast enough for this workload.

As of September 2026, **.NET 10 is the current active LTS release**, supported until November 2028. ([Microsoft][1])

# Recommended architecture

```text
                   ┌──────────────────────┐
                   │     Unity Client     │
                   │       C# / IL2CPP    │
                   └──────────┬───────────┘
                              │
                  ┌───────────┴───────────┐
                  │                       │
                HTTPS                    UDP
                  │                       │
                  ▼                       ▼
       ┌────────────────────┐   ┌──────────────────────┐
       │   Backend Server   │   │    Battle Server     │
       │ ASP.NET Core/.NET  │   │      .NET 10 C#      │
       │                    │   │                      │
       │ Auth               │   │ Authoritative       │
       │ Profile            │   │ 30 Hz simulation    │
       │ Inventory          │   │ Shooting            │
       │ Shop               │   │ Movement            │
       │ Economy            │   │ Army AI             │
       │ Matchmaking        │   │ Damage              │
       │ Leaderboards       │   │ Cover               │
       └──────────┬─────────┘   │ WarCards            │
                  │             └──────────┬───────────┘
            ┌─────┴──────┐                 │
            ▼            ▼                 │
       PostgreSQL      Redis               │
                                            │
                              BattleResult ──┘
```

The two applications can share common C# libraries but should remain separate processes.

---

# 1. Recommended technology stack

| Component                | Recommended                              |
| ------------------------ | ---------------------------------------- |
| Unity client             | C#                                       |
| Framework                | **.NET 10 LTS**                          |
| Backend                  | **ASP.NET Core**                         |
| Battle server            | **.NET Worker Service / Generic Host**   |
| Realtime network         | **UDP with `System.Net.Sockets.Socket`** |
| Backend network          | HTTPS                                    |
| Internal API             | gRPC or HTTP                             |
| Serialization            | MemoryPack / MessagePack / Protobuf      |
| Database                 | PostgreSQL                               |
| Cache/match queue        | Redis                                    |
| ORM                      | EF Core for normal backend data          |
| High-performance DB path | Dapper/Npgsql where useful               |
| Logging                  | Serilog / OpenTelemetry                  |
| Metrics                  | OpenTelemetry + Prometheus/Grafana       |
| Deployment               | Linux + Docker                           |
| Later scaling            | Kubernetes/Agones if needed              |

Microsoft's current `Socket` API supports asynchronous UDP operations such as `ReceiveFromAsync` and `SendToAsync`; you do not need a separate C++ networking framework to build this. ([Microsoft Learn][2])

---

# 2. Don't run the realtime battle inside ASP.NET controllers

This is important.

Your backend can be:

```text
ASP.NET Core
```

but your Battle Server should not work like:

```text
POST /fire
POST /move
POST /deploy
POST /aim
```

That is not how I would build realtime combat.

Instead:

```text
Backend Server
    ASP.NET Core
    HTTPS
```

and separately:

```text
Battle Server
    .NET Worker Service
    UDP
    Fixed simulation tick
```

Microsoft's Worker Service / `BackgroundService` model is specifically intended for long-running service processes like this. ([Microsoft Learn][3])

---

# 3. Overall solution structure

I would make one Visual Studio solution:

```text
WarFriendsServer.sln
│
├── src/
│
│   ├── War.Shared/
│   │   ├── Protocol/
│   │   ├── Models/
│   │   ├── Constants/
│   │   └── Utilities/
│   │
│   ├── War.Backend/
│   │   ├── Auth/
│   │   ├── Players/
│   │   ├── Inventory/
│   │   ├── Economy/
│   │   ├── Matchmaking/
│   │   ├── Leaderboards/
│   │   └── BattleResults/
│   │
│   ├── War.BattleServer/
│   │   ├── Network/
│   │   ├── Simulation/
│   │   ├── Battle/
│   │   ├── Combat/
│   │   ├── Army/
│   │   └── Sessions/
│   │
│   ├── War.Persistence/
│   │
│   └── War.Infrastructure/
│
└── tests/
    ├── War.Backend.Tests/
    ├── War.Battle.Tests/
    └── War.LoadTests/
```

The big advantage is that all three environments can understand shared protocol structures:

```text
Unity C#
Backend C#
Battle C#
```

That reduces duplication substantially.

---

# 4. Backend Server

Use:

```text
ASP.NET Core
.NET 10
```

for things such as:

```text
Authentication
Account creation
Player profile
Inventory
Weapons
Army collection
Loadouts
Shop
Currency
Upgrades
Daily rewards
Matchmaking
Squads
Leaderboards
Battle history
```

Conceptually:

```text
Unity
  │
  │ HTTPS
  ▼
ASP.NET Core
  │
  ├── Auth
  ├── Player
  ├── Inventory
  ├── Economy
  ├── Matchmaking
  └── BattleResult
       │
       ▼
 PostgreSQL / Redis
```

For ordinary CRUD operations:

```csharp
app.MapGet("/api/player/{id}", ...);

app.MapPost("/api/loadout", ...);

app.MapPost("/api/matchmaking/join", ...);
```

ASP.NET Core is perfect here.

---

# 5. Battle Server

The realtime server should be something like:

```text
War.BattleServer.exe
```

built using:

```text
Microsoft.NET.Sdk.Worker
```

with roughly:

```csharp
public sealed class BattleServerWorker : BackgroundService
{
    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        // Start UDP receiver
        // Start simulation workers
        // Process network packets
    }
}
```

Don't put ASP.NET Core MVC into the core combat loop.

You can expose a small HTTP admin/health endpoint separately if useful.

---

# 6. UDP networking in C#

Use:

```csharp
System.Net.Sockets.Socket
```

rather than relying on Unity's networking for the server.

Conceptually:

```csharp
var socket = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);
```

and async operations:

```csharp
await socket.ReceiveFromAsync(...);

await socket.SendToAsync(...);
```

.NET directly provides asynchronous datagram send/receive APIs. ([Microsoft Learn][4])

For your first implementation, this is plenty.

---

# 7. Do not create a Task for every packet

This matters for performance.

Avoid:

```csharp
while (true)
{
    var packet = await ReceivePacketAsync();

    _ = Task.Run(() =>
        HandlePacket(packet));
}
```

With thousands of packets:

```text
Packet
 → Task
 → allocation
 → scheduler
 → GC
```

you create unnecessary overhead.

A better pattern is:

```text
UDP receive loop
        │
        ▼
Incoming packet queue
        │
        ▼
Simulation worker
        │
        ▼
Battle
```

For example:

```text
Network Thread / Async IO
       │
       ▼
Channel<IncomingPacket>
       │
       ▼
Battle Worker #0
Battle Worker #1
Battle Worker #2
...
```

Use:

```csharp
System.Threading.Channels
```

or a custom bounded queue.

---

# 8. Fixed 30 Hz Battle Simulation

Start with:

```text
30 ticks per second
```

Therefore:

```text
1 tick ≈ 33.333 ms
```

Conceptually:

```csharp
const double TickRate = 30.0;
const double TickTime = 1.0 / TickRate;
```

Server loop:

```text
Tick 1000
 ├── Read commands
 ├── Update players
 ├── Update movement
 ├── Update weapons
 ├── Update units
 ├── Update AI
 ├── Resolve damage
 ├── Check win conditions
 └── Build snapshots

Tick 1001
...
```

Unity can still render:

```text
60 FPS
120 FPS
```

independently.

---

# 9. Don't depend on `Task.Delay(33)` for precise game ticks

This:

```csharp
while (true)
{
    Update();
    await Task.Delay(33);
}
```

is okay for a crude prototype.

But production simulation should measure elapsed time.

Use:

```csharp
Stopwatch.GetTimestamp()
```

and accumulated delta time:

```text
real elapsed time
        │
        ▼
accumulator
        │
while accumulator >= 33.33ms
        │
        ▼
simulate tick
```

Conceptually:

```csharp
while (!token.IsCancellationRequested)
{
    var now = Stopwatch.GetTimestamp();
    var elapsed = GetElapsed(previous, now);
    previous = now;

    accumulator += elapsed;

    while (accumulator >= TickDuration)
    {
        Tick();
        accumulator -= TickDuration;
    }
}
```

That produces a much more stable simulation.

---

# 10. One battle should behave like an actor

For example:

```csharp
public sealed class Battle
{
    public long BattleId { get; }

    public PlayerState PlayerA { get; }
    public PlayerState PlayerB { get; }

    public List<UnitState> Units { get; }

    public void Tick()
    {
    }

    public void HandleCommand(
        PlayerCommand command)
    {
    }
}
```

The key rule is:

> only one simulation worker modifies one battle at a time.

Don't do:

```text
Network Thread
   modifies Player HP

AI Thread
   modifies Player HP

Weapon Thread
   modifies Player HP
```

simultaneously.

Instead:

```text
             Commands
                │
                ▼
         Battle Worker
                │
                ▼
              Battle
           ┌────┼────┐
           │    │    │
         Player AI  Combat
```

This allows most battle code to avoid locks.

---

# 11. Multiple battles per worker

Don't make:

```text
1 thread = 1 match
```

Instead:

```text
CPU Core / Worker 0
 ├─ Battle 1
 ├─ Battle 5
 ├─ Battle 9
 └─ Battle 13

Worker 1
 ├─ Battle 2
 ├─ Battle 6
 ├─ Battle 10
 └─ Battle 14
```

For example:

```csharp
public sealed class BattleWorker
{
    private readonly List<Battle> _battles = new();

    public void Tick()
    {
        foreach (var battle in _battles)
            battle.Tick();
    }
}
```

Real implementation should handle load balancing, queues, shutdown and exceptions, but that's the basic model.

---

# 12. Use all CPU cores

Imagine:

```text
16 CPU cores
```

Don't run every Battle on one thread.

Use multiple simulation workers:

```text
Core 0 → Networking
Core 1 → Worker 0
Core 2 → Worker 1
Core 3 → Worker 2
...
```

Approximately:

```csharp
int workerCount =
    Math.Max(1, Environment.ProcessorCount - 2);
```

But don't assume that exact formula forever.

Benchmark it.

---

# 13. Player movement can be lightweight

A WarFriends server doesn't need Unity physics.

Player:

```csharp
public sealed class PlayerState
{
    public int CoverIndex;

    public MovementState MovementState;

    public float MoveProgress;

    public int Health;

    public WeaponState Primary;
    public WeaponState Special;
    public WeaponState Explosive;
}
```

Possible states:

```csharp
public enum MovementState : byte
{
    InCover,
    LeavingCover,
    Moving,
    EnteringCover
}
```

Then:

```text
Cover 1
   ↓
Move request
   ↓
Server validates
   ↓
Moving
   ↓
MoveProgress 0 → 1
   ↓
Cover 3
```

No expensive CharacterController required.

---

# 14. Server-authoritative shooting

Unity sends:

```csharp
public struct FireCommand
{
    public uint Sequence;
    public uint ClientTick;

    public ushort WeaponId;

    public Vector3 AimOrigin;
    public Vector3 AimDirection;
}
```

But the server decides:

```text
Player alive?
   ↓
Weapon equipped?
   ↓
Ammo > 0?
   ↓
Reloading?
   ↓
Cooldown ready?
   ↓
Aim valid?
   ↓
Hit?
   ↓
Damage?
```

Then:

```csharp
public struct HitEvent
{
    public long ShooterId;
    public long TargetId;

    public ushort WeaponId;

    public int Damage;
    public int RemainingHealth;
}
```

The client displays the effect.

The server owns the result.

---

# 15. Never trust Unity damage

Never accept:

```csharp
DealDamageRequest
{
    Damage = 10000
}
```

Instead Unity says:

```text
Fire
```

Server calculates:

```text
damage = weapon.Damage
       × modifiers
       × critical
       × armor
       ...
```

Same for:

```text
Gold
Ammo
Energy
Unit deployment
Reload
HP
Victory
Rank
Reward
```

All authoritative.

---

# 16. Army AI should also live in C#

Example:

```csharp
public enum UnitAiState : byte
{
    Spawn,
    FindTarget,
    Move,
    Attack,
    Dead
}
```

and:

```csharp
public sealed class UnitState
{
    public int Id;
    public UnitType Type;

    public int Health;

    public float Position;

    public long TargetId;

    public UnitAiState State;
}
```

The server performs:

```text
Find target
     ↓
Move
     ↓
Attack range?
 ┌───┴───┐
 No     Yes
 │        │
Move     Fire
```

Unity simply interpolates the unit's visual position.

---

# 17. Avoid Unity server builds for the core battle simulation

You technically *can* build a Unity headless server.

For your particular WarFriends architecture, however, I'd prefer:

```text
Pure .NET C# BattleServer
```

because the battle logic is relatively simple.

Benefits:

```text
smaller process
less memory
faster startup
no rendering engine
no Unity engine dependencies
easier Docker deployment
easier unit testing
better server-focused profiling
```

Use Unity only for:

```text
rendering
animations
UI
effects
audio
input
```

---

# 18. Share pure game logic where practical

A great advantage of all-C# is shared assemblies.

Example:

```text
War.Shared.Gameplay
```

could contain:

```text
Weapon definitions
Unit IDs
Enums
Protocol definitions
Fixed-point helpers
Damage formulas
Configuration models
```

Then:

```text
Unity
       ↘
         War.Shared
       ↗
BattleServer
```

But don't share server authority logic with the Unity client blindly.

For example:

```text
Shared:
WeaponId
WeaponType
Base stats
```

Good.

```text
Shared:
ServerAntiCheatSecrets
Internal economy validation
Server signing keys
```

Bad.

---

# 19. Consider deterministic math

Since the server is authoritative, full cross-machine determinism isn't always mandatory.

But avoid having important server logic depend excessively on:

```text
Unity physics
client floating-point state
frame rate
```

For important systems such as:

```text
energy
cooldowns
timers
ammo
HP
rank calculation
```

prefer integers:

```csharp
int Health;
int Ammo;
int Energy;

long ServerTick;
```

For example:

```text
ReloadDuration = 60 ticks
```

instead of:

```text
reloadTime = 1.9999987 seconds
```

where practical.

---

# 20. Network packet structure

I would build a compact header:

```csharp
public struct PacketHeader
{
    public ushort ProtocolVersion;

    public PacketType PacketType;

    public uint Sequence;

    public uint Ack;
    public uint AckBits;

    public ulong SessionId;
}
```

Then payload:

```text
Header
+
Payload
```

Typical packets:

```text
ClientHello
ServerHello

PlayerInput
MoveCover
FireWeapon
Reload
DeployUnit

Snapshot
DamageEvent
UnitSpawn
UnitDeath

Ping
Pong

BattleEnded
Disconnect
```

---

# 21. Reliable + unreliable UDP channels

You don't need reliability for everything.

### Unreliable/sequenced

Use for:

```text
Aim
Unit positions
Movement progress
Snapshots
Ping
```

Example:

```text
Snapshot #100
Snapshot #101
Snapshot #102
```

If #101 disappears:

```text
ignore it
```

because #102 is newer.

### Reliable

Use for:

```text
JoinBattle
DeployUnit
WeaponSwitch
UseWarCard
BattleStart
BattleEnd
```

Implement:

```text
sequence
ACK
ACK bits
resend
duplicate prevention
```

---

# 22. Avoid excessive allocations

This is one of the biggest differences between slow and fast C# servers.

Bad:

```csharp
byte[] packet = new byte[1024];
```

for every packet.

Also bad:

```csharp
new Packet();
new List<>();
new UnitSnapshot();
```

thousands of times per second.

Prefer:

```text
ArrayPool<byte>
Memory<byte>
Span<byte>
ReadOnlySpan<byte>
ValueTask
structs where sensible
object pools
```

For example:

```csharp
var buffer = ArrayPool<byte>.Shared.Rent(1500);

try
{
    ...
}
finally
{
    ArrayPool<byte>.Shared.Return(buffer);
}
```

This reduces GC pressure dramatically.

---

# 23. GC matters, but don't fear C#

For this type of server, C# performance problems usually come from architecture such as:

```text
too many allocations
bad locking
Task.Run everywhere
JSON in realtime packets
database calls in game loop
LINQ in hot loops
huge object graphs
```

rather than simply:

```text
"C# has garbage collection."
```

A carefully written C# battle server can perform extremely well.

For a 1v1 WarFriends-type simulation, C# is more than reasonable.

---

# 24. Avoid JSON for realtime gameplay

Do not send:

```json
{
  "messageType":"PlayerPosition",
  "playerId":1001,
  "x":4.115,
  "y":2.332
}
```

30 times per second.

Use binary.

For example:

```text
1 byte    message type
4 bytes   sequence
8 bytes   player id
2 bytes   position
2 bytes   aim
...
```

You might reduce:

```text
100–300 bytes
```

to:

```text
20–50 bytes
```

depending on the message.

JSON is fine for debugging/admin APIs.

Not ideal for realtime combat traffic.

---

# 25. PostgreSQL architecture

Permanent state:

```text
Players
Accounts
Inventory
Weapons
Units
Loadouts
Currencies
Transactions
BattleHistory
Ranks
Squads
```

Use:

```text
ASP.NET Core
        │
        ▼
    EF Core
        │
        ▼
 PostgreSQL
```

You do not need EF Core in the battle loop.

The battle server ideally performs:

```text
0 database queries
```

while the match is active.

---

# 26. Match start flow

```text
Unity A
   │
   ├─ Find Match
   ▼
Backend
   │
   ▼
Matchmaking
   │
   ├──── finds Player B
   │
   ▼
BattleServer Allocator
   │
   ▼
Create Battle #9301
   │
   ├── loadout A
   └── loadout B
   │
   ▼
Return connection data
```

Unity receives:

```json
{
    "battleId": 9301,
    "host": "eu-1.example.com",
    "port": 30000,
    "token": "..."
}
```

Then:

```text
Player A ─ UDP ─┐
                ▼
          BattleServer
                ▲
Player B ─ UDP ─┘
```

---

# 27. Authentication between backend and battle server

Backend generates a short-lived battle token.

Example data:

```text
PlayerId
BattleId
ServerId
Expiry
Nonce
Signature
```

When Unity connects:

```text
ClientHello
{
    BattleId
    PlayerId
    Token
}
```

BattleServer verifies:

```text
Signature valid?
Battle valid?
Player belongs to battle?
Token expired?
Token already used?
```

Then creates the UDP session.

---

# 28. Redis role

Use Redis for things such as:

```text
matchmaking queues
online presence
temporary sessions
rate limiting
cached leaderboard data
server registration
battle allocation
```

For example:

```text
matchmaking:eu:rank:10
```

may contain waiting players.

Permanent economy state should remain in PostgreSQL.

---

# 29. Matchmaking structure

```csharp
public sealed record MatchmakingTicket
{
    public required long PlayerId { get; init; }

    public required string Region { get; init; }

    public int Mmr { get; init; }

    public int Power { get; init; }

    public int Ping { get; init; }

    public DateTimeOffset CreatedAt { get; init; }
}
```

Search based on:

```text
Region
    +
Ping
    +
MMR
    +
Equipment Power
    +
Queue waiting time
```

As the player waits:

```text
acceptable MMR range ↑
acceptable power range ↑
```

gradually.

---

# 30. Battle result flow

Battle server should not directly modify player currency.

Instead:

```text
BattleServer
      │
      ▼
BattleResult
{
    BattleId
    Winner
    Loser
    Stats
    Duration
}
      │
      ▼
Backend
      │
      ├── validate
      ├── idempotency check
      ├── calculate rewards
      ├── update rank
      └── update database
```

This is safer.

For example, if the same result arrives twice:

```text
BattleId = 9301
```

backend checks:

```text
Already processed?
```

and refuses to reward twice.

---

# 31. Recommended first server architecture

Don't build 20 microservices.

Start with:

```text
┌───────────────────────────────┐
│      War.Backend             │
│      ASP.NET Core            │
│                              │
│ Auth                         │
│ Player                       │
│ Inventory                    │
│ Economy                      │
│ Matchmaking                  │
│ Battle Results               │
└───────────────┬───────────────┘
                │
          PostgreSQL
             Redis


┌───────────────────────────────┐
│      War.BattleServer        │
│                              │
│ UDP                          │
│ Sessions                     │
│ Battles                      │
│ Combat                       │
│ AI                           │
│ Tick system                  │
└───────────────────────────────┘
```

Two executable services.

That's enough.

---

# 32. Do not start with microservices

Don't start with:

```text
AuthService
PlayerService
WeaponService
UnitService
InventoryService
EconomyService
LeaderboardService
SquadService
ShopService
RewardService
MatchmakingService
```

as independent deployments.

For a new game, that's likely unnecessary operational complexity.

Start:

```text
War.Backend
```

as a **modular monolith**.

Later, if matchmaking becomes extremely busy:

```text
War.Backend
   ↓
extract
   ↓
War.Matchmaker
```

If chat becomes huge:

```text
extract ChatService
```

Scale only where necessary.

---

# 33. Deployment

For development:

```text
Your PC

Backend
BattleServer
PostgreSQL
Redis
```

Then Docker:

```text
docker-compose

backend
battle-server
postgres
redis
```

For alpha:

```text
Linux VM #1
    Backend

Linux VM #2
    PostgreSQL

Linux VM #3
    Redis

Linux VM #4
    Battle servers
```

For larger scale:

```text
                       Global
                         │
            ┌────────────┼─────────────┐
            ▼            ▼             ▼
           EU           US            Asia
            │            │             │
      Battle Servers Battle Servers Battle Servers
```

Regional deployment will usually matter more for player experience than changing from C# to C++.

---

# 34. Recommended network rates

Start around:

```text
Battle tick        30 Hz

Snapshots          15 Hz

Aim/input          20–30 Hz

Player rendering   60/120 FPS

Ping               every 1 sec
```

Don't blindly send the complete battle state 30 times per second.

Use:

```text
delta snapshots
event messages
quantization
```

later.

---

# 35. Example BattleServer object model

```text
BattleServer
│
├── UdpTransport
│
├── SessionManager
│
├── BattleManager
│
├── SimulationWorkers
│
└── Metrics
     │
     ▼
BattleManager
│
├── Battle #100
├── Battle #101
├── Battle #102
└── ...
```

Each Battle:

```text
Battle
│
├── Players[2]
│
├── Covers[]
│
├── Units[]
│
├── Projectiles[]
│
├── Timers
│
├── Energy
│
└── BattleRules
```

---

# 36. Classes I would create first

```text
BattleServer
UdpTransport
ClientSession
SessionManager

Battle
BattleManager
BattleWorker

PlayerState
PlayerCommand

WeaponState
WeaponDefinition
WeaponSystem

DamageSystem

CoverState
CoverSystem

UnitState
UnitDefinition
UnitSystem
UnitAiSystem

SnapshotBuilder
PacketCodec

ReliableChannel
SequenceWindow
```

That's enough for the first multiplayer prototype.

---

# 37. Recommended development order

### Phase 1 — networking

Build:

```text
Unity
   ↓ UDP
C# BattleServer
```

Support:

```text
Hello
Ping
Pong
Disconnect
```

---

### Phase 2 — battle

Add:

```text
2 players
battle room
server ticks
battle timer
```

---

### Phase 3 — cover movement

```text
MoveCoverCommand

Cover 0
Cover 1
Cover 2
Cover 3
```

Server validates all movement.

---

### Phase 4 — shooting

Implement:

```text
Fire
Ammo
Reload
Hit
Damage
HP
Death
```

---

### Phase 5 — synchronization

Implement:

```text
Snapshot
Interpolation
Sequence numbers
Loss handling
```

---

### Phase 6 — AI

Only one unit initially:

```text
Infantry
```

Then:

```text
Sniper
Heavy
Rusher
Explosive
```

---

### Phase 7 — Backend

Now add:

```text
ASP.NET Core
Login
Profile
Inventory
Loadout
```

---

### Phase 8 — Database

Add:

```text
PostgreSQL
EF Core
```

---

### Phase 9 — matchmaking

```text
Redis
+
Matchmaker
+
BattleServer allocator
```

---

### Phase 10 — production features

Then:

```text
Monitoring
Metrics
Load testing
Anti-cheat
Rate limiting
Reconnect
Crash recovery
Deployment automation
```

---

# 38. Your final recommended technology stack

For your project, I would choose:

```text
                 CLIENT
──────────────────────────────────
Unity
C#
IL2CPP
UDP gameplay client
HTTPS backend client


                 BACKEND
──────────────────────────────────
.NET 10 LTS
ASP.NET Core
EF Core / Npgsql
PostgreSQL
Redis


              BATTLE SERVER
──────────────────────────────────
.NET 10 LTS
C#
Worker Service
System.Net.Sockets.Socket
UDP
30 Hz authoritative simulation
MemoryPool / ArrayPool
Span<T>
Channels
Binary protocol


                HOSTING
──────────────────────────────────
Linux
Docker
Regional servers
```

And the overall architecture becomes:

```text
                   ┌─────────────────┐
                   │  Unity Mobile   │
                   │      C#         │
                   └────────┬────────┘
                            │
               ┌────────────┴────────────┐
               │                         │
             HTTPS                      UDP
               │                         │
               ▼                         ▼
       ┌────────────────┐       ┌─────────────────┐
       │ ASP.NET Core   │       │ C# BattleServer│
       │ .NET 10        │       │ .NET 10        │
       │                │       │                │
       │ Login          │       │ 30 Hz          │
       │ Profile        │       │ Movement       │
       │ Inventory      │       │ Shooting       │
       │ Economy        │       │ AI             │
       │ Matchmaking    │       │ Damage         │
       └───────┬────────┘       └────────┬────────┘
               │                         │
        ┌──────┴──────┐                  │
        ▼             ▼                  │
  PostgreSQL        Redis                │
        ▲                                │
        └──────── Battle Result ─────────┘
```

## C# vs C++ for your WarFriends server

For this particular game I would now recommend you **stay completely with C#**.

You gain:

```text
Unity C#
+
Backend C#
+
BattleServer C#
+
Shared libraries
+
one engineering language
+
faster development
+
easier debugging
+
easier hiring/maintenance
```

while giving up relatively little in practical performance for a **2-player, cover-based shooter with lightweight AI**.

The places where we need to be disciplined are not the language itself; they are **allocation rate, GC pressure, locking, packet design, fixed-tick simulation, database separation and network architecture**.

If those are designed correctly, **C#/.NET is fully suitable for the complete WarFriends-style backend and realtime game server**.

[1]: https://dotnet.microsoft.com/en-us/platform/support/policy?utm_source=chatgpt.com "The official .NET support policy | .NET"
[2]: https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.sockettaskextensions.sendtoasync?view=net-10.0&utm_source=chatgpt.com "SocketTaskExtensions.SendToAsync Method (System.Net.Sockets) | Microsoft Learn"
[3]: https://learn.microsoft.com/ka-ge/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-10.0&utm_source=chatgpt.com "Background tasks with hosted services in ASP.NET Core | Microsoft Learn"
[4]: https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.socket.sendasync?view=net-10.0&utm_source=chatgpt.com "Socket.SendAsync Method (System.Net.Sockets) | Microsoft Learn"
