import { config } from "../config";
import type { WarArenaState } from "../db";
import { integerNumberAttribute } from "./dynamoNumberAttributeService";

const MAX_CLIENT_INTEGER = 2_147_483_647;

export interface ArenaPolicy {
  readonly idPrefix: string;
  readonly maxBattles: number;
  readonly startingLives: number;
  readonly entryTickets: number;
  readonly entryGold: number;
  readonly heartTickets: number;
  readonly heartGold: number;
  readonly guaranteedScraps: number;
}

/** Require exact operator policy before it controls a client-visible price, cap, or reward. */
function configuredInteger(value: number, field: string, minimum: number, maximum = MAX_CLIENT_INTEGER): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`War Arena ${field} policy is invalid.`);
  }
  return value;
}

function configuredIdPrefix(value: string): string {
  // The monthly suffix occupies eight characters (`-YYYY-MM`) inside the stored 128-character
  // Arena identity. Restrict the deployment prefix to the same safe alphabet accepted by durable
  // Arena IDs so malformed configuration cannot publish an event that later fails state authority.
  if (typeof value !== "string" || value.length < 1 || value.length > 120
    || !/^[\w.:@+-]+$/.test(value)) {
    throw new Error("War Arena identity-prefix policy is invalid.");
  }
  return value;
}

function exactArenaPolicy(policy: ArenaPolicy): ArenaPolicy {
  return {
    idPrefix: configuredIdPrefix(policy.idPrefix),
    // IKPLPPFFDNI supports MaxBattles only from one through twelve. Reject an out-of-range
    // deployment rather than silently clamping it and storing lifecycle authority under a policy
    // different from the operator's reviewed configuration.
    maxBattles: configuredInteger(policy.maxBattles, "maximum-battles", 1, 12),
    startingLives: configuredInteger(policy.startingLives, "starting-lives", 1),
    entryTickets: configuredInteger(policy.entryTickets, "entry-Tickets", 0),
    entryGold: configuredInteger(policy.entryGold, "entry-Gold", 0),
    heartTickets: configuredInteger(policy.heartTickets, "heart-Tickets", 0),
    heartGold: configuredInteger(policy.heartGold, "heart-Gold", 0),
    guaranteedScraps: configuredInteger(policy.guaranteedScraps, "guaranteed-Scraps", 0),
  };
}

// A single Arena run consumes limits, prices, and fallback rewards over many requests. Resolve the
// complete operator policy before traffic starts so one process cannot change authority midway
// through a run because a mutable configuration object was re-read.
const CONFIGURED_ARENA_POLICY = Object.freeze(exactArenaPolicy({
  idPrefix: config.arenaIdPrefix,
  maxBattles: config.arenaMaxBattles,
  startingLives: config.arenaLives,
  entryTickets: config.arenaEntryTickets,
  entryGold: config.arenaEntryGold,
  heartTickets: config.arenaHeartTickets,
  heartGold: config.arenaHeartGold,
  guaranteedScraps: config.arenaGuaranteedScraps,
}));

export function arenaPolicy(policy?: ArenaPolicy): ArenaPolicy {
  return policy === undefined ? CONFIGURED_ARENA_POLICY : exactArenaPolicy(policy);
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

export function currentArenaId(now: number, policy?: ArenaPolicy): string {
  const values = arenaPolicy(policy);
  return `${values.idPrefix}-${monthBounds(now).suffix}`;
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
export function warArenaConfiguration(now: number, policy?: ArenaPolicy): ArenaConfiguration {
  const values = arenaPolicy(policy);
  const bounds = monthBounds(now);
  const result: ArenaConfiguration = {
    Id: { S: currentArenaId(now, values) },
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
