# Offline region metadata

The active Backend intentionally omits the Photon `Regions` player field.
Actions 140/143 retain their empty callback-safe responses; they do not measure
or provision Photon Cloud. The Client's ping entry points were already closed.

## Client changes

`PhotonConnectionManager.bestRegion` now starts as `CloudRegionCode.none`.
Missing or empty measurements produce an empty sorted list, rather than an
invented Australia/zero-millisecond entry. The selected-region ping returns the
recovered 4,000 ms unknown sentinel when its dictionary or key is missing;
actual cached measurements remain unchanged. This sentinel is not a measurement.

Normal deathmatch matchmaking no longer indexes a possibly empty region list.
`HasMeasuredRegionPingAbove` applies the recovered strict comparison only to an
actual best cached row. Missing metadata cannot itself establish the high-ping
bot condition. The other source bot conditions, source threshold and local
payment/callback order are unchanged. This is an explicit consequence of retired
Photon measurements, not an invented measurement of the self-hosted endpoint.

The two-player legacy region selector returns none/false when either side has
no measurements, without reading unrelated GameVariables. The retired region
retry path also stops on an empty list. Manager Start no longer configures
Photon send rates or accesses `PhotonNetwork.networkingPeer`; the self-hosted
Worker/SDK own their transport configuration.

## Verification and remaining boundary

`UnityOfflineRegionAudit` checks null and empty dictionaries, selected-key
absence, no fabricated allowed/shared route, no missing-data latency bot,
preserved cached ordering/strict threshold comparison and selected measured ping.
It invokes the actual Start and closed ping entry points in the disposable
Unity 2018 scene fixture. The combined original Chat/retry/cancellation modal
suite passes in `Server/.local/unity-offline-regions.log`.

This does not execute the complete normal match button/profile flow, measure
self-hosted network latency or replace invitations/other Photon room behavior.
Local solo, time, ownership, serialization and other retained Photon callers
still need their respective migration/verification. Unity 5.2, Android and full
two-Unity-client gameplay are not proved by this gate.
