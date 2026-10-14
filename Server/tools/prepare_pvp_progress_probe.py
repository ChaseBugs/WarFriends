"""Run recovered score gain/Update methods in a disposable Unity Mono probe."""
import hashlib
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]


def method(source, signature):
    start = source.index(signature)
    end = source.index("{", start) + 1
    depth = 1
    while depth:
        depth += (source[end] == "{") - (source[end] == "}")
        end += 1
    return source[start:end]


def main():
    probe = Path(sys.argv[1]).resolve()
    if probe == ROOT or ROOT in probe.parents:
        raise ValueError("Use a disposable probe outside the repository")
    editor = probe / "Assets/Editor"
    editor.mkdir(parents=True, exist_ok=True)
    scripts = ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp"
    manager_bytes = (scripts / "ScoreManager.cs").read_bytes()
    source = manager_bytes.decode("utf-8-sig")
    gain = method(source, "public void AddSkillshot(")
    update = method(source, "protected void Update()")
    if update.count("Time.deltaTime") != 3:
        raise ValueError("Source Update clock reads changed")
    reference = '''using System; using System.Collections.Generic; using UnityEngine;
public static class SourceScoreClock { public static float deltaTime; }
public class SourceScoreReference {
public int score, opponentScore; public float killsStreakProgressLoss = 1.1f;
public float killStreakScoreRatio = .75f, bonusMultiplier = 1f, bonusMultiplierEnemy = 1f;
public float killStreakProgress {get; private set;} public float killStreakProgressOpponent {get; private set;}
public bool isNewKillStreak; public AudioClip skillStreakSound;
private float mTimeFromStart; private int mTenSeconds;
private List<int> mKilledEnemiesInXSeconds = new List<int>{0};
private List<int> mScoreOverTime = new List<int>{0};
public Dictionary<SkillShot.SkillShotType,int> skillShotCounts = new Dictionary<SkillShot.SkillShotType,int>{{SkillShot.SkillShotType.Kill,0}};
public Dictionary<SkillShot.SkillShotType,int> skillShotCountsOponent = new Dictionary<SkillShot.SkillShotType,int>{{SkillShot.SkillShotType.Kill,0}};
public void SetProgress(float local, float opponent) {killStreakProgress=local;killStreakProgressOpponent=opponent;}
public void Frame(float delta, bool running) {SourceScoreClock.deltaTime=delta;Singleton<GameController>.instance.gameIsRunning=running;Update();}
'''
    reference += gain + "\n" + update.replace("Time.deltaTime", "SourceScoreClock.deltaTime") + "\n}\n"
    reference += '''public class Singleton<T> where T:new() {public static T instance=new T();}
public class PlayerController {public bool isCurrentPlayer;public static PlayerController currentPlayer=new PlayerController{isCurrentPlayer=true};}
public class GameController {public bool gameIsRunning;public PlayerController opponent=new PlayerController();}
public class SkillShotManager {public class SkillShotItemDefinition {public SkillShot.SkillShotType skillShotType;public int points;}}
public class KillStreakManager {public int localBonuses, opponentBonuses;
public void GenerateNewBonus(PlayerController player) {if(player.isCurrentPlayer)localBonuses++;else opponentBonuses++;}}
public class SoundsManager {public static SoundsManager Instance=new SoundsManager();public void PlaySound(AudioClip clip){}}
'''
    reference += 'public static class SourceScoreProvenance { public const string ManagerHash="' + hashlib.sha256(manager_bytes).hexdigest() + '"; }\n'
    (editor / "SourceScoreReference.cs").write_text(reference, encoding="utf-8")
    (editor / "SkillShot.cs").write_bytes((scripts / "SkillShot.cs").read_bytes())
    (editor / "SkipAttribute.cs").write_text("namespace Beebyte.Obfuscator { public sealed class SkipAttribute:System.Attribute {} }", encoding="utf-8")
    (editor / "UnityPvpProgressAudit.cs").write_bytes((ROOT / "Server/tools/UnityPvpProgressAudit.cs").read_bytes())
    print("Prepared original AddSkillshot and Update with controlled delta-time reads.")


if __name__ == "__main__":
    main()
