import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  acceptChallenge,
  claimMessageReward,
  ignoreMessage,
  inbox,
  listPlayers,
  markRead,
  searchPlayers,
  sendChallenge,
  sendMessage,
  toClientMessage,
} from "../services/socialService";
import { getFriendsInfo } from "../services/friendService";
import { authed, type HandlerEntry } from "./types";

// Player discovery and inbox handlers. Hit-list mutations remain rejected because their
// recovered capacity semantics are ambiguous; normal/challenge messages use exact client
// field names and recipient-owned state changes.

function str(v: unknown): string {
  return typeof v === "string" ? v : "";
}

export const socialHandlers: Record<number, HandlerEntry> = {
  [DbAction.SearchPlayers]: authed(async ({ req }) => {
    const query = str(req.Query) || str(req.PlayerName) || str(req.Name) || str(req.SearchTerm);
    // MAFHBBEKBJJ reads the capitalized Items array and parses each entry as DatabasePlayer.
    return ok(DbAction.SearchPlayers, { Items: await searchPlayers(query) });
  }),

  [DbAction.GetAllPlayers]: authed(async () => ok(DbAction.GetAllPlayers, { Items: await listPlayers() })),

  [DbAction.GetFriendsInfo]: authed(async ({ player, req }) =>
    ok(DbAction.GetFriendsInfo, await getFriendsInfo(player!, req))),

  [DbAction.MessageSent]: authed(async ({ player, req }) => {
    const challengedPlayerId = str(req.ChallengedPlayerId);
    if (challengedPlayerId) {
      const message = await sendChallenge(player!, {
        challengedPlayerId,
        mapName: str(req.MapName),
        gameType: Number(req.GameType) || 0,
        region: Number(req.Region) || 0,
        roomName: str(req.roomName) || "default",
        clientVersion: str(req.clientVersion) || "0.0.0",
        missionType: str(req.MissionType) || undefined,
        numberOfMission: Number.isInteger(Number(req.NumberOfMission)) ? Number(req.NumberOfMission) : undefined,
        missionData: str(req.MissionData) || undefined,
      });
      return ok(DbAction.MessageSent, { Delivered: true, MessageId: message.messageId });
    }

    const to = str(req.ToPlayerId) || str(req.PlayerId);
    const body = str(req.Message) || str(req.Body) || str(req.Text);
    const delivered = Boolean(to && body.trim());
    const message = delivered ? await sendMessage(player!.id, player!.player.accountName, to, body) : null;
    return ok(DbAction.MessageSent, { Delivered: delivered, ...(message ? { MessageId: message.messageId } : {}) });
  }),

  [DbAction.GetAllMessages]: authed(async ({ player, req }) => {
    const items = (await inbox(player!.id, Number(req.Limit) || 50)).map(toClientMessage);
    return ok(DbAction.GetAllMessages, { Items: items });
  }),

  [DbAction.ReadMessage]: authed(async ({ player, req }) => {
    const messageId = str(req.MessageId) || str(req.Id);
    if (messageId) await markRead(player!.id, messageId);
    return ok(DbAction.ReadMessage);
  }),

  [DbAction.IgnoreMessage]: authed(async ({ player, req }) => {
    const messageId = str(req.MessageId) || str(req.Id) || str(req.ObjData);
    return ok(DbAction.IgnoreMessage, { Ignored: messageId ? await ignoreMessage(player!.id, messageId) : false });
  }),

  [DbAction.ClaimReward]: authed(async ({ player, req }) => {
    const result = await claimMessageReward(player!.id, str(req.MessageId) || str(req.Id));
    // FABILEDDNIM reads Gold and Warbucks without ContainsKey guards. Always provide both
    // deltas, including zero Warbucks for a PlayerLeagueFinished Gold reward.
    return ok(DbAction.ClaimReward, {
      Gold: result.Gold,
      Warbucks: result.Warbucks,
      Replayed: result.replayed,
    });
  }),

  [DbAction.AcceptChallenge]: authed(async ({ player, req }) => {
    const messageId = str(req.MessageId) || str(req.Id);
    return ok(DbAction.AcceptChallenge, { Accepted: messageId ? await acceptChallenge(player!.id, messageId) : false });
  }),
};
