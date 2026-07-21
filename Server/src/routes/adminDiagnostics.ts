import { Router, type Response } from "express";
import {
  AdminDiagnosticInputError,
  findAdminDiagnostic,
  listAdminDiagnostics,
  normalizeAdminDiagnosticId,
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

adminDiagnosticsRouter.get("/:kind/:id", async (req, res, next) => {
  try {
    const id = normalizeAdminDiagnosticId(req.params.id);
    const item = await findAdminDiagnostic(req.params.kind, id);
    if (!item) {
      res.status(404).json({ Code: 0, Message: "Diagnostic entry was not found." });
      return;
    }
    // findAdminDiagnostic validates kind before storage access, so the route parameter is now the
    // exact discriminant expected by the family-specific wire adapter.
    const input = normalizeAdminDiagnosticListInput({ kind: req.params.kind, limit: "1" });
    res.json({ kind: input.kind, item: wireAdminDiagnostic(input.kind, item) });
  } catch (error) {
    try {
      diagnosticFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

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
