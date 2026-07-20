import { ApiError, ApiErrorCode } from "../apiErrors";

/**
 * Add a nonnegative server-authored reward to a persisted currency balance safely.
 *
 * Gold and WarBucks may be negative after an authoritative purchase chargeback, so the current
 * balance is allowed to be any safe integer. The reward itself must be nonnegative, and the sum
 * must remain exactly representable by JavaScript. Callers must run this check before marking a
 * claim or receipt complete; otherwise an overflowed wallet and a consumed reward could commit
 * together with no reliable amount to restore on retry.
 */
export function checkedRewardBalance(balance: number, reward: number, label: string): number {
  if (!Number.isSafeInteger(balance) || !Number.isSafeInteger(reward) || reward < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} reward balance is invalid.`);
  }
  const next = balance + reward;
  if (!Number.isSafeInteger(next)) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} reward balance overflowed.`);
  }
  return next;
}
