"""Inventory remaining Photon source/type/asset dependencies, including the retained Plugins layer."""
import json
import re
from collections import Counter
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"


def main():
    sources = []
    identities = {}
    calls = Counter()
    for path in sorted(ASSETS.rglob("*.cs")):
        text = path.read_text(encoding="utf-8-sig")
        tokens = re.findall(r"\bPhoton\w*\b|\bPunRPC\b|ExitGames\.Client\.Photon", text)
        if not tokens:
            continue
        relative = path.relative_to(ROOT).as_posix()
        sources.append({"path": relative, "references": len(tokens),
                        "types": sorted(set(tokens)), "retainedPlugin": "Plugins" in path.parts})
        calls.update(re.findall(r"\bPhotonNetwork\.([A-Za-z_]\w*)", text))
        metadata = Path(str(path) + ".meta")
        if metadata.is_file() and path.stem.startswith("Photon"):
            match = re.search(r"^guid: ([0-9a-f]{32})$", metadata.read_text(), re.MULTILINE)
            if match:
                identities[match.group(1)] = relative
    attachments = []
    for path in sorted(ASSETS.rglob("*")):
        if path.suffix not in {".unity", ".prefab", ".asset"}:
            continue
        text = path.read_text(encoding="utf-8", errors="replace")
        for guid, source in identities.items():
            count = len(re.findall(r"m_Script:\s*\{[^}\n]*guid: " + guid + r"\b", text))
            if count:
                attachments.append({"asset": path.relative_to(ROOT).as_posix(), "source": source, "count": count})
    report = {"scope": "Active 1.4.0 Client, including Plugins; lexical inventory, not runtime proof",
              "photonAssemblyRemoved": False, "sourceFiles": len(sources),
              "applicationSourceFiles": sum(not row["retainedPlugin"] for row in sources),
              "componentAttachments": sum(row["count"] for row in attachments),
              "apiReferences": dict(sorted(calls.items())), "sources": sources, "attachments": attachments}
    output = ROOT / "Server/docs/photon-migration-inventory.json"
    output.write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({key: report[key] for key in
                     ("sourceFiles", "applicationSourceFiles", "componentAttachments", "photonAssemblyRemoved")}))


if __name__ == "__main__":
    main()
