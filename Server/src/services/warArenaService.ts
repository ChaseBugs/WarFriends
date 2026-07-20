import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState, WarArenaState } from "../db";
import { advanceAchievementState } from "./achievementService";
import { mutateProgression } from "./progressionMutationService";
import {
  arenaPolicy,
  currentArenaId,
  serializeWarArenaData,
  warArenaConfiguration,
} from "./warArenaContract";

/**
 * War Arena run state, entry costs, lives, and replay-safe rewards.
 *
 * A run belongs to the current server-generated Arena ID. Entry starts or re-enters that run,
 * `startWarArenaBattleState` issues a battle receipt, and `settleWarArenaBattleState` consumes
 * the receipt once. Currency prices and run limits are always read from `arenaPolicy`; values
 * echoed by Unity are validated but cannot select a cheaper price or larger reward.
 *
 * Response snapshots are stored for operations that the mobile client may retry after a lost
 * connection. Replaying a stored response is as important as avoiding a second database debit:
 * the client subtracts some returned spend fields locally and would double-charge its visible
 * wallet if the server rebuilt a semantically similar response with different fields.
 *
 * Combat is currently client-reported. The service is authoritative for lifecycle, receipt
 * ownership, result enum validation, lives, entry costs, and reward idempotency, but it does
 * not yet verify individual combat events.
 */

const MAX_RECENT_SETTLEMENTS = 20;
// One Arena is generated per month. Two years of acknowledgements is enough to make delayed
// reconnects replay-safe without allowing this low-value UI history to grow a player document
// forever.
const MAX_SHOWN_ARENA_IDS = 24;
const BATTLE_RECEIPT_LIFETIME_SECONDS = 4 * 60 * 60;
const HEART_REPLAY_WINDOW_SECONDS = 60;
const ARENA_WIN = new Set([2, 3]); // Win and WinByForfeit in GameController.HKGHCIEPGEL.
const ARENA_LOSS = new Set([1, 5, 8]); // Killed, Forfeit, and Kia.

export interface ArenaMutationResult {
  /** Complete progression snapshot to commit through optimistic concurrency control. */
  state: PlayerProgressionState;
  /** Public arena state after the transition, including server-only receipts internally. */
  arena: WarArenaState;
  /** Exact Beanstalk response fields consumed by the recovered callback for this action. */
  response: Record<string, unknown>;
  /** True when no economy/lifecycle effect was applied because the request was a retry. */
  replayed: boolean;
}

export interface ArenaShownResult {
  /** Complete progression snapshot; exact input identity is preserved for a replay. */
  state: PlayerProgressionState;
  /** Internal Arena snapshot after validation, useful to callers and focused tests. */
  arena: WarArenaState;
  /** False when this exact current event was acknowledged previously. */
  changed: boolean;
}

export interface ArenaEntryInput {
  /** Gold amount echoed by Unity when it chooses premium-currency re-entry. */
  usedGold: number;
  /** Client display list, deduplicated and capped; it never controls match rewards. */
  opponents: string[];
}

export interface ArenaHeartInput {
  /** Ticket price field uses the client's original `hearth` spelling on the wire. */
  hearthPrice?: number;
  /** Present instead of `hearthPrice` when the Gold fallback is selected. */
  usedGold?: number;
}

export interface ArenaSettlementInput {
  /** Receipt ID previously issued by the start-battle action. */
  battleId: string;
  /** Recovered GameController end-reason enum; only explicit win/loss values are accepted. */
  endReason: number;
}

function nonNegative(value: number, fallback: number): number {
  return Number.isFinite(value) ? Math.max(0, Math.floor(value)) : fallback;
}

function cloneResponse(value: Record<string, unknown>): Record<string, unknown> {
  return JSON.parse(JSON.stringify(value)) as Record<string, unknown>;
}

