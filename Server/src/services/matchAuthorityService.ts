import { ApiError, ApiErrorCode } from "../apiErrors";
import { League } from "../constants";
import { MAX_PVP_CARDS_PER_MATCH, parsePvpUsedCards } from "./cardInventoryService";
import { PLAYER_LEVELS } from "./levelProgressionService";
import { validatedPlayerLeagueRemainingMatches } from "./playerLeagueContract";
import { validatedPvpWinStreak } from "./pvpWinStreakAuthorityService";
import type { MatchDoc, MatchPlayerReward } from "./matchService";

const MAX_CLIENT_INTEGER = 2_147_483_647;
const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const MATCH_ID_PATTERN = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/;
const HASH_PATTERN = /^[0-9a-f]{64}$/;
const MATCH_KEYS = new Set([
  "_id", "matchId", "coordinatorId", "joinedPlayerIds", "roomStartedAt", "disconnectedAt",
  "players", "state", "winnerId", "resultReports", "usedCardsReports", "relayedCardPlays",
  "relayedCardDeliveries", "rewardReceipts", "squadEventProjection", "squadWarProjection",
  "createdAt", "endedAt", "cancelReason",
]);
const PLAYER_KEYS = new Set(["playerId", "name", "armyPower", "leagueTier"]);
const REWARD_KEYS = new Set([
  "baseWarBucks", "warBucks", "baseWinStreakWarBucks", "winStreakWarBucks", "winCount",
  "winStreakTimestamp", "baseLeagueWarBucks", "leagueWarBucks", "squadPoints", "skill",
  "medalsBalance", "placementMatchesRequired", "beginnersLeague", "enteredLeague",
  "enteredNormalLeague", "leagueEvaluation", "baseExperience", "experience", "baseGold", "gold",
  "isVip", "matchesToNextLootboxes", "newVisuals", "lootboxWarBucks", "levelFrom", "levelTo",
  "levelExperience", "rentalSettled", "rental",
]);
const RENTAL_KEYS = new Set(["Id", "Amount", "Type", "nextGenerate", "accepted"]);
const EVENT_KEYS = new Set(["eventId", "configHash", "participants"]);
const PROJECTION_PARTICIPANT_KEYS = new Set(["playerId", "squadId", "status"]);
const EVENT_STATUSES = new Set([
  "not_joined", "not_member", "unchanged", "updated", "config_mismatch", "invalid_progress",
]);
const WAR_STATUSES = new Set([
  "recorded", "disabled", "no_squad", "not_member", "no_active_round", "outside_round", "no_points",
]);

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value) && !(value instanceof Date);
}

function knownKeys(value: Record<string, unknown>, allowed: ReadonlySet<string>): boolean {
  return Object.keys(value).every((key) => allowed.has(key));
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function canonicalText(value: unknown, minimum: number, maximum: number): value is string {
  return typeof value === "string"
    && value.length >= minimum
    && value.length <= maximum
    && !/\p{Cc}/u.test(value)
    && value.trim() === value;
}

function safeClientInteger(value: unknown, minimum = 0): value is number {
  return Number.isSafeInteger(value) && (value as number) >= minimum && (value as number) <= MAX_CLIENT_INTEGER;
}

function validateParticipantMap(
  value: unknown,
  participantIds: ReadonlySet<string>,
  validateValue: (child: unknown, playerId: string) => void,
  label: string,
): void {
  if (value === undefined) return;
  if (!plainRecord(value)) invalid(`Stored match ${label} is invalid.`);
  for (const [playerId, child] of Object.entries(value)) {
    if (!participantIds.has(playerId)) invalid(`Stored match ${label} contains a non-participant.`);
    validateValue(child, playerId);
  }
}

function validateCardList(value: unknown): void {
  try {
    parsePvpUsedCards(value);
  } catch {
    invalid("Stored match card evidence is invalid.");
  }
}

function validateNewVisuals(value: string): void {
  if (value.length < 2 || value.length > 4_096) invalid("Stored match visual receipt is invalid.");
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    invalid("Stored match visual receipt is invalid.");
  }
  if (!plainRecord(parsed)
    || Object.keys(parsed).length < 1
    || Object.keys(parsed).length > 2
    || Object.entries(parsed).some(([key, amount]) => !canonicalText(key, 1, 256) || amount !== "1")) {
    invalid("Stored match visual receipt is invalid.");
  }
}

