import assert from "node:assert/strict";
import test from "node:test";
import { createInitialProgression } from "../services/playerStateService";
import {
  arenaPolicy,
  currentArenaId,
  warArenaConfiguration,
  warArenaWireData,
} from "../services/warArenaContract";
import {
  buyWarArenaHeartState,
  claimWarArenaScrapsState,
  endWarArenaState,
  enterWarArenaState,
  settleWarArenaBattleState,
  startWarArenaBattleState,
  takeWarArenaLifeState,
} from "../services/warArenaService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;

test("War Arena config and persisted wire use the recovered client field names", () => {
  const configuration = warArenaConfiguration(NOW);
  assert.equal((configuration.Id as { S: string }).S, currentArenaId(NOW));
  assert.equal((configuration.Rules as { S: string }).S, "{}");
  assert.equal((configuration.MaxBattles as { N: string }).N, String(arenaPolicy().maxBattles));
  assert.equal((configuration.LifeCount as { N: string }).N, String(arenaPolicy().startingLives));
  assert.equal(
    (configuration.ArenaPrice as { S: string }).S,
    Array(arenaPolicy().maxBattles).fill(arenaPolicy().entryTickets).join(","),
  );
  assert.equal((configuration.HeartPrice1 as { N: string }).N, String(arenaPolicy().heartTickets));

  const initial = createInitialProgression(NOW);
  const entered = enterWarArenaState(initial, NOW, { usedGold: 0, opponents: ["p2", "p3", "p2"] });
  assert.equal(entered.state.tickets, 0, "the first recovered-client Arena entry is free");
  assert.equal(typeof entered.response.WarArenaData, "string");
  const wire = warArenaWireData(entered.arena);
  assert.deepEqual(Object.keys(wire), [
    "wins",
    "lives",
    "opponents",
    "arenaId",
    "runs",
    "visualType",
    "visualTimestamp",
    "flawless",
    "topRun",
    "matches",
    "shields",
    "played",
    "heartDialogShown",
  ]);
  assert.deepEqual(wire.opponents, ["p2", "p3"]);
});

test("Arena battle receipts make wins replay-safe and reject conflicting replay results", () => {
  let state = enterWarArenaState(createInitialProgression(NOW), NOW, { usedGold: 0, opponents: [] }).state;
  state = startWarArenaBattleState(state, NOW + 1, "arena-battle-1").state;
  const won = settleWarArenaBattleState(state, NOW + 10, { battleId: "arena-battle-1", endReason: 2 });
  assert.equal(won.arena.wins, 1);
  assert.equal(won.arena.matches, 1);
  assert.equal(won.response.IsWarArena, 1);
  assert.equal(won.response.ArenaWins, 1);

  const replay = settleWarArenaBattleState(won.state, NOW + 20, { battleId: "arena-battle-1", endReason: 2 });
  assert.equal(replay.replayed, true);
  assert.equal(replay.arena.wins, 1);
  assert.deepEqual(replay.response, won.response);
  assert.throws(
    () => settleWarArenaBattleState(won.state, NOW + 20, { battleId: "arena-battle-1", endReason: 1 }),
    (error: unknown) => (error as { code?: number }).code === 90,
  );
});

test("three losses finish a run, scraps claim once, and the next entry charges Tickets", () => {
  let state = { ...createInitialProgression(NOW), tickets: 2 };
  state = enterWarArenaState(state, NOW, { usedGold: 0, opponents: [] }).state;
  for (let index = 0; index < arenaPolicy().startingLives; index += 1) {
    const battleId = `arena-loss-${index}`;
    state = startWarArenaBattleState(state, NOW + index * 20 + 1, battleId).state;
    state = settleWarArenaBattleState(state, NOW + index * 20 + 10, { battleId, endReason: 1 }).state;
  }
  assert.equal(state.warArena?.lives, 0);

  const claimed = claimWarArenaScrapsState(state, NOW + 100, true);
  assert.equal(claimed.state.scraps, arenaPolicy().guaranteedScraps);
  assert.equal(claimed.response.Scraps, arenaPolicy().guaranteedScraps);
  const replay = claimWarArenaScrapsState(claimed.state, NOW + 110, true);
  assert.equal(replay.replayed, true);
  assert.equal(replay.state.scraps, arenaPolicy().guaranteedScraps);

  const next = enterWarArenaState(replay.state, NOW + 120, { usedGold: 0, opponents: [] });
  assert.equal(next.state.tickets, 2 - arenaPolicy().entryTickets);
  assert.equal(next.response.Tickets, arenaPolicy().entryTickets);
  assert.equal(next.arena.runs, 2);
});

