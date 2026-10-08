"""Check Unity shot-rotation oracle provenance and three source branches."""

import hashlib
import json
import math
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
REFERENCE = ROOT / "Server/content/coop-assaulter-shot-rotation-reference.json"


def sha256(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def main():
    data = json.loads(REFERENCE.read_text())
    assert data["version"] == 1 and data["unity"] == "2018.3.0f2"
    assert data["enemyControllerSha256"] == sha256(
        ASSETS / "Scripts/Assembly-CSharp/EnemyController.cs")
    assert data["geometryToolsSha256"] == sha256(
        ASSETS / "Plugins/Assembly-CSharp-firstpass/GeometryTools.cs")
    assert [row["name"] for row in data["cases"]] == [
        "obstacle", "corner-right", "corner-left"]
    assert [row["tweenSeconds"] for row in data["cases"]] == [
        0.2, 0.3, 0.3]
    assert [row["signedAngle"] for row in data["cases"]] == [
        0, 90, -90]
    for row in data["cases"]:
        assert len(row["enemy"]) == len(row["target"]) == 3
        assert len(row["direction"]) == 3
        assert len(row["rotation"]) == 4
        assert all(math.isfinite(value) for value in
                   row["enemy"] + row["target"] + row["direction"] +
                   row["rotation"])
        assert abs(sum(value * value for value in row["rotation"]) - 1) < 0.001
    print("PASS: source-bound obstacle and both corner final shot rotations")


if __name__ == "__main__":
    main()
