import assert from "node:assert/strict";
import test from "node:test";
import { PlayerStatus } from "../constants";
import {
  exactPlayerStatus,
  exactRenamePaymentFlag,
  requestedDeviceRegistration,
  requestedPlayerCountry,
  requestedPlayerStatus,
} from "../handlers/playerRequestParsing";

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

test("presence mutation requires the recovered PlayerStatus field and consistent duplicates", () => {
  assert.equal(requestedPlayerStatus({ PlayerStatus: "1" }), PlayerStatus.Online);
  assert.equal(requestedPlayerStatus({ PlayerStatus: "2", Status: 2 }), PlayerStatus.InGame);
  assert.equal(requestedPlayerStatus({ Status: "1" }), undefined);
  assert.equal(requestedPlayerStatus({ PlayerStatus: "1", Status: "2" }), undefined);
  assert.equal(requestedPlayerStatus({ PlayerStatus: "1", Status: true }), undefined);
});

test("device registration validates token and locale as one recovered request tuple", () => {
  assert.deepEqual(requestedDeviceRegistration({ DeviceToken: "fcm-token", Locale: "pt-BR" }), {
    deviceToken: "fcm-token",
    locale: "pt-BR",
  });
  assert.deepEqual(requestedDeviceRegistration({ DeviceToken: "", Locale: "en" }), {
    deviceToken: "",
    locale: "en",
  });
  assert.throws(() => requestedDeviceRegistration({ DeviceToken: "fcm-token" }), /required together/);
  assert.throws(() => requestedDeviceRegistration({ Locale: "en" }), /required together/);
  assert.throws(
    () => requestedDeviceRegistration({ DeviceToken: "fcm-token", Locale: true }),
    /Locale is required/,
  );
});

test("country mutation requires NewCountryCode and rejects conflicting diagnostic aliases", () => {
  assert.equal(requestedPlayerCountry({ NewCountryCode: "us" }), "US");
  assert.equal(requestedPlayerCountry({ NewCountryCode: " us ", Country: "US" }), "US");
  assert.throws(() => requestedPlayerCountry({ Country: "US" }), /Country code is required/);
  assert.throws(
    () => requestedPlayerCountry({ NewCountryCode: "US", Country: "CA" }),
    /Country fields conflict/,
  );
});
