import { createHash, createHmac, timingSafeEqual } from "crypto";
import { readFileSync } from "fs";
import { resolve } from "path";
import { config } from "../config";
import type { RequestEnvelope } from "../dtos";
import { exactNumericClientVersion } from "../handlers/requestEnvelopeParsing";

export interface RemoteConfigurationSheet {
  id: string;
  version: string;
  columns: string[];
  rowIds: string[];
  rows: string[][];
}

export interface RemoteConfigurationPublication {
  sheetConfiguration: string;
  variant?: string;
  languages?: string[];
  minimumClientVersion?: number;
  maximumClientVersion?: number;
  rolloutPercent?: number;
  rolloutSalt?: string;
  sheets: RemoteConfigurationSheet[];
}

export interface RemoteConfigurationManifest {
  schemaVersion: 1;
  releaseId: string;
  publications: RemoteConfigurationPublication[];
  signature: string;
}

const CLIENT_VERSION_MAXIMUM = 2_147_483_647;
const MANIFEST_KEYS = new Set(["schemaVersion", "releaseId", "publications", "signature"]);
const PUBLICATION_KEYS = new Set([
  "sheetConfiguration", "variant", "languages", "minimumClientVersion", "maximumClientVersion",
  "rolloutPercent", "rolloutSalt", "sheets",
]);
const PUBLICATION_REQUIRED_KEYS = new Set(["sheetConfiguration", "sheets"]);
const SHEET_KEYS = new Set(["id", "version", "columns", "rowIds", "rows"]);

let activeManifest: RemoteConfigurationManifest | null = null;

function plainObject(value: unknown): value is Record<string, unknown> {
  return typeof value === "object" && value !== null && !Array.isArray(value);
}

function exactKeys(
  value: Record<string, unknown>,
  allowed: ReadonlySet<string>,
  required: ReadonlySet<string>,
): boolean {
  const keys = Object.keys(value);
  return keys.every((key) => allowed.has(key)) && [...required].every((key) => keys.includes(key));
}

/** Deterministic JSON representation shared by validation and the offline signing command. */
export function stableJson(value: unknown): string {
  if (Array.isArray(value)) return `[${value.map(stableJson).join(",")}]`;
  if (plainObject(value)) {
    return `{${Object.keys(value).sort().map((key) => `${JSON.stringify(key)}:${stableJson(value[key])}`).join(",")}}`;
  }
  return JSON.stringify(value);
}

export function remoteConfigurationSignature(value: unknown, secret: string): string {
  if (!plainObject(value)) throw new Error("Remote configuration manifest must be an object.");
  const { signature: _signature, ...unsigned } = value;
  return createHmac("sha256", secret)
    .update("warfriends-remote-configuration-v1\0", "utf8")
    .update(stableJson(unsigned), "utf8")
    .digest("hex");
}

function boundedText(value: unknown, field: string, maximum: number, allowWildcard = false): string {
  if (typeof value !== "string" || value.length === 0 || value.length > maximum || value.trim() !== value) {
    throw new Error(`${field} is invalid.`);
  }
  if ((!allowWildcard || value !== "*") && !/^[A-Za-z0-9_.-]+$/.test(value)) {
    throw new Error(`${field} contains unsupported characters.`);
  }
  return value;
}

function optionalInteger(value: unknown, field: string): number | undefined {
  if (value === undefined) return undefined;
  if (typeof value !== "number"
    || !Number.isSafeInteger(value)
    || value < 0
    || value > CLIENT_VERSION_MAXIMUM) {
    throw new Error(`${field} must be a non-negative signed-client integer.`);
  }
  return value;
}

