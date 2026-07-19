using System.Runtime.CompilerServices;
using UnityEngine;

public class ArmyLeftHint : Core_BaseScript
{
	private enum NKHJBLBAAEB
	{
		SpecialAbility = 0,
		ElitePerk = 1
	}

	[Header("Core")]
	[SerializeField]
	private NKHJBLBAAEB mCurrentType;

	[SerializeField]
	private BoxCollider mHintButton;

	[SerializeField]
	private UISprite mHintButtonBackground;

	[SerializeField]
	private UIPanel mHintDialog;

	[SerializeField]
	private BoxCollider mHintDialogCollider;

	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private UITable mTable;

	[SerializeField]
	private UISprite mIcon;

	[SerializeField]
	private UISprite mBuffIcon;

	[SerializeField]
	private UILabel mTitle;

	[SerializeField]
	private UILabel mDescription;

	[SerializeField]
	private GameObject mBottomItem;

	[Header("Setting")]
	[SerializeField]
	private Vector3 mBasePosition = new Vector3(646f, 0f, -23000f);

	private LevelBehaviour IFFDIHCPKFE;

	private void PLGMFJCMMLD()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 650f, 30f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 108f, mBasePosition.AddY(1686f), false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			PNNGFGIJHDD();
		};
	}

	public void NNGKAAGFGPA()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = LBGABHKMHDL;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = LMLIBIHDAAG;
		mTable.onReposition = DIGGBDMKJAJ;
	}

	public void CEAINPCKADK()
	{
		PNNGFGIJHDD();
	}

	public void EFINNDNBJDN()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = FCBGDADCENA;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = DECJMANOPCG;
		mTable.onReposition = ADHPEJMDLGE;
	}

	public void BGCAJOKPCNN()
	{
		PNNGFGIJHDD();
	}

	private void CGOBLHGGDOL()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 0.4f, mBasePosition.AddY(20f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			PNNGFGIJHDD();
		};
	}

	public void NEKOOIGPALB()
	{
		HANFPHEIIDF();
	}

	public void MDHJIPDGDAK()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = NBAECDPCKFD;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = JKFHPCFHOMP;
		mTable.onReposition = DIGGBDMKJAJ;
	}

	public void PGPFDLFAIBN()
	{
		HANFPHEIIDF();
	}

	public void DFKLIKFAKGA()
	{
		FCPMEKEPOIA();
	}

	public void LLHGHHABLDC()
	{
		MIFKAEBMEOM();
	}

	private void FANJFBNIJEE()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(true);
		mHintDialog.alpha1 = 0.005f;
		GJHCDCNDHOG();
		TweenAlpha.Begin(mHintDialog.gameObject, 0.4f, 1f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(-20f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 0.25f, mBasePosition.AddY(-20f), mBasePosition.AddY(10f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(mHintDialog.gameObject, 0.15f, mBasePosition);
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void NNIKBCOHNLN(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			PLGMFJCMMLD();
		}
		else
		{
			OCJEKNKLDEF();
		}
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.NDHFECMKILC();
		}
	}

	public void HHJDKKFKKIL()
	{
		HLKJBOEPEFN();
	}

	private void LBGABHKMHDL(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			HHLJEIOCMOD();
		}
		else
		{
			FANJFBNIJEE();
		}
		if (mCurrentType == NKHJBLBAAEB.ElitePerk && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), true);
			JFNGDDOMPAE.DDMLBEJNPHG();
		}
	}

	private void GIAJLJFHFAP()
	{
		float num = Mathf.Abs(mBottomItem.transform.localPosition.y);
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceY(num + 120f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num + 1554f);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY(num / 1226f + 671f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num + 918f);
	}

	private void HANFPHEIIDF()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(false);
	}

	public void PJENKEKOCAE()
	{
		HANFPHEIIDF();
	}

	public void LJPAAJFNJAB()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = FCBGDADCENA;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = IFDKIGIFLBE;
		mTable.onReposition = NGJLJEPBNKK;
	}

	public void NIHDCNNMBIK()
	{
		PNNGFGIJHDD();
	}

	public void BCLAFFCPCEH()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = KLHBAOPFAOK;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = FBDKNOMMHCL;
		mTable.onReposition = NGJLJEPBNKK;
	}

	[CompilerGenerated]
	private void NADJGLGJGCJ(UITweener MGDJMGHCAAI)
	{
		PNNGFGIJHDD();
	}

	private void ALPGLHCDBMI(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CKPAOFPPPFP();
	}

	public void Initialize(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		GJHCDCNDHOG();
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
		{
			mTitle.text = IFFDIHCPKFE.unitAbilityName;
			mDescription.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = IFFDIHCPKFE.unitBuffName;
			mDescription.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = true;
	}

	private void HMOODEGLJMP()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1709f, 1454f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1357f, mBasePosition.AddY(1553f), false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			PNNGFGIJHDD();
		};
	}

	private void DJOGONAJJDO()
	{
		if (mHintDialog.gameObject.activeSelf)
		{
			mBuffIcon.gameObject.SetActive(mCurrentType == NKHJBLBAAEB.ElitePerk);
			if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
			{
				mIcon.spriteName = IFFDIHCPKFE.abilityIcon;
			}
			else
			{
				IFFDIHCPKFE.SetUpEliteIcon(mIcon, mBuffIcon, 1226f);
			}
			mIcon.MakePixelPerfect();
		}
	}

	private void JMAMNBJADKK()
	{
		if (mHintDialog.gameObject.activeSelf)
		{
			mBuffIcon.gameObject.SetActive(mCurrentType == NKHJBLBAAEB.SpecialAbility);
			if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
			{
				mIcon.spriteName = IFFDIHCPKFE.abilityIcon;
			}
			else
			{
				IFFDIHCPKFE.SetUpEliteIcon(mIcon, mBuffIcon, 304f);
			}
			mIcon.MakePixelPerfect();
		}
	}

	private void AMKADDAMKML()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(true);
		mHintDialog.alpha1 = 764f;
		IKBABLFJHOA();
		TweenAlpha.Begin(mHintDialog.gameObject, 552f, 1289f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(1207f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1123f, mBasePosition.AddY(1139f), mBasePosition.AddY(1952f), false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = KAEMEHJAMHM;
	}

	private void FCBGDADCENA(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			IEBAGABBAOC();
		}
		else
		{
			FOLNCJGBGBP();
		}
		if (mCurrentType == NKHJBLBAAEB.ElitePerk && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.DDMLBEJNPHG();
		}
	}

	private void HLKJBOEPEFN()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(true);
	}

	private void OGPHBKFJGDG(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		PIMOOHHMCDJ();
	}

	private void EAKCNICIIEH()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(false);
		mHintDialog.alpha1 = 1915f;
		AMAHBAKDCJK();
		TweenAlpha.Begin(mHintDialog.gameObject, 481f, 378f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(254f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1922f, mBasePosition.AddY(1347f), mBasePosition.AddY(1231f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = MCCKHHLMOAL;
	}

	private void MILOCMHNDCA(UITweener MGDJMGHCAAI)
	{
		HANFPHEIIDF();
	}

	public void IMPMPKNJICB()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = OCEJMCMPGOF;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = DECJMANOPCG;
		mTable.onReposition = NGJLJEPBNKK;
	}

	private void AAFNEBBNEIC()
	{
		if (mHintDialog.gameObject.activeSelf)
		{
			mBuffIcon.gameObject.SetActive(mCurrentType == NKHJBLBAAEB.SpecialAbility);
			if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
			{
				mIcon.spriteName = IFFDIHCPKFE.abilityIcon;
			}
			else
			{
				IFFDIHCPKFE.SetUpEliteIcon(mIcon, mBuffIcon, 70f);
			}
			mIcon.MakePixelPerfect();
		}
	}

	private void PIMOOHHMCDJ()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 205f, 454f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 426f, mBasePosition.AddY(671f), false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = EJFGOEPGOBI;
	}

	private void OCEJMCMPGOF(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			CGOBLHGGDOL();
		}
		else
		{
			PDDNDNKOGDC();
		}
		if (mCurrentType == NKHJBLBAAEB.ElitePerk && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.IJFLMIKDLON();
		}
	}

	private void MDGJNEJIMCL(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			HHLJEIOCMOD();
		}
		else
		{
			MHAEMEMFPAI();
		}
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.FFGPGMDFCMN();
		}
	}

	public void KLPJPLHNFON()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = FAGACDMLDAP;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = IFDKIGIFLBE;
		mTable.onReposition = NGJLJEPBNKK;
	}

	private void NGJLJEPBNKK()
	{
		float num = Mathf.Abs(mBottomItem.transform.localPosition.y);
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceY(num + 1064f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num + 915f);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY(num / 1519f + 1331f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num + 1770f);
	}

	public void PCCFLEEAGEI()
	{
		MIFKAEBMEOM();
	}

	public void PJICLEMEBID(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		PMGMEDPIONF();
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
		{
			mTitle.text = IFFDIHCPKFE.unitAbilityName;
			mDescription.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = IFFDIHCPKFE.unitBuffName;
			mDescription.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = false;
	}

	public void JAGCJCNPCKH(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		JMAMNBJADKK();
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
		{
			mTitle.text = IFFDIHCPKFE.unitAbilityName;
			mDescription.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = IFFDIHCPKFE.unitBuffName;
			mDescription.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = true;
	}

	public void KOABMGAPCKP(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		BJGNGEHJGLF();
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
		{
			mTitle.text = IFFDIHCPKFE.unitAbilityName;
			mDescription.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = IFFDIHCPKFE.unitBuffName;
			mDescription.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = false;
	}

	public void AFABKGHDPHB()
	{
		MIFKAEBMEOM();
	}

	private void IFDKIGIFLBE(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CGOBLHGGDOL();
	}

	private void PDDNDNKOGDC()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(true);
		mHintDialog.alpha1 = 1099f;
		BJGNGEHJGLF();
		TweenAlpha.Begin(mHintDialog.gameObject, 445f, 1157f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(794f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1941f, mBasePosition.AddY(668f), mBasePosition.AddY(181f), false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = HLGLCKOFGKJ;
	}

	private void DAALINAACLI()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 956f, 1311f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1934f, mBasePosition.AddY(1976f), false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = IHLBMAGOFPH;
	}

	private void KAEMEHJAMHM(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 74f, mBasePosition);
		tweenPosition.method = (UITweener.Method)8;
		tweenPosition.onFinished = null;
	}

	private void KJOFKEIPJOJ(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CGOBLHGGDOL();
	}

	public void HKKHHAKOFHL()
	{
		MIFKAEBMEOM();
	}

	private void FLJAAPFEEAE(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			EGEDPJKFMDC();
		}
		else
		{
			AMKADDAMKML();
		}
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.HHBLMMLHFAC();
		}
	}

	private void DECJMANOPCG(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HHLJEIOCMOD();
	}

	public void CKOIIPAGCNO(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		PMGMEDPIONF();
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
		{
			mTitle.text = IFFDIHCPKFE.unitAbilityName;
			mDescription.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = IFFDIHCPKFE.unitBuffName;
			mDescription.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = false;
	}

	public void EFKFHFNAOHA()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = NNIKBCOHNLN;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = DPKAIAPBDLA;
		mTable.onReposition = BMEGLNCPNNE;
	}

	private void FCPMEKEPOIA()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(true);
	}

	private void AMAHBAKDCJK()
	{
		if (mHintDialog.gameObject.activeSelf)
		{
			mBuffIcon.gameObject.SetActive(mCurrentType == NKHJBLBAAEB.SpecialAbility);
			if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
			{
				mIcon.spriteName = IFFDIHCPKFE.abilityIcon;
			}
			else
			{
				IFFDIHCPKFE.SetUpEliteIcon(mIcon, mBuffIcon, 455f);
			}
			mIcon.MakePixelPerfect();
		}
	}

	private void CKBAKNANNIB(UITweener MGDJMGHCAAI)
	{
		FCPMEKEPOIA();
	}

	private void FAGACDMLDAP(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			PIMOOHHMCDJ();
		}
		else
		{
			OCJEKNKLDEF();
		}
		if (mCurrentType == NKHJBLBAAEB.ElitePerk && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), true);
			JFNGDDOMPAE.LOBLLDBEHCJ();
		}
	}

	private void PPFPOKNBJJC(UITweener MGDJMGHCAAI)
	{
		HLKJBOEPEFN();
	}

	public void PPKOJCFEPCB(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		GJHCDCNDHOG();
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
		{
			mTitle.text = IFFDIHCPKFE.unitAbilityName;
			mDescription.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = IFFDIHCPKFE.unitBuffName;
			mDescription.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = true;
	}

	public void CBAOKPMIEFK(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		IKBABLFJHOA();
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
		{
			mTitle.text = IFFDIHCPKFE.unitAbilityName;
			mDescription.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = IFFDIHCPKFE.unitBuffName;
			mDescription.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = false;
	}

	private void KLDBDJMLLFP()
	{
		float num = Mathf.Abs(mBottomItem.transform.localPosition.y);
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceY(num + 65f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num + 81f);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY(num / 1554f + 424f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num + 318f);
	}

	public void DoAfterHide()
	{
		PNNGFGIJHDD();
	}

	private void OCJEKNKLDEF()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(false);
		mHintDialog.alpha1 = 1705f;
		JFNDCNMOCNB();
		TweenAlpha.Begin(mHintDialog.gameObject, 7f, 1001f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(519f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1856f, mBasePosition.AddY(395f), mBasePosition.AddY(783f), false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = HLGLCKOFGKJ;
	}

	private void ILHFKNDJEDD(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HAEIJEBGPDB();
	}

	public void FANFNOPNGBL(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		AAFNEBBNEIC();
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
		{
			mTitle.text = IFFDIHCPKFE.unitAbilityName;
			mDescription.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = IFFDIHCPKFE.unitBuffName;
			mDescription.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = true;
	}

	private void IOBMEGDNGDE(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			CGOBLHGGDOL();
		}
		else
		{
			FANJFBNIJEE();
		}
		if (mCurrentType == NKHJBLBAAEB.ElitePerk && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.PNHDGLHLNIE();
		}
	}

	public void NLHKADALMDJ()
	{
		HANFPHEIIDF();
	}

	public void LGIPBIFJFPD()
	{
		FCPMEKEPOIA();
	}

	public void LBHEIOEPJLJ()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = BOLMLOBOHFB;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = OGPHBKFJGDG;
		mTable.onReposition = GIAJLJFHFAP;
	}

	private void GJHCDCNDHOG()
	{
		if (mHintDialog.gameObject.activeSelf)
		{
			mBuffIcon.gameObject.SetActive(mCurrentType == NKHJBLBAAEB.ElitePerk);
			if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
			{
				mIcon.spriteName = IFFDIHCPKFE.abilityIcon;
			}
			else
			{
				IFFDIHCPKFE.SetUpEliteIcon(mIcon, mBuffIcon);
			}
			mIcon.MakePixelPerfect();
		}
	}

	public void LONNFKPGCLL()
	{
		HLKJBOEPEFN();
	}

	private void BJGNGEHJGLF()
	{
		if (mHintDialog.gameObject.activeSelf)
		{
			mBuffIcon.gameObject.SetActive(mCurrentType == NKHJBLBAAEB.SpecialAbility);
			if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
			{
				mIcon.spriteName = IFFDIHCPKFE.abilityIcon;
			}
			else
			{
				IFFDIHCPKFE.SetUpEliteIcon(mIcon, mBuffIcon, 644f);
			}
			mIcon.MakePixelPerfect();
		}
	}

	private void BPNDDFBJOBF(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HHLJEIOCMOD();
	}

	private void KAIJCKLMNBI(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		KNDHJKMCPAG();
	}

	private void MBEBHDJGMAF(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			CKPAOFPPPFP();
		}
		else
		{
			PDDNDNKOGDC();
		}
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.GGIKKCKMIFJ();
		}
	}

	private void ADHPEJMDLGE()
	{
		float num = Mathf.Abs(mBottomItem.transform.localPosition.y);
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceY(num + 30f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num + 60f);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY(num / 2f + 30f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num + 60f);
	}

	private void PMGMEDPIONF()
	{
		if (mHintDialog.gameObject.activeSelf)
		{
			mBuffIcon.gameObject.SetActive(mCurrentType == NKHJBLBAAEB.SpecialAbility);
			if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
			{
				mIcon.spriteName = IFFDIHCPKFE.abilityIcon;
			}
			else
			{
				IFFDIHCPKFE.SetUpEliteIcon(mIcon, mBuffIcon, 122f);
			}
			mIcon.MakePixelPerfect();
		}
	}

	private void HHLJEIOCMOD()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1756f, 591f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1737f, mBasePosition.AddY(1397f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = PPFPOKNBJJC;
	}

	private void HGHFPJIKOIP(UITweener MGDJMGHCAAI)
	{
		HANFPHEIIDF();
	}

	public void KOEBOGHPHIA(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		JMAMNBJADKK();
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
		{
			mTitle.text = IFFDIHCPKFE.unitAbilityName;
			mDescription.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = IFFDIHCPKFE.unitBuffName;
			mDescription.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = true;
	}

	private void EGEDPJKFMDC()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1501f, 1873f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 659f, mBasePosition.AddY(164f), false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = MILOCMHNDCA;
	}

	private void IHLBMAGOFPH(UITweener MGDJMGHCAAI)
	{
		HLKJBOEPEFN();
	}

	public void EIKAKAMAPIO()
	{
		HANFPHEIIDF();
	}

	private void PNNGFGIJHDD()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(false);
	}

	private void KNDHJKMCPAG()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1731f, 98f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1990f, mBasePosition.AddY(1339f), false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = PPFPOKNBJJC;
	}

	private void MIFKAEBMEOM()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(true);
	}

	private void FOLNCJGBGBP()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(true);
		mHintDialog.alpha1 = 242f;
		PMGMEDPIONF();
		TweenAlpha.Begin(mHintDialog.gameObject, 1200f, 453f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(760f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 104f, mBasePosition.AddY(746f), mBasePosition.AddY(453f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = IPOFHAAKIFP;
	}

	private void FBDKNOMMHCL(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		DAALINAACLI();
	}

	public void JAIAMFJHDLP()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = MBEBHDJGMAF;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = LCNKKHNCCID;
		mTable.onReposition = ADHPEJMDLGE;
	}

	private void BMEGLNCPNNE()
	{
		float num = Mathf.Abs(mBottomItem.transform.localPosition.y);
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceY(num + 1334f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num + 322f);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY(num / 886f + 1170f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num + 597f);
	}

	public void GOMEJLFFKJM()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = KNJLEDOKELE;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = DPKAIAPBDLA;
		mTable.onReposition = BMEGLNCPNNE;
	}

	private void HALMNONOIFD(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		DAALINAACLI();
	}

	private void OGCPJDAAJGG()
	{
		float num = Mathf.Abs(mBottomItem.transform.localPosition.y);
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceY(num + 1341f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num + 420f);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY(num / 1395f + 1130f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num + 228f);
	}

	public void DLDGKEHFKDP()
	{
		FCPMEKEPOIA();
	}

	private void IEBAGABBAOC()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1141f, 62f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1223f, mBasePosition.AddY(56f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = PJIJPNLBOLM;
	}

	private void GPFOACJENNE(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			EGEDPJKFMDC();
		}
		else
		{
			OCJEKNKLDEF();
		}
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.PACPAOLNFAH();
		}
	}

	public void MMFBOMDHGPL()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = OCEJMCMPGOF;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = HALMNONOIFD;
		mTable.onReposition = GIAJLJFHFAP;
	}

	public void InitControls()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = IOBMEGDNGDE;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = IFDKIGIFLBE;
		mTable.onReposition = ADHPEJMDLGE;
	}

	public void JDFDJPAAIAA()
	{
		HANFPHEIIDF();
	}

	private void BOLMLOBOHFB(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			CKPAOFPPPFP();
		}
		else
		{
			MHAEMEMFPAI();
		}
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.ALEMDADOLKD();
		}
	}

	public void HEPDPPIBFMN()
	{
		FCPMEKEPOIA();
	}

	public void AAJLGPIGDED()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = MBEBHDJGMAF;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = HALMNONOIFD;
		mTable.onReposition = BMEGLNCPNNE;
	}

	private void MGDHGPFMFAA(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 93f, mBasePosition);
		tweenPosition.method = (UITweener.Method)8;
		tweenPosition.onFinished = null;
	}

	private void NBINKMOJALO(UITweener MGDJMGHCAAI)
	{
		FCPMEKEPOIA();
	}

	private void IPOFHAAKIFP(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 195f, mBasePosition);
		tweenPosition.method = UITweener.Method.BounceIn;
		tweenPosition.onFinished = null;
	}

	private void DCDGEHAIGIM(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 504f, mBasePosition);
		tweenPosition.method = UITweener.Method.BounceIn;
		tweenPosition.onFinished = null;
	}

	private void JKFHPCFHOMP(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		EGEDPJKFMDC();
	}

	public void AAPGEAEKKGF()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = NNIKBCOHNLN;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = ALPGLHCDBMI;
		mTable.onReposition = GIAJLJFHFAP;
	}

	private void LCNKKHNCCID(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HMOODEGLJMP();
	}

	private void PJIJPNLBOLM(UITweener MGDJMGHCAAI)
	{
		HANFPHEIIDF();
	}

	public void AEOHKMFNAGF()
	{
		FCPMEKEPOIA();
	}

	private void GAHBJIAGMEK(UITweener MGDJMGHCAAI)
	{
		FCPMEKEPOIA();
	}

	private void MHAEMEMFPAI()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(true);
		mHintDialog.alpha1 = 1217f;
		PMGMEDPIONF();
		TweenAlpha.Begin(mHintDialog.gameObject, 1588f, 567f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(888f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 334f, mBasePosition.AddY(1667f), mBasePosition.AddY(1359f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = IPOFHAAKIFP;
	}

	private void LMLIBIHDAAG(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HAEIJEBGPDB();
	}

	private void HLGLCKOFGKJ(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1978f, mBasePosition, false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = null;
	}

	private void DGPDKGNIGGF(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			DAALINAACLI();
		}
		else
		{
			AMKADDAMKML();
		}
		if (mCurrentType == NKHJBLBAAEB.ElitePerk && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), true);
			JFNGDDOMPAE.PBHGKCMOEKI();
		}
	}

	public void DDJIMJHDAMI(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		IKBABLFJHOA();
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
		{
			mTitle.text = IFFDIHCPKFE.unitAbilityName;
			mDescription.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = IFFDIHCPKFE.unitBuffName;
			mDescription.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = false;
	}

	private void CKPAOFPPPFP()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 700f, 1223f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 5f, mBasePosition.AddY(1299f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = NBINKMOJALO;
	}

	private void IKBABLFJHOA()
	{
		if (mHintDialog.gameObject.activeSelf)
		{
			mBuffIcon.gameObject.SetActive(mCurrentType == NKHJBLBAAEB.SpecialAbility);
			if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
			{
				mIcon.spriteName = IFFDIHCPKFE.abilityIcon;
			}
			else
			{
				IFFDIHCPKFE.SetUpEliteIcon(mIcon, mBuffIcon, 166f);
			}
			mIcon.MakePixelPerfect();
		}
	}

	private void NLCKILJAKEL(UITweener MGDJMGHCAAI)
	{
		HANFPHEIIDF();
	}

	private void KNJLEDOKELE(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			HHLJEIOCMOD();
		}
		else
		{
			EAKCNICIIEH();
		}
		if (mCurrentType == NKHJBLBAAEB.ElitePerk && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), true);
			JFNGDDOMPAE.PNHDGLHLNIE();
		}
	}

	public void FAHPIINNMBB()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = MBEBHDJGMAF;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = LMLIBIHDAAG;
		mTable.onReposition = BMEGLNCPNNE;
	}

	private void HAEIJEBGPDB()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1729f, 797f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1587f, mBasePosition.AddY(1770f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			PNNGFGIJHDD();
		};
	}

	public void InitGUIValues()
	{
		PNNGFGIJHDD();
	}

	private void DIGGBDMKJAJ()
	{
		float num = Mathf.Abs(mBottomItem.transform.localPosition.y);
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceY(num + 575f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num + 1141f);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY(num / 1500f + 192f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num + 143f);
	}

	[CompilerGenerated]
	private void ONAFPHKJDGI(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 0.15f, mBasePosition);
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	private void DPKAIAPBDLA(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		IEBAGABBAOC();
	}

	private void MCCKHHLMOAL(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 314f, mBasePosition, false);
		tweenPosition.method = UITweener.Method.BounceOut;
		tweenPosition.onFinished = null;
	}

	private void NBAECDPCKFD(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			DAALINAACLI();
		}
		else
		{
			OCJEKNKLDEF();
		}
		if (mCurrentType == NKHJBLBAAEB.ElitePerk && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), true);
			JFNGDDOMPAE.PACPAOLNFAH();
		}
	}

	public void HNLIFPCKGEK()
	{
		FCPMEKEPOIA();
	}

	public void PGLHICADCEE()
	{
		HANFPHEIIDF();
	}

	private void EJFGOEPGOBI(UITweener MGDJMGHCAAI)
	{
		HLKJBOEPEFN();
	}

	public void HPJDOALKOGF()
	{
		HANFPHEIIDF();
	}

	private void KLHBAOPFAOK(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			DAALINAACLI();
		}
		else
		{
			MHAEMEMFPAI();
		}
		if (mCurrentType == NKHJBLBAAEB.SpecialAbility && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.FFGPGMDFCMN();
		}
	}

	public void KICJHALCOOM()
	{
		HANFPHEIIDF();
	}

	private void JFNDCNMOCNB()
	{
		if (mHintDialog.gameObject.activeSelf)
		{
			mBuffIcon.gameObject.SetActive(mCurrentType == NKHJBLBAAEB.SpecialAbility);
			if (mCurrentType == NKHJBLBAAEB.SpecialAbility)
			{
				mIcon.spriteName = IFFDIHCPKFE.abilityIcon;
			}
			else
			{
				IFFDIHCPKFE.SetUpEliteIcon(mIcon, mBuffIcon, 1248f);
			}
			mIcon.MakePixelPerfect();
		}
	}
}
