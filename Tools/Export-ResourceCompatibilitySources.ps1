[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Split-Path -Parent $PSScriptRoot),
    [switch]$CleanOutput
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

# This exporter deliberately starts from serialized YAML references instead of copying the
# entire recovered assembly. That keeps the source replacement bounded to the MonoBehaviour
# and ScriptableObject identities that Unity assets actually use. Compile-time dependency
# files are added separately after their necessity has been proven by the compiler.
$targets = @(
    [pscustomobject]@{
        AssemblyName = 'WarFriends.ResourceCompatibility'
        OldGuid = 'da3348191866a384b95001cc2c6d51b2'
        TypeMap = 'Client\resource-compatibility-types.csv'
        DecompiledRoot = '.codex-resourcecompat-decompile\Main'
        OutputRoot = 'Client\ExportedProject\Assets\Scripts\ResourceCompatibility'
        Manifest = 'Client\resource-compatibility-source-map.csv'
        ClosureMap = 'Client\resource-compatibility-type-closure.csv'
        DependencyManifest = 'Client\resource-compatibility-source-dependencies.csv'
        ExpectedTypeCount = 277
        ExpectedReferenceCount = 1057
    },
    [pscustomobject]@{
        AssemblyName = 'WarFriends.ResourceCompatibility.FirstPass'
        OldGuid = 'ac2116c440a88b441990deaeb6e59e4b'
        TypeMap = 'Client\resource-compatibility-types-firstpass.csv'
        DecompiledRoot = '.codex-resourcecompat-decompile\FirstPass'
        OutputRoot = 'Client\ExportedProject\Assets\Scripts\ResourceCompatibility.FirstPass'
        Manifest = 'Client\resource-compatibility-source-map-firstpass.csv'
        ClosureMap = 'Client\resource-compatibility-type-closure-firstpass.csv'
        DependencyManifest = 'Client\resource-compatibility-source-dependencies-firstpass.csv'
        ExpectedTypeCount = 125
        ExpectedReferenceCount = 136
    }
)

function Resolve-RepositoryPath([string]$RelativePath) {
    return [System.IO.Path]::GetFullPath((Join-Path $RepositoryRoot $RelativePath))
}

function Get-DeterministicMetaGuid([string]$AssemblyName, [string]$FullName) {
    # Stable GUIDs make the YAML migration reproducible across machines. The assembly name is
    # included in the identity so equal type names from FirstPass and main cannot collide.
    $identity = "$AssemblyName|$FullName"
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($identity)
    $sha256 = [System.Security.Cryptography.SHA256]::Create()
    try {
        $hash = $sha256.ComputeHash($bytes)
    } finally {
        $sha256.Dispose()
    }
    $hex = ([System.BitConverter]::ToString($hash)).Replace('-', '').ToLowerInvariant()
    return $hex.Substring(0, 32)
}

