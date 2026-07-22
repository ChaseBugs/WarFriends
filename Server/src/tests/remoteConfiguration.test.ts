import assert from "node:assert/strict";
import test from "node:test";
import type { RequestEnvelope } from "../dtos";
import {
  buildRemoteConfigurationResponse,
  remoteConfigurationSignature,
  selectRemoteConfiguration,
  validateRemoteConfigurationManifest,
} from "../services/remoteConfigurationService";

const secret = "remote-configuration-test-secret-with-at-least-32-characters";

function signedManifest() {
  const value = {
    schemaVersion: 1,
    releaseId: "release-2026-07-21",
    publications: [{
      sheetConfiguration: "balance-v2",
      variant: "economy-a",
      languages: ["en", "ko"],
      minimumClientVersion: 490,
      maximumClientVersion: 500,
      rolloutPercent: 100,
      rolloutSalt: "balance-v2-rollout",
      sheets: [{
        id: "Constants",
        version: "42",
        columns: ["DBKEY", "STRINGVALUE"],
        rowIds: ["DogTagCap", "Notice"],
        rows: [["DogTagCap", "5"], ["Notice", "safe;message"]],
      }],
    }],
    signature: "",
  };
  value.signature = remoteConfigurationSignature(value, secret);
  return validateRemoteConfigurationManifest(value, secret);
}

test("signed remote publication emits the exact stock semicolon and DynamoDB-shaped sheet wire", () => {
  const manifest = signedManifest();
  const response = buildRemoteConfigurationResponse({
    DbAction: 157,
    PlayerId: "player-1",
    SheetConfiguraton: "old",
    abTestVariant: "economy-a",
    Language: "en",
    ClientVersion: 495,
  }, manifest);
  const segments = response.split(";");
  assert.equal(segments.length, 4);
  assert.equal(segments[0], "success");
  assert.equal(segments[1], "balance-v2");
  assert.deepEqual(JSON.parse(segments[2]!), { Constants: { N: "42" } });
  const sheet = JSON.parse(segments[3]!);
  assert.deepEqual(sheet.Id, { S: "Client_Constants" });
  assert.deepEqual(sheet.ColumnNames, { S: "DBKEY/STRINGVALUE" });
  assert.deepEqual(sheet.RowIDs.L, [{ S: "DogTagCap" }, { S: "Notice" }]);
  assert.equal(sheet.Data.L[1].S, "Notice/safe;message");
});

test("current, untargeted, and pre-auth rollout clients retain bundled sheets", () => {
  const manifest = signedManifest();
  const targeted = {
    DbAction: 157,
    PlayerId: "player-1",
    abTestVariant: "economy-a",
    Language: "ko",
    ClientVersion: 495,
  };
  assert.equal(
    buildRemoteConfigurationResponse({ ...targeted, SheetConfiguraton: "balance-v2" }, manifest),
    "success;balance-v2;{}",
  );
  assert.equal(selectRemoteConfiguration({ ...targeted, Language: "fr" }, manifest), null);
  assert.equal(selectRemoteConfiguration({ ...targeted, ClientVersion: 501 }, manifest), null);

  const rolloutManifest = {
    ...manifest,
    publications: [{ ...manifest.publications[0]!, rolloutPercent: 50 }],
  };
  assert.equal(selectRemoteConfiguration({
    DbAction: 157,
    abTestVariant: "economy-a",
    Language: "en",
    ClientVersion: 495,
  }, rolloutManifest), null);
});

test("remote targeting rejects malformed selectors instead of widening them to wildcards", () => {
  const manifest = {
    ...signedManifest(),
    publications: [{
      ...signedManifest().publications[0]!,
      variant: "*",
      languages: ["*"],
      minimumClientVersion: undefined,
      maximumClientVersion: undefined,
    }],
  };
  assert.equal(selectRemoteConfiguration({
    DbAction: 157,
    SheetConfiguraton: "old",
    abTestVariant: "",
    Language: "EN",
  }, manifest), manifest.publications[0]);

  for (const fields of [
    { Language: "en" },
    { abTestVariant: "economy-a" },
    { abTestVariant: 1, Language: "en" },
    { abTestVariant: " economy-a", Language: "en" },
    { abTestVariant: "economy-a", Language: " en" },
    { abTestVariant: "economy-a", Language: "en\n" },
  ]) {
    assert.equal(selectRemoteConfiguration({ DbAction: 157, ...fields }, manifest), null);
  }
});

