import assert from "node:assert/strict";
import test from "node:test";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { exactIdentityRequestProof } from "../handlers/identityRequestParsing";
import {
  FacebookIdentityProofVerifier,
  facebookIdentityPolicy,
  parseFacebookIdentityProof,
  validatedFacebookTokenInspection,
  verifyFacebookIdentityOwnership,
  type FacebookIdentityPolicy,
  type FacebookTokenInspectionClient,
} from "../services/facebookIdentityProofService";

const NOW = new Date("2026-07-22T06:00:00.000Z");
const NOW_SECONDS = Math.floor(NOW.getTime() / 1_000);
const USER_ID = "123456789012345678";
const ACCESS_TOKEN = "EAATestUserAccessToken_1234567890";
const POLICY: FacebookIdentityPolicy = {
  enabled: true,
  appId: "123456789012345",
  appSecret: "0123456789abcdef0123456789abcdef",
  graphApiVersion: "v23.0",
  timeoutMs: 5_000,
};

function proof(overrides: Record<string, unknown> = {}): string {
  return JSON.stringify({ version: 1, accessToken: ACCESS_TOKEN, ...overrides });
}

function inspection(overrides: Record<string, unknown> = {}): unknown {
  return {
    data: {
      app_id: POLICY.appId,
      type: "USER",
      is_valid: true,
      user_id: USER_ID,
      issued_at: NOW_SECONDS - 60,
      expires_at: NOW_SECONDS + 3_600,
      data_access_expires_at: NOW_SECONDS + 7_200,
      scopes: ["public_profile"],
      ...overrides,
    },
  };
}

test("Facebook identity policy is immutable, exact, and opt-in", () => {
  const resolved = facebookIdentityPolicy(POLICY);
  assert.deepEqual(resolved, POLICY);
  assert.equal(Object.isFrozen(resolved), true);
  for (const value of [
    { ...POLICY, appId: "0123" },
    { ...POLICY, appSecret: "too-short" },
    { ...POLICY, graphApiVersion: "23.0" },
    { ...POLICY, graphApiVersion: "v023.0" },
    { ...POLICY, timeoutMs: 999 },
    { ...POLICY, timeoutMs: 10_001 },
    { ...POLICY, appId: "" },
  ]) {
    assert.throws(() => facebookIdentityPolicy(value), /Facebook/);
  }
});

test("Facebook proof parser accepts only exact versioned user access-token JSON", () => {
  assert.deepEqual(parseFacebookIdentityProof(proof()), { version: 1, accessToken: ACCESS_TOKEN });
  for (const value of [
    "",
    ACCESS_TOKEN,
    proof({ version: 2 }),
    proof({ extra: true }),
    proof({ accessToken: " padded" }),
    proof({ accessToken: "line\nbreak" }),
    proof({ accessToken: 123 }),
  ]) {
    assert.throws(() => parseFacebookIdentityProof(value), ApiError);
  }
});

test("debug-token authority binds the exact app, USER identity, and live provider dates", () => {
  assert.deepEqual(validatedFacebookTokenInspection(inspection(), USER_ID, POLICY, NOW), {
    appId: POLICY.appId,
    userId: USER_ID,
    issuedAt: NOW_SECONDS - 60,
    expiresAt: NOW_SECONDS + 3_600,
    dataAccessExpiresAt: NOW_SECONDS + 7_200,
  });
  for (const value of [
    inspection({ is_valid: false }),
    inspection({ type: "APP" }),
    inspection({ app_id: "999999999" }),
    inspection({ user_id: `${USER_ID}0` }),
    inspection({ issued_at: NOW_SECONDS + 31 }),
    inspection({ expires_at: NOW_SECONDS }),
    inspection({ data_access_expires_at: NOW_SECONDS }),
  ]) {
    assert.throws(() => validatedFacebookTokenInspection(value, USER_ID, POLICY, NOW), ApiError);
  }
  assert.throws(
    () => validatedFacebookTokenInspection(inspection({ expires_at: String(NOW_SECONDS + 3_600) }), USER_ID, POLICY, NOW),
    (error: unknown) => error instanceof ApiError && error.code === ApiErrorCode.InternalServerError,
  );
});

test("Facebook verifier sends the user token only to the configured app inspection client", async () => {
  let calls = 0;
  const client: FacebookTokenInspectionClient = {
    inspect: async (input) => {
      calls += 1;
      assert.deepEqual(input, {
        userAccessToken: ACCESS_TOKEN,
        appAccessToken: `${POLICY.appId}|${POLICY.appSecret}`,
        graphApiVersion: POLICY.graphApiVersion,
        timeoutMs: POLICY.timeoutMs,
      });
      return inspection();
    },
  };
  const verifier = new FacebookIdentityProofVerifier(POLICY, client);
  await verifier.verify(USER_ID, proof(), NOW);
  assert.equal(calls, 1);
  await assert.rejects(() => verifier.verify(`${USER_ID}0`, proof(), NOW), ApiError);
});

test("provider transport failures remain retryable server errors rather than bad credentials", async () => {
  const verifier = new FacebookIdentityProofVerifier(POLICY, {
    inspect: async () => { throw new Error("simulated provider outage"); },
  });
  await assert.rejects(
    () => verifier.verify(USER_ID, proof(), NOW),
    (error: unknown) => error instanceof ApiError && error.code === ApiErrorCode.InternalServerError,
  );
});

test("legacy mode never silently consumes a supplied Facebook ProviderProof", async () => {
  const disabled: FacebookIdentityPolicy = {
    ...POLICY,
    enabled: false,
    appId: "",
    appSecret: "",
    graphApiVersion: "",
  };
  await assert.doesNotReject(() => verifyFacebookIdentityOwnership(USER_ID, undefined, undefined, disabled));
  await assert.rejects(
    () => verifyFacebookIdentityOwnership(USER_ID, proof(), undefined, disabled),
    ApiError,
  );
});

test("identity proof aliases are exact for Facebook while Google Play remains closed", () => {
  const value = proof();
  assert.equal(exactIdentityRequestProof({ ProviderProof: value }, "facebook"), value);
  assert.equal(
    exactIdentityRequestProof({ ProviderProof: value, FacebookProof: value }, "facebook"),
    value,
  );
  assert.throws(
    () => exactIdentityRequestProof({ ProviderProof: value, FacebookProof: "different" }, "facebook"),
    ApiError,
  );
  assert.throws(() => exactIdentityRequestProof({ ProviderProof: value }, "googlePlay"), ApiError);
});
