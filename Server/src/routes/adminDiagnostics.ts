import { Router, type Response } from "express";
import {
  AdminDiagnosticInputError,
  listAdminDiagnostics,
  normalizeAdminDiagnosticListInput,
  wireAdminDiagnostic,
} from "../services/adminDiagnosticService";

export const adminDiagnosticsRouter = Router();

function diagnosticFailure(error: unknown, res: Response): void {
  if (error instanceof AdminDiagnosticInputError) {
    res.status(error.httpStatus).json({ Code: 0, Message: error.message });
    return;
  }
  throw error;
}

adminDiagnosticsRouter.get("/:kind", async (req, res, next) => {
  try {
    const input = normalizeAdminDiagnosticListInput({
      kind: req.params.kind,
      playerId: req.query.playerId,
      limit: req.query.limit,
      cursor: req.query.cursor,
    });
    const page = await listAdminDiagnostics(input);
    res.json({
      kind: input.kind,
      playerId: input.playerId,
      items: page.items.map((item) => wireAdminDiagnostic(input.kind, item)),
      nextCursor: page.nextCursor,
    });
  } catch (error) {
    try {
      diagnosticFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});
