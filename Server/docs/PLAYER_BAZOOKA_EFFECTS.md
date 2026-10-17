# Player bazooka explosion effects

The production projectile presenter now resumes interrupted explosion callbacks
without repeating a successfully returned sound or particle dispatch. This
checkpoint extends [source presentation](PLAYER_BAZOOKA_PRESENTATION.md) and
[impact lifetimes](PLAYER_BAZOOKA_LIFETIME.md); it does not complete B32.

## Recovered behavior and failure

`Explosion.PlayEffects` selects Medium for ordinary player missiles and Small
for M202. Both use particle index 3, offset 0.2 units upward. The sound call
precedes the particle call. `Explosion.MissileExplode` dispatches these effects
before its harmless-missile early return, so fake M202 missiles also need Small
effects. Damage and overlap queries remain outside the replacement effect path.

Previously, the presenter marked an impact complete before calling effects. If
the sound returned but the particle service threw, callback replay considered
the impact finished and permanently skipped the missing particles. An isolated
native Play Mode run reproduced this failure with the previous presenter.

`SelfHostedBazookaImpactEffects` keeps separate successful sound and particle
steps for each projectile. It clones and compares the complete authoritative
impact record, rejects altered replays, and bounds retained records at 512.
Same-match reconnect preserves progress; a new match scope clears it. The
presenter still retires the flight and preserves its source smoke-tail timer.
This tracks completed source calls, not arbitrary internal engine side effects
from a call that mutates state and then throws.

## Source audio container restoration

Native testing found that the two recovered WAV files had zero RIFF and data
length fields despite containing PCM samples. Unity returned null clips.
`tools/repair_bazooka_audio_headers.py` restores only the two 32-bit lengths:
RIFF size becomes file length minus 8, and data size becomes file length minus
46. The pinned layout is mono 16-bit PCM with an 18-byte format chunk. No sample
byte, file length, resource path, metadata file or GUID changes.

| Clip | Extracted SHA-256 | Restored SHA-256 |
| --- | --- | --- |
| `EXPLOSION_MEDIUM` | `9f4607932f030fc81a5e0b614cd4b9775f426283ca15ddc3692b0a6fee423087` | `6c681a63a91463134b8e5f36ddf99127b22e06c7b325e1b0223cb97483198a4e` |
| `EXPLOSION_SMALL` | `89b4964e4ce1829dce88f29954b0b54d34afe8d0294af9aaf98bba53734a5b55` | `fec89921d42e7cd3941c759455348ab7b5be9d720d3dad0752e8bb3de80b7958` |

Run `python Server/tools/repair_bazooka_audio_headers.py --verify` from the
repository root. Verification reconstructs the zero-length header and requires
the exact extracted digest, then compares the complete restored file. This is
a two-clip repair, not an audit or repair of every recovered sound.

## Native verification boundary

`UnityBazookaEffectsPlayAudit.Run` uses `UnityBazookaEffectFixture` to isolate
the original MainScene sound entries, AudioSource settings, particle prefab
lists, actual source services and real SpawnPools. It avoids original boot,
music, storage and retired online services. The volume/quality providers stay
inactive; the sound, hit-particle and pool services execute their source Awakes.

The Unity 2018.3 Play Mode run passes:

- Sound completes before an injected unavailable particle pool; callback replay
  creates the particle without dispatching sound twice.
- Medium, M202 Small and harmless M202 Small dispatch actual recovered clips
  with source position, spatial blend and volume, plus source particle index 3.
- Completed duplicates, initial scope adoption and same-match reconnect do not
  repeat effects; changed impact bytes are rejected.
- A new match can reuse a projectile counter and dispatch once through the
  original AudioSource ring.
- Original ParticleSystems emit CPU particles over automatic Unity frames.

Regression checks also pass: 1,144 protocol checks, 218 focused bazooka checks,
37 native controlled lifetime checks, all seven native player missile families
plus the M202 fake, and the actual Worker/SDK/Unity Editor UDP checkpoint.
Static asset checks still report zero missing scripts or broken references;
the existing 17 NGUI sprite mismatches are unchanged. The source-derived
missile prefab verifier and both restored audio digest checks pass.

The run is isolated Play Mode, without rendered pixels or audible-output proof.
It is separate from the [actual UDP Editor checkpoint](PLAYER_BAZOOKA_LIVE_UDP.md).
The [subsequent live Play Mode checkpoint](PLAYER_BAZOOKA_LIVE_PLAY_MODE.md)
combines actual UDP and automatic adapter polling with these source effects,
including callback failure/retry. Its original player rigs and boot/input stay
inactive. Two Unity clients, Android, Unity 5.2, Linux gameplay and rendered
normal boot remain unverified. No full-game completion claim follows.
