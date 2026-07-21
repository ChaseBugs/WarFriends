import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import {
  handlerlessActionDispositions,
  registeredHandlerActions,
} from "../handlers";

test("every recovered DbAction has one explicit backend disposition", () => {
  const recovered = Object.values(DbAction).filter((value): value is number => typeof value === "number");
  const classifications = [
    registeredHandlerActions,
    ...Object.values(handlerlessActionDispositions),
  ];
  const counts = new Map<number, number>();
  for (const group of classifications) {
    for (const action of group) counts.set(action, (counts.get(action) ?? 0) + 1);
  }

  const missing = recovered.filter((action) => !counts.has(action));
  const duplicated = recovered.filter((action) => counts.get(action) !== 1);
  assert.deepEqual(missing, [], `Unclassified DbActions: ${missing.join(", ")}`);
  assert.deepEqual(duplicated, [], `Multiply classified DbActions: ${duplicated.join(", ")}`);
});
