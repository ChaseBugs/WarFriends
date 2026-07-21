import assert from "node:assert/strict";
import test from "node:test";
import type { Collection } from "mongodb";
import type { PlayerAppealDocument, PlayerAppealReviewEntry, PlayerSanctionDocument } from "../db";
import {
  appealTransitionAllowed,
  decodeAppealCursor,
  encodeAppealCursor,
  listPlayerAppeals,
  normalizeAppealListInput,
  normalizeAppealMessage,
  normalizeAppealOperationId,
  PlayerAppealInputError,
  reviewPlayerAppealInCollections,
  submitPlayerAppeal,
  validatedPlayerAppeal,
} from "../services/playerAppealService";
import { parsePlayerSupportAuthorization } from "../services/playerSupportAuthService";

function sanction(overrides: Partial<PlayerSanctionDocument> = {}): PlayerSanctionDocument {
  return {
    _id: "123e4567-e89b-42d3-a456-426614174000",
    playerId: "player-1",
    status: "active",
    reason: "private moderation reason",
    issuedBy: "moderator@example.test",
    issuedAt: new Date("2026-07-21T00:00:00Z"),
    operationId: "issue:player-1:001",
    ...overrides,
  };
}

function appeal(overrides: Partial<PlayerAppealDocument> = {}): PlayerAppealDocument {
  return {
    _id: "223e4567-e89b-42d3-a456-426614174000",
    sanctionId: "123e4567-e89b-42d3-a456-426614174000",
    playerId: "player-1",
    status: "open",
    message: "Please review this sanction because the reported result is incorrect.",
    submissionOperationId: "appeal:player-1:001",
    createdAt: new Date("2026-07-21T01:00:00Z"),
    updatedAt: new Date("2026-07-21T01:00:00Z"),
    ...overrides,
  };
}

function appealCollection(rows: PlayerAppealDocument[]): Collection<PlayerAppealDocument> {
  return {
    async findOne(filter: Record<string, unknown>) {
      if (typeof filter.submissionOperationId === "string") {
        return rows.find((row) => row.submissionOperationId === filter.submissionOperationId) ?? null;
      }
      if (typeof filter.sanctionId === "string") {
        return rows.find((row) => row.sanctionId === filter.sanctionId) ?? null;
      }
      if (typeof filter._id === "string") {
        return rows.find((row) => row._id === filter._id &&
          (filter.playerId === undefined || row.playerId === filter.playerId)) ?? null;
      }
      const alternatives = filter.$or;
      if (Array.isArray(alternatives)) {
        return rows.find((row) => alternatives.some((alternative) => {
          const candidate = alternative as Record<string, unknown>;
          return candidate.sanctionId === row.sanctionId ||
            candidate.submissionOperationId === row.submissionOperationId;
        })) ?? null;
      }
      return null;
    },
    async insertOne(row: PlayerAppealDocument) {
      rows.push(row);
      return { acknowledged: true, insertedId: row._id };
    },
  } as unknown as Collection<PlayerAppealDocument>;
}

function sanctionCollection(rows: PlayerSanctionDocument[]): Collection<PlayerSanctionDocument> {
  return {
    async findOne(filter: { _id: string; playerId: string }) {
      return rows.find((row) => row._id === filter._id && row.playerId === filter.playerId) ?? null;
    },
  } as unknown as Collection<PlayerSanctionDocument>;
}

function reviewAppealCollection(rows: PlayerAppealDocument[]): Collection<PlayerAppealDocument> {
  return {
    async findOne(filter: Record<string, unknown>) {
      if (typeof filter._id === "string") return rows.find((row) => row._id === filter._id) ?? null;
      const operationId = filter["reviewHistory.operationId"];
      if (typeof operationId === "string") {
        return rows.find((row) => row.reviewHistory?.some((entry) => entry.operationId === operationId)) ?? null;
      }
      return null;
    },
    async findOneAndUpdate(
      filter: Record<string, unknown>,
      update: {
        $set: { status: PlayerAppealDocument["status"]; updatedAt: Date };
        $push: { reviewHistory: PlayerAppealReviewEntry };
      },
    ) {
      const row = rows.find((candidate) =>
        candidate._id === filter._id &&
        candidate.status === filter.status &&
        !candidate.reviewHistory?.some((entry) => entry.operationId === update.$push.reviewHistory.operationId),
      );
      if (!row) return null;
      row.status = update.$set.status;
      row.updatedAt = update.$set.updatedAt;
      row.reviewHistory = [...(row.reviewHistory ?? []), update.$push.reviewHistory];
      return row;
    },
  } as unknown as Collection<PlayerAppealDocument>;
}

