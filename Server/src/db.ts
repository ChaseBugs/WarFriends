import { MongoClient, type Collection, type Db, type Document } from "mongodb";
import { config } from "./config";
import type { DatabasePlayerDTO, SquadDTO } from "./dtos";

// One document per account. Top-level fields are indexed for lookup/matchmaking; the full
// client-facing snapshot lives in `player` (DatabasePlayerDTO), mirroring the reference
// backend's playerJson pattern.
export interface PlayerDocument {
  id: string;
  accountName: string;
  authToken: string;
  accountType: number;
  facebookId?: string;
  googlePlayId?: string;
  gameCenterId?: string;
  deviceToken?: string;
  // Indexed matchmaking + leaderboard dimensions (kept in sync with player on write).
  leagueTier: number;
  armyPower: number;
  experience: number;
  squadPoints: number;
  squadName: string;
  player: DatabasePlayerDTO;
  createdAt: Date;
  updatedAt: Date;
}

export interface SquadDocument extends SquadDTO {
  createdAt: Date;
  updatedAt: Date;
}

const client = new MongoClient(config.mongoUrl, { maxPoolSize: config.mongoPoolSize });

let db: Db | null = null;
let playersCollection: Collection<PlayerDocument> | null = null;
let squadsCollection: Collection<SquadDocument> | null = null;
let matchesCollection: Collection<Document> | null = null;
let messagesCollection: Collection<Document> | null = null;

export async function connectMongo(): Promise<void> {
  await client.connect();
  db = client.db(config.mongoDbName);

  playersCollection = db.collection<PlayerDocument>("players");
  squadsCollection = db.collection<SquadDocument>("squads");
  matchesCollection = db.collection("matches");
  messagesCollection = db.collection("messages");

  await playersCollection.createIndex({ id: 1 }, { unique: true });
  await playersCollection.createIndex({ authToken: 1 });
  await playersCollection.createIndex({ accountName: 1 });
  await playersCollection.createIndex({ facebookId: 1 }, { sparse: true });
  await playersCollection.createIndex({ googlePlayId: 1 }, { sparse: true });
  // Matchmaking scan: opponents near league + army power.
  await playersCollection.createIndex({ leagueTier: 1, armyPower: 1 });
  // Leaderboards.
  await playersCollection.createIndex({ experience: -1 });

  await squadsCollection.createIndex({ name: 1 }, { unique: true });
  await squadsCollection.createIndex({ experience: -1 });
  await squadsCollection.createIndex({ squadPoints: -1 });

  await matchesCollection.createIndex({ matchId: 1 }, { unique: true });
  await matchesCollection.createIndex({ "players.playerId": 1, createdAt: -1 });
  await messagesCollection.createIndex({ toPlayerId: 1, createdAt: -1 });
}

export async function disconnectMongo(): Promise<void> {
  await client.close();
  db = null;
  playersCollection = null;
  squadsCollection = null;
  matchesCollection = null;
  messagesCollection = null;
}

function requireCollection<T extends Document>(name: string, value: Collection<T> | null): Collection<T> {
  if (!value) throw new Error(`MongoDB collection ${name} is not connected.`);
  return value;
}

export function players(): Collection<PlayerDocument> {
  return requireCollection("players", playersCollection);
}

export function squads(): Collection<SquadDocument> {
  return requireCollection("squads", squadsCollection);
}

export function matches(): Collection<Document> {
  return requireCollection("matches", matchesCollection);
}

export function messages(): Collection<Document> {
  return requireCollection("messages", messagesCollection);
}
