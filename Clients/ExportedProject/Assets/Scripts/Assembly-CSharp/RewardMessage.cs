using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class RewardMessage : DatabaseMessage
{
	private RewardDialogType mType;

	private JToken mRewardCard;

	private PlayerVisual mPowerBand;

	private long mAmount;

	private CardPack mPackId;

	private Card[] mCards;

	private List<LootboxContent> mLootboxes;

	private int mNumberOfPlayedGames;

	public RewardMessage(RewardDialogType type, JToken card)
		: base("RewardMessage", Type.RewardMessage)
	{
		mType = type;
		messageId += $"-{type}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		mRewardCard = card;
	}

	public RewardMessage(RewardDialogType type)
		: base("RewardMessage", Type.RewardMessage)
	{
		mType = type;
		messageId += $"-{type}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		mNumberOfPlayedGames = StatsManager.instance.totalGames;
	}

	public RewardMessage(RewardDialogType type, long amount)
		: base("RewardMessage", Type.RewardMessage)
	{
		mType = type;
		messageId += $"-{type}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		mAmount = amount;
	}

	public RewardMessage(RewardDialogType type, PlayerVisual powerBand, long time)
		: base("RewardMessage", Type.RewardMessage)
	{
		mType = type;
		messageId += $"-{type}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		mPowerBand = powerBand;
		mAmount = time;
	}

	public RewardMessage(RewardDialogType type, CardPack cardPack, Card[] cards)
		: base("RewardMessage", Type.RewardMessage)
	{
		mType = type;
		messageId += $"-{type}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		mPackId = cardPack;
		mCards = cards;
	}

	public RewardMessage(RewardDialogType type, List<LootboxContent> lootboxes)
		: base("RewardMessage", Type.RewardMessage)
	{
		mType = type;
		messageId += $"-{type}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		mLootboxes = lootboxes;
	}

	public override void Show()
	{
		base.Show();
		switch (mType)
		{
		case RewardDialogType.WarCard:
			GuiElementSingle<RewardDialog>.instance.ShowDialog(mType, mRewardCard);
			break;
		case RewardDialogType.PowerBand:
			GuiElementSingle<RewardDialog>.instance.ShowDialog(mType, mPowerBand, mAmount);
			break;
		case RewardDialogType.CardPack:
			GuiElementSingle<RewardDialog>.instance.ShowDialog(mType, mPackId, mCards);
			break;
		case RewardDialogType.Lootboxes:
			GuiElementSingle<LootBoxDialog>.instance.ShowDialogMoreBoxes(mLootboxes, showVideoButton: false);
			break;
		case RewardDialogType.Dogtag:
			if (mNumberOfPlayedGames < StatsManager.instance.totalGames)
			{
				Debug.Log("DOGTAG REWARD DIALOG - not showing because player already played one match and spent gained dogtag");
			}
			else
			{
				GuiElementSingle<RewardDialog>.instance.ShowDialog(mType);
			}
			break;
		case RewardDialogType.Gold:
		case RewardDialogType.Warbucks:
		case RewardDialogType.VIP:
		case RewardDialogType.Tickets:
		case RewardDialogType.Scraps:
			GuiElementSingle<RewardDialog>.instance.ShowDialog(mType, mAmount);
			break;
		case RewardDialogType.DailyGold:
			break;
		}
	}

	public override bool CanShow()
	{
		return base.CanShow() || (mType == RewardDialogType.Lootboxes && DialogManager.instance.numberOfShownDialogues == 1 && GuiElementSingle<InappScreen>.instance.gameObject.activeSelf);
	}
}
