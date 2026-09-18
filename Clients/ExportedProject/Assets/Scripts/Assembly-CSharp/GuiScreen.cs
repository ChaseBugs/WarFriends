using System;
using UnityEngine;

[RequireComponent(typeof(UIPanel))]
public abstract class GuiScreen : SwitchableGui
{
	public enum HeaderType
	{
		None,
		Normal,
		League,
		Arena
	}

	public bool UseOverlay = true;

	public HeaderType headerType;

	public bool showChat;

	public bool showActiveUnits;

	public bool showBackground;

	public Background.Type backgroundType;

	public bool showDialogs;

	public static Action ChangingScreen;

	private bool mFirstEnable = true;

	public virtual bool dialogsEnabled => showDialogs;

	public bool showHeaderPart => headerType == HeaderType.Normal || headerType == HeaderType.League || headerType == HeaderType.Arena;

	public bool showHeaderLeaguePart => headerType == HeaderType.League;

	public bool showHeaderDogtagPart => headerType == HeaderType.Normal || headerType == HeaderType.League;

	public bool showHeaderTicketPart => headerType == HeaderType.Arena;

	public event Action BeforeShowUp;

	public event Action AfterShowUp;

	public event Action BeforeHide;

	public event Action AfterHide;

	public virtual void OnDestroy()
	{
		ChangingScreen = null;
		this.BeforeShowUp = null;
		this.AfterShowUp = null;
		this.BeforeHide = null;
		this.AfterHide = null;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (mFirstEnable)
		{
			GuiElement[] componentsInChildren = GetComponentsInChildren<GuiElement>(includeInactive: true);
			foreach (GuiElement guiElement in componentsInChildren)
			{
				guiElement.guiScreen = this;
			}
			try
			{
				InitControls();
			}
			catch (Exception ex)
			{
				Debug.LogError($"OBJECT: {base.gameObject.name}\nERROR: {ex.Message}\nSTACKTRACE: {ex.StackTrace}");
				if (DebugSettings.debugEnabled)
				{
					WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_GUIERROR"), 0f, null, string.Empty, useDialogBackground: true);
				}
				Crittercism.LogHandledException(ex);
			}
			mFirstEnable = false;
		}
		try
		{
			InitGUIValues();
		}
		catch (Exception ex2)
		{
			Debug.LogError($"OBJECT: {base.gameObject.name}\nERROR: {ex2.Message}\nSTACKTRACE: {ex2.StackTrace}");
			if (DebugSettings.debugEnabled)
			{
				WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_GUIERROR"), 0f, null, string.Empty, useDialogBackground: true);
			}
			Crittercism.LogHandledException(ex2);
		}
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		GuiScreen guiScreen = base.previousScreenForElementsToHide;
		GuiElementSingle<Background>.instance.ShowVariant(backgroundType);
		if (guiScreen == null)
		{
			if (showChat || showActiveUnits)
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
			if (showBackground)
			{
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<Background>.instance);
			}
			if (!showBackground)
			{
				Singleton<GuiManager>.instance.FadeOut(GuiElementSingle<Background>.instance);
			}
		}
		else
		{
			AnimateShowElement((!showBackground) ? null : GuiElementSingle<Background>.instance, (!guiScreen.showBackground) ? null : GuiElementSingle<Background>.instance);
			AnimateShowElement((!showChat && !showActiveUnits) ? null : GuiElementSingle<ChatGuiElement>.instance, (!guiScreen.showChat && !guiScreen.showActiveUnits) ? null : GuiElementSingle<ChatGuiElement>.instance);
			AnimateShowElement((!showHeaderPart) ? null : GuiElementSingle<MenuHeader>.instance, (!guiScreen.showHeaderPart) ? null : GuiElementSingle<MenuHeader>.instance);
			AnimateShowElement((!showHeaderLeaguePart) ? null : GuiElementSingle<HeaderLeagueButton>.instance, (!guiScreen.showHeaderLeaguePart) ? null : GuiElementSingle<HeaderLeagueButton>.instance);
			AnimateShowElement((!showHeaderDogtagPart) ? null : GuiElementSingle<HeaderDogtagButton>.instance, (!guiScreen.showHeaderDogtagPart) ? null : GuiElementSingle<HeaderDogtagButton>.instance);
			AnimateShowElement((!showHeaderTicketPart) ? null : GuiElementSingle<HeaderTicketsButton>.instance, (!guiScreen.showHeaderTicketPart) ? null : GuiElementSingle<HeaderTicketsButton>.instance);
		}
		GuiElementSingle<ChatGuiElement>.instance.ShowContent(showChat, showActiveUnits);
	}

	private void AnimateShowElement(GuiElement element, GuiElement prevScreenElement)
	{
		if (element != null)
		{
			if (prevScreenElement == null || !element.isShowed)
			{
				Singleton<GuiManager>.instance.FadeIn(element);
			}
			else if (prevScreenElement != element)
			{
				prevScreenElement.DoBeforeHide();
				prevScreenElement.AnimateHide(forceFadeOut: true);
				Singleton<GuiManager>.instance.FadeIn(element);
				Debug.Log("Show: " + element.name);
			}
		}
		else if (prevScreenElement != null)
		{
			prevScreenElement.DoBeforeHide();
			prevScreenElement.AnimateHide(forceFadeOut: true);
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if (UseOverlay)
		{
			Singleton<GuiManager>.instance.ShowOverlay();
		}
		else
		{
			Singleton<GuiManager>.instance.HideOverlay();
		}
		if (ChangingScreen != null)
		{
			ChangingScreen();
		}
		if (this.BeforeShowUp != null)
		{
			this.BeforeShowUp();
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		Singleton<GuiManager>.instance.TurnOnInput();
		if (showDialogs)
		{
			Singleton<MessageManager>.instance.StartMessageCoroutine();
		}
		if (this.AfterShowUp != null)
		{
			this.AfterShowUp();
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (showDialogs)
		{
			Singleton<MessageManager>.instance.StopMessageCoroutine();
		}
		if (this.BeforeHide != null)
		{
			this.BeforeHide();
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		Singleton<GuiManager>.instance.TurnOnInput();
		if (this.AfterHide != null)
		{
			this.AfterHide();
		}
	}

	protected abstract void InitControls();

	public abstract void InitGUIValues();

	protected virtual void FixedUpdate()
	{
	}
}
