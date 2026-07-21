# WarFriends backend operations

## Required production secrets

- Set a unique `AUTH_SECRET` for gameplay credentials.
- Set a separate `ADMIN_SECRET` of at least 32 characters for `GET /metrics` and future operator routes.
- Send metrics requests with `Authorization: Bearer <ADMIN_SECRET>`.
- Keep `TRUST_PROXY_HOPS=0` unless the exact number of trusted reverse proxies is known.

## MongoDB backup

Install MongoDB Database Tools so `mongodump` and `mongorestore` are available. Run from `Server`:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File scripts\Backup-Mongo.ps1
```

The script uses `MONGO_URL` and `MONGO_DB_NAME`, writes a compressed archive under ignored
`backups/`, refuses to overwrite an existing archive, and writes a JSON manifest containing the
database name, byte length, UTC creation time, and SHA-256 hash. This local form is useful for a
manual same-host maintenance snapshot; production retention should use the encrypted workflow.

## Encrypted off-host backup and retention

Point `BACKUP_OFFHOST_DIRECTORY` at a mounted remote volume or UNC share. Generate a raw 256-bit key
once and store it in the deployment secret manager, not in `.env` committed to Git:

```powershell
[Convert]::ToBase64String([Security.Cryptography.RandomNumberGenerator]::GetBytes(32))
```

Set that value as `BACKUP_ENCRYPTION_KEY`, choose `BACKUP_RETENTION_DAYS` from 7 through 3650, then
run from `Server`:

```powershell
npm run backup:mongodb:offhost
```

The workflow creates the `mongodump` archive in a unique OS temporary directory, verifies its
format-1 manifest, and writes only AES-256-GCM ciphertext plus a format-2 manifest to the off-host
target. Database identity, creation time, original name, byte count, and plaintext SHA-256 are GCM
authenticated. The temporary plaintext directory is removed after success or failure. Existing
destinations are never overwritten. Retention runs only after a new encrypted archive is durable
and removes only old, same-database `.wfbk`/manifest pairs whose confined path, size, and encrypted
SHA-256 validate; damaged, malformed, unknown, and orphaned files are preserved for review.

Schedule this command with the deployment scheduler or Windows Task Scheduler under an account that
can read the database secret and backup key and can write only the intended remote directory. Alert
on a nonzero exit and on the age of the newest manifest. Keep every historical encryption key until
all archives produced by it have expired, and perform a restore drill after key or tooling changes.

## MongoDB restore

Stop game traffic to the target deployment and verify `MONGO_URL`, `MONGO_DB_NAME`, the archive,
and its manifest. Restoration verifies database identity, byte length, and SHA-256 before allowing
`mongorestore --drop`:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File scripts\Restore-Mongo.ps1 `
  -ArchivePath backups\warfriends-YYYYMMDDTHHMMSSZ.archive.gz `
  -ConfirmDatabaseReplacement
```

The confirmation switch is mandatory because this replaces target collections. After restoration,
start one backend node first, confirm migrations and `/health`, authenticate `/metrics`, then open
traffic and add the remaining nodes.

For an encrypted off-host archive, set the matching historical `BACKUP_ENCRYPTION_KEY` and run:

```powershell
npm run restore:mongodb:offhost -- `
  -EncryptedArchivePath \\backup-host\warfriends\warfriends-YYYYMMDDTHHMMSSZ.archive.gz.wfbk `
  -ConfirmDatabaseReplacement
```

The wrapper verifies ciphertext size/SHA, authenticates the GCM tag and bound database metadata,
decrypts into a unique temporary directory, and then invokes the existing restore script. That
script independently verifies the plaintext database, byte count, and SHA-256 before its guarded
`mongorestore --drop`. Plaintext is removed from temporary storage in a `finally` block.

## Rolling deployment

1. Back up MongoDB and retain the manifest outside the host.
2. Deploy one node. Versioned migrations acquire the database-wide lease before listeners open.
3. Confirm `/health`, authenticated `/metrics`, and that Redis reports available when enabled.
4. Roll remaining nodes. PvP coordinator heartbeats preserve matches owned by healthy peers.
5. Watch HTTP 5xx, rate rejections, WebSocket connections, Redis availability, and memory.

## Prometheus alerts and Grafana dashboard

`ops/prometheus/prometheus.example.yml` shows an authenticated multi-node scrape. Put only the raw
`ADMIN_SECRET` value in its external `credentials_file`; do not add the `Bearer ` prefix and do not
commit that secret file. Copy `warfriends-alerts.yml` beside the Prometheus configuration, retain
the `rule_files` entry, and validate both files with the deployed Prometheus `promtool` before
reloading. The example labels production targets `redis_required=true`; omit or set that label to
`false` for intentionally Mongo-only deployments so the Redis alert has no matching series.

The alert group covers target loss, sustained HTTP 5xx ratio, sustained mean latency, required Redis
loss, sustained WebSocket rate-limit pressure, repeated restarts, and high in-flight requests. Ratio
alerts include minimum-traffic gates so an isolated failure does not look like a production outage.
Route `severity=critical` to the primary on-call destination and `severity=warning` to the secondary
notification path in the deployment-owned Alertmanager configuration.

Import `ops/grafana/warfriends-overview.json` and select the Prometheus data source when prompted.
The dashboard uses only bounded metrics exported by this repository: availability, request rate,
mean processing time, WebSocket connections/messages/rejections, in-flight work, Redis availability,
resident memory, and error/rejection ratios. The repository contract test parses the dashboard and
checks every referenced `warfriends_*` name against the live exposition contract; `promtool` remains
the deployment gate for full PromQL/YAML validation.
