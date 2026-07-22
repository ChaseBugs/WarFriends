using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json;
using UnityEngine.Scripting;

public class AugmentationManager : DatabaseSerializedObjectGeneric<AugmentationManager.AugmentationData>
{
	public enum JJKEMOGCMGL
	{
		AttackSlot1,
		AttackSlot2,
		DefenseSlot1,
		DefenseSlot2,
		UtilitySlot1
	}

	public enum ENBIFKHMAGA
	{
		Common,
		Rare,
		Epic,
		Legendary
	}

	public enum GAEKEDEFBBG
	{
		Attack,
		Defense,
		Utility
	}

	[Preserve]
	public class AugmentationData
	{
		[JsonProperty]
		public string augIdEquippedInAttackSlot1;

		[JsonProperty]
		public string augIdEquippedInAttackSlot2;

		[JsonProperty]
		public string augIdEquippedInDefenseSlot1;

		[JsonProperty]
		public string augIdEquippedInDefenseSlot2;

		[JsonProperty]
		public string augIdEquippedInUtilitySlot1;

		public Dictionary<string, Augmentation> all;

		[JsonProperty]
		public bool tutorialComplete;

		[JsonProperty]
		public bool tutorialCrateClaimed;

		public bool augmentationShown;

		public void SetIdForSlot(JJKEMOGCMGL slot, string id)
		{
		}

		public string GetIdForSlot(JJKEMOGCMGL slot)
		{
			return null;
		}

		public List<Augmentation> GetInstalledAugmentations()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}

	[Serializable]
	[Preserve]
	public class Augmentation
	{
		[JsonProperty]
		public int effectId;

		[JsonProperty]
		public string triggerId;

		public int level;

		public int xp;

		public int augId;

		public AJHPODMFICL effectType
		{
			get
			{
				return default(AJHPODMFICL);
			}
			set
			{
			}
		}

		public override string ToString()
		{
			return null;
		}
	}

	private sealed class JCCJLCGGIJA
	{
		public AugmentationManager HNNCIECPFEJ;

		public PlayerController EHODJLJJAKB;

		internal DJLLCPELJDB DBJDCKOKEOE(Augmentation OEKEOADHEOB)
		{
			return null;
		}
	}

	private sealed class BONGGKMBFPI : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private int BDGCJCKMMEF;

		private int JCLIPFHDGAO;

		private IList<Augmentation> CJHHIAMDDKJ;

		public IList<Augmentation> AKAJMJLNLDE;

