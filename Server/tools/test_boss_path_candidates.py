"""Exercise packaging with synthetic routes; native capture remains separate runtime evidence."""
import hashlib
import json
import unittest

import package_coop_boss_paths as package


def encode(value):
    return json.dumps(value, allow_nan=False).encode()


def fixture():
    anchors = {"maps": []}
    navigation = {"maps": []}
    native = {"version": 1, "maps": []}
    for stage in range(5):
        scene = "Test" + str(stage)
        points = [{"worldPosition": [index, 0, stage]} for index in range(8)]
        anchors["maps"].append({"stage": stage, "scene": scene, "sceneSha256": "a" * 64,
                                "playerPositions": points})
        navigation["maps"].append({"scene": scene + ".unity", "sceneSha256": "a" * 64,
                                   "navMeshAsset": scene + ".asset", "navMeshSha256": "b" * 64})
        routes = []
        for start in range(8):
            for end in range(8):
                if start == end or (start < 4) != (end < 4):
                    continue
                first = dict(zip("xyz", points[start]["worldPosition"]))
                last = dict(zip("xyz", points[end]["worldPosition"]))
                routes.append({"from": start, "to": end, "startSampled": True, "endSampled": True,
                               "sampledStart": first, "sampledEnd": last, "status": "PathComplete",
                               "corners": [first, last]})
        native["maps"].append({"scene": scene, "asset": scene + ".asset", "routes": routes})
    return anchors, navigation, native


class BossPathCandidateTests(unittest.TestCase):
    def test_exact_dependency_hashes_and_all_routes(self):
        anchors, navigation, native = fixture()
        anchor_bytes = encode(anchors)
        navigation_bytes = encode(navigation)
        result = package.build_document(anchor_bytes, navigation_bytes, encode(native))
        self.assertEqual(result["anchorSourceSha256"], hashlib.sha256(anchor_bytes).hexdigest())
        self.assertEqual(result["navigationSourceSha256"], hashlib.sha256(navigation_bytes).hexdigest())
        self.assertEqual(sum(len(row["routes"]) for row in result["maps"]), 120)

    def test_boolean_cannot_be_a_native_coordinate(self):
        with self.assertRaisesRegex(ValueError, "vector is invalid"):
            package.vector({"x": True, "y": 0, "z": 0})

    def test_missing_route_is_rejected(self):
        anchors, navigation, native = fixture()
        native["maps"][0]["routes"].pop()
        with self.assertRaisesRegex(ValueError, "differs from source anchors"):
            package.build_document(encode(anchors), encode(navigation), encode(native))

    def test_incomplete_native_path_is_rejected(self):
        anchors, navigation, native = fixture()
        native["maps"][0]["routes"][0]["status"] = "PathPartial"
        with self.assertRaisesRegex(ValueError, "missing or incomplete"):
            package.build_document(encode(anchors), encode(navigation), encode(native))

    def test_native_endpoints_must_match_current_anchors(self):
        anchors, navigation, native = fixture()
        anchors["maps"][0]["playerPositions"][0]["worldPosition"][0] += 1
        with self.assertRaisesRegex(ValueError, "endpoints differ"):
            package.build_document(encode(anchors), encode(navigation), encode(native))


if __name__ == "__main__":
    unittest.main()
