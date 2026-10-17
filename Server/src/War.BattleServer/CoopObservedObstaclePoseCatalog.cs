using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Loads source-observed poses without granting transport, collision or gameplay authority.</summary>
internal sealed partial class CoopObservedObstaclePoseCatalog
{
    private const string ArtifactDigest = "bd861aad1415154f11bc9c1c92164e97d70e425720545a12311884dad00bdaf8";
    private const string ContentRevision = "dd1e4ac94ca558155645f58e9bacdaa2691d9726f837063a531230b3e1b52854";
    private const int MaximumCompressedBytes = 32 * 1024;
    private const int MaximumJsonBytes = 256 * 1024;
    private const int PhaseCount = 17;
    private const int ObservationCount = 13;
    private const int SampleCount = PhaseCount * ObservationCount;
    private const int SkeletonCount = 58;
    private readonly Sample[] _samples;

    internal string Revision => ContentRevision;
    internal ReadOnlyCollection<TransformIdentity> Skeleton { get; }

    private CoopObservedObstaclePoseCatalog(List<TransformIdentity> skeleton, Sample[] samples)
    {
        Skeleton = skeleton.AsReadOnly();
        _samples = samples;
    }

    internal static CoopObservedObstaclePoseCatalog Load(string path, string enemyRevision)
    {
        using var file = File.OpenRead(path);
        byte[] bytes = ReadBounded(file, MaximumCompressedBytes);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ArtifactDigest)
        {
            throw new InvalidDataException("Observed obstacle catalog differs from reviewed source content.");
        }
        using JsonDocument document = JsonDocument.Parse(Decompress(bytes), new JsonDocumentOptions { MaxDepth = 12 });
        JsonElement root = document.RootElement;
        ValidateHeader(root, enemyRevision);
        List<TransformIdentity> skeleton = ReadSkeleton(root.GetProperty("skeleton"));
        Sample[] samples = ReadSamples(root.GetProperty("samples"));
        return new CoopObservedObstaclePoseCatalog(skeleton, samples);
    }

    internal Sample GetSample(int id)
    {
        if (id < 1 || id > SampleCount)
        {
            throw new InvalidDataException("Observed obstacle sample identity is outside the reviewed domain.");
        }
        return _samples[id - 1];
    }

    private static byte[] Decompress(byte[] bytes)
    {
        using var input = new MemoryStream(bytes, false);
        using var gzip = new GZipStream(input, CompressionMode.Decompress);
        return ReadBounded(gzip, MaximumJsonBytes);
    }

    private static byte[] ReadBounded(Stream input, int maximumBytes)
    {
        const int readBufferBytes = 4096;
        using var output = new MemoryStream();
        byte[] buffer = new byte[readBufferBytes];
        int count;
        while ((count = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            if (output.Length + count > maximumBytes)
            {
                throw new InvalidDataException("Observed obstacle catalog exceeds its stream size bound.");
            }
            output.Write(buffer, 0, count);
        }
        return output.ToArray();
    }

    private static string DigestWithoutRevision(JsonElement root)
    {
        using var bytes = new MemoryStream();
        using (var writer = new Utf8JsonWriter(bytes))
        {
            writer.WriteStartObject();
            foreach (JsonProperty property in root.EnumerateObject())
            {
                if (property.Name != "revision")
                {
                    property.WriteTo(writer);
                }
            }
            writer.WriteEndObject();
        }
        return Convert.ToHexStringLower(SHA256.HashData(bytes.ToArray()));
    }

    internal sealed record TransformIdentity(int Index, string Path, string Name);
    internal sealed record PoseOverride(int TransformIndex, Vector3 LocalPosition, Vector3 LocalScale);
    internal sealed record SampleIdentity(int Id, int PriorReturnTicks, int ObservationTick);

    internal sealed class Sample
    {
        private readonly BattleInfantryAnimationFrame _frame;
        internal SampleIdentity Identity { get; }
        internal ReadOnlyCollection<PoseOverride> Overrides { get; }

        internal Sample(SampleIdentity identity, BattleInfantryAnimationFrame frame, List<PoseOverride> overrides)
        {
            Identity = identity;
            _frame = frame;
            Overrides = overrides.AsReadOnly();
        }

        internal BattleInfantryAnimationFrame Animation(ulong sampleTick)
        {
            BattleInfantryAnimationFrame copy = _frame.Clone();
            copy.SampleTick = sampleTick;
            return copy;
        }
    }
}
