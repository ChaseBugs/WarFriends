import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import {
  SQUAD_CREATE_BASE_WARBUCKS_COST,
  SQUAD_CREATE_NOT_ENOUGH_WARBUCKS,
  applySquadCreationEconomyState,
  squadCreationWarBucksPrice,
} from "../services/squadService";
import { createInitialProgression } from "../services/playerStateService";

const NOW = Date.UTC(2026, 6, 20, 12, 0, 0) / 1_000;

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
  assert.throws(
    () => squadCreationWarBucksPrice(-1),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
  );
  assert.throws(
    () => squadCreationWarBucksPrice(Number.MAX_SAFE_INTEGER),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
  );
});
