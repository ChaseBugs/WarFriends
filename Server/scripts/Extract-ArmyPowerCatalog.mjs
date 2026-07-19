import { createHash } from "node:crypto";
import { readFileSync, writeFileSync } from "node:fs";
import { dirname, resolve } from "node:path";
import { fileURLToPath } from "node:url";

const scriptDirectory = dirname(fileURLToPath(import.meta.url));
const serverDirectory = resolve(scriptDirectory, "..");
const repositoryDirectory = resolve(serverDirectory, "..");
const scenePath = resolve(repositoryDirectory, "Client/ExportedProject/Assets/Scenes/MainScene.unity");
const weaponCatalogPath = resolve(serverDirectory, "src/data/weaponCatalog.generated.json");
const outputPath = resolve(serverDirectory, "src/data/armyPowerCatalog.generated.json");
const checkOnly = process.argv.includes("--check");

const sceneBuffer = readFileSync(scenePath);
const scene = sceneBuffer.toString("utf8");
const weaponCatalog = JSON.parse(readFileSync(weaponCatalogPath, "utf8"));

/**
 * Build a lightweight index over Unity YAML documents. MainScene is about 87 MB; indexing byte
 * ranges once is substantially faster than the older PowerShell extractors, which invoke a
 * scriptblock for every line on every pass. Only target document slices are retained afterward.
 */
const documents = new Map();
const headerPattern = /^--- !u!(\d+) &(\d+)\r?$/gm;
let previous = null;
let header;
while ((header = headerPattern.exec(scene)) !== null) {
  if (previous) previous.end = header.index;
  const document = { type: Number(header[1]), start: header.index, end: scene.length };
  documents.set(header[2], document);
  previous = document;
}

function documentText(fileId) {
  const document = documents.get(String(fileId));
  if (!document) throw new Error(`Unity document ${fileId} was not found in MainScene.`);
  return scene.slice(document.start, document.end);
}

const setupListMatch = /^  weaponLevelsSetups:\r?\n((?:  - \{fileID: \d+\}\r?\n)+)/m.exec(scene);
if (!setupListMatch) throw new Error("LevelManager.weaponLevelsSetups was not found.");
const setupIds = [...setupListMatch[1].matchAll(/fileID: (\d+)/g)].map((match) => match[1]);

function gameObjectId(componentId) {
  const match = /^  m_GameObject: \{fileID: (\d+)\}$/m.exec(documentText(componentId));
  if (!match) throw new Error(`Component ${componentId} has no GameObject reference.`);
  return match[1];
}

function componentIds(gameObjectFileId) {
  return [...documentText(gameObjectFileId).matchAll(/^  - component: \{fileID: (\d+)\}$/gm)]
    .map((match) => match[1]);
}

function dpsRows(componentId) {
  const block = documentText(componentId);
  if (!/^  Rows:$/m.test(block) || !/^    DPS: /m.test(block)) return null;

  const rows = [];
  let insideRows = false;
  let currentDps = null;
  for (const line of block.split(/\r?\n/)) {
    if (!insideRows) {
      if (line === "  Rows:") insideRows = true;
      continue;
    }
    if (/^  - [A-Z][A-Z0-9_]*:/.test(line)) {
      if (currentDps !== null) rows.push(currentDps);
      currentDps = null;
      continue;
    }
    const dps = /^    DPS: (-?\d+(?:\.\d+)?)$/.exec(line);
    if (dps) currentDps = Number(dps[1]);
  }
  if (currentDps !== null) rows.push(currentDps);
  return rows;
}

