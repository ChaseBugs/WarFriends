using System;
using System.Globalization;
using CodeStage.AntiCheat.ObscuredTypes;
using Newtonsoft.Json;

/// <summary>Measures the legacy Mono Single formatting round trip without loading a Unity project.</summary>
internal static class MonoFloatExportProbe
{
    private const int MaximumSamples = 100000;

    private static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        int samples = 0;
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            if (++samples > MaximumSamples)
            {
                throw new InvalidOperationException("Probe sample budget exceeded.");
            }
            uint bits = uint.Parse(line, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            float source = BitConverter.ToSingle(BitConverter.GetBytes(bits), 0);
            if (float.IsNaN(source) || float.IsInfinity(source))
            {
                throw new InvalidOperationException("Probe requires finite samples.");
            }
            object encrypted = (ObscuredFloat)source;
            string formatted = encrypted.ToString();
            float parsed = float.Parse(formatted, CultureInfo.InvariantCulture);
            uint resultBits = BitConverter.ToUInt32(BitConverter.GetBytes(parsed), 0);
            float corrected = (float)(ObscuredFloat)encrypted;
            float serialized = JsonConvert.DeserializeObject<float>(JsonConvert.SerializeObject(corrected));
            uint correctedBits = BitConverter.ToUInt32(BitConverter.GetBytes(corrected), 0);
            uint serializedBits = BitConverter.ToUInt32(BitConverter.GetBytes(serialized), 0);
            Console.WriteLine(bits.ToString("x8") + "|" + formatted + "|" + resultBits.ToString("x8")
                + "|" + correctedBits.ToString("x8") + "|" + serializedBits.ToString("x8"));
        }
    }
}
