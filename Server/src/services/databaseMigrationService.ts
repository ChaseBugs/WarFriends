import { randomUUID } from "crypto";
import type { Db, Document } from "mongodb";
import { mongoDatabase } from "../db";
import type { PlayerDocument, PlayerProgressionState } from "../db";
import logger from "../utils/logger";
import { migrateLegacySquadExperienceState } from "./squadProgressionService";
import { progressionForPlayer } from "./playerStateService";
import { SquadRank } from "../constants";
import { nextSquadUpdatedAt, validatedSquadDocument } from "./squadAuthorityService";
import type { SquadDocument } from "../db";

/**
 * Versioned database migrations for rolling deployments.
 *
 * Every migration must be safe to run again. MongoDB can acknowledge the schema/index change and
 * the process can still terminate before its receipt is inserted; the next process then executes
 * `up` again. MongoDB index creation and the bounded update operations used here are idempotent.
 * Never edit an applied migration. Add a new ordered entry with a new checksum instead.
 */
export interface DatabaseMigration {
  id: string;
  checksum: string;
  description: string;
  up: (db: Db) => Promise<void>;
}

export interface AppliedMigration {
  id: string;
  checksum: string;
}

const migrations: readonly DatabaseMigration[] = [
  {
    id: "20260721_001_match_lifecycle_indexes",
    // This is a manifest checksum, not a runtime hash. Changing the implementation requires a new
    // migration ID/checksum so an older database can never silently receive different logic.
    checksum: "sha256:0f6be24933201c1b4e7ed2d963dff6506e7e2b5dc7fb4f4f9cce49b184703536",
    description: "Index active match recovery and player presence repair scans.",
    up: async (db) => {
      await db.collection("matches").createIndex(
        { state: 1, createdAt: 1 },
        { name: "match_lifecycle_recovery" },
      );
      await db.collection("players").createIndex(
        { "player.status": 1, updatedAt: 1 },
        { name: "player_presence_repair" },
      );
    },
  },
  {
    id: "20260721_002_match_coordinator_recovery",
    checksum: "sha256:b10f9465ea19a752e5ff340f7254e542b70332828370472077c171e03ea5341e",
    description: "Index coordinator-owned active match recovery scans.",
    up: async (db) => {
      await db.collection("matches").createIndex(
        { state: 1, coordinatorId: 1, createdAt: 1 },
        { name: "match_coordinator_recovery" },
      );
    },
  },
  {
    id: "20260722_003_client_analytics_retention",
    checksum: "sha256:d1e2397667739c09ed69c39e052975d30ffb88cf3fe02abe26ef5f72df7b3f94",
    description: "Index bounded client analytics inspection and TTL retention.",
    up: async (db) => {
      await db.collection("clientAnalyticsEvents").createIndex(
        { playerId: 1, receivedAt: -1 },
        { name: "client_analytics_player_time" },
      );
      await db.collection("clientAnalyticsEvents").createIndex(
        { expiresAt: 1 },
        { name: "client_analytics_expiry", expireAfterSeconds: 0 },
      );
    },
  },
  {
    id: "20260722_004_client_support_log_retention",
    checksum: "sha256:8b8d7d88eea1d93c1285719823284261b52c7d6a81dcff4e35b0c8e10e7f7d44",
    description: "Index player support-log lookup and TTL retention.",
    up: async (db) => {
      await db.collection("clientLogEntries").createIndex(
        { playerId: 1, receivedAt: -1 },
        { name: "client_log_player_time" },
      );
      await db.collection("clientLogEntries").createIndex(
        { expiresAt: 1 },
        { name: "client_log_expiry", expireAfterSeconds: 0 },
      );
    },
  },
  {
    id: "20260722_005_client_error_retention",
    checksum: "sha256:74feecf38e2cbd370e075869bf48d44e47ecfd52c220342902aada53cc3e1f15",
    description: "Index bounded client error inspection and TTL retention.",
    up: async (db) => {
      await db.collection("clientErrorEvents").createIndex(
        { playerId: 1, receivedAt: -1 },
        { name: "client_error_player_time" },
      );
      await db.collection("clientErrorEvents").createIndex(
        { expiresAt: 1 },
        { name: "client_error_expiry", expireAfterSeconds: 0 },
      );
    },
  },
  {
    id: "20260722_006_admin_diagnostic_read_indexes",
    checksum: "sha256:295a9a1e51e0c942991f6d4ec8b27e3a9bce29cb861463aab58e3be7c093cf95",
    description: "Index stable global and per-player diagnostic administration pages.",
    up: async (db) => {
      for (const [collectionName, prefix] of [
        ["clientAnalyticsEvents", "client_analytics"],
        ["clientLogEntries", "client_log"],
        ["clientErrorEvents", "client_error"],
      ] as const) {
        await db.collection(collectionName).createIndex(
          { receivedAt: -1, _id: -1 },
          { name: `${prefix}_admin_time` },
        );
        await db.collection(collectionName).createIndex(
          { playerId: 1, receivedAt: -1, _id: -1 },
          { name: `${prefix}_admin_player_time` },
        );
      }
    },
  },
  {
    id: "20260722_007_admin_replay_video_indexes",
    checksum: "sha256:7cf7eaf54ef9679fe61ec8bda5c211d055266dfa49b75baf8795c473f2977f71",
    description: "Index stable global and per-player replay-video administration pages.",
    up: async (db) => {
      await db.collection("videoFeed").createIndex(
        { createdAt: -1, videoId: -1 },
        { name: "video_feed_admin_time" },
      );
      await db.collection("videoFeed").createIndex(
        { playerId: 1, createdAt: -1, videoId: -1 },
        { name: "video_feed_admin_player_time" },
      );
    },
  },
  {
    id: "20260722_008_current_arena_leaderboard_index",
    checksum: "sha256:fa929652c94c4ab61a2e64498924ecf352bbb64219888d0d5b24a87bed7962e1",
    description: "Index current-event War Arena leaderboard admission.",
    up: async (db) => {
      // Ranking uses conditional recovered comparison keys and therefore completes in the
      // aggregation pipeline. This prefix index first limits that work to one exact monthly event.
      await db.collection("players").createIndex(
        { "progression.warArena.arenaId": 1, "progression.warArena.played": 1 },
        { name: "war_arena_current_event_players" },
      );
    },
  },
  {
    id: "20260722_009_stable_experience_leaderboard_indexes",
    checksum: "sha256:15cc19cb52ddd2cb6a5c2cdacb02eb67f2d05058438072cb24210a5725140fe1",
    description: "Index deterministic global and country experience leaderboards.",
    up: async (db) => {
      await db.collection("players").createIndex(
        { experience: -1, id: 1 },
        { name: "player_experience_stable" },
      );
      await db.collection("players").createIndex(
        { "player.country": 1, experience: -1, id: 1 },
        { name: "player_country_experience_stable" },
      );
    },
  },
  {
    id: "20260722_010_stable_squad_skill_leaderboard_index",
    checksum: "sha256:4cedefe437523fa92f72f2b1c6f194233848ce2d4ab4018493b9d85a0ae2e508",
    description: "Index deterministic Squad skill leaderboard admission.",
    up: async (db) => {
      // The recovered action name mentions experience, but Unity ranks the selected page by the
      // wire `Skill` value. The server maps Skill from squadPoints, so this compound index keeps
      // admission and deterministic name ties aligned with the actual client-visible board.
      await db.collection("squads").createIndex(
        { squadPoints: -1, name: 1 },
        { name: "squad_skill_stable" },
      );
    },
  },
  {
    id: "20260722_011_suggested_squad_eligibility_index",
    checksum: "sha256:960f75fd8c7ce3585e77213e55bf178ee098207eeed4e73a6430f1cf6f920ee2",
    description: "Index server-authoritative Suggested Squad eligibility and ranking.",
    up: async (db) => {
      // Capacity remains an exact $expr over the validated roster/maxMembers pair. This prefix
      // index removes invite-only and medal-ineligible rows before that expression and preserves
      // the same stable competitive order used by the recovered Suggested Squads response.
      await db.collection("squads").createIndex(
        { joinPolicy: 1, requiredMedals: 1, squadPoints: -1, name: 1 },
        { name: "suggested_squad_eligibility" },
      );
    },
  },
  {
    id: "20260722_012_recovered_squad_progression",
    checksum: "sha256:387994a056a9732a37c8ec1d4a4da068f02bdc53e152ff6c1dc230143613ec51",
    description: "Roll legacy Squad experience into recovered rank progress and roster capacity.",
    up: async (db) => {
      const collection = db.collection("squads");
      const rows = await collection.find({}, {
        projection: { _id: 1, name: 1, level: 1, experience: 1, maxMembers: 1, members: 1 },
      }).toArray();
      const plans = rows.map((row) => {
        const transition = migrateLegacySquadExperienceState(row.level, row.experience);
        if (!Array.isArray(row.members) || row.members.length > transition.maxMembers) {
          // The old reconstruction admitted up to 15 members at rank one. Silently removing a
          // real roster member would be destructive, while retaining that capacity would keep an
          // invented entitlement. Abort before the first write and require operator resolution.
          throw new MigrationHistoryError(
            `Squad ${String(row.name)} has ${Array.isArray(row.members) ? row.members.length : "an invalid roster"}`
            + ` members but recovered level ${transition.levelTo} permits ${transition.maxMembers}.`,
          );
        }
        return { row, transition };
      });

      // Planning every row first prevents a late malformed roster from leaving a partially
      // transformed database. Each compare-and-set is still idempotent if the process terminates
      // after writes but before the migration receipt is committed.
      for (const { row, transition } of plans) {
        if (row.level === transition.levelTo
          && row.experience === transition.levelExperience
          && row.maxMembers === transition.maxMembers) continue;
        const result = await collection.updateOne(
          {
            _id: row._id,
            level: row.level,
            experience: row.experience,
            maxMembers: row.maxMembers,
          },
          {
            $set: {
              level: transition.levelTo,
              experience: transition.levelExperience,
              maxMembers: transition.maxMembers,
            },
          },
        );
        if (result.matchedCount !== 1) {
          throw new MigrationHistoryError(`Squad ${String(row.name)} changed during progression migration.`);
        }
      }
    },
  },
  {
    id: "20260723_013_progression_null_cleanup",
    checksum: "sha256:d2a2d014b2b3bcb248fa69e36c4730df013286f4b6dee5187e23ab7632fc59c8",
    description: "Remove BSON nulls accidentally written for absent optional progression fields.",
    up: async (db) => {
      const optionalFields = [
        "dogTags", "vipExpiration", "subscription", "subscriptionAuthorityReceiptId",
        "tutorialFinished", "tutorialBattle", "warcardsTutorialFinished",
        "warcardsTutorialBattle", "featureIntroductions", "matchesToNextLootboxes",
        "collectedRewards", "vipDailyCards", "dailyReward", "assignments", "dailyMissions",
        "eventAssignment", "itemInventory", "visualInventory", "cardInventory", "cardCrafting",
        "warCardsPlayed", "pvpWinStreak", "goldCardsCrafted", "warArena", "achievements",
        "starterAssignments", "lastSeenSquadChatTimestamp", "pendingMessageIgnores",
        "squadCreationsCount", "instantBattle", "videoAdRewards", "warBucksConversion",
        "blackMarket", "rental", "processedRequestBuffers",
      ] as const satisfies readonly (keyof PlayerProgressionState)[];
      const collection = db.collection<PlayerDocument>("players");
      const nullSelectors = optionalFields.map((field) => ({
        [`progression.${field}`]: { $type: 10 },
      }));
      const rows = await collection.find({ $or: nullSelectors }).toArray();
      const plans = rows.map((row) => {
        if (!row.progression || typeof row.progression !== "object" || Array.isArray(row.progression)) {
          throw new MigrationHistoryError(`Player ${row.id} has invalid progression during null cleanup.`);
        }
        const repaired = { ...row.progression } as PlayerProgressionState & Record<string, unknown>;
        const fields = optionalFields.filter((field) => repaired[field] === null);
        for (const field of fields) delete repaired[field];
        // Plan and validate every complete successor before the first write. This migration
        // repairs only the driver-created null/absence ambiguity; unrelated corruption remains
        // fail-closed for explicit operator inspection.
        progressionForPlayer({ ...row, progression: repaired });
        return { row, fields };
      });

      for (const { row, fields } of plans) {
        if (fields.length === 0) continue;
        const unset: Record<string, ""> = Object.fromEntries(
          fields.map((field): [string, ""] => [`progression.${field}`, ""]),
        );
        const stillNull = fields.map((field) => ({ [`progression.${field}`]: { $type: 10 } }));
        const result = await collection.updateOne(
          { _id: row._id, updatedAt: row.updatedAt, $and: stillNull },
          { $unset: unset },
        );
        if (result.matchedCount !== 1) {
          throw new MigrationHistoryError(`Player ${row.id} changed during progression null cleanup.`);
        }
      }
    },
  },
  {
    id: "20260723_014_legacy_squad_rank_repair",
    checksum: "sha256:8b2f46216088bfd85dd57b7370ac169a02852c5eb7ac4248f76a2bc98c47458b",
    description: "Realign legacy Founder and no-Squad ranks to the recovered Client enum.",
    up: async (db) => {
      const now = new Date();
      const squadCollection = db.collection<SquadDocument>("squads");
      const playerCollection = db.collection<PlayerDocument>("players");
      const validateRankMirror = (
        player: PlayerDocument,
        squadName: string,
        rank: SquadRank,
      ): void => {
        if (!player
          || !player.player
          || typeof player.id !== "string"
          || player.id.length < 1
          || player.id.length > 256
          || player.player.id !== player.id
          || player.squadName !== squadName
          || player.player.squadName !== squadName
          || player.player.squadRank !== rank
          || !(player.createdAt instanceof Date)
          || !(player.updatedAt instanceof Date)
          || !Number.isSafeInteger(player.createdAt.getTime())
          || !Number.isSafeInteger(player.updatedAt.getTime())
          || player.createdAt.getTime() < 0
          || player.createdAt.getTime() > player.updatedAt.getTime()
          || player.updatedAt.getTime() > now.getTime()) {
          throw new MigrationHistoryError(`Player ${player?.id ?? "<missing>"} has ambiguous Squad rank mirrors.`);
        }
      };
      const legacySquads = await squadCollection.find({
        "members.rank": SquadRank.Coleader,
      }).toArray();
      const squadPlans: Array<{
        current: SquadDocument;
        repaired: SquadDocument;
        founder: PlayerDocument;
        repairedFounder: PlayerDocument;
      }> = [];

      for (const squad of legacySquads) {
        const founder = squad.members.find((member) => member.playerId === squad.founderId);
        const leaders = squad.members.filter((member) => member.rank === SquadRank.Leader);
        // Rank 3 is a legitimate current Coleader. Repair only the exact initial reconstruction
        // shape: the founder alone carries old Founder=3 and there is no recovered Leader=2.
        if (!founder || founder.rank !== SquadRank.Coleader || leaders.length !== 0) continue;
        const repaired: SquadDocument = {
          ...squad,
          // These two required fields did not exist in the initial reconstruction that wrote
          // Founder=3. Supply only their source-compatible empty defaults when truly absent;
          // an explicitly malformed value remains corruption and fails validation below.
          requiredMedals: squad.requiredMedals === undefined ? 0 : squad.requiredMedals,
          invitedPlayerIds: squad.invitedPlayerIds === undefined ? [] : squad.invitedPlayerIds,
          members: squad.members.map((member) => member.playerId === squad.founderId
            ? { ...member, rank: SquadRank.Leader }
            : member),
          updatedAt: nextSquadUpdatedAt(squad, now),
        };
        validatedSquadDocument(repaired, now);

        const founderPlayer = await playerCollection.findOne({ id: squad.founderId });
        if (!founderPlayer
          || founderPlayer.squadName !== squad.name
          || founderPlayer.player.squadName !== squad.name
          || (founderPlayer.player.squadRank !== SquadRank.Coleader
            && founderPlayer.player.squadRank !== SquadRank.Leader)) {
          throw new MigrationHistoryError(`Legacy founder mirror for Squad ${squad.name} is ambiguous.`);
        }
        const repairedFounder: PlayerDocument = {
          ...founderPlayer,
          updatedAt: founderPlayer.player.squadRank === SquadRank.Leader
            ? founderPlayer.updatedAt
            : new Date(Math.max(now.getTime(), founderPlayer.updatedAt.getTime() + 1)),
          player: { ...founderPlayer.player, squadRank: SquadRank.Leader },
        };
        // Old development rows can have unrelated pre-contract identity fields. This migration
        // changes only the exact duplicated Squad mirror tuple, so validate that tuple and its
        // optimistic dates without normalizing or authorizing any unrelated profile field.
        validateRankMirror(founderPlayer, squad.name, founderPlayer.player.squadRank);
        validateRankMirror(repairedFounder, squad.name, SquadRank.Leader);
        squadPlans.push({ current: squad, repaired, founder: founderPlayer, repairedFounder });
      }

      const detachedPlayers = await playerCollection.find({
        squadName: "",
        "player.squadName": "",
        "player.squadRank": SquadRank.Member,
      }).toArray();
      const detachedPlans = detachedPlayers.map((player) => {
        const repaired: PlayerDocument = {
          ...player,
          updatedAt: new Date(Math.max(now.getTime(), player.updatedAt.getTime() + 1)),
          player: { ...player.player, squadRank: SquadRank.None },
        };
        validateRankMirror(player, "", SquadRank.Member);
        validateRankMirror(repaired, "", SquadRank.None);
        return { current: player, repaired };
      });

      // All successors are proven before the first write. Each compare-and-set remains
      // idempotent if startup stops between the player mirror and Squad roster updates.
      for (const { current, repaired } of detachedPlans) {
        const result = await playerCollection.updateOne(
          {
            _id: current._id,
            updatedAt: current.updatedAt,
            squadName: "",
            "player.squadName": "",
            "player.squadRank": SquadRank.Member,
          },
          { $set: { "player.squadRank": SquadRank.None, updatedAt: repaired.updatedAt } },
        );
        if (result.matchedCount !== 1) {
          throw new MigrationHistoryError(`Detached player ${current.id} changed during rank repair.`);
        }
      }

      for (const plan of squadPlans) {
        if (plan.founder.player.squadRank === SquadRank.Coleader) {
          const playerResult = await playerCollection.updateOne(
            {
              id: plan.founder.id,
              updatedAt: plan.founder.updatedAt,
              squadName: plan.current.name,
              "player.squadName": plan.current.name,
              "player.squadRank": SquadRank.Coleader,
            },
            { $set: { "player.squadRank": SquadRank.Leader, updatedAt: plan.repairedFounder.updatedAt } },
          );
          if (playerResult.matchedCount !== 1) {
            throw new MigrationHistoryError(`Founder ${plan.founder.id} changed during rank repair.`);
          }
        }
        const squadResult = await squadCollection.updateOne(
          { name: plan.current.name, updatedAt: plan.current.updatedAt, members: plan.current.members },
          { $set: { members: plan.repaired.members, updatedAt: plan.repaired.updatedAt } },
        );
        if (squadResult.matchedCount !== 1) {
          throw new MigrationHistoryError(`Squad ${plan.current.name} changed during founder rank repair.`);
        }
      }
    },
  },
  {
    id: "20260723_015_legacy_squad_admission_defaults",
    checksum: "sha256:b4ffb232164e224524a109030879c73c91e9f8c6a39a10cd6540d6cf2f0a796e",
    description: "Add missing source-compatible Squad admission defaults after the legacy rank repair.",
    up: async (db) => {
      const now = new Date();
      const squadCollection = db.collection<SquadDocument>("squads");
      const candidates = await squadCollection.find({
        $or: [
          { requiredMedals: { $exists: false } },
          { invitedPlayerIds: { $exists: false } },
        ],
      }).toArray();
      const plans = candidates.map((current) => {
        const missingRequiredMedals = !Object.prototype.hasOwnProperty.call(current, "requiredMedals");
        const missingInvitedPlayerIds = !Object.prototype.hasOwnProperty.call(current, "invitedPlayerIds");
        const repaired: SquadDocument = {
          ...current,
          requiredMedals: missingRequiredMedals ? 0 : current.requiredMedals,
          invitedPlayerIds: missingInvitedPlayerIds ? [] : current.invitedPlayerIds,
          updatedAt: nextSquadUpdatedAt(current, now),
        };
        // Validate every complete successor before the first write. An explicitly present null,
        // malformed admission value, or any unrelated damaged authority remains fail-closed.
        validatedSquadDocument(repaired, now);
        return { current, repaired, missingRequiredMedals, missingInvitedPlayerIds };
      });

      for (const plan of plans) {
        const filter: Document = {
          _id: plan.current._id,
          updatedAt: plan.current.updatedAt,
          ...(plan.missingRequiredMedals
            ? { requiredMedals: { $exists: false } }
            : { requiredMedals: plan.current.requiredMedals }),
          ...(plan.missingInvitedPlayerIds
            ? { invitedPlayerIds: { $exists: false } }
            : { invitedPlayerIds: plan.current.invitedPlayerIds }),
        };
        const set: Document = { updatedAt: plan.repaired.updatedAt };
        if (plan.missingRequiredMedals) set.requiredMedals = plan.repaired.requiredMedals;
        if (plan.missingInvitedPlayerIds) set.invitedPlayerIds = plan.repaired.invitedPlayerIds;
        const result = await squadCollection.updateOne(filter, { $set: set });
        if (result.matchedCount !== 1) {
          throw new MigrationHistoryError(`Squad ${plan.current.name} changed during admission-default repair.`);
        }
      }
    },
  },
];

