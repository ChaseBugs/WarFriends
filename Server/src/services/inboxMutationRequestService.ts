import { ApiError, ApiErrorCode } from "../apiErrors";

/**
 * Parse the identity of one direct inbox mutation.
 *
 * Recovered AcceptChallenge and ClaimReward calls send `MessageId`; stock IgnoreMessage uses the
 * separate RequestBuffer data field. `Id` is also a common account-authentication alias and
 * `ObjData` belongs to buffered transport, so neither may be reinterpreted as a direct message row.
 */
export function exactInboxMutationMessageId(req: Record<string, unknown>): string {
  const value = req.MessageId;
  if (typeof value !== "string"
    || value.length < 1
    || value.length > 256
    || value.trim() !== value
    || /\p{Cc}/u.test(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "MessageId is invalid.");
  }
  return value;
}
