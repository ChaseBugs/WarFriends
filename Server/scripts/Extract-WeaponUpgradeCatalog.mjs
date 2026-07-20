import { readFileSync, writeFileSync } from "node:fs";
import { dirname, resolve } from "node:path";
import { fileURLToPath } from "node:url";

const scriptDirectory = dirname(fileURLToPath(import.meta.url));
const serverDirectory = resolve(scriptDirectory, "..");
const repositoryDirectory = resolve(serverDirectory, "..");
const scenePath = resolve(repositoryDirectory, "Client/ExportedProject/Assets/Scenes/MainScene.unity");
const weaponCatalogPath = resolve(serverDirectory, "src/data/weaponCatalog.generated.json");
const outputPath = resolve(serverDirectory, "src/data/weaponUpgradeCatalog.generated.ts");
const checkOnly = process.argv.includes("--check");

const scene = readFileSync(scenePath, "utf8");
const artifact = JSON.parse(readFileSync(weaponCatalogPath, "utf8"));
const shopDefinitions = artifact.catalog;
const blackMarketDefinitions = artifact.blackMarketCatalog;
if (!Array.isArray(shopDefinitions) || !Array.isArray(blackMarketDefinitions)) {
  throw new Error("weaponCatalog.generated.json does not contain both weapon families.");
}

/**
 * MainScene is roughly 87 MB. Index Unity document byte ranges once, then inspect only the
 * LevelManager setups and Google2u table components referenced by the generated catalog.
 * This replaces the older multi-pass PowerShell scriptblock scan, reducing verification from
 * several minutes to seconds while preserving the same checked-in source authority.
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

function obscuredInt(section, field, weaponName) {
  if (section.direct !== null) return section.direct;
  const hidden = Number(section.hidden);
  if (!Number.isInteger(section.key) || !Number.isInteger(hidden)) {
    throw new Error(`${weaponName} contains an incomplete ${field} ObscuredInt.`);
  }
  return section.key ^ hidden;
}

function obscuredFloat(section, field, weaponName) {
  if (section.direct !== null) return section.direct;
  if (!Number.isInteger(section.key) || !/^[0-9a-fA-F]{8}$/.test(section.hidden ?? "")) {
    throw new Error(`${weaponName} contains an incomplete ${field} ObscuredFloat.`);
  }
  // Unity serialized the four encrypted union bytes in little-endian memory order. XOR the
  // 32-bit representation with currentCryptoKey, then reinterpret those bits as float32.
  const encrypted = Buffer.from(section.hidden, "hex").readUInt32LE(0);
  const plain = (encrypted ^ (section.key >>> 0)) >>> 0;
  const bytes = Buffer.allocUnsafe(4);
  bytes.writeUInt32LE(plain, 0);
  return bytes.readFloatLE(0);
}

function emptySection() {
  return { direct: null, key: null, hidden: null };
}

/** Parse the exact four price/time fields needed from one Google2u weapon-level table. */
function weaponRows(block, weaponName, requireBlackMarketPrice) {
  if (!/^  Rows:$/m.test(block) || !/^    NEXTUPGRADEPRICE:/m.test(block) || !/^    DELIVERYTIME:/m.test(block)) {
    return null;
  }

  const rows = [];
  let insideRows = false;
  let current = null;
  let activeSection = null;
  function finishRow() {
    if (!current) return;
    const deliveryFloat = obscuredFloat(current.delivery, "DELIVERYTIME", weaponName);
    const deliverySeconds = Math.round(deliveryFloat);
    if (Math.abs(deliveryFloat - deliverySeconds) > 0.001 || deliverySeconds < 0) {
      throw new Error(`${weaponName} contains invalid DELIVERYTIME ${deliveryFloat}.`);
    }
    if (current.upgradeGold !== 0) {
      throw new Error(`${weaponName} contains unexpected Gold upgrade price ${current.upgradeGold}.`);
    }
    const warBucks = obscuredInt(current.upgrade, "NEXTUPGRADEPRICE", weaponName);
    const blackMarketGold = requireBlackMarketPrice
      ? obscuredInt(current.blackMarket, "WEAPONPRICE", weaponName)
      : null;
    if (warBucks < 0 || (blackMarketGold !== null && blackMarketGold < 0)) {
      throw new Error(`${weaponName} contains a negative recovered price.`);
    }
    rows.push({ warBucks, deliverySeconds, blackMarketGold });
  }

  for (const line of block.split(/\r?\n/)) {
    if (!insideRows) {
      if (line === "  Rows:") insideRows = true;
      continue;
    }
    if (/^  - [A-Z][A-Z0-9_]*:/.test(line)) {
      finishRow();
      current = {
        upgrade: emptySection(),
        upgradeGold: 0,
        delivery: emptySection(),
        blackMarket: emptySection(),
      };
      activeSection = null;
      continue;
    }
    if (!current) continue;

    const direct = /^    (NEXTUPGRADEPRICE|DELIVERYTIME|WEAPONPRICE): (-?\d+(?:\.\d+)?)$/.exec(line);
    if (direct) {
      const target = direct[1] === "NEXTUPGRADEPRICE"
        ? current.upgrade
        : direct[1] === "DELIVERYTIME"
          ? current.delivery
          : current.blackMarket;
      target.direct = Number(direct[2]);
      activeSection = null;
      continue;
    }
    if (line === "    NEXTUPGRADEPRICE:") activeSection = current.upgrade;
    else if (line === "    DELIVERYTIME:") activeSection = current.delivery;
    else if (line === "    WEAPONPRICE:") activeSection = current.blackMarket;
    else {
      const upgradeGold = /^    NEXTUPGRADEPRICEGOLD: (-?\d+)$/.exec(line);
      if (upgradeGold) {
        current.upgradeGold = Number(upgradeGold[1]);
        activeSection = null;
        continue;
      }
      if (/^    [A-Z][A-Z0-9_]*:/.test(line)) activeSection = null;
    }

    if (activeSection) {
      const key = /^      currentCryptoKey: (-?\d+)$/.exec(line);
      const hidden = /^      hiddenValue: ([0-9a-fA-F-]+)$/.exec(line);
      if (key) activeSection.key = Number(key[1]);
      if (hidden) activeSection.hidden = hidden[1];
    }
  }
  finishRow();
  return rows;
}

