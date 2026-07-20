import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { publishVideoFeed } from "../services/videoFeedService";
import { authed, type HandlerEntry } from "./types";

export const videoFeedHandlers: Record<number, HandlerEntry> = {
  [DbAction.AddVideoFeed]: authed(async ({ player, req }) => {
    const result = await publishVideoFeed(player!.id, req.URL);
    // MHEHGPLIFHF.LLCLNJKBGGM reads URL unconditionally and reports it to VideoUploaded.
    // Additional diagnostics are safe because the callback ignores unknown response keys.
    return ok(DbAction.AddVideoFeed, {
      URL: result.url,
      VideoId: result.videoId,
      Replayed: result.replayed,
    });
  }),
};
