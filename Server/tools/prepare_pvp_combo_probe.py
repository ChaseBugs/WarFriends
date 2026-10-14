"""Compile the recovered combo method in an isolated Unity Mono probe."""

import hashlib
import json
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
SCRIPTS = ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp"


def main():
    probe = Path(sys.argv[1]).resolve()
    if probe == ROOT or ROOT in probe.parents:
        raise ValueError("Use a disposable probe outside the repository")
    editor = probe / "Assets/Editor"
    editor.mkdir(parents=True, exist_ok=True)
    manager_bytes = (SCRIPTS / "SkillShotManager.cs").read_bytes()
    skill_bytes = (SCRIPTS / "SkillShot.cs").read_bytes()
    manager = manager_bytes.decode("utf-8-sig")
    start = manager.index("public void RecieveKill(ref SkillShot skillShot)")
    body = manager.index("{", start)
    depth = 1
    end = body + 1
    while depth:
        if manager[end] == "{":
            depth += 1
        if manager[end] == "}":
            depth -= 1
        end += 1
    method = manager[start:end]
    if method.count("Time.time") != 2:
        raise ValueError("Recovered combo clock reads changed")
    window = json.loads((ROOT / "Server/content/recovered-pvp-skillshot-scores.json").read_bytes())["comboWindowSeconds"]
    reference = (
        "public static class SourceComboClock { public static float time; }\n"
        "public sealed class SourceComboReference {\n"
        "private float mLastKillTime; private int mKillStreak;\n"
        f"public float timeForCombo = {window}f;\n"
        "public int Streak { get { return mKillStreak; } }\n"
        + method.replace("Time.time", "SourceComboClock.time") + "\n}\n"
    )
    reference += (
        "public static class SourceComboProvenance {\n"
        f'public const string ManagerHash = "{hashlib.sha256(manager_bytes).hexdigest()}";\n'
        f'public const string SkillHash = "{hashlib.sha256(skill_bytes).hexdigest()}";\n'
        "}\n"
    )
    (editor / "SourceComboReference.cs").write_text(reference, encoding="utf-8")
    (editor / "SkillShot.cs").write_bytes(skill_bytes)
    (editor / "SkipAttribute.cs").write_text(
        "namespace Beebyte.Obfuscator { public sealed class SkipAttribute : System.Attribute {} }\n",
        encoding="utf-8")
    (editor / "UnityPvpComboAudit.cs").write_bytes((ROOT / "Server/tools/UnityPvpComboAudit.cs").read_bytes())
    print("Prepared original combo method with only its clock reads substituted.")


if __name__ == "__main__":
    main()
