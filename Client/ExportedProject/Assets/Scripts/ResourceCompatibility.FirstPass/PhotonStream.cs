using System.Collections.Generic;
using UnityEngine;

public class PhotonStream
{
	private bool write;

	private Queue<object> writeData;

	private object[] readData;

	internal byte currentItem;

	public bool isWriting => false;

	public bool isReading => false;

	public int Count => 0;

	public PhotonStream(bool write, object[] incomingData)
	{
	}

	public void SetReadStream(object[] incomingData, byte pos = 0)
	{
	}

	internal void ResetWriteStream()
	{
	}

	public object ReceiveNext()
	{
		return null;
	}

	public object PeekNext()
	{
		return null;
	}

	public void SendNext(object obj)
	{
	}

	public object[] ToArray()
	{
		return null;
	}

	public void Serialize(ref bool myBool)
	{
	}

	public void Serialize(ref int myInt)
	{
	}

	public void Serialize(ref string value)
	{
	}

	public void Serialize(ref char value)
	{
	}

	public void Serialize(ref short value)
	{
	}

	public void Serialize(ref float obj)
	{
	}

	public void Serialize(ref PhotonPlayer obj)
	{
	}

	public void Serialize(ref Vector3 obj)
	{
	}

	public void Serialize(ref Vector2 obj)
	{
	}

	public void Serialize(ref Quaternion obj)
	{
	}
}