const receiptCollectionName = "schemaMigrations";
const runnerLockId = "__database_migration_runner__";
const lockLeaseMs = 5 * 60 * 1000;
const migrationIdPattern = /^\d{8}_\d{3}_[a-z0-9_]+$/u;
const checksumPattern = /^sha256:[a-f0-9]{64}$/u;
const uuidV4Pattern = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;
const receiptKeys = new Set(["_id", "kind", "checksum", "description", "appliedAt", "durationMs"]);
const lockKeys = new Set(["_id", "kind", "ownerId", "acquiredAt", "expiresAt"]);

interface MigrationReceiptDocument extends Document {
  _id: string;
  kind: "migration";
  checksum: string;
  description: string;
  appliedAt: Date;
  durationMs: number;
}

interface MigrationLockDocument extends Document {
  _id: string;
  kind: "lock";
  ownerId: string;
  acquiredAt: Date;
  expiresAt: Date;
}

function plainObject(value: unknown): value is Record<string, unknown> {
  return typeof value === "object" && value !== null && !Array.isArray(value);
}

function validDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function validNow(now: Date): number {
  if (!validDate(now)) throw new MigrationHistoryError("Database migration authority time is invalid.");
  return now.getTime();
}

/**
 * Validate one durable success receipt before it is allowed to suppress a migration.
 *
 * The old read projected only `_id` and `checksum`. A damaged row could therefore omit its kind,
 * description, audit date, or duration and still convince startup that schema work had completed.
 * These receipts are deployment authority, so every persisted field is now required and immutable.
 */
