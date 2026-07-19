param(
    [string]$ScenePath,
    [string]$OutputPath,
    [string]$UpgradeOutputPath,
    [switch]$Check
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

$repoRoot = Split-Path -Parent $PSScriptRoot
if ([string]::IsNullOrWhiteSpace($ScenePath)) {
    $ScenePath = Join-Path $repoRoot "Client\ExportedProject\Assets\Scenes\MainScene.unity"
}
if ([string]::IsNullOrWhiteSpace($OutputPath)) {
    $OutputPath = Join-Path $repoRoot "Server\src\data\unitCatalog.generated.json"
}
if ([string]::IsNullOrWhiteSpace($UpgradeOutputPath)) {
    $UpgradeOutputPath = Join-Path $repoRoot "Server\src\data\unitUpgradeCatalog.generated.json"
}

function Decode-ObscuredFloat([uint32]$Key, [string]$HiddenHex) {
    if ($HiddenHex -notmatch '^[0-9a-fA-F]{8}$') {
        throw "Invalid ObscuredFloat hidden value '$HiddenHex'."
    }
    # Unity serializes the encrypted four-byte union in memory order. Decode those bytes as
    # little-endian before XORing with currentCryptoKey, matching the recovered Android build.
    $encryptedBytes = [byte[]]::new(4)
    for ($index = 0; $index -lt 4; $index++) {
        $encryptedBytes[$index] = [Convert]::ToByte($HiddenHex.Substring($index * 2, 2), 16)
    }
    $encryptedBits = [BitConverter]::ToUInt32($encryptedBytes, 0)
    $plainBits = $encryptedBits -bxor $Key
    return [BitConverter]::ToSingle([BitConverter]::GetBytes($plainBits), 0)
}

function Resolve-RequiredFile([string]$Path, [string]$Description) {
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "$Description was not found: $Path"
    }
    return (Resolve-Path -LiteralPath $Path).Path
}

function Read-PluginGuid([string]$AssemblyPath) {
    $match = Select-String -LiteralPath "$AssemblyPath.meta" -Pattern '^guid: ([0-9a-f]{32})$' | Select-Object -First 1
    if (-not $match) {
        throw "Unity plugin GUID was not found for $AssemblyPath"
    }
    return $match.Matches[0].Groups[1].Value
}

$scene = Resolve-RequiredFile $ScenePath "Recovered MainScene"
$patcherProject = Resolve-RequiredFile (Join-Path $PSScriptRoot "LegacyAssemblyPatcher\LegacyAssemblyPatcher.csproj") "Script type mapper"
$pluginRoot = Join-Path $repoRoot "Client\ExportedProject\Assets\Plugins"
$gameplayAssembly = Resolve-RequiredFile (Join-Path $pluginRoot "WarFriends.Gameplay.dll") "Recovered gameplay assembly"
$firstPassAssembly = Resolve-RequiredFile (Join-Path $pluginRoot "WarFriends.Gameplay.FirstPass.dll") "Recovered FirstPass assembly"
$temporaryRoot = Join-Path ([IO.Path]::GetTempPath()) ("warfriends-unit-catalog-" + [Guid]::NewGuid().ToString("N"))
[void](New-Item -ItemType Directory -Path $temporaryRoot)

function Read-TypeMap([string]$AssemblyPath, [string]$MapName) {
    $mapPath = Join-Path $temporaryRoot "$MapName.csv"
    & dotnet run --project $patcherProject -- $AssemblyPath --dump-script-types $mapPath | Out-Host
    if ($LASTEXITCODE -ne 0) {
        throw "Could not read Unity script types from $AssemblyPath"
    }
    $types = @{}
    foreach ($row in (Import-Csv -LiteralPath $mapPath)) {
        $types[[string]$row.file_id] = [string]$row.full_name
    }
    return [pscustomobject]@{
        Guid = Read-PluginGuid $AssemblyPath
        Types = $types
    }
}

