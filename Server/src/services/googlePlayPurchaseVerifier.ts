import { GoogleAuth } from "google-auth-library";
import { googlePlayStoreProductId, type InAppEntitlement } from "./inAppCatalogService";

const androidPublisherScope = "https://www.googleapis.com/auth/androidpublisher";
const publisherRoot = "https://androidpublisher.googleapis.com/androidpublisher/v3/applications";

export interface GooglePlayVerificationInput {
  packageName: string;
  productId: string;
  purchaseToken: string;
  orderId: string;
  entitlement: InAppEntitlement;
}

export interface VerifiedGooglePlayPurchase {
  kind: "currency" | "pack" | "subscription";
  productId: string;
  storeProductId: string;
  orderId: string;
  purchasedAt: number;
  expiresAt?: number;
  subscriptionState?: string;
}

export interface GoogleProductPurchaseResponse {
  purchaseTimeMillis?: string;
  purchaseState?: number;
  consumptionState?: number;
  orderId?: string;
  acknowledgementState?: number;
  purchaseToken?: string;
  productId?: string;
  quantity?: number;
}

export interface GoogleSubscriptionPurchaseV2Response {
  startTime?: string;
  subscriptionState?: string;
  acknowledgementState?: string;
  lineItems?: Array<{
    productId?: string;
    expiryTime?: string;
    latestSuccessfulOrderId?: string;
  }>;
}

export interface GooglePlaySubscriptionStatusInput {
  packageName: string;
  productId: string;
  purchaseToken: string;
}

/** Parsed successful subscriptionsv2 response used by both purchase and background paths. */
export interface GooglePlaySubscriptionStatus {
  subscriptionState: string;
  entitled: boolean;
  storeProductId: string;
  orderId?: string;
  purchasedAt?: number;
  expiresAt?: number;
}

export class GooglePlayVerificationError extends Error {
  constructor(message: string, readonly transient = false) {
    super(message);
    this.name = "GooglePlayVerificationError";
  }
}

function unixSeconds(value: string | undefined, field: string): number {
  const milliseconds = value ? Date.parse(value) : Number.NaN;
  if (!Number.isFinite(milliseconds)) throw new GooglePlayVerificationError(`Google Play ${field} is invalid.`);
  return Math.floor(milliseconds / 1_000);
}

function verifiedOrderId(serverOrderId: string | undefined, clientOrderId: string): string {
  if (!serverOrderId || !serverOrderId.trim()) {
    throw new GooglePlayVerificationError("Google Play did not return an order ID.");
  }
  if (serverOrderId !== clientOrderId) {
    throw new GooglePlayVerificationError("Google Play order ID does not match the request.");
  }
  return serverOrderId;
}

function serverOrderId(serverOrder: string | undefined): string {
  if (!serverOrder || !serverOrder.trim()) {
    throw new GooglePlayVerificationError("Google Play did not return an order ID.");
  }
  return serverOrder;
}

/** Validate the current products.get response without trusting any client-authored amount. */
export function parseGoogleProductPurchase(
  response: GoogleProductPurchaseResponse,
  input: GooglePlayVerificationInput,
): VerifiedGooglePlayPurchase {
  if (input.entitlement.kind === "subscription") {
    throw new GooglePlayVerificationError("Subscription must use the subscriptions endpoint.");
  }
  const storeProductId = googlePlayStoreProductId(input.packageName, input.productId);
  if (response.purchaseState !== 0) throw new GooglePlayVerificationError("Google Play purchase is not completed.");
  // Older product responses may omit productId; the endpoint path already binds token and SKU.
  // If Google returns it, require the exact value instead of accepting contradictory metadata.
  if (response.productId !== undefined && response.productId !== storeProductId) {
    throw new GooglePlayVerificationError("Google Play product does not match.");
  }
  if ((response.quantity ?? 1) !== 1) throw new GooglePlayVerificationError("Google Play quantity is not supported.");
  const purchasedAtMilliseconds = Number(response.purchaseTimeMillis);
  if (!Number.isSafeInteger(purchasedAtMilliseconds) || purchasedAtMilliseconds <= 0) {
    throw new GooglePlayVerificationError("Google Play purchase time is invalid.");
  }
  return {
    // products.get verifies both consumable currency and one-time packs. Their benefit kind is
    // selected only from the server catalog; the Play payload cannot change this discriminator.
    kind: input.entitlement.kind,
    productId: input.productId,
    storeProductId,
    orderId: verifiedOrderId(response.orderId, input.orderId),
    purchasedAt: Math.floor(purchasedAtMilliseconds / 1_000),
  };
}

