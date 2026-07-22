using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;
using WarFriends.Legacy;

[ExecuteInEditMode]
public class CamosManager : DatabaseSerializedObjectGeneric<CamosManager.DecalManagerData>
{
	public class DecalManagerData
	{
		public Dictionary<string, SavedPlayerVisual> visuals = new Dictionary<string, SavedPlayerVisual>();

		public Dictionary<int, SavedPlayerVisualSlot> slots = new Dictionary<int, SavedPlayerVisualSlot>();

		public string previousHeadDecal = string.Empty;
	}

	public class SavedPlayerVisualSlot
	{
		public string equippedID;
	}

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

	private sealed class BPDPFLADPLN : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<PlayerVisualCategory>.Enumerator KFCAECGLKKO;

		internal PlayerVisualCategory JNNIIODOFIF;

		internal CamosManager BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.playerVisualCategories.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							JNNIIODOFIF = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JNNIIODOFIF.PrepareAssets());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00c4:
				return true;
			}
		}

		public bool ILNBJIJONKD()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.playerVisualCategories.GetEnumerator();
				num = 62u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							JNNIIODOFIF = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JNNIIODOFIF.PrepareAssets());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00c4:
				return true;
			}
		}

		public void EPKPNKGJHEC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void ENENMOAOOBG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public void IFLGJMJCOMC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void CPDBCJLIGFN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public bool LGNMOMFLLPP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.playerVisualCategories.GetEnumerator();
				num = 13u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							JNNIIODOFIF = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JNNIIODOFIF.PrepareAssets());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00c4:
				return false;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public void HCJOIAHBFGB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public void OCBFBEMDMMJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public BPDPFLADPLN()
		{
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public bool GBHCODKDPBO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.playerVisualCategories.GetEnumerator();
				num = 4294967179u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							JNNIIODOFIF = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JNNIIODOFIF.PrepareAssets());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00c4:
				return true;
			}
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public bool JMCPAKBLPML()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.playerVisualCategories.GetEnumerator();
				num = 4u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							JNNIIODOFIF = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JNNIIODOFIF.PrepareAssets());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00c4:
				return false;
			}
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public bool NIGJJBALHDN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.playerVisualCategories.GetEnumerator();
				num = 4294967239u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							JNNIIODOFIF = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JNNIIODOFIF.PrepareAssets());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00c4:
				return true;
			}
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public void OPMABIIDKCN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}
	}

	private static CamosManager mInstance;

	public List<PlayerVisualCategory> playerVisualCategories;

	public PlayerController mainPlayer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private PlayerVisuals _003Cvisuals_003Ek__BackingField;

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
			mInstance = mInstance ?? ((CamosManager)SingletonSupport.FindOrCreate(typeof(CamosManager)));
			return mInstance;
		}
	}

	public PlayerVisuals visuals
	{
		[CompilerGenerated]
		get
		{
			return _003Cvisuals_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003Cvisuals_003Ek__BackingField = value;
		}
	}

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
				allVisual.JDLGJNAIFMM();
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
					equippedID = playerVisualCategory.EGKNDPKCHPC + text
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

	public void ApplyVisuals(KMNCIJPDFPJ character, bool useHighRes)
	{
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			playerVisualCategory.equippedVisual.MNEEDLCGAFN(character, useHighRes);
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

	public void ApplyVisuals(KMNCIJPDFPJ playerController, string[] indices, bool useHighRes = false)
	{
		if (indices == null)
		{
			UnityEngine.Debug.LogError("ApplyVisuals Error, indices are null!");
			return;
		}
		for (int i = 0; i < playerVisualCategories.Count; i++)
		{
			PlayerVisualCategory playerVisualCategory = playerVisualCategories[i];
			PlayerVisual playerVisual = playerVisualCategory[indices[i]];
			playerVisual.MNEEDLCGAFN(playerController, useHighRes);
			playerController.playerVisuals[i] = indices[i];
		}
		UpdateVisuals(playerController);
	}

	public void ApplyVisuals(KMNCIJPDFPJ playerController, Dictionary<int, SavedPlayerVisualSlot> playerVisuals, bool useHighRes = false)
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
			playerVisual?.FHPICBCCOAO();
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
				allVisual.MBHMIBGFPEG();
			}
		}
	}

	public void LoadAll()
	{
		foreach (PlayerVisualCategory playerVisualCategory in playerVisualCategories)
		{
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				allVisual.EMLFJBOLENO();
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

	public Dictionary<PlayerVisual.EJHADIHBCBK, int> GetItemsCountByRarity(List<CCNAEIGGMNK> lootboxes)
	{
		Dictionary<PlayerVisual.EJHADIHBCBK, int> dictionary = new Dictionary<PlayerVisual.EJHADIHBCBK, int>();
		dictionary.Add(PlayerVisual.EJHADIHBCBK.Common, 0);
		dictionary.Add(PlayerVisual.EJHADIHBCBK.Uncommon, 0);
		dictionary.Add(PlayerVisual.EJHADIHBCBK.Rare, 0);
		dictionary.Add(PlayerVisual.EJHADIHBCBK.Epic, 0);
		dictionary.Add(PlayerVisual.EJHADIHBCBK.Legendary, 0);
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
					dictionary[allVisual.rarity]++;
					continue;
				}
				string nAME = allVisual.row.NAME;
				int num = allVisual.numberOfParts;
				foreach (CCNAEIGGMNK lootbox in lootboxes)
				{
					if (lootbox.HJAJAAMHKKG == nAME)
					{
						num += lootbox.AMEELJHHGKP;
					}
				}
				if (num >= allVisual.numberOfPartsMax)
				{
					dictionary[allVisual.rarity]++;
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

	[DebuggerHidden]
	public IEnumerator PrepareAssets()
	{
		BPDPFLADPLN bPDPFLADPLN = new BPDPFLADPLN();
		bPDPFLADPLN.BJGCPDNMHDH = this;
		return bPDPFLADPLN;
	}

	public void UpdateVisuals(KMNCIJPDFPJ playerController)
	{
		string iNFLHPGMEOB = playerController.playerVisuals[0];
		string text = playerController.playerVisuals[1];
		string text2 = playerController.playerVisuals[2];
		GetVisualVisibility(text, text2, out var helmetHidden, out var headAccesoryHidden);
		PlayerVisualCategoryCamos.PlayerVisualCamo pAFBOGDNAFF = playerVisualCategories[0][iNFLHPGMEOB] as PlayerVisualCategoryCamos.PlayerVisualCamo;
		PlayerVisualCategoryHelmets.PlayerVisualHelmet playerVisualHelmet = playerVisualCategories[1][text] as PlayerVisualCategoryHelmets.PlayerVisualHelmet;
		playerVisualHelmet.MNEEDLCGAFN(playerController);
		playerVisualCategories[2][text2].MNEEDLCGAFN(playerController);
		if (helmetHidden)
		{
			playerController.meshChanger.LJBKNMJBPEG.Hide();
		}
		if (headAccesoryHidden)
		{
			playerController.meshChanger.AKPKJMNGFIE.HideAllAttachments();
		}
		playerController.meshChanger.ChangeHair(pAFBOGDNAFF, playerVisualHelmet.hairIndex);
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
