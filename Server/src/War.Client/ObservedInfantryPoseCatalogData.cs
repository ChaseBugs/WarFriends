using System;
using System.IO;
using System.Security.Cryptography;
using War.Protocol;

namespace War.Client
{
    /// <summary>Owns the pinned portable source catalog without accepting arbitrary network transform arrays.</summary>
    public sealed class ObservedInfantryPoseCatalogData
    {
        private const string Digest = "06ad659e6b22a0c18a98867b2061e14520d6bf935fb6aa84a50bec32543d279d";
        private const string SourceRevision = "dd1e4ac94ca558155645f58e9bacdaa2691d9726f837063a531230b3e1b52854";
        private const string PrefabDigest = "64b4db85d1c9a0bd46a690a86102a22f66feeab8d4157a4c87824ac3d5dbeb54";
        private const int MaximumBytes = 64 * 1024;
        private const int SampleCount = 221;
        private const int ObservationCount = 13;
        private const int SkeletonCount = 58;
        private static readonly Lazy<ObservedInfantryPoseCatalogData> Embedded =
            new Lazy<ObservedInfantryPoseCatalogData>(ReadEmbedded);
        private readonly ObservedInfantryPoseCatalog _catalog;

        /// <summary>Gets the exact reviewed catalog revision.</summary>
        public string Revision { get { return SourceRevision; } }

        private ObservedInfantryPoseCatalogData(ObservedInfantryPoseCatalog catalog)
        {
            _catalog = catalog;
        }

        /// <summary>Returns the verified catalog embedded in the portable SDK assembly.</summary>
        public static ObservedInfantryPoseCatalogData BuiltIn { get { return Embedded.Value; } }

        /// <summary>Copies and verifies bounded binary content before exposing any sample.</summary>
        public static ObservedInfantryPoseCatalogData Load(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0 || bytes.Length > MaximumBytes)
            {
                throw new InvalidDataException("Portable pose content exceeds its reviewed byte domain.");
            }
            byte[] owned = (byte[])bytes.Clone();
            using (SHA256 hash = SHA256.Create())
            {
                string digest = BitConverter.ToString(hash.ComputeHash(owned)).Replace("-", "").ToLowerInvariant();
                if (digest != Digest)
                {
                    throw new InvalidDataException("Portable pose content differs from the reviewed source.");
                }
            }
            ObservedInfantryPoseCatalog catalog = ObservedInfantryPoseCatalog.Parser.ParseFrom(owned);
            Validate(catalog);
            return new ObservedInfantryPoseCatalogData(catalog);
        }

        /// <summary>Returns a deep sample copy only for an exact known revision and bounded sample identity.</summary>
        public ObservedInfantryPoseSample GetSample(BattleInfantryObservedPoseReference reference)
        {
            if (reference == null)
            {
                throw new InvalidDataException("A complete observed pose reference is required.");
            }
            string revision = reference.CatalogRevision;
            uint id = reference.SampleId;
            if (revision != SourceRevision || id < 1 || id > SampleCount)
            {
                throw new InvalidDataException("Observed pose reference is outside the installed source catalog.");
            }
            return _catalog.Samples[(int)id - 1].Clone();
        }

        /// <summary>Returns an isolated source topology snapshot for future hierarchy binding.</summary>
        public ObservedInfantryPoseCatalog Snapshot()
        {
            return _catalog.Clone();
        }

        private static ObservedInfantryPoseCatalogData ReadEmbedded()
        {
            using (Stream source = typeof(ObservedInfantryPoseCatalog).Assembly.GetManifestResourceStream(
                "WarFriends.ObservedObstaclePoseCatalog"))
            {
                if (source == null)
                {
                    throw new InvalidDataException("The portable pose resource is missing from the SDK.");
                }
                using (var output = new MemoryStream())
                {
                    byte[] buffer = new byte[4096];
                    int count;
                    while ((count = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (output.Length + count > MaximumBytes)
                        {
                            throw new InvalidDataException("The portable pose resource exceeds its byte bound.");
                        }
                        output.Write(buffer, 0, count);
                    }
                    return Load(output.ToArray());
                }
            }
        }

        private static void Validate(ObservedInfantryPoseCatalog catalog)
        {
            if (catalog.Revision != SourceRevision || catalog.PrefabSha256 != PrefabDigest ||
                catalog.Skeleton.Count != SkeletonCount || catalog.Samples.Count != SampleCount)
            {
                throw new InvalidDataException("Portable pose catalog identity or shape is invalid.");
            }
            for (int index = 0; index < catalog.Skeleton.Count; index++)
            {
                if (catalog.Skeleton[index].Index != index + 1)
                {
                    throw new InvalidDataException("Portable pose topology ordering is invalid.");
                }
            }
            for (int index = 0; index < catalog.Samples.Count; index++)
            {
                ObservedInfantryPoseSample sample = catalog.Samples[index];
                if (sample.Id != index + 1 || sample.PriorReturnTicks != index / ObservationCount ||
                    sample.ObservationTick != index % ObservationCount || sample.Clips.Count < 1 ||
                    sample.Clips.Count > 2 || sample.Overrides.Count > 21)
                {
                    throw new InvalidDataException("Portable pose sample ordering or shape is invalid.");
                }
            }
        }
    }
}
