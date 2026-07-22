import { createHash } from "node:crypto";
import { readFileSync, writeFileSync } from "node:fs";
import { dirname, resolve } from "node:path";
import { fileURLToPath } from "node:url";

const scriptDirectory = dirname(fileURLToPath(import.meta.url));
const serverDirectory = resolve(scriptDirectory, "..");
const repositoryDirectory = resolve(serverDirectory, "..");
const scenePath = resolve(repositoryDirectory, "Client/ExportedProject/Assets/Scenes/MainScene.unity");
const outputPath = resolve(serverDirectory, "src/data/cardCatalog.generated.json");
const checkOnly = process.argv.includes("--check");

const sceneBuffer = readFileSync(scenePath);
const scene = sceneBuffer.toString("utf8");

/** Index the large Unity YAML scene once and retain stable document boundaries. */
const documents = [];
const headerPattern = /^--- !u!(\d+) &(\d+)\r?$/gm;
let previous = null;
let header;
while ((header = headerPattern.exec(scene)) !== null) {
  if (previous) previous.end = header.index;
  const document = {
    type: Number(header[1]),
    fileId: header[2],
    start: header.index,
    end: scene.length,
  };
  documents.push(document);
  previous = document;
}

const blocks = documents.map((document) => ({
  ...document,
  text: scene.slice(document.start, document.end),
}));
const blockById = new Map(blocks.map((block) => [block.fileId, block]));

function scalar(value) {
  const trimmed = value.trim();
  if (/^-?\d+$/.test(trimmed)) return Number(trimmed);
  if (/^-?\d+(?:\.\d+)?(?:[eE][+-]?\d+)$/.test(trimmed)) return Number(trimmed);
  if (/^-?\d+\.\d+$/.test(trimmed)) return Number(trimmed);
  return trimmed.replace(/^'(.*)'$/, "$1");
}

function rowNames(block, tableName) {
  const match = /^  rowNames:\r?\n((?:  - [^\r\n]+\r?\n)+)/m.exec(block.text);
  if (!match) throw new Error(`${tableName}.rowNames was not found.`);
  return [...match[1].matchAll(/^  - ([^\r\n]+)$/gm)].map((item) => item[1]);
}

function flatRows(block, fields, tableName, validateNames = true) {
  const start = block.text.search(/^  Rows:$/m);
  if (start < 0) throw new Error(`${tableName}.Rows was not found.`);
  const rows = block.text
    .slice(start)
    .split(/^  - /m)
    .slice(1)
    .map((text) => `  - ${text}`)
    .map((text, index) => {
      const row = {};
      for (const line of text.split(/\r?\n/)) {
        const match = /^(?:  - |    )([A-Z][A-Z0-9_]*): ?(.*)$/.exec(line);
        if (match) row[match[1]] = scalar(match[2]);
      }
      for (const field of fields) {
        if (!(field in row)) throw new Error(`${tableName} row ${index} is missing ${field}.`);
      }
      return row;
    });
  const names = rowNames(block, tableName);
  if (names.length !== rows.length) {
    throw new Error(`${tableName} has ${names.length} names but ${rows.length} rows.`);
  }
  for (let index = 0; index < names.length; index++) {
    if (validateNames && names[index] !== rows[index].NAME) {
      throw new Error(`${tableName} row order differs at index ${index}.`);
    }
  }
  return rows;
}

/** Decode CodeStage ObscuredFloat's little-endian hidden int XOR currentCryptoKey. */
function obscuredFloat(hiddenHex, cryptoKey) {
  const bytes = Buffer.from(hiddenHex, "hex");
  if (bytes.length !== 4) throw new Error(`ObscuredFloat ${hiddenHex} is not four bytes.`);
  const bits = (bytes.readUInt32LE(0) ^ (cryptoKey >>> 0)) >>> 0;
  const decoded = Buffer.allocUnsafe(4);
  decoded.writeUInt32LE(bits, 0);
  return decoded.readFloatLE(0);
}

