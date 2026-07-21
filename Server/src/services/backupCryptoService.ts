import { createCipheriv, createDecipheriv, createHash, randomBytes } from "node:crypto";
import { createReadStream, createWriteStream } from "node:fs";
import { access, open, readFile, rm, stat } from "node:fs/promises";
import { basename, dirname, resolve } from "node:path";
import { pipeline } from "node:stream/promises";

const ALGORITHM = "aes-256-gcm";
const KEY_BYTES = 32;
const NONCE_BYTES = 12;
const AUTH_TAG_BYTES = 16;

export interface PlainBackupManifest {
  format: 1;
  database: string;
  createdAtUtc: string;
  archiveFile: string;
  archiveBytes: number;
  sha256: string;
}

export interface EncryptedBackupManifest {
  format: 2;
  database: string;
  createdAtUtc: string;
  sourceArchiveFile: string;
  sourceArchiveBytes: number;
  sourceSha256: string;
  encryptedFile: string;
  encryptedBytes: number;
  encryptedSha256: string;
  encryption: typeof ALGORITHM;
  nonce: string;
  authTag: string;
}

function plainObject(value: unknown): value is Record<string, unknown> {
  return !!value && typeof value === "object" && !Array.isArray(value);
}

function safeDatabaseName(value: unknown): value is string {
  return typeof value === "string" && /^[A-Za-z0-9_-]{1,64}$/.test(value);
}

function sha256Text(value: unknown): value is string {
  return typeof value === "string" && /^[a-f0-9]{64}$/.test(value);
}

function positiveSafeInteger(value: unknown): value is number {
  return Number.isSafeInteger(value) && Number(value) > 0;
}

function validUtc(value: unknown): value is string {
  return typeof value === "string" && Number.isFinite(Date.parse(value));
}

function fileNameOnly(value: unknown): value is string {
  return typeof value === "string" && value.length > 0 && value.length <= 255 && basename(value) === value;
}

/**
 * Parse the deployment-owned backup key without accepting ambiguous or weak encodings.
 *
 * The key is deliberately a raw 256-bit random value, not a human password. Avoiding an
 * undocumented password KDF makes restores deterministic across hosts and lets operators rotate
 * keys by retaining the old secret only for the archives produced with it.
 */
export function parseBackupEncryptionKey(value: string | undefined): Buffer {
  const encoded = value?.trim() ?? "";
  if (!/^[A-Za-z0-9+/]{43}=$/.test(encoded)) {
    throw new Error("BACKUP_ENCRYPTION_KEY must be one canonical Base64-encoded 32-byte key.");
  }
  const key = Buffer.from(encoded, "base64");
  if (key.length !== KEY_BYTES || key.toString("base64") !== encoded) {
    throw new Error("BACKUP_ENCRYPTION_KEY must be one canonical Base64-encoded 32-byte key.");
  }
  return key;
}

export function parsePlainBackupManifest(value: unknown): PlainBackupManifest {
  if (!plainObject(value) || value.format !== 1) throw new Error("Unsupported plaintext backup manifest format.");
  if (!safeDatabaseName(value.database)) throw new Error("Plaintext backup manifest database is invalid.");
  if (!validUtc(value.createdAtUtc)) throw new Error("Plaintext backup manifest creation time is invalid.");
  if (!fileNameOnly(value.archiveFile)) throw new Error("Plaintext backup manifest archive name is invalid.");
  if (!positiveSafeInteger(value.archiveBytes)) throw new Error("Plaintext backup manifest size is invalid.");
  if (!sha256Text(value.sha256)) throw new Error("Plaintext backup manifest SHA256 is invalid.");
  return value as unknown as PlainBackupManifest;
}

export function parseEncryptedBackupManifest(value: unknown): EncryptedBackupManifest {
  if (!plainObject(value) || value.format !== 2) throw new Error("Unsupported encrypted backup manifest format.");
  if (!safeDatabaseName(value.database)) throw new Error("Encrypted backup manifest database is invalid.");
  if (!validUtc(value.createdAtUtc)) throw new Error("Encrypted backup manifest creation time is invalid.");
  if (!fileNameOnly(value.sourceArchiveFile) || !fileNameOnly(value.encryptedFile)) {
    throw new Error("Encrypted backup manifest file name is invalid.");
  }
  if (!positiveSafeInteger(value.sourceArchiveBytes) || !positiveSafeInteger(value.encryptedBytes)) {
    throw new Error("Encrypted backup manifest size is invalid.");
  }
  if (!sha256Text(value.sourceSha256) || !sha256Text(value.encryptedSha256)) {
    throw new Error("Encrypted backup manifest SHA256 is invalid.");
  }
  if (value.encryption !== ALGORITHM) throw new Error("Encrypted backup algorithm is not supported.");
  if (typeof value.nonce !== "string" || Buffer.from(value.nonce, "base64").length !== NONCE_BYTES) {
    throw new Error("Encrypted backup nonce is invalid.");
  }
  if (typeof value.authTag !== "string" || Buffer.from(value.authTag, "base64").length !== AUTH_TAG_BYTES) {
    throw new Error("Encrypted backup authentication tag is invalid.");
  }
  return value as unknown as EncryptedBackupManifest;
}

