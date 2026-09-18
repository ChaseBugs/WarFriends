using UnityEngine;

internal class SpecialOfferMessage : DatabaseMessage
{
	private string mItemId;

	private int mSale;

	private bool mIsUpgrade;

	private bool mNewType;

	private OneOffer[] mCurrentOffers;

	public SpecialOfferMessage(string itemId, int sale, OfferBuyType type)
		: base($"SpecialOfferMessage {itemId} {sale} {type}", Type.SpecialOfferMessage)
	{
		mItemId = itemId;
		mSale = sale;
		mIsUpgrade = (type & OfferBuyType.Upgrade) == OfferBuyType.Upgrade;
		Debug.Log($"ADD special offer to show {itemId} {sale} {type.ToString()}");
	}

	public SpecialOfferMessage(OneOffer[] currentOffers)
		: base($"SpecialOfferMessage", Type.SpecialOfferMessage)
	{
		mNewType = true;
		string text = string.Empty;
		for (int i = 0; i < currentOffers.Length; i++)
		{
			text = text + " " + currentOffers[i].id + currentOffers[i].deadline;
		}
		messageId += text;
		mCurrentOffers = currentOffers;
	}

	public SpecialOfferMessage(OneOffer currentOffer)
		: base($"SpecialOfferMessage", Type.SpecialOfferMessage)
	{
		mNewType = true;
		messageId = messageId + " " + currentOffer.id;
		mCurrentOffers = new OneOffer[1];
		mCurrentOffers[0] = currentOffer;
	}

	public override void Show()
	{
		base.Show();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(mCurrentOffers);
		if (mNewType)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ShowDialog(mCurrentOffers);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ShowDialog(mItemId, mSale, mIsUpgrade);
		}
	}
}
