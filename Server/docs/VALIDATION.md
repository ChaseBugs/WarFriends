# Verification checkpoint — 2026-09-19

- Host: Windows, .NET SDK 10.0.401, native MongoDB 8.3.
- Solution build: zero warnings and zero errors.
- Protocol executable: 17 targeted assertions and 1,000 seeded random malformed-packet authentication checks passed.
- Native smoke: 44 live assertions passed. Covers Mongo account registration, duplicate-name rejection, login, password failure, profile persistence, old bearer-session invalidation, anonymous rejection, content type and exact username boundaries, connection grants, portable SDK hello/ping, raw UDP authentication, idempotent hello retry, endpoint binding, duplicate ping rejection, invalid MAC rejection, and closed-ticket replay rejection.
- Smoke data/processes are isolated. Last passing local run: `Server/.local/smoke-8cb5aacd92064b9fa257dd5f42e5eeac`. The script stopped its backend, worker and Mongo processes afterward. Credentials/signing keys are never printed.
- Linux-x64 backend and worker publish succeeded; Linux execution/systemd startup is not verified here.
- No Unity integration, Android build, real battle, Photon removal, chat migration, economy settlement, load benchmark, or production readiness is claimed.

The first smoke readiness loop needed `Invoke-WebRequest -UseBasicParsing` for Windows PowerShell 5. That portability issue was corrected and the complete smoke rerun successfully.
