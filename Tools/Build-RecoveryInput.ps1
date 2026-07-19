param(
    [string]$RepositoryRoot = (Split-Path -Parent $PSScriptRoot)
)

$ErrorActionPreference = 'Stop'

$repositoryPath = [System.IO.Path]::GetFullPath($RepositoryRoot)
$recoveryPath = Join-Path $repositoryPath 'Recovery'
$apkRoot = Join-Path $recoveryPath 'ApkRoot'
$obbRoot = Join-Path $recoveryPath 'ObbRoot'
$androidRoot = Join-Path $recoveryPath 'AndroidRoot'

Write-Warning 'This helper only prepares a diagnostic hybrid input. The supplied OBB is WarFriends 6.1.7 / Unity 6000 and is not compatible with the 1.6.0 / Unity 5.6 Mono APK.'

if (-not (Test-Path (Join-Path $apkRoot 'assets\bin\Data\Managed\Assembly-CSharp.dll'))) {
    throw "The extracted Mono APK data is missing from $apkRoot"
}

if (-not (Test-Path (Join-Path $obbRoot 'assets\bin\Data'))) {
    throw "The extracted OBB data is missing from $obbRoot"
}

if (Test-Path $androidRoot) {
    $resolvedRecovery = (Resolve-Path $recoveryPath).Path.TrimEnd('\')
    $resolvedAndroid = (Resolve-Path $androidRoot).Path
    if (-not $resolvedAndroid.StartsWith("$resolvedRecovery\", [System.StringComparison]::OrdinalIgnoreCase)) {
        throw "Refusing to replace a directory outside Recovery: $resolvedAndroid"
    }
    Remove-Item -LiteralPath $resolvedAndroid -Recurse -Force
}

New-Item -ItemType Directory -Path $androidRoot | Out-Null
Copy-Item -Path (Join-Path $obbRoot '*') -Destination $androidRoot -Recurse -Force
Copy-Item -Path (Join-Path $apkRoot '*') -Destination $androidRoot -Recurse -Force

$splitFiles = Get-ChildItem $androidRoot -Recurse -File | Where-Object Name -Match '\.split\d+$'
$groups = $splitFiles | Group-Object { $_.FullName -replace '\.split\d+$', '' }

foreach ($group in $groups) {
    $targetPath = $group.Name
    $parts = $group.Group | Sort-Object { [int]([regex]::Match($_.Name, '\.split(\d+)$').Groups[1].Value) }
    $expected = 0
    foreach ($part in $parts) {
        $partNumber = [int]([regex]::Match($part.Name, '\.split(\d+)$').Groups[1].Value)
        if ($partNumber -ne $expected) {
            throw "Missing split part $expected for $targetPath"
        }
        $expected++
    }

    $output = [System.IO.File]::Create($targetPath)
    try {
        foreach ($part in $parts) {
            $input = [System.IO.File]::OpenRead($part.FullName)
            try {
                $input.CopyTo($output)
            }
            finally {
                $input.Dispose()
            }
        }
    }
    finally {
        $output.Dispose()
    }

    foreach ($part in $parts) {
        Remove-Item -LiteralPath $part.FullName -Force
    }
}

$assemblyPath = Join-Path $androidRoot 'assets\bin\Data\Managed\Assembly-CSharp.dll'
Write-Host "Prepared combined Android root: $androidRoot"
Write-Host "Recombined split asset groups: $($groups.Count)"
Write-Host "Assembly-CSharp.dll size: $((Get-Item $assemblyPath).Length) bytes"
