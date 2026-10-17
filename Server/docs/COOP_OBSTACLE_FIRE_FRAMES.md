# Confirmed obstacle fire frames

The host now projects `rifle_shot_loop` from actual emitted-round history for
stationary Assaulter obstacle volleys. Each confirmed round resets displayed
time to zero; later samples use the latest round epoch at the fixed host rate.
The existing protobuf frame, SDK validation and script-free sampler are reused.

The recovered `ShootFromCrawl` method retains an already playing preparation,
restarts enabled fire, or reverses crawl progress before queuing fire. The
separate source notification audit verifies these branches and compares both
queued and ordinary zero-time fire against the production sampler. It passes
254 checks including the retained corner cases. That audit does not prove
normal source callback scheduling.

This increment only connects the confirmed fire window. No frame is invented
for a callback without an emitted round. Walking/repositioning, navigation
rotation conflicts, interrupted crawl, the return timer boundary, the next
attempt boundary, death and non-running matches remain excluded. Preparation,
return blending and later interrupted attempts need their own host timeline;
this is not complete obstacle presentation or an admission gate removal.

The visual is evaluated after notification. Gameplay muzzle geometry still
uses its earlier source observation. Collider placement, player damage,
outcomes, economy and public co-op admission are unchanged.

## Verification

Live runtime regression checks the absent pre-round frame, exact first-round
zero-time tuple and the second-round reset. The combat executable passes
26,368 assertions. The native Unity 2018 adapter audit passes nineteen checks,
including protobuf decoding of the obstacle fire frame, actor reuse and a
changed bone pose. These are isolated Windows checks, not rendered gameplay,
two normal Unity clients, Android/Linux execution or shipped Unity 5.2 parity.

Native MongoDB/HTTP/protobuf/UDP smoke also passes 1,136 protocol checks,
74 live integration checks and restart recovery. That smoke does not exercise
public co-op combat admission or normal Unity gameplay.
