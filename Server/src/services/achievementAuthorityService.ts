import { ApiError, ApiErrorCode } from "../apiErrors";
import type { AchievementGroupState, AchievementState } from "../db";

const MAX_CLIENT_INTEGER = 2_147_483_647;
const MAX_ACHIEVEMENT_GROUPS = 128;
const MAX_UNKNOWN_TIERS = 64;
const ROOT_KEYS = new Set(["data"]);
const GROUP_KEYS = new Set(["id", "offset", "value", "progress"]);
const TIER_KEYS = new Set(["claimed"]);

/** Scene-exact tier targets; rewards remain in achievementService and never come from this table. */
const KNOWN_TARGETS: Readonly<Record<number, readonly number[]>> = Object.freeze({
  0: [8, 16, 24], 1: [5, 10, 15], 2: [10, 50, 100], 3: [2, 10, 100],
  4: [1, 3, 10], 5: [10, 30, 60], 6: [100, 1_000, 10_000], 7: [30, 300, 3_000],
  8: [5, 50, 500], 9: [10, 25, 100], 10: [1, 10, 50], 11: [15, 150, 300],
  12: [3, 20, 100], 13: [5, 9, 13], 14: [15, 150, 1_500], 15: [7, 14, 29],
  16: [7, 30, 100], 17: [5], 18: [15, 150, 1_500], 19: [1],
});

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function exactObject(value: unknown, keys: ReadonlySet<string>, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) invalid(`${label} is invalid.`);
  const record = value as Record<string, unknown>;
  const actual = Object.keys(record);
  if (actual.length !== keys.size || actual.some((key) => !keys.has(key))) invalid(`${label} is invalid.`);
  return record;
}

function safeClientInteger(value: unknown, label: string, allowNegative = false): number {
  if (!Number.isSafeInteger(value) || (value as number) > MAX_CLIENT_INTEGER
    || (allowNegative ? (value as number) < -MAX_CLIENT_INTEGER - 1 : (value as number) < 0)) {
    invalid(`${label} is invalid.`);
  }
  return value as number;
}

function validatedGroup(value: unknown, index: number, seenIds: Set<number>): AchievementGroupState {
  const record = exactObject(value, GROUP_KEYS, `Stored achievement group ${index}`);
  const id = safeClientInteger(record.id, `Stored achievement group ${index} id`);
  if (seenIds.has(id)) invalid("Stored achievement group IDs are duplicated.");
  seenIds.add(id);
  const offset = safeClientInteger(record.offset, `Stored achievement group ${id} offset`, true);
  // Preserve the feature service's established corruption diagnostic for unsafe progress values;
  // RequestBuffer tests and operator logs already use this exact wording.
  const progressValue = safeClientInteger(record.value, "Stored achievement progress");
  const targets = KNOWN_TARGETS[id];
  if (targets && progressValue > targets[targets.length - 1]!) {
    invalid(`Stored achievement group ${id} value exceeds its final tier.`);
  }
  if (!Array.isArray(record.progress)
    || record.progress.length > (targets?.length ?? MAX_UNKNOWN_TIERS)) {
    invalid(`Stored achievement group ${id} claim state is invalid.`);
  }
  let foundUnclaimed = false;
  const progress = record.progress.map((tier, tierIndex) => {
    const tierRecord = exactObject(tier, TIER_KEYS, `Stored achievement group ${id} tier ${tierIndex}`);
    if (typeof tierRecord.claimed !== "boolean") {
      invalid(`Stored achievement group ${id} claim state is invalid.`);
    }
    if (!tierRecord.claimed) foundUnclaimed = true;
    else if (foundUnclaimed) invalid(`Stored achievement group ${id} claim order is invalid.`);
    if (tierRecord.claimed && targets && progressValue < targets[tierIndex]!) {
      invalid(`Stored achievement group ${id} claimed tier is not earned.`);
    }
    return { claimed: tierRecord.claimed };
  });
  return { id, offset, value: progressValue, progress };
}

/**
 * Validate durable AchievementsData before normalization, comparison, claim, or publication.
 *
 * Missing groups and short known progress arrays remain legal migration inputs because the
 * recovered client and achievementStateFor extend them. Extra known tiers, duplicate IDs, unsafe
 * counters, out-of-order claims, and claimed-but-unearned tiers are corruption: silently merging
 * those shapes could either erase a paid marker or make a reward claimable without its server fact.
 * Well-formed unknown groups are bounded and preserved for forward compatibility but cannot map to
 * a reward until an explicit server definition exists.
 */
export function validatedAchievementState(value: AchievementState | undefined): AchievementState | undefined {
  if (value === undefined) return undefined;
  const root = exactObject(value, ROOT_KEYS, "Stored achievement state");
  if (!Array.isArray(root.data) || root.data.length > MAX_ACHIEVEMENT_GROUPS) {
    invalid("Stored achievement collection is invalid.");
  }
  const seenIds = new Set<number>();
  return { data: root.data.map((group, index) => validatedGroup(group, index, seenIds)) };
}
