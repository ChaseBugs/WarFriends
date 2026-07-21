import assert from "node:assert/strict";
import test from "node:test";
import {
  exactDatabaseAction,
  exactMinimumClientVersion,
  exactNumericClientVersion,
  exactRequestedNumericClientVersion,
  replacementClientVersionIsAllowed,
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

test("minimum replacement-client policy is an exact startup integer including disabled zero", () => {
  assert.equal(exactMinimumClientVersion(0), 0);
  assert.equal(exactMinimumClientVersion(160), 160);
  assert.equal(exactMinimumClientVersion(2_147_483_647), 2_147_483_647);
  for (const value of [undefined, null, false, "", "0160", "160.0", -1, 160.5, 2_147_483_648, Number.NaN]) {
    assert.throws(() => exactMinimumClientVersion(value), /Minimum client-version policy is invalid/);
  }
});

test("replacement-client aliases must be canonical and agree when both are supplied", () => {
  assert.equal(exactRequestedNumericClientVersion(undefined, undefined), 0);
  assert.equal(exactRequestedNumericClientVersion("160", undefined), 160);
  assert.equal(exactRequestedNumericClientVersion(undefined, 160), 160);
  assert.equal(exactRequestedNumericClientVersion("160", 160), 160);
  for (const aliases of [
    ["160", "161"],
    ["160", "0160"],
    ["1.6.0", undefined],
    [null, undefined],
    [false, 0],
    [Number.NaN, 160],
  ] as const) {
    assert.equal(exactRequestedNumericClientVersion(aliases[0], aliases[1]), undefined);
  }
});

test("enabled replacement-client admission rejects missing, old, malformed, and conflicting claims", () => {
  assert.equal(replacementClientVersionIsAllowed(undefined, undefined, 0), true);
  assert.equal(replacementClientVersionIsAllowed("not-numeric", "161", 0), true);
  assert.equal(replacementClientVersionIsAllowed("160", undefined, 160), true);
  assert.equal(replacementClientVersionIsAllowed("161", 161, 160), true);
  assert.equal(replacementClientVersionIsAllowed(undefined, undefined, 160), false);
  assert.equal(replacementClientVersionIsAllowed("159", undefined, 160), false);
  assert.equal(replacementClientVersionIsAllowed("1.6.0", undefined, 160), false);
  assert.equal(replacementClientVersionIsAllowed("160", "161", 160), false);
});
