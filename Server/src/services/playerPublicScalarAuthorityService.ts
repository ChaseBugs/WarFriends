import type { DatabasePlayerDTO } from "../dtos";
import { playerLevelDefinition } from "./levelProgressionService";
import { validatedRenameCount } from "./playerRenameAuthorityService";
import { validatedVipExpiration } from "./vipEntitlementService";

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

/** Add a server-authored Reputation reward without overflowing DatabasePlayer's C# `int`. */
export function checkedPlayerReputationIncrement(current: number, increment: number): number {
  if (!Number.isSafeInteger(current)
    || current < 0
    || current > MAX_CLIENT_INT
    || !Number.isSafeInteger(increment)
    || increment < 0
    || increment > MAX_CLIENT_INT - current) {
    throw new Error("Player reputation increment is invalid.");
  }
  return current + increment;
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

  checkedPlayerReputationIncrement(player.reputation, 0);
  // DatabasePlayer.canPlayerSendLogs treats exactly one as enabled. Keeping this as a closed
  // integer Boolean prevents unknown operator/import values from becoming ambiguous consent.
  if (player.sendLogsValue !== 0 && player.sendLogsValue !== 1) {
    throw new Error("Stored player log consent is invalid.");
  }
  if (typeof player.awaitingSquadMember !== "boolean") {
    throw new Error("Stored awaiting-squad-member state is invalid.");
  }
  // RenameCount is private PlayerAnalytics data, but it lives inside the same durable DTO and its
  // signed shift/multiply result selects the next Gold debit. Prove it on every shared account
  // read so an unrelated heartbeat, device update, or gameplay write cannot carry malformed price
  // authority forward until the narrower rename or boot handler finally notices it.
  validatedRenameCount(player.renameCount);
  // Canonical accounts own VIP in progression, while imported accounts may still fall back to
  // DatabasePlayer.vipExpiration. Do not require those two generations to mirror one another, but
  // prove the dormant fallback as well: a valid progression deadline must not mask NaN/Infinity or
  // negative legacy authority until a later benefit happens to read it.
  validatedVipExpiration(player.vipExpiration);
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
