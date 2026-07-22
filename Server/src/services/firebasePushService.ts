import { GoogleAuth } from "google-auth-library";
import { players } from "../db";
import { PlayerStatus } from "../constants";
import logger from "../utils/logger";
import type { NotificationSettingsDTO } from "../dtos";
import type { MessageDoc } from "./socialService";
import { getLiveInboxFanout } from "./inboxFanoutService";
import { validatedPlayerAccountEnvelope } from "./playerProfileMirrorAuthorityService";
import { settingsForPlayer } from "./playerSettingsService";
import { firebasePushPolicy, type FirebasePushPolicy } from "./firebasePushPolicyService";
import { outboundRequestHeaders } from "./requestContextService";

const FIREBASE_MESSAGING_SCOPE = "https://www.googleapis.com/auth/firebase.messaging";

export interface FirebaseDataPush {
  readonly token: string;
  readonly data: Readonly<{ id: "2" | "90" }>;
}

export interface FirebasePushTransport {
  send(message: FirebaseDataPush, policy: FirebasePushPolicy): Promise<void>;
}

export type FirebaseFailureDisposition = "invalidToken" | "transient" | "configuration";

export class FirebasePushDeliveryError extends Error {
  constructor(
    message: string,
    readonly disposition: FirebaseFailureDisposition,
  ) {
    super(message);
    this.name = "FirebasePushDeliveryError";
  }
}

function record(value: unknown): Record<string, unknown> | null {
  return value !== null && typeof value === "object" && !Array.isArray(value)
    ? value as Record<string, unknown>
    : null;
}

/**
 * Classify the structured HTTP v1 error without deleting tokens for deployment mistakes.
 *
 * Firebase documents `UNREGISTERED` as terminal. `INVALID_ARGUMENT` is terminal for a token only
 * when the response contains the FCM-specific detail; a generic BadRequest can instead mean that
 * the sender payload is wrong. Quota, availability, internal, and transport failures remain
 * retryable. Sender/auth/project mismatches are configuration failures and must retain every token.
 */
export function firebaseFailureDisposition(error: unknown): FirebaseFailureDisposition {
  const outer = record(error);
  const response = record(outer?.response);
  const envelope = record(response?.data);
  const providerError = record(envelope?.error);
  const status = typeof providerError?.status === "string" ? providerError.status : "";
  const details = Array.isArray(providerError?.details) ? providerError.details : [];
  const fcmCode = details
    .map(record)
    .find((detail) => detail?.["@type"] === "type.googleapis.com/google.firebase.fcm.v1.FcmError")
    ?.errorCode;
  if (fcmCode === "UNREGISTERED"
    || (status === "UNREGISTERED")
    || (fcmCode === "INVALID_ARGUMENT" && status === "INVALID_ARGUMENT")) return "invalidToken";

  const httpStatus = typeof response?.status === "number"
    ? response.status
    : typeof providerError?.code === "number" ? providerError.code : 0;
  if (status === "QUOTA_EXCEEDED"
    || status === "UNAVAILABLE"
    || status === "INTERNAL"
    || httpStatus === 429
    || httpStatus >= 500
    || !response) return "transient";
  return "configuration";
}

/** Build the complete provider request without adding un-recovered visible notification fields. */
export function firebaseHttpV1RequestFor(message: FirebaseDataPush, policy: FirebasePushPolicy) {
  return {
    method: "POST" as const,
    url: `https://fcm.googleapis.com/v1/projects/${encodeURIComponent(policy.projectId)}/messages:send`,
    timeout: policy.requestTimeoutMilliseconds,
    headers: outboundRequestHeaders(),
    data: {
      message: {
        token: message.token,
        data: message.data,
        // Data-only messages need high priority to wake the stock Android Firebase callback in
        // time; this changes transport scheduling, not game-visible notification content.
        android: { priority: "HIGH" },
      },
    },
  };
}

