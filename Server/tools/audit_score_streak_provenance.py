"""Verify reviewed Client source transitions without treating host wiring as original game logic."""
import hashlib
import json
import re
import subprocess
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
SOURCES = {
    "ScoreManager": ("5bab66c53f82b7bba692e1d94d920d0bd13e5ecc",
                     "b8b3e9a7e07ed310044c536c1f041c2efef6c0390dfa82dcd2424d1d56b11cb6",
                     "52555acfdb42d53978c0640bb430de7d3eef0165f498533cf9dbddce4cc85a26"),
    "GameControllerOnline": ("0fc5a46c288e2fd113bed5aee4b42350dae1b10a",
                             "f260e01480d4abb28e6ff4ce5f42edefe621ff8ec176b2561bad110a5e26ec0e",
                             "2a8714af01868e70a84e77b81d0d4b4ac56eafd87427ce116923ba9fb9d821f0")}


def compact(source):
    return re.sub(r"\s+", "", source)


def body(source, declaration):
    start = source.index("{", source.index(declaration))
    depth = 1
    for end in range(start + 1, len(source)):
        depth += (source[end] == "{") - (source[end] == "}")
        if depth == 0:
            return source[start + 1:end]
    raise ValueError("Incomplete source block")


def verify_rules(previous, current):
    if compact(body(previous["GameControllerOnline"], "public override bool dropCreates")) != compact(
            body(current["GameControllerOnline"], "public override bool dropCreates")):
        raise ValueError("Crate eligibility changed")
    old_update = body(previous["ScoreManager"], "protected void Update()")
    old_streak = old_update[old_update.index("killStreakProgress -="):old_update.index("mTimeFromStart +=")]
    new_streak = compact(body(current["ScoreManager"], "private void AdvanceLocalStreak()"))
    guard = "if(IsSelfHostedScoreActive){return;}"
    if not new_streak.startswith(guard):
        raise ValueError("Host-owned score guard changed")
    new_streak = new_streak[len(guard):].replace("KillStreakThreshold", "100f")
    if new_streak != compact(old_streak):
        raise ValueError("Local streak arithmetic or bonus ordering changed")
    if "privateconstfloatKillStreakThreshold=100f;" not in compact(current["ScoreManager"]):
        raise ValueError("Streak threshold changed")


def audit():
    previous, current, rows = {}, {}, {}
    for name, (commit, old_hash, new_hash) in SOURCES.items():
        relative = "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/" + name + ".cs"
        original = subprocess.check_output(["git", "show", commit + ":" + relative], cwd=ROOT)
        original = original.replace(b"\r\n", b"\n").replace(b"\n", b"\r\n")
        active = (ROOT / relative).read_bytes()
        if hashlib.sha256(original).hexdigest() != old_hash or hashlib.sha256(active).hexdigest() != new_hash:
            raise ValueError("Reviewed source transition changed: " + name)
        previous[name], current[name] = original.decode(), active.decode()
        rows[name] = {"baselineCommit": commit, "legacyCrlfSha256": old_hash, "currentSha256": new_hash}
    verify_rules(previous, current)
    return {"sources": rows, "localStreakArithmeticEqual": True, "crateEligibilityEqual": True,
            "scope": "Reviewed source transition, not full Client gameplay verification"}


if __name__ == "__main__":
    print(json.dumps(audit(), indent=2))
