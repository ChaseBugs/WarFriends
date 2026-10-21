using System.Text.RegularExpressions;
using War.Battle.Tests.Startup;

namespace War.Battle.Tests.Match.Effects;

/// <summary>Runs the recovered Fire/Update bodies after verified identifier-only substitutions.</summary>
internal sealed class FlameAmmoClockReference
{
    private readonly List<float> _hitTimes = [];
    private bool _isChecking;
    private int _pulseCount;
    private float _nextDeadline;
    private float _sourceSeconds;

    internal FlameAmmoClockReference(float sourceSeconds)
    {
        _sourceSeconds = sourceSeconds;
        Fire();
    }

    internal int PulseCount => _pulseCount;

    internal float NextDeadline => _nextDeadline;

    internal float? DestroyDelay { get; private set; }

    internal IReadOnlyList<float> HitTimes => _hitTimes.AsReadOnly();

    internal void Advance(float sourceSeconds)
    {
        _sourceSeconds = sourceSeconds;
        Update();
    }

    internal static void VerifyRecoveredBodies()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string recovered = File.ReadAllText(Path.Combine(server,
            "../Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/FlameAmmo.cs"));
        string reference = File.ReadAllText(Path.Combine(server,
            "tests/War.Battle.Tests/Match/Effects/FlameAmmoClockReference.cs"));
        VerifyBody(ReadBody(recovered, "public override void Fire("), ReadBody(reference, "private void Fire("));
        VerifyBody(ReadBody(recovered, "protected void Update("), ReadBody(reference, "private void Update("));
    }

    private static string ReadBody(string source, string signature)
    {
        System.Text.RegularExpressions.Match match =
            Regex.Match(source, @"^\s*" + Regex.Escape(signature), RegexOptions.Multiline);
        if (!match.Success)
        {
            throw new InvalidDataException("The reviewed FlameAmmo method signature was not found.");
        }
        int start = source.IndexOf('{', match.Index + match.Length);
        int depth = 0;
        for (int index = start; index < source.Length; index++)
        {
            if (source[index] == '{')
            {
                depth++;
            }
            if (source[index] == '}' && --depth == 0)
            {
                return source[start..(index + 1)];
            }
        }
        throw new InvalidDataException("The reviewed FlameAmmo method body was not found.");
    }

    private static void VerifyBody(string source, string reference)
    {
        source = source.Replace("mCheckHit", "_isChecking", StringComparison.Ordinal)
            .Replace("mHitCheckCount", "_pulseCount", StringComparison.Ordinal)
            .Replace("mNextHitCheck", "_nextDeadline", StringComparison.Ordinal)
            .Replace("TimeManager.realTimeWithoutPauses", "_sourceSeconds", StringComparison.Ordinal)
            .Replace("CheckHit()", "RecordHit()", StringComparison.Ordinal)
            .Replace("DestroyPooled(", "Finish(", StringComparison.Ordinal);
        if (Regex.Replace(source, @"\s+", "") != Regex.Replace(reference, @"\s+", ""))
        {
            throw new InvalidDataException("The compiled flame clock reference differs from recovered Client bodies.");
        }
    }

    private void Fire()
    {
        _isChecking = true;
        _pulseCount = 0;
        _nextDeadline = _sourceSeconds + 0.35f;
    }

    private void Update()
    {
        if (_isChecking && _sourceSeconds > _nextDeadline)
        {
            _nextDeadline += 0.35f;
            RecordHit();
            _pulseCount++;
            if (_pulseCount >= 6)
            {
                _isChecking = false;
                Finish(0.5f);
            }
        }
    }

    private void RecordHit()
    {
        _hitTimes.Add(_sourceSeconds);
    }

    private void Finish(float delay)
    {
        DestroyDelay = delay;
    }
}
