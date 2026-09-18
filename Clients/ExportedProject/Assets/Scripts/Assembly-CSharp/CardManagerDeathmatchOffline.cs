using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class CardManagerDeathmatchOffline : Singleton<CardManagerDeathmatchOffline>, ICardManager
{
	public Dictionary<string, Card> botCards = new Dictionary<string, Card>();

	public List<Card> cardsForGame = new List<Card>();

	public List<Card> cardsUsedByBot = new List<Card>();

	private PhotonView mPhotonView;

	private float mTimeLockDisarmedAndBurst;

	private PlayerWeapon mLastUsedWeapon;

	private PlayerWeapon mGrenade;

	private List<Card> mUsedCards;

	private float mNextTime;

	private float mCooldown = 5f;

	private bool mCardUseInProgress;

	private float mGameStarTime;

	private bool mIsEnemyBuff;

	private bool mSendLocal;

	private float mNoViableCardCooldown;

	private int mMissionEventCardCount;

	private float mStartCoolDownMin = 7f;

	private float mStartCoolDownMax = 20f;

	private float mCoolDownMin = 5f;

	private float mCoolDownMax = 60f;

	public float timeLockWeaponSwitch
	{
		get
		{
			return mTimeLockDisarmedAndBurst;
		}
		set
		{
			mTimeLockDisarmedAndBurst = value;
		}
	}

	public PlayerWeapon savedWeapon
	{
		get
		{
			return mLastUsedWeapon;
		}
		set
		{
			mLastUsedWeapon = value;
		}
	}

	public PlayerWeapon grenadeSaved
	{
		get
		{
			return mGrenade;
		}
		set
		{
			mGrenade = value;
		}
	}

	public bool noMoreCards
	{
		get
		{
			if (cardsForGame.Count > mMissionEventCardCount)
			{
				return false;
			}
			return true;
		}
	}

	public bool noViableCardCooldown => TimeManager.realTimeWithoutPauses < mNoViableCardCooldown;

	public bool startGameCooldown => TimeManager.realTimeWithoutPauses < mGameStarTime;

	public float progress
	{
		get
		{
			if (mNextTime == 0f)
			{
				return 0f;
			}
			return (mCooldown != 0f) ? Mathf.Clamp01((mNextTime - TimeManager.realTimeWithoutPauses) / mCooldown) : 0f;
		}
	}

	protected override void Awake()
	{
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		mPhotonView = GetComponent<PhotonView>();
	}

	private void InstanceOnGameStarted()
	{
		mGameStarTime = TimeManager.realTimeWithoutPauses + Random.Range(mStartCoolDownMin, mStartCoolDownMax);
		mNoViableCardCooldown = TimeManager.realTimeWithoutPauses;
		mCardUseInProgress = false;
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		cardsForGame.Clear();
		if (mUsedCards != null)
		{
			foreach (Card mUsedCard in mUsedCards)
			{
				mUsedCard.DisconnectEvents();
			}
			mUsedCards.Clear();
		}
		mCardUseInProgress = false;
	}

	public void InitCards()
	{
		Transform transform = CardManager.instance.transform.Find("MineCards");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = "BotCards";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: true);
		Card[] array = componentsInChildren;
		foreach (Card card in array)
		{
			botCards.Add(card.id, card);
		}
	}

	public void Load()
	{
		foreach (KeyValuePair<string, Card> botCard in botCards)
		{
			CardDefinitionsRow row = CardManager.instance.cardDefinitions.GetRow(botCard.Value.id);
			if (row == null && !botCard.Value.isBuddyCard)
			{
				Debug.LogError($"There is no definition for card {botCard.Value.id}");
			}
			botCard.Value.Init(row);
		}
	}

	private List<string> IdsOfAllowedCardsForBot()
	{
		List<string> list = new List<string>();
		foreach (Card value in botCards.Values)
		{
			if (!(value.id == "KEVLARUP") && !(value.id == "MINE") && !(value.id == "COPYCAT") && (!Singleton<GameController>.instance.isMission || value.newFromMission <= MissionsManager.instance.currentMission.number))
			{
				list.Add(value.id);
			}
		}
		return list;
	}

	public void RemoveCard(Card card)
	{
		if (!cardsForGame.Remove(card))
		{
			Debug.LogError($"Remove card (ID = {card.id}) failed!");
		}
	}

	public void UseCard()
	{
		if (!mCardUseInProgress && !noMoreCards && !startGameCooldown && !(progress > 0f) && !noViableCardCooldown)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.currentPlayer.fraction);
			Card viableCardForBot = GetViableCardForBot(enemyOf);
			if (viableCardForBot == null)
			{
				mNoViableCardCooldown = TimeManager.realTimeWithoutPauses + 0.5f;
			}
			else
			{
				UseCardInternal(enemyOf, viableCardForBot);
			}
		}
	}

	public bool UseMissionEventCard(string cardId)
	{
		if (mCardUseInProgress || startGameCooldown || progress > 0.2f)
		{
			return false;
		}
		Card card = null;
		for (int i = 0; i < mMissionEventCardCount; i++)
		{
			Card card2 = cardsForGame[i];
			if (card2.id == cardId)
			{
				card = card2;
				break;
			}
		}
		if (card == null)
		{
			Debug.LogError($"Mission Event card not found! ({cardId})");
			return true;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.currentPlayer.fraction);
		UseCardInternal(enemyOf, card);
		mMissionEventCardCount--;
		return true;
	}

	private void UseCardInternal(PlayerController bot, Card card)
	{
		Fractions fraction = bot.fraction;
		mCardUseInProgress = true;
		card.UseCard(this, fraction);
		if (Singleton<GameController>.instance.isCoopBot)
		{
			if (Random.value < 0.5f)
			{
				card.UseCardOnline(this, bot.fraction);
				mSendLocal = true;
			}
			else
			{
				mPhotonView.RPC("PlayCard", PhotonTargets.Others, card.id, (byte)fraction);
				mSendLocal = false;
			}
			mIsEnemyBuff = card.isEnemyPlayerBuff;
		}
		else
		{
			card.UseCardOnline(this, fraction);
		}
		cardsUsedByBot.Add(card);
		float num = Random.Range(mCoolDownMin, mCoolDownMax);
		mCooldown = card.cooldown + num;
		mUsedCards.Add(card);
		RemoveCard(card);
	}

	[PunRPC]
	private void PlayCard(string id, byte fraction)
	{
		if (!botCards.ContainsKey(id))
		{
			Debug.LogError("Bot Cards does not contain id: " + id);
			return;
		}
		botCards[id].UseCardOnline(this, (Fractions)fraction);
		mUsedCards.Add(botCards[id]);
	}

	public void CardWasUsed(Card card, Fractions fraction)
	{
		if (mCardUseInProgress)
		{
			mNextTime = TimeManager.realTimeWithoutPauses + mCooldown;
			mCardUseInProgress = false;
			if ((mSendLocal && mIsEnemyBuff) || !mIsEnemyBuff)
			{
				CardManager.instance.ShowCardBotPlayed(card, fraction);
			}
			if ((!mSendLocal && mIsEnemyBuff) || !mIsEnemyBuff)
			{
				mPhotonView.RPC("CardWasUsedOnline", PhotonTargets.Others, card.id, (byte)fraction);
			}
		}
	}

	[PunRPC]
	private void CardWasUsedOnline(string id, byte fraction)
	{
		if ((Fractions)fraction == PlayerController.currentPlayer.fraction && mCardUseInProgress)
		{
			mNextTime = TimeManager.realTimeWithoutPauses + mCooldown;
			mCardUseInProgress = false;
		}
		CardManager.instance.ShowCardBotPlayed(botCards[id], (Fractions)fraction);
	}

	public Card GetCardInstance(string cardId)
	{
		if (botCards.ContainsKey(cardId))
		{
			return botCards[cardId];
		}
		Debug.LogError($"Card ID \"{cardId}\" is not pressent in card dictionary.");
		return null;
	}

	private Card GetViableCardForBot(PlayerController bot)
	{
		Fractions fraction = bot.fraction;
		Fractions fraction2 = ((fraction == Fractions.Allies) ? Fractions.Enemies : Fractions.Allies);
		float healthRatio = bot.destroyableParts.healthRatio;
		List<GameShootableEntity> entities = GameShootableEntity.GetEntities(fraction);
		List<GameShootableEntity> entities2 = GameShootableEntity.GetEntities(fraction2);
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(fraction, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> opponents2 = GameShootableEntity.GetOpponents(fraction2, GameShootableEntity.GetAllMechanicalTypes());
		List<Card> list = new List<Card>();
		for (int i = mMissionEventCardCount; i < cardsForGame.Count; i++)
		{
			Card card = cardsForGame[i];
			if (card.IsViableForBotNow(fraction, healthRatio, entities, entities2, opponents2, opponents))
			{
				list.Add(card);
			}
		}
		return (list.Count > 0) ? list[Random.Range(0, list.Count)] : null;
	}

	public void ChooseCardsForMatch(string cardsquality, PlayerController player, float buddyCardProbability, string cardsFrequency = "")
	{
		mCooldown = 5f;
		mUsedCards = new List<Card>();
		cardsUsedByBot.Clear();
		cardsForGame.Clear();
		mMissionEventCardCount = 0;
		List<string> list = IdsOfAllowedCardsForBot();
		List<Card> list2 = new List<Card>();
		bool flag = Singleton<GameController>.instance.isCampaignBot || Singleton<GameController>.instance.isCoopBot;
		if (flag)
		{
			MissionDefinition definition = MissionsManager.instance.currentMission.GetDefinition();
			foreach (MissionDefinitionEvent @event in definition.events)
			{
				if (!string.IsNullOrEmpty(@event.card) && list.Contains(@event.card))
				{
					Card item = botCards[@event.card];
					list2.Add(item);
					mMissionEventCardCount++;
				}
			}
		}
		if (flag && MissionsManager.instance.currentMission.GetDefinition().bot.useDefinedCards)
		{
			MissionDefinition definition2 = MissionsManager.instance.currentMission.GetDefinition();
			foreach (string card2 in definition2.bot.cards)
			{
				if (list.Contains(card2))
				{
					list2.Add(botCards[card2]);
				}
			}
		}
		else
		{
			string[] array = cardsquality.Split('|');
			if (array.Length > 3)
			{
				int min = int.Parse(array[0]);
				int num = int.Parse(array[1]);
				float num2 = float.Parse(array[2]);
				float num3 = float.Parse(array[3]);
				int num4 = Random.Range(min, num + 1);
				int num5 = ((Random.value < num2) ? 3 : ((!((double)Random.value > 0.5)) ? 1 : 2));
				while (list2.Count != num4 + mMissionEventCardCount)
				{
					int index = Random.Range(0, list.Count);
					string key = list[index];
					Card card = botCards[key];
					if (!list2.Contains(card) && card.rarity == (CardManager.CardType)num5)
					{
						list2.Add(card);
						float value = Random.value;
						num5 = ((value < num2) ? 3 : ((!(value < num3 + num2)) ? 1 : 2));
					}
				}
			}
		}
		SetUpCardsFrequency(cardsFrequency);
		List<Tuple<string, CardManager.BuddyCardData>> list3 = new List<Tuple<string, CardManager.BuddyCardData>>();
		if (Random.value < buddyCardProbability)
		{
			list3.Add(new Tuple<string, CardManager.BuddyCardData>("BUDDY_CARD_BOT", CardBuddy.CreateRandomByddyCard(player.playerProperties.level, player.playerProperties.armyPower)));
			List<CardBuddy> list4 = CardManager.instance.SetBuddyCardsOher(list3);
			foreach (CardBuddy item2 in list4)
			{
				if (item2.amount == 1 && item2.id == "BUDDY_CARD_BOT")
				{
					int count = list2.Count;
					list2.Insert(Random.Range(0, count), item2);
				}
			}
		}
		string text = "CardManager - BOT cards";
		string text2 = string.Empty;
		foreach (Card item3 in list2)
		{
			cardsForGame.Add(item3);
			string text3 = text;
			text = text3 + "\t\t" + item3.id + " " + item3.cardName;
			text2 = text2 + item3.id + ";";
		}
		text2 = text2.TrimEnd(';');
		Debug.Log(text);
		player.playerProperties.chosenCards = text2;
		player.playerProperties.buddyCards = list3;
	}

	private void SetUpCardsFrequency(string cardsFrequency)
	{
		string[] array = cardsFrequency.Split('|');
		mStartCoolDownMin = 7f;
		mStartCoolDownMax = 20f;
		mCoolDownMin = 5f;
		mCoolDownMax = 60f;
		if (array.Length > 3)
		{
			mStartCoolDownMin = int.Parse(array[0]);
			mStartCoolDownMax = int.Parse(array[1]);
			mCoolDownMin = float.Parse(array[2]);
			mCoolDownMax = float.Parse(array[3]);
		}
	}
}
