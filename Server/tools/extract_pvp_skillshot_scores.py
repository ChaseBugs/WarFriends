"""Recover all active PvP skill-shot score rows without changing Client assets."""

import hashlib
import json
import re
import extract_coop_skillshot_scores as source


def long_shot_distance(scene):
    start = scene.index("  skillShotItemDefinitions:\n")
    nearby = scene[start - 200:start]
    match = re.search(
        r"^  longShotKillDistance: (\d+(?:\.\d+)?)$", nearby, re.M)
    if not match or float(match.group(1)) != 6.0:
        raise ValueError("MainScene long-shot distance differs from the reviewed source")
    return float(match.group(1))


def main():
    scene_bytes = source.SCENE.read_bytes()
    content_bytes = source.CONTENT.read_bytes()
    sheet_bytes = source.SHEET_CODE.read_bytes()
    flag_bytes = source.SKILL_CODE.read_bytes()
    scene = scene_bytes.decode("utf-8-sig")
    content = json.loads(content_bytes)
    if content["mainSceneSha256"] != hashlib.sha256(scene_bytes).hexdigest():
        raise ValueError("PvP scores and battle content refer to different scenes")
    sheet = next(item for item in content["sheets"] if item["type"] == "Google2u.Skillshots")
    names = source.row_names(sheet_bytes.decode("utf-8-sig"))
    flags = source.skill_flags(flag_bytes.decode("utf-8-sig"))
    if len(sheet["rows"]) != len(names):
        raise ValueError("Skill-shot score and name tables differ")
    points_by_name = dict(zip(names, sheet["rows"]))
    rows = []
    for dictionary_id, flag in source.scene_items(scene):
        name = flags[flag]
        points = points_by_name[name]["SCOREMP"]
        if type(points) is not int or not 0 <= points <= 1_000_000:
            raise ValueError("Invalid source multiplayer score")
        rows.append({"flag": flag, "name": name, "dictionaryId": dictionary_id,
                     "multiplayerPoints": points})
    document = {
        "version": 1,
        "sceneSha256": hashlib.sha256(scene_bytes).hexdigest(),
        "battleContentSha256": hashlib.sha256(content_bytes).hexdigest(),
        "sheetCodeSha256": hashlib.sha256(sheet_bytes).hexdigest(),
        "skillCodeSha256": hashlib.sha256(flag_bytes).hexdigest(),
        "comboWindowSeconds": source.combo_window(scene),
        "longShotDistance": long_shot_distance(scene),
        "rows": rows,
    }
    path = source.ROOT / "Server/content/recovered-pvp-skillshot-scores.json"
    data = (json.dumps(document, indent=2) + "\n").encode("utf-8")
    path.write_bytes(data)
    print(f"Recovered {len(rows)} PvP score rows; SHA-256 {hashlib.sha256(data).hexdigest()}")


if __name__ == "__main__":
    main()