function keyedFloatRows(block, tableName) {
  const rowsStart = block.text.search(/^  Rows:$/m);
  if (rowsStart < 0) throw new Error(`${tableName}.Rows was not found.`);
  const rowBlocks = block.text.slice(rowsStart).split(/^  - /m).slice(1);
  const values = new Map();
  for (const [index, row] of rowBlocks.entries()) {
    const key = /^    DBKEY: ?([^\r\n]+)$/m.exec(row)?.[1]?.trim();
    if (!key) throw new Error(`${tableName} row ${index} has no DBKEY.`);
    const direct = /^FLOATVALUE: (-?\d+(?:\.\d+)?(?:[eE][+-]?\d+)?)$/m.exec(row);
    const hidden = /^FLOATVALUE:\r?\n      currentCryptoKey: (\d+)\r?\n      hiddenValue: ([0-9a-fA-F]{8})$/m.exec(row);
    const value = direct ? Number(direct[1]) : hidden ? obscuredFloat(hidden[2], Number(hidden[1])) : NaN;
    if (!Number.isFinite(value)) throw new Error(`${tableName}.${key} has an invalid FLOATVALUE.`);
    if (values.has(key)) throw new Error(`${tableName} contains duplicate DBKEY ${key}.`);
    values.set(key, value);
  }
  return values;
}

const definitionsBlock = blocks.find(({ text }) =>
  /^  - SLOWMOVE$/m.test(text)
  && /^    RARITY: /m.test(text)
  && /^    IMPLEMENTED: /m.test(text));
if (!definitionsBlock) throw new Error("CardDefinitions sheet was not found in MainScene.");
const definitionRows = flatRows(
  definitionsBlock,
  ["NAME", "RARITY", "FROMMISSION", "IMPLEMENTED"],
  "CardDefinitions",
).map((row) => ({
  name: row.NAME,
  rarity: row.RARITY,
  fromMission: row.FROMMISSION,
  implemented: row.IMPLEMENTED === 1,
}));

const definitionByName = new Map(definitionRows.map((row) => [row.name, row]));
if (definitionByName.size !== definitionRows.length) throw new Error("CardDefinitions contains duplicate names.");

const cardManager = blocks.find(({ text }) =>
  /^  cards:$/m.test(text)
  && new RegExp(`^  cardDefinitions: \\{fileID: ${definitionsBlock.fileId}\\}$`, "m").test(text));
if (!cardManager) throw new Error("CardManager component was not found in MainScene.");
const cardList = /^  cards:\r?\n((?:  - \{fileID: \d+\}\r?\n)+)/m.exec(cardManager.text)?.[1];
if (!cardList) throw new Error("CardManager.cards was not found.");
const cardComponentIds = [...cardList.matchAll(/fileID: (\d+)/g)].map((match) => match[1]);
const assetNames = cardComponentIds.map((fileId) => {
  const block = blockById.get(fileId);
  if (!block) throw new Error(`Card component ${fileId} was not found.`);
  const id = /^  id: ([^\r\n]+)$/m.exec(block.text)?.[1]?.trim();
  if (!id) throw new Error(`Card component ${fileId} has no id.`);
  return id;
});
if (new Set(assetNames).size !== assetNames.length) throw new Error("CardManager contains duplicate card IDs.");

const cards = assetNames.map((name) => {
  const definition = definitionByName.get(name);
  if (!definition) throw new Error(`Serialized card ${name} has no CardDefinitions row.`);
  return definition;
}).sort((left, right) => left.rarity - right.rarity || left.name.localeCompare(right.name));

const assetNameSet = new Set(assetNames);
const unresolvedRows = definitionRows
  .filter((row) => !assetNameSet.has(row.name))
  .map((row) => ({ ...row, reason: "No matching serialized Card component in MainScene." }))
  .sort((left, right) => left.rarity - right.rarity || left.name.localeCompare(right.name));

for (const row of definitionRows) {
  if (
    !Number.isInteger(row.rarity)
    || !Number.isInteger(row.fromMission)
    || (row.implemented && (row.rarity < 1 || row.rarity > 3))
    || (!row.implemented && (row.rarity < -1 || row.rarity > 3))
  ) {
    throw new Error(`Card ${row.name} has invalid rarity or mission data.`);
  }
}

const packsBlock = blocks.find(({ text }) =>
  /^  - BRONZE_CARDPACK$/m.test(text)
  && /^  - THREE_CARDS$/m.test(text)
  && /^    WARBUCKS: /m.test(text));
if (!packsBlock) throw new Error("CardPacks sheet was not found in MainScene.");
const packRows = flatRows(packsBlock, ["NAME", "GOLD", "WARBUCKS"], "CardPacks");