function sourceRows(definition) {
  const setupId = setupIds[definition.index];
  if (!setupId || setupId === "0") {
    throw new Error(`${definition.name} has no LevelManager setup at index ${definition.index}.`);
  }
  const objectId = gameObjectId(setupId);
  const candidates = componentIds(objectId)
    .filter((componentId) => componentId !== setupId)
    .map((componentId) => {
      const block = documentText(componentId);
      const hasBlackMarketPrice = /^    WEAPONPRICE:/m.test(block);
      const rows = weaponRows(block, definition.name, hasBlackMarketPrice);
      return rows ? { rows, hasBlackMarketPrice } : null;
    })
    .filter((candidate) => candidate !== null);
  if (candidates.length !== 1) {
    throw new Error(`${definition.name} resolved ${candidates.length} weapon tables instead of one.`);
  }
  if (candidates[0].rows.length < 3) throw new Error(`${definition.name} has too few weapon rows.`);
  return candidates[0];
}

const allDefinitions = [...shopDefinitions, ...blackMarketDefinitions];
const upgrades = new Map();
const blackMarketPrices = new Map();
const blackMarketNames = new Set(blackMarketDefinitions.map((definition) => definition.name));
for (const definition of allDefinitions) {
  if (upgrades.has(definition.name)) throw new Error(`Duplicate weapon definition ${definition.name}.`);
  const isBlackMarket = blackMarketNames.has(definition.name);
  const source = sourceRows(definition);
  const rows = source.rows;
  // With N total rows, N-1 is WARARENA and N-2 is the maximum normal level. Upgrade
  // transitions therefore use 0..N-3, while Black Market purchase prices use 0..N-2.
  upgrades.set(definition.name, rows.slice(0, -2));
  if (isBlackMarket && source.hasBlackMarketPrice) {
    blackMarketPrices.set(definition.name, rows.slice(0, -1).map((row) => row.blackMarketGold));
  }
}

const lines = [
  "// Generated by scripts/Extract-WeaponUpgradeCatalog.mjs from the 4.9.5 MainScene.",
  "// Do not hand-edit prices or delivery times; regenerate and review the source diff.",
  "",
  "export type WeaponUpgradeStage = readonly [warBucks: number, deliverySeconds: number];",
  "",
  "/**",
  " * Index N is the authoritative cost and duration for upgrading boughtIndex N to N+1.",
  " * Both normal-shop and dedicated Black Market LevelManager weapon families are included.",
  " */",
  "export const WEAPON_UPGRADE_CATALOG: Readonly<Record<string, readonly WeaponUpgradeStage[]>> = Object.freeze({",
];
for (const definition of allDefinitions) {
  lines.push(`  ${JSON.stringify(definition.name)}: Object.freeze([`);
  const rows = upgrades.get(definition.name);
  for (let index = 0; index < rows.length; index += 8) {
    lines.push(`    ${rows.slice(index, index + 8).map((row) => `[${row.warBucks}, ${row.deliverySeconds}]`).join(", ")},`);
  }
  lines.push("  ] as const),");
}
lines.push("});", "", "/**");
lines.push(" * Gold price at each normal boughtIndex for dedicated Black Market weapons.");
lines.push(" * The terminal WARARENA row is excluded from every array.");
lines.push(" */");
lines.push("export const WEAPON_BLACK_MARKET_PRICES: Readonly<Record<string, readonly number[]>> = Object.freeze({");
for (const definition of blackMarketDefinitions.filter((entry) => blackMarketPrices.has(entry.name))) {
  lines.push(`  ${JSON.stringify(definition.name)}: Object.freeze([`);
  const prices = blackMarketPrices.get(definition.name);
  for (let index = 0; index < prices.length; index += 12) {
    lines.push(`    ${prices.slice(index, index + 12).join(", ")},`);
  }
  lines.push("  ] as const),");
}
lines.push("});", "");
const expectedText = lines.join("\n");

if (checkOnly) {
  const actualText = readFileSync(outputPath, "utf8");
  if (actualText !== expectedText) {
    throw new Error("Generated weapon upgrade catalog is stale. Run npm run generate:weapon-upgrades.");
  }
  console.log(`Weapon upgrade catalog is current: ${allDefinitions.length} weapons, ${blackMarketPrices.size} Black Market price tables.`);
} else {
  writeFileSync(outputPath, expectedText, "utf8");
  console.log(`Wrote ${outputPath} with ${allDefinitions.length} weapon upgrade tables and ${blackMarketPrices.size} Black Market price tables.`);
}
