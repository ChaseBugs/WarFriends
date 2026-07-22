using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Scripting;

[ExecuteInEditMode]
public class CardManager : DatabaseSerializedObjectGeneric<CardManager.CardManagerData>, BNAICKJBHFH
{
	public enum CardType
	{
		Bronze = 1,
		Silver,
		Gold,
		Buddy
	}

	[Flags]
	public enum CardFilter
	{
		None = 0,
		Bronze = 1,
		Silver = 2,
		Gold = 4,
		Buddy = 8,
		Preselected = 0x10,
		Random = 0x20,
		All = 0xFFFFFF
	}

	[Preserve]
	public class CardData
	{
		public int amount;
	}

	[Serializable]
	[Preserve]
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

	[Preserve]
	public class CardManagerData
	{
		public Dictionary<string, CardData> cardData;

		public Dictionary<string, BuddyCardData> buddyCardData;

		public int nextWithdraw;

		public int nextBuddyDeposit;

		public bool extraSlot;

		public int GetCardAmount()
		{
			return 0;
		}
	}

	public List<Card> cards;

	public List<Card> obtainedCards;

	public List<Card> enemyCards;

	public List<Card> cardUsedByMe;

	[SerializeField]
	private CardBuddy mCardBuddyPrefab;

	private List<CardBuddy> mBuddyCards;

	private List<CardBuddy> mBuddyCardsSquad;

	private Transform mSquadCardsParent;

	private Dictionary<string, Card> mCardDictionary;

	[HideInInspector]
	public List<Card> cardsByRarity;

	public static int LowLevelTreshold;

	public static int HighLevelTreshold;

	public Action<string[], int> WarcardRewardClaimed;

	private static CardManager mInstance;

	public CardDefinitions cardDefinitions;

	private PhotonView mPhotonView;

	private float mCooldown;

	private float mNextTime;

	private Dictionary<CardType, List<Card>> mCardsByQuality;

	private Dictionary<string, Card> mOtherPlayerCards;

	private List<Card> mUsedCards;

	private bool mCardUseInProgress;

	private string mIdLastGainedCard;

	private List<CardBuddy> mOtherBuddyCards;

	private CardBuddy mBuddyCard;

	public List<Card> cardsForGame => null;

	public Card withdrawingCard { get; set; }

	public bool canUseCards => false;

	public int numOfBuddyCards => 0;

	public int cardsInPack => 0;

	public int bronzePackBronzeCards => 0;

	public CardType bronzePackMin => default(CardType);

	public CardType bronzePackMax => default(CardType);

	public int silverPackSilverCards => 0;

	public CardType silverPackMin => default(CardType);

	public CardType silverPackMax => default(CardType);

	public int goldPackGoldCards => 0;

	public CardType goldPackMin => default(CardType);

	public CardType goldPackMax => default(CardType);

	public int nextWithdraw
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int nextBuddyDeposit
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool isWithdrawAvailable => false;

	public bool canWithdrawBuddy => false;

	public bool isBuddyDepositAvailable => false;

	public bool extraSlot => false;

	public static CardManager instance => null;

	public PlayerWeapon grenadeSaved { get; set; }

	public PlayerWeapon savedWeapon { get; set; }

	public float timeLockWeaponSwitch { get; set; }

	public Card CurrentCard => null;

	public bool NoMoreCards => false;

	public float Progress => 0f;

	public CardBuddy buddyCard
	{
		get
		{
			return null;
		}
		private set
		{
		}
	}

	public static float availableLengthInSmallCard => 0f;

	public string selectedCards => null;

	public List<Tuple<string, BuddyCardData>> selectedBuddyCards => null;

	public Dictionary<CardType, List<Card>> cardsByQuality
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public event Action<Card, HPHFGNJPDKN, bool> CardUsed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<bool> OnSyncWithServer
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action ErrorHappened
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<Card> OnCardGainedInGame
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action CardPackBought
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action WithdrawTimeChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static CardFilter GetFilter(CardType cardType)
	{
		return default(CardFilter);
	}

	public Card GetCardInstanceAll(string cardId, bool isCurrentPlayer = true)
	{
		return null;
	}

	public Card GetCardInstance(string cardId, bool isCurrentPlayer = true)
	{
		return null;
	}

	public bool IsCardId(string cardId)
	{
		return false;
	}

