import type { MessageDoc } from "./socialService";
import { validatedChallengeMessage } from "./challengeMessageAuthorityService";
import { validatedInboxRewardMessage } from "./inboxRewardAuthorityService";
import { validatedStandardInboxMessage } from "./standardInboxMessageAuthorityService";
import { validatedSquadInvitationMessage } from "./squadInvitationMessageAuthorityService";

/** Route an untyped MongoDB inbox row to its complete message-family validator. */
export function validatedInboxMessageDocument(message: MessageDoc, now?: Date): MessageDoc {
  if (message?.messageType === 0) return validatedChallengeMessage(message, now)!;
  if (message?.messageType === 1) return validatedSquadInvitationMessage(message, now)!;
  if (message && [9, 11, 23].includes(message.messageType)) {
    validatedInboxRewardMessage(message, now);
    return message;
  }
  const standard = validatedStandardInboxMessage(message, now);
  if (standard) return standard;
  throw new Error("Stored inbox message type is unsupported.");
}
