import { ApiError, ApiErrorCode } from "../apiErrors";
import type { WarBucksConversionReceiptState } from "../db";
import { progressionRevisionForRead } from "./progressionRevisionAuthorityService";

const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const CONVERSION_ID_PATTERN = /^(?:b)?warbucks([1-6])$/;
const GOLD_PRICES = [50, 200, 500, 1_000, 3_500, 7_000] as const;

/**
 * Validate the narrow lost-response receipt for action 221.
 *
 * Both MainScene A/B prefixes are accepted because deployment configuration may change after a
 * receipt is written; the stored Gold debit must still match that row's source price. The exact
 * WarBucks grant also depends on the historical player level, which the receipt does not retain,
 * so it is constrained to a positive safe integer rather than guessed from today's level.
 */
export function validatedWarBucksConversionReceipt(
  value: WarBucksConversionReceiptState | undefined,
  currentRevision: number,
): WarBucksConversionReceiptState | undefined {
  const revision = progressionRevisionForRead(currentRevision);
  if (value === undefined) return undefined;
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored WarBucks conversion receipt is invalid.");
  }
  const keys = Object.keys(value).sort();
  if (
    keys.length !== 5
    || keys[0] !== "goldDeducted"
    || keys[1] !== "id"
    || keys[2] !== "processedAt"
    || keys[3] !== "progressionRevision"
    || keys[4] !== "warBucksAdded"
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored WarBucks conversion receipt is invalid.");
  }
  const match = typeof value.id === "string" ? CONVERSION_ID_PATTERN.exec(value.id) : null;
  const rowIndex = match ? Number(match[1]) - 1 : -1;
  if (
    rowIndex < 0
    || value.goldDeducted !== GOLD_PRICES[rowIndex]
    || !Number.isSafeInteger(value.warBucksAdded)
    || value.warBucksAdded <= 0
    || !Number.isSafeInteger(value.processedAt)
    || value.processedAt < 0
    || value.processedAt > MAX_DATE_UNIX_SECONDS
    || !Number.isSafeInteger(value.progressionRevision)
    || value.progressionRevision < 0
    || value.progressionRevision > revision
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored WarBucks conversion receipt is invalid.");
  }
  return {
    id: value.id,
    goldDeducted: value.goldDeducted,
    warBucksAdded: value.warBucksAdded,
    processedAt: value.processedAt,
    progressionRevision: value.progressionRevision,
  };
}

export function validatedWarBucksConversionTime(now: number): number {
  if (!Number.isSafeInteger(now) || now < 0 || now > MAX_DATE_UNIX_SECONDS) {
    throw new ApiError(ApiErrorCode.InternalServerError, "WarBucks conversion time is invalid.");
  }
  return now;
}
