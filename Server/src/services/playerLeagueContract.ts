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
  /** `REWARDWARBUCKS`: the source league component granted for a confirmed ranked win. */
  rewardWarBucks: number;
  /** `REWARDSQUADPOINTS`: the source squad contribution granted for that same win. */
  rewardSquadPoints: number;
  /** Retained source factors for the still-unrecovered global/league medal formula. */
  winFactor: number;
  loseFactor: number;
  durationHours: number;
  promoteFraction: number;
  demoteFraction: number;
  underfilledGold: number;
}

export const PLAYER_LEAGUE_RULES: readonly PlayerLeagueRule[] = [
  { tier: League.Bronze3, name: "Bronze3", rewardWarBucks: 800, rewardSquadPoints: 2, winFactor: 1, loseFactor: 0.2, durationHours: 24, promoteFraction: 0.5, demoteFraction: 0, underfilledGold: 10 },
  { tier: League.Bronze2, name: "Bronze2", rewardWarBucks: 900, rewardSquadPoints: 2, winFactor: 1, loseFactor: 0.4, durationHours: 24, promoteFraction: 0.5, demoteFraction: 0.1, underfilledGold: 20 },
  { tier: League.Bronze1, name: "Bronze1", rewardWarBucks: 1000, rewardSquadPoints: 2, winFactor: 1, loseFactor: 0.8, durationHours: 24, promoteFraction: 0.5, demoteFraction: 0.1, underfilledGold: 30 },
  { tier: League.Silver3, name: "Silver3", rewardWarBucks: 1250, rewardSquadPoints: 3, winFactor: 1, loseFactor: 1, durationHours: 72, promoteFraction: 0.3, demoteFraction: 0, underfilledGold: 40 },
  { tier: League.Silver2, name: "Silver2", rewardWarBucks: 1500, rewardSquadPoints: 3, winFactor: 1, loseFactor: 1, durationHours: 72, promoteFraction: 0.3, demoteFraction: 0.1, underfilledGold: 50 },
  { tier: League.Silver1, name: "Silver1", rewardWarBucks: 1750, rewardSquadPoints: 3, winFactor: 1, loseFactor: 1, durationHours: 72, promoteFraction: 0.3, demoteFraction: 0.1, underfilledGold: 60 },
  { tier: League.Gold3, name: "Gold3", rewardWarBucks: 2000, rewardSquadPoints: 4, winFactor: 1, loseFactor: 1, durationHours: 168, promoteFraction: 0.1, demoteFraction: 0, underfilledGold: 70 },
  { tier: League.Gold2, name: "Gold2", rewardWarBucks: 2250, rewardSquadPoints: 4, winFactor: 1, loseFactor: 1, durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 80 },
  { tier: League.Gold1, name: "Gold1", rewardWarBucks: 2500, rewardSquadPoints: 4, winFactor: 1, loseFactor: 1, durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 90 },
  { tier: League.Elite3, name: "Elite3", rewardWarBucks: 2750, rewardSquadPoints: 5, winFactor: 1, loseFactor: 1, durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 100 },
  { tier: League.Elite2, name: "Elite2", rewardWarBucks: 3000, rewardSquadPoints: 5, winFactor: 1, loseFactor: 1, durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 125 },
  { tier: League.Elite1, name: "Elite1", rewardWarBucks: 3250, rewardSquadPoints: 5, winFactor: 1, loseFactor: 1, durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 150 },
  { tier: League.Master3, name: "Master3", rewardWarBucks: 3500, rewardSquadPoints: 6, winFactor: 1, loseFactor: 1, durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 175 },
  { tier: League.Master2, name: "Master2", rewardWarBucks: 3750, rewardSquadPoints: 6, winFactor: 1, loseFactor: 1, durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 200 },
  { tier: League.Master1, name: "Master1", rewardWarBucks: 4000, rewardSquadPoints: 6, winFactor: 1, loseFactor: 1, durationHours: 168, promoteFraction: 0.1, demoteFraction: 0.1, underfilledGold: 225 },
  { tier: League.Champion, name: "Champion", rewardWarBucks: 5000, rewardSquadPoints: 7, winFactor: 1, loseFactor: 1, durationHours: 168, promoteFraction: 0, demoteFraction: 0.1, underfilledGold: 250 },
] as const;

