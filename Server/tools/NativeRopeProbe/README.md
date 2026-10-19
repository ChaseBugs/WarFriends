# Stationary helicopter rope research probe

This executable recreates the three stripped Unity rope fixtures using the official PhysX 3.4
CPU SDK. It is not a Worker backend, a Unity plugin, or a gameplay acceptance test. Both
managed and native results retain unresolved tilted rotation/angular-velocity differences.
See [the physics boundary](../../docs/HELICOPTER_ROPE_PHYSICS.md).

Run commands from the repository root. Downloads and build outputs stay under `Server/.local`.
The SDK is pinned to `5e42a5f112351a223c19c17bb331e6c55037b8eb`.
An existing checkout at another revision is rejected without resetting it.

The same CMake project also builds the `WarRopePhysics` shared library for deliberate
.NET adapter validation. This does not register a solver in the Worker. See the
[ownership and ABI contract](../../native/WarRopePhysics/README.md) for the separate
`--native-helicopter-rope-only` acceptance mode.

## Windows

Install Git, Python 3, and Visual Studio 2022 C++ tools with CMake and Windows SDK 10.

```powershell
& Server/tools/BuildPhysXReference.ps1
python Server/tools/PrepareNativeRopeProbe.py `
    Server/content/recovered-helicopter-rope-physics-unity-reference.json `
    Server/.local/rope-native-input.txt
$sdk = Join-Path $PWD 'Server/.local/physx-sdk-3.4'
$env:PATH = "$sdk/PhysX_3.4/Bin/vc15win64;$sdk/PxShared/bin/vc15win64;$env:PATH"
& Server/.local/native-rope-probe/Release/NativeRopeProbe.exe `
    Server/.local/rope-native-input.txt > Server/.local/rope-native-output.csv
if ($LASTEXITCODE -ne 0) { throw 'Native rope probe failed.' }
python Server/tools/CompareNativeRopeProbe.py `
    Server/content/recovered-helicopter-rope-physics-unity-reference.json `
    Server/.local/rope-native-output.csv --output Server/.local/rope-native-comparison.json
```

The Windows SDK script replaces the retired `typeinfo.h` include with `typeinfo`, selects
MSVC v143/SDK 10, and preserves warnings without treating them as errors. The probe links
the static MSVC runtime to match the SDK's Extensions library. No physics equations are patched.

## Linux

Install Git, Python 3, GNU make, GCC/G++, and CMake 3.20 or newer. No Docker is used.

```bash
bash Server/tools/BuildPhysXReference.sh
python3 Server/tools/PrepareNativeRopeProbe.py \
    Server/content/recovered-helicopter-rope-physics-unity-reference.json \
    Server/.local/rope-native-input.txt
sdk="$PWD/Server/.local/physx-sdk-3.4"
export LD_LIBRARY_PATH="$sdk/PhysX_3.4/Bin/linux64:$sdk/PxShared/bin/linux64:${LD_LIBRARY_PATH:-}"
Server/.local/native-rope-probe-linux/NativeRopeProbe \
    Server/.local/rope-native-input.txt > Server/.local/rope-native-linux.csv
python3 Server/tools/CompareNativeRopeProbe.py \
    Server/content/recovered-helicopter-rope-physics-unity-reference.json \
    Server/.local/rope-native-linux.csv --output Server/.local/rope-native-linux-comparison.json
```

The Linux script corrects a const-reference return in the old SDK's unused
`RelativeConvex::getRelativeTransform` accessor. It removes `-Werror` while preserving
warnings. Actual Ubuntu WSL SDK/probe builds and execution succeeded after this patch
and the probe's portable SDK-pi constant declaration. Platform diagnostics and their
remaining differences are recorded in the physics evidence document.

## Scope of the comparison

The input exporter requires the exact reviewed fixture digest, including the attachment
rest rotation captured before QuickRope2 activation. The comparator requires exactly
120 uniquely identified finite body-step records. It reports Euclidean position/velocity
errors and sign-invariant quaternion-component distance, not degrees. It sets no gameplay
acceptance threshold. A successful comparison command means the diagnostic is complete,
not that every trajectory matches. The fixture omits moving aircraft, extension commands,
map collisions, live crew, and landing.
