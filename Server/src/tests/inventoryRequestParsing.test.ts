import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import {
  requestedDirectInventoryName,
  requestedDirectVisualName,
  requestedDirectVisualPurchase,
} from "../handlers/inventoryRequestParsing";
import { visualHandlers } from "../handlers/visuals";

test("direct visual purchase requires canonical ObjData and agreeing duplicates", () => {
  const payload = JSON.stringify({ Name: "HEAD_CIGAR" });
  assert.equal(requestedDirectVisualPurchase({ ObjData: payload }), payload);
  assert.equal(requestedDirectVisualPurchase({ ObjData: payload, Data: payload, data: payload }), payload);
  assert.throws(() => requestedDirectVisualPurchase({ Data: payload }), /ObjData is invalid/);
  assert.throws(
    () => requestedDirectVisualPurchase({ ObjData: payload, Data: "{}" }),
    /ObjData fields conflict/,
  );
});

test("direct visual and inventory acknowledgements require their canonical identity fields", () => {
  assert.equal(requestedDirectVisualName({ DecalId: "HEAD_CIGAR" }), "HEAD_CIGAR");
  assert.equal(
    requestedDirectVisualName({ DecalId: "HEAD_CIGAR", Name: "HEAD_CIGAR" }),
    "HEAD_CIGAR",
  );
  assert.equal(requestedDirectInventoryName({ LevelName: "RIFLE_M16" }), "RIFLE_M16");
  assert.throws(() => requestedDirectVisualName({ Name: "HEAD_CIGAR" }), /DecalId is invalid/);
  assert.throws(() => requestedDirectInventoryName({ data: "RIFLE_M16" }), /LevelName is invalid/);
  assert.throws(
    () => requestedDirectInventoryName({ LevelName: "RIFLE_M16", Name: "RIFLE_AK47" }),
    /LevelName fields conflict/,
  );
});

test("ambiguous direct DecalWasShown remains telemetry even when a visual-looking alias is supplied", async () => {
  const response = await visualHandlers[DbAction.DecalWasShown].handler({
    req: { DbAction: DbAction.DecalWasShown, DecalId: "HEAD_CIGAR" },
    player: { id: "visual-impression-player" } as never,
  });
  assert.equal(response.Result, 1);
  assert.equal(response.Ignored, true);
  assert.equal(response.DecalManagerData, undefined);
});
