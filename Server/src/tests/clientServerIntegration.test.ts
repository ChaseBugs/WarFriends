import assert from "node:assert/strict";
import { readFileSync } from "node:fs";
import { createServer, type Server } from "node:http";
import { resolve } from "node:path";
import test from "node:test";
import express from "express";
import { DbAction } from "../dbActions";
import { apiRouter } from "../routes";
import { CARD_PACK_NOT_FOUND, parseCardPackPurchaseData } from "../services/cardInventoryService";
import { parseRestorePackInputs, validateRefundPackNotice } from "../handlers/purchases";
import { parseRecoveredMultipartForm } from "../middleware/recoveredMultipartForm";

const CLIENT_ENDPOINT_SOURCE = resolve(
  process.cwd(),
  "../Client/ExportedProject/Assets/LegacyCompat/ServerEndpoint.cs",
);
const SERVER_ENV_EXAMPLE = resolve(process.cwd(), ".env.example");
const CLIENT_CARD_MANAGER_SOURCE = resolve(
  process.cwd(),
  "../Client/ExportedProject/Assets/Scripts/Gameplay/CardManager.cs",
);
const CLIENT_ANDROID_PURCHASE_SOURCE = resolve(
  process.cwd(),
  "../Client/ExportedProject/Assets/Scripts/Gameplay/PLIABAOLHBE.cs",
);

async function withRecoveredRouter(
  run: (baseUrl: string) => Promise<void>,
): Promise<void> {
  const app = express();

  // BestHTTP.AddField uses URL encoding for short values and automatically switches to multipart
  // when one value exceeds 256 characters. Mount both production parsers so this test detects a
  // body-parser or /api prefix regression.
  app.use(express.urlencoded({ extended: false, limit: "2mb" }));
  app.use(parseRecoveredMultipartForm);
  app.use("/api", apiRouter);

  const server = createServer(app);
  await new Promise<void>((accept, reject) => {
    server.once("error", reject);
    server.listen(0, "127.0.0.1", accept);
  });

  try {
    const address = server.address();
    assert.ok(address && typeof address === "object");
    await run(`http://127.0.0.1:${address.port}/api`);
  } finally {
    await closeServer(server);
  }
}

async function closeServer(server: Server): Promise<void> {
  await new Promise<void>((accept, reject) => {
    server.close((error) => error ? reject(error) : accept());
  });
}

test("editable Client endpoint matches the Server local port and recovered /api dispatcher", () => {
  const endpointSource = readFileSync(CLIENT_ENDPOINT_SOURCE, "utf8");
  const endpointMatch = endpointSource.match(/BaseUrl\s*=\s*"([^"]+)"/u);
  assert.ok(endpointMatch, "ServerEndpoint.cs must contain one inspectable BaseUrl constant");

  const endpoint = new URL(endpointMatch[1]);
  assert.equal(endpoint.protocol, "http:");
  assert.equal(endpoint.hostname, "127.0.0.1");
  assert.equal(endpoint.port, "8080");
  assert.equal(endpoint.pathname, "/api/");

  const examplePort = readFileSync(SERVER_ENV_EXAMPLE, "utf8").match(/^PORT=(\d+)$/mu)?.[1];
  assert.equal(examplePort, endpoint.port);
});

test("stock CheckIsOnline request receives the exact callback-enabling body", async () => {
  await withRecoveredRouter(async (baseUrl) => {
    const response = await fetch(`${baseUrl}/check.php`, { method: "POST" });
    assert.equal(response.status, 200);
    assert.match(response.headers.get("content-type") ?? "", /^text\/plain\b/u);
    assert.equal(await response.text(), "ok");
  });
});

test("stock GetConfigurations form reaches action 157 and preserves its raw parser contract", async () => {
  await withRecoveredRouter(async (baseUrl) => {
    const form = new URLSearchParams({
      SheetConfig: "0",
      requestId: "157",
      Version: "4.9.5.2",
      Os: "android",
      abTestVariant: "",
      SheetConfiguraton: "0",
      Language: "en",
    });
    const response = await fetch(`${baseUrl}/157/4-9-5`, {
      method: "POST",
      headers: { "Content-Type": "application/x-www-form-urlencoded" },
      body: form,
    });

    assert.equal(response.status, 200);
    assert.match(response.headers.get("content-type") ?? "", /^text\/plain\b/u);
    assert.equal(await response.text(), "success;0;{}");
  });
});

test("stock authenticated action without both session fields opens manual login instead of relogging", async () => {
  await withRecoveredRouter(async (baseUrl) => {
    const form = new URLSearchParams({
      SheetConfig: "0",
      requestId: String(DbAction.GetPlayerData),
      Version: "4.9.5.2",
      Os: "android",
    });
    const response = await fetch(`${baseUrl}/${DbAction.GetPlayerData}/4-9-5`, {
      method: "POST",
      headers: { "Content-Type": "application/x-www-form-urlencoded" },
      body: form,
    });

    assert.equal(response.status, 200);
    assert.deepEqual(await response.json(), {
      DbAction: DbAction.GetPlayerData,
      Result: 3_001,
      Code: 3_001,
      Message: "Missing credentials.",
    });
  });
});