/** Exact compare-and-set used to retire only the registration token rejected by FCM. */
export function invalidFirebaseTokenRetirement(
  recipientPlayerId: string,
  deviceToken: string,
  now: Date,
) {
  return {
    filter: {
      id: recipientPlayerId,
      deviceToken,
      "player.deviceToken": deviceToken,
    },
    update: {
      $set: {
        deviceToken: "",
        "player.deviceToken": "",
        updatedAt: now,
      },
    },
  };
}

type ConsentKey = keyof NotificationSettingsDTO;

/**
 * Complete durable inbox families eligible for an offline Firebase wake.
 *
 * Keep this exported list shared with crash-window reconciliation. Type 27 is deliberately absent
 * because the recovered settings have no direct-message consent category; every listed family is
 * handled by `firebaseWakeActionFor` below.
 */
export const FIREBASE_PUSH_MESSAGE_TYPES = Object.freeze([
  0, 1, 3, 9, 10, 11, 21, 23, 28,
] as const satisfies readonly MessageDoc["messageType"][]);

/**
 * Map durable inbox families to the only remote data actions recovered from
 * `PushNotificationManager.ReactToNotification`.
 *
 * A challenge uses `DatabaseAction.MessageSent` (2), which also sets the client's challenge-wake
 * flag. Every other supported remote inbox family uses `SystemMessage` (90), which only refreshes
 * the inbox. Direct text (27) has no dedicated recovered consent category and is deliberately not
 * pushed; borrowing another switch would violate the player's stored preference.
 */
export function firebaseWakeActionFor(
  messageType: MessageDoc["messageType"],
): { id: "2" | "90"; consent: ConsentKey } | null {
  switch (messageType) {
    case 0: return { id: "2", consent: "challenge" };
    case 1:
    case 3:
    // A Squad rank change is durable Squad status, while action 90 remains only the recovered
    // generic inbox-refresh wake. Reuse the player's explicit squadStatus consent.
    case 10: return { id: "90", consent: "squadStatus" };
    case 9:
    case 11:
    case 21:
      return { id: "90", consent: "squadEvents" };
    case 23: return { id: "90", consent: "playerLeague" };
    // The recovered local War Card withdrawal reminder uses the SQUAD_INFO channel, so the same
    // squad-status consent is the narrowest source-supported remote category for type 28.
    case 28: return { id: "90", consent: "squadStatus" };
    case 27: return null;
  }
}

/** Build a provider message only for an offline, registered, consenting recipient. */
export function firebaseDataPushFor(
  messageType: MessageDoc["messageType"],
  status: PlayerStatus,
  deviceToken: string,
  settings: NotificationSettingsDTO,
): FirebaseDataPush | null {
  const wake = firebaseWakeActionFor(messageType);
  if (!wake
    || status !== PlayerStatus.Offline
    || deviceToken.length === 0
    || !settings[wake.consent]) return null;
  return { token: deviceToken, data: { id: wake.id } };
}

/** Production Firebase Cloud Messaging HTTP v1 transport backed by ADC. */
export class FirebaseHttpV1Transport implements FirebasePushTransport {
  private readonly auth = new GoogleAuth({ scopes: [FIREBASE_MESSAGING_SCOPE] });

  async send(message: FirebaseDataPush, policy: FirebasePushPolicy): Promise<void> {
    try {
      const client = await this.auth.getClient();
      await client.request(firebaseHttpV1RequestFor(message, policy));
    } catch (error) {
      throw new FirebasePushDeliveryError(
        "Firebase HTTP v1 delivery failed.",
        firebaseFailureDisposition(error),
      );
    }
  }
}

const productionTransport = new FirebaseHttpV1Transport();

export type FirebasePushAttemptResult =
  | { readonly outcome: "sent" }
  | { readonly outcome: "not-eligible" }
  | {
    readonly outcome: "failed";
    readonly disposition: FirebaseFailureDisposition;
    readonly attemptedToken: string;
    readonly error: string;
  };

