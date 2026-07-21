import { readdir } from "node:fs/promises";
import { join, resolve } from "node:path";
import {
  decryptBackup,
  encryptBackup,
  parseBackupEncryptionKey,
  parseEncryptedBackupManifest,
  parsePlainBackupManifest,
  pruneEncryptedBackups,
  readJsonFile,
} from "../services/backupCryptoService";

function options(args: readonly string[]): Map<string, string> {
  const parsed = new Map<string, string>();
  for (let index = 0; index < args.length; index += 2) {
    const name = args[index];
    const value = args[index + 1];
    if (!name?.startsWith("--") || value === undefined) throw new Error(`Invalid argument near ${name ?? "end"}.`);
    parsed.set(name.slice(2), value);
  }
  return parsed;
}

function required(values: Map<string, string>, name: string): string {
  const value = values.get(name);
  if (!value) throw new Error(`Missing --${name}.`);
  return value;
}

async function main(): Promise<void> {
  const [command, ...args] = process.argv.slice(2);
  const values = options(args);
  const key = command === "prune" ? undefined : parseBackupEncryptionKey(process.env.BACKUP_ENCRYPTION_KEY);

  if (command === "encrypt") {
    const archive = resolve(required(values, "archive"));
    const manifestPath = resolve(required(values, "manifest"));
    const output = resolve(required(values, "output"));
    const outputManifest = resolve(required(values, "output-manifest"));
    const manifest = parsePlainBackupManifest(await readJsonFile(manifestPath));
    const encrypted = await encryptBackup(archive, manifest, output, outputManifest, key!);
    process.stdout.write(`${JSON.stringify(encrypted)}\n`);
    return;
  }

  if (command === "decrypt") {
    const archive = resolve(required(values, "archive"));
    const manifestPath = resolve(required(values, "manifest"));
    const output = resolve(required(values, "output"));
    const outputManifest = resolve(required(values, "output-manifest"));
    const database = required(values, "database");
    const manifest = parseEncryptedBackupManifest(await readJsonFile(manifestPath));
    const plain = await decryptBackup(archive, manifest, output, outputManifest, key!, database);
    process.stdout.write(`${JSON.stringify(plain)}\n`);
    return;
  }

  if (command === "prune") {
    const directory = resolve(required(values, "directory"));
    const database = required(values, "database");
    const retentionDays = Number(required(values, "retention-days"));
    if (!Number.isInteger(retentionDays) || retentionDays < 7 || retentionDays > 3_650) {
      throw new Error("--retention-days must be an integer from 7 to 3650.");
    }
    const names = await readdir(directory);
    const manifests = names
      .filter((name) => name.endsWith(".wfbk.manifest.json"))
      .map((name) => join(directory, name));
    const removed = await pruneEncryptedBackups(
      directory,
      manifests,
      database,
      Date.now() - retentionDays * 86_400_000,
    );
    process.stdout.write(`${JSON.stringify({ removed, retentionDays })}\n`);
    return;
  }

  throw new Error("Usage: backupCrypto <encrypt|decrypt|prune> [options].");
}

void main().catch((error: unknown) => {
  process.stderr.write(`${error instanceof Error ? error.message : String(error)}\n`);
  process.exitCode = 1;
});
