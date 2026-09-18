using System.Collections.Generic;
using UnityEngine;

public class WarArenaShownRequest
{
	public static void Send()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ArenaId", WarArena.instance.warArenaConfig.id.ToString()));
		List<Tuple<string, string>> parameters = list;
		Debug.Log(WarArena.instance.warArenaConfig.id + " arena id");
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.WarArenaShown, parameters);
	}

	public static void OnSuccess(Dictionary<string, object> response)
	{
		Debug.LogError("On War arena Shown endeeeed!!");
		string id = WarArena.instance.warArenaConfig.id;
		bool isOpened = WarArena.instance.isOpened;
		Singleton<MessageManager>.instance.AddMessage(new ArenaOpenedMessage(id, isOpened));
	}
}
