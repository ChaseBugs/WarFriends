import assert from "node:assert/strict";
import { randomBytes } from "node:crypto";
import { mkdtemp, readFile, rm, stat, writeFile } from "node:fs/promises";
import { tmpdir } from "node:os";
import { join } from "node:path";
import test from "node:test";
import {
  decryptBackup,
  encryptBackup,
  parseBackupEncryptionKey,
  parseEncryptedBackupManifest,
  pruneEncryptedBackups,
  readJsonFile,
  sha256File,
  type PlainBackupManifest,
} from "../services/backupCryptoService";

async function fixture(createdAtUtc = "2026-07-01T00:00:00.000Z") {
  const directory = await mkdtemp(join(tmpdir(), "warfriends-backup-"));
  const archive = join(directory, "warfriends.archive.gz");
  const bytes = randomBytes(32_777);
  await writeFile(archive, bytes);
  const manifest: PlainBackupManifest = {
    format: 1,
    database: "warfriends",
    createdAtUtc,
    archiveFile: "warfriends.archive.gz",
    archiveBytes: bytes.length,
    sha256: await sha256File(archive),
  };
  return { directory, archive, bytes, manifest };
}

test("backup encryption round-trips a manifest-bound AES-256-GCM archive", async (t) => {
  const source = await fixture();
  t.after(() => rm(source.directory, { recursive: true, force: true }));
  const key = randomBytes(32);
  const encrypted = join(source.directory, "warfriends.wfbk");
  const encryptedManifest = `${encrypted}.manifest.json`;
  const result = await encryptBackup(source.archive, source.manifest, encrypted, encryptedManifest, key);

  assert.equal(result.format, 2);
  assert.equal(result.database, "warfriends");
  assert.equal((await stat(encrypted)).size, source.bytes.length);
  assert.notDeepEqual(await readFile(encrypted), source.bytes);
  assert.deepEqual(parseEncryptedBackupManifest(JSON.parse(await readFile(encryptedManifest, "utf8"))), result);

  const restored = join(source.directory, "restored.archive.gz");
  await decryptBackup(encrypted, result, restored, `${restored}.manifest.json`, key, "warfriends");
  assert.deepEqual(await readFile(restored), source.bytes);
});

test("backup decryption rejects ciphertext and authenticated metadata tampering", async (t) => {
  const source = await fixture();
  t.after(() => rm(source.directory, { recursive: true, force: true }));
  const key = randomBytes(32);
  const encrypted = join(source.directory, "warfriends.wfbk");
  const manifestPath = `${encrypted}.manifest.json`;
  const manifest = await encryptBackup(source.archive, source.manifest, encrypted, manifestPath, key);

  const tamperedBytes = await readFile(encrypted);
  tamperedBytes[100] ^= 0xff;
  await writeFile(encrypted, tamperedBytes);
  const tamperedManifest = { ...manifest, encryptedSha256: await sha256File(encrypted) };
  await assert.rejects(
    decryptBackup(encrypted, tamperedManifest, join(source.directory, "bad.archive"), join(source.directory, "bad.manifest"), key, "warfriends"),
  );

  await writeFile(encrypted, await readFile(source.archive));
  await assert.rejects(
    decryptBackup(
      encrypted,
      { ...manifest, database: "other", encryptedSha256: await sha256File(encrypted) },
      join(source.directory, "wrong.archive"),
      join(source.directory, "wrong.manifest"),
      key,
      "other",
    ),
  );
});

test("backup keys require canonical 256-bit Base64 and encryption never overwrites", async (t) => {
  const key = randomBytes(32);
  assert.deepEqual(parseBackupEncryptionKey(key.toString("base64")), key);
  for (const invalid of [undefined, "", "password", randomBytes(31).toString("base64"), `${key.toString("base64")}\nextra`]) {
    assert.throws(() => parseBackupEncryptionKey(invalid));
  }

  const source = await fixture();
  t.after(() => rm(source.directory, { recursive: true, force: true }));
  const encrypted = join(source.directory, "existing.wfbk");
  await writeFile(encrypted, "do-not-replace");
  await assert.rejects(encryptBackup(source.archive, source.manifest, encrypted, `${encrypted}.manifest.json`, key));
  assert.equal(await readFile(encrypted, "utf8"), "do-not-replace");
});

test("backup manifest reader accepts the UTF-8 BOM emitted by Windows PowerShell 5.1", async (t) => {
  const source = await fixture();
  t.after(() => rm(source.directory, { recursive: true, force: true }));
  const path = join(source.directory, "powershell.manifest.json");
  await writeFile(path, `\uFEFF${JSON.stringify(source.manifest)}`, "utf8");
  assert.deepEqual(await readJsonFile(path), source.manifest);
});

test("retention removes only old verified same-database archive pairs", async (t) => {
  const old = await fixture("2026-01-01T00:00:00.000Z");
  t.after(() => rm(old.directory, { recursive: true, force: true }));
  const key = randomBytes(32);
  const encrypted = join(old.directory, "old.wfbk");
  const manifestPath = `${encrypted}.manifest.json`;
  await encryptBackup(old.archive, old.manifest, encrypted, manifestPath, key);
  const unknown = join(old.directory, "unknown.wfbk");
  await writeFile(unknown, "retain me");

  assert.equal(await pruneEncryptedBackups(old.directory, [manifestPath], "other", Date.parse("2026-07-01T00:00:00Z")), 0);
  assert.equal(await pruneEncryptedBackups(old.directory, [manifestPath], "warfriends", Date.parse("2026-07-01T00:00:00Z")), 1);
  await assert.rejects(stat(encrypted));
  await assert.rejects(stat(manifestPath));
  assert.equal(await readFile(unknown, "utf8"), "retain me");
});
