using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LeftGoldenSuitcase : Core_BaseScript
{
	public enum LPNAMBCJEOM
	{
		None = 0,
		Waiting = 1,
		Ready = 2
	}

	[Header("Core")]
	public BoxCollider PMAOBDMEKFD;

	public GameObject HPKOHODOPMH;

	public UIButtonScale JADGKMOBLCO;

	public UISprite DAANKCOLJGJ;

	public UISprite KMFGCJEGJJK;

	public UILabel PIGCPLONEIC;

	public UILabel NEPIMKJAFGP;

	[Header("Hint Part")]
	public UIPanel IILAJEMNNEA;

	public BoxCollider PMBJBGEJGEC;

	public UISprite MDOHPDCGFHP;

	public UILabel CNMDFMGELLH;

	public UISprite BEOJPKEGEMN;

	private LPNAMBCJEOM FPABAOJKDFC;

	private int AIBDJOEKPJH = -1;

	private void JKPFDMPELBN(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CGOBLHGGDOL();
	}

	public void InitGuiValues()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(EHAEIFENOFB));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(EHAEIFENOFB));
		FPABAOJKDFC = LPNAMBCJEOM.None;
		LPNAMBCJEOM lPNAMBCJEOM = BHDGGFMIPDI();
		switch (lPNAMBCJEOM)
		{
		case LPNAMBCJEOM.Ready:
			NGANNGEBJDB(true);
			break;
		case LPNAMBCJEOM.None:
			FAAONKCCKEG();
			break;
		default:
			PENILGDMCEA();
			break;
		}
		FPABAOJKDFC = lPNAMBCJEOM;
		PNNGFGIJHDD();
	}

	public void HBGBFKJBLBO()
	{
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += ECGHFEMNMMH;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += ECGHFEMNMMH;
	}

	private void DHDDADCAPEL()
	{
		float duration = 1353f;
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, duration, 303f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, duration, 889f);
		TweenAlpha.Begin(PIGCPLONEIC.gameObject, duration, 1199f);
		TweenAlpha.Begin(NEPIMKJAFGP.gameObject, duration, 1555f);
		TweenAlpha.Begin(MDOHPDCGFHP.gameObject, duration, 956f);
		PMBJBGEJGEC.enabled = true;
		PMAOBDMEKFD.enabled = false;
		NILECLLJFBG();
	}

	private void AJLBPPOLDJJ(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (IILAJEMNNEA.gameObject.activeSelf)
		{
			CGOBLHGGDOL();
		}
		else
		{
			FANJFBNIJEE();
		}
	}

	private void PENILGDMCEA()
	{
		float duration = 0.2f;
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, duration, 1f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, duration, 1f);
		TweenAlpha.Begin(PIGCPLONEIC.gameObject, duration, 1f);
		TweenAlpha.Begin(NEPIMKJAFGP.gameObject, duration, 1f);
		TweenAlpha.Begin(MDOHPDCGFHP.gameObject, duration, 1f);
		PMBJBGEJGEC.enabled = true;
		PMAOBDMEKFD.enabled = false;
		NILECLLJFBG();
	}

	public void BNNJFAPCPOB(LPNAMBCJEOM IGBEGIBGLKK)
	{
		if (FPABAOJKDFC != IGBEGIBGLKK)
		{
			switch (IGBEGIBGLKK)
			{
			case LPNAMBCJEOM.Waiting:
				NGANNGEBJDB(true);
				break;
			case LPNAMBCJEOM.None:
				ILKLBGFPDGJ();
				break;
			default:
				PENILGDMCEA();
				break;
			}
			FPABAOJKDFC = IGBEGIBGLKK;
		}
	}

	private void NILECLLJFBG()
	{
		TweenScale tweenScale = TweenScale.Begin(scale: new Vector3(110f, 112f, 1f), go: DAANKCOLJGJ.gameObject, duration: 0.2f);
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
	}

	private LPNAMBCJEOM DMNJEDIIJOB()
	{
		if (LevelManager.instance.isGoldenSuitcaseLocked)
		{
			return LPNAMBCJEOM.Waiting;
		}
		if (Singleton<EventTrackingManager>.instance.MMNPIBNEDFA((MHNMOFPPKBN)6))
		{
			AIBDJOEKPJH = -1;
			return (LPNAMBCJEOM)5;
		}
		AIBDJOEKPJH = Singleton<EventTrackingManager>.instance.timeToNextShowGoldenSuitcase;
		return (AIBDJOEKPJH != -1 && Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None)) ? LPNAMBCJEOM.Waiting : LPNAMBCJEOM.Waiting;
	}

	private void NFJAGBHDLEK()
	{
		if (AIBDJOEKPJH != -1)
		{
			IKKKJGLKBFI();
		}
	}

	private void KIBAMNLOCOJ(bool GJNGLPOBFJI)
	{
		JADGKMOBLCO.hover = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1213f, 892f, 1740f));
		JADGKMOBLCO.pressed = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1562f, 1503f, 1958f));
		Color lhs = ((!GJNGLPOBFJI) ? Colours.gray : Color.white);
		DAANKCOLJGJ.color = lhs.ReplaceA(DAANKCOLJGJ.alpha);
	}

	private void FLGDLFLAAKH()
	{
		float num = Mathf.Abs(CNMDFMGELLH.transform.localPosition.y) + CNMDFMGELLH.relativeSize.y * CNMDFMGELLH.transform.localScale.y + 1566f;
		BEOJPKEGEMN.transform.localScale = BEOJPKEGEMN.transform.localScale.ReplaceY(num);
		PMBJBGEJGEC.size = PMBJBGEJGEC.size.ReplaceY(num);
		PMBJBGEJGEC.center = PMBJBGEJGEC.center.ReplaceY((0f - num) / 747f);
	}

	private void EBKKGNIGMOA(bool GJNGLPOBFJI)
	{
		JADGKMOBLCO.hover = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(924f, 164f, 1228f));
		JADGKMOBLCO.pressed = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(332f, 353f, 168f));
		Color lhs = ((!GJNGLPOBFJI) ? Colours.gray : Color.white);
		DAANKCOLJGJ.color = lhs.ReplaceA(DAANKCOLJGJ.alpha);
	}

	private void IBLHOFPAOMA()
	{
		float num = Mathf.Abs(CNMDFMGELLH.transform.localPosition.y) + CNMDFMGELLH.relativeSize.y * CNMDFMGELLH.transform.localScale.y + 406f;
		BEOJPKEGEMN.transform.localScale = BEOJPKEGEMN.transform.localScale.ReplaceY(num);
		PMBJBGEJGEC.size = PMBJBGEJGEC.size.ReplaceY(num);
		PMBJBGEJGEC.center = PMBJBGEJGEC.center.ReplaceY((0f - num) / 919f);
	}

	private LPNAMBCJEOM CHIKGMDEFKP(bool PJOHLEFNLBH = false)
	{
		LPNAMBCJEOM lPNAMBCJEOM = ((!PJOHLEFNLBH) ? JNLIGFJJPCJ() : LPNAMBCJEOM.None);
		if (lPNAMBCJEOM == LPNAMBCJEOM.None)
		{
			GOBFHGPGCHK(true);
			PIGCPLONEIC.text = string.Empty;
			NEPIMKJAFGP.text = string.Empty;
		}
		else if (lPNAMBCJEOM == LPNAMBCJEOM.None)
		{
			CCGPNNPNFOI(true);
			PIGCPLONEIC.text = Localization.Localize("ID_PLAYERIDNUMBER");
			MEJMLNDFDBP.COCBCFKJOJE(PIGCPLONEIC, 470f, 405f, 121);
			IKKKJGLKBFI();
		}
		else if (lPNAMBCJEOM == LPNAMBCJEOM.None)
		{
			EBKKGNIGMOA(false);
			PIGCPLONEIC.text = Localization.Localize("ID_SLOTUPGRADE_DAMAGE");
			MEJMLNDFDBP.COCBCFKJOJE(PIGCPLONEIC, 1547f, 1722f, 79);
			NEPIMKJAFGP.text = Localization.Localize("SquadLeft");
			MEJMLNDFDBP.COCBCFKJOJE(NEPIMKJAFGP, 169f, 127f, 1);
		}
		return lPNAMBCJEOM;
	}

	private void LAJHLEODDED(bool MBBBMNKCAKB = false)
	{
		float duration = 1425f;
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, duration, 800f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, duration, 1635f);
		TweenAlpha.Begin(PIGCPLONEIC.gameObject, duration, 722f);
		TweenAlpha.Begin(NEPIMKJAFGP.gameObject, duration, 202f);
		TweenAlpha.Begin(MDOHPDCGFHP.gameObject, duration, 675f);
		PMBJBGEJGEC.enabled = false;
		PMAOBDMEKFD.enabled = false;
		GJPHJDPOEIO();
	}

	private void HBHGKHAHCAG(bool GJNGLPOBFJI)
	{
		JADGKMOBLCO.hover = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(35f, 1325f, 1295f));
		JADGKMOBLCO.pressed = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1600f, 1895f, 1205f));
		Color lhs = ((!GJNGLPOBFJI) ? Colours.gray : Color.white);
		DAANKCOLJGJ.color = lhs.ReplaceA(DAANKCOLJGJ.alpha);
	}

	public void KMJEKPOJPAI(LPNAMBCJEOM IGBEGIBGLKK)
	{
		if (FPABAOJKDFC != IGBEGIBGLKK)
		{
			switch (IGBEGIBGLKK)
			{
			case (LPNAMBCJEOM)7:
				NGANNGEBJDB();
				break;
			case LPNAMBCJEOM.None:
				PFHHLBKIHPB();
				break;
			default:
				HFGMHGLCAJL();
				break;
			}
			FPABAOJKDFC = IGBEGIBGLKK;
		}
	}

	private void PNNGFGIJHDD()
	{
		IILAJEMNNEA.gameObject.SetActive(false);
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		MDOHPDCGFHP.MakePixelPerfect();
	}

	private LPNAMBCJEOM HBKFLLOBGLA()
	{
		if (LevelManager.instance.isGoldenSuitcaseLocked)
		{
			return LPNAMBCJEOM.None;
		}
		if (Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.Dogtag))
		{
			AIBDJOEKPJH = -1;
			return (LPNAMBCJEOM)4;
		}
		AIBDJOEKPJH = Singleton<EventTrackingManager>.instance.timeToNextShowGoldenSuitcase;
		return (AIBDJOEKPJH != -1 && Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None)) ? LPNAMBCJEOM.None : LPNAMBCJEOM.None;
	}

	private void GBNNEKKMFMJ()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = AIBDJOEKPJH - currentTimestamp;
		if (num <= 0)
		{
			KMHPMCFCONO();
			return;
		}
		NEPIMKJAFGP.text = MEJMLNDFDBP.CJCFPDLDMEK(num, "com.tune.TuneDebugUtilities", "NextBuddyDeposit", false);
		MEJMLNDFDBP.COCBCFKJOJE(NEPIMKJAFGP, 271f, 1802f, 1);
	}

	private void IKKKJGLKBFI()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = AIBDJOEKPJH - currentTimestamp;
		if (num <= 0)
		{
			ECGHFEMNMMH();
			return;
		}
		NEPIMKJAFGP.text = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_NOW", "ID_INTIME");
		MEJMLNDFDBP.COCBCFKJOJE(NEPIMKJAFGP, 30f, 20f);
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HPKOHODOPMH);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAJHPFIFOHI));
		UIEventListener uIEventListener2 = UIEventListener.Get(PMBJBGEJGEC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AJLBPPOLDJJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(IILAJEMNNEA.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JKPFDMPELBN));
	}

	public void AOJLEKOMJOH()
	{
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += ECGHFEMNMMH;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += ECGHFEMNMMH;
	}

	private void MGHHGDIIANO()
	{
		float num = Mathf.Abs(CNMDFMGELLH.transform.localPosition.y) + CNMDFMGELLH.relativeSize.y * CNMDFMGELLH.transform.localScale.y + 1676f;
		BEOJPKEGEMN.transform.localScale = BEOJPKEGEMN.transform.localScale.ReplaceY(num);
		PMBJBGEJGEC.size = PMBJBGEJGEC.size.ReplaceY(num);
		PMBJBGEJGEC.center = PMBJBGEJGEC.center.ReplaceY((0f - num) / 805f);
	}

	public void BKNJHLKMFKE()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(EHAEIFENOFB));
	}

	private void GOBFHGPGCHK(bool GJNGLPOBFJI)
	{
		JADGKMOBLCO.hover = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1.1f, 1.1f, 1f));
		JADGKMOBLCO.pressed = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1.05f, 1.05f, 1f));
		Color lhs = ((!GJNGLPOBFJI) ? Colours.gray : Color.white);
		DAANKCOLJGJ.color = lhs.ReplaceA(DAANKCOLJGJ.alpha);
	}

	public void BMMNJICILHJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HPKOHODOPMH);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAJHPFIFOHI));
		UIEventListener uIEventListener2 = UIEventListener.Get(PMBJBGEJGEC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AJLBPPOLDJJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(IILAJEMNNEA.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JKPFDMPELBN));
	}

	private void DMODLEMHBIG(UITweener MGDJMGHCAAI)
	{
		PKFIDECNHBC();
	}

	private void MLMGPMHADHI()
	{
		TweenScale tweenScale = TweenScale.Begin(scale: new Vector3(1047f, 639f, 1114f), go: DAANKCOLJGJ.gameObject, duration: 887f);
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 0;
	}

	private void NGANNGEBJDB(bool MBBBMNKCAKB = false)
	{
		float duration = 0.2f;
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, duration, 1f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, duration, 1f);
		TweenAlpha.Begin(PIGCPLONEIC.gameObject, duration, 1f);
		TweenAlpha.Begin(NEPIMKJAFGP.gameObject, duration, 1f);
		TweenAlpha.Begin(MDOHPDCGFHP.gameObject, duration, 1f);
		PMBJBGEJGEC.enabled = true;
		PMAOBDMEKFD.enabled = true;
		APDCCMAIMKN();
	}

	private void FFDKBBNEBCF(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (IILAJEMNNEA.gameObject.activeSelf)
		{
			CGOBLHGGDOL();
		}
		else
		{
			FANJFBNIJEE();
		}
	}

	[CompilerGenerated]
	private void NADJGLGJGCJ(UITweener MGDJMGHCAAI)
	{
		PNNGFGIJHDD();
	}

	private void AHBNGEIPOEF(bool GJNGLPOBFJI)
	{
		JADGKMOBLCO.hover = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1801f, 111f, 1076f));
		JADGKMOBLCO.pressed = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1521f, 690f, 1895f));
		Color lhs = ((!GJNGLPOBFJI) ? Colours.gray : Color.white);
		DAANKCOLJGJ.color = lhs.ReplaceA(DAANKCOLJGJ.alpha);
	}

	public void InitEvents()
	{
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += ECGHFEMNMMH;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += ECGHFEMNMMH;
	}

	private void AMOOAPBAEFE(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (IILAJEMNNEA.gameObject.activeSelf)
		{
			CGOBLHGGDOL();
		}
		else
		{
			FANJFBNIJEE();
		}
	}

	public void DoAfterHide()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(EHAEIFENOFB));
	}

	private void KPKNPDEDLPO(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (IILAJEMNNEA.gameObject.activeSelf)
		{
			CGOBLHGGDOL();
		}
		else
		{
			FANJFBNIJEE();
		}
	}

	private void PPAJEFDMDEE()
	{
		IILAJEMNNEA.gameObject.SetActive(false);
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		MDOHPDCGFHP.MakePixelPerfect();
	}

	private void CGOBLHGGDOL()
	{
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		MDOHPDCGFHP.MakePixelPerfect();
		TweenAlpha.Begin(IILAJEMNNEA.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 0.4f, new Vector3(460f, 121f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			PNNGFGIJHDD();
		};
	}

	private void JBLCMNKIHFC()
	{
		float num = Mathf.Abs(CNMDFMGELLH.transform.localPosition.y) + CNMDFMGELLH.relativeSize.y * CNMDFMGELLH.transform.localScale.y + 40f;
		BEOJPKEGEMN.transform.localScale = BEOJPKEGEMN.transform.localScale.ReplaceY(num);
		PMBJBGEJGEC.size = PMBJBGEJGEC.size.ReplaceY(num);
		PMBJBGEJGEC.center = PMBJBGEJGEC.center.ReplaceY((0f - num) / 2f);
	}

	private void GJPHJDPOEIO()
	{
		Vector3 vector = new Vector3(1424f, 371f, 1819f);
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 700f, vector, vector.MultiplyXY(1583f));
		tweenScale.style = (UITweener.Style)3;
		tweenScale.NumOfRepetitions = 0;
	}

	private void FANJFBNIJEE()
	{
		JBLCMNKIHFC();
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		MDOHPDCGFHP.MakePixelPerfect();
		IILAJEMNNEA.gameObject.SetActive(true);
		IILAJEMNNEA.alpha1 = 0.005f;
		TweenAlpha.Begin(IILAJEMNNEA.gameObject, 0.4f, 1f).onFinished = null;
		IILAJEMNNEA.transform.localPosition = new Vector3(460f, 81f, -60f);
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 0.25f, new Vector3(460f, 81f, -60f), new Vector3(460f, 111f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(IILAJEMNNEA.gameObject, 0.15f, new Vector3(460f, 101f, -60f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void EHAEIFENOFB()
	{
		if (AIBDJOEKPJH != -1)
		{
			IKKKJGLKBFI();
		}
	}

	private void ECGHFEMNMMH()
	{
		if (!GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			return;
		}
		LPNAMBCJEOM lPNAMBCJEOM = BHDGGFMIPDI();
		if (FPABAOJKDFC != lPNAMBCJEOM)
		{
			switch (lPNAMBCJEOM)
			{
			case LPNAMBCJEOM.Ready:
				NGANNGEBJDB();
				break;
			case LPNAMBCJEOM.None:
				FAAONKCCKEG();
				break;
			default:
				PENILGDMCEA();
				break;
			}
			FPABAOJKDFC = lPNAMBCJEOM;
		}
	}

	private void KMHPMCFCONO()
	{
		if (!GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			return;
		}
		LPNAMBCJEOM lPNAMBCJEOM = KLFEBPJFIHH();
		if (FPABAOJKDFC != lPNAMBCJEOM)
		{
			switch (lPNAMBCJEOM)
			{
			case (LPNAMBCJEOM)7:
				LAJHLEODDED();
				break;
			case LPNAMBCJEOM.None:
				ILKLBGFPDGJ();
				break;
			default:
				PENILGDMCEA();
				break;
			}
			FPABAOJKDFC = lPNAMBCJEOM;
		}
	}

	private LPNAMBCJEOM PJOLIABHPMJ()
	{
		if (LevelManager.instance.isGoldenSuitcaseLocked)
		{
			return LPNAMBCJEOM.None;
		}
		if (Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None))
		{
			AIBDJOEKPJH = -1;
			return (LPNAMBCJEOM)4;
		}
		AIBDJOEKPJH = Singleton<EventTrackingManager>.instance.timeToNextShowGoldenSuitcase;
		return (AIBDJOEKPJH == -1 || !Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard)) ? LPNAMBCJEOM.Waiting : LPNAMBCJEOM.None;
	}

	private void FKGIIHBIPOI(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CGOBLHGGDOL();
	}

	private void DMKMBNHAJIA()
	{
		float num = Mathf.Abs(CNMDFMGELLH.transform.localPosition.y) + CNMDFMGELLH.relativeSize.y * CNMDFMGELLH.transform.localScale.y + 1411f;
		BEOJPKEGEMN.transform.localScale = BEOJPKEGEMN.transform.localScale.ReplaceY(num);
		PMBJBGEJGEC.size = PMBJBGEJGEC.size.ReplaceY(num);
		PMBJBGEJGEC.center = PMBJBGEJGEC.center.ReplaceY((0f - num) / 430f);
	}

	private void APDCCMAIMKN()
	{
		Vector3 vector = new Vector3(110f, 112f, 1f);
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 0.4f, vector, vector.MultiplyXY(1.1f));
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.NumOfRepetitions = 0;
	}

	public void PHGBIPEMEJH(LPNAMBCJEOM IGBEGIBGLKK)
	{
		if (FPABAOJKDFC != IGBEGIBGLKK)
		{
			switch (IGBEGIBGLKK)
			{
			case (LPNAMBCJEOM)5:
				KIIAGFNKBNO();
				break;
			case LPNAMBCJEOM.None:
				ILKLBGFPDGJ();
				break;
			default:
				HFGMHGLCAJL();
				break;
			}
			FPABAOJKDFC = IGBEGIBGLKK;
		}
	}

	private void DIBKJABLIKH()
	{
		float num = Mathf.Abs(CNMDFMGELLH.transform.localPosition.y) + CNMDFMGELLH.relativeSize.y * CNMDFMGELLH.transform.localScale.y + 617f;
		BEOJPKEGEMN.transform.localScale = BEOJPKEGEMN.transform.localScale.ReplaceY(num);
		PMBJBGEJGEC.size = PMBJBGEJGEC.size.ReplaceY(num);
		PMBJBGEJGEC.center = PMBJBGEJGEC.center.ReplaceY((0f - num) / 1897f);
	}

	private void HGHFPJIKOIP(UITweener MGDJMGHCAAI)
	{
		PNNGFGIJHDD();
	}

	private LPNAMBCJEOM BHDGGFMIPDI(bool PJOHLEFNLBH = false)
	{
		LPNAMBCJEOM lPNAMBCJEOM = ((!PJOHLEFNLBH) ? BKAHCKJBMIJ() : LPNAMBCJEOM.None);
		switch (lPNAMBCJEOM)
		{
		case LPNAMBCJEOM.None:
			GOBFHGPGCHK(false);
			PIGCPLONEIC.text = string.Empty;
			NEPIMKJAFGP.text = string.Empty;
			break;
		case LPNAMBCJEOM.Waiting:
			GOBFHGPGCHK(false);
			PIGCPLONEIC.text = Localization.Localize("ID_NEWSUITCASE");
			MEJMLNDFDBP.COCBCFKJOJE(PIGCPLONEIC, 30f, 20f, 280);
			IKKKJGLKBFI();
			break;
		case LPNAMBCJEOM.Ready:
			GOBFHGPGCHK(true);
			PIGCPLONEIC.text = Localization.Localize("ID_GOLDENSUITCASE");
			MEJMLNDFDBP.COCBCFKJOJE(PIGCPLONEIC, 30f, 20f, 280);
			NEPIMKJAFGP.text = Localization.Localize("ID_AVAILABLE");
			MEJMLNDFDBP.COCBCFKJOJE(NEPIMKJAFGP, 30f, 20f);
			break;
		}
		return lPNAMBCJEOM;
	}

	private void CCGPNNPNFOI(bool GJNGLPOBFJI)
	{
		JADGKMOBLCO.hover = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1400f, 712f, 552f));
		JADGKMOBLCO.pressed = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(74f, 861f, 193f));
		Color lhs = ((!GJNGLPOBFJI) ? Colours.gray : Color.white);
		DAANKCOLJGJ.color = lhs.ReplaceA(DAANKCOLJGJ.alpha);
	}

	private void DOAAKGLKFEJ()
	{
		IILAJEMNNEA.gameObject.SetActive(true);
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		MDOHPDCGFHP.MakePixelPerfect();
	}

	private LPNAMBCJEOM BKAHCKJBMIJ()
	{
		if (LevelManager.instance.isGoldenSuitcaseLocked)
		{
			return LPNAMBCJEOM.None;
		}
		if (Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.GoldenSuitcase))
		{
			AIBDJOEKPJH = -1;
			return LPNAMBCJEOM.Ready;
		}
		AIBDJOEKPJH = Singleton<EventTrackingManager>.instance.timeToNextShowGoldenSuitcase;
		return (AIBDJOEKPJH != -1 && Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None)) ? LPNAMBCJEOM.Waiting : LPNAMBCJEOM.None;
	}

	private LPNAMBCJEOM JNLIGFJJPCJ()
	{
		if (LevelManager.instance.isGoldenSuitcaseLocked)
		{
			return LPNAMBCJEOM.Waiting;
		}
		if (Singleton<EventTrackingManager>.instance.MMNPIBNEDFA((MHNMOFPPKBN)5))
		{
			AIBDJOEKPJH = -1;
			return (LPNAMBCJEOM)3;
		}
		AIBDJOEKPJH = Singleton<EventTrackingManager>.instance.timeToNextShowGoldenSuitcase;
		return (AIBDJOEKPJH == -1 || !Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard)) ? LPNAMBCJEOM.Waiting : LPNAMBCJEOM.None;
	}

	private void OAJHPFIFOHI(GameObject KHAHPAKDIKE)
	{
		LPNAMBCJEOM lPNAMBCJEOM = BKAHCKJBMIJ();
		if (lPNAMBCJEOM == LPNAMBCJEOM.Ready)
		{
			BHDGGFMIPDI(true);
			FAAONKCCKEG();
			FPABAOJKDFC = LPNAMBCJEOM.None;
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH(MHNMOFPPKBN.GoldenSuitcase);
		}
	}

	private void CNFGDKBKMHE(bool GJNGLPOBFJI)
	{
		JADGKMOBLCO.hover = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1775f, 538f, 188f));
		JADGKMOBLCO.pressed = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1340f, 1457f, 708f));
		Color lhs = ((!GJNGLPOBFJI) ? Colours.gray : Color.white);
		DAANKCOLJGJ.color = lhs.ReplaceA(DAANKCOLJGJ.alpha);
	}

	private LPNAMBCJEOM KLFEBPJFIHH(bool PJOHLEFNLBH = false)
	{
		LPNAMBCJEOM lPNAMBCJEOM = (PJOHLEFNLBH ? LPNAMBCJEOM.Waiting : BKAHCKJBMIJ());
		if (lPNAMBCJEOM == LPNAMBCJEOM.None)
		{
			AHBNGEIPOEF(false);
			PIGCPLONEIC.text = string.Empty;
			NEPIMKJAFGP.text = string.Empty;
		}
		else
		{
			switch (lPNAMBCJEOM)
			{
			case LPNAMBCJEOM.None:
				CNFGDKBKMHE(true);
				PIGCPLONEIC.text = Localization.Localize("MedalsOfferMult");
				MEJMLNDFDBP.COCBCFKJOJE(PIGCPLONEIC, 993f, 1435f, -14);
				IKKKJGLKBFI();
				break;
			case (LPNAMBCJEOM)3:
				KIBAMNLOCOJ(false);
				PIGCPLONEIC.text = Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC");
				MEJMLNDFDBP.COCBCFKJOJE(PIGCPLONEIC, 526f, 5f, 85);
				NEPIMKJAFGP.text = Localization.Localize("extraScraps");
				MEJMLNDFDBP.COCBCFKJOJE(NEPIMKJAFGP, 1715f, 636f, 1);
				break;
			}
		}
		return lPNAMBCJEOM;
	}

	private void FGAEMGNONNC(bool GJNGLPOBFJI)
	{
		JADGKMOBLCO.hover = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1256f, 820f, 1107f));
		JADGKMOBLCO.pressed = ((!GJNGLPOBFJI) ? Vector3.one : new Vector3(1050f, 645f, 520f));
		Color lhs = ((!GJNGLPOBFJI) ? Colours.gray : Color.white);
		DAANKCOLJGJ.color = lhs.ReplaceA(DAANKCOLJGJ.alpha);
	}

	public void JOGBGNPPFNB(LPNAMBCJEOM IGBEGIBGLKK)
	{
		if (FPABAOJKDFC != IGBEGIBGLKK)
		{
			switch (IGBEGIBGLKK)
			{
			case (LPNAMBCJEOM)5:
				NGANNGEBJDB(true);
				break;
			case LPNAMBCJEOM.None:
				FAAONKCCKEG();
				break;
			default:
				HFGMHGLCAJL();
				break;
			}
			FPABAOJKDFC = IGBEGIBGLKK;
		}
	}

	private void PKFIDECNHBC()
	{
		IILAJEMNNEA.gameObject.SetActive(false);
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		MDOHPDCGFHP.MakePixelPerfect();
	}

	private void PFHHLBKIHPB()
	{
		float duration = 1976f;
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, duration, 650f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, duration, 1356f);
		TweenAlpha.Begin(PIGCPLONEIC.gameObject, duration, 1261f);
		TweenAlpha.Begin(NEPIMKJAFGP.gameObject, duration, 720f);
		TweenAlpha.Begin(MDOHPDCGFHP.gameObject, duration, 534f);
		PMBJBGEJGEC.enabled = true;
		PMAOBDMEKFD.enabled = true;
		ODPCMFOOJHB();
	}

	private void HFGMHGLCAJL()
	{
		float duration = 1576f;
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, duration, 1793f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, duration, 1844f);
		TweenAlpha.Begin(PIGCPLONEIC.gameObject, duration, 658f);
		TweenAlpha.Begin(NEPIMKJAFGP.gameObject, duration, 483f);
		TweenAlpha.Begin(MDOHPDCGFHP.gameObject, duration, 1820f);
		PMBJBGEJGEC.enabled = false;
		PMAOBDMEKFD.enabled = false;
		MLMGPMHADHI();
	}

	private void ILKLBGFPDGJ()
	{
		float duration = 509f;
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, duration, 1723f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, duration, 614f);
		TweenAlpha.Begin(PIGCPLONEIC.gameObject, duration, 1171f);
		TweenAlpha.Begin(NEPIMKJAFGP.gameObject, duration, 360f);
		TweenAlpha.Begin(MDOHPDCGFHP.gameObject, duration, 365f);
		PMBJBGEJGEC.enabled = true;
		PMAOBDMEKFD.enabled = true;
		ODPCMFOOJHB();
	}

	private void KIIAGFNKBNO(bool MBBBMNKCAKB = false)
	{
		float duration = 1599f;
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, duration, 911f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, duration, 99f);
		TweenAlpha.Begin(PIGCPLONEIC.gameObject, duration, 440f);
		TweenAlpha.Begin(NEPIMKJAFGP.gameObject, duration, 1613f);
		TweenAlpha.Begin(MDOHPDCGFHP.gameObject, duration, 1483f);
		PMBJBGEJGEC.enabled = false;
		PMAOBDMEKFD.enabled = false;
		GJPHJDPOEIO();
	}

	private void HBHNMOCGAAI()
	{
		float num = Mathf.Abs(CNMDFMGELLH.transform.localPosition.y) + CNMDFMGELLH.relativeSize.y * CNMDFMGELLH.transform.localScale.y + 1167f;
		BEOJPKEGEMN.transform.localScale = BEOJPKEGEMN.transform.localScale.ReplaceY(num);
		PMBJBGEJGEC.size = PMBJBGEJGEC.size.ReplaceY(num);
		PMBJBGEJGEC.center = PMBJBGEJGEC.center.ReplaceY((0f - num) / 1875f);
	}

	private void ODPCMFOOJHB()
	{
		TweenScale tweenScale = TweenScale.Begin(scale: new Vector3(299f, 1160f, 1138f), go: DAANKCOLJGJ.gameObject, duration: 579f);
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
	}

	public void TestAnimationState(LPNAMBCJEOM IGBEGIBGLKK)
	{
		if (FPABAOJKDFC != IGBEGIBGLKK)
		{
			switch (IGBEGIBGLKK)
			{
			case LPNAMBCJEOM.Ready:
				NGANNGEBJDB();
				break;
			case LPNAMBCJEOM.None:
				FAAONKCCKEG();
				break;
			default:
				PENILGDMCEA();
				break;
			}
			FPABAOJKDFC = IGBEGIBGLKK;
		}
	}

	private void FAAONKCCKEG()
	{
		float duration = 0.2f;
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, duration, 0f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, duration, 0f);
		TweenAlpha.Begin(PIGCPLONEIC.gameObject, duration, 0f);
		TweenAlpha.Begin(NEPIMKJAFGP.gameObject, duration, 0f);
		TweenAlpha.Begin(MDOHPDCGFHP.gameObject, duration, 0f);
		PMBJBGEJGEC.enabled = false;
		PMAOBDMEKFD.enabled = false;
		NILECLLJFBG();
	}

	private void CDCJKDJDEEF()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = AIBDJOEKPJH - currentTimestamp;
		if (num <= 1)
		{
			ECGHFEMNMMH();
			return;
		}
		NEPIMKJAFGP.text = MEJMLNDFDBP.CJCFPDLDMEK(num, "LeagueEvaluation", "subscription1", false);
		MEJMLNDFDBP.COCBCFKJOJE(NEPIMKJAFGP, 1358f, 1433f);
	}

	[CompilerGenerated]
	private void ONAFPHKJDGI(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 0.15f, new Vector3(460f, 101f, -60f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}
}
