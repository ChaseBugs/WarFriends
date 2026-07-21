/** DatabasePlayer.maxPlayerName and every recovered rename/search input use this exact cap. */
export const PLAYER_ACCOUNT_NAME_MAX_LENGTH = 15;

/**
 * Recognize the canonical durable subset produced by every replacement-server name writer.
 *
 * The recovered client supplies the upper bound but older platform names may legitimately be
 * shorter than the replacement UI's three-character manual-entry minimum. The durable migration
 * boundary therefore requires only a nonempty visible name, while new account and rename requests
 * retain their stricter three-character policy in playerSettingsService.
 */
export function isCanonicalStoredPlayerName(value: unknown): value is string {
  return typeof value === "string"
    && value.length > 0
    && value.length <= PLAYER_ACCOUNT_NAME_MAX_LENGTH
    && value === value.trim()
    && !/[\u0000-\u001f\u007f]/u.test(value);
}
