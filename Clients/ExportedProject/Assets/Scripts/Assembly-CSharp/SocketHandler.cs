using System;
using BestHTTP.SocketIO;
using PlatformSupport.Collections.ObjectModel;
using UnityEngine;

internal class SocketHandler
{
	private SocketManager mManager;

	public SocketHandler(string playerId)
	{
		Debug.Log("SH: Init");
		SocketOptions options = new SocketOptions
		{
			AutoConnect = false,
			AdditionalQueryParams = new ObservableDictionary<string, string>
			{
				{ "key", "value" },
				{ "id", playerId }
			}
		};
		mManager = new SocketManager(new Uri("http://localhost:3000/socket.io/"), options);
		mManager.Socket.On("chatmessage", OnNewMessage);
		mManager.Socket.On(SocketIOEventTypes.Error, delegate(Socket socket, Packet packet, object[] args)
		{
			Debug.LogError($"Error: {args[0].ToString()}");
		});
		mManager.Open();
	}

	private void OnNewMessage(Socket socket, Packet packet, params object[] args)
	{
		Debug.Log("SH: New message = " + args[0]);
	}

	public void Close()
	{
		mManager.Close();
	}
}
