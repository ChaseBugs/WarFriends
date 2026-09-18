using System;
using UnityEngine;

public class TimeLimitedOffer : DatabaseMessage
{
	public bool runnningOut;

	public TimeLimitedOffer(bool isRunningOut = false)
		: base("MoneyPackTimeLimitedOffer", Type.TimeLimitedOffer)
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
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.DialogType.MONEY_PACK, afterGame: true);
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_TimeLimitedOffer(messageType, messageTime);
		return delegate
		{
			if (!PlayerAnalytics.instance.data.IsPackBought(CardPack.Money))
			{
				GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.DialogType.MONEY_PACK, afterGame: true);
			}
			else
			{
				Debug.Log("Money Pack was already bought!");
			}
		};
	}
}
