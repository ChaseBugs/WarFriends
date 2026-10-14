param(
    [string]$UnityExecutable = 'C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe',
    [string]$ProbeRoot = (Join-Path $env:TEMP ('WarFriends-PvpBonusAreas-' + [guid]::NewGuid().ToString('N')))
)
$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
python (Join-Path $serverRoot 'tools/prepare_pvp_bonus_spawn_area_probe.py') $ProbeRoot
if ($LASTEXITCODE -ne 0) { throw 'Source bonus area probe preparation failed.' }
$output = Join-Path $serverRoot 'content/unity-pvp-bonus-spawn-areas-reference.json'
$prior = $env:WAR_PVP_BONUS_AREAS_OUTPUT
$env:WAR_PVP_BONUS_AREAS_OUTPUT = $output
try {
    $log = Join-Path $ProbeRoot 'Editor.log'
    $arguments = @('-batchmode', '-nographics', '-quit', '-projectPath',
        ('"' + $ProbeRoot + '"'), '-executeMethod', 'UnityPvpBonusSpawnAreaAudit.Run',
        '-logFile', ('"' + $log + '"'))
    $process = Start-Process -FilePath $UnityExecutable -ArgumentList $arguments -PassThru -WindowStyle Hidden
    $deadline = [DateTime]::UtcNow.AddMinutes(3)
    while (!$process.WaitForExit(1000)) {
        if ([DateTime]::UtcNow -ge $deadline) {
            $process.Kill()
            throw "Unity bonus area probe exceeded its execution bound; inspect $log"
        }
    }
    if ($process.ExitCode -ne 0 -or !(Test-Path -LiteralPath $output) -or
        !(Select-String -LiteralPath $log -SimpleMatch 'PVP_BONUS_AREAS PASS' -Quiet)) {
        throw "Unity bonus area probe failed; inspect $log"
    }
    Select-String -LiteralPath $log -SimpleMatch 'PVP_BONUS_AREAS PASS' | ForEach-Object { $_.Line }
}
finally { $env:WAR_PVP_BONUS_AREAS_OUTPUT = $prior }
