# Drives the recovered 1.4.0 client's own boot chain against a live backend.
#
# The request shapes here are copied from BeanstalkServerManager.GetServerRequest and the response
# assertions from ServerResponseHandler: this script fails if the server stops speaking what the
# shipped client parses. It starts an isolated mongod and backend, stops only what it started, and
# restores the calling environment.
param([string]$MongoExecutable = 'mongod', [int]$HttpPort = 18081, [int]$MongoPort = 27029, [string]$ContentPath = '')
$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
if ([string]::IsNullOrEmpty($ContentPath)) { $ContentPath = Join-Path $serverRoot 'content/recovered-battle-content.json' }
$runRoot = Join-Path $serverRoot ('.local/legacy-' + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path (Join-Path $runRoot 'mongo') -Force | Out-Null
$processes = @()
$variables = @('ASPNETCORE_ENVIRONMENT', 'ASPNETCORE_URLS', 'Mongo__Uri', 'Mongo__Database', 'Battle__SigningKey', 'Battle__ControlKey', 'Legacy__ContentPath', 'RateLimiting__Api__PermitLimit')
$prior = @{}
foreach ($name in $variables) { $prior[$name] = [Environment]::GetEnvironmentVariable($name, 'Process') }

$script:checks = 0
function Assert([bool]$condition, [string]$description) {
    $script:checks++
    if (-not $condition) { throw "FAILED: $description" }
    Write-Host "  ok  $description"
}

# The client's envelope: SheetConfig, requestId, Version, Os, then Token/PlayerId for every action
# outside the account-management set {118, 146, 30}.
function Send([int]$RequestId, [hashtable]$Fields = @{}, [string]$Token, [string]$PlayerId) {
    $body = @{ SheetConfig = '0'; requestId = "$RequestId"; Version = '1.4.0'; Os = 'android' }
    if ($PSBoundParameters.ContainsKey('Token')) { $body['Token'] = $Token }
    if ($PSBoundParameters.ContainsKey('PlayerId')) { $body['PlayerId'] = $PlayerId }
    foreach ($key in $Fields.Keys) { $body[$key] = $Fields[$key] }
    Invoke-WebRequest "http://127.0.0.1:$HttpPort/index_09_25_2015.php" -Method Post -Body $body `
        -Headers @{ 'App-Version' = '1.4.0' } -UseBasicParsing -TimeoutSec 10
}
function SendJson([int]$RequestId, [hashtable]$Fields = @{}, [string]$Token, [string]$PlayerId) {
    (Send @PSBoundParameters).Content | ConvertFrom-Json
}

try {
    dotnet build (Join-Path $serverRoot 'WarFriendsServer.sln') --nologo -v minimal
    if ($LASTEXITCODE -ne 0) { throw 'Build failed' }
    $keyBytes = New-Object byte[] 32
    $rng = [Security.Cryptography.RandomNumberGenerator]::Create()
    $rng.GetBytes($keyBytes)
    $rng.Dispose()
    $env:Battle__SigningKey = [Convert]::ToBase64String($keyBytes)
    $controlBytes = New-Object byte[] 32
    [Security.Cryptography.RandomNumberGenerator]::Fill($controlBytes)
    $env:Battle__ControlKey = [Convert]::ToBase64String($controlBytes)
    $env:ASPNETCORE_ENVIRONMENT = 'Development'
    $env:ASPNETCORE_URLS = "http://127.0.0.1:$HttpPort"
    $env:Mongo__Uri = "mongodb://127.0.0.1:$MongoPort"
    $env:Mongo__Database = 'warfriends_legacy_smoke'
    # This script is a single fast sequential client sharing one IP; the production default
    # (120/min, unaffected here) would otherwise 429 once assertion count grows past it.
    $env:RateLimiting__Api__PermitLimit = '2000'
    # Load the real recovered economy catalog when present, so pricing assertions below check
    # against verified game-balance numbers rather than a mock. Absent is not a script failure —
    # the same graceful-degradation path Program.cs takes when Legacy:ContentPath is unset.
    $catalogLoaded = Test-Path $ContentPath
    if ($catalogLoaded) { $env:Legacy__ContentPath = $ContentPath } else { Write-Host "Catalog not found at $ContentPath; pricing assertions will check the refusal path instead." }
    $mongoArgs = @('--dbpath', ('"' + (Join-Path $runRoot 'mongo') + '"'), '--bind_ip', '127.0.0.1', '--port', "$MongoPort", '--logpath', ('"' + (Join-Path $runRoot 'mongo.log') + '"'))
    $processes += Start-Process $MongoExecutable -ArgumentList $mongoArgs -PassThru -WindowStyle Hidden
    $dll = Join-Path $serverRoot 'src/War.Backend/bin/Debug/net10.0/War.Backend.dll'
    $processes += Start-Process dotnet -ArgumentList ('"' + $dll + '"') -WorkingDirectory (Join-Path $serverRoot 'src/War.Backend') `
        -RedirectStandardOutput (Join-Path $runRoot 'backend.log') -RedirectStandardError (Join-Path $runRoot 'backend.error.log') -PassThru -WindowStyle Hidden
    $ready = $false
    for ($i = 0; $i -lt 40; $i++) {
        if (@($processes | Where-Object HasExited).Count -gt 0) { throw "A service stopped; inspect $runRoot" }
        try { $null = Invoke-WebRequest "http://127.0.0.1:$HttpPort/health/ready" -UseBasicParsing -TimeoutSec 1; $ready = $true; break } catch { Start-Sleep -Milliseconds 250 }
    }
    if (-not $ready) { throw "Backend not ready; inspect $runRoot" }

    Write-Host "`nReachability probe (check.php)"
    # BeanstalkServerManager.GetCheckRequest demands the body be exactly "ok".
    $check = Invoke-WebRequest "http://127.0.0.1:$HttpPort/check.php" -UseBasicParsing -TimeoutSec 10
    Assert ($check.Content -ceq 'ok') 'check.php body is exactly "ok"'

    Write-Host "`nGetConfigurations (157)"
    # GameConfigurationManager.PrepareConfigurations splits on ';' and requires segment 1 = "success".
    $configs = (Send -RequestId 157 -Token 'null' -PlayerId 'null').Content
    $segments = $configs -split ';'
    Assert ($segments[0] -ceq 'success') 'configurations segment 1 is "success"'
    Assert ($segments.Count -ge 3) 'configurations carry a version and a versions object'
    Assert ($null -ne ($segments[2] | ConvertFrom-Json)) 'configurations segment 3 parses as JSON'

    Write-Host "`nCreateAccount (118)"
    $created = SendJson -RequestId 118 -Fields @{ UtcOffset = '0'; Locale = 'en'; StartingGold = '999999' }
    Assert ($created.Result -eq 1) 'CreateAccount returns Result = Success'
    # OnCreateAccount indexes all five of these without a presence check.
    foreach ($key in 'Player', 'Token', 'Password', 'PlayerData', 'Time') {
        Assert ($null -ne $created.$key) "CreateAccount response carries $key"
    }
    $playerId = $created.Player.Id.S
    Assert (-not [string]::IsNullOrEmpty($playerId)) 'Player.Id uses the S attribute shape'
    Assert ($null -ne $created.Player.Level.N) 'Player.Level uses the N attribute shape'
    $expectedStartGold = if ($catalogLoaded) { '75' } else { '500' }
    Assert ($created.PlayerData.Gold.N -eq $expectedStartGold) 'PlayerData.Gold is the server starter value, not the client-reported StartingGold'
    if ($catalogLoaded) { Assert ($created.PlayerData.WarBucks.N -eq '15000') 'PlayerData.WarBucks matches the verified Google2u.Constants StartingWarbucks value' }
    Assert ($null -eq $created.PlayerData.TutorialData) 'a new account omits TutorialData so the client runs the tutorial'
    # Absent subsystem blobs are the client's LoadEmpty() path, not an error.
    Assert ($null -eq $created.PlayerData.CardManagerData) 'a new account omits subsystem blobs'
    # The client reads these with Convert.ToInt32 straight off the dictionary, so they must be bare
    # numbers; an AttributeValue would deserialize to an object and throw.
    Assert ($created.Time -isnot [PSCustomObject]) 'Time is a plain number, not an AttributeValue'
    Assert ($created.Result -isnot [PSCustomObject]) 'Result is a plain number, not an AttributeValue'

    Write-Host "`nLoginToCustomAccount (30)"
    $login = SendJson -RequestId 30 -Fields @{ Id = $playerId; Password = $created.Password; AccountType = '0' }
    Assert ($login.Result -eq 1) 'Login with the issued password succeeds'
    foreach ($key in 'Player', 'AccountType', 'Token', 'Password') {
        Assert ($null -ne $login.$key) "Login response carries $key"
    }
    Assert ($login.Token -ne $created.Token) 'Login rotates the session token'
    $token = $login.Token

    Write-Host "`nGetPlayerData (34)"
    $data = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
    Assert ($data.Result -eq 1) 'GetPlayerData succeeds with the rotated token'
    Assert ($null -ne $data.Time) 'GetPlayerData carries Time'
    Assert ($null -ne $data.PlayerData) 'GetPlayerData carries PlayerData'
    Assert ($null -eq $data.Squad) 'a squadless player omits Squad'
    # DogTagManager.max = DogTagCap * DogTagRefillTime (a count times a per-tag regen period, in
    # seconds), not the bare tag count — DogTagCap=5, DogTagRefillTime=900 in the verified catalog.
    $expectedDogTagMax = if ($catalogLoaded) { '4500' } else { '10' }
    Assert ($data.PlayerData.DogTagMax.N -eq $expectedDogTagMax) 'PlayerData carries the server dog-tag cap in seconds, matching DogTagManager.max'

    Write-Host "`nGetAllMessages (5)"
    $messages = SendJson -RequestId 5 -Token $token -PlayerId $playerId
    Assert ($messages.Result -eq 1) 'GetAllMessages succeeds'
    # OnGetAllMessages casts mResponse["Items"] to a JArray with no presence check.
    Assert ($null -ne $messages.PSObject.Properties['Items']) 'an empty inbox still carries Items'

    Write-Host "`nAuthentication"
    $rotated = SendJson -RequestId 34 -Token $created.Token -PlayerId $playerId
    Assert ($rotated.Result -eq 99990) 'the pre-rotation token is rejected as InvalidToken'
    $forged = SendJson -RequestId 34 -Token ('A' * 64) -PlayerId $playerId
    Assert ($forged.Result -eq 99990) 'an unissued token is rejected'
    $crossed = SendJson -RequestId 34 -Token $token -PlayerId 'someone-else'
    Assert ($crossed.Result -eq 99990) 'a valid token bound to a different PlayerId is rejected'
    $missing = SendJson -RequestId 34 -Token 'null' -PlayerId 'null'
    Assert ($missing.Result -eq 99990) 'the client "null" literal is treated as absent, not as a token'
    $badPassword = SendJson -RequestId 30 -Fields @{ Id = $playerId; Password = 'wrong'; AccountType = '0' }
    Assert ($badPassword.Result -eq 3001) 'a wrong password returns LoginFailure'
    $noAccount = SendJson -RequestId 30 -Fields @{ Id = 'nobody'; Password = 'wrong'; AccountType = '0' }
    Assert ($noAccount.Result -eq 3001) 'an unknown account returns LoginFailure'

    Write-Host "`nUnimplemented actions"
    $unimplemented = SendJson -RequestId 62 -Token $token -PlayerId $playerId
    Assert ($unimplemented.Result -eq 503) 'an unimplemented action reports maintenance rather than a hollow success'
    Assert ($unimplemented.Result -gt 10) 'the result takes the client failure branch (Result > 10)'

    Write-Host "`nSetPlayerStatus (29)"
    $status = SendJson -RequestId 29 -Token $token -PlayerId $playerId -Fields @{ PlayerStatus = '1' }
    Assert ($status.Result -eq 1) 'SetPlayerStatus succeeds'

    Write-Host "`nSendRequestBuffer (98): WeaponWasShown"
    # RequestBuffer.AddRequest passes the plain sheet name as `data` for WeaponWasShown.
    $buf1 = @{ '0' = @{ action = 104; data = 'M4A1' } } | ConvertTo-Json -Depth 5 -Compress
    $sent = SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-1'; Count = '1'; Requests = $buf1 }
    Assert ($sent.Result -eq 1) 'SendRequestBuffer succeeds'
    Assert ($sent.BufferId -eq 'buf-1') 'BufferId is echoed as a bare string, not an AttributeValue'
    $results1 = $sent.RequestsResults | ConvertFrom-Json
    Assert ($results1.Count -eq 1) 'one buffered request produces one result'
    Assert ($results1[0].ActionId -eq 104) 'the result carries the WeaponWasShown ActionId'
    Assert ($results1[0].Result -eq 1) 'WeaponWasShown succeeds'

    Write-Host "`nSendRequestBuffer (98): idempotent replay"
    # The client resends a buffer whose ack it never received; the same index must not re-apply.
    $replay = SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-1'; Count = '1'; Requests = $buf1 }
    $results1b = $replay.RequestsResults | ConvertFrom-Json
    Assert ($results1b[0].Result -eq 1) 'replaying the same BufferId/index returns the recorded result, not a re-execution'

    $afterShown = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
    $levelData = $afterShown.PlayerData.LevelManagerData.S | ConvertFrom-Json
    Assert ($levelData.savedWeapons.M4A1.showed -eq $true) 'WeaponWasShown persisted into LevelManagerData.savedWeapons'

    Write-Host "`nSendRequestBuffer (98): EquipWeapon rollback"
    # No BuyWeapon economy path exists yet, so M4A1 is not owned; the client's WeaponNotBought
    # branch expects LevelName/Weapon/InventoryData back so it can revert the slot it optimistically set.
    $equipPayload = @{ Index = '3'; Name = 'M4A1'; SlotIndex = 0; ArmyPower = 120 } | ConvertTo-Json -Compress
    $buf2 = @{ '0' = @{ action = 116; data = $equipPayload } } | ConvertTo-Json -Depth 5 -Compress
    $equip = SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-2'; Count = '1'; Requests = $buf2 }
    $results2 = $equip.RequestsResults | ConvertFrom-Json
    Assert ($results2[0].ActionId -eq 116) 'EquipWeapon ActionId is 116'
    Assert ($results2[0].Result -eq 110) 'equipping an unbought weapon returns WeaponNotBought (110)'
    Assert ($results2[0].LevelName -eq 'M4A1') 'the rollback names the weapon to revert'
    Assert ($null -ne $results2[0].InventoryData) 'the rollback carries authoritative InventoryData'

    Write-Host "`nSendRequestBuffer (98): UpdateEquippedUnits rollback"
    $equipsPayload = @{ armyPower = 500; equips = @{ Soldier1 = @{ equipped = $true } } } | ConvertTo-Json -Depth 5 -Compress
    $buf3 = @{ '0' = @{ action = 1003; data = $equipsPayload } } | ConvertTo-Json -Depth 6 -Compress
    $updateUnits = SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-3'; Count = '1'; Requests = $buf3 }
    $results3 = $updateUnits.RequestsResults | ConvertFrom-Json
    Assert ($results3[0].ActionId -eq 1003) 'UpdateEquippedUnits ActionId is 1003'
    Assert ($results3[0].Result -eq 11406) 'equipping an unowned unit returns CantEquipUnit (11406)'
    Assert ($null -ne $results3[0].data) 'the rollback carries the stored army data'

    Write-Host "`nSendRequestBuffer (98): unimplemented economy action"
    # ClaimAssignment (171) needs Battle Server result trust (assignment progress is only ever
    # authoritative once match outcomes are); BuyWeapon (76)/BuyUnit (80) are covered separately below.
    $buf4 = @{ '0' = @{ action = 171; data = 'starter_pack' } } | ConvertTo-Json -Depth 5 -Compress
    $buy = SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-4'; Count = '1'; Requests = $buf4 }
    $results4 = $buy.RequestsResults | ConvertFrom-Json
    Assert ($results4[0].Result -eq 503) 'ClaimAssignment (needs Battle Server result trust) reports maintenance rather than a fabricated claim'

    if ($catalogLoaded) {
        Write-Host "`nSendRequestBuffer (98): BuyWeapon against the verified catalog"
        $goldBefore = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.Gold.N
        $warbucksBefore = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.WarBucks.N

        # Free starter weapon (PRICE=0, PRICEGOLD=0, CANBEBOUGHT=0): succeeds with no charge.
        $freeData = @{ Name = 'Google2u.AssaultRifle_AK47'; Warbucks = 0; Gold = 0; UnlockLevel = 1; StartTime = 0; discount = 0 } | ConvertTo-Json -Compress
        $bufFree = @{ '0' = @{ action = 76; data = $freeData } } | ConvertTo-Json -Depth 5 -Compress
        $freeBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-weapon-free'; Count = '1'; Requests = $bufFree }).RequestsResults | ConvertFrom-Json
        Assert ($freeBuy[0].Result -eq 1) 'buying a free shop weapon (PRICE=0, PRICEGOLD=0) succeeds'

        # Re-buying the same weapon is an idempotent no-op success, not an error.
        $freeAgain = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-weapon-free-2'; Count = '1'; Requests = $bufFree }).RequestsResults | ConvertFrom-Json
        Assert ($freeAgain[0].Result -eq 1) 'buying an already-owned weapon again is an idempotent success, not an error'

        # Warbucks-priced weapon affordable from the starting balance: Grenade_FRAG costs 999 Warbucks, CANBEBOUGHT=0.
        $wbData = @{ Name = 'Google2u.Grenade_FRAG'; Warbucks = 999; Gold = 0; UnlockLevel = 1; StartTime = 0; discount = 0 } | ConvertTo-Json -Compress
        $bufWb = @{ '0' = @{ action = 76; data = $wbData } } | ConvertTo-Json -Depth 5 -Compress
        $wbBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-weapon-wb'; Count = '1'; Requests = $bufWb }).RequestsResults | ConvertFrom-Json
        Assert ($wbBuy[0].Result -eq 1) 'buying a Warbucks-priced weapon (Grenade_FRAG, 999) succeeds'
        $afterWbBuy = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([long]$afterWbBuy.PlayerData.WarBucks.N -eq ($warbucksBefore - 999)) 'exactly 999 Warbucks (the catalog PRICE) was debited, not a client-asserted amount'

        # Gold-priced weapon the starting 75-gold balance cannot afford: Bazooka_RPG7 costs 89 gold.
        $goldData = @{ Name = 'Google2u.Bazooka_RPG7'; Warbucks = 0; Gold = 89; UnlockLevel = 1; StartTime = 0; discount = 0 } | ConvertTo-Json -Compress
        $bufGold = @{ '0' = @{ action = 76; data = $goldData } } | ConvertTo-Json -Depth 5 -Compress
        $goldBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-weapon-gold'; Count = '1'; Requests = $bufGold }).RequestsResults | ConvertFrom-Json
        Assert ($goldBuy[0].Result -eq 103) 'a weapon priced above the current gold balance returns NotEnoughGold (103)'
        Assert ($goldBuy[0].Gold -eq $goldBefore) 'the NotEnoughGold rollback carries the untouched authoritative Gold balance'

        # High-level-gated weapon: AssaultRifle_G36 requires CANBEBOUGHT=29 at a level-1 player.
        $levelData = @{ Name = 'Google2u.AssaultRifle_G36'; Warbucks = 0; Gold = 4199; UnlockLevel = 29; StartTime = 0; discount = 0 } | ConvertTo-Json -Compress
        $bufLevel = @{ '0' = @{ action = 76; data = $levelData } } | ConvertTo-Json -Depth 5 -Compress
        $levelBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-weapon-level'; Count = '1'; Requests = $bufLevel }).RequestsResults | ConvertFrom-Json
        Assert ($levelBuy[0].Result -eq 101) 'a weapon above the player level returns NotEnoughLevel (101), checked before funds'

        # Not sold in the shop (PURCHASABLE=starter): LMG_Minigun.
        $starterData = @{ Name = 'Google2u.LMG_Minigun'; Warbucks = 0; Gold = 0; UnlockLevel = 1; StartTime = 0; discount = 0 } | ConvertTo-Json -Compress
        $bufStarter = @{ '0' = @{ action = 76; data = $starterData } } | ConvertTo-Json -Depth 5 -Compress
        $starterBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-weapon-starter'; Count = '1'; Requests = $bufStarter }).RequestsResults | ConvertFrom-Json
        Assert ($starterBuy[0].Result -eq 110) 'a non-shop-purchasable weapon (PURCHASABLE=starter) returns WeaponNotBought (110)'

        # Unknown weapon name: no matching catalog row.
        $unknownData = @{ Name = 'Google2u.DoesNotExist'; Warbucks = 0; Gold = 0; UnlockLevel = 1; StartTime = 0; discount = 0 } | ConvertTo-Json -Compress
        $bufUnknown = @{ '0' = @{ action = 76; data = $unknownData } } | ConvertTo-Json -Depth 5 -Compress
        $unknownBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-weapon-unknown'; Count = '1'; Requests = $bufUnknown }).RequestsResults | ConvertFrom-Json
        Assert ($unknownBuy[0].Result -eq 113) 'an unknown weapon name returns PriceNotFound (113)'

        # A nonzero client-asserted discount is refused, not validated against a sale system we don't have.
        $discountData = @{ Name = 'Google2u.Bazooka_RPG7'; Warbucks = 0; Gold = 80; UnlockLevel = 1; StartTime = 0; discount = 10 } | ConvertTo-Json -Compress
        $bufDiscount = @{ '0' = @{ action = 76; data = $discountData } } | ConvertTo-Json -Depth 5 -Compress
        $discountBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-weapon-discount'; Count = '1'; Requests = $bufDiscount }).RequestsResults | ConvertFrom-Json
        Assert ($discountBuy[0].Result -eq 13601) 'a nonzero client-asserted discount is refused (NoDiscountFound), not honored unverified'

        Write-Host "`nSendRequestBuffer (98): ActivateWeapon / InstantBuyWeapon"
        # The real client always queues ActivateWeapon right after BuyWeapon when weaponDeliveryTime
        # is 0 (true for every weapon in the current export) — it must be safe to call on a weapon
        # BuyWeapon already fully completed.
        $activateOwnedData = @{ LevelName = 'Google2u.AssaultRifle_AK47' } | ConvertTo-Json -Compress
        $bufActivateOwned = @{ '0' = @{ action = 128; data = $activateOwnedData } } | ConvertTo-Json -Depth 5 -Compress
        $activateOwnedBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-activate-owned'; Count = '1'; Requests = $bufActivateOwned }).RequestsResults | ConvertFrom-Json
        Assert ($activateOwnedBuy[0].Result -eq 1) 'ActivateWeapon on an already-bought weapon is an idempotent success'
        $goldBeforeInstantOwned = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.Gold.N
        $instantOwnedData = @{ LevelName = 'Google2u.AssaultRifle_AK47'; ExpectedPrice = 999; GoldCoefficient = 0.6325; GoldExpCoefficient = -0.175 } | ConvertTo-Json -Compress
        $bufInstantOwned = @{ '0' = @{ action = 126; data = $instantOwnedData } } | ConvertTo-Json -Depth 5 -Compress
        $instantOwnedBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-instant-owned'; Count = '1'; Requests = $bufInstantOwned }).RequestsResults | ConvertFrom-Json
        Assert ($instantOwnedBuy[0].Result -eq 1) 'InstantBuyWeapon on an already-bought weapon is an idempotent success'
        $afterInstantOwned = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([long]$afterInstantOwned.PlayerData.Gold.N -eq $goldBeforeInstantOwned) 'InstantBuyWeapon on an already-owned weapon charges nothing'

        # No pending delivery and not bought: a genuine mismatch.
        $activateUnboughtData = @{ LevelName = 'Google2u.Pistol_Berreta' } | ConvertTo-Json -Compress
        $bufActivateUnbought = @{ '0' = @{ action = 128; data = $activateUnboughtData } } | ConvertTo-Json -Depth 5 -Compress
        $activateUnboughtBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-activate-unbought'; Count = '1'; Requests = $bufActivateUnbought }).RequestsResults | ConvertFrom-Json
        Assert ($activateUnboughtBuy[0].Result -eq 104) 'ActivateWeapon with nothing pending and nothing owned returns WrongIndexToActivate (104)'

        Write-Host "`nSendRequestBuffer (98): BuyUnit against the verified catalog"
        $warbucksBeforeUnit = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.WarBucks.N

        # Free starter unit (PRICE=0, PRICEGOLD=0, CANBEBOUGHT=0): succeeds with no charge.
        $freeUnitData = @{ Name = 'Google2u.DBUpgradeSlotsShotgunner'; Warbucks = 0; Gold = 0; UnlockLevel = 1; StartTime = 0; discount = 0 } | ConvertTo-Json -Compress
        $bufFreeUnit = @{ '0' = @{ action = 80; data = $freeUnitData } } | ConvertTo-Json -Depth 5 -Compress
        $freeUnitBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-unit-free'; Count = '1'; Requests = $bufFreeUnit }).RequestsResults | ConvertFrom-Json
        Assert ($freeUnitBuy[0].Result -eq 1) 'buying a free starter unit (PRICE=0, PRICEGOLD=0) succeeds'

        # Re-buying is an idempotent no-op success.
        $freeUnitAgain = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-unit-free-2'; Count = '1'; Requests = $bufFreeUnit }).RequestsResults | ConvertFrom-Json
        Assert ($freeUnitAgain[0].Result -eq 1) 'buying an already-owned unit again is an idempotent success, not an error'

        # Warbucks-priced unit affordable from the starting balance: DBUpgradeSlotsAssaulter costs 1500 Warbucks, CANBEBOUGHT=0.
        $wbUnitData = @{ Name = 'Google2u.DBUpgradeSlotsAssaulter'; Warbucks = 1500; Gold = 0; UnlockLevel = 1; StartTime = 0; discount = 0 } | ConvertTo-Json -Compress
        $bufWbUnit = @{ '0' = @{ action = 80; data = $wbUnitData } } | ConvertTo-Json -Depth 5 -Compress
        $wbUnitBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-unit-wb'; Count = '1'; Requests = $bufWbUnit }).RequestsResults | ConvertFrom-Json
        Assert ($wbUnitBuy[0].Result -eq 1) 'buying a Warbucks-priced unit (DBUpgradeSlotsAssaulter, 1500) succeeds'
        $afterUnitBuy = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([long]$afterUnitBuy.PlayerData.WarBucks.N -eq ($warbucksBeforeUnit - 1500)) 'exactly 1500 Warbucks (the catalog PRICE) was debited for the unit'

        # High-level-gated unit: DBUpgradeSlotsSwat requires CANBEBOUGHT=15 at a level-1 player.
        $levelUnitData = @{ Name = 'Google2u.DBUpgradeSlotsSwat'; Warbucks = 249999; Gold = 0; UnlockLevel = 18; StartTime = 0; discount = 0 } | ConvertTo-Json -Compress
        $bufLevelUnit = @{ '0' = @{ action = 80; data = $levelUnitData } } | ConvertTo-Json -Depth 5 -Compress
        $levelUnitBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-unit-level'; Count = '1'; Requests = $bufLevelUnit }).RequestsResults | ConvertFrom-Json
        Assert ($levelUnitBuy[0].Result -eq 101) 'a unit above the player level returns NotEnoughLevel (101), checked before funds'
        Assert ($levelUnitBuy[0].LevelName -eq 'Google2u.DBUpgradeSlotsSwat') 'the rollback names the unit to revert'
        Assert ($null -ne $levelUnitBuy[0].Unit) 'the rollback carries the authoritative Unit slot'

        # Unknown unit name: no matching catalog row.
        $unknownUnitData = @{ Name = 'Google2u.DoesNotExist'; Warbucks = 0; Gold = 0; UnlockLevel = 1; StartTime = 0; discount = 0 } | ConvertTo-Json -Compress
        $bufUnknownUnit = @{ '0' = @{ action = 80; data = $unknownUnitData } } | ConvertTo-Json -Depth 5 -Compress
        $unknownUnitBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-unit-unknown'; Count = '1'; Requests = $bufUnknownUnit }).RequestsResults | ConvertFrom-Json
        Assert ($unknownUnitBuy[0].Result -eq 113) 'an unknown unit name returns PriceNotFound (113)'

        Write-Host "`nSendRequestBuffer (98): ActivateUnit / InstantBuyUnit"
        $activateUnitOwnedData = @{ LevelName = 'Google2u.DBUpgradeSlotsShotgunner' } | ConvertTo-Json -Compress
        $bufActivateUnitOwned = @{ '0' = @{ action = 127; data = $activateUnitOwnedData } } | ConvertTo-Json -Depth 5 -Compress
        $activateUnitOwnedBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-activateunit-owned'; Count = '1'; Requests = $bufActivateUnitOwned }).RequestsResults | ConvertFrom-Json
        Assert ($activateUnitOwnedBuy[0].Result -eq 1) 'ActivateUnit on an already-bought unit is an idempotent success'
        $goldBeforeInstantUnitOwned = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.Gold.N
        $instantUnitOwnedData = @{ LevelName = 'Google2u.DBUpgradeSlotsShotgunner'; ExpectedPrice = 999; GoldCoefficient = 0.6325; GoldExpCoefficient = -0.175 } | ConvertTo-Json -Compress
        $bufInstantUnitOwned = @{ '0' = @{ action = 125; data = $instantUnitOwnedData } } | ConvertTo-Json -Depth 5 -Compress
        $instantUnitOwnedBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-instantunit-owned'; Count = '1'; Requests = $bufInstantUnitOwned }).RequestsResults | ConvertFrom-Json
        Assert ($instantUnitOwnedBuy[0].Result -eq 1) 'InstantBuyUnit on an already-bought unit is an idempotent success'
        $afterInstantUnitOwned = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([long]$afterInstantUnitOwned.PlayerData.Gold.N -eq $goldBeforeInstantUnitOwned) 'InstantBuyUnit on an already-owned unit charges nothing'
        $activateUnitUnboughtData = @{ LevelName = 'Google2u.DBUpgradeSlotsSwat' } | ConvertTo-Json -Compress
        $bufActivateUnitUnbought = @{ '0' = @{ action = 127; data = $activateUnitUnboughtData } } | ConvertTo-Json -Depth 5 -Compress
        $activateUnitUnboughtBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-activateunit-unbought'; Count = '1'; Requests = $bufActivateUnitUnbought }).RequestsResults | ConvertFrom-Json
        Assert ($activateUnitUnboughtBuy[0].Result -eq 104) 'ActivateUnit with nothing pending and nothing owned returns WrongIndexToActivate (104)'

        Write-Host "`nSendRequestBuffer (98): BuyWeaponUpgrade / ActivateWeaponUpgrade / InstantWeaponUpgrade"
        $goldBeforeUpgrade = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.Gold.N
        $warbucksBeforeUpgrade = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.WarBucks.N

        # AK47 was already bought for free above; its per-level upgrade sheet is one of the two the
        # map exporter actually captured.
        $upgradeData = @{ LevelName = 'Google2u.AssaultRifle_AK47'; BoughtIndex = 0; StartTime = 0; discount = 0; DeliveryTime = 0 } | ConvertTo-Json -Compress
        $bufUpgrade = @{ '0' = @{ action = 73; data = $upgradeData } } | ConvertTo-Json -Depth 5 -Compress
        $upgradeBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-upgrade-buy'; Count = '1'; Requests = $bufUpgrade }).RequestsResults | ConvertFrom-Json
        Assert ($upgradeBuy[0].Result -eq 1) 'BuyWeaponUpgrade succeeds for the owned AK47 at BoughtIndex 0'
        Assert ($upgradeBuy[0].DeliveryTime -eq 60) 'BuyWeaponUpgrade returns the catalog DELIVERYTIME (60s) for the first upgrade'
        $afterUpgradeBuy = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([long]$afterUpgradeBuy.PlayerData.WarBucks.N -eq ($warbucksBeforeUpgrade - 500)) 'exactly 500 Warbucks (catalog NEXTUPGRADEPRICE) was debited for the upgrade'

        # A second buy while one delivery is already pending is rejected.
        $upgradeAgain = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-upgrade-buy-2'; Count = '1'; Requests = $bufUpgrade }).RequestsResults | ConvertFrom-Json
        Assert ($upgradeAgain[0].Result -eq 105) 'a second BuyWeaponUpgrade while one is pending returns AlreadyUpgrading (105)'

        # Activating before the 60s timer elapses is rejected.
        $activateData = @{ LevelName = 'Google2u.AssaultRifle_AK47'; BoughtIndex = 0; ArmyPower = 0 } | ConvertTo-Json -Compress
        $bufActivateEarly = @{ '0' = @{ action = 75; data = $activateData } } | ConvertTo-Json -Depth 5 -Compress
        $activateEarly = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-upgrade-activate-early'; Count = '1'; Requests = $bufActivateEarly }).RequestsResults | ConvertFrom-Json
        Assert ($activateEarly[0].Result -eq 106) 'activating before the delivery timer elapses returns TooSoonToActivate (106)'

        # Instant-completing pays MiscTools.ConvertTimeIntoGold over the ~60 remaining seconds:
        # ceil(0.6325 * 1^-0.175 * 1) = 1 gold. The client's ExpectedPrice/GoldCoefficient fields
        # are ignored; the server recomputes from its own catalog constants.
        $instantData = @{ LevelName = 'Google2u.AssaultRifle_AK47'; BoughtIndex = 0; ExpectedPrice = 999; ArmyPower = 0; GoldCoefficient = 0.6325; GoldExpCoefficient = -0.175 } | ConvertTo-Json -Compress
        $bufInstant = @{ '0' = @{ action = 74; data = $instantData } } | ConvertTo-Json -Depth 5 -Compress
        $instantBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-upgrade-instant'; Count = '1'; Requests = $bufInstant }).RequestsResults | ConvertFrom-Json
        Assert ($instantBuy[0].Result -eq 1) 'InstantWeaponUpgrade succeeds'
        $afterInstant = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([long]$afterInstant.PlayerData.Gold.N -eq ($goldBeforeUpgrade - 1)) 'InstantWeaponUpgrade charged the server-computed 1 gold, not the client-asserted ExpectedPrice (999)'
        $levelData3 = $afterInstant.PlayerData.LevelManagerData.S | ConvertFrom-Json
        Assert ($levelData3.savedWeapons.'Google2u.AssaultRifle_AK47'.boughtIndex -eq 1) 'the weapon BoughtIndex advanced to 1 after the upgrade completed'
        Assert ([string]::IsNullOrEmpty($levelData3.weaponDelivery.itemId)) 'the weapon delivery slot is cleared after completion'

        # An entirely unknown weapon name has no exported per-level upgrade sheet.
        $noSheetData = @{ LevelName = 'Google2u.DoesNotExist'; BoughtIndex = 0; StartTime = 0; discount = 0; DeliveryTime = 0 } | ConvertTo-Json -Compress
        $bufNoSheet = @{ '0' = @{ action = 73; data = $noSheetData } } | ConvertTo-Json -Depth 5 -Compress
        $noSheetBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-upgrade-nosheet'; Count = '1'; Requests = $bufNoSheet }).RequestsResults | ConvertFrom-Json
        Assert ($noSheetBuy[0].Result -eq 113) 'a weapon with no exported per-level upgrade sheet returns PriceNotFound (113)'

        Write-Host "`nSendRequestBuffer (98): BuyUnitUpgrade / ActivateUnitUpgrade / InstantUnitUpgrade"
        $warbucksBeforeUnitUpgrade = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.WarBucks.N
        $goldBeforeUnitUpgrade = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.Gold.N

        # DBUpgradeSlotsAssaulter was already bought (1500 Warbucks) above; row[0] NEXTUPGRADEPRICE=375, DELIVERYTIME=60.
        $unitUpgradeData = @{ LevelName = 'Google2u.DBUpgradeSlotsAssaulter'; BoughtIndex = 0; StartTime = 0; IsSpecial = '0'; discount = 0; DeliveryTime = 0 } | ConvertTo-Json -Compress
        $bufUnitUpgrade = @{ '0' = @{ action = 77; data = $unitUpgradeData } } | ConvertTo-Json -Depth 5 -Compress
        $unitUpgradeBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-unitupgrade-buy'; Count = '1'; Requests = $bufUnitUpgrade }).RequestsResults | ConvertFrom-Json
        Assert ($unitUpgradeBuy[0].Result -eq 1) 'BuyUnitUpgrade succeeds for the owned unit at BoughtIndex 0'
        Assert ($unitUpgradeBuy[0].DeliveryTime -eq 60) 'BuyUnitUpgrade returns the catalog DELIVERYTIME (60s)'
        $afterUnitUpgradeBuy = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([long]$afterUnitUpgradeBuy.PlayerData.WarBucks.N -eq ($warbucksBeforeUnitUpgrade - 375)) 'exactly 375 Warbucks (catalog NEXTUPGRADEPRICE) was debited for the unit upgrade'

        $unitUpgradeAgain = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-unitupgrade-buy-2'; Count = '1'; Requests = $bufUnitUpgrade }).RequestsResults | ConvertFrom-Json
        Assert ($unitUpgradeAgain[0].Result -eq 105) 'a second BuyUnitUpgrade while one is pending returns AlreadyUpgrading (105)'

        $unitActivateData = @{ LevelName = 'Google2u.DBUpgradeSlotsAssaulter'; BoughtIndex = 0; ArmyPower = 0 } | ConvertTo-Json -Compress
        $bufUnitActivateEarly = @{ '0' = @{ action = 79; data = $unitActivateData } } | ConvertTo-Json -Depth 5 -Compress
        $unitActivateEarly = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-unitupgrade-activate-early'; Count = '1'; Requests = $bufUnitActivateEarly }).RequestsResults | ConvertFrom-Json
        Assert ($unitActivateEarly[0].Result -eq 106) 'activating a unit upgrade before its delivery timer elapses returns TooSoonToActivate (106)'

        $unitInstantData = @{ LevelName = 'Google2u.DBUpgradeSlotsAssaulter'; BoughtIndex = 0; ExpectedPrice = 999; ArmyPower = 0; GoldCoefficient = 0.6325; GoldExpCoefficient = -0.175 } | ConvertTo-Json -Compress
        $bufUnitInstant = @{ '0' = @{ action = 78; data = $unitInstantData } } | ConvertTo-Json -Depth 5 -Compress
        $unitInstantBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-unitupgrade-instant'; Count = '1'; Requests = $bufUnitInstant }).RequestsResults | ConvertFrom-Json
        Assert ($unitInstantBuy[0].Result -eq 1) 'InstantUnitUpgrade succeeds'
        $afterUnitInstant = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([long]$afterUnitInstant.PlayerData.Gold.N -eq ($goldBeforeUnitUpgrade - 1)) 'InstantUnitUpgrade charged the server-computed 1 gold, not the client-asserted ExpectedPrice (999)'
        $levelData4 = $afterUnitInstant.PlayerData.LevelManagerData.S | ConvertFrom-Json
        Assert ($levelData4.savedArmies.'Google2u.DBUpgradeSlotsAssaulter'.boughtIndex -eq 1) 'the unit BoughtIndex advanced to 1 after the upgrade completed'

        # IsSpecial=1 has no verified pricing source and is refused, not guessed at.
        $specialData = @{ LevelName = 'Google2u.DBUpgradeSlotsAssaulter'; BoughtIndex = 1; StartTime = 0; IsSpecial = '1'; discount = 0; DeliveryTime = 0 } | ConvertTo-Json -Compress
        $bufSpecial = @{ '0' = @{ action = 77; data = $specialData } } | ConvertTo-Json -Depth 5 -Compress
        $specialBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-unitupgrade-special'; Count = '1'; Requests = $bufSpecial }).RequestsResults | ConvertFrom-Json
        Assert ($specialBuy[0].Result -eq 503) 'the special upgrade track (IsSpecial=1) is refused as ServerMaintenance, not priced from unverified data'

        Write-Host "`nSendRequestBuffer (98): PromoteUnit"
        # DBUpgradeSlotsAssaulter: STARTINGTIER=1, UNLOCKTIER2=9 — a level-1 player cannot promote yet.
        $promoteData = @{ LevelName = 'Google2u.DBUpgradeSlotsAssaulter' } | ConvertTo-Json -Compress
        $bufPromote = @{ '0' = @{ action = 158; data = $promoteData } } | ConvertTo-Json -Depth 5 -Compress
        $promoteBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-promote'; Count = '1'; Requests = $bufPromote }).RequestsResults | ConvertFrom-Json
        Assert ($promoteBuy[0].Result -eq 101) 'promoting a unit below its UNLOCKTIER2 player-level gate returns NotEnoughLevel (101)'
        $promoteUnownedData = @{ LevelName = 'Google2u.DBUpgradeSlotsSwat' } | ConvertTo-Json -Compress
        $bufPromoteUnowned = @{ '0' = @{ action = 158; data = $promoteUnownedData } } | ConvertTo-Json -Depth 5 -Compress
        $promoteUnownedBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-promote-unowned'; Count = '1'; Requests = $bufPromoteUnowned }).RequestsResults | ConvertFrom-Json
        Assert ($promoteUnownedBuy[0].Result -eq 104) 'promoting an unowned unit returns WrongIndexToActivate (104)'
        $promoteUnknownData = @{ LevelName = 'Google2u.DoesNotExist' } | ConvertTo-Json -Compress
        $bufPromoteUnknown = @{ '0' = @{ action = 158; data = $promoteUnknownData } } | ConvertTo-Json -Depth 5 -Compress
        $promoteUnknownBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-promote-unknown'; Count = '1'; Requests = $bufPromoteUnknown }).RequestsResults | ConvertFrom-Json
        Assert ($promoteUnknownBuy[0].Result -eq 113) 'promoting an unknown unit name returns PriceNotFound (113)'

        Write-Host "`nSendRequestBuffer (98): UpgradeEliteSlot (209) / ConvertPartsToScraps (208) / ConvertScrapsToParts (207)"
        # DBUpgradeSlotsAssaulter: STARTINGELITE=-1 in the verified catalog — elite is not unlocked
        # for this unit at all, despite its per-level sheet still containing TIER=21 rows.
        $eliteLockedData = @{ LevelName = 'Google2u.DBUpgradeSlotsAssaulter'; BoughtIndex = 0; SpentWarbucks = 0; SpentParts = 50 } | ConvertTo-Json -Compress
        $bufEliteLocked = @{ '0' = @{ action = 209; data = $eliteLockedData } } | ConvertTo-Json -Depth 5 -Compress
        $eliteLockedBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-elite-locked'; Count = '1'; Requests = $bufEliteLocked }).RequestsResults | ConvertFrom-Json
        Assert ($eliteLockedBuy[0].Result -eq 104) 'UpgradeEliteSlot on a unit with STARTINGELITE<=0 returns WrongIndexToActivate (104), not a fabricated price'

        $scrapsLockedData = @{ LevelName = 'Google2u.DBUpgradeSlotsAssaulter' } | ConvertTo-Json -Compress
        $bufPartsLocked = @{ '0' = @{ action = 208; data = $scrapsLockedData } } | ConvertTo-Json -Depth 5 -Compress
        $partsLockedBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-parts-locked'; Count = '1'; Requests = $bufPartsLocked }).RequestsResults | ConvertFrom-Json
        Assert ($partsLockedBuy[0].Result -eq 20801) 'ConvertPartsToScraps on a unit with no elite track returns EliteSlotLocked (20801)'

        $bufScrapsLocked = @{ '0' = @{ action = 207; data = 'Google2u.DBUpgradeSlotsAssaulter' } } | ConvertTo-Json -Depth 5 -Compress
        $scrapsLockedBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-scraps-locked'; Count = '1'; Requests = $bufScrapsLocked }).RequestsResults | ConvertFrom-Json
        Assert ($scrapsLockedBuy[0].Result -eq 104) 'ConvertScrapsToParts on a unit with no elite track returns WrongIndexToActivate (104)'

        # DBUpgradeSlotsShotgunner: STARTINGELITE=127 (unlocked), already owned from the free-unit
        # BuyUnit test above. Its first elite level (eliteSlot=0) needs 50 parts (NEXTUPGRADEPRICEGOLD,
        # a repurposed column name — not literal gold) and a 0 Warbucks skip price.
        $eliteUnownedPartsData = @{ LevelName = 'Google2u.DBUpgradeSlotsShotgunner'; BoughtIndex = 0; SpentWarbucks = 0; SpentParts = 50 } | ConvertTo-Json -Compress
        $bufEliteNoParts = @{ '0' = @{ action = 209; data = $eliteUnownedPartsData } } | ConvertTo-Json -Depth 5 -Compress
        $eliteNoPartsBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-elite-noparts'; Count = '1'; Requests = $bufEliteNoParts }).RequestsResults | ConvertFrom-Json
        Assert ($eliteNoPartsBuy[0].Result -eq 20902) 'buying elite level 0 with 0 accumulated Elite Parts returns NotEnoughParts (20902)'

        $eliteWrongIndexData = @{ LevelName = 'Google2u.DBUpgradeSlotsShotgunner'; BoughtIndex = 3; SpentWarbucks = 0; SpentParts = 50 } | ConvertTo-Json -Compress
        $bufEliteWrongIndex = @{ '0' = @{ action = 209; data = $eliteWrongIndexData } } | ConvertTo-Json -Depth 5 -Compress
        $eliteWrongIndexBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-elite-wrongindex'; Count = '1'; Requests = $bufEliteWrongIndex }).RequestsResults | ConvertFrom-Json
        Assert ($eliteWrongIndexBuy[0].Result -eq 104) 'a stale/mismatched EliteSlot BoughtIndex assertion returns WrongIndexToActivate (104)'

        $eliteWrongPartsData = @{ LevelName = 'Google2u.DBUpgradeSlotsShotgunner'; BoughtIndex = 0; SpentWarbucks = 0; SpentParts = 999 } | ConvertTo-Json -Compress
        $bufEliteWrongParts = @{ '0' = @{ action = 209; data = $eliteWrongPartsData } } | ConvertTo-Json -Depth 5 -Compress
        $eliteWrongPartsBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-elite-wrongparts'; Count = '1'; Requests = $bufEliteWrongParts }).RequestsResults | ConvertFrom-Json
        Assert ($eliteWrongPartsBuy[0].Result -eq 20903) 'a client-asserted SpentParts that does not match the catalog row returns IncorrectValuesOnClient (20903)'

        # No source in this pass grants Elite Parts or Scraps (no missions/rewards implemented yet),
        # so a fresh account genuinely has zero of both — verified as real refusals, not skipped.
        $bufPartsZero = @{ '0' = @{ action = 208; data = (@{ LevelName = 'Google2u.DBUpgradeSlotsShotgunner'; PartsToConvert = 0; Scraps = 0 } | ConvertTo-Json -Compress) } } | ConvertTo-Json -Depth 5 -Compress
        $partsZeroBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-parts-zero'; Count = '1'; Requests = $bufPartsZero }).RequestsResults | ConvertFrom-Json
        Assert ($partsZeroBuy[0].Result -eq 20802) 'ConvertPartsToScraps with zero accumulated Elite Parts returns IncorrectPartsAmount (20802), never a zero-value success'

        $bufScrapsInsufficient = @{ '0' = @{ action = 207; data = 'Google2u.DBUpgradeSlotsShotgunner' } } | ConvertTo-Json -Depth 5 -Compress
        $scrapsInsufficientBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-scraps-insufficient'; Count = '1'; Requests = $bufScrapsInsufficient }).RequestsResults | ConvertFrom-Json
        Assert ($scrapsInsufficientBuy[0].Result -eq 20701) 'ConvertScrapsToParts with a zero Scraps balance (50 parts x 24 PartToScrapsUpgrade = 1200 needed) returns NotEnoughScraps (20701)'

        Write-Host "`nSendRequestBuffer (98): BuyDecal against the verified catalog"
        # CAMOS_DEFAULT: PRICEWARBUCKS=0, PRICEGOLD=0, ONLYFORVIP=false, PURCHASABLE=shop.
        $freeDecalData = @{ Name = 'CAMOS_DEFAULT'; Warbucks = 0; Gold = 0; discount = 0; StartTime = 0 } | ConvertTo-Json -Compress
        $bufFreeDecal = @{ '0' = @{ action = 109; data = $freeDecalData } } | ConvertTo-Json -Depth 5 -Compress
        $freeDecalBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-decal-free'; Count = '1'; Requests = $bufFreeDecal }).RequestsResults | ConvertFrom-Json
        Assert ($freeDecalBuy[0].Result -eq 1) 'buying a free shop visual (PRICEWARBUCKS=0, PRICEGOLD=0) succeeds'
        Assert ($freeDecalBuy[0].DecalId -eq 'CAMOS_DEFAULT') 'the success response echoes the bought DecalId'
        Assert ($freeDecalBuy[0].ExpiresOn -eq 0) 'a permanent (non-rental) purchase reports ExpiresOn=0'

        $freeDecalAgain = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-decal-free-2'; Count = '1'; Requests = $bufFreeDecal }).RequestsResults | ConvertFrom-Json
        Assert ($freeDecalAgain[0].Result -eq 1) 'buying an already-owned visual again is an idempotent success'

        # CAMOS_MACHINEGUNNER: PRICEWARBUCKS=800000 — far beyond any balance this account reaches.
        $expensiveDecalData = @{ Name = 'CAMOS_MACHINEGUNNER'; Warbucks = 800000; Gold = 0; discount = 0; StartTime = 0 } | ConvertTo-Json -Compress
        $bufExpensiveDecal = @{ '0' = @{ action = 109; data = $expensiveDecalData } } | ConvertTo-Json -Depth 5 -Compress
        $expensiveDecalBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-decal-expensive'; Count = '1'; Requests = $bufExpensiveDecal }).RequestsResults | ConvertFrom-Json
        Assert ($expensiveDecalBuy[0].Result -eq 100) 'a visual priced above the current Warbucks balance returns NotEnoughWarbucks (100)'
        Assert ($null -ne $expensiveDecalBuy[0].DecalManagerData) 'the rollback carries the full DecalManagerData blob, matching the client''s whole-blob resync on this action'

        # CAMOS_PARA: PRICEGOLD=200, ONLYFORVIP=true — this account is not VIP.
        $vipDecalData = @{ Name = 'CAMOS_PARA'; Warbucks = 0; Gold = 200; discount = 0; StartTime = 0 } | ConvertTo-Json -Compress
        $bufVipDecal = @{ '0' = @{ action = 109; data = $vipDecalData } } | ConvertTo-Json -Depth 5 -Compress
        $vipDecalBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-decal-vip'; Count = '1'; Requests = $bufVipDecal }).RequestsResults | ConvertFrom-Json
        Assert ($vipDecalBuy[0].Result -eq 109) 'a VIP-only visual for a non-VIP player returns DecalOnlyForVip (109)'

        $unknownDecalData = @{ Name = 'CAMOS_DOES_NOT_EXIST'; Warbucks = 0; Gold = 0; discount = 0; StartTime = 0 } | ConvertTo-Json -Compress
        $bufUnknownDecal = @{ '0' = @{ action = 109; data = $unknownDecalData } } | ConvertTo-Json -Depth 5 -Compress
        $unknownDecalBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-decal-unknown'; Count = '1'; Requests = $bufUnknownDecal }).RequestsResults | ConvertFrom-Json
        Assert ($unknownDecalBuy[0].Result -eq 113) 'an unknown visual name returns PriceNotFound (113)'

        $discountDecalData = @{ Name = 'CAMOS_DEFAULT'; Warbucks = 0; Gold = 0; discount = 10; StartTime = 0 } | ConvertTo-Json -Compress
        $bufDiscountDecal = @{ '0' = @{ action = 109; data = $discountDecalData } } | ConvertTo-Json -Depth 5 -Compress
        $discountDecalBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-decal-discount'; Count = '1'; Requests = $bufDiscountDecal }).RequestsResults | ConvertFrom-Json
        Assert ($discountDecalBuy[0].Result -eq 13601) 'a nonzero client-asserted discount on a visual purchase is refused (NoDiscountFound)'

        Write-Host "`nSendRequestBuffer (98): EquipDecal against the verified catalog"
        # CamosScreen.EquipPlayerVisual sends the decal's bare NAME as `data`, not JSON.
        $bufEquipOwned = @{ '0' = @{ action = 110; data = 'CAMOS_DEFAULT' } } | ConvertTo-Json -Depth 5 -Compress
        $equipOwned = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-equip-owned'; Count = '1'; Requests = $bufEquipOwned }).RequestsResults | ConvertFrom-Json
        Assert ($equipOwned[0].Result -eq 1) 'equipping an already-bought visual succeeds'
        $afterEquipOwned = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        $decalData1 = $afterEquipOwned.PlayerData.DecalManagerData.S | ConvertFrom-Json
        Assert ($decalData1.slots.'0'.equippedID -eq 'CAMOS_DEFAULT') 'CATEGORYID=0 (CAMOS_) is the slot key EquipDecal wrote into, matching the recovered scene''s categoryNumber order'

        # CAMOS_MACHINEGUNNER was never successfully bought above (NotEnoughWarbucks), so it is not owned.
        $bufEquipUnowned = @{ '0' = @{ action = 110; data = 'CAMOS_MACHINEGUNNER' } } | ConvertTo-Json -Depth 5 -Compress
        $equipUnowned = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-equip-unowned'; Count = '1'; Requests = $bufEquipUnowned }).RequestsResults | ConvertFrom-Json
        Assert ($equipUnowned[0].Result -eq 107) 'equipping an unowned, non-free visual returns DecalNotBought (107)'
        Assert ($null -ne $equipUnowned[0].DecalManagerData) 'the DecalNotBought rollback carries the full DecalManagerData blob'

        $bufEquipUnknown = @{ '0' = @{ action = 110; data = 'CAMOS_DOES_NOT_EXIST' } } | ConvertTo-Json -Depth 5 -Compress
        $equipUnknown = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-equip-unknown'; Count = '1'; Requests = $bufEquipUnknown }).RequestsResults | ConvertFrom-Json
        Assert ($equipUnknown[0].Result -eq 108) 'equipping an unrecognised visual name returns DecalCategoryNotFound (108), not DecalNotBought'

        # HELMETS_EMPTY: PRICEWARBUCKS=0, PRICEGOLD=0, PURCHASABLE=shop, never explicitly bought —
        # PlayerVisual.isBought treats a free shop item as always-owned, so equip must not require a
        # prior BuyDecal for it.
        $bufEquipFreeUnbought = @{ '0' = @{ action = 110; data = 'HELMETS_EMPTY' } } | ConvertTo-Json -Depth 5 -Compress
        $equipFreeUnbought = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-equip-free'; Count = '1'; Requests = $bufEquipFreeUnbought }).RequestsResults | ConvertFrom-Json
        Assert ($equipFreeUnbought[0].Result -eq 1) 'a zero-price PURCHASABLE=shop visual equips without ever being explicitly bought'
        $afterEquipFree = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        $decalData2 = $afterEquipFree.PlayerData.DecalManagerData.S | ConvertFrom-Json
        Assert ($decalData2.slots.'1'.equippedID -eq 'HELMETS_EMPTY') 'CATEGORYID=1 (HELMETS_) is a distinct slot key from CATEGORYID=0'

        Write-Host "`nSendRequestBuffer (98): BuyCardPack against the verified catalog"
        # BuyCardPack/BuyThreeCards both run their own client-side RNG before sending the request —
        # the asserted `cards` array is never read server-side, so it is intentionally left empty
        # here to prove the server never depends on it.
        $unknownPackData = @{ cards = @(); cardPack = 'DOES_NOT_EXIST'; discount = 0; StartTime = 0 } | ConvertTo-Json -Compress
        $bufUnknownPack = @{ '0' = @{ action = 97; data = $unknownPackData } } | ConvertTo-Json -Depth 5 -Compress
        $unknownPackBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-pack-unknown'; Count = '1'; Requests = $bufUnknownPack }).RequestsResults | ConvertFrom-Json
        Assert ($unknownPackBuy[0].Result -eq 112) 'an unknown pack name returns CardPackNotFound (112)'

        $discountPackData = @{ cards = @(); cardPack = 'BRONZE_CARDPACK'; discount = 10; StartTime = 0 } | ConvertTo-Json -Compress
        $bufDiscountPack = @{ '0' = @{ action = 97; data = $discountPackData } } | ConvertTo-Json -Depth 5 -Compress
        $discountPackBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-pack-discount'; Count = '1'; Requests = $bufDiscountPack }).RequestsResults | ConvertFrom-Json
        Assert ($discountPackBuy[0].Result -eq 13601) 'a nonzero client-asserted discount on a card pack purchase is refused (NoDiscountFound)'

        $goldBeforePack = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.Gold.N
        $bronzePackData = @{ cards = @('SLOWMOVE'); cardPack = 'BRONZE_CARDPACK'; discount = 0; StartTime = 0 } | ConvertTo-Json -Compress
        $bufBronzePack = @{ '0' = @{ action = 97; data = $bronzePackData } } | ConvertTo-Json -Depth 5 -Compress
        $bronzePackBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-pack-bronze'; Count = '1'; Requests = $bufBronzePack }).RequestsResults | ConvertFrom-Json
        if ($goldBeforePack -ge 19) {
            Assert ($bronzePackBuy[0].Result -eq 1) 'BRONZE_CARDPACK succeeds when 19 gold (the catalog GOLD price) is available'
            $afterBronzePack = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
            Assert ([long]$afterBronzePack.PlayerData.Gold.N -eq ($goldBeforePack - 19)) 'exactly 19 gold (the catalog price) was debited, never the clients own asserted amount (there is none to assert)'
            $cardData1 = $afterBronzePack.PlayerData.CardManagerData.S | ConvertFrom-Json
            $totalCards1 = ($cardData1.cardData.PSObject.Properties | ForEach-Object { $_.Value.amount } | Measure-Object -Sum).Sum
            Assert ($totalCards1 -eq 10) 'a bronze pack awards exactly CardsInPack (10) cards, server-generated, not the empty client-asserted cards array'
        } else {
            Assert ($bronzePackBuy[0].Result -eq 100) 'BRONZE_CARDPACK correctly fails as NotEnoughWarbucks (the only evidenced insufficient-funds code for this action, reused even for a Gold-priced pack) when the real remaining balance is below 19 gold'
        }

        $warbucksBeforeThree = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.WarBucks.N
        $threeCardsData = @{ cards = @(); cardPack = 'THREE_CARDS'; discount = 0; StartTime = 0 } | ConvertTo-Json -Compress
        $bufThreeCards = @{ '0' = @{ action = 97; data = $threeCardsData } } | ConvertTo-Json -Depth 5 -Compress
        $threeCardsBuy = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-pack-three'; Count = '1'; Requests = $bufThreeCards }).RequestsResults | ConvertFrom-Json
        if ($warbucksBeforeThree -ge 1200) {
            Assert ($threeCardsBuy[0].Result -eq 1) 'THREE_CARDS succeeds when 1200 warbucks (the catalog WARBUCKS price) is available'
            $afterThreeCards = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
            Assert ([long]$afterThreeCards.PlayerData.WarBucks.N -eq ($warbucksBeforeThree - 1200)) 'exactly 1200 warbucks (the catalog price) was debited for THREE_CARDS'
            $cardData2 = $afterThreeCards.PlayerData.CardManagerData.S | ConvertFrom-Json
            $totalCards2 = ($cardData2.cardData.PSObject.Properties | ForEach-Object { $_.Value.amount } | Measure-Object -Sum).Sum
            Assert ($totalCards2 -eq 13) 'THREE_CARDS awards exactly 3 more cards on top of the 10 from the bronze pack (BuyThreeCards ignores CardsInPack entirely)'
        } else {
            Assert ($threeCardsBuy[0].Result -eq 100) 'THREE_CARDS correctly fails as NotEnoughWarbucks when the real remaining balance is below 1200'
        }
    } else {
        Write-Host "`nSendRequestBuffer (98): BuyWeapon / BuyUnit"
        Write-Host 'Skipping catalog-dependent BuyWeapon/BuyUnit assertions; no catalog loaded.'
    }

    Write-Host "`nGetPlayerData (34): buffers carried from an unacknowledged prior session"
    # Shape of RequestBufferManager.GetJsonData(): Dictionary<string, RequestBuffer>.
    $buffersPayload = @{
        'buf-offline' = @{
            alreadySent  = $false
            id           = 'buf-offline'
            requestCount = 1
            requests     = @{ '0' = @{ action = 105; data = 'Soldier1' } }
        }
    } | ConvertTo-Json -Depth 8 -Compress
    $offline = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = $buffersPayload }
    Assert ($offline.Result -eq 1) 'GetPlayerData with a Buffers payload still succeeds'
    $levelData2 = $offline.PlayerData.LevelManagerData.S | ConvertFrom-Json
    Assert ($levelData2.savedArmies.Soldier1.showed -eq $true) 'a buffer carried on GetPlayerData is applied before the response is built'
    $offlineReplay = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = $buffersPayload }
    Assert ($offlineReplay.Result -eq 1) 'replaying the same offline buffer via GetPlayerData does not error'

    Write-Host "`nUpdateDeviceToken (13)"
    $devTok = SendJson -RequestId 13 -Token $token -PlayerId $playerId -Fields @{ DeviceToken = 'abc123'; Locale = 'en' }
    Assert ($devTok.Result -eq 1) 'UpdateDeviceToken succeeds'
    $badLocale = SendJson -RequestId 13 -Token $token -PlayerId $playerId -Fields @{ DeviceToken = 'abc123'; Locale = '???' }
    Assert ($badLocale.Result -gt 10) 'an invalid locale is rejected'

    Write-Host "`nChangeLanguage (150)"
    $lang = SendJson -RequestId 150 -Token $token -PlayerId $playerId -Fields @{ Locale = 'fr' }
    Assert ($lang.Result -eq 1) 'ChangeLanguage succeeds'

    Write-Host "`nChangePlayerCountry (196)"
    $country = SendJson -RequestId 196 -Token $token -PlayerId $playerId -Fields @{ NewCountryCode = 'gb' }
    Assert ($country.Result -eq 1) 'ChangePlayerCountry succeeds'
    $badCountry = SendJson -RequestId 196 -Token $token -PlayerId $playerId -Fields @{ NewCountryCode = 'GBR' }
    Assert ($badCountry.Result -gt 10) 'a non-2-letter country code is rejected'

    Write-Host "`nUpdateSettings (165)"
    $settingsJson = @{ challenge = $true; squadStatus = $false; squadEvents = $true; maintenance = $false; playerLeague = $true; dailyRewardNotification = $false } | ConvertTo-Json -Compress
    $settings = SendJson -RequestId 165 -Token $token -PlayerId $playerId -Fields @{ Settings = $settingsJson }
    Assert ($settings.Result -eq 1) 'UpdateSettings succeeds'
    $badSettings = SendJson -RequestId 165 -Token $token -PlayerId $playerId -Fields @{ Settings = 'not json' }
    Assert ($badSettings.Result -gt 10) 'malformed Settings JSON is rejected'
    $afterSettings = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
    $storedSettings = $afterSettings.PlayerData.Settings.S | ConvertFrom-Json
    Assert ($storedSettings.challenge -eq $true -and $storedSettings.squadStatus -eq $false) 'UpdateSettings persisted into the Settings subsystem blob'

    Write-Host "`nChangePlayerName (139): free first rename"
    $rename1 = SendJson -RequestId 139 -Token $token -PlayerId $playerId -Fields @{ Name = 'Recruit2'; PayForRename = '0' }
    Assert ($rename1.Result -eq 1) 'the first rename succeeds'
    Assert ($rename1.Name -eq 'Recruit2') 'the response echoes the new name as a bare string'
    Assert ($rename1.PayForRename -eq 0) 'the first rename is free'
    Assert ($rename1.RenameCount -eq 1) 'RenameCount advances to 1'

    $currentName = 'Recruit2'
    if ($catalogLoaded) {
        Write-Host "`nChangePlayerName (139): priced rename against the verified catalog (SecondRenameGoldCost=25)"
        $goldBeforeRename = [long]$afterSettings.PlayerData.Gold.N
        $rename2 = SendJson -RequestId 139 -Token $token -PlayerId $playerId -Fields @{ Name = 'Recruit3'; PayForRename = '1' }
        Assert ($rename2.Result -eq 1) 'a priced second rename succeeds when the catalog is loaded'
        Assert ($rename2.PayForRename -eq 1) 'the second rename is charged, not free'
        Assert ($rename2.RenameCount -eq 2) 'RenameCount advances to 2'
        $currentName = 'Recruit3'
        $afterRename = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([long]$afterRename.PlayerData.Gold.N -eq $goldBeforeRename - 25) 'exactly 25 gold (SecondRenameGoldCost, RenameCount=1) was debited for the second rename'
        # PlayerAnalytics.renameGoldPrice doubles per rename: 2^(RenameCount-1) * 25. At
        # RenameCount=2 (this third rename) that is 2 * 25 = 50. Gold remaining at this point
        # depends on how much the catalog-priced weapon-upgrade tests above already spent, so
        # whether this succeeds or correctly fails for insufficient funds is computed, not assumed.
        $goldBeforeRename3 = [long]$afterRename.PlayerData.Gold.N
        $rename3 = SendJson -RequestId 139 -Token $token -PlayerId $playerId -Fields @{ Name = 'Recruit4'; PayForRename = '1' }
        if ($goldBeforeRename3 -ge 50) {
            Assert ($rename3.Result -eq 1) 'a third rename succeeds when 50 gold (the doubled price) is available'
            $afterRename3 = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
            Assert ([long]$afterRename3.PlayerData.Gold.N -eq $goldBeforeRename3 - 50) 'the third rename price doubled to 50 gold, matching the 2^(RenameCount-1) formula'
            $currentName = 'Recruit4'
        } else {
            # NotEnoughGoldForChangeName (11402) — a rename-specific code, not the generic NotEnoughGold (103).
            Assert ($rename3.Result -eq 11402) 'a third rename correctly fails as NotEnoughGoldForChangeName when the doubled 50-gold price exceeds the real remaining balance'
        }
    } else {
        Write-Host "`nChangePlayerName (139): priced rename without a configured catalog"
        $rename2 = SendJson -RequestId 139 -Token $token -PlayerId $playerId -Fields @{ Name = 'Recruit3'; PayForRename = '1' }
        Assert ($rename2.Result -eq 503) 'a second rename is refused, not charged an invented price, while no catalog is loaded'
    }

    Write-Host "`nGetPlayerInfo (170)"
    $info = SendJson -RequestId 170 -Token $token -PlayerId $playerId -Fields @{ PlayerInfoId = $playerId }
    Assert ($info.Result -eq 1) 'GetPlayerInfo succeeds for an existing player'
    Assert ($info.PlayerInfo.Name.S -eq $currentName) 'GetPlayerInfo reflects the renamed player'
    Assert ($null -eq $info.PlayerInfo.DeviceToken) 'GetPlayerInfo withholds the DeviceToken from a third party'
    $missingInfo = SendJson -RequestId 170 -Token $token -PlayerId $playerId -Fields @{ PlayerInfoId = 'does-not-exist' }
    Assert ($missingInfo.Result -eq 1) 'GetPlayerInfo for an unknown id is still a protocol success'
    # PowerShell property access can't distinguish "absent" from "present but null", so check the
    # raw body: OnGetPlayerInfo indexes mResponse["PlayerInfo"] directly on the top-level
    # Dictionary<string,object>, which throws if the key is missing even though the caller then
    # compares the result to null — the key must be present with a literal JSON null.
    Assert (($missingInfo | ConvertTo-Json -Compress) -match '"PlayerInfo":null') 'GetPlayerInfo carries an explicit null PlayerInfo key for an unknown id, not an omitted one'

    Write-Host "`nRefillDogtags (70) / PayOneDogTag (129)"
    $dogtagSnapshot = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
    $dogTagMax = [int]$dogtagSnapshot.PlayerData.DogTagMax.N
    $dogTagSecondsBefore = [int]$dogtagSnapshot.PlayerData.DogTagSeconds.N
    Assert ($dogTagSecondsBefore -eq 0) 'a freshly created account starts with zero accumulated DogTagSeconds'

    # PayOneDogTag is not a purchase — every call site spends one already-held dog tag as an
    # early-quit penalty. With zero seconds accumulated, it must floor at zero, not go negative.
    $payWithZero = SendJson -RequestId 129 -Token $token -PlayerId $playerId
    Assert ($payWithZero.Result -eq 1) 'PayOneDogTag always succeeds; it has no evidenced failure code'
    Assert ($payWithZero.Seconds -eq 0) 'consuming a dog tag with nothing accumulated floors at zero, never negative'
    Assert ($null -ne $payWithZero.LastUpdate) 'PayOneDogTag carries LastUpdate, an unguarded top-level read in OnPayOneDogTag'

    $goldBeforeDogtags = [long]$dogtagSnapshot.PlayerData.Gold.N
    # dogtagRefillPrice = 35 - 2*currentDogtags; at 0 current dogtags that is the full 35 gold.
    $refill1 = SendJson -RequestId 70 -Token $token -PlayerId $playerId
    if ($goldBeforeDogtags -ge 35) {
        Assert ($refill1.Result -eq 1) 'RefillDogtags succeeds when 35 gold (the price at 0 current dogtags) is available'
        Assert ($refill1.Gold -eq ($goldBeforeDogtags - 35)) 'exactly 35 gold was debited, matching DogTagManager.dogtagRefillPrice at 0 dogtags'
        $afterRefill = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([int]$afterRefill.PlayerData.DogTagSeconds.N -eq $dogTagMax) 'a successful refill sets DogTagSeconds to the server DogTagMax, not a client-asserted value'

        # Already full: DogtagDialog never lets a genuine client send this, and there is no
        # evidenced failure code for it, so it is an idempotent no-op success instead.
        $refillAgain = SendJson -RequestId 70 -Token $token -PlayerId $playerId
        Assert ($refillAgain.Result -eq 1) 'refilling an already-full dogtag pool is an idempotent success'
        Assert ($refillAgain.Gold -eq ($goldBeforeDogtags - 35)) 'refilling an already-full pool charges nothing further'

        $payAfterFull = SendJson -RequestId 129 -Token $token -PlayerId $playerId
        Assert ($payAfterFull.Result -eq 1) 'PayOneDogTag after a refill succeeds'
        if ($catalogLoaded) {
            # DogTagRefillTime=900 in the verified catalog (Google2u.Constants).
            Assert ($payAfterFull.Seconds -eq ($dogTagMax - 900)) 'consuming one dog tag subtracts exactly one DogTagRefillTime period (900s) from the full pool'
        }
    } else {
        Assert ($refill1.Result -eq 7001) 'RefillDogtags correctly fails as NotEnoughGoldForDogtags when the real remaining balance is below the computed price'
    }

    Write-Host "`nSquad membership: CheckUniqueSquadName (41) / CreateSquad (37) / JoinSquad (38) / GetSquadDetails (45) / GetAllSquadMembers (44) / LeaveSquad (49)"
    $squadName = 'Smoke' + [guid]::NewGuid().ToString('N').Substring(0, 8)
    $uniqueCheck = SendJson -RequestId 41 -Token $token -PlayerId $playerId -Fields @{ SquadId = $squadName }
    Assert ($uniqueCheck.Result -eq 1) 'CheckUniqueSquadName succeeds'
    Assert ($uniqueCheck.IsUnique -eq $true) 'a never-used squad name is reported unique'

    $overlongNameData = @{ SquadId = 'ThisNameIsWayTooLong'; IsPublic = '1'; Icon = 'icon1'; SkillRequirement = '0' }
    $overlongName = SendJson -RequestId 37 -Token $token -PlayerId $playerId -Fields $overlongNameData
    Assert ($overlongName.Result -eq 11301) 'CreateSquad refuses a squad name over DatabaseSquad.maxSquadName (15 chars) as WrongPlayerData'

    # CreateSquad costs (squadCreationsCount + 1) * WarBucksCreateSquadPrice (verified 50,000) — far
    # beyond this account's starting balance (500/15,000), so the reachable outcome in this suite is
    # always the insufficient-funds refusal; branch dynamically rather than assume it, in case a
    # future run's starting balance or price ever changes.
    $warBucksBeforeSquad = [long](SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.WarBucks.N
    $createSquadData = @{ SquadId = $squadName; IsPublic = '1'; Icon = 'icon1'; SkillRequirement = '0' }
    $createSquad = SendJson -RequestId 37 -Token $token -PlayerId $playerId -Fields $createSquadData
    if ($catalogLoaded -and $warBucksBeforeSquad -ge 50000) {
        Assert ($createSquad.Result -eq 1) 'CreateSquad succeeds when the real remaining balance covers the price'
        Assert ($createSquad.SquadId -eq $squadName) 'CreateSquad echoes the squad name as SquadId'
        Assert ($createSquad.PlayerRank -eq 2) 'the creator is assigned SquadRank.Leader (2)'
        Assert ($createSquad.Squad.Id.S -eq $squadName) 'the nested Squad object carries its own Id'
        Assert ($createSquad.squadCreationsCnt -eq 1) 'squadCreationsCnt advances to 1 after the first creation'
        $afterCreate = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ([long]$afterCreate.PlayerData.WarBucks.N -eq ($warBucksBeforeSquad - 50000)) 'exactly 50,000 warbucks (the catalog price for the first squad) was debited'

        $uniqueAfterCreate = SendJson -RequestId 41 -Token $token -PlayerId $playerId -Fields @{ SquadId = $squadName }
        Assert ($uniqueAfterCreate.IsUnique -eq $false) 'a squad name already taken is no longer reported unique'

        $sameNameAgain = SendJson -RequestId 37 -Token $token -PlayerId $playerId -Fields $createSquadData
        Assert ($sameNameAgain.Result -eq 13301) 'a player already in a squad cannot create another (PlayerAlreadyInSquad)'

        $details = SendJson -RequestId 45 -Token $token -PlayerId $playerId -Fields @{ SquadId = $squadName }
        Assert ($details.Result -eq 1) 'GetSquadDetails succeeds for the squad just created'
        Assert ($details.Squad.Id.S -eq $squadName) 'GetSquadDetails returns the same squad'

        $members = SendJson -RequestId 44 -Token $token -PlayerId $playerId -Fields @{ SquadId = $squadName }
        Assert ($members.Result -eq 1) 'GetAllSquadMembers succeeds'
        Assert ($members.SquadMembers.Count -eq 1) 'a freshly created squad has exactly its founder as a member'
        Assert ($members.SquadMembers[0].Id.S -eq $playerId) 'the sole member is the squad creator'
        Assert ($members.SquadMembers[0].SquadRank.N -eq '2') "the member's Player projection reflects SquadRank.Leader"

        $leave = SendJson -RequestId 49 -Token $token -PlayerId $playerId
        Assert ($leave.Result -eq 1) 'LeaveSquad succeeds'
        $afterLeave = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        Assert ($null -eq $afterLeave.Player.SquadId) 'leaving clears the players SquadId'
    } else {
        Assert ($createSquad.Result -eq 11403) 'CreateSquad correctly fails as NotEnoughWarBucksForCreateSquad when the real remaining balance is below the escalating price'
    }

    $joinMissing = SendJson -RequestId 38 -Token $token -PlayerId $playerId -Fields @{ NewSquadId = 'DoesNotExist' + [guid]::NewGuid().ToString('N') }
    Assert ($joinMissing.Result -eq 3805) 'JoinSquad on a nonexistent squad returns SquadNoLongerExists'

    $detailsMissing = SendJson -RequestId 45 -Token $token -PlayerId $playerId -Fields @{ SquadId = 'DoesNotExist' + [guid]::NewGuid().ToString('N') }
    Assert ($detailsMissing.Result -eq 4501) 'GetSquadDetails for a nonexistent squad returns NoSquadFound'

    $membersMissing = SendJson -RequestId 44 -Token $token -PlayerId $playerId -Fields @{ SquadId = 'DoesNotExist' + [guid]::NewGuid().ToString('N') }
    Assert ($membersMissing.Result -eq 4501) 'GetAllSquadMembers for a nonexistent squad returns NoSquadFound'

    $leaveNotInSquad = SendJson -RequestId 49 -Token $token -PlayerId $playerId
    Assert ($leaveNotInSquad.Result -eq 4901) 'LeaveSquad while not in a squad returns SquadLeaveError'

    Write-Host "`nSquad management: PromotePlayer (55) / DemotePlayer (58) / PromotePlayerToFounder (57) / KickPlayer (172) / UpdateSquad (131) / UpdateSquadEmblem (63) / GetSquads (56) / FindSuggestedSquads (81)"
    # None of these six rank/settings actions can reach their success path in this suite either,
    # since that needs a real squad and CreateSquad's own success path is not economically reachable
    # (see above) — but "not currently in any squad" is a real, deterministic, always-reachable
    # refusal for every one of them, verified here for real rather than skipped.
    $notLeaderCases = @(
        @{ Id = 55; Fields = @{ PlayerToPromoteId = 'someone'; OldSquadRank = '0' }; Name = 'PromotePlayer' },
        @{ Id = 58; Fields = @{ PlayerToDemoteId = 'someone'; OldSquadRank = '1' }; Name = 'DemotePlayer' },
        @{ Id = 57; Fields = @{ PlayerToPromoteId = 'someone' }; Name = 'PromotePlayerToFounder' },
        @{ Id = 172; Fields = @{ PlayerToKickId = 'someone' }; Name = 'KickPlayer' },
        @{ Id = 131; Fields = @{ IsPublic = '1'; RequiredMedals = '0' }; Name = 'UpdateSquad' },
        @{ Id = 63; Fields = @{ Icon = 'icon2' }; Name = 'UpdateSquadEmblem' }
    )
    foreach ($case in $notLeaderCases) {
        $result = SendJson -RequestId $case.Id -Token $token -PlayerId $playerId -Fields $case.Fields
        Assert ($result.Result -eq 6301) "$($case.Name) while not leading any squad returns NotLeaderOfSquad"
    }

    # No squad in this run's isolated database ever finishes creation (the price is unreachable), so
    # a real, deterministic empty result is the correct — not skipped — outcome for both searches.
    $searchName = SendJson -RequestId 56 -Token $token -PlayerId $playerId -Fields @{ SquadNameStart = 'NoSquadHasThisPrefix' }
    Assert ($searchName.Result -eq 1) 'GetSquads succeeds'
    Assert ($searchName.Items.Count -eq 0) 'GetSquads returns an empty Items array when no public squad matches the prefix'
    $searchSuggested = SendJson -RequestId 81 -Token $token -PlayerId $playerId -Fields @{ Skill = '0' }
    Assert ($searchSuggested.Result -eq 1) 'FindSuggestedSquads succeeds'
    Assert ($searchSuggested.Items.Count -eq 0) 'FindSuggestedSquads returns an empty Items array when no public squad exists yet'

    Write-Host "`nSquad invite/request flow: InvitePlayerToSquad (59) / JoinSquadRequest (132) / AcceptSquadJoinRequest (133) / DeclineSquadJoinRequest (181) / GetFullSquadInfo (151)"
    $invite = SendJson -RequestId 59 -Token $token -PlayerId $playerId -Fields @{ PlayerToInviteId = 'someone' }
    Assert ($invite.Result -eq 6301) 'InvitePlayerToSquad while not in any squad returns NotLeaderOfSquad'

    $joinRequest = SendJson -RequestId 132 -Token $token -PlayerId $playerId -Fields @{ SquadId = 'DoesNotExist' + [guid]::NewGuid().ToString('N') }
    Assert ($joinRequest.Result -eq 3805) 'JoinSquadRequest for a nonexistent squad returns SquadNoLongerExists'

    $acceptRequest = SendJson -RequestId 133 -Token $token -PlayerId $playerId -Fields @{ SquadId = $squadName; PlayerToJoin = 'someone' }
    Assert ($acceptRequest.Result -eq 6301) 'AcceptSquadJoinRequest while not leading any squad returns NotLeaderOfSquad'

    $declineRequest = SendJson -RequestId 181 -Token $token -PlayerId $playerId -Fields @{ MessageId = 'msg1'; Id = 'someone' }
    Assert ($declineRequest.Result -eq 6301) 'DeclineSquadJoinRequest while not leading any squad returns NotLeaderOfSquad'

    $fullInfoMissing = SendJson -RequestId 151 -Token $token -PlayerId $playerId -Fields @{ SquadId = 'DoesNotExist' + [guid]::NewGuid().ToString('N') }
    Assert ($fullInfoMissing.Result -eq 4501) 'GetFullSquadInfo for a nonexistent squad returns NoSquadFound'

    Write-Host "`nSquad card pool: DepositCards (174) / WithdrawCard (175)"
    # WithdrawCard always needs the caller to be in a squad, which this account never reaches
    # (CreateSquad's price is unreachable, see above) — a real, deterministic refusal, not skipped.
    $withdraw = SendJson -RequestId 175 -Token $token -PlayerId $playerId -Fields @{ IdOfPlayer = $playerId; CardId = 'SLOWMOVE' }
    Assert ($withdraw.Result -eq 11301) 'WithdrawCard while not in any squad returns WrongPlayerData'

    $depositUnowned = @{ 'DOES_NOT_EXIST_CARD' = (@{ amount = 1 } | ConvertTo-Json -Compress) } | ConvertTo-Json -Compress
    $depositUnownedResult = SendJson -RequestId 174 -Token $token -PlayerId $playerId -Fields @{ AddedCards = $depositUnowned; RemovedCards = '{}' }
    Assert ($depositUnownedResult.Result -eq 11301) 'DepositCards for a card the player does not own returns WrongPlayerData'

    $withdrawUndeposited = @{ 'DOES_NOT_EXIST_CARD' = (@{ amount = 1 } | ConvertTo-Json -Compress) } | ConvertTo-Json -Compress
    $removeUndepositedResult = SendJson -RequestId 174 -Token $token -PlayerId $playerId -Fields @{ AddedCards = '{}'; RemovedCards = $withdrawUndeposited }
    Assert ($removeUndepositedResult.Result -eq 11301) 'DepositCards un-depositing a card that was never deposited returns WrongPlayerData'

    $buddyCardDeposit = @{ BuddyCard = (@{ amount = 1 } | ConvertTo-Json -Compress) } | ConvertTo-Json -Compress
    $buddyCardResult = SendJson -RequestId 174 -Token $token -PlayerId $playerId -Fields @{ AddedCards = $buddyCardDeposit; RemovedCards = '{}' }
    Assert ($buddyCardResult.Result -eq 11301) 'DepositCards refuses the literal BuddyCard id (a distinct, unimplemented wire shape) rather than mishandling it'

    # A genuine deposit-then-withdraw round trip needs a real owned card; use whichever card (if
    # any) the BuyCardPack tests above actually won, rather than assuming a specific one.
    $ownedCardsSnapshot = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
    $ownedCardData = $ownedCardsSnapshot.PlayerData.CardManagerData.S | ConvertFrom-Json
    $ownedCardName = $null
    if ($null -ne $ownedCardData -and $null -ne $ownedCardData.cardData) {
        foreach ($prop in $ownedCardData.cardData.PSObject.Properties) {
            if ($prop.Value.amount -gt 0) { $ownedCardName = $prop.Name; break }
        }
    }
    if ($null -ne $ownedCardName) {
        $depositOwned = @{ $ownedCardName = (@{ amount = 1 } | ConvertTo-Json -Compress) } | ConvertTo-Json -Compress
        $depositOwnedResult = SendJson -RequestId 174 -Token $token -PlayerId $playerId -Fields @{ AddedCards = $depositOwned; RemovedCards = '{}' }
        Assert ($depositOwnedResult.Result -eq 1) "DepositCards succeeds for $ownedCardName, a card this account actually won from BuyCardPack"
        # GetPlayerData never carries a Player object at all (only PlayerData) — GetPlayerInfo is
        # the action that projects the DatabasePlayer shape DepositedCards actually lives on.
        $afterDeposit = SendJson -RequestId 170 -Token $token -PlayerId $playerId -Fields @{ PlayerInfoId = $playerId }
        $depositedCardData = $afterDeposit.PlayerInfo.DepositedCards.M
        Assert ($null -ne $depositedCardData -and $null -ne $depositedCardData.$ownedCardName) "the deposited card appears on the players own Player.DepositedCards, matching DatabasePlayer.CreateFromDatabase's read site"
        Assert ($depositedCardData.$ownedCardName.M.Amount.N -eq '1') 'the deposited amount is exactly 1, in the nested M/Amount/N shape DatabasePlayer expects'

        $withdrawUndeposited2Result = SendJson -RequestId 174 -Token $token -PlayerId $playerId -Fields @{ AddedCards = '{}'; RemovedCards = $depositOwned }
        Assert ($withdrawUndeposited2Result.Result -eq 1) 'un-depositing the same card back succeeds'
    } else {
        Write-Host '  (skipped: no owned card available in this run to deposit — BuyCardPack success path above was not reachable either)'
    }

    Write-Host "`nCraftCard (176) / ClaimCraftedCard (177)"
    $wrongCount = @('SLOWMOVE', 'SLOWMOVE') | ConvertTo-Json -Compress
    $wrongCountResult = SendJson -RequestId 176 -Token $token -PlayerId $playerId -Fields @{ Cards = $wrongCount }
    Assert ($wrongCountResult.Result -eq 11301) 'CraftCard with anything other than exactly 3 cards returns WrongPlayerData'

    $mixedRarity = @('SLOWMOVE', 'FREEZE', 'SLOWMOVE') | ConvertTo-Json -Compress
    $mixedRarityResult = SendJson -RequestId 176 -Token $token -PlayerId $playerId -Fields @{ Cards = $mixedRarity }
    Assert ($mixedRarityResult.Result -eq 11301) 'CraftCard with cards of different rarities (SLOWMOVE=Gold, FREEZE=Silver) returns WrongPlayerData'

    if (-not $catalogLoaded) {
        # Without a catalog there's no row to resolve at all, so any three names hit the same
        # WrongPlayerData refusal — a real assertion for this scenario, distinct from the
        # catalog-loaded ownership check below (which needs real card data to be meaningful).
        $noCatalogCards = @('EMPTYMAG', 'SMALLMEDKIT', 'VEHICLEHEALTH') | ConvertTo-Json -Compress
        $noCatalogResult = SendJson -RequestId 176 -Token $token -PlayerId $playerId -Fields @{ Cards = $noCatalogCards }
        Assert ($noCatalogResult.Result -eq 11301) 'CraftCard with no catalog loaded returns WrongPlayerData (no row to resolve)'
    }

    $claimNothing = SendJson -RequestId 177 -Token $token -PlayerId $playerId
    Assert ($claimNothing.Result -eq 11301) 'ClaimCraftedCard with nothing crafting returns WrongPlayerData'

    if ($catalogLoaded) {
        # Find up to 3 distinct Bronze (RARITY=1) cards this account actually owns, from whatever
        # BuyCardPack tests above actually won — never assumed, since the outcome is random.
        $catalogRaw = Get-Content $ContentPath -Raw | ConvertFrom-Json
        $cardDefsSheet = $catalogRaw.sheets | Where-Object { $_.type -eq 'Google2u.CardDefinitions' } | Select-Object -First 1
        $bronzeNames = @{}
        foreach ($row in $cardDefsSheet.rows) { if ($row.RARITY -eq 1) { $bronzeNames[$row.NAME] = $true } }
        $ownedSnapshot = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
        $ownedCards2 = $ownedSnapshot.PlayerData.CardManagerData.S | ConvertFrom-Json
        $ownedBronze = @()
        $ownedBronzeSet = @{}
        if ($null -ne $ownedCards2 -and $null -ne $ownedCards2.cardData) {
            foreach ($prop in $ownedCards2.cardData.PSObject.Properties) {
                if ($prop.Value.amount -gt 0 -and $bronzeNames.ContainsKey($prop.Name)) {
                    $ownedBronzeSet[$prop.Name] = $true
                    if ($ownedBronze.Count -lt 3) { $ownedBronze += $prop.Name }
                }
            }
        }

        # Pick 3 real Bronze names this account does NOT currently own, computed from the live
        # snapshot above rather than a hardcoded literal list — a card BuyCardPack randomly won
        # earlier in this same continuous run could otherwise collide with an assumed-unowned name
        # and make this assertion flaky.
        $unownedBronze = @($bronzeNames.Keys | Where-Object { -not $ownedBronzeSet.ContainsKey($_) } | Select-Object -First 3)
        if ($unownedBronze.Count -eq 3) {
            $unownedCards = $unownedBronze | ConvertTo-Json -Compress
            $unownedResult = SendJson -RequestId 176 -Token $token -PlayerId $playerId -Fields @{ Cards = $unownedCards }
            Assert ($unownedResult.Result -eq 11301) "CraftCard for three genuinely unowned Bronze cards ($($unownedBronze -join ', ')) returns WrongPlayerData"
        }

        if ($ownedBronze.Count -ge 3) {
            $craftCards = $ownedBronze[0..2] | ConvertTo-Json -Compress
            $craftResult = SendJson -RequestId 176 -Token $token -PlayerId $playerId -Fields @{ Cards = $craftCards }
            Assert ($craftResult.Result -eq 1) "CraftCard succeeds crafting 3 real owned Bronze cards ($($ownedBronze[0..2] -join ', ')) into a Silver"
            Assert ($null -ne $craftResult.End) 'CraftCard carries End, an unguarded top-level read in OnCraftCards'

            $secondCraft = SendJson -RequestId 176 -Token $token -PlayerId $playerId -Fields @{ Cards = $craftCards }
            Assert ($secondCraft.Result -eq 105) 'a second CraftCard while one is already in progress returns AlreadyUpgrading'

            $claimTooSoon = SendJson -RequestId 177 -Token $token -PlayerId $playerId
            Assert ($claimTooSoon.Result -eq 106) 'ClaimCraftedCard immediately after starting (30 real minutes remaining) returns TooSoonToActivate'
        } else {
            Write-Host '  (skipped: fewer than 3 distinct owned Bronze cards in this run to craft with)'
        }
    }

    Write-Host "`nGameStartedTutorial (119) / TutorialEnded (120)"
    # Snapshot gold here rather than reusing $expectedStartGold: the rename tests above already
    # spent real gold when the catalog is loaded.
    $goldBeforeTutorial = (SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }).PlayerData.Gold.N
    $tutStart = SendJson -RequestId 119 -Token $token -PlayerId $playerId -Fields @{ Name = 'Recruit2' }
    Assert ($tutStart.Result -eq 1) 'GameStartedTutorial succeeds'
    Assert (-not [string]::IsNullOrEmpty($tutStart.BattleId)) 'GameStartedTutorial always carries a BattleId, matching the client''s unguarded top-level read'
    $wrongBattle = SendJson -RequestId 120 -Token $token -PlayerId $playerId -Fields @{ BattleId = 'not-the-right-id'; EndReason = '2'; Experience = '9999'; Gold = '999999'; Warbucks = '999999'; GoldBoxes = '0'; WarBucksBoxes = '0'; ObtainedCards = '[]'; UsedCards = '[]'; ArmyPower = '0' }
    Assert ($wrongBattle.Result -eq 6202) 'TutorialEnded with a mismatched BattleId is rejected as GameDidntExist'
    $tutEnd = SendJson -RequestId 120 -Token $token -PlayerId $playerId -Fields @{ BattleId = $tutStart.BattleId; EndReason = '2'; Experience = '9999'; Gold = '999999'; Warbucks = '999999'; GoldBoxes = '0'; WarBucksBoxes = '0'; ObtainedCards = '[]'; UsedCards = '[]'; ArmyPower = '0' }
    Assert ($tutEnd.Result -eq 1) 'TutorialEnded with the matching BattleId succeeds'
    Assert ($null -ne $tutEnd.LevelExperience) 'TutorialEnded carries LevelExperience, the one unguarded read in OnClassicGameEnded'
    Assert ($tutEnd.TutorialData -eq $true) 'TutorialEnded carries the top-level TutorialData marker'
    $playerAfterTutorial = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
    Assert ($playerAfterTutorial.PlayerData.Gold.N -eq $goldBeforeTutorial) 'the client-reported Gold/Experience/GoldBoxes assertions from TutorialEnded were never applied'
    $tutEndReplay = SendJson -RequestId 120 -Token $token -PlayerId $playerId -Fields @{ BattleId = $tutStart.BattleId; EndReason = '2'; Experience = '9999'; Gold = '999999'; Warbucks = '999999'; GoldBoxes = '0'; WarBucksBoxes = '0'; ObtainedCards = '[]'; UsedCards = '[]'; ArmyPower = '0' }
    Assert ($tutEndReplay.Result -eq 1) 'replaying TutorialEnded after completion is an idempotent success, not a re-application'

    Write-Host "`nUpdateArmyPower (192)"
    $armyPower = SendJson -RequestId 192 -Token $token -PlayerId $playerId -Fields @{ ArmyPower = '4200' }
    Assert ($armyPower.Result -eq 1) 'UpdateArmyPower succeeds'

    Write-Host "`nUpdateRegionPings (140) / PhotonIsFull (143): offline no-ops"
    $regions = SendJson -RequestId 140 -Token $token -PlayerId $playerId -Fields @{ Regions = '{}'; Connection = 'WiFi' }
    Assert ($regions.Result -eq 1) 'UpdateRegionPings acknowledges without contacting Photon'
    $full = SendJson -RequestId 143 -Token $token -PlayerId $playerId
    Assert ($full.Result -eq 1) 'PhotonIsFull acknowledges without contacting Photon'

    Write-Host "`nShown-once flags (163, 168, 169, 180, 182, 183, 213)"
    foreach ($pair in @(@{ Id = 163; Field = 'chatShown' }, @{ Id = 168; Field = 'customizationShown' }, @{ Id = 169; Field = 'warpathShown' }, @{ Id = 180; Field = 'cardpoolShown' }, @{ Id = 183; Field = 'craftingShown' }, @{ Id = 182; Field = 'leagueLeaderboardsShown' }, @{ Id = 213; Field = 'elitesShown' })) {
        $shown = SendJson -RequestId $pair.Id -Token $token -PlayerId $playerId
        Assert ($shown.Result -eq 1) "action $($pair.Id) ($($pair.Field)) succeeds"
    }
    $afterFlags = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
    $analytics = $afterFlags.PlayerData.PlayerAnalyticsData.S | ConvertFrom-Json
    Assert ($analytics.chatShown -eq $true -and $analytics.customizationShown -eq $true -and $analytics.warpathShown -eq $true -and $analytics.cardpoolShown -eq $true -and $analytics.craftingShown -eq $true -and $analytics.leagueLeaderboardsShown -eq $true -and $analytics.elitesShown -eq $true) 'all seven shown-once flags persisted into PlayerAnalyticsData'

    Write-Host "`nNotifyPlayerToDeposit (178)"
    # This account never reaches CreateSquad's real success path (50,000 WarBucks vs. a 15,000
    # starting balance, same limitation documented on the Squad management block above), so the only
    # deterministic, always-reachable outcome here is "not in a squad at all" -> WrongPlayerData,
    # verified for real rather than skipped, matching the posture already established for the
    # rank/settings actions.
    $notifyNoSquad = SendJson -RequestId 178 -Token $token -PlayerId $playerId -Fields @{ SquadMemberId = 'someone' }
    Assert ($notifyNoSquad.Result -eq 11301) 'NotifyPlayerToDeposit while not in a squad returns WrongPlayerData'
    $notifySelf = SendJson -RequestId 178 -Token $token -PlayerId $playerId -Fields @{ SquadMemberId = $playerId }
    Assert ($notifySelf.Result -eq 11301) 'NotifyPlayerToDeposit targeting yourself returns WrongPlayerData'

    Write-Host "`nSendRequestBuffer (98): SaveLastSeenSquadChatTimeStamp (193)"
    # PlayerAnalytics.lastSeenSquadChatTimestamp's setter only ever advances, never regresses;
    # reproduced by patching just this one field of the PlayerAnalyticsData blob (see WorkingState.Analytics).
    $bufChat1 = @{ '0' = @{ action = 193; data = '1000' } } | ConvertTo-Json -Depth 5 -Compress
    $chat1 = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-chat-1'; Count = '1'; Requests = $bufChat1 }).RequestsResults | ConvertFrom-Json
    Assert ($chat1[0].Result -eq 1) 'SaveLastSeenSquadChatTimeStamp succeeds'
    $afterChat1 = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
    $analyticsChat1 = $afterChat1.PlayerData.PlayerAnalyticsData.S | ConvertFrom-Json
    Assert ($analyticsChat1.lastSeenSquadChatTimeStampDB -eq 1000) 'the timestamp persisted into PlayerAnalyticsData'

    $bufChat2 = @{ '0' = @{ action = 193; data = '500' } } | ConvertTo-Json -Depth 5 -Compress
    $chat2 = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-chat-2'; Count = '1'; Requests = $bufChat2 }).RequestsResults | ConvertFrom-Json
    Assert ($chat2[0].Result -eq 1) 'a lower timestamp still reports success'
    $afterChat2 = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
    $analyticsChat2 = $afterChat2.PlayerData.PlayerAnalyticsData.S | ConvertFrom-Json
    Assert ($analyticsChat2.lastSeenSquadChatTimeStampDB -eq 1000) 'a lower timestamp never regresses the stored value, mirroring the client''s own guard'

    $bufChat3 = @{ '0' = @{ action = 193; data = '2000' } } | ConvertTo-Json -Depth 5 -Compress
    $chat3 = (SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-chat-3'; Count = '1'; Requests = $bufChat3 }).RequestsResults | ConvertFrom-Json
    Assert ($chat3[0].Result -eq 1) 'a higher timestamp succeeds'
    $afterChat3 = SendJson -RequestId 34 -Token $token -PlayerId $playerId -Fields @{ Locale = 'en'; Buffers = 'null' }
    $analyticsChat3 = $afterChat3.PlayerData.PlayerAnalyticsData.S | ConvertFrom-Json
    Assert ($analyticsChat3.lastSeenSquadChatTimeStampDB -eq 2000) 'a higher timestamp advances the stored value'
    Assert ($analyticsChat3.chatShown -eq $true) 'the earlier shown-once flags in the same blob survived this later targeted-field patch'

    Write-Host "`nTest (167) / OnVIPExpired (195) / ReportCheater (197)"
    $test = SendJson -RequestId 167 -Token $token -PlayerId $playerId
    Assert ($test.Result -eq 1) 'Test succeeds'
    Assert ($test.Test -eq $true) 'Test carries the Test key, an unguarded top-level read in OnTest'
    $vipExpired = SendJson -RequestId 195 -Token $token -PlayerId $playerId -Fields @{ DogTagRefillTime = '900'; DogTagCap = '5' }
    Assert ($vipExpired.Result -eq 1) 'OnVIPExpired succeeds even though this account has never held VIP'
    $cheater = SendJson -RequestId 197 -Token $token -PlayerId $playerId -Fields @{ ReportedPlayerId = 'suspicious-player'; ReportType = '1'; MyArmyPower = '100'; MyRank = '1'; OpponentArmyPower = '999'; OpponentRank = '1'; TimeOfMatch = '60' }
    Assert ($cheater.Result -eq 1) 'ReportCheater succeeds'
    Assert ($cheater.PlayerID -eq 'suspicious-player') 'ReportCheater carries PlayerID (capitalized exactly like this), an unguarded top-level read in OnReportCheater'

    Write-Host "`nSendLog (166)"
    $log = SendJson -RequestId 166 -Token $token -PlayerId $playerId -Fields @{ PlayerName = 'Recruit2'; Logs = 'test log line'; ClientVersion = '1.4.0' }
    Assert ($log.Result -eq 1) 'SendLog succeeds'
    Assert (-not [string]::IsNullOrEmpty($log.LogId)) 'SendLog carries LogId, the one unguarded top-level read in OnSendLog'

    Write-Host "`nErrorMessage (92)"
    $errorMsg = SendJson -RequestId 92 -Token $token -PlayerId $playerId -Fields @{ PlayerName = 'Recruit2'; ExceptionMessage = 'test exception'; ExceptionStacktrace = 'at Test()'; DbAction = 'GetPlayerData http://example'; ServerResponse = 'response=test'; PostParameters = 'test'; ClientVersion = '1.4.0' }
    Assert ($errorMsg.Result -eq 1) 'ErrorMessage succeeds (reachable when ServerEndpoint.BaseUrl is not literally localhost)'

    Write-Host "`nSendCrashReport (141) / UpdateAnalytics (179)"
    $crash = SendJson -RequestId 141 -Token $token -PlayerId $playerId -Fields @{ ExceptionMessage = 'test'; ExceptionStacktrace = 'test' }
    Assert ($crash.Result -eq 1) 'SendCrashReport succeeds'
    $analyticsUpdate = SendJson -RequestId 179 -Token $token -PlayerId $playerId -Fields @{ PlayerAnalytics = '{}' }
    Assert ($analyticsUpdate.Result -eq 1) 'UpdateAnalytics succeeds'
    $fuse = SendJson -RequestId 1014 -Token $token -PlayerId $playerId -Fields @{ fuseData = '{}' }
    Assert ($fuse.Result -eq 1) 'SaveFuseConfigs succeeds'
    $offerShown = SendJson -RequestId 1007 -Token $token -PlayerId $playerId -Fields @{ showedOffers = '["starter_pack"]' }
    Assert ($offerShown.Result -eq 1) 'SpecialOfferShowed succeeds (a presentation fact, separable from the still-refused accept/purchase flow)'
    $arenaShown = SendJson -RequestId 212 -Token $token -PlayerId $playerId -Fields @{ ArenaId = 'arena_1' }
    Assert ($arenaShown.Result -eq 1) 'WarArenaShown succeeds'

    Write-Host "`nLegacy smoke passed: $script:checks assertions. Local test data/logs: $runRoot"
}
finally {
    foreach ($process in $processes) { if (!$process.HasExited) { Stop-Process -Id $process.Id -ErrorAction SilentlyContinue } }
    foreach ($name in $variables) { [Environment]::SetEnvironmentVariable($name, $prior[$name], 'Process') }
}