function reviewSanctionCollection(rows: PlayerSanctionDocument[]): Collection<PlayerSanctionDocument> {
  return {
    async findOne(filter: { _id: string; playerId: string }) {
      return rows.find((row) => row._id === filter._id && row.playerId === filter.playerId) ?? null;
    },
    async updateOne(
      filter: { _id: string; playerId: string; status: PlayerSanctionDocument["status"] },
      update: { $set: Partial<PlayerSanctionDocument> },
    ) {
      const row = rows.find((candidate) =>
        candidate._id === filter._id && candidate.playerId === filter.playerId && candidate.status === filter.status,
      );
      if (!row) return { acknowledged: true, matchedCount: 0, modifiedCount: 0 };
      Object.assign(row, update.$set);
      return { acknowledged: true, matchedCount: 1, modifiedCount: 1 };
    },
  } as unknown as Collection<PlayerSanctionDocument>;
}

function listCollection(
  rows: PlayerAppealDocument[],
  capture: { filter?: Record<string, unknown>; sort?: Record<string, number>; limit?: number },
): Collection<PlayerAppealDocument> {
  return {
    find(filter: Record<string, unknown>) {
      capture.filter = filter;
      const cursor = {
        sort(sort: Record<string, number>) {
          capture.sort = sort;
          return cursor;
        },
        limit(limit: number) {
          capture.limit = limit;
          return cursor;
        },
        async toArray() { return rows; },
      };
      return cursor;
    },
  } as unknown as Collection<PlayerAppealDocument>;
}

test("player support accepts one exact Bearer session credential", () => {
  assert.equal(parsePlayerSupportAuthorization("Bearer session-token"), "session-token");
  assert.equal(parsePlayerSupportAuthorization(undefined), null);
  assert.equal(parsePlayerSupportAuthorization("Basic session-token"), null);
  assert.equal(parsePlayerSupportAuthorization("Bearer token extra"), null);
  assert.equal(parsePlayerSupportAuthorization("Bearer "), null);
});

test("appeal input is bounded and operation keys are retry-safe identifiers", () => {
  assert.equal(
    normalizeAppealMessage("  Please   review this sanction because it is incorrect. "),
    "Please review this sanction because it is incorrect.",
  );
  assert.equal(normalizeAppealOperationId("appeal:player-1:001"), "appeal:player-1:001");
  assert.throws(() => normalizeAppealMessage("too short"), PlayerAppealInputError);
  assert.throws(() => normalizeAppealMessage("x".repeat(2001)), PlayerAppealInputError);
  assert.throws(() => normalizeAppealOperationId("short"), PlayerAppealInputError);
});

test("active owned sanction accepts one appeal and exact retry replays it", async () => {
  const appeals: PlayerAppealDocument[] = [];
  const sanctions = [sanction()];
  const input = {
    sanctionId: sanctions[0]!._id,
    message: "Please review this sanction because the reported result is incorrect.",
    operationId: "appeal:player-1:001",
  };
  const createdAt = new Date("2026-07-21T01:00:00Z");
  const first = await submitPlayerAppeal(
    "player-1",
    input,
    createdAt,
    appealCollection(appeals),
    sanctionCollection(sanctions),
  );
  const replay = await submitPlayerAppeal(
    "player-1",
    input,
    new Date("2026-07-21T02:00:00Z"),
    appealCollection(appeals),
    sanctionCollection(sanctions),
  );
  assert.equal(first.replayed, false);
  assert.equal(replay.replayed, true);
  assert.equal(replay.appeal._id, first.appeal._id);
  assert.equal(replay.appeal.createdAt.toISOString(), createdAt.toISOString());
  assert.equal(appeals.length, 1);
});

test("appeal cannot target another player, an expired sanction, or change first submission", async () => {
  const active = sanction();
  const existing = appeal();
  await assert.rejects(
    submitPlayerAppeal(
      "player-2",
      {
        sanctionId: active._id,
        message: "Please review this sanction because it belongs to another account.",
        operationId: "appeal:player-2:001",
      },
      new Date("2026-07-21T01:00:00Z"),
      appealCollection([]),
      sanctionCollection([active]),
    ),
    (error: unknown) => error instanceof PlayerAppealInputError && error.httpStatus === 404,
  );
  await assert.rejects(
    submitPlayerAppeal(
      "player-1",
      {
        sanctionId: active._id,
        message: "Please review this sanction even though its temporary period ended.",
        operationId: "appeal:player-1:002",
      },
      new Date("2026-07-21T02:00:00Z"),
      appealCollection([]),
      sanctionCollection([sanction({
        durationSeconds: 3600,
        expiresAt: new Date("2026-07-21T01:00:00Z"),
      })]),
    ),
    (error: unknown) => error instanceof PlayerAppealInputError && error.httpStatus === 409,
  );
  await assert.rejects(
    submitPlayerAppeal(
      "player-1",
      {
        sanctionId: active._id,
        message: "This changed message must not replace the first appeal submission.",
        operationId: "appeal:player-1:002",
      },
      new Date("2026-07-21T02:00:00Z"),
      appealCollection([existing]),
      sanctionCollection([active]),
    ),
    (error: unknown) => error instanceof PlayerAppealInputError && error.httpStatus === 409,
  );
});

