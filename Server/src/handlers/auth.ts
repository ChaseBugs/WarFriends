import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { ok, type RequestEnvelope } from "../dtos";
import { createCustomAccount, createFullCustomAccount, ensureSessionToken } from "../services/authService";
import { buildDatabasePlayer, buildPlayerStateResponse } from "../services/playerStateService";
import { authed, open, type HandlerEntry } from "./types";
import {
  buildEventAssignmentClientConfig,
  ensureActiveEventAssignment,
} from "../services/eventAssignmentService";
import { exactRequestedAccountType } from "../services/accountTypeRequestService";
import { exactAuthenticationRequest } from "./authenticationRequestParsing";

// Account and session actions form the boot handshake the client must complete before it
// reaches the menu. Response fields here follow OGLEHLIPEFM's recovered parsers exactly.

function requestCredential(req: RequestEnvelope): string {
  // CreateFullAccount and LoginToCustomAccount both send the dedicated Password field. A Token
  // alias is not equivalent: accepting it here would make response metadata and custom-password
  // creation disagree with the dispatcher's recovered login boundary.
  return exactAuthenticationRequest(req, "login").credential ?? "";
}

function requestedAccountType(req: RequestEnvelope, player: PlayerDocument): AccountType {
  const value = exactRequestedAccountType(req.AccountType);
  // LoginToCustomAccount chooses which provider ID it stores by AccountType. Honor only
  // known enum values; malformed input falls back to the account's current linked mode.
  return value ?? player.player.accountType;
}

async function accountPayload(
  player: PlayerDocument,
  password: string,
  accountType: AccountType,
): Promise<Record<string, unknown>> {
  // Token is the internal session credential sent with every ordinary PlayerId request.
  // Password is retained separately because GameLoginManager stores it under the selected
  // provider and reuses it only on a later LoginToCustomAccount call.
  const sessionToken = player.authToken ?? password;
  const eventAssignment = await ensureActiveEventAssignment(player.id);
  const projected = eventAssignment ? { ...player, progression: eventAssignment.state } : player;
  return {
    id: player.id,
    Id: player.id,
    PlayerId: player.id,
    token: sessionToken,
    Token: sessionToken,
    password,
    Password: password,
    AccountType: accountType,
    Player: buildDatabasePlayer(projected),
    ...buildPlayerStateResponse(projected),
    ...(eventAssignment ? {
      EventAssignmentConfig: buildEventAssignmentClientConfig(eventAssignment.event),
    } : {}),
  };
}

export const authHandlers: Record<number, HandlerEntry> = {
  [DbAction.CreateAccount]: open(async ({ req }) => {
    const accountName = typeof req.AccountName === "string" ? req.AccountName : "";
    const created = await createCustomAccount(accountName, AccountType.Guest, req.DeviceToken);
    return ok(
      DbAction.CreateAccount,
      await accountPayload(created.doc, created.authToken, AccountType.Guest),
    );
  }),

  // A full account receives a human password for future login and a separate session token
  // for gameplay requests. This preserves the two values saved by GameLoginManager.
  [DbAction.CreateFullAccount]: open(async ({ req }) => {
    const accountName = typeof req.AccountName === "string" ? req.AccountName : "";
    const requestedPassword = requestCredential(req);
    const created = await createFullCustomAccount(accountName, requestedPassword, req.DeviceToken);
    return ok(DbAction.CreateFullAccount, await accountPayload(created.doc, requestedPassword, AccountType.Guest));
  }),

  [DbAction.LoginToCustomAccount]: authed(async ({ player, req }) => {
    // The dispatcher has already verified either the custom credential or the selected
    // platform identity. Returning all fields is still mandatory: the client parser reads
    // AccountType, Token, and Password unconditionally before saving the account locally.
    await ensureSessionToken(player!);
    return ok(
      DbAction.LoginToCustomAccount,
      await accountPayload(player!, requestCredential(req), requestedAccountType(req, player!)),
    );
  }),
};
