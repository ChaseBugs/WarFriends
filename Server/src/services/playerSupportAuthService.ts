import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerDocument } from "../db";
import { authenticateModerationAppealSession } from "./authService";

/** Parse one exact player-session Bearer credential without confusing it with ADMIN_SECRET. */
export function parsePlayerSupportAuthorization(value: string | undefined): string | null {
  if (!value) return null;
  const match = /^Bearer ([^\s]{1,4096})$/u.exec(value);
  return match?.[1] ?? null;
}

export async function authenticatePlayerSupportRequest(
  playerId: string | undefined,
  authorization: string | undefined,
): Promise<PlayerDocument> {
  const token = parsePlayerSupportAuthorization(authorization);
  if (!playerId || !token) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Player support authorization required.");
  }
  return authenticateModerationAppealSession(playerId, token);
}
