import { Router, type Request, type Response } from "express";
import {
  createGooglePlayRefundReviewIntent,
  findGooglePlayRefundReview,
  GooglePlayRefundReviewInputError,
  listGooglePlayRefundReviews,
  normalizeGooglePlayRefundReviewListInput,
  normalizeGooglePlayRefundReviewSubmission,
  wireGooglePlayRefundReview,
} from "../services/googlePlayRefundReviewService";

export const adminGooglePlayRefundReviewsRouter = Router();

function header(req: Request, name: string): string | undefined {
  const value = req.header(name);
  return typeof value === "string" ? value : undefined;
}

function refundReviewFailure(error: unknown, res: Response): void {
  if (error instanceof GooglePlayRefundReviewInputError) {
    res.status(error.httpStatus).json({ Code: 0, Message: error.message });
    return;
  }
  throw error;
}

/**
 * List the bounded operator queue without decrypting provider evidence. The stable cursor binds
 * the last RTDN receipt time and message ID, so concurrent arrivals cannot duplicate older rows.
 */
adminGooglePlayRefundReviewsRouter.get("/", async (req, res, next) => {
  try {
    const input = normalizeGooglePlayRefundReviewListInput({
      limit: req.query.limit,
      cursor: req.query.cursor,
    });
    const page = await listGooglePlayRefundReviews(input);
    res.json({
      items: page.items.map(({ event, review }) => wireGooglePlayRefundReview(event, review)),
      nextCursor: page.nextCursor,
    });
  } catch (error) {
    try {
      refundReviewFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

/** Return audit metadata only; pending tokens, IP addresses, and usage details remain encrypted. */
adminGooglePlayRefundReviewsRouter.get("/:messageId", async (req, res, next) => {
  try {
    const item = await findGooglePlayRefundReview(req.params.messageId);
    if (!item) {
      res.status(404).json({ Code: 0, Message: "Pending refund review was not found." });
      return;
    }
    res.json({ item: wireGooglePlayRefundReview(item.event, item.review) });
  } catch (error) {
    try {
      refundReviewFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

/**
 * Seal one immutable recommendation before the background worker calls Google's first-call-wins
 * API. The operation header and actor are retained with the encrypted evidence for exact replay.
 */
adminGooglePlayRefundReviewsRouter.post("/:messageId/review", async (req, res, next) => {
  try {
    const submission = normalizeGooglePlayRefundReviewSubmission(
      req.params.messageId,
      req.body,
      header(req, "X-Admin-Actor"),
      header(req, "Idempotency-Key"),
    );
    const result = await createGooglePlayRefundReviewIntent(submission);
    const item = await findGooglePlayRefundReview(result.review._id);
    if (!item?.review) throw new Error("Committed Google Play refund-review intent could not be reloaded.");
    res.status(result.replayed ? 200 : 202).json({
      replayed: result.replayed,
      item: wireGooglePlayRefundReview(item.event, item.review),
    });
  } catch (error) {
    try {
      refundReviewFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});
