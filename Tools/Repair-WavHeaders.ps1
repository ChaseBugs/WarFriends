param(
    [Parameter(Mandatory = $true)]
    [string] $AudioRoot,

    [Parameter(Mandatory = $true)]
    [string] $BackupRoot,

    [Parameter(Mandatory = $true)]
    [string] $ReportPath
)

$ErrorActionPreference = 'Stop'
$resolvedAudioRoot = (Resolve-Path -LiteralPath $AudioRoot).Path
$resolvedBackupRoot = [IO.Path]::GetFullPath($BackupRoot)
$resolvedReportPath = [IO.Path]::GetFullPath($ReportPath)
$audioRootUri = [Uri]($resolvedAudioRoot.TrimEnd([IO.Path]::DirectorySeparatorChar) + [IO.Path]::DirectorySeparatorChar)
New-Item -ItemType Directory -Force -Path $resolvedBackupRoot | Out-Null

$results = [Collections.Generic.List[object]]::new()
foreach ($file in Get-ChildItem -LiteralPath $resolvedAudioRoot -Filter '*.wav' -File -Recurse) {
    $relativePath = [Uri]::UnescapeDataString($audioRootUri.MakeRelativeUri([Uri]$file.FullName).ToString()).Replace('/', [IO.Path]::DirectorySeparatorChar)
    $backupPath = Join-Path $resolvedBackupRoot $relativePath
    $backupDirectory = Split-Path -Parent $backupPath
    New-Item -ItemType Directory -Force -Path $backupDirectory | Out-Null

    $stream = [IO.File]::Open($file.FullName, [IO.FileMode]::Open, [IO.FileAccess]::ReadWrite, [IO.FileShare]::Read)
    $reader = [IO.BinaryReader]::new($stream, [Text.Encoding]::ASCII, $true)
    $writer = [IO.BinaryWriter]::new($stream, [Text.Encoding]::ASCII, $true)
    try {
        if ($stream.Length -lt 44) {
            throw "WAV is too short: $($file.FullName)"
        }

        $stream.Position = 0
        $riff = [Text.Encoding]::ASCII.GetString($reader.ReadBytes(4))
        $oldRiffSize = $reader.ReadUInt32()
        $wave = [Text.Encoding]::ASCII.GetString($reader.ReadBytes(4))
        if ($riff -ne 'RIFF' -or $wave -ne 'WAVE') {
            throw "Unsupported WAV container: $($file.FullName)"
        }

        $dataSizeOffset = -1L
        $dataPayloadOffset = -1L
        $oldDataSize = 0L
        $chunkOffset = 12L
        while ($chunkOffset + 8 -le $stream.Length) {
            $stream.Position = $chunkOffset
            $chunkId = [Text.Encoding]::ASCII.GetString($reader.ReadBytes(4))
            $chunkSize = [long]$reader.ReadUInt32()
            $payloadOffset = $chunkOffset + 8
            if ($chunkId -eq 'data') {
                $dataSizeOffset = $chunkOffset + 4
                $dataPayloadOffset = $payloadOffset
                $oldDataSize = $chunkSize
                break
            }

            if ($chunkSize -eq 0) {
                break
            }

            $chunkOffset = $payloadOffset + $chunkSize + ($chunkSize % 2)
        }

        if ($dataSizeOffset -lt 0) {
            throw "WAV data chunk was not found: $($file.FullName)"
        }

        $newRiffSize = $stream.Length - 8
        $newDataSize = $stream.Length - $dataPayloadOffset
        if ($newRiffSize -gt [uint32]::MaxValue -or $newDataSize -gt [uint32]::MaxValue) {
            throw "WAV exceeds RIFF 32-bit size limits: $($file.FullName)"
        }

        $changed = $oldRiffSize -ne $newRiffSize -or $oldDataSize -ne $newDataSize
        if ($changed) {
            Copy-Item -LiteralPath $file.FullName -Destination $backupPath -Force
            $stream.Position = 4
            $writer.Write([uint32]$newRiffSize)
            $stream.Position = $dataSizeOffset
            $writer.Write([uint32]$newDataSize)
            $writer.Flush()
        }

        $results.Add([pscustomobject]@{
            Path = $relativePath
            Changed = $changed
            OldRiffSize = $oldRiffSize
            NewRiffSize = $newRiffSize
            OldDataSize = $oldDataSize
            NewDataSize = $newDataSize
        })
    }
    finally {
        $writer.Dispose()
        $reader.Dispose()
        $stream.Dispose()
    }
}

$reportDirectory = Split-Path -Parent $resolvedReportPath
New-Item -ItemType Directory -Force -Path $reportDirectory | Out-Null
$results | Export-Csv -LiteralPath $resolvedReportPath -NoTypeInformation -Encoding UTF8
Write-Output "WAV files=$($results.Count) repaired=$(($results | Where-Object Changed).Count) report=$resolvedReportPath"