function validateSheet(value: unknown, publicationIndex: number, sheetIndex: number): RemoteConfigurationSheet {
  if (!plainObject(value) || !exactKeys(value, SHEET_KEYS, SHEET_KEYS)) {
    throw new Error(`Publication ${publicationIndex} sheet ${sheetIndex} is invalid.`);
  }
  const prefix = `publications[${publicationIndex}].sheets[${sheetIndex}]`;
  const id = boundedText(value.id, `${prefix}.id`, 128);
  const version = boundedText(value.version, `${prefix}.version`, 64);
  if (!Array.isArray(value.columns) || value.columns.length === 0 || value.columns.length > 256) {
    throw new Error(`${prefix}.columns is invalid.`);
  }
  const columns = value.columns.map((column, index) => boundedText(column, `${prefix}.columns[${index}]`, 128));
  if (new Set(columns).size !== columns.length) throw new Error(`${prefix}.columns contains duplicates.`);
  if (!Array.isArray(value.rowIds) || !Array.isArray(value.rows) || value.rowIds.length !== value.rows.length) {
    throw new Error(`${prefix} row IDs and rows must have equal lengths.`);
  }
  if (value.rows.length > 10_000) throw new Error(`${prefix} has too many rows.`);
  const rowIds = value.rowIds.map((rowId, index) => boundedText(rowId, `${prefix}.rowIds[${index}]`, 256));
  if (new Set(rowIds).size !== rowIds.length) throw new Error(`${prefix}.rowIds contains duplicates.`);
  let encodedCellCharacters = 0;
  const rows = value.rows.map((row, rowIndex) => {
    if (!Array.isArray(row) || row.length !== columns.length) {
      throw new Error(`${prefix}.rows[${rowIndex}] does not match the column count.`);
    }
    return row.map((cell, columnIndex) => {
      if (typeof cell !== "string" || cell.length > 64_000 || cell.includes("/")) {
        throw new Error(`${prefix}.rows[${rowIndex}][${columnIndex}] is not wire-safe.`);
      }
      encodedCellCharacters += cell.length;
      if (encodedCellCharacters > 2_000_000) throw new Error(`${prefix} exceeds the response-size budget.`);
      return cell;
    });
  });
  return { id, version, columns, rowIds, rows };
}

