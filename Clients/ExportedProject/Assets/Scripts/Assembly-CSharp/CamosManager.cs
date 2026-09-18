using System;
using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

[ExecuteInEditMode]
[Skip]
public class CamosManager : DatabaseSerializedObjectGeneric<CamosManager.DecalManagerData>
{
	[Skip]
	public class DecalManagerData
	{
		public Dictionary<string, SavedPlayerVisual> visuals = new Dictionary<string, SavedPlayerVisual>();

		public Dictionary<int, SavedPlayerVisualSlot> slots = new Dictionary<int, SavedPlayerVisualSlot>();

		public string previousHeadDecal = string.Empty;
	}

	[Skip]
	public class SavedPlayerVisualSlot
	{
		public string equippedID;
	}

	[Skip]
	public class SavedPlayerVisual
	{
		public bool bought;

		public bool showed;

		public int expiresOn;

		public bool borrowed;

		public int parts;

		public bool notificate;
	}

	[Serializable]
	public class VisualVisibilityConfiguration
	{
		public string helmetId;

		public string headAccessoryId;

		public bool hideHelmet;

		public bool hideHeadAccesory;
	}

	[Serializable]
	public class CamoHairConfiguration
	{
		public string camoId;

		public string otherVisualId;

		public int hairIndex;
	}

	private static CamosManager mInstance;

	public List<PlayerVisualCategory> playerVisualCategories;

	public PlayerController mainPlayer;

	public List<VisualVisibilityConfiguration> visualVisibility;

	public List<CamoHairConfiguration> camoHairConfiguration;

	private List<PlayerVisual> mVisualsSortedByLevel = new List<PlayerVisual>();

	private PlayerVisualsRarities mPlayerVisualsRarities;

	public bool loadPaths;

	private bool mAssetsPrepared;

	public static CamosManager instance
	{
		get
		{
			mInstance = mInstance ?? ((CamosManager)UnityEngine.Object.FindObjectsOfType(typeof(CamosManager))[0]);
			return mInstance;
		}
	}

	public PlayerVisuals visuals { get; private set; }

	public PlayerVisualsRarities playerVisualsRarities => mPlayerVisualsRarities ?? (mPlayerVisualsRarities = GetComponent<PlayerVisualsRarities>());

	public List<PlayerVisual> visualsSortedByLevel => mVisualsSortedByLevel;

	public PlayerVisuals getPlayerVisualsSafety
	{
		get
		{
			if (visuals == null)
			{
				visuals = GetComponent<PlayerVisuals>();
			}
			return visuals;
		}
	}