		int IEnumerator<int>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public BONGGKMBFPI(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	public static readonly Dictionary<WeaponCategory, string> OBFJEIDJDKO;

	public static AugmentationManager NALCBOIBJJF;

	private AugmentationEffects KDBFHENPAGO;

	private AugmentationTriggers JBKFPIDKKFI;

	private AugmentationEffectValues DGPIOFMAEEN;

	private AugmentationEffectMultipliers GFHPNMMBEAI;

	public AugmentationConstants JKKFNCGPKDL;

	private AugmentationCrates NJNLLFHLKKP;

	private AugmentationRarities IJFGOCLPOCI;

	private AugmentationLevels OHHOFDLDIJH;

	[CompilerGenerated]
	private Action<JJKEMOGCMGL, string> KGOGJFPABPB;

	[CompilerGenerated]
	private Action<JJKEMOGCMGL> BAPBJLDKAGN;

	[CompilerGenerated]
	private Action<string> BMMHFCDBBDE;

	public Action<Augmentation> LGCBOMGHPHB;

	public Action IHIGJIPMFIM;

	[NonSerialized]
	public List<DJLLCPELJDB> INDMMMNCFAJ;

	public List<DJLLCPELJDB> OGCJEMAFNNM;

	public List<ONNAEEJFLHK> allAugmentations => null;

	public bool hasCompletedTutorial
	{
		get
		{
			return false;
		}
		private set
		{
		}
	}

	public bool hasClaimedTutorialCrate
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int currentAugCount => 0;

	public int limitOfAugForGui => 0;

	public int limitOfAugForServer => 0;

	public int slot4UnlockLevel => 0;

	public int slot5UnlockLevel => 0;

	public float fusionCoef => 0f;

	public float xpValueMultiplier => 0f;

	public int winPoints => 0;

	public int losePoints => 0;

	public int cooldownAugCrateHours => 0;

	public bool canShowSecondTutorialDialog => false;

	public bool didShowSecondAugmentationDialog => false;

	public event Action<JJKEMOGCMGL, string> AugmentationInstalled
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

	public event Action<JJKEMOGCMGL> AugmentationExtracted
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

	public event Action<string> AugmentationFused
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

	private int BMKKBCHLALA(ONNAEEJFLHK OEKEOADHEOB, ONNAEEJFLHK EGMJAECMHBP)
	{
		return 0;
	}

	protected override void Awake()
	{
	}

	public int GetAugmentationMaxLevel(int GNNNEDJBMOH)
	{
		return 0;
	}

	public int GetTriggerMaxLevel(int GNNNEDJBMOH)
	{
		return 0;
	}

	public AugmentationTriggersRow GetTriggerConfigs(string PIABCCCHEGG)
	{
		return null;
	}

	public AugmentationEffectsRow GetEffectConfigs(AJHPODMFICL JPJLBLFBIGE)
	{
		return null;
	}

	public AugmentationCratesRow GetCrateConfig(BEFFDLMFIND HGMGAFFGLEN)
	{
		return null;
	}

	public int GetRarityChance(ENBIFKHMAGA GNNNEDJBMOH, BEFFDLMFIND HGMGAFFGLEN)
	{
		return 0;
	}

	public int GetAugLevelXp(ENBIFKHMAGA GNNNEDJBMOH, int MCFEIECJOFN)
	{
		return 0;
	}

	public float CalculateFuseXP(int FGMHGFEFLDC)
	{
		return 0f;
	}

	public bool IsInstalledAugmentation(string ILHCOEHJJIB)
	{
		return false;
	}

	public JJKEMOGCMGL InstalledInSlot(string ILHCOEHJJIB)
	{
		return default(JJKEMOGCMGL);
	}

	public List<AJHPODMFICL> GetAllEffects(JJKEMOGCMGL DHBBBJLNMPH)
	{
		return null;
	}

	public ENBIFKHMAGA GetRarityForEffect(AJHPODMFICL JPJLBLFBIGE)
	{
		return default(ENBIFKHMAGA);
	}

	public GAEKEDEFBBG GetTypeForEffect(AJHPODMFICL JPJLBLFBIGE)
	{
		return default(GAEKEDEFBBG);
	}

	public float GetCooldownForTrigger(string PIABCCCHEGG)
	{
		return 0f;
	}

	public List<string> GetTriggersByRarity(ENBIFKHMAGA GNNNEDJBMOH)
	{
		return null;
	}

	public Augmentation GetSelectedAugmentation(JJKEMOGCMGL DHBBBJLNMPH)
	{
		return null;
	}

	public void InstallAugmentation(string ILHCOEHJJIB, JJKEMOGCMGL DHBBBJLNMPH)
	{
	}

	public void ExtractAugmentation(string ILHCOEHJJIB, JJKEMOGCMGL DHBBBJLNMPH)
	{
	}

	public void ExtractAllAugmentations()
	{
	}

	public void FuseAugmentation(ONNAEEJFLHK HILNKGONIOM, List<ONNAEEJFLHK> DIEPPEJKIHL, int MGPHBMOIHJB, int DCDPFEDICHI, int FGCHJGAFHFI)
	{
	}

	public void UpgradeAugmentation(string ILHCOEHJJIB)
	{
	}

	private void DOLCIIEMHLB()
	{
	}

	public string GetSlotName(JJKEMOGCMGL PKELBCEPGLI)
	{
		return null;
	}

	private void LDOBIMHMAAP(GameController.ALOAMODMHMO KIHIFIBOOIM)
	{
	}

	public void DeactivateWithSameEffect(DJLLCPELJDB NFOFKPHABKH)
	{
	}

	private void DJIKBALBFCM()
	{
	}

	private void PFAHCCIOFAE()
	{
	}

	public AugmentationData CreateFakeAugData(int CFJJEKNHGKF)
	{
		return null;
	}

	private void FPFODEIGAEE(PlayerController BPBMHENPDIA)
	{
	}

	public Augmentation[] GetEquippedAugmentationData()
	{
		return null;
	}

	public void TutorialFinished()
	{
	}

	public void SecondAugmentationShown()
	{
	}

	public PEEMNNNBDJE[] GenerateRemoteStatusProviders(Augmentation[] CJHHIAMDDKJ)
	{
		return null;
	}

	private IEnumerable<int> IJMIJCCJFND(IList<Augmentation> CJHHIAMDDKJ)
	{
		return null;
	}

	private Augmentation AGMEEBOMOBC(string MMIJDFDBIFP)
	{
		return null;
	}

	private DJLLCPELJDB KEGGCCGBNBL(Augmentation HILNKGONIOM, PlayerController BPBMHENPDIA)
	{
		return null;
	}

	private float FKMOIKHMOAP(string JHJLDDPFDIL, int DBMLGANKIOK, int EBBFLHBMJFJ)
	{
		return 0f;
	}

	private float PCKBKIGJEHJ(string JHJLDDPFDIL, int DBMLGANKIOK)
	{
		return 0f;
	}

	private float FFCEBFLINPL(string JHJLDDPFDIL, int GIMEENGFKFB)
	{
		return 0f;
	}

	public float GetDuration(AJHPODMFICL JPJLBLFBIGE, int DBMLGANKIOK)
	{
		return 0f;
	}

	public float GetDurationByWeaponCategory(AJHPODMFICL JPJLBLFBIGE, int DBMLGANKIOK, WeaponCategory FCNJEGHDPKH)
	{
		return 0f;
	}

	public float GetDurationByWeaponCategory(AJHPODMFICL JPJLBLFBIGE, int DBMLGANKIOK, PlayerController GDMBMAPOKCL, int EJJCLMMHANF)
	{
		return 0f;
	}

	public float GetParam(AJHPODMFICL JPJLBLFBIGE, int DBMLGANKIOK)
	{
		return 0f;
	}

	public string GetWeaponCategory(int EJJCLMMHANF)
	{
		return null;
	}

	private float EEEKNIPOBFC(AJHPODMFICL JPJLBLFBIGE, int DBMLGANKIOK, PlayerController GDMBMAPOKCL, int EJJCLMMHANF)
	{
		return 0f;
	}

	public float GetParamByWeaponCategory(AJHPODMFICL JPJLBLFBIGE, int DBMLGANKIOK, WeaponCategory FCNJEGHDPKH)
	{
		return 0f;
	}

	private NMPBGNOOKNO JAPNKOCKPMP(PlayerController GDMBMAPOKCL, AJHPODMFICL JPJLBLFBIGE, int DBMLGANKIOK)
	{
		return null;
	}

	private CDJGGLCLOAC FGFLLABKHAL(PlayerController BPBMHENPDIA, string BPGGGINIGDC, float EMKIONJKPDK, float LBBNMEJEBKC)
	{
		return null;
	}

	private void Update()
	{
	}

	public void CheckIfStartAugTutorial()
	{
	}

	protected override void InitData()
	{
	}

	public void ShowSecondTutorialDialog()
	{
	}

	[CompilerGenerated]
	private Augmentation AEOLHEGPEJM(string OEKEOADHEOB)
	{
		return null;
	}
}
