#!/usr/bin/env python3
"""Ensure every literal MatchEngine terminal reason has a durable policy."""

from __future__ import annotations

import re
from pathlib import Path


SERVER_SOURCE = Path(__file__).resolve().parents[1] / "src"
END_REASON = re.compile(r'\bEnd\(\s*"([^"]+)"')
POLICY_SET = re.compile(
    r'HashSet<string>\s+(ScoredReasons|AbortedReasons).*?\{(.*?)\};',
    re.DOTALL,
)
STRING_LITERAL = re.compile(r'"([^"]+)"')


def main() -> int:
    engine_files = sorted((SERVER_SOURCE / "War.Battle.Simulation").rglob("MatchEngine*.cs"))
    emitted = {
        reason
        for source_file in engine_files
        for reason in END_REASON.findall(source_file.read_text(encoding="utf-8"))
    }
    policy_text = (SERVER_SOURCE / "War.Battle.Domain/Results/Validation/BattleTerminalPolicy.cs").read_text(
        encoding="utf-8")
    policy_sets = {
        name: set(STRING_LITERAL.findall(body))
        for name, body in POLICY_SET.findall(policy_text)
    }

    if not emitted or set(policy_sets) != {"ScoredReasons", "AbortedReasons"}:
        print("FAIL: terminal reason source or policy sets could not be read")
        return 1

    scored = policy_sets["ScoredReasons"]
    aborted = policy_sets["AbortedReasons"]
    missing = emitted - scored - aborted
    overlap = scored & aborted
    if missing or overlap:
        for reason in sorted(missing):
            print(f"FAIL: MatchEngine emits unregistered terminal reason: {reason}")
        for reason in sorted(overlap):
            print(f"FAIL: terminal reason belongs to both policy sets: {reason}")
        return 1

    print(f"PASS: {len(emitted)} MatchEngine terminal reasons have one durable policy")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
