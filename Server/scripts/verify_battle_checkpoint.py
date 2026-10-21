#!/usr/bin/env python3
"""Run the repeatable checks available before a BattleServer release review.

This is a checkpoint, not a claim that Unity gameplay or Android is complete.
The optional native smoke needs a local MongoDB executable and free test ports.
"""

from __future__ import annotations

import argparse
import json
import os
import shutil
import subprocess
import sys
import time
from pathlib import Path

from test_artifacts import DEFAULT_ROOT, finish_run, prepare_test_environment, prune_runs, start_run


REPOSITORY = Path(__file__).resolve().parents[2]

FOCUSED_BATTLE_CASES = {
    "army-missile-expiry": ("Source army missile expiry priority", "--army-missile-expiry-only"),
    "content-precision": ("Content precision vitality boundaries", "--content-precision-only"),
    "army-flame-interpolation": ("Original Unity flame interpolation", "--army-flame-interpolation-only"),
    "army-flame-clock": ("Recovered army flame clock", "--army-flame-clock-only"),
    "army-flame-geometry": ("Army flame geometry", "--flame-only"),
    "test-arguments": ("Battle test argument refusals", "--test-arguments-only"),
    "allocation-inventory": ("Shared-prefix allocation inventory", "--allocation-inventory-only"),
    "pvp-army-bullets": ("PvP army bullet state", "--pvp-army-bullets-only"),
    "pvp-army-effects": ("PvP army flame and poison state", "--pvp-army-effects-only"),
    "pvp-army-missiles": ("PvP army Rocket and Mortar missile state", "--pvp-army-missiles-only"),
    "assaulter-volley": ("Source Assaulter volleys", "--assaulter-volley-only"),
    "gunslinger-shooting": ("Source Gunslinger shooting", "--gunslinger-shooting-only"),
    "grenadier-primary": ("Source Grenadier primary damage", "--grenadier-damage-only"),
    "grenade-combat": ("Source grenade combat and UDP", "--grenade-only"),
    "grenades-burst-udp": ("Cluster Grenade card UDP", "--live-grenades-burst-only"),
    "bonus-grenade-policy": ("Bonus grenade shared setup", "--pvp-bonus-grenade-only"),
    "pvp-grenades": ("PvP ordinary and bonus grenade state", "--pvp-grenade-state-only"),
    "bazooka-combat": ("Source bazooka combat and UDP", "--bazooka-only"),
    "pvp-bazookas": ("PvP bazooka state and capacity", "--pvp-bazooka-state-only"),
    "pvp-bazooka-capacity": ("PvP bazooka capacity", "--pvp-bazooka-capacity-only"),
    "combat-content": ("Recovered combat content", "--combat-content-only"),
    "pvp-player-bullets": ("PvP player bullet state", "--pvp-player-bullets-only"),
    "pvp-movement": ("PvP movement state", "--pvp-movement-only"),
    "pvp-weapons": ("PvP weapon state", "--pvp-weapon-state-only"),
    "pvp-connection": ("PvP connection lifecycle", "--pvp-connection-lifecycle-only"),
    "legacy-buffer-dispatch": ("Legacy buffered feature dispatch", "--legacy-buffer-dispatch-only"),
    "legacy-diagnostics": ("Legacy diagnostic metadata", "--legacy-diagnostics-only"),
    "legacy-dispatch": ("Legacy action dispatch", "--legacy-dispatch-only"),
    "worker-http": ("Worker HTTP boundaries", "--worker-http-only"),
    "terminal-envelope": ("Terminal HTTP envelope", "--terminal-envelope-only"),
    "backend-http": ("Backend HTTP boundaries", "--backend-http-only"),
    "startup-refusals": ("Startup refusal processes", "--startup-refusal-processes-only"),
    "backend-startup": ("Backend startup policy", "--backend-startup-only"),
    "battle-projects": ("Battle project boundaries", "--battle-projects-only"),
    "army-perks": ("Bilateral army perks", "--army-perks-only"),
    "canonical-identity": ("Canonical battle identity", "--canonical-identity-only"),
    "mixed-grenade-udp": ("Mixed grenade UDP lifecycle", "--mixed-grenade-udp-only"),
    "shotgunner-udp": ("Shotgunner UDP scan replay", "--shotgunner-udp-only"),
}


