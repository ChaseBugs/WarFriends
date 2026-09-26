using System;
using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using UnityEngine;

[Skip]
[ExecuteInEditMode]
public class CardManager : DatabaseSerializedObjectGeneric<CardManager.CardManagerData>, ICardManager
{
	[Skip]
	public enum CardType
	{
		Bronze = 1,
		Silver,
		Gold,
		Buddy
	}

	[Skip]
	[Flags]
	[JsonConverter(typeof(StringEnumConverter))]
	public enum CardFilter
	{
		None = 0,
		Bronze = 1,
		Silver = 2,
		Gold = 4,
		Buddy = 8,
		All = 0xFFFFFF
	}

	[Skip]
	public class CardData
	{
		public int amount;
	}

	[Serializable]
	public class BuddyCardData
	{
		public int amount;

		public string buddyName;

		public Dictionary<int, CamosManager.SavedPlayerVisualSlot> equippedVisuals;

		public LevelBehaviour.UnitType unityType;

		public int primaryWeapon;

		public int secondaryWeapon;

		public int armypower;

		public int level;
	}

	[Skip]
	public class CardManagerData
	{
		public Dictionary<string, CardData> cardData = new Dictionary<string, CardData>();

		public Dictionary<string, BuddyCardData> buddyCardData = new Dictionary<string, BuddyCardData>();

		public int nextWithdraw;

		public int nextBuddyDeposit;

		public bool extraSlot;

		public int GetCardAmount()
		{
			if (cardData == null)
			{
				return 0;
			}
			int num = 0;
			foreach (KeyValuePair<string, CardData> cardDatum in cardData)
			{
				num += cardDatum.Value.amount;
			}
			return num;
		}
	}

	[Header("List for References to Cards in Scene")]
	public List<Card> cards;

	public List<Card> obtainedCards = new List<Card>();

	public List<Card> enemyCards = new List<Card>();

	public List<Card> cardUsedByMe = new List<Card>();

	[SerializeField]
	private CardBuddy mCardBuddyPrefab;

	private List<CardBuddy> mBuddyCards = new List<CardBuddy>();

	private List<CardBuddy> mBuddyCardsSquad = new List<CardBuddy>();

	private Transform mSquadCardsParent;

	[HideInInspector]
	private Dictionary<string, Card> mCardDictionary = new Dictionary<string, Card>();

	[HideInInspector]
	public List<Card> cardsByRarity = new List<Card>();

	public static int LowLevelTreshold = 7;

	public static int HighLevelTreshold = 10;

	private static CardManager mInstance;

	public CardDefinitions cardDefinitions;

	private PhotonView mPhotonView;

	private float mCooldown = 5f;

	private float mNextTime;

	private List<Card>[] mCardsByQuality;

	private Dictionary<string, Card> mOtherPlayerCards = new Dictionary<string, Card>();

	private List<Card> mUsedCards = new List<Card>();

	private bool mCardUseInProgress;

	private string mIdLastGainedCard;

	private List<CardBuddy> mOtherBuddyCards;

	private CardBuddy mBuddyCard;

	public List<Card> cardsForGame => Singleton<GameController>.instance.mainController.cardsForGame;

	public Card withdrawingCard { get; set; }

	public bool canUseCards => Singleton<GameController>.instance.mainController.canDeployUnits;

