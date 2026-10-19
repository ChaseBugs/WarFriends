# Local normal-match admission policy

The local starter allocation template now uses a 60-second prestart admission window.
This is explicit reconstruction/deployment policy, not a recovered original server timeout.
Other combat timings, readiness requirements, idle handling and gameplay duration are unchanged.
The bounded manifest validation range remains 5 through 120 seconds.

## Evidence and reason

The active Client's `GameVariables.GetMatchStartTime` gives players five seconds before War Cards
unlock, or the recovered `MatchMakingConstants.CardsChoosingTime` afterward. The latter is row
index 30 and equals 15 in `recovered-battle-content.json`. This is a card-selection allowance,
not the whole match-loading allowance. After selection, the ordinary controllers still load
assets, place players and finish camera/loading callbacks before acknowledging readiness.

`MatchEngine` starts the admission deadline when the host allocation is created and retains
Waiting until those readiness commands. The old ten-second template could therefore expire
before a source-allowed card choice alone completed. Earlier normal two-Unity runs failed at
ten seconds and passed with a diagnostic thirty-second window while choosing cards immediately.
Those runs did not exercise a human's full fifteen-second selection period.

The new sixty-second policy budgets selection plus ordinary loading while preserving a finite
resource lifetime. It is not a promise that every device loads within sixty seconds. A missing
or unready peer still aborts without score at the deadline. Expired allocations cannot reopen.
A production operator may choose a different validated value in their template; the owner must
measure actual device loading and resource capacity before treating a timeout as production-tuned.

## Harness and verification

`ClientBootSmoke.ps1` no longer defaults its diagnostic override to a hardcoded ten seconds.
Omitting `-PairAdmissionSeconds` uses the repository template directly. Supplying the parameter
still creates a run-local diagnostic template and explicitly labels that override. No normal
Client loading wait or readiness condition was bypassed.

`BattleArmyManifestProjectionTests` imports the repository admission policy into its real
source-bound mixed host. It waits twenty seconds before Ready, then still requires positive
spawned vitality. A separate instance must remain Waiting immediately before the configured
deadline, abort exactly at it, and reject late admission. These are native authority checks;
a new rendered two-Unity run without any override is still required. Earlier thirty-second
runs do not prove the new default. Editor startup failures remain recorded separately in
[NORMAL_UNITY_TERMINAL.md](NORMAL_UNITY_TERMINAL.md).

## Current native results

The Release solution build passes with zero warnings/errors. The mixed allocator group passes
24 starter host checks, including the late-readiness and deadline tests above. Protocol tests
pass, including the 1,360-check protocol/admission/replay group. Parameter-binding probes confirm
that an omitted override remains absent, an explicit thirty-second override is retained, and
zero is rejected by the declared validation range.

The standard native smoke exits zero at
`.local/smoke-3c742c5bf0d14d21aaad044448713ea2`, including 74 real MongoDB/HTTP/protobuf/UDP
checks with two independent SDK clients, transactional terminal/card acceptance, cancellation
and restart evidence. That smoke uses its own prototype fixture and does not replace the
source-bound default-policy tests or a rendered normal-Client run.
