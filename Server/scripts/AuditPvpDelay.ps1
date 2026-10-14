param(
    [string]$UnityExecutable = 'C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe',
    [string]$ProbeRoot = (Join-Path $env:TEMP ('WarFriends-PvpDelay-' + [guid]::NewGuid().ToString('N')))
)
$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
python (Join-Path $serverRoot 'tools/prepare_pvp_delay_probe.py') $ProbeRoot
if ($LASTEXITCODE -ne 0) { throw 'Source delay probe preparation failed.' }
$output = Join-Path $serverRoot 'content/unity-pvp-delay-reference.json'
$prior = $env:WAR_PVP_DELAY_OUTPUT
$env:WAR_PVP_DELAY_OUTPUT = $output
try {
    $log = Join-Path $ProbeRoot 'Editor.log'
    $arguments = @('-batchmode', '-nographics', '-projectPath',
        ('"' + $ProbeRoot + '"'), '-executeMethod', 'UnityPvpDelayAudit.Run',
        '-logFile', ('"' + $log + '"'))
    $process = Start-Process -FilePath $UnityExecutable -ArgumentList $arguments -PassThru -WindowStyle Hidden
    $deadline = [DateTime]::UtcNow.AddMinutes(3)
    while (!$process.WaitForExit(1000)) {
        if ([DateTime]::UtcNow -ge $deadline) {
            $process.Kill()
            throw "Unity delay probe exceeded its execution bound; inspect $log"
        }
    }
    if ($process.ExitCode -ne 0 -or !(Test-Path -LiteralPath $output) -or
        !(Select-String -LiteralPath $log -SimpleMatch 'PVP_DELAY_SOURCE PASS' -Quiet)) {
        throw "Unity delay source probe failed; inspect $log"
    }
    Select-String -LiteralPath $log -SimpleMatch 'PVP_DELAY_SOURCE PASS' | ForEach-Object { $_.Line }
}
finally { $env:WAR_PVP_DELAY_OUTPUT = $prior }
