import { Router, type Response } from "express";
import {
  AdminReplayVideoInputError,
  findAdminReplayVideo,
  listAdminReplayVideos,
  normalizeAdminReplayVideoId,
  normalizeAdminReplayVideoListInput,
  wireAdminReplayVideo,
} from "../services/adminReplayVideoService";

export const adminReplayVideosRouter = Router();

function replayVideoFailure(error: unknown, res: Response): void {
  if (error instanceof AdminReplayVideoInputError) {
    res.status(error.httpStatus).json({ Code: 0, Message: error.message });
    return;
  }
  throw error;
}

adminReplayVideosRouter.get("/:videoId", async (req, res, next) => {
  try {
    const videoId = normalizeAdminReplayVideoId(req.params.videoId);
    const item = await findAdminReplayVideo(videoId);
    if (!item) {
      res.status(404).json({ Code: 0, Message: "Replay video was not found." });
      return;
    }
    res.json({ item: wireAdminReplayVideo(item) });
  } catch (error) {
    try {
      replayVideoFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

adminReplayVideosRouter.get("/", async (req, res, next) => {
  try {
    const input = normalizeAdminReplayVideoListInput({
      playerId: req.query.playerId,
      limit: req.query.limit,
      cursor: req.query.cursor,
    });
    const page = await listAdminReplayVideos(input);
    res.json({
      playerId: input.playerId,
      items: page.items.map(wireAdminReplayVideo),
      nextCursor: page.nextCursor,
    });
  } catch (error) {
    try {
      replayVideoFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});
