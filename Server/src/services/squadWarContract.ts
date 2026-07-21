/**
 * Source-exact Squad Wars balancing recovered from the 4.9.5 MainScene resources.
 *
 * The callable protocol comes from the 1.6.0 C# client, while the values below come from the
 * newer project resource requested for this reconstruction. They are intentionally kept in a
 * small pure module so scheduling and settlement cannot silently drift from the UI's tier and
 * per-member reward calculations.
 */

export const SQUAD_WAR_MIN_LEVEL = 1;
export const SQUAD_WAR_MAX_LEVEL = 8;
export const SQUAD_WAR_MAX_DIVISION_SIZE = 50;
export const SQUAD_WAR_SMALL_DIVISION_LIMIT = 7;
const MAX_CLIENT_UNIX_SECONDS = 2_147_483_647;

/** Level 1..8 -> Gold awarded before the member-position fraction is applied. */
const rewardsByLevel = [
  [100, 50, 25, 17, 11],
  [200, 100, 50, 33, 22],
  [300, 150, 75, 50, 33],
  [400, 200, 100, 67, 45],
  [500, 250, 125, 83, 55],
  [600, 300, 150, 100, 67],
  [800, 400, 200, 133, 89],
  [1_000, 500, 250, 167, 111],
] as const;

/** Squad-member rank bands from MainScene's SquadWarsReward rows. */
const memberRewardFractions = [
  { maximumRank: 1, fraction: 1 },
  { maximumRank: 5, fraction: 2 },
  { maximumRank: 10, fraction: 3 },
  { maximumRank: 19, fraction: 5 },
  { maximumRank: 29, fraction: 10 },
  { maximumRank: 40, fraction: 25 },
  { maximumRank: Number.POSITIVE_INFINITY, fraction: 50 },
] as const;

export interface SquadWarWindow {
  seasonId: string;
  startsAt: Date;
  endsAt: Date;
}

export interface SquadWarRankedValue {
  squadId: string;
  baseScore: number;
  score: number;
}

export interface SquadWarPlacement extends SquadWarRankedValue {
  position: number;
  tier: number;
  nextLevel: number;
}

function boundedLevel(level: number): number {
  if (!Number.isInteger(level)) return SQUAD_WAR_MIN_LEVEL;
  return Math.min(SQUAD_WAR_MAX_LEVEL, Math.max(SQUAD_WAR_MIN_LEVEL, level));
}

/** JavaScript equivalent of Mathf.CeilToInt for the non-negative values used here. */
function ceil(value: number): number {
  return Math.ceil(value);
}

/**
 * Reproduce MEJMLNDFDBP.NJDAEFEJPLL's 1-based reward tier.
 *
 * Divisions of seven or fewer use the fixed 4/6/8/11 cutoffs serialized in MainScene. Larger
 * divisions give tier 1 to first place and use the recovered 20%, 32%, 50%, and 50% boundaries.
 * A return value of zero means the client deliberately shows the no-reward band.
 */
export function squadWarRewardTier(position: number, divisionSize: number): number {
  if (!Number.isInteger(position) || position < 1 || !Number.isInteger(divisionSize) || divisionSize < 1) return 0;
  if (divisionSize <= SQUAD_WAR_SMALL_DIVISION_LIMIT) {
    if (position < 4) return 1;
    if (position < 6) return 2;
    if (position < 8) return 3;
    if (position < 11) return 4;
    return 0;
  }
  if (position === 1) return 1;
  const zeroBased = position - 1;
  if (zeroBased < ceil(divisionSize * 0.20)) return 2;
  if (zeroBased < ceil(divisionSize * 0.32)) return 3;
  if (zeroBased < ceil(divisionSize * 0.50)) return 4;
  if (zeroBased < ceil(divisionSize * 0.50)) return 5;
  return 0;
}

/**
 * Reproduce GameVariables.SquadWarsRewardForMember, including its round-half-up helper.
 */
export function squadWarMemberReward(tier: number, level: number, memberRank: number): number {
  if (!Number.isInteger(tier) || tier < 1 || tier > 5 || !Number.isInteger(memberRank) || memberRank < 1) return 0;
  const reward = rewardsByLevel[boundedLevel(level) - 1]![tier - 1];
  const fraction = memberRewardFractions.find((band) => memberRank <= band.maximumRank)?.fraction ?? 50;
  return Math.floor(reward / fraction + 0.5);
}

