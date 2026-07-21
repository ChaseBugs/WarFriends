import assert from "node:assert/strict";
import test from "node:test";
import {
  exactRequestIntegerText,
  exactRequestJsonFiniteNumber,
  exactRequestJsonInteger,
} from "../services/requestJsonNumberService";

const ERROR_CODE = 777;

function hasExpectedCode(error: unknown): boolean {
  return (error as { code?: number }).code === ERROR_CODE;
}

test("C# int dictionary members require exact signed Int32 JSON numbers", () => {
  for (const value of [-2_147_483_648, -1, 0, 1, 2_147_483_647]) {
    assert.equal(exactRequestJsonInteger(value, "Value", ERROR_CODE), value);
  }

  for (const value of [
    undefined,
    null,
    false,
    true,
    "",
    "0",
    [],
    [0],
    0.5,
    Number.NaN,
    Number.NEGATIVE_INFINITY,
    Number.POSITIVE_INFINITY,
    -2_147_483_649,
    2_147_483_648,
  ]) {
    assert.throws(() => exactRequestJsonInteger(value, "Value", ERROR_CODE), hasExpectedCode);
  }
});

test("C# floating dictionary members require actual finite JSON numbers", () => {
  for (const value of [-1.5, 0, 0.6325, 2_147_483_648]) {
    assert.equal(exactRequestJsonFiniteNumber(value, "Value", ERROR_CODE), value);
  }

  for (const value of [undefined, null, false, true, "0.5", [], Number.NaN, Number.POSITIVE_INFINITY]) {
    assert.throws(() => exactRequestJsonFiniteNumber(value, "Value", ERROR_CODE), hasExpectedCode);
  }
});

test("WeaponScreen Index requires its one recovered canonical integer-text shape", () => {
  for (const [wire, parsed] of [["0", 0], ["2", 2], ["2147483647", 2_147_483_647]] as const) {
    assert.equal(exactRequestIntegerText(wire, "Index", ERROR_CODE), parsed);
  }

  for (const value of [
    undefined,
    null,
    2,
    "",
    " 2",
    "2 ",
    "+2",
    "-1",
    "02",
    "2.0",
    "2e0",
    "2147483648",
  ]) {
    assert.throws(() => exactRequestIntegerText(value, "Index", ERROR_CODE), hasExpectedCode);
  }
});
