using UnityEngine;

public class BuyHearthArenaMessage : DatabaseMessage
{
	private string mArenaId;

	public BuyHearthArenaMessage(string id)
		: base($"BuyHearth-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.BuyHearthMessage)
	{
		mArenaId = id;
	}

	public override void Show()
	{
		base.Show();
		Debug.Log("Show buy hearth dialog");
		if (WarArena.instance.warArenaConfig.id == mArenaId)
		{
			GuiElementSingle<BuyHearthDialog>.instance.ShowDialog();
		}
	}

	public override bool CanShow()
	{
		return base.CanShow() && Singleton<GuiManager>.instance.currentScreen != null && Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<ArenaScreen>.instance;
	}
}
