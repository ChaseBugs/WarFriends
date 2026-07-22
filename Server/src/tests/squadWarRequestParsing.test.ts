import assert from "node:assert/strict";
import test from "node:test";
import { requestedSquadWarRoundId } from "../handlers/squadWarRequestParsing";

test("Squad Wars division reads only the exact recovered RoundId field", () => {
  assert.equal(requestedSquadWarRoundId({ RoundId: "4-swseason:division_2" }), "4-swseason:division_2");
  assert.equal(requestedSquadWarRoundId({
    RoundId: "8-archived.round",
    roundId: "diagnostic-alias-is-not-authority",
  }), "8-archived.round");

  for (const request of [
    {},
    { roundId: "4-round" },
    { RoundId: 4 },
    { RoundId: null },
    { RoundId: true },
    { RoundId: "" },
    { RoundId: " 4-round" },
    { RoundId: "4-round " },
    { RoundId: "4 round" },
    { RoundId: "4/round" },
    { RoundId: "4-round\n" },
    { RoundId: "x".repeat(129) },
  ]) {
    assert.throws(() => requestedSquadWarRoundId(request), /RoundId is invalid/);
  }
});
