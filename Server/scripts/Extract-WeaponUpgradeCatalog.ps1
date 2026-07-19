param(
    [string]$ScenePath = (Join-Path $PSScriptRoot '..\..\Client\ExportedProject\Assets\Scenes\MainScene.unity'),
    [string]$InventoryServicePath = (Join-Path $PSScriptRoot '..\src\services\itemInventoryService.ts'),
    [string]$OutputPath = (Join-Path $PSScriptRoot '..\src\data\weaponUpgradeCatalog.generated.ts'),
    [switch]$Check
)

$ErrorActionPreference = 'Stop'
$resolvedScene = (Resolve-Path -LiteralPath $ScenePath).Path
$resolvedInventoryService = (Resolve-Path -LiteralPath $InventoryServicePath).Path

function Read-SceneLines {
    param([scriptblock]$Visitor)

    $reader = [System.IO.File]::OpenText($resolvedScene)
    try {
        while (($line = $reader.ReadLine()) -ne $null) {
            & $Visitor $line
        }
    }
    finally {
        $reader.Dispose()
    }
}

function Decode-ObscuredInt {
    param([long]$Key, [long]$Hidden)
    return [int]($Key -bxor $Hidden)
}

function Decode-ObscuredFloat {
    param([uint32]$Key, [string]$HiddenHex)

    if ($HiddenHex -notmatch '^[0-9a-fA-F]{8}$') {
        throw "Invalid ObscuredFloat hidden value '$HiddenHex'."
    }

    # Unity serializes the encrypted four-byte union in memory order. On this little-endian
    # build, e7857342 therefore means bytes E7 85 73 42, not the integer 0xE7857342.
    $encryptedBytes = [byte[]]::new(4)
    for ($index = 0; $index -lt 4; $index++) {
        $encryptedBytes[$index] = [Convert]::ToByte($HiddenHex.Substring($index * 2, 2), 16)
    }
    $encryptedBits = [BitConverter]::ToUInt32($encryptedBytes, 0)
    $plainBits = $encryptedBits -bxor $Key
    return [BitConverter]::ToSingle([BitConverter]::GetBytes($plainBits), 0)
}

# The generated upgrade table must cover exactly the weapon rows that the server is willing
# to sell/equip. Parsing the checked-in catalog avoids silently generating data for null or
# otherwise unresolved LevelManager references.
$catalog = [System.Collections.Generic.List[object]]::new()
foreach ($line in Get-Content -LiteralPath $resolvedInventoryService) {
    if ($line -match '^  weapon\("([^"]+)", ([0-9_]+),') {
        [void]$catalog.Add([pscustomobject]@{
            Name = $Matches[1]
            Index = [int]($Matches[2] -replace '_', '')
        })
    }
}
if ($catalog.Count -eq 0) {
    throw 'No weapon definitions were found in itemInventoryService.ts.'
}

# Recover the non-sequential LevelManager index -> WeaponLevelsSetup component relationship.
$levelManagerIds = [System.Collections.Generic.List[string]]::new()
$insideLevelManagerList = $false
Read-SceneLines {
    param($line)
    if ($line -eq '  weaponLevelsSetups:') {
        $script:insideLevelManagerList = $true
        return
    }
    if ($script:insideLevelManagerList) {
        if ($line -match '^  - \{fileID: ([0-9]+)\}$') {
            [void]$script:levelManagerIds.Add($Matches[1])
            return
        }
        $script:insideLevelManagerList = $false
    }
}

$weaponComponentToName = @{}
foreach ($entry in $catalog) {
    if ($entry.Index -ge $levelManagerIds.Count) {
        throw "LevelManager index $($entry.Index) for $($entry.Name) is outside the scene list."
    }
    $componentId = $levelManagerIds[$entry.Index]
    if ($componentId -eq '0') {
        throw "LevelManager index $($entry.Index) for $($entry.Name) is null."
    }
    if ($weaponComponentToName.ContainsKey($componentId)) {
        throw "LevelManager component $componentId is shared by multiple catalog rows."
    }
    $weaponComponentToName[$componentId] = $entry.Name
}

