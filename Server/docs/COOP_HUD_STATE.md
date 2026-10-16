# Host-owned co-op mission HUD

The recovered mission manager receives progress, remaining time and an integer
objective through Photon serialization. Its public HUD properties otherwise
read the local mission simulation. Once that simulation is disabled for host
authority, neither path supplies a reliable self-hosted view.

`SelfHostedCoopHudState` now reads the confirmed source snapshot using the
existing outcome/lifecycle validator. Remaining time is
`(deadlineTick - serverTick) / 30`; duration uses `deadlineTick - startTick`.
This clock does not advance on local wall time, so a stopped host tick cannot
silently exhaust a locally running countdown.

| Source mission | HUD objective argument | Progress |
| --- | --- | --- |
| KillXEnemies | Host enemy kill count | Kills divided by source target, matching the unclamped Client ratio. |
| Score | Conserved two-player objective score | Shared score divided by source target, capped at one. |
| SurviveXSeconds | Original base argument zero | Elapsed host time divided by duration. |
| KillOpponent | Original base argument zero | Original inherited zero progress; source text identifies the boss. |

Started source lifecycle, nonnegative counters/index and positive Kill/Score
targets are required. Score uses the existing complete contribution validator.
The source manager additionally binds the view to the selected mission index,
type, duration and Kill/Score target before replacing its current HUD view.
A wrong mission cannot partially replace the displayed time or progress.

The co-op controller binds the mission manager before configuring its terminal
bridge. The adapter publishes subsequent mission views before room lifecycle
and snapshot callbacks. Scene binding clears the previous view and replays the
current snapshot. Before start, the manager shows zero progress and the source
full duration. After connection close it retains the last confirmed view while
the mission authority latch remains active. The retired Photon serializer
cannot overwrite that host-owned view. Solo/legacy HUD reads keep their branch.

Eight protocol checks compile the exact Unity helper source and cover host
time, all four mission mappings and invalid counters/targets/index. Four new
native component checks exercise the actual manager and adapter: host reads
without a PhotonView, foreign-mission rejection without partial publication,
publication before snapshot callbacks, and replay on rebind. The existing
sixteen lifecycle checks remain in the same audit executable.

This supplies read-only mission presentation state. It does not run local
objective completion, alter stars, grant rewards or open Worker co-op admission.
Rendered localized text, mission HUD animation, normal two-Client gameplay,
full combat attribution and durable settlement remain open requirements.

Windows verification passes 1,090 protocol checks and all 20 checks in the
disposable Unity 2018.3.0f2 mission component audit. The native process completed
shutdown, and active source hashes match its tested copies. Static audits keep
zero missing scripts/broken references and the existing seventeen unmatched
NGUI selections. No new live UDP, Linux or Android run is claimed; the server
runtime and installed portable DLLs are unchanged by this connection.
