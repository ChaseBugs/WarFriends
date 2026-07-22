import { ApiError, ApiErrorCode } from "../apiErrors";
import { requireModeratedText } from "./textModerationService";

export interface DirectMessageRequest {
  toPlayerId: string;
  body: string;
}

const BODY_ALIASES = Object.freeze(["Message", "Body", "Text"] as const);

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.UnknownAction, message);
}

/** Keep the recipient separate from the authenticated request's generic PlayerId identity. */
export function exactDirectMessageTarget(value: unknown): string {
  if (typeof value !== "string"
    || value.length < 1
    || value.length > 160
    || value.trim() !== value
    || /\p{Cc}/u.test(value)) {
    invalid("Direct-message recipient is invalid.");
  }
  return value;
}

/** Validate and normalize presentation whitespace without ever truncating player-authored text. */
export function normalizedDirectMessageBody(value: unknown): string {
  if (typeof value !== "string" || value.length > 500 || /\p{Cc}/u.test(value)) {
    invalid("Direct-message body is invalid.");
  }
  const body = value.trim();
  if (body.length === 0) invalid("Direct-message body is required.");
  return requireModeratedText(body, "Message");
}

/**
 * Parse the replacement direct-message extension to recovered action 2.
 *
 * The stock request always carries `PlayerId` as authentication identity. Reusing that field as a
 * recipient made actor/target interpretation depend on the dispatcher, so direct messages require
 * the unambiguous `ToPlayerId` extension. Multiple text aliases are accepted only when identical.
 */
export function parseDirectMessageRequest(req: Record<string, unknown>): DirectMessageRequest | null {
  const suppliedBodies = BODY_ALIASES
    .filter((alias) => Object.prototype.hasOwnProperty.call(req, alias))
    .map((alias) => req[alias]);
  const hasTarget = Object.prototype.hasOwnProperty.call(req, "ToPlayerId");
  if (!hasTarget && suppliedBodies.length === 0) return null;
  if (!hasTarget || suppliedBodies.length === 0) invalid("Direct-message request is incomplete.");
  if (suppliedBodies.some((value) => value !== suppliedBodies[0])) {
    invalid("Direct-message body aliases conflict.");
  }
  return {
    toPlayerId: exactDirectMessageTarget(req.ToPlayerId),
    body: normalizedDirectMessageBody(suppliedBodies[0]),
  };
}
