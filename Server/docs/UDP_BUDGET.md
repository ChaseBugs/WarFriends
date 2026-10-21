# Fixed UDP datagram budget

The current protocol supports exactly 1,200 bytes per UDP datagram, including the 32-byte HMAC.
`War.Shared/PacketCodec.MaximumDatagramBytes` owns this limit for both hosts and the portable SDK.
`Battle__MtuBytes` may be omitted or set to `1200`; any other value fails startup before the Worker
binds or loads match state. Backend startup uses the same runtime validator.

Previously, startup accepted 576-1400, the Worker clamped receive to 1200, and outbound codecs and
reply paging still used 1200. A configured lower budget therefore did not limit replies and a higher
budget did not actually permit larger packets. Startup now refuses unsupported values. There is no
MTU negotiation or silent clamping in the current protocol.

| Component | Ownership |
| --- | --- |
| BattleRuntimeConfigValidator | Resolve/freeze the supported protocol budget before traffic |
| PacketMtuPolicy | Reject unsupported budgets, MAC-only packets and oversized received bytes |
| PacketCodec | Refuse oversized encoding/authentication/parsing against the same limit |
| MatchEndpoint | Fit snapshots/projectile pages and select bounded reply transfer when needed |
| MatchReplyTransfer and SDK | Preserve 900-byte chunks, exact reconstruction and digest verification |

The 900-byte chunk payload leaves room for protobuf fields, the widest envelope/transfer IDs and
the MAC inside the same 1200-byte budget. Snapshot truncation does not change collision/damage
authority. The SDK verifies the complete chunked reply before publishing its acknowledgement.

## Verification

```powershell
dotnet build Server/WarFriendsServer.sln
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --transport-mtu-only
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --reply-transfer-only
```

The focused MTU selector tests default/explicit/frozen configuration, former range endpoints and
nearby unsupported values, actual authenticated 1199/1200-byte loopback UDP round trips, and a
1201-byte outbound refusal. Near-maximum reply transfers exercise every chunk with full-width
envelope/transfer IDs and multi-byte page counters. It creates no files or database. This selector
also runs in fast/runtime/full checkpoints and in the full Battle executable.

The existing reply-transfer selector additionally runs real Worker/two-SDK admission, poll, command
acknowledgement, reconnect and complete large-state reconstruction. Native Mongo/HTTP/UDP smoke
remains the broader account/network integration gate. These checks prove the supported size boundary;
they are not throughput benchmarks or normal Unity gameplay verification.
