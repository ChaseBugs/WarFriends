import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState, ProcessedRequestBuffer } from "../db";

export const MAX_PROCESSED_REQUEST_BUFFERS = 20;
export const MAX_PENDING_MESSAGE_IGNORES = 100;
const MAX_BUFFER_REQUESTS = 100;
const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const CONTROL_CHARACTERS = /[\u0000-\u001f\u007f]/;

function authorityError(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

/** Validate a new transport BufferId before it can address or create durable replay authority. */
export function validatedRequestBufferId(value: unknown): string {
  if (
    typeof value !== "string"
    || value.length < 1
    || value.length > 128
    || value !== value.trim()
    || CONTROL_CHARACTERS.test(value)
  ) {
    throw new ApiError(ApiErrorCode.UnknownAction, "BufferId is invalid.");
  }
  return value;
}

function durableBufferId(value: unknown): string {
  try {
    return validatedRequestBufferId(value);
  } catch {
    return authorityError("Stored RequestBuffer ID is invalid.");
  }
}

function durableMessageId(value: unknown): string {
  if (
    typeof value !== "string"
    || value.length < 1
    || value.length > 256
    || value !== value.trim()
    || CONTROL_CHARACTERS.test(value)
  ) {
    return authorityError("Stored message-ignore outbox ID is invalid.");
  }
  return value;
}

function validatedReplayResult(value: unknown): string {
  if (typeof value !== "string" || value.length < 2) {
    return authorityError("Stored RequestBuffer result is invalid.");
  }
  try {
    const parsed: unknown = JSON.parse(value);
    if (!Array.isArray(parsed) || parsed.length > MAX_BUFFER_REQUESTS) {
      return authorityError("Stored RequestBuffer result is invalid.");
    }
  } catch (error) {
    if (error instanceof ApiError) throw error;
    return authorityError("Stored RequestBuffer result is invalid.");
  }
  return value;
}

export interface RequestBufferAuthority {
  processedRequestBuffers: ProcessedRequestBuffer[];
  pendingMessageIgnores: string[];
}

/**
 * Validate the complete private RequestBuffer replay and cross-collection outbox snapshot.
 *
 * A duplicate or malformed replay ID changes which cached byte string `.find()` returns; dropping
 * a malformed row would instead reopen its buffered rewards. Likewise, duplicate/out-of-shape
 * outbox IDs can make acknowledgement remove the wrong work. Fail closed on the full bounded
 * snapshot and leave operator recovery to inspect the original durable evidence.
 */
export function validatedRequestBufferAuthority(
  state: Pick<PlayerProgressionState, "processedRequestBuffers" | "pendingMessageIgnores">,
): RequestBufferAuthority {
  const processed = state.processedRequestBuffers ?? [];
  if (!Array.isArray(processed) || processed.length > MAX_PROCESSED_REQUEST_BUFFERS) {
    return authorityError("Stored RequestBuffer replay cache is invalid.");
  }
  const replayIds = new Set<string>();
  const processedRequestBuffers = processed.map((entry) => {
    if (!entry || typeof entry !== "object" || Array.isArray(entry)) {
      return authorityError("Stored RequestBuffer replay entry is invalid.");
    }
    const keys = Object.keys(entry).sort();
    if (keys.length !== 3 || keys[0] !== "id" || keys[1] !== "processedAt" || keys[2] !== "result") {
      return authorityError("Stored RequestBuffer replay entry is invalid.");
    }
    const id = durableBufferId(entry.id);
    if (replayIds.has(id)) return authorityError("Stored RequestBuffer replay IDs are duplicated.");
    replayIds.add(id);
    if (
      !Number.isSafeInteger(entry.processedAt)
      || entry.processedAt < 0
      || entry.processedAt > MAX_DATE_UNIX_SECONDS
    ) {
      return authorityError("Stored RequestBuffer replay timestamp is invalid.");
    }
    return { id, result: validatedReplayResult(entry.result), processedAt: entry.processedAt };
  });

  const pending = state.pendingMessageIgnores ?? [];
  if (!Array.isArray(pending) || pending.length > MAX_PENDING_MESSAGE_IGNORES) {
    return authorityError("Stored message-ignore outbox is invalid.");
  }
  const pendingIds = new Set<string>();
  const pendingMessageIgnores = pending.map((value) => {
    const id = durableMessageId(value);
    if (pendingIds.has(id)) return authorityError("Stored message-ignore outbox IDs are duplicated.");
    pendingIds.add(id);
    return id;
  });
  return { processedRequestBuffers, pendingMessageIgnores };
}
