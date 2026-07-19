import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { inbox, listPlayers, markRead, searchPlayers, sendMessage } from "../services/socialService";
import { authed, type HandlerEntry } from "./types";

// Player discovery + messaging. Unimplemented hit-list mutations are rejected so callers
// never receive a false success.

function str(v: unknown): string {
  return typeof v === "string" ? v : "";
}

export const socialHandlers: Record<number, HandlerEntry> = {
  [DbAction.SearchPlayers]: authed(async ({ req }) => {
    const query = str(req.Query) || str(req.PlayerName) || str(req.Name) || str(req.SearchTerm);
    return ok(DbAction.SearchPlayers, { players: await searchPlayers(query) });
  }),

  [DbAction.GetAllPlayers]: authed(async () => ok(DbAction.GetAllPlayers, { players: await listPlayers() })),

  // No friend graph yet — return an empty set rather than failing.
  [DbAction.GetFriendsInfo]: authed(() => ok(DbAction.GetFriendsInfo, { facebookFriends: [] })),

  [DbAction.MessageSent]: authed(async ({ player, req }) => {
    const to = str(req.ToPlayerId) || str(req.ChallengedPlayerId) || str(req.PlayerId);
    const body = str(req.Message) || str(req.Body) || str(req.Text);
    const delivered = Boolean(to && body.trim());
    if (delivered) await sendMessage(player!.id, player!.player.accountName, to, body);
    return ok(DbAction.MessageSent, { Delivered: delivered });
  }),

  [DbAction.GetAllMessages]: authed(async ({ player }) =>
    ok(DbAction.GetAllMessages, { messages: await inbox(player!.id) }),
  ),

  [DbAction.ReadMessage]: authed(async ({ player, req }) => {
    const messageId = str(req.MessageId) || str(req.Id);
    if (messageId) await markRead(player!.id, messageId);
    return ok(DbAction.ReadMessage);
  }),
};