/** `StringConstants.BeginnersRewards`: three exact local beginner-league win rows. */
export const BEGINNER_LEAGUE_REWARDS = Object.freeze([
  { beginnersLeague: 1, rewardWarBucks: 200, rewardSquadPoints: 1 },
  { beginnersLeague: 2, rewardWarBucks: 400, rewardSquadPoints: 1 },
  { beginnersLeague: 3, rewardWarBucks: 600, rewardSquadPoints: 1 },
] as const);

/**
 * Recovered beginner leaderboard rows.
 *
 * `BeginnersLeagues` supplies the maximum-medal curve (50/100/150). Promotion into the
 * next displayed league uses `BeginnersPromotion` keys 2/3/4 (positions 40/35/31). The
 * client renders exactly 100 local fake competitors; its private randomPosition only moves
 * the displayed player by at most two places and must not become backend reward authority.
 */
export const BEGINNER_LEAGUE_RULES = Object.freeze([
  { beginnersLeague: 1, maxMedals: 50, promoteAtOrAbovePosition: 40 },
  { beginnersLeague: 2, maxMedals: 100, promoteAtOrAbovePosition: 35 },
  { beginnersLeague: 3, maxMedals: 150, promoteAtOrAbovePosition: 31 },
] as const);

export interface BeginnerLeagueAdvance {
  beginnersLeague: number;
  medalsBalance: number;
  leagueTier: League;
  leagueId: string;
  leagueDivision: string;
  remainingMatches: number;
  enteredBeginnerLeague: boolean;
  enteredNormalLeague: boolean;
  endsAt?: number;
}

/** Match positive `Mathf.RoundToInt` arithmetic after each single-precision operation. */
function unityPositiveRound(value: number): number {
  return Math.floor(Math.fround(Math.fround(value) + Math.fround(0.5)));
}

/**
 * Reproduce FakePlayersManager.GetCurrentPositionInBeginnersLeague without its visual jitter.
 *
 * The local random offset is stored only in FakePlayersManager and is not sent to the server.
 * Using the deterministic base position gives every account the same promotion boundary while
 * preserving the recovered 20% padding and 99-place linear medal curve.
 */
export function beginnerLeaguePosition(
  beginnersLeague: number,
  leagueMedals: number,
  playersInLeague = 100,
): number {
  const rule = BEGINNER_LEAGUE_RULES.find((row) => row.beginnersLeague === beginnersLeague);
  if (!rule) throw new Error(`Unsupported beginner league ${beginnersLeague}.`);
  if (!Number.isSafeInteger(leagueMedals) || leagueMedals < 0
    || !Number.isSafeInteger(playersInLeague) || playersInLeague < 2) {
    throw new Error("Beginner league position input is invalid.");
  }
  const medalPadding = unityPositiveRound(Math.fround(rule.maxMedals * 0.2));
  const adjustedMaximum = rule.maxMedals + medalPadding;
  const adjustedMedals = leagueMedals + medalPadding;
  const scaled = Math.fround(
    Math.fround(adjustedMedals * (playersInLeague - 1)) / Math.fround(adjustedMaximum),
  );
  return playersInLeague - unityPositiveRound(scaled);
}

/**
 * Advance one beginner league, or enter the managed Bronze division, after settlement.
 *
 * Beginner medal scores carry across tiers: the three recovered curves require roughly
 * 27, 59, and 95 cumulative medals, matching their increasing maximums. On the final transition
 * weekly medals reset to zero because they now belong to a new timed division, while global
 * Skill remains untouched by this function. The final transition enters the managed tier
 * directly; emitting both BeginnersLeague=0 and EnteredLeague matches OGLEHLIPEFM's explicit
 * branch for leaving beginner leagues.
 */
export function advanceBeginnerLeagueAfterPvp(
  player: PlayerLeaguePlacementInput,
  postMatchLeagueMedals: number,
  now: number,
): BeginnerLeagueAdvance | null {
  validatePlayerLeagueProgression(player);
  if (player.beginnersLeague <= 0) return null;
  const rule = BEGINNER_LEAGUE_RULES.find((row) => row.beginnersLeague === player.beginnersLeague);
  if (!rule) throw new Error(`Unsupported beginner league ${player.beginnersLeague}.`);
  const position = beginnerLeaguePosition(player.beginnersLeague, postMatchLeagueMedals);
  if (position > rule.promoteAtOrAbovePosition) return null;

  if (player.beginnersLeague < BEGINNER_LEAGUE_RULES.length) {
    return {
      beginnersLeague: player.beginnersLeague + 1,
      medalsBalance: postMatchLeagueMedals,
      leagueTier: player.leagueTier,
      leagueId: player.leagueId,
      leagueDivision: player.leagueId ? (player.leagueDivision ?? "") : "",
      remainingMatches: player.remainingMatches,
      enteredBeginnerLeague: true,
      enteredNormalLeague: false,
    };
  }

  const tier = Math.min(League.Champion, Math.max(League.Bronze3, player.leagueTier)) as League;
  const active = managedPlayerLeagueId(tier, now);
  return {
    beginnersLeague: 0,
    medalsBalance: 0,
    leagueTier: tier,
    leagueId: active.leagueId,
    leagueDivision: active.division,
    remainingMatches: 0,
    enteredBeginnerLeague: false,
    enteredNormalLeague: true,
    endsAt: active.endsAt,
  };
}

