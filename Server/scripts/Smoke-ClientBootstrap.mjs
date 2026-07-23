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

  // RequestBuffer creates its HTTP envelope before its delayed send. Preserve a representative
  // pre-account snapshot and submit it only after registration, matching the stock first-boot race.
  const queuedPreAccountBuffer = {
    PlayerId: "null",
    Token: "null",
    BufferId: `pre-account-${randomUUID()}`,
    Count: "19",
    Requests: JSON.stringify(Array.from({ length: 19 }, (_, index) => ({
      DbAction: 108,
      Name: `untrusted-pre-account-telemetry-${index}`,
    }))),
  };
  assert.ok(queuedPreAccountBuffer.Requests.length > 256);

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
  assert.equal(typeof created.Password, "string");
  assert.equal(created.Player?.Id?.S, created.PlayerId);
  assert.ok(created.PlayerData && typeof created.PlayerData === "object");

  // The buffer has no authentication authority, so the server must not execute the nested action.
  // It does acknowledge the transport ID with an empty result list so the recovered client drops
  // the stale queue instead of treating UnAuthorizedAction as OldToken and relogging forever.
  const staleBufferResponse = await stockPost(origin, 98, queuedPreAccountBuffer);
  assert.equal(staleBufferResponse.status, 200);
  const staleBuffer = await staleBufferResponse.json();
  assert.deepEqual(
    {
      DbAction: staleBuffer.DbAction,
      Result: staleBuffer.Result,
      BufferId: staleBuffer.BufferId,
      RequestsResults: staleBuffer.RequestsResults,
      DiscardedPreAccountBuffer: staleBuffer.DiscardedPreAccountBuffer,
    },
    {
      DbAction: 98,
      Result: 1,
      BufferId: queuedPreAccountBuffer.BufferId,
      RequestsResults: "[]",
      DiscardedPreAccountBuffer: true,
    },
  );

  // Some recovered BestHTTP paths omit both common fields instead of serializing their null
  // sentinels. This is the same fail-closed stale-buffer case: discard, never execute.
  const omittedAuthBufferId = `pre-account-omitted-${randomUUID()}`;
  const omittedAuthBufferResponse = await stockPost(origin, 98, {
    BufferId: omittedAuthBufferId,
    Count: "1",
    Requests: JSON.stringify([{ DbAction: 108, Name: "still-untrusted" }]),
  });
  assert.equal(omittedAuthBufferResponse.status, 200);
  const omittedAuthBuffer = await omittedAuthBufferResponse.json();
  assert.deepEqual(
    {
      DbAction: omittedAuthBuffer.DbAction,
      Result: omittedAuthBuffer.Result,
      BufferId: omittedAuthBuffer.BufferId,
      RequestsResults: omittedAuthBuffer.RequestsResults,
    },
    {
      DbAction: 98,
      Result: 1,
      BufferId: omittedAuthBufferId,
      RequestsResults: "[]",
    },
  );

  // A rejected stock login must use IJEAJGCCHEF.LoginFailure. Returning UnAuthorizedAction makes
  // the recovered client treat a bad password as an old gameplay token and enter a relog loop.
  const rejectedLoginResponse = await stockPost(origin, 30, {
    Id: created.PlayerId,
    Password: `${created.Password}-wrong`,
    AccountType: "0",
  });
  assert.equal(rejectedLoginResponse.status, 200);
  const rejectedLogin = await rejectedLoginResponse.json();
  assert.deepEqual(
    { DbAction: rejectedLogin.DbAction, Result: rejectedLogin.Result, Code: rejectedLogin.Code },
    { DbAction: 30, Result: 3001, Code: 3001 },
  );

  // Reproduce the next-launch path: the client persists the long-lived Password separately from
  // Token, sends Id + Password to action 30, then must use the newly returned Token for gameplay.
  const loginResponse = await stockPost(origin, 30, {
    Id: created.PlayerId,
    Password: created.Password,
    AccountType: "0",
  });
  assert.equal(loginResponse.status, 200);
  const login = await loginResponse.json();
  assert.equal(login.DbAction, 30);
  assert.equal(login.Result, 1);
  assert.equal(login.PlayerId, created.PlayerId);
  assert.equal(login.Password, created.Password);
  assert.equal(typeof login.Token, "string");
  assert.ok(login.Token.length > 0);
  assert.equal(
    login.Token,
    created.Token,
    "A bootstrap Guest has no independent password yet, so explicit login must preserve its token",
  );

  // OLD TOKEN makes the stock client call Relog immediately. A first-boot Guest stores Password as
  // the same opaque bootstrap token, so that exact saved value must remain valid across repeated
  // LoginToCustomAccount calls until ChangeNameAndPassword creates a durable password hash.
  const repeatedLoginResponse = await stockPost(origin, 30, {
    Id: created.PlayerId,
    Password: created.Password,
    AccountType: "0",
  });
  assert.equal(repeatedLoginResponse.status, 200);
  const repeatedLogin = await repeatedLoginResponse.json();
  assert.equal(repeatedLogin.DbAction, 30);
  assert.equal(repeatedLogin.Result, 1);
  assert.equal(repeatedLogin.Token, login.Token);
  assert.equal(repeatedLogin.Password, created.Password);

  // EIDPAHNCFPD adds PlayerId and Token to every authenticated action. GetPlayerData's recovered
  // callback unconditionally reads Time and PlayerData, so prove the same credentials survive a
  // second real HTTP request and return those fields from durable MongoDB state.
  const bootBufferId = `boot-buffer-${randomUUID()}`;
  const bootBufferRequests = {
    0: { action: 194, data: JSON.stringify({ MessageId: "bootstrap-visible-message" }) },
  };
  const playerDataResponse = await stockPost(origin, 34, {
    PlayerId: repeatedLogin.PlayerId,
    Token: repeatedLogin.Token,
    Buffers: JSON.stringify({
      [bootBufferId]: {
        alreadySent: true,
        id: bootBufferId,
        requestCount: 1,
        requests: bootBufferRequests,
      },
    }),
    Locale: "en",
    DogTagRefillTime: "900",
    DogTagCap: "5",
  });
  assert.equal(playerDataResponse.status, 200);
  const playerData = await playerDataResponse.json();
  assert.equal(playerData.DbAction, 34);
  if (playerData.Result !== 1) {
    const stored = await loadSmokePlayer(mongoUrl, databaseName, repeatedLogin.PlayerId);
    throw new Error(`GetPlayerData failed: ${JSON.stringify(playerData)}; stored progression: ${JSON.stringify(stored?.progression)}`);
  }
  assert.equal(playerData.Result, 1, `GetPlayerData failed: ${JSON.stringify(playerData)}`);
  assert.equal(Number.isSafeInteger(playerData.Time), true);
  assert.ok(playerData.PlayerData && typeof playerData.PlayerData === "object");
  assert.deepEqual(playerData.VideoFeed, { FeaturedVideos: "{}", RecentVideos: "{}" });
  assert.equal("LeagueId" in playerData, false);

  // EGPLNLMMADN clears RequestBufferManager immediately after a successful action 34. Re-submit
  // the exact buffer through action 98 and require a durable replay receipt; Replayed=false here
  // would prove GetPlayerData ignored and therefore lost the Client's queued mutation.
  const restoredBufferResponse = await stockPost(origin, 98, {
    PlayerId: repeatedLogin.PlayerId,
    Token: repeatedLogin.Token,
    BufferId: bootBufferId,
    Count: "1",
    Requests: JSON.stringify(bootBufferRequests),
  });
  assert.equal(restoredBufferResponse.status, 200);
  const restoredBuffer = await restoredBufferResponse.json();
  assert.equal(restoredBuffer.Result, 1);
  assert.equal(restoredBuffer.Replayed, true);
  assert.deepEqual(JSON.parse(restoredBuffer.RequestsResults), [{ ActionId: 194, Result: 1 }]);

  // The recovered RequestBufferManager creates IDs by concatenating its counter with the current
  // server timestamp, so the first ID is a leading-zero decimal such as the live Editor value
  // `01784723999`. Exercise an authenticated, long multipart buffer after PlayerDataLoaded: this
  // is the exact path that previously returned `BufferId is invalid` and made the client clear its
  // waitlist. AchievementProgressGroups then evaluates the 1.6 runtime's 19 scene groups in ID
  // order. A new account reports league group 13 at one and visual group 15 at five because
  // PlayerVisual.isBought includes CAMOS_GIRLBLONDE as well as the four category defaults.
  const authenticatedBufferId = `0${playerData.Time}`;
  const authenticatedRequests = JSON.stringify(Object.fromEntries(
    Array.from({ length: 19 }, (_, index) => [index, {
      action: 220,
      data: JSON.stringify({
        Id: index,
        Progress: index === 13 ? 1 : index === 15 ? 5 : 0,
      }),
    }]),
  ));
  assert.ok(authenticatedRequests.length > 256);
  const authenticatedBufferResponse = await stockPost(origin, 98, {
    PlayerId: repeatedLogin.PlayerId,
    Token: repeatedLogin.Token,
    BufferId: authenticatedBufferId,
    Count: "19",
    Requests: authenticatedRequests,
  });
  assert.equal(authenticatedBufferResponse.status, 200);
  const authenticatedBuffer = await authenticatedBufferResponse.json();
  assert.equal(authenticatedBuffer.DbAction, 98);
  assert.equal(
    authenticatedBuffer.Result,
    1,
    `Authenticated RequestBuffer failed: ${JSON.stringify(authenticatedBuffer)}`,
  );
  assert.equal(authenticatedBuffer.BufferId, authenticatedBufferId);
  assert.deepEqual(
    JSON.parse(authenticatedBuffer.RequestsResults),
    Array.from({ length: 19 }, () => ({ ActionId: 220, Result: 1 })),
  );

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
  const fields = {
    SheetConfig: "0",
    requestId: String(action),
    Version: "4.9.5.2",
    Os: "android",
    ...actionFields,
  };
  // BestHTTP.HTTPRequest selects multipart automatically when any AddField value is longer than
  // 256 characters. Reproduce that transport decision instead of testing only short URL-encoded
  // forms; a real RequestBuffer normally crosses the boundary through its Requests JSON.
  const useMultipart = Object.values(fields).some((value) => String(value).length > 256);
  const body = useMultipart ? new FormData() : new URLSearchParams();
  for (const [name, value] of Object.entries(fields)) body.set(name, String(value));
  return fetch(`${origin}/api/${action}/4-9-5`, {
    method: "POST",
    headers: {
      "App-Version": "4.9.5",
      ...(useMultipart ? {} : { "Content-Type": "application/x-www-form-urlencoded" }),
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

async function loadSmokePlayer(url, name, id) {
  const client = new MongoClient(url);
  try {
    await client.connect();
    return await client.db(name).collection("players").findOne({ id });
  } finally {
    await client.close();
  }
}
