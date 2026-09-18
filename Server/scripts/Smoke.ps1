param([string]$MongoExecutable = 'mongod', [int]$HttpPort=18080, [int]$UdpPort=30080, [int]$MongoPort=27028)
$ErrorActionPreference='Stop'
$serverRoot=Split-Path $PSScriptRoot -Parent
$runRoot=Join-Path $serverRoot ('.local/smoke-'+[guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path (Join-Path $runRoot 'mongo') -Force | Out-Null
$processes=@()
$variables=@('ASPNETCORE_ENVIRONMENT','ASPNETCORE_URLS','Mongo__Uri','Mongo__Database','Battle__SigningKey','Battle__Port','Battle__ServerId','Battle__PublicHost','Battle__BindAddress')
$prior=@{}
foreach($name in $variables) { $prior[$name]=[Environment]::GetEnvironmentVariable($name,'Process') }
try {
    dotnet build (Join-Path $serverRoot 'WarFriendsServer.sln') --nologo -v minimal
    if($LASTEXITCODE -ne 0) { throw 'Build failed' }
    $keyBytes=New-Object byte[] 32
    $rng=[Security.Cryptography.RandomNumberGenerator]::Create()
    $rng.GetBytes($keyBytes)
    $rng.Dispose()
    $env:Battle__SigningKey=[Convert]::ToBase64String($keyBytes)
    $env:ASPNETCORE_ENVIRONMENT='Development'
    $env:ASPNETCORE_URLS="http://127.0.0.1:$HttpPort"
    $env:Mongo__Uri="mongodb://127.0.0.1:$MongoPort"
    $env:Mongo__Database='warfriends_smoke'
    $env:Battle__Port="$UdpPort"
    $env:Battle__ServerId='local-1'
    $env:Battle__PublicHost='127.0.0.1'
    $env:Battle__BindAddress='127.0.0.1'
    $mongoArgs=@('--dbpath',('"'+(Join-Path $runRoot 'mongo')+'"'),'--bind_ip','127.0.0.1','--port',"$MongoPort",'--logpath',('"'+(Join-Path $runRoot 'mongo.log')+'"'))
    $processes+=Start-Process $MongoExecutable -ArgumentList $mongoArgs -PassThru -WindowStyle Hidden
    foreach($project in @('War.Backend','War.BattleServer')) {
        $dll=Join-Path $serverRoot "src/$project/bin/Debug/net10.0/$project.dll"
        $processes+=Start-Process dotnet -ArgumentList ('"'+$dll+'"') -WorkingDirectory (Join-Path $serverRoot "src/$project") -RedirectStandardOutput (Join-Path $runRoot "$project.log") -RedirectStandardError (Join-Path $runRoot "$project.error.log") -PassThru -WindowStyle Hidden
    }
    $ready=$false
    for($i=0;$i -lt 40;$i++) {
        if(@($processes | Where-Object HasExited).Count -gt 0) { throw "A service stopped; inspect $runRoot" }
        try { $null=Invoke-WebRequest "http://127.0.0.1:$HttpPort/health/ready" -UseBasicParsing -TimeoutSec 1; $ready=$true; break } catch { Start-Sleep -Milliseconds 250 }
    }
    if(!$ready) { throw "Backend not ready; inspect $runRoot" }
    dotnet (Join-Path $serverRoot 'tests/War.Protocol.Tests/bin/Debug/net10.0/War.Protocol.Tests.dll')
    if($LASTEXITCODE -ne 0) { throw 'Protocol checks failed' }
    dotnet (Join-Path $serverRoot 'tools/War.SmokeClient/bin/Debug/net10.0/War.SmokeClient.dll') "http://127.0.0.1:$HttpPort"
    if($LASTEXITCODE -ne 0) { throw 'Live smoke failed' }
    Write-Host "Smoke passed. Local test data/logs: $runRoot"
}
finally {
    foreach($process in $processes) { if(!$process.HasExited) { Stop-Process -Id $process.Id -ErrorAction SilentlyContinue } }
    foreach($name in $variables) { [Environment]::SetEnvironmentVariable($name,$prior[$name],'Process') }
}
