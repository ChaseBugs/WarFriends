export type InAppEntitlement =
  | { kind: "currency"; productId: string; gold: number; warBucks: number }
  | PackEntitlement
  | { kind: "subscription"; productId: "subscription1" };

export interface PackVisualEntitlement {
  name: string;
  /** Zero is permanent; positive values are seconds from verified delivery time. */
  durationSeconds: number;
}

export interface PackEntitlement {
  kind: "pack";
  /** Exact InApps/Google Play product identity. */
  productId: string;
  /** Exact Packs sheet row used as grant authority; differs only for afstarterpack. */
  sourcePackName: string;
  gold: number;
  warBucks: number;
  vipSeconds: number;
  weapons: readonly string[];
  visuals: readonly PackVisualEntitlement[];
  extraCardSlot: boolean;
}

/**
 * Paid currency rows serialized in the recovered 4.9.5 MainScene InApps table.
 *
 * This is intentionally a narrow allowlist. Daily boosters and packs need additional durable
 * state/inventory delivery, so treating their client-visible price row as sufficient authority
 * would accept money without implementing the purchased benefit. Unknown rows therefore fail
 * with the recovered InvalidInapp response instead of silently granting guessed contents.
 */
const currencyEntitlements = new Map<string, InAppEntitlement>([
  ...[100, 275, 575, 1_250, 3_750, 8_250].flatMap((gold, index) => [
    [`afgold${index + 1}`, { kind: "currency" as const, productId: `afgold${index + 1}`, gold, warBucks: 0 }],
    [`bgold${index + 1}`, { kind: "currency" as const, productId: `bgold${index + 1}`, gold, warBucks: 0 }],
  ]),
  ...[15_000, 47_500, 112_500, 300_000, 950_000, 2_250_000].map((warBucks, index) => [
    `warbucks${index + 1}`,
    { kind: "currency" as const, productId: `warbucks${index + 1}`, gold: 0, warBucks },
  ]),
  ...[30_000, 95_000, 225_000, 600_000, 1_900_000, 4_500_000].map((warBucks, index) => [
    `bwarbucks${index + 1}`,
    { kind: "currency" as const, productId: `bwarbucks${index + 1}`, gold: 0, warBucks },
  ]),
] as Array<[string, InAppEntitlement]>);

function pack(
  productId: string,
  sourcePackName: string,
  gold: number,
  warBucks: number,
  vipSeconds: number,
  weapons: readonly string[] = [],
  visuals: readonly PackVisualEntitlement[] = [],
  extraCardSlot = false,
): [string, PackEntitlement] {
  return [productId, Object.freeze({
    kind: "pack",
    productId,
    sourcePackName,
    gold,
    warBucks,
    vipSeconds,
    weapons: Object.freeze([...weapons]),
    visuals: Object.freeze(visuals.map((visual) => Object.freeze({ ...visual }))),
    extraCardSlot,
  })];
}

/**
 * Fully deliverable 4.9.5 pack rows joined to the InApps table.
 *
 * This is deliberately not every product whose name contains "pack". Elite/Veteran rows name
 * special weapon types that are absent from the recovered LevelManager catalog, while special
 * offer rows advertise LP/Scraps not present in their serialized grant columns. Enabling either
 * family would accept real money for an incomplete benefit. These seven rows can be represented
 * completely by the existing wallet, VIP, weapon, visual, and CardManagerData models.
 */
const packEntitlements = new Map<string, InAppEntitlement>([
  pack(
    "afstarterpack",
    "starterpack",
    150,
    25_000,
    259_200,
    ["Google2u.LMG_Minigun"],
    [{ name: "BANDS_DAMAGE_0", durationSeconds: 14_400 }],
  ),
  pack(
    "starterpackB",
    "starterpackB",
    150,
    25_000,
    259_200,
    ["Google2u.LMG_Minigun"],
    [{ name: "BANDS_DAMAGE_0", durationSeconds: 14_400 }],
  ),
  pack(
    "valuepackaf",
    "valuepackaf",
    200,
    0,
    1_209_600,
    [],
    [
      { name: "CAMOS_ALIEN", durationSeconds: 0 },
      { name: "HELMETS_SKULL", durationSeconds: 0 },
    ],
    true,
  ),
  pack(
    "valuepackafB",
    "valuepackafB",
    200,
    0,
    1_209_600,
    [],
    [
      { name: "CAMOS_ALIEN", durationSeconds: 0 },
      { name: "HELMETS_SKULL", durationSeconds: 0 },
    ],
    true,
  ),
  pack(
    "valuepackafc",
    "valuepackafc",
    200,
    0,
    1_209_600,
    [],
    [
      { name: "CAMOS_ALIEN", durationSeconds: 0 },
      { name: "HELMETS_SKULL", durationSeconds: 0 },
    ],
    true,
  ),
  pack("moneypack1", "moneypack1", 1_150, 350_000, 86_400),
  pack("moneypack1B", "moneypack1B", 575, 180_000, 86_400),
]);

export function inAppEntitlement(productId: string): InAppEntitlement | null {
  if (productId === "subscription1") return { kind: "subscription", productId };
  return currencyEntitlements.get(productId) ?? packEntitlements.get(productId) ?? null;
}

/** Android PLIABAOLHBE.GCPPOCNJDNA constructs the Play SKU with this exact convention. */
export function googlePlayStoreProductId(packageName: string, productId: string): string {
  return `${packageName}.${productId.toLowerCase()}`;
}
