export type InAppEntitlement =
  | { kind: "currency"; productId: string; gold: number; warBucks: number }
  | { kind: "subscription"; productId: "subscription1" };

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

export function inAppEntitlement(productId: string): InAppEntitlement | null {
  if (productId === "subscription1") return { kind: "subscription", productId };
  return currencyEntitlements.get(productId) ?? null;
}

/** Android PLIABAOLHBE.GCPPOCNJDNA constructs the Play SKU with this exact convention. */
export function googlePlayStoreProductId(packageName: string, productId: string): string {
  return `${packageName}.${productId.toLowerCase()}`;
}