/** MainScene Constants.NotEnoughPlayersForPlayerLeague (decoded ObscuredFloat). */
export const PLAYER_LEAGUE_MINIMUM_PLAYERS = 30;
/** MainScene Constants.LeaguePlacementMatches (decoded ObscuredFloat). */
export const PLAYER_LEAGUE_PLACEMENT_MATCHES = 1;
/** Stock PlayerLeague screen and recovered beginner simulation both operate on 100 rows. */
export const PLAYER_LEAGUE_MAXIMUM_PLAYERS = 100;
/** MainScene Constants.ChampionLeagueTopPlayersForReward (decoded ObscuredFloat). */
export const CHAMPION_REWARD_FRACTION = 0.1;

const CHAMPION_REWARDS = { first: 700, second: 350, remainingTop: 150 } as const;
const LEGACY_MANAGED_DIVISION = "local";
/** Exact IDs emitted by managedPlayerLeagueId; exported so MongoDB discovery cannot drift. */
export const MANAGED_PLAYER_LEAGUE_ID_PATTERN = /^([1-9]|1[0-6])-(\d{9,11})-(local(?:[1-9]\d*)?)$/;
/** Broad backend-owned namespace used only to surface malformed local IDs for repair. */
export const MANAGED_PLAYER_LEAGUE_NAMESPACE_PATTERN = /^[^-]+-[^-]+-local[^-]*$/;

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
  leagueDivision?: string;
  remainingMatches: number;
}

export interface PlayerLeagueIdentityInput {
  leagueTier: League;
  leagueId: string;
  leagueDivision: string;
}

export interface PlayerLeaguePlacementAdvance {
  leagueTier: League;
  leagueId: string;
  leagueDivision: string;
  remainingMatches: number;
  enteredLeague: boolean;
  endsAt?: number;
}

/** Validate the only placement countdown supported by the recovered MainScene contract. */
export function validatedPlayerLeagueRemainingMatches(value: number): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > PLAYER_LEAGUE_PLACEMENT_MATCHES) {
    throw new Error("Player league placement counter is invalid.");
  }
  return value;
}

/**
 * Prove that the durable LeagueId tuple will deserialize to the same tier and division.
 *
 * DatabasePlayer.CreateFromDatabase does not trust separate LeagueTier/LeagueDivision fields:
 * when LeagueId is present it parses the first dash-separated segment as the tier and the final
 * segment as the division. The replacement backend still stores those derived values because its
 * ranking and allocation code consumes them directly. If the three values disagree, the server
 * and stock client would authorize different competitions from one document. Unknown retired
 * production IDs remain supported deliberately; only their source-defined prefix/suffix relation
 * is checked, while their opaque middle segments are left untouched until migration evidence is
 * recovered. An empty ID is the recovered placement fallback and therefore has no stored division.
 */
export function validatePlayerLeagueIdentity(player: PlayerLeagueIdentityInput): void {
  playerLeagueRule(player.leagueTier);
  if (typeof player.leagueId !== "string" || typeof player.leagueDivision !== "string") {
    throw new Error("Player league identity is invalid.");
  }
  if (player.leagueId === "") {
    if (player.leagueDivision !== "") throw new Error("Player league identity is invalid.");
    return;
  }

  const parts = player.leagueId.split("-");
  const tier = parts[0];
  const division = parts[parts.length - 1];
  if (parts.length < 2
    || tier !== String(player.leagueTier)
    || !division
    || division !== player.leagueDivision) {
    throw new Error("Player league identity is invalid.");
  }
}

/**
 * Validate persisted league progression before it can select a reward table or admission path.
 *
 * Clamping is unsafe here: `Math.floor(Infinity)` remains infinite and permanently freezes the
 * recovered one-match placement gate, while a negative beginner tier can incorrectly fall through
 * into normal-league admission. These values are server-owned and have exact source-backed bounds,
 * so damaged legacy documents must stop before boot, tutorial repair, or PvP settlement publishes
 * a contradictory profile.
 */
