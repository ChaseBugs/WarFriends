"""Compile the original SpawnBonus selection prefix with controlled draws."""
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
    source_bytes = (ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/KillStreakManager.cs").read_bytes()
    original = method(source_bytes.decode("utf-8-sig"), "private void SpawnBonus(")
    selection = original[original.index("{") + 1:original.index("KillStreakBonus killStreakBonus3 =")]
    if selection.count("Random.Range(0f, num)") != 1:
        raise ValueError("Original selection draw changed")
    reference = '''using System.Collections.Generic;
public enum Fractions {Allies=1,Enemy=2}
public class PlayerController {public Fractions fraction;}
public class KillStreakBonus {public int index;public float weight;public float GetBonusProbability(PlayerController owner){return weight;}}
public static class SourceSelectionDraw {public static float value,total;public static int calls;
public static float Range(float minimum,float maximum){total=maximum;calls++;return value;}}
public class SourceSelectionResult {public int prefabIndex,sourceIndex;}
public class SourceSelectionReference {
public List<KillStreakBonus> bonusesPrefabs=new List<KillStreakBonus>();
private Queue<int> alliesBonusses=new Queue<int>(),enemyBonusses=new Queue<int>();
private int mLastBonusIndex;
public int LastIndex {get{return mLastBonusIndex;}}
public SourceSelectionReference(float[] weights,int last){mLastBonusIndex=last;
for(int index=0;index<weights.Length;index++)bonusesPrefabs.Add(new KillStreakBonus{index=index,weight=weights[index]});}
public void Enqueue(int index,Fractions side){(side==Fractions.Allies?alliesBonusses:enemyBonusses).Enqueue(index);}
public SourceSelectionResult Select(PlayerController owner) {
'''
    reference += selection.replace("Random.Range(0f, num)", "SourceSelectionDraw.Range(0f, num)")
    reference += "return new SourceSelectionResult{prefabIndex=killStreakBonus.index,sourceIndex=i};\n}\n}\n"
    reference += 'public static class SourceSelectionProvenance {public const string ManagerHash="' + hashlib.sha256(source_bytes).hexdigest() + '";}\n'
    (editor / "SourceSelectionReference.cs").write_text(reference, encoding="utf-8")
    (editor / "UnityPvpSelectionAudit.cs").write_bytes((ROOT / "Server/tools/UnityPvpSelectionAudit.cs").read_bytes())
    print("Prepared original SpawnBonus selection prefix; only its draw is substituted.")


if __name__ == "__main__":
    main()
