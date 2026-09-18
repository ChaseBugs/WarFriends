using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class WarArenaEndedRequest
{
	public static void Send()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ArenaId", WarArena.instance.warArenaConfig.id.ToString()));
		List<Tuple<string, string>> parameters = list;
		Debug.Log(WarArena.instance.warArenaConfig.id + " arena id");
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.WarArenaEnded, parameters);
	}

	public static void OnSuccess(Dictionary<string, object> response)
	{
		Debug.LogError("On War arena endeeeed!!");
		if (response.ContainsKey("Scraps"))
		{
			int num = StringParser.ParseInt(response["Scraps"]);
			Debug.Log("Arena Lost - Scraps received = " + num);
			Singleton<MessageManager>.instance.AddMessage(new ArenaLostMessage(num, arenaExpired: true));
			Singleton<EventTrackingManager>.instance.ArenaExpired(WarArena.instance.data.wins, WarArena.instance.data.lives, WarArena.instance.data.heartDialogShown);
			Debug.LogFormat("Arena Expired - you gain scraps. You have {0} lives.", WarArena.instance.data.lives);
		}
		if (response.ContainsKey("NewArena"))
		{
			WarArena.instance.LoadWarArenaConfig((JToken)response["NewArena"]);
			Debug.Log("SHOW WAR ARENA DIALOG!!");
			string id = WarArena.instance.warArenaConfig.id;
			bool isOpened = WarArena.instance.isOpened;
			Singleton<MessageManager>.instance.AddMessage(new ArenaOpenedMessage(id, isOpened));
		}
	}

	public static void OnError(DatabaseResult resultCode, Dictionary<string, object> response)
	{
		WarArena.instance.FailedDownloadWarArena();
		Debug.LogError("errooor war arena ended!!!");
		if (resultCode == DatabaseResult.WarArenaNotFound)
		{
			string arg = StringParser.ParseString(response["WrongId"], string.Empty);
			Debug.LogError($"WarArenaId with ID {arg} not found in DB!");
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WRONGARENAID"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
		}
	}
}
