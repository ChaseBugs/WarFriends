import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { hashCustomCredential, validateCustomCredential } from "../services/authService";

test("custom passwords preserve the recovered 6-to-128 character contract", () => {
  assert.equal(validateCustomCredential("secret"), "secret");
  assert.equal(validateCustomCredential("x".repeat(128)), "x".repeat(128));
  for (const invalid of [undefined, 123456, "short", "x".repeat(129)]) {
    assert.throws(
      () => validateCustomCredential(invalid),
      (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
    );
  }
});

test("custom password hashing emits independently salted versioned scrypt digests", async () => {
  const first = await hashCustomCredential("player-1", "secret-password");
  const second = await hashCustomCredential("player-1", "secret-password");

  assert.match(first, /^scrypt\$v1\$16384\$8\$1\$[0-9a-f]{32}\$[0-9a-f]{64}$/u);
  assert.match(second, /^scrypt\$v1\$16384\$8\$1\$[0-9a-f]{32}\$[0-9a-f]{64}$/u);
  assert.notEqual(first, second);
});
