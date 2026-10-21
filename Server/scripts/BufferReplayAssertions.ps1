# Pure replay assertions shared by the HTTP smoke and shell-compatibility checks.
function Test-BufferReplay([string]$Expected, [string]$Actual, $CurrentPlayerData) {
    $script:bufferReplayMismatch = ''
    $original = [object[]](ConvertFrom-Json -InputObject $Expected)
    $replayed = [object[]](ConvertFrom-Json -InputObject $Actual)
    if ($original.Count -ne $replayed.Count) { $script:bufferReplayMismatch = 'entry count'; return $false }
    for ($index = 0; $index -lt $original.Count; $index++) {
        if ($original[$index].Result -ne 1) {
            foreach ($field in @('Gold', 'WarBucks', 'Scraps')) {
                if ($null -eq $original[$index].PSObject.Properties[$field]) { continue }
                $balance = $replayed[$index].PSObject.Properties[$field]
                if ($null -eq $balance -or ($balance.Value -isnot [int] -and $balance.Value -isnot [long]) -or `
                    $balance.Value -ne [long]$CurrentPlayerData.$field.N) {
                    $script:bufferReplayMismatch = 'wallet {0} (actual={1}, current={2})' -f `
                        $field, $balance.Value, $CurrentPlayerData.$field.N
                    return $false
                }
                $original[$index].PSObject.Properties.Remove($field)
                $replayed[$index].PSObject.Properties.Remove($field)
            }
            foreach ($field in @('Weapon', 'Unit', 'InventoryData', 'CardManagerData', 'DecalManagerData', `
                'data', 'weaponDelivery', 'unitDelivery')) {
                if ($null -eq $original[$index].PSObject.Properties[$field]) { continue }
                $snapshot = $replayed[$index].PSObject.Properties[$field]
                if ($null -eq $snapshot -or $snapshot.Value -isnot [string]) {
                    $script:bufferReplayMismatch = "missing/non-string $field"
                    return $false
                }
                try { $decoded = $snapshot.Value | ConvertFrom-Json }
                catch { $script:bufferReplayMismatch = "invalid JSON $field"; return $false }
                if ($null -eq $decoded -or $decoded -isnot [PSCustomObject]) {
                    $script:bufferReplayMismatch = "non-object $field"
                    return $false
                }
                $original[$index].PSObject.Properties.Remove($field)
                $replayed[$index].PSObject.Properties.Remove($field)
            }
        }
        if ($null -eq $original[$index].PSObject.Properties['DeliveryTime']) { continue }
        $remaining = $replayed[$index].PSObject.Properties['DeliveryTime']
        if ($null -ne $remaining) {
            if (($remaining.Value -isnot [int] -and $remaining.Value -isnot [long]) -or `
                $remaining.Value -lt 0 -or $remaining.Value -gt $original[$index].DeliveryTime) {
                $script:bufferReplayMismatch = 'delivery countdown'
                return $false
            }
        }
        # The Client adds DeliveryTime to its current clock. Only this field is time-relative.
        $original[$index].PSObject.Properties.Remove('DeliveryTime')
        $replayed[$index].PSObject.Properties.Remove('DeliveryTime')
    }
    $before = ConvertTo-Json -InputObject $original -Depth 30 -Compress
    $after = ConvertTo-Json -InputObject $replayed -Depth 30 -Compress
    if ($before -cne $after) {
        $script:bufferReplayMismatch = 'outcome/identity (expected={0}/{1}, actual={2}/{3})' -f `
            $original[0].ActionId, $original[0].Result, $replayed[0].ActionId, $replayed[0].Result
    }
    return $before -ceq $after
}
