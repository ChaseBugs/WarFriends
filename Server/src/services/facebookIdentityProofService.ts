import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import { outboundRequestHeaders } from "./requestContextService";

const PROOF_KEYS = new Set(["version", "accessToken"]);
const MAX_PROOF_BYTES = 8_192;
const MAX_ACCESS_TOKEN_BYTES = 4_096;
const MAX_PROVIDER_RESPONSE_BYTES = 65_536;

export interface FacebookIdentityPolicy {
  enabled: boolean;
  appId: string;
  appSecret: string;
  graphApiVersion: string;
  timeoutMs: number;
}

export interface FacebookIdentityProof {
  version: 1;
  accessToken: string;
}

export interface FacebookTokenInspectionInput {
  userAccessToken: string;
  appAccessToken: string;
  graphApiVersion: string;
  timeoutMs: number;
}

export interface FacebookTokenInspectionClient {
  inspect(input: FacebookTokenInspectionInput): Promise<unknown>;
}

export interface ValidatedFacebookTokenInspection {
  appId: string;
  userId: string;
  issuedAt: number;
  expiresAt: number;
  dataAccessExpiresAt?: number;
}

function authorizationFailure(): never {
  // The client must not learn whether the token, app binding, user binding, or timestamp failed.
  // Those distinctions would turn login into a provider-token and Facebook-ID probing oracle.
  throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Facebook identity proof is invalid.");
}

function providerUnavailable(): never {
  // Provider/network/schema failures differ from a rejected user token. The login layer clears
  // this request's brute-force reservation before returning the retryable server error.
  throw new ApiError(ApiErrorCode.InternalServerError, "Facebook identity verification is temporarily unavailable.");
}

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value);
}

function exactFacebookIdentityPolicy(policy: FacebookIdentityPolicy): FacebookIdentityPolicy {
  const appIdValid = typeof policy.appId === "string"
    && (policy.appId === "" || /^[1-9][0-9]{0,19}$/u.test(policy.appId));
  const appSecretValid = typeof policy.appSecret === "string"
    && (policy.appSecret === "" || /^[A-Fa-f0-9]{32,128}$/u.test(policy.appSecret));
  const versionValid = typeof policy.graphApiVersion === "string"
    && (policy.graphApiVersion === "" || /^v[1-9][0-9]{0,2}\.[0-9]$/u.test(policy.graphApiVersion));
  if (typeof policy.enabled !== "boolean"
    || !appIdValid
    || !appSecretValid
    || !versionValid
    || !Number.isSafeInteger(policy.timeoutMs)
    || policy.timeoutMs < 1_000
    || policy.timeoutMs > 10_000
    || (policy.enabled && (policy.appId === "" || policy.appSecret === "" || policy.graphApiVersion === ""))) {
    throw new Error("Facebook identity-verification policy is invalid.");
  }
  return Object.freeze({ ...policy });
}

const CONFIGURED_FACEBOOK_IDENTITY_POLICY = exactFacebookIdentityPolicy({
  enabled: config.facebookIdentityVerificationEnabled,
  appId: config.facebookAppId,
  appSecret: config.facebookAppSecret,
  graphApiVersion: config.facebookGraphApiVersion,
  timeoutMs: config.facebookIdentityTimeoutMs,
});

export function facebookIdentityPolicy(policy?: FacebookIdentityPolicy): FacebookIdentityPolicy {
  return policy === undefined
    ? CONFIGURED_FACEBOOK_IDENTITY_POLICY
    : exactFacebookIdentityPolicy(policy);
}

/** Parse a versioned replacement-client proof without ever consuming FacebookPassword as a token. */
export function parseFacebookIdentityProof(value: unknown): FacebookIdentityProof {
  if (typeof value !== "string" || value.length === 0 || value.length > MAX_PROOF_BYTES) {
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
    || typeof decoded.accessToken !== "string"
    || decoded.accessToken.length === 0
    || Buffer.byteLength(decoded.accessToken, "utf8") > MAX_ACCESS_TOKEN_BYTES
    || decoded.accessToken.trim() !== decoded.accessToken
    || /[\u0000-\u001f\u007f]/u.test(decoded.accessToken)) authorizationFailure();
  return Object.freeze({ version: 1, accessToken: decoded.accessToken });
}

function exactProviderUnixSecond(value: unknown): number | null {
  return typeof value === "number" && Number.isSafeInteger(value) && value >= 0 ? value : null;
}

/**
 * Validate only identity-bearing debug-token fields. Display names and scopes are deliberately not
 * accepted as account authority: the recovered `Name` remains untrusted presentation metadata.
 */
