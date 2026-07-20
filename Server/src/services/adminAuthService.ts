import { createHash, timingSafeEqual } from "crypto";
import type { NextFunction, Request, Response } from "express";
import { config } from "../config";

export type AdminAuthDecision = "allowed" | "missing" | "invalid" | "disabled";

function digest(value: string): Buffer {
  return createHash("sha256").update(value, "utf8").digest();
}

/** Parse one exact Bearer credential and compare fixed-size digests in constant time. */
export function validateAdminAuthorization(authorization: string | undefined, secret: string): AdminAuthDecision {
  if (!secret) return "disabled";
  if (!authorization) return "missing";
  const match = /^Bearer ([^\s]{1,4096})$/u.exec(authorization);
  if (!match) return "invalid";
  return timingSafeEqual(digest(match[1]!), digest(secret)) ? "allowed" : "invalid";
}

export function requireAdmin(
  req: Request,
  res: Response,
  next: NextFunction,
): void {
  const decision = validateAdminAuthorization(req.header("authorization"), config.adminSecret);
  if (decision === "allowed") {
    next();
    return;
  }
  if (decision === "disabled") {
    res.status(503).json({ Code: 0, Message: "Administrative API is disabled." });
    return;
  }
  res.setHeader("WWW-Authenticate", "Bearer realm=\"warfriends-admin\"");
  res.status(401).json({ Code: 0, Message: "Administrative authorization required." });
}
