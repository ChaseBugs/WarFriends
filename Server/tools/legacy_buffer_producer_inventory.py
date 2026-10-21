"""Inventory literal result dispositions in the explicit legacy planner methods.

This is a drift guard for the reviewed producer test matrix, not a C# coverage collector.
Fixtures must independently arrange the guards responsible for each observed result.
"""

from __future__ import annotations

import re
from pathlib import Path


def planner_result_sets(repository: Path, actions: list[str]) -> dict[str, list[str]]:
    folder = repository / "Server/src/War.Backend/Legacy/Buffering"
    files = sorted(folder.rglob("*.cs"))
    if not files:
        raise ValueError("The buffered producer source tree is missing.")
    source = "\n".join(path.read_text(encoding="utf-8") for path in files)
    # The inspected methods contain ordinary string literals, comments and balanced block bodies.
    # Refuse verbatim/raw literals rather than silently claiming this small scanner understands them.
    if re.search(r'@"|"""', source):
        raise ValueError("Review the producer inventory scanner before using new C# literal syntax.")
    source = re.sub(r'//[^\n]*|/\*[\s\S]*?\*/|"(?:\\.|[^"\\])*"', " ", source)
    bodies = {}
    declarations = r"(?:private|internal|public) static \(DatabaseResult, JsonObject\) (\w+)\("
    for match in re.finditer(declarations, source):
        end, depth = match.end(), 1
        while depth:
            depth += (source[end] == "(") - (source[end] == ")")
            end += 1
        start = end
        while source[start].isspace():
            start += 1
        if source.startswith("=>", start):
            end = source.index(";", start) + 1
        elif source[start] == "{":
            end, depth = start + 1, 1
            while depth:
                depth += (source[end] == "{") - (source[end] == "}")
                end += 1
        else:
            raise ValueError(f"Unsupported planner method body: {match[1]}")
        if match[1] in bodies:
            raise ValueError(f"Duplicate planner method: {match[1]}")
        bodies[match[1]] = source[start:end]

    def results(name: str, visited: frozenset[str] = frozenset()) -> set[str]:
        if name in visited:
            return set()
        body = bodies[name]
        found = set(re.findall(r"DatabaseResult\.(\w+)", body))
        for helper in bodies:
            if re.search(r"\b" + helper + r"\s*\(", body):
                found |= results(helper, visited | {name})
        return found

    return {action: sorted(results(action)) for action in sorted(actions)}
