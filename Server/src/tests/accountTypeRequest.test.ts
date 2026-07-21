import assert from "node:assert/strict";
import test from "node:test";
import { AccountType } from "../constants";
import { exactRequestedAccountType } from "../services/accountTypeRequestService";

test("login AccountType preserves every recovered canonical provider value", () => {
  assert.equal(exactRequestedAccountType("0"), AccountType.Guest);
  assert.equal(exactRequestedAccountType(2), AccountType.Facebook);
  assert.equal(exactRequestedAccountType("3"), AccountType.GameCenter);
  assert.equal(exactRequestedAccountType(4), AccountType.GooglePlay);
});

test("malformed AccountType cannot select a credential provider through coercion", () => {
  for (const value of [
    undefined, null, true, false, [], ["2"], {}, "", " 2", "02", "+2", "2.0", "2e0", -1, 1, 5,
    Number.NaN, Number.POSITIVE_INFINITY,
  ]) {
    assert.equal(exactRequestedAccountType(value), undefined);
  }
});
