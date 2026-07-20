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
  kind: "currency" | "subscription";
  productId: string;
  storeProductId: string;
  orderId: string;
  purchasedAt: number;
  expiresAt?: number;
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
    kind: "currency",
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
  const entitledStates = new Set([
    "SUBSCRIPTION_STATE_ACTIVE",
    "SUBSCRIPTION_STATE_IN_GRACE_PERIOD",
    "SUBSCRIPTION_STATE_CANCELED",
  ]);
  if (!response.subscriptionState || !entitledStates.has(response.subscriptionState)) {
    throw new GooglePlayVerificationError("Google Play subscription is not entitled.");
  }
  const storeProductId = googlePlayStoreProductId(input.packageName, input.productId);
  const matching = (response.lineItems ?? []).filter((item) => item.productId === storeProductId);
  if (matching.length === 0) throw new GooglePlayVerificationError("Google Play subscription product does not match.");
  const latest = matching.reduce((best, item) => {
    const expiry = unixSeconds(item.expiryTime, "subscription expiry");
    return expiry > best.expiry ? { item, expiry } : best;
  }, { item: matching[0]!, expiry: 0 });
  if (latest.expiry <= now) throw new GooglePlayVerificationError("Google Play subscription is expired.");
  return {
    kind: "subscription",
    productId: input.productId,
    storeProductId,
    // BillingClient may retain the initial subscription order while V2 exposes the newest
    // renewal order. The verified token/product/expiry are authoritative; store Google's latest
    // order for uniqueness instead of rejecting a legitimate renewal on that expected mismatch.
    orderId: serverOrderId(latest.item.latestSuccessfulOrderId),
    purchasedAt: unixSeconds(response.startTime, "subscription start time"),
    expiresAt: latest.expiry,
  };
}

export interface GooglePlayPurchaseVerifier {
  verify(input: GooglePlayVerificationInput, now: number): Promise<VerifiedGooglePlayPurchase>;
}

/** Production verifier backed by Google Application Default Credentials. */
export class GooglePlayDeveloperApiVerifier implements GooglePlayPurchaseVerifier {
  private readonly auth = new GoogleAuth({ scopes: [androidPublisherScope] });

  async verify(input: GooglePlayVerificationInput, now: number): Promise<VerifiedGooglePlayPurchase> {
    const packageName = encodeURIComponent(input.packageName);
    const token = encodeURIComponent(input.purchaseToken);
    try {
      // Credential discovery can fail before an HTTP request is made. Keep it in this guarded
      // block so missing/revoked deployment credentials become a classified transient failure
      // instead of escaping as an unrelated generic backend error.
      const client = await this.auth.getClient();
      if (input.entitlement.kind === "subscription") {
        const response = await client.request<GoogleSubscriptionPurchaseV2Response>({
          method: "GET",
          url: `${publisherRoot}/${packageName}/purchases/subscriptionsv2/tokens/${token}`,
        });
        return parseGoogleSubscriptionPurchase(response.data, input, now);
      }
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
