param([switch]$IncludeAvailableHosts)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'TestRun.ps1')
$names = @('WAR_TEST_ENV_ABSENT', 'WAR_TEST_ENV_EMPTY', 'WAR_TEST_ENV_VALUE')
$original = @{}
foreach ($name in $names) { $original[$name] = [Environment]::GetEnvironmentVariable($name, 'Process') }
try {
    foreach ($name in $names) { Remove-Item -LiteralPath ("Env:" + $name) -ErrorAction SilentlyContinue }
    [Environment]::SetEnvironmentVariable($names[1], '', 'Process')
    [Environment]::SetEnvironmentVariable($names[2], 'exact original value', 'Process')
    $emptySupported = [Environment]::GetEnvironmentVariables('Process').Contains($names[1])
    $expected = @{}
    foreach ($name in $names) { $expected[$name] = [Environment]::GetEnvironmentVariable($name, 'Process') }
    foreach ($name in $names) { [Environment]::SetEnvironmentVariable($name, 'temporary', 'Process') }
    Restore-WarTestEnvironment $expected
    $actual = [Environment]::GetEnvironmentVariables('Process')
    foreach ($name in $names) {
        if ($null -eq $expected[$name]) {
            if ($actual.Contains($name)) { throw "Absent environment key was retained: $name" }
        }
        elseif (!$actual.Contains($name) -or $actual[$name] -cne $expected[$name]) {
            throw "Environment value or explicit empty state was changed: $name"
        }
    }
    Write-Host "PASS: absent/empty/value environment restoration on PowerShell $($PSVersionTable.PSVersion); empty supported=$emptySupported"
}
finally { Restore-WarTestEnvironment $original }

if ($IncludeAvailableHosts) {
    $otherName = if ($PSVersionTable.PSEdition -eq 'Desktop') { 'pwsh' } else { 'powershell' }
    $other = Get-Command $otherName -ErrorAction SilentlyContinue
    if ($other) {
        & $other.Source -NoProfile -ExecutionPolicy Bypass -File $PSCommandPath
        if ($LASTEXITCODE -ne 0) { throw 'Environment restoration failed on another installed PowerShell host.' }
    }
}
