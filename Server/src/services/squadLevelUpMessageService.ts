import type { ClientSession } from "mongodb";
import { messages, type SquadDocument } from "../db";
import { validatedInboxMessageDocument } from "./inboxMessageAuthorityService";
import type { InboxFanoutReference } from "./inboxFanoutService";
import type { MessageDoc } from "./socialService";
import { MAX_SQUAD_LEVEL } from "./squadProgressionService";

function invalid(message: string): never {
  throw new Error(message);
}

/**
 * Build the complete recovered type-10 inbox batch for one committed Squad rank transition.
 *
 * The client payload contains no reward and no sender. `Level` is deliberately the prior rank:
 * KGALJDLJCEH.HDCCFKAHHOP adds one before calling SetAppearance_SquadLevelUp. A separate row per
 * crossed rank preserves every intermediate roster/card-pool/emblem unlock if a future
 * server-authored grant crosses more than one threshold. The authoritative match UUID, recipient,
 * and reached rank form the retry identity; including the match generation prevents a deleted and
 * recreated Squad with the same name from colliding with an older durable row.
 */
export function buildSquadLevelUpMessages(
  squad: Pick<SquadDocument, "name" | "members">,
  levelFrom: number,
  levelTo: number,
  createdAt: Date,
  sourceBattleId: string,
): MessageDoc[] {
  if (!squad
    || typeof squad.name !== "string"
    || squad.name.length < 1
    || squad.name.length > 24
    || squad.name.trim() !== squad.name
    || !Array.isArray(squad.members)
    || !Number.isSafeInteger(levelFrom)
    || !Number.isSafeInteger(levelTo)
    || levelFrom < 1
    || levelTo < levelFrom
    || levelTo > MAX_SQUAD_LEVEL
    || !/^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/u.test(sourceBattleId)
    || !(createdAt instanceof Date)
    || !Number.isSafeInteger(createdAt.getTime())
    || createdAt.getTime() <= 0) {
    return invalid("Squad level-up notification input is invalid.");
  }
  const unixSeconds = Math.floor(createdAt.getTime() / 1_000);
  if (unixSeconds < 1 || unixSeconds > 2_147_483_647) {
    return invalid("Squad level-up notification time is outside the recovered client range.");
  }

  const result: MessageDoc[] = [];
  const recipientIds = new Set<string>();
  for (const member of squad.members) {
    if (!member
      || typeof member.playerId !== "string"
      || member.playerId.length < 1
      || member.playerId.length > 160
      || member.playerId.trim() !== member.playerId
      || /\p{Cc}/u.test(member.playerId)
      || recipientIds.has(member.playerId)) {
      return invalid("Squad level-up notification roster is invalid.");
    }
    recipientIds.add(member.playerId);
  }

  for (let reachedLevel = levelFrom + 1; reachedLevel <= levelTo; reachedLevel += 1) {
    for (const recipientPlayerId of recipientIds) {
      const message: MessageDoc = {
        // The authoritative match UUID prevents a deleted/recreated Squad with the same name from
        // colliding with an older generation's globally unique message or idempotency key.
        messageId: `SquadLevelUp-${sourceBattleId}-${reachedLevel}-${unixSeconds}`,
        idempotencyKey:
          `squad-level-up:${sourceBattleId}:${squad.name}:${reachedLevel}:${recipientPlayerId}`,
        toPlayerId: recipientPlayerId,
        // Type 10 has no sender on the wire. Keep an explicit server-owned audit identity rather
        // than attributing the Squad transition to a client or whichever member won the match.
        fromPlayerId: `squad:${squad.name}`,
        fromName: squad.name,
        body: "Your squad reached a new level.",
        messageType: 10,
        payload: { Level: reachedLevel - 1, SquadId: squad.name },
        otherPlayerJson: "",
        read: false,
        ignored: false,
        accepted: false,
        createdAt,
      };
      result.push(validatedInboxMessageDocument(message, createdAt));
    }
  }
  return result;
}

/** Insert the batch inside the caller's match transaction and return only post-commit hints. */
export async function insertSquadLevelUpMessages(
  session: ClientSession,
  squad: Pick<SquadDocument, "name" | "members">,
  levelFrom: number,
  levelTo: number,
  createdAt: Date,
  sourceBattleId: string,
): Promise<InboxFanoutReference[]> {
  const batch = buildSquadLevelUpMessages(
    squad,
    levelFrom,
    levelTo,
    createdAt,
    sourceBattleId,
  );
  if (batch.length === 0) return [];
  await messages().insertMany(batch, { session, ordered: true });
  return batch.map((message) => ({
    recipientPlayerId: message.toPlayerId,
    messageId: message.messageId,
  }));
}