# Resolve each WeaponLevelsSetup component to its GameObject.
$weaponComponentToGameObject = @{}
$activeWeaponComponent = $null
Read-SceneLines {
    param($line)
    if ($line -match '^--- !u!114 &([0-9]+)$') {
        $id = $Matches[1]
        $script:activeWeaponComponent = if ($script:weaponComponentToName.ContainsKey($id)) { $id } else { $null }
        return
    }
    if ($script:activeWeaponComponent -and $line -match '^  m_GameObject: \{fileID: ([0-9]+)\}$') {
        $script:weaponComponentToGameObject[$script:activeWeaponComponent] = $Matches[1]
        $script:activeWeaponComponent = $null
    }
}
if ($weaponComponentToGameObject.Count -ne $catalog.Count) {
    throw "Resolved $($weaponComponentToGameObject.Count) of $($catalog.Count) weapon GameObjects."
}

# Read each target GameObject's component list. A recovered weapon object contains a Transform,
# its WeaponLevelsSetup, and its row-specific Google2u component.
$targetGameObjects = @{}
foreach ($componentId in $weaponComponentToGameObject.Keys) {
    $targetGameObjects[$weaponComponentToGameObject[$componentId]] = $componentId
}
$gameObjectComponents = @{}
$activeGameObject = $null
$activeComponents = $null
function Finish-GameObject {
    if ($script:activeGameObject -and $script:targetGameObjects.ContainsKey($script:activeGameObject)) {
        $script:gameObjectComponents[$script:activeGameObject] = @($script:activeComponents)
    }
    $script:activeGameObject = $null
    $script:activeComponents = $null
}
Read-SceneLines {
    param($line)
    if ($line -match '^--- !u!([0-9]+) &([0-9]+)$') {
        Finish-GameObject
        if ($Matches[1] -eq '1' -and $script:targetGameObjects.ContainsKey($Matches[2])) {
            $script:activeGameObject = $Matches[2]
            $script:activeComponents = [System.Collections.Generic.List[string]]::new()
        }
        return
    }
    if ($script:activeGameObject -and $line -match '^  - component: \{fileID: ([0-9]+)\}$') {
        [void]$script:activeComponents.Add($Matches[1])
    }
}
Finish-GameObject

# Determine which sibling component is a MonoBehaviour; the remaining sibling is Transform.
$candidateComponents = @{}
foreach ($gameObjectId in $gameObjectComponents.Keys) {
    $weaponComponentId = $targetGameObjects[$gameObjectId]
    foreach ($componentId in $gameObjectComponents[$gameObjectId]) {
        if ($componentId -ne $weaponComponentId) {
            $candidateComponents[$componentId] = $true
        }
    }
}
$monoBehaviourCandidates = @{}
Read-SceneLines {
    param($line)
    if ($line -match '^--- !u!114 &([0-9]+)$' -and $script:candidateComponents.ContainsKey($Matches[1])) {
        $script:monoBehaviourCandidates[$Matches[1]] = $true
    }
}

$googleComponentToName = @{}
foreach ($entry in $catalog) {
    $weaponComponentId = $levelManagerIds[$entry.Index]
    $gameObjectId = $weaponComponentToGameObject[$weaponComponentId]
    $googleCandidates = @(
        $gameObjectComponents[$gameObjectId] |
            Where-Object { $_ -ne $weaponComponentId -and $monoBehaviourCandidates.ContainsKey($_) }
    )
    if ($googleCandidates.Count -ne 1) {
        throw "Expected one Google2u sibling for $($entry.Name), found $($googleCandidates.Count)."
    }
    $googleComponentToName[$googleCandidates[0]] = $entry.Name
}

