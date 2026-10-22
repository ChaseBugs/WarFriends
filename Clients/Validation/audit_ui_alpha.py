"""Check the recovered premultiplied UI texture import contract; --fix repairs metadata only."""
import argparse
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1] / "ExportedProject/Assets"


def texture_paths():
    metas = {}
    for path in ROOT.rglob("*.meta"):
        match = re.search(r"^guid: (\w+)$", path.read_text(encoding="utf-8-sig"), re.M)
        if match:
            metas[match[1]] = path
    shaders = set()
    for guid, meta in metas.items():
        if meta.name.endswith(".shader.meta"):
            shader = meta.with_suffix("").read_text(encoding="utf-8-sig")
            if re.search(r'Shader "Unlit/Premultiplied Colored', shader):
                shaders.add(guid)
    textures = set()
    for material in ROOT.rglob("*.mat"):
        content = material.read_text(encoding="utf-8-sig")
        shader = re.search(r"m_Shader:.*guid: (\w+)", content)
        if shader and shader[1] in shaders:
            for guid in re.findall(r"m_Texture:.*guid: (\w+)", content):
                if guid in metas:
                    textures.add(metas[guid])
    # AtlasPreparer replaces the serialized 1x1 placeholders by these runtime atlases.
    for prefab in (ROOT / "GameObject").glob("*.prefab"):
        for name in re.findall(r"^  pngPath: (\w+)$", prefab.read_text(encoding="utf-8-sig"), re.M):
            meta = ROOT / "Resources/gui" / (name + ".png.meta")
            if meta.exists():
                textures.add(meta)
    return sorted(textures)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--fix", action="store_true")
    args = parser.parse_args()
    errors = []
    textures = texture_paths()
    for meta in textures:
        original = meta.read_bytes()
        text = original.decode("utf-8-sig")
        # RGB is already multiplied by alpha in the APK. Unity's alpha dilation
        # creates visible RGB in transparent pixels under Blend One OneMinusSrcAlpha.
        updated = re.sub(r"(alphaIsTransparency:) \d+", r"\1 0", text)
        updated = re.sub(r"(enableMipMap:) \d+", r"\1 0", updated)
        updated = re.sub(r"(filterMode:) \d+", r"\1 1", updated)
        # RGBA32 avoids block-compression fringes and preserves the recovered pixels.
        updated = re.sub(r"(textureFormat:) -?\d+", r"\1 4", updated)
        if updated != text:
            errors.append(str(meta.relative_to(ROOT)))
            if args.fix:
                meta.write_bytes(updated.encode("utf-8"))
    print(f"Premultiplied UI textures: {len(textures)}; {'repaired' if args.fix else 'invalid'}: {len(errors)}")
    for error in errors:
        print(error)
    if errors and not args.fix:
        raise SystemExit(1)


if __name__ == "__main__":
    main()