export function validatedFacebookTokenInspection(
  value: unknown,
  expectedUserId: string,
  policy: FacebookIdentityPolicy = CONFIGURED_FACEBOOK_IDENTITY_POLICY,
  now = new Date(),
): ValidatedFacebookTokenInspection {
  const exactPolicy = facebookIdentityPolicy(policy);
  const nowMs = now instanceof Date ? now.getTime() : Number.NaN;
  if (!exactPolicy.enabled || !Number.isSafeInteger(nowMs) || nowMs < 0) {
    if (!exactPolicy.enabled) authorizationFailure();
    throw new Error("Facebook verification time is invalid.");
  }
  if (!plainRecord(value) || !plainRecord(value.data)) providerUnavailable();
  const data = value.data;
  const issuedAt = exactProviderUnixSecond(data.issued_at);
  const expiresAt = exactProviderUnixSecond(data.expires_at);
  const dataAccessExpiresAt = data.data_access_expires_at === undefined
    ? undefined
    : exactProviderUnixSecond(data.data_access_expires_at);
  const nowSeconds = Math.floor(nowMs / 1_000);
  // A well-formed negative inspection is rejected as bad proof. Missing or wrong-typed authority
  // fields instead mean the configured Graph contract changed or returned damaged upstream data;
  // that must stay retryable and must not consume a player's login-attempt budget.
  if (typeof data.is_valid !== "boolean"
    || typeof data.type !== "string"
    || typeof data.app_id !== "string"
    || typeof data.user_id !== "string"
    || issuedAt === null
    || expiresAt === null
    || dataAccessExpiresAt === null) providerUnavailable();
  if (data.is_valid !== true
    || data.type !== "USER"
    || data.app_id !== exactPolicy.appId
    || data.user_id !== expectedUserId
    || issuedAt <= 0
    || issuedAt > nowSeconds + 30
    || expiresAt <= nowSeconds
    || issuedAt > expiresAt
    || (dataAccessExpiresAt !== undefined
      && dataAccessExpiresAt !== 0
      && (dataAccessExpiresAt <= nowSeconds || dataAccessExpiresAt < issuedAt))) authorizationFailure();
  return Object.freeze({
    appId: exactPolicy.appId,
    userId: expectedUserId,
    issuedAt,
    expiresAt,
    ...(dataAccessExpiresAt === undefined ? {} : { dataAccessExpiresAt }),
  });
}

export class HttpFacebookTokenInspectionClient implements FacebookTokenInspectionClient {
  async inspect(input: FacebookTokenInspectionInput): Promise<unknown> {
    const url = new URL(`https://graph.facebook.com/${input.graphApiVersion}/debug_token`);
    url.searchParams.set("input_token", input.userAccessToken);
    let response: globalThis.Response;
    try {
      response = await globalThis.fetch(url.toString(), {
        method: "GET",
        redirect: "error",
        headers: {
          ...outboundRequestHeaders(),
          Accept: "application/json",
          // Meta accepts the app access token as normal Graph Bearer authentication. Keeping the
          // app secret out of the query prevents URL/proxy access logs from capturing it.
          Authorization: `Bearer ${input.appAccessToken}`,
        },
        signal: AbortSignal.timeout(input.timeoutMs),
      });
    } catch {
      providerUnavailable();
    }
    if (response.status === 429 || response.status >= 500) providerUnavailable();
    if (!response.ok || response.url !== url.toString()) authorizationFailure();
    const declaredLength = response.headers.get("content-length");
    if (declaredLength !== null
      && (!/^(?:0|[1-9][0-9]{0,8})$/u.test(declaredLength)
        || Number(declaredLength) > MAX_PROVIDER_RESPONSE_BYTES)) providerUnavailable();
    let bytes: Buffer;
    try {
      bytes = Buffer.from(await response.arrayBuffer());
    } catch {
      providerUnavailable();
    }
    if (bytes.length === 0 || bytes.length > MAX_PROVIDER_RESPONSE_BYTES) providerUnavailable();
    try {
      return JSON.parse(bytes.toString("utf8")) as unknown;
    } catch {
      providerUnavailable();
    }
  }
}

export class FacebookIdentityProofVerifier {
  constructor(
    private readonly policy: FacebookIdentityPolicy = CONFIGURED_FACEBOOK_IDENTITY_POLICY,
    private readonly client: FacebookTokenInspectionClient = new HttpFacebookTokenInspectionClient(),
  ) {}

  async verify(expectedUserId: string, proofValue: unknown, now = new Date()): Promise<void> {
    const exactPolicy = facebookIdentityPolicy(this.policy);
    if (!exactPolicy.enabled) authorizationFailure();
    const proof = parseFacebookIdentityProof(proofValue);
    let inspection: unknown;
    try {
      inspection = await this.client.inspect({
        userAccessToken: proof.accessToken,
        appAccessToken: `${exactPolicy.appId}|${exactPolicy.appSecret}`,
        graphApiVersion: exactPolicy.graphApiVersion,
        timeoutMs: exactPolicy.timeoutMs,
      });
    } catch (error) {
      if (error instanceof ApiError) throw error;
      providerUnavailable();
    }
    validatedFacebookTokenInspection(inspection, expectedUserId, exactPolicy, now);
  }
}

const defaultVerifier = new FacebookIdentityProofVerifier();

/** Enforce live proof only in explicit patched-client mode; never ignore a supplied token proof. */
export async function verifyFacebookIdentityOwnership(
  externalId: string,
  proofValue: unknown,
  verifier: FacebookIdentityProofVerifier = defaultVerifier,
  policy: FacebookIdentityPolicy = CONFIGURED_FACEBOOK_IDENTITY_POLICY,
): Promise<void> {
  const exactPolicy = facebookIdentityPolicy(policy);
  if (!exactPolicy.enabled) {
    if (proofValue !== undefined) authorizationFailure();
    return;
  }
  await verifier.verify(externalId, proofValue);
}
