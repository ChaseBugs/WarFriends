# Captured projectile frame revocation

2026-10-22 — scoped BS12 correction.

MatchEngine.End clears equipped grenade and bazooka owners before publishing its
terminal snapshot. Their previously captured iteration frames retained references
to flights/reservations and could still progress them after Clear. Callers usually
break on Terminal, but cleanup ownership itself did not revoke these captured frames.

Equipped grenade frames now require the same active FlightState reference before
advancement. Bazooka owners advance a cleanup revision; captured launch and active
frames stop when their revision is revoked. Reusing a projectile ID or scheduling an
equal launch cannot allow an old frame to act on the replacement. No per-step
allocation or gameplay timing/order change is introduced.

Regression tests capture frames, clear owners, reuse identities, then verify old
frames do nothing while new frames still operate normally. Existing recorded
projectile traces remain the behavior check for normal execution.

This preserves current terminal policy. It does not settle the separate question
of how long bonus/card grenade visuals should survive the recovered result cinematic,
and it does not claim BS12's entire reconnect/crash/recovery scope is complete.

Verification: seven unchanged grenade traces plus nine ownership/order groups;
six unchanged bazooka traces plus seven owner/order and three capacity groups.
The complete Debug solution, protocol suite, native network smoke and legacy
HTTP smoke passed after these changes. This is host-level proof, not a new
rendered two-Client terminal cinematic comparison.
