param(
    [string]$ScenePath,
    [string]$OutputPath,
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
        $googleTypes = @(
            $componentsByGameObject[$upgrade.GameObject] |
                Where-Object { $_.TypeName -like 'Google2u.DBUpgradeSlots*' } |
                Select-Object -ExpandProperty TypeName -Unique
        )
        if ($googleTypes.Count -ne 1) {
            throw "UpgradeSlots $($upgrade.Id) resolved $($googleTypes.Count) Google2u unit tables."
        }
        return [pscustomobject]@{
            Name = [string]$googleTypes[0]
            Index = $Index
            Additional = $Additional
            BehaviourType = [string]$behaviour.TypeName
            UpgradeType = [string]$upgrade.TypeName
            TutorialUnit = [bool]$upgrade.TutorialUnit
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
        foreach ($field in @('unlockLevel', 'canBeBought', 'deliverySeconds', 'startingTier', 'startingLevel', 'unitType', 'clientId')) {
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
                    unitType = $null
                    clientId = $null
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
            if ($line -match '^    UNITTYPE: (-?\d+)$') { $row.unitType = [int]$Matches[1]; continue }
            if ($line -match '^    CLIENTID: (-?\d+)$') { $row.clientId = [int]$Matches[1]; continue }
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
            unlockLevel = $source.unlockLevel
            canBuyLevelIndex = $source.canBeBought
            warBucks = $source.warBucks
            gold = $source.gold
            deliverySeconds = $source.deliverySeconds
            startingTier = $source.startingTier
            startingLevel = $source.startingLevel
            unitType = $source.unitType
            clientId = $source.clientId
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
                unitType = $source.unitType
                clientId = $source.clientId
            })
        }
    }
    if ($unresolved.Count -ne 18) {
        throw "Expected 18 unreferenced ArmyUpgrades rows, found $($unresolved.Count)."
    }

    $artifact = [ordered]@{
        schemaVersion = 1
        source = 'Client/ExportedProject/Assets/Scenes/MainScene.unity'
        sourceSha256 = (Get-FileHash -LiteralPath $scene -Algorithm SHA256).Hash.ToLowerInvariant()
        catalog = $catalog
        unresolvedRows = $unresolved
    }
    $expectedText = ($artifact | ConvertTo-Json -Depth 8) + [Environment]::NewLine
    if ($Check) {
        $resolvedOutput = Resolve-RequiredFile $OutputPath "Generated unit catalog"
        if ([IO.File]::ReadAllText($resolvedOutput) -ne $expectedText) {
            throw "Generated unit catalog is stale. Run Tools\Extract-UnitCatalog.ps1."
        }
        Write-Host "Unit catalog is current: 24 player rows, 3 additional rows, 18 unresolved rows."
    }
    else {
        $directory = Split-Path -Parent $OutputPath
        if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
            [void](New-Item -ItemType Directory -Path $directory)
        }
        [IO.File]::WriteAllText($OutputPath, $expectedText, [Text.UTF8Encoding]::new($false))
        Write-Host "Wrote $OutputPath with 24 player rows, 3 additional rows, and 18 unresolved rows."
    }
}
finally {
    if (Test-Path -LiteralPath $temporaryRoot -PathType Container) {
        Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
    }
}
