import assert from "node:assert/strict";
import test from "node:test";
import { currentRequestId, runWithRequestContext } from "../services/requestContextService";

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
