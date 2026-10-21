"""Review 1.4.0 root competition identities and compile the original Army Power scaling property."""

from pathlib import Path


def root_sources(client: Path) -> dict[str, str]:
    player = (client / "DatabasePlayer.cs").read_text(encoding="utf-8-sig")
    matches = [line.strip() for line in player.splitlines() if line.strip().startswith("public int armyPowerX10 =>")]
    if len(matches) != 1:
        raise ValueError("Client Army Power scaling property must be unique.")
    league = (client / "League.cs").read_text(encoding="utf-8-sig")
    variables = (client / "GameVariables.cs").read_text(encoding="utf-8-sig")
    start = variables.index("\tpublic string BeginnersLeagueName(int beginnersNumber)")
    end = variables.index("\n\tpublic string BeginnersLeagueIcon(", start)
    return {
        "Root.ArmyPowerScale": matches[0],
        "Root.League": league[league.index("public enum League"):].rstrip(),
        "Root.BeginnerNames": variables[start:end].strip(),
    }


def root_oracle(recovered: dict[str, str]) -> str:
    template = """
internal static class RecoveredRootOracle
{
    __LEAGUE__
    private sealed class Power
    {
        internal int armyPower;
        __POWER__
    }
    internal static int Scale(int value) => new Power { armyPower = value }.armyPowerX10;
    internal static int MaximumLeague => Enum.GetValues<League>().Select(value => (int)value).Max();
}
"""
    return template.replace("__POWER__", recovered["Root.ArmyPowerScale"]) \
        .replace("__LEAGUE__", recovered["Root.League"])