/**
 * Validate subscriptionsv2.get. Active, grace-period, and canceled-but-unexpired states still
 * carry entitlement; pending, paused, on-hold, and expired states must never enable benefits.
 */
export function parseGoogleSubscriptionPurchase(
  response: GoogleSubscriptionPurchaseV2Response,
  input: GooglePlayVerificationInput,
  now: number,
): VerifiedGooglePlayPurchase {
  const status = parseGoogleSubscriptionStatus(response, input, now);
  if (!status.entitled) {
    throw new GooglePlayVerificationError("Google Play subscription is not entitled.");
  }
  if (status.purchasedAt === undefined) {
    throw new GooglePlayVerificationError("Google Play subscription start time is invalid.");
  }
  return {
    kind: "subscription",
    productId: input.productId,
    storeProductId: status.storeProductId,
    // BillingClient may retain the initial subscription order while V2 exposes the newest
    // renewal order. The verified token/product/expiry are authoritative; store Google's latest
    // order for uniqueness instead of rejecting a legitimate renewal on that expected mismatch.
    orderId: serverOrderId(status.orderId),
    purchasedAt: status.purchasedAt,
    expiresAt: status.expiresAt,
    subscriptionState: status.subscriptionState,
  };
}

/**
 * Parse a successful status response without conflating non-entitlement with transport failure.
 *
 * Background reconciliation may shorten entitlement only after Google returned a structurally
 * valid resource. HTTP/authentication failures never reach this function and are retryable, so a
 * credential outage cannot revoke every subscriber. Canceled remains entitled through expiry,
 * matching Play's documented access rule; paused and on-hold stop benefits immediately.
 */
export function parseGoogleSubscriptionStatus(
  response: GoogleSubscriptionPurchaseV2Response,
  input: Pick<GooglePlayVerificationInput, "packageName" | "productId">,
  now: number,
): GooglePlaySubscriptionStatus {
  const knownStates = new Set([
    "SUBSCRIPTION_STATE_UNSPECIFIED",
    "SUBSCRIPTION_STATE_PENDING",
    "SUBSCRIPTION_STATE_ACTIVE",
    "SUBSCRIPTION_STATE_PAUSED",
    "SUBSCRIPTION_STATE_IN_GRACE_PERIOD",
    "SUBSCRIPTION_STATE_ON_HOLD",
    "SUBSCRIPTION_STATE_CANCELED",
    "SUBSCRIPTION_STATE_EXPIRED",
    "SUBSCRIPTION_STATE_PENDING_PURCHASE_CANCELED",
  ]);
  const entitledStates = new Set([
    "SUBSCRIPTION_STATE_ACTIVE",
    "SUBSCRIPTION_STATE_IN_GRACE_PERIOD",
    "SUBSCRIPTION_STATE_CANCELED",
  ]);
  if (!response.subscriptionState) {
    throw new GooglePlayVerificationError("Google Play subscription state is invalid.");
  }
  // New API states require an explicit entitlement decision. Failing the check is safer than
  // interpreting an unknown future state as revoked and shortening paid access accidentally.
  if (!knownStates.has(response.subscriptionState)) {
    throw new GooglePlayVerificationError("Google Play returned an unknown subscription state.", true);
  }
  const storeProductId = googlePlayStoreProductId(input.packageName, input.productId);
  const matching = (response.lineItems ?? []).filter((item) => item.productId === storeProductId);
  const latest = matching.reduce<{ item?: NonNullable<GoogleSubscriptionPurchaseV2Response["lineItems"]>[number]; expiry: number }>((best, item) => {
    const expiry = unixSeconds(item.expiryTime, "subscription expiry");
    return expiry > best.expiry ? { item, expiry } : best;
  }, { expiry: 0 });
  const purchasedAt = response.startTime === undefined
    ? undefined
    : unixSeconds(response.startTime, "subscription start time");
  return {
    subscriptionState: response.subscriptionState,
    entitled: entitledStates.has(response.subscriptionState) && latest.expiry > now,
    storeProductId,
    orderId: latest.item?.latestSuccessfulOrderId,
    purchasedAt,
    expiresAt: latest.expiry > 0 ? latest.expiry : undefined,
  };
}

