import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  acknowledgeBufferedMessageIgnores,
  claimAssignment,
  claimAssignmentMegaReward,
  getOrCreateAssignments,
  processAssignmentBuffer,
  serializeAssignmentData,
  skipAssignment,
  type BufferedRequestInput,
} from "../services/assignmentService";
import { ignoreMessage } from "../services/socialService";
import {
  claimStarterAssignment,
  completeStarterAssignments,
  serializeStarterAssignmentsData,
} from "../services/starterAssignmentService";
import { authed, type HandlerEntry } from "./types";
import {
  claimEventAssignment,
  claimEventMilestone,
} from "../services/eventAssignmentService";
import { validatedRequestBufferId } from "../services/requestBufferAuthorityService";
import { exactMatchInteger } from "./matchRequestParsing";

/**
 * Assignment form fields and RequestBuffer integer members originate from C# `int` values.
 * Reuse the exact invariant decimal/JSON-number boundary so JavaScript coercion cannot turn null,
 * booleans, arrays, blanks, signs, fractions, or exponents into reward or sequence authority.
 */
export function requestedAssignmentInteger(value: unknown, field: string): number {
  return exactMatchInteger(value, field);
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
export function bufferedRequests(value: unknown): BufferedRequestInput[] {
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

  const entries = Object.entries(parsed as Record<string, unknown>).map(([key, item]) => {
    if (!/^(?:0|[1-9]\d*)$/.test(key)) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Buffered request sequence is invalid.");
    }
    const sequence = Number(key);
    if (!Number.isSafeInteger(sequence) || sequence > 99) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Buffered request sequence is invalid.");
    }
    return { sequence, item };
  }).sort((left, right) => left.sequence - right.sequence);
  // RequestBuffer.AddRequest uses `requests.Add(requestCount++, value)`. Requiring that exact
  // contiguous key set prevents arbitrary object names or gaps from being silently reordered and
  // accepted merely because the outer Count happens to equal the number of properties.
  if (entries.some((entry, index) => entry.sequence !== index)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Buffered request sequence is invalid.");
  }

  return entries.map(({ item }) => {
    if (!item || typeof item !== "object" || Array.isArray(item)) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Buffered request entry is invalid.");
    }
    const request = item as Record<string, unknown>;
    // Recovered `Request.cs` contains exactly two public fields: lower-case `action` and `data`.
    // Accepting aliases or extra fields creates two possible descriptions of one buffered action;
    // JavaScript property preference would then decide which description receives economy authority.
    // Reject the complete outer buffer before processing any item unless its nested shape is exact.
    const keys = Object.keys(request).sort();
    if (keys.length !== 2 || keys[0] !== "action" || keys[1] !== "data") {
      throw new ApiError(ApiErrorCode.UnknownAction, "Buffered request entry shape is invalid.");
    }
    const action = requestedAssignmentInteger(request.action, "Buffered action");
    const data = request.data;
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
      requestedAssignmentInteger(req.Gold, "Gold"),
      requestedAssignmentInteger(req.WarBucks, "WarBucks"),
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
    const result = await skipAssignment(player!.id, requestedAssignmentInteger(req.AssignmentIndex, "AssignmentIndex"));
    return ok(DbAction.SkipDailyAssignment, {
      AssignmentData: serializeAssignmentData(result.assignments),
    });
  }),
  [DbAction.SkipAssignment]: authed(async ({ player, req }) => {
    const result = await skipAssignment(player!.id, requestedAssignmentInteger(req.AssignmentIndex, "AssignmentIndex"));
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
      requestedAssignmentInteger(req.AssignmentId, "AssignmentId"),
      requestedAssignmentInteger(req.Reward, "Reward"),
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

  // Current Unity normally queues these through RequestBuffer. Direct handlers preserve the
  // same server-owned validation for diagnostic/older builds without trusting echoed rewards.
  [DbAction.ClaimEventAssignment]: authed(async ({ player, req }) => {
    const result = await claimEventAssignment(player!.id, {
      rewardType: requestedAssignmentInteger(req.RewardType, "RewardType"),
      rewardValue: requestedAssignmentInteger(req.RewardValue, "RewardValue"),
    });
    return ok(DbAction.ClaimEventAssignment, {
      EventAssignmentData: JSON.stringify({
        eventId: result.eventAssignment.eventId,
        totalValue: result.eventAssignment.totalValue,
        progress: result.eventAssignment.progress,
        milestones: result.eventAssignment.milestones,
      }),
    });
  }),

  [DbAction.ClaimEventMilestone]: authed(async ({ player, req }) => {
    if (typeof req.RewardValue !== "string" || req.RewardValue.length > 128) {
      throw new ApiError(ApiErrorCode.UnknownAction, "RewardValue is invalid.");
    }
    const result = await claimEventMilestone(player!.id, {
      milestoneId: requestedAssignmentInteger(req.MilestoneId, "MilestoneId"),
      rewardValue: req.RewardValue,
    });
    return ok(DbAction.ClaimEventMilestone, {
      EventAssignmentData: JSON.stringify({
        eventId: result.eventAssignment.eventId,
        totalValue: result.eventAssignment.totalValue,
        progress: result.eventAssignment.progress,
        milestones: result.eventAssignment.milestones,
      }),
    });
  }),

  [DbAction.SendRequestBuffer]: authed(async ({ player, req }) => {
    const id = validatedRequestBufferId(req.BufferId);
    const requests = bufferedRequests(req.Requests);
    const expectedCount = requestedAssignmentInteger(req.Count, "Count");
    if (expectedCount !== requests.length || expectedCount < 0 || expectedCount > 100) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Request buffer count does not match its payload.");
    }
    // Buffered item purchases need the authenticated profile level for the recovered
    // CANBEBOUGHT gate. Passing it from the loaded player prevents a request payload from
    // choosing its own unlock level while preserving one atomic buffer transaction.
    const result = await processAssignmentBuffer(
      player!.id,
      id,
      requests,
      player!.player.level,
      player!.progression?.vipExpiration ?? player!.player.vipExpiration,
      player!.player.leagueTier,
    );
    const pendingMessageIgnores = result.state.pendingMessageIgnores ?? [];
    if (pendingMessageIgnores.length > 0) {
      // Action 12 is idempotent and recipient-filtered in socialService. Drain every durable
      // outbox entry before acknowledging the HTTP request, then clear exactly those IDs from
      // progression. If either database step fails, the uncleared entry survives for retry.
      for (const messageId of pendingMessageIgnores) {
        await ignoreMessage(player!.id, messageId);
      }
      await acknowledgeBufferedMessageIgnores(player!.id, pendingMessageIgnores);
    }
    return ok(DbAction.SendRequestBuffer, {
      BufferId: id,
      RequestsResults: result.requestsResults,
      Replayed: result.replayed,
    });
  }),
};
