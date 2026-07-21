import type { PvpWinStreakState } from "../db";

/** The recovered `WinStreak.TimeStamp` field is a signed C# `int`, not a 64-bit timestamp. */
const MAX_CLIENT_UNIX_SECONDS = 2_147_483_647;

/** `WinstreakInterval` decoded from the 4.9.5 MainScene Constants component. */
export const PVP_WIN_STREAK_INTERVAL_SECONDS = 200;

/**
 * Source-decoded WarBucks tiers for consecutive ranked wins.
 *
 * MainScene contains exact currency values for WinstreakReward1..9. Its nominal tenth row
 * decodes to 1.5 (the same value as VipWarbucksMultiplier), which is not a plausible currency
 * grant and indicates retired/live-data drift in this recovered scene. The offline backend
 * therefore caps progression at the ninth verified tier instead of inventing a tenth amount.
 */
export const PVP_WIN_STREAK_WARBUCKS = Object.freeze([
  400,
  700,
  1_000,
  1_400,
  1_800,
  2_200,
  2_600,
  3_000,
  3_600,
] as const);

/**
 * Validate the complete server-owned streak before boot projection or ranked settlement.
 *
 * Clamping a stored count is unsafe because a damaged value such as 100 would select the maximum
 * verified WarBucks reward. Resetting a malformed value is unsafe for the opposite reason: it
 * silently converts unknown authority into an eligible tier-one grant. The timestamp must also
 * fit the recovered client's signed `int` and cannot be in the future. Otherwise the client's
 * `isInfinite` branch treats a clock-damaged streak as permanently active. Only the exact zero
 * pair represents no streak; a positive count always carries one positive settlement timestamp.
 */
export function validatedPvpWinStreak(
  value: PvpWinStreakState | undefined,
  now: number,
): PvpWinStreakState {
  if (!Number.isSafeInteger(now) || now < 0 || now > MAX_CLIENT_UNIX_SECONDS) {
    throw new Error("PvP win-streak authority timestamp is invalid.");
  }
  if (value === undefined) return { winCount: 0, timestamp: 0 };
  if (!Number.isSafeInteger(value.winCount)
    || value.winCount < 0
    || value.winCount > PVP_WIN_STREAK_WARBUCKS.length
    || !Number.isSafeInteger(value.timestamp)
    || value.timestamp < 0
    || value.timestamp > MAX_CLIENT_UNIX_SECONDS
    || value.timestamp > now
    || (value.winCount === 0) !== (value.timestamp === 0)) {
    throw new Error("Stored PvP win-streak authority is invalid.");
  }
  return { ...value };
}
