#!/usr/bin/env bash
set -euo pipefail
server_root="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")/.." && pwd)"
mkdir -p "$server_root/.local"
run_root="$(mktemp -d "$server_root/.local/smoke-XXXXXXXX")"
mkdir "$run_root/mongo"
pids=()
cleanup() { for pid in "${pids[@]}"; do kill "$pid" 2>/dev/null || true; done; }
trap cleanup EXIT INT TERM
dotnet build "$server_root/WarFriendsServer.sln" --nologo -v minimal
export ASPNETCORE_ENVIRONMENT=Development
export ASPNETCORE_URLS=http://127.0.0.1:18080
export Mongo__Uri=mongodb://127.0.0.1:27028
export Mongo__Database=warfriends_smoke
export Battle__SigningKey="$(openssl rand -base64 32)"
export Battle__Port=30080 Battle__ServerId=local-1 Battle__PublicHost=127.0.0.1 Battle__BindAddress=127.0.0.1
"${MONGOD:-mongod}" --dbpath "$run_root/mongo" --bind_ip 127.0.0.1 --port 27028 --logpath "$run_root/mongo.log" &
pids+=("$!")
for app in War.Backend War.BattleServer; do
    dotnet "$server_root/src/$app/bin/Debug/net10.0/$app.dll" >"$run_root/$app.log" 2>&1 &
    pids+=("$!")
done
ready=0
for ((i=0;i<60;i++)); do
    if curl --silent --fail --max-time 1 http://127.0.0.1:18080/health/ready >/dev/null; then ready=1; break; fi
    sleep 0.25
done
if [[ "$ready" != 1 ]]; then echo "Startup failed; logs: $run_root"; exit 1; fi
dotnet "$server_root/tests/War.Protocol.Tests/bin/Debug/net10.0/War.Protocol.Tests.dll"
dotnet "$server_root/tools/War.SmokeClient/bin/Debug/net10.0/War.SmokeClient.dll" http://127.0.0.1:18080
echo "Smoke passed. Local data/logs: $run_root"
