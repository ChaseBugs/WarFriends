import { ApiError, ApiErrorCode } from "../apiErrors";
import { MAX_PROCESSED_REQUEST_BUFFERS, validatedRequestBufferId } from "../services/requestBufferAuthorityService";
import { bufferedRequests, requestedAssignmentInteger } from "./assignments";
import type { BufferedRequestInput } from "../services/assignmentService";

export interface RecoveredPendingRequestBuffer {
  id: string;
  requests: BufferedRequestInput[];
}

/**
 * Decode RequestBufferManager.GetJsonData(), which action 34 sends as `Buffers` immediately
 * after login. The stock callback clears its complete local buffer dictionary as soon as
 * GetPlayerData succeeds, so ignoring this field silently loses queued economy mutations.
 *
 * Newtonsoft serializes each RequestBuffer through its four public fields. GetJsonData marks
 * every selected buffer sent before serialization, therefore `alreadySent` must be the JSON
 * Boolean true and the dictionary key must agree exactly with the nested `id`.
 */
export function recoveredGetPlayerDataBuffers(value: unknown): RecoveredPendingRequestBuffer[] {
  // Replacement clients may omit the field. The stock client always sends the string "{}" when
  // there is no work; an explicit null/blank value is malformed rather than another empty form.
  if (value === undefined) return [];
  if (typeof value !== "string" || value.length < 2 || value.length > 2_000_000) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Buffers payload is invalid.");
  }

  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ApiErrorCode.UnknownAction, "Buffers payload is invalid JSON.");
  }
  if (!parsed || typeof parsed !== "object" || Array.isArray(parsed)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Buffers payload must be an object.");
  }

  const entries = Object.entries(parsed as Record<string, unknown>);
  // The durable replay cache retains exactly this many IDs. Processing more in one action-34
  // request would evict an earlier receipt before the whole response is acknowledged and could
  // execute it twice after a transport retry.
  if (entries.length > MAX_PROCESSED_REQUEST_BUFFERS) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Buffers payload contains too many request buffers.");
  }

  return entries.map(([outerId, raw]) => {
    const id = validatedRequestBufferId(outerId);
    if (!raw || typeof raw !== "object" || Array.isArray(raw)) {
      throw new ApiError(ApiErrorCode.UnknownAction, "RequestBuffer snapshot is invalid.");
    }
    const buffer = raw as Record<string, unknown>;
    const keys = Object.keys(buffer).sort();
    if (
      keys.length !== 4
      || keys[0] !== "alreadySent"
      || keys[1] !== "id"
      || keys[2] !== "requestCount"
      || keys[3] !== "requests"
      || buffer.alreadySent !== true
      || buffer.id !== id
    ) {
      throw new ApiError(ApiErrorCode.UnknownAction, "RequestBuffer snapshot shape is invalid.");
    }

    const requestsJson = JSON.stringify(buffer.requests);
    const requests = bufferedRequests(requestsJson);
    const requestCount = requestedAssignmentInteger(buffer.requestCount, "RequestBuffer requestCount");
    if (requestCount !== requests.length || requestCount > 100) {
      throw new ApiError(ApiErrorCode.UnknownAction, "RequestBuffer count does not match its payload.");
    }
    return { id, requests };
  });
}
