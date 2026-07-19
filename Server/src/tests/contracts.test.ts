import assert from "node:assert/strict";
import test from "node:test";
import { AccountType, League, PlayerStatus, SquadRank } from "../constants";
import { configurationResponse, normalizeEnvelope } from "../routes";
import { squadRankAuthority } from "../services/squadService";

test("wire enums match the recovered 1.6.0 client", () => {
  assert.equal(AccountType.Guest, 0);
  assert.equal(AccountType.Facebook, 2);
  assert.equal(League.NoLeague, 0);
  assert.equal(League.Bronze3, 1);
  assert.equal(League.Champion, 16);
  assert.equal(PlayerStatus.InGame, 2);
  assert.equal(SquadRank.None, -1);
  assert.equal(SquadRank.Member, 0);
  assert.equal(SquadRank.Veteran, 1);
  assert.equal(SquadRank.Leader, 2);
  assert.equal(SquadRank.Coleader, 3);
});

test("squad authority does not rely on numeric enum ordering", () => {
  assert.ok(squadRankAuthority(SquadRank.Leader) > squadRankAuthority(SquadRank.Coleader));
  assert.ok(squadRankAuthority(SquadRank.Coleader) > squadRankAuthority(SquadRank.Veteran));
  assert.ok(squadRankAuthority(SquadRank.Veteran) > squadRankAuthority(SquadRank.Member));
});

test("request normalization accepts JSON envelopes and BestHTTP form fields", () => {
  assert.equal(normalizeEnvelope({ DbAction: 34 }).DbAction, 34);
  assert.equal(normalizeEnvelope({ requestId: "38", PlayerId: "p1", Token: "t1" }).DbAction, 38);
  assert.equal(normalizeEnvelope({}, "124").DbAction, 124);
  assert.ok(Number.isNaN(normalizeEnvelope({ requestId: "38" }, "124").DbAction));
});

test("configuration response matches the recovered raw client parser", () => {
  assert.equal(configurationResponse({ DbAction: 157, SheetConfiguraton: "prod" }), "success;prod;{};");
  assert.equal(configurationResponse({ DbAction: 157, SheetConfig: "bad;value" }), "success;badvalue;{};");
});