function Finish-UpgradeRow {
    param($Row, [System.Collections.Generic.List[object]]$Rows)

    if ($null -eq $Row) {
        return
    }
    if ($Row.PriceKey -eq $null -or $Row.PriceHidden -eq $null -or
        $Row.TimeKey -eq $null -or $Row.TimeHidden -eq $null) {
        throw 'An upgrade row is missing NEXTUPGRADEPRICE or DELIVERYTIME encryption fields.'
    }
    if ($Row.PriceGold -ne 0) {
        throw "Unexpected Gold upgrade price $($Row.PriceGold); the 1.6.0 request pays WarBucks."
    }

    $delivery = Decode-ObscuredFloat ([uint32]$Row.TimeKey) ([string]$Row.TimeHidden)
    $roundedDelivery = [int][Math]::Round($delivery)
    if ([Math]::Abs($delivery - $roundedDelivery) -gt 0.001 -or $roundedDelivery -lt 0) {
        throw "Decoded non-integral or negative delivery time '$delivery'."
    }
    [void]$Rows.Add([pscustomobject]@{
        WarBucks = Decode-ObscuredInt ([long]$Row.PriceKey) ([long]$Row.PriceHidden)
        DeliverySeconds = $roundedDelivery
    })
}

# Parse the row-specific Google2u tables. Weapon families have different normal level counts;
# the final row is always WARARENA. With N total rows, maxWeaponLevel is N-1 and CanUpgrade
# permits current indexes 0..N-3, so exactly N-2 transition rows are authoritative.
$upgradeRowsByName = @{}
$activeGoogleComponent = $null
$activeRows = $null
$insideRows = $false
$currentRow = $null
$activeSection = ''
function Finish-GoogleComponent {
    if ($script:activeGoogleComponent) {
        Finish-UpgradeRow $script:currentRow $script:activeRows
        $name = $script:googleComponentToName[$script:activeGoogleComponent]
        if ($script:activeRows.Count -lt 3) {
            throw "$name has too few upgrade rows: $($script:activeRows.Count)."
        }
        $transitionCount = $script:activeRows.Count - 2
        $script:upgradeRowsByName[$name] = @($script:activeRows | Select-Object -First $transitionCount)
    }
    $script:activeGoogleComponent = $null
    $script:activeRows = $null
    $script:insideRows = $false
    $script:currentRow = $null
    $script:activeSection = ''
}
Read-SceneLines {
    param($line)
    if ($line -match '^--- !u![0-9]+ &([0-9]+)$') {
        Finish-GoogleComponent
        $id = $Matches[1]
        if ($script:googleComponentToName.ContainsKey($id)) {
            $script:activeGoogleComponent = $id
            $script:activeRows = [System.Collections.Generic.List[object]]::new()
        }
        return
    }
    if (-not $script:activeGoogleComponent) {
        return
    }
    if (-not $script:insideRows) {
        if ($line -eq '  Rows:') {
            $script:insideRows = $true
        }
        return
    }
    if ($line -match '^  - [A-Z][A-Z0-9_]*:') {
        Finish-UpgradeRow $script:currentRow $script:activeRows
        $script:currentRow = [pscustomobject]@{
            PriceKey = $null
            PriceHidden = $null
            PriceGold = 0
            TimeKey = $null
            TimeHidden = $null
        }
        $script:activeSection = ''
        return
    }
    if ($null -eq $script:currentRow) {
        return
    }
    if ($line -eq '    NEXTUPGRADEPRICE:') {
        $script:activeSection = 'price'
        return
    }
    if ($line -match '^    NEXTUPGRADEPRICEGOLD: (-?[0-9]+)$') {
        $script:currentRow.PriceGold = [int]$Matches[1]
        $script:activeSection = ''
        return
    }
    if ($line -eq '    DELIVERYTIME:') {
        $script:activeSection = 'time'
        return
    }
    if ($line -match '^    [A-Z][A-Z0-9_]*:') {
        $script:activeSection = ''
    }
    if ($line -match '^      currentCryptoKey: ([0-9]+)$') {
        if ($script:activeSection -eq 'price') {
            $script:currentRow.PriceKey = [long]$Matches[1]
        }
        elseif ($script:activeSection -eq 'time') {
            $script:currentRow.TimeKey = [uint32]$Matches[1]
        }
        return
    }
    if ($line -match '^      hiddenValue: ([0-9a-fA-F]+)$') {
        if ($script:activeSection -eq 'price') {
            $script:currentRow.PriceHidden = [long]$Matches[1]
        }
        elseif ($script:activeSection -eq 'time') {
            $script:currentRow.TimeHidden = $Matches[1]
        }
    }
}
Finish-GoogleComponent

