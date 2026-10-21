"""Prepare explicitly named exporter copies for a single owned Editor invocation."""
from recapture_battle_content import digest


def prepare(project, exporters, class_name):
    edits = {}
    calls = []
    for exporter, exit_count in exporters:
        relative = "Assets/Editor/SelfHosted" + exporter + "Export.cs"
        path = project / relative
        original = path.read_bytes()
        if original.count(b"EditorApplication.Exit(0);") != exit_count:
            raise ValueError("Unexpected exporter exit shape: " + relative)
        modified = original.replace(b"EditorApplication.Exit(0);", b"/* Batch runner owns successful exit. */")
        path.write_bytes(modified)
        edits[relative] = {"originalSha256": digest(original), "batchSha256": digest(modified)}
        calls.append("        SelfHosted" + exporter + "Export.Run();")
    wrapper = ("public static class " + class_name + "\n{\n    public static void Run()\n    {\n"
               + "\n".join(calls) + "\n    }\n}\n").encode()
    (project / "Assets/Editor" / (class_name + ".cs")).write_bytes(wrapper)
    return edits, wrapper
