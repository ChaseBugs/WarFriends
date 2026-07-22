using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(UIPanel))]
public abstract class GuiScreen : SwitchableGui
{
	public enum MNICBHKMMBN
	{
		None,
		Normal,
		League,
		Arena,
		Event
	}

	[FormerlySerializedAs("HJAGKLIEJDI")]
	public bool LBKOJGLHAKI = true;

	public MNICBHKMMBN LNLNFBAHOBH;

	[FormerlySerializedAs("OGEKKJKIIFG")]
	public bool DDFHHMBLHPI;

	[FormerlySerializedAs("EDCBJNBDDIG")]
	public bool DLJHPBBKIBD;

	[FormerlySerializedAs("HAJOFLFGMEH")]
	public bool MBINJMOJOBG;

	public Background.NKHJBLBAAEB GNBPNIJDCJK;

	[FormerlySerializedAs("LAPEIEHDOON")]
	public bool MKKCEBLJADC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action NIDKGMFOGKA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action GENFBHPKJPE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action KDHIDOCCIBD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action FKJKCLPIIHM;

	public static Action LHMKJNFDMCM;

	private bool GAOGMKKNGAG = true;

	public virtual bool dialogsEnabled => MKKCEBLJADC;

	public bool showHeaderPart => LNLNFBAHOBH == MNICBHKMMBN.Normal || LNLNFBAHOBH == MNICBHKMMBN.League || LNLNFBAHOBH == MNICBHKMMBN.Arena || LNLNFBAHOBH == MNICBHKMMBN.Event;

	public bool showHeaderLeaguePart => LNLNFBAHOBH == MNICBHKMMBN.League;

	public bool showHeaderDogtagPart => LNLNFBAHOBH == MNICBHKMMBN.Normal || LNLNFBAHOBH == MNICBHKMMBN.League || LNLNFBAHOBH == MNICBHKMMBN.Event;

	public bool showHeaderTicketPart => LNLNFBAHOBH == MNICBHKMMBN.Arena;

	public bool showHeaderEventPart => LNLNFBAHOBH == MNICBHKMMBN.Event;

