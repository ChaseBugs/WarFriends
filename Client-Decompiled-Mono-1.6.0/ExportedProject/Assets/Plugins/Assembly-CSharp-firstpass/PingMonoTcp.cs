using System;
using System.Net;
using System.Net.Sockets;
using ExitGames.Client.Photon;
using UnityEngine;

public class PingMonoTcp : PhotonPing
{
	private Socket sock;

	public override bool StartPing(string ip)
	{
		Init();
		try
		{
			sock = (ip.Contains(".") ? new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) : new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp));
			sock.Blocking = false;
			sock.ReceiveTimeout = 5000;
			IPEndPoint end_point = new IPEndPoint(IPAddress.Parse(ip), 4530);
			sock.BeginConnect(end_point, CallBackMethod, null);
		}
		catch (Exception ex)
		{
			sock = null;
			Debug.LogError(ex.Message);
			Console.WriteLine(ex);
		}
		return false;
	}

	private void CallBackMethod(IAsyncResult asyncresult)
	{
		Dispose();
		Successful = true;
		GotResult = true;
	}

	public override bool Done()
	{
		if (GotResult || sock == null)
		{
			return true;
		}
		if (sock.Available <= 0)
		{
			return false;
		}
		int num = sock.Receive(PingBytes, SocketFlags.None);
		if (PingBytes[PingBytes.Length - 1] != PingId || num != PingLength)
		{
			DebugString += " ReplyMatch is false! ";
		}
		Successful = num == PingBytes.Length && PingBytes[PingBytes.Length - 1] == PingId;
		GotResult = true;
		return true;
	}

	public override void Dispose()
	{
		try
		{
			sock.Close();
		}
		catch
		{
		}
		sock = null;
	}
}
