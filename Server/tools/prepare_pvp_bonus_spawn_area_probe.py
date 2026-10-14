"""Create a disposable Unity project for the ten recovered source boxes."""

import shutil
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]


def main():
    probe = Path(sys.argv[1]).resolve()
    if probe == ROOT or ROOT in probe.parents:
        raise ValueError("Use a disposable probe outside the repository")
    editor = probe / "Assets/Editor"
    settings = probe / "ProjectSettings"
    editor.mkdir(parents=True, exist_ok=True)
    settings.mkdir(parents=True, exist_ok=True)
    shutil.copyfile(ROOT / "Server/tools/UnityPvpBonusSpawnAreaAudit.cs",
                    editor / "UnityPvpBonusSpawnAreaAudit.cs")
    shutil.copyfile(ROOT / "Server/content/recovered-pvp-bonus-spawn-areas.json",
                    editor / "source-bonus-areas.json")
    (settings / "ProjectVersion.txt").write_text("m_EditorVersion: 2018.3.0f2\n",
                                                   encoding="utf-8")
    print("Prepared isolated Unity bonus area probe:", probe)


if __name__ == "__main__":
    main()
