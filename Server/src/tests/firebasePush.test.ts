import assert from "node:assert/strict";
import test from "node:test";
import { PlayerStatus } from "../constants";
import type { NotificationSettingsDTO } from "../dtos";
import {
  firebaseDataPushFor,
  firebaseHttpV1RequestFor,
  firebaseWakeActionFor,
} from "../services/firebasePushService";
import { exactFirebasePushPolicy } from "../services/firebasePushPolicyService";

const ALL_ENABLED: NotificationSettingsDTO = {
  challenge: true,
  squadStatus: true,
  squadEvents: true,
  maintenance: true,
  playerLeague: true,
  dailyRewardNotification: true,
};

test("Firebase wake actions preserve the two recovered client data IDs", () => {
  assert.deepEqual(firebaseWakeActionFor(0), { id: "2", consent: "challenge" });
  assert.deepEqual(firebaseWakeActionFor(3), { id: "90", consent: "squadStatus" });
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

test("Firebase HTTP v1 request contains only recovered data and transport scheduling", () => {
  const request = firebaseHttpV1RequestFor(
    { token: "device-token", data: { id: "90" } },
    {
      enabled: true,
      projectId: "warfriends-offline",
      requestTimeoutMilliseconds: 5_000,
    },
  );
  assert.deepEqual(request, {
    method: "POST",
    url: "https://fcm.googleapis.com/v1/projects/warfriends-offline/messages:send",
    timeout: 5_000,
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
