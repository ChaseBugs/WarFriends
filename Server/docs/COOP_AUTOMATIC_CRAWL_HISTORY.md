# Automatic crawl-return history

The earlier 221-entry catalog primed each crawl phase by setting its clock and
sampling once before the recovered `ShootFromCrawl` notification. This control
checks whether naturally evaluating the preceding return produces the same pose.

## Source experiment

`UnityAutomaticCrawlHistoryExport` runs 17 script-free body/rifle actors in an
empty Unity 2018.3 Play Mode scene at 30 frames per second. Each actor first plays
the source rifle clip automatically for 30 frames, reaching its clamped end.
It then performs the recovered return operation, ordinary
`Animation.Play("stand_up_crawl")`, without setting crawl time or calling
`Animation.Sample`. Actors receive the original `ShootFromCrawl` notification
after zero through sixteen automatic return frames. Each records 13 observations.

The original controller's full Update and enemy AI are not invoked. The return
operation is reproduced from its recovered branch; the notification uses the
original controller method through the existing inactive probe. This isolates
one uninterrupted fire-to-return history, not every gameplay scheduling order.

The archive `content/coop-automatic-crawl-history-reference.json.gz` has SHA-256
`f1486690b3f588a8fa4d574f82498978dea44a9a60e60413726f497ee256478e`.
It includes all 17 origins and 221 observations, source asset/helper hashes and
clip hashes checked before and after capture. It is provenance, not a replacement
runtime catalog or an APK recovery artifact.

## Result and counterexample

Run `python Server/tools/verify_coop_automatic_crawl_history.py` from the repository.
It verifies bindings to the earlier independent source/replay evidence and
compares non-root local transforms at the existing tolerances: position 1e-5,
quaternion-dot error 1e-6 and per-axis relative scale 1e-5.

220 observations match. The maximum matched errors are approximately 1.63e-8
position, 8e-15 rotation and 1.53e-7 relative scale. All observations for return
phases 1 through 16 match; phase zero also matches after its first observation.

Phase zero, observation zero is a material counterexample: the new crawl state
exists but has not evaluated, so the hierarchy still contains the prior fire
pose. Maximum differences are 0.03363 local position units, 0.07662 quaternion-dot
error and 0.0003511 relative scale; 20 transform rotations exceed the limit.
The current position/scale-only correction scheme must not pretend that this
first pose is an ordinary nominal crawl sample. The verifier preserves this
failure instead of replacing automatic observations with manual sampling.

## Server boundary

The host now publishes preparation references for known prior-return phases
1 through 16 under the existing alive, stationary and settled-root guards.
The new evidence permits visual projection while `HasInterruptedReturn` still
blocks fresh-clock collision and muzzle diagnostics. A new emitted round closes
this observed preparation path. Unknown history, phase zero and a later repeated
interruption remain closed; those require additional source-backed handling.

Runtime tests cover phases 1, 3, 15 and 16, source-reply isolation and frozen
delivery, while checking that partial-history hitbox diagnostics remain absent.
Real SDK UDP tests cover phases 3 and 16 with negotiated and clip-only peers and
frozen chunk reassembly. No combat, score or reward authority comes from these
visual references. This does not close normal Worker/Unity gameplay or B32.
