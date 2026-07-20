import assert from "node:assert/strict";
import test from "node:test";
import { createInboxCursor, parseInboxCursor } from "../services/socialService";

const TIMESTAMP = Date.UTC(2026, 6, 20, 8, 15, 30, 456);

test("inbox cursor preserves exact time and deterministic same-time message identity", () => {
  // Server-generated message IDs are not always UUIDs; league/squad notifications use readable
  // deterministic keys, so the cursor must safely round-trip spaces and Unicode as well.
  const messageId = "Squad event - Player one - 전투 - 1752999330";
  const cursor = createInboxCursor({ createdAt: new Date(TIMESTAMP), messageId });

  assert.deepEqual(parseInboxCursor(cursor), { v: 1, t: TIMESTAMP, id: messageId });
});

test("inbox cursor rejects malformed, unsupported, and control-character payloads", () => {
  assert.equal(parseInboxCursor(""), null);
  assert.equal(parseInboxCursor("not+base64"), null);
  assert.equal(parseInboxCursor("x".repeat(513)), null);

  const unsupported = Buffer.from(JSON.stringify({ v: 2, t: TIMESTAMP, id: "message-1" })).toString("base64url");
  assert.equal(parseInboxCursor(unsupported), null);
  const control = Buffer.from(JSON.stringify({ v: 1, t: TIMESTAMP, id: "message\n1" })).toString("base64url");
  assert.equal(parseInboxCursor(control), null);
  assert.throws(() => createInboxCursor({ createdAt: new Date(TIMESTAMP), messageId: "message\n1" }));
});
