import type { PlayerDocument } from "../db";
import {
  acknowledgeBufferedMessageIgnores,
  processAssignmentBuffer,
  type AssignmentBufferResult,
  type BufferedRequestInput,
} from "./assignmentService";
import { validatedRequestBufferAuthority } from "./requestBufferAuthorityService";
import { ignoreMessage } from "./socialService";

/** Execute one stock RequestBuffer and finish its durable cross-collection ignore outbox. */
export async function executeRecoveredRequestBuffer(
  player: PlayerDocument,
  id: string,
  requests: readonly BufferedRequestInput[],
): Promise<AssignmentBufferResult> {
  const result = await processAssignmentBuffer(
    player.id,
    id,
    requests,
    player.player.level,
    player.progression?.vipExpiration ?? player.player.vipExpiration,
    player.player.leagueTier,
  );
  const pendingMessageIgnores = validatedRequestBufferAuthority(result.state).pendingMessageIgnores;
  if (pendingMessageIgnores.length > 0) {
    // Action 12 is idempotent and recipient-filtered. Drain every durable outbox entry before
    // acknowledging the enclosing request, then clear only those completed IDs. A failed write
    // leaves the entry durable for the next action-34 or action-98 replay.
    for (const messageId of pendingMessageIgnores) {
      await ignoreMessage(player.id, messageId);
    }
    await acknowledgeBufferedMessageIgnores(player.id, pendingMessageIgnores);
  }
  return result;
}
