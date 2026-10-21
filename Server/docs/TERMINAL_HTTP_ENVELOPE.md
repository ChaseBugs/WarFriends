# Terminal HTTP envelope capacity

C26 aligns the server-to-server JSON body with the existing maximum WFR1 protobuf snapshot. The
binary contract, digest framing, signed MAC domain and terminal authority validator are unchanged.
No terminal bytes are truncated and no result becomes scored or settled by transport acceptance.

## Derived budgets

War.Infrastructure/Transport/TerminalResultEnvelope owns serialization and the result-body budget:

| Quantity | Maximum bytes / characters |
| --- | ---: |
| Binary snapshot | 65,536 |
| Base64 snapshot | 87,384 |
| Server ID + match ID + digest | 64 + 64 + 64 |
| Four-field JSON syntax | 54 |
| Decoded JSON body | 87,630 |
| HTTP/1 wire body with canonical one-byte chunks | 525,785 |

The JSON formula is 54 + 192 + 4 * ceil(65536 / 3). The writer emits the snapshot through
Utf8JsonWriter.WriteBase64String, so plus signs are not expanded into six-character HTML escapes.
Metadata uses the existing bounded ASCII identity alphabets and lower-case SHA-256 digest shape.
The serializer checks its exact output length and refuses invalid payload/metadata before HTTP.

Only /internal/battle/results/accept raises its per-request Kestrel feature. Global Backend,
protobuf and provision budgets remain 65,536; allocation-read remains 2,048. BoundedStreamReader
independently enforces decoded bytes and consumes at most one excess byte. Its pooled buffer is
cleared on return.

Kestrel counts chunk framing as observed request-body bytes, including chunk prefixes and suffixes.
That behavior is visible in the
[ASP.NET Core implementation](https://raw.githubusercontent.com/dotnet/aspnetcore/v10.0.0/src/Servers/Kestrel/Core/src/Internal/Http/Http1ChunkedEncodingMessageBody.cs).
A canonical one-byte chunk occupies six wire bytes and the final chunk five; the finite wire cap
is therefore 6 * 87630 + 5. Extensions or noncanonical framing consume that same finite cap. Decoded
JSON never receives the larger wire allowance.

## Failure evidence and correction

smoke-63366e3984f148e8bb62cca74e39fdb8 first validated a 65,536-byte canonical snapshot and then
observed BackendResultForwarder receive HTTP 413. It used the previous serializer and body cap.

The shared serializer/body budget allowed the full binary snapshot. Exact decoded-body testing then
found HTTP/1 chunk framing could still reject an at-limit payload. The first full attempt
checkpoint-9a809fbc11204e3b91503527c56721c7 and targeted smoke-960f95d29e3f43a8bc5cfe977f10306d
record that boundary. Separate wire/decoded limits now cover normal chunking and canonical one-byte
chunks through actual signed HTTP.

The regression fixture starts from real MatchEngine terminal evidence. A canonical unknown protobuf
compatibility field pads it to exactly 65,536 bytes and deliberately contains plus-heavy Base64
input. Existing ValidatePayload checks its complete semantic state, digest and canonical roundtrip
before submission. The compatibility field is transport-boundary padding; this does not prove a
normal Unity battle generates a 64-KiB terminal or change the game/protobuf schema.

Native checks prove first acceptance and exact durable replay, exact 87,630-byte JSON with declared,
normal chunked and raw one-byte-chunked transfer, binary 65,537-byte refusal without writes, decoded
budget + 1 refusal and unchanged unrelated protobuf limits. Pure checks verify maximum metadata,
Base64 roundtrips, exact serializer capacity and zero HTTP sends for local refusal.

## Oversized HTTP/1 connection lifetime

Boundary testing also exposed C27. A declared oversize response could finish with a reusable
connection header, followed by Kestrel failing to drain the unread over-limit body and closing the
socket. The next client request could observe ResponseEnded rather than its response.

smoke-4e48f4ab545142d18f7d6b54b56eb7e0 records the provision route's following chunked request and
Kestrel's post-response drain rejection. Backend 413 handling and Worker early size refusal now
advertise Connection: close for HTTP/1. Protocol-specific unit checks ensure no such connection
header is added to HTTP/2. Native cases reuse the client after each negative input and require both
413 and explicit closure. No retry hides the failed response.

The two added negative registration requests consume the test IP's auth limiter. Both native smoke
scripts explicitly select twenty permits for that test process and restore the caller's environment;
the production default remains ten. This avoids confusing an expected 413/415 with an unrelated 429.

## Developer gates

```powershell
python Server/scripts/verify_battle_checkpoint.py --suite focused --case terminal-envelope
python Server/scripts/verify_battle_checkpoint.py --suite focused --case backend-http
python Server/scripts/verify_battle_checkpoint.py --suite fast --native-smoke `
    --mongo-executable 'C:/Program Files/MongoDB/Server/8.3/bin/mongod.exe'
```

Deploy the rebuilt server binary set together. This server-only envelope changes no Unity package,
action ID or protobuf field. MAC replay nonces C03, complete schemas/catalogs C12/C13, ordinary
GameEnded C18, V07 source provenance and normal Client gameplay retain their separate gates.