function validateRentalReceipt(value: unknown): void {
  if (!plainRecord(value)
    || Object.keys(value).length !== RENTAL_KEYS.size
    || !knownKeys(value, RENTAL_KEYS)
    || !canonicalText(value.Id, 1, 256)
    || (value.Type !== 0 && value.Type !== 1)
    || typeof value.Amount !== "string"
    || !/^(20|21|22|23|24|25)$/.test(value.Amount)
    || typeof value.nextGenerate !== "string"
    || !/^[1-9][0-9]{0,12}$/.test(value.nextGenerate)
    || !Number.isSafeInteger(Number(value.nextGenerate))
    || Number(value.nextGenerate) > MAX_DATE_UNIX_SECONDS
    || value.accepted !== 3) {
    invalid("Stored match rental receipt is invalid.");
  }
}

function multiplied(base: number, vip: boolean, multiplier: number): number {
  return vip ? Math.trunc(base * multiplier) : base;
}

function validateReward(reward: MatchPlayerReward, endedAt: Date): void {
  const raw = reward as unknown as Record<string, unknown>;
  const integerFields: Array<keyof MatchPlayerReward> = [
    "baseWarBucks", "warBucks", "baseWinStreakWarBucks", "winStreakWarBucks",
    "baseLeagueWarBucks", "leagueWarBucks", "squadPoints", "skill", "medalsBalance",
    "baseExperience", "experience", "baseGold", "gold", "lootboxWarBucks", "levelExperience",
  ];
  if (!plainRecord(reward)
    || !knownKeys(raw, REWARD_KEYS)
    || integerFields.some((field) => !safeClientInteger(reward[field]))
    || typeof reward.isVip !== "boolean"
    || reward.warBucks !== multiplied(reward.baseWarBucks, reward.isVip, 1.5)
    || reward.winStreakWarBucks !== multiplied(reward.baseWinStreakWarBucks, reward.isVip, 1.5)
    || reward.leagueWarBucks !== multiplied(reward.baseLeagueWarBucks, reward.isVip, 1.5)
    || reward.experience !== multiplied(reward.baseExperience, reward.isVip, 1.5)
    || reward.gold !== multiplied(reward.baseGold, reward.isVip, 2)
    || !safeClientInteger(reward.beginnersLeague)
    || reward.beginnersLeague > 3
    || !safeClientInteger(reward.levelFrom)
    || !safeClientInteger(reward.levelTo)
    || reward.levelFrom >= PLAYER_LEVELS.length
    || reward.levelTo >= PLAYER_LEVELS.length
    || reward.levelTo < reward.levelFrom
    || (reward.levelTo === reward.levelFrom && (reward.baseGold !== 0 || reward.gold !== 0))
    || !Number.isSafeInteger(reward.matchesToNextLootboxes)
    || reward.matchesToNextLootboxes < 1
    || reward.matchesToNextLootboxes > 4
    // Absence is the existing, explicit migration signal for matches finalized before rental
    // settlement moved into the terminal transaction. False or any other value is not authority.
    || (reward.rentalSettled !== true && reward.rentalSettled !== undefined)) {
    invalid("Stored match reward receipt is invalid.");
  }
  try {
    validatedPlayerLeagueRemainingMatches(reward.placementMatchesRequired);
    validatedPvpWinStreak(
      { winCount: reward.winCount, timestamp: reward.winStreakTimestamp },
      Math.floor(endedAt.getTime() / 1_000),
    );
  } catch {
    invalid("Stored match reward league or streak receipt is invalid.");
  }

  const entered = reward.enteredLeague !== undefined
    || reward.enteredNormalLeague !== undefined
    || reward.leagueEvaluation !== undefined;
  if (entered && (!canonicalText(reward.enteredLeague, 1, 128)
    || reward.enteredNormalLeague !== true
    || !safeClientInteger(reward.leagueEvaluation, 1))) {
    invalid("Stored match league-entry receipt is invalid.");
  }
  if (reward.newVisuals !== undefined) {
    if (typeof reward.newVisuals !== "string") invalid("Stored match visual receipt is invalid.");
    validateNewVisuals(reward.newVisuals);
  }
  if (reward.rental !== undefined) {
    if (reward.rentalSettled !== true) invalid("Stored match rental receipt is missing its marker.");
    validateRentalReceipt(reward.rental);
  }
}

