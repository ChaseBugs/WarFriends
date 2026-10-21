"""Compose the existing Minigun package schema exclusively from two native exports."""
import copy
import json
import math


def exact(value):
    return json.dumps(value, sort_keys=True, allow_nan=False)


def build_document(family_bytes, identity_bytes):
    family = json.loads(family_bytes)
    identities = json.loads(identity_bytes)
    for field in ("client", "source", "sha256", "playerPath"):
        if exact(family[field]) != exact(identities[field]):
            raise ValueError("Minigun native source identities differ: " + field)
    matches = [row for row in identities["weapons"] if row["id"] == "Google2u.LMG_Minigun"]
    if len(matches) != 1 or family["weapon"]["id"] != "Google2u.LMG_Minigun":
        raise ValueError("Expected exactly one native Minigun identity")
    identity = matches[0]
    native = family["weapon"]
    missing = {"setupType", "ammoSetupType", "weaponComponents"}
    if set(identity) - set(native) != missing:
        raise ValueError("Unexpected Minigun identity schema")
    for field in set(identity) & set(native):
        if exact(identity[field]) != exact(native[field]):
            raise ValueError("Minigun native overlap differs: " + field)
    for field, length in (("muzzlePosition", 3), ("muzzleRotation", 4)):
        value = native[field]
        if not isinstance(value, list) or len(value) != length or any(
                type(item) not in (int, float) or not math.isfinite(item) for item in value):
            raise ValueError("Invalid native Minigun pose")
    if not isinstance(native["motorPath"], str) or not native["motorPath"].startswith(family["playerPath"] + "/"):
        raise ValueError("Invalid native Minigun motor path")
    result = copy.deepcopy(family)
    # Reference-pose diagnostics stay in raw evidence; the established runtime package omits them.
    for field in ("muzzlePosition", "muzzleRotation", "motorPath"):
        del result["weapon"][field]
    for field in sorted(missing):
        result["weapon"][field] = copy.deepcopy(identity[field])
    return result
