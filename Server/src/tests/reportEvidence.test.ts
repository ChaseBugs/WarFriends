import assert from "node:assert/strict";
import test from "node:test";
import type { MatchDoc } from "../services/matchService";
import { buildAuthoritativeMatchEvidence } from "../services/reportService";

const CREATED_AT = new Date("2026-07-20T12:00:00.000Z");
const ENDED_AT = new Date("2026-07-20T12:04:00.000Z");

function match(values: Partial<MatchDoc> = {}): MatchDoc {
  return {
    matchId: "match-1",
    players: [
      { playerId: "reporter", name: "Reporter", armyPower: 1200, leagueTier: 3 },
      { playerId: "target", name: "Target", armyPower: 1350, leagueTier: 4 },
    ],
    state: "finished",
    winnerId: "target",
    resultReports: { reporter: "target", target: "target" },
    relayedCardPlays: { reporter: ["CARD_A"], target: ["CARD_B"] },
    usedCardsReports: { reporter: ["CARD_A"], target: ["CARD_B"] },
    createdAt: CREATED_AT,
    endedAt: ENDED_AT,
    ...values,
  };
}

test("report evidence binds exact participants and server match snapshots", () => {
  const evidence = buildAuthoritativeMatchEvidence(match(), "reporter", "target");
  assert.ok(evidence);
  assert.equal(evidence.source, "ranked-match");
  assert.equal(evidence.matchId, "match-1");
  assert.equal(evidence.state, "finished");
  assert.equal(evidence.winnerId, "target");
  assert.deepEqual(evidence.reporter, {
    playerId: "reporter",
    name: "Reporter",
    armyPower: 1200,
    leagueTier: 3,
  });
  assert.equal(evidence.resultClaims.reporter, "target");
  assert.deepEqual(evidence.relayedCardPlays.target, ["CARD_B"]);
  assert.equal(evidence.combatValidated, false);
});

test("report evidence rejects self, stranger, and malformed participant correlations", () => {
  assert.equal(buildAuthoritativeMatchEvidence(match(), "reporter", "reporter"), null);
  assert.equal(buildAuthoritativeMatchEvidence(match(), "reporter", "stranger"), null);
  assert.equal(
    buildAuthoritativeMatchEvidence(match({
      players: [
        { playerId: "reporter", name: "Reporter", armyPower: 1200, leagueTier: 3 },
        { playerId: "target", name: "Target", armyPower: 1350, leagueTier: 4 },
        { playerId: "third", name: "Third", armyPower: 900, leagueTier: 2 },
      ],
    }), "reporter", "target"),
    null,
  );
});

test("report evidence labels claims and bounds legacy card arrays", () => {
  const oversized = Array.from({ length: 30 }, (_, index) => `CARD_${index}`);
  const evidence = buildAuthoritativeMatchEvidence(match({
    resultReports: { reporter: "x".repeat(129), target: "reporter" },
    relayedCardPlays: { reporter: oversized, target: ["CARD_B", 17 as unknown as string] },
    usedCardsReports: { reporter: oversized },
  }), "reporter", "target");
  assert.ok(evidence);
  assert.equal(evidence.resultClaims.reporter, undefined);
  assert.equal(evidence.resultClaims.target, "reporter");
  assert.equal(evidence.relayedCardPlays.reporter.length, 16);
  assert.deepEqual(evidence.relayedCardPlays.target, ["CARD_B"]);
  assert.equal(evidence.usedCardClaims.reporter.length, 16);
  assert.deepEqual(evidence.usedCardClaims.target, []);
});
