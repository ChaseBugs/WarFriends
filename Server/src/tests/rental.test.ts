import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import type { PlayerProgressionState, RentalItemType } from "../db";
import {
  WEAPON_CATALOG,
  equipWeaponState,
  parseWeaponEquipData,
} from "../services/itemInventoryService";
import { equippedWeaponPower } from "../services/armyPowerService";
import { createInitialProgression } from "../services/playerStateService";
import {
  RENTAL_OFFER_SECONDS,
  RENTAL_SALE_MAX_PERCENT,
  RENTAL_SALE_MIN_PERCENT,
  RENTAL_TRIAL_SECONDS,
  acceptRentalOfferState,
  advanceRentalAfterBattleState,
  ensureRentalOfferState,
  rentalDiscountedPrice,
} from "../services/rentalService";
import {
  UNIT_CATALOG,
  equippedUnitPower,
  updateEquippedUnitsState,
} from "../services/unitInventoryService";

const NOW = 1_900_000_000;
const SLOT_MASKS = [263, 1064, 592, 128] as const;

function fundedState(): PlayerProgressionState {
  return {
    ...createInitialProgression(NOW),
    gold: 10_000_000,
    warBucks: 10_000_000,
    tutorialFinished: true,
  };
}

function issueType(type: RentalItemType) {
  for (let index = 0; index < 200; index += 1) {
    const result = ensureRentalOfferState(fundedState(), `rental-type-${type}-${index}`, 8, NOW);
    if (result.rental?.type === type) return result;
  }
  throw new Error(`Could not deterministically issue rental type ${type}.`);
}

test("GetPlayerData rental generation uses the recovered duration, discount, and exact wire fields", () => {
  const issued = ensureRentalOfferState(fundedState(), "rental-wire", 8, NOW);
  assert.ok(issued.rental);
  assert.ok(issued.bootOffer);
  assert.equal(issued.rental.status, "offered");
  assert.equal(issued.rental.nextGenerate, NOW + RENTAL_OFFER_SECONDS);
  assert.ok(issued.rental.discount >= RENTAL_SALE_MIN_PERCENT);
  assert.ok(issued.rental.discount <= RENTAL_SALE_MAX_PERCENT);
  assert.deepEqual(Object.keys(issued.bootOffer).sort(), ["Amount", "Id", "Type", "nextGenerate"]);
  assert.equal(issued.bootOffer.Id, issued.rental.id);
  assert.equal(issued.bootOffer.Amount, String(issued.rental.discount));

  const replay = ensureRentalOfferState(issued.state, "rental-wire", 50, NOW + 60);
  assert.equal(replay.rental?.id, issued.rental.id);
  assert.deepEqual(replay.bootOffer, issued.bootOffer);
});

test("rental generation requires durable tutorial completion even at an eligible level", () => {
  const unfinished = {
    ...fundedState(),
    tutorialFinished: false,
  };
  const result = ensureRentalOfferState(unfinished, "unfinished-rental", 50, NOW);
  assert.equal(result.state, unfinished);
  assert.equal(result.rental, undefined);
  assert.equal(result.bootOffer, undefined);
});

test("weapon rental is borrowable for one trial, becomes a post-battle sale, and restores its slot", () => {
  const issued = issueType(1);
  const id = issued.rental!.id;
  const definition = WEAPON_CATALOG[id]!;
  const trial = acceptRentalOfferState(issued.state, false, NOW + 1);
  assert.equal(trial.resultAction, DbAction.AcceptRentalOffer);
  assert.equal(trial.rental?.status, "trial");
  assert.equal(trial.rental?.trialExpiresAt, NOW + 1 + RENTAL_TRIAL_SECONDS);
  assert.equal(trial.state.itemInventory?.levelManagerData.savedWeapons[id]?.borrowed, true);
  const trialReplay = acceptRentalOfferState(trial.state, false, NOW + 2);
  assert.equal(trialReplay.replayed, true);
  assert.equal(trialReplay.state, trial.state, "trial acceptance replay must not advance revision");

  const slotIndex = SLOT_MASKS.findIndex((mask) => (mask & definition.category) === definition.category);
  assert.notEqual(slotIndex, -1);
  const previous = trial.state.itemInventory!.inventoryData.slots[String(slotIndex)]!;
  const equipped = equipWeaponState(trial.state, parseWeaponEquipData(JSON.stringify({
    Index: String(definition.index),
    Name: id,
    SlotIndex: slotIndex,
    ArmyPower: 0,
    SpecialFeature: 0,
  })), NOW + 2);
  assert.equal(equipped.state.itemInventory?.inventoryData.slots[String(slotIndex)]?.name, id);
  assert.ok(equippedWeaponPower(equipped.state, NOW + 2) > 0);

  const sale = advanceRentalAfterBattleState(equipped.state, "rental-battle", NOW + 3);
  assert.equal(sale.rental?.status, "sale");
  assert.equal(sale.saleOffer?.accepted, 3);
  assert.equal(sale.state.itemInventory?.levelManagerData.savedWeapons[id], undefined);
  assert.deepEqual(sale.state.itemInventory?.inventoryData.slots[String(slotIndex)], previous);
});

