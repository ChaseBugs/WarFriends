# Live UDP bazooka effects in Play Mode

The same production Worker, installed SDK, Unity adapter and normal DeathMatch
bridge now pass one combined native Play Mode scenario. Automatic adapter
`Update` drives state and reliable-event polling; the harness does not call
`Refresh` or `DispatchEvents` in Play Mode. This extends the
[Editor UDP checkpoint](PLAYER_BAZOOKA_LIVE_UDP.md) and
[source effect checkpoint](PLAYER_BAZOOKA_EFFECTS.md).

## Executable scenario

The existing trusted local fixture still supplies two independent signed grants,
the recovered City collision map, source level-zero M202/RPG data and a bounded
unscored high-health match. No host authority rule or content value changes.

1. The SDK peer readies first. Unity observes its state through automatic polling
   and sends its own Ready; the Worker enters Running.
2. Unity sends a typed M202 hold. Four source missiles, including two harmless
   missiles, reach the normal presenter through multiple moving snapshots.
3. After all sub-shots launch, Unity switches to RPG. Existing M202 models keep
   their Small appearance; the other authenticated peer launches its RPG.
4. Before the bridge processes the first real host impact, the fixture makes
   the actual particle pool unavailable. The original sound call succeeds, the
   source particle call throws, and the adapter reports the error without
   advancing its processed-event cursor.
5. The fixture verifies the pending cursor, one sound and no particle, then
   restores that same pool. Automatic polling delivers the identical event
   again. Production presentation resumes the missing particle step without
   repeating the sound.
6. All five impacts select their real recovered Medium/Small clips, source 3D
   audio settings and source particles at the confirmed host positions. Their
   ParticleSystems emit over automatic Unity frames. Reliable impact bytes
   match the independently authenticated SDK peer's history.

The first successful run observed impact event 6 while the acknowledged cursor
remained 5 during the injected failure. Replacing only the disposable presenter's
code with commit `ecd803849` reproduces the regression: the retry skips the
particle, and the combined audit fails while inspecting the missing source
spawn. Restoring the production fix passes. The active recovered project is
never reverted during this regression comparison.

## Source scene and test boundaries

`UnityLiveBazookaPlayScene` retains the original MainScene object graph below an
inactive parent before moving it into the isolated scene. Level behaviour and
pool references target scene objects, so copying only their manager components
would lose real source dependencies when the original scene closes. The first
fixture attempt failed with a missing Rocket soldier and was corrected by
preserving those references, without relaxing the production presenter.

Original boot, touch input and legacy simulation remain inactive. The two copied
player rigs supply recovered binding and weapon data, also while inactive.
Source sound, hit-particle and pool services are active, as are the production
adapter, bridge and projectile presenter. The harness issues typed commands;
it does not claim normal touch input, camera/UI startup or rendered player rigs.
Unexpected runtime Unity errors and later adapter errors fail the audit.

This is one Unity process plus one SDK participant, not two running Unity clients.
It proves automatic Play Mode network/effect scheduling and callback recovery,
not rendered pixels, audible hardware output, full scene boot, Backend allocation
or economy settlement. Android, Linux Unity gameplay and Unity 5.2 remain open.
B32 and the complete BattleServer objective remain partial.

The final solution build passes with zero warnings and errors. The combined
Play Mode run, original Editor UDP control, isolated source-effect Play Mode
control and 1,144 protocol checks pass. Source audio and derived missile digest
verification also pass. The final trusted run removes its temporary grant file.

## Running

Use a disposable Unity 2018.3 project with the current Client integration, SDK,
source-derived missile visual and restored explosion WAV headers. Copy these
tools into its `Assets/Editor` directory:

- `UnityLiveBazookaAudit.cs`
- `UnityLiveBazookaObservation.cs`
- `UnityLiveBazookaRigs.cs`
- `UnityLiveBazookaPlayAudit.cs`
- `UnityLiveBazookaPlayScene.cs`
- `UnityLiveBazookaEffectObservation.cs`
- `UnityBazookaEffectFixture.cs`

From the repository root:

```powershell
dotnet run --project Server/tests/War.Battle.Tests --no-build -- `
  --unity-bazooka-play-only <UnityExecutable> <DisposableProject>
```

The parent Worker fixture owns temporary grants, the Unity process and bounded
timeouts. It removes grants in `finally` and retains logs and a non-secret match
manifest under `Server/.local/bazooka-live-*`. Success requires native exit zero
and `UNITY_LIVE_BAZOOKA_PLAY_PASSED`. The original `--unity-bazooka-only` command
remains the separate Editor control; it explicitly polls because Editor mode
does not execute the adapter's normal `Update`.

The [subsequent matchmaking checkpoint](CLIENT_MATCHMAKING_CANCELLATION.md)
adds `--unity-bazooka-matchmaking-only`. It enters through actual authenticated
HTTP queue/grant requests to a test-only allocator facade, then the real Worker;
the existing direct-grant Editor/Play Mode controls remain separate.

The scoped queue checkpoint also reruns the matchmaking Play Mode scenario with
normal `SelfHostedMatchmakingAttempt` credential issuance and scoped search.
The test facade now requires one authenticated protobuf issuance and the same
credential in its queue requests. Real Worker/UDP and automatic presentation
still pass; this remains a preallocated facade rather than normal Mongo-backed
login/UI or two actual Unity clients. See `QUEUE_ATTEMPT_FENCING.md`.
