import assert from "node:assert/strict";
import test from "node:test";
import {
  applyRelayedCardPlay,
  deliveredRelayedCards,
  validatedRelayedCardSequence,
  validateRelayedCardReport,
} from "../services/matchService";

test("CardPlayed sequence requires the exact bounded JSON-number transport", () => {
  assert.equal(validatedRelayedCardSequence(0), 0);
  assert.equal(validatedRelayedCardSequence(5), 5);
  for (const value of [undefined, null, false, true, [], [0], "", "0", NaN, Infinity, -1, 0.5, 6]) {
    assert.throws(() => validatedRelayedCardSequence(value), /CardPlayed sequence is invalid/);
    assert.throws(() => applyRelayedCardPlay([], value, "AMMOCRATE"), /CardPlayed sequence is invalid/);
  }
});

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

test("only the contiguous delivered CardPlayed prefix can authorize inventory consumption", () => {
  const recorded = ["AMMOCRATE", "AIRSTRIKE", "SABOTAGE"];
  assert.deepEqual(deliveredRelayedCards(recorded, []), []);
  assert.deepEqual(deliveredRelayedCards(recorded, [0]), ["AMMOCRATE"]);
  assert.deepEqual(deliveredRelayedCards(recorded, [0, 1]), ["AMMOCRATE", "AIRSTRIKE"]);
  assert.deepEqual(deliveredRelayedCards(recorded, [0, 1, 2]), recorded);
  for (const corrupt of [[1], [0, 2], [0, 1, 1], [0, 1, 2, 3]]) {
    assert.throws(
      () => deliveredRelayedCards(recorded, corrupt),
      /delivery evidence is not a contiguous prefix/,
    );
  }
});
