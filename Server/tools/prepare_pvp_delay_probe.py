"""Exercise original GenerateNewBonus/WaitAndCall in a disposable Play Mode."""
import hashlib
import sys
from pathlib import Path
from prepare_pvp_progress_probe import method

ROOT = Path(__file__).resolve().parents[2]


def main():
    probe = Path(sys.argv[1]).resolve()
    if probe == ROOT or ROOT in probe.parents:
        raise ValueError("Use a disposable probe outside the repository")
    assets = probe / "Assets"
    editor = assets / "Editor"
    editor.mkdir(parents=True, exist_ok=True)
    manager_bytes = (ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/KillStreakManager.cs").read_bytes()
    core_bytes = (ROOT / "Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs").read_bytes()
    manager = manager_bytes.decode("utf-8-sig")
    core = core_bytes.decode("utf-8-sig")
    source = "using System;using System.Collections;using UnityEngine;\npublic class SourceDelayReference:MonoBehaviour {\n"
    source += "public Action<PlayerController> callback;public object killStreakBonusBoxPrefab;private void SpawnBonus(PlayerController owner){callback(owner);}\n"
    source += method(manager, "public void GenerateNewBonus(") + "\n"
    source += method(core, "public void InvokeAfter(") + "\n"
    source += method(core, "private static IEnumerator WaitAndCall(") + "\n"
    source += method(manager, "private void InstanceOnGameEnded(") + "\n"
    source += "public void EndGame(){InstanceOnGameEnded(GameController.GameEndReason.Ended);}\n}\n"
    source += "public class PlayerController {public int id;}\npublic class GameController {public enum GameEndReason {Ended}}\n"
    source += "public static class ObjectPoolDatabase {public static SourcePool networkPool=new SourcePool();}\npublic class SourcePool {public int frees;public void FreeObjectsWithPrefab(object prefab){frees++;}}\n"
    source += 'public static class SourceDelayProvenance {public const string ManagerHash="' + hashlib.sha256(manager_bytes).hexdigest() + '";'
    source += 'public const string CoreHash="' + hashlib.sha256(core_bytes).hexdigest() + '";}\n'
    (assets / "SourceDelayReference.cs").write_text(source, encoding="utf-8")
    (assets / "SourceDelayRunner.cs").write_bytes((ROOT / "Server/tools/SourceDelayRunner.cs").read_bytes())
    (editor / "UnityPvpDelayAudit.cs").write_bytes((ROOT / "Server/tools/UnityPvpDelayAudit.cs").read_bytes())
    print("Prepared original coroutine and game-end handler for isolated Play Mode.")


if __name__ == "__main__":
    main()
