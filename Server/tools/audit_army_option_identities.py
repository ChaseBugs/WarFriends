"""Check the compiled army-option map against recovered deployment evidence."""

from pathlib import Path
import json
import re


ROOT = Path(__file__).resolve().parents[2]
catalog = json.loads((ROOT / "Server/content/recovered-army-deployment.json").read_text(encoding="utf-8"))
source = (ROOT / "Server/src/War.BattleServer/ArmyOptionIdentityCatalog.cs").read_text(encoding="utf-8")
compiled = {}
for unit_id, encoded in re.findall(r'\("(ID_UNIT-[A-Z0-9-]+)","([0-9:,]+)"\)', source):
    for part in encoded.split(","):
        index, count = map(int, part.split(":"))
        assert index not in compiled, index
        compiled[index] = (unit_id, count)
recovered = {
    option["index"]: (family["unitId"], option["count"])
    for family in catalog["families"] for option in family["options"]
}
assert set(compiled) == set(range(48))
assert compiled == recovered, ("Army option identities differ", compiled, recovered)
print("PASS: 48 compiled army options match 24 recovered deployment families")
