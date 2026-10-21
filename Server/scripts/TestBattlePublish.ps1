param(
    [ValidateSet('Debug', 'Release')][string]$Configuration = 'Release',
    [switch]$KeepArtifacts
)

$ErrorActionPreference = 'Stop'
$serverRoot = Split-Path $PSScriptRoot -Parent
. (Join-Path $PSScriptRoot 'TestRun.ps1')
$runRoot = New-WarTestRun 'battle-publish'
$succeeded = $false

function Read-PublishSnapshot([string]$Directory, [string]$Name, [string[]]$Required, [string[]]$Forbidden) {
    $dependencyPath = Join-Path $Directory "$Name.deps.json"
    $dependencies = Get-Content -LiteralPath $dependencyPath -Raw | ConvertFrom-Json
    $projects = @($dependencies.libraries.PSObject.Properties.Name | ForEach-Object { $_.Split('/')[0] })
    foreach ($project in $Required) {
        if ($projects -cnotcontains $project) { throw "$Name publish is missing dependency $project." }
    }
    foreach ($project in $Forbidden) {
        if ($projects -ccontains $project -or (Test-Path -LiteralPath (Join-Path $Directory "$project.dll"))) {
            throw "$Name publish includes forbidden dependency $project."
        }
    }
    $runtimeConfigs = @(Get-ChildItem -LiteralPath $Directory -File -Filter '*.runtimeconfig.json')
    if ($runtimeConfigs.Count -ne 1 -or $runtimeConfigs[0].Name -cne "$Name.runtimeconfig.json") {
        throw "$Name publish contains another executable's runtime metadata."
    }
    if (!(Test-Path -LiteralPath (Join-Path $Directory "$Name.dll"))) {
        throw "$Name publish is missing its entry assembly."
    }
    return [pscustomobject]@{
        Name = $Name
        Projects = @($projects | Where-Object { $_.StartsWith('War.', [StringComparison]::Ordinal) })
        RuntimeConfig = $runtimeConfigs[0].Name
        # A managed graph check does not provision or verify the optional native physics distribution.
        HasNativeRopeAdapter = Test-Path -LiteralPath (Join-Path $Directory 'WarRopePhysics.dll')
    }
}

try {
    foreach ($name in @('War.Backend', 'War.BattleServer')) {
        $output = Join-Path $runRoot "data/$name"
        $project = Join-Path $serverRoot "src/$name/$name.csproj"
        $log = Join-Path $runRoot "$name.log"
        # Fresh owned destinations expose missing dependencies and stale host-file leakage.
        & dotnet publish $project -c $Configuration --self-contained false -o $output --nologo *> $log
        if ($LASTEXITCODE -ne 0) { throw "$name publish failed; inspect $log." }
    }

    $backendDirectory = Join-Path $runRoot 'data/War.Backend'
    $workerDirectory = Join-Path $runRoot 'data/War.BattleServer'
    $common = @('War.Battle.Domain', 'War.Infrastructure', 'War.Shared')
    $backend = Read-PublishSnapshot $backendDirectory 'War.Backend' `
        ($common + @('War.Backend', 'War.Persistence')) @('War.BattleServer', 'War.Battle.Simulation')
    $worker = Read-PublishSnapshot $workerDirectory 'War.BattleServer' `
        ($common + @('War.BattleServer', 'War.Battle.Simulation')) @('War.Backend', 'War.Persistence')
    $backendHash = (Get-FileHash -LiteralPath (Join-Path $backendDirectory 'War.Battle.Domain.dll')).Hash
    $workerHash = (Get-FileHash -LiteralPath (Join-Path $workerDirectory 'War.Battle.Domain.dll')).Hash
    if ($backendHash -cne $workerHash) { throw 'Hosts publish different Domain assemblies.' }

    $report = [pscustomobject]@{
        Configuration = $Configuration
        DomainSha256 = $backendHash.ToLowerInvariant()
        Backend = $backend
        Worker = $worker
    }
    $json = ($report | ConvertTo-Json -Depth 5) + [Environment]::NewLine
    [IO.File]::WriteAllText((Join-Path $runRoot 'results.json'), $json, [Text.UTF8Encoding]::new($false))
    $succeeded = $true
    Write-Host "PASS: fresh $Configuration host publishes have independent graphs and one identical Domain DLL."
    Write-Host "Reports: $runRoot"
}
finally {
    Complete-WarTestRun $runRoot $succeeded $KeepArtifacts.IsPresent
}
