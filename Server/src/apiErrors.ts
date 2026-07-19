// Error payloads returned to the client. The recovered client parses server JSON with
// Newtonsoft.Json and (per BeanstalkServerManager) treats an empty body as an error and
// surfaces ErrorMessage/SystemMessage. Exact server error codes are still ⚠ RE-NEEDED
// (BACKEND.md §5); these are provisional and MUST be numeric (no StringEnumConverter on
// the client).
export const ApiErrorCode = {
  InternalServerError: 0,
  RequestNotAuthorized: 10,
  InvalidClientVersion: 20,
  PlayerNotFound: 50,
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

export type ApiErrorPayload = { Code: number; Message: string };

export function apiError(code: number, message: string): ApiErrorPayload {
  return { Code: code, Message: message };
}

/** Thrown by handlers to short-circuit with a specific client-facing error. */
export class ApiError extends Error {
  readonly code: number;
  constructor(code: number, message: string) {
    super(message);
    this.name = "ApiError";
    this.code = code;
  }
}
