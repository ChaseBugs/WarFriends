import { League } from "../constants";

/**
 * One row from the PlayerLeaderboards component serialized in MainScene.unity.
 *
 * These are gameplay rules, not tuning invented by the replacement backend. The recovered
 * 4.9.5 scene contains the same 16 rows consumed by GameVariables.LeagueGoUpPercent,
 * LeagueGoDownPercent, and the league UI. Keeping the complete table here makes promotion
 * decisions reviewable and prevents a future refactor from silently flattening tier rules.
 */
export interface PlayerLeagueRule {
  tier: League;
  name: string;
  durationHours: number;
  promoteFraction: number;
  demoteFraction: number;
  underfilledGold: number;
}

export const PLAYER_LEAGUE_RULES: readonly PlayerLeagueRule[] = [
  { tier: League.Bronze3, name: "Bronze3", durationHours: 24, promoteFraction: 0.5, demoteFraction: 0, underfilledGold: 10 },
  { tier: League.Bronze2, name: "Bronze2", durationHours: 24, promoteFraction: 0.5, demoteFraction: 0.1, underfilledGold: 20 },
  { tier: League.Bronze1, name: "Bronze1", durationHours: 24, promoteFraction: 0.5, demoteFraction: 0.1, underfilledGold: 30 },
  { tier: League.Silver3, name: "Silver3", durationHours: 72, promoteFraction: 0.3, demoteFraction: 0, underfilledGold: 40 },
  { tier: League.Silver2, name: "Silver2", durationHours: 72, promoteFraction: 0.3, demoteFraction: 0.1, underfilledGold: 50 },
  { tier: League.Silver1, name: "Silver1", durationHours: 72, promoteFraction: 0.3, demoteFraction: 0.1, underfilledGold: 60 },
  { tier: League.Gold3, name: "Gold3", durationHours: 168, promoteFraction: 0.1, demoteFraction: 0, underfilledGold: 70 },
  { tier: League.Gold2, name: "Gold2", durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 80 },
  { tier: League.Gold1, name: "Gold1", durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 90 },
  { tier: League.Elite3, name: "Elite3", durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 100 },
  { tier: League.Elite2, name: "Elite2", durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 125 },
  { tier: League.Elite1, name: "Elite1", durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 150 },
  { tier: League.Master3, name: "Master3", durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 175 },
  { tier: League.Master2, name: "Master2", durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 200 },
  { tier: League.Master1, name: "Master1", durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 225 },
  { tier: League.Champion, name: "Champion", durationHours: 168, promoteFraction: 0, demoteFraction: 0.1, underfilledGold: 250 },
] as const;

/** MainScene Constants.NotEnoughPlayersForPlayerLeague (decoded ObscuredFloat). */
export const PLAYER_LEAGUE_MINIMUM_PLAYERS = 30;
/** MainScene Constants.LeaguePlacementMatches (decoded ObscuredFloat). */
export const PLAYER_LEAGUE_PLACEMENT_MATCHES = 1;
/** MainScene Constants.ChampionLeagueTopPlayersForReward (decoded ObscuredFloat). */
export const CHAMPION_REWARD_FRACTION = 0.1;

const CHAMPION_REWARDS = { first: 700, second: 350, remainingTop: 150 } as const;
const MANAGED_DIVISION = "local";

export interface ManagedLeagueId {
  tier: League;
  endsAt: number;
  division: string;
}

export interface LeagueSettlementDecision {
  nextTier: League;
  rewardGold: number;
  notEnoughPlayers: boolean;
  result: "promote" | "stay" | "demote";
}

export interface PlayerLeaguePlacementInput {
  beginnersLeague: number;
  leagueTier: League;
  leagueId: string;
  remainingMatches: number;
}

export interface PlayerLeaguePlacementAdvance {
  leagueTier: League;
  leagueId: string;
  leagueDivision: string;
  remainingMatches: number;
  enteredLeague: boolean;
  endsAt?: number;
}

export function playerLeagueRule(tier: number): PlayerLeagueRule {
  const rule = PLAYER_LEAGUE_RULES[tier - 1];
  if (!rule || rule.tier !== tier) throw new Error(`Unsupported player league tier ${tier}.`);
  return rule;
}

/**
 * Produce a deterministic local-season ID which remains compatible with DatabasePlayer.cs.
 *
 * That parser splits LeagueId on '-' and treats the first segment as the numeric tier and
 * the final segment as the division label. The retired service's division allocator is not
 * present in either client archive, so this replacement deliberately uses one "local"
 * division per tier and a UTC-aligned recovered-duration window. The timestamp in the
 * middle makes old seasons immutable and lets every process derive the same end time.
 */
export function managedPlayerLeagueId(tier: League, now: number): ManagedLeagueId & { leagueId: string } {
  const rule = playerLeagueRule(tier);
  const duration = rule.durationHours * 3_600;
  const endsAt = (Math.floor(Math.max(0, now) / duration) + 1) * duration;
  return { tier, endsAt, division: MANAGED_DIVISION, leagueId: `${tier}-${endsAt}-${MANAGED_DIVISION}` };
}

