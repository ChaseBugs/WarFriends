$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'BufferReplayAssertions.ps1')

$current = [PSCustomObject]@{ Gold = @{ N = '10' }; WarBucks = @{ N = '20' } }
$old = '[{"ActionId":79,"Result":106,"LevelName":"unit","Gold":0,"WarBucks":0,"Unit":"{}"}]'
$fresh = '[{"ActionId":79,"Result":106,"LevelName":"unit","Gold":10,"WarBucks":20,"Unit":"{\"bought\":true}"}]'
if (!(Test-BufferReplay $old $fresh $current)) {
    throw "Single-entry rollback array was not inspected: $script:bufferReplayMismatch"
}
if (Test-BufferReplay $old ($fresh.Replace('"Gold":10', '"Gold":9')) $current) {
    throw 'Replay assertions accepted an outdated wallet.'
}
if (Test-BufferReplay $old ($fresh.Replace('"Result":106', '"Result":1')) $current) {
    throw 'Replay assertions accepted a changed outcome.'
}

$timed = '[{"ActionId":73,"Result":1,"DeliveryTime":60}]'
if (!(Test-BufferReplay $timed '[{"ActionId":73,"Result":1,"DeliveryTime":50}]' $current)) {
    throw 'Replay assertions rejected a decreasing countdown.'
}
if (!(Test-BufferReplay $timed '[{"ActionId":73,"Result":1}]' $current)) {
    throw 'Replay assertions rejected suppression of an obsolete countdown.'
}
if (Test-BufferReplay $timed '[{"ActionId":73,"Result":1,"DeliveryTime":61}]' $current) {
    throw 'Replay assertions accepted a restarted countdown.'
}

$multiple = '[{"ActionId":104,"Result":1},{"ActionId":105,"Result":1}]'
if (!(Test-BufferReplay $multiple $multiple $current)) {
    throw 'Multi-entry replay array was not inspected.'
}
Write-Output "PASS: 7 replay assertion scenarios on PowerShell $($PSVersionTable.PSVersion)"