/** Promotion/demotion transition used by SquadWarsContent.TypeAccordingToPositionAndDivision. */
export function squadWarNextLevel(position: number, divisionSize: number, level: number): number {
  const current = boundedLevel(level);
  if (divisionSize <= SQUAD_WAR_SMALL_DIVISION_LIMIT) return current;
  const promoteFraction = current === SQUAD_WAR_MIN_LEVEL ? 0.20 : current === SQUAD_WAR_MAX_LEVEL ? 0 : 0.10;
  const demoteFraction = current === SQUAD_WAR_MIN_LEVEL ? 0 : current === SQUAD_WAR_MAX_LEVEL ? 0.20 : 0.10;
  const promoteCount = ceil(divisionSize * promoteFraction);
  const demoteStartZeroBased = Math.floor(divisionSize * (1 - demoteFraction));
  const zeroBased = position - 1;
  if (promoteCount > 0 && zeroBased < promoteCount) return Math.min(SQUAD_WAR_MAX_LEVEL, current + 1);
  if (demoteFraction > 0 && zeroBased >= demoteStartZeroBased) return Math.max(SQUAD_WAR_MIN_LEVEL, current - 1);
  return current;
}

/** Deterministic ordering; the squad ID removes database-order ambiguity from tied scores. */
export function rankSquadWarDivision(
  values: readonly SquadWarRankedValue[],
  level: number,
): SquadWarPlacement[] {
  // Placement determines both currency and promotion. A NaN score makes Array.sort treat the
  // comparator result as zero, silently turning MongoDB input order into reward authority. Reject
  // malformed totals before sorting rather than fabricating a deterministic but incorrect rank.
  if (values.some((value) => (
    !Number.isSafeInteger(value.baseScore)
    || value.baseScore < 0
    || !Number.isSafeInteger(value.score)
    || value.score < 0
    || value.baseScore > Number.MAX_SAFE_INTEGER - value.score
  ))) {
    throw new Error("Stored Squad Wars placement score is invalid.");
  }
  const ranked = [...values].sort((left, right) =>
    (right.baseScore + right.score) - (left.baseScore + left.score)
    || left.squadId.localeCompare(right.squadId, "en"));
  return ranked.map((value, index) => ({
    ...value,
    position: index + 1,
    tier: squadWarRewardTier(index + 1, ranked.length),
    nextLevel: squadWarNextLevel(index + 1, ranked.length, level),
  }));
}

/**
 * Generate reconstruction-owned weekly windows aligned to Monday 00:00 UTC.
 *
 * The retired production calendar is absent from both APKs. A deterministic local calendar is
 * therefore explicit policy rather than a claim about the old live service. The compact base36
 * ID contains no hyphen so a RoundId can retain the client's required `<level>-<token>` shape.
 */
export function squadWarWindowAt(now: Date, durationSeconds = 7 * 24 * 60 * 60): SquadWarWindow {
  if (
    !(now instanceof Date)
    || !Number.isSafeInteger(now.getTime())
    || now.getTime() < 0
    || now.getTime() > MAX_CLIENT_UNIX_SECONDS * 1_000
    || !Number.isSafeInteger(durationSeconds)
    || durationSeconds < 3_600
    || durationSeconds > MAX_CLIENT_UNIX_SECONDS
  ) {
    // The duration defines both the persistent season ID and every settlement deadline. Silently
    // flooring/clamping operator policy would let different nodes derive different authority,
    // while NaN previously produced a superficially shaped `swNaN` season with invalid dates.
    throw new Error("Squad Wars calendar policy is invalid.");
  }
  const duration = durationSeconds;
  const mondayEpochSeconds = Date.UTC(2020, 0, 6) / 1_000;
  const nowSeconds = Math.floor(now.getTime() / 1_000);
  const startsAtSeconds = mondayEpochSeconds
    + Math.floor((nowSeconds - mondayEpochSeconds) / duration) * duration;
  const endsAtSeconds = startsAtSeconds + duration;
  if (
    !Number.isSafeInteger(startsAtSeconds)
    || startsAtSeconds < 0
    || !Number.isSafeInteger(endsAtSeconds)
    || endsAtSeconds > MAX_CLIENT_UNIX_SECONDS
  ) {
    throw new Error("Squad Wars calendar policy is invalid.");
  }
  return {
    seasonId: `sw${startsAtSeconds.toString(36)}`,
    startsAt: new Date(startsAtSeconds * 1_000),
    endsAt: new Date(endsAtSeconds * 1_000),
  };
}

export function squadWarRoundId(level: number, window: Pick<SquadWarWindow, "seasonId">, division: number): string {
  const token = `${window.seasonId.slice(2)}${Math.max(0, Math.floor(division)).toString(36).padStart(2, "0")}`;
  return `${boundedLevel(level)}-${token}`;
}
