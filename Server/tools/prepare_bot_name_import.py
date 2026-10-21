"""Prepare lossless BotNames YAML in memory for disposable native export inputs."""
import json
import re

import yaml

from audit_battle_sheet_values import UniqueScalarLoader

COMPONENT_HEADER = "--- !u!114 &46609\n"
ROW_COUNT = 269


def prepare_scene(scene):
    """Return prepared bytes and changed rows; never save or alter a source asset."""
    text = scene.decode("utf-8-sig")
    if "\r" in text or text.count(COMPONENT_HEADER) != 1:
        raise ValueError("Expected one LF-delimited BotNames source component")
    start = text.index(COMPONENT_HEADER) + len(COMPONENT_HEADER)
    end = text.find("--- !u!", start)
    if end < 0:
        end = len(text)
    original = text[start:end]
    fields = yaml.load(original, Loader=UniqueScalarLoader)["MonoBehaviour"]
    rows = fields.get("Rows")
    expected_ids = ["ID_" + str(index + 1) for index in range(ROW_COUNT)]
    if fields.get("rowNames") != expected_ids or not isinstance(rows, list) or len(rows) != ROW_COUNT:
        raise ValueError("BotNames row identity changed")
    if any(set(row) != {"NAME"} or not isinstance(row["NAME"], str) for row in rows):
        raise ValueError("BotNames row schema changed")
    matches = list(re.finditer(r"^  - NAME: (.*)$", original, re.M))
    if len(matches) != ROW_COUNT:
        raise ValueError("Unsupported BotNames scalar layout")
    prepared = original
    changes = []
    for index in reversed(range(ROW_COUNT)):
        match = matches[index]
        value = rows[index]["NAME"]
        if match[1].isascii():
            continue
        # Already quoted source scalars import correctly; preserve their exact bytes.
        if match[1].startswith(("'", '"')):
            continue
        if match[1] != value:
            raise ValueError("Non-plain Unicode scalar requires separate review")
        escaped = json.dumps(value, ensure_ascii=True)
        prepared = prepared[:match.start(1)] + escaped + prepared[match.end(1):]
        changes.append({"rowIndex": index, "value": value})
    if yaml.load(prepared, Loader=UniqueScalarLoader) != yaml.load(original, Loader=UniqueScalarLoader):
        raise ValueError("Import preparation changed serialized values")
    output = (text[:start] + prepared + text[end:]).encode("utf-8")
    if scene.startswith(b"\xef\xbb\xbf"):
        output = b"\xef\xbb\xbf" + output
    return output, list(reversed(changes))
