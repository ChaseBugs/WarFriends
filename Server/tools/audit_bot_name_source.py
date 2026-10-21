"""Verify all original BotNames strings before reviewing the four truncated export values."""
import argparse
import hashlib
import json
import struct
import zipfile
from pathlib import Path

import UnityPy
import yaml

from audit_battle_sheet_values import UniqueScalarLoader
from restore_level_manager_bindings import EXPECTED_OBB_HASH, read_split

ROOT = Path(__file__).resolve().parents[2]
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
REPORT = ROOT / "Server/docs/bot-name-source-audit.json"
COMPONENT_ID = 46609
ROW_COUNT = 269


def file_hash(path):
    with path.open("rb") as stream:
        return hashlib.file_digest(stream, "sha256").hexdigest()


def read_array(raw, position):
    if position + 4 > len(raw):
        raise ValueError("Missing string array count")
    count = struct.unpack_from("<i", raw, position)[0]
    if count != ROW_COUNT:
        raise ValueError("Original string array count changed")
    position += 4
    values = []
    for _ in range(count):
        if position + 4 > len(raw):
            raise ValueError("Missing string length")
        length = struct.unpack_from("<i", raw, position)[0]
        position += 4
        if length < 0 or length > 1024 or position + length > len(raw):
            raise ValueError("Invalid original string byte length")
        values.append(raw[position:position + length].decode("utf-8", errors="strict"))
        end = position + length
        position = (end + 3) & ~3
        if position > len(raw) or any(raw[end:position]):
            raise ValueError("Invalid original string alignment")
    return values, position


def decode_payload(raw):
    expected_header = struct.pack("<iqB3xiqI", 0, 6369, 1, 1, 570, 0)
    if raw[:32] != expected_header:
        raise ValueError("Original Mono header changed")
    row_names, position = read_array(raw, 32)
    names, position = read_array(raw, position)
    if row_names != ["ID_" + str(index + 1) for index in range(ROW_COUNT)] or position != len(raw):
        raise ValueError("Original row order or payload boundary changed")
    return row_names, names


def read_original():
    apk_path = ROOT / "WarFriends 1.4.0.apk"
    obb_path = ROOT / "main.14008.com.chillingo.warfriends.android.gplay.obb"
    recorded = json.loads((ROOT / "Server/docs/level-manager-bindings.json").read_bytes())["source"]
    if file_hash(obb_path) != EXPECTED_OBB_HASH or file_hash(apk_path) != recorded["apkSha256"]:
        raise ValueError("Original package identity differs")
    with zipfile.ZipFile(apk_path) as apk, zipfile.ZipFile(obb_path) as obb:
        environment = UnityPy.Environment()
        scene = environment.load_file(read_split(obb, "level0"), name="level0")
        if scene.unity_version != "5.2.5f1":
            raise ValueError("Original Unity version differs")
        component = scene.objects[COMPONENT_ID]
        header = component.read_typetree(check_read=False)
        pointer = header["m_Script"]
        external = scene.externals[pointer["m_FileID"] - 1].name
        archive = apk if "assets/bin/Data/" + external + ".split0" in apk.namelist() else obb
        scripts = environment.load_file(read_split(archive, external), name=external)
        script = scripts.objects[pointer["m_PathID"]].read_typetree()
        identity = (script["m_Namespace"], script["m_ClassName"], script["m_AssemblyName"])
        if identity != ("Google2u", "BotNames", "Assembly-CSharp-firstpass.dll"):
            raise ValueError("Original script identity differs")
        raw = component.get_raw_data()
        rows, names = decode_payload(raw)
        return rows, names, {"apkSha256": recorded["apkSha256"], "obbSha256": EXPECTED_OBB_HASH,
                             "componentFileId": COMPONENT_ID, "payloadBytes": len(raw),
                             "payloadSha256": hashlib.sha256(raw).hexdigest()}


def create_report():
    row_names, names, original = read_original()
    scene = SCENE.read_bytes()
    blocks = [block for block in scene.decode("utf-8-sig").split("--- !u!")
              if block.startswith("114 &46609\n")]
    if len(blocks) != 1:
        raise ValueError("Expected one active BotNames component")
    fields = yaml.load(blocks[0].split("\n", 1)[1], Loader=UniqueScalarLoader)["MonoBehaviour"]
    if fields["rowNames"] != row_names or fields["Rows"] != [{"NAME": name} for name in names]:
        raise ValueError("Active scene strings differ from original package")
    content_path = ROOT / "Server/content/recovered-battle-content.json"
    sheets = [sheet for sheet in json.loads(content_path.read_bytes())["sheets"]
              if sheet["type"] == "Google2u.BotNames"]
    if len(sheets) != 1 or len(sheets[0]["rows"]) != ROW_COUNT:
        raise ValueError("Exported BotNames inventory changed")
    differences = []
    for index, (name, exported) in enumerate(zip(names, sheets[0]["rows"])):
        if name != exported["NAME"]:
            differences.append({"rowIndex": index, "original": name, "exported": exported["NAME"],
                                "utf8ExtraBytes": len(name.encode("utf-8")) - len(name)})
    return {"schemaVersion": 1, "original": original, "sceneSha256": hashlib.sha256(scene).hexdigest(),
            "contentSha256": file_hash(content_path), "rowCount": ROW_COUNT,
            "allSceneStringsMatchOriginal": True, "releaseVerified": False, "differences": differences}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true")
    args = parser.parse_args()
    report = json.dumps(create_report(), indent=2) + "\n"
    if args.check:
        if REPORT.read_text(encoding="utf-8") != report:
            raise ValueError("BotNames source audit differs")
        print("PASS: all 269 scene names match original bytes; exported differences remain recorded")
    else:
        print(report, end="")


if __name__ == "__main__":
    main()
