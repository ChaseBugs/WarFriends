"""Pin the recovered 1.4.0 per-mission shield starting states."""

import argparse
import hashlib
import json
from pathlib import Path

from extract_mission_catalog import SCENE, component_lines


ROOT = Path(__file__).resolve().parents[2]
OUTPUT = ROOT / "Server/content/recovered-coop-shield-states.json"
MISSION_CATALOG = ROOT / "Server/content/recovered-mission-catalog.json"


def read_scene_data(lines):
    data_rows = [line.split("    DATA: ", 1)[1]
                 for line in lines if line.startswith("    DATA: ")]
    if len(data_rows) != 75:
        raise ValueError("Expected 75 mission DATA rows")
    for row in data_rows:
        if row.startswith("'") and row.endswith("'"):
            yield row[1:-1].replace("''", "'")
        elif row.startswith('"') and row.endswith('"'):
            yield json.loads(row)
        else:
            raise ValueError("Unknown MainScene YAML string encoding")


def shield_states(scene_data, field):
    states = scene_data.get(field, [])
    if not isinstance(states, list) or len(states) > 4:
        raise ValueError("Invalid mission shield state list")
    result = []
    for state in states:
        if not isinstance(state, dict) or set(state) - {
            "healthRatio", "maxHealthRatio", "regenerate", "autoRepair"
        }:
            raise ValueError("Invalid mission shield state fields")
        complete = {
            "healthRatio": state.get("healthRatio", 1),
            "maxHealthRatio": state.get("maxHealthRatio", 1),
            "regenerate": state.get("regenerate", True),
            "autoRepair": state.get("autoRepair", True),
        }
        if (not all(isinstance(complete[name], (int, float)) and
                    not isinstance(complete[name], bool) and
                    0 <= complete[name] <= 10
                    for name in ("healthRatio", "maxHealthRatio")) or
                not all(type(complete[name]) is bool
                        for name in ("regenerate", "autoRepair"))):
            raise ValueError(f"Invalid mission shield state value: {complete}")
        result.append(complete)
    return result


def build_document(scene_bytes, catalog_bytes):
    catalog = json.loads(catalog_bytes)
    if catalog["sourceSha256"] != hashlib.sha256(scene_bytes).hexdigest():
        raise ValueError("Mission catalog is bound to a different MainScene")
    if len(catalog["missions"]) != 75:
        raise ValueError("Shield states require the complete 75-mission catalog")
    rows = []
    lines = component_lines(scene_bytes.decode("utf-8-sig").splitlines())
    for index, raw in enumerate(read_scene_data(lines)):
        source = catalog["missions"][index]
        if source["index"] != index or source["sceneDataSha256"] != hashlib.sha256(
                raw.encode("utf-8")).hexdigest():
            raise ValueError("Mission DATA differs from the reviewed catalog")
        data = json.loads(raw)
        rows.append({
            "missionIndex": index,
            "player": shield_states(data, "playerShieldStates"),
            "bot": shield_states(data, "botShieldStates"),
        })
    return {"version": 1, "sourceSha256": catalog["sourceSha256"], "missions": rows}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true", help="Validate without writing production content")
    args = parser.parse_args()
    result = build_document(SCENE.read_bytes(), MISSION_CATALOG.read_bytes())
    expected = (json.dumps(result, indent=2, allow_nan=False) + "\n").encode("utf-8")
    if args.check:
        if not OUTPUT.exists() or OUTPUT.read_bytes() != expected:
            raise ValueError("Shield state artifact differs from MainScene")
        print("Verified 75 co-op shield state rows")
    else:
        OUTPUT.write_bytes(expected)
        print("Extracted 75 co-op shield state rows")


if __name__ == "__main__":
    main()
