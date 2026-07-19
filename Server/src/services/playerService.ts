import { players, type PlayerDocument } from "../db";
import type { DatabasePlayerDTO } from "../dtos";

// Data-access for the player document. The full client-facing snapshot lives in
// document.player (DatabasePlayerDTO); a few dimensions are denormalized to the top level
// for indexed lookup/matchmaking and kept in sync on every save.

export async function findById(id: string): Promise<PlayerDocument | null> {
  return players().findOne({ id });
}

export async function findByAuthToken(id: string, authToken: string): Promise<PlayerDocument | null> {
  return players().findOne({ id, authToken });
}

/** Best-effort attach for non-auth-required handlers: returns null instead of throwing. */
export async function findByIdOptional(id: string, authToken: string): Promise<PlayerDocument | null> {
  return players().findOne({ id, authToken });
}

export async function insertPlayer(doc: Omit<PlayerDocument, "createdAt" | "updatedAt">): Promise<PlayerDocument> {
  const now = new Date();
  const full: PlayerDocument = { ...doc, createdAt: now, updatedAt: now };
  await players().insertOne(full);
  return full;
}

/** Persist a mutated player snapshot, re-syncing the denormalized top-level fields. */
export async function savePlayer(id: string, player: DatabasePlayerDTO): Promise<void> {
  await players().updateOne(
    { id },
    {
      $set: {
        player,
        accountName: player.accountName,
        leagueTier: player.leagueTier,
        armyPower: player.armyPower,
        experience: player.experience,
        squadPoints: player.squadPoints,
        squadName: player.squadName,
        updatedAt: new Date(),
      },
    },
  );
}

/** Update only the supplied player fields so concurrent match/squad writes are not lost. */
export async function updatePlayerFields(id: string, fields: Partial<DatabasePlayerDTO>): Promise<void> {
  const set: Record<string, unknown> = { updatedAt: new Date() };
  for (const [key, value] of Object.entries(fields)) set[`player.${key}`] = value;

  if (fields.accountName !== undefined) set.accountName = fields.accountName;
  if (fields.leagueTier !== undefined) set.leagueTier = fields.leagueTier;
  if (fields.armyPower !== undefined) set.armyPower = fields.armyPower;
  if (fields.experience !== undefined) set.experience = fields.experience;
  if (fields.squadPoints !== undefined) set.squadPoints = fields.squadPoints;
  if (fields.squadName !== undefined) set.squadName = fields.squadName;
  if (fields.deviceToken !== undefined) set.deviceToken = fields.deviceToken;

  await players().updateOne({ id }, { $set: set });
}
