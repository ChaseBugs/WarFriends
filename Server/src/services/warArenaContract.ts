import { config } from "../config";
import type { WarArenaState } from "../db";
import { integerNumberAttribute } from "./dynamoNumberAttributeService";

export interface ArenaPolicy {
  maxBattles: number;
  startingLives: number;
  entryTickets: number;
  entryGold: number;
  heartTickets: number;
  heartGold: number;
  guaranteedScraps: number;
}

function nonNegative(value: number, fallback: number): number {
  return Number.isFinite(value) ? Math.max(0, Math.floor(value)) : fallback;
}

export function arenaPolicy(): ArenaPolicy {
  return {
    // IKPLPPFFDNI clamps MaxBattles to a client-supported range of one through twelve.
    maxBattles: Math.min(12, Math.max(1, nonNegative(config.arenaMaxBattles, 12))),
    startingLives: Math.max(1, nonNegative(config.arenaLives, 3)),
    entryTickets: nonNegative(config.arenaEntryTickets, 1),
    entryGold: nonNegative(config.arenaEntryGold, 30),
    heartTickets: nonNegative(config.arenaHeartTickets, 1),
    heartGold: nonNegative(config.arenaHeartGold, 30),
    guaranteedScraps: nonNegative(config.arenaGuaranteedScraps, 10),
  };
}

/** Return the exact public WarArena.WarArenaData JSON shape and no server-only receipts. */
export function warArenaWireData(value: WarArenaState): Record<string, unknown> {
  return {
    wins: value.wins,
    lives: value.lives,
    opponents: [...value.opponents],
    arenaId: value.arenaId,
    runs: value.runs,
    visualType: value.visualType,
    visualTimestamp: value.visualTimestamp,
    flawless: value.flawless,
    topRun: value.topRun,
    matches: value.matches,
    shields: value.shields,
    played: value.played,
    heartDialogShown: value.heartDialogShown,
  };
}

export function serializeWarArenaData(value: WarArenaState): string {
  return JSON.stringify(warArenaWireData(value));
}

function monthBounds(now: number): { start: number; end: number; suffix: string } {
  // Arena IDs and windows are server time authority. Invalid time used to flow through Date as
  // NaN and produce a superficially shaped `prefix-NaN-NaN` event plus invalid N attributes.
  if (!Number.isSafeInteger(now) || now < 0 || now > 2_147_483_647) {
    throw new Error("War Arena configuration time authority is invalid.");
  }
  const date = new Date(Math.floor(now) * 1_000);
  const year = date.getUTCFullYear();
  const month = date.getUTCMonth();
  const start = Math.floor(Date.UTC(year, month, 1) / 1_000);
  const end = Math.floor(Date.UTC(year, month + 1, 1) / 1_000) - 1;
  return { start, end, suffix: `${year}-${String(month + 1).padStart(2, "0")}` };
}

export function currentArenaId(now: number): string {
  return `${config.arenaIdPrefix}-${monthBounds(now).suffix}`;
}

type DynamoString = { S: string };
type DynamoNumber = { N: string };
export type ArenaConfiguration = Record<string, DynamoString | DynamoNumber>;

/**
 * Build the DynamoDB-style live document consumed by IKPLPPFFDNI(JToken).
 *
 * Login/GetPlayerData must include this object as `WarArenaConfig`; without it the stock
 * client logs "NO WAR ARENA CONFIG" and cannot open the feature. The retired service's
 * prices and loot tables are not archived. This reconstruction therefore emits an explicit
 * monthly event using environment-owned prices while preserving every recovered field name.
 */
export function warArenaConfiguration(now: number): ArenaConfiguration {
  const values = arenaPolicy();
  const bounds = monthBounds(now);
  const result: ArenaConfiguration = {
    Id: { S: currentArenaId(now) },
    // WarArena.LEBPNELDIEG immediately deserializes and enumerates this string. An empty
    // string becomes null in Json.NET and crashes its foreach; an empty JSON object means
    // "no special Arena rules" and is the smallest safe recovered-client value.
    Rules: { S: "{}" },
    ExtraLifeEnabled: { N: "1" },
    LifeCount: integerNumberAttribute(values.startingLives),
    PauseDuration: { N: "0" },
    PlayWindowCount: { N: "1" },
    MaxBattles: integerNumberAttribute(values.maxBattles),
    GuaranteedScraps: integerNumberAttribute(values.guaranteedScraps),
    StartTime: integerNumberAttribute(bounds.start),
    // IKPLPPFFDNI treats WindowDuration as minutes and derives EndTime from its final window.
    WindowDuration: integerNumberAttribute(Math.ceil((bounds.end - bounds.start + 1) / 60)),
    ArenaPrice: { S: Array(values.maxBattles).fill(values.entryTickets).join(",") },
  };
  for (let index = 1; index <= values.maxBattles; index += 1) {
    result[`HeartPrice${index}`] = integerNumberAttribute(values.heartTickets);
  }
  return result;
}