function validateProjectionParticipants(
  value: unknown,
  participantIds: ReadonlySet<string>,
  statuses: ReadonlySet<string>,
  label: string,
): void {
  if (!Array.isArray(value) || value.length !== participantIds.size) {
    invalid(`Stored match ${label} projection is invalid.`);
  }
  const seen = new Set<string>();
  for (const participant of value) {
    const raw = participant as Record<string, unknown>;
    if (!plainRecord(participant)
      || Object.keys(raw).length !== PROJECTION_PARTICIPANT_KEYS.size
      || !knownKeys(raw, PROJECTION_PARTICIPANT_KEYS)
      || !canonicalText(participant.playerId, 1, 128)
      || !participantIds.has(participant.playerId)
      || seen.has(participant.playerId)
      || !canonicalText(participant.squadId, 0, 24)
      || typeof participant.status !== "string"
      || !statuses.has(participant.status)) {
      invalid(`Stored match ${label} projection is invalid.`);
    }
    seen.add(participant.playerId);
  }
}

/**
 * Prove the complete ranked-match state machine before the row can authorize room admission,
 * disconnect forfeits, relayed card consumption, result consensus, moderation evidence, or reward
 * replay. Dynamic participant-keyed maps are restricted to the immutable two-player roster; player
 * IDs containing MongoDB path syntax are rejected because they cannot safely own `$set` subpaths.
 */
