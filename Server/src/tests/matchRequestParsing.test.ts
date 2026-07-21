import assert from "node:assert/strict";
import test from "node:test";
import { exactMatchInteger } from "../handlers/matchRequestParsing";

test("GameEnded integers preserve canonical C# form and JSON-number adapters", () => {
  assert.equal(exactMatchInteger("0", "EndReason"), 0);
  assert.equal(exactMatchInteger("10", "EndReason"), 10);
  assert.equal(exactMatchInteger(2, "EndReason"), 2);
  assert.equal(exactMatchInteger(2_147_483_647, "MissionIndex"), 2_147_483_647);
});

test("GameEnded integers reject JavaScript-coercible and non-C# values", () => {
  for (const value of [
    undefined, null, true, false, [], ["2"], {}, "", " 2", "2 ", "02", "+2", "-1",
    "2.0", "2e0", -1, 2.5, 2_147_483_648, Number.NaN, Number.POSITIVE_INFINITY,
  ]) {
    assert.throws(() => exactMatchInteger(value, "EndReason"));
  }
});