function cloneArena(value: WarArenaState): WarArenaState {
  return {
    ...value,
    opponents: [...value.opponents],
    // Accounts written before action 212 became durable do not have this server-only field.
    // Normalize them while cloning instead of requiring a destructive database migration.
    shownArenaIds: [...(value.shownArenaIds ?? [])],
    activeBattle: value.activeBattle ? { ...value.activeBattle } : undefined,
    recentSettlements: value.recentSettlements.map((item) => ({
      ...item,
      response: cloneResponse(item.response),
    })),
    lastEntryResponse: value.lastEntryResponse ? cloneResponse(value.lastEntryResponse) : undefined,
    lastHeartResponse: value.lastHeartResponse ? cloneResponse(value.lastHeartResponse) : undefined,
    lastRunRewardResponse: value.lastRunRewardResponse ? cloneResponse(value.lastRunRewardResponse) : undefined,
  };
}

/** Return the exact public WarArena.WarArenaData JSON shape and no server-only receipts. */
export function initialWarArenaState(): WarArenaState {
  return {
    wins: 0,
    lives: arenaPolicy().startingLives,
    opponents: [],
    arenaId: "",
    runs: 0,
    visualType: "",
    visualTimestamp: 0,
    flawless: 0,
    topRun: 0,
    matches: 0,
    shields: 0,
    played: false,
    heartDialogShown: false,
    shownArenaIds: [],
    runLosses: 0,
    runRewardClaimed: false,
    recentSettlements: [],
  };
}

export function warArenaStateFor(state: PlayerProgressionState): WarArenaState {
  return cloneArena(state.warArena ?? initialWarArenaState());
}

/**
 * Persist the recovered WarArenaShown action for the active monthly event.
 *
 * FCIGAKGDAHO sends WarArena.instance's current configuration ID when Unity displays the
 * Arena-opening message. The ID is therefore an assertion, not a client-selected event: only
 * the ID generated by the server for `now` is accepted. The acknowledgement does not grant a
 * run, currency, or reward and is intentionally separate from EnterArena.
 *
 * A repeated acknowledgement returns the exact input state object. mutateProgression uses that
 * identity to skip MongoDB entirely, which makes reconnect and RequestBuffer replay harmless.
 */
export function markWarArenaShownState(
  state: PlayerProgressionState,
  now: number,
  requestedArenaId: string,
): ArenaShownResult {
  const expectedArenaId = currentArenaId(now);
  if (!requestedArenaId || requestedArenaId.length > 128 || requestedArenaId !== expectedArenaId) {
    throw new ApiError(ApiErrorCode.UnknownAction, "ArenaId is not the current Arena event.");
  }

  const arena = warArenaStateFor(state);
  if (arena.shownArenaIds.includes(expectedArenaId)) {
    return { state, arena, changed: false };
  }

  arena.shownArenaIds = [...arena.shownArenaIds, expectedArenaId].slice(-MAX_SHOWN_ARENA_IDS);
  return { state: withArena(state, arena), arena, changed: true };
}

function validateBattleId(value: string): void {
  if (!value || value.length > 160 || !/^[\w.:@+-]+$/.test(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "BattleId is invalid.");
  }
}

function withArena(
  state: PlayerProgressionState,
  arena: WarArenaState,
): PlayerProgressionState {
  return { ...state, revision: state.revision + 1, warArena: arena };
}

function runIsActive(arena: WarArenaState, now: number): boolean {
  const values = arenaPolicy();
  return arena.arenaId === currentArenaId(now)
    && arena.lives > 0
    && arena.wins < values.maxBattles
    && !arena.runRewardClaimed;
}

