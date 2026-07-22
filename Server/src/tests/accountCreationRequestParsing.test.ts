import assert from "node:assert/strict";
import test from "node:test";
import {
  exactClientUtcOffsetHours,
  optionalAccountCreationContext,
  recoveredAccountCreationContext,
} from "../handlers/accountCreationRequestParsing";

test("recovered account creation requires locale and finite client UTC-offset hints", () => {
  assert.deepEqual(recoveredAccountCreationContext({
    Locale: "pt-BR",
    UtcOffset: "5.5",
    StartingGold: "999999999",
    StartingWarbucks: "999999999",
  }), {
    locale: "pt-BR",
    utcOffsetHours: 5.5,
    deviceToken: "",
  });
  assert.equal(exactClientUtcOffsetHours("-2.77777777777778E-07"), -2.77777777777778e-7);
  assert.equal(exactClientUtcOffsetHours(9), 9);
  assert.deepEqual(
    recoveredAccountCreationContext({ Locale: "en", UtcOffset: "10.00000001", DeviceToken: "fcm-token" }),
    { locale: "en", utcOffsetHours: 10.00000001, deviceToken: "fcm-token" },
  );
});

test("malformed account context cannot become locale, device, or time authority", () => {
  for (const value of [
    undefined, null, true, [], {}, "", " 9", "9 ", "+9", "09", ".5", "5.", "1e0",
    "NaN", "Infinity", 16, -16,
  ]) {
    assert.throws(() => exactClientUtcOffsetHours(value), /UtcOffset is invalid/);
  }
  assert.throws(() => recoveredAccountCreationContext({ UtcOffset: "9" }), /Locale is required/);
  assert.throws(
    () => recoveredAccountCreationContext({ Locale: "../../etc", UtcOffset: "9" }),
    /Invalid locale/,
  );
  assert.throws(
    () => recoveredAccountCreationContext({ Locale: "en", UtcOffset: "9", DeviceToken: 123 }),
    /Invalid device token/,
  );
});

test("source-unobserved full-account adapter retains explicit optional defaults", () => {
  assert.deepEqual(optionalAccountCreationContext({}), {
    locale: "en",
    utcOffsetHours: 0,
    deviceToken: "",
  });
  assert.deepEqual(optionalAccountCreationContext({ Locale: "ko-KR", UtcOffset: -3.5 }), {
    locale: "ko-KR",
    utcOffsetHours: -3.5,
    deviceToken: "",
  });
});
