import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  acceptJoinRequest,
  createSquad,
  declineJoinRequest,
  demoteMember,
  getByName,
  getSquadMemberPlayers,
  invitePlayer,
  isNameAvailable,
  joinSquad,
  kickMember,
  leaveSquad,
  listByExperience,
  promoteMember,
  requestToJoin,
  SQUAD_CREATE_NOT_ENOUGH_WARBUCKS,
  transferLeadership,
  updateSquad,
} from "../services/squadService";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { authed, type HandlerEntry } from "./types";
import { buildDatabaseSquad, buildSquadWarsDivision } from "../services/squadWireService";
import { buildDatabasePlayer, progressionForPlayer } from "../services/playerStateService";
import { findById } from "../services/playerService";
import { informSquadLeaderAboutEvent, saveSquadChatCursor } from "../services/squadSocialService";
import {
  buildSquadEventProgress,
  getSquadEventWireFields,
  joinSquadEvent,
  squadEventPlayerLevelProgress,
} from "../services/squadEventService";
import {
  getSquadWarDetailFields,
  getSquadWarDivision,
} from "../services/squadWarService";
import { rankSquadWarDivision } from "../services/squadWarContract";

// Squad system — BACKEND.md §2.5. Every handler is authenticated; rank checks live in the
// service layer.

function squadName(req: Record<string, unknown>): string {
  const name = req.SquadName ?? req.SquadId ?? req.NewSquadId ?? req.Name;
  return typeof name === "string" ? name : "";
}

function targetId(req: Record<string, unknown>): string {
  const id =
    req.TargetPlayerId ??
    req.PlayerToPromoteId ??
    req.PlayerToKickId ??
    req.PlayerToJoin ??
    req.PlayerToInviteId ??
    req.SquadMemberId ??
    req.Id ??
    req.id;
  return typeof id === "string" ? id : "";
}

function squadWarsRoundId(req: Record<string, unknown>): string {
  const value = typeof req.RoundId === "string" ? req.RoundId.trim() : "";
  if (!value || value.length > 128 || !/^[\p{L}\p{N}_.:-]+$/u.test(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "RoundId is invalid.");
  }
  return value;
}

function integer(value: unknown, fallback = 0): number {
  const parsed = Number(value);
  return Number.isFinite(parsed) ? Math.floor(parsed) : fallback;
}

function joinPolicy(req: Record<string, unknown>): number | undefined {
  if (req.JoinPolicy !== undefined) return integer(req.JoinPolicy);
  if (req.IsPublic !== undefined) {
    const value = String(req.IsPublic).toLowerCase();
    return value === "1" || value === "true" ? 0 : 1;
  }
  return undefined;
}

function emblem(req: Record<string, unknown>): Record<string, unknown> | undefined {
  if (typeof req.Icon === "string") return { id: req.Icon };
  return req.Emblem && typeof req.Emblem === "object" && !Array.isArray(req.Emblem)
    ? (req.Emblem as Record<string, unknown>)
    : undefined;
}

