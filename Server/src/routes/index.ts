import { Router, type Request, type Response } from "express";
import { dispatch } from "../handlers";
import { DbAction } from "../dbActions";
import type { RequestEnvelope } from "../dtos";
import { buildRemoteConfigurationResponse } from "../services/remoteConfigurationService";
import { exactDatabaseAction } from "../handlers/requestEnvelopeParsing";

// The recovered 1.6.0 client posts form fields to
// <base>/<DatabaseAction>/<short-version> and repeats the action as `requestId`.
// JSON/envelope routes remain available for diagnostics and newer adapters.
export const apiRouter = Router();

export function normalizeEnvelope(body: unknown, routeAction?: string): RequestEnvelope {
  const fields = body && typeof body === "object" && !Array.isArray(body) ? (body as RequestEnvelope) : ({} as RequestEnvelope);
  const parsedRouteAction = routeAction === undefined ? undefined : exactDatabaseAction(routeAction);
  const parsedRequestIdAction = fields.requestId === undefined ? undefined : exactDatabaseAction(fields.requestId);
  const parsedDbAction = fields.DbAction === undefined ? undefined : exactDatabaseAction(fields.DbAction);
  // Action 92 has a recovered field-name collision: requestId carries the transport action while
  // its diagnostic payload names the action that failed as a human-readable `DbAction` string.
  // Preserve that text under a server-only alias before replacing DbAction with the route action.
  const errorAction = parsedRouteAction === DbAction.ErrorMessage || parsedRequestIdAction === DbAction.ErrorMessage;
  const reportedDbAction = errorAction
    && typeof fields.DbAction === "string"
    && parsedDbAction === undefined
    ? fields.DbAction
    : undefined;
  const parsedActions = [parsedRouteAction, parsedRequestIdAction, parsedDbAction]
    .filter((value): value is number => value !== undefined);
  // A present malformed copy is not equivalent to absence. Fail the whole envelope before the
  // raw-configuration fast path or normal dispatcher can mistake it for another action.
  if (
    (routeAction !== undefined && parsedRouteAction === undefined)
    || (fields.requestId !== undefined && parsedRequestIdAction === undefined)
    || (fields.DbAction !== undefined && parsedDbAction === undefined && reportedDbAction === undefined)
    || parsedActions.some((value) => value !== parsedActions[0])
  ) {
    return { ...fields, DbAction: Number.NaN };
  }
  return {
    ...fields,
    ...(reportedDbAction === undefined ? {} : { ReportedDbAction: reportedDbAction }),
    DbAction: parsedActions[0] ?? Number.NaN,
  };
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
