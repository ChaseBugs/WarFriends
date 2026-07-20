import { AsyncLocalStorage } from "async_hooks";

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
