import { ApiError, ApiErrorCode } from "../apiErrors";
import { exactDeviceToken, normalizeLocale } from "../services/playerSettingsService";

export interface AccountCreationClientContext {
  locale: string;
  /** Validated client-local hint; never used as reward, calendar, or server-time authority. */
  utcOffsetHours: number;
  deviceToken: string;
}

/**
 * Parse DateTime.Now - DateTime.UtcNow as emitted by C# double.ToString(InvariantCulture).
 *
 * The two DateTime reads are separate, so even whole-hour zones can include a tiny fractional or
 * exponent-form scheduling difference. Accept the complete finite invariant double grammar while
 * bounding it outside any plausible civil offset. The value is diagnostics only: all reward days,
 * deadlines, and receipts continue to derive from server UTC.
 */
export function exactClientUtcOffsetHours(value: unknown): number {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string"
      && value.length <= 64
      && /^-?(?:0|[1-9]\d*)(?:\.\d+)?(?:E[+-]?\d+)?$/u.test(value)
      ? Number(value)
      : Number.NaN;
  if (!Number.isFinite(parsed) || parsed < -15 || parsed > 15) {
    throw new ApiError(ApiErrorCode.UnknownAction, "UtcOffset is invalid.");
  }
  return parsed;
}

function optionalDeviceToken(value: unknown): string {
  return value === undefined ? "" : exactDeviceToken(value);
}

/** Exact shared context sent by recovered CreateAccount and CreateGcAccount builders. */
export function recoveredAccountCreationContext(
  req: Record<string, unknown>,
): AccountCreationClientContext {
  return {
    locale: normalizeLocale(req.Locale),
    utcOffsetHours: exactClientUtcOffsetHours(req.UtcOffset),
    deviceToken: optionalDeviceToken(req.DeviceToken),
  };
}

/**
 * Context for the source-unobserved CreateFullAccount adapter.
 *
 * Preserve the new-account English default only when Locale is absent, and validate UtcOffset if
 * supplied. This route may not turn malformed optional metadata into a stored profile value.
 */
export function optionalAccountCreationContext(
  req: Record<string, unknown>,
): AccountCreationClientContext {
  return {
    locale: req.Locale === undefined ? "en" : normalizeLocale(req.Locale),
    utcOffsetHours: req.UtcOffset === undefined ? 0 : exactClientUtcOffsetHours(req.UtcOffset),
    deviceToken: optionalDeviceToken(req.DeviceToken),
  };
}
