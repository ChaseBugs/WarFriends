#!/usr/bin/env python3
"""Own small, bounded test runs without pruning unmarked historical evidence."""

from __future__ import annotations

import argparse
import ctypes
import json
import os
import re
import shutil
import stat
import time
import uuid
from pathlib import Path

from process_identity import process_start_identity, valid_identity


DEFAULT_ROOT = Path(os.environ.get("WAR_TEST_RUN_ROOT") or
                    Path(__file__).resolve().parents[1] / ".local" / "test-runs")
MARKER = "test-run.json"
LEGACY_SCHEMA = "warfriends-test-run-v1"
SCHEMA = "warfriends-test-run-v2"
RUN_NAME = re.compile(r"[a-z][a-z0-9-]{0,47}-[0-9a-f]{32}\Z")


def is_link(path: Path) -> bool:
    if path.is_symlink():
        return True
    if os.name != "nt":
        return False
    try:
        # Reject all Windows reparse points, including junctions, without requiring Python 3.12.
        return bool(path.lstat().st_file_attributes & 0x400)
    except FileNotFoundError:
        return False


def checked_root(root: Path) -> Path:
    root = root.absolute()
    if root == Path(root.anchor):
        raise ValueError("A filesystem root cannot be a test artifact root.")
    for path in (root, *root.parents):
        if is_link(path):
            raise ValueError(f"Linked artifact path is not allowed: {path}")
    return root.resolve()


def checked_run(root: Path, run: Path) -> Path:
    root = checked_root(root)
    run = run.absolute()
    if run.parent != root or not RUN_NAME.fullmatch(run.name) or is_link(run):
        raise ValueError("Run must be a direct, unlinked managed child of the artifact root.")
    return run


def tree_bytes(path: Path) -> int:
    if is_link(path):
        return 0
    if path.is_file():
        return path.stat().st_size
    total = 0
    for directory, folders, files in os.walk(path):
        folders[:] = [name for name in folders if not is_link(Path(directory, name))]
        for name in files:
            child = Path(directory, name)
            if not is_link(child):
                total += child.stat().st_size
    return total


def has_links(path: Path) -> bool:
    for directory, folders, files in os.walk(path):
        if any(is_link(Path(directory, name)) for name in folders + files):
            return True
    return False


def remove_owned_tree(path: Path) -> None:
    """Remove an already ownership-checked tree, including read-only Unity package files."""
    boundary = path.resolve()
    if is_link(path) or has_links(path):
        raise ValueError("Linked owned data cannot be removed.")

    def retry_readonly(function, filename, error):
        target = Path(filename)
        if (not isinstance(error, PermissionError) or function not in (os.unlink, os.remove)
                or is_link(target) or not target.is_file()
                or not target.resolve().is_relative_to(boundary)):
            raise error
        attributes = target.stat()
        readonly = (getattr(attributes, "st_file_attributes", 0) & stat.FILE_ATTRIBUTE_READONLY) != 0
        if not readonly:
            raise error
        target.chmod(attributes.st_mode | stat.S_IWRITE)
        function(filename)

    shutil.rmtree(path, onerror=lambda function, filename, info: retry_readonly(function, filename, info[1]))


def process_is_alive(pid: int) -> bool:
    if os.name == "nt":
        # os.kill(pid, 0) is not the portable process probe on Windows.
        kernel = ctypes.WinDLL("kernel32", use_last_error=True)
        kernel.OpenProcess.restype = ctypes.c_void_p
        kernel.OpenProcess.argtypes = [ctypes.c_ulong, ctypes.c_int, ctypes.c_ulong]
        kernel.GetExitCodeProcess.argtypes = [ctypes.c_void_p, ctypes.POINTER(ctypes.c_ulong)]
        kernel.CloseHandle.argtypes = [ctypes.c_void_p]
        handle = kernel.OpenProcess(0x1000, False, pid)
        if not handle:
            return ctypes.get_last_error() != 87  # Access denied is conservatively live.
        try:
            code = ctypes.c_ulong()
            return not kernel.GetExitCodeProcess(handle, ctypes.byref(code)) or code.value == 259
        finally:
            kernel.CloseHandle(handle)
    try:
        os.kill(pid, 0)
        return True
    except ProcessLookupError:
        return False
    except PermissionError:
        return True


