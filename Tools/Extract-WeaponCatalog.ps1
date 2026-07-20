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
    $OutputPath = Join-Path $repoRoot "Server\src\data\weaponCatalog.generated.json"
}

function Resolve-RequiredFile([string]$Path, [string]$Description) {
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "$Description was not found: $Path"
    }
    return (Resolve-Path -LiteralPath $Path).Path
}

function Read-PluginGuid([string]$AssemblyPath) {
    $metaPath = "$AssemblyPath.meta"
    $match = Select-String -LiteralPath $metaPath -Pattern '^guid: ([0-9a-f]{32})$' | Select-Object -First 1
    if (-not $match) {
        throw "Unity plugin GUID was not found in $metaPath"
    }
    return $match.Matches[0].Groups[1].Value
}

$scene = Resolve-RequiredFile $ScenePath "Recovered MainScene"
$patcherProject = Resolve-RequiredFile (Join-Path $PSScriptRoot "LegacyAssemblyPatcher\LegacyAssemblyPatcher.csproj") "Script type mapper"
$pluginRoot = Join-Path $repoRoot "Client\ExportedProject\Assets\Plugins"
$sourceAssembly = Resolve-RequiredFile (Join-Path $pluginRoot "WarFriends.Gameplay.FirstPass.dll") "Recovered FirstPass assembly"
$compatibilityAssembly = Resolve-RequiredFile (Join-Path $pluginRoot "WarFriends.ResourceCompatibility.FirstPass.dll") "Compatibility FirstPass assembly"

$temporaryRoot = Join-Path ([IO.Path]::GetTempPath()) ("warfriends-weapon-catalog-" + [Guid]::NewGuid().ToString("N"))
[void](New-Item -ItemType Directory -Path $temporaryRoot)

function Read-GoogleTypeMap([string]$AssemblyPath, [string]$MapName) {
    $mapPath = Join-Path $temporaryRoot "$MapName.csv"
    & dotnet run --project $patcherProject -- $AssemblyPath --dump-script-types $mapPath | Out-Host
    if ($LASTEXITCODE -ne 0) {
        throw "Could not read Unity script types from $AssemblyPath"
    }

    $types = @{}
    foreach ($row in (Import-Csv -LiteralPath $mapPath)) {
        if ($row.namespace -eq "Google2u" -and $row.full_name -like "Google2u.*") {
            $types[[string]$row.file_id] = [string]$row.full_name
        }
    }
    return [pscustomobject]@{
        Guid = Read-PluginGuid $AssemblyPath
        Types = $types
    }
}

