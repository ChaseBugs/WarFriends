using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardDisarmedAndLocked : Card
{
	private PlayerWeapon LAHMMDBPFCB;

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private PlayerController MBIAKMPDOPG;

	private GDCLLGDCODD MNBIOCOAJHK;

	public const string EJLCMBEKFFN = "game-card-ico-disarmed";

	public float buffTime => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.DisarmedTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(buffTime));

	protected void IAPBHPLNNNO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1474f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / GPHGHEJNIDG();
				MBIAKMPDOPG.cardIconIndicator.EMOGLBGNDBD("ios", num);
				MBIAKMPDOPG.FMKGGADDHJK().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = false;
				MBIAKMPDOPG.weaponInventory.FBAIIPAKIJD = 1173f;
				Debug.Log("ID_CATEGORY_LOW_PL_GRENADE" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses;
				BHABHIDDBLH = 1010f;
				NNDMKIACBBM = true;
				MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("http://", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
		}
	}

	protected void NHEOMLPEBLC()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 271f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / OLENBOBKCEH();
				MBIAKMPDOPG.cardIconIndicator.BBCGKKJPIIN("ID_SKILLSHOTHINT_MULTIKILL", num);
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = false;
				MBIAKMPDOPG.weaponInventory.FBAIIPAKIJD = 538f;
				Debug.Log("ID_INBRONZE1" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC();
				BHABHIDDBLH = 24f;
				NNDMKIACBBM = false;
				MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("OnRestartDrawing", NABOFKMBMKH: false);
			}
		}
	}

	public virtual void CFPFCPGPOCP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float CLJBDOPFJFJ()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.WarcardsUnlockLevel).FLOATVALUE;
	}

	protected void PKPIMPKNFJJ()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 141f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / buffTime;
				MBIAKMPDOPG.cardIconIndicator.BBCGKKJPIIN("ID_GRENADEDAMAGE", num);
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN = true;
				MBIAKMPDOPG.BEIIOAIJMFK().FBAIIPAKIJD = 1900f;
				Debug.Log("Sessions" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses;
				BHABHIDDBLH = 688f;
				NNDMKIACBBM = false;
				MBIAKMPDOPG.cardIconIndicator.BIIHCAEKCOD("setRewardedVideoUserID", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
		}
	}

	[SpecialName]
	public virtual string MPBJBJKHMKK()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.AIPKMDCJCOG(KGNGPHMCHII(), "IsLocal");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string AFHFCDAAACH()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(GPHGHEJNIDG(), " game config values"));
	}

	public virtual void ENAEPBAOONK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC() + EBGKECLEHNK() - 727f;
		Debug.Log("RETRY" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.weaponInventory.currentWeapon;
			MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN = true;
			MNBIOCOAJHK.timeLockWeaponSwitch += 1277f;
		}
		MBIAKMPDOPG.JLMDEMFIHCA().BGIFMIBBJIB(MBIAKMPDOPG.BEIIOAIJMFK().PGNNINCBMJH());
		MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN = false;
		MBIAKMPDOPG.BEIIOAIJMFK().FBAIIPAKIJD = 1767f;
		BHABHIDDBLH = AMKKMNNHANC();
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("Action ", NABOFKMBMKH: false, HGNIGKCLLHM: true);
	}

	public virtual void IOKJMNMABHC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float AMKKMNNHANC()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-95)).FLOATVALUE;
	}

	public virtual void EOELDFKKJLE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string INLLPOMLLEN()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.AIPKMDCJCOG(AMKKMNNHANC(), "ID_INGOLD1");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	protected void GFPPJNOENLE()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1618f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / AMKKMNNHANC();
				MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("country-new-zealand", num);
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = false;
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = 1798f;
				Debug.Log("Sheet." + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC();
				BHABHIDDBLH = 718f;
				NNDMKIACBBM = true;
				MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME("starter", NABOFKMBMKH: false);
			}
		}
	}

	[SpecialName]
	public virtual string CGCEEBCGCFH()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(CLJBDOPFJFJ(), "veteranpack4");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float LOMIJKLEDIJ()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-90)).FLOATVALUE;
	}

	[SpecialName]
	public virtual string PKCGGJCMCNO()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(CCCNNJFKNNK(), "PrepareBotForDeathMatch 5");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	protected void LIMHNKKJODK()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 0f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / CLJBDOPFJFJ();
				MBIAKMPDOPG.cardIconIndicator.BBCGKKJPIIN("GameGold", num);
				MBIAKMPDOPG.weaponInventory.FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN = false;
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = 1688f;
				Debug.Log("Unit_Upgrade" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC();
				BHABHIDDBLH = 1131f;
				NNDMKIACBBM = false;
				MBIAKMPDOPG.cardIconIndicator.Show("N", NABOFKMBMKH: true);
			}
		}
	}

	protected void BBCOBMGHMGE()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 44f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / AMKKMNNHANC();
				MBIAKMPDOPG.cardIconIndicator.OODPJFJIMPI("\"{0}\"", num);
				MBIAKMPDOPG.weaponInventory.FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = true;
				MBIAKMPDOPG.FMKGGADDHJK().FBAIIPAKIJD = 561f;
				Debug.Log("Squad name failure" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses;
				BHABHIDDBLH = 14f;
				NNDMKIACBBM = false;
				MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("100+.", NABOFKMBMKH: true, HGNIGKCLLHM: true);
			}
		}
	}

	[SpecialName]
	public virtual string IBCHHANJMKL()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(CCCNNJFKNNK(), "ID_UNITTYPE2");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	protected void OFNEGNKMKKG()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 478f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / OLENBOBKCEH();
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("ID_", num);
				MBIAKMPDOPG.FMKGGADDHJK().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = true;
				MBIAKMPDOPG.weaponInventory.FBAIIPAKIJD = 761f;
				Debug.Log("ID_CONFIRM_NOTLEADEROFSQUAD" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC();
				BHABHIDDBLH = 73f;
				NNDMKIACBBM = false;
				MBIAKMPDOPG.cardIconIndicator.EOEDEJKJKMN("Country", NABOFKMBMKH: true);
			}
		}
	}

	[SpecialName]
	public virtual string KLMIHMJCAEE()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(GPHGHEJNIDG(), "Player promoted - database informations:\nName:{0} Level:{1} SquadId:{2} SquadRank:{3}");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void CGALPALBIDJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses + FCLPBLNEGLC() - 1532f;
		Debug.Log("ID_HOU" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.JLMDEMFIHCA().JECOEJBGKDF();
			MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN = true;
			MNBIOCOAJHK.timeLockWeaponSwitch += 1209f;
		}
		MBIAKMPDOPG.BEIIOAIJMFK().currentWeapon = MBIAKMPDOPG.JLMDEMFIHCA().MEJMPOEHBKA();
		MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = false;
		MBIAKMPDOPG.BEIIOAIJMFK().FBAIIPAKIJD = 1494f;
		BHABHIDDBLH = PLLFPHIFKCI();
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("S", NABOFKMBMKH: true);
	}

	[SpecialName]
	public float FCLPBLNEGLC()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-125)).FLOATVALUE;
	}

	[SpecialName]
	public virtual string LMFKIIKIIEA()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(PLLFPHIFKCI(), "menu-army-reload-ico"));
	}

	public virtual void OAJHAPCNJML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC() + KGNGPHMCHII() - 512f;
		Debug.Log("Scraps" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.weaponInventory.MFHBEJOLGLC();
			MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = true;
			MNBIOCOAJHK.timeLockWeaponSwitch += 1197f;
		}
		MBIAKMPDOPG.weaponInventory.HLOKMIDGPCA(MBIAKMPDOPG.FMKGGADDHJK().PGNNINCBMJH());
		MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN = false;
		MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = 1985f;
		BHABHIDDBLH = KPAMPHFMAAM();
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.BIIHCAEKCOD("ID_ZEROSECONDS", NABOFKMBMKH: true, HGNIGKCLLHM: true);
	}

	public virtual void AEDODFGIJLN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses + PLLFPHIFKCI() - 1885f;
		Debug.Log("game-card-ico-mineyourstep-full" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.JLMDEMFIHCA().JECOEJBGKDF();
			MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN = true;
			MNBIOCOAJHK.timeLockWeaponSwitch += 338f;
		}
		MBIAKMPDOPG.BEIIOAIJMFK().HLOKMIDGPCA(MBIAKMPDOPG.JLMDEMFIHCA().PPFBHJOBBJG());
		MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = true;
		MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = 788f;
		BHABHIDDBLH = EBGKECLEHNK();
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("ChangeWeapon", NABOFKMBMKH: true, HGNIGKCLLHM: true);
	}

	[SpecialName]
	public virtual string KGJIEDNENPD()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(AMKKMNNHANC(), "getErrorMessage"));
	}

	public virtual void HLCFNFCMGFD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses + CLJBDOPFJFJ() - 1812f;
		Debug.Log("menu-hub-multiplayer-vipico" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.JLMDEMFIHCA().APLKMLDHMDL();
			MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN = false;
			MNBIOCOAJHK.timeLockWeaponSwitch += 1456f;
		}
		MBIAKMPDOPG.weaponInventory.BGIFMIBBJIB(MBIAKMPDOPG.FMKGGADDHJK().pistol);
		MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN = true;
		MBIAKMPDOPG.weaponInventory.FBAIIPAKIJD = 719f;
		BHABHIDDBLH = LOMIJKLEDIJ();
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("DogTagCap", NABOFKMBMKH: true, HGNIGKCLLHM: true);
	}

	protected void KBKILDENNLM()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 156f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / KGNGPHMCHII();
				MBIAKMPDOPG.cardIconIndicator.DFNMNBFDDFD("OnDeathRPC", num);
				MBIAKMPDOPG.BEIIOAIJMFK().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN = true;
				MBIAKMPDOPG.FMKGGADDHJK().FBAIIPAKIJD = 415f;
				Debug.Log("Current Locale unity = " + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC();
				BHABHIDDBLH = 1063f;
				NNDMKIACBBM = false;
				MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("Action ", NABOFKMBMKH: true);
			}
		}
	}

	public virtual void CBJDBAKNBAG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses + KPAMPHFMAAM() - 1076f;
		Debug.Log("\n" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.BEIIOAIJMFK().NANJBGIGNCG();
			MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = false;
			MNBIOCOAJHK.timeLockWeaponSwitch += 1311f;
		}
		MBIAKMPDOPG.JLMDEMFIHCA().currentWeapon = MBIAKMPDOPG.BEIIOAIJMFK().PHOGJCDEHEI();
		MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN = false;
		MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = 914f;
		BHABHIDDBLH = CLJBDOPFJFJ();
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("Player disconected 0002", NABOFKMBMKH: false, HGNIGKCLLHM: true);
	}

	protected void MNFDMKFLAKO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1696f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / CLJBDOPFJFJ();
				MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("no parameters", num);
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = false;
				MBIAKMPDOPG.FMKGGADDHJK().FBAIIPAKIJD = 1610f;
				Debug.Log("Found starting gold currency = " + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses;
				BHABHIDDBLH = 672f;
				NNDMKIACBBM = true;
				MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("ID_BRONZEPACK", NABOFKMBMKH: true, HGNIGKCLLHM: true);
			}
		}
	}

	public virtual void INPLMEOCGKE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string CAJAELIAPFJ()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(PLLFPHIFKCI(), "{0} {1}"));
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses + buffTime - 0.1f;
		Debug.Log("Start TimeLock: " + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.weaponInventory.currentWeapon;
			MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = false;
			MNBIOCOAJHK.timeLockWeaponSwitch += 1000f;
		}
		MBIAKMPDOPG.weaponInventory.currentWeapon = MBIAKMPDOPG.weaponInventory.pistol;
		MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = true;
		MBIAKMPDOPG.weaponInventory.FBAIIPAKIJD = 1f;
		BHABHIDDBLH = buffTime;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-disarmed", NABOFKMBMKH: true);
	}

	public virtual void HLBAHDMEALA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC() + FCLPBLNEGLC() - 42f;
		Debug.Log("Enemy could not be spawned" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.JLMDEMFIHCA().PDLFJEDGLAO();
			MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN = true;
			MNBIOCOAJHK.timeLockWeaponSwitch += 1960f;
		}
		MBIAKMPDOPG.weaponInventory.BGIFMIBBJIB(MBIAKMPDOPG.BEIIOAIJMFK().PGNNINCBMJH());
		MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN = true;
		MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = 1511f;
		BHABHIDDBLH = CLJBDOPFJFJ();
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("Start TUNE SDK clicked", NABOFKMBMKH: true);
	}

	protected void JBGDAOIDBGF()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1445f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / LOMIJKLEDIJ();
				MBIAKMPDOPG.cardIconIndicator.CMGKLHJOLDD("001 LOADING ASSETS STARTED", num);
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN = false;
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = 1098f;
				Debug.Log("ArenaEnded" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC();
				BHABHIDDBLH = 1855f;
				NNDMKIACBBM = true;
				MBIAKMPDOPG.cardIconIndicator.OFPAGLLFPPK("menu-assignments-bar-gold", NABOFKMBMKH: true);
			}
		}
	}

	[SpecialName]
	public float KPAMPHFMAAM()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-25)).FLOATVALUE;
	}

	[SpecialName]
	public float KGNGPHMCHII()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BoobyTrapDamage).FLOATVALUE;
	}

	public virtual void PFLGKCELNOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float CCCNNJFKNNK()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-125)).FLOATVALUE;
	}

	public virtual void IFHKCJGBDAN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC() + buffTime - 240f;
		Debug.Log("Ranks/" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.weaponInventory.currentWeapon;
			MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN = true;
			MNBIOCOAJHK.timeLockWeaponSwitch += 502f;
		}
		MBIAKMPDOPG.weaponInventory.BGIFMIBBJIB(MBIAKMPDOPG.JLMDEMFIHCA().pistol);
		MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN = false;
		MBIAKMPDOPG.FMKGGADDHJK().FBAIIPAKIJD = 1560f;
		BHABHIDDBLH = GPHGHEJNIDG();
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("ID_READYTIME", NABOFKMBMKH: false, HGNIGKCLLHM: true);
	}

	[SpecialName]
	public virtual string CEFFPGFEPAL()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(buffTime, "\tTime since vip: {0}\tTime since last show: {1}\tTime since squad reminder: {2}");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void NHMADLLGPLC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses + EBGKECLEHNK() - 883f;
		Debug.Log("S" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.BEIIOAIJMFK().NANJBGIGNCG();
			MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = true;
			MNBIOCOAJHK.timeLockWeaponSwitch += 1093f;
		}
		MBIAKMPDOPG.weaponInventory.BGIFMIBBJIB(MBIAKMPDOPG.BEIIOAIJMFK().PGNNINCBMJH());
		MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = true;
		MBIAKMPDOPG.BEIIOAIJMFK().FBAIIPAKIJD = 1270f;
		BHABHIDDBLH = CCCNNJFKNNK();
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("game-card-ico-bulletsponge-full", NABOFKMBMKH: false);
	}

	protected void MGKCNLDGNEM()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 111f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / AMKKMNNHANC();
				MBIAKMPDOPG.cardIconIndicator.DFNMNBFDDFD("iconParent", num);
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN = true;
				MBIAKMPDOPG.weaponInventory.FBAIIPAKIJD = 287f;
				Debug.Log("IAPOfferInfo" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses;
				BHABHIDDBLH = 70f;
				NNDMKIACBBM = false;
				MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("MissionReward", NABOFKMBMKH: false);
			}
		}
	}

	public virtual void JEHJMHHHOCE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC() + LOMIJKLEDIJ() - 583f;
		Debug.Log(" >" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.BEIIOAIJMFK().CILCMCDCKKE();
			MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN = false;
			MNBIOCOAJHK.timeLockWeaponSwitch += 1839f;
		}
		MBIAKMPDOPG.FMKGGADDHJK().BGIFMIBBJIB(MBIAKMPDOPG.weaponInventory.PGNNINCBMJH());
		MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN = false;
		MBIAKMPDOPG.FMKGGADDHJK().FBAIIPAKIJD = 216f;
		BHABHIDDBLH = CCCNNJFKNNK();
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("Player_Had_To_Select_Grenade", NABOFKMBMKH: false, HGNIGKCLLHM: true);
	}

	[SpecialName]
	public virtual string CFACFKEJBJF()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(AMKKMNNHANC(), "    demote:{0}");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string IMIBCBLGEBC()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(GPHGHEJNIDG(), "game-revenge-indicator");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string HEEBHGBEELC()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(KPAMPHFMAAM(), "ID_INMASTER1");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void PEGJJBMLEML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void GJCKHJLEPKG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses + OLENBOBKCEH() - 696f;
		Debug.Log("{0} {1}{2} {3}" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.JLMDEMFIHCA().JECOEJBGKDF();
			MBIAKMPDOPG.FMKGGADDHJK().HKGLMFFAHFN = true;
			MNBIOCOAJHK.timeLockWeaponSwitch += 26f;
		}
		MBIAKMPDOPG.FMKGGADDHJK().LPMCOFOCCAH(MBIAKMPDOPG.BEIIOAIJMFK().pistol);
		MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = true;
		MBIAKMPDOPG.BEIIOAIJMFK().FBAIIPAKIJD = 1128f;
		BHABHIDDBLH = LOMIJKLEDIJ();
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("Manual_Unit_Spawn", NABOFKMBMKH: false);
	}

	[SpecialName]
	public float EBGKECLEHNK()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-118)).FLOATVALUE;
	}

	[SpecialName]
	public float PLLFPHIFKCI()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-22)).FLOATVALUE;
	}

	[SpecialName]
	public float OLENBOBKCEH()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-24)).FLOATVALUE;
	}

	public virtual void JGNBFCJFAHM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void MGAIKDBOPKI()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1535f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / OLENBOBKCEH();
				MBIAKMPDOPG.cardIconIndicator.CMFDIDFKHPF("_Packs", num);
				MBIAKMPDOPG.BEIIOAIJMFK().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN = true;
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = 1661f;
				Debug.Log("ID_YOUHAVENOBUDDYWARCARDSAVAILABLE" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses;
				BHABHIDDBLH = 1219f;
				NNDMKIACBBM = true;
				MBIAKMPDOPG.cardIconIndicator.EOEDEJKJKMN("ID_REMINDER_YOURVIPMEMBERSHIP", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
		}
	}

	protected void CJAHPFMAMKK()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 356f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / PLLFPHIFKCI();
				MBIAKMPDOPG.cardIconIndicator.DFNMNBFDDFD("WarBucks", num);
				MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = true;
				MBIAKMPDOPG.FMKGGADDHJK().FBAIIPAKIJD = 87f;
				Debug.Log("Bad inventory data, data= " + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC();
				BHABHIDDBLH = 1723f;
				NNDMKIACBBM = true;
				MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("Problem for max! in army/weapon stats", NABOFKMBMKH: true, HGNIGKCLLHM: true);
			}
		}
	}

	[SpecialName]
	public float GPHGHEJNIDG()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-111)).FLOATVALUE;
	}

	protected void DIOAOBFDPMH()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 614f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / FCLPBLNEGLC();
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("Metal", num);
				MBIAKMPDOPG.BEIIOAIJMFK().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.BEIIOAIJMFK().HKGLMFFAHFN = false;
				MBIAKMPDOPG.FMKGGADDHJK().FBAIIPAKIJD = 887f;
				Debug.Log("game-card-ico-triggerhappy" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC();
				BHABHIDDBLH = 1940f;
				NNDMKIACBBM = true;
				MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("game-elite-debuff", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
		}
	}

	protected void HDLDMGEFCEJ()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 14f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / CCCNNJFKNNK();
				MBIAKMPDOPG.cardIconIndicator.ONONEOAEOHL("{0} {1} {2}lvl {3}", num);
				MBIAKMPDOPG.FMKGGADDHJK().FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = false;
				MBIAKMPDOPG.BEIIOAIJMFK().FBAIIPAKIJD = 1146f;
				Debug.Log("ExpectedPrice" + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses;
				BHABHIDDBLH = 756f;
				NNDMKIACBBM = true;
				MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("Player_Rank", NABOFKMBMKH: false);
			}
		}
	}

	protected void Update()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 0f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				float num = BHABHIDDBLH / buffTime;
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("game-card-ico-disarmed", num);
				MBIAKMPDOPG.weaponInventory.FBAIIPAKIJD = num;
			}
			else
			{
				MBIAKMPDOPG.weaponInventory.HKGLMFFAHFN = false;
				MBIAKMPDOPG.weaponInventory.FBAIIPAKIJD = 0f;
				Debug.Log("Ending TimeLock: " + CardManager.instance.timeLockWeaponSwitch);
				MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses;
				BHABHIDDBLH = 0f;
				NNDMKIACBBM = false;
				MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-disarmed", NABOFKMBMKH: false);
			}
		}
	}

	public virtual void KNEKFCFPHBK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		this.MNBIOCOAJHK = MNBIOCOAJHK;
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MNBIOCOAJHK.timeLockWeaponSwitch = TimeManager.CEAFAMFNGCC() + OLENBOBKCEH() - 1965f;
		Debug.Log("From server came null PlayerInfo!" + CardManager.instance.timeLockWeaponSwitch);
		if (MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN)
		{
			MNBIOCOAJHK.grenadeSaved = MBIAKMPDOPG.BEIIOAIJMFK().MFHBEJOLGLC();
			MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN = false;
			MNBIOCOAJHK.timeLockWeaponSwitch += 1751f;
		}
		MBIAKMPDOPG.BEIIOAIJMFK().currentWeapon = MBIAKMPDOPG.FMKGGADDHJK().PPFBHJOBBJG();
		MBIAKMPDOPG.JLMDEMFIHCA().HKGLMFFAHFN = true;
		MBIAKMPDOPG.JLMDEMFIHCA().FBAIIPAKIJD = 991f;
		BHABHIDDBLH = KGNGPHMCHII();
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME("| time: ", NABOFKMBMKH: true, HGNIGKCLLHM: true);
	}
}
