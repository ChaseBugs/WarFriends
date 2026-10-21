#!/usr/bin/env python3
"""Compile a reviewed, unchanged Client callback into the small headless contract test.

Only generated obj output is written. Client files are read in place; no Unity project copy,
Editor, native engine or external service is needed. Scene/gameplay behavior is outside this test.
"""

from __future__ import annotations

import argparse
import hashlib
import json
from pathlib import Path

from legacy_buffer_producer_inventory import planner_result_sets
from legacy_upgrade_oracle import upgrade_oracle, upgrade_sources
from legacy_dog_tag_oracle import dog_tag_oracle, dog_tag_sources
from legacy_settings_oracle import settings_oracle, settings_sources
from legacy_root_oracle import root_oracle, root_sources
from legacy_profile_oracle import profile_oracle, profile_sources
from legacy_analytics_oracle import analytics_oracle, analytics_sources
from legacy_tutorial_oracle import tutorial_oracle, tutorial_sources


REPOSITORY = Path(__file__).resolve().parents[2]
CLIENT = REPOSITORY / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp"
MATRIX = REPOSITORY / "Server/docs/legacy-buffer-contracts.json"


def sources() -> dict[str, str]:
    handler = (CLIENT / "ServerResponseHandler.cs").read_text(encoding="utf-8-sig")
    start = handler.index("\tprivate static string ProcessBuffer(")
    end = handler.index("\n\tprivate void OnSetPlayerStatus()", start)
    result = {"ServerResponseHandler.ProcessBuffer": handler[start:end].rstrip()}
    for name in ("StringParser", "DatabaseAction", "DatabaseResult", "GameItem"):
        result[name] = (CLIENT / f"{name}.cs").read_text(encoding="utf-8-sig").rstrip()
    for identity, filename, prefix in (
        ("Rank.DisplayNumber", "LevelManager", "public int displayNumber =>"),
        ("Rank.WeaponPurchase", "WeaponLevelsSetup", "public bool canBeBought =>"),
        ("Rank.UnitPurchase", "UpgradeSlots", "public bool canBeBought =>"),
        ("Rank.VisualIndex", "PlayerVisual", "public int unlockLevelIndex =>"),
        ("Rank.VisualUnlock", "PlayerVisual", "public bool isUnlocked =>"),
        ("Rank.Promotion", "UpgradeSlots", "public bool isPromoteToNextTierLocked =>"),
    ):
        lines = (CLIENT / f"{filename}.cs").read_text(encoding="utf-8-sig").splitlines()
        matches = [line.strip() for line in lines if line.strip().startswith(prefix)]
        if len(matches) != 1:
            raise ValueError(f"Rank property extraction is no longer unique: {identity}")
        result[identity] = matches[0]
    result.update(upgrade_sources(CLIENT))
    result.update(dog_tag_sources(CLIENT))
    result.update(settings_sources(CLIENT))
    result.update(root_sources(CLIENT))
    result.update(profile_sources(CLIENT))
    result.update(analytics_sources(CLIENT))
    result.update(tutorial_sources(CLIENT))
    return result


def rank_oracle(recovered: dict[str, str]) -> str:
    template = """
internal static class RecoveredRankGateOracle
{
    internal sealed class DisplayRank
    {
        public int index { get; set; }
        __DISPLAY__
    }
    private sealed class Row
    {
        public int CANBEBOUGHT { get; set; }
        public int UNLOCKLEVEL { get; set; }
    }
    private sealed class WeaponGate
    {
        internal Row weaponUpgradesRow = new Row();
        __WEAPON__
    }
    private sealed class UnitGate
    {
        internal Row armyUpgradesRow = new Row();
        internal int unlockTierLevel;
        __UNIT__
        __PROMOTION__
    }
    private sealed class VisualGate
    {
        internal Row row = new Row();
        private bool isBought => false;
        __VISUAL_INDEX__
        __VISUAL_UNLOCK__
    }
    internal static bool IsUnlocked(string kind, int rank, int requiredDisplayLevel)
    {
        LevelManager.instance.currentLevel.index = rank;
        var row = new Row { CANBEBOUGHT = requiredDisplayLevel, UNLOCKLEVEL = requiredDisplayLevel };
        switch (kind)
        {
            case "weapon": return new WeaponGate { weaponUpgradesRow = row }.canBeBought;
            case "unit": return new UnitGate { armyUpgradesRow = row }.canBeBought;
            case "visual": return new VisualGate { row = row }.isUnlocked;
            case "promotion": return !new UnitGate { unlockTierLevel = requiredDisplayLevel }.isPromoteToNextTierLocked;
            default: throw new ArgumentOutOfRangeException(nameof(kind));
        }
    }
}
"""
    for placeholder, identity in (("DISPLAY", "DisplayNumber"), ("WEAPON", "WeaponPurchase"),
                                  ("UNIT", "UnitPurchase"), ("PROMOTION", "Promotion"),
                                  ("VISUAL_INDEX", "VisualIndex"), ("VISUAL_UNLOCK", "VisualUnlock")):
        template = template.replace(f"__{placeholder}__", recovered[f"Rank.{identity}"])
    return template


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output", type=Path)
    arguments = parser.parse_args()
    recovered = sources()
    matrix = json.loads(MATRIX.read_text(encoding="utf-8"))
    reviewed = matrix["sourceSha256"]
    actual = {name: hashlib.sha256(source.encode()).hexdigest() for name, source in recovered.items()}
    if actual != reviewed:
        raise SystemExit("Client buffer contract changed. Review callback, callees and matrix before updating hashes.")
    actions = [action for group in matrix["groups"] for action in group["actions"]]
    if planner_result_sets(REPOSITORY, actions) != matrix["serverResults"]:
        raise SystemExit("Server result dispositions changed. Review producer fixtures before updating the matrix.")
    dependencies = matrix["dependencySha256"]
    for path, expected in dependencies.items():
        if hashlib.sha256((REPOSITORY / path).read_bytes()).hexdigest() != expected:
            raise SystemExit(f"Recovered Client JSON dependency changed: {path}")
    if arguments.output is None:
        print(f"PASS: {len(actual)} reviewed Client sources and {len(actions)} server result inventories")
        return

    body = ["// Generated from reviewed Client sources. Do not edit.", "#nullable disable",
            "namespace War.LegacyContract.Tests.Recovered", "{", "using System;",
            "using System.Globalization;", "using System.Collections.Generic;",
            "using Newtonsoft.Json;", "using Newtonsoft.Json.Linq;"]
    for name in ("DatabaseAction", "DatabaseResult", "GameItem", "StringParser"):
        # Only move source-level imports to the enclosing namespace. The type body is unchanged.
        source = recovered[name]
        lines = [line for line in source.splitlines() if not line.startswith("using ")]
        body.extend([f'#line 1 "{(CLIENT / (name + ".cs")).as_posix()}"', *lines, "#line default"])
    body.extend(["internal static partial class ServerResponseHandler", "{",
                 recovered["ServerResponseHandler.ProcessBuffer"], "}", rank_oracle(recovered),
                 upgrade_oracle(recovered), dog_tag_oracle(recovered), settings_oracle(recovered),
                 root_oracle(recovered), profile_oracle(recovered), analytics_oracle(recovered), tutorial_oracle(recovered), "}"])
    arguments.output.parent.mkdir(parents=True, exist_ok=True)
    arguments.output.write_text("\n".join(body) + "\n", encoding="utf-8", newline="\n")


if __name__ == "__main__":
    main()
