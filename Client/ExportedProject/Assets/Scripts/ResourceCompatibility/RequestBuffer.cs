using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting;

[Preserve]
public class RequestBuffer
{
	public bool alreadySent;

	public string id;

	public int requestCount;

	public Dictionary<int, Request> requests;

	private float mTimeOut;

	private RadicalRoutine mWaitingRoutine;

	public void AddRequest(DatabaseAction databaseAction, string objData, int warbucks = 0, int gold = 0, string parameter = "", bool additionalParameter = false, int loyalty = 0)
	{
	}

	public void Send()
	{
	}

	internal void Init(string bufferId, float timeOut)
	{
	}

	internal void Init(string bufferId)
	{
	}

	private IEnumerator WaitAndSend(float waitTime)
	{
		return null;
	}
}
