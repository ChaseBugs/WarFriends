using System;
using System.Net;
using UnityEngine;

using Beebyte.Obfuscator;

/// <summary>Retains recovered telemetry call sites without starting a retired online SDK.</summary>
[Skip]
public class Crittercism : MonoBehaviour
{
    // Serialized field names and public signatures remain for recovered scenes and callers.
    // Retired telemetry is always opted out; gameplay must not depend on its counters.

    public string CrittercismiOSAppID = "YOUR IOS APP ID GOES HERE";

    public string CrittercismAndroidAppID = "YOUR ANDROID APP ID GOES HERE";

    private void Awake()
    {
        UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
    }

    public static void LogHandledException(Exception e)
    {
        if (e != null)
        {
            Debug.LogError(e);
            Debug.LogError(e.StackTrace);
        }
    }

    public static bool GetOptOut()
    {
        return true;
    }

    public static void SetOptOut(bool isOptedOut)
    {
    }

    public static void SetUsername(string username)
    {
    }

    public static void SetValue(string key, string value)
    {
    }

    public static void SetMetadata(string[] keys, string[] values)
    {
    }

    public static void LeaveBreadcrumb(string breadcrumb)
    {
    }

    public static void LogNetworkRequest(
        string method,
        string uriString,
        double latencyInSeconds,
        int bytesRead,
        int bytesSent,
        HttpStatusCode responseCode,
        WebExceptionStatus exceptionStatus)
    {
    }

    public static void LogNetworkRequest(
        string method,
        string uriString,
        long latencyInMilliseconds,
        int bytesRead,
        int bytesSent,
        HttpStatusCode responseCode,
        WebExceptionStatus exceptionStatus)
    {
    }

    public static bool DidCrashOnLastLoad()
    {
        return false;
    }

    public static void BeginUserflow(string name)
    {
    }

    public static void BeginUserflow(string name, int value)
    {
    }

    public static void CancelUserflow(string name)
    {
    }

    public static void EndUserflow(string name)
    {
    }

    public static void FailUserflow(string name)
    {
    }

    public static void SetUserflowValue(string name, int value)
    {
    }

    public static int GetUserflowValue(string name)
    {
        return 0;
    }

    public static void SetLogUnhandledExceptionAsCrash(bool value)
    {
    }

    public static bool GetLogUnhandledExceptionAsCrash()
    {
        return false;
    }
}
