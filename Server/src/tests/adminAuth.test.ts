import assert from "node:assert/strict";
import test from "node:test";
import { validateAdminAuthorization } from "../services/adminAuthService";

test("admin authorization requires one exact bearer credential", () => {
  const secret = "a-strong-independent-admin-secret";
  assert.equal(validateAdminAuthorization(`Bearer ${secret}`, secret), "allowed");
  assert.equal(validateAdminAuthorization(undefined, secret), "missing");
  assert.equal(validateAdminAuthorization(`Basic ${secret}`, secret), "invalid");
  assert.equal(validateAdminAuthorization(`Bearer ${secret} extra`, secret), "invalid");
  assert.equal(validateAdminAuthorization("Bearer wrong", secret), "invalid");
});

test("empty deployment secret disables rather than exposes admin routes", () => {
  assert.equal(validateAdminAuthorization("Bearer anything", ""), "disabled");
});
