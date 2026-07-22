using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json;
using UnityEngine.Scripting;

public class WeaponAugsManager : DatabaseSerializedObjectGeneric<WeaponAugsManager.WeaponAugData>
{
	public enum BMDBMIKHHJN
	{
		Damage,
		MagazineSize,
		Reload,
		CriticalChance,
		TotalAmmo,
		Accuracy,
		RateOfFire,
		ShotVelocity,
		Cooldown,
		Overheating
	}

	[Preserve]
	public class WeaponAugData
	{
		public Dictionary<string, WeaponAug> all;

		public int materials;

		public bool tutorialComplete;

		public bool tutorialCrateClaimed;

		public bool augmentationShown;
	}

	[Serializable]
	[Preserve]
	public class WeaponAug
	{
		[JsonProperty]
		public int effectId;

		public int augId;

		public int grade;

		public int xp;

		public BMDBMIKHHJN statId;

		public WeaponCategory weaponCat;

		public AugmentationManager.ENBIFKHMAGA rarity;

		public bool installed;

		[JsonProperty]
		public string effectParameters;

		public NIKDALAFEAD effectType
		{
			get
			{
				return default(NIKDALAFEAD);
			}
			set
			{
			}
		}
	}

	private sealed class JGNCDDKAABI
	{
		public WeaponCategory GMOKGOJCJFH;

		internal bool MGAEODOAAJD(KeyValuePair<string, WeaponAug> CLMNCBPINKO)
		{
			return false;
		}
	}

	public static readonly Dictionary<WeaponCategory, string> OBFJEIDJDKO;

	private static WeaponAugsManager DJDBDKFAKHN;

	private WeaponAugEffects KDBFHENPAGO;

	private WeaponAugLevels OHHOFDLDIJH;

	private WeaponAugValues PBMEMIIDLGL;

	private WeaponAugStatBonuses JIEBNKOFJMC;

	[CompilerGenerated]
	private Action<int, int, WeaponLevelsSetup> KGOGJFPABPB;

	[CompilerGenerated]
	private Action<int, int, WeaponLevelsSetup> BAPBJLDKAGN;

	[CompilerGenerated]
	private Action<int> BMMHFCDBBDE;

	[CompilerGenerated]
	private Action<int> MFJJDJGOLPB;

	public List<BBFBFANGDJP> PBLOMHBFPPD;

	public static WeaponAugsManager instance => null;

	public List<JBEPBGJGPBN> allAugmentationsSorted => null;

	public Dictionary<string, WeaponAug> allAugs => null;

	public int materialCount => 0;

	public int currentAugCount => 0;

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

	public int augmentationMaxLevel => 0;

	public float weaponAugXPValueMultiplier => 0f;

	public float weaponMaterialsToXP => 0f;

	public float materialDismantlePriceWeapon => 0f;

	public float weaponAugDismantleCoef => 0f;

	public float xpToMaterial => 0f;

	public float weaponAugFuseCoef => 0f;

	public bool canShowSecondTutorialDialog => false;

	public bool didShowSecondAugmentationDialog => false;

	public bool hasMinigunAug => false;

	public event Action<int, int, WeaponLevelsSetup> AugmentationInstalled
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

	public event Action<int, int, WeaponLevelsSetup> AugmentationExtracted
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

	public event Action<int> AugmentationFused
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

	public event Action<int> AugmentationDismantled
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

	public int GetCountForCategory(WeaponCategory GMOKGOJCJFH)
	{
		return 0;
	}

	public int CalculateWarbucks(WeaponLevelsSetup AEBEOCBIBFI)
	{
		return 0;
	}

	public int CalculateWarbucks(int IGPDMLPNJCH)
	{
		return 0;
	}

	public float CalculateFuseXP(int FGMHGFEFLDC)
	{
		return 0f;
	}

	protected override void Awake()
	{
	}

	public List<JBEPBGJGPBN> GetAugmentations(WeaponCategory FCNJEGHDPKH)
	{
		return null;
	}

	public string GetInstalledAugForSlot(int PKELBCEPGLI)
	{
		return null;
	}

	public WeaponAug GetAugById(string ILHCOEHJJIB)
	{
		return null;
	}

	private int BMKKBCHLALA(JBEPBGJGPBN OEKEOADHEOB, JBEPBGJGPBN EGMJAECMHBP)
	{
		return 0;
	}

