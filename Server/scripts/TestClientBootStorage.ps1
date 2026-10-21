# Exercise an early build failure without launching Unity, Mongo or a real build.
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'TestRun.ps1')
$original = @{}
foreach ($name in @('WAR_TEST_RUN_ROOT', 'TEMP', 'TMP', 'TMPDIR', 'WAR_STARTER_LOADOUT_OUTPUT')) {
    $original[$name] = [Environment]::GetEnvironmentVariable($name, 'Process')
}
$parent = $null
$succeeded = $false
try {
    # The Client boot guard still requires its disposable Unity project under Server/.local.
    $env:WAR_TEST_RUN_ROOT = Join-Path (Split-Path $PSScriptRoot -Parent) '.local/test-runs'
    $parent = New-WarTestRun 'client-boot-storage'
    $project = Join-Path $parent 'data/project'
    New-Item -ItemType Directory -Path $project -Force | Out-Null
    $childRoot = Join-Path $parent 'data/managed root with spaces'
    $env:WAR_TEST_RUN_ROOT = $childRoot
    $expected = @{}
    foreach ($name in @('TEMP', 'TMP', 'TMPDIR', 'WAR_STARTER_LOADOUT_OUTPUT')) {
        $expected[$name] = [Environment]::GetEnvironmentVariable($name, 'Process')
    }
    function dotnet { $global:LASTEXITCODE = 1 }
    $failedAsExpected = $false
    try {
        & (Join-Path $PSScriptRoot 'ClientBootSmoke.ps1') -UnityExecutable 'must-not-launch' `
            -UnityProject $project -MongoExecutable 'must-not-launch' -ExportStarterLoadout
    }
    catch {
        if ($_.Exception.Message -ne 'Release build failed.') { throw }
        $failedAsExpected = $true
    }
    if (!$failedAsExpected) { throw 'The injected build failure did not stop the smoke.' }
    foreach ($name in $expected.Keys) {
        $actual = [Environment]::GetEnvironmentVariable($name, 'Process')
        if ($actual -cne $expected[$name]) { throw "Environment was not restored: $name" }
    }
    $runs = @(Get-ChildItem -LiteralPath $childRoot -Directory)
    if ($runs.Count -ne 1) { throw 'Expected exactly one owned child run.' }
    $manifest = Get-Content -LiteralPath (Join-Path $runs[0].FullName 'test-run.json') -Raw | ConvertFrom-Json
    if ($manifest.status -ne 'failed' -or $manifest.ownerPid -ne $PID) {
        throw 'Failed boot did not finalize its owned run.'
    }
    if (!(Test-Path -LiteralPath (Join-Path $runs[0].FullName 'data/mongo'))) {
        throw 'Failure diagnostics were removed instead of retained.'
    }
    $succeeded = $true
    Write-Output 'PASS: boot failure finalizes managed storage and restores temporary/export environment'
}
finally {
    Remove-Item Function:dotnet -ErrorAction SilentlyContinue
    $env:WAR_TEST_RUN_ROOT = Join-Path (Split-Path $PSScriptRoot -Parent) '.local/test-runs'
    if ($parent) { Complete-WarTestRun $parent $succeeded $false }
    Restore-WarTestEnvironment $original
}
