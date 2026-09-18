using System;
using System.Text;
using UnityEngine;

namespace TuneSDK;

public class TuneListener : MonoBehaviour
{
	public void trackerDidSucceed(string data)
	{
		MonoBehaviour.print("TuneListener trackerDidSucceed: " + data);
	}

	public void trackerDidFail(string error)
	{
		MonoBehaviour.print("TuneListener trackerDidFail: " + error);
	}

	public void trackerDidEnqueueRequest(string refId)
	{
		MonoBehaviour.print("TuneListener trackerDidEnqueueRequest: " + refId);
	}

	public void trackerDidEnqueueUrl(string url)
	{
		MonoBehaviour.print("TuneListener trackerDidEnqueueUrl: " + url);
	}

	public void trackerDidReceiveDeeplink(string url)
	{
		MonoBehaviour.print("TuneListener trackerDidReceiveDeeplink: " + url);
	}

	public void trackerDidFailDeeplink(string error)
	{
		MonoBehaviour.print("TuneListener trackerDidFailDeeplink: " + error);
	}

	public void onPowerHooksChanged(string empty)
	{
		MonoBehaviour.print("TuneListener onPowerHooksChanged");
	}

	public void onFirstPlaylistDownloaded(string empty)
	{
		MonoBehaviour.print("TuneListener onFirstPlaylistDownloaded");
	}

	public static string DecodeFrom64(string encodedString)
	{
		string text = null;
		MonoBehaviour.print("TuneListener.DecodeFrom64(string)");
		return Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
	}
}
