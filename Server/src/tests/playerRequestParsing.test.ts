import assert from "node:assert/strict";
import test from "node:test";
import { PlayerStatus } from "../constants";
import { exactPlayerStatus, exactRenamePaymentFlag } from "../handlers/playerRequestParsing";

test("presence and rename flags preserve recovered canonical integer forms", () => {
  assert.equal(exactPlayerStatus("0"), PlayerStatus.Offline);
  assert.equal(exactPlayerStatus(1), PlayerStatus.Online);
  assert.equal(exactPlayerStatus("2"), PlayerStatus.InGame);
  assert.equal(exactRenamePaymentFlag("0"), 0);
  assert.equal(exactRenamePaymentFlag(1), 1);
});

test("malformed profile scalars cannot coerce into presence or rename authority", () => {
  for (const value of [undefined, null, true, false, [], ["1"], {}, "", " 1", "01", "1.0", "1e0", -1, 3]) {
    assert.equal(exactPlayerStatus(value), undefined);
  }
  for (const value of [undefined, null, true, false, [], ["0"], {}, "", " 0", "00", "0.0", "0e0", -1, 2]) {
    assert.throws(() => exactRenamePaymentFlag(value), /exact 0 or 1 integer/);
  }
});
