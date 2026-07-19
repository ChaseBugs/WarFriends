using System.Collections.Generic;
using UnityEngine;

public class ArmyStatProgressBar : Core_BaseScript
{
	private enum AAICHFHEIGB
	{
		Normal = 0,
		SpecialAbility = 1,
		ElitePerk = 2
	}

	[Header("Core")]
	[SerializeField]
	private AAICHFHEIGB mCurrentType;

	public UISprite HMMKJFFOEFN;

	public UISprite EHFNJLLILFE;

	public UILabel CKBELNDIMJG;

	[Header("-Ability Locked")]
	public GameObject FOLLFHBFNMF;

	public UITable CFABIJLGDEN;

	public UILabel JKKDKNOOBCE;

	public UISprite[] KBCDCFBPJKB;

	[Header("-Elite Locked")]
	public GameObject JAPEPJAHLIA;

	public UILabel INLFNIJAILN;

	[Header("-Progress Bar")]
	public GameObject AJIBIAPCLIN;

	public UISprite OCMNNPMNOCB;

	public UISprite KCDCGGKKMOM;

	public UILabel CGNKNENMLPB;

	public UILabel PNBGMFFKJIP;

	[Header("--Right Box")]
	public UISprite MBMIOELEAND;

	public UILabel GMBDMEAAFPG;

	public UILabel KIIOABOEJBN;

	private Vector3 NMFBHDFAAKL = new Vector3(62f, 62f, 1f);

	private Vector3 DGAIKOFGBFD = new Vector3(87f, 87f, 1f);

	private static Dictionary<AAICHFHEIGB, Color> MAKKOBHOPFJ = new Dictionary<AAICHFHEIGB, Color>
	{
		{
			AAICHFHEIGB.Normal,
			Colours.blueUpgradeAnim1
		},
		{
			AAICHFHEIGB.SpecialAbility,
			Colours.yellowUpgradeAnim1
		},
		{
			AAICHFHEIGB.ElitePerk,
			Colours.greenUpgradeAnim1
		}
	};

	private static Dictionary<AAICHFHEIGB, Color> NCFNBHOHBCE = new Dictionary<AAICHFHEIGB, Color>
	{
		{
			AAICHFHEIGB.Normal,
			Colours.blueUpgradeAnim2
		},
		{
			AAICHFHEIGB.SpecialAbility,
			Colours.yellowUpgradeAnim2
		},
		{
			AAICHFHEIGB.ElitePerk,
			Colours.greenUpgradeAnim2
		}
	};

	private static Dictionary<AAICHFHEIGB, Color> DCELBNFFEHN = new Dictionary<AAICHFHEIGB, Color>
	{
		{
			AAICHFHEIGB.Normal,
			Colours.blue
		},
		{
			AAICHFHEIGB.SpecialAbility,
			Colours.goldUpgrade
		},
		{
			AAICHFHEIGB.ElitePerk,
			Colours.greenArena
		}
	};

