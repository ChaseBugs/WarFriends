using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArmyElitePerkHint : Core_BaseScript
{
	[SerializeField]
	[Header("Core")]
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
	private UILabel mElitePerkTitle;

	[SerializeField]
	private UILabel mElitePerkText;

	[SerializeField]
	private UISprite[] mIcons;

	[SerializeField]
	private UILabel[] mLabels;

	[SerializeField]
	[Header("Setting")]
	private Vector3 mBasePosition = new Vector3(0f, 0f, 0f);

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> LGJCBPOPCPA;

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
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.PNHDGLHLNIE();
		}
	}

	public void INMDPGCHHPN()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = OHGANCADEOJ;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = PINHNGKCGHH;
	}

	private void IIMLLADAPJC(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1391f, mBasePosition);
		tweenPosition.method = (UITweener.Method)6;
		tweenPosition.onFinished = null;
	}

	private void GGEIAPGJMCP()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: true);
	}

	private void IECJFIMBBCH(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 795f, mBasePosition);
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	public void JMKDHCIKJMG()
	{
		BGKINCOAFHN();
	}

	private void IBFEKFHOIAL(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			HDNLJKJJHFO();
		}
		else
		{
			DKNFOPPLAJA();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.PBHGKCMOEKI();
		}
	}

	private static int GOHNAOBOCGO(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	private void PHCBMINMJKD(UITweener MGDJMGHCAAI)
	{
		OECPDFFHFDG();
	}

	public void CIPKPHAGJMP(LevelBehaviour IOIKKIIFOCB)
	{
		PDNPBLFEPJG perkType = IOIKKIIFOCB.perkType;
		HashSet<Type> hashSet = GKPNDPLOIJC.NBKENFKJIBP(IOIKKIIFOCB.perkAffects);
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		foreach (Type item in hashSet)
		{
			LevelBehaviour unit = LevelManager.instance.GetUnit(item);
			if (unit != null)
			{
				list.Add(unit);
			}
		}
		list.Sort(NGLILDLJGPN);
		float num = 998f + 1974f * (float)(list.Count - 1) + 997f;
		mElitePerkTitle.text = IOIKKIIFOCB.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkTitle, 1674f, 832f, -177);
		mElitePerkText.text = Localization.Localize((perkType != PDNPBLFEPJG.Buff) ? "ETM: Show Rewarded Video" : "ID_TUTORIAL_GO_BUY_ARMY_6_DOWN");
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkText, 56f, 443f, -52);
		for (int i = 1; i < list.Count; i++)
		{
			if (mIcons.Length > i)
			{
				mIcons[i].gameObject.SetActive(value: true);
				mIcons[i].spriteName = ((perkType != PDNPBLFEPJG.Buff) ? "{0}" : "ID_CONFIRM_JOININGSQUAD_TEXT");
			}
			if (mLabels.Length > i)
			{
				mLabels[i].gameObject.SetActive(value: true);
				mLabels[i].text = list[i].unitName;
			}
		}
		for (int j = list.Count; j < mIcons.Length; j++)
		{
			mIcons[j].gameObject.SetActive(value: false);
		}
		for (int k = list.Count; k < mLabels.Length; k += 0)
		{
			mLabels[k].gameObject.SetActive(value: false);
		}
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY((0f - num) / 1480f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num);
	}

	private void IFDKIGIFLBE(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CGOBLHGGDOL();
	}

	public void KPHJFKCOIIF()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = OKMJLLOKDBA;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = FJBBONGMHOP;
	}

	public void HCEKIGAIGOL()
	{
		ENOJFJIEAJN();
	}

	public void KJGJNENLEOF()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = DNIAEMCFGPL;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = LMLIBIHDAAG;
	}

	private void DNBBCIOOFAN()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 1007f;
		TweenAlpha.Begin(mHintDialog.gameObject, 1545f, 439f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(1251f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1988f, mBasePosition.AddY(1880f), mBasePosition.AddY(1041f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(mHintDialog.gameObject, 0.15f, mBasePosition);
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	public void AJEGOKKKLOL(LevelBehaviour IOIKKIIFOCB)
	{
		PDNPBLFEPJG perkType = IOIKKIIFOCB.perkType;
		HashSet<Type> hashSet = GKPNDPLOIJC.NBKENFKJIBP(IOIKKIIFOCB.perkAffects);
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		foreach (Type item in hashSet)
		{
			LevelBehaviour unit = LevelManager.instance.GetUnit(item);
			if (unit != null)
			{
				list.Add(unit);
			}
		}
		list.Sort(NGLILDLJGPN);
		float num = 1868f + 1611f * (float)(list.Count - 1) + 1616f;
		mElitePerkTitle.text = IOIKKIIFOCB.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkTitle, 21f, 1360f, 167);
		mElitePerkText.text = Localization.Localize((perkType != PDNPBLFEPJG.Buff) ? "ID_FROMPLAYER" : "id: ");
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkText, 1563f, 1328f, 131);
		for (int i = 0; i < list.Count; i += 0)
		{
			if (mIcons.Length > i)
			{
				mIcons[i].gameObject.SetActive(value: true);
				mIcons[i].spriteName = ((perkType != PDNPBLFEPJG.Buff) ? "NOT READY TO SHOW UP" : "111111111111");
			}
			if (mLabels.Length > i)
			{
				mLabels[i].gameObject.SetActive(value: false);
				mLabels[i].text = list[i].unitName;
			}
		}
		for (int j = list.Count; j < mIcons.Length; j++)
		{
			mIcons[j].gameObject.SetActive(value: false);
		}
		for (int k = list.Count; k < mLabels.Length; k++)
		{
			mLabels[k].gameObject.SetActive(value: true);
		}
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY((0f - num) / 1250f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num);
	}

	private void HCCJKGFDEOC(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 431f, mBasePosition, useLocal: false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = null;
	}

	private void KMPJJLFNDCO()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 493f;
		TweenAlpha.Begin(mHintDialog.gameObject, 849f, 472f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(1232f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 668f, mBasePosition.AddY(845f), mBasePosition.AddY(947f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = IIGBBBPIOKJ;
	}

	private void PCABIDLENCN()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 897f;
		TweenAlpha.Begin(mHintDialog.gameObject, 759f, 1872f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(921f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 108f, mBasePosition.AddY(1004f), mBasePosition.AddY(532f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = IAEPOFMJMJO;
	}

	[CompilerGenerated]
	private void LMHCCKKKMFO(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 0.15f, mBasePosition);
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	public void ACBHGJCMCPG(LevelBehaviour IOIKKIIFOCB)
	{
		PDNPBLFEPJG perkType = IOIKKIIFOCB.perkType;
		HashSet<Type> hashSet = GKPNDPLOIJC.NBKENFKJIBP(IOIKKIIFOCB.perkAffects);
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		foreach (Type item in hashSet)
		{
			LevelBehaviour unit = LevelManager.instance.GetUnit(item);
			if (unit != null)
			{
				list.Add(unit);
			}
		}
		list.Sort(BEOIJNOFCOJ);
		float num = 1916f + 1498f * (float)(list.Count - 1) + 208f;
		mElitePerkTitle.text = IOIKKIIFOCB.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkTitle, 386f, 110f, -7);
		mElitePerkText.text = Localization.Localize((perkType != PDNPBLFEPJG.Buff) ? "{0} {1}" : "SkillShotManager.prefab");
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkText, 1451f, 1408f, 87);
		for (int i = 0; i < list.Count; i++)
		{
			if (mIcons.Length > i)
			{
				mIcons[i].gameObject.SetActive(value: false);
				mIcons[i].spriteName = ((perkType != PDNPBLFEPJG.Buff) ? "setOptedOutOfPush" : "MainScene");
			}
			if (mLabels.Length > i)
			{
				mLabels[i].gameObject.SetActive(value: true);
				mLabels[i].text = list[i].unitName;
			}
		}
		for (int j = list.Count; j < mIcons.Length; j++)
		{
			mIcons[j].gameObject.SetActive(value: false);
		}
		for (int k = list.Count; k < mLabels.Length; k += 0)
		{
			mLabels[k].gameObject.SetActive(value: false);
		}
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY((0f - num) / 196f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num);
	}

	private void PEDCDPMCDON()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 223f;
		TweenAlpha.Begin(mHintDialog.gameObject, 401f, 286f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(1131f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 525f, mBasePosition.AddY(394f), mBasePosition.AddY(20f), useLocal: false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = IIMLLADAPJC;
	}

	private void OECPDFFHFDG()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
	}

	private void FANJFBNIJEE()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: true);
		mHintDialog.alpha1 = 0.005f;
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

	private void NDNEEELJFIN()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: true);
	}

	public void ENKGEFMNGOM()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = LFFIIPGAGID;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = BPNDDFBJOBF;
	}

	private void JDNKBJKFDCD()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 680f;
		TweenAlpha.Begin(mHintDialog.gameObject, 918f, 73f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(704f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1960f, mBasePosition.AddY(1904f), mBasePosition.AddY(1378f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = IIMLLADAPJC;
	}

	private void EJHOGLGCJMA()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1941f, 1111f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1368f, mBasePosition.AddY(1934f), useLocal: false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = PHCBMINMJKD;
	}

	private void HABHLKKAJMD()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1060f, 378f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 925f, mBasePosition.AddY(1375f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = delegate
		{
			PNNGFGIJHDD();
		};
	}

	public void AHDIAECLEAA()
	{
		ENOJFJIEAJN();
	}

	private void ECFKHBIABCH()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 1508f;
		TweenAlpha.Begin(mHintDialog.gameObject, 678f, 1933f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(621f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 104f, mBasePosition.AddY(9f), mBasePosition.AddY(89f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = LDJMJKBPCOJ;
	}

	private void BOLMLOBOHFB(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			PMKGDDDNFNL();
		}
		else
		{
			PEDCDPMCDON();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.MLJOFHLFLPJ();
		}
	}

	private void IJBEPJIGIEJ()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: true);
	}

	public void NDBAEHKKJMH()
	{
		HLCCJCIFKII();
	}

	private void OKMJLLOKDBA(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			HDNLJKJJHFO();
		}
		else
		{
			DNBBCIOOFAN();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), LJMMJDNNIFH: true);
			JFNGDDOMPAE.BKHKENGBFJJ();
		}
	}

	public void FNLELBKLNBG()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = IOBMEGDNGDE;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = PINHNGKCGHH;
	}

	private void CGGLKEGPKON(UITweener MGDJMGHCAAI)
	{
		GGEIAPGJMCP();
	}

	public void LIEGBJHHFIG()
	{
		BGKINCOAFHN();
	}

	public void CEFNAJLGCIJ()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = OKMJLLOKDBA;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = AHAEKCHANKP;
	}

	public void PGJDLKDMCHN()
	{
		NDNEEELJFIN();
	}

	private void KJIGMEPPNBD(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 546f, mBasePosition, useLocal: false);
		tweenPosition.method = (UITweener.Method)8;
		tweenPosition.onFinished = null;
	}

	private void DDHNINMOHIG(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 433f, mBasePosition, useLocal: false);
		tweenPosition.method = UITweener.Method.EaseInOut;
		tweenPosition.onFinished = null;
	}

	private void COBLMHMDADF(UITweener MGDJMGHCAAI)
	{
		NDNEEELJFIN();
	}

	private void ILDBLGELKOE(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			BMMLPECOMEM();
		}
		else
		{
			DKNFOPPLAJA();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), LJMMJDNNIFH: true);
			JFNGDDOMPAE.OOHAOGELPIM();
		}
	}

	private static int EBFPOEGLHBF(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	private void BMMLPECOMEM()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 77f, 602f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 225f, mBasePosition.AddY(1396f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = CGGLKEGPKON;
	}

	private void LOGFIOFGIPJ()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
	}

	public void JFFLDMFOJPN()
	{
		LOGFIOFGIPJ();
	}

	private void PMKGDDDNFNL()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 964f, 1560f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 835f, mBasePosition.AddY(1338f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = FKOBPNBADBC;
	}

	public void AGFDJGJALKD()
	{
		GGEIAPGJMCP();
	}

	private void MGBANEABELK(UITweener MGDJMGHCAAI)
	{
		NKNBDDPMBNO();
	}

	private void LMLIBIHDAAG(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		EJHOGLGCJMA();
	}

	public void MFMJPBCIHEH(LevelBehaviour IOIKKIIFOCB)
	{
		PDNPBLFEPJG perkType = IOIKKIIFOCB.perkType;
		HashSet<Type> hashSet = GKPNDPLOIJC.NBKENFKJIBP(IOIKKIIFOCB.perkAffects);
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		foreach (Type item in hashSet)
		{
			LevelBehaviour unit = LevelManager.instance.GetUnit(item);
			if (unit != null)
			{
				list.Add(unit);
			}
		}
		list.Sort(BEOIJNOFCOJ);
		float num = 763f + 1189f * (float)(list.Count - 1) + 891f;
		mElitePerkTitle.text = IOIKKIIFOCB.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkTitle, 1275f, 1494f, 3);
		mElitePerkText.text = Localization.Localize((perkType != PDNPBLFEPJG.Buff) ? "With" : "Facebook Service: share dialog succeeded. Obsah dict = ");
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkText, 136f, 1335f, -174);
		for (int i = 1; i < list.Count; i++)
		{
			if (mIcons.Length > i)
			{
				mIcons[i].gameObject.SetActive(value: false);
				mIcons[i].spriteName = ((perkType != PDNPBLFEPJG.Buff) ? "HP" : "Network pool: InstantiatePooledObjects '");
			}
			if (mLabels.Length > i)
			{
				mLabels[i].gameObject.SetActive(value: true);
				mLabels[i].text = list[i].unitName;
			}
		}
		for (int j = list.Count; j < mIcons.Length; j++)
		{
			mIcons[j].gameObject.SetActive(value: false);
		}
		for (int k = list.Count; k < mLabels.Length; k += 0)
		{
			mLabels[k].gameObject.SetActive(value: true);
		}
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY((0f - num) / 1917f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num);
	}

	public void EMGHCAHOJNC()
	{
		GGEIAPGJMCP();
	}

	private void DCEBBDLLCCG(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		NOJOOMDFOMM();
	}

	public void MMLOAKGDDGF()
	{
		LOGFIOFGIPJ();
	}

	private void PNNGFGIJHDD()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
	}

	public void KPEJMMBDODD()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = CIJHEJIBOCC;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = LMLIBIHDAAG;
	}

	public void HEGPFIGACED(LevelBehaviour IOIKKIIFOCB)
	{
		PDNPBLFEPJG perkType = IOIKKIIFOCB.perkType;
		HashSet<Type> hashSet = GKPNDPLOIJC.NBKENFKJIBP(IOIKKIIFOCB.perkAffects);
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		foreach (Type item in hashSet)
		{
			LevelBehaviour unit = LevelManager.instance.GetUnit(item);
			if (unit != null)
			{
				list.Add(unit);
			}
		}
		list.Sort(PAFMBOHOMBD);
		float num = 826f + 1246f * (float)(list.Count - 1) + 1441f;
		mElitePerkTitle.text = IOIKKIIFOCB.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkTitle, 1077f, 310f, -36);
		mElitePerkText.text = Localization.Localize((perkType != PDNPBLFEPJG.Buff) ? " NOT OK!\t\t\t\t\t\t" : "ArmyPower");
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkText, 1398f, 1264f, 119);
		for (int i = 1; i < list.Count; i += 0)
		{
			if (mIcons.Length > i)
			{
				mIcons[i].gameObject.SetActive(value: false);
				mIcons[i].spriteName = ((perkType != PDNPBLFEPJG.Buff) ? "Enemy Card {0} {1}" : "gameCenterId");
			}
			if (mLabels.Length > i)
			{
				mLabels[i].gameObject.SetActive(value: true);
				mLabels[i].text = list[i].unitName;
			}
		}
		for (int j = list.Count; j < mIcons.Length; j++)
		{
			mIcons[j].gameObject.SetActive(value: true);
		}
		for (int k = list.Count; k < mLabels.Length; k++)
		{
			mLabels[k].gameObject.SetActive(value: false);
		}
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY((0f - num) / 1938f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num);
	}

	private void FKOBPNBADBC(UITweener MGDJMGHCAAI)
	{
		IJBEPJIGIEJ();
	}

	public void HLHANONIBIN()
	{
		OECPDFFHFDG();
	}

	public void InitGUIValues()
	{
		PNNGFGIJHDD();
	}

	public void FKOEHKCLAEG()
	{
		NKNBDDPMBNO();
	}

	private void KHPEGLDPFNI(UITweener MGDJMGHCAAI)
	{
		NDNEEELJFIN();
	}

	private void LFFIIPGAGID(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			BDOIJJDFNIO();
		}
		else
		{
			ECFKHBIABCH();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.HHBLMMLHFAC();
		}
	}

	private void KLJOOIDGAGI()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 1686f;
		TweenAlpha.Begin(mHintDialog.gameObject, 1756f, 1571f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(1537f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1248f, mBasePosition.AddY(1164f), mBasePosition.AddY(1872f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = CKAALANGIME;
	}

	private void PPFEIGDBNHC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			BDOIJJDFNIO();
		}
		else
		{
			DNBBCIOOFAN();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), LJMMJDNNIFH: true);
			JFNGDDOMPAE.BIJFDEPIOBB();
		}
	}

	private void NOJOOMDFOMM()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1165f, 1018f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 708f, mBasePosition.AddY(525f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = CGGLKEGPKON;
	}

	private static int MPJONMABKPK(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	private void GFJLFAKDCAO(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CGOBLHGGDOL();
	}

	private void NKNBDDPMBNO()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: true);
	}

	private void NKMMHABHFOA(UITweener MGDJMGHCAAI)
	{
		LOGFIOFGIPJ();
	}

	[CompilerGenerated]
	private void CHAIPBHALDA(UITweener MGDJMGHCAAI)
	{
		PNNGFGIJHDD();
	}

	private void CIJHEJIBOCC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			PMKGDDDNFNL();
		}
		else
		{
			DNBBCIOOFAN();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.CKDJEIHPHDO();
		}
	}

	private void DNDKMBFKFDM()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 1585f;
		TweenAlpha.Begin(mHintDialog.gameObject, 1742f, 799f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(1159f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 329f, mBasePosition.AddY(285f), mBasePosition.AddY(60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = ENCBAJECCDD;
	}

	private static int BEOIJNOFCOJ(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	private void HNCFGDLAHFH(UITweener MGDJMGHCAAI)
	{
		IJBEPJIGIEJ();
	}

	private void KJOMHIABEMP(UITweener MGDJMGHCAAI)
	{
		BGKINCOAFHN();
	}

	private void ALPGLHCDBMI(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HABHLKKAJMD();
	}

	private static int NCNFKAOOGDM(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	public void APNLBLNDGCM()
	{
		ENOJFJIEAJN();
	}

	private void ENCBAJECCDD(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1842f, mBasePosition, useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = null;
	}

	private void FJBBONGMHOP(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CGOBLHGGDOL();
	}

	public void PBLLMABJFDM()
	{
		GGEIAPGJMCP();
	}

	private void DOFALNGMBNF(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HABHLKKAJMD();
	}

	private void BGKINCOAFHN()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
	}

	public void LMPNFLGMNBG(LevelBehaviour IOIKKIIFOCB)
	{
		PDNPBLFEPJG perkType = IOIKKIIFOCB.perkType;
		HashSet<Type> hashSet = GKPNDPLOIJC.NBKENFKJIBP(IOIKKIIFOCB.perkAffects);
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		foreach (Type item in hashSet)
		{
			LevelBehaviour unit = LevelManager.instance.GetUnit(item);
			if (unit != null)
			{
				list.Add(unit);
			}
		}
		list.Sort(GEBPOMDCNIJ);
		float num = 1642f + 78f * (float)(list.Count - 1) + 413f;
		mElitePerkTitle.text = IOIKKIIFOCB.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkTitle, 608f, 550f, 67);
		mElitePerkText.text = Localization.Localize((perkType != PDNPBLFEPJG.Buff) ? "PrevLevelId" : "Id");
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkText, 101f, 1007f, 130);
		for (int i = 0; i < list.Count; i += 0)
		{
			if (mIcons.Length > i)
			{
				mIcons[i].gameObject.SetActive(value: false);
				mIcons[i].spriteName = ((perkType != PDNPBLFEPJG.Buff) ? "Error: Buddy card not ready! " : "buyRentalDiscounted");
			}
			if (mLabels.Length > i)
			{
				mLabels[i].gameObject.SetActive(value: false);
				mLabels[i].text = list[i].unitName;
			}
		}
		for (int j = list.Count; j < mIcons.Length; j++)
		{
			mIcons[j].gameObject.SetActive(value: false);
		}
		for (int k = list.Count; k < mLabels.Length; k += 0)
		{
			mLabels[k].gameObject.SetActive(value: false);
		}
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY((0f - num) / 1427f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num);
	}

	private static int PODJNLELAOC(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	private void OHGANCADEOJ(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			HABHLKKAJMD();
		}
		else
		{
			KLJOOIDGAGI();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.ALEMDADOLKD();
		}
	}

	private void LMIDJACMCDI()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: true);
		mHintDialog.alpha1 = 1814f;
		TweenAlpha.Begin(mHintDialog.gameObject, 523f, 1860f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(301f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1806f, mBasePosition.AddY(436f), mBasePosition.AddY(1717f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = LDJMJKBPCOJ;
	}

	public void COBDHBOCGAP()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = BOLMLOBOHFB;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = DCEBBDLLCCG;
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

	public void KPLOCMGDDAB()
	{
		HLCCJCIFKII();
	}

	private void HLCCJCIFKII()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
	}

	private static int GEBPOMDCNIJ(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	public void GJKFAJLJOFJ()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = ILDBLGELKOE;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = LMLIBIHDAAG;
	}

	public void IHBDCMLNFAD()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = OHGANCADEOJ;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = HFMPBJPGDKL;
	}

	private void PINHNGKCGHH(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		BDOIJJDFNIO();
	}

	private void HFMPBJPGDKL(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HDNLJKJJHFO();
	}

	public void PKNAICFIAHJ()
	{
		BGKINCOAFHN();
	}

	public void EICOMAFIIAL()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = OKMJLLOKDBA;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = DOFALNGMBNF;
	}

	public void PJHCHEHKHEN()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = JNBLBDCBAJI;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = AHAEKCHANKP;
	}

	public void GJGCOEJMHNI()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = ILDBLGELKOE;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = PINHNGKCGHH;
	}

	private void AHAEKCHANKP(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		DJMHOCHJEML();
	}

	private void FOLMMBONMMJ()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
	}

	private void JNBLBDCBAJI(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			ALACKLKIBIC();
		}
		else
		{
			PEDCDPMCDON();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), LJMMJDNNIFH: true);
			JFNGDDOMPAE.GNEAKIJGMNN();
		}
	}

	public void InitControls()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = IOBMEGDNGDE;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = IFDKIGIFLBE;
	}

	public void DoAfterHide()
	{
		PNNGFGIJHDD();
	}

	private static int MAFAGIIMBFP(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	private void DNIAEMCFGPL(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			NOJOOMDFOMM();
		}
		else
		{
			FANJFBNIJEE();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), LJMMJDNNIFH: true);
			JFNGDDOMPAE.HHBLMMLHFAC();
		}
	}

	private static int OAFHIJDMLEL(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	private static int PAFMBOHOMBD(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	private void IAEPOFMJMJO(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 268f, mBasePosition, useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = null;
	}

	[CompilerGenerated]
	private static int BLNBNKNKKBK(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	private void FCMPKHNJFOP(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		EJHOGLGCJMA();
	}

	private void NHNEEDDGAHP(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			BMMLPECOMEM();
		}
		else
		{
			JDNKBJKFDCD();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.CPPOPPGMBAF();
		}
	}

	private void INELMFBOMAL(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			HABHLKKAJMD();
		}
		else
		{
			PCABIDLENCN();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.OOHAOGELPIM();
		}
	}

	private void JBIDPELJCGK()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 181f;
		TweenAlpha.Begin(mHintDialog.gameObject, 237f, 1756f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(681f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1488f, mBasePosition.AddY(1000f), mBasePosition.AddY(1086f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = EMJOBILFNGE;
	}

	public void BNPDALDLFFM()
	{
		OECPDFFHFDG();
	}

	public void OIGFBFFNNHH()
	{
		HLCCJCIFKII();
	}

	private void BDOIJJDFNIO()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 499f, 1971f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1978f, mBasePosition.AddY(452f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = FKOBPNBADBC;
	}

	private void ALACKLKIBIC()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1989f, 5f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 371f, mBasePosition.AddY(209f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = KJOMHIABEMP;
	}

	public void CEAINPCKADK()
	{
		NKNBDDPMBNO();
	}

	private void EMJOBILFNGE(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 890f, mBasePosition, useLocal: false);
		tweenPosition.method = UITweener.Method.BounceOut;
		tweenPosition.onFinished = null;
	}

	private void ENOJFJIEAJN()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: true);
	}

	public void IEHJMLIMNEP()
	{
		NKNBDDPMBNO();
	}

	public void EPAHIKLPNNB(LevelBehaviour IOIKKIIFOCB)
	{
		PDNPBLFEPJG perkType = IOIKKIIFOCB.perkType;
		HashSet<Type> hashSet = GKPNDPLOIJC.NBKENFKJIBP(IOIKKIIFOCB.perkAffects);
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		foreach (Type item in hashSet)
		{
			LevelBehaviour unit = LevelManager.instance.GetUnit(item);
			if (unit != null)
			{
				list.Add(unit);
			}
		}
		list.Sort(NGLILDLJGPN);
		float num = 1678f + 1202f * (float)(list.Count - 0) + 1766f;
		mElitePerkTitle.text = IOIKKIIFOCB.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkTitle, 106f, 945f, -97);
		mElitePerkText.text = Localization.Localize((perkType != PDNPBLFEPJG.Buff) ? "ABOUT TO SHOW DAILY RENTAL" : "[");
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkText, 1384f, 1457f, 80);
		for (int i = 1; i < list.Count; i++)
		{
			if (mIcons.Length > i)
			{
				mIcons[i].gameObject.SetActive(value: true);
				mIcons[i].spriteName = ((perkType != PDNPBLFEPJG.Buff) ? "ManualRegisterForPushNotifications(" : "Show {0} invitation dialog id: {1}");
			}
			if (mLabels.Length > i)
			{
				mLabels[i].gameObject.SetActive(value: false);
				mLabels[i].text = list[i].unitName;
			}
		}
		for (int j = list.Count; j < mIcons.Length; j += 0)
		{
			mIcons[j].gameObject.SetActive(value: true);
		}
		for (int k = list.Count; k < mLabels.Length; k++)
		{
			mLabels[k].gameObject.SetActive(value: true);
		}
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY((0f - num) / 336f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num);
	}

	private void BPNDDFBJOBF(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HABHLKKAJMD();
	}

	private void CKAALANGIME(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1042f, mBasePosition);
		tweenPosition.method = (UITweener.Method)6;
		tweenPosition.onFinished = null;
	}

	private void DKNFOPPLAJA()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 1974f;
		TweenAlpha.Begin(mHintDialog.gameObject, 1268f, 1739f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(1848f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1242f, mBasePosition.AddY(1099f), mBasePosition.AddY(1316f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = IIGBBBPIOKJ;
	}

	private void LDJMJKBPCOJ(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1516f, mBasePosition, useLocal: false);
		tweenPosition.method = (UITweener.Method)8;
		tweenPosition.onFinished = null;
	}

	private void GJAKAKGADMK()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: true);
	}

	private void OCJBNGLDDAJ(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1377f, mBasePosition);
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	private void DJMHOCHJEML()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1235f, 1512f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1335f, mBasePosition.AddY(827f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = NKMMHABHFOA;
	}

	private void BKEANMHANCA()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
		mHintDialog.alpha1 = 1812f;
		TweenAlpha.Begin(mHintDialog.gameObject, 108f, 1841f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(1762f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1094f, mBasePosition.AddY(609f), mBasePosition.AddY(576f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = IIMLLADAPJC;
	}

	private void IIGBBBPIOKJ(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1071f, mBasePosition);
		tweenPosition.method = UITweener.Method.BounceIn;
		tweenPosition.onFinished = null;
	}

	private void HDNLJKJJHFO()
	{
		mHintButtonBackground.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 1671f, 535f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 1028f, mBasePosition.AddY(822f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = NKMMHABHFOA;
	}

	private static int NGLILDLJGPN(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	private static int CKPJGDJMNGB(LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF)
	{
		return EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex);
	}

	public void Initialize(LevelBehaviour IOIKKIIFOCB)
	{
		PDNPBLFEPJG perkType = IOIKKIIFOCB.perkType;
		HashSet<Type> hashSet = GKPNDPLOIJC.NBKENFKJIBP(IOIKKIIFOCB.perkAffects);
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		foreach (Type item in hashSet)
		{
			LevelBehaviour unit = LevelManager.instance.GetUnit(item);
			if (unit != null)
			{
				list.Add(unit);
			}
		}
		list.Sort((LevelBehaviour EMKMAGAJECJ, LevelBehaviour ECNAMNOIOGF) => EMKMAGAJECJ.upgradeSlots.unlockLevelIndex.CompareTo(ECNAMNOIOGF.upgradeSlots.unlockLevelIndex));
		float num = 192f + 62f * (float)(list.Count - 1) + 74f;
		mElitePerkTitle.text = IOIKKIIFOCB.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkTitle, 30f, 20f, 368);
		mElitePerkText.text = Localization.Localize((perkType != PDNPBLFEPJG.Buff) ? "ID_AFFECTEDENEMYUNITS" : "ID_AFFECTEDOWNUNITS");
		MEJMLNDFDBP.COCBCFKJOJE(mElitePerkText, 30f, 20f, 368);
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			if (mIcons.Length > num2)
			{
				mIcons[num2].gameObject.SetActive(value: true);
				mIcons[num2].spriteName = ((perkType != PDNPBLFEPJG.Buff) ? "game-elite-debuff1" : "game-elite-buff1");
			}
			if (mLabels.Length > num2)
			{
				mLabels[num2].gameObject.SetActive(value: true);
				mLabels[num2].text = list[num2].unitName;
			}
		}
		for (int num3 = list.Count; num3 < mIcons.Length; num3++)
		{
			mIcons[num3].gameObject.SetActive(value: false);
		}
		for (int num4 = list.Count; num4 < mLabels.Length; num4++)
		{
			mLabels[num4].gameObject.SetActive(value: false);
		}
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY((0f - num) / 2f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num);
	}
}