try {
    # Unity stores DLL-backed MonoScript references as a signed MD4-derived file ID plus the
    # plugin GUID. LegacyAssemblyPatcher already implements Unity's exact file-ID algorithm,
    # so use it for both original and compatibility assemblies instead of guessing class names.
    $typeMapsByGuid = @{}
    foreach ($map in @(
        (Read-GoogleTypeMap $sourceAssembly "source-types"),
        (Read-GoogleTypeMap $compatibilityAssembly "compatibility-types")
    )) {
        $typeMapsByGuid[$map.Guid] = $map.Types
    }

    # First pass: recover the ordered LevelManager reference array. Its array position is the
    # integer sent by EquipWeapon; Google2u row order is unrelated and must never be substituted.
    $setupIds = [Collections.Generic.List[string]]::new()
    $reader = [IO.File]::OpenText($scene)
    try {
        $insideSetupList = $false
        while (($line = $reader.ReadLine()) -ne $null) {
            if ($line -eq "  weaponLevelsSetups:") {
                $insideSetupList = $true
                continue
            }
            if ($insideSetupList) {
                if ($line -match '^  - \{fileID: (\d+)\}$') {
                    $setupIds.Add($Matches[1])
                    continue
                }
                break
            }
        }
    }
    finally {
        $reader.Dispose()
    }
    if ($setupIds.Count -eq 0) {
        throw "LevelManager.weaponLevelsSetups was not found in $scene"
    }

    $setupIdSet = [Collections.Generic.HashSet[string]]::new([string[]]$setupIds)
    $setups = @{}
    $googleTypesByGameObject = @{}

    function Save-MonoBehaviourBlock($Block) {
        if ($null -eq $Block) {
            return
        }

        $id = [string]$Block.id
        if ($setupIdSet.Contains($id)) {
            $setups[$id] = $Block
        }

        $guid = [string]$Block.guid
        if (-not $typeMapsByGuid.ContainsKey($guid)) {
            return
        }
        $typeMap = $typeMapsByGuid[$guid]
        $scriptId = [string]$Block.scriptId
        if (-not $typeMap.ContainsKey($scriptId)) {
            return
        }

        $gameObject = [string]$Block.gameObject
        $typeName = [string]$typeMap[$scriptId]
        if (-not $googleTypesByGameObject.ContainsKey($gameObject)) {
            $googleTypesByGameObject[$gameObject] = [Collections.Generic.HashSet[string]]::new()
        }
        [void]$googleTypesByGameObject[$gameObject].Add($typeName)
    }

    # Second pass: join each setup to the Google2u component on the same GameObject. This
    # resolves aliases such as RocketLauncher_RPG7 -> Google2u.Bazooka_RPG7 without a manual
    # spelling table and also covers compatibility components added during project recovery.
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
                        codeName = ""
                        sheetHint = ""
                        category = $null
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
            elseif ($line -match '^  CKNHABFHJIP: (.*)$') {
                $block.codeName = $Matches[1]
            }
            elseif ($line -match '^  IMMNMGDBOOD: (.*)$') {
                $block.sheetHint = $Matches[1]
            }
            elseif ($line -match '^  BHCEOOLEHHG: (-?\d+)$') {
                $block.category = [int]$Matches[1]
            }
        }
        Save-MonoBehaviourBlock $block
    }
    finally {
        $reader.Dispose()
    }

    $weaponRows = @{}
    function Save-WeaponRow($Row) {
        if ($null -eq $Row) {
            return
        }
        $required = @("unlockLevel", "canBeBought", "deliverySeconds", "purchasable", "category")
        foreach ($field in $required) {
            if ($null -eq $Row[$field] -or [string]::IsNullOrWhiteSpace([string]$Row[$field])) {
                return
            }
        }
        $weaponRows[[string]$Row.name] = $Row
    }

    # Third pass: read the master weapon balancing rows. PRICE and PRICEGOLD are CodeStage
    # ObscuredInt values. Only the immediately nested key/hidden pair belongs to that price;
    # later obscured combat fields must not overwrite it.
    $reader = [IO.File]::OpenText($scene)
    $row = $null
    $moneyField = $null
    try {
        while (($line = $reader.ReadLine()) -ne $null) {
            if ($line -match '^  - NAME: (Google2u\.[A-Za-z0-9_]+)$') {
                Save-WeaponRow $row
                $row = [ordered]@{
                    name = $Matches[1]
                    unlockLevel = $null
                    canBeBought = $null
                    priceKey = $null
                    priceHidden = $null
                    priceValue = $null
                    goldKey = $null
                    goldHidden = $null
                    goldValue = $null
                    deliverySeconds = $null
                    purchasable = ""
                    category = $null
                }
                $moneyField = $null
                continue
            }
            if ($null -eq $row) {
                continue
            }
            if ($line -match '^  - NAME:' -or $line -match '^--- !u!') {
                Save-WeaponRow $row
                $row = $null
                $moneyField = $null
                continue
            }

            if ($line -match '^    UNLOCKLEVEL: (-?\d+)$') {
                $row.unlockLevel = [int]$Matches[1]
            }
            elseif ($line -match '^    CANBEBOUGHT: (-?\d+)$') {
                $row.canBeBought = [int]$Matches[1]
            }
            elseif ($line -match '^    PRICE: (-?\d+)$') {
                $row.priceValue = [int64]$Matches[1]
                $moneyField = $null
            }
            elseif ($line -match '^    PRICEGOLD: (-?\d+)$') {
                $row.goldValue = [int64]$Matches[1]
                $moneyField = $null
            }
            elseif ($line -eq "    PRICE:") {
                $moneyField = "price"
            }
            elseif ($line -eq "    PRICEGOLD:") {
                $moneyField = "gold"
            }
            elseif ($moneyField -and $line -match '^      currentCryptoKey: (-?\d+)$') {
                $row["${moneyField}Key"] = [int64]$Matches[1]
            }
            elseif ($moneyField -and $line -match '^      hiddenValue: (-?\d+)$') {
                $row["${moneyField}Hidden"] = [int64]$Matches[1]
                $moneyField = $null
            }
            elseif ($line -match '^    DELIVERTIME: (-?\d+)$') {
                $row.deliverySeconds = [int]$Matches[1]
            }
            elseif ($line -match '^    PURCHASABLE: (.*)$') {
                $row.purchasable = $Matches[1]
            }
            elseif ($line -match '^    WEAPONCATEGORY: (-?\d+)$') {
                $row.category = [int]$Matches[1]
            }
        }
        Save-WeaponRow $row
    }
    finally {
        $reader.Dispose()
    }

    function Decode-Price($Row, [string]$Prefix) {
        $direct = $Row["${Prefix}Value"]
        if ($null -ne $direct) {
            return [int64]$direct
        }
        $key = $Row["${Prefix}Key"]
        $hidden = $Row["${Prefix}Hidden"]
        if ($null -eq $key -or $null -eq $hidden) {
            throw "$($Row.name) has no complete $Prefix price."
        }
        return [int64]$key -bxor [int64]$hidden
    }

    $starterNames = [Collections.Generic.HashSet[string]]::new([string[]]@(
        "Google2u.AssaultRifle_AK47",
        "Google2u.SniperRifle_M24",
        "Google2u.Grenade_FRAG",
        "Google2u.Pistol_Remmington51"
    ))
    $mappedNames = [Collections.Generic.HashSet[string]]::new()
    $catalog = [Collections.Generic.List[object]]::new()
    $blackMarketCatalog = [Collections.Generic.List[object]]::new()
    $unresolvedSetups = [Collections.Generic.List[object]]::new()

    for ($index = 0; $index -lt $setupIds.Count; $index++) {
        $setupId = $setupIds[$index]
        if ($setupId -eq "0") {
            continue
        }
        if (-not $setups.ContainsKey($setupId)) {
            throw "LevelManager index $index references missing setup component $setupId."
        }

        $setup = $setups[$setupId]
        $gameObject = [string]$setup.gameObject
        if (-not $googleTypesByGameObject.ContainsKey($gameObject)) {
            $unresolvedSetups.Add([ordered]@{ index = $index; setupId = $setupId; codeName = $setup.codeName })
            continue
        }
        $candidateTypes = @($googleTypesByGameObject[$gameObject] | Where-Object { $weaponRows.ContainsKey($_) })
        if ($candidateTypes.Count -ne 1) {
            $unresolvedSetups.Add([ordered]@{
                index = $index
                setupId = $setupId
                codeName = $setup.codeName
                candidateTypes = @($candidateTypes)
            })
            continue
        }
        $typeName = [string]$candidateTypes[0]

        $weaponRow = $weaponRows[$typeName]
        [void]$mappedNames.Add($typeName)
        if ([int]$setup.category -ne [int]$weaponRow.category) {
            throw "$typeName category differs between LevelManager and the balancing row."
        }
        $resolved = [ordered]@{
            name = $typeName
            index = $index
            category = [int]$weaponRow.category
            canBuyLevelIndex = [Math]::Max(0, [int]$weaponRow.canBeBought - 1)
            unlockLevel = [int]$weaponRow.unlockLevel
            warBucks = Decode-Price $weaponRow "price"
            gold = Decode-Price $weaponRow "gold"
            deliverySeconds = [int]$weaponRow.deliverySeconds
            starterOwned = $starterNames.Contains($typeName)
        }
        if ($weaponRow.purchasable -eq "shop") {
            $catalog.Add($resolved)
        }
        elseif ($weaponRow.purchasable -eq "blackmarket") {
            # These are distinct LevelManager weapon setups, not discounted aliases of shop
            # rows. Their master PRICE fields are retained for audit, while actual redemption
            # Gold comes from the selected level table's WEAPONPRICE.
            $resolved.starterOwned = $false
            $blackMarketCatalog.Add($resolved)
        }
    }

    $unresolvedShopRows = [Collections.Generic.List[object]]::new()
    $unresolvedBlackMarketRows = [Collections.Generic.List[object]]::new()
    foreach ($weaponRow in ($weaponRows.Values | Sort-Object { [string]$_['name'] })) {
        if ($mappedNames.Contains([string]$weaponRow.name)) {
            continue
        }
        if ($weaponRow.purchasable -ne "shop" -and $weaponRow.purchasable -ne "blackmarket") {
            continue
        }
        $unresolved = [ordered]@{
            name = [string]$weaponRow.name
            category = [int]$weaponRow.category
            canBuyLevelIndex = [Math]::Max(0, [int]$weaponRow.canBeBought - 1)
            unlockLevel = [int]$weaponRow.unlockLevel
            warBucks = Decode-Price $weaponRow "price"
            gold = Decode-Price $weaponRow "gold"
            deliverySeconds = [int]$weaponRow.deliverySeconds
            reason = "No non-null LevelManager.weaponLevelsSetups entry resolves this row."
        }
        if ($weaponRow.purchasable -eq "shop") {
            $unresolvedShopRows.Add($unresolved)
        }
        else {
            $unresolvedBlackMarketRows.Add($unresolved)
        }
    }

    # OrderedDictionary keys are not normal CLR properties, so use explicit indexers in sort
    # expressions. Plain `Sort-Object index` silently treats every key as null and leaves the
    # hash-derived input order intact on Windows PowerShell 5.1.
    $orderedCatalog = @($catalog | Sort-Object { [int]$_['index'] })
    $orderedBlackMarketCatalog = @($blackMarketCatalog | Sort-Object { [int]$_['index'] })
    if ($orderedCatalog.Count -ne 84) {
        throw "Expected 84 resolvable shop weapons from the 4.9.5 scene, found $($orderedCatalog.Count)."
    }
    if ($unresolvedShopRows.Count -ne 9) {
        throw "Expected 9 unresolved shop rows from the 4.9.5 scene, found $($unresolvedShopRows.Count)."
    }
    if ($orderedBlackMarketCatalog.Count -ne 81) {
        throw "Expected 81 resolvable Black Market weapons from the 4.9.5 scene, found $($orderedBlackMarketCatalog.Count)."
    }
    if ($unresolvedBlackMarketRows.Count -ne 9) {
        throw "Expected 9 unresolved Black Market rows from the 4.9.5 scene, found $($unresolvedBlackMarketRows.Count)."
    }
    if (@($orderedCatalog | Where-Object { $_.deliverySeconds -ne 0 }).Count -ne 0) {
        throw "At least one enabled shop weapon has a non-zero delivery time."
    }
    foreach ($starterName in $starterNames) {
        if (@($orderedCatalog | Where-Object { $_.name -eq $starterName -and $_.starterOwned }).Count -ne 1) {
            throw "Starter weapon $starterName was not resolved exactly once."
        }
    }

    $relativeScene = $scene.Substring($repoRoot.Length).TrimStart('\', '/') -replace '\\', '/'
    $document = [ordered]@{
        schemaVersion = 1
        source = $relativeScene
        sourceSha256 = (Get-FileHash -LiteralPath $scene -Algorithm SHA256).Hash.ToLowerInvariant()
        catalog = $orderedCatalog
        unresolvedShopRows = @($unresolvedShopRows | Sort-Object { [string]$_['name'] })
        blackMarketCatalog = $orderedBlackMarketCatalog
        unresolvedBlackMarketRows = @($unresolvedBlackMarketRows | Sort-Object { [string]$_['name'] })
    }
    $json = $document | ConvertTo-Json -Depth 6
    $expectedText = $json + [Environment]::NewLine

    if ($Check) {
        if (-not (Test-Path -LiteralPath $OutputPath -PathType Leaf)) {
            throw "Generated catalog is missing: $OutputPath"
        }
        $actualText = [IO.File]::ReadAllText((Resolve-Path -LiteralPath $OutputPath).Path)
        if ($actualText -ne $expectedText) {
            throw "Generated catalog is stale. Run Tools\Extract-WeaponCatalog.ps1 and commit the result."
        }
        Write-Host "Weapon catalog is current: 84 shop rows, $($orderedBlackMarketCatalog.Count) Black Market rows, 9 unresolved shop rows, and $($unresolvedBlackMarketRows.Count) unresolved Black Market rows."
    }
    else {
        $outputDirectory = Split-Path -Parent $OutputPath
        if (-not (Test-Path -LiteralPath $outputDirectory -PathType Container)) {
            [void](New-Item -ItemType Directory -Path $outputDirectory)
        }
        [IO.File]::WriteAllText($OutputPath, $expectedText, [Text.UTF8Encoding]::new($false))
        Write-Host "Wrote $OutputPath with 84 shop rows, $($orderedBlackMarketCatalog.Count) Black Market rows, 9 unresolved shop rows, and $($unresolvedBlackMarketRows.Count) unresolved Black Market rows."
    }

    if ($unresolvedSetups.Count -gt 0) {
        Write-Host "Note: $($unresolvedSetups.Count) concrete LevelManager setups have no recoverable Google2u row and remain disabled."
    }
}
finally {
    if (Test-Path -LiteralPath $temporaryRoot) {
        Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
    }
}
