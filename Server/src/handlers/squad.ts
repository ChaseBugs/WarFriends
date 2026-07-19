import { DbAction } from "../dbActions";
import { SquadRank } from "../constants";
import { ok } from "../dtos";
import {
  createSquad,
  getByName,
  isNameAvailable,
  joinSquad,
  kickMember,
  leaveSquad,
  listByExperience,
  setMemberRank,
} from "../services/squadService";
import { authed, type HandlerEntry } from "./types";

// Squad system — BACKEND.md §2.5. Every handler is authenticated; rank checks live in the
// service layer.

function squadName(req: Record<string, unknown>): string {
  const name = req.SquadName ?? req.SquadId ?? req.Name;
  return typeof name === "string" ? name : "";
}

function targetId(req: Record<string, unknown>): string {
  const id = req.TargetPlayerId ?? req.PlayerId ?? req.id;
  return typeof id === "string" ? id : "";
}

export const squadHandlers: Record<number, HandlerEntry> = {
  [DbAction.CheckUniqueSquadName]: authed(async ({ req }) => {
    const available = await isNameAvailable(squadName(req));
    return ok(available ? DbAction.UniqueSquadNameSuccess : DbAction.UniqueSquadNameFailure, { Available: available });
  }),

  [DbAction.CreateSquad]: authed(async ({ player, req }) => {
    const squad = await createSquad(player!.id, squadName(req));
    return ok(DbAction.CreateSquad, { Squad: squad });
  }),

  [DbAction.JoinSquad]: authed(async ({ player, req }) => {
    const squad = await joinSquad(player!.id, squadName(req));
    return ok(DbAction.JoinSquad, { Squad: squad });
  }),

  [DbAction.LeaveSquad]: authed(async ({ player, req }) => {
    await leaveSquad(player!.id, squadName(req) || player!.player.squadName);
    return ok(DbAction.LeaveSquad);
  }),

  [DbAction.PromotePlayer]: authed(async ({ player, req }) => {
    const squad = await setMemberRank(player!.id, targetId(req), squadName(req), SquadRank.Officer);
    return ok(DbAction.PromotePlayer, { Squad: squad });
  }),

  [DbAction.PromotePlayerToFounder]: authed(async ({ player, req }) => {
    const squad = await setMemberRank(player!.id, targetId(req), squadName(req), SquadRank.Founder);
    return ok(DbAction.PromotePlayerToFounder, { Squad: squad });
  }),

  [DbAction.DemotePlayer]: authed(async ({ player, req }) => {
    const squad = await setMemberRank(player!.id, targetId(req), squadName(req), SquadRank.Member);
    return ok(DbAction.DemotePlayer, { Squad: squad });
  }),

  [DbAction.KickPlayer]: authed(async ({ player, req }) => {
    const squad = await kickMember(player!.id, targetId(req), squadName(req));
    return ok(DbAction.KickPlayer, { Squad: squad });
  }),

  [DbAction.RemoveUserFromSquad]: authed(async ({ player, req }) => {
    const squad = await kickMember(player!.id, targetId(req), squadName(req));
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
    const squad = await getByName(squadName(req) || player!.player.squadName);
    return ok(DbAction.GetAllSquadMembers, { Members: squad?.members ?? [] });
  }),

  [DbAction.GetSquads]: authed(async () => ok(DbAction.GetSquads, { Squads: await listByExperience() })),

  [DbAction.GetSquadsByExperience]: authed(async () =>
    ok(DbAction.GetSquadsByExperience, { Squads: await listByExperience() }),
  ),

  [DbAction.FindSuggestedSquads]: authed(async () =>
    ok(DbAction.FindSuggestedSquads, { Squads: await listByExperience(20) }),
  ),
};
