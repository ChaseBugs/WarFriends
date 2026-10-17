"""Restore the exact LevelManager lists from the matching APK/OBB Mono payload.

Only this component's missing custom payload is written. Existing Unity headers,
script GUIDs, object IDs and the original pointer ordering are retained.
"""
import argparse
import hashlib
import importlib.metadata
import json
import re
import zipfile
from pathlib import Path

import UnityPy
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator

ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
SCENE = ASSETS / "Scenes/MainScene.unity"
COMPONENT_ID = 45847
EXPECTED_OBB_HASH = "078cd1c4ebaeef4a39646274a54d35ce05741bc15a2e13d95ae55340711b5125"
EXPECTED_COUNTS = {"weaponLevelsSetups": 66, "behaviours": 24, "additionalBehaviours": 3}
BLOCK = re.compile(r"--- !u!(\d+) &(-?\d+)\n.*?(?=\n--- !u!|\Z)", re.S)


def digest(data):
    return hashlib.sha256(data).hexdigest()


def read_split(archive, basename):
    prefix = "assets/bin/Data/" + basename
    if prefix in archive.namelist():
        return archive.read(prefix)
    parts = [name for name in archive.namelist() if name.startswith(prefix + ".split")]
    parts.sort(key=lambda name: int(name.rsplit(".split", 1)[1]))
    if not parts or [int(name.rsplit(".split", 1)[1]) for name in parts] != list(range(len(parts))):
        raise ValueError("Missing or non-contiguous original file: " + basename)
    return b"".join(archive.read(name) for name in parts)


def read_original():
    apk_path = ROOT / "WarFriends 1.4.0.apk"
    obb_path = ROOT / "main.14008.com.chillingo.warfriends.android.gplay.obb"
    if digest(obb_path.read_bytes()) != EXPECTED_OBB_HASH:
        raise ValueError("The OBB does not match the active 1.4.0 package.")
    with zipfile.ZipFile(apk_path) as apk, zipfile.ZipFile(obb_path) as obb:
        environment = UnityPy.Environment()
        scene = environment.load_file(read_split(obb, "level0"), name="level0")
        if scene.unity_version != "5.2.5f1":
            raise ValueError("Unexpected original scene version.")
        loaded = {"level0": scene}

        def script_type(component):
            header = component.read_typetree(check_read=False)
            pointer = header["m_Script"]
            name = scene.externals[pointer["m_FileID"] - 1].name if pointer["m_FileID"] else "level0"
            if name not in loaded:
                archive = apk if "assets/bin/Data/" + name + ".split0" in apk.namelist() else obb
                loaded[name] = environment.load_file(read_split(archive, name), name=name)
            script = loaded[name].objects[pointer["m_PathID"]]
            if script.type.name != "MonoScript":
                raise ValueError("Original script pointer has the wrong type.")
            return script.read_typetree()

        component = scene.objects[COMPONENT_ID]
        definition = script_type(component)
        if definition["m_ClassName"] != "LevelManager" or definition["m_AssemblyName"] != "Assembly-CSharp.dll":
            raise ValueError("Original component identity differs.")
        generator = TypeTreeGenerator(scene.unity_version)
        for assembly in (ROOT / "Clients/AuxiliaryFiles/GameAssemblies").glob("*.dll"):
            if assembly.name == "P31RestKit 1.dll":
                continue
            data = assembly.read_bytes()
            if data != apk.read("assets/bin/Data/Managed/" + assembly.name):
                raise ValueError("Reference assembly differs from the APK: " + assembly.name)
            generator.load_dll(data)
        nodes = json.loads(generator.get_nodes_as_json("Assembly-CSharp.dll", "LevelManager"))
        native_flags = {node.m_Name: node.m_MetaFlag for node in component._get_typetree_node().m_Children}
        for node in nodes:
            if node["m_Level"] == 1 and node["m_Name"] in native_flags:
                # Unity 5 aligns the enabled byte before the script PPtr; use its native header schema.
                node["m_MetaFlag"] = native_flags[node["m_Name"]]
        fields = component.read_typetree(nodes)
        header = component.read_typetree(check_read=False)
        for name in ("m_GameObject", "m_Enabled", "m_Script", "m_Name"):
            if fields[name] != header[name]:
                raise ValueError("Decoded Mono header differs: " + name)
        targets = {}
        for name, count in EXPECTED_COUNTS.items():
            pointers = fields[name]
            if len(pointers) != count or len({item["m_PathID"] for item in pointers}) != count:
                raise ValueError("Original list count or uniqueness differs: " + name)
            for pointer in pointers:
                if pointer["m_FileID"] != 0 or pointer["m_PathID"] <= 0:
                    raise ValueError("Only original nonzero local component pointers are supported.")
                target = scene.objects[pointer["m_PathID"]]
                if target.type.name != "MonoBehaviour":
                    raise ValueError("Original list references a non-component object.")
                targets[pointer["m_PathID"]] = script_type(target)["m_ClassName"]
        if fields["levelExperience"] != 0 or fields["experience"] != 0 or fields["levels"] != []:
            raise ValueError("Unexpected original initial progression fields.")
        return fields, targets, {
            "apkSha256": digest(apk_path.read_bytes()), "obbSha256": EXPECTED_OBB_HASH,
            "serializedFile": "level0", "componentPathId": COMPONENT_ID,
            "payloadBytes": component.byte_size, "payloadSha256": digest(component.get_raw_data()),
            "assemblySha256": digest(apk.read("assets/bin/Data/Managed/Assembly-CSharp.dll")),
            "unityVersion": scene.unity_version,
            "unityPyVersion": importlib.metadata.version("UnityPy"),
        }


