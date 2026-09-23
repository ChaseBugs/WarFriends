param(
    [string]$UnityExecutable = 'C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe',
    [string]$ProbeRoot = (Join-Path $env:TEMP 'WarFriends-MinigunnerSortAudit')
)

$ErrorActionPreference = 'Stop'
$assetEditor = Join-Path $ProbeRoot 'Assets/Editor'
New-Item -ItemType Directory -Path $assetEditor -Force | Out-Null
$source = Join-Path $PSScriptRoot '../tools/UnityMinigunnerSortAudit.cs'
Copy-Item -LiteralPath $source -Destination (Join-Path $assetEditor 'UnityMinigunnerSortAudit.cs') -Force
$log = Join-Path $ProbeRoot 'Editor.log'
$arguments = @('-batchmode', '-nographics', '-quit', '-projectPath',
    ('"' + $ProbeRoot + '"'), '-executeMethod', 'UnityMinigunnerSortAudit.Run',
    '-logFile', ('"' + $log + '"'))
$process = Start-Process -FilePath $UnityExecutable -ArgumentList $arguments -PassThru -Wait -WindowStyle Hidden
if ($process.ExitCode -ne 0 -or -not (Test-Path -LiteralPath $log) -or
    -not (Select-String -LiteralPath $log -SimpleMatch 'MINIGUNNER_SORT PASS' -Quiet)) {
    throw "Unity Minigunner sort audit failed (exit $($process.ExitCode)); inspect $log"
}
Select-String -LiteralPath $log -Pattern 'MINIGUNNER_SORT (2|3|PASS)' |
    ForEach-Object { $_.Line }
