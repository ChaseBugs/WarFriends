// Error payloads returned to the client. The recovered client parses server JSON with
// Newtonsoft.Json, reads a numeric `Result` first, and enters its failure dispatcher only for
// values greater than ten. Source-named codes below are exact IJEAJGCCHEF values; the remaining
// generic reconstruction codes stay numeric and above that parser boundary.
export const ApiErrorCode = {
  /** IJEAJGCCHEF.ServerError. Values at or below 10 enter Unity's success dispatcher. */
  InternalServerError: 99_996,
  /** IJEAJGCCHEF.UnAuthorizedAction. */
  RequestNotAuthorized: 99_998,
  /** IJEAJGCCHEF.OldClientVersion. */
  InvalidClientVersion: 99_997,
  /** IJEAJGCCHEF.PlayerNotExists. */
  PlayerNotFound: 3_002,
  OpponentNotFound: 51,
  SquadNotFound: 60,
  /** IJEAJGCCHEF.SquadnameTaken; the stock create dialog handles this exact code. */
  SquadNameTaken: 3701,
  SquadAlreadyExists: 3702,
  SquadIsFull: 3801,
  JoiningSameSquad: 3802,
  NotEnoughSquadSkill: 3803,
  SquadIsNotPublic: 3804,
  SquadNoLongerExists: 3805,
  SquadLeaveError: 4901,
  PromotePlayerError: 5501,
  PromoteToFounderError: 5701,
  DemotePlayerError: 5801,
  KickPlayerError: 5802,
  OnlyLeaderCanSendInvites: 5901,
  NotLeaderOfSquad: 6301,
  PlayerAlreadyInSquadCantJoin: 13201,
  PlayerAlreadyInSquad: 13301,
  SquadJoinRequestNotExists: 13302,
  /** IJEAJGCCHEF.NoActiveEvent; action 113 uses this when no configured season is active. */
  NoActiveEvent: 11302,
  /** IJEAJGCCHEF.NoSkirmishAvailable; the stock client asks the player to relog. */
  NoSkirmishAvailable: 19901,
  /** IJEAJGCCHEF.NotEnoughGoldForSkirmish; its error parser also consumes wallet snapshots. */
  NotEnoughGoldForSkirmish: 19902,
  /** IJEAJGCCHEF.NotEnoughGoldForWarbucks; action 221 has a dedicated stock warning. */
  NotEnoughGoldForWarbucks: 22101,
  SquadFull: 62,
  NotSquadMember: 63,
  InsufficientRank: 64,
  NotEnoughCurrency: 70,
  UnknownAction: 90,
  /** IJEAJGCCHEF.GameCenterAlreadyCreated; the stock client opens UserExistsDialog. */
  GameCenterAlreadyCreated: 15400,
  DailyRewardWrongIndex: 1000001,
  DailyRewardAlreadyClaimed: 1000002,
} as const;

export type ApiErrorPayload = { Result: number; Code: number; Message: string };

export function apiError(code: number, message: string): ApiErrorPayload {
  // OGLEHLIPEFM reads `Result` before it dispatches either the success or failure parser.
  // Keep `Code` as a diagnostic/new-adapter alias, but never make the stock Unity client
  // depend on it because the recovered Beanstalk protocol does not inspect that property.
  return { Result: code, Code: code, Message: message };
}

/** Thrown by handlers to short-circuit with a specific client-facing error. */
export class ApiError extends Error {
  readonly code: number;
  readonly details?: Readonly<Record<string, unknown>>;
  constructor(code: number, message: string, details?: Readonly<Record<string, unknown>>) {
    super(message);
    this.name = "ApiError";
    this.code = code;
    // Some recovered error callbacks require state-repair fields in addition to Result. For
    // example, action 199 reads SkirmishCost, PaidBattles, and PlayerGold after a failed paid
    // attempt. Keeping optional immutable details on the typed error preserves atomic service
    // validation while allowing the common dispatcher to reproduce those exact contracts.
    this.details = details;
  }
}
