import { ApiError, ApiErrorCode } from "../apiErrors";
import { PlayerStatus } from "../constants";
import {
  exactDeviceToken,
  normalizeCountry,
  normalizeLocale,
} from "../services/playerSettingsService";

function canonicalUnsignedInteger(value: unknown): number | undefined {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|[1-9]\d*)$/.test(value)
      ? Number(value)
      : Number.NaN;
  return Number.isSafeInteger(parsed) && parsed >= 0 ? parsed : undefined;
}

/**
 * Parse the action-29 enum emitted through `PlayerStatus.ToString`. Invalid heartbeats remain
 * callback-safe, but return undefined so missing/null/Boolean/array input cannot become a valid
 * Offline or Online transition through JavaScript numeric coercion.
 */
export function exactPlayerStatus(value: unknown): PlayerStatus | undefined {
  const parsed = canonicalUnsignedInteger(value);
  return parsed === PlayerStatus.Offline
    || parsed === PlayerStatus.Online
    || parsed === PlayerStatus.InGame
    ? parsed
    : undefined;
}

/**
 * Resolve action 29 from the recovered `PlayerStatus` request field.
 *
 * Older diagnostic adapters sometimes sent `Status`, but no recovered 1.6.0 caller does. A
 * Status-only request therefore remains the same callback-safe no-op as any malformed heartbeat.
 * When an adapter sends both fields, the extra claim must parse exactly and agree; otherwise a
 * caller could hide a contradictory transition behind canonical-field precedence.
 */
export function requestedPlayerStatus(req: Record<string, unknown>): PlayerStatus | undefined {
  const canonical = exactPlayerStatus(req.PlayerStatus);
  if (canonical === undefined) return undefined;
  if (req.Status === undefined) return canonical;
  return exactPlayerStatus(req.Status) === canonical ? canonical : undefined;
}

export interface DeviceRegistrationRequest {
  deviceToken: string;
  locale: string;
}

/**
 * Parse the complete action-13 registration tuple emitted by `PIPLIJHJHFC`.
 *
 * The stock caller always sends DeviceToken and Locale in the same request. Validating the pair
 * before either value reaches the persistence layer prevents a missing or malformed second field
 * from leaving a token registered with a stale language (or changing language without the token
 * that caused this registration callback). Empty DeviceToken remains the recovered unregister
 * sentinel and is validated by the shared opaque-token contract.
 */
export function requestedDeviceRegistration(req: Record<string, unknown>): DeviceRegistrationRequest {
  if (req.DeviceToken === undefined || req.Locale === undefined) {
    throw new ApiError(ApiErrorCode.UnknownAction, "DeviceToken and Locale are required together.");
  }
  return {
    deviceToken: exactDeviceToken(req.DeviceToken),
    locale: normalizeLocale(req.Locale),
  };
}

/**
 * Parse action 196 from the recovered `NewCountryCode` field.
 *
 * `Country` was accepted by an early diagnostic adapter but is not a stock-client request field.
 * It may accompany the canonical value only when both normalize to the same two-letter code;
 * Country alone, malformed aliases, and conflicting claims cannot mutate public geography.
 */
export function requestedPlayerCountry(req: Record<string, unknown>): string {
  const country = normalizeCountry(req.NewCountryCode);
  if (req.Country !== undefined && normalizeCountry(req.Country) !== country) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Country fields conflict.");
  }
  return country;
}

/** Parse the recovered paid-rename 0/1 integer without accepting truthy/falsy substitutes. */
export function exactRenamePaymentFlag(value: unknown): 0 | 1 {
  const parsed = canonicalUnsignedInteger(value);
  if (parsed !== 0 && parsed !== 1) {
    throw new ApiError(ApiErrorCode.UnknownAction, "PayForRename must be an exact 0 or 1 integer.");
  }
  return parsed;
}
