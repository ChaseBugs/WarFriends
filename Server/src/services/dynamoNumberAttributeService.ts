export type DynamoNumberAttribute = { N: string };

function invalid(): never {
  throw new Error("DynamoDB numeric attribute authority is invalid.");
}

/**
 * Serialize numeric fields whose recovered C# parser consumes an integer.
 *
 * The legacy adapter truncated legitimate fractional values (notably calculated Army Power), so
 * that behavior remains part of the wire contract. The truncation result must be exactly
 * representable in JavaScript; otherwise JSON would publish a different integer than authority.
 */
export function integerNumberAttribute(value: number): DynamoNumberAttribute {
  const projected = Math.trunc(value);
  if (!Number.isFinite(value) || !Number.isSafeInteger(projected)) return invalid();
  return { N: String(projected) };
}

/**
 * Serialize numeric fields whose recovered parser intentionally consumes a fraction.
 *
 * Squad Event contribution/progress values are binary32-derived decimals and must not be
 * truncated. Their magnitude still has to remain in the exactly represented integer envelope;
 * feature-specific validators apply the tighter 0-1 or configured-target bounds beforehand.
 */
export function decimalNumberAttribute(value: number): DynamoNumberAttribute {
  if (!Number.isFinite(value) || Math.abs(value) > Number.MAX_SAFE_INTEGER) return invalid();
  return { N: String(value) };
}
