param(
    [Parameter(Mandatory = $true)]
    [string]$ArchivePath,
    [string]$MongoUri = $env:MONGO_URL,
    [string]$DatabaseName = $env:MONGO_DB_NAME,
    [switch]$ConfirmDatabaseReplacement
)

$ErrorActionPreference = "Stop"
if (-not $ConfirmDatabaseReplacement) {
    throw "Restore replaces the target database. Re-run with -ConfirmDatabaseReplacement after verifying the target."
}
if ([string]::IsNullOrWhiteSpace($MongoUri)) { $MongoUri = "mongodb://127.0.0.1:27017" }
if ([string]::IsNullOrWhiteSpace($DatabaseName)) { $DatabaseName = "warfriends" }
if ($DatabaseName -notmatch '^[A-Za-z0-9_-]{1,64}$') { throw "DatabaseName contains unsupported characters." }

$restore = Get-Command mongorestore -ErrorAction SilentlyContinue
if (-not $restore) { throw "mongorestore was not found. Install MongoDB Database Tools first." }
$fullArchivePath = [System.IO.Path]::GetFullPath($ArchivePath)
if (-not (Test-Path -LiteralPath $fullArchivePath -PathType Leaf)) { throw "Archive was not found: $fullArchivePath" }

$manifestPath = "$fullArchivePath.manifest.json"
if (-not (Test-Path -LiteralPath $manifestPath -PathType Leaf)) { throw "Backup manifest was not found: $manifestPath" }
$manifest = Get-Content -LiteralPath $manifestPath -Raw | ConvertFrom-Json
if ($manifest.format -ne 1) { throw "Unsupported backup manifest format." }
if ($manifest.database -ne $DatabaseName) {
    throw "Manifest database '$($manifest.database)' does not match target '$DatabaseName'."
}
$archive = Get-Item -LiteralPath $fullArchivePath
if ([long]$manifest.archiveBytes -ne $archive.Length) { throw "Archive size does not match its manifest." }
$actualHash = (Get-FileHash -LiteralPath $fullArchivePath -Algorithm SHA256).Hash.ToLowerInvariant()
if ($actualHash -ne [string]$manifest.sha256) { throw "Archive SHA256 does not match its manifest." }

# --drop is intentionally unreachable without the explicit switch above. It removes each target
# collection before restoring the verified archive, preventing a misleading mixed old/new database.
& $restore.Source "--uri=$MongoUri" "--nsInclude=$DatabaseName.*" "--archive=$fullArchivePath" --gzip --drop
if ($LASTEXITCODE -ne 0) { throw "mongorestore failed with exit code $LASTEXITCODE." }
Write-Output "Restored database '$DatabaseName' from: $fullArchivePath"