def focused_stages(case: str):
    name, selector = FOCUSED_BATTLE_CASES[case]
    return [
        ("Solution build", ["dotnet", "build", "Server/WarFriendsServer.sln", "--nologo", "-v", "minimal"]),
        (name, ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", selector]),
    ]


def command_stages(native_smoke: bool, mongo_executable: str | None):
    python = sys.executable
    stages = [
        ("Server source layout", [python, "Server/tools/verify_server_source_layout.py"]),
        ("Server extraction guard", [python, "Server/tools/test_server_source_layout.py"]),
        ("Test artifact lifecycle", [python, "Server/scripts/test_test_artifacts.py"]),
        ("Mission source catalog", [python, "Server/tools/extract_mission_catalog.py", "--check"]),
        ("Co-op spawn source catalog", [python, "Server/tools/extract_coop_spawn_points.py", "--check"]),
        ("Battle card source inventory", [python, "Server/tools/audit_battle_card_inventory.py", "--check"]),
        ("PvP score-streak source policy", [python, "Server/tools/extract_pvp_score_streak_policy.py", "--check"]),
        ("PvP bonus source catalog", [python, "Server/tools/extract_pvp_bonus_catalog.py", "--check"]),
        ("PvP bonus spawn areas", [python, "Server/tools/extract_pvp_bonus_spawn_areas.py", "--check"]),
        ("Photon replacement ledger", [python, "Server/tools/verify_photon_replacement_ledger.py"]),
        ("Battle terminal reasons", [python, "Server/tools/audit_battle_terminal_reasons.py"]),
        ("Portable content hashes", [python, "Server/tools/verify_content_checkout_hashes.py"]),
        ("Solution build", ["dotnet", "build", "Server/WarFriendsServer.sln", "--nologo", "-v", "minimal"]),
        ("Protocol tests", ["dotnet", "run", "--project", "Server/tests/War.Protocol.Tests", "--no-build"]),
        ("Battle test argument refusals", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--test-arguments-only"]),
        ("Battle project boundaries", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--battle-projects-only"]),
        ("PvP connection lifecycle", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--pvp-connection-lifecycle-only"]),
        ("PvP weapon state", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--pvp-weapon-state-only"]),
        ("PvP movement state", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--pvp-movement-only"]),
        ("PvP player bullet state", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--pvp-player-bullets-only"]),
        ("PvP bazooka state and capacity", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--pvp-bazooka-state-only"]),
        ("PvP ordinary and bonus grenade state", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--pvp-grenade-state-only"]),
        ("PvP army bullet state", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--pvp-army-bullets-only"]),
        ("PvP army flame and poison state", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--pvp-army-effects-only"]),
        ("PvP army Rocket and Mortar missile state", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--pvp-army-missiles-only"]),
        ("Source army missile expiry priority", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--army-missile-expiry-only"]),
        ("Recovered army flame clock", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--army-flame-clock-only"]),
        ("Original Unity flame interpolation", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--army-flame-interpolation-only"]),
        ("Backend startup policy", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--backend-startup-only"]),
        ("Backend HTTP boundaries", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--backend-http-only"]),
        ("Terminal HTTP envelope", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--terminal-envelope-only"]),
        ("Worker HTTP boundaries", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--worker-http-only"]),
        ("Startup refusal processes", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--startup-refusal-processes-only"]),
        ("Canonical battle identity", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--canonical-identity-only"]),
        ("UDP MTU boundaries", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--transport-mtu-only"]),
        ("Legacy economy boundaries", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--legacy-economy-only"]),
        ("Legacy buffer envelopes", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--legacy-buffer-parser-only"]),
        ("Legacy card pool rules", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--legacy-card-pool-only"]),
        ("Legacy squad rules", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--legacy-squad-only"]),
        ("Legacy account rules", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--legacy-account-only"]),
        ("Legacy action dispatch", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--legacy-dispatch-only"]),
        ("Legacy diagnostic metadata", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--legacy-diagnostics-only"]),
        ("Legacy buffered feature dispatch", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build", "--", "--legacy-buffer-dispatch-only"]),
        ("Client buffer contract provenance", [python, "Server/tools/generate_legacy_buffer_oracle.py"]),
        ("Legacy producer inventory guard", [python, "Server/tools/test_legacy_buffer_producer_inventory.py"]),
        ("Legacy unit scene roles", [python, "Server/tools/verify_legacy_unit_roster.py"]),
        ("Legacy catalog release profile", [python, "Server/tools/build_legacy_catalog_profile.py", "--check"]),
        ("Client buffer contracts", ["dotnet", "run", "--project", "Server/tests/War.LegacyContract.Tests", "--no-build"]),
        ("Battle tests", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build"]),
    ]
    if os.name == "nt":
        shell = shutil.which("powershell") or shutil.which("pwsh")
        if shell is None:
            raise RuntimeError("PowerShell is required for the Windows replay assertions.")
        stages.insert(2, ("PowerShell replay assertions", [shell, "-NoProfile", "-ExecutionPolicy", "Bypass",
                                                        "-File", "Server/scripts/TestBufferReplay.ps1"]))
        stages.insert(3, ("PowerShell environment isolation", [shell, "-NoProfile", "-ExecutionPolicy", "Bypass",
                                                            "-File", "Server/scripts/TestEnvironment.ps1",
                                                            "-IncludeAvailableHosts"]))
    if native_smoke:
        if os.name == "nt":
            shell = shutil.which("powershell") or shutil.which("pwsh")
            if shell is None:
                raise RuntimeError("PowerShell is required for the Windows native smoke.")
            command = [shell, "-NoProfile", "-ExecutionPolicy", "Bypass",
                       "-File", "Server/scripts/Smoke.ps1", "-NoBuild"]
            if mongo_executable:
                command.extend(["-MongoExecutable", mongo_executable])
        else:
            command = ["bash", "Server/scripts/smoke.sh"]
        stages.append(("Native Mongo, HTTP, and UDP smoke", command))
    return stages


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--native-smoke", action="store_true",
                        help="also start isolated Mongo, Backend, and Battle processes")
    parser.add_argument("--mongo-executable",
                        help="Windows mongod executable for --native-smoke")
    parser.add_argument("--list", action="store_true",
                        help="show the stages without running them")
    parser.add_argument("--suite", choices=("fast", "runtime", "battle", "focused"), default="battle",
                        help="fast: code boundaries; runtime: combat; battle: source audits; focused: one named case")
    parser.add_argument("--case", choices=tuple(FOCUSED_BATTLE_CASES),
                        help="required with --suite focused; managed logs/temp without the full combat suite")
    parser.add_argument("--no-build", action="store_true",
                        help="reuse binaries from a successful solution build")
    arguments = parser.parse_args()
    if (arguments.suite == "focused") != (arguments.case is not None):
        parser.error("--suite focused requires --case; other suites do not accept --case")
    if arguments.suite == "focused" and arguments.native_smoke:
        parser.error("focused cases do not start Mongo services; use --suite fast/runtime with --native-smoke")
    if arguments.mongo_executable and not arguments.native_smoke:
        parser.error("--mongo-executable requires --native-smoke")
    if arguments.mongo_executable and os.name != "nt":
        parser.error("on Linux, set MONGOD for the native smoke script")

    try:
        if arguments.suite == "focused":
            stages = focused_stages(arguments.case)
        else:
            stages = command_stages(arguments.native_smoke, arguments.mongo_executable)
        if arguments.suite in ("fast", "runtime"):
            runtime_stages = {"Server source layout", "Server extraction guard", "Battle project boundaries",
                              "PvP connection lifecycle",
                              "PvP weapon state",
                              "PvP movement state",
                              "PvP player bullet state",
                              "PvP bazooka state and capacity",
                              "PvP ordinary and bonus grenade state",
                              "PvP army bullet state",
                              "PvP army flame and poison state",
                              "PvP army Rocket and Mortar missile state",
                              "Source army missile expiry priority",
                              "Battle test argument refusals",
                              "Recovered army flame clock",
                              "Original Unity flame interpolation",
                              "Backend startup policy", "Backend HTTP boundaries", "Terminal HTTP envelope",
                              "Worker HTTP boundaries",
                              "Canonical battle identity",
                              "Test artifact lifecycle", "PowerShell replay assertions",
                              "PowerShell environment isolation", "Solution build",
                              "Protocol tests", "UDP MTU boundaries", "Legacy economy boundaries", "Legacy buffer envelopes", "Legacy card pool rules",
                              "Legacy squad rules", "Legacy account rules", "Legacy action dispatch",
                              "Legacy diagnostic metadata",
                              "Legacy buffered feature dispatch",
                              "Client buffer contract provenance",
                              "Client buffer contracts", "Legacy producer inventory guard", "Legacy unit scene roles",
                              "Legacy catalog release profile",
                              "Battle terminal reasons",
                              "Native Mongo, HTTP, and UDP smoke"}
            if arguments.suite == "runtime":
                runtime_stages.update({"Battle tests", "Startup refusal processes"})
            stages = [stage for stage in stages if stage[0] in runtime_stages]
        if arguments.no_build:
            stages = [stage for stage in stages if stage[0] != "Solution build"]
    except RuntimeError as error:
        parser.error(str(error))

    run_root = None if arguments.list else start_run(DEFAULT_ROOT, "checkpoint", os.getpid())
    results = []
    for index, (name, command) in enumerate(stages, start=1):
        print(f"[{index}/{len(stages)}] {name}: {' '.join(command)}", flush=True)
        if arguments.list:
            continue
        started = time.monotonic()
        environment = os.environ.copy()
        if command[:2] == ["dotnet", "run"]:
            environment = prepare_test_environment(DEFAULT_ROOT, run_root)
        environment["PYTHONDONTWRITEBYTECODE"] = "1"
        environment["NO_BUILD"] = "1"
        log_path = run_root / f"{index:02d}.log"
        try:
            with log_path.open("w", encoding="utf-8") as log:
                result = subprocess.run(command, cwd=REPOSITORY,
                                        env=environment, check=False,
                                        stdout=log, stderr=subprocess.STDOUT)
        except OSError as error:
            finish_run(DEFAULT_ROOT, run_root, "failed", False)
            print(f"FAIL: {name}: {error}", file=sys.stderr, flush=True)
            return 1
        elapsed = time.monotonic() - started
        results.append({"name": name, "exitCode": result.returncode,
                        "seconds": round(elapsed, 3), "log": log_path.name})
        report = {"suite": arguments.suite, "stages": results}
        if arguments.case is not None:
            report["case"] = arguments.case
        (run_root / "results.json").write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8")
        if result.returncode != 0:
            finish_run(DEFAULT_ROOT, run_root, "failed", False)
            print(f"FAIL: {name} exited {result.returncode} after {elapsed:.1f}s",
                  file=sys.stderr, flush=True)
            print(f"Failure log: {log_path}", file=sys.stderr, flush=True)
            return result.returncode
        print(f"PASS: {name} ({elapsed:.1f}s)", flush=True)

    if not arguments.list:
        finish_run(DEFAULT_ROOT, run_root, "passed", False)
        prune_runs(DEFAULT_ROOT, apply=True)
        print(f"PASS: all {len(stages)} selected Battle checkpoint stages", flush=True)
        print(f"Reports: {run_root}", flush=True)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
