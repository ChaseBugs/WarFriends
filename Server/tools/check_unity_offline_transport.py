"""Compile and check the Client in one disposable Editor import without copying Library caches."""
import argparse
import json
import os
from pathlib import Path

import recapture_battle_content as capture


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--unity", type=Path, required=True)
    args = parser.parse_args()
    if not args.unity.is_file():
        parser.error("Unity executable does not exist")
    run = capture.start_run(capture.DEFAULT_ROOT, "offline-transport", os.getpid())
    print("Owned Client transport check: " + str(run), flush=True)
    try:
        project, _, _, _ = capture.prepare_project(run, prepare_strings=False)
        audit = capture.ROOT / "Server/tools/UnityOfflineTransportAudit.cs"
        (project / "Assets/Editor/UnityOfflineTransportAudit.cs").write_bytes(audit.read_bytes())
        transport_audit = capture.ROOT / "Server/tools/UnityBestHttpBackendAudit.cs"
        (project / "Assets/Editor/UnityBestHttpBackendAudit.cs").write_bytes(transport_audit.read_bytes())
        output = run / "transport-report.json"
        capture.execute_editor(args.unity.resolve(), project, run, method="UnityOfflineTransportAudit.Run",
                               outputs={"WAR_OFFLINE_TRANSPORT_REPORT": output})
        report = json.loads(output.read_bytes())
        if report.get("passed") is not True:
            raise ValueError("Client transport checks failed")
        report["unchangedSourceFiles"] = capture.verify_source_snapshot(run)
        capture.write_report(output, report)
    except BaseException as error:
        capture.write_report(run / "failure.json", {"type": type(error).__name__, "message": str(error)})
        capture.finish_run(capture.DEFAULT_ROOT, run, "failed", False)
        raise
    capture.finish_run(capture.DEFAULT_ROOT, run, "passed", False)
    print("PASS: Client compile, retired Photon connections, local room, protobuf codec and BestHTTP requests", flush=True)


if __name__ == "__main__":
    main()
