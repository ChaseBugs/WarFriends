import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { settleResult } from "../services/matchService";
import { findById } from "../services/playerService";
import { authed, type HandlerEntry } from "./types";

// PvP match lifecycle reported to the meta server (BACKEND.md §3.1). The live turn traffic
// runs over the ws hub; these REST actions record start/end and settle rewards. Exact
// payload field names are ⚠ RE-NEEDED — winner is read flexibly (WinnerId, or Won=self).

function matchId(req: Record<string, unknown>): string {
  const id = req.MatchId ?? req.BattleId;
  return typeof id === "string" ? id : "";
}

export const matchHandlers: Record<number, HandlerEntry> = {
  // Photon master/client start reports — acknowledge; the match row is created at pairing.
  [DbAction.GameStartedMaster]: authed(() => ok(DbAction.GameStartedMaster)),
  [DbAction.GameStartedClient]: authed(() => ok(DbAction.GameStartedClient)),

  [DbAction.GameEnded]: authed(async ({ player, req }) => {
    const id = matchId(req);
    let winnerId = typeof req.WinnerId === "string" ? req.WinnerId : "";
    if (!winnerId && req.Won === true) winnerId = player!.id;

    if (id && winnerId) {
      const settlement = await settleResult(id, winnerId);
      const updated = await findById(player!.id);
      return ok(DbAction.GameEnded, { Settled: settlement.rewarded, WinnerId: settlement.winnerId, Player: updated?.player });
    }
    return ok(DbAction.GameEnded, { Settled: false });
  }),

  // Quick battle vs a bot loadout — acknowledged; reward simulation is a follow-up.
  [DbAction.InstantBattle]: authed(() => ok(DbAction.InstantBattle)),

  // Region latency report — used to bias matchmaking; store is a follow-up, ack for now.
  [DbAction.UpdateRegionPings]: authed(() => ok(DbAction.UpdateRegionPings)),

  // Client couldn't get into a Photon room — irrelevant to the ws relay; ack.
  [DbAction.PhotonIsFull]: authed(() => ok(DbAction.PhotonIsFull)),
};
