param(
    [string]$SdkDirectory = (Join-Path $PSScriptRoot '../.local/physx-sdk-3.4'),
    [ValidateRange(1, 8)][int]$Parallelism = 2
)

$ErrorActionPreference = 'Stop'
$revision = '5e42a5f112351a223c19c17bb331e6c55037b8eb'
$repositoryUrl = 'https://github.com/NVIDIAGameWorks/PhysX-3.4.git'
$serverDirectory = Split-Path $PSScriptRoot -Parent

if (-not (Test-Path -LiteralPath $SdkDirectory)) {
    & git clone --depth 1 --filter=blob:none --sparse $repositoryUrl $SdkDirectory
    if ($LASTEXITCODE -ne 0) { throw 'PhysX source download failed.' }
}

$actualRevision = (& git -C $SdkDirectory rev-parse HEAD).Trim()
if ($LASTEXITCODE -ne 0 -or $actualRevision -ne $revision) {
    throw "Expected PhysX revision $revision; found $actualRevision. The checkout was not reset."
}

& git -C $SdkDirectory sparse-checkout add PhysX_3.4/Source PhysX_3.4/Include PxShared Externals/nvToolsExt
if ($LASTEXITCODE -ne 0) { throw 'PhysX source selection failed.' }

# Modern MSVC removed the legacy compatibility header; this does not change SDK physics math.
$allocatorHeader = Join-Path $SdkDirectory 'PxShared/src/foundation/include/PsAllocator.h'
$header = [System.IO.File]::ReadAllText($allocatorHeader)
if (-not $header.Contains('#include <typeinfo>') -and -not $header.Contains('#include <typeinfo.h>')) {
    throw 'The pinned allocator header no longer matches the reviewed compatibility patch.'
}
$patchedHeader = $header.Replace('#include <typeinfo.h>', '#include <typeinfo>')
if ($patchedHeader -ne $header) { [System.IO.File]::WriteAllText($allocatorHeader, $patchedHeader) }

# Keep new compiler diagnostics visible without treating SDK-era warning policy as a physics error.
$projectDirectories = @(
    (Join-Path $SdkDirectory 'PhysX_3.4/Source/compiler/vc15win64'),
    (Join-Path $SdkDirectory 'PxShared/src/compiler/vc15win64')
)
foreach ($directory in $projectDirectories) {
    foreach ($project in Get-ChildItem -LiteralPath $directory -Filter '*.vcxproj') {
        $contents = [System.IO.File]::ReadAllText($project.FullName)
        $patched = $contents.Replace('<TreatWarningAsError>true</TreatWarningAsError>',
            '<TreatWarningAsError>false</TreatWarningAsError>')
        if ($patched -ne $contents) { [System.IO.File]::WriteAllText($project.FullName, $patched) }
    }
}

$vswhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio/Installer/vswhere.exe'
if (-not (Test-Path -LiteralPath $vswhere)) { throw 'Visual Studio Installer discovery is unavailable.' }
$installation = (& $vswhere -latest -version '[17.0,18.0)' -products '*' `
    -requires Microsoft.VisualStudio.Component.VC.Tools.x86.x64 `
    -property installationPath).Trim()
$msbuild = Join-Path $installation 'MSBuild/Current/Bin/MSBuild.exe'
$cmake = Join-Path $installation 'Common7/IDE/CommonExtensions/Microsoft/CMake/CMake/bin/cmake.exe'
if (-not (Test-Path -LiteralPath $msbuild) -or -not (Test-Path -LiteralPath $cmake)) {
    throw 'Install the Visual Studio C++ and CMake tools before building this reference.'
}

$solution = Join-Path $SdkDirectory 'PhysX_3.4/Source/compiler/vc15win64/PhysX.sln'
& $msbuild $solution "/m:$Parallelism" /p:Configuration=release /p:Platform=x64 `
    /p:PlatformToolset=v143 /p:WindowsTargetPlatformVersion=10.0 /v:minimal
if ($LASTEXITCODE -ne 0) { throw 'PhysX SDK build failed.' }

$probeSource = Join-Path $PSScriptRoot 'NativeRopeProbe'
$probeBuild = Join-Path $serverDirectory '.local/native-rope-probe'
& $cmake -S $probeSource -B $probeBuild -G 'Visual Studio 17 2022' -A x64 "-DPHYSX_ROOT=$SdkDirectory"
if ($LASTEXITCODE -ne 0) { throw 'PhysX rope probe configuration failed.' }
& $cmake --build $probeBuild --config Release
if ($LASTEXITCODE -ne 0) { throw 'PhysX rope probe build failed.' }

Write-Output "Built the Windows research SDK and probe at $probeBuild. No runtime Backend or Worker was changed."
