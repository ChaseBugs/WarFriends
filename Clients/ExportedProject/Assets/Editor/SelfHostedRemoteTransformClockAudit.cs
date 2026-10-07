using System;
using UnityEditor;
using UnityEngine;

public static class SelfHostedRemoteTransformClockAudit
{
    public static void Run()
    {
        var owner = new GameObject("RemoteTransformClockAudit");
        try
        {
            var buffer = new SelfHostedRemoteTransformBuffer();
            buffer.Add(60, Vector3.zero, Quaternion.identity, 0f);
            buffer.Add(66, new Vector3(4f, 0f, 0f), Quaternion.Euler(0f, 90f, 0f), .1f);

            // The Worker runs at 30 Hz. Tick 60 is 2.0 seconds and tick 66 is
            // 2.2 seconds; at receive time +0.12 the delayed pose is 70% through.
            buffer.Render(owner.transform, .22f, .016f);
            Require(Mathf.Abs(owner.transform.position.x - 2.8f) < .01f,
                "30 Hz host-tick interpolation");
            Require(Quaternion.Angle(owner.transform.rotation,
                Quaternion.Euler(0f, 63f, 0f)) < .1f, "rotation interpolation");

            buffer.Render(owner.transform, .31f, .016f);
            Require(Mathf.Abs(owner.transform.position.x - 4.6f) < .01f,
                "bounded source extrapolation");
            buffer.Render(owner.transform, 1.4f, .016f);
            Require(Mathf.Abs(owner.transform.position.x - 4f) < .01f,
                "settle on latest host pose");

            buffer.Add(72, new Vector3(40f, 0f, 0f), Quaternion.identity, 1.5f);
            Require(buffer.Count == 1, "distant spawn correction resets the visual buffer");
            bool rejectedBackwardTick = false;
            try { buffer.Add(65, Vector3.zero, Quaternion.identity, 1.6f); }
            catch (InvalidOperationException) { rejectedBackwardTick = true; }
            Require(rejectedBackwardTick, "backward host tick is rejected");

            Debug.Log("UNITY_REMOTE_TRANSFORM_CLOCK_PASSED tickRate=30 delaySeconds=0.18");
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogError(exception);
            EditorApplication.Exit(1);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException("Remote transform clock: " + message);
    }
}
