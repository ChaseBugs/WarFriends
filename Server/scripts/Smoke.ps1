param([string]$MongoExecutable = 'mongod', [int]$HttpPort=18080, [int]$UdpPort=30080, [int]$MongoPort=27028)
$ErrorActionPreference='Stop'
$serverRoot=Split-Path $PSScriptRoot -Parent
$runRoot=Join-Path $serverRoot ('.local/smoke-'+[guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path (Join-Path $runRoot 'mongo') -Force | Out-Null
$processes=@()
$variables=@('ASPNETCORE_ENVIRONMENT','ASPNETCORE_URLS','Mongo__Uri','Mongo__Database','Battle__SigningKey','Battle__ControlKey','Battle__Port','Battle__ControlPort','Battle__ServerId','Battle__PublicHost','Battle__BindAddress','Battle__ResultOutboxPath')
$prior=@{}
foreach($name in $variables) { $prior[$name]=[Environment]::GetEnvironmentVariable($name,'Process') }
function Restart-BattleProcess($current,[string]$label,[string]$root,[string]$run,[int]$port) {
    if($current.HasExited) { throw "BattleServer stopped before $label restart" }
    Stop-Process -Id $current.Id
    if(!$current.WaitForExit(5000)) { throw "BattleServer did not stop for $label restart" }
    $dll=Join-Path $root 'src/War.BattleServer/bin/Debug/net10.0/War.BattleServer.dll'
    $next=Start-Process dotnet -ArgumentList ('"'+$dll+'"') -WorkingDirectory (Join-Path $root 'src/War.BattleServer') -RedirectStandardOutput (Join-Path $run "War.BattleServer-$label.log") -RedirectStandardError (Join-Path $run "War.BattleServer-$label.error.log") -PassThru -WindowStyle Hidden
    $ready=$false
    for($i=0;$i -lt 40;$i++) {
        if($next.HasExited) { throw "BattleServer failed $label restart; inspect $run" }
        try { $null=Invoke-WebRequest "http://127.0.0.1:$($port+1)/health/ready" -UseBasicParsing -TimeoutSec 1; $ready=$true; break }
        catch { Start-Sleep -Milliseconds 250 }
    }
    if(!$ready) { throw "BattleServer was not ready after $label restart" }
    return $next
}
try {
    dotnet build (Join-Path $serverRoot 'WarFriendsServer.sln') --nologo -v minimal
    if($LASTEXITCODE -ne 0) { throw 'Build failed' }
    $keyBytes=New-Object byte[] 32
    $rng=[Security.Cryptography.RandomNumberGenerator]::Create()
    $rng.GetBytes($keyBytes)
    $rng.Dispose()
    $env:Battle__SigningKey=[Convert]::ToBase64String($keyBytes)
    $controlKeyBytes=New-Object byte[] 32
    $rng=[Security.Cryptography.RandomNumberGenerator]::Create()
    $rng.GetBytes($controlKeyBytes)
    $rng.Dispose()
    $env:Battle__ControlKey=[Convert]::ToBase64String($controlKeyBytes)
    $env:ASPNETCORE_ENVIRONMENT='Development'
    $env:ASPNETCORE_URLS="http://127.0.0.1:$HttpPort"
    $env:Mongo__Uri="mongodb://127.0.0.1:$MongoPort"
    $env:Mongo__Database='warfriends_smoke'
    $env:Battle__Port="$UdpPort"
    $env:Battle__ControlPort="$($UdpPort+1)"
    $env:Battle__ServerId='local-1'
    $env:Battle__PublicHost='127.0.0.1'
    $env:Battle__BindAddress='127.0.0.1'
    $env:Battle__ResultOutboxPath=Join-Path $runRoot 'terminal-outbox'
    $mongoCommand=Get-Command $MongoExecutable -CommandType Application -ErrorAction SilentlyContinue
    if($null -eq $mongoCommand) { throw "MongoDB executable '$MongoExecutable' was not found. Install mongod or pass -MongoExecutable with its full path." }
    $MongoExecutable=if($mongoCommand.Path) { $mongoCommand.Path } else { $mongoCommand.Source }
    $mongoArgs=@('--dbpath',('"'+(Join-Path $runRoot 'mongo')+'"'),'--bind_ip','127.0.0.1','--port',"$MongoPort",'--logpath',('"'+(Join-Path $runRoot 'mongo.log')+'"'))
    $processes+=Start-Process $MongoExecutable -ArgumentList $mongoArgs -PassThru -WindowStyle Hidden
    foreach($project in @('War.Backend','War.BattleServer')) {
        $dll=Join-Path $serverRoot "src/$project/bin/Debug/net10.0/$project.dll"
        $processes+=Start-Process dotnet -ArgumentList ('"'+$dll+'"') -WorkingDirectory (Join-Path $serverRoot "src/$project") -RedirectStandardOutput (Join-Path $runRoot "$project.log") -RedirectStandardError (Join-Path $runRoot "$project.error.log") -PassThru -WindowStyle Hidden
    }
    $battleProcess=$processes[-1]
    $ready=$false
    for($i=0;$i -lt 40;$i++) {
        if(@($processes | Where-Object HasExited).Count -gt 0) { throw "A service stopped; inspect $runRoot" }
        try { $null=Invoke-WebRequest "http://127.0.0.1:$HttpPort/health/ready" -UseBasicParsing -TimeoutSec 1; $ready=$true; break } catch { Start-Sleep -Milliseconds 250 }
    }
    if(!$ready) { throw "Backend not ready; inspect $runRoot" }
    $controlUrl="http://127.0.0.1:$($UdpPort+1)/internal/matches"
    $controlReady=$false
    for($i=0;$i -lt 40;$i++) {
        if(@($processes | Where-Object HasExited).Count -gt 0) { throw "A service stopped; inspect $runRoot" }
        try { $null=Invoke-WebRequest "http://127.0.0.1:$($UdpPort+1)/health/ready" -UseBasicParsing -TimeoutSec 1; $controlReady=$true; break } catch { Start-Sleep -Milliseconds 250 }
    }
    if(!$controlReady) { throw "Battle control endpoint not ready; inspect $runRoot" }
    $metrics=Invoke-RestMethod "http://127.0.0.1:$($UdpPort+1)/health/metrics" -TimeoutSec 2
    if(!$metrics.ready -or $metrics.received -lt 0 -or $metrics.handled -lt 0 -or
       $metrics.malformedDrops -lt 0 -or $metrics.unownedDrops -lt 0 -or
       $metrics.endpointLimitDrops -lt 0 -or $metrics.queueFullDrops -lt 0 -or
       $metrics.pending -lt 0 -or $metrics.pending -gt 512 -or $metrics.tickBacklogs -lt 0) {
        throw 'Battle Worker metrics endpoint returned invalid counters'
    }
    $manifest=@{
        MatchId='smoke-control-match'; ServerId='local-1'; MapId='fixture-map';
        MapRevision=('a'*64); CatalogRevision=('b'*64); Mode='unscored-weapon-prototype';
        AdmissionSeconds=10; DurationSeconds=60; IdleSeconds=10;
        Players=@(
            @{PlayerId=('a'*32); Weapon=@{SourceId='fixture-rifle';ClipSize=2;ReserveAmmo=3;CadenceSeconds=0.1;ReloadSeconds=0.2}},
            @{PlayerId=('b'*32); Weapon=@{SourceId='fixture-rifle';ClipSize=2;ReserveAmmo=3;CadenceSeconds=0.1;ReloadSeconds=0.2}}
        )
    }
    $body=ConvertTo-Json $manifest -Depth 8 -Compress
    $unsignedStatus=0
    try { $null=Invoke-WebRequest $controlUrl -Method Post -Body $body -ContentType 'application/json' -UseBasicParsing }
    catch { $unsignedStatus=[int]$_.Exception.Response.StatusCode }
    if($unsignedStatus -ne 401) { throw "Unsigned match publication returned $unsignedStatus" }
    $stamp=[DateTimeOffset]::UtcNow.ToUnixTimeSeconds().ToString([Globalization.CultureInfo]::InvariantCulture)
    $macBytes=[Text.Encoding]::UTF8.GetBytes("war/match/control/v1/$stamp`n$body")
    $signature=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$macBytes))
    $headers=@{'X-War-Control-Time'=$stamp;'X-War-Control-Mac'=$signature}
    $registered=Invoke-WebRequest $controlUrl -Method Post -Body $body -ContentType 'application/json' -Headers $headers -UseBasicParsing
    $registration=$registered.Content | ConvertFrom-Json
    if([int]$registered.StatusCode -ne 201 -or $registration.code -ne 'registered' -or $registration.matchId -ne 'smoke-control-match' -or $registration.manifestHash -notmatch '^[0-9a-f]{64}$') { throw 'Signed match publication failed' }
    if(@($registration.grants).Count -ne 2) { throw 'Match publication did not issue two grants' }
    $replayed=Invoke-WebRequest $controlUrl -Method Post -Body $body -ContentType 'application/json' -Headers $headers -UseBasicParsing
    $replay=$replayed.Content | ConvertFrom-Json
    if([int]$replayed.StatusCode -ne 200 -or $replay.code -ne 'existing-match' -or
        $replay.grants[0].ticket -ne $registration.grants[0].ticket -or
        $replay.grants[1].ticket -ne $registration.grants[1].ticket) { throw 'Identical registration did not replay its grants' }
    $changed=$manifest.Clone()
    $changed.AdmissionSeconds=11
    $changedBody=ConvertTo-Json $changed -Depth 8 -Compress
    $changedBytes=[Text.Encoding]::UTF8.GetBytes("war/match/control/v1/$stamp`n$changedBody")
    $changedHeaders=@{'X-War-Control-Time'=$stamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$changedBytes))}
    $duplicateStatus=0
    try { $null=Invoke-WebRequest $controlUrl -Method Post -Body $changedBody -ContentType 'application/json' -Headers $changedHeaders -UseBasicParsing }
    catch { $duplicateStatus=[int]$_.Exception.Response.StatusCode }
    if($duplicateStatus -ne 409) { throw "Conflicting match publication returned $duplicateStatus" }
    $malformed='{}'
    $malformedBytes=[Text.Encoding]::UTF8.GetBytes("war/match/control/v1/$stamp`n$malformed")
    $malformedHeaders=@{'X-War-Control-Time'=$stamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$malformedBytes))}
    $malformedStatus=0
    try { $null=Invoke-WebRequest $controlUrl -Method Post -Body $malformed -ContentType 'application/json' -Headers $malformedHeaders -UseBasicParsing }
    catch { $malformedStatus=[int]$_.Exception.Response.StatusCode }
    if($malformedStatus -ne 400) { throw "Signed malformed match returned $malformedStatus" }
    $oldStamp=([long]$stamp-60).ToString([Globalization.CultureInfo]::InvariantCulture)
    $oldBytes=[Text.Encoding]::UTF8.GetBytes("war/match/control/v1/$oldStamp`n$body")
    $oldHeaders=@{'X-War-Control-Time'=$oldStamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$oldBytes))}
    $staleStatus=0
    try { $null=Invoke-WebRequest $controlUrl -Method Post -Body $body -ContentType 'application/json' -Headers $oldHeaders -UseBasicParsing }
    catch { $staleStatus=[int]$_.Exception.Response.StatusCode }
    if($staleStatus -ne 401) { throw "Stale signed match returned $staleStatus" }
    $reconnectUrl="http://127.0.0.1:$($UdpPort+1)/internal/matches/reconnect"
    $reconnectBody='{"matchId":"smoke-control-match","playerId":"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","requestId":"11111111111111111111111111111111"}'
    $unsignedReconnect=0
    try { $null=Invoke-WebRequest $reconnectUrl -Method Post -Body $reconnectBody -ContentType 'application/json' -UseBasicParsing }
    catch { $unsignedReconnect=[int]$_.Exception.Response.StatusCode }
    if($unsignedReconnect -ne 401) { throw "Unsigned reconnect returned $unsignedReconnect" }
    $reconnectBytes=[Text.Encoding]::UTF8.GetBytes("war/match/control/v1/$stamp`n$reconnectBody")
    $reconnectHeaders=@{'X-War-Control-Time'=$stamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$reconnectBytes))}
    $prematureReconnect=0
    try { $null=Invoke-WebRequest $reconnectUrl -Method Post -Body $reconnectBody -ContentType 'application/json' -Headers $reconnectHeaders -UseBasicParsing }
    catch { $prematureReconnect=[int]$_.Exception.Response.StatusCode }
    if($prematureReconnect -ne 409) { throw "Reconnect before player admission returned $prematureReconnect" }
    $cancelUrl="http://127.0.0.1:$($UdpPort+1)/internal/matches/cancel"
    $cancelBody='{"matchId":"smoke-control-match"}'
    $unsignedCancel=0
    try { $null=Invoke-WebRequest $cancelUrl -Method Post -Body $cancelBody -ContentType 'application/json' -UseBasicParsing }
    catch { $unsignedCancel=[int]$_.Exception.Response.StatusCode }
    if($unsignedCancel -ne 401) { throw "Unsigned match cancellation returned $unsignedCancel" }
    $cancelBytes=[Text.Encoding]::UTF8.GetBytes("war/match/control/v1/$stamp`n$cancelBody")
    $cancelHeaders=@{'X-War-Control-Time'=$stamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$cancelBytes))}
    $cancelled=(Invoke-WebRequest $cancelUrl -Method Post -Body $cancelBody -ContentType 'application/json' -Headers $cancelHeaders -UseBasicParsing).Content | ConvertFrom-Json
    $cancelRetry=(Invoke-WebRequest $cancelUrl -Method Post -Body $cancelBody -ContentType 'application/json' -Headers $cancelHeaders -UseBasicParsing).Content | ConvertFrom-Json
    if($cancelled.code -ne 'cancelled-before-start' -or $cancelRetry.code -ne 'already-cancelled') { throw 'Prestart cancellation did not replay safely' }
    if(!(Test-Path -LiteralPath (Join-Path $env:Battle__ResultOutboxPath 'smoke-control-match.wfr'))) { throw 'Successful prestart cancellation returned before terminal evidence was durable' }
    Write-Host 'PASS: authenticated match publication, cancellation, grant replay, unsigned/stale/malformed/conflict rejection'
    dotnet (Join-Path $serverRoot 'tests/War.Protocol.Tests/bin/Debug/net10.0/War.Protocol.Tests.dll')
    if($LASTEXITCODE -ne 0) { throw 'Protocol checks failed' }
    dotnet (Join-Path $serverRoot 'tools/War.SmokeClient/bin/Debug/net10.0/War.SmokeClient.dll') "http://127.0.0.1:$HttpPort"
    if($LASTEXITCODE -ne 0) { throw 'Live smoke failed' }
    $crashManifest=$manifest.Clone()
    $crashManifest.MatchId='smoke-crash-match'
    $crashBody=ConvertTo-Json $crashManifest -Depth 8 -Compress
    $crashStamp=[DateTimeOffset]::UtcNow.ToUnixTimeSeconds().ToString([Globalization.CultureInfo]::InvariantCulture)
    $crashBytes=[Text.Encoding]::UTF8.GetBytes("war/match/control/v1/$crashStamp`n$crashBody")
    $crashHeaders=@{'X-War-Control-Time'=$crashStamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$crashBytes))}
    $crashRegistered=Invoke-WebRequest $controlUrl -Method Post -Body $crashBody -ContentType 'application/json' -Headers $crashHeaders -UseBasicParsing
    if([int]$crashRegistered.StatusCode -ne 201 -or !(Test-Path -LiteralPath (Join-Path $env:Battle__ResultOutboxPath 'active/smoke-crash-match.active'))) { throw 'Runtime allocation was returned before its crash marker was durable' }
    $terminalFiles=@(Get-ChildItem -LiteralPath $env:Battle__ResultOutboxPath -Filter 'smoke-allocated-*.wfr' -File)
    if($terminalFiles.Count -ne 1) { throw "Expected one durable terminal record; found $($terminalFiles.Count)" }
    $battleProcess=Restart-BattleProcess $battleProcess 'pending' $serverRoot $runRoot $UdpPort
    $processes+=$battleProcess
    if(!(Test-Path -LiteralPath (Join-Path $env:Battle__ResultOutboxPath 'smoke-crash-match.wfr')) -or
       (Test-Path -LiteralPath (Join-Path $env:Battle__ResultOutboxPath 'active/smoke-crash-match.active'))) { throw 'Forced host restart did not publish abandoned runtime allocation' }
    $reuseStamp=[DateTimeOffset]::UtcNow.ToUnixTimeSeconds().ToString([Globalization.CultureInfo]::InvariantCulture)
    $reuseBytes=[Text.Encoding]::UTF8.GetBytes("war/match/control/v1/$reuseStamp`n$crashBody")
    $reuseHeaders=@{'X-War-Control-Time'=$reuseStamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$reuseBytes))}
    $reuseStatus=0
    try { $null=Invoke-WebRequest $controlUrl -Method Post -Body $crashBody -ContentType 'application/json' -Headers $reuseHeaders -UseBasicParsing }
    catch { $reuseStatus=[int]$_.Exception.Response.StatusCode }
    if($reuseStatus -ne 409) { throw "Durable terminal match ID reuse returned $reuseStatus" }
    $resultStamp=[DateTimeOffset]::UtcNow.ToUnixTimeSeconds().ToString([Globalization.CultureInfo]::InvariantCulture)
    $pollBody='{}'
    $pollBytes=[Text.Encoding]::UTF8.GetBytes("war/result/poll/v1/$resultStamp`n$pollBody")
    $pollHeaders=@{'X-War-Control-Time'=$resultStamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$pollBytes))}
    $pollUrl="http://127.0.0.1:$($UdpPort+1)/internal/results/poll"
    $unsignedPoll=0
    try { $null=Invoke-WebRequest $pollUrl -Method Post -Body $pollBody -ContentType 'application/json' -UseBasicParsing }
    catch { $unsignedPoll=[int]$_.Exception.Response.StatusCode }
    if($unsignedPoll -ne 401) { throw "Unsigned result fetch returned $unsignedPoll" }
    $wrongDomainBytes=[Text.Encoding]::UTF8.GetBytes("war/match/control/v1/$resultStamp`n$pollBody")
    $wrongDomainHeaders=@{'X-War-Control-Time'=$resultStamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$wrongDomainBytes))}
    $wrongDomainStatus=0
    try { $null=Invoke-WebRequest $pollUrl -Method Post -Body $pollBody -ContentType 'application/json' -Headers $wrongDomainHeaders -UseBasicParsing }
    catch { $wrongDomainStatus=[int]$_.Exception.Response.StatusCode }
    if($wrongDomainStatus -ne 401) { throw "Cross-domain result signature returned $wrongDomainStatus" }
    $polled=Invoke-WebRequest $pollUrl -Method Post -Body $pollBody -ContentType 'application/json' -Headers $pollHeaders -UseBasicParsing
    $page=$polled.Content | ConvertFrom-Json
    $result=@($page.results | Where-Object { $_.matchId -like 'smoke-allocated-*' })
    if($result.Count -ne 1 -or $result[0].digest -notmatch '^[0-9a-f]{64}$' -or ![Convert]::FromBase64String($result[0].snapshot)) { throw 'Authenticated result fetch failed' }
    $ackUrl="http://127.0.0.1:$($UdpPort+1)/internal/results/ack"
    $wrongBody=ConvertTo-Json @{matchId=$result[0].matchId;digest=('0'*64)} -Compress
    $wrongBytes=[Text.Encoding]::UTF8.GetBytes("war/result/ack/v1/$resultStamp`n$wrongBody")
    $wrongHeaders=@{'X-War-Control-Time'=$resultStamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$wrongBytes))}
    $wrongStatus=0
    try { $null=Invoke-WebRequest $ackUrl -Method Post -Body $wrongBody -ContentType 'application/json' -Headers $wrongHeaders -UseBasicParsing }
    catch { $wrongStatus=[int]$_.Exception.Response.StatusCode }
    if($wrongStatus -ne 409) { throw "Wrong result digest returned $wrongStatus" }
    $ackBody=ConvertTo-Json @{matchId=$result[0].matchId;digest=$result[0].digest} -Compress
    $ackBytes=[Text.Encoding]::UTF8.GetBytes("war/result/ack/v1/$resultStamp`n$ackBody")
    $ackHeaders=@{'X-War-Control-Time'=$resultStamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$ackBytes))}
    $firstAck=Invoke-WebRequest $ackUrl -Method Post -Body $ackBody -ContentType 'application/json' -Headers $ackHeaders -UseBasicParsing
    $battleProcess=Restart-BattleProcess $battleProcess 'acknowledged' $serverRoot $runRoot $UdpPort
    $processes+=$battleProcess
    $replayStamp=[DateTimeOffset]::UtcNow.ToUnixTimeSeconds().ToString([Globalization.CultureInfo]::InvariantCulture)
    $replayAckBytes=[Text.Encoding]::UTF8.GetBytes("war/result/ack/v1/$replayStamp`n$ackBody")
    $replayAckHeaders=@{'X-War-Control-Time'=$replayStamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$replayAckBytes))}
    $secondAck=Invoke-WebRequest $ackUrl -Method Post -Body $ackBody -ContentType 'application/json' -Headers $replayAckHeaders -UseBasicParsing
    if(($firstAck.Content | ConvertFrom-Json).code -ne 'acknowledged' -or ($secondAck.Content | ConvertFrom-Json).code -ne 'already-acknowledged') { throw 'Result acknowledgement replay failed' }
    if(@(Get-ChildItem -LiteralPath $env:Battle__ResultOutboxPath -Filter 'smoke-allocated-*.ack' -File).Count -ne 1) { throw 'Result acknowledgement was not durable' }
    $replayPollBytes=[Text.Encoding]::UTF8.GetBytes("war/result/poll/v1/$replayStamp`n$pollBody")
    $replayPollHeaders=@{'X-War-Control-Time'=$replayStamp;'X-War-Control-Mac'=[Convert]::ToHexString([Security.Cryptography.HMACSHA256]::HashData($controlKeyBytes,$replayPollBytes))}
    $afterAck=(Invoke-WebRequest $pollUrl -Method Post -Body $pollBody -ContentType 'application/json' -Headers $replayPollHeaders -UseBasicParsing).Content | ConvertFrom-Json
    if(@($afterAck.results | Where-Object { $_.matchId -eq $result[0].matchId }).Count -ne 0) { throw 'Acknowledged result remained pending' }
    Write-Host 'PASS: pending evidence and acknowledged tombstone survive BattleServer restarts; digest-checked ack is idempotent'
    Write-Host "Smoke passed. Local test data/logs: $runRoot"
}
finally {
    foreach($process in $processes) { if(!$process.HasExited) { Stop-Process -Id $process.Id -ErrorAction SilentlyContinue } }
    foreach($name in $variables) { [Environment]::SetEnvironmentVariable($name,$prior[$name],'Process') }
}