export function validateMigrationReceiptAuthority(
  value: unknown,
  now: Date,
  expected?: DatabaseMigration,
): asserts value is MigrationReceiptDocument {
  const nowMs = validNow(now);
  if (!plainObject(value)
    || Object.keys(value).length !== receiptKeys.size
    || Object.keys(value).some((key) => !receiptKeys.has(key))
    || typeof value._id !== "string"
    || !migrationIdPattern.test(value._id)
    || value.kind !== "migration"
    || typeof value.checksum !== "string"
    || !checksumPattern.test(value.checksum)
    || typeof value.description !== "string"
    || value.description.trim() !== value.description
    || value.description.length < 1
    || value.description.length > 512
    || !validDate(value.appliedAt)
    || value.appliedAt.getTime() > nowMs
    || !Number.isSafeInteger(value.durationMs)
    || (value.durationMs as number) < 0) {
    throw new MigrationHistoryError("Stored database migration receipt authority is invalid.");
  }
  if (expected && (value._id !== expected.id
    || value.checksum !== expected.checksum
    || value.description !== expected.description)) {
    throw new MigrationHistoryError(`Stored database migration receipt does not match ${value._id}.`);
  }
}

/**
 * Validate the singleton lease before deciding whether it is active or safe to replace.
 * An invalid date must never be interpreted as expired, because that would let two migration
 * runners overlap. The upper expiry bound also prevents a corrupt row from blocking startup
 * forever; operators must repair that row explicitly rather than letting time comparisons guess.
 */