	public string[] equppedIndices
	{
		get
		{
			CheckEquippedPowerBand();
			CheckEquippedHelmet();
			string[] array = new string[playerVisualCategories.Count];
			for (int i = 0; i < playerVisualCategories.Count; i++)
			{
				PlayerVisualCategory playerVisualCategory = playerVisualCategories[i];
				array[i] = playerVisualCategory.equippedVisual.id;
			}
			return array;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		if (Application.isPlaying)
		{
			Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OnPlayerDataLoaded;
			for (int i = 0; i < playerVisualCategories.Count; i++)
			{
				PlayerVisualCategory playerVisualCategory = playerVisualCategories[i];
				playerVisualCategory.categoryNumber = i;
			}
			LoadAll();
		}
		foreach (PlayerVisualCategory playerVisualCategory2 in playerVisualCategories)
		{
			playerVisualCategory2.SetVisualIds();
		}
	}

	protected void Update()
	{
		if (!loadPaths)
		{
			return;
		}
		loadPaths = false;
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				allVisual.LoadPathsForEditor();
			}
		}
	}

	private void OnPlayerDataLoaded()
	{
		visuals = GetComponent<PlayerVisuals>();
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			Dictionary<int, SavedPlayerVisualSlot> slots = data.slots;
			string text = string.Empty;
			using (IEnumerator<PlayerVisual> enumerator2 = playerVisualCategory.allVisuals.GetEnumerator())
			{
				if (enumerator2.MoveNext())
				{
					PlayerVisual current2 = enumerator2.Current;
					text = current2.visualName;
				}
			}
			if (!slots.ContainsKey(playerVisualCategory.categoryNumber))
			{
				slots[playerVisualCategory.categoryNumber] = new SavedPlayerVisualSlot
				{
					equippedID = playerVisualCategory.idPrefix + text
				};
			}
			playerVisualCategory.InitVisuals();
		}
		mVisualsSortedByLevel.Clear();
		foreach (PlayerVisualCategory playerVisualCategory2 in playerVisualCategories)
		{
			foreach (PlayerVisual allVisual in playerVisualCategory2.allVisuals)
			{
				mVisualsSortedByLevel.Add(allVisual);
			}
		}
		mVisualsSortedByLevel.Sort((PlayerVisual visual1, PlayerVisual visual2) => visual2.unlockLevelIndex.CompareTo(visual1.unlockLevelIndex));
	}

	public string[] GetDefault()
	{
		string[] array = new string[playerVisualCategories.Count];
		for (int i = 0; i < playerVisualCategories.Count; i++)
		{
			PlayerVisualCategory playerVisualCategory = playerVisualCategories[i];
			using (IEnumerator<PlayerVisual> enumerator = playerVisualCategory.allVisuals.GetEnumerator())
			{
			if (enumerator.MoveNext())
			{
				PlayerVisual current = enumerator.Current;
				array[i] = current.id;
			}
				}
}
		return array;
	}

	public void ApplyVisuals(ICharacter character, bool useHighRes)
	{
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			playerVisualCategory.equippedVisual.ApplyVisual(character, useHighRes);
		}
		UpdateVisuals(character);
	}

	public string[] ConvertVisuals(int[] indices)
	{
		string[] array = new string[indices.Length];
		for (int i = 0; i < indices.Length; i++)
		{
			int num = 0;
			foreach (PlayerVisual allVisual in playerVisualCategories[i].allVisuals)
			{
				if (num == indices[i])
				{
					array[i] = allVisual.id;
					break;
				}
				num++;
			}
		}
		return array;
	}

	public void ApplyVisuals(ICharacter playerController, string[] indices, bool useHighRes = false)
	{
		if (indices == null)
		{
			Debug.LogError("ApplyVisuals Error, indices are null!");
			return;
		}
		for (int i = 0; i < playerVisualCategories.Count; i++)
		{
			PlayerVisualCategory playerVisualCategory = playerVisualCategories[i];
			PlayerVisual playerVisual = playerVisualCategory[indices[i]];
			playerVisual.ApplyVisual(playerController, useHighRes);
			playerController.playerVisuals[i] = indices[i];
		}
		UpdateVisuals(playerController);
	}

	public void ApplyVisuals(ICharacter playerController, Dictionary<int, SavedPlayerVisualSlot> playerVisuals, bool useHighRes = false)
	{
		string[] array = GetDefault();
		if (playerVisuals != null)
		{
			foreach (KeyValuePair<int, SavedPlayerVisualSlot> playerVisual in playerVisuals)
			{
				array[playerVisual.Key] = playerVisual.Value.equippedID;
			}
		}
		ApplyVisuals(playerController, array, useHighRes);
	}

	internal void LoadData(string decalData)
	{
		SerializedObject = JsonConvert.DeserializeObject<DecalManagerData>(decalData);
		OnPlayerDataLoaded();
	}

	public void CheckEquippedPowerBand()
	{
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			if (!(playerVisualCategory is PlayerVisualCategoryPowerBands) || playerVisualCategory.equippedVisual.isBought)
			{
				continue;
			}
			PlayerVisual playerVisual = null;
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				if (allVisual.isBought)
				{
					playerVisual = allVisual;
				}
			}
			playerVisual?.Equip();
		}
	}

	public void CheckEquippedHelmet(bool forceUpdateCamoScreen = false)
	{
		if (data.slots == null || data.slots.Count < 1)
		{
			return;
		}
		PlayerVisual playerVisual = EquippedPlayerVisual(1);
		if (playerVisual != null && playerVisual.isFromArena && !playerVisual.isBought)
		{
			PlayerVisual visual = GetVisual(data.previousHeadDecal);
			if (visual == null)
			{
				visual = GetVisual("HELMETS_EMPTY");
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(visual);
			if (GuiScreenSingle<CamosScreen>.instance.isShowed)
			{
				GuiScreenSingle<CamosScreen>.instance.OnVisualChanged();
			}
		}
	}

	public void Null()
	{
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				allVisual.Null();
			}
		}
	}

	public void LoadAll()
	{
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				allVisual.Load();
			}
		}
	}

	public PlayerVisual GetVisual(string idVisual)
	{
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			if (playerVisualCategory is PlayerVisualCategoryPowerBands)
			{
				continue;
			}
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				if (allVisual.id == idVisual)
				{
					return allVisual;
				}
			}
		}
		return null;
	}

	public Dictionary<PlayerVisual.Rarity, int> GetItemsCountByRarity(List<LootboxContent> lootboxes)
	{
		Dictionary<PlayerVisual.Rarity, int> dictionary = new Dictionary<PlayerVisual.Rarity, int>();
		dictionary.Add(PlayerVisual.Rarity.Common, 0);
		dictionary.Add(PlayerVisual.Rarity.Uncommon, 0);
		dictionary.Add(PlayerVisual.Rarity.Rare, 0);
		dictionary.Add(PlayerVisual.Rarity.Epic, 0);
		dictionary.Add(PlayerVisual.Rarity.Legendary, 0);
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			if (playerVisualCategory is PlayerVisualCategoryPowerBands)
			{
				continue;
			}
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				if (allVisual.numberOfPartsMax <= 0)
				{
					continue;
				}
				if (allVisual.numberOfParts >= allVisual.numberOfPartsMax)
				{
					Dictionary<PlayerVisual.Rarity, int> dictionary3;
					Dictionary<PlayerVisual.Rarity, int> dictionary2 = (dictionary3 = dictionary);
					PlayerVisual.Rarity rarity;
					PlayerVisual.Rarity key = (rarity = allVisual.rarity);
					int num = dictionary3[rarity];
					dictionary2[key] = num + 1;
					continue;
				}
				string nAME = allVisual.row.NAME;
				int num2 = allVisual.numberOfParts;
				foreach (LootboxContent lootbox in lootboxes)
				{
					if (lootbox.visualId == nAME)
					{
						num2 += lootbox.parts;
					}
				}
				if (num2 >= allVisual.numberOfPartsMax)
				{
					Dictionary<PlayerVisual.Rarity, int> dictionary5;
					Dictionary<PlayerVisual.Rarity, int> dictionary4 = (dictionary5 = dictionary);
					PlayerVisual.Rarity rarity;
					PlayerVisual.Rarity key2 = (rarity = allVisual.rarity);
					int num = dictionary5[rarity];
					dictionary4[key2] = num + 1;
				}
			}
		}
		return dictionary;
	}

	public PlayerVisual GetPowerBand(string idVisual)
	{
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			if (!(playerVisualCategory is PlayerVisualCategoryPowerBands))
			{
				continue;
			}
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				if (allVisual.id == idVisual)
				{
					return allVisual;
				}
			}
		}
		return null;
	}

	public IEnumerator PrepareAssets()
	{
		foreach (PlayerVisualCategory category in playerVisualCategories)
		{
			yield return StartCoroutine(category.PrepareAssets());
		}
	}

	public void UpdateVisuals(ICharacter playerController)
	{
		string id = playerController.playerVisuals[0];
		string text = playerController.playerVisuals[1];
		string text2 = playerController.playerVisuals[2];
		GetVisualVisibility(text, text2, out var helmetHidden, out var headAccesoryHidden);
		PlayerVisualCategoryCamos.PlayerVisualCamo camo = playerVisualCategories[0][id] as PlayerVisualCategoryCamos.PlayerVisualCamo;
		PlayerVisualCategoryHelmets.PlayerVisualHelmet playerVisualHelmet = playerVisualCategories[1][text] as PlayerVisualCategoryHelmets.PlayerVisualHelmet;
		playerVisualHelmet.ApplyVisual(playerController);
		playerVisualCategories[2][text2].ApplyVisual(playerController);
		if (helmetHidden)
		{
			playerController.meshChanger.helmet.Hide();
		}
		if (headAccesoryHidden)
		{
			playerController.meshChanger.helmetAttachments.HideAllAttachments();
		}
		playerController.meshChanger.ChangeHair(camo, playerVisualHelmet.hairIndex);
	}

	public void GetVisualVisibility(string helmetId, string headAccesoryId, out bool helmetHidden, out bool headAccesoryHidden)
	{
		foreach (VisualVisibilityConfiguration item in visualVisibility)
		{
			if (helmetId == item.helmetId && headAccesoryId == item.headAccessoryId)
			{
				helmetHidden = item.hideHelmet;
				headAccesoryHidden = item.hideHeadAccesory;
				return;
			}
		}
		helmetHidden = false;
		headAccesoryHidden = false;
	}

	public bool IsCamoIdPressent(string camoId)
	{
		foreach (PlayerVisual allVisual in playerVisualCategories[0].allVisuals)
		{
			if (allVisual.id == camoId)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsHelmetIdPressent(string helmetId)
	{
		foreach (PlayerVisual allVisual in playerVisualCategories[1].allVisuals)
		{
			if (allVisual.id == helmetId)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsHeadAccessoriesIdPressent(string headAccessoriesId)
	{
		foreach (PlayerVisual allVisual in playerVisualCategories[2].allVisuals)
		{
			if (allVisual.id == headAccessoriesId)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsPowerBandIdPressent(string powerBandId)
	{
		foreach (PlayerVisual allVisual in playerVisualCategories[3].allVisuals)
		{
			if (allVisual.id == powerBandId)
			{
				return true;
			}
		}
		return false;
	}

	public PlayerVisual RandomPlayerVisual(int categoryNumber)
	{
		if (categoryNumber < 0 || categoryNumber > playerVisualCategories.Count)
		{
			return null;
		}
		int num = 0;
		foreach (PlayerVisual allVisual in playerVisualCategories[categoryNumber].allVisuals)
		{
			num++;
		}
		if (num == 0)
		{
			return null;
		}
		int num2 = UnityEngine.Random.Range(0, num);
		int num3 = 0;
		foreach (PlayerVisual allVisual2 in playerVisualCategories[categoryNumber].allVisuals)
		{
			if (num3 == num2)
			{
				return allVisual2;
			}
			num3++;
		}
		return null;
	}

	public bool IsPlayerVisual(string rowName)
	{
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				if (allVisual.row.NAME == rowName)
				{
					return true;
				}
			}
		}
		return false;
	}

	public PlayerVisual EquippedPlayerVisual(int categoryNumber)
	{
		if (categoryNumber < 0 || categoryNumber > playerVisualCategories.Count)
		{
			return null;
		}
		return playerVisualCategories[categoryNumber].equippedVisual;
	}

	public SavedPlayerVisual GetSavedPlayerVisual(string visualId)
	{
		if (data.visuals.TryGetValue(visualId, out var value))
		{
			return value;
		}
		return null;
	}
}
