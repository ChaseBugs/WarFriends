import assert from "node:assert/strict";
import test from "node:test";
import { parseChallengeMessageRequest } from "../handlers/socialRequestParsing";
import { sameChallenge, type ChallengeMessageInput, type MessageDoc } from "../services/socialService";
import {
  requestedFacebookFriendCount,
  requestedInboxPageLimit,
} from "../services/socialRequestCountService";

const NOW = new Date("2026-07-22T00:00:00.000Z");

function request(values: Record<string, unknown> = {}): Record<string, unknown> {
  return {
    ChallengedPlayerId: "recipient",
    MapName: "Aztec_Multiplayer",
    GameType: "2",
    Region: "3",
    roomName: "challenge-room",
    clientVersion: "1.6.0",
    ...values,
  };
}

function challenge(input: ChallengeMessageInput): MessageDoc {
  return {
    messageId: `challenger-${Math.floor(NOW.getTime() / 1_000)}`,
    toPlayerId: input.challengedPlayerId,
    fromPlayerId: "challenger",
    fromName: "Challenger",
    body: "",
    messageType: 0,
    payload: {
      MapName: input.mapName,
      GameType: input.gameType,
      Region: input.region,
      roomName: input.roomName,
      clientVersion: input.clientVersion,
      ...(input.missionType !== undefined ? { MissionType: input.missionType } : {}),
      ...(input.numberOfMission !== undefined ? { NumberOfMission: input.numberOfMission } : {}),
      ...(input.missionData !== undefined ? { MissionData: input.missionData } : {}),
    },
    otherPlayerJson: "{}",
    read: false,
    ignored: false,
    accepted: false,
    createdAt: NOW,
    expiresAt: new Date(NOW.getTime() + 60_000),
  };
}

test("action 2 challenge parsing preserves the exact recovered form contract", () => {
  const parsed = parseChallengeMessageRequest(request({
    MissionType: "Campaign",
    NumberOfMission: "7",
    MissionData: "{\"difficulty\":2}",
  }));
  assert.deepEqual(parsed, {
    challengedPlayerId: "recipient",
    mapName: "Aztec_Multiplayer",
    gameType: 2,
    region: 3,
    roomName: "challenge-room",
    clientVersion: "1.6.0",
    missionType: "Campaign",
    numberOfMission: 7,
    missionData: "{\"difficulty\":2}",
  });
});

test("challenge parsing rejects broad JavaScript coercion and malformed defaults", () => {
  for (const field of ["ChallengedPlayerId", "MapName", "GameType", "Region", "roomName", "clientVersion"]) {
    assert.throws(() => parseChallengeMessageRequest(request({ [field]: undefined })), /is invalid/);
  }
  for (const value of [null, true, false, [], ["2"], {}, "", " 2", "02", "2.0", "2e0"]) {
    assert.throws(() => parseChallengeMessageRequest(request({ GameType: value })), /GameType is invalid/);
  }
  for (const value of [null, true, [], ["3"], "", "-1", "1.5", "1000001"]) {
    assert.throws(
      () => parseChallengeMessageRequest(request({ NumberOfMission: value })),
      /NumberOfMission is invalid/,
    );
  }
  assert.throws(() => parseChallengeMessageRequest(request({ Region: "11" })), /Region is invalid/);
  assert.throws(() => parseChallengeMessageRequest(request({ MissionType: "" })), /MissionType is invalid/);
});

test("challenge retry reuses only an identical payload, not merely the same room", () => {
  const input = parseChallengeMessageRequest(request());
  const stored = challenge(input);
  assert.equal(sameChallenge(stored, "challenger", input), true);
  assert.equal(sameChallenge(stored, "challenger", { ...input, mapName: "Desert_Multiplayer" }), false);
  assert.equal(sameChallenge(stored, "challenger", { ...input, region: 4 }), false);
  assert.equal(sameChallenge(stored, "challenger", { ...input, numberOfMission: 2 }), false);
  assert.equal(sameChallenge(stored, "other-challenger", input), false);
});

test("social read counts honor recovered fields and retain bounded replacement defaults", () => {
  assert.equal(requestedInboxPageLimit({ MessagesCount: "137" }), 100);
  assert.equal(requestedInboxPageLimit({ MessagesCount: 20 }), 20);
  assert.equal(requestedInboxPageLimit({ Limit: "25" }), 25);
  assert.equal(requestedInboxPageLimit({}), 50);
  assert.equal(requestedFacebookFriendCount("0"), 0);
  assert.equal(requestedFacebookFriendCount("501"), 500);
});

test("social read counts reject JavaScript coercion and non-C# forms", () => {
  for (const value of [
    null, true, false, [], ["2"], {}, "", " 2", "2 ", "02", "+2", "-1", "2.0", "2e0",
    -1, 2.5, 2_147_483_648, Number.NaN, Number.POSITIVE_INFINITY,
  ]) {
    assert.throws(() => requestedInboxPageLimit({ MessagesCount: value }));
    assert.throws(() => requestedFacebookFriendCount(value));
  }
  assert.throws(() => requestedInboxPageLimit({ MessagesCount: "0" }));
  assert.throws(() => requestedFacebookFriendCount(undefined));
});
