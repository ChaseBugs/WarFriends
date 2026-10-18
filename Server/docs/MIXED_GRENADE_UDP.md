# Mixed starter grenade two-peer UDP checkpoint

The native starter FRAG command path now has a real UDP verification gate using
two signed portable SDK connections and an isolated in-process NetworkWorker.
The Worker loads the same pinned mixed package, including grenades, as the source
starter manifest. This is SDK transport proof, not a rendered Unity match.

MixedBattleUdpFixture starts only its own loopback Worker, issues grants only for
the manifest's participants and stops that Worker through async disposal.
Its generated manifest and outbox/journal stay in a unique Server/.local run
directory. It does not change process environment, stop an existing service or
write credentials into the committed repository.

## Verified path

Both peers authenticate and submit the four source-bound army upgrade lanes
before readiness. An authenticated claim for a higher, unowned normal stage is
rejected without consuming selection; the correct subsequent selection succeeds.
The owner selects FRAG and the other peer observes its active slot and grenade
idle pose. A typed swipe releases one host projectile and decrements grenade
ammo once. The owner returns to rifle while that grenade remains in flight.

After impact, both peers agree on settled active slot, ammunition and shot count,
with the same signed match identity. Snapshot clocks are intentionally not
compared for equality because the two clients poll different host ticks.
Both peers then drain the reliable event history and receive the same ordered
grenade Shot and Impact bound to one projectile ID.

Run the focused gate with:

```powershell
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll `
  --mixed-grenade-udp-only
```

It is also included in the default native suite. At this checkpoint the focused
gate passes 12 checks and the Release solution builds with zero warnings/errors.
The verified run is Server/.local/mixed-grenade-udp-f73bfc1814a4467ba961037d8df78c9e.
The runtime is unchanged from the preceding 205,658-check full native run;
that historical count does not include this newly added UDP gate.

## Remaining boundaries

The fixture authors its trusted allocation from the reviewed starter lanes and
uses an explicitly empty ordinary/Buddy card inventory. It does not implement
normal Mongo-backed automatic allocation or prove the Client's initial card
hand. Grants here omit the normal Backend presentation publication, so this
does not substitute for the full account-to-lobby-to-battle path.

Normal Unity/Android rendering, all other mixed weapon transitions and effects,
packet-loss/reconnect variants,
durable card consumption, allocation and production settlement remain open.
The later [rig observation](GRENADE_RIG_OBSERVATION.md) and
[delayed rifle host scenarios](MIXED_GRENADE_LONGSHOT.md) cover the previously
missing weapon-root/moving-target data and native kill path. Those checks do not
expand this UDP fixture into full Unity gameplay or production settlement proof.
