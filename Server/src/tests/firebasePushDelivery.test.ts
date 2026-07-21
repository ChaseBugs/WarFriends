import assert from "node:assert/strict";
import test from "node:test";
import type { FirebasePushDeliveryDocument } from "../db";
import {
  enqueueFirebaseInboxPush,
  firebasePushDeliveryId,
  runFirebasePushDeliverySweep,
  validatedFirebasePushDelivery,
} from "../services/firebasePushDeliveryService";
import {
  exactFirebasePushDeliveryPolicy,
  firebasePushRetryDelaySeconds,
} from "../services/firebasePushDeliveryPolicyService";

const POLICY = {
  schedulerIntervalSeconds: 60,
  batchSize: 100,
  initialRetrySeconds: 60,
  maximumRetrySeconds: 3_600,
};

function pending(now: Date): FirebasePushDeliveryDocument {
  return {
    _id: firebasePushDeliveryId("player-1", "message-1"),
    recipientPlayerId: "player-1",
    messageId: "message-1",
    status: "pending",
    attempts: 0,
    createdAt: now,
    updatedAt: now,
    nextAttemptAt: now,
    completedAt: null,
    lastDisposition: null,
    terminalReason: null,
  };
}

test("Firebase delivery policy bounds worker pressure and FCM retry timing", () => {
  assert.deepEqual(exactFirebasePushDeliveryPolicy(POLICY), POLICY);
  assert.equal(firebasePushRetryDelaySeconds(0, POLICY), 60);
  assert.equal(firebasePushRetryDelaySeconds(1, POLICY), 120);
  assert.equal(firebasePushRetryDelaySeconds(6, POLICY), 3_600);
  assert.equal(firebasePushRetryDelaySeconds(1_000_000, POLICY), 3_600);

  for (const policy of [
    { ...POLICY, schedulerIntervalSeconds: 4 },
    { ...POLICY, batchSize: 0 },
    { ...POLICY, initialRetrySeconds: 59 },
    { ...POLICY, maximumRetrySeconds: 59 },
    { ...POLICY, maximumRetrySeconds: Number.NaN },
  ]) {
    assert.throws(
      () => exactFirebasePushDeliveryPolicy(policy),
      /Firebase push delivery policy is invalid/,
    );
  }
  assert.throws(() => firebasePushRetryDelaySeconds(-1, POLICY), /attempt is invalid/);
});

test("disabled Firebase delivery performs no database lookup or worker acquisition", async () => {
  const now = new Date("2026-07-22T00:00:00.000Z");
  const pushPolicy = { enabled: false, projectId: "", requestTimeoutMilliseconds: 5_000 };
  assert.equal(await enqueueFirebaseInboxPush("player-1", "message-1", now, undefined, pushPolicy), false);
  assert.deepEqual(await runFirebasePushDeliverySweep(undefined, now, POLICY, pushPolicy), {
    recovered: 0,
    delivered: 0,
    suppressed: 0,
    retried: 0,
    skipped: true,
  });
});

test("Firebase delivery IDs bind the complete recipient and message identity", () => {
  const one = firebasePushDeliveryId("player-1", "message-1");
  assert.match(one, /^[a-f0-9]{64}$/u);
  assert.equal(one, firebasePushDeliveryId("player-1", "message-1"));
  assert.notEqual(one, firebasePushDeliveryId("player-2", "message-1"));
  assert.notEqual(one, firebasePushDeliveryId("player-1", "message-2"));
  assert.throws(() => firebasePushDeliveryId(" player-1", "message-1"), /identity is invalid/);
  assert.throws(() => firebasePushDeliveryId("player-1", "message\n1"), /identity is invalid/);
});

test("Firebase delivery authority enforces pending and terminal state invariants", () => {
  const now = new Date("2026-07-22T00:00:00.000Z");
  const row = pending(now);
  assert.equal(validatedFirebasePushDelivery(row, now), row);

  const delivered: FirebasePushDeliveryDocument = {
    ...row,
    status: "delivered",
    attempts: 1,
    nextAttemptAt: null,
    completedAt: now,
  };
  assert.equal(validatedFirebasePushDelivery(delivered, now), delivered);

  const suppressed: FirebasePushDeliveryDocument = {
    ...row,
    status: "suppressed",
    attempts: 1,
    nextAttemptAt: null,
    completedAt: now,
    terminalReason: "invalid-token",
  };
  assert.equal(validatedFirebasePushDelivery(suppressed, now), suppressed);

  assert.throws(
    () => validatedFirebasePushDelivery({ ...row, _id: "0".repeat(64) }, now),
    /authority is invalid/,
  );
  assert.throws(
    () => validatedFirebasePushDelivery({ ...row, nextAttemptAt: null }, now),
    /authority is invalid/,
  );
  assert.throws(
    () => validatedFirebasePushDelivery({
      ...row,
      nextAttemptAt: new Date(now.getTime() + (8 * 24 * 60 * 60 * 1_000)),
    }, now),
    /authority is invalid/,
  );
  assert.throws(
    () => validatedFirebasePushDelivery({ ...delivered, attempts: 0 }, now),
    /authority is invalid/,
  );
  assert.throws(
    () => validatedFirebasePushDelivery({ ...suppressed, attempts: 0 }, now),
    /authority is invalid/,
  );
  assert.throws(
    () => validatedFirebasePushDelivery({
      ...row,
      updatedAt: new Date(now.getTime() + 1),
    }, now),
    /authority is invalid/,
  );
});
