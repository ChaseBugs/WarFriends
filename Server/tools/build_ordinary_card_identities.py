"""Extract the complete ordinary card identity table independently of implemented host effects."""
import hashlib
import json
from pathlib import Path

REPOSITORY = Path(__file__).resolve().parents[2]
CONTENT = REPOSITORY / "Server/content"
SOURCE_HASH = "28b94d12a9ba78a8a46287cd40bf51d454afa75c036b1368561d22979e47d39a"


def build():
    source = CONTENT / "recovered-battle-content.json"
    if hashlib.sha256(source.read_bytes()).hexdigest() != SOURCE_HASH:
        raise ValueError("Reviewed source content changed.")
    document = json.loads(source.read_text(encoding="utf-8"))
    sheets = [sheet for sheet in document["sheets"] if sheet["type"] == "Google2u.CardDefinitions"]
    if len(sheets) != 1:
        raise ValueError("Expected exactly one source card definition sheet.")
    rows = [{"id": row["NAME"], "rarity": row["RARITY"], "implemented": row["IMPLEMENTED"]}
            for row in sheets[0]["rows"] if row["RARITY"] in (1, 2, 3)]
    if (len(rows) != 67 or len({row["id"] for row in rows}) != 67
            or sum(row["implemented"] is True for row in rows) != 57
            or any(type(row["implemented"]) is not bool for row in rows)):
        raise ValueError("The complete source card identity set changed.")
    result = {"schemaVersion": 1, "clientVersion": "1.4.0", "sourceSha256": SOURCE_HASH,
              "sheet": "Google2u.CardDefinitions", "path": sheets[0]["path"], "cards": rows}
    output = CONTENT / "recovered-ordinary-card-identities.json"
    output.write_text(json.dumps(result, indent=2) + "\n", encoding="utf-8", newline="\n")
    print("ORDINARY_CARD_IDENTITIES_BUILT rows=67 active=57 sha256=" + hashlib.sha256(output.read_bytes()).hexdigest())


if __name__ == "__main__":
    build()
