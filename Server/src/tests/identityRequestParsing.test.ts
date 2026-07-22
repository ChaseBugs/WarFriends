import assert from "node:assert/strict";
import test from "node:test";
import {
  exactHaveGameCenterId,
  exactIdentityRequestCredential,
  exactIdentityRequestId,
} from "../handlers/identityRequestParsing";

test("platform identity request IDs preserve exact recovered strings and reject coercion", () => {
  assert.equal(
    exactIdentityRequestId({ FacebookId: "9223372036854775807" }, "facebook"),
    "9223372036854775807",
  );
  assert.equal(
    exactIdentityRequestId({ GooglePlayId: "gpgs-player", googlePlayId: "gpgs-player" }, "googlePlay"),
    "gpgs-player",
  );

  for (const invalid of [9_007_199_254_740_992, null, true, [], {}, " 123", "123 "]) {
    assert.throws(
      () => exactIdentityRequestId({ FacebookId: invalid }, "facebook"),
      /account id is invalid/i,
    );
  }
  assert.throws(
    () => exactIdentityRequestId({ GooglePlayId: "primary", googlePlayId: "different" }, "googlePlay"),
    /account id is invalid/i,
  );
  assert.throws(
    () => exactIdentityRequestId({ GameCenterId: 123, gameCenterId: "123" }, "gameCenter"),
    /account id is invalid/i,
  );
});

test("platform credentials remain exact and conflicting aliases cannot choose authentication", () => {
  assert.equal(
    exactIdentityRequestCredential({ GooglePlayPassword: "opaque-token=", googlePlayPassword: "opaque-token=" }, "googlePlay"),
    "opaque-token=",
  );
  for (const invalid of [123, null, true, [], " padded", "padded ", "line\nbreak", "x".repeat(4_097)]) {
    assert.throws(
      () => exactIdentityRequestCredential({ GameCenterPassword: invalid }, "gameCenter"),
      /credential is invalid/i,
    );
  }
  assert.throws(
    () => exactIdentityRequestCredential({
      GameCenterPassword: "first",
      gameCenterPassword: "second",
    }, "gameCenter"),
    /credential is invalid/i,
  );
});

test("Game Center update selector accepts only the recovered zero-or-one string", () => {
  assert.equal(exactHaveGameCenterId("0"), false);
  assert.equal(exactHaveGameCenterId("1"), true);
  for (const invalid of [undefined, null, false, true, 0, 1, "", " 0", "01", [], {}]) {
    assert.throws(() => exactHaveGameCenterId(invalid), /selector is invalid/i);
  }
});
