import assert from "node:assert/strict";
import test from "node:test";
import { exactInboxMutationMessageId } from "../services/inboxMutationRequestService";

test("direct inbox mutations accept only the recovered exact MessageId field", () => {
  assert.equal(
    exactInboxMutationMessageId({
      PlayerId: "authenticated-player",
      MessageId: "InGameMessage-11111111-1111-4111-8111-111111111111-1784678400",
    }),
    "InGameMessage-11111111-1111-4111-8111-111111111111-1784678400",
  );
  // Extra authentication/buffer aliases cannot redirect the selected durable row.
  assert.equal(exactInboxMutationMessageId({
    MessageId: "message-authority",
    Id: "different-account-alias",
    ObjData: "different-buffer-alias",
  }), "message-authority");
});

test("Id and ObjData never substitute for a missing or malformed direct MessageId", () => {
  for (const request of [
    {},
    { Id: "message-through-account-alias" },
    { ObjData: "message-through-buffer-alias" },
    { MessageId: undefined },
    { MessageId: null },
    { MessageId: 123 },
    { MessageId: "" },
    { MessageId: " padded" },
    { MessageId: "padded " },
    { MessageId: "line\nbreak" },
    { MessageId: "x".repeat(257) },
  ]) {
    assert.throws(() => exactInboxMutationMessageId(request), /MessageId is invalid/i);
  }
});
