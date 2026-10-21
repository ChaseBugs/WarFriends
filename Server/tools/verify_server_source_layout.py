#!/usr/bin/env python3
"""Require every recorded source move and keep host roots free of implementation files."""

import json
import re
from collections import Counter
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
EXPECTED_MOVES = {"War.Backend": 28, "War.BattleServer": 659}
EXPECTED_EXTRACTIONS = (632, 915)
EXTRACTION_SOURCES = {"War.BattleServer", "War.Infrastructure"}
EXTRACTION_TARGETS = {"War.Battle.Domain", "War.Battle.Simulation", "War.Infrastructure"}
CLEAN_LIBRARY_ROOTS = {"War.Battle.Domain", "War.Battle.Simulation"}


def checked_source_path(root: Path, value: object, projects: set[str], require_feature_folder: bool = False) -> Path:
    if not isinstance(value, str):
        raise ValueError("A source path must be text.")
    path = root / value
    relative = path.resolve().relative_to(root.resolve())
    if (relative.as_posix() != value or len(relative.parts) < 4
            or relative.parts[:2] != ("Server", "src") or relative.parts[2] not in projects
            or path.suffix != ".cs"
            or (require_feature_folder and len(relative.parts) < 5)):
        raise ValueError("A source path is outside its declared project boundary.")
    return path


def validate_extractions(root: Path, manifest: dict, expected: tuple[int, int]) -> tuple[dict, list[str]]:
    failures = []
    origins = {}
    targets = set()
    if (not isinstance(manifest, dict)
            or set(manifest) != {"schemaVersion", "description", "extractions"}
            or type(manifest.get("schemaVersion")) is not int or manifest["schemaVersion"] != 1
            or not isinstance(manifest.get("description"), str)
            or not isinstance(manifest.get("extractions"), list)):
        return {}, ["Invalid project extraction manifest."]
    for entry in manifest["extractions"]:
        try:
            if (not isinstance(entry, dict)
                    or set(entry) != {"from", "to", "sourceRemains", "originalSha256"}
                    or type(entry["sourceRemains"]) is not bool
                    or not isinstance(entry["to"], list) or not 1 <= len(entry["to"]) <= 128
                    or not isinstance(entry["originalSha256"], str)
                    or not re.fullmatch(r"[0-9a-f]{64}", entry["originalSha256"])):
                raise ValueError("Invalid extraction identity or provenance.")
            source = checked_source_path(root, entry["from"], EXTRACTION_SOURCES)
            if entry["from"] in origins or source.is_file() != entry["sourceRemains"]:
                raise ValueError("Duplicated, reversed or missing extraction source.")
            origins[entry["from"]] = entry
            for destination in entry["to"]:
                target = checked_source_path(root, destination, EXTRACTION_TARGETS, require_feature_folder=True)
                if destination in targets or not target.is_file():
                    raise ValueError("Duplicated or missing extraction target.")
                targets.add(destination)
        except (KeyError, TypeError, ValueError):
            failures.append(f"Invalid project extraction: {entry}")
    if (len(origins), len(targets)) != expected:
        failures.append(f"Project extraction inventory differs: {len(origins)} sources, {len(targets)} targets.")
    return origins, failures


def main() -> int:
    manifest = json.loads((ROOT / "Server/docs/server-source-layout.json").read_text(encoding="utf-8"))
    extraction_manifest = json.loads((ROOT / "Server/docs/battle-project-extraction.json").read_text(encoding="utf-8"))
    extractions, failures = validate_extractions(ROOT, extraction_manifest, EXPECTED_EXTRACTIONS)
    destinations = set()
    counts = Counter()
    if manifest.get("schemaVersion") != 1:
        failures.append("Unsupported source layout schema.")
    for move in manifest["moves"]:
        source = ROOT / move["from"]
        target = ROOT / move["to"]
        project = ROOT / "Server/src" / source.parts[-2]
        counts[project.name] += 1
        if (project.name not in EXPECTED_MOVES or source.parent != project
                or source.suffix != ".cs" or target.name != source.name
                or not target.resolve().is_relative_to(project.resolve())
                or not re.fullmatch(r"[0-9a-f]{64}", move["originalSha256"])):
            failures.append(f"Invalid move boundary: {move['from']}")
        extracted = move["to"] in extractions and not extractions[move["to"]]["sourceRemains"]
        if source.exists() or (not target.is_file() and not extracted) or move["to"] in destinations:
            failures.append(f"Missing, duplicate, or reversed source move: {move['to']}")
        destinations.add(move["to"])
    if counts != EXPECTED_MOVES:
        failures.append(f"Source move inventory differs: {dict(counts)}")
    for name in ("War.Backend", "War.BattleServer"):
        project = ROOT / "Server/src" / name
        for path in project.glob("*.cs"):
            if path.name != "Program.cs":
                failures.append(f"Implementation file in host root: {path.name}")
    for name in CLEAN_LIBRARY_ROOTS:
        for path in (ROOT / "Server/src" / name).glob("*.cs"):
            failures.append(f"Implementation file in library root: {path.name}")
    if failures:
        print("\n".join("FAIL: " + failure for failure in failures))
        return 1
    print(f"PASS: {len(destinations)} root moves and {len(extractions)} project extractions; host/library roots are clean")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
