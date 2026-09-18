using System;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

[Skip]
public class CardCraftingManager : DatabaseSerializedObjectGeneric<CardCraftingManager.CraftData>
{
	[Skip]
	public class CraftData
	{
		public List<string> cards = new List<string>();

		public int start;

		public int end;
	}

	private static CardCraftingManager mInstance;

	[HideInInspector]
	public bool waitingForServerResponse;

	public static CardCraftingManager instance
	{
		get
		{
			mInstance = mInstance ?? ((CardCraftingManager)UnityEngine.Object.FindObjectsOfType(typeof(CardCraftingManager))[0]);
			return mInstance;
		}
	}

	public int startCraftingTime => data.start;

	public int endCraftingTime
	{
		get
		{
			return data.end;
		}
		set
		{
			data.end = value;
			if (this.EndTimeChanged != null)
			{
				this.EndTimeChanged();
			}
		}
	}

	public List<Card> craftingCards
	{
		get
		{
			List<Card> list = new List<Card>();
			if (data == null || data.cards == null)
			{
				return list;
			}
			for (int i = 0; i < data.cards.Count; i++)
			{
				list.Add(CardManager.instance.GetCardInstance(data.cards[i]));
			}
			return list;
		}
	}

	public bool isCardCrafting => isCrafting && data.end > Singleton<BeanstalkServerManager>.instance.currentTimestamp;

	public bool isCardCrafted => !waitingForServerResponse && isCrafting && data.end <= Singleton<BeanstalkServerManager>.instance.currentTimestamp;

	public bool isCrafting => data != null && data.cards != null && data.cards.Count > 0 && data.start < data.end;

	public float craftingProgress
	{
		get
		{
			if (data.start == data.end)
			{
				return 0f;
			}
			return Mathf.Clamp01((float)(Singleton<BeanstalkServerManager>.instance.currentTimestamp - data.start) / (float)(data.end - data.start));
		}
	}

	public int remainingSeconds => Mathf.Max(0, data.end - Singleton<BeanstalkServerManager>.instance.currentTimestamp);

	public bool isGoldCrafting => craftingCards.Count != 0 && craftingCards[0].rarity == CardManager.CardType.Silver;

	public bool canAnyWarcardBeCrafted => CardManager.instance.GetWarcardsCount(CardManager.CardType.Bronze) > 2 || CardManager.instance.GetWarcardsCount(CardManager.CardType.Silver) > 2;

	public event Action<Card> CardWasCrafted;

	public event Action EndTimeChanged;

	public event Action NewDataLoaded;

	public void LoadData(string data)
	{
		SerializedObject = JsonConvert.DeserializeObject<CraftData>(data);
		waitingForServerResponse = false;
		if (this.NewDataLoaded != null)
		{
			this.NewDataLoaded();
		}
	}

	public void CraftWarcard(List<Card> cardsToCraft)
	{
		if (cardsToCraft == null || cardsToCraft.Count != 3)
		{
			return;
		}
		if (data == null)
		{
			data = new CraftData();
		}
		data.start = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = ((cardsToCraft[0].rarity != CardManager.CardType.Silver) ? ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CardCraftTimeSilver).FLOATVALUE) : ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CardCraftTimeGold).FLOATVALUE));
		data.end = data.start + num * 60;
		if (data.cards == null)
		{
			data.cards = new List<string>();
		}
		else
		{
			data.cards.Clear();
		}
		foreach (Card item in cardsToCraft)
		{
			data.cards.Add(item.id);
			item.RemoveCard();
		}
		Singleton<BeanstalkServerManager>.instance.CraftCard(JsonConvert.SerializeObject(data.cards));
	}

	public void ClaimWarcard(string cardId)
	{
		Card obj = CardManager.instance.AddCard(cardId);
		if (this.CardWasCrafted != null)
		{
			this.CardWasCrafted(obj);
		}
		Debug.Log("Added warcard from crafting is " + cardId);
		waitingForServerResponse = false;
		GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.ClaimAnimation(cardId);
		StopCrafting();
	}

	public void DebugSpeedCrafting()
	{
		if (isCrafting)
		{
			endCraftingTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp + 60;
		}
	}

	private void StopCrafting()
	{
		data.cards.Clear();
		data.start = 0;
		data.end = 0;
	}
}
