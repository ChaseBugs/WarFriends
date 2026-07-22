using System;
using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;
using UnityEngine.Scripting;

[ExecuteInEditMode]
public class CamosManager : DatabaseSerializedObjectGeneric<CamosManager.DecalManagerData>
{
	[Preserve]
	public class DecalManagerData
	{
		public Dictionary<string, SavedPlayerVisual> visuals;

		public Dictionary<int, SavedPlayerVisualSlot> slots;

		public string previousHeadDecal;
	}

	[Preserve]
	public class SavedPlayerVisualSlot
	{
		public string equippedID;
	}

	[Preserve]
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

	private List<PlayerVisual> mVisualsSortedByLevel;

	private PlayerVisualsRarities mPlayerVisualsRarities;

	public bool loadPaths;

	private bool mAssetsPrepared;

	public static CamosManager instance => null;

	public PlayerVisuals visuals { get; private set; }

	public PlayerVisualsRarities playerVisualsRarities => null;

	public List<PlayerVisual> visualsSortedByLevel => null;

	public PlayerVisuals getPlayerVisualsSafety => null;

	public string[] equppedIndices => null;

	public void OnDestroy()
	{
	}

	protected override void Awake()
	{
	}

	protected void Update()
	{
	}

	private void OnPlayerDataLoaded()
	{
	}

	public string[] GetDefault()
	{
		return null;
	}

	public void ApplyVisuals(AFIKFLMIBBA character, bool useHighRes)
	{
	}

	public string[] ConvertVisuals(int[] indices)
	{
		return null;
	}

	public void ApplyVisuals(AFIKFLMIBBA playerController, string[] indices, bool useHighRes = false)
	{
	}

	public void ApplyVisuals(AFIKFLMIBBA playerController, Dictionary<int, SavedPlayerVisualSlot> playerVisuals, bool useHighRes = false)
	{
	}

	internal void LoadData(string decalData)
	{
	}

	public void CheckEquippedPowerBand()
	{
	}

	public void CheckEquippedHelmet(bool forceUpdateCamoScreen = false)
	{
	}

	public void Null()
	{
	}

	public void LoadAll()
	{
	}

	public PlayerVisual GetVisual(string idVisual)
	{
		return null;
	}

	public Dictionary<PlayerVisual.BJLIFLPNINI, int> GetItemsCountByRarity(List<FPMGOANDNKO> lootboxes)
	{
		return null;
	}

	public PlayerVisual GetPowerBand(string idVisual)
	{
		return null;
	}

	public IEnumerator PrepareAssets()
	{
		return null;
	}

	public void UpdateVisuals(AFIKFLMIBBA playerController)
	{
	}

	public void GetVisualVisibility(string helmetId, string headAccesoryId, out bool helmetHidden, out bool headAccesoryHidden)
	{
		helmetHidden = default(bool);
		headAccesoryHidden = default(bool);
	}

	public bool IsCamoIdPressent(string camoId)
	{
		return false;
	}

	public bool IsHelmetIdPressent(string helmetId)
	{
		return false;
	}

	public bool IsHeadAccessoriesIdPressent(string headAccessoriesId)
	{
		return false;
	}

	public bool IsPowerBandIdPressent(string powerBandId)
	{
		return false;
	}

	public PlayerVisual RandomPlayerVisual(int categoryNumber)
	{
		return null;
	}

	public bool IsPlayerVisual(string rowName)
	{
		return false;
	}

	public PlayerVisual EquippedPlayerVisual(int categoryNumber)
	{
		return null;
	}

	public SavedPlayerVisual GetSavedPlayerVisual(string visualId)
	{
		return null;
	}
}
