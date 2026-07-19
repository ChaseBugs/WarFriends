// The Beanstalk request/response envelope.
//
// ⚠ RE-NEEDED (BACKEND.md §5): the exact field names and whether the body is
// signed/encrypted are not yet confirmed. The names below are derived from string
// literals in BeanstalkServerManager (`DbAction`, `id`, `password`/`token`,
// `ClientVersion`, device ids). This file is the SINGLE seam for the wire format — when
// the real envelope is confirmed, change it here only.

export interface RequestEnvelope {
  /** DbAction integer selecting the operation. */
  DbAction: number;
  /** Player id (absent for CreateAccount / first login). */
  id?: string;
  /** Credential the client stores after account creation and replays on login. */
  password?: string;
  token?: string;
  /** Client build version, gated against config.minClientVersion. */
  ClientVersion?: number;
  clientVersion?: number;
  /** Device identifiers seen in the client. */
  DeviceToken?: string;
  AndroidID?: string;
  AndroidAdvertisingID?: string;
  BundleId?: string;
  /** Account-linking ids. */
  AccountType?: number;
  FacebookId?: string;
  GooglePlayId?: string;
  GameCenterId?: string;
  /** Action-specific fields ride alongside the known keys. */
  [key: string]: unknown;
}

export interface ResponseEnvelope {
  /** Echo of the action handled, so the client routes the result correctly. */
  DbAction: number;
  /** Optional error surface; when present the client shows ErrorMessage/SystemMessage. */
  Code?: number;
  Message?: string;
  /** Result payload keys are action-specific. */
  [key: string]: unknown;
}

export function ok(action: number, payload: Record<string, unknown> = {}): ResponseEnvelope {
  return { DbAction: action, ...payload };
}
