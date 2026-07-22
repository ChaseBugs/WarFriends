import { AsyncLocalStorage } from "async_hooks";
import { randomUUID } from "crypto";

export interface RequestContext {
  requestId: string;
}

const storage = new AsyncLocalStorage<RequestContext>();

/** Run the complete Express async chain inside one immutable correlation context. */
export function runWithRequestContext<T>(requestId: string, callback: () => T): T {
  return storage.run({ requestId }, callback);
}

export function currentRequestId(): string | undefined {
  return storage.getStore()?.requestId;
}

const UUID_V4_PATTERN = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;

/**
 * Build the one identity-free correlation header allowed on outbound provider requests.
 *
 * Express always installs a generated UUID. Background workers have no inbound request, so they
 * receive a fresh generated UUID per provider call. A malformed manually installed test/tool
 * context is never forwarded to an external provider, and no player, message, purchase token,
 * access token, or URL enters the header value.
 */
export function outboundRequestHeaders(generatedId: string = randomUUID()): Readonly<{ "X-Request-ID": string }> {
  if (!UUID_V4_PATTERN.test(generatedId)) throw new Error("Generated outbound request ID is invalid.");
  const current = currentRequestId();
  return { "X-Request-ID": current && UUID_V4_PATTERN.test(current) ? current : generatedId };
}
