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
