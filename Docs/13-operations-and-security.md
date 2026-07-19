# Operations and Security

## HTTP request boundary

The Express server applies the global limiter before JSON and form decoding. This ordering matters:
an over-limit caller receives a small response before the server spends CPU and memory parsing a
potentially large request body. CORS headers are applied first so browser adapters can still read
the rejection. WebSocket upgrades do not pass through Express and therefore require a separate
shared limiter before a horizontally scaled production deployment.

`/health` and `OPTIONS` requests are exempt. Health probes must remain able to distinguish a live
process from an overloaded client address, while an OPTIONS preflight executes no game mutation.
Every actual REST game request, including unauthenticated account and configuration calls, consumes
one token.

## Token-bucket algorithm

Each client key owns a bucket with a capacity and a continuous refill rate:

```text
refill rate = HTTP_RATE_LIMIT_MAX_REQUESTS / HTTP_RATE_LIMIT_WINDOW_SECONDS
new tokens  = min(capacity, old tokens + elapsed milliseconds * refill rate)
```

An allowed request consumes one token. A request with less than one token receives HTTP `429`, a
`Retry-After` value derived from the exact time until the next token, and a generic JSON error. The
continuous refill avoids the double burst possible at a fixed-window boundary.

The bucket map has a hard `HTTP_RATE_LIMIT_MAX_ENTRIES` ceiling. Fully refilled idle entries are
removed first; if every bucket is active, the least recently used key is evicted. This keeps an
attacker rotating through addresses from growing process memory without limit. The current map is
process-local, so multi-process deployments must move enforcement to a shared atomic store before
claiming one global limit.

## Client-address trust

Raw client addresses are never stored in the limiter or written to logs. The server derives a
deployment-local key using HMAC-SHA256 with `AUTH_SECRET`, and logs only a short prefix when a limit
is exceeded.

Express ignores forwarded addresses by default. `TRUST_PROXY_HOPS` must remain `0` for a directly
exposed server. Behind a controlled reverse proxy, set it to the exact number of trusted hops.
Enabling arbitrary proxy trust would allow a caller to choose a new `X-Forwarded-For` value on every
request and bypass the per-address bucket.

## Default policy

- `HTTP_RATE_LIMIT_MAX_REQUESTS=120`
- `HTTP_RATE_LIMIT_WINDOW_SECONDS=60`
- `HTTP_RATE_LIMIT_MAX_ENTRIES=10000`
- `TRUST_PROXY_HOPS=0`

These values protect the offline reconstruction without assuming production traffic volume. Tune
them from observed legitimate request bursts, and keep the independent durable login throttle in
place: the HTTP limiter controls transport abuse, while the MongoDB login limiter controls repeated
password/provider guesses for one identity.

## Remaining production work

- use a shared atomic HTTP and WebSocket limiter across all server processes;
- authenticate administration and configuration-publication routes;
- add structured metrics, traces, alerting, backup/restore drills, and schema migrations;
- define an `AUTH_SECRET` rotation procedure because it protects passwords, identity keys, and
  address pseudonyms.