test("remote sheet cache identity remains exact across canonical and replacement aliases", () => {
  assert.equal(buildRemoteConfigurationResponse({
    DbAction: 157,
    SheetConfiguraton: "release-1",
    SheetConfiguration: "release-1",
    abTestVariant: "",
    Language: "en",
  }, null), "success;release-1;{}");
  for (const fields of [
    {},
    { SheetConfiguraton: 1 },
    { SheetConfiguraton: " release-1" },
    { SheetConfiguraton: "release-1 " },
    { SheetConfiguraton: "release;1" },
    { SheetConfiguraton: "release-1", SheetConfig: "release-2" },
  ]) {
    assert.equal(buildRemoteConfigurationResponse({
      DbAction: 157,
      abTestVariant: "",
      Language: "en",
      ...fields,
    } as unknown as RequestEnvelope, signedManifest()), "success;0;{}");
  }
});

test("remote publication targeting requires one canonical numeric replacement-client version", () => {
  const manifest = signedManifest();
  const targeted = {
    DbAction: 157,
    PlayerId: "player-1",
    abTestVariant: "economy-a",
    Language: "en",
  };
  assert.equal(selectRemoteConfiguration({ ...targeted, ClientVersion: "495" }, manifest), manifest.publications[0]);

  // Stock 1.6.0 supplies dotted Version automatically. It is deliberately not interpreted as
  // integer build 160/1 because the manifest declares an unrelated numeric adapter contract.
  assert.equal(selectRemoteConfiguration({ ...targeted, Version: "1.6.0" }, manifest), null);
  for (const ClientVersion of [null, false, "", "0495", "495.0", "1.6.0", [], Number.NaN]) {
    assert.equal(selectRemoteConfiguration({
      ...targeted,
      ClientVersion: ClientVersion as unknown as string | number,
    }, manifest), null);
  }
  assert.equal(selectRemoteConfiguration({
    ...targeted,
    ClientVersion: 495,
    clientVersion: 496,
  }, manifest), null);

  const unbounded = {
    ...manifest,
    publications: [{
      ...manifest.publications[0]!,
      minimumClientVersion: undefined,
      maximumClientVersion: undefined,
    }],
  };
  assert.equal(selectRemoteConfiguration({ ...targeted, Version: "1.6.0" }, unbounded), unbounded.publications[0]);
  assert.equal(selectRemoteConfiguration({
    ...targeted,
    ClientVersion: false as unknown as string,
  }, unbounded), null);
});

test("remote manifest rejects tampering and row delimiters that would corrupt the stock parser", () => {
  const manifest = signedManifest();
  assert.throws(
    () => validateRemoteConfigurationManifest({ ...manifest, releaseId: "tampered" }, secret),
    /signature is invalid/,
  );
  const invalid = JSON.parse(JSON.stringify(manifest));
  invalid.publications[0].sheets[0].rows[0][1] = "bad/value";
  invalid.signature = remoteConfigurationSignature(invalid, secret);
  assert.throws(() => validateRemoteConfigurationManifest(invalid, secret), /wire-safe/);
});

test("remote manifest rejects ignored fields and JavaScript-coercible rollout authority", () => {
  const mutateAndValidate = (
    mutate: (value: Record<string, any>) => void,
    expected: RegExp,
  ): void => {
    const invalid = JSON.parse(JSON.stringify(signedManifest())) as Record<string, any>;
    mutate(invalid);
    invalid.signature = remoteConfigurationSignature(invalid, secret);
    assert.throws(() => validateRemoteConfigurationManifest(invalid, secret), expected);
  };

  mutateAndValidate((value) => { value.release = "typo"; }, /schema is invalid/);
  mutateAndValidate((value) => { value.publications[0].rollout = 50; }, /publications\[0\] is invalid/);
  mutateAndValidate((value) => { value.publications[0].sheets[0].column = []; }, /sheet 0 is invalid/);
  for (const rolloutPercent of [null, false, "50", [], {}]) {
    mutateAndValidate((value) => { value.publications[0].rolloutPercent = rolloutPercent; }, /rolloutPercent is invalid/);
  }
  mutateAndValidate(
    (value) => { value.publications[0].maximumClientVersion = Number.MAX_SAFE_INTEGER; },
    /signed-client integer/,
  );
  mutateAndValidate(
    (value) => { value.publications[0].languages = ["en", "EN"]; },
    /languages contains duplicates/,
  );
});
