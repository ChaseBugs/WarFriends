import assert from "node:assert/strict";
import { readFileSync } from "node:fs";
import { createServer, type Server } from "node:http";
import { resolve } from "node:path";
import test from "node:test";
import express from "express";
import { apiRouter } from "../routes";

const CLIENT_ENDPOINT_SOURCE = resolve(
  process.cwd(),
  "../Client/ExportedProject/Assets/LegacyCompat/ServerEndpoint.cs",
);
const SERVER_ENV_EXAMPLE = resolve(process.cwd(), ".env.example");

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
