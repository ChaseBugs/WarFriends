import type { DatabasePlayerDTO } from "../dtos";
import { playerLevelDefinition } from "./levelProgressionService";

const MAX_CLIENT_INT = 2_147_483_647;
const WAR_ARENA_CROWN_TYPES = new Set(["", "bronze", "silver", "gold", "flawless"]);

/** Prove a Unix second fits the recovered client's signed C# `int` LastAction field. */
export function validatedPlayerLastAction(value: unknown): number {
  if (!Number.isSafeInteger(value)
    || Number(value) < 0
    || Number(value) > MAX_CLIENT_INT) {
    throw new Error("Stored player last-action time is invalid.");
  }
  return Number(value);
}

/**
 * Validate public DatabasePlayer scalars that are not duplicated in MongoDB root indexes.
 *
 * These values are parsed by the recovered client as C# `int` or direct Boolean/string fields.
 * Waiting until Dynamo-style serialization is too late: authenticated gameplay, squad cards,
 * presence, and notification selection may already have consumed the DTO. This boundary therefore
 * proves the source-backed level row and exact client-width shapes before any shared lookup returns.
 */
export function validatePlayerPublicScalarAuthority(player: DatabasePlayerDTO): void {
  // Almost every economy and gameplay selector consumes this zero-based source catalog index.
  // Reuse the same exact 4.9.5 row proof as settlement instead of maintaining a drifting bound.
  playerLevelDefinition(player.level);

  if (!Number.isSafeInteger(player.reputation)
    || player.reputation < 0
    || player.reputation > MAX_CLIENT_INT) {
    throw new Error("Stored player reputation is invalid.");
  }
  // DatabasePlayer.canPlayerSendLogs treats exactly one as enabled. Keeping this as a closed
  // integer Boolean prevents unknown operator/import values from becoming ambiguous consent.
  if (player.sendLogsValue !== 0 && player.sendLogsValue !== 1) {
    throw new Error("Stored player log consent is invalid.");
  }
  if (typeof player.awaitingSquadMember !== "boolean") {
    throw new Error("Stored awaiting-squad-member state is invalid.");
  }
  // `GetRealStatus` subtracts this recovered signed-int Unix second from server time. A negative,
  // fractional, non-finite, or wider value can keep a stale player online through overflow-like
  // JavaScript behavior even though the stock client could never represent the durable value.
  validatedPlayerLastAction(player.lastAction);

  // DatabasePlayer.warArenaCrown recognizes only these four exact source strings and uses the
  // paired signed-int Unix expiry. Unknown strings must not be retained as public live-event state;
  // an expired known crown may legitimately keep its original type and timestamp for history.
  if (typeof player.visualType !== "string"
    || !WAR_ARENA_CROWN_TYPES.has(player.visualType)
    || !Number.isSafeInteger(player.visualTimestamp)
    || player.visualTimestamp < 0
    || player.visualTimestamp > MAX_CLIENT_INT) {
    throw new Error("Stored player War Arena crown is invalid.");
  }
}