/** Parse only IDs owned by this scheduler. Unknown production-era IDs fail closed. */
export function parseManagedPlayerLeagueId(value: string): ManagedLeagueId | null {
  const match = /^([1-9]|1[0-6])-(\d{9,11})-(local)$/.exec(value);
  if (!match) return null;
  const tier = Number(match[1]) as League;
  const endsAt = Number(match[2]);
  if (!Number.isSafeInteger(endsAt) || endsAt <= 0) return null;
  playerLeagueRule(tier);
  return { tier, endsAt, division: match[3]! };
}

/**
 * Advance the recovered one-match placement counter after a confirmed PvP settlement.
 *
 * Placement cannot be progressed by a standalone request: callers use this pure decision
 * only inside the same database transaction that accepts both participants' match result.
 * Beginners remain in their separate client-simulated league path. An unknown non-placement
 * LeagueId is also left unchanged because migrating a retired production division without
 * its original deadline could skip an owed result.
 */
export function advancePlayerLeaguePlacementAfterPvp(
  player: PlayerLeaguePlacementInput,
  now: number,
): PlayerLeaguePlacementAdvance | null {
  if (player.beginnersLeague > 0 || parseManagedPlayerLeagueId(player.leagueId)) return null;
  if (player.leagueId && !/^([1-9]|1[0-6])-placement$/.test(player.leagueId)) return null;

  const tier = Math.min(League.Champion, Math.max(League.Bronze3, player.leagueTier)) as League;
  const remainingMatches = Math.max(0, Math.floor(player.remainingMatches));
  if (remainingMatches > 1) {
    return {
      leagueTier: tier,
      leagueId: player.leagueId || `${tier}-placement`,
      leagueDivision: "placement",
      remainingMatches: remainingMatches - 1,
      enteredLeague: false,
    };
  }

  const active = managedPlayerLeagueId(tier, now);
  return {
    leagueTier: tier,
    leagueId: active.leagueId,
    leagueDivision: active.division,
    remainingMatches: 0,
    enteredLeague: true,
    endsAt: active.endsAt,
  };
}

/**
 * Reproduce GameVariables.LeaguePositionPromote/LeaguePositionDemote using integer ranks.
 *
 * The client switches to its underfilled presentation unless count is strictly greater than
 * 30. Underfilled divisions do not promote or demote; only their top ten percent receive the
 * tier's NOTENOUGHTPLAYERSGOLDREWARD. Normal Champion divisions use the three recovered
 * Champion reward constants for first, second, and the rest of the top ten percent.
 */
export function playerLeagueSettlementDecision(
  tier: League,
  position: number,
  playerCount: number,
): LeagueSettlementDecision {
  const rule = playerLeagueRule(tier);
  if (!Number.isInteger(position) || !Number.isInteger(playerCount) || position < 1 || position > playerCount) {
    throw new Error(`Invalid league position ${position}/${playerCount}.`);
  }

  if (playerCount <= PLAYER_LEAGUE_MINIMUM_PLAYERS) {
    const rewardedPositions = Math.ceil(playerCount * 0.1);
    return {
      nextTier: tier,
      rewardGold: position <= rewardedPositions ? rule.underfilledGold : 0,
      notEnoughPlayers: true,
      result: "stay",
    };
  }

  const promoteThrough = Math.ceil(playerCount * rule.promoteFraction);
  const demoteCount = Math.ceil(playerCount * rule.demoteFraction);
  const demoteFrom = playerCount + 1 - demoteCount;
  if (rule.promoteFraction > 0 && position <= promoteThrough) {
    return {
      nextTier: Math.min(League.Champion, tier + 1) as League,
      rewardGold: 0,
      notEnoughPlayers: false,
      result: "promote",
    };
  }
  if (rule.demoteFraction > 0 && position >= demoteFrom) {
    return {
      nextTier: Math.max(League.Bronze3, tier - 1) as League,
      rewardGold: 0,
      notEnoughPlayers: false,
      result: "demote",
    };
  }

  let rewardGold = 0;
  if (tier === League.Champion && position <= Math.ceil(playerCount * CHAMPION_REWARD_FRACTION)) {
    rewardGold = position === 1
      ? CHAMPION_REWARDS.first
      : position === 2
        ? CHAMPION_REWARDS.second
        : CHAMPION_REWARDS.remainingTop;
  }
  return { nextTier: tier, rewardGold, notEnoughPlayers: false, result: "stay" };
}

/** Optional fields consumed by GetPlayerData's league timer and processing UI. */
export function playerLeagueBootFields(leagueId: string, now: number): Record<string, number | boolean> {
  const managed = parseManagedPlayerLeagueId(leagueId);
  if (!managed) return {};
  return managed.endsAt <= now
    ? { LeagueEvaluation: managed.endsAt, PlayerLeagueProcessing: true }
    : { LeagueEvaluation: managed.endsAt };
}