/**
 * Resolve current inbox, account, consent, presence, and token authority immediately before send.
 *
 * Provider failures are returned as data so the durable delivery worker can choose between retry,
 * token retirement, and terminal suppression. MongoDB validation failures deliberately escape:
 * malformed durable authority is an operator repair condition and must stop the leased batch
 * rather than being mislabeled as a transient Firebase outage.
 */
export async function attemptOfflineInboxPush(
  recipientPlayerId: string,
  messageId: string,
  transport: FirebasePushTransport = productionTransport,
  policy: FirebasePushPolicy = firebasePushPolicy(),
): Promise<FirebasePushAttemptResult> {
  if (!policy.enabled) return { outcome: "not-eligible" };
  const fanout = await getLiveInboxFanout(recipientPlayerId, messageId);
  if (!fanout) return { outcome: "not-eligible" };
  const messageTypeAttribute = fanout.message.MessageType;
  if (!messageTypeAttribute || !("N" in messageTypeAttribute)) return { outcome: "not-eligible" };
  const rawMessageType = Number(messageTypeAttribute.N);
  const wake = firebaseWakeActionFor(rawMessageType as MessageDoc["messageType"]);
  if (!wake) return { outcome: "not-eligible" };

  const player = await players().findOne({ id: recipientPlayerId });
  if (!player) return { outcome: "not-eligible" };
  validatedPlayerAccountEnvelope(player);
  const dataPush = firebaseDataPushFor(
    rawMessageType as MessageDoc["messageType"],
    player.player.status,
    player.player.deviceToken,
    settingsForPlayer(player),
  );
  if (!dataPush) return { outcome: "not-eligible" };
  try {
    await transport.send(dataPush, policy);
    return { outcome: "sent" };
  } catch (error) {
    return {
      outcome: "failed",
      disposition: error instanceof FirebasePushDeliveryError
        ? error.disposition
        : firebaseFailureDisposition(error),
      attemptedToken: dataPush.token,
      error: error instanceof Error ? error.message : "Unknown Firebase error",
    };
  }
}

/**
 * Best-effort offline wake-up after the inbox row has committed.
 *
 * The identity-only fan-out is rebound to the complete unclaimed MongoDB message first. The full
 * player envelope then proves status, device-token mirrors, locale metadata, and notification
 * consent before Firebase sees the token. Provider failure is logged but never changes or removes
 * the durable inbox row; reconnect/GetAllMessages remains the authoritative recovery path.
 */
export async function publishOfflineInboxPush(
  recipientPlayerId: string,
  messageId: string,
  transport: FirebasePushTransport = productionTransport,
  policy: FirebasePushPolicy = firebasePushPolicy(),
): Promise<boolean> {
  try {
    const result = await attemptOfflineInboxPush(recipientPlayerId, messageId, transport, policy);
    if (result.outcome === "sent") return true;
    if (result.outcome === "not-eligible") return false;
    if (result.disposition === "invalidToken") {
      // Compare both mirrored copies so a concurrent action-13 token refresh wins. Only the exact
      // token rejected by Firebase is retired; a newer installation credential is never cleared by
      // a delayed provider response from an older send attempt.
      try {
        const retirement = invalidFirebaseTokenRetirement(
          recipientPlayerId,
          result.attemptedToken,
          new Date(),
        );
        await players().updateOne(retirement.filter, retirement.update);
      } catch (retirementError) {
        logger.warnWithEmoji("PUSH", "Invalid Firebase token could not be retired", "FIREBASE", {
          recipientPlayerId,
          messageId,
          error: retirementError instanceof Error ? retirementError.message : "Unknown database error",
        });
      }
    }
    logger.warnWithEmoji("PUSH", "Firebase inbox wake-up failed", "FIREBASE", {
      recipientPlayerId,
      messageId,
      disposition: result.disposition,
      error: result.error,
    });
    return false;
  } catch (error) {
    logger.warnWithEmoji("PUSH", "Firebase inbox wake-up authority failed", "FIREBASE", {
      recipientPlayerId,
      messageId,
      error: error instanceof Error ? error.message : "Unknown database error",
    });
    return false;
  }
}
