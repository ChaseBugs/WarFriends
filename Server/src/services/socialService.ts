import { randomUUID } from "crypto";
import { messages, players, type PlayerDocument } from "../db";

// Player discovery + messaging (BACKEND.md §2.3 "Social / messaging / hit list"). Search
// and directory reads project players to the client's summary shape; messages are stored
// per-recipient in the `messages` collection.

export interface PlayerSummary {
  id: string;
  Name: string;
  Level: number;
  ArmyPower: number;
  LeagueId: string;
  SquadId: string;
}

function toSummary(doc: PlayerDocument): PlayerSummary {
  return {
    id: doc.id,
    Name: doc.player.accountName,
    Level: doc.player.level,
    ArmyPower: doc.player.armyPower,
    LeagueId: doc.player.leagueId,
    SquadId: doc.player.squadName,
  };
}

export async function searchPlayers(query: string, limit = 25): Promise<PlayerSummary[]> {
  const trimmed = query.trim();
  if (!trimmed) return [];
  // Anchored, case-insensitive prefix match on account name (escaped to a literal).
  const escaped = trimmed.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
  const docs = await players()
    .find({ accountName: { $regex: `^${escaped}`, $options: "i" } })
    .limit(limit)
    .toArray();
  return docs.map(toSummary);
}

export async function listPlayers(limit = 50): Promise<PlayerSummary[]> {
  const docs = await players().find().sort({ experience: -1 }).limit(limit).toArray();
  return docs.map(toSummary);
}

export interface MessageDoc {
  messageId: string;
  toPlayerId: string;
  fromPlayerId: string;
  fromName: string;
  body: string;
  read: boolean;
  createdAt: Date;
}

export async function sendMessage(fromPlayerId: string, fromName: string, toPlayerId: string, body: string): Promise<MessageDoc> {
  const doc: MessageDoc = {
    messageId: randomUUID(),
    toPlayerId,
    fromPlayerId,
    fromName,
    body: body.slice(0, 500),
    read: false,
    createdAt: new Date(),
  };
  await messages().insertOne(doc);
  return doc;
}

export async function inbox(playerId: string, limit = 50): Promise<MessageDoc[]> {
  const docs = await messages().find({ toPlayerId: playerId }).sort({ createdAt: -1 }).limit(limit).toArray();
  return docs as unknown as MessageDoc[];
}

export async function markRead(playerId: string, messageId: string): Promise<void> {
  await messages().updateOne({ messageId, toPlayerId: playerId }, { $set: { read: true } });
}
