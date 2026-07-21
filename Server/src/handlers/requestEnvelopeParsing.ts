const CSHARP_INT32_MAX = 2_147_483_647;

/**
 * Parse the recovered `DatabaseAction` transport without JavaScript numeric coercion.
 *
 * BestHTTP writes the enum's nonnegative C# `int` as canonical decimal form text in both the URL
 * and `requestId`. Diagnostic JSON clients may use the same exact integer as a number. Null,
 * Booleans, arrays, blanks, signs, leading zeros, fractions, and exponent strings must not become
 * a routable action through `Number()`; the route/body equality proof uses this parser too.
 */
export function exactDatabaseAction(value: unknown): number | undefined {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|[1-9]\d*)$/u.test(value)
      ? Number(value)
      : Number.NaN;
  return Number.isInteger(parsed) && parsed >= 0 && parsed <= CSHARP_INT32_MAX
    ? parsed
    : undefined;
}

/**
 * Parse the optional numeric build adapter used by `MIN_CLIENT_VERSION`.
 *
 * The stock 1.6.0 form uses dotted `Version` and remains outside this numeric replacement-client
 * gate. When an adapter supplies `ClientVersion`, however, a malformed value must fail the gate;
 * `NaN < minimum` is false and previously let invalid input bypass an enabled minimum.
 */
export function exactNumericClientVersion(value: unknown): number | undefined {
  return exactDatabaseAction(value);
}

/**
 * Validate the deployment-owned replacement-client floor without silently disabling it.
 *
 * Zero is the documented disabled state. A negative, fractional, non-finite, or oversized value
 * must fail module startup rather than making `requestedVersion < minimumVersion` evaluate false
 * or changing the operator's reviewed threshold through rounding.
 */
export function exactMinimumClientVersion(value: unknown): number {
  const parsed = exactNumericClientVersion(value);
  if (parsed === undefined) throw new Error("Minimum client-version policy is invalid.");
  return parsed;
}

/**
 * Parse the replacement adapter's two accepted field aliases as one request claim.
 *
 * Total absence maps to zero so the stock client remains outside an enabled replacement-client
 * gate exactly as documented. When either alias is supplied, every supplied value must use the
 * canonical C# integer transport and all aliases must agree; precedence would let a caller hide a
 * conflicting or malformed claim behind whichever property the dispatcher happened to read first.
 */
export function exactRequestedNumericClientVersion(
  clientVersion: unknown,
  legacyClientVersion: unknown,
): number | undefined {
  const supplied = [clientVersion, legacyClientVersion].filter((value) => value !== undefined);
  if (supplied.length === 0) return 0;
  const parsed = supplied.map(exactNumericClientVersion);
  if (parsed.some((value) => value === undefined)) return undefined;
  return parsed.every((value) => value === parsed[0]) ? parsed[0] : undefined;
}

/** Apply one already-validated deployment floor to the canonical replacement-client claim. */
export function replacementClientVersionIsAllowed(
  clientVersion: unknown,
  legacyClientVersion: unknown,
  minimumClientVersion: number,
): boolean {
  if (minimumClientVersion === 0) return true;
  const requested = exactRequestedNumericClientVersion(clientVersion, legacyClientVersion);
  return requested !== undefined && requested >= minimumClientVersion;
}
