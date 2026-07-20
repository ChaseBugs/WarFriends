import assert from "node:assert/strict";
import test from "node:test";
import {
  applyRelayedCardPlay,
  validateRelayedCardReport,
} from "../services/matchService";

test("sequenced CardPlayed evidence is contiguous, bounded, and replay-idempotent", () => {
  const first = applyRelayedCardPlay([], 0, "AMMOCRATE");
  assert.deepEqual(first, { cards: ["AMMOCRATE"], replayed: false });

  const replay = applyRelayedCardPlay(first.cards, 0, "AMMOCRATE");
  assert.deepEqual(replay, { cards: ["AMMOCRATE"], replayed: true });
  assert.throws(() => applyRelayedCardPlay(first.cards, 0, "AIRSTRIKE"));
  assert.throws(() => applyRelayedCardPlay(first.cards, 2, "AIRSTRIKE"));

  let cards: string[] = [];
  for (let sequence = 0; sequence < 6; sequence += 1) {
    cards = applyRelayedCardPlay(cards, sequence, `card-${sequence}`).cards;
  }
  assert.equal(cards.length, 6);
  assert.throws(() => applyRelayedCardPlay(cards, 6, "card-6"));
});

test("terminal UsedCards must exactly reproduce durable CardPlayed order and multiplicity", () => {
  const evidence = ["AMMOCRATE", "AMMOCRATE", "AIRSTRIKE"];
  assert.deepEqual(validateRelayedCardReport(evidence, [...evidence]), evidence);
  assert.throws(() => validateRelayedCardReport(evidence, ["AMMOCRATE", "AIRSTRIKE"]));
  assert.throws(() => validateRelayedCardReport(evidence, ["AIRSTRIKE", "AMMOCRATE", "AMMOCRATE"]));
  assert.throws(() => validateRelayedCardReport(evidence, [...evidence, "SABOTAGE"]));
});
