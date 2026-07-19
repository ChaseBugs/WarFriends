import type { PlayerDocument } from "../db";
import type { RequestEnvelope, ResponseEnvelope } from "../dtos";

export interface HandlerContext {
  req: RequestEnvelope;
  /** Present when the request carried valid id+token credentials. */
  player: PlayerDocument | null;
}

export type Handler = (ctx: HandlerContext) => Promise<ResponseEnvelope> | ResponseEnvelope;

export interface HandlerEntry {
  handler: Handler;
  /** When true the dispatcher rejects the request if no authenticated player is attached. */
  requiresAuth: boolean;
}

export function authed(handler: Handler): HandlerEntry {
  return { handler, requiresAuth: true };
}

export function open(handler: Handler): HandlerEntry {
  return { handler, requiresAuth: false };
}