const constantsBlock = blocks.find(({ text }) =>
  /^  - GoldCardRarity$/m.test(text)
  && /^  - BronzePackBronzeCards$/m.test(text)
  && /^  - CardsInPack$/m.test(text));
if (!constantsBlock) throw new Error("Constants card-pack rows were not found in MainScene.");
const constants = keyedFloatRows(constantsBlock, "Constants");

const cardConstantsBlock = blocks.find(({ text }) =>
  /^  - WarcardsUnlockLevel$/m.test(text)
  && /^  - CardsForRewardedVideo$/m.test(text)
  && /^  Rows:$/m.test(text));
if (!cardConstantsBlock) throw new Error("CardConstants sheet was not found in MainScene.");
const cardConstants = keyedFloatRows(cardConstantsBlock, "CardConstants");

const squadsBlock = blocks.find(({ text }) =>
  /^    CARDPOOLSIZE: /m.test(text)
  && /^  - LEVEL: 1$/m.test(text)
  && /^  - LEVEL: 50$/m.test(text));
if (!squadsBlock) throw new Error("Squads card-pool rows were not found in MainScene.");
const squadRows = flatRows(squadsBlock, ["LEVEL", "SIZE", "EXPERIENCE", "CARDPOOLSIZE"], "Squads", false)
  .sort((left, right) => left.LEVEL - right.LEVEL);
if (squadRows.length !== 50) {
  throw new Error(`Squads progression must contain exactly 50 rows, found ${squadRows.length}.`);
}
for (let index = 0; index < squadRows.length; index++) {
  const row = squadRows[index];
  if (
    row.LEVEL !== index + 1
    || !Number.isInteger(row.SIZE)
    || row.SIZE < 1
    || !Number.isSafeInteger(row.EXPERIENCE)
    || row.EXPERIENCE < 1
    || !Number.isInteger(row.CARDPOOLSIZE)
    || row.CARDPOOLSIZE < 1
    || (index > 0 && row.EXPERIENCE < squadRows[index - 1].EXPERIENCE)
    || (index > 0 && row.SIZE < squadRows[index - 1].SIZE)
    || (index > 0 && row.CARDPOOLSIZE < squadRows[index - 1].CARDPOOLSIZE)
  ) {
    throw new Error(`Squads progression row ${index} is invalid or non-contiguous.`);
  }
}

function integerConstant(source, key) {
  const value = source.get(key);
  if (!Number.isInteger(value) || value < 0) throw new Error(`${key} is not a non-negative integer.`);
  return value;
}

const cardsInPack = integerConstant(constants, "CardsInPack");
const packRules = {
  BRONZE_CARDPACK: {
    enumValue: 1,
    cardCount: cardsInPack,
    fixedRarity: 1,
    fixedRarityCount: integerConstant(constants, "BronzePackBronzeCards"),
    guaranteedRarity: integerConstant(constants, "BronzePackGuaranteedCardsType"),
    maxRarity: integerConstant(constants, "BronzePackMaxRarityCardsType"),
  },
  SILVER_CARDPACK: {
    enumValue: 2,
    cardCount: cardsInPack,
    fixedRarity: 2,
    fixedRarityCount: integerConstant(constants, "SilverPackSilverCards"),
    guaranteedRarity: integerConstant(constants, "SilverPackGuaranteedCardsType"),
    maxRarity: integerConstant(constants, "SilverPackMaxRarityCardsType"),
  },
  GOLD_CARDPACK: {
    enumValue: 3,
    cardCount: cardsInPack,
    fixedRarity: 3,
    fixedRarityCount: integerConstant(constants, "GoldPackGoldCards"),
    guaranteedRarity: integerConstant(constants, "GoldPackGuaranteedCardsType"),
    maxRarity: integerConstant(constants, "GoldPackMaxRarityCardsType"),
  },
  THREE_CARDS: {
    enumValue: 6,
    cardCount: 3,
    fixedRarity: 0,
    fixedRarityCount: 0,
    guaranteedRarity: 1,
    maxRarity: 3,
  },
};

