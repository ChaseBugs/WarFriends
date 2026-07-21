param(
    [Parameter(Mandatory = $true)]
    [string]$EncryptedArchivePath,
    [string]$MongoUri = $env:MONGO_URL,
    [string]$DatabaseName = $env:MONGO_DB_NAME,
    [switch]$ConfirmDatabaseReplacement
)

$ErrorActionPreference = "Stop"
if (-not $ConfirmDatabaseReplacement) {
    throw "Restore replaces the target database. Re-run with -ConfirmDatabaseReplacement after verifying the target."
}
if ([string]::IsNullOrWhiteSpace($DatabaseName)) { $DatabaseName = "warfriends" }
if ($DatabaseName -notmatch '^[A-Za-z0-9_-]{1,64}$') { throw "DatabaseName contains unsupported characters." }
if ([string]::IsNullOrWhiteSpace($env:BACKUP_ENCRYPTION_KEY)) {
    throw "BACKUP_ENCRYPTION_KEY for this archive is required."
}

$cryptoScript = Join-Path $PSScriptRoot "..\dist\scripts\backupCrypto.js"
if (-not (Test-Path -LiteralPath $cryptoScript -PathType Leaf)) {
    throw "Compiled backup crypto tool was not found. Run npm run build first."
}
$node = Get-Command node -ErrorAction SilentlyContinue
if (-not $node) { throw "node was not found." }
$fullEncryptedPath = [System.IO.Path]::GetFullPath($EncryptedArchivePath)
if (-not (Test-Path -LiteralPath $fullEncryptedPath -PathType Leaf)) {
    throw "Encrypted archive was not found: $fullEncryptedPath"
}
$encryptedManifest = "$fullEncryptedPath.manifest.json"
if (-not (Test-Path -LiteralPath $encryptedManifest -PathType Leaf)) {
    throw "Encrypted backup manifest was not found: $encryptedManifest"
}

$temporaryRoot = Join-Path ([System.IO.Path]::GetTempPath()) ("warfriends-restore-" + [Guid]::NewGuid().ToString("N"))
[System.IO.Directory]::CreateDirectory($temporaryRoot) | Out-Null
try {
    $plainArchive = Join-Path $temporaryRoot "$DatabaseName-restored.archive.gz"
    & $node.Source $cryptoScript decrypt `
        --archive $fullEncryptedPath `
        --manifest $encryptedManifest `
        --output $plainArchive `
        --output-manifest "$plainArchive.manifest.json" `
        --database $DatabaseName
    if ($LASTEXITCODE -ne 0) { throw "Backup decryption or authentication failed with exit code $LASTEXITCODE." }

    # Restore-Mongo performs a second independent size/SHA/database verification before its guarded
    # mongorestore --drop call. Authentication therefore cannot be bypassed by a partial temp file.
    & (Join-Path $PSScriptRoot "Restore-Mongo.ps1") `
        -ArchivePath $plainArchive `
        -MongoUri $MongoUri `
        -DatabaseName $DatabaseName `
        -ConfirmDatabaseReplacement
}
finally {
    if (Test-Path -LiteralPath $temporaryRoot) {
        Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
    }
}
