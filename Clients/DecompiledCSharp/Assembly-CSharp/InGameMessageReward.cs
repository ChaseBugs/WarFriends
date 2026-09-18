using System.Collections.Generic;
using UnityEngine;

public class InGameMessageReward : Core_BaseScript
{
	[Header("Basic")]
	public UISprite warbucksIcon;

	public UISprite goldIcon;

	public UISprite vipIcon;

	public UISprite ticketsIcon;

	public UILabel textLabel;

	[Header("-Power Band")]
	public GameObject powerBandPart;

	public UISprite powerBandSprite;

	public UISprite powerBandMiniIcon;

	public UILabel powerBandValue;

	[Header("-Customization")]
	public UISprite visualSprite;

	[Header("-Warcards")]
	public UIGrid warcardsGrid;

	public GameObject[] warcards;

	public UISprite[] warcardsBackgrounds;

	public UISprite[] warcardsQuestion;

	[Header("-Cardpack")]
	public GameObject cardpack;

	public UISprite cardpackBackground;

	public UISprite cardpackFrontWarcard;

	public UISprite cardpackBackWarcard;

	private List<Card> mParticularCards = new List<Card>();

	public void Initialize(DailyRewardMonthScreen.DailyRewardDataForDay reward)
	{
		warbucksIcon.gameObject.SetActive(reward.rewardType == DailyReward.Warbucks);
		goldIcon.gameObject.SetActive(reward.rewardType == DailyReward.Gold);
		vipIcon.gameObject.SetActive(reward.rewardType == DailyReward.Vip);
		ticketsIcon.gameObject.SetActive(reward.rewardType == DailyReward.ArenaTickets);
		powerBandPart.SetActive(reward.rewardType == DailyReward.PowerBand);
		visualSprite.gameObject.SetActive(reward.rewardType == DailyReward.Customization);
		warcardsGrid.gameObject.SetActive(reward.rewardType == DailyReward.BronzeCard || reward.rewardType == DailyReward.BronzeCards || reward.rewardType == DailyReward.SilverCard || reward.rewardType == DailyReward.SilverCards || reward.rewardType == DailyReward.GoldCard || reward.rewardType == DailyReward.GoldCards || reward.rewardType == DailyReward.ParticularCards);
		cardpack.gameObject.SetActive(reward.rewardType == DailyReward.BronzeCardpack || reward.rewardType == DailyReward.SilverCardpack || reward.rewardType == DailyReward.GoldCardpack);
		textLabel.gameObject.SetActive(warbucksIcon.gameObject.activeSelf || goldIcon.gameObject.activeSelf || vipIcon.gameObject.activeSelf || ticketsIcon.gameObject.activeSelf || powerBandPart.activeSelf);
		switch (reward.rewardType)
		{
		case DailyReward.Warbucks:
		case DailyReward.Gold:
			textLabel.text = MiscTools.FormatBigNumberLong(reward.count);
			MiscTools.SetUILabelRescale(textLabel, 47f, 25f, 250);
			break;
		case DailyReward.ArenaTickets:
			textLabel.text = $"x{MiscTools.FormatBigNumberLong(reward.count)}";
			MiscTools.SetUILabelRescale(textLabel, 47f, 25f, 250);
			break;
		case DailyReward.Vip:
			textLabel.text = MiscTools.PrintableTimeVipConvertSmall((int)reward.count * 3600);
			MiscTools.SetUILabelRescale(textLabel, 47f, 25f, 250);
			break;
		case DailyReward.PowerBand:
		{
			textLabel.text = MiscTools.PrintableTimeVipConvertSmall((int)reward.count * 3600);
			MiscTools.SetUILabelRescale(textLabel, 47f, 25f, 250);
			PlayerVisual powerBand = CamosManager.instance.GetPowerBand(reward.parameters);
			powerBandSprite.spriteName = powerBand.icon;
			powerBandSprite.MakePixelPerfect();
			float multiplier = Mathf.Min(100f / powerBandSprite.transform.localScale.x, 100f / powerBandSprite.transform.localScale.y);
			powerBandSprite.transform.localScale = powerBandSprite.transform.localScale.MultiplyXY(multiplier);
			powerBandValue.text = powerBand.decalValueString;
			float num7 = powerBandValue.transform.localPosition.x + powerBandValue.relativeSize.x * powerBandValue.transform.localScale.x + 8f;
			powerBandMiniIcon.spriteName = powerBand.decalMiniIcon;
			powerBandMiniIcon.MakePixelPerfect();
			powerBandMiniIcon.color = powerBand.decalMiniIconColor;
			powerBandMiniIcon.transform.localPosition = powerBandValue.transform.localPosition.ReplaceX(num7);
			float val = textLabel.transform.localPosition.x - 20f - (num7 + powerBandMiniIcon.transform.localScale.x);
			powerBandPart.transform.localPosition = powerBandPart.transform.localPosition.ReplaceX(val);
			break;
		}
		case DailyReward.Customization:
		{
			PlayerVisual visual = CamosManager.instance.GetVisual(reward.parameters);
			visualSprite.spriteName = visual.icon;
			visualSprite.MakePixelPerfect();
			float multiplier2 = Mathf.Min(400f / visualSprite.transform.localScale.x, 100f / visualSprite.transform.localScale.y);
			visualSprite.transform.localScale = visualSprite.transform.localScale.MultiplyXY(multiplier2);
			break;
		}
		case DailyReward.BronzeCards:
		case DailyReward.SilverCards:
		case DailyReward.GoldCards:
		case DailyReward.BronzeCard:
		case DailyReward.SilverCard:
		case DailyReward.GoldCard:
		{
			int num4 = (int)((reward.rewardType == DailyReward.BronzeCard || reward.rewardType == DailyReward.SilverCard || reward.rewardType == DailyReward.GoldCard) ? 1 : reward.count);
			CardManager.CardType cardType = ((reward.rewardType != DailyReward.GoldCard && reward.rewardType != DailyReward.GoldCards) ? ((reward.rewardType != DailyReward.SilverCard && reward.rewardType != DailyReward.SilverCards) ? CardManager.CardType.Bronze : CardManager.CardType.Silver) : CardManager.CardType.Gold);
			for (int j = 0; j < warcards.Length; j++)
			{
				warcards[j].SetActive(num4 > j);
				if (num4 > j)
				{
					warcardsBackgrounds[j].spriteName = Card.CardBackground(cardType);
					warcardsQuestion[j].color = cardType switch
					{
						CardManager.CardType.Gold => Colours.questionGold, 
						CardManager.CardType.Silver => Colours.questionSilver, 
						_ => Colours.questionBronze, 
					};
				}
			}
			float num5 = Mathf.Clamp(340f / Mathf.Max(1f, num4 - 1), 1f, 40f);
			warcardsGrid.cellWidth = num5;
			warcardsGrid.repositionNow = true;
			float num6 = ((num4 % 2 != 1) ? (((float)(num4 / 2) - 0.5f) * num5) : (Mathf.Floor(num4 / 2) * num5));
			warcardsGrid.transform.localPosition = warcardsGrid.transform.localPosition.ReplaceX(0f - num6);
			break;
		}
		case DailyReward.ParticularCards:
		{
			string text = reward.parameters;
			for (int num = text.IndexOf(';'); num > -1; num = text.IndexOf(';'))
			{
				string cardId = text.Substring(0, num);
				mParticularCards.Add(CardManager.instance.GetCardInstance(cardId));
				text = text.Substring(num);
			}
			mParticularCards.Add(CardManager.instance.GetCardInstance(text));
			for (int i = 0; i < warcards.Length; i++)
			{
				warcards[i].SetActive(mParticularCards.Count > i);
				if (mParticularCards.Count > i)
				{
					Card card = mParticularCards[i];
					warcardsBackgrounds[i].spriteName = Card.CardBackground(card.rarity);
					warcardsQuestion[i].color = ((card.rarity == CardManager.CardType.Gold) ? Colours.questionGold : ((card.rarity != CardManager.CardType.Silver) ? Colours.questionBronze : Colours.questionSilver));
				}
			}
			float num2 = Mathf.Clamp(340f / Mathf.Max(1f, mParticularCards.Count - 1), 1f, 40f);
			warcardsGrid.cellWidth = num2;
			warcardsGrid.repositionNow = true;
			float num3 = ((mParticularCards.Count % 2 != 1) ? (((float)(mParticularCards.Count / 2) - 0.5f) * num2) : (Mathf.Floor(mParticularCards.Count / 2) * num2));
			warcardsGrid.transform.localPosition = warcardsGrid.transform.localPosition.ReplaceX(0f - num3);
			break;
		}
		case DailyReward.BronzeCardpack:
			cardpackBackground.spriteName = "menu-cards-bronzepack";
			cardpackFrontWarcard.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			cardpackBackWarcard.spriteName = Card.CardBackground(CardManager.CardType.Silver);
			break;
		case DailyReward.SilverCardpack:
			cardpackBackground.spriteName = "menu-cards-silverpack";
			cardpackFrontWarcard.spriteName = Card.CardBackground(CardManager.CardType.Silver);
			cardpackBackWarcard.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			break;
		case DailyReward.GoldCardpack:
			cardpackBackground.spriteName = "menu-cards-goldpack";
			cardpackFrontWarcard.spriteName = Card.CardBackground(CardManager.CardType.Gold);
			cardpackBackWarcard.spriteName = Card.CardBackground(CardManager.CardType.Silver);
			break;
		}
	}
}
