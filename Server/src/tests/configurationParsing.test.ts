import assert from "node:assert/strict";
import test from "node:test";
import { exactEnvironmentBoolean } from "../config";

test("deployment Boolean switches preserve exact case-insensitive literals and defaults", () => {
  assert.equal(exactEnvironmentBoolean(undefined, true, "TEST_SWITCH"), true);
  assert.equal(exactEnvironmentBoolean(undefined, false, "TEST_SWITCH"), false);
  assert.equal(exactEnvironmentBoolean("true", false, "TEST_SWITCH"), true);
  assert.equal(exactEnvironmentBoolean("TRUE", false, "TEST_SWITCH"), true);
  assert.equal(exactEnvironmentBoolean("false", true, "TEST_SWITCH"), false);
  assert.equal(exactEnvironmentBoolean("False", true, "TEST_SWITCH"), false);
});

test("deployment Boolean switches reject values previously coerced to disabled", () => {
  for (const value of ["", " true", "false ", "1", "0", "yes", true, false, 1, null]) {
    assert.throws(
      () => exactEnvironmentBoolean(value, true, "TEST_SWITCH"),
      /TEST_SWITCH must be exactly true or false/,
    );
  }
});
