using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class EnterArenaRequest
{
	public static Action<bool> Response;

	public static void Send(int goldCost = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (goldCost > 0)
		{
			list.Add(new Tuple<string, string>("UsedGold", goldCost.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.EnterArena, list);
	}

	public static void OnSuccess(Dictionary<string, object> response)
	{
		Debug.Log("On Enter Arena!!");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns++;
		if (response.ContainsKey("Tickets"))
		{
			num = StringParser.ParseLong(response["Tickets"], 0L);
			Debug.Log("Tickets Spent " + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (response.ContainsKey("Gold"))
		{
			num2 = StringParser.ParseLong(response["Gold"], 0L);
			Debug.Log("Gold Spent " + num2);
			Singleton<Wallet>.instance.GoldSpent(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(StringParser.ParseString(response["WarArenaData"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (Response != null)
		{
			Response(obj: true);
		}
	}

	public static void OnError(DatabaseResult resultCode, Dictionary<string, object> response)
	{
		if (Response != null)
		{
			Response(obj: false);
		}
		switch (resultCode)
		{
		case DatabaseResult.ArenaDoesntExist:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ARENADOESNTEXIST"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case DatabaseResult.NotEnoughTickets:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHTICKETSARENA"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case DatabaseResult.NotEnoughGoldForArena:
			Debug.LogError("NOT ENOUGH GOLD FOR ARENA");
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHGOLDARENA"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		}
	}
}
