"""Inventory migration candidates without changing recovered Client sources or serialized assets.

This is lexical source/attachment evidence, not a call graph, network trace or removal approval.
"""

import argparse
import hashlib
import json
import re
from collections import Counter
from pathlib import Path


REPOSITORY = Path(__file__).resolve().parents[2]
CLIENT = REPOSITORY / "Clients/ExportedProject"
GAMEPLAY = CLIENT / "Assets/Scripts/Assembly-CSharp"
PROVIDERS = (
    "GameLauncher", "PhotonConnectionManager", "FuseSDK", "GooglePlayGameService",
    "GameCenterProvider", "KochavaManager", "FacebookService", "PushNotificationManager",
)
CATEGORIES = {
    "photon_api": r"\bPhotonNetwork\.[A-Za-z_]\w*",
    "fuse_api": r"\bFuseSDK\.[A-Za-z_]\w*",
    "kochava_api": r"\bKochava\.[A-Za-z_]\w*",
    "google_play_api": r"\bPlayGamesPlatform\.[A-Za-z_]\w*",
    "aws_analytics_type": r"\b(?:MobileAnalyticsManager|AmazonMobileAnalyticsClient)\b",
    "social_api": r"\b(?:FB|FacebookAndroid|FacebookBinding|FacebookManager|GameCenterBinding)\.[A-Za-z_]\w*",
    "platform_service_api": (
        r"\b(?:Terms|Crittercism|GoogleIAB|StoreKitBinding|GoogleCloudMessaging|EtceteraAndroid)"
        r"\.[A-Za-z_]\w*"
    ),
}
MAXIMUM_EXAMPLES = 8


def relative(path):
    return path.relative_to(REPOSITORY).as_posix()


def source_identity(path):
    metadata = Path(str(path) + ".meta").read_text(encoding="utf-8-sig")
    match = re.search(r"^guid: ([0-9a-f]{32})$", metadata, re.MULTILINE)
    if not match:
        raise ValueError(f"Missing source GUID: {relative(path)}")
    return {
        "source": relative(path),
        "sha256": hashlib.sha256(path.read_bytes()).hexdigest(),
        "guid": match.group(1),
        "attachmentCounts": {},
        "attachmentExamples": [],
    }


def inventory_attachments(providers):
    by_guid = {row["guid"]: row for row in providers.values()}
    expression = re.compile(r"m_Script:\s*\{[^}\r\n]*guid: ([0-9a-f]{32})\b")
    scanned = Counter()
    skipped = {"count": 0, "examples": []}
    for extension in (".unity", ".prefab", ".asset"):
        for path in sorted((CLIENT / "Assets").rglob("*" + extension)):
            raw = path.read_bytes()
            if not raw.removeprefix(b"\xef\xbb\xbf").startswith(b"%YAML"):
                skipped["count"] += 1
                if len(skipped["examples"]) < MAXIMUM_EXAMPLES:
                    skipped["examples"].append(relative(path))
                continue
            scanned[extension] += 1
            text = raw.decode("utf-8-sig")
            for match in expression.finditer(text):
                provider = by_guid.get(match.group(1))
                if provider is None:
                    continue
                counts = provider["attachmentCounts"]
                counts[extension] = counts.get(extension, 0) + 1
                if len(provider["attachmentExamples"]) < MAXIMUM_EXAMPLES:
                    provider["attachmentExamples"].append({
                        "asset": relative(path),
                        "line": text.count("\n", 0, match.start()) + 1,
                    })
    return dict(scanned), skipped


def inventory_source_references():
    categories = {
        name: {"occurrences": 0, "files": set(), "examples": []}
        for name in CATEGORIES
    }
    patterns = {name: re.compile(pattern) for name, pattern in CATEGORIES.items()}
    paths = sorted(GAMEPLAY.glob("*.cs"))
    for path in paths:
        for line_number, line in enumerate(path.read_text(encoding="utf-8-sig").splitlines(), 1):
            for name, pattern in patterns.items():
                for match in pattern.finditer(line):
                    row = categories[name]
                    row["occurrences"] += 1
                    row["files"].add(relative(path))
                    if len(row["examples"]) < MAXIMUM_EXAMPLES:
                        row["examples"].append({
                            "source": relative(path), "line": line_number, "symbol": match.group(0),
                        })
    for row in categories.values():
        row["files"] = sorted(row["files"])
    return len(paths), categories


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output", type=Path, help="Optional inventory JSON destination.")
    arguments = parser.parse_args()
    providers = {
        name: source_identity(GAMEPLAY / (name + ".cs"))
        for name in PROVIDERS
    }
    assets, skipped = inventory_attachments(providers)
    source_count, categories = inventory_source_references()
    result = {
        "version": 1,
        "scope": "Top-level recovered Assembly-CSharp source; serialized Assets scene/prefab/asset attachments.",
        "limitations": [
            "Lexical matches may include comments or unreachable code; no reachability or network claim.",
            "Native plugins, SDK internals, manifest auto-initializers and DLL-based script types "
            "need separate audits.",
            "Attachment counts include inactive objects and unreferenced assets; examples are bounded.",
            "No credentials, endpoint values or source-line contents are copied into this inventory.",
        ],
        "sourceFilesScanned": source_count,
        "yamlFilesScanned": assets,
        "nonYamlFilesNotParsed": skipped,
        "providers": providers,
        "categories": categories,
    }
    encoded = json.dumps(result, indent=2, ensure_ascii=True) + "\n"
    if arguments.output:
        arguments.output.parent.mkdir(parents=True, exist_ok=True)
        arguments.output.write_text(encoded, encoding="utf-8", newline="\n")
        print(f"Inventoried {source_count} gameplay sources and {sum(assets.values())} serialized files.")
        for name, row in categories.items():
            print(f"{name}: {row['occurrences']} lexical references in {len(row['files'])} files")
    else:
        print(encoded, end="")


if __name__ == "__main__":
    main()
