# Runs the recovered Splash-to-MainScene chain against an isolated native Backend.
param(
    [Parameter(Mandatory = $true)][string]$UnityExecutable,
    [Parameter(Mandatory = $true)][string]$UnityProject,
    [string]$MongoExecutable = 'mongod',
    [switch]$ExportStarterLoadout,
    [switch]$VerifyReturningPlayer,
    [switch]$VerifyNormalQueue,
    [string]$SecondUnityProject,
    [ValidateRange(5, 120)][Nullable[int]]$PairAdmissionSeconds,
    [switch]$KeepArtifacts
)
$ErrorActionPreference = 'Stop'
if ($VerifyNormalQueue) { $VerifyReturningPlayer = $true }
$serverRoot = Split-Path $PSScriptRoot -Parent
. (Join-Path $PSScriptRoot 'TestRun.ps1')
$projectPath = (Resolve-Path -LiteralPath $UnityProject).Path
$validationRoot = [IO.Path]::GetFullPath((Join-Path $serverRoot '.local')) + [IO.Path]::DirectorySeparatorChar
if (!$projectPath.StartsWith($validationRoot, [StringComparison]::OrdinalIgnoreCase)) {
    throw 'Use a disposable Unity project under Server/.local.'
}
$editorFolder = Join-Path $projectPath 'Assets/Editor'
New-Item -ItemType Directory -Path $editorFolder -Force | Out-Null
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityNormalClientBootAudit.cs') -Destination $editorFolder
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityNormalMatchmakingReadinessAudit.cs') -Destination $editorFolder
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityNormalBattleEntryAudit.cs') -Destination $editorFolder
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityNormalBattleReconnectAudit.cs') -Destination $editorFolder
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityNormalWeaponSelectionAudit.cs') -Destination $editorFolder
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityNormalReloadAudit.cs') -Destination $editorFolder
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityNormalTerminalAudit.cs') -Destination $editorFolder
Copy-Item -LiteralPath (Join-Path $serverRoot 'tools/UnityStarterLoadoutExport.cs') -Destination $editorFolder
$runRoot = New-WarTestRun 'client-boot'
$mongoPath = Join-Path $runRoot 'data/mongo'
$succeeded = $false
$processes = @()
$variables = @(
    'TEMP', 'TMP', 'TMPDIR', 'ASPNETCORE_ENVIRONMENT', 'ASPNETCORE_URLS', 'Mongo__Uri', 'Mongo__Database',
    'Battle__SigningKey', 'Battle__ControlKey', 'Legacy__ContentPath',
    'WARFRIENDS_BACKEND_URL', 'WAR_LOBBY_BOOT_REQUIRE_ACCOUNT', 'WAR_STARTER_LOADOUT_OUTPUT',
    'WAR_LOBBY_BOOT_IDENTITY', 'WAR_NORMAL_QUEUE_REPORT', 'WAR_NORMAL_BATTLE_SELF', 'WAR_NORMAL_BATTLE_PEER',
    'Battle__Port', 'Battle__ControlPort', 'Battle__ControlEndpoint', 'Battle__ServerId', 'Battle__PublicHost',
    'Battle__BindAddress', 'Battle__ResultOutboxPath', 'Battle__BackendResultEndpoint'
)
$battleContentFiles = @{
    'Combat' = 'combat'; 'Shotgun' = 'shotgun'; 'Smg' = 'smg'; 'Pistol' = 'pistol';
    'Lmg' = 'lmg'; 'Minigun' = 'minigun'; 'Sniper' = 'sniper'; 'Bazooka' = 'bazooka'; 'Grenade' = 'grenade'
}
$variables += @('Battle__MatchmakingCompatibilityKey', 'Battle__MatchManifestTemplatePath')
foreach ($family in $battleContentFiles.Keys) { $variables += "Battle__${family}ContentManifestPath" }
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
function Get-FreeUdpPort {
    $socket = [Net.Sockets.Socket]::new(
        [Net.Sockets.AddressFamily]::InterNetwork,
        [Net.Sockets.SocketType]::Dgram,
        [Net.Sockets.ProtocolType]::Udp)
    try {
        $socket.Bind([Net.IPEndPoint]::new([Net.IPAddress]::Any, 0))
        return $socket.LocalEndPoint.Port
    }
    finally { $socket.Dispose() }
}
try {
    Set-WarTestTemporaryDirectory $runRoot
    New-Item -ItemType Directory -Path $mongoPath -Force | Out-Null
    dotnet build (Join-Path $serverRoot 'WarFriendsServer.sln') -c Release --no-restore --nologo -v minimal
    if ($LASTEXITCODE -ne 0) { throw 'Release build failed.' }
    $mongoPort = Get-FreePort
    $httpPort = Get-FreePort
    while ($httpPort -eq $mongoPort) { $httpPort = Get-FreePort }
    $mongoArguments = @(
        '--bind_ip', '127.0.0.1', '--port', $mongoPort, '--dbpath', ('"' + $mongoPath + '"'),
        '--replSet', 'wfClientBoot', '--logpath', ('"' + (Join-Path $runRoot 'mongo.log') + '"'), '--logappend'
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
    if ($VerifyNormalQueue -or $SecondUnityProject) {
        $env:Battle__MatchmakingCompatibilityKey = 'unscored-starter.fixture'
        $env:Battle__MatchManifestTemplatePath = Join-Path $serverRoot 'content/local-starter-match-template.json'
        if ($SecondUnityProject -and $null -ne $PairAdmissionSeconds) {
            $template = [System.Text.Json.Nodes.JsonNode]::Parse(
                [IO.File]::ReadAllText($env:Battle__MatchManifestTemplatePath))
            $template['AdmissionSeconds'] = [System.Text.Json.Nodes.JsonNode]::Parse(
                $PairAdmissionSeconds.ToString([Globalization.CultureInfo]::InvariantCulture))
            $diagnosticTemplate = Join-Path $runRoot 'diagnostic-starter-template.json'
            [IO.File]::WriteAllText($diagnosticTemplate, $template.ToJsonString() + "`n",
                [Text.UTF8Encoding]::new($false))
            $env:Battle__MatchManifestTemplatePath = $diagnosticTemplate
            Write-Output "Diagnostic pair admission window: $PairAdmissionSeconds seconds; repository template unchanged."
        }
        foreach ($family in $battleContentFiles.Keys) {
            $manifest = Join-Path $serverRoot ("content/" + $battleContentFiles[$family] + '-content-manifest.json')
            [Environment]::SetEnvironmentVariable("Battle__${family}ContentManifestPath", $manifest, 'Process')
        }
        if ($SecondUnityProject) {
            $env:Battle__Port = Get-FreeUdpPort
            do { $env:Battle__ControlPort = Get-FreePort }
            while ($env:Battle__ControlPort -eq $env:Battle__Port)
            $env:Battle__ControlEndpoint = "http://127.0.0.1:$($env:Battle__ControlPort)/internal/matches"
            $env:Battle__ServerId = 'local-1'
            $env:Battle__PublicHost = '127.0.0.1'
            $env:Battle__BindAddress = '127.0.0.1'
            $env:Battle__ResultOutboxPath = Join-Path $runRoot 'outbox'
            $env:Battle__BackendResultEndpoint = "http://127.0.0.1:$httpPort/internal/battle/results/accept"
        }
    }
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
    $env:WAR_NORMAL_QUEUE_REPORT = $null
    $env:WAR_NORMAL_BATTLE_SELF = $null
    $env:WAR_NORMAL_BATTLE_PEER = $null
    $env:WAR_LOBBY_BOOT_IDENTITY = 'NormalBoot-' + [Guid]::NewGuid().ToString('N')
    $env:WAR_STARTER_LOADOUT_OUTPUT = $null
    if ($ExportStarterLoadout) {
        # The Editor exporter deliberately restricts writes to a disposable Server/.local project.
        # Give this run a unique scratch file, then retain the validated result in managed storage.
        $starterScratch = Join-Path $projectPath ((Split-Path $runRoot -Leaf) + '-starter-loadout.json')
        $env:WAR_STARTER_LOADOUT_OUTPUT = $starterScratch
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
        Copy-Item -LiteralPath $starterScratch -Destination (Join-Path $runRoot 'starter-loadout.json')
        Remove-Item -LiteralPath $starterScratch
    }
    if ($SecondUnityProject) {
        & (Join-Path $PSScriptRoot 'NormalUnityPairSmoke.ps1') -UnityExecutable $UnityExecutable `
            -FirstProject $projectPath -SecondProject $SecondUnityProject -RunRoot $runRoot -TestDll $testDll
    }
    elseif ($VerifyReturningPlayer) {
        dotnet $testDll --seed-returning-boot-player $env:Mongo__Uri $env:Mongo__Database `
            (Join-Path $runRoot 'returning-player-fixture.json')
        if ($LASTEXITCODE -ne 0) { throw 'Returning-player fixture creation failed.' }
        if ($VerifyNormalQueue) {
            $env:WAR_NORMAL_QUEUE_REPORT = Join-Path $runRoot 'normal-queue.json'
            $queueArguments = @(
                ('"' + $testDll + '"'), '--watch-normal-unity-queue', $env:Mongo__Uri, $env:Mongo__Database,
                ('"' + $env:WAR_NORMAL_QUEUE_REPORT + '"')
            )
            $queueObserver = Start-Process dotnet -ArgumentList $queueArguments -WindowStyle Hidden -PassThru `
                -RedirectStandardOutput (Join-Path $runRoot 'QueueObserver.log') `
                -RedirectStandardError (Join-Path $runRoot 'QueueObserver.error.log')
            $processes += $queueObserver
            for ($attempt = 0; $attempt -lt 100 -and
                !(Test-Path -LiteralPath ($env:WAR_NORMAL_QUEUE_REPORT + '.ready')); $attempt++) {
                if ($queueObserver.HasExited) { throw 'Normal queue observer exited before readiness.' }
                Start-Sleep -Milliseconds 100
            }
            if (!(Test-Path -LiteralPath ($env:WAR_NORMAL_QUEUE_REPORT + '.ready'))) {
                throw 'Normal queue observer did not become ready.'
            }
        }
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
        if ($VerifyNormalQueue) {
            if (!$queueObserver.WaitForExit(10000) -or $queueObserver.ExitCode -ne 0 -or
                !$returning.normalQueueStarted -or !$returning.normalQueueObserved) {
                throw "Normal controller queue admission was not observed; inspect $runRoot"
            }
            Write-Output 'PASS: normal Unity DeathMatch controller reached the real Backend queue'
        }
    }
    $succeeded = $true
    Write-Output "PASS: actual isolated Client account/unit initialization boundary; $runRoot"
}
finally {
    [array]::Reverse($processes)
    $stopped = Stop-WarTestProcesses $processes
    Restore-WarTestEnvironment $prior
    if ($stopped) { Complete-WarTestRun $runRoot $succeeded $KeepArtifacts.IsPresent }
    foreach ($process in $processes) { $process.Dispose() }
}