const packs = packRows.map((row) => {
  const rules = packRules[row.NAME];
  if (!rules) throw new Error(`Unsupported CardPacks row ${row.NAME}.`);
  if (
    !Number.isInteger(row.GOLD)
    || row.GOLD < 0
    || !Number.isInteger(row.WARBUCKS)
    || row.WARBUCKS < 0
    || rules.fixedRarityCount > rules.cardCount
    || rules.guaranteedRarity < 1
    || rules.maxRarity > 3
    || rules.guaranteedRarity > rules.maxRarity
  ) {
    throw new Error(`Card pack ${row.NAME} has invalid price or rarity rules.`);
  }
  return {
    name: row.NAME,
    priceGold: row.GOLD,
    priceWarBucks: row.WARBUCKS,
    ...rules,
  };
});
if (packs.length !== Object.keys(packRules).length) throw new Error("CardPacks is missing a supported pack row.");

const rarityProbabilities = {
  lowLevel: 7,
  highLevel: 10,
  silverEarly: constants.get("SilverCardRarityEarly"),
  silver: constants.get("SilverCardRarity"),
  goldEarly: constants.get("GoldCardRarityEarly"),
  gold: constants.get("GoldCardRarity"),
};
for (const [name, value] of Object.entries(rarityProbabilities)) {
  if (!Number.isFinite(value) || value < 0) throw new Error(`Card rarity setting ${name} is invalid.`);
}
if (
  rarityProbabilities.silverEarly > rarityProbabilities.goldEarly
  || rarityProbabilities.goldEarly > 1
  || rarityProbabilities.silver > rarityProbabilities.gold
  || rarityProbabilities.gold > 1
) {
  throw new Error("Card rarity probability thresholds are not ordered.");
}

const unlockLevel = integerConstant(cardConstants, "WarcardsUnlockLevel");
const craftingRules = {
  inputCount: 3,
  bronzeToSilverMinutes: integerConstant(constants, "CardCraftTimeSilver"),
  silverToGoldMinutes: integerConstant(constants, "CardCraftTimeGold"),
};
const cardPoolRules = {
  withdrawCooldownMinutes: integerConstant(constants, "CardWithdrawTimer"),
  buddyDepositCooldownMinutes: integerConstant(cardConstants, "BuddyDepositTimer"),
  maximumBuddyCards: integerConstant(constants, "MaximumNumberOfBuddyCards"),
  reputationPoints: {
    bronze: integerConstant(cardConstants, "RepPointsBronzeCard"),
    silver: integerConstant(cardConstants, "RepPointsSilverCard"),
    gold: integerConstant(cardConstants, "RepPointsGoldCard"),
    buddy: integerConstant(cardConstants, "RepPointsBuddyCard"),
  },
  capacityBySquadLevel: squadRows.map((row) => row.CARDPOOLSIZE),
};
// The recovered SquadStatsContent renders LevelExperience against the current row's EXPERIENCE,
// while GetSquadRankSize and SquadCardpoolSize read SIZE/CARDPOOLSIZE from that same one-based
// level. Keep the four values in one extracted row so backend rank transitions cannot combine
// thresholds and unlocks from different source revisions.
const squadLevelDefinitions = squadRows.map((row) => ({
  level: row.LEVEL,
  experience: row.EXPERIENCE,
  size: row.SIZE,
  cardPoolSize: row.CARDPOOLSIZE,
}));
const artifact = {
  schemaVersion: 4,
  clientVersion: "4.9.5",
  source: "Client/ExportedProject/Assets/Scenes/MainScene.unity",
  sourceSha256: createHash("sha256").update(sceneBuffer).digest("hex"),
  unlockLevel,
  rarityProbabilities,
  craftingRules,
  cardPoolRules,
  squadLevelDefinitions,
  cards,
  unresolvedRows,
  packs,
};
const expected = `${JSON.stringify(artifact, null, 2)}\n`;

const playableCount = cards.filter((card) => card.implemented).length;
const disabledCount = cards.length - playableCount;
if (checkOnly) {
  let actual;
  try {
    actual = readFileSync(outputPath, "utf8");
  } catch {
    throw new Error(`Card catalog is missing: ${outputPath}`);
  }
  if (actual !== expected) throw new Error("Card catalog is stale. Run npm run generate:card-catalog.");
  process.stdout.write(
    `Card catalog is current: ${playableCount} playable, ${disabledCount} disabled, ${unresolvedRows.length} unresolved, and ${packs.length} packs.\n`,
  );
} else {
  writeFileSync(outputPath, expected, "utf8");
  process.stdout.write(
    `Wrote ${outputPath}: ${playableCount} playable, ${disabledCount} disabled, ${unresolvedRows.length} unresolved, and ${packs.length} packs.\n`,
  );
}
