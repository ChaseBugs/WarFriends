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
database name, byte length, UTC creation time, and SHA-256 hash. Copy both files to independently
managed encrypted storage and test restoration regularly.

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

## Rolling deployment

1. Back up MongoDB and retain the manifest outside the host.
2. Deploy one node. Versioned migrations acquire the database-wide lease before listeners open.
3. Confirm `/health`, authenticated `/metrics`, and that Redis reports available when enabled.
4. Roll remaining nodes. PvP coordinator heartbeats preserve matches owned by healthy peers.
5. Watch HTTP 5xx, rate rejections, WebSocket connections, Redis availability, and memory.
