"""Dependent candidates must retain gameplay values and bind the exact staged bytes."""
import hashlib
import json
import subprocess
import sys
import unittest
import extract_army_perks as perks
import extract_coop_card_rows as coop_cards
import extract_coop_skillshot_scores as coop_scores
import extract_pvp_skillshot_scores as pvp_scores
import build_ordinary_card_identities as card_identities
import extract_coop_enemy_point_masks as point_masks
import extract_air_unit_geometry as air_geometry
import extract_rusher_weapon_bindings as rusher_weapons
import extract_coop_assaulter_weapon as assaulter_weapon
import extract_landmine_source as landmine
import extract_heavy_turret_source as heavy_turret
import extract_mortar_weapon_pool as mortar_pool

from audit_battle_sheet_values import CONTENT, ROOT, SCENE
from stage_battle_sheet_content import build_candidate
from stage_sheet_dependents import build_candidates, validate_changes


class DependentCandidateTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.names = json.loads((ROOT / "Server/docs/bot-name-source-audit.json").read_bytes())
        audit = json.loads((ROOT / "Server/docs/battle-sheet-value-audit.json").read_bytes())
        cls.content = build_candidate(SCENE.read_bytes(), CONTENT.read_bytes(), audit, cls.names)
        cls.candidates = build_candidates(SCENE.read_bytes(), cls.content, cls.names)

    def test_exact_dependency_binding(self):
        digest = hashlib.sha256(self.content).hexdigest()
        profile = json.loads(self.candidates["legacy-catalog-profile.json"])
        score = json.loads(self.candidates["recovered-pvp-score-streak-policy.json"])
        self.assertEqual(profile["artifactSha256"], digest)
        self.assertEqual(score["battleContentSha256"], digest)
        self.assertEqual(score["bonusThreshold"], 100)
        self.assertEqual(score["maximumBonusesPerUpdate"], 1)
        self.assertEqual(score["multiplayerRatio"], 0.75)

    def test_changed_gameplay_is_not_a_hash_refresh(self):
        name = "recovered-pvp-score-streak-policy.json"
        previous = json.loads((ROOT / "Server/content" / name).read_bytes())
        changed = json.loads(self.candidates[name])
        changed["maximumBonusesPerUpdate"] = 2
        with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
            validate_changes(name, previous, changed, self.names)

    def test_unreviewed_profile_identity_is_rejected(self):
        name = "legacy-catalog-profile.json"
        previous = json.loads((ROOT / "Server/content" / name).read_bytes())
        changed = json.loads(self.candidates[name])
        changed["sheets"][0]["path"] = "invented"
        with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
            validate_changes(name, previous, changed, self.names)

    def test_stale_dependency_hash_is_rejected(self):
        name = "legacy-catalog-profile.json"
        previous = json.loads((ROOT / "Server/content" / name).read_bytes())
        changed = json.loads(self.candidates[name])
        changed["artifactSha256"] = previous["artifactSha256"]
        with self.assertRaisesRegex(ValueError, "not refreshed"):
            validate_changes(name, previous, changed, self.names)

    def test_unknown_score_arguments_fail_before_writing(self):
        path = ROOT / "Server/content/recovered-pvp-score-streak-policy.json"
        before = path.read_bytes()
        result = subprocess.run([sys.executable, str(ROOT / "Server/tools/extract_pvp_score_streak_policy.py"),
                                 "--unknown"], capture_output=True, timeout=30)
        self.assertEqual(result.returncode, 2)
        self.assertEqual(path.read_bytes(), before)

    def test_bonus_rules_keep_recovered_float_bits_and_probability_rows(self):
        name = "recovered-pvp-bonus-catalog.json"
        previous = json.loads((ROOT / "Server/content" / name).read_bytes())
        candidate = json.loads(self.candidates[name])
        self.assertEqual(candidate["rows"], previous["rows"])
        self.assertEqual(candidate["rules"]["grenadeCount"], 3)
        self.assertEqual(candidate["battleContentSha256"], hashlib.sha256(self.content).hexdigest())
        candidate["rules"]["warbucksScalingBase"] += 0.001
        with self.assertRaisesRegex(ValueError, "recovered bits"):
            validate_changes(name, previous, candidate, self.names)

    def test_bonus_boolean_cannot_replace_float_rule(self):
        name = "recovered-pvp-bonus-catalog.json"
        previous = json.loads((ROOT / "Server/content" / name).read_bytes())
        candidate = json.loads(self.candidates[name])
        candidate["rules"]["lowAmmoThreshold"] = False
        with self.assertRaisesRegex(ValueError, "wrong JSON type"):
            validate_changes(name, previous, candidate, self.names)

    def test_army_movement_bits_and_wire_line_endings_are_preserved(self):
        name = "recovered-army-deployment.json"
        payload = self.candidates[name]
        self.assertIn(b"\r\n", payload)
        self.assertNotIn(b"\n", payload.replace(b"\r\n", b""))
        previous = json.loads((ROOT / "Server/content" / name).read_bytes())
        candidate = json.loads(payload)
        self.assertEqual(len(candidate["families"]), 24)
        for old, new in zip(previous["families"], candidate["families"]):
            self.assertEqual(old["options"], new["options"])
        candidate["families"][0]["movementSpeed"] += 0.01
        with self.assertRaisesRegex(ValueError, "recovered bits"):
            validate_changes(name, previous, candidate, self.names)

    def test_perks_bind_exact_candidate_dependencies_and_preserve_all_rules(self):
        name = "recovered-army-perks.json"
        previous = json.loads((ROOT / "Server/content" / name).read_bytes())
        candidate = json.loads(self.candidates[name])
        self.assertEqual(candidate["families"], previous["families"])
        self.assertEqual(len(candidate["families"]), 24)
        sources = {row["path"]: row["sha256"] for row in candidate["sources"]}
        self.assertEqual(sources["Server/content/recovered-battle-content.json"],
                         hashlib.sha256(self.content).hexdigest())
        self.assertEqual(sources["Server/content/recovered-army-deployment.json"],
                         hashlib.sha256(self.candidates["recovered-army-deployment.json"]).hexdigest())
        candidate["families"][0]["faction"] = "invented"
        with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
            validate_changes(name, previous, candidate, self.names)

    def test_perks_reject_mixed_scene_snapshots_before_building(self):
        with self.assertRaisesRegex(ValueError, "snapshots disagree"):
            perks.build_document(SCENE.read_bytes(), self.content,
                                 (ROOT / "Server/content/recovered-army-deployment.json").read_bytes())

    def test_perk_source_collection_does_not_leak_between_builds(self):
        scene = SCENE.read_bytes()
        deployment = self.candidates["recovered-army-deployment.json"]
        first = perks.build_document(scene, self.content, deployment)
        second = perks.build_document(scene, self.content + b"\n", deployment)
        self.assertEqual(first["families"], second["families"])
        self.assertNotEqual(first["sources"], second["sources"])
        self.assertEqual(first, perks.build_document(scene, self.content, deployment))

    def test_unknown_perk_arguments_fail_before_writing(self):
        before = perks.OUTPUT.read_bytes()
        result = subprocess.run([sys.executable, str(ROOT / "Server/tools/extract_army_perks.py"),
                                 "--unknown"], capture_output=True, timeout=30)
        self.assertEqual(result.returncode, 2)
        self.assertEqual(perks.OUTPUT.read_bytes(), before)

    def test_coop_card_indexes_preserve_source_fallback_and_exact_dependencies(self):
        name = "recovered-coop-card-rows.json"
        previous = json.loads(coop_cards.OUTPUT.read_bytes())
        candidate = json.loads(self.candidates[name])
        self.assertEqual(candidate["rows"], previous["rows"])
        self.assertEqual(len(candidate["rows"]), 8)
        sniper = next(row for row in candidate["rows"] if row["unitId"] == "ID_UNIT-SNIPER")
        self.assertEqual((sniper["minimumIndex"], sniper["maximumIndex"], sniper["hasCardRows"]), (0, 0, False))
        self.assertEqual(candidate["contentSha256"], hashlib.sha256(self.content).hexdigest())
        self.assertEqual(candidate["armySha256"],
                         hashlib.sha256(self.candidates["recovered-army-deployment.json"]).hexdigest())
        candidate["rows"][0]["minimumIndex"] += 1
        with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
            validate_changes(name, previous, candidate, self.names)

    def test_coop_cards_reject_duplicate_family_instead_of_counting_it_as_coverage(self):
        army = json.loads(self.candidates["recovered-army-deployment.json"])
        eligible = [row for row in army["families"] if row["behaviorType"] in coop_cards.CARD_BEHAVIOURS]
        army["families"] = [eligible[0]] + eligible[:-1]
        with self.assertRaisesRegex(ValueError, "identity is duplicated"):
            coop_cards.build_document(SCENE.read_bytes(), self.content, json.dumps(army).encode())

    def test_coop_cards_reject_nonfinite_or_boolean_combat_values(self):
        for value in (float("nan"), float("inf"), True):
            with self.subTest(value=value):
                content = json.loads(self.content)
                sheet = next(row for row in content["sheets"] if row["type"] == "Google2u.DBUpgradeSlotsSniper")
                sheet["rows"][0]["HP"] = value
                with self.assertRaisesRegex(ValueError, "not finite numeric data"):
                    coop_cards.build_document(SCENE.read_bytes(), json.dumps(content).encode(),
                                              self.candidates["recovered-army-deployment.json"])

    def test_coop_cards_reject_mixed_scene_and_unknown_cli_without_writing(self):
        before = coop_cards.OUTPUT.read_bytes()
        with self.assertRaisesRegex(ValueError, "do not bind"):
            coop_cards.build_document(SCENE.read_bytes(), self.content, coop_cards.ARMY.read_bytes())
        result = subprocess.run([sys.executable, str(ROOT / "Server/tools/extract_coop_card_rows.py"),
                                 "--unknown"], capture_output=True, timeout=30)
        self.assertEqual(result.returncode, 2)
        self.assertEqual(coop_cards.OUTPUT.read_bytes(), before)

    def test_both_skillshot_catalogs_preserve_all_mode_specific_scores(self):
        for mode in ("coop", "pvp"):
            name = f"recovered-{mode}-skillshot-scores.json"
            with self.subTest(mode=mode):
                previous = json.loads((ROOT / "Server/content" / name).read_bytes())
                candidate = json.loads(self.candidates[name])
                self.assertEqual(candidate["rows"], previous["rows"])
                self.assertEqual(len(candidate["rows"]), 19)
                self.assertEqual(candidate["comboWindowSeconds"], 0.9)
                self.assertEqual(candidate["battleContentSha256"], hashlib.sha256(self.content).hexdigest())
                candidate["rows"][0]["flag"] = 0
                with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
                    validate_changes(name, previous, candidate, self.names)

    def test_skillshot_scores_reject_boolean_fraction_and_negative_points(self):
        for producer, column in ((coop_scores, "SCORESINGLE"), (pvp_scores, "SCOREMP")):
            for value in (True, 0.5, -1, 1_000_001):
                with self.subTest(column=column, value=value):
                    content = json.loads(self.content)
                    sheet = coop_scores.skill_sheet(content)
                    for row in sheet["rows"]:
                        row[column] = value
                    with self.assertRaisesRegex(ValueError, "Invalid .*score"):
                        producer.build_document(SCENE.read_bytes(), json.dumps(content).encode())

    def test_skillshot_scores_reject_duplicate_sheet_and_mixed_scene(self):
        for producer in (coop_scores, pvp_scores):
            with self.subTest(producer=producer.__name__):
                content = json.loads(self.content)
                content["sheets"].append(coop_scores.skill_sheet(content))
                with self.assertRaisesRegex(ValueError, "exactly one"):
                    producer.build_document(SCENE.read_bytes(), json.dumps(content).encode())
                with self.assertRaisesRegex(ValueError, "different"):
                    producer.build_document(SCENE.read_bytes(), CONTENT.read_bytes())

    def test_skillshot_unknown_arguments_fail_without_writing(self):
        for mode in ("coop", "pvp"):
            path = ROOT / f"Server/content/recovered-{mode}-skillshot-scores.json"
            before = path.read_bytes()
            result = subprocess.run([sys.executable, str(ROOT / f"Server/tools/extract_{mode}_skillshot_scores.py"),
                                     "--unknown"], capture_output=True, timeout=30)
            self.assertEqual(result.returncode, 2)
            self.assertEqual(path.read_bytes(), before)

    def test_card_identity_candidate_preserves_enabled_and_disabled_rows(self):
        name = "recovered-ordinary-card-identities.json"
        previous = json.loads((ROOT / "Server/content" / name).read_bytes())
        candidate = json.loads(self.candidates[name])
        self.assertEqual(candidate["cards"], previous["cards"])
        self.assertEqual(len(candidate["cards"]), 67)
        self.assertEqual(sum(row["implemented"] for row in candidate["cards"]), 57)
        self.assertEqual(candidate["sourceSha256"], hashlib.sha256(self.content).hexdigest())
        candidate["cards"][0]["id"] = "invented"
        with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
            validate_changes(name, previous, candidate, self.names)

    def test_card_identity_rarity_cannot_use_boolean_or_float_equivalence(self):
        for value in (True, 1.0, "1"):
            with self.subTest(value=value):
                content = json.loads(self.content)
                sheet = next(row for row in content["sheets"] if row["type"] == "Google2u.CardDefinitions")
                sheet["rows"][0]["RARITY"] = value
                with self.assertRaisesRegex(ValueError, "source types"):
                    card_identities.build_document(json.dumps(content).encode())

    def test_card_identity_cli_check_and_unknown_argument_preserve_production(self):
        path = ROOT / "Server/content/recovered-ordinary-card-identities.json"
        before = path.read_bytes()
        tool = str(ROOT / "Server/tools/build_ordinary_card_identities.py")
        for argument, expected_code in (("--check", 0), ("--unknown", 2)):
            result = subprocess.run([sys.executable, tool, argument], capture_output=True, timeout=30)
            self.assertEqual(result.returncode, expected_code, result.stderr.decode())
            self.assertEqual(path.read_bytes(), before)

    def test_soldier_point_masks_preserve_all_types_and_sniper_distance(self):
        name = "recovered-coop-enemy-point-masks.json"
        previous = json.loads(point_masks.OUTPUT.read_bytes())
        candidate = json.loads(self.candidates[name])
        self.assertEqual(candidate["soldiers"], previous["soldiers"])
        self.assertEqual(len(candidate["soldiers"]), 16)
        sniper = next(row for row in candidate["soldiers"] if row["behaviorType"] == "SoldierBehaviourSniper")
        self.assertEqual(sniper["minimumPlayerDistance"], 6.0)
        candidate["soldiers"][0]["enemyPointMask"] = 0
        with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
            validate_changes(name, previous, candidate, self.names)

    def test_soldier_point_masks_reject_duplicate_identity_and_coerced_classification(self):
        army = json.loads(self.candidates["recovered-army-deployment.json"])
        soldiers = [row for row in army["families"] if row["isSoldier"]]
        army["families"] = [soldiers[0]] + soldiers[:-1]
        with self.assertRaisesRegex(ValueError, "Duplicate soldier"):
            point_masks.build_document(SCENE.read_bytes(), json.dumps(army).encode())
        soldiers[0]["isSoldier"] = 1
        with self.assertRaisesRegex(ValueError, "must be Boolean"):
            point_masks.build_document(SCENE.read_bytes(), json.dumps(army).encode())

    def test_soldier_point_masks_reject_mixed_source_and_unknown_arguments(self):
        before = point_masks.OUTPUT.read_bytes()
        with self.assertRaisesRegex(ValueError, "differs from the deployment"):
            point_masks.build_document(SCENE.read_bytes(), point_masks.ARMY.read_bytes())
        result = subprocess.run([sys.executable, str(ROOT / "Server/tools/extract_coop_enemy_point_masks.py"),
                                 "--unknown"], capture_output=True, timeout=30)
        self.assertEqual(result.returncode, 2)
        self.assertEqual(point_masks.OUTPUT.read_bytes(), before)

    def test_air_geometry_preserves_all_prefab_values_and_pinned_line_endings(self):
        name = "recovered-air-unit-geometry.json"
        payload = self.candidates[name]
        candidate = json.loads(payload)
        previous = json.loads(air_geometry.OUTPUT.read_bytes())
        self.assertEqual(candidate["units"], previous["units"])
        self.assertEqual(candidate["meshSources"], previous["meshSources"])
        self.assertEqual(len(candidate["units"]), 3)
        self.assertEqual(candidate["deploymentSource"]["sha256"],
                         hashlib.sha256(self.candidates["recovered-army-deployment.json"]).hexdigest())
        self.assertIn(b"\r\n", payload)
        self.assertNotIn(b"\n", payload.replace(b"\r\n", b""))
        candidate["units"][0]["colliders"][0]["enabled"] = "changed"
        with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
            validate_changes(name, previous, candidate, self.names)

    def test_air_geometry_rejects_duplicate_air_coverage(self):
        army = json.loads(self.candidates["recovered-army-deployment.json"])
        air = next(row for row in army["families"] if row["isAir"])
        army["families"].append(air)
        with self.assertRaisesRegex(ValueError, "family inventory"):
            air_geometry.build_document(json.dumps(army).encode())

    def test_air_geometry_unknown_argument_fails_before_writing(self):
        before = air_geometry.OUTPUT.read_bytes()
        result = subprocess.run([sys.executable, str(ROOT / "Server/tools/extract_air_unit_geometry.py"),
                                 "--unknown"], capture_output=True, timeout=30)
        self.assertNotEqual(result.returncode, 0)
        self.assertIn(b"usage:", result.stderr)
        self.assertEqual(air_geometry.OUTPUT.read_bytes(), before)

    def test_rusher_bindings_preserve_all_combat_values(self):
        name = "recovered-rusher-weapon-bindings.json"
        previous = json.loads(rusher_weapons.OUT.read_bytes())
        candidate = json.loads(self.candidates[name])
        self.assertEqual(len(candidate["families"]), 8)
        self.assertEqual(candidate["warperRelocation"], previous["warperRelocation"])
        for old, new in zip(previous["families"], candidate["families"]):
            self.assertEqual(old["inventory"], new["inventory"])
            self.assertEqual(old["attackWindup"], new["attackWindup"])
            self.assertEqual(old["attackCadence"]["seconds"], new["attackCadence"]["seconds"])
        candidate["families"][0]["attackCadence"]["seconds"] += 0.01
        with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
            validate_changes(name, previous, candidate, self.names)

    def test_rusher_binding_unreviewed_source_change_is_rejected(self):
        name = "recovered-rusher-weapon-bindings.json"
        previous = json.loads(rusher_weapons.OUT.read_bytes())
        candidate = json.loads(self.candidates[name])
        candidate["families"][0]["attackCadence"]["sha256"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "Unreviewed base soldier"):
            validate_changes(name, previous, candidate, self.names)

    def test_rusher_binding_mixed_sources_and_unknown_arguments_cannot_write(self):
        before = rusher_weapons.OUT.read_bytes()
        with self.assertRaisesRegex(ValueError, "different scenes"):
            rusher_weapons.build_document(SCENE.read_bytes(), self.content, rusher_weapons.DEPLOY.read_bytes())
        result = subprocess.run([sys.executable, str(ROOT / "Server/tools/extract_rusher_weapon_bindings.py"),
                                 "--unknown"], capture_output=True, timeout=30)
        self.assertEqual(result.returncode, 2)
        self.assertEqual(rusher_weapons.OUT.read_bytes(), before)

    def test_assaulter_weapon_preserves_flight_and_attack_configuration(self):
        name = "recovered-coop-assaulter-weapon.json"
        previous = json.loads(assaulter_weapon.OUTPUT.read_bytes())
        candidate = json.loads(self.candidates[name])
        for field in ("muzzle", "shotOffset", "realBulletSpeed", "fakeBulletSpeed", "collisionCheckDistance",
                      "criticalProbability", "criticalAmount", "cadenceSeconds", "weaponPrefabSha256"):
            self.assertEqual(candidate[field], previous[field], field)
        candidate["cadenceSeconds"] += 0.01
        with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
            validate_changes(name, previous, candidate, self.names)

    def test_assaulter_weapon_refuses_unreviewed_source_and_changed_inventory(self):
        name = "recovered-coop-assaulter-weapon.json"
        previous = json.loads(assaulter_weapon.OUTPUT.read_bytes())
        candidate = json.loads(self.candidates[name])
        candidate["soldierSourceSha256"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "Unreviewed Assaulter"):
            validate_changes(name, previous, candidate, self.names)
        scene = SCENE.read_bytes().replace(b"unitDictionaryId: ID_UNIT-ASSAULT\n",
                                          b"unitDictionaryId: ID_UNIT-INVALID\n")
        with self.assertRaisesRegex(ValueError, "source owner"):
            assaulter_weapon.build_document(scene)

    def test_assaulter_unknown_arguments_fail_without_writing(self):
        before = assaulter_weapon.OUTPUT.read_bytes()
        result = subprocess.run([sys.executable, str(ROOT / "Server/tools/extract_coop_assaulter_weapon.py"),
                                 "--unknown"], capture_output=True, timeout=30)
        self.assertEqual(result.returncode, 2)
        self.assertEqual(assaulter_weapon.OUTPUT.read_bytes(), before)

    def test_deployables_preserve_maps_prefabs_and_recovered_stat_bits(self):
        for name in ("recovered-landmine-source.json", "recovered-heavy-turret-source.json"):
            with self.subTest(name=name):
                previous = json.loads((ROOT / "Server/content" / name).read_bytes())
                candidate = json.loads(self.candidates[name])
                self.assertEqual(candidate["maps"], previous["maps"])
                self.assertEqual(candidate["prefab"], previous["prefab"])
                self.assertEqual(len(candidate["maps"]), 5)
                if name == "recovered-landmine-source.json":
                    self.assertEqual(candidate["damage"], previous["damage"])
                    candidate["damage"]["maximum"] += 1
                    expected = "gameplay/schema change"
                else:
                    candidate["stats"][1]["HP"] += 1
                    expected = "recovered bits"
                with self.assertRaisesRegex(ValueError, expected):
                    validate_changes(name, previous, candidate, self.names)

    def test_landmine_rejects_ambiguous_damage_constants(self):
        content = json.loads(self.content)
        sheet = next(row for row in content["sheets"]
                     if any(item.get("DBKEY") == "LandMineDamageMin" for item in row["rows"]))
        duplicate = next(row for row in sheet["rows"] if row.get("DBKEY") == "LandMineDamageMin")
        sheet["rows"].append(duplicate)
        with self.assertRaisesRegex(ValueError, "Duplicate Land Mine"):
            landmine.build_document(SCENE.read_bytes(), json.dumps(content).encode())

    def test_deployable_unknown_arguments_and_stale_scene_cannot_write(self):
        for producer in (landmine, heavy_turret):
            with self.subTest(producer=producer.__name__):
                before = producer.OUTPUT.read_bytes()
                with self.assertRaisesRegex(ValueError, "MainScene"):
                    producer.build_document(SCENE.read_bytes(), CONTENT.read_bytes())
                result = subprocess.run([sys.executable, str(ROOT / f"Server/tools/{producer.__name__}.py"),
                                         "--unknown"], capture_output=True, timeout=30)
                self.assertEqual(result.returncode, 2)
                self.assertEqual(producer.OUTPUT.read_bytes(), before)

    def test_mortar_pool_preserves_capacity_allocation_and_return_rules(self):
        name = "recovered-mortar-weapon-pool.json"
        previous = json.loads(mortar_pool.OUTPUT.read_bytes())
        candidate = json.loads(self.candidates[name])
        self.assertEqual(candidate["capacity"], 4)
        self.assertEqual(candidate["deployment"]["maxPerOwner"], 2)
        for field in ("sources", "reviewedAllocation", "reviewedReturn"):
            self.assertEqual(candidate[field], previous[field])
        self.assertEqual(candidate["deployment"]["revision"],
                         hashlib.sha256(self.candidates["recovered-army-deployment.json"]).hexdigest())
        candidate["reviewedReturn"]["deathReturnsWeapon"] = True
        with self.assertRaisesRegex(ValueError, "gameplay/schema change"):
            validate_changes(name, previous, candidate, self.names)

    def test_mortar_pool_rejects_noninteger_or_unconserved_capacity(self):
        for value in (2.0, True, 3):
            with self.subTest(value=value):
                army = json.loads(self.candidates["recovered-army-deployment.json"])
                mortar = next(row for row in army["families"] if row["unitId"] == "ID_UNIT-MORTAR")
                mortar["maxGeneratedCount"] = value
                with self.assertRaisesRegex(ValueError, "conserve"):
                    mortar_pool.build_document(SCENE.read_bytes(), json.dumps(army).encode())

    def test_mortar_pool_mixed_scene_and_unknown_arguments_preserve_production(self):
        before = mortar_pool.OUTPUT.read_bytes()
        with self.assertRaisesRegex(ValueError, "different scenes"):
            mortar_pool.build_document(SCENE.read_bytes(), rusher_weapons.DEPLOY.read_bytes())
        result = subprocess.run([sys.executable, str(ROOT / "Server/tools/extract_mortar_weapon_pool.py"),
                                 "--unknown"], capture_output=True, timeout=30)
        self.assertEqual(result.returncode, 2)
        self.assertEqual(mortar_pool.OUTPUT.read_bytes(), before)


if __name__ == "__main__":
    unittest.main()
