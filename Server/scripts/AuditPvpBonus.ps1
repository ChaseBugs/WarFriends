param(
    [string]$UnityExecutable = 'C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe',
    [string]$ProbeRoot = (Join-Path $env:TEMP ('WarFriends-PvpBonus-' + [guid]::NewGuid().ToString('N')))
)
$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
python (Join-Path $serverRoot 'tools/prepare_pvp_bonus_probe.py') $ProbeRoot
if ($LASTEXITCODE -ne 0) { throw 'Source bonus probe preparation failed.' }
$output = Join-Path $serverRoot 'content/unity-pvp-bonus-reference.json'
$prior = $env:WAR_PVP_BONUS_OUTPUT
$env:WAR_PVP_BONUS_OUTPUT = $output
try {
    $log = Join-Path $ProbeRoot 'Editor.log'
    $arguments = @('-batchmode', '-nographics', '-quit', '-projectPath',
        ('"' + $ProbeRoot + '"'), '-executeMethod', 'UnityPvpBonusAudit.Run',
        '-logFile', ('"' + $log + '"'))
    $process = Start-Process -FilePath $UnityExecutable -ArgumentList $arguments -PassThru -WindowStyle Hidden
    while (!$process.WaitForExit(1000)) { }
    if ($process.ExitCode -ne 0 -or !(Test-Path -LiteralPath $output) -or
        !(Select-String -LiteralPath $log -SimpleMatch 'PVP_BONUS_SOURCE PASS' -Quiet)) {
        throw "Unity bonus source probe failed; inspect $log"
    }
    Select-String -LiteralPath $log -SimpleMatch 'PVP_BONUS_SOURCE PASS' | ForEach-Object { $_.Line }
}
finally { $env:WAR_PVP_BONUS_OUTPUT = $prior }
