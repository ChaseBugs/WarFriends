import { ApiError, ApiErrorCode } from "../apiErrors";

// Strong terms may be detected inside a compacted string so punctuation, spaces, and simple
// leetspeak cannot bypass the policy. Keep this list deliberately narrow to reduce accidental
// matches in legitimate localized player names. Operators can extend it without changing code.
const STRONG_TERMS = [
  // English
  "fuck", "shit", "cunt", "nigger", "faggot",
  // Russian
  "хуй", "пизд", "ебан", "бляд",
  // Korean
  "씨발", "시발", "병신", "개새끼",
  // German, Spanish, Portuguese
  "hurensohn", "scheisse", "scheiße", "mierda", "caralho",
] as const;

// Short or commonly valid substrings require a whole normalized token. For example, `ass` must
// not reject `Assault` and `dick` must not reject a longer unrelated Unicode word.
const TOKEN_TERMS = new Set([
  "ass", "bitch", "dick", "cock", "rape", "nazi", "puta", "puto", "cono", "porra",
]);

const LEET_MAP: Record<string, string> = {
  "0": "o",
  "1": "i",
  "3": "e",
  "4": "a",
  "5": "s",
  "7": "t",
  "8": "b",
  "@": "a",
  "$": "s",
};

function configuredTerms(): string[] {
  return (process.env.PROFANITY_EXTRA_TERMS ?? "")
    .split(",")
    .map((value) => value.trim())
    .filter((value) => value.length >= 2 && value.length <= 64);
}

/** Produce a stable locale-independent key for policy matching, not for display or storage. */
export function moderationForms(value: string): { tokens: string[]; compact: string } {
  const normalized = value
    .normalize("NFKD")
    .replace(/\p{M}+/gu, "")
    .toLocaleLowerCase("en-US")
    .replace(/[0134578@$]/gu, (character) => LEET_MAP[character] ?? character);
  const tokens = normalized.split(/[^\p{L}\p{N}]+/u).filter(Boolean);
  const compact = tokens.join("").replace(/([a-z])\1{2,}/gu, "$1");
  return { tokens, compact };
}

/**
 * Return true when text violates the built-in multilingual policy or an operator extension.
 * This function is pure apart from reading the optional environment list, making every account,
 * rename, and squad path use identical Unicode/evasion behavior.
 */
export function containsProhibitedLanguage(value: string): boolean {
  const forms = moderationForms(value);
  if (STRONG_TERMS.some((term) => forms.compact.includes(moderationForms(term).compact))) return true;
  if (forms.tokens.some((token) => TOKEN_TERMS.has(token))) return true;
  return configuredTerms().some((term) => {
    const prohibited = moderationForms(term);
    return prohibited.compact.length > 0 && (
      forms.compact.includes(prohibited.compact)
      || prohibited.tokens.some((token) => forms.tokens.includes(token))
    );
  });
}

/** Reject prohibited public text before it reaches a unique index, roster, inbox, or profile. */
export function requireModeratedText(value: string, field: string): string {
  if (containsProhibitedLanguage(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} contains prohibited language.`);
  }
  return value;
}
