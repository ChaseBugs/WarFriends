#!/usr/bin/env bash
set -euo pipefail

server_root="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")/.." && pwd)"
published_root="${PUBLISHED_ROOT:-}"
http_port="${HTTP_PORT:-18080}"
mongo_port="${MONGO_PORT:-27028}"
battle_port="${BATTLE_PORT:-30080}"
validate_port() {
    local port="$1"
    if [[ ! "$port" =~ ^[1-9][0-9]{0,4}$ ]] || ((port > 65535)); then
        echo "Smoke ports must be canonical integers from 1 through 65535." >&2
        return 1
    fi
}
for port in "$http_port" "$mongo_port" "$battle_port"; do
    validate_port "$port"
done
control_port="${CONTROL_PORT:-$((battle_port + 1))}"
validate_port "$control_port"
if [[ "$http_port" == "$mongo_port" || "$http_port" == "$control_port" ||
      "$mongo_port" == "$control_port" ]]; then
    echo "HTTP, MongoDB and control endpoints require distinct TCP ports." >&2
    exit 1
fi

run_parent="${SMOKE_RUN_ROOT:-${WAR_TEST_RUN_ROOT:-$server_root/.local/test-runs}}"
artifact_tool="$server_root/scripts/test_artifacts.py"
run_root="$(python3 "$artifact_tool" --root "$run_parent" start smoke --owner-pid "$$")"
mkdir "$run_root/data/mongo"
pids=()
cleanup() {
    local exit_code=$?
    # Only direct children started by this run may be stopped or reaped.
    for pid in "${pids[@]}"; do
        kill "$pid" 2>/dev/null || true
    done
    for pid in "${pids[@]}"; do
        wait "$pid" 2>/dev/null || true
    done
    local status=failed
    if [[ "$exit_code" == 0 ]]; then status=passed; fi
    local keep=()
    if [[ "${KEEP_TEST_ARTIFACTS:-0}" == 1 ]]; then keep=(--keep); fi
    python3 "$artifact_tool" --root "$run_parent" finish "$run_root" --status "$status" "${keep[@]}" || true
    python3 "$artifact_tool" --root "$run_parent" prune --apply || true
}
trap cleanup EXIT
trap 'exit 130' INT
trap 'exit 143' TERM

if [[ -z "$published_root" ]]; then
    if [[ "${NO_BUILD:-0}" != 1 ]]; then
        dotnet build "$server_root/WarFriendsServer.sln" --nologo -v minimal
    fi
else
    published_root="$(cd -- "$published_root" && pwd)"
fi

python3 "$artifact_tool" --root "$run_parent" temp-root "$run_root" > /dev/null
export TMPDIR="$run_root/data/temp"
export TEMP="$TMPDIR"
export TMP="$TMPDIR"

resolve_command() {
    local project_folder="$1"
    local app_name="$2"
    if [[ -n "$published_root" ]]; then
        app_command=("$published_root/$app_name/$app_name")
        if [[ ! -x "${app_command[0]}" ]]; then
            echo "Published native executable is missing: ${app_command[0]}" >&2
            return 1
        fi
    else
        app_command=(dotnet "$server_root/$project_folder/bin/Debug/net10.0/$app_name.dll")
    fi
}
resolve_command "src/War.Backend" "War.Backend"
backend_command=("${app_command[@]}")
resolve_command "src/War.BattleServer" "War.BattleServer"
worker_command=("${app_command[@]}")
resolve_command "tests/War.Battle.Tests" "War.Battle.Tests"
battle_tests=("${app_command[@]}")
resolve_command "tests/War.Protocol.Tests" "War.Protocol.Tests"
protocol_tests=("${app_command[@]}")
resolve_command "tools/War.SmokeClient" "War.SmokeClient"
smoke_client=("${app_command[@]}")

if [[ -n "$published_root" ]]; then
    backend_content_root="$published_root/War.Backend"
    worker_content_root="$published_root/War.BattleServer"
else
    backend_content_root="$server_root/src/War.Backend"
    worker_content_root="$server_root/src/War.BattleServer"
fi

cd -- "$server_root"
export ASPNETCORE_ENVIRONMENT=Development
export Legacy__AllowCatalogFreeStartup=true
export RateLimiting__Auth__PermitLimit=20
export ASPNETCORE_URLS="http://127.0.0.1:$http_port"
export Mongo__Uri="mongodb://127.0.0.1:$mongo_port/?replicaSet=wfSmoke"
export Mongo__Database=warfriends_smoke
export Battle__SigningKey="$(openssl rand -base64 32)"
export Battle__ControlKey="$(openssl rand -base64 32)"
export Battle__Port="$battle_port" Battle__ControlPort="$control_port"
export Battle__ServerId=local-1 Battle__PublicHost=127.0.0.1 Battle__BindAddress=127.0.0.1
export Battle__ResultOutboxPath="$run_root/data/terminal-outbox"

"${MONGOD:-mongod}" --dbpath "$run_root/data/mongo" --bind_ip 127.0.0.1 --port "$mongo_port" \
    --replSet wfSmoke --logpath "$run_root/mongo.log" >"$run_root/mongo-startup.log" 2>&1 &
pids+=("$!")
"${battle_tests[@]}" --init-mongo-replica-set \
    "mongodb://127.0.0.1:$mongo_port/?directConnection=true" wfSmoke "127.0.0.1:$mongo_port"
"${battle_tests[@]}" --queue-attempts-only "$Mongo__Uri"
"${battle_tests[@]}" --queue-cancellation-recovery-only "$Mongo__Uri"
"${battle_tests[@]}" --atomic-terminal-only "$Mongo__Uri"
"${battle_tests[@]}" --prestart-cancellation-ordering-only
"${battle_tests[@]}" --command-ack-only

# Scope configuration watchers to each host, rather than the entire repository.
"${backend_command[@]}" --contentRoot "$backend_content_root" >"$run_root/War.Backend.log" 2>&1 &
pids+=("$!")
"${worker_command[@]}" --contentRoot "$worker_content_root" >"$run_root/War.BattleServer.log" 2>&1 &
pids+=("$!")
ready=0
for ((attempt=0; attempt<60; attempt++)); do
    for pid in "${pids[@]}"; do
        if ! kill -0 "$pid" 2>/dev/null; then
            echo "Owned service exited; inspect $run_root" >&2
            exit 1
        fi
    done
    if curl --silent --fail --max-time 1 "http://127.0.0.1:$http_port/health/ready" >/dev/null &&
       curl --silent --fail --max-time 1 "http://127.0.0.1:$control_port/health/ready" >/dev/null; then
        ready=1
        break
    fi
    sleep 0.25
done
if [[ "$ready" != 1 ]]; then
    echo "Startup failed; logs: $run_root" >&2
    exit 1
fi

"${battle_tests[@]}" --backend-internal-http-only "$Mongo__Uri" "$Mongo__Database" "http://127.0.0.1:$http_port"
"${battle_tests[@]}" --worker-control-http-only "http://127.0.0.1:$control_port"
"${protocol_tests[@]}"
"${smoke_client[@]}" "http://127.0.0.1:$http_port"
echo "Smoke passed. Local data/logs: $run_root"