const weaponPower = [];
for (const definition of weaponCatalog.catalog) {
  const setupId = setupIds[definition.index];
  if (!setupId || setupId === "0") {
    throw new Error(`Weapon ${definition.name} has no LevelManager setup at index ${definition.index}.`);
  }
  const objectId = gameObjectId(setupId);
  const candidates = componentIds(objectId).filter((componentId) => componentId !== setupId);
  const tables = candidates
    .map((componentId) => ({ componentId, rows: dpsRows(componentId) }))
    .filter((candidate) => candidate.rows !== null);
  if (tables.length !== 1) {
    throw new Error(`Weapon ${definition.name} resolved ${tables.length} DPS tables instead of one.`);
  }

  const rows = tables[0].rows;
  if (rows.length < 2 || rows.some((value) => !Number.isFinite(value) || value < 0)) {
    throw new Error(`Weapon ${definition.name} contains invalid DPS rows.`);
  }
  // maxWeaponLevel is source row count - 1. The last row is WARARENA balancing, so normal
  // persisted boughtIndex values resolve against every row except that final source row.
  weaponPower.push({
    name: definition.name,
    index: definition.index,
    powerByLevel: rows.slice(0, -1),
  });
}

const featureNames = [
  "MagazineSize",
  "Reload",
  "Damage",
  "Critical",
  "BurstSize",
  "TotalAmmo",
  "Accuracy",
  "RateOfFire",
  "ShotVelocity",
];
const featureFields = featureNames.map((name) => name.toUpperCase());
const categoryNames = [
  "AssaultRifle",
  "SMG",
  "LMG",
  "SniperRifle",
  "RocketLauncher",
  "Shotgun",
  "Grenade",
  "Pistol",
  "Minigun",
  "GrenadeLauncher",
  "PulseRifle",
];

/** Decode CodeStage ObscuredFloat's little-endian hidden int XOR currentCryptoKey. */
function obscuredFloat(hiddenHex, cryptoKey) {
  const bytes = Buffer.from(hiddenHex, "hex");
  if (bytes.length !== 4) throw new Error(`ObscuredFloat ${hiddenHex} is not four bytes.`);
  const bits = (bytes.readUInt32LE(0) ^ (cryptoKey >>> 0)) >>> 0;
  const decoded = Buffer.allocUnsafe(4);
  decoded.writeUInt32LE(bits, 0);
  return decoded.readFloatLE(0);
}

const featuresDocument = [...documents.values()]
  .map((document) => scene.slice(document.start, document.end))
  .find((block) => /^  - DpsCoefAssaultRifle$/m.test(block) && /^  Rows:$/m.test(block));
if (!featuresDocument) throw new Error("WeaponFeatures coefficient table was not found.");

const rowNamesBlock = /^  rowNames:\r?\n((?:  - [^\r\n]+\r?\n)+)/m.exec(featuresDocument)?.[1];
if (!rowNamesBlock) throw new Error("WeaponFeatures.rowNames was not found.");
const featureRowNames = [...rowNamesBlock.matchAll(/^  - ([^\r\n]+)$/gm)].map((match) => match[1]);

const rowsStart = featuresDocument.indexOf("\n  Rows:\n");
if (rowsStart < 0) throw new Error("WeaponFeatures.Rows was not found.");
const rowBlocks = featuresDocument
  .slice(rowsStart + "\n  Rows:\n".length)
  .split(/^  - /m)
  .filter(Boolean)
  .map((block) => `  - ${block}`);
if (rowBlocks.length !== featureRowNames.length) {
  throw new Error(`WeaponFeatures has ${featureRowNames.length} names but ${rowBlocks.length} rows.`);
}

const featureDpsCoefficients = categoryNames.map((category, categoryIndex) => {
  const rowName = `DpsCoef${category}`;
  const rowIndex = featureRowNames.indexOf(rowName);
  if (rowIndex < 0) throw new Error(`WeaponFeatures row ${rowName} was not found.`);
  const row = rowBlocks[rowIndex];
  const dpsByFeature = featureFields.map((field, featureIndex) => {
    const pattern = new RegExp(
      `^(?:  - |    )${field}:\\r?\\n      currentCryptoKey: (\\d+)\\r?\\n      hiddenValue: ([0-9a-fA-F]{8})$`,
      "m",
    );
    const match = pattern.exec(row);
    if (!match) throw new Error(`${rowName}.${field} has no serialized ObscuredFloat.`);
    const value = obscuredFloat(match[2], Number(match[1]));
    if (!Number.isFinite(value) || value <= 0 || value > 10) {
      throw new Error(`${rowName}.${field} decoded to invalid coefficient ${value}.`);
    }
    return { index: featureIndex, name: featureNames[featureIndex], coefficient: value };
  });
  return { category, categoryMask: 2 ** categoryIndex, dpsByFeature };
});

