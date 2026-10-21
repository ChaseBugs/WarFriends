"""Compare exported Google2u cells with typed serialized MainScene values, without rewriting either."""
import hashlib
import json
import math
import re
import struct
from collections import Counter
from pathlib import Path

import yaml

ROOT = Path(__file__).resolve().parents[2]
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
CONTENT = ROOT / "Server/content/recovered-battle-content.json"
SCHEMAS = ROOT / "Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u"


class UniqueScalarLoader(getattr(yaml, "CBaseLoader", yaml.BaseLoader)):
    """Keep scalar spelling and reject duplicate mapping keys before interpretation."""

    def construct_mapping(self, node, deep=False):
        result = {}
        for key_node, value_node in node.value:
            key = self.construct_object(key_node, deep=deep)
            if key in result:
                raise ValueError("Duplicate serialized key: " + key)
            result[key] = self.construct_object(value_node, deep=deep)
        return result


def binary32(value):
    result = struct.unpack("<f", struct.pack("<f", value))[0]
    if not math.isfinite(result):
        raise ValueError("Non-finite source/catalog value")
    return result


def read_obscured(value, kind):
    if set(value) != {"currentCryptoKey", "hiddenValue", "fakeValue", "inited"}:
        raise ValueError("Unexpected obscured-value schema")
    if value["inited"] != "1" or value["fakeValue"] != "0":
        raise ValueError("Unreviewed obscured-value initialization")
    key = int(value["currentCryptoKey"])
    if key == 0:
        raise ValueError("Default crypto-key branch requires separate review")
    if kind == "ObscuredInt":
        result = int(value["hiddenValue"]) ^ key
        if not -(2**31) <= result < 2**31:
            raise ValueError("ObscuredInt exceeds signed width")
        return result
    hidden = value["hiddenValue"]
    if not re.fullmatch(r"[0-9a-f]{8}", hidden):
        raise ValueError("ObscuredFloat requires four little-endian bytes")
    bits = int.from_bytes(bytes.fromhex(hidden), "little") ^ key
    return binary32(struct.unpack("<f", bits.to_bytes(4, "little"))[0])


def read_cell(value, kind):
    if kind in {"ObscuredInt", "ObscuredFloat"}:
        return read_obscured(value, kind)
    if kind == "string":
        return value
    if kind == "bool":
        if value not in {"0", "1"}:
            raise ValueError("Unexpected serialized Boolean")
        return value == "1"
    if kind == "float":
        return binary32(float(value))
    if kind in {"int", "long"}:
        number = int(value)
        width = 32 if kind == "int" else 64
        if not -(2 ** (width - 1)) <= number < 2 ** (width - 1):
            raise ValueError("Source integer exceeds declared width")
        return number
    raise ValueError("Unsupported source field type: " + kind)


def normalize_export(value, kind):
    if kind in {"float", "ObscuredFloat"}:
        if type(value) not in {int, float}:
            raise ValueError("Export float has the wrong JSON type")
        return binary32(value)
    expected = str if kind == "string" else bool if kind == "bool" else int
    if type(value) is not expected:
        raise ValueError("Export scalar has the wrong JSON type")
    return value


def component_index(scene):
    result = {}
    for block in scene.split("--- !u!"):
        if not block.startswith("114 &"):
            continue
        match = re.search(r"m_Script:.*guid: ([0-9a-f]{32})", block)
        if match:
            result.setdefault(match[1], []).append(block)
    return result


def read_sheet_source(sheet, blocks):
    if not re.fullmatch(r"Google2u\.[A-Za-z0-9_]+", sheet["type"]):
        raise ValueError("Invalid source sheet identity")
    name = sheet["type"].removeprefix("Google2u.")
    meta = (SCHEMAS / (name + ".cs.meta")).read_bytes()
    schema = (SCHEMAS / (name + "Row.cs")).read_bytes()
    guid = re.search(r"guid: ([0-9a-f]{32})", meta.decode("utf-8-sig"))[1]
    selected = blocks.get(guid, [])
    if len(selected) != 1:
        raise ValueError("Expected one source component: " + name)
    component = yaml.load(selected[0].split("\n", 1)[1], Loader=UniqueScalarLoader)["MonoBehaviour"]
    declarations = re.findall(r"^\s*public (\w+) (\w+);\s*$", schema.decode("utf-8-sig"), re.M)
    fields = dict((field, kind) for kind, field in declarations)
    if not fields or len(fields) != len(declarations):
        raise ValueError("Missing row schema: " + name)
    if "Rows" not in component and name == "Squads" and sheet["rows"] == []:
        return [], fields, hashlib.sha256(schema).hexdigest()
    rows = component["Rows"]
    if len(rows) != len(sheet["rows"]):
        raise ValueError("Row count changed: " + name)
    return rows, fields, hashlib.sha256(schema).hexdigest()


def compare_sheet(sheet, blocks):
    rows, fields, schema_hash = read_sheet_source(sheet, blocks)
    differences, counts = [], Counter()
    for index, (source, exported) in enumerate(zip(rows, sheet["rows"])):
        if source.keys() != fields.keys() or exported.keys() != fields.keys():
            raise ValueError("Row fields differ from schema: " + sheet["type"])
        for field, kind in fields.items():
            actual = read_cell(source[field], kind)
            expected = normalize_export(exported[field], kind)
            counts[kind] += 1
            if actual == expected:
                continue
            cause = "unexplained-value-difference"
            if kind == "ObscuredFloat" and binary32(float(format(actual, ".7g"))) == expected:
                cause = "matches-seven-significant-digit-format"
            differences.append({"sheet": sheet["type"], "rowIndex": index, "field": field,
                                "kind": kind, "source": actual, "exported": expected, "classification": cause})
    return differences, counts, schema_hash


def create_report():
    scene, content = SCENE.read_bytes(), CONTENT.read_bytes()
    sheets = json.loads(content)["sheets"]
    if len(sheets) != 132 or len({row["type"] for row in sheets}) != 132:
        raise ValueError("Unreviewed sheet inventory")
    blocks = component_index(scene.decode("utf-8-sig"))
    differences, counts, schemas = [], Counter(), {}
    for sheet in sheets:
        changes, observed, schema_hash = compare_sheet(sheet, blocks)
        differences.extend(changes)
        counts.update(observed)
        schemas[sheet["type"]] = schema_hash
    return {"schemaVersion": 1, "sceneSha256": hashlib.sha256(scene).hexdigest(),
            "contentSha256": hashlib.sha256(content).hexdigest(), "sheetCount": len(sheets),
            "scalarCounts": dict(sorted(counts.items())), "schemaHashes": schemas,
            "releaseVerified": False, "differenceCount": len(differences), "differences": differences}


def main():
    import argparse
    parser = argparse.ArgumentParser(description=__doc__)
    parser.parse_args()
    report = create_report()
    print(json.dumps(report, indent=2, allow_nan=False))
    return 1 if report["differenceCount"] else 0


if __name__ == "__main__":
    raise SystemExit(main())