/** Enter a new run once, charging only server-owned prices. */
export function enterWarArenaState(
  state: PlayerProgressionState,
  now: number,
  input: ArenaEntryInput,
): ArenaMutationResult {
  const arena = warArenaStateFor(state);
  const values = arenaPolicy();
  const arenaId = currentArenaId(now);

  if (runIsActive(arena, now)) {
    const response = arena.lastEntryResponse ?? { WarArenaData: serializeWarArenaData(arena) };
    // The entry receipt already contains the exact client-visible debit snapshot. A transport
    // retry must return it without advancing revision or replacing an identical progression.
    return { state, arena, response: cloneResponse(response), replayed: true };
  }
  if (arena.arenaId && arena.arenaId !== arenaId && !arena.runRewardClaimed) {
    throw new ApiError(ApiErrorCode.UnknownAction, "The expired Arena run must be settled first.");
  }
  if (arena.arenaId === arenaId && arena.played && !arena.runRewardClaimed) {
    // A zero-life run must pass through GetScrapsReward, while a fully won run is marked
    // claimed by its final GameEnded response below. Do not let EnterArena erase an unpaid
    // finished run merely because it is no longer considered active by the client UI.
    throw new ApiError(ApiErrorCode.UnknownAction, "The finished Arena run must be settled first.");
  }

  const firstEntry = !arena.played;
  const usedGold = nonNegative(input.usedGold, 0);
  let chargedTickets = 0;
  let chargedGold = 0;
  if (!firstEntry && usedGold > 0) {
    if (usedGold !== values.entryGold) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Arena Gold price does not match the server configuration.");
    }
    if (state.gold < usedGold) throw new ApiError(ApiErrorCode.NotEnoughCurrency, "Not enough Gold.");
    chargedGold = usedGold;
  } else if (!firstEntry && values.entryTickets > 0) {
    if (state.tickets < values.entryTickets) throw new ApiError(ApiErrorCode.NotEnoughCurrency, "Not enough Tickets.");
    chargedTickets = values.entryTickets;
  }

  const sameArena = arena.arenaId === arenaId;
  arena.wins = 0;
  arena.lives = values.startingLives;
  arena.opponents = [...new Set(input.opponents.filter(Boolean))].slice(0, values.maxBattles);
  arena.arenaId = arenaId;
  arena.runs = sameArena ? arena.runs + 1 : 1;
  arena.played = true;
  arena.heartDialogShown = false;
  arena.runLosses = 0;
  arena.runRewardClaimed = false;
  arena.activeBattle = undefined;
  arena.lastHeartPurchaseAt = undefined;
  arena.lastHeartResponse = undefined;
  arena.lastRunRewardResponse = undefined;

  const response: Record<string, unknown> = { WarArenaData: serializeWarArenaData(arena) };
  // DIENNAGJJOM subtracts these response values locally; use its exact singular key names.
  if (chargedTickets > 0) response.Tickets = chargedTickets;
  if (chargedGold > 0) response.Gold = chargedGold;
  arena.lastEntryResponse = cloneResponse(response);

  const next = withArena({
    ...state,
    tickets: state.tickets - chargedTickets,
    gold: state.gold - chargedGold,
  }, arena);
  return { state: next, arena, response, replayed: false };
}

/** Bind a War Arena GameEnded report to a prior action-64 battle start. */
export function startWarArenaBattleState(
  state: PlayerProgressionState,
  now: number,
  battleId: string,
): ArenaMutationResult {
  validateBattleId(battleId);
  const arena = warArenaStateFor(state);
  if (!runIsActive(arena, now)) throw new ApiError(ApiErrorCode.UnknownAction, "No active War Arena run exists.");

  const settled = arena.recentSettlements.find((item) => item.battleId === battleId);
  if (settled) {
    return { state, arena, response: cloneResponse(settled.response), replayed: true };
  }
  if (arena.activeBattle && arena.activeBattle.battleId !== battleId) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Another War Arena battle is already active.");
  }
  if (arena.activeBattle?.battleId === battleId) {
    return { state, arena, response: { BattleId: battleId }, replayed: true };
  }

  arena.activeBattle = { battleId, startedAt: now, arenaId: arena.arenaId };
  // Once gameplay starts, a later EnterArena call is not a transport retry of the paid
  // entry. Dropping the charged response prevents Unity from subtracting the price twice
  // and prevents an old wins=0 JSON snapshot from overwriting current run progress.
  arena.lastEntryResponse = undefined;
  // Likewise, a bought heart has now been consumed by a real battle. If that battle ends
  // quickly, the player may legitimately buy another heart inside the 60-second window.
  arena.lastHeartPurchaseAt = undefined;
  arena.lastHeartResponse = undefined;
  return {
    state: withArena(state, arena),
    arena,
    response: { BattleId: battleId },
    replayed: false,
  };
}

