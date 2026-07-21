import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { SquadRank } from "../constants";
import type { SquadDocument } from "../db";
import { newSquad } from "../dtos";
import { validatedSquadDocument } from "../services/squadAuthorityService";
import {
  applySquadExperienceState,
  MAX_SQUAD_LEVEL,
  MAX_SQUAD_ROSTER_SIZE,
  migrateLegacySquadExperienceState,
  squadLevelDefinition,
  validatedSquadProgressionSnapshot,
} from "../services/squadProgressionService";
import { buildDatabaseSquad } from "../services/squadWireService";

test("squad progression uses the exact first and final recovered 4.9.5 rows", () => {
  assert.deepEqual(squadLevelDefinition(1), {
    level: 1,
    experience: 120_000,
    size: 4,
    cardPoolSize: 3,
  });
  assert.equal(MAX_SQUAD_LEVEL, 50);
  assert.equal(MAX_SQUAD_ROSTER_SIZE, 60);
  assert.deepEqual(squadLevelDefinition(50), {
    level: 50,
    experience: 3_636_292_600,
    size: 60,
    cardPoolSize: 10,
  });
});

test("squad experience remains within the current rank below its threshold", () => {
  assert.deepEqual(applySquadExperienceState(1, 10, 4, 119_989), {
    levelFrom: 1,
    levelTo: 1,
    levelExperience: 119_999,
    maxMembers: 4,
    levelsGained: 0,
  });
});

test("squad experience subtracts each crossed threshold and unlocks source roster size", () => {
  assert.deepEqual(applySquadExperienceState(1, 0, 4, 120_000 + 122_000 + 124_100), {
    levelFrom: 1,
    levelTo: 4,
    levelExperience: 0,
    maxMembers: 8,
    levelsGained: 3,
  });
});

test("legacy migration rolls the old never-advanced counter without trusting its capacity", () => {
  assert.deepEqual(migrateLegacySquadExperienceState(1, 120_000 + 122_000 + 5), {
    levelFrom: 1,
    levelTo: 3,
    levelExperience: 5,
    maxMembers: 4,
    levelsGained: 2,
  });
});

test("final squad rank retains safe progress because there is no successor row", () => {
  assert.deepEqual(applySquadExperienceState(50, 3_000_000_000, 60, 1), {
    levelFrom: 50,
    levelTo: 50,
    levelExperience: 3_000_000_001,
    maxMembers: 60,
    levelsGained: 0,
  });
});

test("complete Squad authority preserves recovered 64-bit high-rank progress", () => {
  const now = new Date("2026-07-22T00:00:00.000Z");
  const squad: SquadDocument = {
    ...newSquad("High Rank", "founder"),
    level: 50,
    experience: 3_000_000_000,
    maxMembers: 60,
    members: [{
      playerId: "founder",
      name: "Founder",
      rank: SquadRank.Leader,
      squadPoints: 0,
      joinedAt: now.getTime(),
      lastSeenChatTimestamp: 0,
    }],
    createdAt: now,
    updatedAt: now,
  };
  assert.equal(validatedSquadDocument(squad, now), squad);
  assert.equal(buildDatabaseSquad(squad).LevelExperience, 3_000_000_000);
});

test("squad progression rejects normalized or inconsistent durable authority", () => {
  for (const operation of [
    () => squadLevelDefinition(0),
    () => squadLevelDefinition(1.5),
    () => squadLevelDefinition(Number.NaN),
    () => squadLevelDefinition(51),
    () => validatedSquadProgressionSnapshot(1, 120_000, 4),
    () => validatedSquadProgressionSnapshot(1, 0, 15),
    () => applySquadExperienceState(1, 0, 4, Number.POSITIVE_INFINITY),
  ]) {
    assert.throws(operation, (error: unknown) => (
      typeof error === "object"
      && error !== null
      && "code" in error
      && error.code === ApiErrorCode.InternalServerError
    ));
  }
});

test("new squads and the public wire expose source-backed rank-one progress", () => {
  const squad = newSquad("Alpha", "founder");
  assert.equal(squad.maxMembers, 4);
  const wire = buildDatabaseSquad(squad);
  assert.equal(wire.Level, 1);
  assert.equal(wire.Experience, 0);
  assert.equal(wire.LevelExperience, 0);

  squad.experience = 42;
  const progressedWire = buildDatabaseSquad(squad);
  assert.equal(progressedWire.Experience, 0);
  assert.equal(progressedWire.LevelExperience, 42);
});
