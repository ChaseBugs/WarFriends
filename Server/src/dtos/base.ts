// Normalized Beanstalk request/response envelope. The recovered client sends URL-encoded
// form fields with `requestId`, `PlayerId`, and `Token`; JSON aliases are retained for
// diagnostics and adapters. GetConfigurations is the one confirmed raw-text response.

export interface RequestEnvelope {
  /** Normalized action integer (from route, requestId, or DbAction). */
  DbAction: number;
  /** Player id (absent for CreateAccount / first login). */
  id?: string;
  Id?: string;
  PlayerId?: string;
  /** Credential the client stores after account creation and replays on login. */
  password?: string;
  token?: string;
  Token?: string;
  Password?: string;
  requestId?: number | string;
  Version?: number | string;
  Os?: string;
  SheetConfig?: string;
  SheetConfiguraton?: string;
  SheetConfiguration?: string;
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