try {
    # Unity serializes DLL MonoScripts as a GUID plus a signed MD4-derived file ID. Resolve
    # both halves through the recovered assemblies so renamed/obfuscated component fields do
    # not force a hand-maintained map between LevelBehaviour and Google2u table names.
    $typeMapsByGuid = @{}
    foreach ($map in @(
        (Read-TypeMap $gameplayAssembly "gameplay-types"),
        (Read-TypeMap $firstPassAssembly "firstpass-types")
    )) {
        $typeMapsByGuid[$map.Guid] = $map.Types
    }

    # LevelManager has two adjacent lists. `behaviours` is the player roster and its array
    # position is the stable client unit index; `additionalBehaviours` contains three turret
    # helpers used by gameplay but not offered by ArmyScreen as purchasable roster entries.
    $rosterIds = [Collections.Generic.List[string]]::new()
    $additionalIds = [Collections.Generic.List[string]]::new()
    $reader = [IO.File]::OpenText($scene)
    try {
        $list = $null
        while (($line = $reader.ReadLine()) -ne $null) {
            if ($line -eq "  behaviours:") {
                $list = $rosterIds
                continue
            }
            if ($line -eq "  additionalBehaviours:") {
                $list = $additionalIds
                continue
            }
            if ($null -ne $list) {
                if ($line -match '^  - \{fileID: (\d+)\}$') {
                    $list.Add($Matches[1])
                    continue
                }
                if ($additionalIds.Count -gt 0) {
                    break
                }
            }
        }
    }
    finally {
        $reader.Dispose()
    }
    if ($rosterIds.Count -ne 24 -or $additionalIds.Count -ne 3) {
        throw "Expected 24 roster and 3 additional unit behaviours, found $($rosterIds.Count) and $($additionalIds.Count)."
    }

    $componentsById = @{}
    $componentsByGameObject = @{}
    function Save-MonoBehaviourBlock($Block) {
        if ($null -eq $Block) {
            return
        }
        $typeName = ""
        if ($typeMapsByGuid.ContainsKey([string]$Block.guid)) {
            $typeMap = $typeMapsByGuid[[string]$Block.guid]
            if ($typeMap.ContainsKey([string]$Block.scriptId)) {
                $typeName = [string]$typeMap[[string]$Block.scriptId]
            }
        }
        $component = [pscustomobject]@{
            Id = [string]$Block.id
            GameObject = [string]$Block.gameObject
            TypeName = $typeName
            UpgradeSlotsId = [string]$Block.upgradeSlotsId
            TutorialUnit = [bool]$Block.tutorialUnit
            DeploymentType = [int]$Block.deploymentType
            IsSoldier = [bool]$Block.isSoldier
        }
        $componentsById[$component.Id] = $component
        if (-not $componentsByGameObject.ContainsKey($component.GameObject)) {
            $componentsByGameObject[$component.GameObject] = [Collections.Generic.List[object]]::new()
        }
        $componentsByGameObject[$component.GameObject].Add($component)
    }

    # A LevelBehaviour points to an UpgradeSlots component on another GameObject. The actual
    # Google2u per-level table lives beside UpgradeSlots, so the authoritative join is:
    # LevelManager list -> LevelBehaviour.upgradeSlots -> same GameObject -> Google2u type.
    $reader = [IO.File]::OpenText($scene)
    $block = $null
    try {
        while (($line = $reader.ReadLine()) -ne $null) {
            if ($line -match '^--- !u!(\d+) &(\d+)$') {
                Save-MonoBehaviourBlock $block
                $block = if ($Matches[1] -eq "114") {
                    [ordered]@{
                        id = $Matches[2]
                        gameObject = ""
                        scriptId = ""
                        guid = ""
                        upgradeSlotsId = ""
                        tutorialUnit = $false
                        deploymentType = -1
                        isSoldier = $true
                    }
                }
                else {
                    $null
                }
                continue
            }
            if ($null -eq $block) {
                continue
            }
            if ($line -match '^  m_GameObject: \{fileID: (\d+)\}$') {
                $block.gameObject = $Matches[1]
            }
            elseif ($line -match '^  m_Script: \{fileID: (-?\d+), guid: ([0-9a-f]{32}), type: 3\}$') {
                $block.scriptId = $Matches[1]
                $block.guid = $Matches[2]
            }
            elseif ($line -match '^  upgradeSlots: \{fileID: (\d+)\}$') {
                $block.upgradeSlotsId = $Matches[1]
            }
            elseif ($line -match '^  isTutorialUnit: ([01])$') {
                $block.tutorialUnit = $Matches[1] -eq "1"
            }
            elseif ($line -match '^  unitType: (-?\d+)$') {
                $block.deploymentType = [int]$Matches[1]
            }
            elseif ($line -match '^  isSoldier: ([01])$') {
                $block.isSoldier = $Matches[1] -eq "1"
            }
        }
        Save-MonoBehaviourBlock $block
    }
    finally {
        $reader.Dispose()
    }

    function Resolve-UnitReference([string]$BehaviourId, [int]$Index, [bool]$Additional) {
        if (-not $componentsById.ContainsKey($BehaviourId)) {
            throw "Unit behaviour component $BehaviourId was not found."
        }
        $behaviour = $componentsById[$BehaviourId]
        if ([string]::IsNullOrWhiteSpace($behaviour.UpgradeSlotsId) -or -not $componentsById.ContainsKey($behaviour.UpgradeSlotsId)) {
            throw "Unit behaviour $BehaviourId has no resolvable UpgradeSlots component."
        }
        $upgrade = $componentsById[$behaviour.UpgradeSlotsId]
        $googleComponents = @(
            $componentsByGameObject[$upgrade.GameObject] |
                Where-Object { $_.TypeName -like 'Google2u.DBUpgradeSlots*' }
        )
        if ($googleComponents.Count -ne 1) {
            throw "UpgradeSlots $($upgrade.Id) resolved $($googleComponents.Count) Google2u unit tables."
        }
        if ($behaviour.DeploymentType -lt 0 -or $behaviour.DeploymentType -gt 3) {
            throw "Unit behaviour $BehaviourId has invalid deployment type $($behaviour.DeploymentType)."
        }
        return [pscustomobject]@{
            Name = [string]$googleComponents[0].TypeName
            GoogleComponentId = [string]$googleComponents[0].Id
            Index = $Index
            Additional = $Additional
            BehaviourType = [string]$behaviour.TypeName
            UpgradeType = [string]$upgrade.TypeName
            TutorialUnit = [bool]$upgrade.TutorialUnit
            DeploymentType = [int]$behaviour.DeploymentType
            IsSoldier = [bool]$behaviour.IsSoldier
        }
    }

    $references = [Collections.Generic.List[object]]::new()
    for ($index = 0; $index -lt $rosterIds.Count; $index++) {
        $references.Add((Resolve-UnitReference $rosterIds[$index] $index $false))
    }
    for ($index = 0; $index -lt $additionalIds.Count; $index++) {
        $references.Add((Resolve-UnitReference $additionalIds[$index] $index $true))
    }

    $armyRows = @{}
    function Save-ArmyRow($Row) {
        if ($null -eq $Row) {
            return
        }
        foreach ($field in @(
            'unlockLevel', 'canBeBought', 'deliverySeconds', 'startingTier', 'startingLevel',
            'startingSpecial', 'startingElite', 'unitType', 'clientId', 'unlockTier2',
            'unlockTier3', 'unlockTier4', 'unlockTier5', 'unlockTier6'
        )) {
            if ($null -eq $Row[$field]) {
                throw "ArmyUpgrades row $($Row.name) is missing $field."
            }
        }
        if ($null -eq $Row.priceKey -or $null -eq $Row.priceHidden -or $null -eq $Row.goldKey -or $null -eq $Row.goldHidden) {
            throw "ArmyUpgrades row $($Row.name) has incomplete obscured prices."
        }
        $Row.warBucks = [int]([long]$Row.priceKey -bxor [long]$Row.priceHidden)
        $Row.gold = [int]([long]$Row.goldKey -bxor [long]$Row.goldHidden)
        $armyRows[[string]$Row.name] = $Row
    }

    # The ArmyUpgrades master table supplies purchase gates and initial state. PRICE and
    # PRICEGOLD are CodeStage ObscuredInt values; capture only their immediately nested
    # key/hidden pair so later obscured combat fields cannot overwrite currency balancing.
    $reader = [IO.File]::OpenText($scene)
    $row = $null
    $moneyField = $null
    try {
        while (($line = $reader.ReadLine()) -ne $null) {
            if ($line -match '^  - NAME: (Google2u\.DBUpgradeSlots[A-Za-z0-9_]+)$') {
                Save-ArmyRow $row
                $row = [ordered]@{
                    name = $Matches[1]
                    unlockLevel = $null
                    canBeBought = $null
                    priceKey = $null
                    priceHidden = $null
                    goldKey = $null
                    goldHidden = $null
                    warBucks = $null
                    gold = $null
                    deliverySeconds = $null
                    startingTier = $null
                    startingLevel = $null
                    startingSpecial = $null
                    startingElite = $null
                    unitType = $null
                    clientId = $null
                    unlockTier2 = $null
                    unlockTier3 = $null
                    unlockTier4 = $null
                    unlockTier5 = $null
                    unlockTier6 = $null
                }
                $moneyField = $null
                continue
            }
            if ($null -eq $row) {
                continue
            }
            if ($line -match '^--- !u!') {
                Save-ArmyRow $row
                $row = $null
                break
            }
            if ($line -match '^    UNLOCKLEVEL: (-?\d+)$') { $row.unlockLevel = [int]$Matches[1]; continue }
            if ($line -match '^    CANBEBOUGHT: (-?\d+)$') { $row.canBeBought = [int]$Matches[1]; continue }
            if ($line -match '^    DELIVERTIME: (-?\d+)$') { $row.deliverySeconds = [int]$Matches[1]; continue }
            if ($line -match '^    STARTINGTIER: (-?\d+)$') { $row.startingTier = [int]$Matches[1]; continue }
            if ($line -match '^    STARTINGLEVEL: (-?\d+)$') { $row.startingLevel = [int]$Matches[1]; continue }
            if ($line -match '^    STARTINGSPECIAL: (-?\d+)$') { $row.startingSpecial = [int]$Matches[1]; continue }
            if ($line -match '^    STARTINGELITE: (-?\d+)$') { $row.startingElite = [int]$Matches[1]; continue }
            if ($line -match '^    UNITTYPE: (-?\d+)$') { $row.unitType = [int]$Matches[1]; continue }
            if ($line -match '^    CLIENTID: (-?\d+)$') { $row.clientId = [int]$Matches[1]; continue }
            if ($line -match '^    UNLOCKTIER2: (-?\d+)$') { $row.unlockTier2 = [int]$Matches[1]; continue }
            if ($line -match '^    UNLOCKTIER3: (-?\d+)$') { $row.unlockTier3 = [int]$Matches[1]; continue }
            if ($line -match '^    UNLOCKTIER4: (-?\d+)$') { $row.unlockTier4 = [int]$Matches[1]; continue }
            if ($line -match '^    UNLOCKTIER5: (-?\d+)$') { $row.unlockTier5 = [int]$Matches[1]; continue }
            if ($line -match '^    UNLOCKTIER6: (-?\d+)$') { $row.unlockTier6 = [int]$Matches[1]; continue }
            if ($line -eq '    PRICE:') { $moneyField = 'price'; continue }
            if ($line -eq '    PRICEGOLD:') { $moneyField = 'gold'; continue }
            if ($line -match '^      currentCryptoKey: (\d+)$') {
                if ($moneyField -eq 'price') { $row.priceKey = [long]$Matches[1] }
                elseif ($moneyField -eq 'gold') { $row.goldKey = [long]$Matches[1] }
                continue
            }
            if ($line -match '^      hiddenValue: (\d+)$') {
                if ($moneyField -eq 'price') { $row.priceHidden = [long]$Matches[1] }
                elseif ($moneyField -eq 'gold') { $row.goldHidden = [long]$Matches[1] }
                $moneyField = $null
            }
        }
        Save-ArmyRow $row
    }
    finally {
        $reader.Dispose()
    }

    if ($armyRows.Count -ne 45) {
        throw "Expected 45 ArmyUpgrades rows, found $($armyRows.Count)."
    }
    $resolvedNames = [Collections.Generic.HashSet[string]]::new()
    $catalog = [Collections.Generic.List[object]]::new()
    foreach ($reference in $references) {
        if (-not $armyRows.ContainsKey($reference.Name)) {
            throw "Referenced unit row $($reference.Name) was not found in ArmyUpgrades."
        }
        [void]$resolvedNames.Add($reference.Name)
        $source = $armyRows[$reference.Name]
        if ($source.deliverySeconds -ne 0) {
            throw "Referenced 4.9.5 unit $($reference.Name) unexpectedly has a non-zero purchase delivery."
        }
        $catalog.Add([ordered]@{
            name = $reference.Name
            index = $reference.Index
            roster = if ($reference.Additional) { 'additional' } else { 'player' }
            behaviourType = $reference.BehaviourType
            upgradeType = $reference.UpgradeType
            tutorialUnit = $reference.TutorialUnit
            deploymentType = $reference.DeploymentType
            isSoldier = $reference.IsSoldier
            unlockLevel = $source.unlockLevel
            canBuyLevelIndex = $source.canBeBought
            warBucks = $source.warBucks
            gold = $source.gold
            deliverySeconds = $source.deliverySeconds
            startingTier = $source.startingTier
            startingLevel = $source.startingLevel
            startingSpecial = $source.startingSpecial
            startingElite = $source.startingElite
            unitType = $source.unitType
            clientId = $source.clientId
            unlockTierLevels = @(
                $source.unlockTier2,
                $source.unlockTier3,
                $source.unlockTier4,
                $source.unlockTier5,
                $source.unlockTier6
            )
        })
    }

    $unresolved = [Collections.Generic.List[object]]::new()
    foreach ($source in ($armyRows.Values | Sort-Object { [string]$_['name'] })) {
        if (-not $resolvedNames.Contains([string]$source.name)) {
            $unresolved.Add([ordered]@{
                name = $source.name
                unlockLevel = $source.unlockLevel
                canBuyLevelIndex = $source.canBeBought
                warBucks = $source.warBucks
                gold = $source.gold
                deliverySeconds = $source.deliverySeconds
                startingTier = $source.startingTier
                startingLevel = $source.startingLevel
                startingSpecial = $source.startingSpecial
                startingElite = $source.startingElite
                unitType = $source.unitType
                clientId = $source.clientId
                unlockTierLevels = @(
                    $source.unlockTier2,
                    $source.unlockTier3,
                    $source.unlockTier4,
                    $source.unlockTier5,
                    $source.unlockTier6
                )
            })
        }
    }
    if ($unresolved.Count -ne 18) {
        throw "Expected 18 unreferenced ArmyUpgrades rows, found $($unresolved.Count)."
    }

    # Each resolved Google2u component contains the per-level rows used by both UpgradeSlot
    # cursors. TIER encodes the slot in its tens digit: 0x is the normal path and 1x is the
    # special path. Preserve the absolute source index because STARTINGSPECIAL is an offset
    # into RowsGeneric, while SavedArmySlots.specialSlot stores a relative cursor.
    $upgradeComponentToName = @{}
    $playerReferences = @($references | Where-Object { -not $_.Additional })
    foreach ($reference in $playerReferences) {
        $upgradeComponentToName[[string]$reference.GoogleComponentId] = [string]$reference.Name
    }
    $upgradeRowsByName = @{}
    $activeUpgradeComponent = $null
    $activeUpgradeRows = $null
    $insideUpgradeRows = $false
    $upgradeRow = $null
    $upgradeSection = $null

    function Save-UnitUpgradeRow($Row, $Rows) {
        if ($null -eq $Row) { return }
        if ($null -eq $Row.tier) {
            throw "Unit upgrade component $activeUpgradeComponent has a row missing tier."
        }
        $tier = [int]$Row.tier
        if ($tier -lt 0) { return }
        foreach ($field in @('priceKey', 'priceHidden', 'priceGold', 'timeKey', 'timeHidden')) {
            if ($null -eq $Row[$field]) {
                throw "Unit upgrade component $activeUpgradeComponent has a row missing $field."
            }
        }
        $slot = [Math]::Floor($tier / 10)
        if ($slot -notin @(0, 1)) {
            # Elite/card/arena rows use different state and currency contracts. They remain in
            # the source table but cannot enter the normal/special RequestBuffer lifecycle.
            return
        }
        if ([int]$Row.priceGold -ne 0) {
            throw "Unexpected premium currency in unit upgrade row $($Row.index)."
        }
        $delivery = Decode-ObscuredFloat ([uint32]$Row.timeKey) ([string]$Row.timeHidden)
        $roundedDelivery = [int][Math]::Round($delivery)
        if ([Math]::Abs($delivery - $roundedDelivery) -gt 0.001 -or $roundedDelivery -lt 0) {
            throw "Unit upgrade row $($Row.index) has invalid delivery time $delivery."
        }
        $Rows.Add([ordered]@{
            sourceIndex = [int]$Row.index
            tier = $tier % 10
            slot = [int]$slot
            warBucks = [int]([long]$Row.priceKey -bxor [long]$Row.priceHidden)
            deliverySeconds = $roundedDelivery
        })
    }

    function Finish-UnitUpgradeComponent {
        if ($null -ne $script:activeUpgradeComponent) {
            Save-UnitUpgradeRow $script:upgradeRow $script:activeUpgradeRows
            $name = $script:upgradeComponentToName[[string]$script:activeUpgradeComponent]
            $script:upgradeRowsByName[$name] = @($script:activeUpgradeRows)
        }
        $script:activeUpgradeComponent = $null
        $script:activeUpgradeRows = $null
        $script:insideUpgradeRows = $false
        $script:upgradeRow = $null
        $script:upgradeSection = $null
    }

    $reader = [IO.File]::OpenText($scene)
    try {
        while (($line = $reader.ReadLine()) -ne $null) {
            if ($line -match '^--- !u![0-9]+ &(\d+)$') {
                Finish-UnitUpgradeComponent
                if ($upgradeComponentToName.ContainsKey($Matches[1])) {
                    $activeUpgradeComponent = $Matches[1]
                    $activeUpgradeRows = [Collections.Generic.List[object]]::new()
                }
                continue
            }
            if ($null -eq $activeUpgradeComponent) { continue }
            if (-not $insideUpgradeRows) {
                if ($line -eq '  Rows:') { $insideUpgradeRows = $true }
                continue
            }
            if ($line -match '^  - TIER: (-?\d+)$') {
                Save-UnitUpgradeRow $upgradeRow $activeUpgradeRows
                $upgradeRow = [ordered]@{
                    index = $activeUpgradeRows.Count
                    tier = [int]$Matches[1]
                    priceKey = $null
                    priceHidden = $null
                    priceGold = $null
                    timeKey = $null
                    timeHidden = $null
                }
                $upgradeSection = $null
                continue
            }
            if ($null -eq $upgradeRow) { continue }
            if ($line -match '^    TIER: (-?\d+)$') { $upgradeRow.tier = [int]$Matches[1]; continue }
            if ($line -eq '    NEXTUPGRADEPRICE:') { $upgradeSection = 'price'; continue }
            if ($line -match '^    NEXTUPGRADEPRICEGOLD: (-?\d+)$') {
                $upgradeRow.priceGold = [int]$Matches[1]
                $upgradeSection = $null
                continue
            }
            if ($line -eq '    DELIVERYTIME:') { $upgradeSection = 'time'; continue }
            if ($line -match '^    [A-Z][A-Z0-9_]*:') { $upgradeSection = $null; continue }
            if ($line -match '^      currentCryptoKey: (\d+)$') {
                if ($upgradeSection -eq 'price') { $upgradeRow.priceKey = [long]$Matches[1] }
                elseif ($upgradeSection -eq 'time') { $upgradeRow.timeKey = [uint32]$Matches[1] }
                continue
            }
            if ($line -match '^      hiddenValue: ([0-9a-fA-F]+)$') {
                if ($upgradeSection -eq 'price') { $upgradeRow.priceHidden = [long]$Matches[1] }
                elseif ($upgradeSection -eq 'time') { $upgradeRow.timeHidden = $Matches[1] }
            }
        }
        Finish-UnitUpgradeComponent
    }
    finally {
        $reader.Dispose()
    }
    if ($upgradeRowsByName.Count -ne $playerReferences.Count) {
        throw "Expected $($playerReferences.Count) player unit upgrade tables, found $($upgradeRowsByName.Count)."
    }

    $upgradeCatalog = [Collections.Generic.List[object]]::new()
    foreach ($reference in $playerReferences) {
        $source = $armyRows[$reference.Name]
        $rows = @($upgradeRowsByName[$reference.Name])
        $normal = @($rows | Where-Object { $_.slot -eq 0 })
        $special = @($rows | Where-Object { $_.slot -eq 1 })
        if ($normal.Count -lt 2 -or $special.Count -lt 2) {
            throw "$($reference.Name) has incomplete normal/special upgrade ranges."
        }
        if ($normal[0].sourceIndex -ne 0 -or $special[0].sourceIndex -ne $source.startingSpecial) {
            throw "$($reference.Name) upgrade offsets disagree with ArmyUpgrades.STARTINGSPECIAL."
        }
        $upgradeCatalog.Add([ordered]@{
            name = $reference.Name
            normalLevels = $normal
            specialLevels = $special
        })
    }

    $artifact = [ordered]@{
        schemaVersion = 1
        source = 'Client/ExportedProject/Assets/Scenes/MainScene.unity'
        sourceSha256 = (Get-FileHash -LiteralPath $scene -Algorithm SHA256).Hash.ToLowerInvariant()
        catalog = $catalog
        unresolvedRows = $unresolved
    }
    $upgradeArtifact = [ordered]@{
        schemaVersion = 1
        source = 'Client/ExportedProject/Assets/Scenes/MainScene.unity'
        sourceSha256 = (Get-FileHash -LiteralPath $scene -Algorithm SHA256).Hash.ToLowerInvariant()
        catalog = $upgradeCatalog
    }
    $expectedText = ($artifact | ConvertTo-Json -Depth 8) + [Environment]::NewLine
    $expectedUpgradeText = ($upgradeArtifact | ConvertTo-Json -Depth 10) + [Environment]::NewLine
    if ($Check) {
        $resolvedOutput = Resolve-RequiredFile $OutputPath "Generated unit catalog"
        if ([IO.File]::ReadAllText($resolvedOutput) -ne $expectedText) {
            throw "Generated unit catalog is stale. Run Tools\Extract-UnitCatalog.ps1."
        }
        $resolvedUpgradeOutput = Resolve-RequiredFile $UpgradeOutputPath "Generated unit upgrade catalog"
        if ([IO.File]::ReadAllText($resolvedUpgradeOutput) -ne $expectedUpgradeText) {
            throw "Generated unit upgrade catalog is stale. Run Tools\Extract-UnitCatalog.ps1."
        }
        Write-Host "Unit catalogs are current: 24 player rows, 3 helpers, 18 unresolved rows, and 24 upgrade tables."
    }
    else {
        $directory = Split-Path -Parent $OutputPath
        if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
            [void](New-Item -ItemType Directory -Path $directory)
        }
        [IO.File]::WriteAllText($OutputPath, $expectedText, [Text.UTF8Encoding]::new($false))
        $upgradeDirectory = Split-Path -Parent $UpgradeOutputPath
        if (-not (Test-Path -LiteralPath $upgradeDirectory -PathType Container)) {
            [void](New-Item -ItemType Directory -Path $upgradeDirectory)
        }
        [IO.File]::WriteAllText($UpgradeOutputPath, $expectedUpgradeText, [Text.UTF8Encoding]::new($false))
        Write-Host "Wrote unit purchase and upgrade artifacts with 24 player upgrade tables."
    }
}
finally {
    if (Test-Path -LiteralPath $temporaryRoot -PathType Container) {
        Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
    }
}