/**
 * Build the exact additional-authenticated-data bytes protected by AES-GCM.
 *
 * Binding the database, creation time, original file name, byte count, and plaintext digest means
 * an attacker cannot relabel a valid ciphertext for a different database or rewrite its retention
 * clock without making decryption fail authentication.
 */
export function encryptedBackupAad(manifest: Pick<
  EncryptedBackupManifest,
  "format" | "database" | "createdAtUtc" | "sourceArchiveFile" | "sourceArchiveBytes" | "sourceSha256" | "encryptedFile" | "encryption"
>): Buffer {
  return Buffer.from(JSON.stringify({
    format: manifest.format,
    database: manifest.database,
    createdAtUtc: manifest.createdAtUtc,
    sourceArchiveFile: manifest.sourceArchiveFile,
    sourceArchiveBytes: manifest.sourceArchiveBytes,
    sourceSha256: manifest.sourceSha256,
    encryptedFile: manifest.encryptedFile,
    encryption: manifest.encryption,
  }), "utf8");
}

export async function sha256File(path: string): Promise<string> {
  const hash = createHash("sha256");
  for await (const chunk of createReadStream(path)) hash.update(chunk as Buffer);
  return hash.digest("hex");
}

async function assertFileMatches(path: string, bytes: number, sha256: string, label: string): Promise<void> {
  const file = await stat(path);
  if (!file.isFile() || file.size !== bytes) throw new Error(`${label} size does not match its manifest.`);
  if (await sha256File(path) !== sha256) throw new Error(`${label} SHA256 does not match its manifest.`);
}

async function pathExists(path: string): Promise<boolean> {
  try {
    await access(path);
    return true;
  } catch {
    return false;
  }
}

async function atomicJsonWrite(path: string, value: unknown): Promise<void> {
  let output: Awaited<ReturnType<typeof open>> | undefined;
  try {
    // Opening the final name with `wx` is the only portable no-overwrite primitive shared by local
    // disks and common mounted/UNC targets. A crash may leave a partial manifest, but parsers and
    // retention fail closed on it; replacing an existing valid manifest would be worse.
    output = await open(path, "wx");
    await output.writeFile(`${JSON.stringify(value, null, 2)}\n`, { encoding: "utf8" });
    await output.sync();
  } catch (error) {
    if (output) {
      await output.close();
      output = undefined;
      await rm(path, { force: true });
    }
    throw error;
  } finally {
    await output?.close();
  }
}

export async function encryptBackup(
  archivePath: string,
  plainManifest: PlainBackupManifest,
  encryptedPath: string,
  encryptedManifestPath: string,
  key: Buffer,
): Promise<EncryptedBackupManifest> {
  if (key.length !== KEY_BYTES) throw new Error("Backup encryption key must contain 32 bytes.");
  if (basename(archivePath) !== plainManifest.archiveFile) {
    throw new Error("Plaintext archive file name does not match its manifest.");
  }
  if (await pathExists(encryptedPath) || await pathExists(encryptedManifestPath)) {
    throw new Error("Refusing to overwrite an existing encrypted backup or manifest.");
  }
  await assertFileMatches(archivePath, plainManifest.archiveBytes, plainManifest.sha256, "Plaintext archive");

  const nonce = randomBytes(NONCE_BYTES);
  const draft: EncryptedBackupManifest = {
    format: 2,
    database: plainManifest.database,
    createdAtUtc: plainManifest.createdAtUtc,
    sourceArchiveFile: plainManifest.archiveFile,
    sourceArchiveBytes: plainManifest.archiveBytes,
    sourceSha256: plainManifest.sha256,
    encryptedFile: basename(encryptedPath),
    encryptedBytes: 1,
    encryptedSha256: "0".repeat(64),
    encryption: ALGORITHM,
    nonce: nonce.toString("base64"),
    authTag: "",
  };
  const cipher = createCipheriv(ALGORITHM, key, nonce, { authTagLength: AUTH_TAG_BYTES });
  cipher.setAAD(encryptedBackupAad(draft));

  let outputCreated = false;
  const output = createWriteStream(encryptedPath, { flags: "wx" });
  output.once("open", () => { outputCreated = true; });
  try {
    await pipeline(createReadStream(archivePath), cipher, output);
    const encrypted = await stat(encryptedPath);
    const manifest: EncryptedBackupManifest = {
      ...draft,
      encryptedBytes: encrypted.size,
      encryptedSha256: await sha256File(encryptedPath),
      authTag: cipher.getAuthTag().toString("base64"),
    };
    await atomicJsonWrite(encryptedManifestPath, manifest);
    return manifest;
  } catch (error) {
    if (outputCreated) await rm(encryptedPath, { force: true });
    await rm(encryptedManifestPath, { force: true });
    throw error;
  }
}