export function validateMigrationLockAuthority(
  value: unknown,
  now: Date,
): asserts value is MigrationLockDocument {
  const nowMs = validNow(now);
  if (!plainObject(value)
    || Object.keys(value).length !== lockKeys.size
    || Object.keys(value).some((key) => !lockKeys.has(key))
    || value._id !== runnerLockId
    || value.kind !== "lock"
    || typeof value.ownerId !== "string"
    || !uuidV4Pattern.test(value.ownerId)
    || !validDate(value.acquiredAt)
    || !validDate(value.expiresAt)
    || value.acquiredAt.getTime() > nowMs
    || value.expiresAt.getTime() <= value.acquiredAt.getTime()
    || value.expiresAt.getTime() > nowMs + lockLeaseMs) {
    throw new MigrationHistoryError("Stored database migration lease authority is invalid.");
  }
}

export class MigrationHistoryError extends Error {
  constructor(message: string) {
    super(message);
    this.name = "MigrationHistoryError";
  }
}

/**
 * Validate migration history and return only the unapplied suffix.
 *
 * Refusing unknown, reordered, duplicated, or checksum-drifted history is deliberate. Starting a
 * binary against an incompatible schema is more dangerous than keeping that node out of service,
 * especially during a rolling deployment where another version may already own the database.
 */
