# Portable observed infantry pose catalog

The SDK now carries the same 221 observed obstacle-preparation samples as the
verified server catalog. This is shared content infrastructure for B32, not a
completed renderer or a new co-op admission path.

## Contract and ownership

`BattleInfantryAnimationFrame` retains its existing sample tick and clip fields.
Its additive `observed_pose` field contains only a catalog revision and sample ID.
The host does not publish this field yet. Arbitrary network transform arrays are
not accepted as presentation authority.

`coop-obstacle-fixed-step-pose-catalog.pb` is embedded in `War.Shared.dll`.
The server exporter derives it from the validated source catalog. The server test
compares its complete encoded bytes with the committed portable artifact.
The SDK bounds input size, verifies its SHA-256, checks source identity and
ordering, and exposes deep copies. Mutating a returned sample or topology cannot
change subsequent lookups. Unknown revisions and out-of-range IDs are rejected.

The catalog contains 58 non-root transform identities and 17 prior-return phases
with 13 observations each. It describes only the captured nominal histories;
it is not proof for every interruption, actor style or weapon hierarchy.

## Verification and remaining integration

Protocol tests round-trip and retrieve all 221 references and check copy
isolation. A native Unity 2018.3 audit repeats those checks using the installed
SDK binaries. Neither check proves rendered pixels or normal gameplay.

The installed SDK also passes the existing 24-check native co-op visual adapter
audit. Focused combat passes 26,368 assertions; native MongoDB/HTTP/protobuf/UDP
smoke passes 1,144 protocol checks, 74 live checks and restart recovery. Static
asset validation reports no missing scripts or broken references. The existing
17 atlas sprite mismatches remain unchanged. These checks do not establish
Unity 5.2, Android, Linux or two-Unity-client gameplay support.

The normal SDK animation view deliberately rejects every observed-pose reference
until a renderer capability is installed. Even a valid reference with matching
clip fields is rejected. This prevents accidental clip-only presentation of a
pose known to require hierarchy corrections.

Before the host can publish references, implement capability and revision
negotiation: older protobuf clients ignore additive fields and could otherwise
display an incorrect clip-only pose. Bind the actual Unity actor hierarchy,
including weapon attachments, validate the complete sample before mutation, and
verify source-equivalent local transforms. Then connect host history selection
and the production presenter, with repeated-interruption and normal gameplay
proof. Public co-op admission remains closed during this work.