/** Settle one Arena battle result exactly once. Combat itself is not yet authoritative. */
export function settleWarArenaBattleState(
  state: PlayerProgressionState,
  now: number,
  input: ArenaSettlementInput,
): ArenaMutationResult {
  validateBattleId(input.battleId);
  if (!Number.isInteger(input.endReason) || (!ARENA_WIN.has(input.endReason) && !ARENA_LOSS.has(input.endReason))) {
    throw new ApiError(ApiErrorCode.UnknownAction, "War Arena EndReason is invalid.");
  }

  const arena = warArenaStateFor(state);
  const replay = arena.recentSettlements.find((item) => item.battleId === input.battleId);
  if (replay) {
    if (replay.endReason !== input.endReason) {
      throw new ApiError(ApiErrorCode.UnknownAction, "BattleId was already settled with another result.");
    }
    return { state, arena, response: cloneResponse(replay.response), replayed: true };
  }

  const receipt = arena.activeBattle;
  if (
    !receipt
    || receipt.battleId !== input.battleId
    || receipt.arenaId !== arena.arenaId
    || now - receipt.startedAt > BATTLE_RECEIPT_LIFETIME_SECONDS
  ) {
    throw new ApiError(ApiErrorCode.UnknownAction, "War Arena battle was not started or its receipt expired.");
  }

  arena.activeBattle = undefined;
  arena.matches += 1;
  const won = ARENA_WIN.has(input.endReason);
  let completedFlawlessRun = false;
  if (won) {
    arena.wins = Math.min(arenaPolicy().maxBattles, arena.wins + 1);
    arena.topRun = Math.max(arena.topRun, arena.wins);
    if (arena.wins === arenaPolicy().maxBattles && arena.runLosses === 0) {
      arena.flawless += 1;
      completedFlawlessRun = true;
    }
  } else {
    arena.lives = Math.max(0, arena.lives - 1);
    arena.runLosses += 1;
  }

  const response: Record<string, unknown> = {
    // KPPNCJBMDPE checks only key presence before selecting the Arena result parser.
    IsWarArena: 1,
    ArenaLives: arena.lives,
    ArenaWins: arena.wins,
    TopRun: arena.topRun,
    Flawless: arena.flawless,
    GameReward: { Gold: 0, IsVip: false },
  };
  let awardedScraps = 0;
  if (arena.wins === arenaPolicy().maxBattles && !arena.runRewardClaimed) {
    /*
     * The original final-win reward was a remote Lootbox document whose inventory payload
     * is not present in either APK. Returning a fabricated Lootbox would corrupt inventory.
     * Use the same explicitly configured GuaranteedScraps fallback as an exhausted run and
     * mark it claimed in the final GameEnded transaction so the player can enter again.
     */
    awardedScraps = arenaPolicy().guaranteedScraps;
    arena.runRewardClaimed = true;
    response.Scraps = awardedScraps;
  }
  arena.recentSettlements = [
    ...arena.recentSettlements,
    { battleId: input.battleId, endReason: input.endReason, settledAt: now, response: cloneResponse(response) },
  ].slice(-MAX_RECENT_SETTLEMENTS);

  let next = withArena({ ...state, scraps: state.scraps + awardedScraps }, arena);
  if (won) {
    // AchievementWinArenaBattles reads the accepted Arena win count. Advancing inside this
    // receipt-consuming transition guarantees that a stored settlement replay cannot count the
    // same win twice, even when GameEnded is retried after the response is lost.
    next = advanceAchievementState(next, 3, 1).state;
  }
  if (completedFlawlessRun) {
    // AchievementFlawlessHero counts complete max-win runs with no accepted losses. It must be
    // coupled to the exact transition that increments `arena.flawless`; deriving it later from
    // the current run would lose lifetime history when EnterArena resets wins and runLosses.
    next = advanceAchievementState(next, 4, 1).state;
  }
  return {
    state: next,
    arena,
    response,
    replayed: false,
  };
}