export function validatePlayerLeagueProgression(player: PlayerLeaguePlacementInput): void {
  if (!Number.isSafeInteger(player.beginnersLeague)
    || player.beginnersLeague < 0
    || player.beginnersLeague > BEGINNER_LEAGUE_RULES.length) {
    throw new Error("Beginner league tier is invalid.");
  }
  playerLeagueRule(player.leagueTier);
  validatedPlayerLeagueRemainingMatches(player.remainingMatches);
  // Pure placement callers may omit the redundant division. Complete durable DTOs always carry
  // it and receive the stronger parser-equivalence proof here and at the public-profile boundary.
  if (player.leagueDivision !== undefined) {
    validatePlayerLeagueIdentity(player as PlayerLeagueIdentityInput);
  }
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
 * present in either client archive, so this replacement uses explicit `localN` buckets and a
 * UTC-aligned recovered-duration window. The timestamp in the middle makes old seasons immutable
 * and lets every process derive the same end time. The optional zero value retains `local` for
 * pre-bounded-allocation rows already active during an upgrade.
 */
export function managedPlayerLeagueId(
  tier: League,
  now: number,
  divisionIndex = 0,
): ManagedLeagueId & { leagueId: string } {
  const rule = playerLeagueRule(tier);
  const duration = rule.durationHours * 3_600;
  const endsAt = (Math.floor(Math.max(0, now) / duration) + 1) * duration;
  if (!Number.isSafeInteger(divisionIndex) || divisionIndex < 0) {
    throw new Error(`Invalid player league division index ${divisionIndex}.`);
  }
  const division = divisionIndex === 0 ? LEGACY_MANAGED_DIVISION : `local${divisionIndex}`;
  return { tier, endsAt, division, leagueId: `${tier}-${endsAt}-${division}` };
}

/** Convert a one-based committed admission ordinal into a one-based bounded division index. */
export function playerLeagueDivisionIndexForOrdinal(ordinal: number): number {
  if (!Number.isSafeInteger(ordinal) || ordinal < 1) {
    throw new Error(`Invalid player league admission ordinal ${ordinal}.`);
  }
  return Math.floor((ordinal - 1) / PLAYER_LEAGUE_MAXIMUM_PLAYERS) + 1;
}

/** Parse only IDs owned by this scheduler. Unknown production-era IDs fail closed. */
export function parseManagedPlayerLeagueId(value: string): ManagedLeagueId | null {
  const match = MANAGED_PLAYER_LEAGUE_ID_PATTERN.exec(value);
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
  validatePlayerLeagueProgression(player);
  if (player.beginnersLeague > 0 || parseManagedPlayerLeagueId(player.leagueId)) return null;
  if (player.leagueId && !/^([1-9]|1[0-6])-placement$/.test(player.leagueId)) return null;

  const tier = Math.min(League.Champion, Math.max(League.Bronze3, player.leagueTier)) as League;
  const remainingMatches = player.remainingMatches;
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

/**
 * Reject damaged competition mirrors before they can influence a leaderboard or season reward.
 *
 * Ranked PvP already writes both fields with checked arithmetic, but imported/legacy MongoDB
 * documents can bypass that transition. MongoDB sorts the stored values before application code
 * sees them, so an `Infinity` medal total would otherwise receive position one and could publish a
 * top-tier Gold message. Settlement validates every member before performing its first write; the
 * public leaderboard uses the same boundary so it never presents corrupted ranking authority.
 */
export function validatePlayerLeagueCompetitionScore(
  medalsBalance: number,
  skill: number,
  playerId: string,
): void {
  if (!Number.isSafeInteger(medalsBalance) || medalsBalance < 0) {
    throw new Error(`Player league medals are invalid for ${playerId}.`);
  }
  if (!Number.isSafeInteger(skill) || skill < 0) {
    throw new Error(`Player league skill is invalid for ${playerId}.`);
  }
}

/** Optional fields consumed by GetPlayerData's league timer and processing UI. */
export function playerLeagueBootFields(leagueId: string, now: number): Record<string, number | boolean> {
  const managed = parseManagedPlayerLeagueId(leagueId);
  if (!managed) return {};
  return managed.endsAt <= now
    ? { LeagueEvaluation: managed.endsAt, PlayerLeagueProcessing: true }
    : { LeagueEvaluation: managed.endsAt };
}
