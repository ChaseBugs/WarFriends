import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  markFeatureIntroduction,
  type FeatureIntroductionKey,
} from "../services/featureIntroductionService";
import { authed, type HandlerEntry } from "./types";

/**
 * Dedicated, parameterless PlayerAnalyticsData introduction acknowledgements.
 *
 * These used to sit in the generic telemetry no-op allowlist. That made them unauthenticated and
 * lost their only durable effect, so tutorials reappeared after reconnect. Keep broad action 179
 * ignored because its serialized analytics blob also carries forgeable economy counters; these
 * narrow actions are the safe source-defined write surface.
 */
const featureByAction: Readonly<Record<number, FeatureIntroductionKey>> = Object.freeze({
  [DbAction.ChatShownFirstTime]: "chatShown",
  [DbAction.CustomizationShown]: "customizationShown",
  [DbAction.WarpathShownFirstTime]: "warpathShown",
  [DbAction.CardpoolShown]: "cardpoolShown",
  [DbAction.LeagueLeaderboardShown]: "leagueLeaderboardsShown",
  [DbAction.CraftingShown]: "craftingShown",
  [DbAction.ElitesFeatureShown]: "elitesShown",
});

export const analyticsHandlers: Record<number, HandlerEntry> = Object.fromEntries(
  Object.entries(featureByAction).map(([rawAction, feature]) => {
    const action = Number(rawAction);
    return [action, authed(async ({ player }) => {
      const result = await markFeatureIntroduction(player!.id, feature);
      // The recovered success callbacks consume no response fields; Changed is harmless to the
      // stock parser and useful to replacement clients when a request is an idempotent replay.
      return ok(action, { Changed: result.changed });
    })];
  }),
);
