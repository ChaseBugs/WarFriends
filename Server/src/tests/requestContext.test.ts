import assert from "node:assert/strict";
import test from "node:test";
import {
  currentRequestId,
  outboundRequestHeaders,
  runWithRequestContext,
} from "../services/requestContextService";

test("request correlation survives asynchronous downstream work and remains isolated", async () => {
  assert.equal(currentRequestId(), undefined);
  await Promise.all([
    runWithRequestContext("request-a", async () => {
      await Promise.resolve();
      assert.equal(currentRequestId(), "request-a");
    }),
    runWithRequestContext("request-b", async () => {
      await new Promise<void>((resolve) => setImmediate(resolve));
      assert.equal(currentRequestId(), "request-b");
    }),
  ]);
  assert.equal(currentRequestId(), undefined);
});

test("outbound provider headers forward only generated UUID correlation identity", () => {
  const fallback = "aaaaaaaa-aaaa-4aaa-8aaa-aaaaaaaaaaaa";
  const inbound = "bbbbbbbb-bbbb-4bbb-8bbb-bbbbbbbbbbbb";
  assert.deepEqual(outboundRequestHeaders(fallback), { "X-Request-ID": fallback });
  runWithRequestContext(inbound, () => {
    assert.deepEqual(outboundRequestHeaders(fallback), { "X-Request-ID": inbound });
  });
  runWithRequestContext("player-controlled-text", () => {
    assert.deepEqual(outboundRequestHeaders(fallback), { "X-Request-ID": fallback });
  });
  assert.throws(() => outboundRequestHeaders("not-a-uuid"), /outbound request ID is invalid/);
});
