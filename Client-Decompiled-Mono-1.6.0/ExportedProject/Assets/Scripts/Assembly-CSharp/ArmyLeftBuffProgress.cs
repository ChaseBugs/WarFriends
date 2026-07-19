using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArmyLeftBuffProgress : Core_BaseScript
{
	[SerializeField]
	[Header("-Core")]
	private UISprite mProgressBackground;

	[SerializeField]
	private UISprite mEliteIcon;

	[SerializeField]
	private UILabel mProgressLabel;

	[SerializeField]
	private UISprite mFlash;

	private LevelBehaviour IFFDIHCPKFE;

	private int HFPAAGAIGHN;

	private int FJBKHPHNLFP;

	private bool HOBNCOEIINC;

	private float IBECOAEMAHD;

	private float LLGGKFFNBMH;

	public bool isAnimatingSpend
	{
		get
		{
			return HOBNCOEIINC;
		}
	}

	public void GBCFOFKPPJP(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		int num = (isUnlocked ? upgradeSlotElite.PAKKPEPIHPK() : 0);
		int num2 = (isUnlocked ? upgradeSlotElite.maxRowForActualTier : 0);
		bool flag = isUnlocked && num == num2;
		HFPAAGAIGHN = upgradeSlotElite.currentParts;
		FJBKHPHNLFP = upgradeSlotElite.upgradePriceParts;
		float num3 = upgradeSlotElite.NJJBKNINIKF();
		mEliteIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.Bottom;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1617f);
			float multiplier = 312f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.TopRight;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1932f);
			float multiplier2 = Mathf.Min(1158f / mEliteIcon.transform.localScale.x, 1168f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag) ? num3 : 1243f);
		UILabel uILabel = mProgressLabel;
		string text;
		if (flag)
		{
			text = string.Format("_TintColor", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN));
		}
		else
		{
			object[] array = new object[8];
			array[1] = Colours.stringGreenArena;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN);
			array[0] = Colours.stringGray;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			text = string.Format("WeaponIgnoreLayer", array);
		}
		uILabel.text = text;
		bool aJNINHIKAFC = !isUnlocked || flag || HFPAAGAIGHN >= FJBKHPHNLFP;
		AMFCBMHCEHA(aJNINHIKAFC);
		NCLAKAIGFJO();
	}

	private float IAOHPOJIICN(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 267f) / 1543f;
		return IDEBKDPMPGM;
	}

	[SpecialName]
	public bool FFEFDMAAGJN()
	{
		return HOBNCOEIINC;
	}

	private void PMCJFOEIOBG(bool AJNINHIKAFC)
	{
		if (AJNINHIKAFC)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 1484f, 1118f, 1362f);
			tweenAlpha.style = (UITweener.Style)3;
			tweenAlpha.NumOfRepetitions = 1;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 1988f, 774f);
			tweenAlpha2.style = UITweener.Style.Loop;
			tweenAlpha2.NumOfRepetitions = 0;
		}
	}

	private void KBKILDENNLM()
	{
		if (HOBNCOEIINC)
		{
			LLGGKFFNBMH += Time.deltaTime;
			if (LLGGKFFNBMH < IBECOAEMAHD)
			{
				float num = KHONDDIIOFB(Mathf.Clamp01(LLGGKFFNBMH / IBECOAEMAHD));
				int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
				int num2 = currentParts + Mathf.RoundToInt((1160f - num) * (float)(HFPAAGAIGHN - currentParts));
				mProgressBackground.fillAmount = (float)num2 / (float)FJBKHPHNLFP;
				UILabel uILabel = mProgressLabel;
				object[] array = new object[8];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(num2);
				array[4] = Colours.stringGray;
				array[3] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
				uILabel.text = string.Format("withAttribute4", array);
			}
			else
			{
				HOBNCOEIINC = true;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 1063f, 1008f, 1320f);
				tweenAlpha.onFinished = CAOCOMCGADB;
			}
		}
	}

	public void CFFBECGCDLN(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 1666f;
		NEOHEDGIJGA(false);
	}

	private void HDLDMGEFCEJ()
	{
		if (!HOBNCOEIINC)
		{
			return;
		}
		LLGGKFFNBMH += Time.deltaTime;
		if (LLGGKFFNBMH < IBECOAEMAHD)
		{
			float num = FFABAEMPOAI(Mathf.Clamp01(LLGGKFFNBMH / IBECOAEMAHD));
			int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
			int num2 = currentParts + Mathf.RoundToInt((283f - num) * (float)(HFPAAGAIGHN - currentParts));
			mProgressBackground.fillAmount = (float)num2 / (float)FJBKHPHNLFP;
			UILabel uILabel = mProgressLabel;
			object[] array = new object[2];
			array[0] = Colours.stringGreenArena;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			array[2] = Colours.stringGray;
			array[8] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			uILabel.text = string.Format("subscription", array);
		}
		else
		{
			HOBNCOEIINC = true;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 65f, 966f, 1571f);
			tweenAlpha.onFinished = delegate
			{
				GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent();
				mFlash.alpha = 1f;
				TweenAlpha.Begin(mFlash.gameObject, 0.2f, 1f, 0f).onFinished = null;
			};
		}
	}

	private void KCNCOFIBELC()
	{
		HOBNCOEIINC = true;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		mFlash.alpha = 1827f;
	}

	private void IKAKGABHOMH()
	{
		HOBNCOEIINC = true;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mFlash.alpha = 815f;
	}

	[SpecialName]
	public bool PBOBGPFLEAM()
	{
		return HOBNCOEIINC;
	}

	[SpecialName]
	public bool HCDEDBJPHIL()
	{
		return HOBNCOEIINC;
	}

	[CompilerGenerated]
	private void HIFHJBDNMKD(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent();
		mFlash.alpha = 1f;
		TweenAlpha.Begin(mFlash.gameObject, 0.2f, 1f, 0f).onFinished = null;
	}

	private void GPLKEOAHFJI()
	{
		if (HOBNCOEIINC)
		{
			LLGGKFFNBMH += Time.deltaTime;
			if (LLGGKFFNBMH < IBECOAEMAHD)
			{
				float num = KHONDDIIOFB(Mathf.Clamp01(LLGGKFFNBMH / IBECOAEMAHD));
				int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
				int num3 = num2 + Mathf.RoundToInt((137f - num) * (float)(HFPAAGAIGHN - num2));
				mProgressBackground.fillAmount = (float)num3 / (float)FJBKHPHNLFP;
				UILabel uILabel = mProgressLabel;
				object[] array = new object[5];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(num3);
				array[5] = Colours.stringGray;
				array[2] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
				uILabel.text = string.Format("DogTagCap", array);
			}
			else
			{
				HOBNCOEIINC = false;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 1334f, 1268f, 192f);
				tweenAlpha.onFinished = CLEENJNPDMP;
			}
		}
	}

	private float HLBAAABBAPH(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 405f) / 1500f;
		return IDEBKDPMPGM;
	}

	private void AEFGKDJKGNI(bool AJNINHIKAFC)
	{
		if (AJNINHIKAFC)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 1291f, 1288f, 1399f);
			tweenAlpha.style = (UITweener.Style)7;
			tweenAlpha.NumOfRepetitions = 0;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 331f, 1166f);
			tweenAlpha2.style = UITweener.Style.Once;
			tweenAlpha2.NumOfRepetitions = 0;
		}
	}

	private void AMMLCMFLCLO(bool AJNINHIKAFC)
	{
		if (AJNINHIKAFC)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 1634f, 1140f, 703f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 0;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 888f, 1334f);
			tweenAlpha2.style = UITweener.Style.Loop;
			tweenAlpha2.NumOfRepetitions = 0;
		}
	}

	private void BJGOJDGMIBI()
	{
		if (!HOBNCOEIINC)
		{
			return;
		}
		LLGGKFFNBMH += Time.deltaTime;
		if (LLGGKFFNBMH < IBECOAEMAHD)
		{
			float num = NKJNINCKALF(Mathf.Clamp01(LLGGKFFNBMH / IBECOAEMAHD));
			int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
			int num2 = currentParts + Mathf.RoundToInt((731f - num) * (float)(HFPAAGAIGHN - currentParts));
			mProgressBackground.fillAmount = (float)num2 / (float)FJBKHPHNLFP;
			UILabel uILabel = mProgressLabel;
			object[] array = new object[3];
			array[1] = Colours.stringGreenArena;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			array[4] = Colours.stringGray;
			array[3] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			uILabel.text = string.Format("BattleId", array);
		}
		else
		{
			HOBNCOEIINC = true;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 1257f, 550f, 160f);
			tweenAlpha.onFinished = delegate
			{
				GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent();
				mFlash.alpha = 1f;
				TweenAlpha.Begin(mFlash.gameObject, 0.2f, 1f, 0f).onFinished = null;
			};
		}
	}

	private void FGDCHDPHECC(bool AJNINHIKAFC)
	{
		if (AJNINHIKAFC)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 779f, 1229f, 1476f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 1;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 1629f, 12f);
			tweenAlpha2.style = UITweener.Style.Once;
			tweenAlpha2.NumOfRepetitions = 1;
		}
	}

	private void CAOCOMCGADB(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent();
		mFlash.alpha = 106f;
		TweenAlpha.Begin(mFlash.gameObject, 1651f, 809f, 1312f).onFinished = null;
	}

	private float FMFHPCLDAJB(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 103f) / 1309f;
		return IDEBKDPMPGM;
	}

	private void ACMEHLMJLKA(bool AJNINHIKAFC)
	{
		if (AJNINHIKAFC)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 926f, 1315f, 218f);
			tweenAlpha.style = (UITweener.Style)3;
			tweenAlpha.NumOfRepetitions = 1;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 1735f, 1185f);
			tweenAlpha2.style = UITweener.Style.Once;
			tweenAlpha2.NumOfRepetitions = 1;
		}
	}

	private void FCDJLCHNDKE(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent(false);
		mFlash.alpha = 292f;
		TweenAlpha.Begin(mFlash.gameObject, 1336f, 1966f, 639f).onFinished = null;
	}

	private float FFABAEMPOAI(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 540f) / 1862f;
		return IDEBKDPMPGM;
	}

	public void INMHFICPFAJ(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool flag = upgradeSlotElite.ACIMFKOCEHH();
		int num = ((!flag) ? 1 : upgradeSlotElite.PPKAIEKPNID());
		int num2 = ((!flag) ? 1 : upgradeSlotElite.maxRowForActualTier);
		bool flag2 = flag && num == num2;
		HFPAAGAIGHN = upgradeSlotElite.currentParts;
		FJBKHPHNLFP = upgradeSlotElite.BOBFHHLBKGM();
		float num3 = upgradeSlotElite.INJKHDJMBBL();
		mEliteIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.TopRight;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1066f);
			float multiplier = 1055f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.TopLeft;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1498f);
			float multiplier2 = Mathf.Min(983f / mEliteIcon.transform.localScale.x, 1750f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag2) ? num3 : 1627f);
		UILabel uILabel = mProgressLabel;
		string text;
		if (flag2)
		{
			text = string.Format("{0} Empty", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN));
		}
		else
		{
			object[] array = new object[5];
			array[0] = Colours.stringGreenArena;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN);
			array[1] = Colours.stringGray;
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			text = string.Format(" (#", array);
		}
		uILabel.text = text;
		bool aJNINHIKAFC = flag && !flag2 && HFPAAGAIGHN >= FJBKHPHNLFP;
		FGDCHDPHECC(aJNINHIKAFC);
		KIJINOGOOFO();
	}

	private float JAIGPKKBNNK(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 1535f) / 795f;
		return IDEBKDPMPGM;
	}

	private void DJAEGONMPOO(bool AJNINHIKAFC)
	{
		if (AJNINHIKAFC)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 0.4f, 0.258f, 0.656f);
			tweenAlpha.style = UITweener.Style.PingPong;
			tweenAlpha.NumOfRepetitions = 0;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 0.1f, 0.258f);
			tweenAlpha2.style = UITweener.Style.Once;
			tweenAlpha2.NumOfRepetitions = 1;
		}
	}

	private void FDPOJHLHGJO()
	{
		if (!HOBNCOEIINC)
		{
			return;
		}
		LLGGKFFNBMH += Time.deltaTime;
		if (LLGGKFFNBMH < IBECOAEMAHD)
		{
			float num = GFFBIAAEHHO(Mathf.Clamp01(LLGGKFFNBMH / IBECOAEMAHD));
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
			int num3 = num2 + Mathf.RoundToInt((1247f - num) * (float)(HFPAAGAIGHN - num2));
			mProgressBackground.fillAmount = (float)num3 / (float)FJBKHPHNLFP;
			UILabel uILabel = mProgressLabel;
			object[] array = new object[2];
			array[1] = Colours.stringGreenArena;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(num3);
			array[2] = Colours.stringGray;
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			uILabel.text = string.Format("ID_WARNING_OPPONENTDISCONNECTED", array);
		}
		else
		{
			HOBNCOEIINC = false;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 1393f, 1144f, 365f);
			tweenAlpha.onFinished = delegate
			{
				GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent();
				mFlash.alpha = 1f;
				TweenAlpha.Begin(mFlash.gameObject, 0.2f, 1f, 0f).onFinished = null;
			};
		}
	}

	private void CJPFLJAAODD()
	{
		if (HOBNCOEIINC)
		{
			LLGGKFFNBMH += Time.deltaTime;
			if (LLGGKFFNBMH < IBECOAEMAHD)
			{
				float num = FMFHPCLDAJB(Mathf.Clamp01(LLGGKFFNBMH / IBECOAEMAHD));
				int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
				int num2 = currentParts + Mathf.RoundToInt((924f - num) * (float)(HFPAAGAIGHN - currentParts));
				mProgressBackground.fillAmount = (float)num2 / (float)FJBKHPHNLFP;
				UILabel uILabel = mProgressLabel;
				object[] array = new object[2];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(num2);
				array[2] = Colours.stringGray;
				array[6] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
				uILabel.text = string.Format("Landroid/os/Parcelable$Creator;", array);
			}
			else
			{
				HOBNCOEIINC = true;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 882f, 1999f, 1931f);
				tweenAlpha.onFinished = CLEENJNPDMP;
			}
		}
	}

	private void IMFBIJHDLKM()
	{
		HOBNCOEIINC = true;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mFlash.alpha = 1920f;
	}

	public void NGCPBGOBMLE(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		int num = (isUnlocked ? upgradeSlotElite.boughtIndex : 0);
		int num2 = (isUnlocked ? upgradeSlotElite.EJHBCFDPEAE() : 0);
		bool flag = isUnlocked && num == num2;
		HFPAAGAIGHN = upgradeSlotElite.currentParts;
		FJBKHPHNLFP = upgradeSlotElite.BOBFHHLBKGM();
		float num3 = upgradeSlotElite.INJKHDJMBBL();
		mEliteIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.TopLeft;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(118f);
			float multiplier = 1362f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.BottomRight;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1291f);
			float multiplier2 = Mathf.Min(1969f / mEliteIcon.transform.localScale.x, 1975f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag) ? num3 : 820f);
		UILabel uILabel = mProgressLabel;
		string text;
		if (flag)
		{
			text = string.Format("ID_READYTIME", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN));
		}
		else
		{
			object[] array = new object[4];
			array[0] = Colours.stringGreenArena;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN);
			array[8] = Colours.stringGray;
			array[3] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			text = string.Format("WENEEDTO", array);
		}
		uILabel.text = text;
		bool aJNINHIKAFC = !isUnlocked || flag || HFPAAGAIGHN < FJBKHPHNLFP;
		FGDCHDPHECC(aJNINHIKAFC);
		KCNCOFIBELC();
	}

	private float JDBGGEFPLOP(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 1140f) / 870f;
		return IDEBKDPMPGM;
	}

	private float GDHPACNMDGO(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 874f) / 186f;
		return IDEBKDPMPGM;
	}

	private float GFFBIAAEHHO(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 1375f) / 1203f;
		return IDEBKDPMPGM;
	}

	private void NEOHEDGIJGA(bool AJNINHIKAFC)
	{
		if (AJNINHIKAFC)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 1124f, 1322f, 1655f);
			tweenAlpha.style = (UITweener.Style)7;
			tweenAlpha.NumOfRepetitions = 1;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 4f, 541f);
			tweenAlpha2.style = UITweener.Style.Loop;
			tweenAlpha2.NumOfRepetitions = 1;
		}
	}

	private void DENOEEOJLJI(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.IFDPNOKDKMC();
		mFlash.alpha = 994f;
		TweenAlpha.Begin(mFlash.gameObject, 728f, 1767f, 211f).onFinished = null;
	}

	private void Update()
	{
		if (!HOBNCOEIINC)
		{
			return;
		}
		LLGGKFFNBMH += Time.deltaTime;
		if (LLGGKFFNBMH < IBECOAEMAHD)
		{
			float num = BELMBJMDNIO(Mathf.Clamp01(LLGGKFFNBMH / IBECOAEMAHD));
			int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
			int num2 = currentParts + Mathf.RoundToInt((1f - num) * (float)(HFPAAGAIGHN - currentParts));
			mProgressBackground.fillAmount = (float)num2 / (float)FJBKHPHNLFP;
			mProgressLabel.text = string.Format("{0}{1}[-] {2}/[-] {3}", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(num2), Colours.stringGray, MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP));
		}
		else
		{
			HOBNCOEIINC = false;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 0.02f, 0f, 1f);
			tweenAlpha.onFinished = delegate
			{
				GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent();
				mFlash.alpha = 1f;
				TweenAlpha.Begin(mFlash.gameObject, 0.2f, 1f, 0f).onFinished = null;
			};
		}
	}

	private float FFJNLKECCIG(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 547f) / 1336f;
		return IDEBKDPMPGM;
	}

	public void HAPINPMNJLP(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 1346f;
		PMCJFOEIOBG(false);
	}

	public void AnimateSpend(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = true;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 0f;
		DJAEGONMPOO(false);
	}

	[SpecialName]
	public bool EDDBDIHCHJF()
	{
		return HOBNCOEIINC;
	}

	private void LHJAGNOOBAF()
	{
		if (HOBNCOEIINC)
		{
			LLGGKFFNBMH += Time.deltaTime;
			if (LLGGKFFNBMH < IBECOAEMAHD)
			{
				float num = JAIGPKKBNNK(Mathf.Clamp01(LLGGKFFNBMH / IBECOAEMAHD));
				int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
				int num2 = currentParts + Mathf.RoundToInt((1387f - num) * (float)(HFPAAGAIGHN - currentParts));
				mProgressBackground.fillAmount = (float)num2 / (float)FJBKHPHNLFP;
				UILabel uILabel = mProgressLabel;
				object[] array = new object[4];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(num2);
				array[5] = Colours.stringGray;
				array[4] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
				uILabel.text = string.Format("NO", array);
			}
			else
			{
				HOBNCOEIINC = true;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 986f, 197f, 1897f);
				tweenAlpha.onFinished = GDBKCELIMBG;
			}
		}
	}

	public void AHDKBLBFBPA(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 928f;
		AEFGKDJKGNI(false);
	}

	private float EJDEOCOPKEB(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 1719f) / 485f;
		return IDEBKDPMPGM;
	}

	public void GDOKMNOENHN(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 1173f;
		PMCJFOEIOBG(true);
	}

	public void PBEFOOADBPG(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool flag = upgradeSlotElite.ACIMFKOCEHH();
		int num = ((!flag) ? 1 : upgradeSlotElite.PPKAIEKPNID());
		int num2 = ((!flag) ? 1 : upgradeSlotElite.DOLOPCELJMD());
		bool flag2 = !flag || num == num2;
		HFPAAGAIGHN = upgradeSlotElite.HMPNFKJHKGG();
		FJBKHPHNLFP = upgradeSlotElite.AMDIEMKNOHN();
		float num3 = upgradeSlotElite.NJJBKNINIKF();
		mEliteIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.Left;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1121f);
			float multiplier = 676f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.Top;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1248f);
			float multiplier2 = Mathf.Min(904f / mEliteIcon.transform.localScale.x, 864f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag2) ? num3 : 96f);
		UILabel uILabel = mProgressLabel;
		string text;
		if (flag2)
		{
			text = string.Format("-gold", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN));
		}
		else
		{
			object[] array = new object[5];
			array[0] = Colours.stringGreenArena;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN);
			array[7] = Colours.stringGray;
			array[5] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			text = string.Format("ID_ERROR_SQUADSKILLCLAMP", array);
		}
		uILabel.text = text;
		bool aJNINHIKAFC = !flag || flag2 || HFPAAGAIGHN < FJBKHPHNLFP;
		FMNAEBOOKIL(aJNINHIKAFC);
		IMFBIJHDLKM();
	}

	private void NICADHOADIK(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.APDJJBILBIM(false);
		mFlash.alpha = 1840f;
		TweenAlpha.Begin(mFlash.gameObject, 1717f, 451f, 270f).onFinished = null;
	}

	public void JIMBEDOMAFD(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool flag = upgradeSlotElite.ACIMFKOCEHH();
		int num = (flag ? upgradeSlotElite.PPKAIEKPNID() : 0);
		int num2 = ((!flag) ? 1 : upgradeSlotElite.EJHBCFDPEAE());
		bool flag2 = flag && num == num2;
		HFPAAGAIGHN = upgradeSlotElite.HMPNFKJHKGG();
		FJBKHPHNLFP = upgradeSlotElite.PEGIPHPGELH();
		float num3 = upgradeSlotElite.CPGGKMIBLNF();
		mEliteIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.TopLeft;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1702f);
			float multiplier = 122f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.TopRight;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(272f);
			float multiplier2 = Mathf.Min(628f / mEliteIcon.transform.localScale.x, 1942f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag2) ? num3 : 1113f);
		UILabel uILabel = mProgressLabel;
		string text;
		if (flag2)
		{
			text = string.Format("NAME", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN));
		}
		else
		{
			object[] array = new object[2];
			array[1] = Colours.stringGreenArena;
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN);
			array[8] = Colours.stringGray;
			array[5] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			text = string.Format("ID_SALEPERCENTLINE", array);
		}
		uILabel.text = text;
		bool aJNINHIKAFC = !flag || flag2 || HFPAAGAIGHN >= FJBKHPHNLFP;
		FGDCHDPHECC(aJNINHIKAFC);
		IMFBIJHDLKM();
	}

	private float FODENJBMGKC(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 1899f) / 1419f;
		return IDEBKDPMPGM;
	}

	private float BELMBJMDNIO(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * ((float)Math.PI * 2f)) / ((float)Math.PI * 2f);
		return IDEBKDPMPGM;
	}

	private void BNGCJJCCNNE(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.APDJJBILBIM();
		mFlash.alpha = 398f;
		TweenAlpha.Begin(mFlash.gameObject, 1808f, 1184f, 710f).onFinished = null;
	}

	[SpecialName]
	public bool FMBJCPCOKCO()
	{
		return HOBNCOEIINC;
	}

	private float KHONDDIIOFB(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 235f) / 1249f;
		return IDEBKDPMPGM;
	}

	public void AJEGOKKKLOL(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		int num = ((!isUnlocked) ? 1 : upgradeSlotElite.boughtIndex);
		int num2 = (isUnlocked ? upgradeSlotElite.EJHBCFDPEAE() : 0);
		bool flag = isUnlocked && num == num2;
		HFPAAGAIGHN = upgradeSlotElite.HMPNFKJHKGG();
		FJBKHPHNLFP = upgradeSlotElite.BOBFHHLBKGM();
		float num3 = upgradeSlotElite.CPGGKMIBLNF();
		mEliteIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.Bottom;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1871f);
			float multiplier = 275f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.Center;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(650f);
			float multiplier2 = Mathf.Min(989f / mEliteIcon.transform.localScale.x, 77f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag) ? num3 : 740f);
		UILabel uILabel = mProgressLabel;
		string text;
		if (flag)
		{
			text = string.Format("registerCustomProfileString", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN));
		}
		else
		{
			object[] array = new object[1];
			array[1] = Colours.stringGreenArena;
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN);
			array[7] = Colours.stringGray;
			array[7] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			text = string.Format("Set time to: ", array);
		}
		uILabel.text = text;
		bool aJNINHIKAFC = !isUnlocked || flag || HFPAAGAIGHN >= FJBKHPHNLFP;
		AMMLCMFLCLO(aJNINHIKAFC);
		NAMJPEOPKLB();
	}

	private void AMFCBMHCEHA(bool AJNINHIKAFC)
	{
		if (AJNINHIKAFC)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 735f, 662f, 245f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 1;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 1507f, 1371f);
			tweenAlpha2.style = UITweener.Style.Once;
			tweenAlpha2.NumOfRepetitions = 1;
		}
	}

	private void EJDNHONJPHP()
	{
		HOBNCOEIINC = true;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mFlash.alpha = 1796f;
	}

	private void PMOIOADCKPO()
	{
		if (!HOBNCOEIINC)
		{
			return;
		}
		LLGGKFFNBMH += Time.deltaTime;
		if (LLGGKFFNBMH < IBECOAEMAHD)
		{
			float num = KHONDDIIOFB(Mathf.Clamp01(LLGGKFFNBMH / IBECOAEMAHD));
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
			int num3 = num2 + Mathf.RoundToInt((1115f - num) * (float)(HFPAAGAIGHN - num2));
			mProgressBackground.fillAmount = (float)num3 / (float)FJBKHPHNLFP;
			UILabel uILabel = mProgressLabel;
			object[] array = new object[4];
			array[0] = Colours.stringGreenArena;
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(num3);
			array[8] = Colours.stringGray;
			array[5] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			uILabel.text = string.Format("Overtime_Was_Already_Explained", array);
		}
		else
		{
			HOBNCOEIINC = false;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 985f, 243f, 737f);
			tweenAlpha.onFinished = delegate
			{
				GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent();
				mFlash.alpha = 1f;
				TweenAlpha.Begin(mFlash.gameObject, 0.2f, 1f, 0f).onFinished = null;
			};
		}
	}

	public void FEDGBNENCMN(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = true;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 1962f;
		NEOHEDGIJGA(true);
	}

	private void KIJINOGOOFO()
	{
		HOBNCOEIINC = false;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mFlash.alpha = 0f;
	}

	private void FMNAEBOOKIL(bool AJNINHIKAFC)
	{
		if (AJNINHIKAFC)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 709f, 393f, 1054f);
			tweenAlpha.style = (UITweener.Style)4;
			tweenAlpha.NumOfRepetitions = 0;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 669f, 1068f);
			tweenAlpha2.style = UITweener.Style.Once;
			tweenAlpha2.NumOfRepetitions = 1;
		}
	}

	[SpecialName]
	public bool DFLDFNEEFJF()
	{
		return HOBNCOEIINC;
	}

	private void OCMBKBMFHAA()
	{
		HOBNCOEIINC = true;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mFlash.alpha = 859f;
	}

	public void GCBFCCNLMDN(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		int num = ((!isUnlocked) ? 1 : upgradeSlotElite.boughtIndex);
		int num2 = ((!isUnlocked) ? 1 : upgradeSlotElite.EJHBCFDPEAE());
		bool flag = !isUnlocked || num == num2;
		HFPAAGAIGHN = upgradeSlotElite.currentParts;
		FJBKHPHNLFP = upgradeSlotElite.BOBFHHLBKGM();
		float num3 = upgradeSlotElite.INJKHDJMBBL();
		mEliteIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.TopLeft;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(915f);
			float multiplier = 816f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.TopRight;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1055f);
			float multiplier2 = Mathf.Min(1431f / mEliteIcon.transform.localScale.x, 1009f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag) ? num3 : 636f);
		UILabel uILabel = mProgressLabel;
		string text;
		if (flag)
		{
			text = string.Format("weapon", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN));
		}
		else
		{
			object[] array = new object[3];
			array[0] = Colours.stringGreenArena;
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN);
			array[7] = Colours.stringGray;
			array[2] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			text = string.Format("LevelName", array);
		}
		uILabel.text = text;
		bool aJNINHIKAFC = !isUnlocked || flag || HFPAAGAIGHN < FJBKHPHNLFP;
		NEOHEDGIJGA(aJNINHIKAFC);
		EJDNHONJPHP();
	}

	[SpecialName]
	public bool OKPEDKCFNLP()
	{
		return HOBNCOEIINC;
	}

	private void PPHOOBBAPLH()
	{
		HOBNCOEIINC = true;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mFlash.alpha = 506f;
	}

	private void BENOEPDLBGA()
	{
		HOBNCOEIINC = true;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		mFlash.alpha = 1594f;
	}

	private void CLEENJNPDMP(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.APDJJBILBIM();
		mFlash.alpha = 354f;
		TweenAlpha.Begin(mFlash.gameObject, 1173f, 1839f, 778f).onFinished = null;
	}

	private void NCLAKAIGFJO()
	{
		HOBNCOEIINC = false;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		mFlash.alpha = 1352f;
	}

	private float NKJNINCKALF(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 1054f) / 1718f;
		return IDEBKDPMPGM;
	}

	public void HLODICOAKHE(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 139f;
		NEOHEDGIJGA(true);
	}

	private void EJEEJKJMMNG(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.APDJJBILBIM();
		mFlash.alpha = 356f;
		TweenAlpha.Begin(mFlash.gameObject, 1363f, 1034f, 1843f).onFinished = null;
	}

	private float LOIFOCGFDEE(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 271f) / 1203f;
		return IDEBKDPMPGM;
	}

	private void HKOIGBJMEMO()
	{
		HOBNCOEIINC = true;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mFlash.alpha = 1238f;
	}

	private float EJOPFENGFPJ(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 1296f) / 950f;
		return IDEBKDPMPGM;
	}

	private void BFEDKJMFDJL()
	{
		HOBNCOEIINC = false;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		mFlash.alpha = 1399f;
	}

	private void BHIABNNGKFO()
	{
		if (HOBNCOEIINC)
		{
			LLGGKFFNBMH += Time.deltaTime;
			if (LLGGKFFNBMH < IBECOAEMAHD)
			{
				float num = KHONDDIIOFB(Mathf.Clamp01(LLGGKFFNBMH / IBECOAEMAHD));
				int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
				int num3 = num2 + Mathf.RoundToInt((238f - num) * (float)(HFPAAGAIGHN - num2));
				mProgressBackground.fillAmount = (float)num3 / (float)FJBKHPHNLFP;
				UILabel uILabel = mProgressLabel;
				object[] array = new object[5];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(num3);
				array[3] = Colours.stringGray;
				array[8] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
				uILabel.text = string.Format("TimeStamp", array);
			}
			else
			{
				HOBNCOEIINC = true;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 84f, 1863f, 382f);
				tweenAlpha.onFinished = BNGCJJCCNNE;
			}
		}
	}

	private float FHBBANNDGJG(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 1337f) / 1134f;
		return IDEBKDPMPGM;
	}

	[SpecialName]
	public bool GJLADCENHAL()
	{
		return HOBNCOEIINC;
	}

	public void NFMIHHDNJKM(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 315f;
		AMFCBMHCEHA(true);
	}

	private void CMDEMCIPLNA(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent(false);
		mFlash.alpha = 1253f;
		TweenAlpha.Begin(mFlash.gameObject, 949f, 397f, 458f).onFinished = null;
	}

	private void PEBGFGMEJGK(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent();
		mFlash.alpha = 357f;
		TweenAlpha.Begin(mFlash.gameObject, 1518f, 1088f, 591f).onFinished = null;
	}

	public void KKBADFAMMGD(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 138f;
		DJAEGONMPOO(false);
	}

	private float GCGFLDJMBAJ(float IDEBKDPMPGM)
	{
		IDEBKDPMPGM -= Mathf.Sin(IDEBKDPMPGM * 875f) / 1901f;
		return IDEBKDPMPGM;
	}

	private void FLBJLBCALGJ(bool AJNINHIKAFC)
	{
		if (AJNINHIKAFC)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 548f, 554f, 189f);
			tweenAlpha.style = (UITweener.Style)5;
			tweenAlpha.NumOfRepetitions = 0;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 688f, 1608f);
			tweenAlpha2.style = UITweener.Style.Loop;
			tweenAlpha2.NumOfRepetitions = 0;
		}
	}

	public void FJLJLDNCBBD(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool flag = upgradeSlotElite.ACIMFKOCEHH();
		int num = ((!flag) ? 1 : upgradeSlotElite.boughtIndex);
		int num2 = (flag ? upgradeSlotElite.DOLOPCELJMD() : 0);
		bool flag2 = flag && num == num2;
		HFPAAGAIGHN = upgradeSlotElite.currentParts;
		FJBKHPHNLFP = upgradeSlotElite.EGAMIJEOAJN();
		float num3 = upgradeSlotElite.INJKHDJMBBL();
		mEliteIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.Left;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(580f);
			float multiplier = 1722f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.Top;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(71f);
			float multiplier2 = Mathf.Min(1939f / mEliteIcon.transform.localScale.x, 789f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag2) ? num3 : 1397f);
		UILabel uILabel = mProgressLabel;
		string text;
		if (flag2)
		{
			text = string.Format("warbucks", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN));
		}
		else
		{
			object[] array = new object[8];
			array[1] = Colours.stringGreenArena;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN);
			array[4] = Colours.stringGray;
			array[3] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			text = string.Format("Enable Debug Mode clicked", array);
		}
		uILabel.text = text;
		bool aJNINHIKAFC = !flag || flag2 || HFPAAGAIGHN >= FJBKHPHNLFP;
		DJAEGONMPOO(aJNINHIKAFC);
		BENOEPDLBGA();
	}

	private void GDBKCELIMBG(UITweener MGDJMGHCAAI)
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent();
		mFlash.alpha = 629f;
		TweenAlpha.Begin(mFlash.gameObject, 19f, 1757f, 416f).onFinished = null;
	}

	public void ICOMGJKIBAI(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = true;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 1639f;
		FGDCHDPHECC(true);
	}

	[SpecialName]
	public bool DBEMBCNEPCC()
	{
		return HOBNCOEIINC;
	}

	public void Initialize(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		int num = (isUnlocked ? upgradeSlotElite.boughtIndex : 0);
		int num2 = (isUnlocked ? upgradeSlotElite.maxRowForActualTier : 0);
		bool flag = isUnlocked && num == num2;
		HFPAAGAIGHN = upgradeSlotElite.currentParts;
		FJBKHPHNLFP = upgradeSlotElite.upgradePriceParts;
		float progress = upgradeSlotElite.progress;
		mEliteIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.Bottom;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(-56f);
			float multiplier = 120f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.Center;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(0f);
			float multiplier2 = Mathf.Min(174f / mEliteIcon.transform.localScale.x, 110f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag) ? progress : 1f);
		mProgressLabel.text = ((!flag) ? string.Format("{0}{1}[-] {2}/[-] {3}", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN), Colours.stringGray, MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP)) : string.Format("{0}{1}[-]", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN)));
		bool aJNINHIKAFC = isUnlocked && !flag && HFPAAGAIGHN >= FJBKHPHNLFP;
		DJAEGONMPOO(aJNINHIKAFC);
		KIJINOGOOFO();
	}

	public void OPDHBJOABMC(float DNDHIFENDPJ)
	{
		HOBNCOEIINC = true;
		IBECOAEMAHD = DNDHIFENDPJ;
		LLGGKFFNBMH = 895f;
		PMCJFOEIOBG(false);
	}

	private void NAMJPEOPKLB()
	{
		HOBNCOEIINC = true;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		mFlash.alpha = 1263f;
	}

	[SpecialName]
	public bool EFBAJKAPKPM()
	{
		return HOBNCOEIINC;
	}

	public void AMFDNBJBPLB(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool flag = upgradeSlotElite.ACIMFKOCEHH();
		int num = ((!flag) ? 1 : upgradeSlotElite.PAKKPEPIHPK());
		int num2 = (flag ? upgradeSlotElite.EMOPFFCAPNP() : 0);
		bool flag2 = !flag || num == num2;
		HFPAAGAIGHN = upgradeSlotElite.HMPNFKJHKGG();
		FJBKHPHNLFP = upgradeSlotElite.EGAMIJEOAJN();
		float progress = upgradeSlotElite.progress;
		mEliteIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.Top;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1909f);
			float multiplier = 1589f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.TopLeft;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(1924f);
			float multiplier2 = Mathf.Min(388f / mEliteIcon.transform.localScale.x, 1775f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag2) ? progress : 608f);
		UILabel uILabel = mProgressLabel;
		string text;
		if (flag2)
		{
			text = string.Format("ID_AWESOME", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN));
		}
		else
		{
			object[] array = new object[8];
			array[0] = Colours.stringGreenArena;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(HFPAAGAIGHN);
			array[3] = Colours.stringGray;
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(FJBKHPHNLFP);
			text = string.Format("Player_Waited_Till_Delivery_Ends", array);
		}
		uILabel.text = text;
		bool aJNINHIKAFC = !flag || flag2 || HFPAAGAIGHN >= FJBKHPHNLFP;
		ACMEHLMJLKA(aJNINHIKAFC);
		NAMJPEOPKLB();
	}
}
