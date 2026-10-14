"""Compile recovered probability overrides in an isolated Mono probe."""
import hashlib
import sys
from pathlib import Path
from prepare_pvp_progress_probe import method

ROOT = Path(__file__).resolve().parents[2]


def main():
    probe = Path(sys.argv[1]).resolve()
    if probe == ROOT or ROOT in probe.parents:
        raise ValueError("Use a disposable probe outside the repository")
    editor = probe / "Assets/Editor"
    editor.mkdir(parents=True, exist_ok=True)
    scripts = ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp"
    reference = "using System.Collections.Generic; using UnityEngine; using Google2u;\npublic class SourceNamedObject {public string name;}\n"
    for name in ["KillStreakBonus", "KillStreakBonusAddCredits", "KillStreakBonusAddMoney", "KillStreakBonusCard", "KillStreakBonusAddAmmo"]:
        source = (scripts / (name + ".cs")).read_text(encoding="utf-8-sig")
        signature = "public virtual float GetBonusProbability(" if name == "KillStreakBonus" else "public override float GetBonusProbability("
        parent = " : SourceNamedObject {" if name == "KillStreakBonus" else " : KillStreakBonus {"
        reference += "public class " + name + parent + method(source, signature) + "}\n"
    level = (scripts / "LevelManager.cs").read_text(encoding="utf-8-sig")
    reference += "public class LevelManager {public static LevelManager instance=new LevelManager(); public Level currentLevel=new Level();"
    reference += method(level, "public float InterpolateNumbersBasedOnLevel(") + "}\n"
    analytics = (scripts / "PlayerAnalytics.cs").read_text(encoding="utf-8-sig")
    reference += "public class PlayerAnalytics {public static PlayerAnalytics instance=new PlayerAnalytics();public AnalyticsData data=new AnalyticsData();"
    reference += method(analytics, "public bool IsAllowedGoldBonus") + method(analytics, "public bool IsAllowedMoneyBonus") + "}\n"
    reference += '''public class Level {public int displayNumber;}
public class AnalyticsData {public int goldBonuses;}
public class Singleton<T> where T:new() {public static T instance=new T();}
public class GameController {public enum GameType {DeathMatch,WarArena} public GameType gameType;public bool isWarArena,isRandomMatchMaking;}
public class GameVariables {public Constants constants=new Constants();public CardConstants cardConstants=new CardConstants();public BonussesDefinitions bonussesDefinitions=new BonussesDefinitions();}
public class KillStreakManager {public Crates crates=new Crates();}
public class PlayerController {public PlayerProperties playerProperties=new PlayerProperties();public WeaponInventory weaponInventory=new WeaponInventory();}
public class PlayerProperties {public int level;}
public class WeaponInventory {public List<PlayerWeapon> usedWeapons=new List<PlayerWeapon>();}
public class PlayerWeapon {public Weapon weapon=new Weapon();}
public class Weapon {public bool hasLowAmmo;}
namespace Google2u {
public class FloatRow {public float FLOATVALUE;}
public class Constants {public enum rowIds {GoldCrateLowLevelProbability} public float value;public FloatRow GetRow(rowIds id){return new FloatRow{FLOATVALUE=value};}}
public class CardConstants {public enum rowIds {WarcardsUnlockLevel} public float value;public FloatRow GetRow(rowIds id){return new FloatRow{FLOATVALUE=value};}}
public class BonussesDefinitions {public enum rowIds {AmmoCrateOnLowAmmoRatio} public float value;public FloatRow GetRow(rowIds id){return new FloatRow{FLOATVALUE=value};}}
public class CratesRow {public float PROBABILITY,PROBABILITYARENA;}
public class Crates {public Dictionary<string,CratesRow> rows=new Dictionary<string,CratesRow>();public CratesRow GetRow(string name){CratesRow row;return rows.TryGetValue(name,out row)?row:null;}}
}
'''
    files = ["KillStreakBonus", "KillStreakBonusAddCredits", "KillStreakBonusAddMoney", "KillStreakBonusCard", "KillStreakBonusAddAmmo", "KillStreakBonusGrenades", "LevelManager", "PlayerAnalytics"]
    identity = "\n".join(name + ":" + hashlib.sha256((scripts / (name + ".cs")).read_bytes()).hexdigest() for name in files)
    reference += 'public static class SourceBonusProvenance {public const string CodeHash="' + hashlib.sha256(identity.encode()).hexdigest() + '";}\n'
    (editor / "SourceBonusReference.cs").write_text(reference, encoding="utf-8")
    (editor / "UnityPvpBonusAudit.cs").write_bytes((ROOT / "Server/tools/UnityPvpBonusAudit.cs").read_bytes())
    (editor / "source-bonus-catalog.json").write_bytes((ROOT / "Server/content/recovered-pvp-bonus-catalog.json").read_bytes())
    print("Prepared original probability overrides, rank interpolation and analytics gates.")


if __name__ == "__main__":
    main()
