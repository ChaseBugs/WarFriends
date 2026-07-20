import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { refillDogTags, spendOneDogTag } from "../services/economyService";
import { claimOneTimeReward, oneTimeRewardWire } from "../services/oneTimeRewardService";
import { authed, type HandlerEntry } from "./types";

// Currency/energy mutations are kept separate from profile handlers. Every operation here
// derives its cost from server configuration and commits through the progression revision,
// rather than trusting client-supplied balances or serialized inventory blobs.
export const economyHandlers: Record<number, HandlerEntry> = {
  [DbAction.PayOneDogTag]: authed(async ({ player }) => {
    const result = await spendOneDogTag(player!.id);
    // ILMBENLPAJD reads LastUpdate and Seconds unconditionally, then rebuilds DogTagManager.
    return ok(DbAction.PayOneDogTag, {
      LastUpdate: result.state.dogTagLastUpdate,
      Seconds: result.state.dogTagSeconds,
    });
  }),

  [DbAction.RefillDogtags]: authed(async ({ player }) => {
    const result = await refillDogTags(player!.id);
    // LJBIDGKODLN interprets Gold as the amount spent and deducts it from the local wallet.
    return ok(DbAction.RefillDogtags, {
      Gold: result.goldSpent,
      GoldBalance: result.state.gold,
      LastUpdate: result.state.dogTagLastUpdate,
      Seconds: result.state.dogTagSeconds,
      DogTagMax: result.state.dogTagMax,
    });
  }),

  [DbAction.AddOneTimeReward]: authed(async ({ player, req }) => {
    const result = await claimOneTimeReward(player!.id, req.RewardId);
    // OOIMBPCOENI reads RewardId and Gold even on a replay, but it gates both wallet changes
    // on the mere presence of WasAdded. Do not send WasAdded=false: ContainsKey would treat it
    // as a fresh grant and the old client would add Gold locally despite the false value.
    return ok(DbAction.AddOneTimeReward, oneTimeRewardWire(result));
  }),
};
