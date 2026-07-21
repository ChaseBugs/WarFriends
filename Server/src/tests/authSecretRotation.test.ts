import assert from "node:assert/strict";
import test from "node:test";
import { config } from "../config";
import {
  hashCustomCredential,
  verifyCustomCredential,
} from "../services/authService";
import {
  hashIdentityCredential,
  verifyIdentityCredentialHash,
} from "../services/identityService";
import { validateAuthenticationSecretConfiguration } from "../services/authSecretService";

const OLD_SECRET = "old-auth-secret-with-at-least-32-characters";
const NEW_SECRET = "new-auth-secret-with-at-least-32-characters";

async function withAuthKeyring<T>(
  current: string,
  fallbacks: string[],
  action: () => Promise<T> | T,
): Promise<T> {
  const savedCurrent = config.authSecret;
  const savedFallbacks = config.authSecretFallbacks;
  config.authSecret = current;
  config.authSecretFallbacks = fallbacks;
  try {
    return await action();
  } finally {
    config.authSecret = savedCurrent;
    config.authSecretFallbacks = savedFallbacks;
  }
}

test("custom passwords remain verifiable during rotation and request active-key upgrade", async () => {
  const storedHash = await withAuthKeyring(OLD_SECRET, [], () =>
    hashCustomCredential("rotation-player", "rotation-password"));

  await withAuthKeyring(NEW_SECRET, [OLD_SECRET], async () => {
    assert.deepEqual(
      await verifyCustomCredential("rotation-player", storedHash, "rotation-password"),
      { matches: true, needsUpgrade: true },
    );
    assert.deepEqual(
      await verifyCustomCredential("rotation-player", storedHash, "wrong-password"),
      { matches: false, needsUpgrade: false },
    );

    const upgradedHash = await hashCustomCredential("rotation-player", "rotation-password");
    assert.deepEqual(
      await verifyCustomCredential("rotation-player", upgradedHash, "rotation-password"),
      { matches: true, needsUpgrade: false },
    );
  });
});

test("provider credential digests use fallback keys only as a migration bridge", async () => {
  const storedHash = hashIdentityCredential(
    "googlePlay",
    "provider-player",
    "provider-token",
    OLD_SECRET,
  );

  await withAuthKeyring(NEW_SECRET, [OLD_SECRET], () => {
    assert.deepEqual(
      verifyIdentityCredentialHash(storedHash, "googlePlay", "provider-player", "provider-token"),
      { matches: true, needsUpgrade: true },
    );
    assert.deepEqual(
      verifyIdentityCredentialHash(storedHash, "googlePlay", "provider-player", "wrong-token"),
      { matches: false, needsUpgrade: false },
    );
    const upgradedHash = hashIdentityCredential("googlePlay", "provider-player", "provider-token");
    assert.deepEqual(
      verifyIdentityCredentialHash(upgradedHash, "googlePlay", "provider-player", "provider-token"),
      { matches: true, needsUpgrade: false },
    );
  });
});

test("production authentication key rings reject weak, duplicate, and unbounded keys", async () => {
  await withAuthKeyring(NEW_SECRET, [OLD_SECRET], () => {
    assert.doesNotThrow(() => validateAuthenticationSecretConfiguration(true));
  });
  await withAuthKeyring("too-short", [], () => {
    assert.throws(
      () => validateAuthenticationSecretConfiguration(true),
      /AUTH_SECRET must contain at least 32 characters/u,
    );
  });
  await withAuthKeyring(NEW_SECRET, [NEW_SECRET], () => {
    assert.throws(
      () => validateAuthenticationSecretConfiguration(true),
      /must contain distinct keys/u,
    );
  });
  await withAuthKeyring(NEW_SECRET, [OLD_SECRET, `${OLD_SECRET}-2`, `${OLD_SECRET}-3`, `${OLD_SECRET}-4`], () => {
    assert.throws(
      () => validateAuthenticationSecretConfiguration(true),
      /at most three/u,
    );
  });

  // Development retains the repository's convenient default and never applies production-only
  // deployment policy while unit tests or a local recovered client are starting.
  await withAuthKeyring("change-me-in-production", [], () => {
    assert.doesNotThrow(() => validateAuthenticationSecretConfiguration(false));
  });
});