test("appeal queue cursor preserves newest-first createdAt and UUID ordering", async () => {
  const newer = appeal({ _id: "223e4567-e89b-42d3-a456-426614174001" });
  const older = appeal({
    _id: "223e4567-e89b-42d3-a456-426614174000",
    createdAt: new Date("2026-07-21T00:59:00Z"),
    updatedAt: new Date("2026-07-21T00:59:00Z"),
  });
  const encoded = encodeAppealCursor(newer);
  const decoded = decodeAppealCursor(encoded);
  assert.equal(decoded?.createdAt.toISOString(), newer.createdAt.toISOString());
  assert.equal(decoded?.appealId, newer._id);

  const capture: { filter?: Record<string, unknown>; sort?: Record<string, number>; limit?: number } = {};
  const page = await listPlayerAppeals(
    { status: "open", playerId: "player-1", limit: 1 },
    listCollection([newer, older], capture),
  );
  assert.deepEqual(page.appeals.map((row) => row._id), [newer._id]);
  assert.ok(page.nextCursor);
  assert.deepEqual(capture.filter, { status: "open", playerId: "player-1" });
  assert.deepEqual(capture.sort, { createdAt: -1, _id: -1 });
  assert.equal(capture.limit, 2);

  const nextCapture: typeof capture = {};
  await listPlayerAppeals(
    { status: "open", playerId: "player-1", limit: 1, cursor: page.nextCursor },
    listCollection([older], nextCapture),
  );
  assert.deepEqual(nextCapture.filter, {
    status: "open",
    playerId: "player-1",
    $or: [
      { createdAt: { $lt: newer.createdAt } },
      { createdAt: newer.createdAt, _id: { $lt: newer._id } },
    ],
  });
});

test("appeal list normalizer rejects unknown status and oversized pages", () => {
  assert.deepEqual(normalizeAppealListInput({ status: "open", playerId: "player-1", limit: "25" }), {
    status: "open",
    playerId: "player-1",
    cursor: undefined,
    limit: 25,
  });
  assert.throws(() => normalizeAppealListInput({ status: "deleted" }), PlayerAppealInputError);
  assert.throws(() => normalizeAppealListInput({ limit: 101 }), PlayerAppealInputError);
});

test("appeal transitions permit review, decision, and withdrawal but keep terminal states immutable", () => {
  assert.equal(appealTransitionAllowed("open", "reviewing"), true);
  assert.equal(appealTransitionAllowed("open", "withdrawn"), true);
  assert.equal(appealTransitionAllowed("reviewing", "accepted"), true);
  assert.equal(appealTransitionAllowed("reviewing", "rejected"), true);
  assert.equal(appealTransitionAllowed("reviewing", "open"), false);
  assert.equal(appealTransitionAllowed("accepted", "rejected"), false);
  assert.equal(appealTransitionAllowed("withdrawn", "reviewing"), false);
});

test("complete appeal authority binds intake, status, and the ordered audit projection", () => {
  const reviewedAt = new Date("2026-07-21T02:00:00Z");
  const valid = appeal({
    status: "accepted",
    updatedAt: reviewedAt,
    reviewHistory: [{
      operationId: "appeal-review:0001",
      fromStatus: "open",
      toStatus: "accepted",
      actor: "moderator@example.test",
      note: "The appeal is supported by the reviewed evidence.",
      createdAt: reviewedAt,
    }],
  });
  assert.equal(validatedPlayerAppeal(valid, reviewedAt), valid);
  assert.throws(
    () => validatedPlayerAppeal({ ...valid, reviewHistory: undefined }, reviewedAt),
    /player appeal authority is invalid/,
  );
  assert.throws(
    () => validatedPlayerAppeal({ ...valid, updatedAt: new Date(reviewedAt.getTime() + 1) }, reviewedAt),
    /player appeal authority is invalid/,
  );
});

