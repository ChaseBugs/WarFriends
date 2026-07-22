import assert from "node:assert/strict";
import test from "node:test";
import { PlayerStatus } from "../constants";
import type { NotificationSettingsDTO } from "../dtos";
import {
  FIREBASE_PUSH_MESSAGE_TYPES,
  firebaseDataPushFor,
  firebaseFailureDisposition,
  firebaseHttpV1RequestFor,
  firebaseWakeActionFor,
  invalidFirebaseTokenRetirement,
} from "../services/firebasePushService";
import { exactFirebasePushPolicy } from "../services/firebasePushPolicyService";
import { runWithRequestContext } from "../services/requestContextService";

const ALL_ENABLED: NotificationSettingsDTO = {
  challenge: true,
  squadStatus: true,
  squadEvents: true,
  maintenance: true,
  playerLeague: true,
  dailyRewardNotification: true,
};

test("Firebase wake actions preserve the two recovered client data IDs", () => {
  assert.deepEqual(FIREBASE_PUSH_MESSAGE_TYPES, [0, 1, 3, 9, 10, 11, 21, 23, 28]);
  assert.equal(FIREBASE_PUSH_MESSAGE_TYPES.every((type) => firebaseWakeActionFor(type) !== null), true);
  assert.deepEqual(firebaseWakeActionFor(0), { id: "2", consent: "challenge" });
  assert.deepEqual(firebaseWakeActionFor(1), { id: "90", consent: "squadStatus" });
  assert.deepEqual(firebaseWakeActionFor(3), { id: "90", consent: "squadStatus" });
  assert.deepEqual(firebaseWakeActionFor(10), { id: "90", consent: "squadStatus" });
  assert.deepEqual(firebaseWakeActionFor(9), { id: "90", consent: "squadEvents" });
  assert.deepEqual(firebaseWakeActionFor(11), { id: "90", consent: "squadEvents" });
  assert.deepEqual(firebaseWakeActionFor(21), { id: "90", consent: "squadEvents" });
  assert.deepEqual(firebaseWakeActionFor(23), { id: "90", consent: "playerLeague" });
  assert.deepEqual(firebaseWakeActionFor(28), { id: "90", consent: "squadStatus" });
  assert.equal(firebaseWakeActionFor(27), null);
});

test("Firebase data pushes require offline status, a token, and matching consent", () => {
  assert.deepEqual(
    firebaseDataPushFor(0, PlayerStatus.Offline, "device-token", ALL_ENABLED),
    { token: "device-token", data: { id: "2" } },
  );
  assert.equal(firebaseDataPushFor(0, PlayerStatus.Online, "device-token", ALL_ENABLED), null);
  assert.equal(firebaseDataPushFor(0, PlayerStatus.InGame, "device-token", ALL_ENABLED), null);
  assert.equal(firebaseDataPushFor(0, PlayerStatus.Offline, "", ALL_ENABLED), null);
  assert.equal(firebaseDataPushFor(27, PlayerStatus.Offline, "device-token", ALL_ENABLED), null);
  assert.equal(firebaseDataPushFor(23, PlayerStatus.Offline, "device-token", {
    ...ALL_ENABLED,
    playerLeague: false,
  }), null);
  assert.equal(firebaseDataPushFor(28, PlayerStatus.Offline, "device-token", {
    ...ALL_ENABLED,
    squadStatus: false,
  }), null);
  assert.equal(firebaseDataPushFor(10, PlayerStatus.Offline, "device-token", {
    ...ALL_ENABLED,
    squadStatus: false,
  }), null);
});

