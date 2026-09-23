#!/usr/bin/env python3
"""Audit the recovered Client for Photon runtime calls.

The recovered project may retain Photon assemblies so serialized component types
continue to resolve.  This audit therefore reports references, but only fails
for service/room calls that would contact Photon at runtime.
"""
from __future__ import annotations

import argparse
import json
import re
from pathlib import Path

FORBIDDEN = re.compile(
    r"\b(?:PhotonNetwork\.(?:Connect|ConnectUsingSettings|Join|Create|Leave|Disconnect|JoinRandom|JoinOrCreate|Instantiate|RaiseEvent)|"
    r"PhotonServerSettings|CloudRegionCode|LoadBalancingClient\.Connect|OpJoin|OpCreateRoom|OpRaiseEvent)\b"
)
PHOTON = re.compile(r"\bPhoton(?:Network|View|TransformView|RigidbodyView|AnimatorView|ServerSettings|Peer|Realtime|Pun|HashTable)\b|Photon3Unity3D")


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("project", type=Path, nargs="?", default=Path("Clients/ExportedProject"))
    parser.add_argument("--json", action="store_true")
    args = parser.parse_args()
    root = args.project
    references: list[dict[str, object]] = []
    forbidden: list[dict[str, object]] = []
    extensions = {".cs", ".unity", ".prefab", ".asset", ".json", ".asmdef", ".txt"}
    for path in root.rglob("*"):
        if not path.is_file() or path.suffix.lower() not in extensions:
            continue
        # The retained Photon implementation itself necessarily contains service
        # symbols; it is a type-resolution compatibility payload, not the
        # application's runtime integration boundary.
        if "Assets" in path.parts and "Plugins" in path.parts:
            continue
        if any(part.lower() in {"quarantinedrecoveredsources", "decompiledcsharp"} for part in path.parts):
            continue
        try:
            text = path.read_text(encoding="utf-8", errors="replace")
        except OSError:
            continue
        for number, line in enumerate(text.splitlines(), 1):
            if not PHOTON.search(line):
                continue
            item = {"file": str(path.relative_to(root)).replace("\\", "/"), "line": number, "text": line.strip()[:240]}
            references.append(item)
            if FORBIDDEN.search(line) and path.name not in {"PhotonServerSettings.asset"}:
                forbidden.append(item)
    report = {"project": str(root), "photonReferences": len(references), "forbiddenRuntimeCalls": forbidden, "pass": not forbidden}
    if args.json:
        print(json.dumps(report, indent=2))
    else:
        print(f"Photon references: {len(references)}")
        print(f"Forbidden runtime calls: {len(forbidden)}")
        for item in forbidden:
            print(f"{item['file']}:{item['line']}: {item['text']}")
    return 0 if not forbidden else 1


if __name__ == "__main__":
    raise SystemExit(main())
