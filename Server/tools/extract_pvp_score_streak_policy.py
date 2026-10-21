"""Pin source ScoreManager parameters; no Client asset changes."""
import hashlib
import json
import re
import argparse
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]


def build_document(scene_bytes, content_bytes):
    manager_bytes = (ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ScoreManager.cs").read_bytes()
    online_bytes = (ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerOnline.cs").read_bytes()
    levels_bytes = (ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LevelManager.cs").read_bytes()
    scene = scene_bytes.decode("utf-8-sig")
    content = json.loads(content_bytes)
    if content["mainSceneSha256"] != hashlib.sha256(scene_bytes).hexdigest():
        raise ValueError("Score policy and content refer to different scenes")
    matches = re.findall(r"^  killsStreakProgressLoss: ([0-9.]+)\r?$", scene, re.M)
    if len(matches) != 1:
        raise ValueError("Expected one ScoreManager decay binding")
    constants = [sheet for sheet in content["sheets"] if sheet["type"] == "Google2u.Constants"]
    if len(constants) != 1:
        raise ValueError("Expected one source Constants sheet")
    ratios = [row["FLOATVALUE"] for row in constants[0]["rows"]
              if row["DBKEY"] == "MultiPlayerScoreStreakRatio"]
    easy_bot_levels = [row["FLOATVALUE"] for row in constants[0]["rows"]
                       if row["DBKEY"] == "MatchmakingEasyBotTillLevel"]
    if len(ratios) != 1 or ratios[0] != 0.75 or float(matches[0]) != 1.1:
        raise ValueError("Reviewed PvP score-streak values changed")
    if easy_bot_levels != [4.0]:
        raise ValueError("Reviewed crate eligibility threshold changed")
    manager = manager_bytes.decode("utf-8-sig")
    for expression in ("Constants.rowIds.MultiPlayerScoreStreakRatio", "killStreakScoreRatio = 0f;",
                       "private const float KillStreakThreshold = 100f;",
                       "killStreakProgress > KillStreakThreshold", "killStreakProgress -= KillStreakThreshold;",
                       "killStreakProgressOpponent > KillStreakThreshold",
                       "killStreakProgressOpponent -= KillStreakThreshold;"):
        if expression not in manager:
            raise ValueError("Source score-streak transition changed")
    online = online_bytes.decode("utf-8-sig")
    levels = levels_bytes.decode("utf-8-sig")
    for expression in ("!LevelManager.isNoob", "mOtherPlayerInstance != null",
                       "mOtherPlayerInstance.playerProperties.level > (float)fLOATVALUE"):
        if expression not in online:
            raise ValueError("Source online crate eligibility changed")
    for expression in ("displayNumber => index + 1", "instance.currentLevel.displayNumber <= num"):
        if expression not in levels:
            raise ValueError("Source level display conversion changed")
    document = {
        "version": 1,
        "sceneSha256": hashlib.sha256(scene_bytes).hexdigest(),
        "battleContentSha256": hashlib.sha256(content_bytes).hexdigest(),
        "scoreManagerSha256": hashlib.sha256(manager_bytes).hexdigest(),
        "gameControllerOnlineSha256": hashlib.sha256(online_bytes).hexdigest(),
        "levelManagerSha256": hashlib.sha256(levels_bytes).hexdigest(),
        "matchmakingEasyBotTillLevel": 4,
        "multiplayerRatio": ratios[0],
        "progressLossPerSecond": float(matches[0]),
        "bonusThreshold": 100,
        "maximumBonusesPerUpdate": 1,
    }
    return document


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true")
    options = parser.parse_args()
    scene_bytes = (ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity").read_bytes()
    content_bytes = (ROOT / "Server/content/recovered-battle-content.json").read_bytes()
    data = (json.dumps(build_document(scene_bytes, content_bytes), indent=2) + "\n").encode("utf-8")
    output = ROOT / "Server/content/recovered-pvp-score-streak-policy.json"
    if options.check:
        if output.read_bytes() != data:
            raise ValueError("Checked-in PvP score-streak policy differs from current source")
    else:
        output.write_bytes(data)
    print("PvP score-streak policy SHA-256 " + hashlib.sha256(data).hexdigest())


if __name__ == "__main__":
    main()