export function planDatabaseMigrations(
  known: readonly DatabaseMigration[],
  applied: readonly AppliedMigration[],
): DatabaseMigration[] {
  const knownIds = new Set<string>();
  for (const migration of known) {
    if (!migrationIdPattern.test(migration.id)) {
      throw new MigrationHistoryError(`Migration ID is invalid: ${migration.id}`);
    }
    if (!checksumPattern.test(migration.checksum)) {
      throw new MigrationHistoryError(`Migration checksum is invalid: ${migration.id}`);
    }
    if (migration.description.trim() !== migration.description
      || migration.description.length < 1
      || migration.description.length > 512) {
      throw new MigrationHistoryError(`Migration description is invalid: ${migration.id}`);
    }
    if (knownIds.has(migration.id)) throw new MigrationHistoryError(`Duplicate migration ID: ${migration.id}`);
    knownIds.add(migration.id);
  }
  const orderedKnown = [...known].sort((a, b) => a.id.localeCompare(b.id));
  if (orderedKnown.some((migration, index) => migration.id !== known[index]?.id)) {
    throw new MigrationHistoryError("Migration registry is not ordered by ID.");
  }

  const appliedIds = new Set<string>();
  for (let index = 0; index < applied.length; index += 1) {
    const receipt = applied[index]!;
    if (appliedIds.has(receipt.id)) throw new MigrationHistoryError(`Duplicate migration receipt: ${receipt.id}`);
    appliedIds.add(receipt.id);
    const expected = known[index];
    if (!expected || expected.id !== receipt.id) {
      throw new MigrationHistoryError(`Database migration history is unknown or out of order at ${receipt.id}.`);
    }
    if (expected.checksum !== receipt.checksum) {
      throw new MigrationHistoryError(`Applied migration checksum changed: ${receipt.id}`);
    }
  }
  return known.slice(applied.length) as DatabaseMigration[];
}