/** Buy one extra life with either Tickets or the exact Gold fallback sent by BuyTicketsDialog. */
export function buyWarArenaHeartState(
  state: PlayerProgressionState,
  now: number,
  input: ArenaHeartInput,
): ArenaMutationResult {
  const arena = warArenaStateFor(state);
  const values = arenaPolicy();
  if (
    arena.lastHeartResponse
    && arena.lastHeartPurchaseAt !== undefined
    && now - arena.lastHeartPurchaseAt <= HEART_REPLAY_WINDOW_SECONDS
  ) {
    return { state, arena, response: cloneResponse(arena.lastHeartResponse), replayed: true };
  }
  if (arena.arenaId !== currentArenaId(now) || arena.lives !== 0 || arena.wins >= values.maxBattles) {
    throw new ApiError(ApiErrorCode.UnknownAction, "An extra Arena life cannot be bought now.");
  }

  const usedGold = input.usedGold === undefined ? undefined : nonNegative(input.usedGold, 0);
  const hearthPrice = input.hearthPrice === undefined ? undefined : nonNegative(input.hearthPrice, 0);
  let ticketsSpent = 0;
  let goldSpent = 0;
  if (usedGold !== undefined) {
    if (usedGold !== values.heartGold) throw new ApiError(ApiErrorCode.UnknownAction, "Arena heart Gold price is invalid.");
    if (state.gold < usedGold) throw new ApiError(ApiErrorCode.NotEnoughCurrency, "Not enough Gold.");
    goldSpent = usedGold;
  } else {
    if (hearthPrice !== values.heartTickets) throw new ApiError(ApiErrorCode.UnknownAction, "Arena heart Ticket price is invalid.");
    if (state.tickets < values.heartTickets) throw new ApiError(ApiErrorCode.NotEnoughCurrency, "Not enough Tickets.");
    ticketsSpent = values.heartTickets;
  }

  arena.lives = 1;
  arena.heartDialogShown = true;
  const response: Record<string, unknown> = { ArenaLives: arena.lives };
  // OGLEHLIPEFM.GOGPNEEKGNK uses lower camel-case spend keys, unlike EnterArena.
  if (ticketsSpent > 0) response.ticketsSpent = ticketsSpent;
  if (goldSpent > 0) response.goldSpent = goldSpent;
  arena.lastHeartPurchaseAt = now;
  arena.lastHeartResponse = cloneResponse(response);

  const next = withArena({
    ...state,
    tickets: state.tickets - ticketsSpent,
    gold: state.gold - goldSpent,
  }, arena);
  return { state: next, arena, response, replayed: false };
}

/** Consume one life only when an issued battle is abandoned before normal GameEnded. */
export function takeWarArenaLifeState(
  state: PlayerProgressionState,
  now: number,
): ArenaMutationResult {
  const arena = warArenaStateFor(state);
  const consumedReceipt = Boolean(
    arena.activeBattle && now - arena.activeBattle.startedAt <= BATTLE_RECEIPT_LIFETIME_SECONDS,
  );
  let clearedExpiredReceipt = false;
  if (consumedReceipt) {
    arena.activeBattle = undefined;
    arena.lives = Math.max(0, arena.lives - 1);
    arena.runLosses += 1;
  } else if (arena.activeBattle) {
    // Expired proof cannot cost a life, but it also must not block every future start.
    arena.activeBattle = undefined;
    clearedExpiredReceipt = true;
  }
  // A duplicate action without a live receipt returns the current value but cannot remove
  // another life. ELDJABHIMEP only requires ArenaLives and invokes the result parser at zero.
  const response = { ArenaLives: arena.lives, ArenaWins: arena.wins, TopRun: arena.topRun, Flawless: arena.flawless };
  // A true duplicate has no receipt and returns the exact input state. Clearing an expired
  // receipt is still a real maintenance mutation even though no life was consumed.
  const next = consumedReceipt || clearedExpiredReceipt ? withArena(state, arena) : state;
  return { state: next, arena, response, replayed: !consumedReceipt };
}