	public event Action BeforeShowUp
	{
		add
		{
			Action action = NIDKGMFOGKA;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NIDKGMFOGKA, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = NIDKGMFOGKA;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NIDKGMFOGKA, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action AfterShowUp
	{
		add
		{
			Action action = GENFBHPKJPE;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref GENFBHPKJPE, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = GENFBHPKJPE;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref GENFBHPKJPE, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action BeforeHide
	{
		add
		{
			Action action = KDHIDOCCIBD;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KDHIDOCCIBD, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = KDHIDOCCIBD;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KDHIDOCCIBD, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action AfterHide
	{
		add
		{
			Action action = FKJKCLPIIHM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FKJKCLPIIHM, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = FKJKCLPIIHM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FKJKCLPIIHM, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public virtual void OnDestroy()
	{
		LHMKJNFDMCM = null;
		NIDKGMFOGKA = null;
		GENFBHPKJPE = null;
		KDHIDOCCIBD = null;
		FKJKCLPIIHM = null;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (GAOGMKKNGAG)
		{
			GuiElement[] componentsInChildren = GetComponentsInChildren<GuiElement>(includeInactive: true);
			foreach (GuiElement guiElement in componentsInChildren)
			{
				guiElement.guiScreen = this;
			}
			try
			{
				AGIKPOLCGNF();
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogError($"OBJECT: {base.gameObject.name}\nERROR: {ex.Message}\nSTACKTRACE: {ex.StackTrace}");
				if (DebugSettings.debugEnabled)
				{
					WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_GUIERROR"), 0f, null, string.Empty, JCOGJEEFLBC: true);
				}
				AnalyticsHelper.LogHandledException(ex);
			}
			GAOGMKKNGAG = false;
		}
		try
		{
			InitGUIValues();
		}
		catch (Exception ex2)
		{
			UnityEngine.Debug.LogError($"OBJECT: {base.gameObject.name}\nERROR: {ex2.Message}\nSTACKTRACE: {ex2.StackTrace}");
			if (DebugSettings.debugEnabled)
			{
				WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_GUIERROR"), 0f, null, string.Empty, JCOGJEEFLBC: true);
			}
			AnalyticsHelper.LogHandledException(ex2);
		}
	}

	public override void AnimateShow(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		GuiScreen guiScreen = base.previousScreenForElementsToHide;
		GuiElementSingle<Background>.instance.ShowVariant(GNBPNIJDCJK);
		if (guiScreen == null)
		{
			if (DDFHHMBLHPI || DLJHPBBKIBD)
			{
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<ChatGuiElement>.instance);
			}
			if (showHeaderPart)
			{
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<MenuHeader>.instance);
			}
			if (showHeaderLeaguePart)
			{
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<HeaderLeagueButton>.instance);
			}
			if (showHeaderDogtagPart)
			{
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<HeaderDogtagButton>.instance);
			}
			if (showHeaderTicketPart)
			{
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<HeaderTicketsButton>.instance);
			}
			if (showHeaderEventPart)
			{
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<HeaderEventButton>.instance);
			}
			if (MBINJMOJOBG)
			{
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<Background>.instance);
			}
			if (!MBINJMOJOBG)
			{
				Singleton<GuiManager>.instance.FadeOut(GuiElementSingle<Background>.instance);
			}
		}
		else
		{
			FGAFPBJCHCI((!MBINJMOJOBG) ? null : GuiElementSingle<Background>.instance, (!guiScreen.MBINJMOJOBG) ? null : GuiElementSingle<Background>.instance);
			FGAFPBJCHCI((!DDFHHMBLHPI && !DLJHPBBKIBD) ? null : GuiElementSingle<ChatGuiElement>.instance, (!guiScreen.DDFHHMBLHPI && !guiScreen.DLJHPBBKIBD) ? null : GuiElementSingle<ChatGuiElement>.instance);
			FGAFPBJCHCI((!showHeaderPart) ? null : GuiElementSingle<MenuHeader>.instance, (!guiScreen.showHeaderPart) ? null : GuiElementSingle<MenuHeader>.instance);
			FGAFPBJCHCI((!showHeaderLeaguePart) ? null : GuiElementSingle<HeaderLeagueButton>.instance, (!guiScreen.showHeaderLeaguePart) ? null : GuiElementSingle<HeaderLeagueButton>.instance);
			FGAFPBJCHCI((!showHeaderDogtagPart) ? null : GuiElementSingle<HeaderDogtagButton>.instance, (!guiScreen.showHeaderDogtagPart) ? null : GuiElementSingle<HeaderDogtagButton>.instance);
			FGAFPBJCHCI((!showHeaderTicketPart) ? null : GuiElementSingle<HeaderTicketsButton>.instance, (!guiScreen.showHeaderTicketPart) ? null : GuiElementSingle<HeaderTicketsButton>.instance);
			FGAFPBJCHCI((!showHeaderEventPart) ? null : GuiElementSingle<HeaderEventButton>.instance, (!guiScreen.showHeaderEventPart) ? null : GuiElementSingle<HeaderEventButton>.instance);
		}
		GuiElementSingle<ChatGuiElement>.instance.ShowContent(DDFHHMBLHPI, DLJHPBBKIBD);
	}

	private void FGAFPBJCHCI(GuiElement JNCCBNDOFAJ, GuiElement EPGPAPILKLO)
	{
		if (JNCCBNDOFAJ != null)
		{
			if (EPGPAPILKLO == null || !JNCCBNDOFAJ.isShowed)
			{
				Singleton<GuiManager>.instance.FadeIn(JNCCBNDOFAJ);
			}
			else if (EPGPAPILKLO != JNCCBNDOFAJ)
			{
				EPGPAPILKLO.DoBeforeHide();
				EPGPAPILKLO.AnimateHide(EAKEFLLCHCJ: true);
				Singleton<GuiManager>.instance.FadeIn(JNCCBNDOFAJ);
				UnityEngine.Debug.Log("Show: " + JNCCBNDOFAJ.name);
			}
		}
		else if (EPGPAPILKLO != null)
		{
			EPGPAPILKLO.DoBeforeHide();
			EPGPAPILKLO.AnimateHide(EAKEFLLCHCJ: true);
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if (LBKOJGLHAKI)
		{
			Singleton<GuiManager>.instance.ShowOverlay();
		}
		else
		{
			Singleton<GuiManager>.instance.HideOverlay();
		}
		if (LHMKJNFDMCM != null)
		{
			LHMKJNFDMCM();
		}
		if (NIDKGMFOGKA != null)
		{
			NIDKGMFOGKA();
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		Singleton<GuiManager>.instance.TurnOnInput();
		if (MKKCEBLJADC)
		{
			Singleton<MessageManager>.instance.StartMessageCoroutine();
		}
		if (GENFBHPKJPE != null)
		{
			GENFBHPKJPE();
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (MKKCEBLJADC)
		{
			Singleton<MessageManager>.instance.StopMessageCoroutine();
		}
		if (KDHIDOCCIBD != null)
		{
			KDHIDOCCIBD();
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		Singleton<GuiManager>.instance.TurnOnInput();
		if (FKJKCLPIIHM != null)
		{
			FKJKCLPIIHM();
		}
	}

	protected abstract void AGIKPOLCGNF();

	public abstract void InitGUIValues();

	protected virtual void FixedUpdate()
	{
	}
}