/** Validate strict schema and HMAC before a publication can influence a live client. */
export function validateRemoteConfigurationManifest(value: unknown, secret: string): RemoteConfigurationManifest {
  if (secret.length < 32) throw new Error("REMOTE_CONFIGURATION_SIGNING_SECRET must contain at least 32 characters.");
  if (!plainObject(value)
    || !exactKeys(value, MANIFEST_KEYS, MANIFEST_KEYS)
    || value.schemaVersion !== 1
    || !Array.isArray(value.publications)) {
    throw new Error("Remote configuration manifest schema is invalid.");
  }
  const suppliedSignature = typeof value.signature === "string" ? value.signature.toLowerCase() : "";
  const expectedSignature = remoteConfigurationSignature(value, secret);
  const supplied = Buffer.from(suppliedSignature, "hex");
  const expected = Buffer.from(expectedSignature, "hex");
  if (supplied.length !== expected.length || !timingSafeEqual(supplied, expected)) {
    throw new Error("Remote configuration manifest signature is invalid.");
  }
  const releaseId = boundedText(value.releaseId, "releaseId", 128);
  if (value.publications.length > 100) throw new Error("Remote configuration manifest has too many publications.");
  const publications = value.publications.map((entry, publicationIndex) => {
    if (!plainObject(entry)
      || !exactKeys(entry, PUBLICATION_KEYS, PUBLICATION_REQUIRED_KEYS)
      || !Array.isArray(entry.sheets)
      || entry.sheets.length === 0
      || entry.sheets.length > 20) {
      throw new Error(`publications[${publicationIndex}] is invalid.`);
    }
    const sheetConfiguration = boundedText(
      entry.sheetConfiguration,
      `publications[${publicationIndex}].sheetConfiguration`,
      128,
    );
    const variant = entry.variant === undefined
      ? "*"
      : boundedText(entry.variant, `publications[${publicationIndex}].variant`, 128, true);
    const languages = entry.languages === undefined ? ["*"] : (() => {
      if (!Array.isArray(entry.languages) || entry.languages.length === 0 || entry.languages.length > 100) {
        throw new Error(`publications[${publicationIndex}].languages is invalid.`);
      }
      return entry.languages.map((language, index) => boundedText(
        language,
        `publications[${publicationIndex}].languages[${index}]`,
        32,
        true,
      ));
    })();
    if (new Set(languages.map((language) => language.toLowerCase())).size !== languages.length) {
      throw new Error(`publications[${publicationIndex}].languages contains duplicates.`);
    }
    const minimumClientVersion = optionalInteger(
      entry.minimumClientVersion,
      `publications[${publicationIndex}].minimumClientVersion`,
    );
    const maximumClientVersion = optionalInteger(
      entry.maximumClientVersion,
      `publications[${publicationIndex}].maximumClientVersion`,
    );
    if (minimumClientVersion !== undefined && maximumClientVersion !== undefined
      && maximumClientVersion < minimumClientVersion) {
      throw new Error(`publications[${publicationIndex}] client-version range is invalid.`);
    }
    const rolloutPercent = entry.rolloutPercent === undefined ? 100 : entry.rolloutPercent;
    if (typeof rolloutPercent !== "number"
      || !Number.isFinite(rolloutPercent)
      || rolloutPercent < 0
      || rolloutPercent > 100) {
      throw new Error(`publications[${publicationIndex}].rolloutPercent is invalid.`);
    }
    const rolloutSalt = entry.rolloutSalt === undefined
      ? releaseId
      : boundedText(entry.rolloutSalt, `publications[${publicationIndex}].rolloutSalt`, 128);
    const sheets = entry.sheets.map((sheet, sheetIndex) => validateSheet(sheet, publicationIndex, sheetIndex));
    if (Buffer.byteLength(JSON.stringify(sheets), "utf8") > 4 * 1_024 * 1_024) {
      throw new Error(`publications[${publicationIndex}] exceeds the four MiB response budget.`);
    }
    if (new Set(sheets.map((sheet) => sheet.id)).size !== sheets.length) {
      throw new Error(`publications[${publicationIndex}] contains duplicate sheet IDs.`);
    }
    return {
      sheetConfiguration,
      variant,
      languages,
      minimumClientVersion,
      maximumClientVersion,
      rolloutPercent,
      rolloutSalt,
      sheets,
    };
  });
  return { schemaVersion: 1, releaseId, publications, signature: suppliedSignature };
}

export function initializeRemoteConfiguration(): void {
  activeManifest = null;
  if (!config.remoteConfigurationManifestPath) return;
  const path = resolve(config.remoteConfigurationManifestPath);
  const source = readFileSync(path, "utf8");
  if (Buffer.byteLength(source, "utf8") > 16 * 1_024 * 1_024) {
    throw new Error("Remote configuration manifest exceeds 16 MiB.");
  }
  const parsed: unknown = JSON.parse(source);
  activeManifest = validateRemoteConfigurationManifest(parsed, config.remoteConfigurationSigningSecret);
}

function requestedString(fields: RequestEnvelope, key: string, fallback = ""): string {
  const value = fields[key];
  return typeof value === "string" ? value.trim() : fallback;
}

function rolloutMatches(publication: RemoteConfigurationPublication, fields: RequestEnvelope): boolean {
  const percent = publication.rolloutPercent ?? 100;
  if (percent >= 100) return true;
  if (percent <= 0) return false;
  const playerId = [fields.PlayerId, fields.id, fields.Id]
    .find((value): value is string => typeof value === "string" && value.length > 0);
  if (!playerId) return false;
  const digest = createHash("sha256")
    .update(publication.rolloutSalt ?? "", "utf8")
    .update("\0", "utf8")
    .update(playerId, "utf8")
    .digest();
  return (digest.readUInt32BE(0) / 0x1_0000_0000) * 100 < percent;
}

