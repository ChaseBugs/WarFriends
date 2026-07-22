import assert from "node:assert/strict";
import { readFileSync } from "node:fs";
import { createServer, type Server } from "node:http";
import { resolve } from "node:path";
import test from "node:test";
import express from "express";
import { apiRouter } from "../routes";
import { CARD_PACK_NOT_FOUND, parseCardPackPurchaseData } from "../services/cardInventoryService";

const CLIENT_ENDPOINT_SOURCE = resolve(
  process.cwd(),
  "../Client/ExportedProject/Assets/LegacyCompat/ServerEndpoint.cs",
);
const SERVER_ENV_EXAMPLE = resolve(process.cwd(), ".env.example");
const CLIENT_CARD_MANAGER_SOURCE = resolve(
  process.cwd(),
  "../Client/ExportedProject/Assets/Scripts/Gameplay/CardManager.cs",
);

async function withRecoveredRouter(
  run: (baseUrl: string) => Promise<void>,
): Promise<void> {
  const app = express();

  // BestHTTP.AddField uses application/x-www-form-urlencoded for the stock request path. Mount
  // exactly as production does so this test detects a body-parser or /api prefix regression.
  app.use(express.urlencoded({ extended: false, limit: "2mb" }));
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