function duplicateKey(error: unknown): boolean {
  return typeof error === "object" && error !== null && "code" in error && (error as { code?: unknown }).code === 11000;
}

/** Acquire the cluster-wide lease. A live runner makes later nodes fail startup instead of race. */
async function acquireMigrationLease(db: Db, ownerId: string, now: Date): Promise<void> {
  const receipts = db.collection<MigrationLockDocument>(receiptCollectionName);
  const nowMs = validNow(now);
  const replacement: MigrationLockDocument = {
    _id: runnerLockId,
    kind: "lock",
    ownerId,
    acquiredAt: now,
    expiresAt: new Date(nowMs + lockLeaseMs),
  };
  validateMigrationLockAuthority(replacement, now);
  try {
    const existing = await receipts.findOne({ _id: runnerLockId });
    if (!existing) {
      // `insertOne` is important here. A read-then-upsert could match and overwrite a competing
      // runner inserted between the two operations. The singleton `_id` turns that race into the
      // duplicate-key contention handled below.
      await receipts.insertOne(replacement);
      return;
    }
    validateMigrationLockAuthority(existing, now);
    if (existing.expiresAt.getTime() > nowMs) {
      throw new MigrationHistoryError("Database migration lease is held by another server.");
    }
    const lock = await receipts.findOneAndUpdate(
      {
        _id: runnerLockId,
        kind: "lock",
        ownerId: existing.ownerId,
        acquiredAt: existing.acquiredAt,
        expiresAt: existing.expiresAt,
      },
      {
        $set: {
          kind: replacement.kind,
          ownerId: replacement.ownerId,
          acquiredAt: replacement.acquiredAt,
          expiresAt: replacement.expiresAt,
        },
      },
      { returnDocument: "after" },
    );
    if (!lock) throw new MigrationHistoryError("Database migration lease changed during acquisition.");
    validateMigrationLockAuthority(lock, now);
    if (lock.ownerId !== ownerId) throw new MigrationHistoryError("Database migration lease is unavailable.");
  } catch (error) {
    // A competing singleton insert produces E11000 because `_id` is unique. Translate that
    // expected contention into one stable operational error.
    if (duplicateKey(error)) throw new MigrationHistoryError("Database migration lease is held by another server.");
    throw error;
  }
}

