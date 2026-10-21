"""Exercise deletion boundaries and successful/failed test retention."""

import importlib.util
import os
import stat
import subprocess
import sys
import tempfile
import unittest
from pathlib import Path
from unittest.mock import patch

import process_identity


SPEC = importlib.util.spec_from_file_location("test_artifacts", Path(__file__).with_name("test_artifacts.py"))
artifacts = importlib.util.module_from_spec(SPEC)
SPEC.loader.exec_module(artifacts)


class TestArtifactLifecycle(unittest.TestCase):
    def setUp(self):
        self.temporary = tempfile.TemporaryDirectory(prefix="war-artifact-tests-")
        self.addCleanup(self.temporary.cleanup)
        self.root = Path(self.temporary.name) / "runs"

    def complete(self, status="passed", keep=False):
        run = artifacts.start_run(self.root, "fixture", os.getpid())
        (run / "data" / "mongo.bin").write_bytes(b"database" * 100)
        (run / "report.json").write_text('{"checks":3}', encoding="utf-8")
        artifacts.finish_run(self.root, run, status, keep)
        return run

    def test_success_removes_only_disposable_data(self):
        run = self.complete()
        self.assertFalse((run / "data").exists())
        self.assertTrue((run / "report.json").is_file())
        self.assertEqual("passed", artifacts.read_manifest(run)["status"])

    def test_readonly_package_file_does_not_strand_successful_run(self):
        run = artifacts.start_run(self.root, "fixture", os.getpid())
        package = run / "data" / "package.md"
        package.write_text("owned Unity package documentation", encoding="utf-8")
        package.chmod(stat.S_IREAD)
        artifacts.finish_run(self.root, run, "passed", False)
        self.assertFalse((run / "data").exists())
        self.assertEqual("passed", artifacts.read_manifest(run)["status"])

    def test_failure_and_keep_preserve_database(self):
        for status, keep in (("failed", False), ("passed", True)):
            run = self.complete(status, keep)
            self.assertTrue((run / "data" / "mongo.bin").is_file())

    def test_dry_run_never_deletes_and_apply_bounds_storage(self):
        run = self.complete("failed")
        with patch.object(artifacts, "process_is_alive", return_value=False):
            preview = artifacts.prune_runs(self.root, max_bytes=0)
            self.assertTrue(run.exists())
            self.assertEqual(1, len(preview["removed"]))
            result = artifacts.prune_runs(self.root, apply=True, max_bytes=0)
        self.assertFalse(run.exists())
        self.assertGreater(result["reclaimedBytes"], 800)

    def test_unknown_active_live_and_pinned_runs_survive(self):
        running = artifacts.start_run(self.root, "fixture", os.getpid())
        pinned = self.complete(keep=True)
        unknown = self.root / "historical-evidence"
        unknown.mkdir()
        live = self.complete()
        artifacts.prune_runs(self.root, apply=True, max_bytes=0)
        for run in (running, pinned, unknown, live):
            self.assertTrue(run.exists())

    def test_outside_root_and_corrupt_ownership_are_refused(self):
        run = self.complete("failed")
        outside = Path(self.temporary.name) / run.name
        with self.assertRaises(ValueError):
            artifacts.checked_run(self.root, outside)
        (run / artifacts.MARKER).write_text("{}", encoding="utf-8")
        with patch.object(artifacts, "process_is_alive", return_value=False):
            artifacts.prune_runs(self.root, apply=True, max_bytes=0)
        self.assertTrue(run.exists())

    def test_another_process_cannot_finish_active_run(self):
        run = artifacts.start_run(self.root, "fixture", os.getpid())
        with self.assertRaises(ValueError):
            artifacts.finish_run(self.root, run, "passed", False, os.getpid() + 1)
        self.assertTrue((run / "data").is_dir())
        self.assertEqual("running", artifacts.read_manifest(run)["status"])

    def test_real_process_creation_identity_is_stable_and_child_scoped(self):
        for invalid in (None, True, -1, 0, 2**32, "1"):
            self.assertIsNone(process_identity.process_start_identity(invalid))
        identity = process_identity.process_start_identity(os.getpid())
        self.assertTrue(process_identity.valid_identity(identity))
        self.assertEqual(identity, process_identity.process_start_identity(os.getpid()))
        child = subprocess.Popen([sys.executable, "-c", "import sys; sys.stdin.buffer.read(1)"],
                                 stdin=subprocess.PIPE, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL)
        try:
            self.assertTrue(process_identity.valid_identity(process_identity.process_start_identity(child.pid)))
        finally:
            child.communicate(b"x", timeout=5)
        self.assertIsNone(process_identity.process_start_identity(child.pid))

    def test_changed_creation_identity_cannot_finish_or_discard_data(self):
        run = artifacts.start_run(self.root, "fixture", os.getpid())
        data = run / "data" / "database.bin"
        data.write_bytes(b"retain this database")
        for observed in ("windows:123", None):
            with self.subTest(observed=observed):
                with patch.object(artifacts, "process_start_identity", return_value=observed):
                    with self.assertRaises(ValueError):
                        artifacts.finish_run(self.root, run, "passed", False)
                self.assertEqual(b"retain this database", data.read_bytes())
                self.assertEqual("running", artifacts.read_manifest(run)["status"])

    def test_reused_pid_does_not_pin_a_completed_run(self):
        run = self.complete("failed")
        with patch.object(artifacts, "process_is_alive", return_value=True):
            with patch.object(artifacts, "process_start_identity", return_value="windows:123"):
                preview = artifacts.prune_runs(self.root, max_bytes=0)
                self.assertEqual([run.name], [row["run"] for row in preview["removed"]])
                artifacts.prune_runs(self.root, apply=True, max_bytes=0)
        self.assertFalse(run.exists())

    def test_inaccessible_identity_and_legacy_live_pid_remain_protected(self):
        current = self.complete()
        legacy = self.complete()
        manifest = artifacts.read_manifest(legacy)
        manifest["schema"] = artifacts.LEGACY_SCHEMA
        del manifest["ownerStarted"]
        artifacts.write_manifest(legacy, manifest)
        with patch.object(artifacts, "process_is_alive", return_value=True):
            with patch.object(artifacts, "process_start_identity", return_value=None):
                result = artifacts.prune_runs(self.root, apply=True, max_bytes=0)
        self.assertEqual([], result["removed"])
        self.assertTrue(current.exists())
        self.assertTrue(legacy.exists())

    def test_invalid_or_missing_creation_identity_is_not_repaired(self):
        run = self.complete("failed")
        original = artifacts.read_manifest(run)
        for value in (None, "", "windows:01", "windows:-1", "windows:18446744073709551616",
                      "linux:bad:42", 123):
            with self.subTest(value=value):
                artifacts.write_manifest(run, dict(original, ownerStarted=value))
                with self.assertRaises(ValueError):
                    artifacts.read_manifest(run)
                self.assertEqual([], artifacts.prune_runs(self.root, apply=True, max_bytes=0)["removed"])
                self.assertTrue(run.exists())
        malformed = dict(original)
        del malformed["ownerStarted"]
        artifacts.write_manifest(run, malformed)
        with self.assertRaises(ValueError):
            artifacts.read_manifest(run)

    def test_unverifiable_owner_cannot_create_a_partial_run(self):
        with patch.object(artifacts, "process_start_identity", return_value=None):
            with self.assertRaises(ValueError):
                artifacts.start_run(self.root, "fixture", os.getpid())
        self.assertFalse(self.root.exists())

    def test_linux_creation_identity_parses_parenthesized_names_and_boot_identity(self):
        boot_id = "01234567-89ab-cdef-0123-456789abcdef"
        stat = "12 (worker with ) spaces) S " + " ".join(["0"] * 18 + ["345", "0"])
        with patch.object(process_identity.Path, "read_text", side_effect=[stat, boot_id + "\n"]):
            self.assertEqual(f"linux:{boot_id}:345", process_identity.linux_identity(12))
        self.assertTrue(process_identity.valid_identity(f"linux:{boot_id}:0"))
        self.assertFalse(process_identity.valid_identity(f"linux:{boot_id}:18446744073709551616"))

    def test_owner_change_during_prune_preserves_the_run(self):
        run = self.complete("failed")
        original = artifacts.read_manifest(run)["ownerStarted"]
        with patch.object(artifacts, "process_is_alive", return_value=True):
            with patch.object(artifacts, "process_start_identity", side_effect=["windows:123", original]):
                with self.assertRaises(ValueError):
                    artifacts.prune_runs(self.root, apply=True, max_bytes=0)
        self.assertTrue(run.exists())

    def test_child_temporary_files_are_owned_and_parent_environment_is_unchanged(self):
        before = {name: os.environ.get(name) for name in ("TEMP", "TMP", "TMPDIR")}
        run = artifacts.start_run(self.root, "fixture", os.getpid())
        environment = artifacts.prepare_test_environment(self.root, run)
        observed = subprocess.check_output([sys.executable, "-c", "import tempfile; print(tempfile.gettempdir())"],
                                           env=environment, text=True).strip()
        self.assertEqual(run / "data" / "temp", Path(observed))
        self.assertEqual(before, {name: os.environ.get(name) for name in before})
        (Path(observed) / "fixture.bin").write_bytes(b"disposable test state")
        artifacts.finish_run(self.root, run, "passed", False)
        self.assertFalse((run / "data").exists())
        with self.assertRaises(ValueError):
            artifacts.prepare_test_environment(self.root, run)

    def test_temporary_root_refuses_a_changed_owner(self):
        run = artifacts.start_run(self.root, "fixture", os.getpid())
        with patch.object(artifacts, "process_start_identity", return_value=None):
            with self.assertRaises(ValueError):
                artifacts.prepare_test_environment(self.root, run)
        self.assertFalse((run / "data" / "temp").exists())

    def test_cli_parent_can_prepare_only_its_owned_temporary_root(self):
        run = artifacts.start_run(self.root, "fixture", os.getpid())
        command = [sys.executable, str(Path(__file__).with_name("test_artifacts.py")),
                   "--root", str(self.root), "temp-root", str(run)]
        observed = subprocess.check_output(command, text=True).strip()
        self.assertEqual(run / "data" / "temp", Path(observed))
        artifacts.finish_run(self.root, run, "passed", False)
        refused = subprocess.run(command, capture_output=True, text=True)
        self.assertNotEqual(0, refused.returncode)
        self.assertFalse((run / "data").exists())

    def test_another_cli_parent_cannot_allocate_temporary_storage(self):
        run = artifacts.start_run(self.root, "fixture", os.getpid())
        command = [sys.executable, str(Path(__file__).with_name("test_artifacts.py")),
                   "--root", str(self.root), "temp-root", str(run)]
        child_code = "import subprocess,sys; sys.exit(subprocess.run(sys.argv[1:], capture_output=True).returncode)"
        refused = subprocess.run([sys.executable, "-c", child_code, *command], capture_output=True)
        self.assertNotEqual(0, refused.returncode)
        self.assertFalse((run / "data" / "temp").exists())

    def test_cli_parent_owns_the_complete_lifecycle(self):
        command = [sys.executable, str(Path(__file__).with_name("test_artifacts.py")),
                   "--root", str(self.root)]
        run = subprocess.check_output(command + ["start", "cli", "--owner-pid", str(os.getpid())], text=True).strip()
        subprocess.run(command + ["finish", run, "--status", "passed"],
                       check=True, stdout=subprocess.DEVNULL)
        self.assertEqual("passed", artifacts.read_manifest(Path(run))["status"])

    def test_environment_selects_the_same_owned_root_for_start_and_finish(self):
        command = [sys.executable, str(Path(__file__).with_name("test_artifacts.py"))]
        environment = dict(os.environ, WAR_TEST_RUN_ROOT=str(self.root))
        run = subprocess.check_output(command + ["start", "relocated", "--owner-pid", str(os.getpid())],
                                      env=environment, text=True).strip()
        self.assertEqual(self.root, Path(run).parent)
        subprocess.run(command + ["finish", run, "--status", "passed"], env=environment,
                       check=True, stdout=subprocess.DEVNULL)
        self.assertEqual("passed", artifacts.read_manifest(Path(run))["status"])

    def test_nested_link_preserves_external_data(self):
        run = artifacts.start_run(self.root, "fixture", os.getpid())
        outside = Path(self.temporary.name) / "external"
        outside.mkdir()
        (outside / "keep.txt").write_text("evidence", encoding="utf-8")
        try:
            (run / "data" / "link").symlink_to(outside, target_is_directory=True)
        except OSError:
            self.skipTest("Creating directory symlinks is unavailable for this account.")
        with self.assertRaises(ValueError):
            artifacts.finish_run(self.root, run, "passed", False)
        self.assertTrue((outside / "keep.txt").exists())


if __name__ == "__main__":
    unittest.main()
