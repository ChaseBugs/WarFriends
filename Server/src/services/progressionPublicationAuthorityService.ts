import type { PlayerProgressionState } from "../db";
import { validatedCoreProgressionBalances } from "./coreProgressionAuthorityService";
import {
  progressionRevisionForRead,
  validateProgressionRevisionAdvance,
} from "./progressionRevisionAuthorityService";
import { validatedProgressionSchemaVersion } from "./progressionSchemaAuthorityService";
import { validatedVipTimeline } from "./vipEntitlementService";
import {
  validatedSubscription,
  validatedSubscriptionAuthorityReceiptId,
} from "./subscriptionBenefitService";
import { validatedRequestBufferAuthority } from "./requestBufferAuthorityService";
import { validatedWarBucksConversionReceipt } from "./warBucksConversionAuthorityService";
import { validatedVipDailyCardState } from "./vipDailyCardAuthorityService";
import { validatedCardLifecycleCounters } from "./cardLifecycleCounterAuthorityService";
import { cardCraftingAuthorityFor } from "./cardCraftingAuthorityService";
import { cardInventoryAuthorityFor } from "./cardInventoryAuthorityService";
import { validatedPvpWinStreakShape } from "./pvpWinStreakAuthorityService";
import { validatedVipLootboxCountdown } from "./vipLootboxService";
import { validatedCollectedRewards } from "./oneTimeRewardAuthorityService";
import { validatedTutorialLifecycleShape } from "./tutorialCompletionAuthorityService";
import { validatedFeatureIntroductions } from "./featureIntroductionAuthorityService";
import { validatedSquadCreationsCount } from "./squadCreationAuthorityService";
import { validatedInstantBattleShape } from "./instantBattleAuthorityService";
import { validatedVideoAdRewardStateShape } from "./videoAdRewardAuthorityService";
import { validatedRentalState } from "./rentalEntitlementService";
import { validatedBlackMarketOfferState } from "./blackMarketEntitlementService";
import { validatedVisualInventoryState } from "./visualEntitlementService";
import { itemInventoryAuthorityFor } from "./itemInventoryAuthorityService";
import { dailyRewardAuthorityFor } from "./dailyRewardAuthorityService";

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
  now = Math.floor(Date.now() / 1000),
): PlayerProgressionState {
  validatedProgressionSchemaVersion(current.schemaVersion);
  validatedProgressionSchemaVersion(next.schemaVersion);
  validatedVipTimeline(current.vipStart, current.vipExpiration);
  validatedVipTimeline(next.vipStart, next.vipExpiration);
  validatedSubscriptionAuthorityReceiptId(current.subscriptionAuthorityReceiptId);
  validatedSubscriptionAuthorityReceiptId(next.subscriptionAuthorityReceiptId);
  validatedSubscription(current.subscription);
  validatedSubscription(next.subscription);
  validatedRequestBufferAuthority(current);
  validatedRequestBufferAuthority(next);
  validatedWarBucksConversionReceipt(current.warBucksConversion, current.revision);
  validatedWarBucksConversionReceipt(next.warBucksConversion, next.revision);
  validatedVipDailyCardState(current.vipDailyCards);
  validatedVipDailyCardState(next.vipDailyCards);
  validatedCardLifecycleCounters(current);
  validatedCardLifecycleCounters(next);
  cardCraftingAuthorityFor(current.cardCrafting);
  cardCraftingAuthorityFor(next.cardCrafting);
  cardInventoryAuthorityFor(current.cardInventory);
  cardInventoryAuthorityFor(next.cardInventory);
  validatedPvpWinStreakShape(current.pvpWinStreak);
  validatedPvpWinStreakShape(next.pvpWinStreak);
  validatedVipLootboxCountdown(current.matchesToNextLootboxes);
  validatedVipLootboxCountdown(next.matchesToNextLootboxes);
  validatedCollectedRewards(current.collectedRewards);
  validatedCollectedRewards(next.collectedRewards);
  validatedTutorialLifecycleShape(current);
  validatedTutorialLifecycleShape(next);
  validatedFeatureIntroductions(current.featureIntroductions);
  validatedFeatureIntroductions(next.featureIntroductions);
  validatedSquadCreationsCount(current.squadCreationsCount);
  validatedSquadCreationsCount(next.squadCreationsCount);
  validatedInstantBattleShape(current.instantBattle, progressionRevisionForRead(current.revision));
  validatedInstantBattleShape(next.instantBattle, progressionRevisionForRead(next.revision));
  validatedVideoAdRewardStateShape(current.videoAdRewards, progressionRevisionForRead(current.revision));
  validatedVideoAdRewardStateShape(next.videoAdRewards, progressionRevisionForRead(next.revision));
  validatedRentalState(current.rental);
  validatedRentalState(next.rental);
  validatedBlackMarketOfferState(current.blackMarket);
  validatedBlackMarketOfferState(next.blackMarket);
  validatedVisualInventoryState(current.visualInventory);
  validatedVisualInventoryState(next.visualInventory);
  itemInventoryAuthorityFor(current.itemInventory);
  itemInventoryAuthorityFor(next.itemInventory);
  dailyRewardAuthorityFor(current.dailyReward, now);
  dailyRewardAuthorityFor(next.dailyReward, now);
  validatedCoreProgressionBalances(current);
  validateProgressionRevisionAdvance(progressionRevisionForRead(current.revision), next.revision);
  validatedCoreProgressionBalances(next);
  return next;
}
