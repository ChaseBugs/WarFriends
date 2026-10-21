using System.Reflection;
using System.Runtime.Loader;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using War.Battle.Tests.Startup;

namespace War.Battle.Tests.Match.Effects;

/// <summary>Calls the original Client's managed Mathf.Lerp without starting Unity or native physics.</summary>
internal sealed class FlameInterpolationReference : IDisposable
{
    private const string UnityDigest = "e428db4e8652f5d548024ccbbb994dc1636a3c4ad374bac48e18e2fd5db6c76b";
    private readonly AssemblyLoadContext _context;
    private readonly Func<float, float, float, float> _lerp;

    internal FlameInterpolationReference()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string path = Path.GetFullPath(Path.Combine(server,
            "../Clients/AuxiliaryFiles/GameAssemblies/UnityEngine.dll"));
        string digest = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(path)));
        if (digest != UnityDigest)
        {
            throw new InvalidDataException("The reviewed original UnityEngine math binary changed.");
        }
        VerifySourceCalls(server);
        _context = new AssemblyLoadContext("flame-original-math", isCollectible: true);
        Assembly assembly = _context.LoadFromAssemblyPath(path);
        MethodInfo method = assembly.GetType("UnityEngine.Mathf", throwOnError: true)!
            .GetMethod("Lerp", [typeof(float), typeof(float), typeof(float)])!;
        _lerp = method.CreateDelegate<Func<float, float, float, float>>();
    }

    internal float Lerp(float minimum, float maximum, float fraction)
    {
        return _lerp(minimum, maximum, fraction);
    }

    /// <summary>Releases the test-only original math assembly context.</summary>
    public void Dispose()
    {
        _context.Unload();
    }

    private static void VerifySourceCalls(string server)
    {
        string path = Path.Combine(server, "../Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/FlameAmmo.cs");
        string source = Regex.Replace(File.ReadAllText(path), @"\s+", "");
        string[] reviewed =
        [
            "floatt=Mathf.Pow(num,0.25f);",
            "floatnum2=Mathf.Lerp(mSetup.shotHalfAngleNear,mSetup.shotHalfAngle,t);",
            "floatnum3=1f-num/mSetup.radius;",
            "mSetup.damageAmount=Mathf.Lerp(mSetup.minDamage,mSetup.maxDamage,num3);"
        ];
        foreach (string expression in reviewed)
        {
            if (!source.Contains(expression, StringComparison.Ordinal))
            {
                throw new InvalidDataException("The reviewed Client flame interpolation expressions changed.");
            }
        }
    }
}