test("Firebase deployment policy is exact, bounded, and fail-closed when enabled", () => {
  assert.deepEqual(exactFirebasePushPolicy({
    enabled: false,
    projectId: "",
    requestTimeoutMilliseconds: 5_000,
  }), {
    enabled: false,
    projectId: "",
    requestTimeoutMilliseconds: 5_000,
  });
  assert.deepEqual(exactFirebasePushPolicy({
    enabled: true,
    projectId: "warfriends-offline",
    requestTimeoutMilliseconds: 1_000,
  }).projectId, "warfriends-offline");

  for (const policy of [
    { enabled: true, projectId: "", requestTimeoutMilliseconds: 5_000 },
    { enabled: true, projectId: " Warfriends ", requestTimeoutMilliseconds: 5_000 },
    { enabled: true, projectId: "wf", requestTimeoutMilliseconds: 5_000 },
    { enabled: true, projectId: "warfriends-offline", requestTimeoutMilliseconds: 999 },
    { enabled: true, projectId: "warfriends-offline", requestTimeoutMilliseconds: 30_001 },
    { enabled: true, projectId: "warfriends-offline", requestTimeoutMilliseconds: Number.NaN },
  ]) {
    assert.throws(() => exactFirebasePushPolicy(policy), /Firebase push policy is invalid/);
  }
});

test("Firebase HTTP v1 request contains only recovered data, scheduling, and correlation", () => {
  const requestId = "cccccccc-cccc-4ccc-8ccc-cccccccccccc";
  const request = runWithRequestContext(requestId, () => firebaseHttpV1RequestFor(
    { token: "device-token", data: { id: "90" } },
    {
      enabled: true,
      projectId: "warfriends-offline",
      requestTimeoutMilliseconds: 5_000,
    },
  ));
  assert.deepEqual(request, {
    method: "POST",
    url: "https://fcm.googleapis.com/v1/projects/warfriends-offline/messages:send",
    timeout: 5_000,
    headers: { "X-Request-ID": requestId },
    data: {
      message: {
        token: "device-token",
        data: { id: "90" },
        android: { priority: "HIGH" },
      },
    },
  });
  assert.equal("notification" in request.data.message, false);
});

function providerError(status: string, code: number, detailType?: string, errorCode?: string) {
  return {
    response: {
      status: code,
      data: {
        error: {
          code,
          status,
          details: detailType ? [{ "@type": detailType, errorCode }] : [],
        },
      },
    },
  };
}

test("Firebase failures retire only provider-proven invalid tokens", () => {
  const fcmDetail = "type.googleapis.com/google.firebase.fcm.v1.FcmError";
  assert.equal(firebaseFailureDisposition(
    providerError("UNREGISTERED", 404, fcmDetail, "UNREGISTERED"),
  ), "invalidToken");
  assert.equal(firebaseFailureDisposition(
    providerError("INVALID_ARGUMENT", 400, fcmDetail, "INVALID_ARGUMENT"),
  ), "invalidToken");

  // A generic invalid payload response is a server/configuration defect, not proof that the
  // player's opaque token is dead. It must never trigger token retirement.
  assert.equal(firebaseFailureDisposition(providerError(
    "INVALID_ARGUMENT",
    400,
    "type.googleapis.com/google.rpc.BadRequest",
  )), "configuration");
  assert.equal(firebaseFailureDisposition(
    providerError("SENDER_ID_MISMATCH", 403, fcmDetail, "SENDER_ID_MISMATCH"),
  ), "configuration");
});

test("Firebase quota, service, and transport failures remain retryable", () => {
  assert.equal(firebaseFailureDisposition(providerError("QUOTA_EXCEEDED", 429)), "transient");
  assert.equal(firebaseFailureDisposition(providerError("UNAVAILABLE", 503)), "transient");
  assert.equal(firebaseFailureDisposition(providerError("INTERNAL", 500)), "transient");
  assert.equal(firebaseFailureDisposition(new Error("socket closed")), "transient");
});

test("invalid-token retirement compare-and-sets both mirrors before clearing either", () => {
  const now = new Date("2026-07-22T00:00:00.000Z");
  assert.deepEqual(invalidFirebaseTokenRetirement("player", "old-token", now), {
    filter: {
      id: "player",
      deviceToken: "old-token",
      "player.deviceToken": "old-token",
    },
    update: {
      $set: {
        deviceToken: "",
        "player.deviceToken": "",
        updatedAt: now,
      },
    },
  });
});