	public void InitializeStat(LevelBehaviour IOIKKIIFOCB, bool LPFLPCOLHPJ)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.guiStatistics[(!LPFLPCOLHPJ) ? 1 : 0];
		bool bought = IOIKKIIFOCB.upgradeSlots.bought;
		bool flag = IOIKKIIFOCB.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering && !IOIKKIIFOCB.upgradeSlots.deliveringSlot.isSpecial;
		float num = ((!LPFLPCOLHPJ) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!LPFLPCOLHPJ) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!LPFLPCOLHPJ) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[2]));
		if (IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			num3 = num;
		}
		float num4 = num3 - num;
		bool flag2 = num4 > 0f;
		bool flag3 = num == num2;
		float num5 = ((!flag3) ? Mathf.Clamp01(num / num2) : 1f);
		float fillAmount = ((!bought) ? num5 : (flag3 ? 1f : ((!flag) ? num5 : Mathf.Clamp01(num3 / num2))));
		HMMKJFFOEFN.spriteName = ((!LPFLPCOLHPJ) ? "menu-health-ico" : "menu-attack-ico");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(27f);
		EHFNJLLILFE.gameObject.SetActive(false);
		CKBELNDIMJG.text = ((!LPFLPCOLHPJ) ? Localization.Localize("ID_HEALTH") : Localization.Localize("ID_ATTACK"));
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		HFMJGJINAJK(MEJMLNDFDBP.MAGANIIGHON(num));
		GMCBBBAAGJO((!flag3) ? MEJMLNDFDBP.MAGANIIGHON(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		HMMKJFFOEFN.color = ((!flag3) ? Colours.blue : color);
		KCDCGGKKMOM.color = ((!flag3) ? Colours.blue : color);
		PNBGMFFKJIP.color = ((!flag3) ? Color.white : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (bought)
		{
			if (flag3)
			{
				NONCNLCDIDD(color);
			}
			else
			{
				NAECNOIDJBM((!flag2) ? string.Empty : string.Format("+{0}", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (flag && flag2)
			{
				HALLAKMKEEN();
			}
			else
			{
				EMDNEOBGFEB();
			}
		}
		else
		{
			NAECNOIDJBM(string.Empty);
			EMDNEOBGFEB();
		}
	}

	private void ONICKKEHECG(Color HAJDGBEPIJF)
	{
		MBMIOELEAND.gameObject.SetActive(false);
		MBMIOELEAND.color = Color.white;
		GMBDMEAAFPG.gameObject.SetActive(true);
		KIIOABOEJBN.gameObject.SetActive(false);
		KIIOABOEJBN.color = HAJDGBEPIJF;
	}

	public void FDPBPLIPBGD(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.BDAAHLLPPGN();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(1272f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		EHFNJLLILFE.gameObject.SetActive(true);
		CKBELNDIMJG.text = Localization.Localize(" (#");
		if (flag)
		{
			bool jHFKBODINGN = IOIKKIIFOCB.upgradeSlots.unitState != (UpgradeSlots.JLANLLEABDC)7 || IOIKKIIFOCB.upgradeSlots.deliveringSlot.isSpecial;
			JMFBBGLPOAJ(IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.NEJNMDNOAKD()[1], jHFKBODINGN);
		}
		else
		{
			OCFNMPOIJBM(IOIKKIIFOCB);
		}
	}

	private void DKBGAIIGOJE(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[0] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("Amount", array);
		MEJMLNDFDBP.COCBCFKJOJE(JKKDKNOOBCE, 414f, 467f, 50);
		for (int i = 0; i < KBCDCFBPJKB.Length; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		HMMKJFFOEFN.color = Colours.gray;
		HBNPCADFFAK(string.Empty);
	}

	private void JINABAKLCLB(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 540f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 375f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 896f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		CGNKNENMLPB.text = Localization.LocalizeFormat("relog OK", ECPOBELNKOO);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_AVOIDRELEGATION1" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1097f / x);
		if (num2 < 229f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "Get Custom Profile Variables" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(473f / x);
		}
		if (num2 < 966f)
		{
			Debug.LogError("Please add ");
		}
		float num3 = Mathf.Clamp(num2, 1258f, 1577f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 16f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1956f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void NIDMHGGNKCP()
	{
		float num = 729f;
		TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		GMBDMEAAFPG.color = Colours.greenDelivering;
		MBMIOELEAND.gameObject.SetActive(false);
		MBMIOELEAND.color = Color.white;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1133f * num, 1353f, 814f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 1;
		TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 1151f * num, new Vector3(127f, 1753f, 100f), new Vector3(334f, 458f, 642f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 0;
	}

	private void AGBNHIBHGFI(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[1];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 653f) : (num4 < 423f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 1895f);
		float fillAmount = (flag ? 662f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		if (ODFAFEEGGJK.Value1 == "Experience")
		{
			HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
			HBNPCADFFAK((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "ID_CHATCANNOTSENDMESSAGESRECONNECTING")
		{
			PCOLLELFIPE(MEJMLNDFDBP.DLDMHFBIEEO(num));
			MHFFPPHHHLO((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "TopRun")
		{
			PCOLLELFIPE(MEJMLNDFDBP.MAJBCINJAGF(num));
			LFJFHKHMNHL((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			NPECPIELDGI(string.Empty);
			FPODNPBANAE(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			HNPABGOKNLK(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "ID_EXPIRED")
			{
				EGNJLGGLNOI(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "Play_Skirmish")
			{
				EGNJLGGLNOI(string.Format((!(num4 < 1975f)) ? "withAttribute3" : "Sync", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "Average_Transaction_Amount")
			{
				EGNJLGGLNOI(string.Format((!(num4 < 1288f)) ? "#DANIEL# New Assignemnts Claimed Arrived: " : "LevelManager: levels are null!!", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 1462f, 445f, 116);
		}
		else
		{
			HDOEJCGICLJ(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			HNIOBODENOJ();
		}
		else
		{
			JGMECIBKBFG();
		}
	}

	public void PJNJICKPAHH(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.JFAELKHPLLA();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(835f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		EHFNJLLILFE.gameObject.SetActive(false);
		CKBELNDIMJG.text = Localization.Localize("Have discount {0} to upgrade {1}");
		if (flag)
		{
			bool jHFKBODINGN = IOIKKIIFOCB.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.NotBuyed || IOIKKIIFOCB.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
			HMLGKGBANCH(IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.guiStatistics[0], jHFKBODINGN);
		}
		else
		{
			PCGHFMMPDFG(IOIKKIIFOCB);
		}
	}

	private void NNDBAHJHFML(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1807f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 859f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 412f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[0] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("^[0-9]*-", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "Player profile - Null or empty player id in player profile dialog." + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(315f / x);
		if (num2 < 79f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_SKILLSHOTHINT_ONTHEMOVE" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(985f / x);
		}
		if (num2 < 847f)
		{
			Debug.LogError("{0} {1}");
		}
		float num3 = Mathf.Clamp(num2, 884f, 1433f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1571f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1503f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void InitializeElite(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isBought;
		EHFNJLLILFE.gameObject.SetActive(true);
		IOIKKIIFOCB.SetUpEliteIcon(HMMKJFFOEFN, EHFNJLLILFE);
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition.ReplaceX(27f);
		CKBELNDIMJG.text = Localization.Localize("ID_ELITEPERK");
		if (flag)
		{
			LCHBCFKJGKH(IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.guiStatistics[0]);
		}
		else
		{
			IALGNOPFKKH(IOIKKIIFOCB);
		}
	}

	private void NONCNLCDIDD(Color HAJDGBEPIJF)
	{
		MBMIOELEAND.gameObject.SetActive(true);
		MBMIOELEAND.color = Color.white;
		GMBDMEAAFPG.gameObject.SetActive(false);
		KIIOABOEJBN.gameObject.SetActive(true);
		KIIOABOEJBN.color = HAJDGBEPIJF;
	}

	private void HEEDKGCFKKP(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
		int num2 = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.KPJDJFMGNNM();
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		UILabel iNLFNIJAILN = INLFNIJAILN;
		object[] array = new object[5];
		array[1] = Colours.stringGreenArena;
		array[0] = num2;
		array[2] = Colours.stringWhite;
		array[6] = num;
		iNLFNIJAILN.text = Localization.LocalizeFormat("HU", array);
		MEJMLNDFDBP.COCBCFKJOJE(INLFNIJAILN, 634f, 1540f, -96);
		HMMKJFFOEFN.color = Colours.gray;
		HBNPCADFFAK(string.Empty);
	}

	public void InitializeSpecial(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.isBought;
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(27f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		EHFNJLLILFE.gameObject.SetActive(false);
		CKBELNDIMJG.text = Localization.Localize("ID_ABILITY");
		if (flag)
		{
			bool jHFKBODINGN = IOIKKIIFOCB.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering && IOIKKIIFOCB.upgradeSlots.deliveringSlot.isSpecial;
			PALDMHMDADB(IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.guiStatistics[0], jHFKBODINGN);
		}
		else
		{
			CINKKANIDDC(IOIKKIIFOCB);
		}
	}

	private void HBNPCADFFAK(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1354f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1476f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1517f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat(" requires ", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "SpecialOfferSuffix" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1935f / x);
		if (num2 < 180f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "GooglePlayLogin(" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(544f / x);
		}
		if (num2 < 284f)
		{
			Debug.LogError("ID_WARNING_ACCOUNTALREADYCREATED");
		}
		float num3 = Mathf.Clamp(num2, 1776f, 1545f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1227f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1473f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void PLJEONHKCFB(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[4];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 1914f) : (num4 < 35f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 1855f);
		float fillAmount = (flag ? 905f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		if (ODFAFEEGGJK.Value1 == "否")
		{
			HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
			HBNPCADFFAK((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "Error: {0}")
		{
			NPECPIELDGI(MEJMLNDFDBP.DLDMHFBIEEO(num));
			BCGJCGBNNAL((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "throw_grenade_left")
		{
			PCOLLELFIPE(MEJMLNDFDBP.MAJBCINJAGF(num));
			NJCAFMINBBN((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			NPECPIELDGI(string.Empty);
			HBNPCADFFAK(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			PMLPKBGLPEL(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "shotReal")
			{
				NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "N")
			{
				EGNJLGGLNOI(string.Format((!(num4 < 1588f)) ? "consumePurchaseSucceededEvent: " : "master2", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "country-slovakia")
			{
				HDOEJCGICLJ(string.Format((!(num4 < 1208f)) ? "Set Delegate" : "0", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 1684f, 560f, 46);
		}
		else
		{
			EGNJLGGLNOI(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			HALLAKMKEEN();
		}
		else
		{
			EMDNEOBGFEB();
		}
	}

	private void HMCKAJMNBJP(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[1];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("}", array);
		MEJMLNDFDBP.COCBCFKJOJE(JKKDKNOOBCE, 814f, 325f, -110);
		for (int i = 1; i < KBCDCFBPJKB.Length; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		HMMKJFFOEFN.color = Colours.gray;
		JINABAKLCLB(string.Empty);
	}

	public void LMKCCMOOEIH(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.JFAELKHPLLA();
		EHFNJLLILFE.gameObject.SetActive(true);
		IOIKKIIFOCB.SetUpEliteIcon(HMMKJFFOEFN, EHFNJLLILFE, 969f);
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition.ReplaceX(1561f);
		CKBELNDIMJG.text = Localization.Localize("ID_CATEGORY_LOW_SG_SPECIAL");
		if (flag)
		{
			FKFIDAJLNEC(IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.guiStatistics[0]);
		}
		else
		{
			IALGNOPFKKH(IOIKKIIFOCB);
		}
	}

	private void KAFKILPMLLF(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[5];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 337f) : (num4 < 841f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 1232f);
		float fillAmount = (flag ? 1818f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		if (ODFAFEEGGJK.Value1 == "(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)V")
		{
			PCOLLELFIPE(MEJMLNDFDBP.JJBMMICPIIG(num));
			GMCBBBAAGJO((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "-[^-]*$")
		{
			PCOLLELFIPE(MEJMLNDFDBP.DLDMHFBIEEO(num));
			BCGJCGBNNAL((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "_Color")
		{
			PCOLLELFIPE(MEJMLNDFDBP.MAJBCINJAGF(num));
			JINABAKLCLB((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			NPECPIELDGI(string.Empty);
			MHFFPPHHHLO(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			PMLPKBGLPEL(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "PreRollMessage")
			{
				NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "Play_Card_Tutorial")
			{
				NAECNOIDJBM(string.Format((!(num4 < 372f)) ? "LeagueId" : "N", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "ID_WARNING_CANTSENDINVITE")
			{
				HDOEJCGICLJ(string.Format((!(num4 < 1614f)) ? "N" : "+0", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 1027f, 845f, 125);
		}
		else
		{
			EGNJLGGLNOI(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			OOHLHELGDGD();
		}
		else
		{
			CLNBNBJABKA();
		}
	}

	private void JIAJEBPHHDG(Tuple<string, float[]> ODFAFEEGGJK)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[2];
		bool flag = num == num2;
		float iDEBKDPMPGM = num3 - num;
		bool flag2 = true;
		float num4 = ((!flag) ? Mathf.Clamp01(num / num2) : 1061f);
		float fillAmount = ((!flag) ? num4 : 1149f);
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(true);
		NPECPIELDGI(MEJMLNDFDBP.JJBMMICPIIG(num));
		HBNPCADFFAK((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.greenArena : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.greenArena : color);
		KCDCGGKKMOM.fillAmount = num4;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			LCCCGDLKOKK(color);
		}
		else if (flag2)
		{
			NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(iDEBKDPMPGM));
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 534f, 305f, 109);
		}
	}

	public void FKEOPAAPOCL(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.JFAELKHPLLA();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(365f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		EHFNJLLILFE.gameObject.SetActive(false);
		CKBELNDIMJG.text = Localization.Localize("ID_NO");
		if (flag)
		{
			bool jHFKBODINGN = IOIKKIIFOCB.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering && IOIKKIIFOCB.upgradeSlots.deliveringSlot.isSpecial;
			JMFBBGLPOAJ(IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.NEJNMDNOAKD()[0], jHFKBODINGN);
		}
		else
		{
			IOBGBHNPFDB(IOIKKIIFOCB);
		}
	}

	private void PCOLLELFIPE(string MKBPHBAAPBE)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = true;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(1476f, 262f, 1599f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(1302f);
		PNBGMFFKJIP.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 1653f, 1166f, -27);
		NMFBHDFAAKL = PNBGMFFKJIP.transform.localScale;
		DGAIKOFGBFD = PNBGMFFKJIP.transform.localScale.MultiplyXY(1010f);
	}

	public void ADNCCCNCJHB(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.BDAAHLLPPGN();
		EHFNJLLILFE.gameObject.SetActive(true);
		IOIKKIIFOCB.SetUpEliteIcon(HMMKJFFOEFN, EHFNJLLILFE, 1116f);
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition.ReplaceX(913f);
		CKBELNDIMJG.text = Localization.Localize("]");
		if (flag)
		{
			MIHLNKGJBEP(IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.NEJNMDNOAKD()[1]);
		}
		else
		{
			HEEDKGCFKKP(IOIKKIIFOCB);
		}
	}

	private void BMBMHIAMKLC(Tuple<string, float[]> ODFAFEEGGJK)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[4];
		bool flag = num == num2;
		float iDEBKDPMPGM = num3 - num;
		bool flag2 = false;
		float num4 = ((!flag) ? Mathf.Clamp01(num / num2) : 748f);
		float fillAmount = ((!flag) ? num4 : 177f);
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		PCOLLELFIPE(MEJMLNDFDBP.JJBMMICPIIG(num));
		JINABAKLCLB((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.greenArena : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.greenArena : color);
		KCDCGGKKMOM.fillAmount = num4;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			PMLPKBGLPEL(color);
		}
		else if (flag2)
		{
			EGNJLGGLNOI(MEJMLNDFDBP.DPAFFLMAFJG(iDEBKDPMPGM));
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 859f, 17f, -56);
		}
	}

	private void OCFNMPOIJBM(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		JKKDKNOOBCE.text = Localization.LocalizeFormat("menu-warbucks", num);
		MEJMLNDFDBP.COCBCFKJOJE(JKKDKNOOBCE, 644f, 798f, -157);
		for (int i = 1; i < KBCDCFBPJKB.Length; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		HMMKJFFOEFN.color = Colours.gray;
		BCGJCGBNNAL(string.Empty);
	}

	private void PCGHFMMPDFG(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("S", array);
		MEJMLNDFDBP.COCBCFKJOJE(JKKDKNOOBCE, 1822f, 1345f, -144);
		for (int i = 1; i < KBCDCFBPJKB.Length; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		HMMKJFFOEFN.color = Colours.gray;
		GMCBBBAAGJO(string.Empty);
	}

	private void EHEBIBKHJEF()
	{
		float num = 1765f;
		TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		GMBDMEAAFPG.color = Colours.greenDelivering;
		MBMIOELEAND.gameObject.SetActive(false);
		MBMIOELEAND.color = Color.white;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 608f * num, 1275f, 1534f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 0;
		TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 909f * num, new Vector3(1280f, 861f, 803f), new Vector3(300f, 1953f, 530f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 0;
	}

	private void CLNBNBJABKA()
	{
		Color color = MAKKOBHOPFJ[mCurrentType];
		Color to = NCFNBHOHBCE[mCurrentType];
		GMBDMEAAFPG.color = color;
		TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 679f, color, to);
		tweenColor.NumOfRepetitions = 1;
		tweenColor.style = (UITweener.Style)6;
		TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		MBMIOELEAND.alpha = 1440f;
		TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		MBMIOELEAND.transform.localScale = new Vector3(1962f, 800f, 918f);
	}

	private void PALDMHMDADB(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[2];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 0f) : (num4 < 0f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 1f);
		float fillAmount = (flag ? 1f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		if (ODFAFEEGGJK.Value1 == "percent")
		{
			HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
			GMCBBBAAGJO((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "seconds")
		{
			HFMJGJINAJK(MEJMLNDFDBP.DLDMHFBIEEO(num));
			GMCBBBAAGJO((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "damage")
		{
			HFMJGJINAJK(MEJMLNDFDBP.MAJBCINJAGF(num));
			GMCBBBAAGJO((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			HFMJGJINAJK(string.Empty);
			GMCBBBAAGJO(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			NONCNLCDIDD(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "percent")
			{
				NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "seconds")
			{
				NAECNOIDJBM(string.Format((!(num4 < 0f)) ? "+{0}" : "{0}", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "damage")
			{
				NAECNOIDJBM(string.Format((!(num4 < 0f)) ? "+{0}" : "{0}", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 47f, 15f, 88);
		}
		else
		{
			NAECNOIDJBM(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			HALLAKMKEEN();
		}
		else
		{
			EMDNEOBGFEB();
		}
	}

	private void OOHLHELGDGD()
	{
		float num = 15f;
		TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		GMBDMEAAFPG.color = Colours.greenDelivering;
		MBMIOELEAND.gameObject.SetActive(true);
		MBMIOELEAND.color = Color.white;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1234f * num, 867f, 1854f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 0;
		TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 1291f * num, new Vector3(1961f, 1413f, 1949f), new Vector3(1211f, 1836f, 1899f));
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 0;
	}

	public void KPPKINLPNNO(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = !IOIKKIIFOCB.upgradeSlots.bought || IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.BDAAHLLPPGN();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(1786f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		EHFNJLLILFE.gameObject.SetActive(false);
		CKBELNDIMJG.text = Localization.Localize("ArmyPower");
		if (flag)
		{
			bool jHFKBODINGN = IOIKKIIFOCB.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active && IOIKKIIFOCB.upgradeSlots.deliveringSlot.isSpecial;
			AGBNHIBHGFI(IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.guiStatistics[0], jHFKBODINGN);
		}
		else
		{
			PCGHFMMPDFG(IOIKKIIFOCB);
		}
	}

	public void IGEFMGGGOKP(LevelBehaviour IOIKKIIFOCB, bool LPFLPCOLHPJ)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!LPFLPCOLHPJ) ? 0 : 0];
		bool bought = IOIKKIIFOCB.upgradeSlots.bought;
		bool flag = IOIKKIIFOCB.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Locked || !IOIKKIIFOCB.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		float num = ((!LPFLPCOLHPJ) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!LPFLPCOLHPJ) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!LPFLPCOLHPJ) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			num3 = num;
		}
		float num4 = num3 - num;
		bool flag2 = num4 > 1145f;
		bool flag3 = num == num2;
		float num5 = ((!flag3) ? Mathf.Clamp01(num / num2) : 1448f);
		float fillAmount = ((!bought) ? num5 : (flag3 ? 1225f : ((!flag) ? num5 : Mathf.Clamp01(num3 / num2))));
		HMMKJFFOEFN.spriteName = ((!LPFLPCOLHPJ) ? "1" : "Database Message does not contain id or type:\n");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(1783f);
		EHFNJLLILFE.gameObject.SetActive(true);
		CKBELNDIMJG.text = ((!LPFLPCOLHPJ) ? Localization.Localize("CheckMessages") : Localization.Localize("game-ico-blind"));
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		NPECPIELDGI(MEJMLNDFDBP.MAGANIIGHON(num));
		HBNPCADFFAK((!flag3) ? MEJMLNDFDBP.MAGANIIGHON(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		HMMKJFFOEFN.color = ((!flag3) ? Colours.blue : color);
		KCDCGGKKMOM.color = ((!flag3) ? Colours.blue : color);
		PNBGMFFKJIP.color = ((!flag3) ? Color.white : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (bought)
		{
			if (flag3)
			{
				LCCCGDLKOKK(color);
			}
			else
			{
				NAECNOIDJBM((!flag2) ? string.Empty : string.Format(" ", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (flag && flag2)
			{
				HALLAKMKEEN();
			}
			else
			{
				CLNBNBJABKA();
			}
		}
		else
		{
			HDOEJCGICLJ(string.Empty);
			JGMECIBKBFG();
		}
	}

	private void HDOEJCGICLJ(string AMFBOIJIGKL)
	{
		MBMIOELEAND.gameObject.SetActive(true);
		GMBDMEAAFPG.gameObject.SetActive(false);
		GMBDMEAAFPG.text = AMFBOIJIGKL;
		KIIOABOEJBN.gameObject.SetActive(false);
	}

	private void LCHBCFKJGKH(Tuple<string, float[]> ODFAFEEGGJK)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[2];
		bool flag = num == num2;
		float iDEBKDPMPGM = num3 - num;
		bool flag2 = true;
		float num4 = ((!flag) ? Mathf.Clamp01(num / num2) : 1f);
		float fillAmount = ((!flag) ? num4 : 1f);
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		GMCBBBAAGJO((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.greenArena : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.greenArena : color);
		KCDCGGKKMOM.fillAmount = num4;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			NONCNLCDIDD(color);
		}
		else if (flag2)
		{
			NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(iDEBKDPMPGM));
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 47f, 15f, 88);
		}
	}

	private void LFJFHKHMNHL(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 639f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 259f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1275f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("GetActualIndex()\nCurPosX: {0}", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_CONFIRM_ERROR" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(782f / x);
		if (num2 < 69f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "isNormal" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1605f / x);
		}
		if (num2 < 1937f)
		{
			Debug.LogError("FB_Connect");
		}
		float num3 = Mathf.Clamp(num2, 387f, 987f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1907f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1796f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void BFKIJPDCKPM()
	{
		if (AJIBIAPCLIN.activeSelf)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 632f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 2;
			tweenScale.style = (UITweener.Style)4;
		}
	}

	private void PMLPKBGLPEL(Color HAJDGBEPIJF)
	{
		MBMIOELEAND.gameObject.SetActive(true);
		MBMIOELEAND.color = Color.white;
		GMBDMEAAFPG.gameObject.SetActive(true);
		KIIOABOEJBN.gameObject.SetActive(true);
		KIIOABOEJBN.color = HAJDGBEPIJF;
	}

	private void CINKKANIDDC(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		JKKDKNOOBCE.text = Localization.LocalizeFormat("ID_UNLOCKEDATTIER", num);
		MEJMLNDFDBP.COCBCFKJOJE(JKKDKNOOBCE, 25f, 20f, 320);
		for (int i = 0; i < KBCDCFBPJKB.Length; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		HMMKJFFOEFN.color = Colours.gray;
		GMCBBBAAGJO(string.Empty);
	}

	private void CINNCLELIJH(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 996f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 163f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 729f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("getValue", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "getStatus" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(17f / x);
		if (num2 < 1157f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "fr" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(99f / x);
		}
		if (num2 < 1955f)
		{
			Debug.LogError("resultMessage");
		}
		float num3 = Mathf.Clamp(num2, 1210f, 1609f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1795f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1036f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void IOBGBHNPFDB(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("Name", array);
		MEJMLNDFDBP.COCBCFKJOJE(JKKDKNOOBCE, 1927f, 1028f, -157);
		for (int i = 1; i < KBCDCFBPJKB.Length; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		HMMKJFFOEFN.color = Colours.gray;
		BCGJCGBNNAL(string.Empty);
	}

	private void GMCBBBAAGJO(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 25f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		CGNKNENMLPB.text = Localization.LocalizeFormat("ID_MAXSTAT", ECPOBELNKOO);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + " " + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(224f / x);
		if (num2 < 20f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + " " + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(224f / x);
		}
		if (num2 < 20f)
		{
			Debug.LogError("Problem for max! in army/weapon stats");
		}
		float num3 = Mathf.Clamp(num2, 20f, 25f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void HNIOBODENOJ()
	{
		float num = 359f;
		TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		GMBDMEAAFPG.color = Colours.greenDelivering;
		MBMIOELEAND.gameObject.SetActive(false);
		MBMIOELEAND.color = Color.white;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1234f * num, 1294f, 318f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 0;
		TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 397f * num, new Vector3(1482f, 1626f, 150f), new Vector3(83f, 1975f, 1066f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 0;
	}

	public void NPMJFOMLDIB(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = !IOIKKIIFOCB.upgradeSlots.bought || IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.isBought;
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(1711f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		EHFNJLLILFE.gameObject.SetActive(false);
		CKBELNDIMJG.text = Localization.Localize("ID_");
		if (flag)
		{
			bool jHFKBODINGN = IOIKKIIFOCB.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered && IOIKKIIFOCB.upgradeSlots.deliveringSlot.isSpecial;
			JMLDPDNABOE(IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.guiStatistics[0], jHFKBODINGN);
		}
		else
		{
			IOBGBHNPFDB(IOIKKIIFOCB);
		}
	}

	private void CMPFAGAEIGL(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[0];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 636f) : (num4 < 533f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 965f);
		float fillAmount = (flag ? 36f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		if (ODFAFEEGGJK.Value1 == "ID_WARNING_MAXVIDEOFEEDSSUBMITTED")
		{
			HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
			NNDBAHJHFML((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "RegisterCustomEvent()")
		{
			PCOLLELFIPE(MEJMLNDFDBP.DLDMHFBIEEO(num));
			BCGJCGBNNAL((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == " NOT OK!")
		{
			PCOLLELFIPE(MEJMLNDFDBP.MAJBCINJAGF(num));
			GMCBBBAAGJO((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			HFMJGJINAJK(string.Empty);
			NJCAFMINBBN(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			NONCNLCDIDD(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "25")
			{
				NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "Tier")
			{
				NAECNOIDJBM(string.Format((!(num4 < 1274f)) ? "StartOverTime_RPC" : "Measure Event With Event Items", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "Weapon delivery now is : ")
			{
				EGNJLGGLNOI(string.Format((!(num4 < 717f)) ? "ID_5SKIRMISHES" : "level", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 290f, 1410f, -35);
		}
		else
		{
			NAECNOIDJBM(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			HALLAKMKEEN();
		}
		else
		{
			GGOOBENGDBE();
		}
	}

	private void HFMJGJINAJK(string MKBPHBAAPBE)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(62f, 62f, 1f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(12f);
		PNBGMFFKJIP.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 62f, 20f, 155);
		NMFBHDFAAKL = PNBGMFFKJIP.transform.localScale;
		DGAIKOFGBFD = PNBGMFFKJIP.transform.localScale.MultiplyXY(1.4f);
	}

	private void BCGJCGBNNAL(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 526f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1974f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1147f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[0] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("Title", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "." + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1694f / x);
		if (num2 < 1419f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "Subtitle" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1698f / x);
		}
		if (num2 < 1645f)
		{
			Debug.LogError("{0}-firstTime-{1}");
		}
		float num3 = Mathf.Clamp(num2, 1252f, 1423f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1886f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 866f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void OMMJBAHCNNI()
	{
		Color color = MAKKOBHOPFJ[mCurrentType];
		Color to = NCFNBHOHBCE[mCurrentType];
		GMBDMEAAFPG.color = color;
		TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 581f, color, to);
		tweenColor.NumOfRepetitions = 1;
		tweenColor.style = UITweener.Style.Once;
		TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		MBMIOELEAND.alpha = 1498f;
		TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		MBMIOELEAND.transform.localScale = new Vector3(937f, 1499f, 1787f);
	}

	private void NPECPIELDGI(string MKBPHBAAPBE)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(1787f, 914f, 1872f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(1648f);
		PNBGMFFKJIP.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 1842f, 789f, 73);
		NMFBHDFAAKL = PNBGMFFKJIP.transform.localScale;
		DGAIKOFGBFD = PNBGMFFKJIP.transform.localScale.MultiplyXY(663f);
	}

	private void HALLAKMKEEN()
	{
		float num = 0.5f;
		TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		GMBDMEAAFPG.color = Colours.greenDelivering;
		MBMIOELEAND.gameObject.SetActive(true);
		MBMIOELEAND.color = Color.white;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 2f * num, 1f, 0f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 0;
		TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 2f * num, new Vector3(88f, 74f, 1f), new Vector3(176f, 148f, 1f));
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 0;
	}

	public void EKFPODLMPBE(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = !IOIKKIIFOCB.upgradeSlots.bought || IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.JFAELKHPLLA();
		EHFNJLLILFE.gameObject.SetActive(true);
		IOIKKIIFOCB.SetUpEliteIcon(HMMKJFFOEFN, EHFNJLLILFE, 1454f);
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition.ReplaceX(481f);
		CKBELNDIMJG.text = Localization.Localize("gamesPlayed");
		if (flag)
		{
			BMBMHIAMKLC(IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.guiStatistics[1]);
		}
		else
		{
			IALGNOPFKKH(IOIKKIIFOCB);
		}
	}

	public void FIBADDHLGCP(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = !IOIKKIIFOCB.upgradeSlots.bought || IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.isBought;
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(1974f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		EHFNJLLILFE.gameObject.SetActive(true);
		CKBELNDIMJG.text = Localization.Localize("ADDING SQUAD BUDDY WARCARD ");
		if (flag)
		{
			bool jHFKBODINGN = IOIKKIIFOCB.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering || IOIKKIIFOCB.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
			JMFBBGLPOAJ(IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.NEJNMDNOAKD()[0], jHFKBODINGN);
		}
		else
		{
			PCGHFMMPDFG(IOIKKIIFOCB);
		}
	}

	public void CKBECIJOAJM()
	{
		if (AJIBIAPCLIN.activeSelf)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 328f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 6;
			tweenScale.style = (UITweener.Style)5;
		}
	}

	private void EGNJLGGLNOI(string AMFBOIJIGKL)
	{
		MBMIOELEAND.gameObject.SetActive(true);
		GMBDMEAAFPG.gameObject.SetActive(false);
		GMBDMEAAFPG.text = AMFBOIJIGKL;
		KIIOABOEJBN.gameObject.SetActive(true);
	}

	public void IHJPBPBLPAF(LevelBehaviour IOIKKIIFOCB, bool LPFLPCOLHPJ)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.guiStatistics[(!LPFLPCOLHPJ) ? 1 : 1];
		bool bought = IOIKKIIFOCB.upgradeSlots.bought;
		bool flag = IOIKKIIFOCB.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.NotBuyed || IOIKKIIFOCB.upgradeSlots.deliveringSlot.isSpecial;
		float num = ((!LPFLPCOLHPJ) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!LPFLPCOLHPJ) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!LPFLPCOLHPJ) ? tuple.Value2[5] : LevelManager.instance.DamageFunction(tuple.Value2[6]));
		if (IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			num3 = num;
		}
		float num4 = num3 - num;
		bool flag2 = num4 > 127f;
		bool flag3 = num == num2;
		float num5 = ((!flag3) ? Mathf.Clamp01(num / num2) : 98f);
		float fillAmount = ((!bought) ? num5 : (flag3 ? 182f : ((!flag) ? num5 : Mathf.Clamp01(num3 / num2))));
		HMMKJFFOEFN.spriteName = ((!LPFLPCOLHPJ) ? "ShotFrequencyMinCannon" : "#AccoutCheck# missing ID from server");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(902f);
		EHFNJLLILFE.gameObject.SetActive(false);
		CKBELNDIMJG.text = ((!LPFLPCOLHPJ) ? Localization.Localize(" - {0}") : Localization.Localize("game-card-ico-paralyzethese"));
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		HFMJGJINAJK(MEJMLNDFDBP.MAGANIIGHON(num));
		HBNPCADFFAK((!flag3) ? MEJMLNDFDBP.MAGANIIGHON(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		HMMKJFFOEFN.color = ((!flag3) ? Colours.blue : color);
		KCDCGGKKMOM.color = ((!flag3) ? Colours.blue : color);
		PNBGMFFKJIP.color = ((!flag3) ? Color.white : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (bought)
		{
			if (flag3)
			{
				HNPABGOKNLK(color);
			}
			else
			{
				EGNJLGGLNOI((!flag2) ? string.Empty : string.Format("ID_FEATURE_MAGAZINE-DESCRIPTION", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (flag && flag2)
			{
				HALLAKMKEEN();
			}
			else
			{
				HHPHMOOCLGF();
			}
		}
		else
		{
			HDOEJCGICLJ(string.Empty);
			EMDNEOBGFEB();
		}
	}

	public void MEDFIABEFMP(LevelBehaviour IOIKKIIFOCB, bool LPFLPCOLHPJ)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.guiStatistics[(!LPFLPCOLHPJ) ? 1 : 1];
		bool bought = IOIKKIIFOCB.upgradeSlots.bought;
		bool flag = IOIKKIIFOCB.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Active || !IOIKKIIFOCB.upgradeSlots.deliveringSlot.isSpecial;
		float num = ((!LPFLPCOLHPJ) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!LPFLPCOLHPJ) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!LPFLPCOLHPJ) ? tuple.Value2[4] : LevelManager.instance.DamageFunction(tuple.Value2[3]));
		if (IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			num3 = num;
		}
		float num4 = num3 - num;
		bool flag2 = num4 > 1570f;
		bool flag3 = num == num2;
		float num5 = ((!flag3) ? Mathf.Clamp01(num / num2) : 745f);
		float fillAmount = ((!bought) ? num5 : (flag3 ? 1950f : ((!flag) ? num5 : Mathf.Clamp01(num3 / num2))));
		HMMKJFFOEFN.spriteName = ((!LPFLPCOLHPJ) ? "nextGenerate" : "withAttribute3");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(1962f);
		EHFNJLLILFE.gameObject.SetActive(true);
		CKBELNDIMJG.text = ((!LPFLPCOLHPJ) ? Localization.Localize("ID_BUYSTARTERPACK") : Localization.Localize("Upgrades"));
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(true);
		PCOLLELFIPE(MEJMLNDFDBP.MAGANIIGHON(num));
		GMCBBBAAGJO((!flag3) ? MEJMLNDFDBP.MAGANIIGHON(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		HMMKJFFOEFN.color = ((!flag3) ? Colours.blue : color);
		KCDCGGKKMOM.color = ((!flag3) ? Colours.blue : color);
		PNBGMFFKJIP.color = ((!flag3) ? Color.white : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (bought)
		{
			if (flag3)
			{
				HNPABGOKNLK(color);
			}
			else
			{
				HDOEJCGICLJ((!flag2) ? string.Empty : string.Format("NO any UIroot - failed ", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (flag && flag2)
			{
				HNIOBODENOJ();
			}
			else
			{
				JGMECIBKBFG();
			}
		}
		else
		{
			EGNJLGGLNOI(string.Empty);
			CLNBNBJABKA();
		}
	}

	private void JMLDPDNABOE(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[0];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 564f) : (num4 < 899f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 1338f);
		float fillAmount = (flag ? 380f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(true);
		if (ODFAFEEGGJK.Value1 == "opponent defense shooting delayed")
		{
			NPECPIELDGI(MEJMLNDFDBP.JJBMMICPIIG(num));
			FPODNPBANAE((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "ID_SECONDS")
		{
			HFMJGJINAJK(MEJMLNDFDBP.DLDMHFBIEEO(num));
			CINNCLELIJH((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "ID_COLLECTXELITEPARTSX")
		{
			NPECPIELDGI(MEJMLNDFDBP.MAJBCINJAGF(num));
			CINNCLELIJH((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			HFMJGJINAJK(string.Empty);
			KLDHNMGJGFH(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			MBPCPMHMDJG(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "ID_ZEROSECONDS")
			{
				NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "About to show Buy Power Band Reminder: ")
			{
				EGNJLGGLNOI(string.Format((!(num4 < 1777f)) ? "x" : "ID_CONFIRM_INAPP_VALIDATION", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "DelayMax")
			{
				NAECNOIDJBM(string.Format((!(num4 < 66f)) ? "MINE" : "ID_BRONZEPACK", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 377f, 182f, -42);
		}
		else
		{
			HDOEJCGICLJ(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			KCEPIPLNNOG();
		}
		else
		{
			HHPHMOOCLGF();
		}
	}

	private void GGOOBENGDBE()
	{
		Color color = MAKKOBHOPFJ[mCurrentType];
		Color to = NCFNBHOHBCE[mCurrentType];
		GMBDMEAAFPG.color = color;
		TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 1007f, color, to);
		tweenColor.NumOfRepetitions = 1;
		tweenColor.style = (UITweener.Style)7;
		TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		MBMIOELEAND.alpha = 1673f;
		TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		MBMIOELEAND.transform.localScale = new Vector3(1197f, 1284f, 475f);
	}

	private void MBPCPMHMDJG(Color HAJDGBEPIJF)
	{
		MBMIOELEAND.gameObject.SetActive(true);
		MBMIOELEAND.color = Color.white;
		GMBDMEAAFPG.gameObject.SetActive(true);
		KIIOABOEJBN.gameObject.SetActive(true);
		KIIOABOEJBN.color = HAJDGBEPIJF;
	}

	private void HNPABGOKNLK(Color HAJDGBEPIJF)
	{
		MBMIOELEAND.gameObject.SetActive(true);
		MBMIOELEAND.color = Color.white;
		GMBDMEAAFPG.gameObject.SetActive(false);
		KIIOABOEJBN.gameObject.SetActive(false);
		KIIOABOEJBN.color = HAJDGBEPIJF;
	}

	public void KOOLFCFAAFF(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isBought;
		EHFNJLLILFE.gameObject.SetActive(false);
		IOIKKIIFOCB.SetUpEliteIcon(HMMKJFFOEFN, EHFNJLLILFE, 1658f);
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition.ReplaceX(123f);
		CKBELNDIMJG.text = Localization.Localize("forever");
		if (flag)
		{
			BMBMHIAMKLC(IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.NEJNMDNOAKD()[1]);
		}
		else
		{
			IALGNOPFKKH(IOIKKIIFOCB);
		}
	}

	private void NJCAFMINBBN(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 799f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 892f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 936f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("FuseRewardedAdOptionKey_ShowPostRoll", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "DailyBonus" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1893f / x);
		if (num2 < 658f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "Xp" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(41f / x);
		}
		if (num2 < 135f)
		{
			Debug.LogError("[CFX_SpawnSystem.GetNextPoolObject()] Object hasn't been preloaded: ");
		}
		float num3 = Mathf.Clamp(num2, 552f, 449f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 325f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 37f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void FKFIDAJLNEC(Tuple<string, float[]> ODFAFEEGGJK)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[8];
		bool flag = num == num2;
		float iDEBKDPMPGM = num3 - num;
		bool flag2 = true;
		float num4 = ((!flag) ? Mathf.Clamp01(num / num2) : 82f);
		float fillAmount = ((!flag) ? num4 : 1810f);
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		MHFFPPHHHLO((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.greenArena : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.greenArena : color);
		KCDCGGKKMOM.fillAmount = num4;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			NONCNLCDIDD(color);
		}
		else if (flag2)
		{
			NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(iDEBKDPMPGM));
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 571f, 801f, -102);
		}
	}

	private void IMHJFCJMGKB(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[0];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 823f) : (num4 < 1832f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 944f);
		float fillAmount = (flag ? 805f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		if (ODFAFEEGGJK.Value1 == "ID_LOADING")
		{
			HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
			NNDBAHJHFML((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "CardsInCardPack")
		{
			HFMJGJINAJK(MEJMLNDFDBP.DLDMHFBIEEO(num));
			KLDHNMGJGFH((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "withRevenue")
		{
			NPECPIELDGI(MEJMLNDFDBP.MAJBCINJAGF(num));
			NNDBAHJHFML((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			PCOLLELFIPE(string.Empty);
			GMCBBBAAGJO(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			NONCNLCDIDD(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "can not find currency for: ")
			{
				EGNJLGGLNOI(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "ID_CONFIRM_ALREADYLEADER")
			{
				HDOEJCGICLJ(string.Format((!(num4 < 1546f)) ? "New hearth bought!" : "Days_Since_Install", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "OK")
			{
				NAECNOIDJBM(string.Format((!(num4 < 1484f)) ? "special" : "Measure Session", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 1998f, 291f, 61);
		}
		else
		{
			EGNJLGGLNOI(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			AIICKEPAEGD();
		}
		else
		{
			HHPHMOOCLGF();
		}
	}

	private void LCCCGDLKOKK(Color HAJDGBEPIJF)
	{
		MBMIOELEAND.gameObject.SetActive(false);
		MBMIOELEAND.color = Color.white;
		GMBDMEAAFPG.gameObject.SetActive(false);
		KIIOABOEJBN.gameObject.SetActive(false);
		KIIOABOEJBN.color = HAJDGBEPIJF;
	}

	public void KGOKAPLKADI(LevelBehaviour IOIKKIIFOCB, bool LPFLPCOLHPJ)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!LPFLPCOLHPJ) ? 0 : 0];
		bool bought = IOIKKIIFOCB.upgradeSlots.bought;
		bool flag = IOIKKIIFOCB.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Active || IOIKKIIFOCB.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		float num = ((!LPFLPCOLHPJ) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!LPFLPCOLHPJ) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!LPFLPCOLHPJ) ? tuple.Value2[5] : LevelManager.instance.DamageFunction(tuple.Value2[2]));
		if (IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			num3 = num;
		}
		float num4 = num3 - num;
		bool flag2 = num4 > 1331f;
		bool flag3 = num == num2;
		float num5 = ((!flag3) ? Mathf.Clamp01(num / num2) : 1280f);
		float fillAmount = ((!bought) ? num5 : (flag3 ? 1892f : ((!flag) ? num5 : Mathf.Clamp01(num3 / num2))));
		HMMKJFFOEFN.spriteName = ((!LPFLPCOLHPJ) ? "FuseSDK instance not initialized. Awake may not have been called." : "{0} {1}");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(1335f);
		EHFNJLLILFE.gameObject.SetActive(true);
		CKBELNDIMJG.text = ((!LPFLPCOLHPJ) ? Localization.Localize("N") : Localization.Localize("S"));
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		NPECPIELDGI(MEJMLNDFDBP.MAGANIIGHON(num));
		BCGJCGBNNAL((!flag3) ? MEJMLNDFDBP.MAGANIIGHON(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		HMMKJFFOEFN.color = ((!flag3) ? Colours.blue : color);
		KCDCGGKKMOM.color = ((!flag3) ? Colours.blue : color);
		PNBGMFFKJIP.color = ((!flag3) ? Color.white : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (bought)
		{
			if (flag3)
			{
				LCCCGDLKOKK(color);
			}
			else
			{
				HDOEJCGICLJ((!flag2) ? string.Empty : string.Format("ID_BUY", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (flag && flag2)
			{
				KCEPIPLNNOG();
			}
			else
			{
				GGOOBENGDBE();
			}
		}
		else
		{
			HDOEJCGICLJ(string.Empty);
			JGMECIBKBFG();
		}
	}

	public void HGCDFJNMCPI(LevelBehaviour IOIKKIIFOCB, bool LPFLPCOLHPJ)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.guiStatistics[LPFLPCOLHPJ ? 1 : 0];
		bool bought = IOIKKIIFOCB.upgradeSlots.bought;
		bool flag = IOIKKIIFOCB.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Locked || IOIKKIIFOCB.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		float num = ((!LPFLPCOLHPJ) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!LPFLPCOLHPJ) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!LPFLPCOLHPJ) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[4]));
		if (IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			num3 = num;
		}
		float num4 = num3 - num;
		bool flag2 = num4 > 181f;
		bool flag3 = num == num2;
		float num5 = ((!flag3) ? Mathf.Clamp01(num / num2) : 1766f);
		float fillAmount = ((!bought) ? num5 : (flag3 ? 154f : ((!flag) ? num5 : Mathf.Clamp01(num3 / num2))));
		HMMKJFFOEFN.spriteName = ((!LPFLPCOLHPJ) ? "percent" : "VisualType");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(801f);
		EHFNJLLILFE.gameObject.SetActive(true);
		CKBELNDIMJG.text = ((!LPFLPCOLHPJ) ? Localization.Localize("ID_SQUADEVENT") : Localization.Localize("DecalId"));
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		HFMJGJINAJK(MEJMLNDFDBP.MAGANIIGHON(num));
		CINNCLELIJH((!flag3) ? MEJMLNDFDBP.MAGANIIGHON(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		HMMKJFFOEFN.color = ((!flag3) ? Colours.blue : color);
		KCDCGGKKMOM.color = ((!flag3) ? Colours.blue : color);
		PNBGMFFKJIP.color = ((!flag3) ? Color.white : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (bought)
		{
			if (flag3)
			{
				PMLPKBGLPEL(color);
			}
			else
			{
				NAECNOIDJBM((!flag2) ? string.Empty : string.Format("GamesMetadata", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (flag && flag2)
			{
				HALLAKMKEEN();
			}
			else
			{
				HHPHMOOCLGF();
			}
		}
		else
		{
			HDOEJCGICLJ(string.Empty);
			OMMJBAHCNNI();
		}
	}

	private void IALGNOPFKKH(LevelBehaviour IOIKKIIFOCB)
	{
		int currentParts = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.currentParts;
		int upgradePriceParts = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.upgradePriceParts;
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		INLFNIJAILN.text = Localization.LocalizeFormat("ID_COLLECTXELITEPARTSX", Colours.stringGreenArena, upgradePriceParts, Colours.stringWhite, currentParts);
		MEJMLNDFDBP.COCBCFKJOJE(INLFNIJAILN, 25f, 20f, 490);
		HMMKJFFOEFN.color = Colours.gray;
		GMCBBBAAGJO(string.Empty);
	}

	public void AnimateStat()
	{
		if (AJIBIAPCLIN.activeSelf)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 4f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 2;
			tweenScale.style = UITweener.Style.PingPong;
		}
	}

	private void JMFBBGLPOAJ(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[3];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 1012f) : (num4 < 114f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 1594f);
		float fillAmount = (flag ? 288f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		if (ODFAFEEGGJK.Value1 == "PlayerUnitPower")
		{
			NPECPIELDGI(MEJMLNDFDBP.JJBMMICPIIG(num));
			JINABAKLCLB((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "Action ")
		{
			NPECPIELDGI(MEJMLNDFDBP.DLDMHFBIEEO(num));
			CINNCLELIJH((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "ID_YOURFRIENDHASDENIED")
		{
			HFMJGJINAJK(MEJMLNDFDBP.MAJBCINJAGF(num));
			LFJFHKHMNHL((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			PCOLLELFIPE(string.Empty);
			GMCBBBAAGJO(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			PMLPKBGLPEL(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "Can not find asset {0}")
			{
				NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "sale")
			{
				HDOEJCGICLJ(string.Format((!(num4 < 1751f)) ? "InstantBattleTime" : " NOT OK!\t\t\t\t\t\t", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "ID_GUI_REPORTABUSE_LISTITEM8")
			{
				HDOEJCGICLJ(string.Format((!(num4 < 1186f)) ? "Connection_Dropped" : "Player_Had_To_Select_Grenade", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 1310f, 1324f, -28);
		}
		else
		{
			EGNJLGGLNOI(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			AIICKEPAEGD();
		}
		else
		{
			JGMECIBKBFG();
		}
	}

	private void HHPHMOOCLGF()
	{
		Color color = MAKKOBHOPFJ[mCurrentType];
		Color to = NCFNBHOHBCE[mCurrentType];
		GMBDMEAAFPG.color = color;
		TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 357f, color, to);
		tweenColor.NumOfRepetitions = 1;
		tweenColor.style = UITweener.Style.PingPong;
		TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		MBMIOELEAND.alpha = 298f;
		TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		MBMIOELEAND.transform.localScale = new Vector3(1348f, 1138f, 32f);
	}

	private void HMLGKGBANCH(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[0];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 1518f) : (num4 < 1592f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 1216f);
		float fillAmount = (flag ? 676f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		if (ODFAFEEGGJK.Value1 == "StoreEntryRoute")
		{
			NPECPIELDGI(MEJMLNDFDBP.JJBMMICPIIG(num));
			FPODNPBANAE((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "ID_HOU")
		{
			PCOLLELFIPE(MEJMLNDFDBP.DLDMHFBIEEO(num));
			BCGJCGBNNAL((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "shield_idle")
		{
			NPECPIELDGI(MEJMLNDFDBP.MAJBCINJAGF(num));
			NNDBAHJHFML((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			NPECPIELDGI(string.Empty);
			NNDBAHJHFML(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			LCCCGDLKOKK(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "sc")
			{
				EGNJLGGLNOI(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "menu-top-vip")
			{
				NAECNOIDJBM(string.Format((!(num4 < 1965f)) ? "discount" : "ID_WARNING_BADVERSIONERROR_TEXT", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "()Z")
			{
				NAECNOIDJBM(string.Format((!(num4 < 1212f)) ? "shield_hide" : "Play_Card_Tutorial_Duration", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 1707f, 512f, -77);
		}
		else
		{
			EGNJLGGLNOI(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			HNIOBODENOJ();
		}
		else
		{
			EMDNEOBGFEB();
		}
	}

	private void KCEPIPLNNOG()
	{
		float num = 859f;
		TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		GMBDMEAAFPG.color = Colours.greenDelivering;
		MBMIOELEAND.gameObject.SetActive(false);
		MBMIOELEAND.color = Color.white;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 405f * num, 1290f, 572f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 0;
		TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 1293f * num, new Vector3(1777f, 1170f, 902f), new Vector3(961f, 1963f, 923f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
	}

	private void AIICKEPAEGD()
	{
		float num = 438f;
		TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		GMBDMEAAFPG.color = Colours.greenDelivering;
		MBMIOELEAND.gameObject.SetActive(true);
		MBMIOELEAND.color = Color.white;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 176f * num, 1949f, 1222f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 1;
		TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 323f * num, new Vector3(1863f, 1987f, 1959f), new Vector3(646f, 480f, 1964f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 0;
	}

	public void IFLGBHCKJPM(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = !IOIKKIIFOCB.upgradeSlots.bought || IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.BDAAHLLPPGN();
		EHFNJLLILFE.gameObject.SetActive(true);
		IOIKKIIFOCB.SetUpEliteIcon(HMMKJFFOEFN, EHFNJLLILFE, 641f);
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition.ReplaceX(896f);
		CKBELNDIMJG.text = Localization.Localize(" succesfully joined squad ");
		if (flag)
		{
			MIHLNKGJBEP(IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.NEJNMDNOAKD()[1]);
		}
		else
		{
			IALGNOPFKKH(IOIKKIIFOCB);
		}
	}

	public void INOOFGPBEIM(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = !IOIKKIIFOCB.upgradeSlots.bought || IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isBought;
		EHFNJLLILFE.gameObject.SetActive(false);
		IOIKKIIFOCB.SetUpEliteIcon(HMMKJFFOEFN, EHFNJLLILFE, 894f);
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition.ReplaceX(346f);
		CKBELNDIMJG.text = Localization.Localize("{0}{1}[-]");
		if (flag)
		{
			JIAJEBPHHDG(IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.guiStatistics[0]);
		}
		else
		{
			HEEDKGCFKKP(IOIKKIIFOCB);
		}
	}

	public void CHKCKLDAANJ(LevelBehaviour IOIKKIIFOCB)
	{
		bool flag = IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isBought;
		EHFNJLLILFE.gameObject.SetActive(true);
		IOIKKIIFOCB.SetUpEliteIcon(HMMKJFFOEFN, EHFNJLLILFE, 1533f);
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition.ReplaceX(1679f);
		CKBELNDIMJG.text = Localization.Localize("Helicopter");
		if (flag)
		{
			JIAJEBPHHDG(IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.guiStatistics[1]);
		}
		else
		{
			IALGNOPFKKH(IOIKKIIFOCB);
		}
	}

	private void AIBCMBPGODE(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[1];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 1061f) : (num4 < 405f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 1678f);
		float fillAmount = (flag ? 1935f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(false);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(true);
		if (ODFAFEEGGJK.Value1 == "VipReward1")
		{
			PCOLLELFIPE(MEJMLNDFDBP.JJBMMICPIIG(num));
			NJCAFMINBBN((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "RE-CONNECTING CALLED ")
		{
			NPECPIELDGI(MEJMLNDFDBP.DLDMHFBIEEO(num));
			BCGJCGBNNAL((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "ID_STARTERASSIGNMENT")
		{
			NPECPIELDGI(MEJMLNDFDBP.MAJBCINJAGF(num));
			JINABAKLCLB((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			NPECPIELDGI(string.Empty);
			NNDBAHJHFML(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			ONICKKEHECG(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "/PC/")
			{
				NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "_DistanceParams")
			{
				NAECNOIDJBM(string.Format((!(num4 < 1874f)) ? "game-card-gold" : "ID_WARNING_INCORRECTAMOUNTOFELITEPARTS", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "IOAJFNMOGOD")
			{
				HDOEJCGICLJ(string.Format((!(num4 < 514f)) ? "WithdrewWarcard-{0}-{1}-{2}" : "LowLevelSilverRarity", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 544f, 339f, -118);
		}
		else
		{
			NAECNOIDJBM(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			HALLAKMKEEN();
		}
		else
		{
			HHPHMOOCLGF();
		}
	}

	public void OEKBNBEPBDB(LevelBehaviour IOIKKIIFOCB, bool LPFLPCOLHPJ)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!LPFLPCOLHPJ) ? 0 : 0];
		bool bought = IOIKKIIFOCB.upgradeSlots.bought;
		bool flag = IOIKKIIFOCB.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivered || !IOIKKIIFOCB.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		float num = ((!LPFLPCOLHPJ) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!LPFLPCOLHPJ) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!LPFLPCOLHPJ) ? tuple.Value2[3] : LevelManager.instance.DamageFunction(tuple.Value2[8]));
		if (IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			num3 = num;
		}
		float num4 = num3 - num;
		bool flag2 = num4 > 432f;
		bool flag3 = num == num2;
		float num5 = ((!flag3) ? Mathf.Clamp01(num / num2) : 1789f);
		float fillAmount = ((!bought) ? num5 : (flag3 ? 1857f : ((!flag) ? num5 : Mathf.Clamp01(num3 / num2))));
		HMMKJFFOEFN.spriteName = ((!LPFLPCOLHPJ) ? "Sniper_Tutorial_Played" : "null");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.transform.localPosition = HMMKJFFOEFN.transform.localPosition.ReplaceX(374f);
		EHFNJLLILFE.gameObject.SetActive(false);
		CKBELNDIMJG.text = ((!LPFLPCOLHPJ) ? Localization.Localize("PNManager: Received event: ") : Localization.Localize("N"));
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		HFMJGJINAJK(MEJMLNDFDBP.MAGANIIGHON(num));
		FPODNPBANAE((!flag3) ? MEJMLNDFDBP.MAGANIIGHON(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		HMMKJFFOEFN.color = ((!flag3) ? Colours.blue : color);
		KCDCGGKKMOM.color = ((!flag3) ? Colours.blue : color);
		PNBGMFFKJIP.color = ((!flag3) ? Color.white : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (bought)
		{
			if (flag3)
			{
				LCCCGDLKOKK(color);
			}
			else
			{
				HDOEJCGICLJ((!flag2) ? string.Empty : string.Format("128 END", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (flag && flag2)
			{
				KCEPIPLNNOG();
			}
			else
			{
				OMMJBAHCNNI();
			}
		}
		else
		{
			HDOEJCGICLJ(string.Empty);
			OMMJBAHCNNI();
		}
	}

	private void MHFFPPHHHLO(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 584f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 898f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1288f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[0] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("Data", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_CONFIRM_RESTORE" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(839f / x);
		if (num2 < 925f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "MessageId" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(609f / x);
		}
		if (num2 < 1284f)
		{
			Debug.LogError("ID_STAT_KILLS");
		}
		float num3 = Mathf.Clamp(num2, 307f, 1872f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1813f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1806f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void FPODNPBANAE(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 341f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1584f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 817f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("accepted", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "AtlasPreparer.LoadImagesCoroutine" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(480f / x);
		if (num2 < 758f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "REMOVING WARCARD: \"{0}\" FROM DEPOSITED WARCARDS" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1408f / x);
		}
		if (num2 < 1574f)
		{
			Debug.LogError("Experience");
		}
		float num3 = Mathf.Clamp(num2, 1587f, 1130f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 875f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 724f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void NLFOOHCPAHH(Tuple<string, float[]> ODFAFEEGGJK, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[6];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 553f) : (num4 < 700f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 1939f);
		float fillAmount = (flag ? 1051f : ((!JHFKBODINGN) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		if (ODFAFEEGGJK.Value1 == "true")
		{
			HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
			BCGJCGBNNAL((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "OnConnectionFailed: restarting minus dogtag")
		{
			NPECPIELDGI(MEJMLNDFDBP.DLDMHFBIEEO(num));
			LFJFHKHMNHL((!flag) ? MEJMLNDFDBP.DLDMHFBIEEO(num2) : string.Empty);
		}
		else if (ODFAFEEGGJK.Value1 == "N1")
		{
			PCOLLELFIPE(MEJMLNDFDBP.MAJBCINJAGF(num));
			NJCAFMINBBN((!flag) ? MEJMLNDFDBP.MAJBCINJAGF(num2) : string.Empty);
		}
		else
		{
			NPECPIELDGI(string.Empty);
			BCGJCGBNNAL(string.Empty);
		}
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.yellow : color);
		KCDCGGKKMOM.fillAmount = num5;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			HNPABGOKNLK(color);
		}
		else if (flag3)
		{
			if (ODFAFEEGGJK.Value1 == "Awake '{0}'")
			{
				EGNJLGGLNOI(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "ID_WEAPON2UPGRADE_WEAPON1BUY")
			{
				NAECNOIDJBM(string.Format((!(num4 < 1322f)) ? "Error - wrong column names and values count ({0} != {1}) for sheet {2}" : "ID_GETSP", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "ID_CATEGORY_SMG")
			{
				NAECNOIDJBM(string.Format((!(num4 < 641f)) ? "Daily" : "SpecialPackFromServer", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 793f, 1840f, 80);
		}
		else
		{
			HDOEJCGICLJ(string.Empty);
		}
		if (JHFKBODINGN && flag3)
		{
			AIICKEPAEGD();
		}
		else
		{
			GGOOBENGDBE();
		}
	}

	private void MIHLNKGJBEP(Tuple<string, float[]> ODFAFEEGGJK)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[3];
		bool flag = num == num2;
		float iDEBKDPMPGM = num3 - num;
		bool flag2 = false;
		float num4 = ((!flag) ? Mathf.Clamp01(num / num2) : 1671f);
		float fillAmount = ((!flag) ? num4 : 1996f);
		FOLLFHBFNMF.SetActive(true);
		JAPEPJAHLIA.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		BCGJCGBNNAL((!flag) ? MEJMLNDFDBP.JJBMMICPIIG(num2) : string.Empty);
		Color color = DCELBNFFEHN[mCurrentType];
		PNBGMFFKJIP.color = ((!flag) ? Color.white : color);
		HMMKJFFOEFN.color = ((!flag) ? Colours.greenArena : color);
		KCDCGGKKMOM.color = ((!flag) ? Colours.greenArena : color);
		KCDCGGKKMOM.fillAmount = num4;
		OCMNNPMNOCB.fillAmount = fillAmount;
		if (flag)
		{
			NONCNLCDIDD(color);
		}
		else if (flag2)
		{
			EGNJLGGLNOI(MEJMLNDFDBP.DPAFFLMAFJG(iDEBKDPMPGM));
			MEJMLNDFDBP.COCBCFKJOJE(GMBDMEAAFPG, 857f, 1593f, 113);
		}
	}

	private void NAECNOIDJBM(string AMFBOIJIGKL)
	{
		MBMIOELEAND.gameObject.SetActive(false);
		GMBDMEAAFPG.gameObject.SetActive(true);
		GMBDMEAAFPG.text = AMFBOIJIGKL;
		KIIOABOEJBN.gameObject.SetActive(false);
	}

	private void KLDHNMGJGFH(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 219f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1825f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 977f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("myapp://myval1/myval2", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "Dialog_Clicked" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(710f / x);
		if (num2 < 1290f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_EMBLEM" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1940f / x);
		}
		if (num2 < 1426f)
		{
			Debug.LogError("Title");
		}
		float num3 = Mathf.Clamp(num2, 1831f, 486f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1682f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1757f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void JGMECIBKBFG()
	{
		Color color = MAKKOBHOPFJ[mCurrentType];
		Color to = NCFNBHOHBCE[mCurrentType];
		GMBDMEAAFPG.color = color;
		TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 1035f, color, to);
		tweenColor.NumOfRepetitions = 0;
		tweenColor.style = (UITweener.Style)4;
		TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		MBMIOELEAND.alpha = 503f;
		TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		MBMIOELEAND.transform.localScale = new Vector3(1539f, 155f, 1f);
	}

	private void EMDNEOBGFEB()
	{
		Color color = MAKKOBHOPFJ[mCurrentType];
		Color to = NCFNBHOHBCE[mCurrentType];
		GMBDMEAAFPG.color = color;
		TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 0.6f, color, to);
		tweenColor.NumOfRepetitions = 0;
		tweenColor.style = UITweener.Style.PingPong;
		TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		MBMIOELEAND.alpha = 1f;
		TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		MBMIOELEAND.transform.localScale = new Vector3(88f, 74f, 1f);
	}
}