/** Claim the configured currency fallback after a run is out of lives or fully won. */
export function claimWarArenaScrapsState(
  state: PlayerProgressionState,
  now: number,
  heartDialogShown: boolean,
): ArenaMutationResult {
  const arena = warArenaStateFor(state);
  if (arena.runRewardClaimed && arena.lastRunRewardResponse) {
    return { state, arena, response: cloneResponse(arena.lastRunRewardResponse), replayed: true };
  }
  if (arena.lives > 0 && arena.wins < arenaPolicy().maxBattles) {
    throw new ApiError(ApiErrorCode.UnknownAction, "The current Arena run is not finished.");
  }

  const scraps = arenaPolicy().guaranteedScraps;
  arena.heartDialogShown ||= heartDialogShown;
  arena.runRewardClaimed = true;
  const response: Record<string, unknown> = {
    Scraps: scraps,
    ArenaLives: arena.lives,
    ArenaWins: arena.wins,
    TopRun: arena.topRun,
    Flawless: arena.flawless,
    GameReward: { Gold: 0, IsVip: false },
  };
  arena.lastRunRewardResponse = cloneResponse(response);
  return {
    // Claim state must persist even when an operator configures a zero-value fallback; otherwise
    // the same finished run remains perpetually claimable.
    state: withArena({ ...state, scraps: state.scraps + scraps }, arena),
    arena,
    response,
    replayed: false,
  };
}

/** Settle an expired monthly event and supply the next client configuration. */
export function endWarArenaState(
  state: PlayerProgressionState,
  now: number,
  requestedArenaId: string,
): ArenaMutationResult {
  const arena = warArenaStateFor(state);
  if (!requestedArenaId || requestedArenaId === currentArenaId(now)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "ArenaId is not an expired event.");
  }

  let scraps = 0;
  let settledExpiredRun = false;
  if (arena.arenaId === requestedArenaId && !arena.runRewardClaimed) {
    scraps = arenaPolicy().guaranteedScraps;
    arena.runRewardClaimed = true;
    settledExpiredRun = true;
  }
  const response: Record<string, unknown> = { NewArena: warArenaConfiguration(now) };
  if (scraps > 0) response.Scraps = scraps;
  return {
    // Settlement and reward amount are separate facts. A zero-value operator policy must still
    // persist runRewardClaimed, whereas a genuine replay must preserve state identity.
    state: settledExpiredRun ? withArena({ ...state, scraps: state.scraps + scraps }, arena) : state,
    arena,
    response,
    replayed: !settledExpiredRun,
  };
}

export async function enterWarArena(playerId: string, input: ArenaEntryInput): Promise<ArenaMutationResult> {
  return mutateProgression(playerId, (state, now) => enterWarArenaState(state, now, input));
}

export async function startWarArenaBattle(playerId: string, battleId: string): Promise<ArenaMutationResult> {
  return mutateProgression(playerId, (state, now) => startWarArenaBattleState(state, now, battleId));
}

export async function settleWarArenaBattle(playerId: string, input: ArenaSettlementInput): Promise<ArenaMutationResult> {
  return mutateProgression(playerId, (state, now) => settleWarArenaBattleState(state, now, input));
}

export async function buyWarArenaHeart(playerId: string, input: ArenaHeartInput): Promise<ArenaMutationResult> {
  return mutateProgression(playerId, (state, now) => buyWarArenaHeartState(state, now, input));
}

export async function takeWarArenaLife(playerId: string): Promise<ArenaMutationResult> {
  return mutateProgression(playerId, (state, now) => takeWarArenaLifeState(state, now));
}

export async function claimWarArenaScraps(
  playerId: string,
  heartDialogShown: boolean,
): Promise<ArenaMutationResult> {
  return mutateProgression(playerId, (state, now) => claimWarArenaScrapsState(state, now, heartDialogShown));
}

export async function endWarArena(playerId: string, arenaId: string): Promise<ArenaMutationResult> {
  return mutateProgression(playerId, (state, now) => endWarArenaState(state, now, arenaId));
}

export async function markWarArenaShown(playerId: string, arenaId: string): Promise<ArenaShownResult> {
  return mutateProgression(playerId, (state, now) => markWarArenaShownState(state, now, arenaId));
}
