import assert from "node:assert/strict";
import test from "node:test";
import { exactPurchaseDiscount } from "../handlers/purchaseRequestParsing";

test("VIP and lootbox discounts preserve the recovered canonical decimal contract", () => {
  assert.equal(exactPurchaseDiscount("0"), 0);
  assert.equal(exactPurchaseDiscount("25"), 25);
  assert.equal(exactPurchaseDiscount(99), 99);
});

test("malformed discounts cannot coerce into an authorized zero-value purchase", () => {
  for (const value of [undefined, null, true, false, [], ["0"], {}, "", " 0", "00", "0.0", "0e0", -1, 100]) {
    assert.throws(() => exactPurchaseDiscount(value), /exact integer from 0 to 99/);
  }
});