def make_payload(fields):
    lines = []
    for name in EXPECTED_COUNTS:
        lines.append("  " + name + ":")
        lines.extend("  - {fileID: " + str(item["m_PathID"]) + "}" for item in fields[name])
    lines.extend(["  levelExperience: 0", "  experience: 0", "  levels: []"])
    return "\n".join(lines) + "\n"


def main():
    parser = argparse.ArgumentParser(__doc__)
    parser.add_argument("--apply", action="store_true")
    args = parser.parse_args()
    fields, targets, source = read_original()
    text = SCENE.read_text(encoding="utf-8-sig")
    blocks = {int(match[2]): match for match in BLOCK.finditer(text)}
    script_names = {}
    for meta in ASSETS.rglob("*.cs.meta"):
        match = re.search(r"guid: ([0-9a-f]{32})", meta.read_text(encoding="utf-8-sig"))
        if match:
            script_names[match[1]] = meta.with_suffix("").stem
    for target_id, class_name in targets.items():
        target = blocks.get(target_id)
        if target is None or target[1] != "114":
            raise ValueError("Active scene is missing original component: " + str(target_id))
        guid = re.search(r"m_Script: .*guid: ([0-9a-f]{32})", target[0])[1]
        if script_names.get(guid) != class_name:
            raise ValueError("Active component type differs from the original: " + str(target_id))
    component = blocks[COMPONENT_ID]
    if "guid: 780c78d4af376959b095359d8460246f" not in component[0]:
        raise ValueError("Active LevelManager script identity differs.")
    if "m_GameObject: {fileID: " + str(fields["m_GameObject"]["m_PathID"]) + "}" not in component[0]:
        raise ValueError("Active LevelManager owner differs.")
    marker = "  m_EditorClassIdentifier:"
    marker_end = component[0].find("\n", component[0].index(marker))
    header = component[0] + "\n" if marker_end < 0 else component[0][:marker_end + 1]
    payload = make_payload(fields)
    old_payload = "" if marker_end < 0 else component[0][marker_end + 1:]
    if old_payload.strip() and old_payload.strip() != payload.strip():
        raise ValueError("Existing custom fields differ; preserve concurrent edits for review.")
    result = text[:component.start()] + header + payload + text[component.end():]
    changed = result != text
    report = {
        "schemaVersion": 1, "source": source, "counts": EXPECTED_COUNTS, "fields": fields,
        "target": {"scene": SCENE.relative_to(ROOT).as_posix(), "componentFileId": COMPONENT_ID,
                   "beforeSha256": digest(text.encode()), "afterSha256": digest(result.encode())},
        "resolvedTargetClasses": {str(key): value for key, value in targets.items()},
    }
    if args.apply and changed:
        SCENE.write_text(result, encoding="utf-8", newline="\n")
        (ROOT / "Server/docs/level-manager-bindings.json").write_text(
            json.dumps(report, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"changed": changed, "applied": args.apply and changed,
                      "counts": EXPECTED_COUNTS, "resolvedPointers": len(targets),
                      "beforeSha256": report["target"]["beforeSha256"],
                      "afterSha256": report["target"]["afterSha256"]}, indent=2))


if __name__ == "__main__":
    main()
