param(
    [string]$MongoUri = $env:MONGO_URL,
    [string]$DatabaseName = $env:MONGO_DB_NAME,
    [string]$OffHostDirectory = $env:BACKUP_OFFHOST_DIRECTORY,
    [int]$RetentionDays = 0
)

$ErrorActionPreference = "Stop"
if ([string]::IsNullOrWhiteSpace($DatabaseName)) { $DatabaseName = "warfriends" }
if ($DatabaseName -notmatch '^[A-Za-z0-9_-]{1,64}$') { throw "DatabaseName contains unsupported characters." }
if ([string]::IsNullOrWhiteSpace($OffHostDirectory)) {
    throw "BACKUP_OFFHOST_DIRECTORY or -OffHostDirectory is required. Use a mounted remote volume or UNC share."
}
if ($RetentionDays -eq 0) {
    if ([string]::IsNullOrWhiteSpace($env:BACKUP_RETENTION_DAYS)) {
        $RetentionDays = 30
    }
    elseif (-not [int]::TryParse($env:BACKUP_RETENTION_DAYS, [ref]$RetentionDays)) {
        throw "BACKUP_RETENTION_DAYS must be an integer from 7 to 3650."
    }
}
if ($RetentionDays -lt 7 -or $RetentionDays -gt 3650) { throw "RetentionDays must be from 7 to 3650." }
if ([string]::IsNullOrWhiteSpace($env:BACKUP_ENCRYPTION_KEY)) {
    throw "BACKUP_ENCRYPTION_KEY is required and must be a Base64-encoded random 32-byte key."
}

$cryptoScript = Join-Path $PSScriptRoot "..\dist\scripts\backupCrypto.js"
if (-not (Test-Path -LiteralPath $cryptoScript -PathType Leaf)) {
    throw "Compiled backup crypto tool was not found. Run npm run build first."
}
$node = Get-Command node -ErrorAction SilentlyContinue
if (-not $node) { throw "node was not found." }

$fullOffHostDirectory = [System.IO.Path]::GetFullPath($OffHostDirectory)
[System.IO.Directory]::CreateDirectory($fullOffHostDirectory) | Out-Null
$temporaryRoot = Join-Path ([System.IO.Path]::GetTempPath()) ("warfriends-backup-" + [Guid]::NewGuid().ToString("N"))
[System.IO.Directory]::CreateDirectory($temporaryRoot) | Out-Null

try {
    $timestamp = (Get-Date).ToUniversalTime().ToString("yyyyMMddTHHmmssZ")
    $plainArchive = Join-Path $temporaryRoot "$DatabaseName-$timestamp.archive.gz"
    & (Join-Path $PSScriptRoot "Backup-Mongo.ps1") `
        -MongoUri $MongoUri `
        -DatabaseName $DatabaseName `
        -ArchivePath $plainArchive

    $encryptedArchive = Join-Path $fullOffHostDirectory "$DatabaseName-$timestamp.archive.gz.wfbk"
    $encryptedManifest = "$encryptedArchive.manifest.json"
    & $node.Source $cryptoScript encrypt `
        --archive $plainArchive `
        --manifest "$plainArchive.manifest.json" `
        --output $encryptedArchive `
        --output-manifest $encryptedManifest
    if ($LASTEXITCODE -ne 0) { throw "Backup encryption failed with exit code $LASTEXITCODE." }

    # Retention runs only after a new authenticated archive is durable. The Node helper verifies
    # each candidate's manifest, database, path confinement, size, and SHA-256 before deleting its
    # exact pair; unknown or damaged files are intentionally left for operator review.
    & $node.Source $cryptoScript prune `
        --directory $fullOffHostDirectory `
        --database $DatabaseName `
        --retention-days $RetentionDays
    if ($LASTEXITCODE -ne 0) { throw "Encrypted backup retention failed with exit code $LASTEXITCODE." }

    Write-Output "Encrypted off-host archive: $encryptedArchive"
    Write-Output "Encrypted manifest: $encryptedManifest"
}
finally {
    # This directory is a freshly generated, resolved child of the OS temporary directory. Plain
    # database material exists only here and is removed after success or failure.
    if (Test-Path -LiteralPath $temporaryRoot) {
        Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
    }
}
