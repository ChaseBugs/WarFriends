import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import type { DailyMissionMode, PlayerProgressionState } from "../db";
import { ok } from "../dtos";
import {
  getMatch,
  pvpGameReward,
  pvpLevelFields,
  reportMatchResult,
  waitForMatchResolution,
  winnerFromEndReason,
} from "../services/matchService";
import { settleDailyMission } from "../services/dailyMissionService";
import { settleWarArenaBattle, startWarArenaBattle } from "../services/warArenaService";
import { findById } from "../services/playerService";
import { progressionForPlayer, unixNow } from "../services/playerStateService";
import { authed, type HandlerEntry } from "./types";
import { getSquadEventWireFields } from "../services/squadEventService";
import logger from "../utils/logger";
import { playerLeagueBootFields } from "../services/playerLeagueContract";
import { advanceRentalAfterBattle } from "../services/rentalService";
import { VIP_LOOTBOX_MATCH_INTERVAL } from "../services/vipLootboxService";
import { parseInternetConnection, parseRegionPings } from "../services/regionPingService";
import { updatePlayerFields } from "../services/playerService";
import {
  settleWarcardsTutorial,
  shouldStartWarcardsTutorial,
  startWarcardsTutorial,
} from "../services/warcardsTutorialService";
import {
  findFriendlyBattle,
  parseOfflineBotStartMetadata,
  settleFriendlyBattle,
  startFriendlyBattle,
} from "../services/friendlyBattleService";
import {
  assertedPvpWinnerId,
  exactGameEndedUsedCards,
  exactMatchInteger,
} from "./matchRequestParsing";
import { exactBinaryBoolean } from "./requestBooleanParsing";

// PvP match lifecycle reported to the meta server. Live event traffic runs over /hub, while
// these actions preserve compatibility with the recovered client's Photon-era REST calls.

function matchId(req: Record<string, unknown>): string {
  // PvP historically names the durable record MatchId, while the stock Photon-era client
  // sends BattleId. Normalizing both names here keeps the settlement logic transport-neutral.
  const id = req.MatchId ?? req.BattleId;
  return typeof id === "string" ? id : "";
}

function missionMode(value: unknown): DailyMissionMode {
  // These strings are enum.ToString() values from GEIKAIJBCPE in the recovered client.
  // Do not accept numeric aliases: a loose conversion could map an unknown future mode to a
  // reward-bearing mode and weaken the start-action/mode ownership check.
  if (value === "Daily" || value === "Coop" || value === "CoopClient" || value === "Heroic") return value;
  throw new ApiError(ApiErrorCode.UnknownAction, "MissionType is invalid.");
}

/**
 * Convert a consumed free trial into the sale variant embedded in GameEnded.
 *
 * Match/mission rewards may already be committed before this auxiliary progression write.
 * A rental failure must therefore be logged and omitted instead of changing a successful
 * battle into a retry that could confuse the end screen. The battle ID stored by the rental
 * service makes a lost-response retry reproduce the same sale without consuming another item.
 */
async function rentalFieldsAfterBattle(
  playerId: string,
  battleId: string,
  state: PlayerProgressionState,
): Promise<Record<string, unknown>> {
  const rental = state.rental;
  if (!rental || !battleId || (
    rental.status !== "trial"
    && !(rental.status === "sale" && rental.saleBattleId === battleId)
  )) return {};
  try {
    const result = await advanceRentalAfterBattle(playerId, battleId);
    return result.saleOffer ? { Rental: result.saleOffer } : {};
  } catch (error) {
    logger.warnWithEmoji("⚠️", "Could not append rental sale to GameEnded", "RENTAL", {
      playerId,
      battleId,
      error: error instanceof Error ? error.message : String(error),
    });
    return {};
  }
}

