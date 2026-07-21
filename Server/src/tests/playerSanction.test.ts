import assert from "node:assert/strict";
import test from "node:test";
import type { Collection } from "mongodb";
import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerSanctionDocument } from "../db";
import {
  accountBannedError,
  activeSanctionAt,
  assertPlayerNotSanctioned,
  issuePlayerSanction,
  normalizeSanctionOperationId,
  normalizeSanctionId,
  normalizeTemporaryBanSeconds,
  PlayerSanctionInputError,
  revokePlayerSanction,
  webSocketMessageRequiresSanctionCheck,
} from "../services/playerSanctionService";

function mutationCollection(rows: PlayerSanctionDocument[]): Collection<PlayerSanctionDocument> {
  return {
    async findOne(filter: { _id?: string; operationId?: string }) {
      return rows.find((row) =>
        (filter._id === undefined || row._id === filter._id) &&
        (filter.operationId === undefined || row.operationId === filter.operationId),
      ) ?? null;
    },
    async updateMany() { return { acknowledged: true, matchedCount: 0, modifiedCount: 0 }; },
    async insertOne(row: PlayerSanctionDocument) {
      rows.push(row);
      return { acknowledged: true, insertedId: row._id };
    },
    async updateOne() { return { acknowledged: true, matchedCount: 0, modifiedCount: 0 }; },
    async findOneAndUpdate(
      filter: { _id: string; status: string },
      update: { $set: Partial<PlayerSanctionDocument> },
    ) {
      const row = rows.find((candidate) => candidate._id === filter._id && candidate.status === filter.status);
      if (!row) return null;
      Object.assign(row, update.$set);
      return row;
    },
  } as unknown as Collection<PlayerSanctionDocument>;
}

test("temporary account bans expose the exact recovered client fields", () => {
  const now = new Date("2026-07-21T00:00:00.100Z");
  const error = accountBannedError(
    { id: "player-1", accountName: "Player One" },
    { expiresAt: new Date("2026-07-21T00:01:00.001Z") },
    now,
  );
  assert.equal(error.code, ApiErrorCode.AccountBanned);
  assert.deepEqual(error.details, {
    accountId: "player-1",
    accountName: "Player One",
    seconds: 60,
  });
});

test("permanent bans omit seconds so the stock client selects its permanent dialog", () => {
  const error = accountBannedError(
    { id: "player-2", accountName: "Player Two" },
    {},
    new Date("2026-07-21T00:00:00Z"),
  );
  assert.deepEqual(error.details, { accountId: "player-2", accountName: "Player Two" });
});

test("expired and revoked sanctions are immediately non-blocking", () => {
  const now = new Date("2026-07-21T00:00:00Z");
  assert.equal(activeSanctionAt({ status: "active" }, now), true);
  assert.equal(activeSanctionAt({ status: "active", expiresAt: new Date(now.getTime() + 1) }, now), true);
  assert.equal(activeSanctionAt({ status: "active", expiresAt: now }, now), false);
  assert.equal(activeSanctionAt({ status: "revoked" }, now), false);
  assert.equal(activeSanctionAt({ status: "expired" }, now), false);
});

test("shared authentication sanction check rejects active rows and ignores elapsed rows", async () => {
  const now = new Date("2026-07-21T00:00:00Z");
  let query: unknown;
  const activeCollection = {
    async findOne(filter: unknown) {
      query = filter;
      return {
        _id: "sanction-1",
        playerId: "player-1",
        status: "active",
        reason: "confirmed abuse",
        issuedBy: "moderator@example.test",
        issuedAt: now,
        operationId: "issue-0001",
      } satisfies PlayerSanctionDocument;
    },
  } as unknown as Collection<PlayerSanctionDocument>;

  await assert.rejects(
    assertPlayerNotSanctioned({ id: "player-1", accountName: "Player One" }, now, activeCollection),
    (error: unknown) => error instanceof ApiError && error.code === ApiErrorCode.AccountBanned,
  );
  assert.deepEqual(query, {
    playerId: "player-1",
    status: "active",
    $or: [{ expiresAt: { $exists: false } }, { expiresAt: { $gt: now } }],
  });

  const clearCollection = {
    async findOne() { return null; },
  } as unknown as Collection<PlayerSanctionDocument>;
  await assert.doesNotReject(
    assertPlayerNotSanctioned({ id: "player-1", accountName: "Player One" }, now, clearCollection),
  );
});

test("operator bounds distinguish permanent bans from bounded temporary bans", () => {
  assert.equal(normalizeTemporaryBanSeconds(undefined), undefined);
  assert.equal(normalizeTemporaryBanSeconds(60), 60);
  assert.equal(normalizeSanctionOperationId("moderation:1234"), "moderation:1234");
  assert.equal(
    normalizeSanctionId("123e4567-e89b-42d3-a456-426614174000"),
    "123e4567-e89b-42d3-a456-426614174000",
  );
  assert.throws(() => normalizeTemporaryBanSeconds(59), PlayerSanctionInputError);
  assert.throws(() => normalizeTemporaryBanSeconds(1.5), PlayerSanctionInputError);
  assert.throws(() => normalizeSanctionOperationId("short"), PlayerSanctionInputError);
  assert.throws(() => normalizeSanctionId("moderation:1234"), PlayerSanctionInputError);
});

test("long-lived sockets recheck sanctions before every non-heartbeat action", () => {
  assert.equal(webSocketMessageRequiresSanctionCheck("Identify"), false);
  assert.equal(webSocketMessageRequiresSanctionCheck("Ping"), false);
  assert.equal(webSocketMessageRequiresSanctionCheck("FindMatch"), true);
  assert.equal(webSocketMessageRequiresSanctionCheck("MatchEvent"), true);
  assert.equal(webSocketMessageRequiresSanctionCheck("MatchResult"), true);
  assert.equal(webSocketMessageRequiresSanctionCheck("SendSquadChat"), true);
});

test("issue and revoke operations replay their original audit rows", async () => {
  const rows: PlayerSanctionDocument[] = [];
  const collection = mutationCollection(rows);
  const issuedAt = new Date("2026-07-21T00:00:00Z");
  const issueInput = {
    playerId: "player-1",
    reason: "confirmed abusive conduct",
    issuedBy: "moderator@example.test",
    operationId: "issue:player-1:001",
    durationSeconds: 3600,
  };
  const issued = await issuePlayerSanction(issueInput, issuedAt, collection);
  const replayedIssue = await issuePlayerSanction(
    issueInput,
    new Date("2026-07-21T00:30:00Z"),
    collection,
  );
  assert.equal(issued.replayed, false);
  assert.equal(replayedIssue.replayed, true);
  assert.equal(replayedIssue.sanction._id, issued.sanction._id);
  assert.equal(replayedIssue.sanction.expiresAt?.toISOString(), "2026-07-21T01:00:00.000Z");
  assert.equal(rows.length, 1);

  const revokeInput = {
    sanctionId: issued.sanction._id,
    reason: "appeal accepted",
    revokedBy: "senior-moderator@example.test",
    operationId: "revoke:player-1:001",
  };
  const revokedAt = new Date("2026-07-21T00:45:00Z");
  const revoked = await revokePlayerSanction(revokeInput, revokedAt, collection);
  const replayedRevoke = await revokePlayerSanction(
    revokeInput,
    new Date("2026-07-21T00:50:00Z"),
    collection,
  );
  assert.equal(revoked.replayed, false);
  assert.equal(revoked.sanction.status, "revoked");
  assert.equal(replayedRevoke.replayed, true);
  assert.equal(replayedRevoke.sanction.revokedAt?.toISOString(), revokedAt.toISOString());
});
