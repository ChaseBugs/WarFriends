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
  transferLeadership,
  updateSquad,
} from "../services/squadService";
import { authed, type HandlerEntry } from "./types";

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
  [DbAction.CheckUniqueSquadName]: authed(async ({ req }) => {
    const available = await isNameAvailable(squadName(req));
    return ok(available ? DbAction.UniqueSquadNameSuccess : DbAction.UniqueSquadNameFailure, { Available: available });
  }),

  [DbAction.CreateSquad]: authed(async ({ player, req }) => {
    const squad = await createSquad(player!.id, squadName(req), {
      description: typeof req.Message === "string" ? req.Message : undefined,
      emblem: emblem(req),
      joinPolicy: joinPolicy(req),
      requiredMedals: integer(req.RequiredMedals ?? req.SkillRequirement),
    });
    return ok(DbAction.CreateSquad, { Squad: squad, SquadId: squad.name, PlayerRank: 2 });
  }),

  [DbAction.JoinSquad]: authed(async ({ player, req }) => {
    const squad = await joinSquad(player!.id, squadName(req));
    return ok(DbAction.JoinSquad, { Squad: squad, SquadId: squad.name, PlayerRank: 0 });
  }),

  [DbAction.JoinSquadRequest]: authed(async ({ player, req }) => {
    const squad = await requestToJoin(player!.id, squadName(req));
    return ok(DbAction.JoinSquadRequest, { Squad: squad });
  }),

  [DbAction.AcceptSquadJoinRequest]: authed(async ({ player, req }) => {
    const name = squadName(req) || player!.player.squadName;
    const squad = await acceptJoinRequest(player!.id, targetId(req), name);
    return ok(DbAction.AcceptSquadJoinRequest, { Squad: squad });
  }),

  [DbAction.DeclineSquadJoinRequest]: authed(async ({ player, req }) => {
    const squad = await declineJoinRequest(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    return ok(DbAction.DeclineSquadJoinRequest, { Squad: squad });
  }),

  [DbAction.InvitePlayerToSquad]: authed(async ({ player, req }) => {
    const squad = await invitePlayer(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    return ok(DbAction.InvitePlayerToSquad, { Squad: squad });
  }),

  [DbAction.LeaveSquad]: authed(async ({ player, req }) => {
    await leaveSquad(player!.id, squadName(req) || player!.player.squadName);
    return ok(DbAction.LeaveSquad);
  }),

  [DbAction.PromotePlayer]: authed(async ({ player, req }) => {
    const squad = await promoteMember(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    return ok(DbAction.PromotePlayer, { Squad: squad });
  }),

  [DbAction.PromotePlayerToFounder]: authed(async ({ player, req }) => {
    const squad = await transferLeadership(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    return ok(DbAction.PromotePlayerToFounder, { Squad: squad });
  }),

  [DbAction.DemotePlayer]: authed(async ({ player, req }) => {
    const squad = await demoteMember(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    return ok(DbAction.DemotePlayer, { Squad: squad });
  }),

  [DbAction.KickPlayer]: authed(async ({ player, req }) => {
    const squad = await kickMember(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    return ok(DbAction.KickPlayer, { Squad: squad });
  }),

  [DbAction.RemoveUserFromSquad]: authed(async ({ player, req }) => {
    const squad = await kickMember(player!.id, targetId(req), squadName(req) || player!.player.squadName);
    return ok(DbAction.RemoveUserFromSquad, { Squad: squad });
  }),

  [DbAction.GetSquadDetails]: authed(async ({ player, req }) => {
    const squad = await getByName(squadName(req) || player!.player.squadName);
    return ok(DbAction.GetSquadDetails, { Squad: squad });
  }),

  [DbAction.GetFullSquadInfo]: authed(async ({ player, req }) => {
    const squad = await getByName(squadName(req) || player!.player.squadName);
    return ok(DbAction.GetFullSquadInfo, { Squad: squad });
  }),

  [DbAction.GetAllSquadMembers]: authed(async ({ player, req }) => {
    const members = await getSquadMemberPlayers(squadName(req) || player!.player.squadName);
    return ok(DbAction.GetAllSquadMembers, { SquadMembers: members, Members: members });
  }),

  [DbAction.GetSquads]: authed(async () => ok(DbAction.GetSquads, { Squads: await listByExperience() })),

  [DbAction.GetSquadsByExperience]: authed(async () =>
    ok(DbAction.GetSquadsByExperience, { Squads: await listByExperience() }),
  ),

  [DbAction.FindSuggestedSquads]: authed(async () =>
    ok(DbAction.FindSuggestedSquads, { Squads: await listByExperience(20) }),
  ),

  [DbAction.UpdateSquad]: authed(async ({ player, req }) => {
    const squad = await updateSquad(player!.id, squadName(req) || player!.player.squadName, {
      description: typeof req.Message === "string" ? req.Message : undefined,
      joinPolicy: joinPolicy(req),
      requiredMedals: req.RequiredMedals === undefined ? undefined : integer(req.RequiredMedals),
    });
    return ok(DbAction.UpdateSquad, { Squad: squad });
  }),

  [DbAction.UpdateSquadEmblem]: authed(async ({ player, req }) => {
    const squad = await updateSquad(player!.id, squadName(req) || player!.player.squadName, { emblem: emblem(req) });
    return ok(DbAction.UpdateSquadEmblem, { Squad: squad });
  }),
};
