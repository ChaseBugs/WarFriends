import assert from "node:assert/strict";
import test from "node:test";
import {
  exactDatabaseAction,
  exactNumericClientVersion,
} from "../handlers/requestEnvelopeParsing";

test("database actions preserve canonical BestHTTP form and exact JSON integer transports", () => {
  assert.equal(exactDatabaseAction("0"), 0);
  assert.equal(exactDatabaseAction("9999999"), 9_999_999);
  assert.equal(exactDatabaseAction(206), 206);
  assert.equal(exactDatabaseAction(2_147_483_647), 2_147_483_647);
});

test("database actions reject JavaScript-coercible and non-C# values", () => {
  for (const value of [
    undefined, null, true, false, [], ["206"], {}, "", " 206", "206 ", "0206", "+206",
    "-1", "206.0", "206e0", -1, 2.5, 2_147_483_648, Number.NaN, Number.POSITIVE_INFINITY,
  ]) {
    assert.equal(exactDatabaseAction(value), undefined);
  }
});

test("numeric replacement-client versions use the same exact nonnegative integer boundary", () => {
  assert.equal(exactNumericClientVersion("160"), 160);
  assert.equal(exactNumericClientVersion(160), 160);
  for (const value of [undefined, null, false, "1.6.0", " 160", "0160", 160.5, Number.NaN]) {
    assert.equal(exactNumericClientVersion(value), undefined);
  }
});
