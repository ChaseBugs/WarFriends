import assert from "node:assert/strict";
import test from "node:test";
import {
  normalizedDirectMessageBody,
  parseDirectMessageRequest,
} from "../services/directMessageRequestService";

test("direct messages keep authentication PlayerId separate from the explicit recipient", () => {
  assert.deepEqual(parseDirectMessageRequest({
    PlayerId: "authenticated-player",
    ToPlayerId: "recipient-player",
    Message: "  Meet me in battle.  ",
  }), {
    toPlayerId: "recipient-player",
    body: "Meet me in battle.",
  });
  assert.equal(parseDirectMessageRequest({ PlayerId: "authenticated-player" }), null);
  assert.throws(
    () => parseDirectMessageRequest({ PlayerId: "recipient-player", Message: "ambiguous target" }),
    /request is incomplete/i,
  );
});

test("direct-message aliases must agree before a durable message can be selected", () => {
  assert.deepEqual(parseDirectMessageRequest({
    ToPlayerId: "recipient-player",
    Message: "same body",
    Body: "same body",
    Text: "same body",
  }), { toPlayerId: "recipient-player", body: "same body" });
  assert.throws(
    () => parseDirectMessageRequest({ ToPlayerId: "recipient-player", Message: "one", Body: "two" }),
    /aliases conflict/i,
  );
  assert.throws(
    () => parseDirectMessageRequest({ ToPlayerId: "recipient-player" }),
    /request is incomplete/i,
  );
});

test("direct-message validation rejects rather than truncates or mutates invalid evidence", () => {
  assert.equal(normalizedDirectMessageBody(" hello "), "hello");
  for (const invalid of [undefined, null, 123, "", "   ", "line\nbreak", "x".repeat(501)]) {
    assert.throws(() => normalizedDirectMessageBody(invalid), /Direct-message body/i);
  }
  for (const invalidTarget of [undefined, null, 123, "", " padded", "padded ", "line\nbreak", "x".repeat(161)]) {
    assert.throws(
      () => parseDirectMessageRequest({ ToPlayerId: invalidTarget, Message: "hello" }),
      /recipient is invalid/i,
    );
  }
});
