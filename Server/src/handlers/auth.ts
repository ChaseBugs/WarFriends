import { DbAction } from "../dbActions";
import { AccountType } from "../constants";
import { ok } from "../dtos";
import { createCustomAccount } from "../services/authService";
import { authed, open, type HandlerEntry } from "./types";

// Account / session actions — BACKEND.md §2.2. CreateAccount and LoginToCustomAccount are
// the boot handshake the client must complete before it reaches the menu.

export const authHandlers: Record<number, HandlerEntry> = {
  [DbAction.CreateAccount]: open(async ({ req }) => {
    const accountName = typeof req.AccountName === "string" ? req.AccountName : "";
    const created = await createCustomAccount(accountName, AccountType.Custom, req.DeviceToken);
    return ok(DbAction.CreateAccount, {
      id: created.doc.id,
      token: created.authToken,
      password: created.authToken,
      Player: created.player,
    });
  }),

  // Full account = custom account with a chosen name/password. Same shape for now.
  [DbAction.CreateFullAccount]: open(async ({ req }) => {
    const accountName = typeof req.AccountName === "string" ? req.AccountName : "";
    const created = await createCustomAccount(accountName, AccountType.Custom, req.DeviceToken);
    return ok(DbAction.CreateFullAccount, {
      id: created.doc.id,
      token: created.authToken,
      password: created.authToken,
      Player: created.player,
    });
  }),

  // Credentials are verified by the dispatcher (requiresAuth); just return the snapshot.
  [DbAction.LoginToCustomAccount]: authed(({ player }) =>
    ok(DbAction.LoginToCustomAccount, { id: player!.id, Player: player!.player }),
  ),
};
