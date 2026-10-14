param(
    [string]$UnityExecutable = 'C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe',
    [string]$ProbeRoot = (Join-Path $env:TEMP ('WarFriends-PvpSelection-' + [guid]::NewGuid().ToString('N')))
)
$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
python (Join-Path $serverRoot 'tools/prepare_pvp_selection_probe.py') $ProbeRoot
if ($LASTEXITCODE -ne 0) { throw 'Source selection probe preparation failed.' }
$output = Join-Path $serverRoot 'content/unity-pvp-selection-reference.json'
$prior = $env:WAR_PVP_SELECTION_OUTPUT
$env:WAR_PVP_SELECTION_OUTPUT = $output
try {
    $log = Join-Path $ProbeRoot 'Editor.log'
    $arguments = @('-batchmode', '-nographics', '-quit', '-projectPath',
        ('"' + $ProbeRoot + '"'), '-executeMethod', 'UnityPvpSelectionAudit.Run',
        '-logFile', ('"' + $log + '"'))
    $process = Start-Process -FilePath $UnityExecutable -ArgumentList $arguments -PassThru -WindowStyle Hidden
    while (!$process.WaitForExit(1000)) { }
    if ($process.ExitCode -ne 0 -or !(Test-Path -LiteralPath $output) -or
        !(Select-String -LiteralPath $log -SimpleMatch 'PVP_SELECTION_SOURCE PASS' -Quiet)) {
        throw "Unity selection source probe failed; inspect $log"
    }
    Select-String -LiteralPath $log -SimpleMatch 'PVP_SELECTION_SOURCE PASS' | ForEach-Object { $_.Line }
}
finally { $env:WAR_PVP_SELECTION_OUTPUT = $prior }