export async function renewMigrationLease(db: Db, ownerId: string, now: Date = new Date()): Promise<void> {
  const nowMs = validNow(now);
  const renewed = await db.collection<MigrationLockDocument>(receiptCollectionName).findOneAndUpdate(
    {
      _id: runnerLockId,
      kind: "lock",
      ownerId,
      acquiredAt: { $lte: now },
      // A stalled process must not resurrect an expired lease. Once this boundary passes, another
      // server is entitled to take ownership even if it has not done so yet.
      expiresAt: { $gt: now },
    },
    { $set: { expiresAt: new Date(nowMs + lockLeaseMs) } },
    { returnDocument: "after" },
  );
  if (!renewed) throw new MigrationHistoryError("Database migration lease was lost.");
  validateMigrationLockAuthority(renewed, now);
}

/**
 * Keep ownership alive while MongoDB performs a potentially long index build. The timer stores its
 * first failure instead of throwing from an unobserved callback; the migration loop checks that
 * failure before writing the success receipt. This preserves the important invariant that a node
 * never records a migration as applied after it has lost exclusive ownership.
 */
function startLeaseHeartbeat(db: Db, ownerId: string): {
  assertOwned: () => Promise<void>;
  stop: () => void;
} {
  let renewal: Promise<void> = Promise.resolve();
  let failure: unknown;
  const timer = setInterval(() => {
    renewal = renewal.then(() => renewMigrationLease(db, ownerId)).catch((error: unknown) => {
      failure ??= error;
    });
  }, Math.floor(lockLeaseMs / 3));
  timer.unref();
  return {
    assertOwned: async () => {
      await renewal;
      if (failure) throw failure;
      await renewMigrationLease(db, ownerId);
    },
    stop: () => clearInterval(timer),
  };
}