	public WeaponLevelsSetup FindInstalledWeapon(int ILHCOEHJJIB, WeaponCategory GMOKGOJCJFH)
	{
		return null;
	}

	public void InstallAugmentation(int PKELBCEPGLI, int ILHCOEHJJIB, WeaponLevelsSetup IDIIEBBLDAM)
	{
	}

	public void ExtractAugmentation(int PKELBCEPGLI, int ILHCOEHJJIB, WeaponLevelsSetup IDIIEBBLDAM)
	{
	}

	public void DismantleAug(int ILHCOEHJJIB, int CAJBBJIBCAE)
	{
	}

	private void GKLPCMDFKCD(int ILHCOEHJJIB, int PKELBCEPGLI, WeaponLevelsSetup IDIIEBBLDAM)
	{
	}

	public void SetExtracted(int ILHCOEHJJIB, int PKELBCEPGLI, WeaponLevelsSetup IDIIEBBLDAM)
	{
	}

	public void FuseAugmentation(JBEPBGJGPBN HILNKGONIOM, List<JBEPBGJGPBN> DIEPPEJKIHL, int MGPHBMOIHJB, int DCDPFEDICHI, int FGCHJGAFHFI, List<int> GKMPMPNOPNO, int GKFEHGMLHEA)
	{
	}

	public void UpgradeAugmentation(int ILHCOEHJJIB)
	{
	}

	public WeaponAugValuesRow GetEffectConfigs(NIKDALAFEAD JPJLBLFBIGE, int APBGMILHDGI)
	{
		return null;
	}

	public WeaponAugValuesRow GetEffectDurationConfigs(NIKDALAFEAD JPJLBLFBIGE)
	{
		return null;
	}

	public WeaponAugStatBonusesRow GetStatConfigs(BMDBMIKHHJN BLHAEHHBAKJ)
	{
		return null;
	}

	public int GetAugLevelXp(AugmentationManager.ENBIFKHMAGA GNNNEDJBMOH, int MCFEIECJOFN)
	{
		return 0;
	}

	public float GetParam(NIKDALAFEAD JPJLBLFBIGE, WeaponCategory FCNJEGHDPKH, int IGIIPDBNAIJ, int GNNNEDJBMOH)
	{
		return 0f;
	}

	public float GetSecondParam(NIKDALAFEAD JPJLBLFBIGE, WeaponCategory FCNJEGHDPKH, int IGIIPDBNAIJ, int GNNNEDJBMOH)
	{
		return 0f;
	}

	public float GetDuration(NIKDALAFEAD JPJLBLFBIGE, WeaponCategory FCNJEGHDPKH, int IGIIPDBNAIJ, int GNNNEDJBMOH)
	{
		return 0f;
	}

	public float GetStatParam(BMDBMIKHHJN BLHAEHHBAKJ, WeaponCategory FCNJEGHDPKH, float IGIIPDBNAIJ, int GNNNEDJBMOH)
	{
		return 0f;
	}

	private BBFBFANGDJP JAPNKOCKPMP(PlayerController GDMBMAPOKCL, WeaponLevelsSetup AEBEOCBIBFI, WeaponAug KHNDMJEPKPB)
	{
		return null;
	}

	public float GetDamageBonus(WeaponAug KHNDMJEPKPB, float IGIIPDBNAIJ)
	{
		return 0f;
	}

	private NIAGGCHHKGI JDENLGEEDIN(WeaponLevelsSetup AEBEOCBIBFI, WeaponAug KHNDMJEPKPB)
	{
		return null;
	}

	public void CheckIfStartAugTutorial()
	{
	}

	public void ShowSecondTutorialDialog()
	{
	}

	public void TutorialFinished()
	{
	}

	public void SecondAugmentationShown()
	{
	}

	public void ExtractAllAugmentations(WeaponLevelsSetup AEBEOCBIBFI)
	{
	}

	private void DOLCIIEMHLB()
	{
	}

	private void HCOCHDHHLPC(GameController.ALOAMODMHMO KIHIFIBOOIM)
	{
	}

	private void PFAHCCIOFAE()
	{
	}

	private List<WeaponAug> FJHBHDFILFD(int EPNGMAHENPA)
	{
		return null;
	}

	public WeaponAugData CreateFakeAugData(DatabasePlayer EHODJLJJAKB)
	{
		return null;
	}
}