export const squadHandlers: Record<number, HandlerEntry> = {
  [DbAction.JoinSquadEvent]: authed(async ({ player }) => {
    const progress = await joinSquadEvent(player!);
    return ok(DbAction.JoinSquadEvent, {
      SquadEventProgress: buildSquadEventProgress(
        progress,
        // Level is the zero-based LevelManager index in the recovered DatabasePlayer contract.
        // LevelProgress is viewer-specific reward scaling, not shared event completion.
        squadEventPlayerLevelProgress(player!.player.level),
      ),
    });
  }),

  [DbAction.SaveLastSeenSquadChatTimeStamp]: authed(async ({ player, req }) => {
    // The stock 1.6.0 client normally submits the cursor as RequestBuffer.data. This direct
    // form remains useful for repaired clients and diagnostics, but accepts only explicit
    // timestamp aliases and never derives a value from the server receive time.
    // Do not use the generic squad integer helper here: it floors decimals, which would turn a
    // malformed cursor into different valid authority before the shared action-193 validator sees it.
    const rawTimestamp = req.LastSeenSquadChatTimeStamp ?? req.Timestamp ?? req.TimeStamp;
    const timestamp = rawTimestamp === undefined
      || rawTimestamp === null
      || (typeof rawTimestamp === "string" && rawTimestamp.trim() === "")
      ? Number.NaN
      : Number(rawTimestamp);
    const result = await saveSquadChatCursor(player!.id, timestamp);
    return ok(DbAction.SaveLastSeenSquadChatTimeStamp, {
      LastSeenSquadChatTimeStamp: result.timestamp,
    });
  }),

  [DbAction.InformSquadLeaderAboutEvent]: authed(async ({ player, req }) => {
    const name = squadName(req) || player!.player.squadName;
    const message = await informSquadLeaderAboutEvent(player!.id, name);
    return ok(DbAction.InformSquadLeaderAboutEvent, {
      Informed: Boolean(message),
      ...(message ? { MessageId: message.messageId } : {}),
    });
  }),

  [DbAction.CheckUniqueSquadName]: authed(async ({ req }) => {
    const available = await isNameAvailable(squadName(req));
    // EBDNFFCCKEP reads IsUnique from the CheckUniqueSquadName response and then emits the
    // local UniqueSquadNameSuccess/Failure event itself. Changing the response action or
    // returning only Available bypasses that callback and leaves the creation dialog waiting.
    return ok(DbAction.CheckUniqueSquadName, { IsUnique: available, Available: available });
  }),

  [DbAction.CreateSquad]: authed(async ({ player, req }) => {
    try {
      const result = await createSquad(player!.id, squadName(req), {
        description: typeof req.Message === "string" ? req.Message : undefined,
        emblem: emblem(req),
        joinPolicy: joinPolicy(req),
        requiredMedals: integer(req.RequiredMedals ?? req.SkillRequirement),
      });
      return ok(DbAction.CreateSquad, {
        Squad: buildDatabaseSquad(result.squad),
        SquadId: result.squad.name,
        PlayerRank: 2,
        // OGLEHLIPEFM persists this exact lower-case-leading key into PlayerAnalytics.
        squadCreationsCnt: result.squadCreationsCount,
      });
    } catch (error) {
      if (!(error instanceof ApiError) || error.code !== SQUAD_CREATE_NOT_ENOUGH_WARBUCKS) throw error;
      const latest = await findById(player!.id) ?? player!;
      const progression = progressionForPlayer(latest);
      return {
        DbAction: DbAction.CreateSquad,
        Result: error.code,
        Code: error.code,
        Message: error.message,
        // LEDNENKKDJM's 11403 branch uses both values to reverse the client's optimistic
        // WarBucks debit and restore the authoritative next-price counter.
        squadCreationsCnt: progression.squadCreationsCount ?? 0,
        PlayerWB: progression.warBucks,
      };
    }
  }),

  [DbAction.JoinSquad]: authed(async ({ player, req }) => {
    const squad = await joinSquad(player!.id, squadName(req));
    return ok(DbAction.JoinSquad, { Squad: buildDatabaseSquad(squad), SquadId: squad.name, PlayerRank: 0 });
  }),

  [DbAction.JoinSquadRequest]: authed(async ({ player, req }) => {
    const squad = await requestToJoin(player!.id, squadName(req));
    return ok(DbAction.JoinSquadRequest, { Squad: buildDatabaseSquad(squad) });
  }),

  [DbAction.AcceptSquadJoinRequest]: authed(async ({ player, req }) => {
    const name = squadName(req) || player!.player.squadName;
    const target = targetId(req);
    try {
      const squad = await acceptJoinRequest(player!.id, target, name);
      const joined = await findById(target);
      return ok(DbAction.AcceptSquadJoinRequest, {
        Squad: buildDatabaseSquad(squad),
        ...(joined ? { joinedPlayer: buildDatabasePlayer(joined) } : {}),
      });
    } catch (error) {
      if (!(error instanceof ApiError)
        || (error.code !== ApiErrorCode.PlayerAlreadyInSquad
          && error.code !== ApiErrorCode.SquadJoinRequestNotExists)) throw error;
      const targetPlayer = await findById(target);
      return {
        DbAction: DbAction.AcceptSquadJoinRequest,
        Result: error.code,
        Code: error.code,
        Message: error.message,
        // LEDNENKKDJM removes this stale row from AwaitingSquadMembersManager. Error 13301
        // additionally displays the target's current squad name in its conflict dialog.
        PlayerId: target,
        ...(error.code === ApiErrorCode.PlayerAlreadyInSquad
          ? { Name: targetPlayer?.player.squadName ?? "" }
          : {}),
      };
    }
  }),

  [DbAction.DeclineSquadJoinRequest]: authed(async ({ player, req }) => {
    const squad = await declineJoinRequest(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    return ok(DbAction.DeclineSquadJoinRequest, { Squad: buildDatabaseSquad(squad) });
  }),

  [DbAction.InvitePlayerToSquad]: authed(async ({ player, req }) => {
    const squad = await invitePlayer(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    return ok(DbAction.InvitePlayerToSquad, { Squad: buildDatabaseSquad(squad) });
  }),

  [DbAction.LeaveSquad]: authed(async ({ player, req }) => {
    const result = await leaveSquad(player!.id, squadName(req) || player!.player.squadName);
    return ok(DbAction.LeaveSquad, {
      // GCGBPMPECDO expects a JSON list and calls CardManager.AddCard once per ID, so amounts
      // are intentionally represented by repeated IDs rather than a dictionary.
      ...(result.returnedCardIds.length > 0
        ? { DepositedCards: JSON.stringify(result.returnedCardIds) }
        : {}),
    });
  }),

  [DbAction.PromotePlayer]: authed(async ({ player, req }) => {
    const name = squadName(req) || player!.player.squadName;
    try {
      const squad = await promoteMember(player!.id, targetId(req), name);
      const promoted = await findById(targetId(req));
      return ok(DbAction.PromotePlayer, {
        Squad: buildDatabaseSquad(squad),
        ...(promoted ? { PromotedPlayer: buildDatabasePlayer(promoted) } : {}),
      });
    } catch (error) {
      if (!(error instanceof ApiError) || error.code !== ApiErrorCode.PromotePlayerError) throw error;
      const members = (await getSquadMemberPlayers(name)).map(buildDatabasePlayer);
      return {
        DbAction: DbAction.PromotePlayer,
        Result: error.code,
        Code: error.code,
        Message: error.message,
        // The stock 5501 parser calls LoadSquadMembers to undo an optimistic rank display.
        SquadMembers: members,
      };
    }
  }),

  [DbAction.PromotePlayerToFounder]: authed(async ({ player, req }) => {
    const squad = await transferLeadership(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    const promoted = await findById(targetId(req));
    return ok(DbAction.PromotePlayerToFounder, {
      Squad: buildDatabaseSquad(squad),
      ...(promoted ? { PromotedPlayer: buildDatabasePlayer(promoted) } : {}),
    });
  }),

  [DbAction.DemotePlayer]: authed(async ({ player, req }) => {
    const name = squadName(req) || player!.player.squadName;
    try {
      const squad = await demoteMember(player!.id, targetId(req), name);
      const demoted = await findById(targetId(req));
      return ok(DbAction.DemotePlayer, {
        Squad: buildDatabaseSquad(squad),
        ...(demoted ? { DemotedPlayer: buildDatabasePlayer(demoted) } : {}),
      });
    } catch (error) {
      if (!(error instanceof ApiError) || error.code !== ApiErrorCode.DemotePlayerError) throw error;
      const members = (await getSquadMemberPlayers(name)).map(buildDatabasePlayer);
      return {
        DbAction: DbAction.DemotePlayer,
        Result: error.code,
        Code: error.code,
        Message: error.message,
        SquadMembers: members,
      };
    }
  }),

  [DbAction.KickPlayer]: authed(async ({ player, req }) => {
    const squad = await kickMember(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    const kicked = await findById(targetId(req));
    return ok(DbAction.KickPlayer, {
      Squad: buildDatabaseSquad(squad),
      ...(kicked ? { Player: buildDatabasePlayer(kicked) } : {}),
    });
  }),

  [DbAction.RemoveUserFromSquad]: authed(async ({ player, req }) => {
    const squad = await kickMember(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    const removed = await findById(targetId(req));
    return ok(DbAction.RemoveUserFromSquad, {
      Squad: buildDatabaseSquad(squad),
      ...(removed ? { Player: buildDatabasePlayer(removed) } : {}),
    });
  }),

  [DbAction.GetSquadDetails]: authed(async ({ player, req }) => {
    const name = squadName(req) || player!.player.squadName;
    // Assignment may update RoundId. Resolve it before reading the squad snapshot so the object
    // and its top-level SquadWarsId/position/evaluation metadata describe the same division.
    const squadWarFields = name ? await getSquadWarDetailFields(name) : {};
    const squad = await getByName(name);
    return ok(DbAction.GetSquadDetails, {
      Squad: squad ? buildDatabaseSquad(squad) : null,
      ...(squad ? await getSquadEventWireFields(squad.name, player!.player.level) : {}),
      ...(squad ? squadWarFields : {}),
    });
  }),

  [DbAction.GetFullSquadInfo]: authed(async ({ player, req }) => {
    const name = squadName(req) || player!.player.squadName;
    const squadWarFields = name ? await getSquadWarDetailFields(name) : {};
    const squad = await getByName(name);
    return ok(DbAction.GetFullSquadInfo, {
      Squad: squad ? buildDatabaseSquad(squad) : null,
      ...(squad ? await getSquadEventWireFields(squad.name, player!.player.level) : {}),
      ...(squad ? squadWarFields : {}),
    });
  }),

  [DbAction.GetAllSquadMembers]: authed(async ({ player, req }) => {
    const name = squadName(req) || player!.player.squadName;
    const members = (await getSquadMemberPlayers(name)).map(buildDatabasePlayer);
    return ok(DbAction.GetAllSquadMembers, { SquadId: name, SquadMembers: members, Members: members });
  }),

  [DbAction.GetSquads]: authed(async () =>
    ok(DbAction.GetSquads, { Items: (await listByExperience()).map(buildDatabaseSquad) }),
  ),

  [DbAction.GetSquadsByExperience]: authed(async () =>
    ok(DbAction.GetSquadsByExperience, { Items: (await listByExperience()).map(buildDatabaseSquad) }),
  ),

  [DbAction.GetSquadWarsDivision]: authed(async ({ player, req }) => {
    const requestedRound = squadWarsRoundId(req);
    const model = await getSquadWarDivision(player!, requestedRound);
    const ranked = rankSquadWarDivision(model.round.entries, model.round.level);
    const squadByName = new Map(model.squads.map((squad) => [squad.name, squad]));
    const orderedSquads = ranked
      .map((entry) => squadByName.get(entry.squadId))
      .filter((value): value is NonNullable<typeof value> => Boolean(value));
    return ok(DbAction.GetSquadWarsDivision, buildSquadWarsDivision(
      model.round.roundId,
      model.season.seasonId,
      orderedSquads,
      ranked.map((entry) => ({
        squadId: entry.squadId,
        baseScore: entry.baseScore,
        score: entry.score,
        wins: model.round.entries.find((candidate) => candidate.squadId === entry.squadId)?.wins ?? 0,
      })),
    ));
  }),

  [DbAction.FindSuggestedSquads]: authed(async () =>
    ok(DbAction.FindSuggestedSquads, { Items: (await listByExperience(20)).map(buildDatabaseSquad) }),
  ),

  [DbAction.UpdateSquad]: authed(async ({ player, req }) => {
    const squad = await updateSquad(player!.id, squadName(req) || player!.player.squadName, {
      description: typeof req.Message === "string" ? req.Message : undefined,
      joinPolicy: joinPolicy(req),
      requiredMedals: req.RequiredMedals === undefined ? undefined : integer(req.RequiredMedals),
    });
    return ok(DbAction.UpdateSquad, { Squad: buildDatabaseSquad(squad) });
  }),

  [DbAction.UpdateSquadEmblem]: authed(async ({ player, req }) => {
    const squad = await updateSquad(player!.id, squadName(req) || player!.player.squadName, { emblem: emblem(req) });
    return ok(DbAction.UpdateSquadEmblem, { Squad: buildDatabaseSquad(squad) });
  }),
};