export interface GooglePlayPurchaseVerifier {
  verify(input: GooglePlayVerificationInput, now: number): Promise<VerifiedGooglePlayPurchase>;
}

export interface GooglePlaySubscriptionStatusVerifier {
  getSubscriptionStatus(
    input: GooglePlaySubscriptionStatusInput,
    now: number,
  ): Promise<GooglePlaySubscriptionStatus>;
}

export interface GooglePlayVoidedPurchase {
  purchaseToken: string;
  orderId: string;
  purchaseTimeMillis: number;
  voidedTimeMillis: number;
  voidedSource: number;
  voidedReason: number;
}

export interface GooglePlayVoidedPurchasePage {
  purchases: GooglePlayVoidedPurchase[];
  nextPageToken?: string;
}

export interface GooglePlayVoidedPurchaseLister {
  listVoidedProductPurchases(
    packageName: string,
    startTimeMillis: number,
    endTimeMillis: number,
    pageToken?: string,
  ): Promise<GooglePlayVoidedPurchasePage>;
}

export interface GoogleVoidedPurchasesResponse {
  tokenPagination?: { nextPageToken?: string };
  voidedPurchases?: Array<{
    purchaseToken?: string;
    orderId?: string;
    purchaseTimeMillis?: string;
    voidedTimeMillis?: string;
    voidedSource?: number;
    voidedReason?: number;
  }>;
}

function positiveMillis(value: string | undefined, field: string): number {
  const parsed = Number(value);
  if (!Number.isSafeInteger(parsed) || parsed <= 0) {
    throw new GooglePlayVerificationError(`Google Play ${field} is invalid.`, true);
  }
  return parsed;
}

function boundedGoogleText(value: string | undefined, field: string, maximum: number): string {
  if (!value || value.length > maximum || value.trim() !== value) {
    throw new GooglePlayVerificationError(`Google Play ${field} is invalid.`, true);
  }
  return value;
}

/** Strictly decode one list page before any refund event is allowed to mutate progression. */
export function parseGoogleVoidedPurchasesPage(
  response: GoogleVoidedPurchasesResponse,
): GooglePlayVoidedPurchasePage {
  const purchases = (response.voidedPurchases ?? []).map((purchase) => ({
    purchaseToken: boundedGoogleText(purchase.purchaseToken, "voided purchase token", 4_096),
    orderId: boundedGoogleText(purchase.orderId, "voided order ID", 255),
    purchaseTimeMillis: positiveMillis(purchase.purchaseTimeMillis, "voided purchase time"),
    voidedTimeMillis: positiveMillis(purchase.voidedTimeMillis, "voided time"),
    voidedSource: Number.isInteger(purchase.voidedSource) ? purchase.voidedSource! : -1,
    voidedReason: Number.isInteger(purchase.voidedReason) ? purchase.voidedReason! : -1,
  }));
  if (purchases.some((purchase) => purchase.voidedSource < 0 || purchase.voidedReason < 0)) {
    throw new GooglePlayVerificationError("Google Play voided purchase reason is invalid.", true);
  }
  const nextPageToken = response.tokenPagination?.nextPageToken;
  if (nextPageToken !== undefined) boundedGoogleText(nextPageToken, "pagination token", 4_096);
  return { purchases, ...(nextPageToken ? { nextPageToken } : {}) };
}

