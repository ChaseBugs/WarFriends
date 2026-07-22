import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  acceptChallenge,
  claimMessageReward,
  ignoreMessage,
  inboxPage,
  listPlayers,
  markRead,
  searchPlayers,
  sendChallenge,
  sendMessage,
  toClientMessage,
} from "../services/socialService";
import { getFriendsInfo } from "../services/friendService";
import { authed, type HandlerEntry } from "./types";
import { parseChallengeMessageRequest } from "./socialRequestParsing";
import { requestedInboxPageLimit } from "../services/socialRequestCountService";
import { publishInboxFanout } from "../services/inboxFanoutService";
import { parseDirectMessageRequest } from "../services/directMessageRequestService";
import { exactInboxMutationMessageId } from "../services/inboxMutationRequestService";

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
    if (req.ChallengedPlayerId !== undefined) {
      const message = await sendChallenge(player!, parseChallengeMessageRequest(req));
      await publishInboxFanout(message.toPlayerId, message.messageId);
      return ok(DbAction.MessageSent, { Delivered: true, MessageId: message.messageId });
    }

    const direct = parseDirectMessageRequest(req);
    const delivered = direct !== null;
    const message = direct
      ? await sendMessage(player!.id, player!.player.accountName, direct.toPlayerId, direct.body)
      : null;
    if (message) await publishInboxFanout(message.toPlayerId, message.messageId);
    return ok(DbAction.MessageSent, { Delivered: delivered, ...(message ? { MessageId: message.messageId } : {}) });
  }),

  [DbAction.GetAllMessages]: authed(async ({ player, req }) => {
    const page = await inboxPage(
      player!.id,
      requestedInboxPageLimit(req),
      str(req.BeforeCursor) || undefined,
    );
    // The stock parser reads only Items and safely ignores NextCursor. A replacement client can
    // round-trip that cursor to reach older durable rows without changing the legacy contract.
    return ok(DbAction.GetAllMessages, {
      Items: page.messages.map(toClientMessage),
      NextCursor: page.nextCursor,
    });
  }),

  [DbAction.ReadMessage]: authed(async ({ player, req }) => {
    const messageId = exactInboxMutationMessageId(req);
    await markRead(player!.id, messageId);
    return ok(DbAction.ReadMessage);
  }),

  [DbAction.IgnoreMessage]: authed(async ({ player, req }) => {
    const messageId = exactInboxMutationMessageId(req);
    return ok(DbAction.IgnoreMessage, { Ignored: await ignoreMessage(player!.id, messageId) });
  }),

  [DbAction.ClaimReward]: authed(async ({ player, req }) => {
    const result = await claimMessageReward(player!.id, exactInboxMutationMessageId(req));
    // FABILEDDNIM reads Gold and Warbucks without ContainsKey guards. Always provide both
    // deltas, including zero Warbucks for a PlayerLeagueFinished Gold reward.
    return ok(DbAction.ClaimReward, {
      Gold: result.Gold,
      Warbucks: result.Warbucks,
      Replayed: result.replayed,
    });
  }),

  [DbAction.AcceptChallenge]: authed(async ({ player, req }) => {
    const messageId = exactInboxMutationMessageId(req);
    return ok(DbAction.AcceptChallenge, { Accepted: await acceptChallenge(player!.id, messageId) });
  }),
};
