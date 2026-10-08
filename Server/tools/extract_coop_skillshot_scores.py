"""Pin mission skill-shot point rows from the recovered 1.4.0 Client."""

import hashlib
import json
import re
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
SCENE = ASSETS / "Scenes/MainScene.unity"
SHEET_CODE = ASSETS / "Plugins/Assembly-CSharp-firstpass/Google2u/Skillshots.cs"
SKILL_CODE = ASSETS / "Scripts/Assembly-CSharp/SkillShot.cs"
CONTENT = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-coop-skillshot-scores.json"


def row_names(source):
    match = re.search(r"public string\[\] rowNames = new string\[20\]\s*\{(.*?)\}",
                      source, re.S)
    if not match:
        raise ValueError("Skillshots row-name table changed")
    names = re.findall(r'"([A-Za-z]+)"', match.group(1))
    if len(names) != 20 or len(set(names)) != 20:
        raise ValueError("Expected 20 unique skill-shot sheet names")
    return names


def skill_flags(source):
    body = re.search(r"enum SkillShotType\s*\{(.*?)\}", source, re.S)
    if not body:
        raise ValueError("SkillShotType enum changed")
    flags = {}
    for name, raw in re.findall(r"(\w+)\s*=\s*(0x[0-9A-Fa-f]+|\d+)", body.group(1)):
        flags[int(raw, 0)] = name
    if len(flags) != 20 or 4096 not in flags:
        raise ValueError("Skill-shot flags changed")
    return flags


def scene_items(source):
    start = source.index("  skillShotItemDefinitions:\n")
    end = source.index("  objectPool:", start)
    block = source[start:end]
    items = []
    for entry in re.split(r"(?=^  - dictionaryId: )", block, flags=re.M):
        if not entry.startswith("  - dictionaryId: "):
            continue
        dictionary_id = re.search(r"^  - dictionaryId: (\S+)$", entry, re.M)
        flag = re.search(r"^    skillShotType: (\d+)$", entry, re.M)
        if not dictionary_id or not flag:
            raise ValueError("Incomplete scene skill-shot definition")
        items.append((dictionary_id.group(1), int(flag.group(1))))
    if len(items) != 19 or len({flag for _, flag in items}) != len(items):
        raise ValueError("Expected 19 unique active scene skill shots")
    return items


def main():
    scene_bytes = SCENE.read_bytes()
    content_bytes = CONTENT.read_bytes()
    sheet_bytes = SHEET_CODE.read_bytes()
    flag_bytes = SKILL_CODE.read_bytes()
    scene = scene_bytes.decode("utf-8-sig")
    content = json.loads(content_bytes)
    if content["mainSceneSha256"] != hashlib.sha256(scene_bytes).hexdigest():
        raise ValueError("Battle content is bound to a different MainScene")
    sheet = next(row for row in content["sheets"]
                 if row["type"] == "Google2u.Skillshots")
    names = row_names(sheet_bytes.decode("utf-8-sig"))
    flags = skill_flags(flag_bytes.decode("utf-8-sig"))
    if len(sheet["rows"]) != len(names):
        raise ValueError("Skill-shot sheet and name table differ")
    points = dict(zip(names, sheet["rows"]))
    rows = []
    for dictionary_id, flag in scene_items(scene):
        name = flags.get(flag)
        if name not in points:
            raise ValueError("Scene skill shot is absent from its source sheet")
        value = points[name]["SCORESINGLE"]
        if not isinstance(value, int) or value < 0 or value > 1_000_000:
            raise ValueError("Invalid mission skill-shot score")
        rows.append({"flag": flag, "name": name,
                     "dictionaryId": dictionary_id, "missionPoints": value})
    document = {
        "version": 1,
        "sceneSha256": hashlib.sha256(scene_bytes).hexdigest(),
        "battleContentSha256": hashlib.sha256(content_bytes).hexdigest(),
        "sheetCodeSha256": hashlib.sha256(sheet_bytes).hexdigest(),
        "skillCodeSha256": hashlib.sha256(flag_bytes).hexdigest(),
        "rows": rows,
    }
    expected = json.dumps(document, indent=2) + "\n"
    if "--check" in sys.argv:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != expected:
            raise ValueError("Skill-shot scores differ from recovered Client")
        print("Verified 19 mission skill-shot score rows")
    else:
        OUTPUT.write_text(expected, encoding="utf-8")
        print("Extracted 19 mission skill-shot score rows")


if __name__ == "__main__":
    main()
