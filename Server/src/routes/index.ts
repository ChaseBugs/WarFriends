import { Router, type Request, type Response } from "express";
import { dispatch } from "../handlers";
import type { RequestEnvelope } from "../dtos";

// The recovered client (BeanstalkServerManager) talks to a single service that carries the
// operation in a `DbAction` field. Exact base path is ⚠ RE-NEEDED (BACKEND.md §5) — the
// client assembles a URL containing "/PC/". We accept the envelope on a few candidate
// paths so the client can be pointed here without yet knowing the precise route.
export const apiRouter = Router();

async function handleEnvelope(req: Request, res: Response): Promise<void> {
  const body = (req.body ?? {}) as RequestEnvelope;
  const response = await dispatch(body);
  res.json(response);
}

apiRouter.post("/pc", handleEnvelope);
apiRouter.post("/PC", handleEnvelope);
apiRouter.post("/warfriends", handleEnvelope);
apiRouter.post("/", handleEnvelope);
