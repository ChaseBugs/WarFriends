import { createHash } from "node:crypto";
import { readFileSync, writeFileSync } from "node:fs";
import { dirname, resolve } from "node:path";
import { fileURLToPath } from "node:url";

const scriptDirectory = dirname(fileURLToPath(import.meta.url));
const serverDirectory = resolve(scriptDirectory, "..");
const repositoryDirectory = resolve(serverDirectory, "..");
const scenePath = resolve(repositoryDirectory, "Client/ExportedProject/Assets/Scenes/MainScene.unity");
const outputPath = resolve(serverDirectory, "src/data/visualCatalog.generated.json");
const checkOnly = process.argv.includes("--check");

const sceneBuffer = readFileSync(scenePath);
const scene = sceneBuffer.toString("utf8");

/** Index Unity YAML documents once so the 87 MB scene is not scanned for every category. */
const documents = [];
const headerPattern = /^--- !u!(\d+) &(\d+)\r?$/gm;
let previous = null;
let header;
while ((header = headerPattern.exec(scene)) !== null) {
  if (previous) previous.end = header.index;
  const document = { type: Number(header[1]), fileId: header[2], start: header.index, end: scene.length };
  documents.push(document);
  previous = document;
}

const blocks = documents.map((document) => ({
  ...document,
  text: scene.slice(document.start, document.end),
}));

const sheet = blocks.find(({ text }) =>
  /^  - NAME: CAMOS_DEFAULT$/m.test(text)
  && /^    DUPLICATEWARBUCKS: /m.test(text)
  && /^  Rows:$/m.test(text));
if (!sheet) throw new Error("PlayerVisuals sheet was not found in MainScene.");

function scalar(value) {
  const trimmed = value.trim();
  if (/^-?\d+$/.test(trimmed)) return Number(trimmed);
  if (/^-?\d+\.\d+$/.test(trimmed)) return Number(trimmed);
  return trimmed;
}

const rowsStart = sheet.text.search(/^  Rows:$/m);
if (rowsStart < 0) throw new Error("PlayerVisuals.Rows was not found.");
const rowNamesBlock = /^  rowNames:\r?\n((?:  - [^\r\n]+\r?\n)+)/m.exec(sheet.text)?.[1];
if (!rowNamesBlock) throw new Error("PlayerVisuals.rowNames was not found.");
const rowNames = [...rowNamesBlock.matchAll(/^  - ([^\r\n]+)$/gm)].map((match) => match[1]);
const rowBlocks = sheet.text
  .slice(rowsStart)
  .split(/^  - /m)
  .slice(1)
  .map((block) => `  - ${block}`);

const sheetRows = rowBlocks.map((block, index) => {
  const row = {};
  for (const line of block.split(/\r?\n/)) {
    const match = /^(?:  - |    )([A-Z][A-Z0-9_]*): ?(.*)$/.exec(line);
    if (match) row[match[1]] = scalar(match[2]);
  }
  const required = [
    "NAME", "UNLOCKLEVEL", "PRICEWARBUCKS", "PRICEGOLD", "TIME", "DECALTYPE",
    "DECALVALUE", "CATEGORYID", "ONLYFORVIP", "PURCHASABLE", "CATEGORY", "PARTS",
    "DUPLICATEWARBUCKS",
  ];
  for (const field of required) {
    if (!(field in row)) throw new Error(`PlayerVisuals row ${index} is missing ${field}.`);
  }
  if (
    typeof row.NAME !== "string"
    || !Number.isInteger(row.CATEGORYID)
    || row.CATEGORYID < 0
    || row.CATEGORYID > 3
  ) {
    throw new Error(`PlayerVisuals row ${index} has an invalid name or category.`);
  }
  return {
    name: row.NAME,
    unlockLevel: row.UNLOCKLEVEL,
    priceWarBucks: row.PRICEWARBUCKS,
    priceGold: row.PRICEGOLD,
    durationSeconds: row.TIME,
    effectType: row.DECALTYPE,
    effectValue: row.DECALVALUE,
    categoryId: row.CATEGORYID,
    vipOnly: row.ONLYFORVIP === 1,
    purchasable: row.PURCHASABLE,
    rarity: row.CATEGORY,
    parts: row.PARTS,
    duplicateWarBucks: row.DUPLICATEWARBUCKS,
  };
});
if (rowNames.length !== sheetRows.length) {
  throw new Error(`PlayerVisuals has ${rowNames.length} names but ${sheetRows.length} rows.`);
}
for (let index = 0; index < rowNames.length; index++) {
  if (rowNames[index] !== sheetRows[index].name) {
    throw new Error(`PlayerVisuals row order differs at index ${index}.`);
  }
}

