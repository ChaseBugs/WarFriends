# Extends ClientBootSmoke's owned Backend/database with two normal Unity battle participants.
param(
    [Parameter(Mandatory = $true)][string]$UnityExecutable,
    [Parameter(Mandatory = $true)][string]$FirstProject,
    [Parameter(Mandatory = $true)][string]$SecondProject,
    [Parameter(Mandatory = $true)][string]$RunRoot,
    [Parameter(Mandatory = $true)][string]$TestDll
)
$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
$validationRoot = [IO.Path]::GetFullPath((Join-Path $serverRoot '.local')) + [IO.Path]::DirectorySeparatorChar
$secondPath = (Resolve-Path -LiteralPath $SecondProject).Path
if (!$secondPath.StartsWith($validationRoot, [StringComparison]::OrdinalIgnoreCase) -or
    $secondPath -eq $FirstProject -or !$env:Mongo__Database.StartsWith('war_client_boot_')) {
    throw 'Use two distinct disposable projects and the isolated parent boot database.'
}
$owned = @()
$previousContentPath = $env:Battle__ContentPath
$previousReconnectMarker = $env:WAR_NORMAL_BATTLE_RECONNECT_MARKER
$previousReconnectSelf = $env:WAR_NORMAL_BATTLE_RECONNECT_SELF
$firstIdentity = $env:WAR_LOBBY_BOOT_IDENTITY
$secondIdentity = 'NormalBoot-' + [Guid]::NewGuid().ToString('N')
function Start-OwnedUnity([string]$project, [string]$identity, [string]$label) {
    $env:WAR_LOBBY_BOOT_IDENTITY = $identity
    $report = Join-Path $project 'normal-client-boot.json'
    if (Test-Path -LiteralPath $report) { Remove-Item -LiteralPath $report }
    $arguments = @(
        '-noUpm', '-projectPath', ('"' + $project + '"'),
        '-executeMethod', 'UnityNormalClientBootAudit.Run',
        '-logFile', ('"' + (Join-Path $RunRoot ($label + '.log')) + '"')
    )
    # Recovered RadicalRoutine requires frame-end rendering during normal battle loading.
    if (!$env:WAR_NORMAL_BATTLE_SELF) {
        $arguments = @('-batchmode', '-nographics') + $arguments
    }
    return Start-Process $UnityExecutable -ArgumentList $arguments -WindowStyle Hidden -PassThru
}
function Complete-OwnedUnity($process, [string]$project, [string]$label) {
    if (!$process.WaitForExit(240000)) { throw "Owned Unity timed out: $label" }
    $source = Join-Path $project 'normal-client-boot.json'
    if (Test-Path -LiteralPath $source) {
        Copy-Item -LiteralPath $source -Destination (Join-Path $RunRoot ($label + '.json'))
    }
    if ($process.ExitCode -ne 0) { throw "Owned Unity failed: $label; inspect $RunRoot" }
}
try {
    $editorFolder = Join-Path $secondPath 'Assets/Editor'
    New-Item -ItemType Directory -Path $editorFolder -Force | Out-Null
    foreach ($name in @('UnityNormalClientBootAudit', 'UnityNormalMatchmakingReadinessAudit',
        'UnityNormalBattleEntryAudit', 'UnityNormalBattleReconnectAudit', 'UnityStarterLoadoutExport')) {
        Copy-Item -LiteralPath (Join-Path $serverRoot ("tools/$name.cs")) -Destination $editorFolder
    }
    $secondBoot = Start-OwnedUnity $secondPath $secondIdentity 'Unity-second-boot'
    $owned += $secondBoot
    Complete-OwnedUnity $secondBoot $secondPath 'Unity-second-boot'
    $initial = Get-Content (Join-Path $RunRoot 'Unity-second-boot.json') -Raw | ConvertFrom-Json
    if (!$initial.playerDataLoadComplete -or $initial.exceptions -ne 0) {
        throw 'Second identity did not complete ordinary account initialization.'
    }
    dotnet $TestDll --seed-returning-boot-pair $env:Mongo__Uri $env:Mongo__Database `
        (Join-Path $RunRoot 'returning-pair-fixture.json')
    if ($LASTEXITCODE -ne 0) { throw 'Returning pair fixture failed.' }

    $workerDll = Join-Path $serverRoot 'src/War.BattleServer/bin/Release/net10.0/War.BattleServer.dll'
    $env:Battle__ContentPath = Join-Path $serverRoot 'content/recovered-battle-content.json'
    $worker = Start-Process dotnet -ArgumentList ('"' + $workerDll + '"') -WindowStyle Hidden -PassThru `
        -WorkingDirectory (Split-Path $workerDll -Parent) `
        -RedirectStandardOutput (Join-Path $RunRoot 'Worker.log') `
        -RedirectStandardError (Join-Path $RunRoot 'Worker.error.log')
    $owned += $worker
    $ready = $false
    for ($attempt = 0; $attempt -lt 100; $attempt++) {
        if ($worker.HasExited) { throw 'Owned battle Worker exited before readiness.' }
        try {
            $null = Invoke-WebRequest "http://127.0.0.1:$($env:Battle__ControlPort)/health/ready" `
                -UseBasicParsing -TimeoutSec 1
            $ready = $true
            break
        }
        catch { Start-Sleep -Milliseconds 200 }
    }
    if (!$ready) { throw 'Owned battle Worker did not become ready.' }
    $firstRunning = Join-Path $RunRoot 'first-running.json'
    $secondRunning = Join-Path $RunRoot 'second-running.json'
    $env:WAR_NORMAL_BATTLE_SELF = $firstRunning
    $env:WAR_NORMAL_BATTLE_PEER = $secondRunning
    $env:WAR_NORMAL_BATTLE_RECONNECT_MARKER = Join-Path $RunRoot 'reconnect-complete.json'
    $env:WAR_NORMAL_BATTLE_RECONNECT_SELF = '1'
    $first = Start-OwnedUnity $FirstProject $firstIdentity 'Unity-first-battle'
    $owned += $first
    $env:WAR_NORMAL_BATTLE_SELF = $secondRunning
    $env:WAR_NORMAL_BATTLE_PEER = $firstRunning
    $env:WAR_NORMAL_BATTLE_RECONNECT_SELF = '0'
    $second = Start-OwnedUnity $secondPath $secondIdentity 'Unity-second-battle'
    $owned += $second
    Complete-OwnedUnity $first $FirstProject 'Unity-first-battle'
    Complete-OwnedUnity $second $secondPath 'Unity-second-battle'
    $reports = @('Unity-first-battle', 'Unity-second-battle') | ForEach-Object {
        Get-Content (Join-Path $RunRoot ($_ + '.json')) -Raw | ConvertFrom-Json
    }
    foreach ($report in $reports) {
        if (!$report.normalBattle.hasReachedRunning -or !$report.normalBattle.hasSubmittedCards -or
            $report.normalBattle.players -ne 2 -or $report.exceptions -ne 0 -or
            !$report.normalBattle.reconnect.hasCompleted) {
            throw "Normal two-Unity entry did not reach running; inspect $RunRoot"
        }
    }
    if (!$reports[0].normalBattle.matchId -or
        $reports[0].normalBattle.matchId -ne $reports[1].normalBattle.matchId) {
        throw 'Normal Unity participants did not observe the same authoritative match.'
    }
    $reconnect = $reports[0].normalBattle.reconnect
    if (!$reconnect.isInitiator -or !$reconnect.hasStarted -or $reconnect.rebuildCount -ne 1 -or
        $reconnect.failureType -or $reports[1].normalBattle.reconnect.isInitiator) {
        throw 'Normal Unity reconnect did not complete the designated one-peer snapshot rebuild.'
    }
    Write-Output "PASS: two normal Unity controllers reached Running and completed live reconnect; $RunRoot"
}
finally {
    [array]::Reverse($owned)
    foreach ($process in $owned) {
        if (!$process.HasExited) { Stop-Process -Id $process.Id }
        $process.Dispose()
    }
    $env:WAR_LOBBY_BOOT_IDENTITY = $firstIdentity
    $env:WAR_NORMAL_BATTLE_SELF = $null
    $env:WAR_NORMAL_BATTLE_PEER = $null
    $env:Battle__ContentPath = $previousContentPath
    $env:WAR_NORMAL_BATTLE_RECONNECT_MARKER = $previousReconnectMarker
    $env:WAR_NORMAL_BATTLE_RECONNECT_SELF = $previousReconnectSelf
}
