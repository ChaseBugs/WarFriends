import { verify, X509Certificate, type KeyObject } from "crypto";
import { isIP } from "net";
import { rootCertificates } from "tls";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import { outboundRequestHeaders } from "./requestContextService";

const PROOF_KEYS = new Set(["version", "publicKeyUrl", "signature", "salt", "timestamp"]);
const MAX_CERTIFICATE_BYTES = 65_536;
const MAX_PROOF_BYTES = 8_192;
const MAX_BINARY_PROOF_BYTES = 2_048;

export interface GameCenterIdentityPolicy {
  enabled: boolean;
  bundleId: string;
  publicKeyHosts: readonly string[];
  proofMaxAgeSeconds: number;
  publicKeyTimeoutMs: number;
}

export interface GameCenterIdentityProof {
  version: 1;
  publicKeyUrl: string;
  signature: Buffer;
  salt: Buffer;
  timestamp: bigint;
}

export interface GameCenterPublicKeyResponse {
  certificate: Buffer;
  cacheSeconds: number;
}

export interface GameCenterPublicKeyFetcher {
  fetch(url: string, timeoutMs: number): Promise<GameCenterPublicKeyResponse>;
}

export interface GameCenterCertificateAuthority {
  validate(certificate: Buffer, now: Date, timeoutMs: number): Promise<void>;
}