export const matchHandlers: Record<number, HandlerEntry> = {
  // Ranked reports are lifecycle telemetry only: matchmaking establishes their persistent
  // match ownership, so a start report cannot create or join an arbitrary rewarded match.
  // IsMatchMaking=0 is different only in that it creates a separate zero-reward friendly
  // receipt; that collection has no path into ranked settlement or progression mutations.
  [DbAction.GameStartedMaster]: authed(async ({ player, req }) => {
    const isWarArenaBattle = exactBinaryBoolean(req.IsWarArenaBattle, "IsWarArenaBattle")!;
    const isMatchMaking = exactBinaryBoolean(req.IsMatchMaking, "IsMatchMaking")!;
    if (!isWarArenaBattle) {
      if (!isMatchMaking) {
        // Direct challenges are already connected through the Photon room embedded in the
        // accepted inbox message. Action 64 supplies the room's battleID but no opponent/message
        // identifier, so create only this authenticated participant's no-reward lifecycle proof.
        const result = await startFriendlyBattle(
          player!.id,
          matchId(req),
          DbAction.GameStartedMaster,
        );
        return ok(DbAction.GameStartedMaster, { Time: unixNow(), Replayed: result.replayed });
      }
      // StartTutorialMatch deliberately enters the normal offline deathmatch controller. Its
      // LoadingStarted callback therefore looks like an ordinary bot action 64: matchmaking is
      // enabled and BotId is present, but there is no dedicated tutorial flag until GameEnded.
      // Server-owned cardTutState is therefore the only safe discriminator. Other bot starts
      // receive a separate zero-reward lifecycle receipt; their client-simulated combat can never
      // enter ranked settlement or become economy/progression authority.
      if (isMatchMaking && req.BotId !== undefined) {
        const progression = progressionForPlayer(player!);
        if (shouldStartWarcardsTutorial(progression, player!.player.level)) {
          const result = await startWarcardsTutorial(player!.id, player!.player.level, matchId(req));
          if (result.started) {
            return ok(DbAction.GameStartedMaster, {
              Time: unixNow(),
              Replayed: result.replayed,
            });
          }
          // Another request may have completed the tutorial between the attached player read and
          // mutateProgression's current-state read. In that race, continue into the ordinary bot
          // path instead of acknowledging a tutorial receipt that was never stored.
        }
        parseOfflineBotStartMetadata(req.BotId, req.BotName, req.BotLevel);
        const result = await startFriendlyBattle(
          player!.id,
          matchId(req),
          DbAction.GameStartedMaster,
          "offline-bot",
        );
        return ok(DbAction.GameStartedMaster, {
          Time: unixNow(),
          Replayed: result.replayed,
          OfflineBotBattle: true,
        });
      }
      return ok(DbAction.GameStartedMaster, { Time: unixNow() });
    }
    const result = await startWarArenaBattle(player!.id, matchId(req));
    // NCAKLEOEDBO reads Time unconditionally and BattleId conditionally for every start
    // action. The Arena receipt uses the same parser as ordinary PvP starts.
    return ok(DbAction.GameStartedMaster, { ...result.response, Time: unixNow(), Replayed: result.replayed });
  }),
  [DbAction.GameStartedClient]: authed(async ({ player, req }) => {
    const isWarArenaBattle = exactBinaryBoolean(req.IsWarArenaBattle, "IsWarArenaBattle")!;
    const isMatchMaking = exactBinaryBoolean(req.IsMatchMaking, "IsMatchMaking")!;
    if (!isWarArenaBattle) {
      if (!isMatchMaking) {
        const result = await startFriendlyBattle(
          player!.id,
          matchId(req),
          DbAction.GameStartedClient,
        );
        return ok(DbAction.GameStartedClient, { Time: unixNow(), Replayed: result.replayed });
      }
      return ok(DbAction.GameStartedClient, { Time: unixNow() });
    }
    const result = await startWarArenaBattle(player!.id, matchId(req));
    return ok(DbAction.GameStartedClient, { ...result.response, Time: unixNow(), Replayed: result.replayed });
  }),

  [DbAction.GameEnded]: authed(async ({ player, req }) => {
    const id = matchId(req);
    const tutorialWarcards = exactBinaryBoolean(req.TutorialWarcards, "TutorialWarcards", false) ?? false;
    const isWarArena = exactBinaryBoolean(req.IsWarArena, "IsWarArena", false) ?? false;
    if (tutorialWarcards) {
      // This flag and ObtainedCards are both client-controlled. The service ignores the latter,
      // requires the earlier action-64 BattleId receipt, and grants the fixed MainScene list at
      // most once. Branch before PvP lookup because this tutorial is an offline bot match and
      // correctly has no two-participant match-consensus document.
      const result = await settleWarcardsTutorial(
        player!.id,
        player!.player.level,
        id,
        exactMatchInteger(req.EndReason, "EndReason"),
      );
      return ok(DbAction.GameEnded, {
        Settled: result.awarded || result.replayed,
        ResultStatus: result.awarded || result.replayed ? "finished" : "tutorial-forfeit",
        GameReward: pvpGameReward(true),
        LevelExperience: result.state.levelExperience,
        Skill: player!.player.skill,
        MedalsBalance: player!.player.medalsBalance,
        PlacementMatchesRequired: player!.player.remainingMatches,
        BeginnersLeague: player!.player.beginnersLeague,
        MatchesToNextLootboxes: result.state.matchesToNextLootboxes ?? VIP_LOOTBOX_MATCH_INTERVAL,
        Time: unixNow(),
        Replayed: result.replayed,
      });
    }
    if (isWarArena) {
      // BeanstalkServerManager adds IsWarArena to action 62. Branch before normal PvP: an
      // Arena BattleId belongs to the player's persistent run receipt, not the two-party
      // match-consensus collection. The service still requires the action-64/65 start proof.
      const result = await settleWarArenaBattle(player!.id, {
        battleId: id,
        endReason: exactMatchInteger(req.EndReason, "EndReason"),
      });
      const rentalFields = await rentalFieldsAfterBattle(player!.id, id, result.state);
      return ok(DbAction.GameEnded, {
        ...result.response,
        ...rentalFields,
        LevelExperience: result.state.levelExperience,
        Time: unixNow(),
        Replayed: result.replayed,
      });
    }
    if (req.MissionType !== undefined) {
      // BeanstalkServerManager.GameEnded adds MissionType and zero-based MissionIndex only
      // when GameController.isMission is true. Branch before the PvP lookup: campaign
      // BattleIds identify short-lived mission receipts, not two-player match documents.
      // The service still validates that this BattleId was issued by the matching start
      // action, so the presence of MissionType alone is not enough to obtain a reward.
      const result = await settleDailyMission(player!.id, {
        battleId: id,
        missionIndex: exactMatchInteger(req.MissionIndex, "MissionIndex"),
        missionType: missionMode(req.MissionType),
        endReason: exactMatchInteger(req.EndReason, "EndReason"),
      });
      const rentalFields = await rentalFieldsAfterBattle(player!.id, id, result.state);
      return ok(DbAction.GameEnded, {
        ...result.response,
        ...rentalFields,
        // OGLEHLIPEFM.PKAHEEJBBNP reads LevelExperience without a ContainsKey guard after
        // IsWarPath selects the mission parser. Return it for success, failure, and replay.
        LevelExperience: result.state.levelExperience,
        // Time is included for parity with the other lifecycle responses and lets repaired
        // clients correct clock drift. The stock mission parser safely ignores it.
        Time: unixNow(),
        Replayed: result.replayed,
      });
    }

    const friendlyReceipt = id ? await findFriendlyBattle(player!.id, id) : null;
    if (friendlyReceipt) {
      // GameEnded does not repeat IsMatchMaking, so the participant/battle receipt is the only
      // durable discriminator between a direct challenge and ranked PvP. Branch before match
      // lookup and UsedCards parsing: challenges may display local combat/assignment animation,
      // but recovered EndScreen code suppresses ranked result/reward panels and no challenge
      // event is authoritative enough to spend cards or advance backend objectives.
      const result = await settleFriendlyBattle(
        player!.id,
        id,
        exactMatchInteger(req.EndReason, "EndReason"),
      );
      const progression = progressionForPlayer(player!);
      const offlineBot = friendlyReceipt.battleKind === "offline-bot";
      return ok(DbAction.GameEnded, {
        Settled: true,
        ResultStatus: offlineBot ? "offline-bot-finished" : "friendly-finished",
        ...(offlineBot ? { OfflineBotBattle: true } : { FriendlyBattle: true }),
        // The stock result parser dereferences GameReward whenever Skill is present. A complete
        // zero-valued object reports successful lifecycle completion without minting anything.
        GameReward: pvpGameReward(true),
        ...pvpLevelFields(
          player!.player.level,
          player!.player.level,
          progression.levelExperience,
        ),
        Skill: player!.player.skill,
        MedalsBalance: player!.player.medalsBalance,
        PlacementMatchesRequired: player!.player.remainingMatches,
        BeginnersLeague: player!.player.beginnersLeague,
        MatchesToNextLootboxes: progression.matchesToNextLootboxes ?? VIP_LOOTBOX_MATCH_INTERVAL,
        Time: unixNow(),
        Replayed: result.replayed,
      });
    }

    const match = id ? await getMatch(id) : null;
    // The stock action always carries EndReason as an invariant C# decimal. Parse it before the
    // optional replacement-transport WinnerId alias so malformed input cannot bypass the common
    // result contract merely by naming a participant explicitly.
    const endReason = exactMatchInteger(req.EndReason, "EndReason");

    // The stock 1.6.0 request sends EndReason, not WinnerId. A replacement transport may echo
    // WinnerId only as an exact assertion of that recovered enum meaning; it must never override
    // an unsupported outcome or contradict which participant won before two-party consensus.
    const inferredWinner = match
      ? winnerFromEndReason(match.players.map((participant) => participant.playerId), player!.id, endReason)
      : null;
    const winnerId = assertedPvpWinnerId(inferredWinner, req.WinnerId) ?? "";
    // Stock 1.6.0 always sends a JSON-string UsedCards field. An omitted field is accepted as
    // the replacement transport's empty-list shorthand; malformed, over-limit,
    // unknown, or unowned IDs are rejected by the card inventory service before consensus.
    const usedCards = exactGameEndedUsedCards(req.UsedCards);
    let report = id && winnerId
      ? await reportMatchResult(id, player!.id, winnerId, usedCards)
      : { status: "invalid" as const };

    // Both stock clients normally post GameEnded almost together. If this request recorded
    // the first half of consensus, wait briefly for the second request to commit the shared
    // immutable receipt. This fixes the old first-reporter path that returned zero rewards
    // even though the match settled immediately afterward. The wait is read-only and bounded;
    // a missing or disagreeing opponent can never be converted into a reward by this branch.
    if (report.status === "pending" && id) report = await waitForMatchResolution(id);

    const updated = await findById(player!.id);
    const progression = updated ? progressionForPlayer(updated) : null;
    // LevelExperience is read without a ContainsKey guard by DMGJCGJDDID. Return it on every
    // outcome, including pending/conflicting reports, so a safe rejection cannot crash the
    // client's end-screen parser.
    const responseWinner = report.settlement?.winnerId ?? winnerId;
    const resultAvailable = report.status === "confirmed" || report.status === "finished";
    const rewardReceipt = report.settlement?.rewards?.[player!.id];
    // A pending report has not proven that a battle settled. Advancing the one-battle rental
    // at that point used to consume the trial even when the opponent never confirmed or sent
    // a conflicting result. Only an immutable confirmed/finished receipt may end the trial.
    // New match receipts contain the rental sale committed in the settlement transaction.
    // Keep the helper only as a migration path for matches finalized before that receipt field
    // existed; a new receipt must never depend on a second database write to end the trial.
    let rentalFields: Record<string, unknown> = {};
    if (rewardReceipt?.rental) {
      rentalFields = { Rental: rewardReceipt.rental };
    } else if (!rewardReceipt?.rentalSettled && progression && id && resultAvailable) {
      // A missing marker identifies an old receipt. A marked receipt with no sale proves that
      // no trial existed at settlement time, so it must not consume a rental accepted later.
      rentalFields = await rentalFieldsAfterBattle(player!.id, id, progression);
    }
    // New receipts preserve this transition explicitly. The comparison remains only as a
    // compatibility path for matches settled before immutable league response fields existed.
    const enteredLeagueId = rewardReceipt?.enteredLeague ?? (resultAvailable
      && updated
      && updated.player.leagueId !== player!.player.leagueId
      && updated.player.leagueId.endsWith("-local")
      ? updated.player.leagueId
      : undefined);
    let squadEventFields: Record<string, unknown> = {};
    if (resultAvailable && updated?.player.squadName) {
      try {
        const fields = await getSquadEventWireFields(updated.player.squadName, updated.player.level);
        // The GameEnded parser consumes only SquadEventProgress. EventDefinition is refreshed
        // by squad-detail reads and is intentionally not duplicated into every match response.
        if (fields.SquadEventProgress) squadEventFields = { SquadEventProgress: fields.SquadEventProgress };
      } catch (error) {
        // Core settlement may already be committed. A configuration/read problem must not turn
        // that success into a retryable GameEnded failure after rewards and progress changed.
        logger.warnWithEmoji("⚠️", "Could not append Squad Event progress to GameEnded", "MATCH", {
          playerId: player!.id,
          error: error instanceof Error ? error.message : String(error),
        });
      }
    }
    return ok(DbAction.GameEnded, {
      Settled: report.settlement?.rewarded ?? false,
      ResultStatus: report.status,
      WinnerId: responseWinner,
      // DMGJCGJDDID constructs IIGFODGJBFA from GameReward before it handles Skill.
      // Always return a valid object, including a zero-XP pending/conflict result, to avoid
      // dereferencing a null ServerResultsCache.lastGameReward on the stock end screen.
      GameReward: pvpGameReward(
        resultAvailable,
        // The receipt contains both base wire components and authoritative multiplied totals.
        // IIGFODGJBFA applies the 4.9.5 VIP constants locally when IsVip is true, so sending
        // the multiplied values here would grant/display each VIP bonus twice.
        rewardReceipt?.baseExperience ?? rewardReceipt?.experience ?? 0,
        rewardReceipt?.baseGold ?? rewardReceipt?.gold ?? 0,
        rewardReceipt?.isVip ?? false,
        rewardReceipt?.newVisuals,
        rewardReceipt?.baseWarBucks ?? rewardReceipt?.warBucks ?? 0,
        rewardReceipt?.baseWinStreakWarBucks ?? rewardReceipt?.winStreakWarBucks ?? 0,
        rewardReceipt?.baseLeagueWarBucks ?? rewardReceipt?.leagueWarBucks ?? 0,
      ),
      // DMGJCGJDDID restores WinStreakManager only when WinCount is present. Return the
      // immutable pair for both wins and losses (zero clears a lost streak); never emit it
      // for a pending/conflicting report whose progression has not been committed.
      ...(resultAvailable && rewardReceipt
        ? {
          // Legacy finished matches predate streak receipts. Zero is the safe migration:
          // it preserves idempotency and asks the stock client to clear, never invent, state.
          WinCount: rewardReceipt.winCount ?? 0,
          TimeStamp: rewardReceipt.winStreakTimestamp ?? 0,
        }
        : {}),
      // OGLEHLIPEFM stores this outer field directly in PlayerAnalyticsData. Prefer the
      // immutable settlement receipt so a delayed retry returns the exact countdown that
      // accompanied its lootboxes even if later matches have already advanced live state.
      MatchesToNextLootboxes: rewardReceipt?.matchesToNextLootboxes
        ?? progression?.matchesToNextLootboxes
        ?? VIP_LOOTBOX_MATCH_INTERVAL,
      // Level is not a normal snapshot field in this callback: its presence means level-up.
      // Omit it while the level is unchanged, but always provide LevelExperience.
      ...pvpLevelFields(
        rewardReceipt?.levelFrom ?? player!.player.level,
        rewardReceipt?.levelTo ?? updated?.player.level ?? player!.player.level,
        rewardReceipt?.levelExperience ?? progression?.levelExperience ?? 0,
      ),
      // Prefer receipt snapshots. Reading the live player here made an old GameEnded retry
      // report medals from a later match and could animate an impossible result delta.
      Skill: rewardReceipt?.skill ?? updated?.player.skill ?? player!.player.skill,
      MedalsBalance: rewardReceipt?.medalsBalance
        ?? updated?.player.medalsBalance
        ?? player!.player.medalsBalance,
      // OGLEHLIPEFM copies this lower-case outer field into IIGFODGJBFA and immediately
      // advances the local lifetime squad-points statistic. Use the immutable receipt so a
      // retry shows the original delta and a pending/conflicting report never invents one.
      ...(resultAvailable && rewardReceipt ? { squadPoints: rewardReceipt.squadPoints ?? 0 } : {}),
      PlacementMatchesRequired: rewardReceipt?.placementMatchesRequired
        ?? updated?.player.remainingMatches
        ?? player!.player.remainingMatches,
      BeginnersLeague: rewardReceipt?.beginnersLeague
        ?? updated?.player.beginnersLeague
        ?? player!.player.beginnersLeague,
      // DMGJCGJDDID treats EnteredLeague as the signal to replace the local placement ID.
      // The value is never taken from the result request; it is the managed ID committed by
      // the same confirmed match transaction that consumed the final placement match.
      ...(enteredLeagueId
        ? {
          EnteredLeague: enteredLeagueId,
          EnteredNormalLeague: rewardReceipt?.enteredNormalLeague ?? true,
          ...(rewardReceipt?.leagueEvaluation !== undefined
            ? { LeagueEvaluation: rewardReceipt.leagueEvaluation }
            : playerLeagueBootFields(enteredLeagueId, unixNow())),
        }
        : {}),
      ...squadEventFields,
      ...rentalFields,
      Time: unixNow(),
    });
  }),

  [DbAction.UpdateRegionPings]: authed(async ({ player, req }) => {
    const bestRegions = parseRegionPings(req.Regions);
    const connectionType = parseInternetConnection(req.Connection);
    // Both values describe one network sample and must become visible together. The generic
    // partial-profile writer emits one MongoDB update and cannot overwrite progression or a
    // concurrent squad/match field. These client measurements remain routing hints only.
    await updatePlayerFields(player!.id, { bestRegions, connectionType });
    player!.player.bestRegions = bestRegions;
    player!.player.connectionType = connectionType;
    // BGHANIMKJBP is intentionally empty; the stock callback only needs a successful Result.
    return ok(DbAction.UpdateRegionPings);
  }),

  // The replacement WebSocket relay does not have Photon room-capacity failures. The action
  // remains an explicit compatibility acknowledgement so it is not mistaken for settlement.
  [DbAction.PhotonIsFull]: authed(() => ok(DbAction.PhotonIsFull)),
};
