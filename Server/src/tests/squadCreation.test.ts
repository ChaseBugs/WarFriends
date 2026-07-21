import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import {
  exactSquadInteger,
  requestedAcceptSquadJoinRequest,
  requestedDirectSquadChatTimestamp,
  requestedDeclineSquadJoinRequest,
  requestedGlobalSquadDirectory,
  requestedSquadInvitation,
  requestedSquadNamePrefix,
  requestedSquadJoinPolicy,
  requestedSuggestedSquadSkill,
} from "../handlers/squadAdmissionParsing";
import {
  SQUAD_CREATE_BASE_WARBUCKS_COST,
  SQUAD_CREATE_NOT_ENOUGH_WARBUCKS,
  applySquadCreationEconomyState,
  nextSquadUpdatedAt,
  squadSnapshotWriteFilter,
  squadCreationWarBucksPrice,
  validatedSquadJoinPolicy,
  validatedSquadRequiredMedals,
} from "../services/squadService";
import { createInitialProgression } from "../services/playerStateService";

const NOW = Date.UTC(2026, 6, 20, 12, 0, 0) / 1_000;

test("single-document squad writes bind the exact authorizing revision", () => {
  const updatedAt = new Date(NOW * 1_000);
  assert.deepEqual(
    squadSnapshotWriteFilter({ name: "Exact Revision", updatedAt }),
    { name: "Exact Revision", updatedAt },
  );
  assert.equal(
    nextSquadUpdatedAt({ name: "Exact Revision", updatedAt }, new Date(updatedAt)).getTime(),
    updatedAt.getTime() + 1,
  );
  assert.equal(
    nextSquadUpdatedAt({ name: "Exact Revision", updatedAt }, new Date(updatedAt.getTime() + 50)).getTime(),
    updatedAt.getTime() + 50,
  );
  assert.throws(
    () => squadSnapshotWriteFilter({ name: "Damaged", updatedAt: new Date(Number.NaN) }),
    /invalid revision/,
  );
  assert.throws(
    () => nextSquadUpdatedAt({ name: "Exact Revision", updatedAt }, new Date(Number.NaN)),
    /clock is invalid/,
  );
});

test("squad admission settings reject coercion and preserve exact recovered integers", () => {
  assert.equal(exactSquadInteger("2", "JoinPolicy"), 2);
  assert.equal(exactSquadInteger("-2147483648", "RequiredMedals"), -2_147_483_648);
  assert.equal(exactSquadInteger(2_147_483_647, "RequiredMedals"), 2_147_483_647);
  assert.equal(exactSquadInteger(undefined, "RequiredMedals", 0), 0);
  assert.equal(requestedSquadJoinPolicy({ JoinPolicy: "2" }), 2);
  assert.equal(requestedSquadJoinPolicy({ IsPublic: "1" }), 0);
  assert.equal(requestedSquadJoinPolicy({ IsPublic: false }), 1);
  assert.equal(validatedSquadJoinPolicy(undefined, 0), 0);
  assert.equal(validatedSquadJoinPolicy(2), 2);
  assert.equal(validatedSquadRequiredMedals(undefined, 0), 0);
  assert.equal(validatedSquadRequiredMedals(2_147_483_647), 2_147_483_647);

  for (const value of [-1, 3, 1.5, Number.NaN, Number.POSITIVE_INFINITY]) {
    assert.throws(() => validatedSquadJoinPolicy(value), /Squad join policy is invalid/);
  }
  for (const value of [-1, 1.5, 2_147_483_648, Number.NaN, Number.POSITIVE_INFINITY]) {
    assert.throws(() => validatedSquadRequiredMedals(value), /Squad medal requirement is invalid/);
  }
  for (const value of [
    null, true, [], {}, "", " 2 ", "02", "-0", "+2", "1.5", "1e0", -2_147_483_649,
    2_147_483_648,
  ]) {
    assert.throws(() => exactSquadInteger(value, "RequiredMedals"), /must be an exact integer/);
  }
  for (const value of [null, "", "yes", "true", "false", " true ", "TRUE", 0, 1, 2, {}, []]) {
    assert.throws(() => requestedSquadJoinPolicy({ IsPublic: value }), /exact stock 0\/1 flag/);
  }
});

test("Squad directory request fields preserve recovered prefix, scope, and Skill assertions", () => {
  assert.equal(requestedSquadNamePrefix({ SquadNameStart: "  Alpha   Sq " }), "Alpha Sq");
  assert.equal(requestedGlobalSquadDirectory({}), false);
  assert.equal(requestedGlobalSquadDirectory({ IsGlobal: "1" }), true);
  assert.equal(requestedGlobalSquadDirectory({ IsGlobal: false }), false);
  assert.equal(requestedSuggestedSquadSkill("123"), 123);

  for (const value of [undefined, null, {}, "ab", "a".repeat(25), "bad\nname"]) {
    assert.throws(() => requestedSquadNamePrefix({ SquadNameStart: value }), /SquadNameStart is invalid/);
  }
  for (const value of [1, "true", "01", null]) {
    assert.throws(() => requestedGlobalSquadDirectory({ IsGlobal: value }), /exact stock 0\/1 flag/);
  }
  for (const value of [-1, "-1", 1.5, "1.0", true]) {
    assert.throws(() => requestedSuggestedSquadSkill(value), /Skill/);
  }
});

