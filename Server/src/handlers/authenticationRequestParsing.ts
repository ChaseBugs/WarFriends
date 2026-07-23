import { ApiError, ApiErrorCode } from "../apiErrors";

export type AuthenticationRequestMode = "login" | "session";

export interface AuthenticationRequestCredentials {
  playerId?: string;
  credential?: string;
}

/**
 * The recovered form builder snapshots `PlayerId` and `Token` when it creates an HTTP request.
 * A RequestBuffer queued before first-account creation can therefore be sent later with either
 * both fields omitted or the exact `null`/`null` sentinels, depending on which recovered HTTP path
 * serialized it. This predicate recognizes only those two no-authority snapshots; aliases or a
 * partially supplied session are not the same case and must continue through strict authentication.
 */
export function isRecoveredPreAccountSessionPlaceholder(
  req: Record<string, unknown>,
): boolean {
  if (Object.prototype.hasOwnProperty.call(req, "id")
    || Object.prototype.hasOwnProperty.call(req, "token")) return false;

  const hasPlayerId = Object.prototype.hasOwnProperty.call(req, "PlayerId");
  const hasToken = Object.prototype.hasOwnProperty.call(req, "Token");
  return (!hasPlayerId && !hasToken)
    || (req.PlayerId === "null" && req.Token === "null");
}

function invalidAuthenticationField(label: string): never {
  throw new ApiError(ApiErrorCode.RequestNotAuthorized, `${label} is invalid.`);
}

function exactAliasValue(
  req: Record<string, unknown>,
  aliases: readonly string[],
  label: string,
): string | undefined {
  const supplied = aliases
    .filter((alias) => Object.prototype.hasOwnProperty.call(req, alias))
    .map((alias) => req[alias]);
  if (supplied.length === 0) return undefined;

  // Replacement JSON clients may carry both the recovered form key and a documented adapter
  // alias. They still describe one authority value. Selecting the first alias would make player
  // ownership depend on object construction order when two values disagree.
  if (supplied.some((value) => typeof value !== "string")
    || supplied.some((value) => value !== supplied[0])) {
    invalidAuthenticationField(label);
  }
  return supplied[0] as string;
}

function exactPlayerId(value: string | undefined): string | undefined {
  if (value === undefined) return undefined;
  if (value === "null"
    || value.length < 1
    || value.length > 256
    || value.trim() !== value
    || /[\u0000-\u001f\u007f]/u.test(value)) {
    invalidAuthenticationField("Player identity");
  }
  return value;
}

function exactCredential(value: string | undefined, mode: AuthenticationRequestMode): string | undefined {
  if (value === undefined) return undefined;
  if (value === "null" || value.length < 1 || value.length > 4_096) {
    invalidAuthenticationField(mode === "login" ? "Login credential" : "Session credential");
  }

  if (mode === "session" && (value.trim() !== value || /[\u0000-\u001f\u007f]/u.test(value))) {
    invalidAuthenticationField("Session credential");
  }
  // A custom-account password is opaque and older accounts may legitimately contain whitespace.
  // Preserve it byte-for-byte here; provider logins receive their stricter provider-specific
  // validation after AccountType selects the corresponding identity authority row.
  return value;
}

/**
 * Parse only the authentication fields emitted by the recovered Beanstalk request builder.
 *
 * Ordinary actions receive the common `PlayerId` + `Token` pair. LoginToCustomAccount is excluded
 * from that common envelope and supplies its own `Id` + `Password` pair instead. In particular,
 * action-specific `Id` fields (match statistics, products, Squads, messages, and similar payloads)
 * must never become an authenticated player identity, and a generic `Password` carried by
 * ChangeNameAndPassword must never substitute for a revoked gameplay session token.
 */
export function exactAuthenticationRequest(
  req: Record<string, unknown>,
  mode: AuthenticationRequestMode,
): AuthenticationRequestCredentials {
  const playerIdAliases = mode === "login"
    ? ["Id", "id", "PlayerId"] as const
    : ["PlayerId", "id"] as const;
  const credentialAliases = mode === "login"
    ? ["Password", "password"] as const
    : ["Token", "token"] as const;

  return {
    playerId: exactPlayerId(exactAliasValue(req, playerIdAliases, "Player identity")),
    credential: exactCredential(
      exactAliasValue(req, credentialAliases, mode === "login" ? "Login credential" : "Session credential"),
      mode,
    ),
  };
}
