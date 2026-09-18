using UnityEngine;

internal class VipCardMessage : DatabaseMessage
{
	private string vipCardId1;

	private string vipCardId2;

	public VipCardMessage(string id1, string id2, string dayString)
		: base($"VipCardMessage {dayString}", Type.VipCards)
	{
		vipCardId1 = id1;
		vipCardId2 = id2;
		Debug.Log("ABOUT TO SHOW VIP CARDS");
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<DailyVIPCardsScreen>.instance.ShowDialogWithCards(vipCardId1, vipCardId2);
	}

	public override bool CanShow()
	{
		return base.CanShow() && Singleton<GuiManager>.instance.currentScreen != null && Singleton<GuiManager>.instance.currentScreen != GuiScreenSingle<EndScreen>.instance;
	}
}
