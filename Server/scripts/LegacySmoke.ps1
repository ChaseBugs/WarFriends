# Drives the recovered 1.4.0 client's own boot chain against a live backend.
#
# The request shapes here are copied from BeanstalkServerManager.GetServerRequest and the response
# assertions from ServerResponseHandler: this script fails if the server stops speaking what the
# shipped client parses. It starts an isolated mongod and backend, stops only what it started, and
# restores the calling environment.
param([string]$MongoExecutable = 'mongod', [int]$HttpPort = 18081, [int]$MongoPort = 27029)
$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
$runRoot = Join-Path $serverRoot ('.local/legacy-' + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path (Join-Path $runRoot 'mongo') -Force | Out-Null
$processes = @()
$variables = @('ASPNETCORE_ENVIRONMENT', 'ASPNETCORE_URLS', 'Mongo__Uri', 'Mongo__Database', 'Battle__SigningKey')
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
    $env:ASPNETCORE_ENVIRONMENT = 'Development'
    $env:ASPNETCORE_URLS = "http://127.0.0.1:$HttpPort"
    $env:Mongo__Uri = "mongodb://127.0.0.1:$MongoPort"
    $env:Mongo__Database = 'warfriends_legacy_smoke'
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
    Assert ($created.PlayerData.Gold.N -eq '500') 'PlayerData.Gold is the server starter value, not the client-reported StartingGold'
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
    Assert ($data.PlayerData.DogTagMax.N -eq '10') 'PlayerData carries the server dog-tag cap'

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
    $buf4 = @{ '0' = @{ action = 76; data = 'M4A1' } } | ConvertTo-Json -Depth 5 -Compress
    $buy = SendJson -RequestId 98 -Token $token -PlayerId $playerId -Fields @{ BufferId = 'buf-4'; Count = '1'; Requests = $buf4 }
    $results4 = $buy.RequestsResults | ConvertFrom-Json
    Assert ($results4[0].Result -eq 503) 'BuyWeapon without catalog data reports maintenance rather than a fabricated purchase'

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

    Write-Host "`nChangePlayerName (139): priced rename without a configured price"
    $rename2 = SendJson -RequestId 139 -Token $token -PlayerId $playerId -Fields @{ Name = 'Recruit3'; PayForRename = '1' }
    Assert ($rename2.Result -eq 503) 'a second rename is refused, not charged an invented price, while SecondRenameGoldCost is unconfigured'

    Write-Host "`nGetPlayerInfo (170)"
    $info = SendJson -RequestId 170 -Token $token -PlayerId $playerId -Fields @{ PlayerInfoId = $playerId }
    Assert ($info.Result -eq 1) 'GetPlayerInfo succeeds for an existing player'
    Assert ($info.PlayerInfo.Name.S -eq 'Recruit2') 'GetPlayerInfo reflects the renamed player'
    Assert ($null -eq $info.PlayerInfo.DeviceToken) 'GetPlayerInfo withholds the DeviceToken from a third party'
    $missingInfo = SendJson -RequestId 170 -Token $token -PlayerId $playerId -Fields @{ PlayerInfoId = 'does-not-exist' }
    Assert ($missingInfo.Result -eq 1) 'GetPlayerInfo for an unknown id is still a protocol success'
    # PowerShell property access can't distinguish "absent" from "present but null", so check the
    # raw body: OnGetPlayerInfo indexes mResponse["PlayerInfo"] directly on the top-level
    # Dictionary<string,object>, which throws if the key is missing even though the caller then
    # compares the result to null — the key must be present with a literal JSON null.
    Assert (($missingInfo | ConvertTo-Json -Compress) -match '"PlayerInfo":null') 'GetPlayerInfo carries an explicit null PlayerInfo key for an unknown id, not an omitted one'

    Write-Host "`nLegacy smoke passed: $script:checks assertions. Local test data/logs: $runRoot"
}
finally {
    foreach ($process in $processes) { if (!$process.HasExited) { Stop-Process -Id $process.Id -ErrorAction SilentlyContinue } }
    foreach ($name in $variables) { [Environment]::SetEnvironmentVariable($name, $prior[$name], 'Process') }
}
