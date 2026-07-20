import assert from "node:assert/strict";
import test from "node:test";
import { applyConfirmedPvpProgressionState } from "../services/matchService";
import { createInitialProgression } from "../services/playerStateService";

const NOW = Date.parse("2026-07-21T12:00:00Z") / 1_000;

test("confirmed PvP progression advances assignments and authoritative achievements together", () => {
  const result = applyConfirmedPvpProgressionState(
    createInitialProgression(NOW),
    NOW,
    true,
    15,
  );

  const assignments = result.assignments!.assignments;
  assert.equal(assignments.find((entry) => entry.id === 5)?.completeFract, 0.5);
  assert.equal(assignments.find((entry) => entry.id === 8)?.completeFract, 1 / 6);
  assert.equal(assignments.find((entry) => entry.id === 7)?.completeFract, 1 / 3);
  assert.equal(result.achievements?.data.find((group) => group.id === 2)?.value, 1);
  assert.equal(result.achievements?.data.find((group) => group.id === 14)?.value, 15);
});

test("a confirmed loss advances play assignments without inventing win or squad progress", () => {
  const result = applyConfirmedPvpProgressionState(
    createInitialProgression(NOW),
    NOW,
    false,
    0,
  );

  const assignments = result.assignments!.assignments;
  assert.equal(assignments.find((entry) => entry.id === 5)?.completeFract, 0.5);
  assert.equal(assignments.find((entry) => entry.id === 8)?.completeFract, 1 / 6);
  assert.equal(assignments.find((entry) => entry.id === 7)?.completeFract, 0);
  assert.equal(result.achievements?.data.find((group) => group.id === 2)?.value, 0);
  assert.equal(result.achievements?.data.find((group) => group.id === 14)?.value, 0);
});

test("confirmed PvP progression rejects malformed settlement authority", () => {
  const initial = createInitialProgression(NOW);
  assert.throws(
    () => applyConfirmedPvpProgressionState(initial, -1, true, 1),
    /settlement time is invalid/,
  );
  assert.throws(
    () => applyConfirmedPvpProgressionState(initial, NOW, true, -1),
    /squad-point achievement amount is invalid/,
  );
});
