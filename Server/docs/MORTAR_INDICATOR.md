# Mortar target warning

The recovered `Mortar.StartIndicatorAnimation` is the behavioral source. The warning must be
visible only for an opposing fraction and must use the final shot target, including the fake
shot's displacement, plus `Vector3.up * 0.04`. It is presentation, never damage authority.

## Native observation and portable sampling

`tools/UnityMortarIndicatorAudit.cs` runs in the disposable project. It invokes the original
private setup method on an isolated weapon shell with a copied source indicator, then calls
the original tween sampling, completion and repetition methods. Inactive player shells provide
the local fraction without starting gameplay or provider services. The nonmatching branch uses
an ownerless weapon's `None` fraction against local `Allies`; it does not prove admitted enemy
ownership. The observation is Editor
method execution, not a Play Mode update/callback scheduling or normal battle proof.

Unity 2018.3.0f2 passed eleven checks: activation/world parenting, target preservation, sprite
alpha, rotation/shrink configuration, blink configuration, five repetition boundaries and allied
suppression. The source indicator includes the recovered tk2d sprite; no replacement artwork
was generated. The report contains six original source/prefab hashes.

`content/recovered-mortar-indicator-reference.json` retains five native samples each for
rotation/scale and blink alpha, using an explicit two-second test stop time. Its SHA-256 is
`b10ea3c6d4d2b8d04a75943c041dea64bc05ec34b23e12498b674bcb570957ba`.
Source-byte attributes preserve the original CRLF for the four additional tween references;
the new observation and implementation files use LF. Tests compare source digests with the
active Client and reject an unreviewed reference change.
The focused executable passes 38 checks for native sample agreement, source/reference digests
and invalid-factor rejection. The final refactored Unity audit reproduces the pinned JSON
byte-for-byte. Local logs are `Server/.local/mortar-indicator-tests-final.log` and
`Server/.local/mortar-indicator-unity-final.log`; the private manifest was restored afterward.

`War.Shared.MortarIndicatorTween` implements the observed sampling:

- Rotation uses linear factor times 360 degrees, composed as a world-up angle followed by
  the source 90-degree X base rotation. The reset animation curve is linear in this observation.
- Shrink uses `f - sin(2*pi*f)/(2*pi)`, interpolating uniform scale from 1.5 to 0.65.
  This is the source NGUI EaseInOut formula, not cosine easing or SmoothStep.
- Each forward blink lane applies that same easing from alpha 0.35 to zero. The source
  PingPong lifecycle reverses the factor. Its counter begins at one and hides the indicator
  on the fifth subsequent boundary; it does not run five complete forward/backward cycles.

The sampler rejects non-finite or out-of-range normalized factors. Native setup uses a shrink
duration of `stopTime - 0.3`, then a 0.1-second blink lane. Absolute frame deadlines, strict
boundary behavior, reset/cancellation and nonpositive shrink durations still need real Update
observations before implementing the lifecycle. Sampling alone cannot prove those behaviors.

## Remaining production integration

The sampler is not connected to Unity presentation yet. The installed Unity SDK remains at the
previous wire/weapon-pose checkpoint; this stage changes no active Client source, scene or prefab.

The host already freezes `MortarMissileLaunch` target, launch tick, fake identity and weapon
stop time, but current `BattleProjectileState` publishes only current pose/velocity and unit
identity. It cannot reconstruct a warning's original target or elapsed phase on late receipt.
The integration must publish the complete required launch authority, validate it in the SDK,
and reconstruct the warning using current authoritative match time rather than receipt time.

Keep warning lifetime independent of current projectile membership: an early collision must
not automatically erase a warning whose source animation is still running. Conversely, an
expired shot replay must not restart a warning. The original weapon reuses one indicator per
weapon and reparents it to the world, so soldier removal and repeated-shot ownership need
explicit acceptance tests. Scene/session cleanup must remove any remaining owned copies.

Required gates include real/fake opposing warnings, allied suppression, native frame-by-frame
timing, late receipt, reconnect, duplicate events, early impact, shooter death, repeat shots,
terminal/session cleanup, packet capacity, normal two-Unity gameplay and Android rendering.
These remain open; neither the sampler nor the native method audit completes this feature.