function Repair-KnownDecompilerAmbiguities([string]$AssemblyName, [string]$RelativePath, [string]$DestinationPath) {
    # ILSpy cannot express an unqualified base named MonoBehaviour when the declaring namespace
    # is also Photon or when both Photon and UnityEngine are imported. These replacements are
    # metadata-backed: the original base/field identities were verified directly with Cecil.
    if ($AssemblyName -ne 'WarFriends.ResourceCompatibility.FirstPass') {
        return
    }

    $normalizedPath = $RelativePath.Replace('\', '/')
    $content = [System.IO.File]::ReadAllText($DestinationPath)
    if ($normalizedPath -eq 'Photon/MonoBehaviour.cs') {
        $content = $content.Replace('public class MonoBehaviour : MonoBehaviour', 'public class MonoBehaviour : UnityEngine.MonoBehaviour')
    } elseif ($normalizedPath -eq 'PhotonView.cs') {
        $content = $content.Replace('public class PhotonView : MonoBehaviour', 'public class PhotonView : Photon.MonoBehaviour')
        $content = $content.Replace('public MonoBehaviour mBehaviour;', 'public UnityEngine.MonoBehaviour mBehaviour;')
        $content = $content.Replace('internal MonoBehaviour[] RpcMonoBehaviours;', 'internal UnityEngine.MonoBehaviour[] RpcMonoBehaviours;')
    } else {
        return
    }
    [System.IO.File]::WriteAllText($DestinationPath, $content, [System.Text.UTF8Encoding]::new($false))
}

$assetsRoot = Resolve-RepositoryPath 'Client\ExportedProject\Assets'
$allManifestRows = [System.Collections.Generic.List[object]]::new()

foreach ($target in $targets) {
    $typeMapPath = Resolve-RepositoryPath $target.TypeMap
    $decompiledRoot = Resolve-RepositoryPath $target.DecompiledRoot
    $outputRoot = Resolve-RepositoryPath $target.OutputRoot
    $manifestPath = Resolve-RepositoryPath $target.Manifest
    $closureMapPath = Resolve-RepositoryPath $target.ClosureMap
    $dependencyManifestPath = Resolve-RepositoryPath $target.DependencyManifest

    if ($CleanOutput -and (Test-Path -LiteralPath $outputRoot)) {
        # The caller must opt into cleanup. The guard prevents a malformed configuration from
        # deleting any directory outside the checked-out repository.
        $resolvedRepositoryRoot = [System.IO.Path]::GetFullPath($RepositoryRoot)
        if (-not $outputRoot.StartsWith($resolvedRepositoryRoot, [System.StringComparison]::OrdinalIgnoreCase)) {
            throw "Refusing to clean output outside repository: $outputRoot"
        }
        Remove-Item -LiteralPath $outputRoot -Recurse -Force
    }

    New-Item -ItemType Directory -Path $outputRoot -Force | Out-Null

    $rowsByFileId = @{}
    foreach ($row in (Import-Csv -LiteralPath $typeMapPath)) {
        $fileId = [int64]$row.file_id
        if (-not $rowsByFileId.ContainsKey($fileId)) {
            $rowsByFileId[$fileId] = [System.Collections.Generic.List[object]]::new()
        }
        $rowsByFileId[$fileId].Add($row)
    }

    $escapedGuid = [regex]::Escape($target.OldGuid)
    $referencePattern = "fileID:\s*(-?\d+),\s*guid:\s*$escapedGuid,\s*type:\s*3"
    $referencedFileIds = [System.Collections.Generic.HashSet[int64]]::new()
    $referenceCount = 0

    # Unity YAML files are UTF-8 text. Reading only files that contain the assembly GUID avoids
    # rewriting or interpreting binary resources and preserves every serialized value verbatim.
    foreach ($assetPath in (& rg -l --fixed-strings $target.OldGuid $assetsRoot)) {
        $content = [System.IO.File]::ReadAllText($assetPath)
        foreach ($match in [regex]::Matches($content, $referencePattern)) {
            $referenceCount++
            [void]$referencedFileIds.Add([int64]$match.Groups[1].Value)
        }
    }

    if ($referenceCount -ne $target.ExpectedReferenceCount) {
        throw "Expected $($target.ExpectedReferenceCount) references for $($target.AssemblyName), found $referenceCount."
    }
    if ($referencedFileIds.Count -ne $target.ExpectedTypeCount) {
        throw "Expected $($target.ExpectedTypeCount) types for $($target.AssemblyName), found $($referencedFileIds.Count)."
    }

    $manifestRows = [System.Collections.Generic.List[object]]::new()
    foreach ($fileId in ($referencedFileIds | Sort-Object)) {
        if (-not $rowsByFileId.ContainsKey($fileId)) {
            throw "No recovered type-map row exists for fileID $fileId in $($target.AssemblyName)."
        }

        $typeCandidates = $rowsByFileId[$fileId]
        if ($typeCandidates.Count -ne 1) {
            $candidateNames = ($typeCandidates | ForEach-Object { $_.full_name }) -join ', '
            throw "Serialized fileID $fileId is ambiguous in $($target.AssemblyName): $candidateNames"
        }
        $type = $typeCandidates[0]
        $simpleName = $type.name -replace '`.*$', ''
        $relativeSourcePath = if ([string]::IsNullOrEmpty($type.namespace)) {
            "$simpleName.cs"
        } else {
            Join-Path $type.namespace "$simpleName.cs"
        }
        $sourcePath = Join-Path $decompiledRoot $relativeSourcePath
        if (-not (Test-Path -LiteralPath $sourcePath -PathType Leaf)) {
            throw "Recovered source file is missing for $($type.full_name): $sourcePath"
        }

        $destinationPath = Join-Path $outputRoot $relativeSourcePath
        $destinationDirectory = Split-Path -Parent $destinationPath
        New-Item -ItemType Directory -Path $destinationDirectory -Force | Out-Null
        Copy-Item -LiteralPath $sourcePath -Destination $destinationPath -Force
        Repair-KnownDecompilerAmbiguities $target.AssemblyName $relativeSourcePath $destinationPath

        $sourceGuid = Get-DeterministicMetaGuid $target.AssemblyName $type.full_name
        $metaText = "fileFormatVersion: 2`nguid: $sourceGuid`n"
        [System.IO.File]::WriteAllText("$destinationPath.meta", $metaText, [System.Text.UTF8Encoding]::new($false))

        $absoluteRepositoryRoot = [System.IO.Path]::GetFullPath($RepositoryRoot).TrimEnd('\')
        if (-not $destinationPath.StartsWith("$absoluteRepositoryRoot\", [System.StringComparison]::OrdinalIgnoreCase)) {
            throw "Exported source escaped repository root: $destinationPath"
        }
        $relativeDestination = $destinationPath.Substring($absoluteRepositoryRoot.Length + 1).Replace('\', '/')
        $manifestRow = [pscustomobject]@{
            assembly = $target.AssemblyName
            old_guid = $target.OldGuid
            old_file_id = $fileId
            full_name = $type.full_name
            source_path = $relativeDestination
            source_guid = $sourceGuid
            source_file_id = 11500000
        }
        $manifestRows.Add($manifestRow)
        $allManifestRows.Add($manifestRow)
    }

    $manifestRows | Export-Csv -LiteralPath $manifestPath -NoTypeInformation -Encoding UTF8
    Write-Output "$($target.AssemblyName): exported $($manifestRows.Count) source scripts for $referenceCount serialized references."

    if (Test-Path -LiteralPath $closureMapPath) {
        $serializedTypeNames = @{}
        foreach ($manifestRow in $manifestRows) {
            $serializedTypeNames[$manifestRow.full_name] = $true
        }
        $dependencyRows = [System.Collections.Generic.List[object]]::new()
        foreach ($type in ((Import-Csv -LiteralPath $closureMapPath) | Where-Object { -not $serializedTypeNames.ContainsKey($_.full_name) })) {
            $simpleName = $type.name -replace '`.*$', ''
            $relativeSourcePath = if ([string]::IsNullOrEmpty($type.namespace)) {
                "$simpleName.cs"
            } else {
                Join-Path $type.namespace "$simpleName.cs"
            }
            $sourcePath = Join-Path $decompiledRoot $relativeSourcePath
            if (-not (Test-Path -LiteralPath $sourcePath -PathType Leaf)) {
                throw "Closure source file is missing for $($type.full_name): $sourcePath"
            }

            $destinationPath = Join-Path $outputRoot $relativeSourcePath
            New-Item -ItemType Directory -Path (Split-Path -Parent $destinationPath) -Force | Out-Null
            Copy-Item -LiteralPath $sourcePath -Destination $destinationPath -Force
            Repair-KnownDecompilerAmbiguities $target.AssemblyName $relativeSourcePath $destinationPath

            $sourceGuid = Get-DeterministicMetaGuid $target.AssemblyName $type.full_name
            $metaText = "fileFormatVersion: 2`nguid: $sourceGuid`n"
            [System.IO.File]::WriteAllText("$destinationPath.meta", $metaText, [System.Text.UTF8Encoding]::new($false))

            $absoluteRepositoryRoot = [System.IO.Path]::GetFullPath($RepositoryRoot).TrimEnd('\')
            $relativeDestination = $destinationPath.Substring($absoluteRepositoryRoot.Length + 1).Replace('\', '/')
            $dependencyRows.Add([pscustomobject]@{
                assembly = $target.AssemblyName
                full_name = $type.full_name
                reason = 'assembly-local dependency'
                source_path = $relativeDestination
                source_guid = $sourceGuid
            })
        }

        $dependencyRows | Sort-Object full_name | Export-Csv -LiteralPath $dependencyManifestPath -NoTypeInformation -Encoding UTF8
        Write-Output "$($target.AssemblyName): exported $($dependencyRows.Count) assembly-local dependency scripts."
    }
}

if ($allManifestRows.Count -ne 402) {
    throw "Expected exactly 402 serialized source identities, exported $($allManifestRows.Count)."
}

Write-Output 'Resource compatibility seed export complete: 402 types and 1,193 references are fully mapped.'
