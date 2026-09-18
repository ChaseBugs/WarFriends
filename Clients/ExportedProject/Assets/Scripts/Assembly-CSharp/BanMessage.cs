using Newtonsoft.Json.Linq;
using UnityEngine;

public class BanMessage : DatabaseMessage
{
	private BanType banType;

	private int timestamp;

	private bool forever;

	public BanMessage(JToken dict)
		: base(dict)
	{
		Debug.Log("Ban Chat Message received");
		this.banType = dict["BanType"]["N"].ToObject<BanType>();
		BanType banType = this.banType;
		if (banType == BanType.ChatBan)
		{
			if (dict["Timestamp"] != null)
			{
				timestamp = dict["Timestamp"]["N"].ToObject<int>();
				forever = false;
				ChatBanManager.instance.BanPlayerFromChat(timestamp);
			}
			else
			{
				timestamp = 0;
				forever = true;
				ChatBanManager.instance.BanPlayerFromChat();
			}
		}
	}

	public override void Show()
	{
		base.Show();
		Ignore();
		switch (banType)
		{
		case BanType.ChatBan:
			GuiElementSingle<SystemMaintenanceDialog>.instance.ShowBannedFromChat(forever, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
			break;
		case BanType.GameBan:
			GameLoginManager.Relog();
			break;
		}
	}
}
