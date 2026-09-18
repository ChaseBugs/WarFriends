using Google2u;
using UnityEngine;

internal class WelcomeBackSoldierMessage : DatabaseMessage
{
	private Tuple<WelcomeBackSoldierDialog.WelcomeBackRewardType, int> box1;

	private Tuple<WelcomeBackSoldierDialog.WelcomeBackRewardType, int> box2;

	private string mPackId;

	public WelcomeBackSoldierMessage(string packId)
		: base($"WelcomeBackSoldierMessage {packId} {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.WelcomBackSoldierMessage)
	{
		mPackId = packId;
		Debug.Log("ABOUT TO SHOW WELCOME BACK SOLDIER REWARDS, packId = " + packId);
	}

	public override void Show()
	{
		base.Show();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == mPackId)
			{
				Debug.Log("Found Pack Id");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("Pack: Vip " + row.VIPSECONDS);
					SetBox(WelcomeBackSoldierDialog.WelcomeBackRewardType.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("Pack: Gold " + row.GOLD);
					SetBox(WelcomeBackSoldierDialog.WelcomeBackRewardType.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("Pack: Gold Cards " + row.GOLDCARDS);
					SetBox(WelcomeBackSoldierDialog.WelcomeBackRewardType.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("Pack: Warbucks " + row.WARBUCKS);
					SetBox(WelcomeBackSoldierDialog.WelcomeBackRewardType.Warbucks, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.ShowDialog(box1, box2);
	}

	private void SetBox(WelcomeBackSoldierDialog.WelcomeBackRewardType type, int parameter)
	{
		if (box1 == null)
		{
			box1 = new Tuple<WelcomeBackSoldierDialog.WelcomeBackRewardType, int>(type, parameter);
		}
		else
		{
			box2 = new Tuple<WelcomeBackSoldierDialog.WelcomeBackRewardType, int>(type, parameter);
		}
	}
}
