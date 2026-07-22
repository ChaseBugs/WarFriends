import assert from "node:assert/strict";
import { createPrivateKey, sign } from "crypto";
import test from "node:test";
import { ApiError } from "../apiErrors";
import { exactIdentityRequestProof } from "../handlers/identityRequestParsing";
import {
  GameCenterIdentityProofVerifier,
  SystemGameCenterCertificateAuthority,
  gameCenterIdentityPolicy,
  parseGameCenterIdentityProof,
  verifyGameCenterIdentityOwnership,
  verifyGameCenterIdentitySignature,
  type GameCenterIdentityPolicy,
  type GameCenterPublicKeyFetcher,
} from "../services/gameCenterIdentityProofService";

const NOW = new Date("2026-07-22T05:00:00.000Z");
const PLAYER_ID = "G:1234567890";
const POLICY: GameCenterIdentityPolicy = {
  enabled: true,
  bundleId: "com.chillingo.warfriends.ios",
  publicKeyHosts: ["static.gc.apple.test"],
  proofMaxAgeSeconds: 300,
  publicKeyTimeoutMs: 5_000,
};

// This key pair is generated solely for deterministic local verification tests. It is not used by
// any runtime path and is trusted only when the test explicitly installs its certificate as a root.
const PRIVATE_KEY = `-----BEGIN PRIVATE KEY-----
MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC7vfnIMOKOTwLI
9QkmAY8NAO9HwDD1dKu22MQaJnzOBugJR4W/mZSrcRNo5RuTeIGFihO2cUXcuGAN
v3TrttlTfs0caEgH6nOKbeybJFUMc/zQkRH03eyo1zOsZD14sodCszkoU6k4pMfv
DnqTAAFCXGgBvyHNU09hsZ/J/nNcgpHJIaDggDh7rMo41vXoyV28iHTUaqyGdqca
292BmtR738fOLJ+LrC+Sn+EVXADDVgOsOy52b6IZ+Zv0Ov/ijr3nCeLaQ2JLPt89
2EnEmbV9vyPUL9BA90NahrK/YhTP5LDqaz6LeMxwtFdvK9TUuSR23KZl0pSkD3Zj
ecnBcEorAgMBAAECggEAMN5TfVOUNVzFqc92kSkItmbO4gtZ8xpqdA7ahMAN7ocH
sRqn6uasNzAY0E4KrolIlZ0KYov7lmd7wThb09tlmIFCHKncTgsuBhN06jE73iD2
5sdMOEPoDU7vCWmSQq+d27PRJfkY7ECgNk67gzYWHdL107aPsuWDnTdiE28jUinL
/wDHCYttZiC3MzxOVmBCaY9a41/aWRuNI3JLLW7WqpIuHlZZUTycLpY2r9AhTynN
813dOqKNCypFTxaW6TKLZAESYXcOIhjrKv/p/5/8PZAOkQj7Fbvs0lnMpwn1D2y7
ih5B1rsbZntNS2lf9t62lXVV4g6Hy1/AXAxrc02tqQKBgQDvH82/c6eUR/zy+g2p
f5LMXJcvaQ9/8eOu0XKFMl6Tj4VtNnFtWhk+N+DPMEWV5cshKXhdCkQQjnTS3VyG
5d1N21Ja/JbugzC2EbLJfV6ELugYHjNPOMOMjpiO9caxsWOzVZ6yZfpYmSwisBGI
KL7HHF5WAw5ioVQ2Zshf9YX6RQKBgQDI/d0xD6W9SOtxUfjr2O3sZLP97mn1vw9I
MpwaeIifFZvZE6ZfNIBbsHV83M59AQ/QFHbYUXJM1VjeYOYYlkPo3y9akUhksojt
T9D32AgRELUomPSA7me/xDjyxybX5VinKN+i/KV7qqa/hKQ0r/WpJmQm8kEwUPvA
v3gFHtcxrwKBgQDW9X4d1zgUQkqPml3huz8Z2zpFcmpul+IXa01Jk6gVenV1YfXB
WbdLiSvc1QYY5EQggYkkCnB5ebZnQHtHAShaLwjvphWAQArwAST5oGvw48HcvHlf
hCW2GxHloeeGIXMA6b0JnkbYkolsfV6lSguGLmhXZdPushxj8y25pZtVCQKBgCE9
ClVQtyIEaxtEaRvntgD/7lwyD0fantZbuEEQadeVJT7S5xKbhhajqepKQcOeZ1UL
7VN8tKBML/QmpiauwvBB6HzbxdMRS1+jcXVrPnpD/xGFqfmgc3vdIWXU1XGitfR+
5+z2Rw+aexT1BIrKBqBAfxOJwIoS+m83ustt/Dx1AoGAN/xXBUrWM0oMr7E5I0Cw
HHz6pdT04dkRSXlqZh+j6OKWI6fQ+yzoeN1/j6b3EGFeemEbYtwu3JNJn6HogM4h
HgRGdTQFJfRNSFkYK9pWPVDW9c/LERKn1lITD62Wt8Vk3eoEY9285dmgo4yce5sE
SYRWh6NJ8yeM4ZQMQXbNGJs=
-----END PRIVATE KEY-----`;
const CERTIFICATE = `-----BEGIN CERTIFICATE-----
MIIC0zCCAbsCFDZCZwtxloHxoqoyhgHXvz8T2V7nMA0GCSqGSIb3DQEBCwUAMCYx
JDAiBgNVBAMMG1dhckZyaWVuZHMgR2FtZSBDZW50ZXIgVGVzdDAeFw0yNjA3MjIw
NDA2NDZaFw0zNjA3MTkwNDA2NDZaMCYxJDAiBgNVBAMMG1dhckZyaWVuZHMgR2Ft
ZSBDZW50ZXIgVGVzdDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALu9
+cgw4o5PAsj1CSYBjw0A70fAMPV0q7bYxBomfM4G6AlHhb+ZlKtxE2jlG5N4gYWK
E7ZxRdy4YA2/dOu22VN+zRxoSAfqc4pt7JskVQxz/NCREfTd7KjXM6xkPXiyh0Kz
OShTqTikx+8OepMAAUJcaAG/Ic1TT2Gxn8n+c1yCkckhoOCAOHusyjjW9ejJXbyI
dNRqrIZ2pxrb3YGa1Hvfx84sn4usL5Kf4RVcAMNWA6w7LnZvohn5m/Q6/+KOvecJ
4tpDYks+3z3YScSZtX2/I9Qv0ED3Q1qGsr9iFM/ksOprPot4zHC0V28r1NS5JHbc
pmXSlKQPdmN5ycFwSisCAwEAATANBgkqhkiG9w0BAQsFAAOCAQEApSSI9tmxp6Mu
IaFFB674n9jB9/J0sSUHwOAdOjqXStUibo01Me6aoUPW7oGOGHEl77wRsX4vSvfg
eJ1IDOc6ZFF6zamniscqomKv+gGpZSuva+EEkj29JK1N5bzY3NKn+EF3Asnslirf
XtszPLCo0TIvY1k3/EsBEAoHxdpefCeDL/w7Pty8B79T3iu1CgjUYPGkSy26sb1i
The5kd99WoVtVBRo3kzR1YFwkqYd4L31lvOYqhhuHvxR0RiDy4tOugpzQ2n9A5pH
qFJzdDXKWSBdiJ/ht/ZJYpgv0H3XJdFKS97coD+ZSIG42AzgvN0rY7dUh5lnGJuD
Oh69Sot+zA==
-----END CERTIFICATE-----`;

