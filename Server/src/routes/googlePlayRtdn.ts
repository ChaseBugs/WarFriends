import { Router, type Request, type Response } from "express";
import { googlePlayRtdnIdentityPolicy } from "../services/googlePlayPolicyService";
import {
  authenticateGooglePlayRtdn,
  GooglePlayRtdnAuthenticationError,
  GooglePlayRtdnConflictError,
  GooglePlayRtdnValidationError,
  ingestGooglePlayRtdn,
  parseGooglePlayRtdnEnvelope,
} from "../services/googlePlayRtdnService";
import logger from "../utils/logger";

export const googlePlayRtdnRouter = Router();
const RTDN_IDENTITY = googlePlayRtdnIdentityPolicy();

googlePlayRtdnRouter.post("/", async (req: Request, res: Response) => {
  // A disabled endpoint is indistinguishable from an absent provider integration. Do not parse
  // or echo any attacker-supplied envelope until the complete immutable OIDC policy is enabled.
  if (!RTDN_IDENTITY.enabled) {
    res.sendStatus(404);
    return;
  }
  try {
    await authenticateGooglePlayRtdn(req.get("authorization"));
    const receivedAt = new Date();
    const event = parseGooglePlayRtdnEnvelope(req.body, receivedAt);
    const result = await ingestGooglePlayRtdn(event);
    logger.infoWithEmoji("PURCHASE", "Google Play RTDN accepted", "API", {
      messageId: event._id,
      kind: event.kind,
      status: result.status,
      replayed: result.replayed,
    });
    // Pub/Sub treats any 2xx response as an acknowledgement. Return only after the insert or an
    // exact durable replay is proven so a process crash cannot lose the provider wake-up.
    res.sendStatus(204);
  } catch (error) {
    if (error instanceof GooglePlayRtdnAuthenticationError) {
      res.sendStatus(401);
      return;
    }
    if (error instanceof GooglePlayRtdnValidationError) {
      res.status(400).json({ Message: error.message });
      return;
    }
    if (error instanceof GooglePlayRtdnConflictError) {
      res.status(409).json({ Message: error.message });
      return;
    }
    // A storage outage must remain non-2xx so Pub/Sub retries. Do not expose MongoDB, JWT, or
    // provider details in this public response.
    logger.errorWithEmoji("PURCHASE", "Google Play RTDN ingestion failed", "API", {
      error: error instanceof Error ? error.message : String(error),
    });
    res.status(503).json({ Message: "Google Play RTDN is temporarily unavailable." });
  }
});