def read_manifest(run: Path) -> dict:
    marker = run / MARKER
    if is_link(marker) or marker.stat().st_size > 4096:
        raise ValueError("Invalid test ownership marker.")
    manifest = json.loads(marker.read_text(encoding="utf-8"))
    expected = {"schema", "id", "suite", "ownerPid", "started", "finished", "status", "keep"}
    if isinstance(manifest, dict) and manifest.get("schema") == SCHEMA:
        expected.add("ownerStarted")
    if not isinstance(manifest, dict) or set(manifest) != expected:
        raise ValueError("Invalid test ownership shape.")
    if (manifest["schema"] not in (LEGACY_SCHEMA, SCHEMA) or manifest["id"] != run.name
            or not isinstance(manifest["suite"], str)
            or not run.name.startswith(manifest["suite"] + "-")
            or type(manifest["ownerPid"]) is not int or not 0 < manifest["ownerPid"] <= 0xFFFFFFFF
            or type(manifest["started"]) is not int or manifest["started"] < 0
            or type(manifest["keep"]) is not bool
            or manifest["status"] not in ("running", "passed", "failed")):
        raise ValueError("Invalid test ownership authority.")
    if manifest["schema"] == SCHEMA and not valid_identity(manifest["ownerStarted"]):
        raise ValueError("Invalid process creation identity.")
    finished = manifest["finished"]
    if manifest["status"] == "running":
        if finished is not None:
            raise ValueError("Running tests cannot have a completion timestamp.")
    elif type(finished) is not int or finished < manifest["started"]:
        raise ValueError("Invalid completion timestamp.")
    return manifest


def owner_is_active(manifest: dict) -> bool:
    if not process_is_alive(manifest["ownerPid"]):
        return False
    if manifest["schema"] == LEGACY_SCHEMA:
        return True  # Historical PID-only records never acquire invented creation evidence.
    current_identity = process_start_identity(manifest["ownerPid"])
    # Inaccessible creation metadata cannot authorize deletion.
    return current_identity is None or current_identity == manifest["ownerStarted"]


def write_manifest(run: Path, manifest: dict) -> None:
    temporary = run / (MARKER + ".tmp")
    if is_link(temporary) or is_link(run / MARKER):
        raise ValueError("Linked ownership marker is not allowed.")
    temporary.write_text(json.dumps(manifest, indent=2) + "\n", encoding="utf-8")
    temporary.replace(run / MARKER)


def start_run(root: Path, suite: str, owner_pid: int) -> Path:
    root = checked_root(root)
    if not re.fullmatch(r"[a-z][a-z0-9-]{0,47}", suite) or owner_pid <= 0:
        raise ValueError("Invalid suite or owning process.")
    identity = process_start_identity(owner_pid)
    if identity is None:
        raise ValueError("Cannot bind a live owning process creation identity.")
    root.mkdir(parents=True, exist_ok=True)
    run = root / f"{suite}-{uuid.uuid4().hex}"
    run.mkdir()
    (run / "data").mkdir()
    write_manifest(run, {"schema": SCHEMA, "id": run.name, "suite": suite,
                        "ownerPid": owner_pid, "ownerStarted": identity, "started": int(time.time()),
                        "finished": None, "status": "running", "keep": False})
    return run


def prepare_test_environment(root: Path, run: Path, owner_pid: int | None = None) -> dict[str, str]:
    """Confine test/owned-service temporary files after verifying the owning process identity."""
    run = checked_run(root, run)
    manifest = read_manifest(run)
    owner_pid = os.getpid() if owner_pid is None else owner_pid
    if (manifest["status"] != "running" or manifest["ownerPid"] != owner_pid
            or manifest["schema"] != SCHEMA
            or process_start_identity(owner_pid) != manifest["ownerStarted"] or has_links(run)):
        raise ValueError("Temporary test storage requires this process's live owned run.")
    temporary = run / "data" / "temp"
    temporary.mkdir(parents=True, exist_ok=True)
    environment = os.environ.copy()
    for name in ("TEMP", "TMP", "TMPDIR"):
        environment[name] = str(temporary)
    return environment


def finish_run(root: Path, run: Path, status: str, keep: bool, owner_pid: int | None = None) -> dict:
    run = checked_run(root, run)
    manifest = read_manifest(run)
    if manifest["ownerPid"] != (os.getpid() if owner_pid is None else owner_pid):
        raise ValueError("Only the recorded owning process may complete a run.")
    if (manifest["schema"] == SCHEMA
            and process_start_identity(manifest["ownerPid"]) != manifest["ownerStarted"]):
        raise ValueError("The owning process creation identity changed or cannot be verified.")
    if status not in ("passed", "failed") or manifest["status"] != "running":
        raise ValueError("Only a running test can be completed once.")
    if has_links(run):
        raise ValueError("Linked test artifacts require manual inspection.")
    # The caller stops and waits for its owned children before this operation.
    # Mongo files are disposable on success; failed runs retain them for diagnosis.
    data = run / "data"
    reclaimed = tree_bytes(data) if status == "passed" and not keep else 0
    if status == "passed" and not keep and data.exists():
        remove_owned_tree(data)
    manifest.update(status=status, finished=max(int(time.time()), manifest["started"]), keep=keep)
    write_manifest(run, manifest)
    return {"run": str(run), "status": status, "reclaimedBytes": reclaimed}


