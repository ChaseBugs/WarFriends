import { players, type PlayerDocument } from "../db";
import type { NotificationSettingsDTO } from "../dtos";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { requireModeratedText } from "./textModerationService";

const DEFAULT_NOTIFICATION_SETTINGS: NotificationSettingsDTO = {
  challenge: true,
  squadStatus: true,
  squadEvents: true,
  maintenance: false,
  playerLeague: true,
  dailyRewardNotification: true,
};

/**
 * Normalize a display name at the server boundary. Trimming before the length check prevents
 * visually blank names, and rejecting control characters prevents line-breaking or invisible
 * terminal/UI content. Unicode letters are retained because the original game is localized.
 */
export function normalizePlayerName(value: unknown): string {
  if (typeof value !== "string") throw new ApiError(ApiErrorCode.UnknownAction, "A player name is required.");
  const name = value.trim();
  if (name.length < 3 || name.length > 15 || /[\u0000-\u001f\u007f]/u.test(name)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Player name must contain 3 to 15 visible characters.");
  }
  return requireModeratedText(name, "Player name");
}

/** Reject a case-insensitive collision before updating the public account name. */
export async function ensurePlayerNameAvailable(playerId: string, name: string): Promise<void> {
  const normalizedAccountName = name.toLocaleLowerCase("en-US");
  const existing = await players().findOne(
    { normalizedAccountName, id: { $ne: playerId } },
    { projection: { id: 1 } },
  );
  if (existing) throw new ApiError(ApiErrorCode.UnknownAction, "Player name is already in use.");
}

/**
 * Parse the exact JSON object emitted by SettingsManager. Unknown keys are ignored so a newer
 * client can add preferences without breaking an older server, while known keys must be real
 * booleans to avoid JavaScript truthiness changing a user's notification consent.
 */
export function parseNotificationSettings(value: unknown, current?: NotificationSettingsDTO): NotificationSettingsDTO {
  if (typeof value !== "string" || value.length > 4096) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Invalid settings payload.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ApiErrorCode.UnknownAction, "Settings must be valid JSON.");
  }
  if (!parsed || typeof parsed !== "object" || Array.isArray(parsed)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Settings must be a JSON object.");
  }

  const source = parsed as Record<string, unknown>;
  const result = { ...(current ?? DEFAULT_NOTIFICATION_SETTINGS) };
  for (const key of Object.keys(DEFAULT_NOTIFICATION_SETTINGS) as (keyof NotificationSettingsDTO)[]) {
    if (source[key] === undefined) continue;
    if (typeof source[key] !== "boolean") {
      throw new ApiError(ApiErrorCode.UnknownAction, `Setting ${key} must be boolean.`);
    }
    result[key] = source[key];
  }
  return result;
}

/** Normalize locale tags such as en, en-US, pt-BR, or zh-Hans without accepting free text. */
export function normalizeLocale(value: unknown): string {
  if (typeof value !== "string") throw new ApiError(ApiErrorCode.UnknownAction, "Locale is required.");
  const locale = value.trim();
  if (!/^[A-Za-z]{2,3}(?:-[A-Za-z]{2,8}){0,2}$/u.test(locale)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Invalid locale.");
  }
  return locale;
}

/** A country code is optional, but when present it must be an ISO-style two-letter code. */
export function normalizeCountry(value: unknown): string {
  if (typeof value !== "string") throw new ApiError(ApiErrorCode.UnknownAction, "Country code is required.");
  const country = value.trim().toUpperCase();
  if (!/^[A-Z]{2}$/u.test(country)) throw new ApiError(ApiErrorCode.UnknownAction, "Invalid country code.");
  return country;
}

/** Resolve settings for legacy player rows created before notificationSettings was added. */
export function settingsForPlayer(player: PlayerDocument): NotificationSettingsDTO {
  return player.player.notificationSettings ?? { ...DEFAULT_NOTIFICATION_SETTINGS };
}