function signedPayload(playerId: string, bundleId: string, timestamp: bigint, salt: Buffer): Buffer {
  const timestampBytes = Buffer.alloc(8);
  timestampBytes.writeBigUInt64BE(timestamp);
  return Buffer.concat([
    Buffer.from(playerId, "utf8"),
    Buffer.from(bundleId, "utf8"),
    timestampBytes,
    salt,
  ]);
}

function proof(overrides: Record<string, unknown> = {}): string {
  const timestamp = BigInt(NOW.getTime() - 1_000);
  const salt = Buffer.from("test-game-center-salt", "utf8");
  const signature = sign(
    "RSA-SHA256",
    signedPayload(PLAYER_ID, POLICY.bundleId, timestamp, salt),
    createPrivateKey(PRIVATE_KEY),
  );
  return JSON.stringify({
    version: 1,
    publicKeyUrl: "https://static.gc.apple.test/public-key/current.cer",
    signature: signature.toString("base64"),
    salt: salt.toString("base64"),
    timestamp: timestamp.toString(),
    ...overrides,
  });
}

test("Game Center identity policy is immutable, exact, and opt-in", () => {
  const resolved = gameCenterIdentityPolicy(POLICY);
  assert.deepEqual(resolved, POLICY);
  assert.equal(Object.isFrozen(resolved), true);
  assert.equal(Object.isFrozen(resolved.publicKeyHosts), true);
  for (const value of [
    { ...POLICY, bundleId: " com.game" },
    { ...POLICY, publicKeyHosts: [] },
    { ...POLICY, publicKeyHosts: ["STATIC.GC.APPLE.TEST"] },
    { ...POLICY, publicKeyHosts: ["localhost"] },
    { ...POLICY, publicKeyHosts: ["127.0.0.1"] },
    { ...POLICY, proofMaxAgeSeconds: 29 },
    { ...POLICY, publicKeyTimeoutMs: 999 },
  ]) {
    assert.throws(() => gameCenterIdentityPolicy(value), /Game Center/);
  }
});

