using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class RequestBufferManager : InGameSerializedObjectGeneric<RequestBufferManager.RequestBufferData>
{
	public class RequestBufferData
	{
		public Dictionary<string, RequestBuffer> requestBuffers = new Dictionary<string, RequestBuffer>();
	}

	private static RequestBufferManager mInstance;

	private static int bufferCounter;

	private RequestBuffer mRequestBuffer;

	public static RequestBufferManager instance
	{
		get
		{
			mInstance = mInstance ?? ((RequestBufferManager)Object.FindObjectsOfType(typeof(RequestBufferManager))[0]);
			return mInstance;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	public bool RemoveRequestBuffer(string id)
	{
		Debug.Log("BufferManager: remove buffer, id = " + id);
		bool result = data.requestBuffers.Remove(id);
		Save();
		return result;
	}

	private RequestBuffer StartNewRequestBuffer()
	{
		string text = string.Empty + bufferCounter++ + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		RequestBuffer requestBuffer = new RequestBuffer();
		requestBuffer.Init(text, 3f);
		data.requestBuffers.Add(text, requestBuffer);
		Save();
		return requestBuffer;
	}

	public RequestBuffer GetRequestBuffer()
	{
		if (mRequestBuffer == null || mRequestBuffer.alreadySent)
		{
			mRequestBuffer = StartNewRequestBuffer();
		}
		return mRequestBuffer;
	}

	public void ForceSendClaimAssignment()
	{
		if (mRequestBuffer != null && !mRequestBuffer.alreadySent)
		{
			mRequestBuffer.Send();
		}
		else
		{
			Debug.Log("No Request ready or already sent");
		}
	}

	internal RequestBuffer StartNewManualRequestBuffer()
	{
		string text = string.Empty + bufferCounter++ + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		RequestBuffer requestBuffer = new RequestBuffer();
		requestBuffer.Init(text);
		Debug.Log("BufferManager: new manual buffer, id = " + text);
		data.requestBuffers.Add(text, requestBuffer);
		Save();
		return requestBuffer;
	}

	protected override void Awake()
	{
		base.Awake();
		bufferCounter = 0;
	}

	internal string GetJsonData()
	{
		Dictionary<string, RequestBuffer> dictionary = new Dictionary<string, RequestBuffer>();
		foreach (KeyValuePair<string, RequestBuffer> requestBuffer in data.requestBuffers)
		{
			if (!requestBuffer.Value.alreadySent)
			{
				dictionary[requestBuffer.Key] = requestBuffer.Value;
				requestBuffer.Value.alreadySent = true;
			}
		}
		return JsonConvert.SerializeObject(dictionary);
	}

	internal void Clear()
	{
		data.requestBuffers.Clear();
		Save();
	}
}