def prune_runs(root: Path, *, apply: bool = False, max_bytes: int = 512 * 1024**2,
               max_age_days: int = 14, passed: int = 5, failed: int = 3) -> dict:
    root = checked_root(root)
    if min(max_bytes, max_age_days, passed, failed) < 0:
        raise ValueError("Retention limits must be nonnegative.")
    candidates = []
    skipped = []
    for run in sorted(root.iterdir()) if root.exists() else []:
        try:
            checked_run(root, run)
            manifest = read_manifest(run)
            if (manifest["status"] == "running" or manifest["keep"]
                    or (run / ".keep").exists() or owner_is_active(manifest)
                    or has_links(run)):
                raise ValueError("Active, pinned, or linked run.")
            candidates.append((run, manifest, tree_bytes(run)))
        except (ValueError, OSError, json.JSONDecodeError):
            skipped.append(run.name)
    candidates.sort(key=lambda row: (row[1]["finished"], row[0].name), reverse=True)
    counts = {"passed": 0, "failed": 0}
    retained = 0
    removed = []
    now = int(time.time())
    for run, manifest, size in candidates:
        status = manifest["status"]
        counts[status] += 1
        limit = passed if status == "passed" else failed
        expired = now - manifest["finished"] > max_age_days * 86400
        remove = expired or counts[status] > limit or retained + size > max_bytes
        if not remove:
            retained += size
            continue
        if apply:
            # Revalidate immediately before deletion; never follow a linked subtree.
            checked_run(root, run)
            current = read_manifest(run)
            if (current != manifest or owner_is_active(current)
                    or (run / ".keep").exists() or has_links(run)):
                raise ValueError("Artifact ownership changed during pruning.")
            remove_owned_tree(run)
        removed.append({"run": run.name, "bytes": size})
    return {"apply": apply, "removed": removed, "skipped": skipped,
            "reclaimedBytes": sum(row["bytes"] for row in removed), "retainedBytes": retained}


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--root", type=Path, default=DEFAULT_ROOT)
    commands = parser.add_subparsers(dest="command", required=True)
    start = commands.add_parser("start")
    start.add_argument("suite")
    start.add_argument("--owner-pid", type=int, required=True)
    temporary = commands.add_parser("temp-root")
    temporary.add_argument("run", type=Path)
    finish = commands.add_parser("finish")
    finish.add_argument("run", type=Path)
    finish.add_argument("--status", choices=("passed", "failed"), required=True)
    finish.add_argument("--keep", action="store_true")
    prune = commands.add_parser("prune")
    prune.add_argument("--apply", action="store_true")
    prune.add_argument("--max-mib", type=int, default=512)
    prune.add_argument("--max-age-days", type=int, default=14)
    report = commands.add_parser("report")
    report.add_argument("--top", type=int, default=20)
    args = parser.parse_args()
    try:
        if args.command == "start":
            print(start_run(args.root, args.suite, args.owner_pid))
        elif args.command == "temp-root":
            print(prepare_test_environment(args.root, args.run, os.getppid())["TMPDIR"])
        elif args.command == "finish":
            print(json.dumps(finish_run(args.root, args.run, args.status, args.keep, os.getppid())))
        elif args.command == "prune":
            print(json.dumps(prune_runs(args.root, apply=args.apply,
                                        max_bytes=args.max_mib * 1024**2,
                                        max_age_days=args.max_age_days)))
        else:
            root = checked_root(args.root)
            if args.top < 1:
                raise ValueError("Report size must be positive.")
            rows = [{"name": p.name, "bytes": tree_bytes(p)}
                    for p in root.iterdir()] if root.exists() else []
            rows.sort(key=lambda row: (-row["bytes"], row["name"]))
            print(json.dumps({"root": str(root), "bytes": sum(row["bytes"] for row in rows),
                              "childCount": len(rows), "children": rows[:args.top]}))
    except (ValueError, OSError, json.JSONDecodeError) as error:
        parser.exit(1, f"Artifact operation refused: {error}\n")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