const levelsStart = scene.indexOf("\n  levels:\n", setupListMatch.index);
if (levelsStart < 0) throw new Error("LevelManager.levels was not found.");
const levelsTail = scene.slice(levelsStart + 1);
const nextField = /\r?\n  (?!- )[A-Za-z_][A-Za-z0-9_]*:/.exec(levelsTail.slice("  levels:\n".length));
if (!nextField) throw new Error("Could not determine the end of LevelManager.levels.");
const levelsSection = levelsTail.slice(
  "  levels:\n".length,
  "  levels:\n".length + nextField.index,
);

const rankLevels = [];
const levelPattern = /^  - index: (\d+)\r?\n    row:\r?\n((?:      .*\r?\n?)*)/gm;
let levelMatch;
while ((levelMatch = levelPattern.exec(levelsSection)) !== null) {
  const index = Number(levelMatch[1]);
  const displayLevelMatch = /^      LEVEL: (\d+)$/m.exec(levelMatch[2]);
  const experienceMatch = /^      EXPERIENCE: (\d+)$/m.exec(levelMatch[2]);
  const rewardGoldMatch = /^      REWARDGOLD: (\d+)$/m.exec(levelMatch[2]);
  const powerMatch = /^      ARMYPOWER: (-?\d+)$/m.exec(levelMatch[2]);
  if (!displayLevelMatch || !experienceMatch || !rewardGoldMatch || !powerMatch) {
    throw new Error(`Level row ${index} is missing LEVEL, EXPERIENCE, REWARDGOLD, or ARMYPOWER.`);
  }
  rankLevels.push({
    index,
    displayLevel: Number(displayLevelMatch[1]),
    experience: Number(experienceMatch[1]),
    rewardGold: Number(rewardGoldMatch[1]),
    armyPower: Number(powerMatch[1]),
  });
}
rankLevels.sort((left, right) => left.index - right.index);
for (let index = 0; index < rankLevels.length; index++) {
  const row = rankLevels[index];
  if (
    row.index !== index
    || row.displayLevel !== index + 1
    || !Number.isSafeInteger(row.experience)
    || row.experience < 1
    || !Number.isSafeInteger(row.rewardGold)
    || row.rewardGold < 0
    || row.armyPower < 0
  ) {
    throw new Error(`Level row ${index} is not contiguous or contains invalid progression balancing.`);
  }
}
if (rankLevels.length < 2) throw new Error("Too few player-level Army Power rows were extracted.");

const artifact = {
  schemaVersion: 2,
  clientVersion: "4.9.5",
  source: "Client/ExportedProject/Assets/Scenes/MainScene.unity",
  sourceSha256: createHash("sha256").update(sceneBuffer).digest("hex"),
  rankLevels,
  featureDpsCoefficients,
  weapons: weaponPower,
};
const expected = `${JSON.stringify(artifact, null, 2)}\n`;

if (checkOnly) {
  let actual;
  try {
    actual = readFileSync(outputPath, "utf8");
  } catch {
    throw new Error(`Army Power catalog is missing: ${outputPath}`);
  }
  if (actual !== expected) {
    throw new Error("Army Power catalog is stale. Run npm run generate:army-power.");
  }
  process.stdout.write(
    `Army Power catalog is current: ${rankLevels.length} rank rows, ${weaponPower.length} weapon tables, and ${featureDpsCoefficients.length} feature coefficient rows.\n`,
  );
} else {
  writeFileSync(outputPath, expected, "utf8");
  process.stdout.write(
    `Wrote ${outputPath} with ${rankLevels.length} rank rows, ${weaponPower.length} weapon tables, and ${featureDpsCoefficients.length} feature coefficient rows.\n`,
  );
}