const categoryNames = ["camo", "helmet", "headAccessory", "powerBand"];
const categoryPrefixes = ["CAMOS_", "HELMETS_", "HEAD_", "BANDS_"];
const categories = categoryPrefixes.map((prefix, categoryId) => {
  const component = blocks.find(({ text }) =>
    new RegExp(`^  EGKNDPKCHPC: ${prefix}$`, "m").test(text)
    && /^  CMBKCHADJPD:$/m.test(text));
  if (!component) throw new Error(`Visual category component ${prefix} was not found.`);
  const visualNames = [...component.text.matchAll(/^  - visualName: ([^\r\n]+)$/gm)]
    .map((match) => match[1].trim());
  if (visualNames.length === 0) throw new Error(`Visual category ${prefix} has no assets.`);
  const ids = visualNames.map((name) => `${prefix}${name}`);
  return {
    id: categoryId,
    name: categoryNames[categoryId],
    prefix,
    defaultId: ids[0],
    ids,
  };
});

const rowByName = new Map(sheetRows.map((row) => [row.name, row]));
if (rowByName.size !== sheetRows.length) throw new Error("PlayerVisuals sheet contains duplicate names.");
const activeIds = new Set(categories.flatMap((category) => category.ids));

const visuals = [...activeIds].map((id) => {
  const row = rowByName.get(id);
  if (!row) throw new Error(`Scene visual ${id} has no PlayerVisuals row.`);
  const prefixCategory = categories.find((category) => id.startsWith(category.prefix));
  if (!prefixCategory || row.categoryId !== prefixCategory.id) {
    throw new Error(`Visual ${id} has category ${row.categoryId}, expected ${prefixCategory?.id}.`);
  }
  return row;
}).sort((left, right) => left.categoryId - right.categoryId || left.name.localeCompare(right.name));

const unresolvedRows = sheetRows
  .filter((row) => !activeIds.has(row.name))
  .map((row) => ({ ...row, reason: "No matching serialized PlayerVisual asset in MainScene." }))
  .sort((left, right) => left.categoryId - right.categoryId || left.name.localeCompare(right.name));

for (const row of visuals) {
  const nonNegativeFields = [
    row.unlockLevel, row.priceWarBucks, row.priceGold, row.durationSeconds,
    row.effectValue, row.rarity, row.parts, row.duplicateWarBucks,
  ];
  if (
    nonNegativeFields.some((value) => !Number.isFinite(value) || value < 0)
    || !Number.isInteger(row.effectType)
    || row.effectType < -1
  ) {
    throw new Error(`Visual ${row.name} contains an invalid numeric value.`);
  }
}

const artifact = {
  schemaVersion: 1,
  clientVersion: "4.9.5",
  source: "Client/ExportedProject/Assets/Scenes/MainScene.unity",
  sourceSha256: createHash("sha256").update(sceneBuffer).digest("hex"),
  categories,
  visuals,
  unresolvedRows,
};
const expected = `${JSON.stringify(artifact, null, 2)}\n`;

if (checkOnly) {
  let actual;
  try {
    actual = readFileSync(outputPath, "utf8");
  } catch {
    throw new Error(`Visual catalog is missing: ${outputPath}`);
  }
  if (actual !== expected) throw new Error("Visual catalog is stale. Run npm run generate:visual-catalog.");
  process.stdout.write(
    `Visual catalog is current: ${categories.length} categories, ${visuals.length} playable rows, and ${unresolvedRows.length} unresolved rows.\n`,
  );
} else {
  writeFileSync(outputPath, expected, "utf8");
  process.stdout.write(
    `Wrote ${outputPath} with ${categories.length} categories, ${visuals.length} playable rows, and ${unresolvedRows.length} unresolved rows.\n`,
  );
}
