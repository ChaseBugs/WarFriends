using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

/// <summary>Evaluates the extracted recovered expression using Unity math, without claiming native agent motion.</summary>
public static class UnityNavigationRecoveryExport
{
    public static void Run()
    {
        string project = Path.GetFullPath(Path.Combine(Application.dataPath, "..")).Replace('\\', '/');
        if (project.IndexOf("/Server/.local/", StringComparison.OrdinalIgnoreCase) < 0)
        {
            throw new InvalidOperationException("Recovery export requires a disposable project.");
        }
        string inputPath = Environment.GetEnvironmentVariable("WAR_NAVIGATION_RECOVERY_INPUT");
        string outputPath = Environment.GetEnvironmentVariable("WAR_NAVIGATION_RECOVERY_OUTPUT");
        Input input = UnityEngine.JsonUtility.FromJson<Input>(File.ReadAllText(inputPath));
        if (input == null || input.Cases == null || input.Cases.Length < 1 || input.Cases.Length > 128)
        {
            throw new InvalidOperationException("Recovery input is absent or unbounded.");
        }
        var results = new Result[input.Cases.Length];
        for (int index = 0; index < results.Length; index++)
        {
            Case probe = input.Cases[index];
            var agent = new SourceNavigationRecoveryExpression.AgentInput
            {
                pathStatus = (NavMeshPathStatus)probe.Status, pathEndPosition = probe.PathEnd,
                destination = probe.Destination, velocity = probe.Velocity, pathPending = probe.Pending,
            };
            results[index] = new Result(probe,
                SourceNavigationRecoveryExpression.Evaluate(probe.Stopped, agent));
        }
        File.WriteAllText(outputPath, UnityEngine.JsonUtility.ToJson(new Output(results), true));
        Debug.Log("NAVIGATION_RECOVERY_REFERENCE_DONE cases=" + results.Length);
        EditorApplication.Exit(0);
    }

    private static int[] Bits(Vector3 value)
    {
        return new[] { Bits(value.x), Bits(value.y), Bits(value.z) };
    }

    private static int Bits(float value)
    {
        return BitConverter.ToInt32(BitConverter.GetBytes(value), 0);
    }

    [Serializable]
    private sealed class Input
    {
        [SerializeField] private Case[] _cases = new Case[0];
        internal Case[] Cases { get { return _cases; } }
    }

    [Serializable]
    private sealed class Case
    {
        [SerializeField] private string _id = "";
        [SerializeField] private bool _stopped = false;
        [SerializeField] private int _status = 0;
        [SerializeField] private bool _pending = false;
        [SerializeField] private Vector3 _pathEnd = Vector3.zero;
        [SerializeField] private Vector3 _destination = Vector3.zero;
        [SerializeField] private Vector3 _velocity = Vector3.zero;
        internal string Id { get { return _id; } }
        internal bool Stopped { get { return _stopped; } }
        internal int Status { get { return _status; } }
        internal bool Pending { get { return _pending; } }
        internal Vector3 PathEnd { get { return _pathEnd; } }
        internal Vector3 Destination { get { return _destination; } }
        internal Vector3 Velocity { get { return _velocity; } }
    }

    [Serializable]
    private sealed class Result
    {
        [SerializeField] private string _id;
        [SerializeField] private bool _stopped;
        [SerializeField] private int _status;
        [SerializeField] private bool _pending;
        [SerializeField] private int[] _pathEndBits;
        [SerializeField] private int[] _destinationBits;
        [SerializeField] private int[] _velocityBits;
        [SerializeField] private int _distanceBits;
        [SerializeField] private int _velocitySquaredBits;
        [SerializeField] private bool _shouldRecover;

        internal Result(Case probe, bool shouldRecover)
        {
            _id = probe.Id;
            _stopped = probe.Stopped;
            _status = probe.Status;
            _pending = probe.Pending;
            _pathEndBits = Bits(probe.PathEnd);
            _destinationBits = Bits(probe.Destination);
            _velocityBits = Bits(probe.Velocity);
            _distanceBits = Bits(Vector3.Distance(probe.PathEnd, probe.Destination));
            _velocitySquaredBits = Bits(probe.Velocity.sqrMagnitude);
            _shouldRecover = shouldRecover;
        }
    }

    [Serializable]
    private sealed class Output
    {
        [SerializeField] private int _version = 1;
        [SerializeField] private string _unityVersion = Application.unityVersion;
        [SerializeField] private string _sourceSha256 = SourceNavigationRecoveryExpression.SourceSha256;
        [SerializeField] private string _expressionSha256 = SourceNavigationRecoveryExpression.ExpressionSha256;
        [SerializeField] private string[] _operations = SourceNavigationRecoveryExpression.Operations;
        [SerializeField] private Result[] _cases;

        internal Output(Result[] cases)
        {
            _cases = cases;
        }
    }
}