test("patched proof parser binds exact Apple fields, allowlisted HTTPS URL, and recent UInt64 time", () => {
  const parsed = parseGameCenterIdentityProof(proof(), POLICY, NOW);
  assert.equal(parsed.version, 1);
  assert.equal(parsed.publicKeyUrl, "https://static.gc.apple.test/public-key/current.cer");
  assert.equal(parsed.timestamp, BigInt(NOW.getTime() - 1_000));
  assert.equal(parsed.salt.toString("utf8"), "test-game-center-salt");

  for (const value of [
    proof({ version: 2 }),
    proof({ extra: true }),
    proof({ publicKeyUrl: "http://static.gc.apple.test/key.cer" }),
    proof({ publicKeyUrl: "https://attacker.test/key.cer" }),
    proof({ publicKeyUrl: "https://static.gc.apple.test/key.cer?redirect=1" }),
    proof({ timestamp: String(NOW.getTime() - 301_000) }),
    proof({ timestamp: String(NOW.getTime() + 31_000) }),
    proof({ timestamp: 123 }),
    proof({ signature: "not-base64" }),
    proof({ salt: "" }),
  ]) {
    assert.throws(() => parseGameCenterIdentityProof(value, POLICY, NOW), ApiError);
  }
});

test("Game Center signature verifies only the signed player, bundle, timestamp, and salt tuple", () => {
  const parsed = parseGameCenterIdentityProof(proof(), POLICY, NOW);
  assert.doesNotThrow(() => verifyGameCenterIdentitySignature(
    PLAYER_ID, parsed, Buffer.from(CERTIFICATE), POLICY, NOW,
  ));
  assert.throws(() => verifyGameCenterIdentitySignature(
    `${PLAYER_ID}-attacker`, parsed, Buffer.from(CERTIFICATE), POLICY, NOW,
  ), ApiError);
  assert.throws(() => verifyGameCenterIdentitySignature(
    PLAYER_ID, parsed, Buffer.from(CERTIFICATE), { ...POLICY, bundleId: "com.attacker.game" }, NOW,
  ), ApiError);
});

test("downloaded signing certificates must chain to an installed trusted authority", async () => {
  const testTrust = new SystemGameCenterCertificateAuthority([Buffer.from(CERTIFICATE)]);
  await assert.doesNotReject(() => testTrust.validate(Buffer.from(CERTIFICATE), NOW, 5_000));
  await assert.rejects(
    () => new SystemGameCenterCertificateAuthority().validate(Buffer.from(CERTIFICATE), NOW, 5_000),
    ApiError,
  );
});

test("public-key cache obeys provider max-age while proof and CA checks remain mandatory", async () => {
  let calls = 0;
  const fetcher: GameCenterPublicKeyFetcher = {
    fetch: async (url, timeoutMs) => {
      calls += 1;
      assert.equal(url, "https://static.gc.apple.test/public-key/current.cer");
      assert.equal(timeoutMs, 5_000);
      return { certificate: Buffer.from(CERTIFICATE), cacheSeconds: 60 };
    },
  };
  const verifier = new GameCenterIdentityProofVerifier(
    POLICY,
    fetcher,
    new SystemGameCenterCertificateAuthority([Buffer.from(CERTIFICATE)]),
  );
  await verifier.verify(PLAYER_ID, proof(), NOW);
  await verifier.verify(PLAYER_ID, proof(), new Date(NOW.getTime() + 1_000));
  assert.equal(calls, 1);
  await assert.rejects(() => verifier.verify(`${PLAYER_ID}-wrong`, proof(), NOW), ApiError);
});

test("legacy mode never silently consumes a supplied ProviderProof", async () => {
  const disabled: GameCenterIdentityPolicy = {
    ...POLICY,
    enabled: false,
    bundleId: "",
    publicKeyHosts: [],
  };
  await assert.doesNotReject(() => verifyGameCenterIdentityOwnership(PLAYER_ID, undefined, undefined, disabled));
  await assert.rejects(
    () => verifyGameCenterIdentityOwnership(PLAYER_ID, proof(), undefined, disabled),
    ApiError,
  );
});

test("identity request parsing keeps proof aliases exact and Game Center-only", () => {
  const value = proof();
  assert.equal(exactIdentityRequestProof({ ProviderProof: value }, "gameCenter"), value);
  assert.equal(
    exactIdentityRequestProof({ ProviderProof: value, GameCenterProof: value }, "gameCenter"),
    value,
  );
  assert.equal(exactIdentityRequestProof({}, "gameCenter"), undefined);
  assert.throws(
    () => exactIdentityRequestProof({ ProviderProof: value, GameCenterProof: "different" }, "gameCenter"),
    ApiError,
  );
  assert.throws(() => exactIdentityRequestProof({ ProviderProof: value }, "googlePlay"), ApiError);
});
