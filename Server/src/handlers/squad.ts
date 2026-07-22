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
  searchSquadsByName,
  suggestedSquads,
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
import { publishInboxFanout } from "../services/inboxFanoutService";
import {
  requestedAcceptSquadJoinRequest,
  requestedCreateSquad,
  requestedGlobalSquadDirectory,
  requestedDirectSquadChatTimestamp,
  requestedDirectSquadJoin,
  requestedDeclineSquadJoinRequest,
  requestedSquadInvitation,
  requestedSquadJoinRequest,
  requestedSquadKickTarget,
  requestedSquadLeadershipTarget,
  requestedSquadNamePrefix,
  requestedSquadRankChange,
  requestedSquadMembersRead,
  requestedSquadRead,
  requestedSuggestedSquadSkill,
  requestedUpdateSquad,
} from "./squadAdmissionParsing";
import { requestedSquadWarRoundId } from "./squadWarRequestParsing";

// Squad system — BACKEND.md §2.5. Every handler is authenticated; rank checks live in the
// service layer.

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
    // timestamp alias. Its exact C# transport boundary runs before the shared nonnegative,
    // future-skew, and monotonic checks, and no server receive-time fallback is invented.
    const timestamp = requestedDirectSquadChatTimestamp(req);
    const result = await saveSquadChatCursor(player!.id, timestamp);
    return ok(DbAction.SaveLastSeenSquadChatTimeStamp, {
      LastSeenSquadChatTimeStamp: result.timestamp,
    });
  }),

  [DbAction.InformSquadLeaderAboutEvent]: authed(async ({ player, req }) => {
    // The recovered caller sends its current SquadId. Keep it as an assertion that the event came
    // from the same Squad snapshot instead of silently replacing an absent/foreign alias with the
    // authenticated profile's membership.
    const name = requestedSquadRead(req, "Squad leader event");
    const message = await informSquadLeaderAboutEvent(player!.id, name);
    if (message) await publishInboxFanout(message.toPlayerId, message.messageId);
    return ok(DbAction.InformSquadLeaderAboutEvent, {
      Informed: Boolean(message),
      ...(message ? { MessageId: message.messageId } : {}),
    });
  }),

  [DbAction.CheckUniqueSquadName]: authed(async ({ req }) => {
    const available = await isNameAvailable(requestedSquadRead(req, "Squad name availability"));
    // EBDNFFCCKEP reads IsUnique from the CheckUniqueSquadName response and then emits the
    // local UniqueSquadNameSuccess/Failure event itself. Changing the response action or
    // returning only Available bypasses that callback and leaves the creation dialog waiting.
    return ok(DbAction.CheckUniqueSquadName, { IsUnique: available, Available: available });
  }),

  [DbAction.CreateSquad]: authed(async ({ player, req }) => {
    const input = requestedCreateSquad(req);
    try {
      const result = await createSquad(player!.id, input.squadId, {
        description: input.description,
        emblem: input.emblem,
        joinPolicy: input.joinPolicy,
        requiredMedals: input.requiredMedals,
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
    const input = requestedDirectSquadJoin(req);
    // The optional MessageId is a recipient/Squad-bound type-1 capability identity, never a
    // fallback Squad selector. The service consumes it with the queue and membership atomically.
    const squad = await joinSquad(player!.id, input.squadId, input.messageId);
    return ok(DbAction.JoinSquad, { Squad: buildDatabaseSquad(squad), SquadId: squad.name, PlayerRank: 0 });
  }),

  [DbAction.JoinSquadRequest]: authed(async ({ player, req }) => {
    const squad = await requestToJoin(player!.id, requestedSquadJoinRequest(req));
    return ok(DbAction.JoinSquadRequest, { Squad: buildDatabaseSquad(squad) });
  }),

  [DbAction.AcceptSquadJoinRequest]: authed(async ({ player, req }) => {
    const input = requestedAcceptSquadJoinRequest(req);
    const name = input.squadId;
    const target = input.playerId;
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
          ? { Name: targetPlayer?.squadName || targetPlayer?.player.squadName || "" }
          : {}),
      };
    }
  }),

  [DbAction.DeclineSquadJoinRequest]: authed(async ({ player, req }) => {
    const input = requestedDeclineSquadJoinRequest(req);
    if (input.squadId !== player!.player.squadName) {
      throw new ApiError(ApiErrorCode.NotLeaderOfSquad, "Decline request does not match the authenticated squad.");
    }
    const squad = await declineJoinRequest(player!.id, input.playerId, input.squadId);
    return ok(DbAction.DeclineSquadJoinRequest, { Squad: buildDatabaseSquad(squad) });
  }),

  [DbAction.InvitePlayerToSquad]: authed(async ({ player, req }) => {
    const target = requestedSquadInvitation(req);
    try {
      // The recovered action-59 request has no Squad field. Derive ownership only from the
      // authenticated profile so a cross-action alias cannot select another mutable document.
      const result = await invitePlayer(player!.id, target, player!.player.squadName);
      return ok(DbAction.InvitePlayerToSquad, { Squad: buildDatabaseSquad(result.squad) });
    } catch (error) {
      if (!(error instanceof ApiError) || error.code !== ApiErrorCode.PlayerAlreadyInSquad) throw error;
      const targetPlayer = await findById(target);
      return {
        DbAction: DbAction.InvitePlayerToSquad,
        Result: error.code,
        Code: error.code,
        Message: error.message,
        // The shared recovered 13301 callback displays the target's current Squad name and can
        // remove that player from stale pending UI only when these exact identity fields exist.
        PlayerId: target,
        Name: targetPlayer?.squadName || targetPlayer?.player.squadName || "",
      };
    }
  }),

  [DbAction.LeaveSquad]: authed(async ({ player }) => {
    // MOGOJFFMFED emits no gameplay fields. Only the authenticated player mirror may select the
    // roster being left; accepting SquadId/NewSquadId here would create an undocumented cross-
    // action capability and could target a Squad unrelated to the session.
    const result = await leaveSquad(player!.id, player!.player.squadName);
    return ok(DbAction.LeaveSquad, {
      // GCGBPMPECDO expects a JSON list and calls CardManager.AddCard once per ID, so amounts
      // are intentionally represented by repeated IDs rather than a dictionary.
      ...(result.returnedCardIds.length > 0
        ? { DepositedCards: JSON.stringify(result.returnedCardIds) }
        : {}),
    });
  }),

  [DbAction.PromotePlayer]: authed(async ({ player, req }) => {
    const input = requestedSquadRankChange(req, "promote");
    const name = player!.player.squadName;
    try {
      const squad = await promoteMember(player!.id, input.playerId, name, input.oldRank);
      const promoted = await findById(input.playerId);
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
    const target = requestedSquadLeadershipTarget(req);
    const squad = await transferLeadership(player!.id, target, player!.player.squadName);
    const promoted = await findById(target);
    return ok(DbAction.PromotePlayerToFounder, {
      Squad: buildDatabaseSquad(squad),
      ...(promoted ? { PromotedPlayer: buildDatabasePlayer(promoted) } : {}),
    });
  }),

  [DbAction.DemotePlayer]: authed(async ({ player, req }) => {
    const input = requestedSquadRankChange(req, "demote");
    const name = player!.player.squadName;
    try {
      const squad = await demoteMember(player!.id, input.playerId, name, input.oldRank);
      const demoted = await findById(input.playerId);
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
    const target = requestedSquadKickTarget(req);
    const squad = await kickMember(player!.id, target, player!.player.squadName);
    const kicked = await findById(target);
    return ok(DbAction.KickPlayer, {
      Squad: buildDatabaseSquad(squad),
      ...(kicked ? { Player: buildDatabasePlayer(kicked) } : {}),
    });
  }),

  [DbAction.GetSquadDetails]: authed(async ({ player, req }) => {
    const name = requestedSquadRead(req, "Squad detail read");
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
    const name = requestedSquadRead(req, "Full Squad read");
    const squadWarFields = name ? await getSquadWarDetailFields(name) : {};
    const squad = await getByName(name);
    return ok(DbAction.GetFullSquadInfo, {
      Squad: squad ? buildDatabaseSquad(squad) : null,
      ...(squad ? await getSquadEventWireFields(squad.name, player!.player.level) : {}),
      ...(squad ? squadWarFields : {}),
    });
  }),

  [DbAction.GetAllSquadMembers]: authed(async ({ req }) => {
    const input = requestedSquadMembersRead(req);
    const name = input.squadId;
    // The stock client computes CheckMessages from its displayed rank. It is not an authority
    // signal and the recovered response parser needs no alternate member payload, but validating
    // its exact 0/1 transport prevents malformed requests from silently taking another path.
    void input.checkMessages;
    const members = (await getSquadMemberPlayers(name)).map(buildDatabasePlayer);
    return ok(DbAction.GetAllSquadMembers, { SquadId: name, SquadMembers: members, Members: members });
  }),

  [DbAction.GetSquads]: authed(async ({ req }) => {
    const prefix = requestedSquadNamePrefix(req);
    // The recovered data model has no authoritative Squad country/locale owner. Always identify
    // the global fallback honestly; the stock parser stores IsLocal and can present that state.
    requestedGlobalSquadDirectory(req);
    return ok(DbAction.GetSquads, {
      Items: (await searchSquadsByName(prefix)).map(buildDatabaseSquad),
      IsLocal: false,
    });
  }),

  [DbAction.GetSquadsByExperience]: authed(async () =>
    ok(DbAction.GetSquadsByExperience, { Items: (await listByExperience()).map(buildDatabaseSquad) }),
  ),

  [DbAction.GetSquadWarsDivision]: authed(async ({ player, req }) => {
    const requestedRound = requestedSquadWarRoundId(req);
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

  [DbAction.FindSuggestedSquads]: authed(async ({ player, req }) => {
    const assertedSkill = requestedSuggestedSquadSkill(req.Skill);
    if (assertedSkill !== player!.player.skill) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Skill does not match authenticated player authority.");
    }
    requestedGlobalSquadDirectory(req);
    return ok(DbAction.FindSuggestedSquads, {
      Items: (await suggestedSquads(player!)).map(buildDatabaseSquad),
      IsLocal: false,
    });
  }),

  [DbAction.UpdateSquad]: authed(async ({ player, req }) => {
    // UpdateSquadInfo emits no Squad identity. Bind the mutation to authenticated membership.
    const input = requestedUpdateSquad(req);
    const squad = await updateSquad(player!.id, player!.player.squadName, {
      description: input.description,
      joinPolicy: input.joinPolicy,
      requiredMedals: input.requiredMedals,
    });
    return ok(DbAction.UpdateSquad, { Squad: buildDatabaseSquad(squad) });
  }),

  [DbAction.UpdateSquadEmblem]: authed(async ({ player, req }) => {
    if (typeof req.Icon !== "string") {
      throw new ApiError(ApiErrorCode.UnknownAction, "Squad emblem Icon is invalid.");
    }
    // AOHJMKNDNOD emits only Icon. The current Squad is session-owned and an `Emblem` object or
    // Squad-name alias must not redirect this manager mutation to another document.
    const squad = await updateSquad(player!.id, player!.player.squadName, { emblem: { id: req.Icon } });
    return ok(DbAction.UpdateSquadEmblem, { Squad: buildDatabaseSquad(squad) });
  }),
};
