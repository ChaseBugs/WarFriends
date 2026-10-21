#!/usr/bin/env python3
"""Bind the reviewed 1.4.0 snapshot to recovered row schemas and source-declared row counts.

This does not regenerate battle content or repair the known whole-scene digest discrepancy.
"""

import argparse
import hashlib
import json
import re
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
CONTENT = ROOT / "Server/content/recovered-battle-content.json"
SCHEMAS = ROOT / "Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u"
OUTPUT = ROOT / "Server/content/legacy-catalog-profile.json"
FIELD_TYPES = {"int": "int32", "ObscuredInt": "int32", "long": "int64", "string": "string",
               "float": "float32", "ObscuredFloat": "float32", "bool": "boolean"}


def review_sheet(sheet):
    name = sheet["type"].removeprefix("Google2u.")
    component = SCHEMAS / (name + ".cs")
    schema = SCHEMAS / (name + "Row.cs")
    component_text = component.read_text(encoding="utf-8-sig")
    schema_text = schema.read_text(encoding="utf-8-sig")
    declared = int(re.search(r"rowNames\s*=\s*new string\[(\d+)\]", component_text)[1])
    fields = {field: FIELD_TYPES[kind]
              for kind, field in re.findall(r"^\s*public (\w+) (\w+);\s*$", schema_text, re.M)}
    rows = sheet["rows"]
    is_closed = sheet["type"] == "Google2u.Squads" and not rows
    if not fields or (len(rows) != declared and not is_closed):
        raise ValueError("Unreviewed missing/extra schema rows: " + sheet["type"])
    if any(set(row) != set(fields) for row in rows):
        raise ValueError("Export fields disagree with the recovered row class: " + sheet["type"])
    identity_field = "DBKEY" if "DBKEY" in fields else "NAME" if "NAME" in fields else None
    return {
        "type": sheet["type"], "declaredRows": declared, "exportedRows": len(rows), "closed": is_closed,
        "path": sheet["path"], "fields": fields, "identityField": identity_field,
        "orderedIdentities": [row[identity_field] for row in rows] if identity_field else [],
        "componentSource": component.relative_to(ROOT).as_posix(),
        "componentSha256": hashlib.sha256(component_text.encode()).hexdigest(),
        "rowSource": schema.relative_to(ROOT).as_posix(),
        "rowSha256": hashlib.sha256(schema_text.encode()).hexdigest(),
    }


def build_profile(source=None):
    if source is None:
        source = CONTENT.read_bytes()
    content = json.loads(source)
    if content["client"] != "1.4.0" or len(content["sheets"]) != 132:
        raise ValueError("Client/sheet inventory needs a new explicit review.")
    return {
        "schemaVersion": 1, "client": content["client"], "exportUnityLabel": content["unity"],
        "claimedMainSceneSha256": content["mainSceneSha256"],
        "artifactSha256": hashlib.sha256(source).hexdigest(),
        "sourceHashEncoding": "UTF-8 without BOM, LF; artifactSha256 uses exact bytes (CRLF pinned by gitattributes)",
        "limitation": "Reviewed export snapshot and row schemas; current whole-scene agreement is V07, still open.",
        "sheets": [review_sheet(sheet) for sheet in content["sheets"]],
    }


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true")
    arguments = parser.parse_args()
    profile = build_profile()
    encoded = (json.dumps(profile, indent=2, ensure_ascii=False) + "\n").encode()
    if arguments.check:
        if not OUTPUT.exists() or OUTPUT.read_bytes() != encoded:
            raise SystemExit("Legacy release profile changed. Review source/schema/snapshot before regeneration.")
        print("PASS: 132 reviewed catalog sheets bind exact source schemas, ordered identities and snapshot bytes")
    else:
        OUTPUT.write_bytes(encoded)
        print("Wrote", OUTPUT.relative_to(ROOT), "(does not resolve V07 scene provenance)")


if __name__ == "__main__":
    main()