test("action 181 decodes applicant MessageId and squad Id without generic alias precedence", () => {
  assert.deepEqual(
    requestedDeclineSquadJoinRequest({ MessageId: "applicant-id", Id: "Alpha Squad" }),
    { playerId: "applicant-id", squadId: "Alpha Squad" },
  );
  for (const request of [
    {},
    { MessageId: "applicant-id" },
    { Id: "Alpha Squad" },
    { MessageId: " applicant-id", Id: "Alpha Squad" },
    { MessageId: "applicant-id", Id: " Alpha Squad" },
    { MessageId: "applicant\nid", Id: "Alpha Squad" },
    { MessageId: "applicant-id", Id: "ab" },
  ]) {
    assert.throws(
      () => requestedDeclineSquadJoinRequest(request),
      /decline fields are invalid/,
    );
  }
});

test("Squad invitation and approval parse only their recovered identity fields", () => {
  assert.equal(
    requestedSquadInvitation({ PlayerToInviteId: "invitee-id" }),
    "invitee-id",
  );
  assert.deepEqual(
    requestedAcceptSquadJoinRequest({ SquadId: "Alpha Squad", PlayerToJoin: "applicant-id" }),
    { playerId: "applicant-id", squadId: "Alpha Squad" },
  );

  for (const request of [
    {},
    { TargetPlayerId: "invitee-id" },
    { PlayerToInviteId: " invitee-id" },
    { PlayerToInviteId: "invitee\nid" },
    { PlayerToInviteId: [] },
  ]) {
    assert.throws(() => requestedSquadInvitation(request), /invitation player field is invalid/);
  }
  for (const request of [
    {},
    { SquadId: "Alpha Squad", TargetPlayerId: "applicant-id" },
    { SquadName: "Alpha Squad", PlayerToJoin: "applicant-id" },
    { SquadId: " Alpha Squad", PlayerToJoin: "applicant-id" },
    { SquadId: "Alpha Squad", PlayerToJoin: "applicant\nid" },
  ]) {
    assert.throws(
      () => requestedAcceptSquadJoinRequest(request),
      /Squad join-request approval.*field is invalid/,
    );
  }
});

test("direct squad-chat cursor accepts exactly one canonical C# integer alias", () => {
  assert.equal(requestedDirectSquadChatTimestamp({ LastSeenSquadChatTimeStamp: "0" }), 0);
  assert.equal(requestedDirectSquadChatTimestamp({ Timestamp: 2_147_483_647 }), 2_147_483_647);
  assert.equal(requestedDirectSquadChatTimestamp({ TimeStamp: "123" }), 123);

  for (const request of [
    {},
    { Timestamp: null },
    { Timestamp: false },
    { Timestamp: [] },
    { Timestamp: "" },
    { Timestamp: " 1" },
    { Timestamp: "+1" },
    { Timestamp: "01" },
    { Timestamp: "1.0" },
    { Timestamp: "1e0" },
    { Timestamp: 1.5 },
    { Timestamp: 2_147_483_648 },
    { Timestamp: "1", TimeStamp: "1" },
    { LastSeenSquadChatTimeStamp: "1", Timestamp: "2" },
  ]) {
    assert.throws(() => requestedDirectSquadChatTimestamp(request), /(field is invalid|exact integer)/);
  }
});

test("squad creation price reproduces the recovered linear WarBucks schedule", () => {
  assert.equal(SQUAD_CREATE_BASE_WARBUCKS_COST, 25);
  assert.equal(squadCreationWarBucksPrice(0), 25);
  assert.equal(squadCreationWarBucksPrice(1), 50);
  assert.equal(squadCreationWarBucksPrice(2), 75);
});

test("first squad creation debits WarBucks and advances count and revision once", () => {
  const initial = { ...createInitialProgression(NOW), warBucks: 100, revision: 4 };
  const result = applySquadCreationEconomyState(initial);

  assert.equal(result.warBucksSpent, 25);
  assert.equal(result.squadCreationsCount, 1);
  assert.equal(result.state.warBucks, 75);
  assert.equal(result.state.squadCreationsCount, 1);
  assert.equal(result.state.revision, 5);
  assert.equal(initial.warBucks, 100);
});

test("later squad creation uses the persisted creation count", () => {
  const initial = {
    ...createInitialProgression(NOW),
    warBucks: 100,
    squadCreationsCount: 1,
  };
  const result = applySquadCreationEconomyState(initial);

  assert.equal(result.warBucksSpent, 50);
  assert.equal(result.state.warBucks, 50);
  assert.equal(result.squadCreationsCount, 2);
});

test("insufficient WarBucks uses the exact stock create recovery error", () => {
  const initial = { ...createInitialProgression(NOW), warBucks: 24 };
  assert.throws(
    () => applySquadCreationEconomyState(initial),
    (error: unknown) => (error as { code?: number }).code === SQUAD_CREATE_NOT_ENOUGH_WARBUCKS,
  );
});

test("invalid creation counters cannot produce a free or overflowed price", () => {
  for (const count of [
    Number.NaN,
    Number.POSITIVE_INFINITY,
    -1,
    1.5,
    Math.floor(2_147_483_647 / SQUAD_CREATE_BASE_WARBUCKS_COST),
    Number.MAX_SAFE_INTEGER,
  ]) {
    assert.throws(
      () => squadCreationWarBucksPrice(count),
      (error: unknown) => (error as { code?: number }).code === ApiErrorCode.InternalServerError,
    );
  }
});

test("squad creation validates wallet and revision before publishing the next count", () => {
  for (const warBucks of [Number.NaN, Number.POSITIVE_INFINITY]) {
    assert.throws(
      () => applySquadCreationEconomyState({ ...createInitialProgression(NOW), warBucks }),
      /Squad creation WarBucks balance is invalid/,
    );
  }
  assert.throws(
    () => applySquadCreationEconomyState({
      ...createInitialProgression(NOW),
      warBucks: 100,
      revision: Number.MAX_SAFE_INTEGER,
    }),
    /Squad creation progression revision is invalid/,
  );
});
