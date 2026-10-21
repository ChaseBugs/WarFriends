"""Reuse reviewed native navigation observations only when all observed inputs remain identical."""
import copy
import argparse
import hashlib
import json
from pathlib import Path

import extract_coop_navmesh_sources as navigation
import package_coop_navmesh_triangulation as triangulation

CONTENT = Path(__file__).resolve().parents[1] / "content"
NAVIGATION = "recovered-coop-navmesh-sources.json"
REVIEWED = {
    NAVIGATION: "8a3e7b87defcdd70d5ba5b89b2c2b26cb25e052698db9016033fdc0a4703977f",
    "recovered-coop-navmesh-paths.json": "7753a0add536af88018794a9118560d22940a9cad2989b6cc3876e731ee542b1",
    "recovered-coop-navmesh-triangulation.json": "87b0d457300a7e88bd7166d1a12e021f7ef73e1ba57b1e97831df4788fb314de",
    "recovered-coop-spawn-points.json": "aeed31ebccefbfb9b12d83c071f4face92c6cec241000b18929e7222f09d4402"}


def digest(payload):
    return hashlib.sha256(payload).hexdigest()


def reviewed(name):
    payload = (CONTENT / name).read_bytes()
    if digest(payload) != REVIEWED[name]:
        raise ValueError("Reviewed navigation observation changed: " + name)
    return json.loads(payload)


def build_candidates(navigation_bytes):
    previous = reviewed(NAVIGATION)
    current = json.loads(navigation_bytes)
    comparable = copy.deepcopy(current)
    comparable["missionSourceSha256"] = previous["missionSourceSha256"]
    if json.dumps(comparable, sort_keys=True) != json.dumps(previous, sort_keys=True):
        raise ValueError("Navigation inputs changed; native recapture required")
    navigation.verify_packaged_assets(current)
    paths = reviewed("recovered-coop-navmesh-paths.json")
    meshes = reviewed("recovered-coop-navmesh-triangulation.json")
    reviewed("recovered-coop-spawn-points.json")
    if paths["spawnSourceSha256"] != REVIEWED["recovered-coop-spawn-points.json"]:
        raise ValueError("Navigation routes use different spawn evidence")
    for document in (paths, meshes):
        if document["navigationSourceSha256"] != REVIEWED[NAVIGATION]:
            raise ValueError("Native navigation dependency changed")
    verify_meshes(meshes, current)
    paths["navigationSourceSha256"] = digest(navigation_bytes)
    meshes["navigationSourceSha256"] = digest(navigation_bytes)
    return {"recovered-coop-navmesh-paths.json": paths,
            "recovered-coop-navmesh-triangulation.json": meshes}


def verify_meshes(manifest, navigation_source):
    if len(manifest["maps"]) != len(navigation_source["maps"]):
        raise ValueError("Native navigation mesh set is incomplete")
    for mesh, source in zip(manifest["maps"], navigation_source["maps"]):
        payload = (CONTENT / "coop-navmesh-triangulation" / mesh["file"]).read_bytes()
        if (digest(payload) != mesh["sha256"] or mesh["navMeshSha256"] != source["sha256"]
                or mesh["sceneSha256"] != source["sceneSha256"] or mesh["stage"] != source["stage"]):
            raise ValueError("Native mesh no longer matches its reviewed inputs")
        counts = triangulation.validate(payload, source["sourceAsset"])
        if counts != (mesh["vertices"], mesh["triangles"]):
            raise ValueError("Native navigation mesh counts differ")


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--navigation", type=Path, required=True, help="Candidate navigation source manifest")
    arguments = parser.parse_args()
    print(json.dumps(build_candidates(arguments.navigation.read_bytes()), indent=2, allow_nan=False))
