using System;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
public class SavingLastSelected : InGameSerializedObjectGeneric<SavingLastSelected.SaveData>
{
	[Skip]
	public class SaveData
	{
		public bool endOfFirstGame;

		public string selectedArmy;

		public Dictionary<string, int> selectedSlotArmy;

		public Dictionary<string, bool> usedInGame = new Dictionary<string, bool>();

		public int lastCategoryIndex;

		public List<string> selectedWeapons;

		public Dictionary<string, int> selectedSlotWeapon;

		public int lastVisualCategoryIndex;

		public List<string> selectedVisuals;

		public List<string> selectedCards = new List<string>();

		public List<string> selectedCardsWarArena = new List<string>();

		public List<Tuple<int, string>> usedBotNames = new List<Tuple<int, string>>();

		public int leaderboardTab;

		public int lastViewedStarterAssignmentId;

		public bool goldCardCrafted;
	}

	private static SavingLastSelected mInstance;

	public static SavingLastSelected instance
	{
		get
		{
			mInstance = mInstance ?? ((SavingLastSelected)UnityEngine.Object.FindObjectsOfType(typeof(SavingLastSelected))[0]);
			return mInstance;
		}
	}

	public bool firstTutorialGameEnded
	{
		get
		{
			return data != null && data.endOfFirstGame;
		}
		set
		{
			if (data.endOfFirstGame != value)
			{
				data.endOfFirstGame = value;
				Save();
			}
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		firstTutorialGameEnded = true;
		SaveSelectedCards();
	}

	public void SaveSelectedCards()
	{
		data.selectedCards = new List<string>();
		data.selectedCardsWarArena = new List<string>();
		foreach (Card item in Singleton<GameController>.instance.gameControllerDeathMatch.cardsForGame)
		{
			data.selectedCards.Add(item.id);
		}
		foreach (Card item2 in Singleton<GameController>.instance.gameControllerWarArena.cardsForGame)
		{
			data.selectedCardsWarArena.Add(item2.id);
		}
		Save();
	}

	public void LoadSelectedCards()
	{
		Singleton<GameController>.instance.gameControllerDeathMatch.cardsForGame = new List<Card>();
		foreach (string selectedCard in data.selectedCards)
		{
			Card cardInstance = CardManager.instance.GetCardInstance(selectedCard);
			if (cardInstance != null)
			{
				Singleton<GameController>.instance.gameControllerDeathMatch.cardsForGame.Add(cardInstance);
			}
		}
		Singleton<GameController>.instance.gameControllerWarArena.cardsForGame = new List<Card>();
		foreach (string item in data.selectedCardsWarArena)
		{
			Card cardInstance2 = CardManager.instance.GetCardInstance(item);
			if (cardInstance2 != null)
			{
				Singleton<GameController>.instance.gameControllerWarArena.cardsForGame.Add(cardInstance2);
			}
		}
	}

	internal void StarterAssignmentViewed(StarterAssignment assignment)
	{
		data.lastViewedStarterAssignmentId = assignment.order;
		Save();
	}

	private void CheckExistingDictionary()
	{
		if (data.selectedSlotArmy == null)
		{
			data.selectedSlotArmy = new Dictionary<string, int>();
			Save();
		}
		if (data.selectedSlotWeapon == null)
		{
			data.selectedSlotWeapon = new Dictionary<string, int>();
			Save();
		}
		if (data.selectedWeapons == null)
		{
			data.selectedWeapons = new List<string>();
			data.selectedWeapons.Add(string.Empty);
			data.selectedWeapons.Add(string.Empty);
			data.selectedWeapons.Add(string.Empty);
			data.selectedWeapons.Add(string.Empty);
			Save();
		}
		if (data.selectedVisuals == null)
		{
			data.selectedVisuals = new List<string>();
			data.selectedVisuals.Add(string.Empty);
			data.selectedVisuals.Add(string.Empty);
			data.selectedVisuals.Add(string.Empty);
			data.selectedVisuals.Add(string.Empty);
			Save();
		}
	}

	public void SaveLastUnit(LevelBehaviour behaviour)
	{
		if (behaviour == null)
		{
			Debug.LogError("Null cannot be saved as last unit.");
			return;
		}
		data.selectedArmy = behaviour.unitDictionaryId;
		Save();
	}

	public void SaveLastWeapon(WeaponLevelsSetup setup)
	{
		CheckExistingDictionary();
		if (setup == null)
		{
			Debug.LogError("Null cannot be saved as last weapon.");
			return;
		}
		if (setup.weaponCategory == (setup.weaponCategory & WeaponCategory.Primary))
		{
			data.lastCategoryIndex = 0;
		}
		else if (setup.weaponCategory == (setup.weaponCategory & WeaponCategory.Special))
		{
			data.lastCategoryIndex = 1;
		}
		else if (setup.weaponCategory == (setup.weaponCategory & WeaponCategory.Explosive))
		{
			data.lastCategoryIndex = 2;
		}
		else
		{
			data.lastCategoryIndex = 3;
		}
		data.selectedWeapons[data.lastCategoryIndex] = setup.weaponDictionaryId;
		Save();
	}

	public void SaveLastVisual(PlayerVisual visual)
	{
		CheckExistingDictionary();
		if (visual == null)
		{
			Debug.LogError("Null cannot be saved as last customization.");
			return;
		}
		for (int i = 0; i < CamosManager.instance.playerVisualCategories.Count; i++)
		{
			if (visual.owner == CamosManager.instance.playerVisualCategories[i])
			{
				data.lastVisualCategoryIndex = i;
			}
		}
		data.selectedVisuals[data.lastVisualCategoryIndex] = visual.id;
		Save();
	}

	public LevelBehaviour GetLastUnit()
	{
		if (string.IsNullOrEmpty(data.selectedArmy))
		{
			return null;
		}
		int num = LevelManager.instance.behaviours.FindIndex((LevelBehaviour behav) => behav.unitDictionaryId == data.selectedArmy);
		if (num == -1)
		{
			return null;
		}
		return LevelManager.instance.behaviours[num];
	}

	public WeaponLevelsSetup GetLastWeapon()
	{
		if (data.selectedWeapons == null)
		{
			return null;
		}
		int num = LevelManager.instance.weaponLevelsSetups.FindIndex((WeaponLevelsSetup setup) => setup.weaponDictionaryId == data.selectedWeapons[data.lastCategoryIndex]);
		if (num == -1)
		{
			return null;
		}
		return LevelManager.instance.weaponLevelsSetups[num];
	}

	public WeaponLevelsSetup GetLastWeaponForIndex(int categ)
	{
		if (data.selectedWeapons == null || categ < 0 || categ >= data.selectedWeapons.Count)
		{
			return null;
		}
		int num = LevelManager.instance.weaponLevelsSetups.FindIndex((WeaponLevelsSetup setup) => setup.weaponDictionaryId == data.selectedWeapons[categ]);
		if (num == -1)
		{
			return null;
		}
		data.lastCategoryIndex = categ;
		Save();
		return LevelManager.instance.weaponLevelsSetups[num];
	}

	public bool WasBotNameUsed(string botName)
	{
		foreach (Tuple<int, string> usedBotName in data.usedBotNames)
		{
			if (botName == usedBotName.Value2)
			{
				return true;
			}
		}
		return false;
	}

	public void AddUsedBotName(string botName)
	{
		Tuple<int, string> item = new Tuple<int, string>(Singleton<BeanstalkServerManager>.instance.currentTimestamp, botName);
		List<Tuple<int, string>> list = new List<Tuple<int, string>>();
		DateTime currentDateTime = Singleton<BeanstalkServerManager>.instance.currentDateTime;
		foreach (Tuple<int, string> usedBotName in data.usedBotNames)
		{
			DateTime dateTime = MiscTools.GetDateTime(usedBotName.Value1);
			if ((currentDateTime - dateTime).TotalHours < 24.0)
			{
				list.Add(usedBotName);
			}
		}
		list.Add(item);
		data.usedBotNames = list;
		Save();
	}

	public PlayerVisual GetLastVisual()
	{
		if (data.selectedVisuals == null)
		{
			return null;
		}
		foreach (PlayerVisualCategory playerVisualCategory in CamosManager.instance.playerVisualCategories)
		{
			if (playerVisualCategory is PlayerVisualCategoryPowerBands)
			{
				continue;
			}
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				if (allVisual.id == data.selectedVisuals[data.lastVisualCategoryIndex])
				{
					return allVisual;
				}
			}
		}
		return null;
	}

	public PlayerVisual GetLastVisualForIndex(int categ)
	{
		if (data.selectedVisuals == null || categ < 0 || categ >= data.selectedVisuals.Count)
		{
			return null;
		}
		foreach (PlayerVisual allVisual in CamosManager.instance.playerVisualCategories[categ].allVisuals)
		{
			if (allVisual.id == data.selectedVisuals[categ])
			{
				data.lastVisualCategoryIndex = categ;
				Save();
				return allVisual;
			}
		}
		return null;
	}

	public void SaveLastLeaderboardTab(int tabIndex)
	{
		data.leaderboardTab = tabIndex;
		Save();
	}

	public int GetLastLeaderboardTab()
	{
		return (data != null) ? data.leaderboardTab : 0;
	}
}
