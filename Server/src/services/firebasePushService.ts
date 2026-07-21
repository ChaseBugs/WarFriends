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

const FIREBASE_MESSAGING_SCOPE = "https://www.googleapis.com/auth/firebase.messaging";

export interface FirebaseDataPush {
  readonly token: string;
  readonly data: Readonly<{ id: "2" | "90" }>;
}

export interface FirebasePushTransport {
  send(message: FirebaseDataPush, policy: FirebasePushPolicy): Promise<void>;
}

/** Build the complete provider request without adding un-recovered visible notification fields. */
export function firebaseHttpV1RequestFor(message: FirebaseDataPush, policy: FirebasePushPolicy) {
  return {
    method: "POST" as const,
    url: `https://fcm.googleapis.com/v1/projects/${encodeURIComponent(policy.projectId)}/messages:send`,
    timeout: policy.requestTimeoutMilliseconds,
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

type ConsentKey = keyof NotificationSettingsDTO;

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
    case 3: return { id: "90", consent: "squadStatus" };
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
    const client = await this.auth.getClient();
    await client.request(firebaseHttpV1RequestFor(message, policy));
  }
}

const productionTransport = new FirebaseHttpV1Transport();

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
  if (!policy.enabled) return false;
  try {
    const fanout = await getLiveInboxFanout(recipientPlayerId, messageId);
    if (!fanout) return false;
    const messageTypeAttribute = fanout.message.MessageType;
    if (!messageTypeAttribute || !("N" in messageTypeAttribute)) return false;
    const rawMessageType = Number(messageTypeAttribute.N);
    const wake = firebaseWakeActionFor(rawMessageType as MessageDoc["messageType"]);
    if (!wake) return false;

    const player = await players().findOne({ id: recipientPlayerId });
    if (!player) return false;
    validatedPlayerAccountEnvelope(player);
    const dataPush = firebaseDataPushFor(
      rawMessageType as MessageDoc["messageType"],
      player.player.status,
      player.player.deviceToken,
      settingsForPlayer(player),
    );
    if (!dataPush) return false;
    await transport.send(dataPush, policy);
    return true;
  } catch (error) {
    logger.warnWithEmoji("PUSH", "Firebase inbox wake-up failed", "FIREBASE", {
      recipientPlayerId,
      messageId,
      error: error instanceof Error ? error.message : "Unknown Firebase error",
    });
    return false;
  }
}
