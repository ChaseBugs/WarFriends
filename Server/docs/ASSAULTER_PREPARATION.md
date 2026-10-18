# Automatic normal Assaulter Corner attempts

The normal host tick now consumes each source Corner's first-shot deadline. It selects the
current opponent/transform and captures moving-player prediction automatically. A packet cannot
choose the actor's target, batch, real-shot flags or callback deadline.

## Recovered order

EnemyController.CornerHidingUpdate tests its shot branch first, with the strict mTime > deadline
comparison. Its PrepareToShoot call has no visibility or maximum-distance test for a Corner.
After PickTarget, StartShooting draws a batch with an exclusive integer upper bound, clamps it
to fourteen rounds and draws each real/fake flag. Only then does the Corner side/angle gate run.
An invalid side therefore still consumes the source batch and round draws.

Successful preparation calls Shoot, which generates the next source shot time and schedules
the callback after uncoverLength + 0.05 seconds. uncoverLength always reads player_look_right3,
including left-side shots. A rejected Corner side generates its next shot time through the
CornerHidingUpdate failure branch instead. It does not retry on every following frame.

AssaulterShotBatchPolicy accepts the validated composed upgrade range through 64, performs the
source exclusive draw and clamps the chosen count to fourteen. A composed real-shot probability
above one legitimately makes every roll real; it is not silently clamped into a different rule.
Invalid ranges or rolls fail before an attempt record is published.

## Host state

AssaulterCornerAttempt retains the actual acquisition tick, immutable target/prediction, complete
batch mask, next eligible shot tick and optional callback tick. A rejected side has no callback
and may retry only at its next eligible tick. A successful attempt keeps its source latch and
blocks replacement until the future callback/volley completion path consumes it. Death removes
the record alongside the actor's navigation and mutable aim state.

Unavailable target geometry does not become a source rejection, a substituted player or an
invented cooldown. It remains unresolved authority. Point-change execution is still separate.

## Verification and remaining boundary

--assaulter-preparation-only passes 24 checks. A fixed Park deployment uses the actual source
arrival and host timer; no explicit CaptureAssaulterAim call creates the tested attempt. It has
no attempt before its first deadline and automatically prepares a player target at tick 199.
It retains the source batch, callback deadline and latch while that player subsequently moves.

A second fixed scenario deploys an opposing ordinary soldier immediately before the deadline.
The source unit-priority branch selects that newly spawned soldier behind the Corner's exposed
side. The automatic attempt records a complete batch but no callback, waits through the source
cooldown and retries at the exact next eligible tick. Both scenarios verify death cleanup.
Policy cases independently verify exclusive count selection, batch-before-round ordering, strict
probability comparison, fourteen-round clamping and malformed authority rejection.

Release build has zero warnings/errors and combat regression passes 26,395 assertions after the
automatic preparation integration. The new checks are registered in the default suite; that
complete suite was not rerun.

This schedules a callback; it does not execute it. Source shot-root turning and look/fire/hide
animation, native queued callback muzzle sampling, shot-start prediction/current non-player
velocity, real/cosmetic launch, volley completion/cooldown, point changes, damage, UDP and normal
Unity gameplay remain required. A successful attempt deliberately remains pending at this
checkpoint. Neither callback metadata nor a pre-rolled real flag is evidence of a fired bullet.
