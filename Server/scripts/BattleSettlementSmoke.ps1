param(
    [string]$MongoExecutable = 'mongod',
    [int]$MongoPort = 27038,
    [switch]$NoBuild,
    [switch]$KeepArtifacts
)
$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
. (Join-Path $PSScriptRoot 'TestRun.ps1')
$run = New-WarTestRun 'battle-settlement'
$passed = $false
$processes = @()
try {
    $project = Join-Path $serverRoot 'tests/War.Battle.Tests/War.Battle.Tests.csproj'
    if (!$NoBuild) {
        dotnet build $project -c Release --no-restore -v quiet
        if ($LASTEXITCODE -ne 0) { throw 'Settlement test build failed.' }
    }
    $dll = Join-Path $serverRoot 'tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll'
    $data = Join-Path $run 'data/mongo'
    New-Item -ItemType Directory -Path $data -Force | Out-Null
    $arguments = @('--dbpath', ('"' + $data + '"'), '--bind_ip', '127.0.0.1',
        '--port', "$MongoPort", '--replSet', 'wfSettlement',
        '--logpath', ('"' + (Join-Path $run 'mongo.log') + '"'))
    $processes += Start-Process $MongoExecutable -ArgumentList $arguments -PassThru -WindowStyle Hidden
    dotnet $dll --init-mongo-replica-set "mongodb://127.0.0.1:$MongoPort/?directConnection=true" `
        wfSettlement "127.0.0.1:$MongoPort"
    if ($LASTEXITCODE -ne 0) { throw 'Settlement replica-set initialization failed.' }
    dotnet $dll --battle-settlement-store-only "mongodb://127.0.0.1:$MongoPort/?replicaSet=wfSettlement" `
        (Join-Path $serverRoot 'content')
    if ($LASTEXITCODE -ne 0) { throw 'Settlement transaction checks failed.' }
    $passed = $true
}
finally {
    $stopped = Stop-WarTestProcesses $processes
    Complete-WarTestRun $run ($passed -and $stopped) ($KeepArtifacts -or !$stopped)
}
