import { config } from "../config";

export interface FirebasePushPolicy {
  readonly enabled: boolean;
  readonly projectId: string;
  readonly requestTimeoutMilliseconds: number;
}

/**
 * Validate one immutable Firebase HTTP v1 deployment boundary.
 *
 * Project IDs are inserted into the provider URL and therefore remain exact, lower-case Firebase
 * identifiers rather than free-form operator text. Disabled deployments may omit the ID entirely,
 * but an enabled deployment must name it explicitly; the recovered numeric sender ID is not enough
 * to prove the Google Cloud project name or authorize a service account.
 */
export function exactFirebasePushPolicy(policy: FirebasePushPolicy): FirebasePushPolicy {
  const validProjectId = policy.projectId === ""
    || /^[a-z][a-z0-9-]{4,28}[a-z0-9]$/u.test(policy.projectId);
  if (typeof policy.enabled !== "boolean"
    || !validProjectId
    || (policy.enabled && policy.projectId === "")
    || !Number.isSafeInteger(policy.requestTimeoutMilliseconds)
    || policy.requestTimeoutMilliseconds < 1_000
    || policy.requestTimeoutMilliseconds > 30_000) {
    throw new Error("Firebase push policy is invalid.");
  }
  return { ...policy };
}

// Every inbox fan-out in this process observes the same provider enablement, project identity, and
// timeout. Resolving once prevents a mutable environment shim from routing later messages through
// a different Firebase project than earlier messages from the same server instance.
const CONFIGURED_FIREBASE_PUSH_POLICY = Object.freeze(exactFirebasePushPolicy({
  enabled: config.firebasePushEnabled,
  projectId: config.firebaseProjectId,
  requestTimeoutMilliseconds: config.firebasePushRequestTimeoutMilliseconds,
}));

export function firebasePushPolicy(policy?: FirebasePushPolicy): FirebasePushPolicy {
  return policy === undefined
    ? CONFIGURED_FIREBASE_PUSH_POLICY
    : exactFirebasePushPolicy(policy);
}