function exactPolicyInteger(value: number, label: string, minimum: number, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Game Center ${label} policy is invalid.`);
  }
  return value;
}

function exactHostList(value: readonly string[]): readonly string[] {
  if (!Array.isArray(value) || value.length > 8) throw new Error("Game Center public-key hosts are invalid.");
  const normalized = value.map((host) => {
    if (typeof host !== "string"
      || host.length === 0
      || host.length > 253
      || host !== host.toLowerCase()
      || host.trim() !== host
      || isIP(host) !== 0
      || !host.includes(".")
      || !/^[a-z0-9](?:[a-z0-9.-]*[a-z0-9])?$/u.test(host)
      || host.includes("..")) {
      throw new Error("Game Center public-key hosts are invalid.");
    }
    return host;
  });
  if (new Set(normalized).size !== normalized.length) {
    throw new Error("Game Center public-key hosts are invalid.");
  }
  return Object.freeze(normalized);
}

function exactGameCenterIdentityPolicy(policy: GameCenterIdentityPolicy): GameCenterIdentityPolicy {
  const hosts = exactHostList(policy.publicKeyHosts);
  const validBundleId = typeof policy.bundleId === "string"
    && policy.bundleId.length <= 255
    && policy.bundleId.trim() === policy.bundleId
    && (policy.bundleId === "" || /^[A-Za-z0-9][A-Za-z0-9.-]*[A-Za-z0-9]$/u.test(policy.bundleId));
  if (typeof policy.enabled !== "boolean"
    || !validBundleId
    || (policy.enabled && (policy.bundleId.length === 0 || hosts.length === 0))) {
    throw new Error("Game Center identity-verification policy is invalid.");
  }
  return Object.freeze({
    enabled: policy.enabled,
    bundleId: policy.bundleId,
    publicKeyHosts: hosts,
    proofMaxAgeSeconds: exactPolicyInteger(policy.proofMaxAgeSeconds, "proof age", 30, 600),
    publicKeyTimeoutMs: exactPolicyInteger(policy.publicKeyTimeoutMs, "public-key timeout", 1_000, 10_000),
  });
}

const CONFIGURED_GAME_CENTER_IDENTITY_POLICY = exactGameCenterIdentityPolicy({
  enabled: config.gameCenterIdentityVerificationEnabled,
  bundleId: config.gameCenterBundleId,
  publicKeyHosts: config.gameCenterPublicKeyHosts === ""
    ? []
    : config.gameCenterPublicKeyHosts.split(","),
  proofMaxAgeSeconds: config.gameCenterProofMaxAgeSeconds,
  publicKeyTimeoutMs: config.gameCenterPublicKeyTimeoutMs,
});

export function gameCenterIdentityPolicy(policy?: GameCenterIdentityPolicy): GameCenterIdentityPolicy {
  return policy === undefined
    ? CONFIGURED_GAME_CENTER_IDENTITY_POLICY
    : exactGameCenterIdentityPolicy(policy);
}

function authorizationFailure(): never {
  // Do not reveal whether parsing, timestamp, provider download, certificate, or signature failed.
  // All branches prove the same thing to the caller: no current Game Center ownership proof.
  throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Game Center identity proof is invalid.");
}

function providerUnavailable(): never {
  // Network and upstream service failures are retryable server failures, not evidence that the
  // presented player proof is wrong. The login layer removes this request's throttle reservation.
  throw new ApiError(ApiErrorCode.InternalServerError, "Game Center identity verification is temporarily unavailable.");
}

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value);
}

function canonicalBase64(value: unknown): Buffer {
  if (typeof value !== "string" || value.length === 0 || value.length > MAX_PROOF_BYTES) {
    authorizationFailure();
  }
  const decoded = Buffer.from(value, "base64");
  if (decoded.length === 0
    || decoded.length > MAX_BINARY_PROOF_BYTES
    || decoded.toString("base64") !== value) authorizationFailure();
  return decoded;
}

/** Parse the separate patched-client proof without ever treating GameCenterPassword as a signature. */
export function parseGameCenterIdentityProof(
  value: unknown,
  policy: GameCenterIdentityPolicy = CONFIGURED_GAME_CENTER_IDENTITY_POLICY,
  now = new Date(),
): GameCenterIdentityProof {
  const exactPolicy = gameCenterIdentityPolicy(policy);
  if (!exactPolicy.enabled || typeof value !== "string" || value.length === 0 || value.length > MAX_PROOF_BYTES) {
    authorizationFailure();
  }
  let decoded: unknown;
  try {
    decoded = JSON.parse(value) as unknown;
  } catch {
    authorizationFailure();
  }
  if (!plainRecord(decoded)
    || Object.keys(decoded).length !== PROOF_KEYS.size
    || Object.keys(decoded).some((key) => !PROOF_KEYS.has(key))
    || decoded.version !== 1
    || typeof decoded.publicKeyUrl !== "string"
    || typeof decoded.timestamp !== "string"
    || !/^[1-9][0-9]{0,19}$/u.test(decoded.timestamp)) authorizationFailure();
  let publicKeyUrl: URL;
  try {
    publicKeyUrl = new URL(decoded.publicKeyUrl);
  } catch {
    authorizationFailure();
  }
  if (publicKeyUrl.protocol !== "https:"
    || publicKeyUrl.username !== ""
    || publicKeyUrl.password !== ""
    || publicKeyUrl.port !== ""
    || publicKeyUrl.search !== ""
    || publicKeyUrl.hash !== ""
    || !exactPolicy.publicKeyHosts.includes(publicKeyUrl.hostname)) authorizationFailure();
  const timestamp = BigInt(decoded.timestamp);
  const nowMs = now instanceof Date ? now.getTime() : Number.NaN;
  if (!Number.isSafeInteger(nowMs) || nowMs < 0) throw new Error("Game Center verification time is invalid.");
  const earliest = BigInt(nowMs - exactPolicy.proofMaxAgeSeconds * 1_000);
  const latest = BigInt(nowMs + 30_000);
  if (timestamp < earliest || timestamp > latest) authorizationFailure();
  return {
    version: 1,
    publicKeyUrl: publicKeyUrl.toString(),
    signature: canonicalBase64(decoded.signature),
    salt: canonicalBase64(decoded.salt),
    timestamp,
  };
}

function parsedCertificate(certificateBytes: Buffer): X509Certificate {
  if (certificateBytes.length === 0 || certificateBytes.length > MAX_CERTIFICATE_BYTES) authorizationFailure();
  try {
    return new X509Certificate(certificateBytes);
  } catch {
    authorizationFailure();
  }
}

function validatedCertificateTime(certificate: X509Certificate, now: Date): number {
  const validFrom = Date.parse(certificate.validFrom);
  const validTo = Date.parse(certificate.validTo);
  const nowMs = now.getTime();
  if (!Number.isFinite(validFrom)
    || !Number.isFinite(validTo)
    || !Number.isSafeInteger(nowMs)
    || nowMs < 0
    || nowMs < validFrom
    || nowMs > validTo) authorizationFailure();
  return validTo;
}

function certificatePublicKey(certificateBytes: Buffer, now: Date): KeyObject {
  const certificate = parsedCertificate(certificateBytes);
  validatedCertificateTime(certificate, now);
  const details = certificate.publicKey.asymmetricKeyDetails;
  if (certificate.publicKey.asymmetricKeyType !== "rsa"
    || !details
    || typeof details.modulusLength !== "number"
    || details.modulusLength < 2_048) authorizationFailure();
  return certificate.publicKey;
}

function certificateIssuedBy(certificate: X509Certificate, issuer: X509Certificate): boolean {
  try {
    return certificate.issuer === issuer.subject
      && certificate.checkIssued(issuer)
      && certificate.verify(issuer.publicKey);
  } catch {
    return false;
  }
}

function issuerUrls(certificate: X509Certificate): readonly string[] {
  const infoAccess = certificate.infoAccess;
  if (!infoAccess) authorizationFailure();
  const urls = infoAccess
    .split(/\r?\n/u)
    .map((line) => /^CA Issuers - URI:(\S+)$/u.exec(line)?.[1])
    .filter((url): url is string => Boolean(url));
  if (urls.length === 0 || urls.length > 4 || new Set(urls).size !== urls.length) authorizationFailure();
  return urls;
}

async function fetchIssuerCertificate(urlValue: string, timeoutMs: number): Promise<Buffer> {
  let url: URL;
  try {
    url = new URL(urlValue);
  } catch {
    authorizationFailure();
  }
  // CA Issuers links are commonly HTTP because their bytes are authenticated by the child
  // certificate signature. Still reject credentials, custom ports, IP literals, and fragments so
  // a malformed Apple certificate can never turn verification into a general-purpose fetcher.
  if ((url.protocol !== "http:" && url.protocol !== "https:")
    || url.username !== ""
    || url.password !== ""
    || url.port !== ""
    || url.search !== ""
    || url.hash !== ""
    || isIP(url.hostname) !== 0
    || !url.hostname.includes(".")) authorizationFailure();
  let response: globalThis.Response;
  try {
    response = await globalThis.fetch(url.toString(), {
      method: "GET",
      redirect: "error",
      headers: outboundRequestHeaders(),
      signal: AbortSignal.timeout(timeoutMs),
    });
  } catch {
    providerUnavailable();
  }
  if (response.status === 429 || response.status >= 500) providerUnavailable();
  if (!response.ok || response.url !== url.toString()) authorizationFailure();
  const declaredLength = response.headers.get("content-length");
  if (declaredLength !== null
    && (!/^(?:0|[1-9][0-9]{0,8})$/u.test(declaredLength)
      || Number(declaredLength) > MAX_CERTIFICATE_BYTES)) authorizationFailure();
  let bytes: Buffer;
  try {
    bytes = Buffer.from(await response.arrayBuffer());
  } catch {
    providerUnavailable();
  }
  if (bytes.length === 0 || bytes.length > MAX_CERTIFICATE_BYTES) authorizationFailure();
  return bytes;
}

/**
 * Validate Apple's downloaded signing certificate back to a root trusted by this Node runtime.
 * The leaf URL alone is not signing authority: Apple explicitly requires validating the issuer,
 * and historical rotations changed both the leaf and issuing CA. Signed AIA metadata supplies
 * intermediates, which are bounded to three hops and never promoted into trust anchors.
 */
export class SystemGameCenterCertificateAuthority implements GameCenterCertificateAuthority {
  private readonly roots: readonly X509Certificate[];
  private readonly trustedLeafExpiry = new Map<string, number>();

  constructor(trustedRoots: readonly (string | Buffer)[] = rootCertificates) {
    this.roots = Object.freeze(trustedRoots.map((root) => parsedCertificate(Buffer.from(root))));
    if (this.roots.length === 0) throw new Error("Game Center certificate roots are unavailable.");
  }

  async validate(certificateBytes: Buffer, now: Date, timeoutMs: number): Promise<void> {
    const leaf = parsedCertificate(certificateBytes);
    const nowMs = now.getTime();
    if ((this.trustedLeafExpiry.get(leaf.fingerprint256) ?? 0) > nowMs) return;

    let current = leaf;
    let chainExpiry = Number.POSITIVE_INFINITY;
    const visited = new Set<string>();
    for (let depth = 0; depth < 3; depth += 1) {
      chainExpiry = Math.min(chainExpiry, validatedCertificateTime(current, now));
      if (visited.has(current.fingerprint256)) authorizationFailure();
      visited.add(current.fingerprint256);

      const trustedRoot = this.roots.find((root) => {
        try {
          return (current.raw.equals(root.raw) || certificateIssuedBy(current, root))
            && validatedCertificateTime(root, now) >= nowMs;
        } catch {
          return false;
        }
      });
      if (trustedRoot) {
        chainExpiry = Math.min(chainExpiry, Date.parse(trustedRoot.validTo));
        if (this.trustedLeafExpiry.size >= 32) this.trustedLeafExpiry.clear();
        this.trustedLeafExpiry.set(leaf.fingerprint256, chainExpiry);
        return;
      }

      let issuer: X509Certificate | undefined;
      for (const issuerUrl of issuerUrls(current)) {
        const candidate = parsedCertificate(await fetchIssuerCertificate(issuerUrl, timeoutMs));
        validatedCertificateTime(candidate, now);
        if (candidate.ca && certificateIssuedBy(current, candidate)) {
          issuer = candidate;
          break;
        }
      }
      if (!issuer) authorizationFailure();
      current = issuer;
    }
    authorizationFailure();
  }
}

function signedGameCenterPayload(
  externalId: string,
  bundleId: string,
  timestamp: bigint,
  salt: Buffer,
): Buffer {
  const timestampBytes = Buffer.alloc(8);
  timestampBytes.writeBigUInt64BE(timestamp);
  return Buffer.concat([
    Buffer.from(externalId, "utf8"),
    Buffer.from(bundleId, "utf8"),
    timestampBytes,
    salt,
  ]);
}

export function verifyGameCenterIdentitySignature(
  externalId: string,
  proof: GameCenterIdentityProof,
  certificateBytes: Buffer,
  policy: GameCenterIdentityPolicy = CONFIGURED_GAME_CENTER_IDENTITY_POLICY,
  now = new Date(),
): void {
  const exactPolicy = gameCenterIdentityPolicy(policy);
  if (!exactPolicy.enabled
    || typeof externalId !== "string"
    || externalId.length === 0
    || externalId.length > 256
    || externalId.trim() !== externalId
    || /[\u0000-\u001f\u007f]/u.test(externalId)) authorizationFailure();
  const publicKey = certificatePublicKey(certificateBytes, now);
  const payload = signedGameCenterPayload(externalId, exactPolicy.bundleId, proof.timestamp, proof.salt);
  if (!verify("RSA-SHA256", payload, publicKey, proof.signature)) authorizationFailure();
}

function cacheSeconds(value: string | null): number {
  if (!value) return 0;
  const match = /(?:^|,)\s*max-age=([0-9]+)(?:,|$)/iu.exec(value);
  if (!match || !/^(?:0|[1-9][0-9]{0,8})$/u.test(match[1]!)) return 0;
  return Math.min(86_400, Number(match[1]));
}

export class HttpsGameCenterPublicKeyFetcher implements GameCenterPublicKeyFetcher {
  async fetch(url: string, timeoutMs: number): Promise<GameCenterPublicKeyResponse> {
    let response: globalThis.Response;
    try {
      response = await globalThis.fetch(url, {
        method: "GET",
        redirect: "error",
        headers: outboundRequestHeaders(),
        signal: AbortSignal.timeout(timeoutMs),
      });
    } catch {
      providerUnavailable();
    }
    if (response.status === 429 || response.status >= 500) providerUnavailable();
    if (!response.ok || response.url !== url) authorizationFailure();
    const declaredLength = response.headers.get("content-length");
    if (declaredLength !== null
      && (!/^(?:0|[1-9][0-9]{0,8})$/u.test(declaredLength)
        || Number(declaredLength) > MAX_CERTIFICATE_BYTES)) authorizationFailure();
    let certificate: Buffer;
    try {
      certificate = Buffer.from(await response.arrayBuffer());
    } catch {
      providerUnavailable();
    }
    if (certificate.length === 0 || certificate.length > MAX_CERTIFICATE_BYTES) authorizationFailure();
    return { certificate, cacheSeconds: cacheSeconds(response.headers.get("cache-control")) };
  }
}

interface CachedCertificate {
  bytes: Buffer;
  expiresAtMs: number;
}

/** Fetch and verify Apple's current signed tuple without persisting its short-lived proof bytes. */
export class GameCenterIdentityProofVerifier {
  private readonly cache = new Map<string, CachedCertificate>();

  constructor(
    private readonly policy: GameCenterIdentityPolicy = CONFIGURED_GAME_CENTER_IDENTITY_POLICY,
    private readonly fetcher: GameCenterPublicKeyFetcher = new HttpsGameCenterPublicKeyFetcher(),
    private readonly certificateAuthority: GameCenterCertificateAuthority = new SystemGameCenterCertificateAuthority(),
  ) {}

  async verify(externalId: string, proofValue: unknown, now = new Date()): Promise<void> {
    const proof = parseGameCenterIdentityProof(proofValue, this.policy, now);
    const nowMs = now.getTime();
    let cached = this.cache.get(proof.publicKeyUrl);
    if (!cached || cached.expiresAtMs <= nowMs) {
      const loaded = await this.fetcher.fetch(proof.publicKeyUrl, this.policy.publicKeyTimeoutMs);
      if (!Number.isSafeInteger(loaded.cacheSeconds) || loaded.cacheSeconds < 0 || loaded.cacheSeconds > 86_400) {
        throw new Error("Game Center public-key cache authority is invalid.");
      }
      cached = {
        bytes: Buffer.from(loaded.certificate),
        expiresAtMs: nowMs + loaded.cacheSeconds * 1_000,
      };
      if (loaded.cacheSeconds > 0) this.cache.set(proof.publicKeyUrl, cached);
    }
    // HTTPS authenticates the configured Apple host; this separate chain check proves that the
    // downloaded signing certificate itself terminates at a runtime-trusted signing authority.
    await this.certificateAuthority.validate(cached.bytes, now, this.policy.publicKeyTimeoutMs);
    verifyGameCenterIdentitySignature(externalId, proof, cached.bytes, this.policy, now);
  }
}

const defaultVerifier = new GameCenterIdentityProofVerifier();

/** Enforce proof only in explicit patched-client mode; a supplied proof is never silently ignored. */
export async function verifyGameCenterIdentityOwnership(
  externalId: string,
  proofValue: unknown,
  verifier: GameCenterIdentityProofVerifier = defaultVerifier,
  policy: GameCenterIdentityPolicy = CONFIGURED_GAME_CENTER_IDENTITY_POLICY,
): Promise<void> {
  const exactPolicy = gameCenterIdentityPolicy(policy);
  if (!exactPolicy.enabled) {
    if (proofValue !== undefined) authorizationFailure();
    return;
  }
  await verifier.verify(externalId, proofValue);
}
