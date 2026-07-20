import { createCipheriv, createDecipheriv, createHash, randomBytes } from "crypto";
import type { PurchaseReceiptDocument } from "../db";

export type EncryptedPurchaseToken = NonNullable<PurchaseReceiptDocument["encryptedPurchaseToken"]>;

function encryptionKey(secret: string): Buffer {
  if (secret.length < 32) throw new Error("Purchase token encryption secret must contain at least 32 characters.");
  // SHA-256 turns a stable deploy-time secret into the exact 32-byte key required by AES-256.
  // This is key derivation, not password storage: operators must supply a high-entropy secret.
  return createHash("sha256").update("warfriends-google-play-token\0", "utf8").update(secret, "utf8").digest();
}

/** Encrypt a Play bearer token and bind its ciphertext to the immutable HMAC receipt identity. */
export function encryptPurchaseToken(token: string, receiptId: string, secret: string): EncryptedPurchaseToken {
  const iv = randomBytes(12);
  const cipher = createCipheriv("aes-256-gcm", encryptionKey(secret), iv);
  cipher.setAAD(Buffer.from(receiptId, "utf8"));
  const ciphertext = Buffer.concat([cipher.update(token, "utf8"), cipher.final()]);
  return {
    version: 1,
    iv: iv.toString("base64"),
    authTag: cipher.getAuthTag().toString("base64"),
    ciphertext: ciphertext.toString("base64"),
  };
}

/** Decrypt only after GCM verifies both the ciphertext and its receipt-bound authentication tag. */
export function decryptPurchaseToken(
  encrypted: EncryptedPurchaseToken,
  receiptId: string,
  secret: string,
): string {
  if (encrypted.version !== 1) throw new Error("Unsupported purchase token encryption version.");
  const decipher = createDecipheriv(
    "aes-256-gcm",
    encryptionKey(secret),
    Buffer.from(encrypted.iv, "base64"),
  );
  decipher.setAAD(Buffer.from(receiptId, "utf8"));
  decipher.setAuthTag(Buffer.from(encrypted.authTag, "base64"));
  return Buffer.concat([
    decipher.update(Buffer.from(encrypted.ciphertext, "base64")),
    decipher.final(),
  ]).toString("utf8");
}