test("stock long RequestBuffer multipart form preserves the transport ID and auth snapshot", async () => {
  await withRecoveredRouter(async (baseUrl) => {
    const bufferId = "01784723999";
    const requests = JSON.stringify(Object.fromEntries(
      Array.from({ length: 19 }, (_, index) => [index, {
        databaseAction: 104,
        objData: `weapon-impression-${index}`,
      }]),
    ));
    assert.ok(requests.length > 256, "fixture must select BestHTTP's multipart form implementation");

    const form = new FormData();
    form.set("SheetConfig", "0");
    form.set("requestId", "98");
    form.set("Version", "4.9.5.2");
    form.set("Os", "android");
    form.set("Token", "null");
    form.set("PlayerId", "null");
    form.set("BufferId", bufferId);
    form.set("Count", "19");
    form.set("Requests", requests);

    const response = await fetch(`${baseUrl}/98/4-9-5`, { method: "POST", body: form });
    assert.equal(response.status, 200);
    assert.deepEqual(await response.json(), {
      DbAction: 98,
      Result: 1,
      BufferId: bufferId,
      RequestsResults: "[]",
      DiscardedPreAccountBuffer: true,
    });
  });
});

test("Server accepts only the two card-pack payload shapes emitted by the untouched Client", () => {
  const source = readFileSync(CLIENT_CARD_MANAGER_SOURCE, "utf8");
  const threeStart = source.indexOf("public Card[] BuyThreeCards(int warbucks)");
  const threeEnd = source.indexOf("internal int[] GetRarityCounts()", threeStart);
  const shopStart = source.indexOf("internal Card[] BuyCardPack(");
  const shopEnd = source.indexOf("public void CardPackBoughtEvent()", shopStart);
  assert.ok(threeStart >= 0 && threeEnd > threeStart, "BuyThreeCards source method was not found");
  assert.ok(shopStart >= 0 && shopEnd > shopStart, "BuyCardPack source method was not found");

  const threeSource = source.slice(threeStart, threeEnd);
  const shopSource = source.slice(shopStart, shopEnd);
  assert.match(threeSource, /dictionary\["cards"\]\s*=\s*array2;/u);
  assert.match(threeSource, /dictionary\["cardPack"\]/u);
  assert.doesNotMatch(threeSource, /dictionary\["discount"\]|dictionary\["StartTime"\]/u);
  assert.match(shopSource, /dictionary\["cards"\]\s*=\s*array;/u);
  assert.match(shopSource, /dictionary\["cardPack"\]\s*=\s*nAME;/u);
  assert.match(shopSource, /dictionary\["discount"\]\s*=\s*discount;/u);
  assert.match(shopSource, /dictionary\["StartTime"\]/u);

  assert.deepEqual(parseCardPackPurchaseData(JSON.stringify({
    cards: ["AMMOCRATE", "FREEZE", "AIRSTRIKE"],
    cardPack: "THREE_CARDS",
  })), {
    cards: ["AMMOCRATE", "FREEZE", "AIRSTRIKE"],
    cardPack: "THREE_CARDS",
    discount: 0,
    startTime: 0,
  });
  assert.deepEqual(parseCardPackPurchaseData(JSON.stringify({
    cards: ["AMMOCRATE"],
    cardPack: "BRONZE_CARDPACK",
    discount: 0,
    StartTime: 1_700_000_000,
  })), {
    cards: ["AMMOCRATE"],
    cardPack: "BRONZE_CARDPACK",
    discount: 0,
    startTime: 1_700_000_000,
  });

  assert.throws(
    () => parseCardPackPurchaseData(JSON.stringify({
      cards: ["AMMOCRATE", "FREEZE", "AIRSTRIKE"],
      cardPack: "THREE_CARDS",
      discount: 0,
      StartTime: 1_700_000_000,
    })),
    (error: unknown) => (error as { code?: number }).code === CARD_PACK_NOT_FOUND,
  );
});

test("Server preserves the exact Android pack restore and refund notice dictionaries", () => {
  const source = readFileSync(CLIENT_ANDROID_PURCHASE_SOURCE, "utf8");
  assert.match(source, /dictionary\.Add\("Value1",\s*inAppsRow\.NAME\);/u);
  assert.match(source, /dictionary\.Add\("Value2",\s*item3\.purchaseToken\);/u);
  assert.match(source, /dictionary\.Add\("Value3",\s*item3\.packageName\);/u);
  assert.match(source, /dictionary\.Add\("Value4",\s*item3\.orderId\);/u);
  assert.match(source, /dictionary\.Add\("inappId",\s*inAppsRow2\.NAME\);/u);
  assert.match(source, /dictionary\.Add\("purchaseToken",\s*item4\.purchaseToken\);/u);
  assert.match(source, /dictionary\.Add\("packageName",\s*item4\.packageName\);/u);
  assert.match(source, /dictionary\.Add\("orderId",\s*item4\.orderId\);/u);

  assert.deepEqual(parseRestorePackInputs(JSON.stringify([{
    Value1: "valuepackaf",
    Value2: "opaque-token",
    Value3: "com.chillingo.warfriends.android.gplay",
    Value4: "GPA.restore",
  }])), [{
    productId: "valuepackaf",
    purchaseToken: "opaque-token",
    packageName: "com.chillingo.warfriends.android.gplay",
    orderId: "GPA.restore",
  }]);
  assert.doesNotThrow(() => validateRefundPackNotice(JSON.stringify([{
    inappId: "valuepackaf",
    purchaseToken: "opaque-token",
    packageName: "com.chillingo.warfriends.android.gplay",
    orderId: "GPA.refund",
  }])));
});
