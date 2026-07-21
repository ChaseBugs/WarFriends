/**
 * Validate one deployment-owned public-traffic limit without changing operator intent.
 *
 * These values size both process-local protection and Redis-backed enforcement. Flooring a
 * fraction, clamping an out-of-range value, or substituting a default for `NaN` would make nodes
 * enforce a policy different from the reviewed environment and can create inconsistent limits
 * during a rolling deployment.
 */
export function exactTrafficPolicyInteger(
  value: number,
  label: string,
  minimum: number,
  maximum: number,
): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Traffic ${label} policy is invalid.`);
  }
  return value;
}
