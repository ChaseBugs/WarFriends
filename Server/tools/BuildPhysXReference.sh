#!/usr/bin/env bash
set -euo pipefail

# Build an isolated research SDK; the live Worker never loads these libraries.
script_directory=$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)
server_directory=$(cd -- "$script_directory/.." && pwd)
sdk_directory=${1:-"$server_directory/.local/physx-sdk-3.4"}
parallelism=${PHYSX_BUILD_JOBS:-4}
revision=5e42a5f112351a223c19c17bb331e6c55037b8eb

if [[ ! $parallelism =~ ^[1-8]$ ]]; then
    echo 'PHYSX_BUILD_JOBS must be an integer from one through eight.' >&2
    exit 1
fi

if [[ ! -d $sdk_directory ]]; then
    git clone --filter=blob:none --sparse https://github.com/NVIDIAGameWorks/PhysX-3.4.git "$sdk_directory"
    git -C "$sdk_directory" checkout "$revision"
fi
if [[ $(git -C "$sdk_directory" rev-parse HEAD) != "$revision" ]]; then
    echo 'Unexpected PhysX revision; the existing checkout was not reset.' >&2
    exit 1
fi
git -C "$sdk_directory" sparse-checkout add PhysX_3.4/Source PhysX_3.4/Include PxShared Externals/nvToolsExt

python3 - "$sdk_directory" <<'PY'
from pathlib import Path
import sys

root = Path(sys.argv[1])
# GCC rejects a non-const reference to this const member, even in an unused template accessor.
header = root / "PhysX_3.4/Source/GeomUtils/src/gjk/GuGJKType.h"
original = "PX_FORCE_INLINE Ps::aos::PsMatTransformV& getRelativeTransform(){ return mAToB; }"
replacement = "PX_FORCE_INLINE const Ps::aos::PsMatTransformV& getRelativeTransform() const { return mAToB; }"
contents = header.read_text()
if original not in contents and replacement not in contents:
    raise ValueError("The pinned PhysX getter does not match the reviewed compiler patch.")
if original in contents:
    header.write_text(contents.replace(original, replacement))

# Preserve compiler warnings without letting the old SDK warning policy reject newer GCC diagnostics.
for makefile in (root / "PhysX_3.4/Source/compiler/linux64").glob("*.mk"):
    contents = makefile.read_text()
    if "-Werror" in contents:
        makefile.write_text(contents.replace("-Werror", ""))
PY

make -C "$sdk_directory/PhysX_3.4/Source/compiler/linux64" release -j"$parallelism"
probe_build="$server_directory/.local/native-rope-probe-linux"
cmake -S "$script_directory/NativeRopeProbe" -B "$probe_build" \
    -DCMAKE_BUILD_TYPE=Release -DPHYSX_ROOT="$sdk_directory"
cmake --build "$probe_build" --parallel "$parallelism"
echo "Built the Linux research SDK and probe at $probe_build; no Worker registration was changed."
