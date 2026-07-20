param(
    [string]$MongoUri = $env:MONGO_URL,
    [string]$DatabaseName = $env:MONGO_DB_NAME,
    [string]$ArchivePath = ""
)

$ErrorActionPreference = "Stop"
if ([string]::IsNullOrWhiteSpace($MongoUri)) { $MongoUri = "mongodb://127.0.0.1:27017" }
if ([string]::IsNullOrWhiteSpace($DatabaseName)) { $DatabaseName = "warfriends" }
if ($DatabaseName -notmatch '^[A-Za-z0-9_-]{1,64}$') { throw "DatabaseName contains unsupported characters." }

$dump = Get-Command mongodump -ErrorAction SilentlyContinue
if (-not $dump) { throw "mongodump was not found. Install MongoDB Database Tools first." }

if ([string]::IsNullOrWhiteSpace($ArchivePath)) {
    $timestamp = (Get-Date).ToUniversalTime().ToString("yyyyMMddTHHmmssZ")
    $ArchivePath = Join-Path $PSScriptRoot "..\backups\$DatabaseName-$timestamp.archive.gz"
}
$fullArchivePath = [System.IO.Path]::GetFullPath($ArchivePath)
$archiveDirectory = Split-Path -Parent $fullArchivePath
[System.IO.Directory]::CreateDirectory($archiveDirectory) | Out-Null
if (Test-Path -LiteralPath $fullArchivePath) { throw "Backup archive already exists: $fullArchivePath" }

# --archive plus --gzip produces one portable file. The database is selected explicitly so a URI
# that has a default database cannot silently change backup scope.
& $dump.Source "--uri=$MongoUri" "--db=$DatabaseName" "--archive=$fullArchivePath" --gzip
if ($LASTEXITCODE -ne 0 -or -not (Test-Path -LiteralPath $fullArchivePath)) {
    throw "mongodump failed with exit code $LASTEXITCODE."
}

$archive = Get-Item -LiteralPath $fullArchivePath
$hash = (Get-FileHash -LiteralPath $fullArchivePath -Algorithm SHA256).Hash.ToLowerInvariant()
$manifestPath = "$fullArchivePath.manifest.json"
$manifest = [ordered]@{
    format = 1
    database = $DatabaseName
    createdAtUtc = (Get-Date).ToUniversalTime().ToString("o")
    archiveFile = $archive.Name
    archiveBytes = $archive.Length
    sha256 = $hash
}
$manifest | ConvertTo-Json | Set-Content -LiteralPath $manifestPath -Encoding UTF8

Write-Output "Backup archive: $fullArchivePath"
Write-Output "Manifest: $manifestPath"
Write-Output "SHA256: $hash"