	public int cardsInPack => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CardsInPack).FLOATVALUE;

	public int bronzePackBronzeCards => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackBronzeCards).FLOATVALUE;

	public CardType bronzePackMin => CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackGuaranteedCardsType).FLOATVALUE);

	public CardType bronzePackMax => CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackMaxRarityCardsType).FLOATVALUE);

	public int silverPackSilverCards => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackSilverCards).FLOATVALUE;

	public CardType silverPackMin => CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackGuaranteedCardsType).FLOATVALUE);

	public CardType silverPackMax => CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackMaxRarityCardsType).FLOATVALUE);

	public int goldPackGoldCards => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldPackGoldCards).FLOATVALUE;

	public CardType goldPackMin => CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldPackGuaranteedCardsType).FLOATVALUE);

	public CardType goldPackMax => CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldPackMaxRarityCardsType).FLOATVALUE);

	public int nextWithdraw
	{
		get
		{
			return data.nextWithdraw;
		}
		set
		{
			data.nextWithdraw = value;
			if (this.WithdrawTimeChanged != null)
			{
				this.WithdrawTimeChanged();
			}
		}
	}

	public int nextBuddyDeposit
	{
		get
		{
			return data.nextBuddyDeposit;
		}
		set
		{
			data.nextBuddyDeposit = value;
		}
	}

	public bool isWithdrawAvailable => nextWithdraw <= Singleton<BeanstalkServerManager>.instance.currentTimestamp;

	public bool isBuddyDepositAvailable => nextBuddyDeposit <= Singleton<BeanstalkServerManager>.instance.currentTimestamp;

	public bool extraSlot => data.extraSlot;

	public static CardManager instance
	{
		get
		{
			mInstance = mInstance ?? ((CardManager)UnityEngine.Object.FindObjectsOfType(typeof(CardManager))[0]);
			return mInstance;
		}
	}

	public PlayerWeapon grenadeSaved { get; set; }

	public PlayerWeapon savedWeapon { get; set; }

	public float timeLockWeaponSwitch { get; set; }

	public Card CurrentCard => (cardsForGame.Count <= 0) ? null : cardsForGame[0];

	public bool NoMoreCards => cardsForGame.Count == 0;

	public float Progress
	{
		get
		{
			if (mCardUseInProgress)
			{
				return 1f;
			}
			if (mNextTime == 0f || mCooldown == 0f)
			{
				return 0f;
			}
			return Mathf.Clamp01((mNextTime - TimeManager.realTimeWithoutPauses) / mCooldown);
		}
	}

	public CardBuddy buddyCard
	{
		get
		{
			return mBuddyCard;
		}
		private set
		{
			mBuddyCard = value;
		}
	}

	public static float availableLengthInSmallCard => 154f;

	public string selectedCards
	{
		get
		{
			string text = string.Empty;
			foreach (Card item in cardsForGame)
			{
				text = text + item.id + ";";
			}
			return text.TrimEnd(';');
		}
	}

	public List<Tuple<string, BuddyCardData>> selectedBuddyCards
	{
		get
		{
			List<Tuple<string, BuddyCardData>> list = new List<Tuple<string, BuddyCardData>>();
			foreach (Card item in cardsForGame)
			{
				if (item is CardBuddy)
				{
					list.Add(new Tuple<string, BuddyCardData>(item.id, ((CardBuddy)item).buddyCardData));
				}
			}
			return list;
		}
	}

	public event Action<Card, Fractions, bool> CardUsed;

	public event Action<bool> OnSyncWithServer;

	public event Action ErrorHappened;

	public event Action<Card> OnCardGainedInGame;

	public event Action CardPackBought;

	public event Action WithdrawTimeChanged;

	public CardManager()
	{
		timeLockWeaponSwitch = 0f;
	}

	public static CardFilter GetFilter(CardType cardType)
	{
		return (CardFilter)Math.Pow(2.0, (double)(cardType - 1));
	}

	public Card GetCardInstanceAll(string cardId, bool isCurrentPlayer = true)
	{
		if (mCardDictionary.ContainsKey(cardId))
		{
			return mCardDictionary[cardId];
		}
		if (mOtherPlayerCards.ContainsKey(cardId))
		{
			return mOtherPlayerCards[cardId];
		}
		string message = $"Card ID \"{cardId}\" is not pressent in card dictionary.";
		Debug.LogError(message);
		Exception e = new Exception(message);
		Crittercism.LogHandledException(e);
		return null;
	}

	public Card GetCardInstance(string cardId, bool isCurrentPlayer = true)
	{
		if (isCurrentPlayer)
		{
			if (mCardDictionary.ContainsKey(cardId))
			{
				return mCardDictionary[cardId];
			}
		}
		else if (mOtherPlayerCards.ContainsKey(cardId))
		{
			return mOtherPlayerCards[cardId];
		}
		string message = $"Card ID \"{cardId}\" is not pressent in card dictionary.";
		Debug.LogError(message);
		Exception e = new Exception(message);
		Crittercism.LogHandledException(e);
		return null;
	}

	public bool IsCardId(string cardId)
	{
		return mCardDictionary.ContainsKey(cardId);
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		cardDefinitions = GetComponent<CardDefinitions>();
		if (!Application.isPlaying)
		{
			return;
		}
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OnPlayerDataLoaded;
		GameLoginManager.instance.PlayerLogOut += delegate
		{
			cardsForGame.Clear();
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (action == DatabaseAction.AddFacebook || action == DatabaseAction.SwitchToFacebook)
			{
				cardsForGame.Clear();
			}
		};
		mPhotonView = GetComponent<PhotonView>();
		InitCards();
		mInstance = this;
	}

	public bool CardsForGameContains(Card card)
	{
		if (cardsForGame == null || card == null)
		{
			return false;
		}
		for (int i = 0; i < cardsForGame.Count; i++)
		{
			if (cardsForGame[i].id == card.id)
			{
				return true;
			}
		}
		return false;
	}

	private int GetRandomRarity(CardType guaranteedRarity = CardType.Bronze, CardType maxRarity = CardType.Gold)
	{
		float min = 0f;
		float max = 1f;
		float num = LevelManager.instance.InterpolateNumbersBasedOnLevel(LowLevelTreshold, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverCardRarityEarly).FLOATVALUE, HighLevelTreshold, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverCardRarity).FLOATVALUE);
		float num2 = LevelManager.instance.InterpolateNumbersBasedOnLevel(LowLevelTreshold, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCardRarityEarly).FLOATVALUE, HighLevelTreshold, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCardRarity).FLOATVALUE);
		if (guaranteedRarity == CardType.Silver)
		{
			min = num;
		}
		if (guaranteedRarity == CardType.Gold)
		{
			min = num2;
		}
		if (maxRarity == CardType.Bronze)
		{
			max = num;
		}
		if (maxRarity == CardType.Silver)
		{
			max = num2;
		}
		float num3 = UnityEngine.Random.Range(min, max);
		if (num2 <= num3)
		{
			return 3;
		}
		return (!(num <= num3)) ? 1 : 2;
	}

	public Card AddRandomCard(CardType guaranteedRarity = CardType.Bronze, CardType maxRarity = CardType.Gold)
	{
		int randomRarity = GetRandomRarity(guaranteedRarity, maxRarity);
		int count = mCardsByQuality[randomRarity - 1].Count;
		Card card = mCardsByQuality[randomRarity - 1][UnityEngine.Random.Range(0, count)];
		mIdLastGainedCard = card.id;
		Debug.Log($"Add RANDOM warcard - min {guaranteedRarity} max {maxRarity} - {card.rarity} {card.cardName}");
		card.AddCard();
		return card;
	}

	public Card AddRarityCard(CardType rarity)
	{
		int count = mCardsByQuality[(int)(rarity - 1)].Count;
		Card card = mCardsByQuality[(int)(rarity - 1)][UnityEngine.Random.Range(0, count)];
		mIdLastGainedCard = card.id;
		card.AddCard();
		Debug.Log($"Add RARITY {rarity} warcard - {card.cardName}");
		return card;
	}

	public Card AddRandomCardDuringGame()
	{
		Card card = AddRandomCard();
		obtainedCards.Add(card);
		return card;
	}

	public void CardWasUsed(Card card, Fractions fraction)
	{
		if (fraction == PlayerController.currentPlayer.fraction && mCardUseInProgress)
		{
			mNextTime = TimeManager.realTimeWithoutPauses + mCooldown;
			mCardUseInProgress = false;
		}
		if (this.CardUsed != null)
		{
			this.CardUsed(card, fraction, fraction == PlayerController.currentPlayer.fraction);
		}
		if (SelfHostedBattleClient.Active == null || !SelfHostedBattleClient.Active.IsConnected)
			mPhotonView.RPC("CardWasUsedOnline", PhotonTargets.Others, card.id, (byte)fraction, card.playerId);
	}

	public void LoadData(JToken cardData)
	{
		LoadData((string)cardData);
	}

	public void LoadData(string cardData)
	{
		SerializedObject = JsonConvert.DeserializeObject<CardManagerData>(cardData);
		if (this.OnSyncWithServer != null)
		{
			this.OnSyncWithServer(obj: true);
		}
		this.OnSyncWithServer = null;
	}

	public void ShowCardBotPlayed(Card card, Fractions fraction)
	{
		if (this.CardUsed != null)
		{
			this.CardUsed(card, fraction, arg3: false);
		}
		enemyCards.Add(card);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.EnemyCardPlayed);
	}

	internal void AddMultipleCards(string cardId, int num)
	{
		Debug.Log($"CardManager: Added {num}x card {cardId}");
		if (mCardDictionary.ContainsKey(cardId))
		{
			Card card = mCardDictionary[cardId];
			card.AddCard(num);
		}
		else
		{
			Debug.LogError($"failed add card {cardId} - not exit?");
		}
	}

	internal Card AddCard(string cardId)
	{
		Debug.Log("CardManager: Added card " + cardId);
		Card card = mCardDictionary[cardId];
		card.AddCard();
		return card;
	}

	public void UseCard(Card card)
	{
		if (!mCardUseInProgress && !NoMoreCards && !(Progress > 0f) && CardsForGameContains(card))
		{
			mCardUseInProgress = true;
			mCooldown = card.cooldown;
			SelfHostedBattleClient selfHosted = SelfHostedBattleClient.Active;
			if (selfHosted != null && selfHosted.IsConnected && (card is CardDecoy || card is CardLandmine))
			{
				UseSelfHostedDeployable(selfHosted, card, PlayerController.currentPlayer.fraction);
				return;
			}
			card.playerId = PhotonNetwork.player.ID;
			mPhotonView.RPC("PlayCardRPC", PhotonTargets.Others, card.id, (byte)PlayerController.currentPlayer.fraction, PhotonNetwork.player.ID);
			card.UseCard(this, PlayerController.currentPlayer.fraction);
			card.RemoveCard();
			StatsManager.instance.matchStats.PlayCard(card);
			BattleRewardsManager.instance.AddWarcardInMatch(card.id);
			if (PhotonNetwork.offlineMode)
			{
				card.UseCardOnline(this, PlayerController.currentPlayer.fraction);
			}
			mUsedCards.Add(card);
			cardUsedByMe.Add(card);
			cardsForGame.Remove(card);
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CardPlayed);
		}
	}

	private async void UseSelfHostedDeployable(SelfHostedBattleClient client, Card card, Fractions fraction)
	{
		try
		{
			var reply = card is CardLandmine ? await client.UseLandMineResult() : await client.UseDecoyResult();
			bool accepted = card is CardLandmine ?
				(reply.Code == "land-mine-spawned" || reply.Code == "land-mine-replayed") :
				(reply.Code == "decoy-spawned" || reply.Code == "decoy-replayed");
			if (!accepted) throw new InvalidOperationException("Battle host rejected deployable activation: " + reply.Code);
			card.playerId = 0;
			CardWasUsed(card, fraction);
			card.RemoveCard();
			StatsManager.instance.matchStats.PlayCard(card);
			BattleRewardsManager.instance.AddWarcardInMatch(card.id);
			mUsedCards.Add(card);
			cardUsedByMe.Add(card);
			cardsForGame.Remove(card);
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CardPlayed);
		}
		catch (Exception exception)
		{
			mCardUseInProgress = false;
			Debug.LogError("Self-hosted deployable activation failed: " + exception.Message);
		}
	}

	public Card[] BuyThreeCards(int warbucks)
	{
		string text = CardPack.ThreeCards.ToString();
		Card[] array = new Card[3];
		string[] array2 = new string[3];
		for (int i = 0; i < 3; i++)
		{
			array[i] = AddRandomCard();
			array2[i] = array[i].id;
		}
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary["cards"] = array2;
		dictionary["cardPack"] = Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.THREE_CARDS).NAME;
		string objData = JsonConvert.SerializeObject(dictionary);
		requestBuffer.AddRequest(DatabaseAction.BuyCardPack, objData, warbucks, 0, text);
		string text2 = string.Empty;
		Card[] array3 = array;
		foreach (Card card in array3)
		{
			string text3 = text2;
			text2 = text3 + "\n\t" + card.rarity.ToString() + " " + card.cardName;
		}
		Debug.Log("BUYING CARD PACK " + text + text2);
		GuiScreenSingle<CardSelectionScreen>.instance.UpdateHeaderAndCards();
		return array;
	}

	internal int[] GetRarityCounts()
	{
		int[] array = new int[3];
		for (int i = 0; i < 3; i++)
		{
			List<Card> list = mCardsByQuality[i];
			foreach (Card item in list)
			{
				array[i] += item.amount;
			}
			Debug.Log("Rarity " + i + " = " + array[i]);
		}
		return array;
	}

	public int GetWarcardsCount(CardType rarity)
	{
		int num = 0;
		if (mCardsByQuality.Length < (int)rarity)
		{
			return 0;
		}
		List<Card> list = mCardsByQuality[(int)(rarity - 1)];
		if (list == null)
		{
			return 0;
		}
		for (int i = 0; i < list.Count; i++)
		{
			num += list[i].amount;
		}
		return num;
	}

	internal Card[] BuyCardPack(CardPack cardTypePack, int warbucks, int gold, int discount)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Buy);
		string text = cardTypePack.ToString().ToUpper();
		string nAME = Singleton<GameVariables>.instance.GetCardPackRow(cardTypePack).NAME;
		CardType cardType;
		switch (cardTypePack)
		{
			case CardPack.Gold: cardType = CardType.Gold; break;
			case CardPack.Silver: cardType = CardType.Silver; break;
			default: cardType = CardType.Bronze; break;
		}
		Card[] cardsFromCardpack = GetCardsFromCardpack(cardType);
		string[] array = new string[cardsFromCardpack.Length];
		switch (cardTypePack)
		{
		case CardPack.Bronze:
			Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchaseCardPack1);
			break;
		case CardPack.Silver:
			Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchaseCardPack2);
			break;
		case CardPack.Gold:
			Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchaseCardPack3);
			break;
		}
		string text2 = $"BUYING CARD PACK: type:{text} -> cardType:{cardType.ToString()}";
		for (int i = 0; i < cardsFromCardpack.Length; i++)
		{
			array[i] = cardsFromCardpack[i].id;
			text2 += $"\n\t{cardsFromCardpack[i].rarity.ToString()} {cardsFromCardpack[i].cardName}";
		}
		Debug.Log(text2);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary["cards"] = array;
		dictionary["cardPack"] = nAME;
		dictionary["discount"] = discount;
		dictionary["StartTime"] = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		string objData = JsonConvert.SerializeObject(dictionary);
		requestBuffer.AddRequest(DatabaseAction.BuyCardPack, objData, warbucks, gold, text);
		return cardsFromCardpack;
	}

	public void CardPackBoughtEvent()
	{
		if (this.CardPackBought != null)
		{
			this.CardPackBought();
		}
	}

	public Card[] GetCardsFromCardpack(CardType typeCardpack)
	{
		int num = cardsInPack;
		CardType cardType = typeCardpack;
		int num2 = 5;
		CardType cardType2 = CardType.Bronze;
		CardType cardType3 = CardType.Gold;
		CardPacks cardPacks = Singleton<GameVariables>.instance.cardPacks;
		switch (typeCardpack)
		{
		case CardType.Bronze:
			cardType = CardType.Bronze;
			num2 = bronzePackBronzeCards;
			cardType2 = bronzePackMin;
			cardType3 = bronzePackMax;
			break;
		case CardType.Silver:
			cardType = CardType.Silver;
			num2 = silverPackSilverCards;
			cardType2 = silverPackMin;
			cardType3 = silverPackMax;
			break;
		case CardType.Gold:
			cardType = CardType.Gold;
			num2 = goldPackGoldCards;
			cardType2 = goldPackMin;
			cardType3 = goldPackMax;
			break;
		}
		Debug.Log($"According to XLS Configuration -> Constants generating:\n{num2.ToString()} {cardType.ToString()}\n{(num - num2).ToString()} minimaly {cardType2.ToString()} maximaly {cardType3.ToString()}");
		Card[] array = new Card[num];
		for (int i = 0; i < num2; i++)
		{
			array[i] = AddRarityCard(cardType);
		}
		for (int j = num2; j < num; j++)
		{
			array[j] = AddRandomCard(cardType2, cardType3);
		}
		return array;
	}

	internal void ClearCardsForGame()
	{
		cardsForGame.Clear();
	}

	[PunRPC]
	private void CardWasUsedOnline(string cardId, byte fraction, int playerID)
	{
		Card cardInstance = GetCardInstance(cardId, isCurrentPlayer: false);
		if (playerID == PhotonNetwork.player.ID && mCardUseInProgress)
		{
			mNextTime = TimeManager.realTimeWithoutPauses + mCooldown;
			mCardUseInProgress = false;
		}
		if (this.CardUsed != null)
		{
			this.CardUsed(cardInstance, (Fractions)fraction, playerID == PhotonNetwork.player.ID);
		}
		enemyCards.Add(cardInstance);
	}

	private void InitCards()
	{
		GameObject gameObject = new GameObject("MineCards");
		gameObject.transform.parent = base.transform;
		foreach (Card card2 in cards)
		{
			if (card2 == null)
			{
				Debug.LogError("There is NULL card in card manager -> cards");
				continue;
			}
			CardDefinitionsRow row = cardDefinitions.GetRow(card2.id);
			if (row == null)
			{
				Debug.LogError($"There is no definition for card {card2.id}");
			}
			card2.Init(row);
			card2.transform.parent = gameObject.transform;
			mCardDictionary.Add(card2.id, card2);
		}
		GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject);
		gameObject2.transform.parent = base.transform;
		gameObject2.name = "OtherCards";
		Card[] componentsInChildren = gameObject2.GetComponentsInChildren<Card>(includeInactive: true);
		mOtherBuddyCards = new List<CardBuddy>();
		for (int i = 0; i < 4; i++)
		{
			CardBuddy cardBuddy = UnityEngine.Object.Instantiate(mCardBuddyPrefab);
			cardBuddy.gameObject.name = $"Other Buddy Warcard {i + 1}";
			cardBuddy.gameObject.transform.parent = gameObject2.transform;
			mOtherBuddyCards.Add(cardBuddy);
		}
		Card[] array = componentsInChildren;
		foreach (Card card in array)
		{
			mOtherPlayerCards.Add(card.id, card);
			CardDefinitionsRow row2 = cardDefinitions.GetRow(card.id);
			card.Init(row2);
			if (row2 == null)
			{
				Debug.LogError($"There is no definition for card {card.id}");
			}
		}
		mBuddyCard = UnityEngine.Object.Instantiate(mCardBuddyPrefab);
		mBuddyCard.gameObject.name = "Buddy Warcard Original";
		mBuddyCard.gameObject.transform.parent = cards[0].gameObject.transform.parent;
		mSquadCardsParent = new GameObject("SquadCards").transform;
		mSquadCardsParent.transform.parent = base.transform;
		Singleton<CardManagerDeathmatchOffline>.instance.InitCards();
	}

	public void InitializeBuddyWarcard()
	{
		mBuddyCard.Init(GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp, CardBuddy.CreateDataForCurrentPlayer());
	}

	public void ActualizeBuddyWarcardTime()
	{
		mBuddyCard.id = GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	private int SortByRarity(Card c1, Card c2)
	{
		if (c1.rarity < c2.rarity)
		{
			return 1;
		}
		if (c1.rarity > c2.rarity)
		{
			return -1;
		}
		return c1.cardName.CompareTo(c2.cardName);
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		for (int num = cardsForGame.Count - 1; num >= 0; num--)
		{
			Card card = cardsForGame[num];
			if (card.amount < 1)
			{
				cardsForGame.RemoveAt(num);
			}
		}
		foreach (Card mUsedCard in mUsedCards)
		{
			mUsedCard.DisconnectEvents();
		}
		mCardUseInProgress = false;
	}

	private void InstanceOnGameStarted()
	{
		mCardUseInProgress = false;
		mUsedCards.Clear();
		obtainedCards.Clear();
		enemyCards.Clear();
		cardUsedByMe.Clear();
		PlayerController.currentPlayer.weaponInventory.cannotChange = false;
	}

	private void OnPlayerDataLoaded()
	{
		mCardsByQuality = new List<Card>[3];
		mCardsByQuality[0] = new List<Card>();
		mCardsByQuality[1] = new List<Card>();
		mCardsByQuality[2] = new List<Card>();
		cardsByRarity.Clear();
		foreach (Card card2 in cards)
		{
			if (card2.implemented)
			{
				mCardsByQuality[(int)(card2.rarity - 1)].Add(card2);
			}
			cardsByRarity.Add(card2);
		}
		cardsByRarity.Sort(SortByRarity);
		Card[] componentsInChildren = GetComponentsInChildren<Card>();
		cardsForGame.Clear();
		foreach (CardBuddy mBuddyCard in mBuddyCards)
		{
			mBuddyCard.RemoveCard();
		}
		Card[] array = componentsInChildren;
		foreach (Card card in array)
		{
			if (!card.isBuddyCard && !data.cardData.ContainsKey(card.id))
			{
				data.cardData[card.id] = new CardData
				{
					amount = 0
				};
			}
		}
		foreach (KeyValuePair<string, BuddyCardData> buddyCardDatum in data.buddyCardData)
		{
			AddBuddyCard(buddyCardDatum.Key, buddyCardDatum.Value);
		}
		Singleton<CardManagerDeathmatchOffline>.instance.Load();
		SavingLastSelected.instance.LoadSelectedCards();
	}

	[PunRPC]
	private void PlayCardRPC(string id, byte fraction, int playerId)
	{
		if (!mOtherPlayerCards.ContainsKey(id))
		{
			Debug.LogError("Other Player Cards -> Card Manager -> does not contain id: " + id);
			return;
		}
		Card cardInstance = GetCardInstance(id, isCurrentPlayer: false);
		cardInstance.playerId = playerId;
		cardInstance.UseCardOnline(this, (Fractions)fraction);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.EnemyCardPlayed);
	}

	internal string GetUsedCards()
	{
		List<string> list = new List<string>();
		foreach (Card mUsedCard in mUsedCards)
		{
			list.Add(mUsedCard.id);
		}
		return JsonConvert.SerializeObject(list);
	}

	public int GetUsedCardsCount()
	{
		return mUsedCards.Count;
	}

	internal string GetObtainedCards()
	{
		string[] array = new string[obtainedCards.Count];
		for (int i = 0; i < obtainedCards.Count; i++)
		{
			array[i] = obtainedCards[i].id;
		}
		return JsonConvert.SerializeObject(array);
	}

	public Card RecentGainedCard()
	{
		if (string.IsNullOrEmpty(mIdLastGainedCard) || mCardDictionary.ContainsKey(mIdLastGainedCard))
		{
			return null;
		}
		return mCardDictionary[mIdLastGainedCard];
	}

	public IEnumerator InitGameCards(string chosenCards, bool isOpponnetCard, bool isCurrentPlayer)
	{
		string[] cards = chosenCards.Split(';');
		Debug.Log(string.Format("Init cards : " + chosenCards + " is Opponent: " + isOpponnetCard));
		string[] array = cards;
		foreach (string cardID in array)
		{
			if (!string.IsNullOrEmpty(cardID))
			{
				Card card = GetCardInstance(cardID, isCurrentPlayer);
				if (card != null)
				{
					yield return StartCoroutine(card.InitCard(isOpponnetCard));
				}
			}
		}
	}

	public void ReleaseCards(string chosenCards, bool isOpponnetCard, bool isCurrentPlayer)
	{
		string[] array = chosenCards.Split(';');
		Debug.Log(string.Format("Release cards : " + chosenCards + " is Opponent: " + isOpponnetCard));
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			Card cardInstance = GetCardInstance(text, isCurrentPlayer);
			if (cardInstance != null)
			{
				try
				{
					cardInstance.ReleaseCard(isOpponnetCard);
				}
				catch (Exception e)
				{
					Crittercism.LogHandledException(e);
				}
			}
		}
	}

	public static CardType CardRarityConverter(int rarity)
	{
		int result;
		switch (rarity)
		{
		case 3:
			return CardType.Gold;
		case 2:
			result = 2;
			break;
		default:
			result = 1;
			break;
		}
		return (CardType)result;
	}

	public void DebugAddEveryCard()
	{
		foreach (Card value in mCardDictionary.Values)
		{
			value.AddCard();
		}
	}

	public Card AddMineBuddyCardTest()
	{
		string id = GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		BuddyCardData buddyCardData = CardBuddy.CreateDataForCurrentPlayer();
		return AddBuddyCard(id, buddyCardData);
	}

	private CardBuddy GetEmptyBuddyCard(out bool exists)
	{
		exists = false;
		foreach (CardBuddy mBuddyCard in mBuddyCards)
		{
			if (mBuddyCard.amount == 0)
			{
				exists = true;
				return mBuddyCard;
			}
		}
		CardBuddy cardBuddy = UnityEngine.Object.Instantiate(mCardBuddyPrefab);
		cardBuddy.gameObject.name = $"Buddy Warcard {mBuddyCards.Count + 1}";
		cardBuddy.gameObject.transform.parent = cards[0].gameObject.transform.parent;
		return cardBuddy;
	}

	public Card AddBuddyCard(string id, BuddyCardData buddyCardData)
	{
		if (!data.buddyCardData.ContainsKey(id))
		{
			data.buddyCardData.Add(id, buddyCardData);
		}
		if (!mCardDictionary.TryGetValue(id, out var value))
		{
			value = GetEmptyBuddyCard(out var exists);
			if (!exists)
			{
				mBuddyCards.Add((CardBuddy)value);
				cards.Add(value);
				cardsByRarity.Add(value);
			}
		}
		CardBuddy cardBuddy = (CardBuddy)value;
		cardBuddy.Init(id, buddyCardData);
		mCardDictionary[id] = cardBuddy;
		cardsByRarity.Sort(SortByRarity);
		return value;
	}

	public List<CardBuddy> SetBuddyCardsOher(List<Tuple<string, BuddyCardData>> buddyCards)
	{
		foreach (CardBuddy mOtherBuddyCard in mOtherBuddyCards)
		{
			mOtherBuddyCard.DestroyCard();
			mOtherBuddyCard.Init("EMPTY", new BuddyCardData
			{
				amount = 0
			});
		}
		for (int i = 0; i < buddyCards.Count; i++)
		{
			Tuple<string, BuddyCardData> tuple = buddyCards[i];
			mOtherBuddyCards[i].Init(tuple.Value1, tuple.Value2);
			mOtherPlayerCards[tuple.Value1] = mOtherBuddyCards[i];
		}
		return mOtherBuddyCards;
	}

	public Card GetSquadCardInstance(string cardId, BuddyCardData buddyCardData = null)
	{
		if (buddyCardData == null)
		{
			if (mCardDictionary.ContainsKey(cardId))
			{
				return mCardDictionary[cardId];
			}
			Debug.LogError($"Squad Card ID \"{cardId}\" is not pressent");
			return null;
		}
		CardBuddy squadBuddyCard = GetSquadBuddyCard(cardId);
		squadBuddyCard.Init(cardId, buddyCardData);
		return squadBuddyCard;
	}

	private CardBuddy GetSquadBuddyCard(string cardId)
	{
		foreach (CardBuddy item in mBuddyCardsSquad)
		{
			if (item.id == cardId)
			{
				return item;
			}
		}
		foreach (CardBuddy item2 in mBuddyCardsSquad)
		{
			if (item2.amount == 0)
			{
				return item2;
			}
		}
		CardBuddy cardBuddy = UnityEngine.Object.Instantiate(mCardBuddyPrefab);
		cardBuddy.gameObject.name = $"Squad Buddy Warcard {mBuddyCardsSquad.Count + 1}";
		cardBuddy.gameObject.transform.parent = mSquadCardsParent;
		mBuddyCardsSquad.Add(cardBuddy);
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("ADDING SQUAD BUDDY WARCARD " + cardId);
		}
		return cardBuddy;
	}

	public void ResetSquadCards(List<string> keepBuddies = null)
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("RESETING SQUAD WARCARDS");
		}
		if (keepBuddies == null)
		{
			foreach (CardBuddy item in mBuddyCardsSquad)
			{
				item.DestroyCard();
				item.Init(string.Empty, new BuddyCardData
				{
					amount = 0
				});
			}
			return;
		}
		CardBuddy cardBuddy;
		foreach (CardBuddy item2 in mBuddyCardsSquad)
		{
			cardBuddy = item2;
			if (keepBuddies.FindIndex((string cardId) => cardId == cardBuddy.id) < 0)
			{
				cardBuddy.DestroyCard();
				cardBuddy.Init(string.Empty, new BuddyCardData
				{
					amount = 0
				});
			}
		}
	}

	public static void AddCardForWinner()
	{
		CardConstants cardConstants = Singleton<GameVariables>.instance.cardConstants;
		float num = 0f;
		float fLOATVALUE = cardConstants.GetRow(CardConstants.rowIds.ChanceToGetcard1MaxLevel).FLOATVALUE;
		float fLOATVALUE2 = cardConstants.GetRow(CardConstants.rowIds.ChanceToGetcard2MaxLevel).FLOATVALUE;
		int displayNumber = LevelManager.instance.currentLevel.displayNumber;
		num = (((float)displayNumber <= fLOATVALUE) ? cardConstants.GetRow(CardConstants.rowIds.ChanceToGetCard1).FLOATVALUE : ((!((float)displayNumber <= fLOATVALUE2)) ? cardConstants.GetRow(CardConstants.rowIds.ChanceToGetCard3).FLOATVALUE : cardConstants.GetRow(CardConstants.rowIds.ChanceToGetCard2).FLOATVALUE));
		float value = UnityEngine.Random.value;
		if (value <= num && !LevelManager.instance.isWarcardsLocked && !TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			instance.AddRandomCardDuringGame();
		}
	}

	internal int BuddyCardChosen()
	{
		foreach (Card mUsedCard in mUsedCards)
		{
			if (mUsedCard.isBuddyCard)
			{
				return 1;
			}
		}
		foreach (Card item in cardsForGame)
		{
			if (item.isBuddyCard)
			{
				return 1;
			}
		}
		return 0;
	}

	internal int BuddyCardsOwned()
	{
		return data.buddyCardData.Count;
	}

	internal int BuddyCardPlayed()
	{
		int num = 0;
		foreach (Card mUsedCard in mUsedCards)
		{
			if (mUsedCard.isBuddyCard)
			{
				num++;
			}
		}
		return num;
	}

	public bool TutorialWarcardPlayed(int index)
	{
		bool flag = false;
		if (Singleton<GameController>.instance.gameControllerTutorial.tutorialCards != null && Singleton<GameController>.instance.gameControllerTutorial.tutorialCards.Count > index && Singleton<GameController>.instance.gameControllerTutorial.tutorialCards[index] != null)
		{
			for (int i = 0; i < cardUsedByMe.Count; i++)
			{
				flag |= cardUsedByMe[i].id == Singleton<GameController>.instance.gameControllerTutorial.tutorialCards[index].id;
			}
		}
		return flag;
	}
}
