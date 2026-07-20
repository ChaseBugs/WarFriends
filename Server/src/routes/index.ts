import { Router, type Request, type Response } from "express";
import { dispatch } from "../handlers";
import { DbAction } from "../dbActions";
import type { RequestEnvelope } from "../dtos";
import { buildRemoteConfigurationResponse } from "../services/remoteConfigurationService";

// The recovered 1.6.0 client posts form fields to
// <base>/<DatabaseAction>/<short-version> and repeats the action as `requestId`.
// JSON/envelope routes remain available for diagnostics and newer adapters.
export const apiRouter = Router();

export function normalizeEnvelope(body: unknown, routeAction?: string): RequestEnvelope {
  const fields = body && typeof body === "object" && !Array.isArray(body) ? (body as RequestEnvelope) : ({} as RequestEnvelope);
  const bodyAction = fields.DbAction ?? fields.requestId;
  if (routeAction !== undefined && bodyAction !== undefined && Number(routeAction) !== Number(bodyAction)) {
    return { ...fields, DbAction: Number.NaN };
  }
  const requestAction = routeAction ?? bodyAction;
  return { ...fields, DbAction: Number(requestAction) };
}

/** Build the special non-JSON response parsed by GameConfigurationManager. */
export function configurationResponse(fields: RequestEnvelope): string {
  return buildRemoteConfigurationResponse(fields);
}

async function handleEnvelope(req: Request, res: Response): Promise<void> {
  const envelope = normalizeEnvelope(req.body, req.params.action);
  if (envelope.DbAction === DbAction.GetConfigurations) {
    res.type("text/plain").send(configurationResponse(envelope));
    return;
  }

  const response = await dispatch(envelope);
  res.json(response);
}

apiRouter.post("/pc", handleEnvelope);
apiRouter.post("/PC", handleEnvelope);
apiRouter.post("/warfriends", handleEnvelope);
apiRouter.post("/", handleEnvelope);

// The 1.6.0 client posts to <base>/<DatabaseAction>/<short-version> and includes the
// numeric action again as the `requestId` form field. Accept the known /PC variants plus
// a direct action route so a recovered base URL can point at this server unchanged.
apiRouter.post("/PC/:appId/:action(\\d+)/:version?", handleEnvelope);
apiRouter.post("/pc/:appId/:action(\\d+)/:version?", handleEnvelope);
apiRouter.post("/PC/:action(\\d+)/:version?", handleEnvelope);
apiRouter.post("/pc/:action(\\d+)/:version?", handleEnvelope);
apiRouter.post("/:action(\\d+)/:version?", handleEnvelope);