/** Production verifier backed by Google Application Default Credentials. */
export class GooglePlayDeveloperApiVerifier implements
  GooglePlayPurchaseVerifier,
  GooglePlaySubscriptionStatusVerifier,
  GooglePlayVoidedPurchaseLister {
  private readonly auth = new GoogleAuth({ scopes: [androidPublisherScope] });

  /**
   * List only voided one-time products (`type=0`). Subscriptions already have their own status
   * authority and renewal order semantics; mixing them into a token-keyed product reversal sweep
   * could revoke the wrong renewal. The caller advances its durable window only after every
   * returned pagination token has completed successfully.
   */
  async listVoidedProductPurchases(
    packageNameValue: string,
    startTimeMillis: number,
    endTimeMillis: number,
    pageToken?: string,
  ): Promise<GooglePlayVoidedPurchasePage> {
    const packageName = encodeURIComponent(packageNameValue);
    const query = new URLSearchParams({
      startTime: String(startTimeMillis),
      endTime: String(endTimeMillis),
      maxResults: "1000",
      type: "0",
    });
    if (pageToken) query.set("token", pageToken);
    try {
      const client = await this.auth.getClient();
      const response = await client.request<GoogleVoidedPurchasesResponse>({
        method: "GET",
        url: `${publisherRoot}/${packageName}/purchases/voidedpurchases?${query.toString()}`,
      });
      return parseGoogleVoidedPurchasesPage(response.data);
    } catch (error) {
      if (error instanceof GooglePlayVerificationError) throw error;
      throw new GooglePlayVerificationError("Google Play voided purchases query failed.", true);
    }
  }

  async getSubscriptionStatus(
    input: GooglePlaySubscriptionStatusInput,
    now: number,
  ): Promise<GooglePlaySubscriptionStatus> {
    const packageName = encodeURIComponent(input.packageName);
    const token = encodeURIComponent(input.purchaseToken);
    try {
      const client = await this.auth.getClient();
      const response = await client.request<GoogleSubscriptionPurchaseV2Response>({
        method: "GET",
        url: `${publisherRoot}/${packageName}/purchases/subscriptionsv2/tokens/${token}`,
      });
      return parseGoogleSubscriptionStatus(response.data, input, now);
    } catch (error) {
      if (error instanceof GooglePlayVerificationError) throw error;
      // A status endpoint error proves nothing about entitlement. Even 4xx responses can be a
      // deployment package/permission mistake, so every transport/auth error is retried and can
      // never shorten a player's current subscription.
      throw new GooglePlayVerificationError("Google Play subscription status check failed.", true);
    }
  }

  async verify(input: GooglePlayVerificationInput, now: number): Promise<VerifiedGooglePlayPurchase> {
    if (input.entitlement.kind === "subscription") {
      const status = await this.getSubscriptionStatus(input, now);
      if (!status.entitled) throw new GooglePlayVerificationError("Google Play subscription is not entitled.");
      if (status.purchasedAt === undefined) {
        throw new GooglePlayVerificationError("Google Play subscription start time is invalid.");
      }
      return {
        kind: "subscription",
        productId: input.productId,
        storeProductId: status.storeProductId,
        orderId: serverOrderId(status.orderId),
        purchasedAt: status.purchasedAt,
        expiresAt: status.expiresAt,
        subscriptionState: status.subscriptionState,
      };
    }
    const packageName = encodeURIComponent(input.packageName);
    const token = encodeURIComponent(input.purchaseToken);
    try {
      // Credential discovery can fail before an HTTP request is made. Keep it in this guarded
      // block so missing/revoked deployment credentials become a classified transient failure
      // instead of escaping as an unrelated generic backend error.
      const client = await this.auth.getClient();
      const storeProductId = encodeURIComponent(googlePlayStoreProductId(input.packageName, input.productId));
      const response = await client.request<GoogleProductPurchaseResponse>({
        method: "GET",
        url: `${publisherRoot}/${packageName}/purchases/products/${storeProductId}/tokens/${token}`,
      });
      return parseGoogleProductPurchase(response.data, input);
    } catch (error) {
      if (error instanceof GooglePlayVerificationError) throw error;
      const status = typeof error === "object" && error !== null && "response" in error
        ? Number((error as { response?: { status?: unknown } }).response?.status)
        : 0;
      const transient = status === 0 || status === 429 || status >= 500;
      throw new GooglePlayVerificationError("Google Play purchase verification failed.", transient);
    }
  }
}
