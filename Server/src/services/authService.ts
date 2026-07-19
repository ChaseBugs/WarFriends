import { createHmac, randomBytes, randomUUID, timingSafeEqual } from "crypto";
import { config } from "../config";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import { newPlayer, type DatabasePlayerDTO } from "../dtos";
import { findById, insertPlayer } from "./playerService";
import type { PlayerDocument } from "../db";
import logger from "../utils/logger";

// Auth model (BACKEND.md §2.2): id + token credential. On CreateAccount the server mints a
// player id and an HMAC auth token derived from a server-side salt; the client stores both
// and replays them on LoginToCustomAccount. Social ids link onto the same player row.

function issueToken(playerId: string, salt: string): string {
  return createHmac("sha256", config.authSecret).update(`${playerId}:${salt}`).digest("hex");
}

function tokensMatch(a: string, b: string): boolean {
  const ba = Buffer.from(a);
  const bb = Buffer.from(b);
  return ba.length === bb.length && timingSafeEqual(ba, bb);
}

export interface CreatedAccount {
  doc: PlayerDocument;
  player: DatabasePlayerDTO;
  authToken: string;
}

export async function createCustomAccount(
  accountName: string,
  accountType: AccountType,
  deviceToken?: string,
): Promise<CreatedAccount> {
  const id = randomUUID();
  const salt = randomBytes(16).toString("hex");
  const authToken = issueToken(id, salt);

  const player = newPlayer(id, accountName || `Recruit-${id.slice(0, 6)}`, accountType);
  player.deviceToken = deviceToken ?? "";

  const doc = await insertPlayer({
    id,
    accountName: player.accountName,
    authToken,
    accountType,
    deviceToken,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
  });

  logger.auth.register(deviceToken ?? id, true, { playerId: id });
  logger.player.create(id, player.accountName);
  logger.auth.token("issued", { playerId: id });
  return { doc, player, authToken };
}

export async function authenticate(id: string | undefined, token: string | undefined): Promise<PlayerDocument> {
  if (!id || !token) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Missing credentials.");
  }
  const doc = await findById(id);
  if (!doc || !tokensMatch(doc.authToken, token)) {
    logger.auth.login(id, false);
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Invalid credentials.");
  }
  logger.auth.login(id, true, { playerId: id });
  return doc;
}
