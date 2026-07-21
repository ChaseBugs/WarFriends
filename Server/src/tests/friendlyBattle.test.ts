import assert from "node:assert/strict";
import test from "node:test";
import type { FriendlyBattleDocument } from "../db";
import {
  friendlyBattleSettlementDecision,
  friendlyBattleStartDecision,
  parseOfflineBotStartMetadata,
  validateFriendlyBattleId,
  validatedFriendlyBattleReceipt,
} from "../services/friendlyBattleService";

const NOW = new Date("2026-07-20T12:00:00.000Z");

function receipt(values: Partial<FriendlyBattleDocument> = {}): FriendlyBattleDocument {
  return {
    playerId: "player-a",
    battleId: "player-a-1784548800",
    startAction: 64,
    state: "active",
    startedAt: NOW,
    expiresAt: new Date(NOW.getTime() + 86_400_000),
    ...values,
  };
}

test("friendly challenge starts are participant-owned and replay across Photon role migration", () => {
  assert.equal(friendlyBattleStartDecision(null, "player-a", "player-a-1784548800", 64), "create");
  assert.equal(
    friendlyBattleStartDecision(receipt(), "player-a", "player-a-1784548800", 64),
    "replay",
  );
  assert.equal(
    friendlyBattleStartDecision(receipt(), "player-a", "player-a-1784548800", 65),
    "replay",
    "a reconnecting Photon client may become master without creating a second receipt",
  );
  assert.equal(
    friendlyBattleStartDecision(receipt(), "player-b", "player-a-1784548800", 64),
    "invalid",
  );
  assert.equal(
    friendlyBattleStartDecision(
      receipt({ battleKind: "offline-bot" }),
      "player-a",
      "player-a-1784548800",
      64,
      "friendly",
    ),
    "invalid",
    "one battle ID cannot change between direct-challenge and offline-bot classifications",
  );
});

test("offline bot metadata is bounded classification evidence and never reward authority", () => {
  assert.deepEqual(parseOfflineBotStartMetadata("17", "Recovered Bot", "57"), {
    botId: 17,
    botLevel: 57,
  });
  assert.equal(
    friendlyBattleStartDecision(null, "player-a", "player-a-1784548800", 64, "offline-bot"),
    "create",
  );
  assert.equal(
    friendlyBattleStartDecision(
      receipt({ battleKind: "offline-bot" }),
      "player-a",
      "player-a-1784548800",
      64,
      "offline-bot",
    ),
    "replay",
  );
  for (const invalid of [
    [-1, "Bot", 1],
    [1_000_001, "Bot", 1],
    [1, "", 1],
    [1, "Bot\nName", 1],
    [1, "Bot", -1],
    [1, "Bot", 58],
    [false, "Bot", 1],
    [1, "Bot", null],
    ["", "Bot", "0"],
  ] as const) {
    assert.throws(() => parseOfflineBotStartMetadata(invalid[0], invalid[1], invalid[2]));
  }
});

test("friendly settlement is terminal, idempotent, and rejects a changed result", () => {
  assert.equal(
    friendlyBattleSettlementDecision(receipt(), "player-a", "player-a-1784548800", 2),
    "settle",
  );
  const finished = receipt({
    state: "finished",
    endReason: 2,
    settledAt: new Date(NOW.getTime() + 30_000),
    expiresAt: new Date(NOW.getTime() + 30_000 + (7 * 86_400_000)),
  });
  assert.equal(
    friendlyBattleSettlementDecision(finished, "player-a", "player-a-1784548800", 2),
    "replay",
  );
  assert.equal(
    friendlyBattleSettlementDecision(finished, "player-a", "player-a-1784548800", 1),
    "invalid",
  );
  assert.equal(
    friendlyBattleSettlementDecision(null, "player-a", "player-a-1784548800", 2),
    "invalid",
    "GameEnded cannot manufacture a no-reward lifecycle without a prior action 64/65 receipt",
  );
});

test("friendly receipt authority rejects stale or contradictory durable lifecycles", () => {
  const valid = receipt();
  assert.equal(validatedFriendlyBattleReceipt(valid), valid);
  assert.throws(
    () => validatedFriendlyBattleReceipt(receipt({ expiresAt: new Date(NOW.getTime() + 1) })),
    /Stored friendly battle receipt is invalid/,
  );
  assert.throws(
    () => validatedFriendlyBattleReceipt(receipt({ state: "active", endReason: 2 })),
    /Stored friendly battle receipt is invalid/,
  );
  assert.equal(
    friendlyBattleSettlementDecision(
      receipt(),
      "player-a",
      "player-a-1784548800",
      2,
      new Date(NOW.getTime() + 86_400_000),
    ),
    "invalid",
    "logical expiry must close authority even before MongoDB TTL cleanup",
  );
});

test("friendly receipts accept only bounded Photon battle IDs and PvP EndReason values", () => {
  assert.doesNotThrow(() => validateFriendlyBattleId("player_a:room.7+retry@eu-west"));
  for (const invalid of ["", "contains spaces", "slash/value", "x".repeat(161)]) {
    assert.throws(() => validateFriendlyBattleId(invalid));
  }
  for (const invalidReason of [0, 4, 9, 10, 2.5, Number.NaN]) {
    assert.throws(() => (
      friendlyBattleSettlementDecision(receipt(), "player-a", "player-a-1784548800", invalidReason)
    ));
  }
  assert.throws(() => friendlyBattleStartDecision(null, "player-a", "player-a-1784548800", 63));
});