if ($upgradeRowsByName.Count -ne $catalog.Count) {
    throw "Extracted $($upgradeRowsByName.Count) of $($catalog.Count) weapon upgrade tables."
}

$builder = [System.Text.StringBuilder]::new()
[void]$builder.AppendLine('// Generated by scripts/Extract-WeaponUpgradeCatalog.ps1 from the 4.9.5 MainScene.')
[void]$builder.AppendLine('// Do not hand-edit prices or delivery times; regenerate and review the source diff.')
[void]$builder.AppendLine('')
[void]$builder.AppendLine('export type WeaponUpgradeStage = readonly [warBucks: number, deliverySeconds: number];')
[void]$builder.AppendLine('')
[void]$builder.AppendLine('/**')
[void]$builder.AppendLine(' * Index N is the server-authoritative cost and duration for upgrading boughtIndex N to N+1.')
[void]$builder.AppendLine(' * Array lengths vary by weapon because each Google2u table has its own normal-level count;')
[void]$builder.AppendLine(' * the final non-transition row in every source table is reserved for WARARENA balancing.')
[void]$builder.AppendLine(' */')
[void]$builder.AppendLine('export const WEAPON_UPGRADE_CATALOG: Readonly<Record<string, readonly WeaponUpgradeStage[]>> = Object.freeze({')
foreach ($entry in $catalog) {
    $quotedName = $entry.Name | ConvertTo-Json -Compress
    [void]$builder.AppendLine("  ${quotedName}: Object.freeze([")
    $rows = $upgradeRowsByName[$entry.Name]
    for ($index = 0; $index -lt $rows.Count; $index += 8) {
        $pairs = [System.Collections.Generic.List[string]]::new()
        $lastIndex = [Math]::Min($rows.Count - 1, $index + 7)
        for ($pairIndex = $index; $pairIndex -le $lastIndex; $pairIndex++) {
            $row = $rows[$pairIndex]
            [void]$pairs.Add("[$($row.WarBucks), $($row.DeliverySeconds)]")
        }
        [void]$builder.AppendLine('    ' + ($pairs -join ', ') + ',')
    }
    [void]$builder.AppendLine('  ] as const),')
}
[void]$builder.AppendLine('});')

$expectedText = $builder.ToString()
if ($Check) {
    if (-not (Test-Path -LiteralPath $OutputPath -PathType Leaf)) {
        throw "Generated weapon upgrade catalog is missing: $OutputPath"
    }
    $actualText = [IO.File]::ReadAllText((Resolve-Path -LiteralPath $OutputPath).Path)
    if ($actualText -ne $expectedText) {
        throw 'Generated weapon upgrade catalog is stale. Run Server\scripts\Extract-WeaponUpgradeCatalog.ps1.'
    }
    Write-Host "Weapon upgrade catalog is current: $($upgradeRowsByName.Count) weapons."
}
else {
    $outputDirectory = Split-Path -Parent $OutputPath
    if (-not (Test-Path -LiteralPath $outputDirectory -PathType Container)) {
        [void](New-Item -ItemType Directory -Path $outputDirectory)
    }
    [IO.File]::WriteAllText($OutputPath, $expectedText, [Text.UTF8Encoding]::new($false))
    Write-Host "Wrote $OutputPath with $($upgradeRowsByName.Count) weapon upgrade tables."
}
