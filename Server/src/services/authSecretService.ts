import { config } from "../config";

/**
 * Return the active authentication pepper first, followed by temporary verification-only keys.
 *
 * Gameplay session tokens do not require this ring: they are opaque random HMAC outputs stored
 * verbatim in MongoDB and compared directly. Durable custom-password and provider digests do need
 * it because login recomputes those values. Keeping that distinction explicit prevents a normal
 * secret rotation from logging out every device while still allowing durable credentials to be
 * migrated as their owners return.
 */
export function authenticationCredentialSecrets(): readonly string[] {
  return [config.authSecret, ...config.authSecretFallbacks];
}

/**
 * Reject unsafe or ambiguous production key rings before the listener or database starts.
 * Three fallback keys are enough for a staged/emergency rollover without turning every password
 * attempt into an unbounded sequence of expensive scrypt operations.
 */
export function validateAuthenticationSecretConfiguration(isProduction: boolean): void {
  if (!isProduction) return;
  if (config.authSecret.length < 32 || config.authSecret === "change-me-in-production") {
    throw new Error("AUTH_SECRET must contain at least 32 characters in production.");
  }
  if (config.authSecretFallbacks.length > 3) {
    throw new Error("AUTH_SECRET_FALLBACKS may contain at most three comma-separated keys.");
  }
  const seen = new Set<string>([config.authSecret]);
  for (const fallback of config.authSecretFallbacks) {
    if (fallback.length < 32) {
      throw new Error("Every AUTH_SECRET_FALLBACKS key must contain at least 32 characters in production.");
    }
    if (seen.has(fallback)) {
      throw new Error("AUTH_SECRET and AUTH_SECRET_FALLBACKS must contain distinct keys.");
    }
    seen.add(fallback);
  }
}