/**
 * Apply every pending migration under one database-wide lease and persist immutable receipts.
 * The lease document is removed only by its owner; an expired lease is recoverable after a crash.
 */
export async function runDatabaseMigrations(db: Db = mongoDatabase()): Promise<number> {
  const ownerId = randomUUID();
  const receipts = db.collection<MigrationReceiptDocument>(receiptCollectionName);
  await acquireMigrationLease(db, ownerId, new Date());
  const heartbeat = startLeaseHeartbeat(db, ownerId);
  try {
    const historyNow = new Date();
    const appliedDocuments = await receipts
      // Read every non-lock row, not merely `{ kind: "migration" }`. Filtering by the asserted
      // kind would hide a damaged receipt and let its duplicate `_id` fail only after `up` ran.
      .find({ _id: { $ne: runnerLockId } })
      .sort({ _id: 1 })
      .toArray();
    for (const receipt of appliedDocuments) {
      const expected = migrations.find((migration) => migration.id === receipt._id);
      validateMigrationReceiptAuthority(receipt, historyNow, expected);
    }
    const pending = planDatabaseMigrations(
      migrations,
      appliedDocuments.map((receipt) => ({ id: receipt._id, checksum: receipt.checksum })),
    );

    for (const migration of pending) {
      await renewMigrationLease(db, ownerId);
      const startedAt = Date.now();
      await migration.up(db);
      await heartbeat.assertOwned();
      const appliedAt = new Date();
      const receipt: MigrationReceiptDocument = {
        _id: migration.id,
        kind: "migration",
        checksum: migration.checksum,
        description: migration.description,
        appliedAt,
        durationMs: appliedAt.getTime() - startedAt,
      };
      // Validate our own projection before it becomes durable authority. In particular, a host
      // clock rollback must stop startup instead of publishing a negative migration duration.
      validateMigrationReceiptAuthority(receipt, appliedAt, migration);
      await receipts.insertOne(receipt);
      logger.infoWithEmoji("DB", "Database migration applied", "MIGRATION", {
        migrationId: migration.id,
        description: migration.description,
      });
    }
    return pending.length;
  } finally {
    heartbeat.stop();
    await db.collection<MigrationLockDocument>(receiptCollectionName).deleteOne({
      _id: runnerLockId,
      kind: "lock",
      ownerId,
    });
  }
}
