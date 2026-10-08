#!/usr/bin/env python3
"""Run the repeatable checks available before a BattleServer release review.

This is a checkpoint, not a claim that Unity gameplay or Android is complete.
The optional native smoke needs a local MongoDB executable and free test ports.
"""

from __future__ import annotations

import argparse
import os
import shutil
import subprocess
import sys
import time
from pathlib import Path


REPOSITORY = Path(__file__).resolve().parents[2]


def command_stages(native_smoke: bool, mongo_executable: str | None):
    python = sys.executable
    stages = [
        ("Mission source catalog", [python, "Server/tools/extract_mission_catalog.py", "--check"]),
        ("Co-op spawn source catalog", [python, "Server/tools/extract_coop_spawn_points.py", "--check"]),
        ("Photon replacement ledger", [python, "Server/tools/verify_photon_replacement_ledger.py"]),
        ("Portable content hashes", [python, "Server/tools/verify_content_checkout_hashes.py"]),
        ("Solution build", ["dotnet", "build", "Server/WarFriendsServer.sln", "--nologo", "-v", "minimal"]),
        ("Protocol tests", ["dotnet", "run", "--project", "Server/tests/War.Protocol.Tests", "--no-build"]),
        ("Battle tests", ["dotnet", "run", "--project", "Server/tests/War.Battle.Tests", "--no-build"]),
    ]
    if native_smoke:
        if os.name == "nt":
            shell = shutil.which("powershell") or shutil.which("pwsh")
            if shell is None:
                raise RuntimeError("PowerShell is required for the Windows native smoke.")
            command = [shell, "-NoProfile", "-ExecutionPolicy", "Bypass",
                       "-File", "Server/scripts/Smoke.ps1"]
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
    arguments = parser.parse_args()
    if arguments.mongo_executable and not arguments.native_smoke:
        parser.error("--mongo-executable requires --native-smoke")
    if arguments.mongo_executable and os.name != "nt":
        parser.error("on Linux, set MONGOD for the native smoke script")

    try:
        stages = command_stages(arguments.native_smoke,
                                arguments.mongo_executable)
    except RuntimeError as error:
        parser.error(str(error))

    for index, (name, command) in enumerate(stages, start=1):
        print(f"[{index}/{len(stages)}] {name}: {' '.join(command)}", flush=True)
        if arguments.list:
            continue
        started = time.monotonic()
        environment = os.environ.copy()
        environment["PYTHONDONTWRITEBYTECODE"] = "1"
        try:
            result = subprocess.run(command, cwd=REPOSITORY,
                                    env=environment, check=False)
        except OSError as error:
            print(f"FAIL: {name}: {error}", file=sys.stderr, flush=True)
            return 1
        elapsed = time.monotonic() - started
        if result.returncode != 0:
            print(f"FAIL: {name} exited {result.returncode} after {elapsed:.1f}s",
                  file=sys.stderr, flush=True)
            return result.returncode
        print(f"PASS: {name} ({elapsed:.1f}s)", flush=True)

    if not arguments.list:
        print(f"PASS: all {len(stages)} selected Battle checkpoint stages", flush=True)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
