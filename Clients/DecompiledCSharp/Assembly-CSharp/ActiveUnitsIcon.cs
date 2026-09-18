using UnityEngine;

public class ActiveUnitsIcon : Core_BaseScript
{
	[Header("Core")]
	public BoxCollider boxCollider;

	public UISprite background;

	public UISprite highlight;

	public UISprite unitIcon;

	public UIPanel panel;

	public UISprite mechanicalIcon;

	public UISprite lockedIcon;

	public GameObject rentedPart;

	public UISprite[] tierIcons;

	[Header("Army Power Animation")]
	public ArmyPowerAnimation armyPowerAnimation;

	private LevelBehaviour mUnit;

	private ActiveUnitsManager.ActiveUnitState mState;

	private Vector3 mHighlightOriginalScale = new Vector3(188f, 142f, 1f);

	private Vector3 mHighlightBigScale = new Vector3(225.6f, 170.40001f, 1f);

	public LevelBehaviour unit => mUnit;

	public ActiveUnitsManager.ActiveUnitState state => mState;

	public void Initialize(LevelBehaviour unit)
	{
		mUnit = unit;
		unitIcon.spriteName = unit.upgradeSlots.iconName;
		unitIcon.MakePixelPerfect();
		unitIcon.transform.localScale = unitIcon.transform.localScale.MultiplyXY(0.5f);
		mechanicalIcon.gameObject.SetActive(!unit.isSoldier);
		UpdateTiers();
	}

	public void SetMechanical(bool canBeChoosed)
	{
		bool flag = mState == ActiveUnitsManager.ActiveUnitState.Selected || mState == ActiveUnitsManager.ActiveUnitState.Deselecting || canBeChoosed;
		mechanicalIcon.color = ((!flag) ? Color.red : Color.white);
	}

	public void UpdateState()
	{
		SetState(Singleton<ActiveUnitsManager>.instance.GetState(mUnit, inMenu: true));
	}

	public void UpdateTiers()
	{
		for (int i = 0; i < tierIcons.Length; i++)
		{
			tierIcons[i].gameObject.SetActive(i < mUnit.upgradeSlots.actualTier);
		}
	}

	public void Show()
	{
		panel.alpha1 = 0.005f;
		TweenAlpha.Begin(panel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 1f);
	}

	public void Hide()
	{
		TweenAlpha.Begin(panel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0f);
	}

	private void SetState(ActiveUnitsManager.ActiveUnitState state)
	{
		if (mState != ActiveUnitsManager.ActiveUnitState.Deselecting && state == ActiveUnitsManager.ActiveUnitState.Deselecting)
		{
			StartPulse();
		}
		if (state == ActiveUnitsManager.ActiveUnitState.Selectable)
		{
			StartPulse();
		}
		if (mState == ActiveUnitsManager.ActiveUnitState.Deselecting && state != ActiveUnitsManager.ActiveUnitState.Deselecting)
		{
			StopPulse();
		}
		if (mState == ActiveUnitsManager.ActiveUnitState.Selectable && state != ActiveUnitsManager.ActiveUnitState.Selectable)
		{
			StopPulse();
		}
		if (state == ActiveUnitsManager.ActiveUnitState.Selected && mState != ActiveUnitsManager.ActiveUnitState.Selected && mState != ActiveUnitsManager.ActiveUnitState.Deselecting)
		{
			AnimateSelect();
		}
		mState = state;
		boxCollider.enabled = mState == ActiveUnitsManager.ActiveUnitState.Selectable || (mState == ActiveUnitsManager.ActiveUnitState.NotSelected && (!Singleton<ActiveUnitsManager>.instance.selectingUnit || mUnit.unitType != Singleton<ActiveUnitsManager>.instance.unitToEquip.unitType)) || mState == ActiveUnitsManager.ActiveUnitState.Deselecting || mState == ActiveUnitsManager.ActiveUnitState.Selecting || mState == ActiveUnitsManager.ActiveUnitState.Selected;
		lockedIcon.gameObject.SetActive(mState == ActiveUnitsManager.ActiveUnitState.Locked);
		unitIcon.alpha = ((mState != ActiveUnitsManager.ActiveUnitState.Locked) ? 1f : 0.5f);
		rentedPart.SetActive(mState == ActiveUnitsManager.ActiveUnitState.Borrowed);
		if (mState == ActiveUnitsManager.ActiveUnitState.Selected || mState == ActiveUnitsManager.ActiveUnitState.Borrowed)
		{
			background.color = Colours.blue;
			highlight.color = Colours.blue;
		}
		else if (mState == ActiveUnitsManager.ActiveUnitState.NotSelected)
		{
			background.color = GameVariables.unitCategory[mUnit.unitType].Value2;
			background.alpha = 0.25f;
			highlight.color = Colours.whiteTransparent;
		}
		else if (mState == ActiveUnitsManager.ActiveUnitState.Selecting)
		{
			background.color = Colours.gray;
			highlight.color = Colours.gray;
		}
		else if (mState == ActiveUnitsManager.ActiveUnitState.Deselecting)
		{
			background.color = Colours.blue;
			highlight.color = Color.white;
		}
		else if (mState == ActiveUnitsManager.ActiveUnitState.Selectable)
		{
			background.color = Color.white;
			highlight.color = Color.white;
			highlight.alpha = 0.25f;
		}
		else
		{
			background.color = Colours.whiteTransparent;
			highlight.color = Colours.whiteTransparent;
		}
	}

