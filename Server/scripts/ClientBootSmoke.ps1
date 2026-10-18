# Runs the recovered Splash-to-MainScene chain against an isolated native Backend.
param(
    [Parameter(Mandatory = $true)][string]$UnityExecutable,
    [Parameter(Mandatory = $true)][string]$UnityProject,
    [string]$MongoExecutable = 'mongod',
    [switch]$ExportStarterLoadout,
    [switch]$VerifyReturningPlayer
)
$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
$projectPath = (Resolve-Path -LiteralPath $UnityProject).Path
$validationRoot = [IO.Path]::GetFullPath((Join-Path $serverRoot '.local')) + [IO.Path]::DirectorySeparatorChar
if (!$projectPath.StartsWith($validationRoot, [StringComparison]::OrdinalIgnoreCase)) {
    throw 'Use a disposable Unity project under Server/.local.'
}
$editorFolder = Join-Path $projectPath 'Assets/Editor'
New-Item -ItemType Directory -Path $editorFolder -Force | Out-Null
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityNormalClientBootAudit.cs') -Destination $editorFolder
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityNormalMatchmakingReadinessAudit.cs') -Destination $editorFolder
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityStarterLoadoutExport.cs') -Destination $editorFolder
$runRoot = Join-Path $validationRoot ('client-boot-' + [Guid]::NewGuid().ToString('N'))
$mongoPath = Join-Path $runRoot 'mongo'
New-Item -ItemType Directory -Path $mongoPath -Force | Out-Null
$processes = @()
$variables = @(
    'ASPNETCORE_ENVIRONMENT', 'ASPNETCORE_URLS', 'Mongo__Uri', 'Mongo__Database',
    'Battle__SigningKey', 'Battle__ControlKey', 'Legacy__ContentPath',
    'WARFRIENDS_BACKEND_URL', 'WAR_LOBBY_BOOT_REQUIRE_ACCOUNT', 'WAR_STARTER_LOADOUT_OUTPUT',
    'WAR_LOBBY_BOOT_IDENTITY'
)
$prior = @{}
foreach ($name in $variables) {
    $prior[$name] = [Environment]::GetEnvironmentVariable($name, 'Process')
}
function Get-FreePort {
    $listener = [Net.Sockets.TcpListener]::new([Net.IPAddress]::Loopback, 0)
    $listener.Start()
    try { return $listener.LocalEndpoint.Port }
    finally { $listener.Stop() }
}
function New-SigningKey {
    $bytes = New-Object byte[] 32
    $generator = [Security.Cryptography.RandomNumberGenerator]::Create()
    try { $generator.GetBytes($bytes) }
    finally { $generator.Dispose() }
    return [Convert]::ToBase64String($bytes)
}
try {
    dotnet build (Join-Path $serverRoot 'WarFriendsServer.sln') -c Release --no-restore --nologo -v minimal
    if ($LASTEXITCODE -ne 0) { throw 'Release build failed.' }
    $mongoPort = Get-FreePort
    $httpPort = Get-FreePort
    while ($httpPort -eq $mongoPort) { $httpPort = Get-FreePort }
    $mongoArguments = @(
        '--bind_ip', '127.0.0.1', '--port', $mongoPort, '--dbpath', $mongoPath,
        '--replSet', 'wfClientBoot', '--logpath', (Join-Path $runRoot 'mongo.log'), '--logappend'
    )
    $mongo = Start-Process $MongoExecutable -ArgumentList $mongoArguments -WindowStyle Hidden -PassThru
    $processes += $mongo
    $testDll = Join-Path $serverRoot 'tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll'
    dotnet $testDll --init-mongo-replica-set "mongodb://127.0.0.1:$mongoPort/?directConnection=true" `
        wfClientBoot "127.0.0.1:$mongoPort"
    if ($LASTEXITCODE -ne 0) { throw 'Mongo initialization failed.' }
    $env:ASPNETCORE_ENVIRONMENT = 'Development'
    $env:ASPNETCORE_URLS = "http://127.0.0.1:$httpPort"
    $env:Mongo__Uri = "mongodb://127.0.0.1:$mongoPort/?replicaSet=wfClientBoot"
    $env:Mongo__Database = 'war_client_boot_' + [Guid]::NewGuid().ToString('N')
    $env:Battle__SigningKey = New-SigningKey
    $env:Battle__ControlKey = New-SigningKey
    $env:Legacy__ContentPath = Join-Path $serverRoot 'content/recovered-battle-content.json'
    $backendDll = Join-Path $serverRoot 'src/War.Backend/bin/Release/net10.0/War.Backend.dll'
    $backend = Start-Process dotnet -ArgumentList ('"' + $backendDll + '"') -WindowStyle Hidden -PassThru `
        -WorkingDirectory (Split-Path $backendDll -Parent) `
        -RedirectStandardOutput (Join-Path $runRoot 'Backend.log') `
        -RedirectStandardError (Join-Path $runRoot 'Backend.error.log')
    $processes += $backend
    $ready = $false
    for ($attempt = 0; $attempt -lt 100; $attempt++) {
        if ($backend.HasExited) { throw "Backend exited; inspect $runRoot" }
        try {
            $null = Invoke-WebRequest "http://127.0.0.1:$httpPort/health/ready" -UseBasicParsing -TimeoutSec 1
            $ready = $true
            break
        }
        catch { Start-Sleep -Milliseconds 200 }
    }
    if (!$ready) { throw "Backend readiness timed out; inspect $runRoot" }
    $initialReport = Join-Path $runRoot 'initial-state-insert.json'
    $watchArguments = @(
        ('"' + $testDll + '"'), '--watch-initial-loadout', $env:Mongo__Uri, $env:Mongo__Database,
        ('"' + $initialReport + '"')
    )
    $watcher = Start-Process dotnet -ArgumentList $watchArguments -WindowStyle Hidden -PassThru `
        -RedirectStandardOutput (Join-Path $runRoot 'InitialStateWatcher.log') `
        -RedirectStandardError (Join-Path $runRoot 'InitialStateWatcher.error.log')
    $processes += $watcher
    for ($attempt = 0; $attempt -lt 100 -and !(Test-Path -LiteralPath ($initialReport + '.ready')); $attempt++) {
        if ($watcher.HasExited) { throw "Initial account observer exited before readiness; inspect $runRoot" }
        Start-Sleep -Milliseconds 100
    }
    if (!(Test-Path -LiteralPath ($initialReport + '.ready'))) { throw 'Initial account observer did not become ready.' }
    $env:WARFRIENDS_BACKEND_URL = "http://127.0.0.1:$httpPort/"
    $env:WAR_LOBBY_BOOT_REQUIRE_ACCOUNT = '1'
    $env:WAR_LOBBY_BOOT_IDENTITY = 'NormalBoot-' + [Guid]::NewGuid().ToString('N')
    $env:WAR_STARTER_LOADOUT_OUTPUT = $null
    if ($ExportStarterLoadout) {
        $env:WAR_STARTER_LOADOUT_OUTPUT = Join-Path $runRoot 'starter-loadout.json'
    }
    $reportPath = Join-Path $projectPath 'normal-client-boot.json'
    if (Test-Path -LiteralPath $reportPath) { Remove-Item -LiteralPath $reportPath }
    $unityArguments = @(
        '-batchmode', '-nographics', '-noUpm', '-projectPath', ('"' + $projectPath + '"'),
        '-executeMethod', 'UnityNormalClientBootAudit.Run', '-logFile', ('"' + (Join-Path $runRoot 'Unity.log') + '"')
    )
    $editor = Start-Process $UnityExecutable -ArgumentList $unityArguments -WindowStyle Hidden -PassThru
    $processes += $editor
    if (!$editor.WaitForExit(150000)) { throw "Owned Editor timed out; inspect $runRoot" }
    if (Test-Path -LiteralPath $reportPath) {
        Copy-Item -LiteralPath $reportPath -Destination (Join-Path $runRoot 'report.json')
    }
    if ($editor.ExitCode -ne 0) { throw "Actual Client account boot failed; inspect $runRoot" }
    if (!$watcher.WaitForExit(10000) -or $watcher.ExitCode -ne 0) {
        throw "Initial account insert did not contain complete source state; inspect $runRoot"
    }
    $initialState = Get-Content -LiteralPath $initialReport -Raw | ConvertFrom-Json
    if (!$initialState.hasCompleteInitialStateInInsert -or $initialState.subsystemCount -ne 3 -or
        !$initialState.hasStarterBattlePresentation -or $initialState.weaponCount -ne 4 -or $initialState.unitCount -ne 4) {
        throw "Initial account insertion evidence is incomplete; inspect $runRoot"
    }
    $report = Get-Content -LiteralPath $reportPath -Raw | ConvertFrom-Json
    if (!$report.mainSceneLoaded -or !$report.accountDataReady -or !$report.playerNetworkReady -or
        !$report.playerDataLoadComplete -or $report.initializedUnitRows -ne $report.recoveredUnitRows -or
        !$report.cardDefinitionsReady -or !$report.matchmakingReadiness.canEvaluate -or
        $report.invalidBootstrapQueries -ne 0 -or
        $report.initializedWeaponRows -ne $report.recoveredWeaponRows -or
        $report.recoveredUnitRows -le 0 -or $report.exceptions -ne 0) {
        throw "Client readiness evidence is incomplete; inspect $runRoot"
    }
    if ($ExportStarterLoadout) {
        $starter = Get-Content -LiteralPath $env:WAR_STARTER_LOADOUT_OUTPUT -Raw | ConvertFrom-Json
        if ($starter.schemaVersion -ne 1 -or $starter.weapons.Count -ne $report.recoveredWeaponRows -or
            $starter.units.Count -ne $report.recoveredUnitRows -or $starter.hasMetadataSideEffects -or
            $starter.weaponIndexChecks -ne (2 * $report.recoveredWeaponRows + 1)) {
            throw "Starter export is incomplete; inspect $runRoot"
        }
    }
    if ($VerifyReturningPlayer) {
        dotnet $testDll --seed-returning-boot-player $env:Mongo__Uri $env:Mongo__Database `
            (Join-Path $runRoot 'returning-player-fixture.json')
        if ($LASTEXITCODE -ne 0) { throw 'Returning-player fixture creation failed.' }
        Remove-Item -LiteralPath $reportPath
        $returningArguments = @(
            '-batchmode', '-nographics', '-noUpm', '-projectPath', ('"' + $projectPath + '"'),
            '-executeMethod', 'UnityNormalClientBootAudit.Run',
            '-logFile', ('"' + (Join-Path $runRoot 'Unity-returning.log') + '"')
        )
        $returningEditor = Start-Process $UnityExecutable -ArgumentList $returningArguments `
            -WindowStyle Hidden -PassThru
        $processes += $returningEditor
        if (!$returningEditor.WaitForExit(150000)) { throw 'Returning-player Editor timed out.' }
        if (Test-Path -LiteralPath $reportPath) {
            Copy-Item -LiteralPath $reportPath -Destination (Join-Path $runRoot 'returning-report.json')
        }
        if ($returningEditor.ExitCode -ne 0) { throw "Returning-player boot failed; inspect $runRoot" }
        $returning = Get-Content -LiteralPath $reportPath -Raw | ConvertFrom-Json
        if (!$returning.playerDataLoadComplete -or $returning.exceptions -ne 0 -or
            !$returning.matchmakingReadiness.canEvaluate -or
            !$returning.matchmakingReadiness.canUseSelfHostedMatchmaking -or
            $returning.matchmakingReadiness.displayRank -ne 5 -or
            $returning.matchmakingReadiness.averageFps -ne 30) {
            throw "Returning-player normal data loading did not retain the fixture; inspect $runRoot"
        }
        Write-Output 'PASS: returning-player normal login satisfies recovered self-hosted matchmaking conditions'
    }
    Write-Output "PASS: actual isolated Client account/unit initialization boundary; $runRoot"
}
finally {
    [array]::Reverse($processes)
    foreach ($process in $processes) {
        if (!$process.HasExited) {
            Stop-Process -Id $process.Id
            $process.WaitForExit(5000) | Out-Null
        }
        $process.Dispose()
    }
    foreach ($name in $variables) {
        [Environment]::SetEnvironmentVariable($name, $prior[$name], 'Process')
    }
}
