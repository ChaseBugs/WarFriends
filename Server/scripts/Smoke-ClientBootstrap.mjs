import assert from "node:assert/strict";
import { spawn } from "node:child_process";
import { randomUUID } from "node:crypto";
import { createServer } from "node:http";
import { once } from "node:events";
import { MongoClient } from "mongodb";

const mongoUrl = process.env.MONGO_URL ?? "mongodb://127.0.0.1:27017";
const databaseName = `warfriends_client_bootstrap_${randomUUID().replaceAll("-", "")}`;
const port = await availableLoopbackPort();
const origin = `http://127.0.0.1:${port}`;
const output = [];
let server;

try {
  server = spawn(process.execPath, ["dist/index.js"], {
    cwd: process.cwd(),
    env: {
      ...process.env,
      NODE_ENV: "development",
      PORT: String(port),
      PUBLIC_URL: origin,
      MONGO_URL: mongoUrl,
      MONGO_DB_NAME: databaseName,
      REDIS_ENABLED: "false",
      AUTH_SECRET: "client-bootstrap-smoke-only-secret-2026",
      AUTH_SECRET_FALLBACKS: "",
      ADMIN_SECRET: "",
      REMOTE_CONFIGURATION_MANIFEST_PATH: "",
      SQUAD_EVENT_CONFIG_PATH: "",
      EVENT_ASSIGNMENT_CONFIG_PATH: "",
      GOOGLE_PLAY_PURCHASES_ENABLED: "false",
      GOOGLE_PLAY_SUBSCRIPTION_REVALIDATION_ENABLED: "false",
      GOOGLE_PLAY_VOIDED_PURCHASE_RECONCILIATION_ENABLED: "false",
      GOOGLE_PLAY_RTDN_ENABLED: "false",
      FIREBASE_PUSH_ENABLED: "false",
    },
    stdio: ["ignore", "pipe", "pipe"],
    windowsHide: true,
  });
  capture(server.stdout, output);
  capture(server.stderr, output);

  await waitForHealth(`${origin}/health`, server, output);

  const probe = await fetch(`${origin}/api/check.php`, { method: "POST" });
  assert.equal(probe.status, 200);
  assert.equal(await probe.text(), "ok");

  const configuration = await stockPost(origin, 157, {
    abTestVariant: "",
    SheetConfiguraton: "0",
    Language: "en",
  });
  assert.equal(configuration.status, 200);
  assert.equal(await configuration.text(), "success;0;{}");

  // These two fields come directly from BeanstalkServerManager.CreateAccount. UtcOffset is a
  // diagnostic hint only; Locale is persisted as part of the new server-owned player profile.
  const createResponse = await stockPost(origin, 118, {
    UtcOffset: "10",
    Locale: "en",
  });
  assert.equal(createResponse.status, 200);
  const created = await createResponse.json();
  assert.equal(created.DbAction, 118);
  assert.equal(created.Result, 1);
  assert.equal(typeof created.PlayerId, "string");
  assert.equal(typeof created.Token, "string");
  assert.equal(created.Player?.Id?.S, created.PlayerId);
  assert.ok(created.PlayerData && typeof created.PlayerData === "object");

  // EIDPAHNCFPD adds PlayerId and Token to every authenticated action. GetPlayerData's recovered
  // callback unconditionally reads Time and PlayerData, so prove the same credentials survive a
  // second real HTTP request and return those fields from durable MongoDB state.
  const playerDataResponse = await stockPost(origin, 34, {
    PlayerId: created.PlayerId,
    Token: created.Token,
    Buffers: "[]",
    Locale: "en",
    DogTagRefillTime: "900",
    DogTagCap: "5",
  });
  assert.equal(playerDataResponse.status, 200);
  const playerData = await playerDataResponse.json();
  assert.equal(playerData.DbAction, 34);
  assert.equal(playerData.Result, 1);
  assert.equal(Number.isSafeInteger(playerData.Time), true);
  assert.ok(playerData.PlayerData && typeof playerData.PlayerData === "object");

  console.log(`Client bootstrap smoke passed on ${origin} (temporary database ${databaseName}).`);
} catch (error) {
  if (output.length > 0) {
    console.error("Server output:\n" + output.join(""));
  }
  throw error;
} finally {
  await stopChild(server);
  await dropTemporaryDatabase(mongoUrl, databaseName);
}

async function availableLoopbackPort() {
  const listener = createServer();
  listener.listen(0, "127.0.0.1");
  await once(listener, "listening");
  const address = listener.address();
  assert.ok(address && typeof address === "object");
  const selectedPort = address.port;
  await new Promise((accept, reject) => listener.close((error) => error ? reject(error) : accept()));
  return selectedPort;
}

function capture(stream, output) {
  stream?.setEncoding("utf8");
  stream?.on("data", (chunk) => {
    output.push(chunk);
    if (output.length > 200) output.shift();
  });
}

async function waitForHealth(url, child, output) {
  const deadline = Date.now() + 20_000;
  while (Date.now() < deadline) {
    if (child.exitCode !== null) {
      throw new Error(`Server exited with code ${child.exitCode}.\n${output.join("")}`);
    }
    try {
      const response = await fetch(url);
      if (response.ok) return;
    } catch {
      // Startup still owns Mongo connection, migrations, catalog validation, and listener setup.
    }
    await new Promise((accept) => setTimeout(accept, 100));
  }
  throw new Error(`Server did not become healthy within 20 seconds.\n${output.join("")}`);
}

function stockPost(origin, action, actionFields) {
  const body = new URLSearchParams({
    SheetConfig: "0",
    requestId: String(action),
    Version: "4.9.5.2",
    Os: "android",
    ...actionFields,
  });
  return fetch(`${origin}/api/${action}/4-9-5`, {
    method: "POST",
    headers: {
      "App-Version": "4.9.5",
      "Content-Type": "application/x-www-form-urlencoded",
    },
    body,
  });
}

async function stopChild(child) {
  if (!child || child.exitCode !== null) return;
  child.kill("SIGTERM");
  await Promise.race([
    once(child, "exit"),
    new Promise((accept) => setTimeout(accept, 5_000)),
  ]);
  if (child.exitCode === null) child.kill("SIGKILL");
}

async function dropTemporaryDatabase(url, name) {
  // The database name is generated in this process with a fixed, test-only prefix. Never accept
  // an arbitrary caller-supplied database here: cleanup is deliberately limited to this run.
  assert.match(name, /^warfriends_client_bootstrap_[0-9a-f]{32}$/u);
  const client = new MongoClient(url);
  try {
    await client.connect();
    await client.db(name).dropDatabase();
  } finally {
    await client.close();
  }
}
