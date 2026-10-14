param(
    [string]$UnityExecutable = 'C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe',
    [string]$ProbeRoot = (Join-Path $env:TEMP ('WarFriends-PvpProgress-' + [guid]::NewGuid().ToString('N'))),
    [string]$OutputFile = ''
)
$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
python (Join-Path $serverRoot 'tools/prepare_pvp_progress_probe.py') $ProbeRoot
if ($LASTEXITCODE -ne 0) { throw 'Source progress probe preparation failed.' }
$output = Join-Path $serverRoot 'content/unity-pvp-progress-reference.json'
if ($OutputFile) { $output = [System.IO.Path]::GetFullPath($OutputFile) }
$prior = $env:WAR_PVP_PROGRESS_OUTPUT
$env:WAR_PVP_PROGRESS_OUTPUT = $output
try {
    $log = Join-Path $ProbeRoot 'Editor.log'
    $arguments = @('-batchmode', '-nographics', '-quit', '-projectPath',
        ('"' + $ProbeRoot + '"'), '-executeMethod', 'UnityPvpProgressAudit.Run',
        '-logFile', ('"' + $log + '"'))
    $process = Start-Process -FilePath $UnityExecutable -ArgumentList $arguments -PassThru -WindowStyle Hidden
    while (!$process.WaitForExit(1000)) { }
    if ($process.ExitCode -ne 0 -or !(Test-Path -LiteralPath $output) -or
        !(Select-String -LiteralPath $log -SimpleMatch 'PVP_PROGRESS_SOURCE PASS' -Quiet)) {
        throw "Unity progress source probe failed; inspect $log"
    }
    Select-String -LiteralPath $log -SimpleMatch 'PVP_PROGRESS_SOURCE PASS' | ForEach-Object { $_.Line }
}
finally { $env:WAR_PVP_PROGRESS_OUTPUT = $prior }
