using System.Numerics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using War.Battle.Tests.Startup;

namespace War.Battle.Tests.Match.Projectiles;

/// <summary>Models only the reviewed straight Missile.Update lifecycle, with synthetic collision decisions.</summary>
internal sealed class MissileExpiryReference
{
    private const string SourceDigest = "0f6cb525bbdced8701efbf170759e58e8e4cc0c74d91f9c383d4c65716a5c1ba";
    private const float TargetLimit = 50f;
    private const float ArmingDistance = 0.5f;
    private const float ExpiryProgress = 3f;
    internal const int TickRate = 30;
    private const float DeltaSeconds = 1f / TickRate;
    private readonly Vector3 _start;
    private readonly Vector3 _end;
    private readonly float _animationSeconds;
    private float _progress;
    private bool _isCollisionEnabled;

    internal MissileExpiryReference(Vector3 start, Vector3 target, float speed, float stopSeconds)
    {
        _start = start;
        Vector3 direction = target - start;
        _end = direction.Length() > TargetLimit ? start + Vector3.Normalize(direction) * TargetLimit : target;
        _animationSeconds = (_end - start).Length() / speed;
        _progress = 0f - stopSeconds / _animationSeconds;
        Position = start;
    }

    internal Vector3 Position { get; private set; }

    internal bool HasExpired { get; private set; }

    internal Frame Advance()
    {
        if (HasExpired)
        {
            throw new InvalidOperationException("Do not advance an expired source reference.");
        }
        Vector3 previous = Position;
        _progress += DeltaSeconds / _animationSeconds;
        Position = _start + (_end - _start) * Math.Clamp(_progress, 0f, float.MaxValue);

        // Update calls TryKill at the advanced position before its !mExploded collision guard.
        if (_progress > ExpiryProgress)
        {
            HasExpired = true;
            return new(Position, true, false);
        }
        bool shouldTrace = _isCollisionEnabled && (Position - previous).Length() > 0;
        if (!_isCollisionEnabled && Vector3.Distance(_start, Position) > ArmingDistance)
        {
            _isCollisionEnabled = true;
        }
        return new(Position, false, shouldTrace);
    }

    internal static void VerifySource()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string path = Path.Combine(server, "../Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Missile.cs");
        string source = File.ReadAllText(path);
        if (Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(path))) != SourceDigest)
        {
            throw new InvalidDataException("The reviewed Client missile source changed.");
        }
        VerifyOrdered(ExtractMethod(source, "public override void Fire(Vector3 from, Vector3 to)"),
            "if(Vector3.Distance(from,to)>50f)", "to=from+normalized*50f;", "AnimateShot(from,to);");
        VerifyOrdered(ExtractMethod(source, "public void AnimateShot(Vector3 from, Vector3 to)"),
            "mAnimtime=mDirection.magnitude/mSetup.speed;", "progress=0f-mSetup.stopTime/mAnimtime;");
        VerifyOrdered(ExtractMethod(source, "protected void Update()"),
            "progress+=((!ignoreTimeScale)?Time.deltaTime:TimeManager.deltaTimeWithoutPauses)/mAnimtime;",
            "floatnum=Mathf.Clamp(progress,0f,float.MaxValue);", "mTransform.position=vector+vector2;",
            "if(progress>((!mSetup.curvedTrajectory)?3f:1.5f))", "TryKill(base.transform.position);",
            "if(mCheckColision)", "if(!mExploded)", "CheckHit();",
            "elseif(Vector3.Distance(mFrom,mTransform.position)>0.5f)");
        VerifyOrdered(ExtractMethod(source, "private void TryKill(Vector3 impactPos)"),
            "if(!mExploded)", "Explosion.MissileExplode(i);", "mExploded=true;");
    }

    private static string ExtractMethod(string source, string signature)
    {
        int signatureIndex = source.IndexOf(signature, StringComparison.Ordinal);
        int start = signatureIndex < 0 ? -1 : source.IndexOf('{', signatureIndex);
        if (start < 0)
        {
            throw new InvalidDataException("A reviewed Client missile method is missing.");
        }
        int depth = 0;
        for (int index = start; index < source.Length; index++)
        {
            depth += source[index] == '{' ? 1 : source[index] == '}' ? -1 : 0;
            if (depth == 0)
            {
                return Regex.Replace(source[start..(index + 1)], @"\s+", "");
            }
        }
        throw new InvalidDataException("A reviewed Client missile method is incomplete.");
    }

    private static void VerifyOrdered(string body, params string[] expressions)
    {
        int previous = -1;
        foreach (string expression in expressions)
        {
            int next = body.IndexOf(expression, previous + 1, StringComparison.Ordinal);
            if (next < 0)
            {
                throw new InvalidDataException("The reviewed Client missile control flow changed.");
            }
            previous = next;
        }
    }

    internal readonly record struct Frame(Vector3 Position, bool IsExpired, bool ShouldTrace);
}