/**
 * Read only the numeric replacement-client build aliases used by remote publication targeting.
 *
 * The recovered client always sends dotted `Version` (for example `1.6.0`) on the common request
 * envelope. That text has no lossless ordering relation to the operator's integer build policy and
 * must not become `NaN`, because both `NaN < minimum` and `NaN > maximum` are false. If a patched
 * client sends both numeric aliases, they must describe one exact canonical C# integer rather than
 * giving alias precedence a chance to select a different publication.
 */
function requestedNumericClientVersion(fields: RequestEnvelope): number | undefined | null {
  const supplied = [fields.ClientVersion, fields.clientVersion].filter((value) => value !== undefined);
  if (supplied.length === 0) return undefined;
  const parsed = supplied.map(exactNumericClientVersion);
  if (parsed.some((value) => value === undefined) || new Set(parsed).size !== 1) return null;
  return parsed[0]!;
}

export function selectRemoteConfiguration(
  fields: RequestEnvelope,
  manifest: RemoteConfigurationManifest | null = activeManifest,
): RemoteConfigurationPublication | null {
  if (!manifest) return null;
  const variant = requestedString(fields, "abTestVariant", "*");
  const language = requestedString(fields, "Language", "*").toLowerCase();
  const clientVersion = requestedNumericClientVersion(fields);
  // A malformed/conflicting numeric adapter value invalidates targeting entirely. This is
  // deliberately stricter than treating it as absent: otherwise an unbounded publication could
  // still be selected after the caller presented a bad version proof.
  if (clientVersion === null) return null;
  return manifest.publications.find((publication) => {
    if (publication.variant !== "*" && publication.variant !== variant) return false;
    const languages = publication.languages ?? ["*"];
    if (!languages.some((candidate) => candidate === "*" || candidate.toLowerCase() === language)) return false;
    if (publication.minimumClientVersion !== undefined
      && (clientVersion === undefined || clientVersion < publication.minimumClientVersion)) return false;
    if (publication.maximumClientVersion !== undefined
      && (clientVersion === undefined || clientVersion > publication.maximumClientVersion)) return false;
    return rolloutMatches(publication, fields);
  }) ?? null;
}

function safeSegmentJson(value: unknown): string {
  // Semicolon is the outer protocol delimiter. JSON unicode escaping preserves the exact string
  // after Newtonsoft parses it while preventing a cell value from creating a false segment.
  return JSON.stringify(value).replaceAll(";", "\\u003b");
}

function currentSheetConfiguration(fields: RequestEnvelope): string {
  const requested = fields.SheetConfiguraton ?? fields.SheetConfiguration ?? fields.SheetConfig ?? "0";
  return String(requested).replaceAll(";", "").trim() || "0";
}

/** Build the exact semicolon protocol parsed by GameConfigurationManager.PrepareConfigurations. */
export function buildRemoteConfigurationResponse(
  fields: RequestEnvelope,
  manifest: RemoteConfigurationManifest | null = activeManifest,
): string {
  const current = currentSheetConfiguration(fields);
  const publication = selectRemoteConfiguration(fields, manifest);
  if (!publication || publication.sheetConfiguration === current) return `success;${current};{}`;

  const versions = Object.fromEntries(publication.sheets.map((sheet) => [sheet.id, { N: sheet.version }]));
  const sheetSegments = publication.sheets.map((sheet) => safeSegmentJson({
    Id: { S: `Client_${sheet.id}` },
    Data: { L: sheet.rows.map((row) => ({ S: row.join("/") })) },
    RowIDs: { L: sheet.rowIds.map((rowId) => ({ S: rowId })) },
    ColumnNames: { S: sheet.columns.join("/") },
  }));
  return ["success", publication.sheetConfiguration, safeSegmentJson(versions), ...sheetSegments].join(";");
}
