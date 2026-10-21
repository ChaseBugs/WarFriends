# Shared lifecycle for native tests. Dot-source this file from the owning script.
function Restore-WarTestEnvironment([hashtable]$Snapshot) {
    foreach ($name in $Snapshot.Keys) {
        if ($null -eq $Snapshot[$name]) {
            # Modern PowerShell binds a method's null string argument as empty, retaining the key.
            # Removing through the provider preserves absence without changing explicit empty values.
            Remove-Item -LiteralPath ("Env:" + $name) -ErrorAction SilentlyContinue
        }
        else {
            [Environment]::SetEnvironmentVariable($name, $Snapshot[$name], 'Process')
        }
    }
}

function New-WarTestRun([string]$Suite) {
    $artifactTool = Join-Path $PSScriptRoot 'test_artifacts.py'
    $run = & python $artifactTool start $Suite --owner-pid $PID
    if ($LASTEXITCODE -ne 0) { throw 'Could not allocate an owned test run.' }
    return [string]$run
}

function Stop-WarTestProcesses([array]$Processes) {
    $allStopped = $true
    foreach ($process in $Processes) {
        try {
            if (!$process.HasExited) {
                Stop-Process -Id $process.Id -ErrorAction Stop
                if (!$process.WaitForExit(10000)) { $allStopped = $false }
            }
        }
        catch {
            $allStopped = $false
            Write-Warning "Could not stop an owned test process; retaining its artifacts."
        }
    }
    return $allStopped
}

function Set-WarTestTemporaryDirectory([string]$Run) {
    $artifactTool = Join-Path $PSScriptRoot 'test_artifacts.py'
    $temporary = & python $artifactTool temp-root $Run
    if ($LASTEXITCODE -ne 0) {
        throw 'Could not validate owned temporary test storage.'
    }
    foreach ($name in @('TEMP', 'TMP', 'TMPDIR')) {
        [Environment]::SetEnvironmentVariable($name, [string]$temporary, 'Process')
    }
}

function Complete-WarTestRun([string]$Run, [bool]$Succeeded, [bool]$KeepArtifacts) {
    $artifactTool = Join-Path $PSScriptRoot 'test_artifacts.py'
    $status = if ($Succeeded) { 'passed' } else { 'failed' }
    $arguments = @($artifactTool, 'finish', $Run, '--status', $status)
    if ($KeepArtifacts) { $arguments += '--keep' }
    & python @arguments
    if ($LASTEXITCODE -ne 0) { Write-Warning 'Artifact finalization failed; files were retained.' }
    & python $artifactTool prune --apply
    if ($LASTEXITCODE -ne 0) { Write-Warning 'Artifact retention was deferred.' }
}