export function validatedMatchDocument(match: MatchDoc, now = new Date()): MatchDoc {
  const raw = match as unknown as Record<string, unknown>;
  if (!plainRecord(match)
    || !knownKeys(raw, MATCH_KEYS)
    || !MATCH_ID_PATTERN.test(match.matchId)
    || (match.coordinatorId !== undefined && !canonicalText(match.coordinatorId, 1, 128))
    || !Array.isArray(match.players)
    || match.players.length !== 2
    || !["active", "settling", "finished", "cancelled"].includes(match.state)
    || !safeDate(match.createdAt)
    || !safeDate(now)
    || match.createdAt.getTime() > now.getTime()) {
    invalid("Stored ranked-match authority is invalid.");
  }

  const participantIds = new Set<string>();
  for (const participant of match.players) {
    const participantRaw = participant as unknown as Record<string, unknown>;
    if (!plainRecord(participant)
      || Object.keys(participantRaw).length !== PLAYER_KEYS.size
      || !knownKeys(participantRaw, PLAYER_KEYS)
      || !canonicalText(participant.playerId, 1, 128)
      || /[.$]/u.test(participant.playerId)
      || participantIds.has(participant.playerId)
      || !canonicalText(participant.name, 1, 64)
      || !Number.isFinite(participant.armyPower)
      || participant.armyPower < 0
      || participant.armyPower > MAX_CLIENT_INTEGER
      || !Number.isSafeInteger(participant.leagueTier)
      || participant.leagueTier < League.NoLeague
      || participant.leagueTier > League.Champion) {
      invalid("Stored ranked-match participant authority is invalid.");
    }
    participantIds.add(participant.playerId);
  }

  if (match.joinedPlayerIds !== undefined) {
    if (!Array.isArray(match.joinedPlayerIds)
      || match.joinedPlayerIds.length > participantIds.size
      || new Set(match.joinedPlayerIds).size !== match.joinedPlayerIds.length
      || match.joinedPlayerIds.some((id) => !participantIds.has(id))) {
      invalid("Stored match room-admission authority is invalid.");
    }
  }
  const allJoined = match.joinedPlayerIds?.length === participantIds.size;
  if (match.roomStartedAt !== undefined && (!safeDate(match.roomStartedAt)
    || match.roomStartedAt.getTime() < match.createdAt.getTime()
    || match.roomStartedAt.getTime() > now.getTime()
    || !allJoined)) {
    invalid("Stored match room-start authority is invalid.");
  }

  validateParticipantMap(match.disconnectedAt, participantIds, (value) => {
    if (!safeDate(value)
      || !match.roomStartedAt
      || value.getTime() < match.roomStartedAt.getTime()
      || value.getTime() > now.getTime()) {
      invalid("Stored match disconnect authority is invalid.");
    }
  }, "disconnect");
  validateParticipantMap(match.resultReports, participantIds, (value) => {
    if (typeof value !== "string" || !participantIds.has(value)) {
      invalid("Stored match result report is invalid.");
    }
  }, "result report");
  validateParticipantMap(match.usedCardsReports, participantIds, validateCardList, "used-card report");
  validateParticipantMap(match.relayedCardPlays, participantIds, validateCardList, "relayed-card evidence");
  validateParticipantMap(match.relayedCardDeliveries, participantIds, (value, playerId) => {
    const cards = match.relayedCardPlays?.[playerId] ?? [];
    if (!Array.isArray(value)
      || value.length > MAX_PVP_CARDS_PER_MATCH
      || new Set(value).size !== value.length
      || value.some((sequence) => !Number.isSafeInteger(sequence) || sequence < 0 || sequence >= cards.length)) {
      invalid("Stored match card-delivery evidence is invalid.");
    }
  }, "relayed-card delivery");

  const terminal = match.state === "finished" || match.state === "cancelled";
  if (terminal) {
    if (!safeDate(match.endedAt)
      || match.endedAt.getTime() < match.createdAt.getTime()
      || (match.roomStartedAt && match.endedAt.getTime() < match.roomStartedAt.getTime())
      || match.endedAt.getTime() > now.getTime()) {
      invalid("Stored match terminal timestamp is invalid.");
    }
  } else if (match.endedAt !== undefined || match.cancelReason !== undefined
    || match.winnerId !== undefined || match.rewardReceipts !== undefined
    || match.squadEventProjection !== undefined || match.squadWarProjection !== undefined) {
    invalid("Stored active match contains terminal authority.");
  }

  if (match.state === "cancelled") {
    if (!canonicalText(match.cancelReason, 1, 64)
      || !/^[a-z0-9][a-z0-9_:-]{0,63}$/u.test(match.cancelReason)
      || match.winnerId !== undefined
      || match.rewardReceipts !== undefined
      || match.squadEventProjection !== undefined
      || match.squadWarProjection !== undefined) {
      invalid("Stored cancelled-match authority is invalid.");
    }
  }

  if (match.state === "finished") {
    if (typeof match.winnerId !== "string"
      || !participantIds.has(match.winnerId)
      || !plainRecord(match.rewardReceipts)
      || Object.keys(match.rewardReceipts).length !== participantIds.size
      || Object.keys(match.rewardReceipts).some((playerId) => !participantIds.has(playerId))
      || match.cancelReason !== undefined) {
      invalid("Stored finished-match authority is invalid.");
    }
    for (const reward of Object.values(match.rewardReceipts)) validateReward(reward, match.endedAt!);
    if (match.resultReports
      && Object.values(match.resultReports).some((reportedWinner) => reportedWinner !== match.winnerId)) {
      invalid("Stored finished match conflicts with its authenticated result reports.");
    }
    if (match.squadEventProjection !== undefined) {
      const projection = match.squadEventProjection as unknown as Record<string, unknown>;
      if (!plainRecord(match.squadEventProjection)
        || Object.keys(projection).length !== EVENT_KEYS.size
        || !knownKeys(projection, EVENT_KEYS)
        || !canonicalText(match.squadEventProjection.eventId, 1, 128)
        || !/^[A-Za-z0-9_.:-]{1,128}$/.test(match.squadEventProjection.eventId)
        || !HASH_PATTERN.test(match.squadEventProjection.configHash)) {
        invalid("Stored match Squad Event projection is invalid.");
      }
      validateProjectionParticipants(
        match.squadEventProjection.participants,
        participantIds,
        EVENT_STATUSES,
        "Squad Event",
      );
    }
    if (match.squadWarProjection !== undefined) {
      validateProjectionParticipants(match.squadWarProjection, participantIds, WAR_STATUSES, "Squad War");
    }
  }
  return match;
}
