# Client mission lifecycle authority

## Source behavior and the migration gap

The four recovered mission types can finish through different local callbacks:
KillMission checks local kill totals, SurviveMission checks local time,
ScoreMission checks the combined local/Photon score, and BotMission checks its
local boss-death flag. Their EndMission overrides can invoke MissionSuccess
before the base EndMission is reached. Guarding only the base method therefore
does not protect stars, completion flags or outcome selection.

`GameController.isCoop` explicitly excludes BotMission, which is exposed as
`isCoopBot`. It cannot by itself identify all host-owned co-op missions.

## Shared authority selection

`Mission.HasSelfHostedCoopAuthority` detects an owned self-hosted adapter with a
co-op snapshot. It does not contact Photon or depend on the source screen-mode
split. The selection latches on that mission until the next explicit
PlayMission selects its transport again. Disconnect alone cannot reopen local
completion or reward authority.

For that selection, PlayMission does not run the legacy local attempt update,
initial spawn or mission-definition callbacks. Horde and Boss overrides also
stop before wave assignment or local bot initialization. Startup callbacks do
not enable local mission simulation, configure source shields or enable the
Boss AI. Normal mission updates, each derived EndMission, base success/failure
and the retained peer completion callback defer to host authority. Local Boss
death cannot set the source kill flag, infer hit attribution or choose success.

The controller and mission manager's local death callbacks use the same
selection, including Boss missions and the disconnected interval. Confirmed
KIA and terminal outcomes continue through their existing self-hosted bridges.
No source GUI identities, serialized references, mission definitions or reward
rules change. Unbound/solo missions retain the recovered branch; full solo
gameplay is not newly verified by this change.

These are migration guards, not a replacement for missing presentation. Normal
Worker co-op admission is still closed. The authoritative enemy/boss/shield
presenters, mission clock/HUD updates, complete combat and durable settlement
must be connected before normal gameplay can be opened. The guards do not
silently fall back to local simulation to make an incomplete connection play.

## Verification boundary

`UnityCoopMissionAuthorityAudit` uses actual Kill, Survive, Score and Boss
components with an owned portable connection in an inactive disposable Editor
object. It invokes real lifecycle, success/failure, completion and Boss-death
methods without supplying gameplay services. An accidental fallthrough into
the source calculation/spawn/progression paths therefore fails the audit.
It also closes the connection, verifies the existing authority selections
remain latched, and verifies an explicit new base PlayMission releases the
selection while a new unbound mission remains unclaimed.

This is an Editor-mode authority/component check, not rendered UI, two-Client
play, a server damage test or full solo regression proof. No new reward gate
opens and no new Linux/Android proof is claimed.

Windows validation: the final disposable Unity 2018.3.0f2 process passed all
16 checks and shut down. The active scripts match the audited copies by SHA-256.
The protocol executable still passes 1,082 checks. Static audits retain 1,052
script targets and 288,080 serialized references with zero missing scripts or
broken references; seventeen known NGUI selections remain unchanged. Server
runtime code and installed SDK binaries are unchanged in this checkpoint, so
the preceding 74-check native smoke is historical evidence, not a new run.
