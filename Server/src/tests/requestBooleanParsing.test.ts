import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import {
  exactBinaryBoolean,
  exactCsharpBoolean,
} from "../handlers/requestBooleanParsing";

test("match flags accept only recovered 0/1 form text or JSON Booleans", () => {
  assert.equal(exactBinaryBoolean("1", "IsMatchMaking"), true);
  assert.equal(exactBinaryBoolean("0", "IsMatchMaking"), false);
  assert.equal(exactBinaryBoolean(true, "IsMatchMaking"), true);
  assert.equal(exactBinaryBoolean(false, "IsMatchMaking"), false);
  assert.equal(exactBinaryBoolean(undefined, "IsWarArena", false), undefined);
});

test("match flags reject aliases instead of selecting a different lifecycle", () => {
  for (const value of [undefined, null, 0, 1, "true", "false", "True", "False", " 1", "1 ", [], ["1"], {}]) {
    assert.throws(
      () => exactBinaryBoolean(value, "IsMatchMaking"),
      (error: unknown) => (
        typeof error === "object"
        && error !== null
        && "code" in error
        && error.code === ApiErrorCode.UnknownAction
      ),
    );
  }
});

test("rental choice accepts only C# Boolean form text or JSON Booleans", () => {
  assert.equal(exactCsharpBoolean("True", "buyRentalDiscounted"), true);
  assert.equal(exactCsharpBoolean("False", "buyRentalDiscounted"), false);
  assert.equal(exactCsharpBoolean(true, "buyRentalDiscounted"), true);
  assert.equal(exactCsharpBoolean(false, "buyRentalDiscounted"), false);
});

test("rental choice rejects truthy aliases before an inventory transition", () => {
  for (const value of [undefined, null, 0, 1, "0", "1", "true", "false", " TRUE", "False ", [], ["True"], {}]) {
    assert.throws(
      () => exactCsharpBoolean(value, "buyRentalDiscounted"),
      (error: unknown) => (
        typeof error === "object"
        && error !== null
        && "code" in error
        && error.code === ApiErrorCode.UnknownAction
      ),
    );
  }
});
