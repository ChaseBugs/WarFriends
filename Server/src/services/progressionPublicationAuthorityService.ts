import type { PlayerProgressionState } from "../db";
import { validatedCoreProgressionBalances } from "./coreProgressionAuthorityService";
import {
  progressionRevisionForRead,
  validateProgressionRevisionAdvance,
} from "./progressionRevisionAuthorityService";
import { validatedProgressionSchemaVersion } from "./progressionSchemaAuthorityService";
import { validatedVipTimeline } from "./vipEntitlementService";
import { validatedSubscriptionAuthorityReceiptId } from "./subscriptionBenefitService";
import { validatedRequestBufferAuthority } from "./requestBufferAuthorityService";

/**
 * Validate the common authority shared by every full progression-document replacement.
 *
 * `mutateProgression` is the usual publisher, but multi-document gameplay and store transactions
 * have to write through their own MongoDB sessions. Keeping the successor proof here prevents
 * those custom paths from drifting: both snapshots need valid balances, and the produced revision
 * must be a strictly newer safe integer before a caller constructs its replacement document.
 */
export function validatedProgressionSuccessor(
  current: PlayerProgressionState,
  next: PlayerProgressionState,
): PlayerProgressionState {
  validatedProgressionSchemaVersion(current.schemaVersion);
  validatedProgressionSchemaVersion(next.schemaVersion);
  validatedVipTimeline(current.vipStart, current.vipExpiration);
  validatedVipTimeline(next.vipStart, next.vipExpiration);
  validatedSubscriptionAuthorityReceiptId(current.subscriptionAuthorityReceiptId);
  validatedSubscriptionAuthorityReceiptId(next.subscriptionAuthorityReceiptId);
  validatedRequestBufferAuthority(current);
  validatedRequestBufferAuthority(next);
  validatedCoreProgressionBalances(current);
  validateProgressionRevisionAdvance(progressionRevisionForRead(current.revision), next.revision);
  validatedCoreProgressionBalances(next);
  return next;
}