export async function decryptBackup(
  encryptedPath: string,
  manifest: EncryptedBackupManifest,
  outputPath: string,
  outputManifestPath: string,
  key: Buffer,
  expectedDatabase: string,
): Promise<PlainBackupManifest> {
  if (key.length !== KEY_BYTES) throw new Error("Backup encryption key must contain 32 bytes.");
  if (manifest.database !== expectedDatabase) {
    throw new Error(`Encrypted backup database '${manifest.database}' does not match target '${expectedDatabase}'.`);
  }
  if (basename(encryptedPath) !== manifest.encryptedFile) {
    throw new Error("Encrypted archive file name does not match its manifest.");
  }
  if (await pathExists(outputPath) || await pathExists(outputManifestPath)) {
    throw new Error("Refusing to overwrite an existing decrypted backup or manifest.");
  }
  await assertFileMatches(encryptedPath, manifest.encryptedBytes, manifest.encryptedSha256, "Encrypted archive");

  const decipher = createDecipheriv(ALGORITHM, key, Buffer.from(manifest.nonce, "base64"), {
    authTagLength: AUTH_TAG_BYTES,
  });
  decipher.setAAD(encryptedBackupAad(manifest));
  decipher.setAuthTag(Buffer.from(manifest.authTag, "base64"));

  let outputCreated = false;
  const output = createWriteStream(outputPath, { flags: "wx" });
  output.once("open", () => { outputCreated = true; });
  try {
    await pipeline(createReadStream(encryptedPath), decipher, output);
    await assertFileMatches(outputPath, manifest.sourceArchiveBytes, manifest.sourceSha256, "Decrypted archive");
    const plain: PlainBackupManifest = {
      format: 1,
      database: manifest.database,
      createdAtUtc: manifest.createdAtUtc,
      archiveFile: basename(outputPath),
      archiveBytes: manifest.sourceArchiveBytes,
      sha256: manifest.sourceSha256,
    };
    await atomicJsonWrite(outputManifestPath, plain);
    return plain;
  } catch (error) {
    if (outputCreated) await rm(outputPath, { force: true });
    await rm(outputManifestPath, { force: true });
    throw error;
  }
}

export async function readJsonFile(path: string): Promise<unknown> {
  // Windows PowerShell 5.1 writes UTF-8 JSON with a BOM. Strip that one transport marker so the
  // existing Backup-Mongo manifest is readable without weakening JSON/schema validation.
  return JSON.parse((await readFile(path, "utf8")).replace(/^\uFEFF/, "")) as unknown;
}

/**
 * Remove only verified archive/manifest pairs owned by this backup format and database.
 * Unknown files, malformed manifests, mismatched paths, and damaged ciphertext are retained for
 * operator review rather than being swept by an unsafe age-based wildcard.
 */
export async function pruneEncryptedBackups(
  directory: string,
  manifestPaths: readonly string[],
  database: string,
  cutoffMs: number,
): Promise<number> {
  const root = resolve(directory);
  let removed = 0;
  for (const suppliedManifestPath of manifestPaths) {
    const manifestPath = resolve(suppliedManifestPath);
    if (dirname(manifestPath) !== root || !manifestPath.endsWith(".wfbk.manifest.json")) continue;
    let manifest: EncryptedBackupManifest;
    try {
      manifest = parseEncryptedBackupManifest(await readJsonFile(manifestPath));
    } catch {
      continue;
    }
    if (manifest.database !== database || Date.parse(manifest.createdAtUtc) >= cutoffMs) continue;
    const encryptedPath = resolve(root, manifest.encryptedFile);
    if (
      dirname(encryptedPath) !== root
      || `${encryptedPath}.manifest.json` !== manifestPath
      || !encryptedPath.endsWith(".wfbk")
    ) continue;
    try {
      await assertFileMatches(encryptedPath, manifest.encryptedBytes, manifest.encryptedSha256, "Encrypted archive");
    } catch {
      continue;
    }
    await rm(encryptedPath);
    await rm(manifestPath);
    removed += 1;
  }
  return removed;
}
