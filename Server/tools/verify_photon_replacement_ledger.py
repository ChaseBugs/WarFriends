#!/usr/bin/env python3
import json
import sys
from pathlib import Path

def main() -> int:
    audit_path = Path(sys.argv[1] if len(sys.argv) > 1 else "Server/docs/photon-runtime-audit.json")
    ledger_path = Path(sys.argv[2] if len(sys.argv) > 2 else "Server/docs/photon-replacement-ledger.json")
    audit = json.loads(audit_path.read_text(encoding="utf-8"))
    ledger = json.loads(ledger_path.read_text(encoding="utf-8"))
    actual = {(x["file"], x["line"], x["text"]) for x in audit["forbiddenRuntimeCalls"]}
    expected = {(x["file"], x["line"]) for x in ledger["calls"]}
    observed = {(x["file"], x["line"]) for x in audit["forbiddenRuntimeCalls"]}
    if expected != observed:
        print("Photon replacement ledger mismatch")
        print("missing:", sorted(observed - expected))
        print("stale:", sorted(expected - observed))
        return 1
    if any(x.get("status") != "open" for x in ledger["calls"]):
        print("Unexpected non-open migration status")
        return 1
    print(f"PASS: {len(actual)} audited Photon calls are represented in the replacement ledger")
    return 0

if __name__ == "__main__":
    raise SystemExit(main())