test("heart purchase uses server price and duplicate life-take cannot consume twice", () => {
  let state = { ...createInitialProgression(NOW), tickets: 3 };
  state = enterWarArenaState(state, NOW, { usedGold: 0, opponents: [] }).state;
  state = startWarArenaBattleState(state, NOW + 1, "abandoned-arena-battle").state;
  const firstTake = takeWarArenaLifeState(state, NOW + 2);
  assert.equal(firstTake.replayed, false);
  assert.equal(firstTake.arena.lives, arenaPolicy().startingLives - 1);
  const duplicateTake = takeWarArenaLifeState(firstTake.state, NOW + 3);
  assert.equal(duplicateTake.replayed, true);
  assert.equal(duplicateTake.arena.lives, arenaPolicy().startingLives - 1);

  // Move the same run to zero lives to exercise the exact direct-ticket heart path.
  state = { ...duplicateTake.state, warArena: { ...duplicateTake.arena, lives: 0 } };
  const bought = buyWarArenaHeartState(state, NOW + 10, { hearthPrice: arenaPolicy().heartTickets });
  assert.equal(bought.arena.lives, 1);
  assert.equal(bought.state.tickets, 3 - arenaPolicy().heartTickets);
  assert.equal(bought.response.ticketsSpent, arenaPolicy().heartTickets);
  const replay = buyWarArenaHeartState(bought.state, NOW + 20, { hearthPrice: arenaPolicy().heartTickets });
  assert.equal(replay.replayed, true);
  assert.equal(replay.state.tickets, bought.state.tickets);
});

test("final win grants the non-inventory fallback exactly once and closes the run", () => {
  let state = { ...createInitialProgression(NOW), tickets: 2 };
  state = enterWarArenaState(state, NOW, { usedGold: 0, opponents: [] }).state;
  let finalResponse: Record<string, unknown> = {};
  for (let index = 0; index < arenaPolicy().maxBattles; index += 1) {
    const battleId = `arena-win-${index}`;
    state = startWarArenaBattleState(state, NOW + index * 20 + 1, battleId).state;
    const won = settleWarArenaBattleState(state, NOW + index * 20 + 10, { battleId, endReason: 2 });
    state = won.state;
    finalResponse = won.response;
  }
  assert.equal(state.warArena?.wins, arenaPolicy().maxBattles);
  assert.equal(state.warArena?.flawless, 1);
  assert.equal(state.warArena?.runRewardClaimed, true);
  assert.equal(state.scraps, arenaPolicy().guaranteedScraps);
  assert.equal(finalResponse.Scraps, arenaPolicy().guaranteedScraps);

  const replay = settleWarArenaBattleState(state, NOW + 500, {
    battleId: `arena-win-${arenaPolicy().maxBattles - 1}`,
    endReason: 2,
  });
  assert.equal(replay.state.scraps, arenaPolicy().guaranteedScraps);
  const next = enterWarArenaState(replay.state, NOW + 510, { usedGold: 0, opponents: [] });
  assert.equal(next.arena.runs, 2);
});

test("expired Arena settlement grants fallback scraps once and supplies NewArena", () => {
  const previousMonth = Date.UTC(2026, 5, 30, 12, 0, 0) / 1_000;
  let state = enterWarArenaState(createInitialProgression(previousMonth), previousMonth, { usedGold: 0, opponents: [] }).state;
  const oldArenaId = state.warArena!.arenaId;
  const ended = endWarArenaState(state, NOW, oldArenaId);
  assert.equal(ended.response.Scraps, arenaPolicy().guaranteedScraps);
  assert.equal((ended.response.NewArena as { Id: { S: string } }).Id.S, currentArenaId(NOW));
  assert.equal(ended.state.scraps, arenaPolicy().guaranteedScraps);

  const replay = endWarArenaState(ended.state, NOW + 1, oldArenaId);
  assert.equal(replay.response.Scraps, undefined);
  assert.equal(replay.state.scraps, arenaPolicy().guaranteedScraps);
});
