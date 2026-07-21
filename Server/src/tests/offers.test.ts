import assert from "node:assert/strict";
import test from "node:test";
import { ApiError } from "../apiErrors";
import { DbAction } from "../dbActions";
import {
  offerHandlers,
  SPECIAL_OFFER_NOT_ACCEPTABLE,
  SPECIAL_OFFERS_UNAVAILABLE,
} from "../handlers/offers";

async function rejectedCode(action: DbAction): Promise<number> {
  const entry = offerHandlers[action];
  assert.ok(entry);
  assert.equal(entry.requiresAuth, true);
  try {
    await entry.handler({ req: { DbAction: action }, player: null });
  } catch (error) {
    assert.ok(error instanceof ApiError);
    return error.code;
  }
  assert.fail(`Action ${action} unexpectedly returned success.`);
}

test("retired special-offer routes fail with their exact recovered action errors", async () => {
  assert.equal(await rejectedCode(DbAction.GenerateSpecialOffer), SPECIAL_OFFERS_UNAVAILABLE);
  assert.equal(await rejectedCode(DbAction.AcceptSpecialOffer), SPECIAL_OFFER_NOT_ACCEPTABLE);
});

test("special-offer acceptance exposes an empty authoritative offer snapshot", async () => {
  const entry = offerHandlers[DbAction.AcceptSpecialOffer]!;
  await assert.rejects(
    async () => entry.handler({ req: { DbAction: DbAction.AcceptSpecialOffer }, player: null }),
    (error: unknown) => {
      assert.ok(error instanceof ApiError);
      assert.deepEqual(error.details, { SpecialOffers: {} });
      return true;
    },
  );
});
