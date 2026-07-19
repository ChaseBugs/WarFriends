import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  claimAssignment,
  claimAssignmentMegaReward,
  getOrCreateAssignments,
  processAssignmentBuffer,
  serializeAssignmentData,
  skipAssignment,
  type BufferedRequestInput,
} from "../services/assignmentService";
import {
  claimStarterAssignment,
  completeStarterAssignments,
  serializeStarterAssignmentsData,
} from "../services/starterAssignmentService";
import { authed, type HandlerEntry } from "./types";

function integer(value: unknown, field: string): number {
  const parsed = Number(value);
  if (!Number.isInteger(parsed)) throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an integer.`);
  return parsed;
}

function bufferId(value: unknown): string {
  if (typeof value !== "string" || value.length < 1 || value.length > 128) {
    throw new ApiError(ApiErrorCode.UnknownAction, "BufferId is invalid.");
  }
  return value;
}

function starterAssignmentIds(value: unknown): string[] {
  if (typeof value !== "string" || value.length > 4_096) {
    throw new ApiError(18501, "AssignmentsIds is invalid.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(18501, "AssignmentsIds is invalid JSON.");
  }
  if (
    !Array.isArray(parsed) ||
    parsed.length < 1 ||
    parsed.length > 10 ||
    parsed.some((id) => typeof id !== "string" || !/^ID_(?:[1-9]|10)$/.test(id))
  ) {
    throw new ApiError(18501, "AssignmentsIds must contain valid starter-assignment IDs.");
  }
  return parsed as string[];
}

function starterAssignmentId(value: unknown): string {
  if (typeof value !== "string" || !/^ID_(?:[1-9]|10)$/.test(value)) {
    throw new ApiError(18501, "AssignmentId is invalid.");
  }
  return value;
}

/**
 * Decode RequestBuffer.requests, which Newtonsoft serializes as an object keyed by numeric
 * request sequence (`{"0":{"action":171,"data":"..."}}`). Sorting keys restores the
 * client's submission order; Count is checked separately by the handler so truncated or
 * injected entries cannot be silently processed.
 */
function bufferedRequests(value: unknown): BufferedRequestInput[] {
  if (typeof value !== "string" || value.length > 256_000) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Requests payload is invalid.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ApiErrorCode.UnknownAction, "Requests payload is invalid JSON.");
  }
  if (!parsed || typeof parsed !== "object" || Array.isArray(parsed)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Requests payload must be an object.");
  }

  return Object.entries(parsed as Record<string, unknown>)
    .sort(([left], [right]) => Number(left) - Number(right))
    .map(([, item]) => {
      if (!item || typeof item !== "object" || Array.isArray(item)) {
        throw new ApiError(ApiErrorCode.UnknownAction, "Buffered request entry is invalid.");
      }
      const request = item as Record<string, unknown>;
      const action = integer(request.action ?? request.Action, "Buffered action");
      const data = request.data ?? request.Data;
      if (typeof data !== "string" || data.length > 64_000) {
        throw new ApiError(ApiErrorCode.UnknownAction, "Buffered request data is invalid.");
      }
      return { action, data };
    });
}

export const assignmentHandlers: Record<number, HandlerEntry> = {
  [DbAction.CompleteStarterAssignments]: authed(async ({ player, req }) => {
    // Unity evaluates local statistics and submits IDs, but this request is only a
    // notification. The service re-evaluates every ID against authenticated server facts;
    // no `completed` flag is accepted directly from a modified APK.
    const result = await completeStarterAssignments(player!.id, starterAssignmentIds(req.AssignmentsIds));
    return ok(DbAction.CompleteStarterAssignments, {
      StarterAssignmentsData: serializeStarterAssignmentsData(result.starterAssignments),
    });
  }),

  // The stock build queues action 186 inside SendRequestBuffer. This direct route preserves
  // compatibility with diagnostic/older builds while applying the same reward validation.
  [DbAction.ClaimStarterAssignment]: authed(async ({ player, req }) => {
    const result = await claimStarterAssignment(
      player!.id,
      starterAssignmentId(req.AssignmentId),
      integer(req.Gold, "Gold"),
      integer(req.WarBucks, "WarBucks"),
    );
    return ok(DbAction.ClaimStarterAssignment, {
      StarterAssignmentsData: serializeStarterAssignmentsData(result.starterAssignments),
      GoldBalance: result.state.gold,
      WarBucksBalance: result.state.warBucks,
    });
  }),

  [DbAction.GetNewAssignments]: authed(async ({ player }) => {
    const result = await getOrCreateAssignments(player!.id);
    return ok(DbAction.GetNewAssignments, {
      AssignmentData: serializeAssignmentData(result.assignments),
    });
  }),

  // Action 214 is the path called by AssignmentsManager in the recovered 1.6.0 build. The
  // older action 112 remains compatible and includes its historic zero-price response field.
  [DbAction.SkipDailyAssignment]: authed(async ({ player, req }) => {
    const result = await skipAssignment(player!.id, integer(req.AssignmentIndex, "AssignmentIndex"));
    return ok(DbAction.SkipDailyAssignment, {
      AssignmentData: serializeAssignmentData(result.assignments),
    });
  }),
  [DbAction.SkipAssignment]: authed(async ({ player, req }) => {
    const result = await skipAssignment(player!.id, integer(req.AssignmentIndex, "AssignmentIndex"));
    return ok(DbAction.SkipAssignment, {
      AssignmentData: serializeAssignmentData(result.assignments),
      WarBucksSkipPrice: 0,
    });
  }),

  // Direct support is useful for diagnostics. The stock client normally wraps this action in
  // SendRequestBuffer, whose replay-safe implementation is below.
  [DbAction.ClaimAssignment]: authed(async ({ player, req }) => {
    const result = await claimAssignment(
      player!.id,
      integer(req.AssignmentId, "AssignmentId"),
      integer(req.Reward, "Reward"),
    );
    return ok(DbAction.ClaimAssignment, {
      AssignmentData: serializeAssignmentData(result.assignments),
      Gold: result.goldAdded ?? 0,
      GoldBalance: result.state.gold,
    });
  }),

  [DbAction.ClaimAssignmentMegaReward]: authed(async ({ player }) => {
    const result = await claimAssignmentMegaReward(player!.id);
    return ok(DbAction.ClaimAssignmentMegaReward, {
      Gold: result.goldAdded ?? 0,
      GoldBalance: result.state.gold,
      AssignmentData: serializeAssignmentData(result.assignments),
    });
  }),

  [DbAction.SendRequestBuffer]: authed(async ({ player, req }) => {
    const id = bufferId(req.BufferId);
    const requests = bufferedRequests(req.Requests);
    const expectedCount = integer(req.Count, "Count");
    if (expectedCount !== requests.length || expectedCount < 0 || expectedCount > 100) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Request buffer count does not match its payload.");
    }
    // Buffered item purchases need the authenticated profile level for the recovered
    // CANBEBOUGHT gate. Passing it from the loaded player prevents a request payload from
    // choosing its own unlock level while preserving one atomic buffer transaction.
    const result = await processAssignmentBuffer(player!.id, id, requests, player!.player.level);
    return ok(DbAction.SendRequestBuffer, {
      BufferId: id,
      RequestsResults: result.requestsResults,
      Replayed: result.replayed,
    });
  }),
};
