import assert from "node:assert/strict";
import test from "node:test";
import {
  exactAuthenticationRequest,
  isRecoveredPreAccountSessionPlaceholder,
} from "../handlers/authenticationRequestParsing";

test("ordinary actions authenticate only with the recovered PlayerId and Token envelope", () => {
  assert.deepEqual(
    exactAuthenticationRequest({ PlayerId: "player-a", Token: "session-token" }, "session"),
    { playerId: "player-a", credential: "session-token" },
  );
  assert.deepEqual(
    exactAuthenticationRequest({ PlayerId: "player-a", id: "player-a", Token: "same", token: "same" }, "session"),
    { playerId: "player-a", credential: "same" },
  );

  // Id belongs to many action payloads and Password is the new credential on action 121. Neither
  // field may silently authenticate an ordinary gameplay mutation when the common pair is absent.
  assert.deepEqual(
    exactAuthenticationRequest({ Id: "product-or-message-id", Password: "session-token" }, "session"),
    { playerId: undefined, credential: undefined },
  );
  assert.deepEqual(
    exactAuthenticationRequest({ PlayerId: "player-a", Token: "session-token", Id: "product-id", Password: "new-password" }, "session"),
    { playerId: "player-a", credential: "session-token" },
  );
});

test("custom login authenticates only with the recovered Id and Password envelope", () => {
  assert.deepEqual(
    exactAuthenticationRequest({ Id: "player-a", Password: "human password" }, "login"),
    { playerId: "player-a", credential: "human password" },
  );
  assert.deepEqual(
    exactAuthenticationRequest({ Id: "player-a", id: "player-a", PlayerId: "player-a", Password: "same", password: "same" }, "login"),
    { playerId: "player-a", credential: "same" },
  );

  // A gameplay token sent under Token is not the recovered explicit-login credential field.
  assert.deepEqual(
    exactAuthenticationRequest({ PlayerId: "player-a", Token: "session-token" }, "login"),
    { playerId: "player-a", credential: undefined },
  );
});

test("authentication aliases must carry one exact bounded value", () => {
  for (const invalid of [
    { PlayerId: "player-a", id: "player-b", Token: "token" },
    { PlayerId: "player-a", Token: "first", token: "second" },
    { PlayerId: 123, Token: "token" },
    { PlayerId: " player-a", Token: "token" },
    { PlayerId: "player-a", Token: " token" },
    { PlayerId: "player-a", Token: "line\nbreak" },
    { PlayerId: "player-a", Token: 123 },
    { PlayerId: "player-a", Token: "x".repeat(4_097) },
    { Id: "player-a", PlayerId: "player-b", Password: "password" },
    { Id: "player-a", Password: "first", password: "second" },
    { Id: "player-a", Password: null },
  ]) {
    const mode = Object.prototype.hasOwnProperty.call(invalid, "Id") ? "login" : "session";
    assert.throws(
      () => exactAuthenticationRequest(invalid, mode),
      /identity|credential is invalid/iu,
    );
  }
});

test("missing and form null sentinels cannot become authentication authority", () => {
  assert.deepEqual(exactAuthenticationRequest({}, "session"), { playerId: undefined, credential: undefined });
  assert.throws(
    () => exactAuthenticationRequest({ PlayerId: "null", Token: "token" }, "session"),
    /Player identity is invalid/u,
  );
  assert.throws(
    () => exactAuthenticationRequest({ PlayerId: "player-a", Token: "null" }, "session"),
    /Session credential is invalid/u,
  );
});

test("only the two recovered unauthenticated envelopes identify a pre-account request snapshot", () => {
  assert.equal(isRecoveredPreAccountSessionPlaceholder({}), true);
  assert.equal(
    isRecoveredPreAccountSessionPlaceholder({ PlayerId: "null", Token: "null" }),
    true,
  );
  for (const request of [
    { PlayerId: "null", Token: "token" },
    { PlayerId: "player-a", Token: "null" },
    { PlayerId: "null" },
    { Token: "null" },
    { PlayerId: "null", Token: "null", id: "player-a" },
    { PlayerId: "null", Token: "null", token: "session-token" },
  ]) {
    assert.equal(isRecoveredPreAccountSessionPlaceholder(request), false);
  }
});
