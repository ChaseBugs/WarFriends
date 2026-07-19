param(
    [string]$RepositoryRoot = (Split-Path -Parent $PSScriptRoot)
)

$ErrorActionPreference = 'Stop'

$repositoryPath = [System.IO.Path]::GetFullPath($RepositoryRoot)
$recoveryPath = Join-Path $repositoryPath 'Recovery\WarFriends-4.9.5'
$apkRoot = Join-Path $recoveryPath 'ApkRoot'
$obbRoot = Join-Path $recoveryPath 'ObbRoot'
$androidRoot = Join-Path $recoveryPath 'AndroidRoot'

if (-not (Test-Path (Join-Path $apkRoot 'assets\bin\Data\Managed\Metadata\global-metadata.dat'))) {
    throw "The extracted 4.9.5 APK metadata is missing from $apkRoot"
}

if (-not (Test-Path (Join-Path $obbRoot 'assets\bin\Data'))) {
    throw "The extracted 4.9.5 OBB data is missing from $obbRoot"
}

if (Test-Path $androidRoot) {
    $resolvedRecovery = (Resolve-Path $recoveryPath).Path.TrimEnd('\')
    $resolvedAndroid = (Resolve-Path $androidRoot).Path
    if (-not $resolvedAndroid.StartsWith("$resolvedRecovery\", [System.StringComparison]::OrdinalIgnoreCase)) {
        throw "Refusing to replace a directory outside the 4.9.5 recovery area: $resolvedAndroid"
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

Write-Host "Prepared WarFriends 4.9.5 Android root: $androidRoot"
Write-Host "Recombined split asset groups: $($groups.Count)"
Write-Host "Files: $((Get-ChildItem $androidRoot -Recurse -File).Count)"