	public void ClickOnIcon(GameObject go)
	{
		ActiveUnitsManager.ActiveUnitState activeUnitState = mState;
		int fakeArmyPowerX = Singleton<ActiveUnitsManager>.instance.fakeArmyPowerX10;
		GuiElementSingle<ChatGuiElement>.instance.activeUnitsContent.Select(mUnit);
		if (activeUnitState == ActiveUnitsManager.ActiveUnitState.NotSelected)
		{
			GuiElementSingle<ChatGuiElement>.instance.activeUnitsContent.recordToSelect = this;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		if (activeUnitState == ActiveUnitsManager.ActiveUnitState.Selectable && mState != ActiveUnitsManager.ActiveUnitState.Selectable)
		{
			int fakeArmyPowerX2 = Singleton<ActiveUnitsManager>.instance.fakeArmyPowerX10;
			int changeNumber = fakeArmyPowerX2 - fakeArmyPowerX;
			armyPowerAnimation.StartAnimation(changeNumber, fakeArmyPowerX2, 0.05f);
			return;
		}
		switch (activeUnitState)
		{
		case ActiveUnitsManager.ActiveUnitState.Selected:
		{
			int fakeArmyPowerX4 = Singleton<ActiveUnitsManager>.instance.fakeArmyPowerX10;
			int changeNumber3 = fakeArmyPowerX4 - fakeArmyPowerX;
			armyPowerAnimation.StartAnimation(changeNumber3, fakeArmyPowerX4, 0.05f);
			break;
		}
		case ActiveUnitsManager.ActiveUnitState.Deselecting:
		{
			int fakeArmyPowerX3 = Singleton<ActiveUnitsManager>.instance.fakeArmyPowerX10;
			int changeNumber2 = fakeArmyPowerX3 - fakeArmyPowerX;
			GuiElementSingle<ChatGuiElement>.instance.activeUnitsContent.recordToSelect.armyPowerAnimation.StartAnimation(changeNumber2, fakeArmyPowerX3, 0.05f);
			break;
		}
		}
	}

	private void StartPulse()
	{
		TweenScale component = highlight.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		highlight.transform.localScale = mHighlightOriginalScale;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(highlight.gameObject, 0.5f, 1f, 0.5f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha.method = UITweener.Method.Linear;
	}

	private void StopPulse()
	{
		TweenAlpha component = highlight.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = highlight.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		highlight.alpha = 1f;
		highlight.transform.localScale = mHighlightOriginalScale;
	}

	private void AnimateSelect()
	{
		float duration = 0.4f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(highlight.gameObject, duration, 0f, 1f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.EaseInOut;
		TweenScale.Begin(highlight.gameObject, duration, mHighlightBigScale, mHighlightOriginalScale);
	}
}
