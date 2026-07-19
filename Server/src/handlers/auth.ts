import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { ok, type RequestEnvelope } from "../dtos";
import { createCustomAccount, ensureSessionToken, replaceCustomCredential } from "../services/authService";
import { buildDatabasePlayer, buildPlayerStateResponse } from "../services/playerStateService";
import { authed, open, type HandlerEntry } from "./types";

// Account and session actions form the boot handshake the client must complete before it
// reaches the menu. Response fields here follow OGLEHLIPEFM's recovered parsers exactly.

function requestCredential(req: RequestEnvelope): string {
  const value = req.Password ?? req.password ?? req.Token ?? req.token;
  return typeof value === "string" && value !== "null" ? value : "";
}

function requestedAccountType(req: RequestEnvelope, player: PlayerDocument): AccountType {
  const value = Number(req.AccountType);
  // LoginToCustomAccount chooses which provider ID it stores by AccountType. Honor only
  // known enum values; malformed input falls back to the account's current linked mode.
  return value === AccountType.Guest ||
    value === AccountType.Facebook ||
    value === AccountType.GameCenter ||
    value === AccountType.GooglePlay
    ? value
    : player.player.accountType;
}

function accountPayload(
  player: PlayerDocument,
  password: string,
  accountType: AccountType,
): Record<string, unknown> {
  // Token is the internal session credential sent with every ordinary PlayerId request.
  // Password is retained separately because GameLoginManager stores it under the selected
  // provider and reuses it only on a later LoginToCustomAccount call.
  const sessionToken = player.authToken ?? password;
  return {
    id: player.id,
    Id: player.id,
    PlayerId: player.id,
    token: sessionToken,
    Token: sessionToken,
    password,
    Password: password,
    AccountType: accountType,
    Player: buildDatabasePlayer(player),
    ...buildPlayerStateResponse(player),
  };
}

export const authHandlers: Record<number, HandlerEntry> = {
  [DbAction.CreateAccount]: open(async ({ req }) => {
    const accountName = typeof req.AccountName === "string" ? req.AccountName : "";
    const created = await createCustomAccount(accountName, AccountType.Guest, req.DeviceToken);
    return ok(
      DbAction.CreateAccount,
      accountPayload(created.doc, created.authToken, AccountType.Guest),
    );
  }),

  // A full account receives a human password for future login and a separate session token
  // for gameplay requests. This preserves the two values saved by GameLoginManager.
  [DbAction.CreateFullAccount]: open(async ({ req }) => {
    const accountName = typeof req.AccountName === "string" ? req.AccountName : "";
    const created = await createCustomAccount(accountName, AccountType.Guest, req.DeviceToken);
    const requestedPassword = requestCredential(req);
    const password = requestedPassword.length >= 6 && requestedPassword.length <= 128
      ? requestedPassword
      : created.authToken;
    if (password !== created.authToken) {
      created.doc.authToken = await replaceCustomCredential(created.doc.id, password);
    }
    return ok(DbAction.CreateFullAccount, accountPayload(created.doc, password, AccountType.Guest));
  }),

  [DbAction.LoginToCustomAccount]: authed(async ({ player, req }) => {
    // The dispatcher has already verified either the custom credential or the selected
    // platform identity. Returning all fields is still mandatory: the client parser reads
    // AccountType, Token, and Password unconditionally before saving the account locally.
    await ensureSessionToken(player!);
    return ok(
      DbAction.LoginToCustomAccount,
      accountPayload(player!, requestCredential(req), requestedAccountType(req, player!)),
    );
  }),
};
