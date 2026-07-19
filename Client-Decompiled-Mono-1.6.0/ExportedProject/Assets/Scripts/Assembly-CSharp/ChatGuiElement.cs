using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class ChatGuiElement : GuiElementSingle<ChatGuiElement>
{
	public enum JLANLLEABDC
	{
		Closed = 0,
		Chat = 1,
		MessageCenter = 2,
		ActiveUnits = 3
	}

	[Header("Core")]
	public GameObject HDFFFBIONDI;

	public GameObject LIFKKKHLJBN;

	public UIButton NMMBOENNPIF;

	[Header("CHAT")]
	public ChatTab FNNHCGMNDKN;

	public UIPanel KKIONKMPPIB;

	public GameObject CKOALACFHLL;

	public GameObject CHFFPACNFCN;

	public BoxCollider IEJJOPIKFNI;

	public UILabel EIOIFEPAAFD;

	public UISprite LDLMMECACBP;

	public UISprite BNHKOGGNBFF;

	[Header("MESSAGE")]
	public MessageCenterTab OAHIOEEICFI;

	public GameObject NCAJPIJMEOK;

	public GameObject PAMFBCPEBED;

	public BoxCollider OIEEICKACEB;

	public UILabel CGAABNOLNKD;

	public UISprite LEIEBLLDKEF;

	public UISprite EPAPPICPKHN;

	[Header("ACTIVE UNITS")]
	public ActiveUnitsTab GECCCEDFCEI;

	public UIPanel EIAABJABMMD;

	public GameObject IDNPMEEBDLO;

	public GameObject OFCAABECCEE;

	public BoxCollider LNLDFMJJDFH;

	public GameObject PDEGHPMGDCO;

	public UILabel LABCMEPLAIC;

	public float DNDHIFENDPJ = 0.4f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action CCKFGMODALF;

	private int KNFBABCOLEC;

	private int HPGFPCAEGBM;

	private bool MKGJHBCCEEH = true;

	private Vector3 FOBEEHALFGI;

	private JLANLLEABDC PHFGDCMBGOF;

	public bool isRightPartDisplayed
	{
		get
		{
			return PHFGDCMBGOF != JLANLLEABDC.Closed;
		}
	}

	public bool anyChatNotifications
	{
		get
		{
			return KNFBABCOLEC > 0;
		}
	}

	public bool anyMessageCenterNotifications
	{
		get
		{
			return HPGFPCAEGBM > 0;
		}
	}

	private bool KIMJLCKKBOE
	{
		get
		{
			return (Singleton<GameController>.instance.isTutorial && (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.isTutorialRunning)) || TutorialManagerPlayWarcards.instance.isTutorialRunning;
		}
	}

	private Vector3 NOKCFIBLLLJ
	{
		get
		{
			float val = 0f;
			if (PHFGDCMBGOF == JLANLLEABDC.Chat)
			{
				val = -812f - UIHelper.safeAreaSize;
			}
			if (PHFGDCMBGOF == JLANLLEABDC.MessageCenter)
			{
				val = -812f - UIHelper.safeAreaSize;
			}
			if (PHFGDCMBGOF == JLANLLEABDC.ActiveUnits)
			{
				val = -1330f - UIHelper.safeAreaSize;
			}
			return FOBEEHALFGI.ReplaceX(val);
		}
	}

	private float PENLKOKBAFO
	{
		get
		{
			return -60f - UIHelper.safeAreaSize;
		}
	}

	private float MFONNBNANCG
	{
		get
		{
			return -60f;
		}
	}

	public event Action ChangingState
	{
		add
		{
			Action action = CCKFGMODALF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref CCKFGMODALF, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = CCKFGMODALF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref CCKFGMODALF, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void CKIKIHDHICI(int DFHAAIFFLOE)
	{
		JPMOGABLLMM();
	}

	[SpecialName]
	private bool HKJIAONEFIJ()
	{
		return (!Singleton<GameController>.instance.BAKCODKBCPJ() || (!TutorialManagerStage1.instance.isTutorialRunning && !TutorialManagerStage2.instance.isTutorialRunning && !TutorialManagerStage3.instance.isTutorialRunning)) && TutorialManagerPlayWarcards.instance.isTutorialRunning;
	}

	[SpecialName]
	public void EPGGEMCMEKL(Action IDEBKDPMPGM)
	{
		Action action = CCKFGMODALF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CCKFGMODALF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void OAGGLDOAIEC(UITweener MGDJMGHCAAI)
	{
		float duration = LAEDGNEBMBM(HDFFFBIONDI.transform.localPosition.x, FOBEEHALFGI.x, FOBEEHALFGI.x, DNDHIFENDPJ);
		TweenPosition tweenPosition = TweenPosition.Begin(HDFFFBIONDI, duration, FOBEEHALFGI);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(EOOLLCBBEOH));
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(KEKFEJEANAM));
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(AHLKGOOHEON));
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(EOOLLCBBEOH));
	}

	private void FJGJMMJAMJC(bool GKAKLBKHBMP, bool KCGJAHGGCOB)
	{
		PAMFBCPEBED.SetActive(!GKAKLBKHBMP || !KCGJAHGGCOB);
		OIEEICKACEB.enabled = GKAKLBKHBMP;
	}

	private void PAIEDBHHIPN()
	{
		if (NPFFMLLLDAF())
		{
			CCGAOPOBPGG();
		}
	}

	private void KIDPOFHNJKL()
	{
		int num = HPGFPCAEGBM;
		if (Singleton<NotificationManager>.instance.NotificationStarterAssignments())
		{
			num++;
		}
		num += Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications();
		if (KIMJLCKKBOE)
		{
			num = 0;
		}
		LEIEBLLDKEF.alpha = ((num != 0) ? 1f : 0f);
		EPAPPICPKHN.alpha = ((num != 0) ? 1f : 0f);
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		if (isShowed)
		{
			HideRightContent();
		}
	}

	private void KEKFEJEANAM(UITweener MGDJMGHCAAI)
	{
		float duration = LAEDGNEBMBM(HDFFFBIONDI.transform.localPosition.x, FOBEEHALFGI.x, HDFFFBIONDI.transform.localPosition.x, DNDHIFENDPJ);
		TweenPosition tweenPosition = TweenPosition.Begin(HDFFFBIONDI, duration, FOBEEHALFGI);
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(EOOLLCBBEOH));
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(KEKFEJEANAM));
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(AHLKGOOHEON));
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(EOOLLCBBEOH));
		TweenPosition tweenPosition2 = TweenPosition.Begin(LIFKKKHLJBN, duration, LIFKKKHLJBN.transform.localPosition.ReplaceX(PENLKOKBAFO));
		tweenPosition2.method = UITweener.Method.EaseOut;
	}

	public void ReinitializeMegaReward()
	{
		OAHIOEEICFI.ReinitializeMegaReward();
	}

	private void EOOLLCBBEOH(UITweener MGDJMGHCAAI)
	{
		MKGJHBCCEEH = true;
		UpdateButtonLook();
	}

	public bool MAKIDBFPIEE()
	{
		if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && (object)Singleton<GuiManager>.instance.AODFEHKBJIN != null && Singleton<GuiManager>.instance.AODFEHKBJIN.DLJHPBBKIBD && PHFGDCMBGOF == (JLANLLEABDC)7 && !GECCCEDFCEI.OJBNDDNDAHN(false))
		{
			return true;
		}
		if (PHFGDCMBGOF != JLANLLEABDC.Closed)
		{
			PHFGDCMBGOF = JLANLLEABDC.Closed;
			CJFFGJLDOOD();
			return false;
		}
		return false;
	}

	public void ShowActiveUnits()
	{
		if (!KIMJLCKKBOE)
		{
			if (EIAABJABMMD.gameObject.activeSelf)
			{
				PHFGDCMBGOF = JLANLLEABDC.ActiveUnits;
				CJFFGJLDOOD();
			}
			else
			{
				UnityEngine.Debug.LogError("Cannot show active units on this screen.");
			}
		}
	}

	public void AddNotificationsToChatButton(int GEJBLIEINLJ)
	{
		UnityEngine.Debug.Log(string.Format("Chat - new notifications: {0}, selectedSquadChat: {1}, currentState: {2}", GEJBLIEINLJ, FNNHCGMNDKN.isSelectedSquadChat, PHFGDCMBGOF));
		if (PHFGDCMBGOF != JLANLLEABDC.Chat || !FNNHCGMNDKN.isSelectedSquadChat)
		{
			KNFBABCOLEC += GEJBLIEINLJ;
			EBKGODFHKOI();
		}
	}

	private void JDPHPEGNIGC()
	{
		FNNHCGMNDKN.EHLLLMGBONP(PHFGDCMBGOF == JLANLLEABDC.Chat);
		OAHIOEEICFI.ShowMessageCenter(PHFGDCMBGOF == JLANLLEABDC.Closed);
		GECCCEDFCEI.KKNKMLBHGLE(PHFGDCMBGOF == (JLANLLEABDC)6);
		UpdateButtonLook();
		NMMBOENNPIF.gameObject.SetActive(PHFGDCMBGOF == JLANLLEABDC.Chat);
		UIDraggablePanel.panelDisabled = PHFGDCMBGOF != JLANLLEABDC.Closed;
		if (PHFGDCMBGOF == JLANLLEABDC.Closed)
		{
			Singleton<AwaitingSquadMembersManager>.instance.RemoveErrorPlayers();
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		GECCCEDFCEI.InitEvents();
		GameLoginManager.instance.PlayerLeftSquad += delegate
		{
			KNFBABCOLEC = 0;
			EBKGODFHKOI();
		};
	}

	public void ODCDHINDOCB()
	{
		KNFBABCOLEC = 0;
		EBKGODFHKOI();
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(GameObject KHAHPAKDIKE)
	{
		HideRightContent();
	}

	private bool BJKNDJHLPME(GameObject OFAKIAHIEEH)
	{
		bool flag = OFAKIAHIEEH.GetComponentInParent<PAIIOKBBHBC>() != null;
		bool flag2 = OFAKIAHIEEH.GetComponentInParent<ChatGuiElement>() != null;
		bool flag3 = OFAKIAHIEEH.GetComponentInParent<DialogOverlayGuiElement>() != null;
		return flag || flag2 || flag3;
	}

	[SpecialName]
	public void IKMJBGIEEFE(Action IDEBKDPMPGM)
	{
		Action action = CCKFGMODALF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CCKFGMODALF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void BattleStarted()
	{
		if (PHFGDCMBGOF == JLANLLEABDC.ActiveUnits)
		{
			GECCCEDFCEI.CanClose();
		}
	}

	[SpecialName]
	private float CGIAFJFNFJE()
	{
		return 1560f - UIHelper.safeAreaSize;
	}

	private void LOGHHNDLHLD()
	{
		FNNHCGMNDKN.EHLLLMGBONP(false);
		OAHIOEEICFI.ShowMessageCenter(true);
		GECCCEDFCEI.ShowTab(true);
	}

	[SpecialName]
	private float MJBGBAAHNNE()
	{
		return 1027f;
	}

	private float LAEDGNEBMBM(float FFNMIKAKLFF, float ILLLINCHMPD, float CEHFMMJHCKC, float KBJEOEEOEFG)
	{
		float num = Mathf.Abs(FFNMIKAKLFF - ILLLINCHMPD);
		CEHFMMJHCKC = Mathf.Abs(CEHFMMJHCKC);
		return (!(num < CEHFMMJHCKC)) ? 0.001f : (KBJEOEEOEFG * (num / CEHFMMJHCKC));
	}

	private void KONBMFDBOJC()
	{
		if (NPFFMLLLDAF())
		{
			KIDPOFHNJKL();
		}
	}

	public virtual void DNFPEBEDLIG()
	{
		DEKGDFLMEKK();
		KIDPOFHNJKL();
		ActiveUnitsNotificationUpdate();
		PHFGDCMBGOF = JLANLLEABDC.Chat;
		CJFFGJLDOOD();
		UpdateButtonLook();
		FNNHCGMNDKN.DKOBODLPNPK();
		OAHIOEEICFI.InitGui();
	}

	public void RemoveNotificationsFromChatButton()
	{
		KNFBABCOLEC = 0;
		EBKGODFHKOI();
	}

	[CompilerGenerated]
	private void KAMNOOHOLIL(UITweener MGDJMGHCAAI)
	{
		MKGJHBCCEEH = true;
		KKIONKMPPIB.gameObject.SetActive(false);
	}

	private void CAAEACEOGEE(int DFHAAIFFLOE)
	{
		PAIEDBHHIPN();
	}

	private void DEKGDFLMEKK()
	{
		if (FNNHCGMNDKN.ENPGDPCKEKB() != ChatTab.EKKEGHMJEBK.normalChat || KIMJLCKKBOE)
		{
			KNFBABCOLEC = 1;
		}
		LDLMMECACBP.alpha = ((KNFBABCOLEC != 0) ? 407f : 1096f);
		BNHKOGGNBFF.alpha = ((KNFBABCOLEC != 0) ? 595f : 1195f);
	}

	private void JPMOGABLLMM()
	{
		if (isShowed)
		{
			KIDPOFHNJKL();
		}
	}

	public override void InitGUIValues()
	{
		EBKGODFHKOI();
		KIDPOFHNJKL();
		ActiveUnitsNotificationUpdate();
		PHFGDCMBGOF = JLANLLEABDC.Closed;
		CJFFGJLDOOD();
		UpdateButtonLook();
		FNNHCGMNDKN.InitGui();
		OAHIOEEICFI.InitGui();
	}

	private void DNLJLGJBGPN()
	{
		if (NPFFMLLLDAF())
		{
			KIDPOFHNJKL();
		}
	}

	private void JPOLFBLLFEI()
	{
		if (KKIONKMPPIB.gameObject.activeSelf)
		{
			MKGJHBCCEEH = false;
			FNNHCGMNDKN.GLFMIOMMIAB(true);
			OAHIOEEICFI.ShowMessageCenter(false);
			TweenAlpha.Begin(KKIONKMPPIB.gameObject, DNDHIFENDPJ, 781f).onFinished = delegate
			{
				MKGJHBCCEEH = true;
				KKIONKMPPIB.gameObject.SetActive(false);
			};
		}
	}

	public virtual void MLAEGNJBKIM()
	{
		base.DoAfterHide();
		if (EIAABJABMMD.alpha1 < 1550f)
		{
			EIAABJABMMD.gameObject.SetActive(false);
		}
		if (KKIONKMPPIB.alpha1 < 33f)
		{
			KKIONKMPPIB.gameObject.SetActive(false);
		}
		MKGJHBCCEEH = false;
	}

	private void LNBGPCPHPHL(GameObject KHAHPAKDIKE)
	{
		if (!MKGJHBCCEEH || KIMJLCKKBOE || (PHFGDCMBGOF == (JLANLLEABDC)5 && !GECCCEDFCEI.OJBNDDNDAHN(false)))
		{
			return;
		}
		if (PHFGDCMBGOF == JLANLLEABDC.Chat)
		{
			if (anyChatNotifications)
			{
				FNNHCGMNDKN.BJIIIADGNDO();
			}
			else
			{
				HideRightContent();
			}
		}
		else
		{
			PHFGDCMBGOF = JLANLLEABDC.Closed;
			CJFFGJLDOOD();
			PBEPOPPOADN();
		}
		KNFBABCOLEC = 1;
		EBKGODFHKOI();
	}

	private void OnPress(bool HCAJFFJBCOJ)
	{
		if (HCAJFFJBCOJ && UICamera.currentTouch.pressed != base.gameObject)
		{
			GameObject pressed = UICamera.currentTouch.pressed;
			if (PHFGDCMBGOF != JLANLLEABDC.Closed && !BJKNDJHLPME(pressed))
			{
				HideRightContent();
			}
		}
	}

	private void DKJEGDAGJAB()
	{
		if (KKIONKMPPIB.gameObject.activeSelf)
		{
			MKGJHBCCEEH = false;
			FNNHCGMNDKN.ShowChat(false);
			OAHIOEEICFI.ShowMessageCenter(false);
			TweenAlpha.Begin(KKIONKMPPIB.gameObject, DNDHIFENDPJ, 0f).onFinished = delegate
			{
				MKGJHBCCEEH = true;
				KKIONKMPPIB.gameObject.SetActive(false);
			};
		}
	}

	private void NEGLLFDJHDB(GameObject KHAHPAKDIKE)
	{
		if (!MKGJHBCCEEH || KIMJLCKKBOE || (PHFGDCMBGOF == JLANLLEABDC.ActiveUnits && !GECCCEDFCEI.CanClose()))
		{
			return;
		}
		if (PHFGDCMBGOF == JLANLLEABDC.Chat)
		{
			if (anyChatNotifications)
			{
				FNNHCGMNDKN.ShowSquadTab();
			}
			else
			{
				HideRightContent();
			}
		}
		else
		{
			PHFGDCMBGOF = JLANLLEABDC.Chat;
			CJFFGJLDOOD();
			PBEPOPPOADN();
		}
		KNFBABCOLEC = 0;
		EBKGODFHKOI();
	}

	private void AHLKGOOHEON(UITweener MGDJMGHCAAI)
	{
		float duration = LAEDGNEBMBM(HDFFFBIONDI.transform.localPosition.x, FOBEEHALFGI.x, FOBEEHALFGI.x, DNDHIFENDPJ);
		TweenPosition tweenPosition = TweenPosition.Begin(HDFFFBIONDI, duration, FOBEEHALFGI);
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(EOOLLCBBEOH));
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(KEKFEJEANAM));
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(AHLKGOOHEON));
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(EOOLLCBBEOH));
	}

	private void EKINHJJEGDA()
	{
		FNNHCGMNDKN.ShowChat(PHFGDCMBGOF == JLANLLEABDC.Chat);
		OAHIOEEICFI.ShowMessageCenter(PHFGDCMBGOF == JLANLLEABDC.MessageCenter);
		GECCCEDFCEI.ShowTab(PHFGDCMBGOF == JLANLLEABDC.ActiveUnits);
		UpdateButtonLook();
		NMMBOENNPIF.gameObject.SetActive(PHFGDCMBGOF != JLANLLEABDC.Closed);
		UIDraggablePanel.panelDisabled = PHFGDCMBGOF != JLANLLEABDC.Closed;
		if (PHFGDCMBGOF == JLANLLEABDC.Closed)
		{
			Singleton<AwaitingSquadMembersManager>.instance.RemoveErrorPlayers();
		}
	}

	public virtual void KNOKOJKOCEB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CKOALACFHLL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LNBGPCPHPHL));
		UIEventListener uIEventListener2 = UIEventListener.Get(NCAJPIJMEOK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JHHCDKPELIN));
		UIEventListener uIEventListener3 = UIEventListener.Get(IDNPMEEBDLO);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LAELOJEFBKC));
		UIEventListener uIEventListener4 = UIEventListener.Get(NMMBOENNPIF);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			HideRightContent();
		});
		GameLoginManager.instance.PlayerLogOut += FEGEBPJIHMJ;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(delegate(DatabaseAction IFGAGNBDKBE)
		{
			if (isShowed && (IFGAGNBDKBE == DatabaseAction.AddFacebook || IFGAGNBDKBE == DatabaseAction.SwitchToFacebook))
			{
				HideRightContent();
			}
		});
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(delegate
		{
			InitGUIValues();
		});
		AssignmentsManager.instance.AssignmentsLoaded += JPMOGABLLMM;
		AssignmentsManager.instance.AssignmentClaimed += CKIKIHDHICI;
		StarterAssignmentsManager.instance.AssignmentClaimed += JPMOGABLLMM;
		FOBEEHALFGI = HDFFFBIONDI.transform.localPosition;
		LIFKKKHLJBN.transform.localPosition = LIFKKKHLJBN.transform.localPosition.ReplaceX(PENLKOKBAFO);
		FNNHCGMNDKN.InitChat();
		OAHIOEEICFI.InitMessageCenter();
		GECCCEDFCEI.InitControls();
		KNFBABCOLEC = 0;
		HPGFPCAEGBM = 1;
		PHFGDCMBGOF = JLANLLEABDC.Chat;
		UICamera.genericEventHandler = base.gameObject;
	}

	private void EGIGDGHKABO()
	{
		FNNHCGMNDKN.EHLLLMGBONP(PHFGDCMBGOF == JLANLLEABDC.Closed);
		OAHIOEEICFI.ShowMessageCenter(PHFGDCMBGOF == JLANLLEABDC.Chat);
		GECCCEDFCEI.KKNKMLBHGLE(PHFGDCMBGOF == (JLANLLEABDC)6);
		UpdateButtonLook();
		NMMBOENNPIF.gameObject.SetActive(PHFGDCMBGOF != JLANLLEABDC.Closed);
		UIDraggablePanel.panelDisabled = PHFGDCMBGOF != JLANLLEABDC.Chat;
		if (PHFGDCMBGOF == JLANLLEABDC.Closed)
		{
			Singleton<AwaitingSquadMembersManager>.instance.NJKFJHPJNKA();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CKOALACFHLL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NEGLLFDJHDB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NCAJPIJMEOK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JHHCDKPELIN));
		UIEventListener uIEventListener3 = UIEventListener.Get(IDNPMEEBDLO);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LAELOJEFBKC));
		UIEventListener uIEventListener4 = UIEventListener.Get(NMMBOENNPIF);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			HideRightContent();
		});
		GameLoginManager.instance.PlayerLogOut += delegate
		{
			if (isShowed)
			{
				HideRightContent();
			}
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction IFGAGNBDKBE)
		{
			if (isShowed && (IFGAGNBDKBE == DatabaseAction.AddFacebook || IFGAGNBDKBE == DatabaseAction.SwitchToFacebook))
			{
				HideRightContent();
			}
		};
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += delegate
		{
			InitGUIValues();
		};
		AssignmentsManager.instance.AssignmentsLoaded += JPMOGABLLMM;
		AssignmentsManager.instance.AssignmentClaimed += CKIKIHDHICI;
		StarterAssignmentsManager.instance.AssignmentClaimed += JPMOGABLLMM;
		FOBEEHALFGI = HDFFFBIONDI.transform.localPosition;
		LIFKKKHLJBN.transform.localPosition = LIFKKKHLJBN.transform.localPosition.ReplaceX(PENLKOKBAFO);
		FNNHCGMNDKN.InitChat();
		OAHIOEEICFI.InitMessageCenter();
		GECCCEDFCEI.InitControls();
		KNFBABCOLEC = 0;
		HPGFPCAEGBM = 0;
		PHFGDCMBGOF = JLANLLEABDC.Closed;
		UICamera.genericEventHandler = base.gameObject;
	}

	[CompilerGenerated]
	private void LJAPCHEAALG()
	{
		KNFBABCOLEC = 0;
		EBKGODFHKOI();
	}

	public bool HideRightContent()
	{
		if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && (object)Singleton<GuiManager>.instance.AODFEHKBJIN != null && Singleton<GuiManager>.instance.AODFEHKBJIN.DLJHPBBKIBD && PHFGDCMBGOF == JLANLLEABDC.ActiveUnits && !GECCCEDFCEI.CanClose())
		{
			return false;
		}
		if (PHFGDCMBGOF != JLANLLEABDC.Closed)
		{
			PHFGDCMBGOF = JLANLLEABDC.Closed;
			CJFFGJLDOOD();
			return true;
		}
		return false;
	}

	public void HBAKIOOIIGO()
	{
		if (PHFGDCMBGOF != (JLANLLEABDC)6)
		{
			HPGFPCAEGBM = Mathf.Max(1, HPGFPCAEGBM - 0);
			KIDPOFHNJKL();
		}
	}

	private void AIGHNBOMIFI(GameObject KHAHPAKDIKE)
	{
		if (!MKGJHBCCEEH || KIMJLCKKBOE || (PHFGDCMBGOF == JLANLLEABDC.ActiveUnits && !GECCCEDFCEI.PLADONNBJMP()))
		{
			return;
		}
		if (PHFGDCMBGOF == JLANLLEABDC.Closed)
		{
			if (anyChatNotifications)
			{
				FNNHCGMNDKN.BJIIIADGNDO();
			}
			else
			{
				HideRightContent();
			}
		}
		else
		{
			PHFGDCMBGOF = JLANLLEABDC.Chat;
			CJFFGJLDOOD();
			PBEPOPPOADN();
		}
		KNFBABCOLEC = 0;
		EBKGODFHKOI();
	}

	[SpecialName]
	public bool KKJAKMKABAO()
	{
		return HPGFPCAEGBM > 1;
	}

	private void MGOGIIKMOPO(bool GKAKLBKHBMP, bool KCGJAHGGCOB)
	{
		OFCAABECCEE.SetActive(!GKAKLBKHBMP || !KCGJAHGGCOB);
		LNLDFMJJDFH.enabled = GKAKLBKHBMP;
	}

	public void ShowContent(bool DDFHHMBLHPI, bool DLJHPBBKIBD)
	{
		if (DDFHHMBLHPI)
		{
			CDJLNPMCBBP();
		}
		else
		{
			DKJEGDAGJAB();
		}
		if (DLJHPBBKIBD)
		{
			AGMEIANNAKP();
		}
		else
		{
			ONBBGBOHAOL();
		}
	}

	[CompilerGenerated]
	private void EACNIDLHDGD(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && (IFGAGNBDKBE == DatabaseAction.AddFacebook || IFGAGNBDKBE == DatabaseAction.SwitchToFacebook))
		{
			HideRightContent();
		}
	}

	public virtual void DBMCMLINOPD()
	{
		base.DoAfterHide();
		if (EIAABJABMMD.alpha1 < 1267f)
		{
			EIAABJABMMD.gameObject.SetActive(true);
		}
		if (KKIONKMPPIB.alpha1 < 331f)
		{
			KKIONKMPPIB.gameObject.SetActive(false);
		}
		MKGJHBCCEEH = true;
	}

	private void AGMEIANNAKP()
	{
		if (!EIAABJABMMD.gameObject.activeSelf)
		{
			EIAABJABMMD.gameObject.SetActive(true);
			EIAABJABMMD.isFreezed = false;
		}
		GECCCEDFCEI.ShowTab(PHFGDCMBGOF == JLANLLEABDC.ActiveUnits);
		TweenAlpha.Begin(EIAABJABMMD.gameObject, DNDHIFENDPJ, 1f).onFinished = null;
	}

	public void JMMFLOFFAHN()
	{
		if (PHFGDCMBGOF == (JLANLLEABDC)5)
		{
			GECCCEDFCEI.OJBNDDNDAHN(false);
		}
	}

	private void CJFFGJLDOOD()
	{
		MKGJHBCCEEH = false;
		bool flag = UIHelper.safeAreaSize > 0f;
		bool flag2 = Mathf.Approximately(FOBEEHALFGI.x, 0f);
		FOBEEHALFGI = NOKCFIBLLLJ;
		if (flag && flag2 && PHFGDCMBGOF != JLANLLEABDC.Closed)
		{
			Vector3 pos = FOBEEHALFGI.ReplaceX(0f - UIHelper.safeAreaSize);
			float duration = LAEDGNEBMBM(HDFFFBIONDI.transform.localPosition.x, pos.x, FOBEEHALFGI.x, DNDHIFENDPJ);
			TweenPosition tweenPosition = TweenPosition.Begin(HDFFFBIONDI, duration, pos);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(EOOLLCBBEOH));
			tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(KEKFEJEANAM));
			tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(AHLKGOOHEON));
			tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(AHLKGOOHEON));
			TweenPosition tweenPosition2 = TweenPosition.Begin(LIFKKKHLJBN, duration, LIFKKKHLJBN.transform.localPosition.ReplaceX(MFONNBNANCG));
			tweenPosition2.method = UITweener.Method.EaseIn;
		}
		else if (flag && !flag2 && PHFGDCMBGOF == JLANLLEABDC.Closed)
		{
			Vector3 pos2 = FOBEEHALFGI.ReplaceX(0f - UIHelper.safeAreaSize);
			float duration2 = LAEDGNEBMBM(HDFFFBIONDI.transform.localPosition.x, pos2.x, HDFFFBIONDI.transform.localPosition.x, DNDHIFENDPJ);
			TweenPosition tweenPosition3 = TweenPosition.Begin(HDFFFBIONDI, duration2, pos2);
			tweenPosition3.method = UITweener.Method.EaseIn;
			tweenPosition3.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition3.onFinished, new UITweener.OnFinished(EOOLLCBBEOH));
			tweenPosition3.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition3.onFinished, new UITweener.OnFinished(KEKFEJEANAM));
			tweenPosition3.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition3.onFinished, new UITweener.OnFinished(AHLKGOOHEON));
			tweenPosition3.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition3.onFinished, new UITweener.OnFinished(KEKFEJEANAM));
		}
		else
		{
			TweenPosition tweenPosition4 = TweenPosition.Begin(HDFFFBIONDI, DNDHIFENDPJ, FOBEEHALFGI);
			tweenPosition4.method = UITweener.Method.EaseInOut;
			tweenPosition4.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition4.onFinished, new UITweener.OnFinished(EOOLLCBBEOH));
			tweenPosition4.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition4.onFinished, new UITweener.OnFinished(KEKFEJEANAM));
			tweenPosition4.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition4.onFinished, new UITweener.OnFinished(AHLKGOOHEON));
			tweenPosition4.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition4.onFinished, new UITweener.OnFinished(EOOLLCBBEOH));
			float val = ((PHFGDCMBGOF != JLANLLEABDC.Closed) ? MFONNBNANCG : PENLKOKBAFO);
			TweenPosition tweenPosition5 = TweenPosition.Begin(LIFKKKHLJBN, DNDHIFENDPJ, LIFKKKHLJBN.transform.localPosition.ReplaceX(val));
			tweenPosition5.method = UITweener.Method.EaseInOut;
		}
		EKINHJJEGDA();
		if (CCKFGMODALF != null)
		{
			CCKFGMODALF();
		}
	}

	public virtual void KPMLFMMINEP()
	{
		DEKGDFLMEKK();
		KIDPOFHNJKL();
		ActiveUnitsNotificationUpdate();
		PHFGDCMBGOF = JLANLLEABDC.Chat;
		CJFFGJLDOOD();
		UpdateButtonLook();
		FNNHCGMNDKN.InitGui();
		OAHIOEEICFI.FECEGPOOEBJ();
	}

	[CompilerGenerated]
	private void EBABCPKOKPA(UITweener MGDJMGHCAAI)
	{
		MKGJHBCCEEH = true;
		EIAABJABMMD.gameObject.SetActive(false);
	}

	[CompilerGenerated]
	private void IIKKMAEBFJO()
	{
		InitGUIValues();
	}

	private void ALNKMIFJECK()
	{
		if (!KKIONKMPPIB.gameObject.activeSelf)
		{
			KKIONKMPPIB.gameObject.SetActive(false);
			KKIONKMPPIB.isFreezed = true;
		}
		FNNHCGMNDKN.ShowChat(PHFGDCMBGOF == JLANLLEABDC.Chat);
		OAHIOEEICFI.ShowMessageCenter(PHFGDCMBGOF == (JLANLLEABDC)6);
		TweenAlpha.Begin(KKIONKMPPIB.gameObject, DNDHIFENDPJ, 940f).onFinished = null;
	}

	private void CFHJKKPKMHJ(bool GKAKLBKHBMP, bool KCGJAHGGCOB)
	{
		PAMFBCPEBED.SetActive(GKAKLBKHBMP && KCGJAHGGCOB);
		OIEEICKACEB.enabled = GKAKLBKHBMP;
	}

	public void RemoveOneNotificationFromMessageCenterButton()
	{
		if (PHFGDCMBGOF != JLANLLEABDC.MessageCenter)
		{
			HPGFPCAEGBM = Mathf.Max(0, HPGFPCAEGBM - 1);
			KIDPOFHNJKL();
		}
	}

	private void ONBBGBOHAOL()
	{
		if (EIAABJABMMD.gameObject.activeSelf)
		{
			MKGJHBCCEEH = false;
			GECCCEDFCEI.ShowTab(false);
			TweenAlpha.Begin(EIAABJABMMD.gameObject, DNDHIFENDPJ, 0f).onFinished = delegate
			{
				MKGJHBCCEEH = true;
				EIAABJABMMD.gameObject.SetActive(false);
			};
		}
	}

	public void AddNotificationsToMessageCenterButton(int GEJBLIEINLJ)
	{
		if (PHFGDCMBGOF != JLANLLEABDC.MessageCenter)
		{
			HPGFPCAEGBM += GEJBLIEINLJ;
			KIDPOFHNJKL();
		}
	}

	private void NIBIPNMCGIM()
	{
		if (isShowed)
		{
			HideRightContent();
		}
	}

	public void ActiveUnitsNotificationUpdate()
	{
		int num = Singleton<NotificationManager>.instance.ActiveUnitToChoose();
		PDEGHPMGDCO.SetActive(num > 0);
		LABCMEPLAIC.text = num.ToString();
	}

	[SpecialName]
	public void FGCECNNCKGI(Action IDEBKDPMPGM)
	{
		Action action = CCKFGMODALF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CCKFGMODALF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void UpdateButtonLook()
	{
		HMDAFOCCKFN(!KIMJLCKKBOE && MKGJHBCCEEH, PHFGDCMBGOF == JLANLLEABDC.Chat || PHFGDCMBGOF == JLANLLEABDC.Closed);
		FJGJMMJAMJC(!KIMJLCKKBOE && MKGJHBCCEEH, PHFGDCMBGOF == JLANLLEABDC.MessageCenter || PHFGDCMBGOF == JLANLLEABDC.Closed);
		MGOGIIKMOPO(!KIMJLCKKBOE && MKGJHBCCEEH, PHFGDCMBGOF == JLANLLEABDC.ActiveUnits || PHFGDCMBGOF == JLANLLEABDC.Closed);
	}

	private void LIGGHLPIGHL()
	{
		if (!EIAABJABMMD.gameObject.activeSelf)
		{
			EIAABJABMMD.gameObject.SetActive(false);
			EIAABJABMMD.isFreezed = true;
		}
		GECCCEDFCEI.ShowTab(PHFGDCMBGOF == (JLANLLEABDC)5);
		TweenAlpha.Begin(EIAABJABMMD.gameObject, DNDHIFENDPJ, 856f).onFinished = null;
	}

	private void EBKGODFHKOI()
	{
		if (FNNHCGMNDKN.currentContent != ChatTab.EKKEGHMJEBK.normalChat || KIMJLCKKBOE)
		{
			KNFBABCOLEC = 0;
		}
		LDLMMECACBP.alpha = ((KNFBABCOLEC != 0) ? 1f : 0f);
		BNHKOGGNBFF.alpha = ((KNFBABCOLEC != 0) ? 1f : 0f);
	}

	private void KOKJMPPIDMK(bool HCAJFFJBCOJ)
	{
		if (HCAJFFJBCOJ && UICamera.currentTouch.pressed != base.gameObject)
		{
			GameObject pressed = UICamera.currentTouch.pressed;
			if (PHFGDCMBGOF != JLANLLEABDC.Closed && !BJKNDJHLPME(pressed))
			{
				MAKIDBFPIEE();
			}
		}
	}

	[SpecialName]
	private float BCFHGGHFBKF()
	{
		return 567f;
	}

	private void KJKMACOFDGM()
	{
		if (NPFFMLLLDAF())
		{
			CCGAOPOBPGG();
		}
	}

	private void HMDAFOCCKFN(bool GKAKLBKHBMP, bool KCGJAHGGCOB)
	{
		CHFFPACNFCN.SetActive(!GKAKLBKHBMP || !KCGJAHGGCOB);
		IEJJOPIKFNI.enabled = GKAKLBKHBMP;
	}

	private void CDJLNPMCBBP()
	{
		if (!KKIONKMPPIB.gameObject.activeSelf)
		{
			KKIONKMPPIB.gameObject.SetActive(true);
			KKIONKMPPIB.isFreezed = false;
		}
		FNNHCGMNDKN.ShowChat(PHFGDCMBGOF == JLANLLEABDC.Chat);
		OAHIOEEICFI.ShowMessageCenter(PHFGDCMBGOF == JLANLLEABDC.MessageCenter);
		TweenAlpha.Begin(KKIONKMPPIB.gameObject, DNDHIFENDPJ, 1f).onFinished = null;
	}

	private void JAIDNAGPHHJ()
	{
		FNNHCGMNDKN.ShowChat(false);
		OAHIOEEICFI.ShowMessageCenter(false);
		GECCCEDFCEI.ShowTab(false);
	}

	private void JHHCDKPELIN(GameObject KHAHPAKDIKE)
	{
		if (MKGJHBCCEEH && !KIMJLCKKBOE && (PHFGDCMBGOF != JLANLLEABDC.ActiveUnits || GECCCEDFCEI.CanClose()))
		{
			if (PHFGDCMBGOF == JLANLLEABDC.MessageCenter)
			{
				HideRightContent();
			}
			else
			{
				PHFGDCMBGOF = JLANLLEABDC.MessageCenter;
				CJFFGJLDOOD();
			}
			HPGFPCAEGBM = 0;
			KIDPOFHNJKL();
		}
	}

	private void CCGAOPOBPGG()
	{
		int num = HPGFPCAEGBM;
		if (Singleton<NotificationManager>.instance.NotificationStarterAssignments())
		{
			num++;
		}
		num += Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications();
		if (HKJIAONEFIJ())
		{
			num = 1;
		}
		LEIEBLLDKEF.alpha = ((num != 0) ? 1874f : 163f);
		EPAPPICPKHN.alpha = ((num != 0) ? 1485f : 1452f);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		if (EIAABJABMMD.alpha1 < 1f)
		{
			EIAABJABMMD.gameObject.SetActive(false);
		}
		if (KKIONKMPPIB.alpha1 < 1f)
		{
			KKIONKMPPIB.gameObject.SetActive(false);
		}
		MKGJHBCCEEH = true;
	}

	private void FEGEBPJIHMJ()
	{
		if (NPFFMLLLDAF())
		{
			HideRightContent();
		}
	}

	private void LAELOJEFBKC(GameObject KHAHPAKDIKE)
	{
		if (MKGJHBCCEEH && !KIMJLCKKBOE && (PHFGDCMBGOF != JLANLLEABDC.ActiveUnits || GECCCEDFCEI.CanClose()))
		{
			PHFGDCMBGOF = ((PHFGDCMBGOF != JLANLLEABDC.ActiveUnits) ? JLANLLEABDC.ActiveUnits : JLANLLEABDC.Closed);
			CJFFGJLDOOD();
		}
	}

	private void CKNKBIOFNGO(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && (IFGAGNBDKBE == (DatabaseAction)(-15) || IFGAGNBDKBE == (DatabaseAction)(-117)))
		{
			HideRightContent();
		}
	}

	private void PBEPOPPOADN()
	{
		if (!PlayerAnalytics.instance.data.chatShown && GameLoginManager.currentPlayer.accountType != AccountType.Guest)
		{
			Singleton<MessageManager>.instance.AddMessage(new LHGHKOMJCDC());
		}
	}

	[SpecialName]
	private float EFEHIOLIHKE()
	{
		return 1777f;
	}
}