	public void OnDestroy()
	{
	}

	protected override void Awake()
	{
	}

	public bool CardsForGameContains(Card card)
	{
		return false;
	}

	private int GetRandomRarity(CardType guaranteedRarity = CardType.Bronze, CardType maxRarity = CardType.Gold)
	{
		return 0;
	}

	public Card AddRandomCard(CardType guaranteedRarity = CardType.Bronze, CardType maxRarity = CardType.Gold)
	{
		return null;
	}

	public Card AddRarityCard(CardType rarity)
	{
		return null;
	}

	public Card AddRandomCardDuringGame()
	{
		return null;
	}

	public void CardWasUsed(Card card, HPHFGNJPDKN fraction)
	{
	}

	public void LoadData(JToken cardData)
	{
	}

	public void LoadData(string cardData)
	{
	}

	public void ShowCardBotPlayed(Card card, HPHFGNJPDKN fraction)
	{
	}

	internal void AddMultipleCards(string cardId, int num)
	{
	}

	internal Card AddCard(string cardId)
	{
		return null;
	}

	public void UseCard(Card card)
	{
	}

	public Card[] BuyThreeCards(int warbucks)
	{
		return null;
	}

	internal int[] GetRarityCounts()
	{
		return null;
	}

	public int GetWarcardsCount(CardType rarity)
	{
		return 0;
	}

	internal Card[] BuyCardPack(HFOMMJIMIGN cardTypePack, int warbucks, int gold, int discount)
	{
		return null;
	}

	public void CardPackBoughtEvent()
	{
	}

	public Card[] GetCardsFromCardpack(CardType typeCardpack)
	{
		return null;
	}

	internal void ClearCardsForGame()
	{
	}

	[PunRPC]
	private void CardWasUsedOnline(string cardId, byte fraction, int playerID)
	{
	}

	private void InitCards()
	{
	}

	public void InitializeBuddyWarcard()
	{
	}

	public void ActualizeBuddyWarcardTime()
	{
	}

	private int SortByRarity(Card c1, Card c2)
	{
		return 0;
	}

	private void InstanceOnGameEnded(GameController.ALOAMODMHMO gameEndReason)
	{
	}

	private void InstanceOnGameStarted()
	{
	}

	private void OnPlayerDataLoaded()
	{
	}

	[PunRPC]
	private void PlayCardRPC(string id, byte fraction, int playerId)
	{
	}

	public string GetUsedBuddyCardData()
	{
		return null;
	}

	internal string GetUsedCards()
	{
		return null;
	}

	public int GetUsedCardsCount()
	{
		return 0;
	}

	internal string GetObtainedCards()
	{
		return null;
	}

	public Card RecentGainedCard()
	{
		return null;
	}

	public IEnumerator InitGameCards(string chosenCards, bool isOpponnetCard, bool isCurrentPlayer)
	{
		return null;
	}

	public void ReleaseCards(string chosenCards, bool isOpponnetCard, bool isCurrentPlayer)
	{
	}

	public static CardType CardRarityConverter(int rarity)
	{
		return default(CardType);
	}

	public void DebugAddEveryCard()
	{
	}

	public Card AddMineBuddyCardTest()
	{
		return null;
	}

	private CardBuddy GetEmptyBuddyCard(out bool exists)
	{
		exists = default(bool);
		return null;
	}

	public Card AddBuddyCard(string id, BuddyCardData buddyCardData)
	{
		return null;
	}

	public List<CardBuddy> SetBuddyCardsOher(List<Tuple<string, BuddyCardData>> buddyCards)
	{
		return null;
	}

	public Card GetSquadCardInstance(string cardId, BuddyCardData buddyCardData = null)
	{
		return null;
	}

	private CardBuddy GetSquadBuddyCard(string cardId)
	{
		return null;
	}

	public void ResetSquadCards(List<string> keepBuddies = null)
	{
	}

	public static void AddCardForWinner()
	{
	}

	internal int BuddyCardChosen()
	{
		return 0;
	}

	internal int BuddyCardsOwned()
	{
		return 0;
	}

	internal int BuddyCardPlayed()
	{
		return 0;
	}

	public bool TutorialWarcardPlayed(int index)
	{
		return false;
	}

	private void OnCooldownCoefficientChanged(float newValue, float oldValue)
	{
	}
}
