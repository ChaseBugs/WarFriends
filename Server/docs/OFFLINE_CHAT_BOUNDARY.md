# Retired Photon Chat boundary

The recovered Chat component remains in its original scene/type identity, but
its Photon transport is retired for the owner's self-hosted offline deployment.
This is service retirement, not an implemented replacement chat feature.

## Runtime behavior

- Awake initializes the original local word filter without constructing a
  Photon ChatClient or reading Photon application/environment configuration.
- The existing Connect/Disconnect entry points remain callable by normal battle
  transitions. Neither creates, connects, disconnects or services a Photon client.
  The SDK service/reconnect Update loop and obsolete connection state are removed.
- Existing connected/connecting properties report false. The original eligibility
  and local player/squad display logic remain separate from transport availability.
- Send reports the original localized unavailable-connection message. It does not
  publish a message or optimistically emit an accepted local echo.
- GetMessages returns no remote history. Retired connection, presence and incoming
  message callbacks cannot subscribe, advertise connectivity or inject accepted
  self-hosted history. Local debug/record formatting APIs remain unchanged.
- Local player-data/squad notifications now pair OnEnable subscriptions with
  OnDisable removal, retaining the exact provider instances and rejecting
  duplicate enable subscriptions.

The public SDK-typed field and listener signatures remain for source/asset
compatibility. The active C# source contains no ChatClient construction or
`chatClient.` SDK calls after this change. Photon binaries remain installed for
other recovered type references; this does not retire every other Photon call.

## Verification boundary

`UnityRetiredChatAudit` uses the original scene Chat and word-filter asset with
inactive local providers, plus the recovered chat error label. It invokes actual
Awake, enable/disable, repeated transition calls, stale callbacks and message
send/read entry points. It requires no Photon object, false connection status,
no accepted echo/history, the original localized unavailable message, one local
subscription per event after repeated enable and none after disable.

This runs with the native cancellation/retry modal audit in a disposable Unity
2018.3 project. It does not prove full account/menu boot, complete squad chat UI,
Android, Unity 5.2 or network-wide retirement of all legacy services.

The final native lifecycle and original cancellation/retry modal suite passed:
`Server/.local/unity-retired-chat-lifecycle-final.log`. Static asset checks still
resolve 1,052 script targets and 288,165 nonzero references with zero missing
scripts/broken references; the 17 existing sprite mismatches remain unchanged.
No scene/prefab, script GUID, SDK binary or owner library change was required.

## Remaining work

An authenticated self-hosted chat service, moderation/rate policy, accepted
message DTOs, durable history, global/squad membership authority and normal
two-client UI proof remain unimplemented. Do not count false connection status
or this closed transport as working global/squad chat. Backend implementation
is separate from the BattleServer rebuild; no successful replacement response
or provider/social integration is fabricated here.
