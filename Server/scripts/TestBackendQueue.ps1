param(
    [string]$MongoExecutable = 'mongod',
    [ValidateRange(1024, 65535)][int]$MongoPort = 27030,
    [switch]$NoBuild,
    [switch]$KeepArtifacts
)

$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
. (Join-Path $PSScriptRoot 'TestRun.ps1')
$runRoot = New-WarTestRun 'backend-queue'
$prior = @{}
foreach ($name in @('TEMP', 'TMP', 'TMPDIR')) {
    $prior[$name] = [Environment]::GetEnvironmentVariable($name, 'Process')
}
$processes = @()
$testProcess = $null
$succeeded = $false

try {
    if (!$NoBuild) {
        & dotnet build (Join-Path $serverRoot 'WarFriendsServer.sln') -c Release --nologo -v minimal
        if ($LASTEXITCODE -ne 0) { throw 'Release build failed.' }
    }
    foreach ($name in @('War.Backend', 'War.BattleServer')) {
        $dll = Join-Path $serverRoot "src/$name/bin/Release/net10.0/$name.dll"
        if (!(Test-Path -LiteralPath $dll)) { throw 'Build Release hosts before -NoBuild.' }
    }
    $testDll = Join-Path $serverRoot 'tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll'
    if (!(Test-Path -LiteralPath $testDll)) { throw 'Build the Release test console before -NoBuild.' }
    Set-WarTestTemporaryDirectory $runRoot
    $mongoPath = Join-Path $runRoot 'data/mongo'
    New-Item -ItemType Directory -Path $mongoPath -Force | Out-Null
    $mongoArgs = @('--dbpath', ('"' + $mongoPath + '"'), '--bind_ip', '127.0.0.1',
        '--port', "$MongoPort", '--replSet', 'wfQueue',
        '--logpath', ('"' + (Join-Path $runRoot 'mongo.log') + '"'))
    $mongo = Start-Process $MongoExecutable -ArgumentList $mongoArgs -PassThru -WindowStyle Hidden
    $processes += $mongo
    $directUri = "mongodb://127.0.0.1:$MongoPort/?directConnection=true"
    & dotnet $testDll --init-mongo-replica-set $directUri wfQueue "127.0.0.1:$MongoPort"
    if ($LASTEXITCODE -ne 0) { throw 'Queue smoke replica-set initiation failed.' }

    $uri = "mongodb://127.0.0.1:$MongoPort/?replicaSet=wfQueue"
    $arguments = @(('"' + $testDll + '"'), '--queue-live', ('"' + $uri + '"'))
    $testProcess = Start-Process dotnet -ArgumentList $arguments -WorkingDirectory $serverRoot `
        -PassThru -WindowStyle Hidden `
        -RedirectStandardOutput (Join-Path $runRoot 'queue.log') `
        -RedirectStandardError (Join-Path $runRoot 'queue.error.log')
    $processes += $testProcess
    if (!$testProcess.WaitForExit(600000)) {
        # Only this explicitly started console and its descendants are terminated.
        & "$env:SystemRoot/System32/taskkill.exe" /PID $testProcess.Id /T /F | Out-Null
        $testProcess.WaitForExit()
        throw 'Owned queue test exceeded its ten-minute deadline.'
    }
    Get-Content -LiteralPath (Join-Path $runRoot 'queue.log') -Tail 25
    if ($testProcess.ExitCode -ne 0) {
        Get-Content -LiteralPath (Join-Path $runRoot 'queue.error.log') -Tail 20
        throw 'Backend queue/reconnect/rematch checks failed.'
    }

    $succeeded = $true
    @{ suite = 'backend-queue'; configuration = 'Release'; exitCode = $testProcess.ExitCode } |
        ConvertTo-Json | Set-Content -LiteralPath (Join-Path $runRoot 'results.json') -Encoding UTF8
    Write-Host "PASS: Release Backend/Worker queue lifecycle. Reports: $runRoot"
}
finally {
    $stopped = Stop-WarTestProcesses $processes
    Restore-WarTestEnvironment $prior
    if ($stopped) { Complete-WarTestRun $runRoot $succeeded $KeepArtifacts.IsPresent }
}