test("discounted rental purchase is server-priced, permanent, and idempotent for both item families", () => {
  for (const type of [0, 1] as const) {
    const issued = issueType(type);
    const trial = acceptRentalOfferState(issued.state, false, NOW + 1);
    const sale = advanceRentalAfterBattleState(trial.state, `battle-type-${type}`, NOW + 2);
    const id = sale.rental!.id;
    const definition = type === 1 ? WEAPON_CATALOG[id]! : UNIT_CATALOG[id]!;
    const usesGold = definition.gold > 0;
    const base = usesGold ? definition.gold : definition.warBucks;
    const price = rentalDiscountedPrice(base, sale.rental!.discount);
    const bought = acceptRentalOfferState(sale.state, true, NOW + 3);

    assert.equal(bought.resultAction, type === 1 ? DbAction.BuyWeapon : DbAction.BuyUnit);
    assert.equal(bought.rental?.status, "purchased");
    assert.equal(bought.state.gold, sale.state.gold - (usesGold ? price : 0));
    assert.equal(bought.state.warBucks, sale.state.warBucks - (usesGold ? 0 : price));
    if (type === 1) {
      assert.deepEqual(bought.state.itemInventory?.levelManagerData.savedWeapons[id], {
        bought: true,
        boughtIndex: 0,
        showed: true,
        borrowed: false,
        specialFeature: 0,
      });
    } else {
      assert.equal(bought.state.itemInventory?.levelManagerData.savedArmies[id]?.borrowed, false);
      assert.equal(bought.state.itemInventory?.levelManagerData.savedArmies[id]?.bought, true);
    }

    const replay = acceptRentalOfferState(bought.state, true, NOW + 4);
    assert.equal(replay.replayed, true);
    assert.equal(replay.state, bought.state, "rental purchase replay must not advance revision");
    assert.equal(replay.state.gold, bought.state.gold);
    assert.equal(replay.state.warBucks, bought.state.warBucks);
  }
});

test("active unit rental can use the normal loadout and Army Power path only before expiry", () => {
  const issued = issueType(0);
  const id = issued.rental!.id;
  const trial = acceptRentalOfferState(issued.state, false, NOW + 1);
  const equipped = updateEquippedUnitsState(trial.state, {
    armyPower: 0,
    equips: { [id]: { wasEquipped: true, equipped: true } },
  }, NOW + 2);
  assert.equal(equipped.state.itemInventory?.levelManagerData.savedArmies[id]?.equipped, true);
  assert.ok(equippedUnitPower(equipped.state, NOW + 2) > 0);
  assert.throws(() => updateEquippedUnitsState(equipped.state, {
    armyPower: 0,
    equips: { [id]: { wasEquipped: true, equipped: true } },
  }, trial.rental!.trialExpiresAt));
});

test("expired trial authority is removed while the daily replacement stays on cooldown", () => {
  const issued = issueType(1);
  const trial = acceptRentalOfferState(issued.state, false, NOW + 1);
  const id = trial.rental!.id;
  const refreshed = ensureRentalOfferState(
    trial.state,
    "rental-expired",
    8,
    trial.rental!.trialExpiresAt,
  );
  assert.equal(refreshed.state.itemInventory?.levelManagerData.savedWeapons[id], undefined);
  assert.equal(refreshed.rental?.status, "cooldown");
  assert.equal(refreshed.rental?.generation, trial.rental!.generation);
  assert.equal(refreshed.bootOffer, undefined);

  const next = ensureRentalOfferState(
    refreshed.state,
    "rental-expired",
    8,
    trial.rental!.nextGenerate,
  );
  assert.equal(next.rental?.status, "offered");
  assert.equal(next.rental?.generation, trial.rental!.generation + 1);
});
