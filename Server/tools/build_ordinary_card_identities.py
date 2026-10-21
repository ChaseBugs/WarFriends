"""Extract the complete ordinary card identity table independently of implemented host effects."""
import argparse
import hashlib
import json
from pathlib import Path

REPOSITORY = Path(__file__).resolve().parents[2]
CONTENT = REPOSITORY / "Server/content"
SOURCE_HASH = "28b94d12a9ba78a8a46287cd40bf51d454afa75c036b1368561d22979e47d39a"


def build_document(content_bytes):
    document = json.loads(content_bytes)
    sheets = [sheet for sheet in document["sheets"] if sheet["type"] == "Google2u.CardDefinitions"]
    if len(sheets) != 1:
        raise ValueError("Expected exactly one source card definition sheet.")
    for row in sheets[0]["rows"]:
        if type(row["RARITY"]) is not int or type(row["IMPLEMENTED"]) is not bool:
            raise ValueError("Card rarity and implementation flag must retain their source types.")
    rows = [{"id": row["NAME"], "rarity": row["RARITY"], "implemented": row["IMPLEMENTED"]}
            for row in sheets[0]["rows"] if row["RARITY"] in (1, 2, 3)]
    if (len(rows) != 67 or len({row["id"] for row in rows}) != 67
            or sum(row["implemented"] is True for row in rows) != 57
            or any(type(row["implemented"]) is not bool for row in rows)):
        raise ValueError("The complete source card identity set changed.")
    return {"schemaVersion": 1, "clientVersion": "1.4.0",
            "sourceSha256": hashlib.sha256(content_bytes).hexdigest(),
            "sheet": "Google2u.CardDefinitions", "path": sheets[0]["path"], "cards": rows}


def build():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true", help="Validate without writing production content")
    args = parser.parse_args()
    content_bytes = (CONTENT / "recovered-battle-content.json").read_bytes()
    if hashlib.sha256(content_bytes).hexdigest() != SOURCE_HASH:
        raise ValueError("Reviewed source content changed.")
    result = build_document(content_bytes)
    output = CONTENT / "recovered-ordinary-card-identities.json"
    encoded = (json.dumps(result, indent=2, allow_nan=False) + "\n").encode("utf-8")
    if args.check:
        if output.read_bytes() != encoded:
            raise ValueError("Ordinary card identities differ from reviewed source.")
    else:
        output.write_bytes(encoded)
    action = "VERIFIED" if args.check else "BUILT"
    print(f"ORDINARY_CARD_IDENTITIES_{action} rows=67 active=57 sha256=" + hashlib.sha256(encoded).hexdigest())


if __name__ == "__main__":
    build()