test("accepting an appeal revokes its active sanction and exact retry appends no second audit entry", async () => {
  const appeals = [appeal()];
  const sanctions = [sanction()];
  const input = {
    appealId: appeals[0]!._id,
    expectedStatus: "open" as const,
    status: "accepted" as const,
    actor: "moderator@example.test",
    note: "Account evidence did not support this sanction.",
    operationId: "appeal-review:accepted:001",
  };
  const decidedAt = new Date("2026-07-21T02:00:00Z");
  const first = await reviewPlayerAppealInCollections(
    input,
    decidedAt,
    reviewAppealCollection(appeals),
    reviewSanctionCollection(sanctions),
  );
  const replay = await reviewPlayerAppealInCollections(
    input,
    new Date("2026-07-21T03:00:00Z"),
    reviewAppealCollection(appeals),
    reviewSanctionCollection(sanctions),
  );

  assert.equal(first.replayed, false);
  assert.equal(replay.replayed, true);
  assert.equal(appeals[0]!.status, "accepted");
  assert.equal(appeals[0]!.reviewHistory?.length, 1);
  assert.equal(appeals[0]!.reviewHistory?.[0]?.createdAt.toISOString(), decidedAt.toISOString());
  assert.equal(sanctions[0]!.status, "revoked");
  assert.equal(sanctions[0]!.revokedBy, input.actor);
  assert.equal(sanctions[0]!.revocationOperationId, `appeal:${appeals[0]!._id}`);
});

test("rejecting or withdrawing an appeal does not change the sanction", async () => {
  for (const status of ["rejected", "withdrawn"] as const) {
    const appeals = [appeal()];
    const sanctions = [sanction()];
    await reviewPlayerAppealInCollections(
      {
        appealId: appeals[0]!._id,
        expectedStatus: "open",
        status,
        actor: status === "withdrawn" ? "player:player-1" : "moderator@example.test",
        note: status === "withdrawn" ? "Withdrawn by player." : "Available evidence supports the sanction.",
        operationId: `appeal-review:${status}:001`,
      },
      new Date("2026-07-21T02:00:00Z"),
      reviewAppealCollection(appeals),
      reviewSanctionCollection(sanctions),
    );
    assert.equal(appeals[0]!.status, status);
    assert.equal(sanctions[0]!.status, "active");
  }
});

test("appeal decisions reject stale status, terminal rewrites, changed retries, and blank terminal notes", async () => {
  const initialEntry: PlayerAppealReviewEntry = {
    operationId: "appeal-review:reviewing:001",
    fromStatus: "open",
    toStatus: "reviewing",
    actor: "moderator@example.test",
    note: "Assigned for evidence review.",
    createdAt: new Date("2026-07-21T01:30:00Z"),
  };
  const appeals = [appeal({
    status: "reviewing",
    reviewHistory: [initialEntry],
    updatedAt: initialEntry.createdAt,
  })];
  const sanctions = [sanction()];
  const collection = reviewAppealCollection(appeals);
  const sanctionRows = reviewSanctionCollection(sanctions);

  await assert.rejects(
    reviewPlayerAppealInCollections({
      appealId: appeals[0]!._id,
      expectedStatus: "open",
      status: "rejected",
      actor: "moderator@example.test",
      note: "Stale queue decision.",
      operationId: "appeal-review:rejected:002",
    }, new Date(), collection, sanctionRows),
    (error: unknown) => error instanceof PlayerAppealInputError && error.httpStatus === 409,
  );
  await assert.rejects(
    reviewPlayerAppealInCollections({
      appealId: appeals[0]!._id,
      expectedStatus: "open",
      status: "accepted",
      actor: "moderator@example.test",
      note: "Changed retry intent.",
      operationId: initialEntry.operationId,
    }, new Date(), collection, sanctionRows),
    (error: unknown) => error instanceof PlayerAppealInputError && error.httpStatus === 409,
  );

  appeals[0]!.status = "rejected";
  await assert.rejects(
    reviewPlayerAppealInCollections({
      appealId: appeals[0]!._id,
      expectedStatus: "reviewing",
      status: "accepted",
      actor: "moderator@example.test",
      note: "Cannot rewrite a terminal decision.",
      operationId: "appeal-review:accepted:003",
    }, new Date(), collection, sanctionRows),
    /player appeal authority is invalid/,
  );
  await assert.rejects(
    reviewPlayerAppealInCollections({
      appealId: appeal()._id,
      expectedStatus: "open",
      status: "accepted",
      actor: "moderator@example.test",
      note: "",
      operationId: "appeal-review:accepted:004",
    }, new Date(), reviewAppealCollection([appeal()]), sanctionRows),
    (error: unknown) => error instanceof PlayerAppealInputError && error.httpStatus === 400,
  );
});
