using System;
using UnityEngine;

public class StarterPackTimeLimitedOffer : DatabaseMessage
{
	public bool runnningOut;

	public StarterPackTimeLimitedOffer(bool isRunningOut = false)
		: base("StarterPackTimeLimitedOffer", Type.StarterPackTimeLimitedOffer)
	{
		runnningOut = isRunningOut;
		if (runnningOut)
		{
			messageId += "RunningOut";
		}
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		if (!runnningOut)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.DialogType.STARTER_PACK, afterGame: true);
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_StarterPackTimeLimitedOffer(messageType, messageTime);
		return delegate
		{
			if (!PlayerAnalytics.instance.data.IsPackBought(CardPack.Starter))
			{
				GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.DialogType.STARTER_PACK, afterGame: true);
			}
			else
			{
				Debug.Log("Starter Pack was already bought!");
			}
		};
	}
}
