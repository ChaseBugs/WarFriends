import { AccountType } from "../constants";

/**
 * Parse the canonical decimal AccountType emitted by LoginToCustomAccount. Provider selection is
 * a credential boundary, so JavaScript coercion of arrays, booleans, blanks, fractions, exponent
 * strings, or inherited object text must never choose a provider digest/index.
 */
export function exactRequestedAccountType(value: unknown): AccountType | undefined {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|[1-9]\d*)$/.test(value)
      ? Number(value)
      : Number.NaN;
  if (!Number.isSafeInteger(parsed)) return undefined;
  return parsed === AccountType.Guest
    || parsed === AccountType.Facebook
    || parsed === AccountType.GameCenter
    || parsed === AccountType.GooglePlay
    ? parsed
    : undefined;
}
