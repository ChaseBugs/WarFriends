using System;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUnitsTab : Core_BaseScript
{
	public UIPanel activeUnitsPart;

	[Header("Header")]
	public List<ActiveUnitsCategoriesIndicator> categoriesIndicators;

	public UILabel selectedUnits;

	[Header("Content")]
	public GameObject middlePart;

	[Header("-Defender Category")]
	public UISprite defenderIcon;

	public UISprite defenderBackground;

	public List<ActiveUnitsIcon> defenderUnits;

	[Header("-Rusher Category")]
	public UISprite rusherIcon;

	public UISprite rusherBackground;

	public List<ActiveUnitsIcon> rusherUnits;

	[Header("-Shooter Category")]
	public UISprite shooterIcon;

	public UISprite shooterBackground;

	public List<ActiveUnitsIcon> shooterUnits;

	[Header("-Explosive Category")]
	public UISprite explosiveIcon;

	public UISprite explosiveBackground;

	public List<ActiveUnitsIcon> explosiveUnits;

	[Header("Bottom")]
	public GameObject bottomPart;

	[Header("-Select Units")]
	public GameObject selectUnitsCheck;

	public GameObject selectUnitsCross;

	public UILabel selectUnitsLabel;

	[Header("-Mechanical")]
	public GameObject mechanicalCheck;

	public GameObject mechanicalCross;

	public UITable mechanicalTable;

	public UILabel leftText;

	public UISprite centerIcon;

	public UILabel rightText;

	[Header("-Saved Combination")]
	public GameObject savedCombinationCheck;

	public GameObject savedCombinationCross;

	public UILabel savedCombinationLabel;

	[Header("Shadows")]
	public UIPanel shadowPanel;

	public GameObject topShadowPart;

	public GameObject defenseShadow;

	public GameObject rusherShadow;

	public GameObject shooterShadow;

	public GameObject explosiveShadow;

	public GameObject bottomShadowPart;

	[Header("-Shadow Labels")]
	public UILabel defenseLabel;

	public UILabel rusherLabel;

	public UILabel shooterLabel;

	public UILabel explosiveLabel;

	[Header("-Select Labels")]
	public GameObject selectParent;

	public UILabel defenseSelectLabel;

	public UILabel rusherSelectLabel;

	public UILabel shooterSelectLabel;

	public UILabel explosiveSelectLabel;

	[HideInInspector]
	public float armyPowerOfUnitToSelect;

	[HideInInspector]
	public ActiveUnitsIcon recordToSelect;

	private List<ActiveUnitsIcon> mMechanicalIcons = new List<ActiveUnitsIcon>();

	private bool mGuiInitialized;

	private Vector3 mDefPos = new Vector3(-366f, 347f, -1f);

	private Vector3 mRusPos = new Vector3(-366f, 175f, -1f);

	private Vector3 mShoPos = new Vector3(-366f, 3f, -1f);

	private Vector3 mExpPos = new Vector3(-366f, -169f, -1f);

	private bool mAnyChanged;

	private LevelBehaviour mUnitToTap;

	private ActiveUnitsIcon mUnitToTapIcon;

	public void ShowTab(bool enable)
	{
		if (enable && !activeUnitsPart.gameObject.activeSelf)
		{
			Singleton<ActiveUnitsManager>.instance.PresetForSelectMenu();
			activeUnitsPart.gameObject.SetActive(value: true);
			activeUnitsPart.isFreezed = false;
			activeUnitsPart.alpha1 = 0.005f;
			shadowPanel.isFreezed = false;
			shadowPanel.alpha1 = 0.005f;
			InitGuiValues();
			TweenAlpha.Begin(activeUnitsPart.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 1f).onFinished = null;
			TweenAlpha.Begin(shadowPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 1f);
			foreach (ActiveUnitsIcon defenderUnit in defenderUnits)
			{
				if (defenderUnit.gameObject.activeSelf)
				{
					defenderUnit.Show();
				}
			}
			foreach (ActiveUnitsIcon rusherUnit in rusherUnits)
			{
				if (rusherUnit.gameObject.activeSelf)
				{
					rusherUnit.Show();
				}
			}
			foreach (ActiveUnitsIcon shooterUnit in shooterUnits)
			{
				if (shooterUnit.gameObject.activeSelf)
				{
					shooterUnit.Show();
				}
			}
			foreach (ActiveUnitsIcon explosiveUnit in explosiveUnits)
			{
				if (explosiveUnit.gameObject.activeSelf)
				{
					explosiveUnit.Show();
				}
			}
		}
		if (enable || !activeUnitsPart.gameObject.activeSelf)
		{
			return;
		}
		TweenAlpha.Begin(shadowPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0f);
		TweenAlpha.Begin(activeUnitsPart.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0f).onFinished = delegate
		{
			activeUnitsPart.gameObject.SetActive(value: false);
		};
		foreach (ActiveUnitsIcon defenderUnit2 in defenderUnits)
		{
			if (defenderUnit2.gameObject.activeSelf)
			{
				defenderUnit2.Hide();
			}
		}
		foreach (ActiveUnitsIcon rusherUnit2 in rusherUnits)
		{
			if (rusherUnit2.gameObject.activeSelf)
			{
				rusherUnit2.Hide();
			}
		}
		foreach (ActiveUnitsIcon shooterUnit2 in shooterUnits)
		{
			if (shooterUnit2.gameObject.activeSelf)
			{
				shooterUnit2.Hide();
			}
		}
		foreach (ActiveUnitsIcon explosiveUnit2 in explosiveUnits)
		{
			if (explosiveUnit2.gameObject.activeSelf)
			{
				explosiveUnit2.Hide();
			}
		}
	}

	public void Select(LevelBehaviour unit)
	{
		if (mUnitToTap == unit)
		{
			mUnitToTap = null;
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		}
		switch (Singleton<ActiveUnitsManager>.instance.GetState(unit, inMenu: true))
		{
		case ActiveUnitsManager.ActiveUnitState.NotSelected:
			if (Singleton<ActiveUnitsManager>.instance.selectingUnit)
			{
				return;
			}
			if (!unit.isSoldier && !Singleton<ActiveUnitsManager>.instance.menuMechanicalCanBeChosen)
			{
				AnimateBottomMechanicalCannotBeChosen();
				return;
			}
			Singleton<ActiveUnitsManager>.instance.unitToEquip = unit;
			UpdateType(unit);
			Shadow();
			AnimateLabels();
			break;
		case ActiveUnitsManager.ActiveUnitState.Selectable:
			if (!Singleton<ActiveUnitsManager>.instance.MenuEquip(unit))
			{
				AnimateBottomMechanicalCannotBeChosen();
				return;
			}
			UpdateGuiSelectUnit(unit);
			UpdateType(unit);
			break;
		case ActiveUnitsManager.ActiveUnitState.Selected:
			Singleton<ActiveUnitsManager>.instance.MenuUnequip(unit);
			UpdateType(unit);
			break;
		case ActiveUnitsManager.ActiveUnitState.Selecting:
			Singleton<ActiveUnitsManager>.instance.MenuEquip(unit);
			Singleton<ActiveUnitsManager>.instance.unitToEquip = null;
			UpdateType(unit);
			Shadow();
			break;
		case ActiveUnitsManager.ActiveUnitState.Deselecting:
			Singleton<ActiveUnitsManager>.instance.MenuUnequip(unit);
			if (!Singleton<ActiveUnitsManager>.instance.MenuEquip(Singleton<ActiveUnitsManager>.instance.unitToEquip))
			{
				AnimateBottomMechanicalCannotBeChosen();
			}
			Singleton<ActiveUnitsManager>.instance.unitToEquip = null;
			UpdateType(unit);
			Shadow();
			break;
		}
		GuiElementSingle<ChatGuiElement>.instance.ActiveUnitsNotificationUpdate();
		mAnyChanged = true;
		SavedCombinationWarning(allOk: false);
		CanClose(animateBottom: false);
	}

	public bool CanClose(bool animateBottom = true)
	{
		bool flag = Singleton<ActiveUnitsManager>.instance.SetUnitsByMenu();
		SelectedUnitsWarning(flag);
		if (!flag)
		{
			if (animateBottom)
			{
				AnimateBottomNotEnoughSelected();
			}
		}
		else if (mAnyChanged)
		{
			SavedCombinationWarning(allOk: false);
			GuiScreenSingle<ArmyScreen>.instance.SendEquippedUnits();
			mAnyChanged = false;
		}
		return flag;
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += delegate
		{
			if (activeUnitsPart.gameObject.activeSelf)
			{
				InitGuiValues();
			}
		};
	}

	public void DatabaseResult(bool dbSuccess)
	{
		if (dbSuccess)
		{
			SavedCombinationWarning(allOk: true);
			return;
		}
		mUnitToTap = null;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		Singleton<ActiveUnitsManager>.instance.PresetForSelectMenu();
		InitGuiValues();
		SavedCombinationWarning(allOk: true);
	}

	public void InitControls()
	{
		float num = UIRoot.list[0].activeHeight;
		middlePart.transform.localPosition = new Vector3(middlePart.transform.localPosition.x, (0f - num) / 2f, middlePart.transform.localPosition.z);
		bottomPart.transform.localPosition = new Vector3(bottomPart.transform.localPosition.x, 0f - num, bottomPart.transform.localPosition.z);
		shadowPanel.transform.localPosition = new Vector3(shadowPanel.transform.localPosition.x, (0f - num) / 2f, shadowPanel.transform.localPosition.z);
		topShadowPart.transform.localPosition = new Vector3(topShadowPart.transform.localPosition.x, num / 2f, topShadowPart.transform.localPosition.z);
		bottomShadowPart.transform.localPosition = new Vector3(bottomShadowPart.transform.localPosition.x, (0f - num) / 2f, bottomShadowPart.transform.localPosition.z);
		shadowPanel.clipRange = new Vector4(shadowPanel.clipRange.x, shadowPanel.clipRange.y, shadowPanel.clipRange.z, num);
		selectParent.transform.localPosition = new Vector3(selectParent.transform.localPosition.x, (0f - num) / 2f, selectParent.transform.localPosition.z);
		foreach (ActiveUnitsIcon defenderUnit in defenderUnits)
		{
			UIEventListener uIEventListener = UIEventListener.Get(defenderUnit.boxCollider.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(defenderUnit.ClickOnIcon));
		}
		foreach (ActiveUnitsIcon rusherUnit in rusherUnits)
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(rusherUnit.boxCollider.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(rusherUnit.ClickOnIcon));
		}
		foreach (ActiveUnitsIcon shooterUnit in shooterUnits)
		{
			UIEventListener uIEventListener3 = UIEventListener.Get(shooterUnit.boxCollider.gameObject);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(shooterUnit.ClickOnIcon));
		}
		foreach (ActiveUnitsIcon explosiveUnit in explosiveUnits)
		{
			UIEventListener uIEventListener4 = UIEventListener.Get(explosiveUnit.boxCollider.gameObject);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(explosiveUnit.ClickOnIcon));
		}
		mechanicalTable.repositionNow = true;
	}

	public void InitGuiValues()
	{
		Singleton<ActiveUnitsManager>.instance.unitToEquip = null;
		mUnitToTap = null;
		bool flag = Singleton<NotificationManager>.instance.ActiveUnitToChoose() == 0;
		if (!flag)
		{
			mUnitToTap = Singleton<NotificationManager>.instance.ActiveUnitWithNotification();
			mUnitToTapIcon = FindIconWithBehaviour(mUnitToTap);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(mUnitToTapIcon.transform.position);
			Singleton<ActiveUnitsManager>.instance.MenuUnequipCategory(mUnitToTap);
		}
		InitializeGui();
		InitializeUnits();
		UpdateIndicators();
		UpdateMechanicals();
		UpdateDefenders();
		UpdateRushers();
		UpdateShooters();
		UpdateExplosive();
		Shadow();
		HideSelectUnits();
		SelectedUnitsWarning(flag);
		SelectedMechanical(allOk: true);
		SavedCombinationWarning(flag);
		GuiElementSingle<ChatGuiElement>.instance.ActiveUnitsNotificationUpdate();
		bool flag2 = Mathf.Max(Singleton<ActiveUnitsManager>.instance.selectableDefenders, Singleton<ActiveUnitsManager>.instance.selectableRusher, Singleton<ActiveUnitsManager>.instance.selectableShooter, Singleton<ActiveUnitsManager>.instance.selectableExplosive) > 2;
		selectUnitsLabel.text = Localization.Localize((!flag2) ? "ID_ALLAVAILABLEUNITSMUSTBESELECTED" : "ID_MAXUNITSFROMEACHCATEGORY");
	}

	private void InitializeGui()
	{
		if (!mGuiInitialized)
		{
			mGuiInitialized = true;
			defenderIcon.spriteName = GameVariables.unitCategory[LevelBehaviour.UnitType.Defender].Value1;
			defenderIcon.MakePixelPerfect();
			defenderBackground.color = GameVariables.unitCategory[LevelBehaviour.UnitType.Defender].Value2;
			defenderBackground.alpha = 0.25f;
			rusherIcon.spriteName = GameVariables.unitCategory[LevelBehaviour.UnitType.AttackerRusher].Value1;
			rusherIcon.MakePixelPerfect();
			rusherBackground.color = GameVariables.unitCategory[LevelBehaviour.UnitType.AttackerRusher].Value2;
			rusherBackground.alpha = 0.25f;
			shooterIcon.spriteName = GameVariables.unitCategory[LevelBehaviour.UnitType.AttackerShooter].Value1;
			shooterIcon.MakePixelPerfect();
			shooterBackground.color = GameVariables.unitCategory[LevelBehaviour.UnitType.AttackerShooter].Value2;
			shooterBackground.alpha = 0.25f;
			explosiveIcon.spriteName = GameVariables.unitCategory[LevelBehaviour.UnitType.AttackerExplosive].Value1;
			explosiveIcon.MakePixelPerfect();
			explosiveBackground.color = GameVariables.unitCategory[LevelBehaviour.UnitType.AttackerExplosive].Value2;
			explosiveBackground.alpha = 0.25f;
			categoriesIndicators[0].Initialize(LevelBehaviour.UnitType.Defender);
			categoriesIndicators[1].Initialize(LevelBehaviour.UnitType.AttackerRusher);
			categoriesIndicators[2].Initialize(LevelBehaviour.UnitType.AttackerShooter);
			categoriesIndicators[3].Initialize(LevelBehaviour.UnitType.AttackerExplosive);
		}
	}

	private void InitializeUnits()
	{
		mMechanicalIcons.Clear();
		for (int i = 0; i < defenderUnits.Count; i++)
		{
			bool flag = i < Singleton<ActiveUnitsManager>.instance.defenderUnits.Count;
			defenderUnits[i].gameObject.SetActive(flag);
			if (flag)
			{
				defenderUnits[i].Initialize(Singleton<ActiveUnitsManager>.instance.defenderUnits[i]);
				if (!Singleton<ActiveUnitsManager>.instance.defenderUnits[i].isSoldier)
				{
					mMechanicalIcons.Add(defenderUnits[i]);
				}
			}
		}
		for (int j = 0; j < rusherUnits.Count; j++)
		{
			bool flag2 = j < Singleton<ActiveUnitsManager>.instance.rusherUnits.Count;
			rusherUnits[j].gameObject.SetActive(flag2);
			if (flag2)
			{
				rusherUnits[j].Initialize(Singleton<ActiveUnitsManager>.instance.rusherUnits[j]);
				if (!Singleton<ActiveUnitsManager>.instance.rusherUnits[j].isSoldier)
				{
					mMechanicalIcons.Add(rusherUnits[j]);
				}
			}
		}
		for (int k = 0; k < shooterUnits.Count; k++)
		{
			bool flag3 = k < Singleton<ActiveUnitsManager>.instance.shooterUnits.Count;
			shooterUnits[k].gameObject.SetActive(flag3);
			if (flag3)
			{
				shooterUnits[k].Initialize(Singleton<ActiveUnitsManager>.instance.shooterUnits[k]);
				if (!Singleton<ActiveUnitsManager>.instance.shooterUnits[k].isSoldier)
				{
					mMechanicalIcons.Add(shooterUnits[k]);
				}
			}
		}
		for (int l = 0; l < explosiveUnits.Count; l++)
		{
			bool flag4 = l < Singleton<ActiveUnitsManager>.instance.explosiveUnits.Count;
			explosiveUnits[l].gameObject.SetActive(flag4);
			if (flag4)
			{
				explosiveUnits[l].Initialize(Singleton<ActiveUnitsManager>.instance.explosiveUnits[l]);
				if (!Singleton<ActiveUnitsManager>.instance.explosiveUnits[l].isSoldier)
				{
					mMechanicalIcons.Add(explosiveUnits[l]);
				}
			}
		}
	}

	private void UpdateType(LevelBehaviour unit)
	{
		switch (unit.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			UpdateDefenders();
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			UpdateRushers();
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			UpdateShooters();
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			UpdateExplosive();
			break;
		}
		UpdateIndicators();
		UpdateMechanicals();
	}

	private void UpdateIndicators()
	{
		categoriesIndicators[0].SetUnits(Singleton<ActiveUnitsManager>.instance.firstDefender, Singleton<ActiveUnitsManager>.instance.secondDefender);
		categoriesIndicators[1].SetUnits(Singleton<ActiveUnitsManager>.instance.firstRusher, Singleton<ActiveUnitsManager>.instance.secondRusher);
		categoriesIndicators[2].SetUnits(Singleton<ActiveUnitsManager>.instance.firstShooter, Singleton<ActiveUnitsManager>.instance.secondShooter);
		categoriesIndicators[3].SetUnits(Singleton<ActiveUnitsManager>.instance.firstExplosive, Singleton<ActiveUnitsManager>.instance.secondExplosive);
		selectedUnits.text = $"{Singleton<ActiveUnitsManager>.instance.numberOfMenuEquippedUnits} / 8";
	}

	private void UpdateMechanicals()
	{
		bool menuMechanicalCanBeChosen = Singleton<ActiveUnitsManager>.instance.menuMechanicalCanBeChosen;
		foreach (ActiveUnitsIcon mMechanicalIcon in mMechanicalIcons)
		{
			mMechanicalIcon.SetMechanical(menuMechanicalCanBeChosen);
		}
	}

	private void UpdateDefenders()
	{
		foreach (ActiveUnitsIcon defenderUnit in defenderUnits)
		{
			if (defenderUnit.gameObject.activeSelf)
			{
				defenderUnit.UpdateState();
			}
		}
	}

	private void UpdateRushers()
	{
		foreach (ActiveUnitsIcon rusherUnit in rusherUnits)
		{
			if (rusherUnit.gameObject.activeSelf)
			{
				rusherUnit.UpdateState();
			}
		}
	}

	private void UpdateShooters()
	{
		foreach (ActiveUnitsIcon shooterUnit in shooterUnits)
		{
			if (shooterUnit.gameObject.activeSelf)
			{
				shooterUnit.UpdateState();
			}
		}
	}

	private void UpdateExplosive()
	{
		foreach (ActiveUnitsIcon explosiveUnit in explosiveUnits)
		{
			if (explosiveUnit.gameObject.activeSelf)
			{
				explosiveUnit.UpdateState();
			}
		}
	}

	protected void Update()
	{
		if (mUnitToTap != null)
		{
			GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(mUnitToTapIcon.transform.position);
		}
	}

	private ActiveUnitsIcon FindIconWithBehaviour(LevelBehaviour unit)
	{
		int num = Singleton<ActiveUnitsManager>.instance.IndexOfUnit(unit);
		if (num == -1)
		{
			return null;
		}
		if (unit.unitType == LevelBehaviour.UnitType.Defender)
		{
			return defenderUnits[num];
		}
		if (unit.unitType == LevelBehaviour.UnitType.AttackerRusher)
		{
			return rusherUnits[num];
		}
		if (unit.unitType == LevelBehaviour.UnitType.AttackerShooter)
		{
			return shooterUnits[num];
		}
		if (unit.unitType == LevelBehaviour.UnitType.AttackerExplosive)
		{
			return explosiveUnits[num];
		}
		return null;
	}

	private void Shadow()
	{
		bool selectingUnit = Singleton<ActiveUnitsManager>.instance.selectingUnit;
		shadowPanel.gameObject.SetActive(selectingUnit);
		if (selectingUnit)
		{
			shadowPanel.isFreezed = false;
			TweenAlpha.Begin(shadowPanel.gameObject, 0.2f, 0f, 1f);
			LevelBehaviour unitToEquip = Singleton<ActiveUnitsManager>.instance.unitToEquip;
			defenseShadow.SetActive(unitToEquip.unitType != LevelBehaviour.UnitType.Defender);
			rusherShadow.SetActive(unitToEquip.unitType != LevelBehaviour.UnitType.AttackerRusher);
			shooterShadow.SetActive(unitToEquip.unitType != LevelBehaviour.UnitType.AttackerShooter);
			explosiveShadow.SetActive(unitToEquip.unitType != LevelBehaviour.UnitType.AttackerExplosive);
			if (defenseShadow.activeSelf)
			{
				HideLabel(defenseLabel, mDefPos);
			}
			if (rusherShadow.activeSelf)
			{
				HideLabel(rusherLabel, mRusPos);
			}
			if (shooterShadow.activeSelf)
			{
				HideLabel(shooterLabel, mShoPos);
			}
			if (explosiveShadow.activeSelf)
			{
				HideLabel(explosiveLabel, mExpPos);
			}
		}
		float alpha = defenseSelectLabel.alpha;
		defenseSelectLabel.color = ((!selectingUnit) ? Color.white : Colours.gray);
		defenseSelectLabel.alpha = alpha;
		alpha = rusherSelectLabel.alpha;
		rusherSelectLabel.color = ((!selectingUnit) ? Color.white : Colours.gray);
		rusherSelectLabel.alpha = alpha;
		alpha = shooterSelectLabel.alpha;
		shooterSelectLabel.color = ((!selectingUnit) ? Color.white : Colours.gray);
		shooterSelectLabel.alpha = alpha;
		alpha = explosiveSelectLabel.alpha;
		explosiveSelectLabel.color = ((!selectingUnit) ? Color.white : Colours.gray);
		explosiveSelectLabel.alpha = alpha;
	}

	private void AnimateLabels()
	{
		if (!defenseShadow.activeSelf)
		{
			defenseLabel.text = Localization.LocalizeFormat("ID_ACTIVATEINSTEADOF", Singleton<ActiveUnitsManager>.instance.unitToEquip.unitName.ToUpper());
			AnimateLabel(defenseLabel, mDefPos);
		}
		if (!rusherShadow.activeSelf)
		{
			rusherLabel.text = Localization.LocalizeFormat("ID_ACTIVATEINSTEADOF", Singleton<ActiveUnitsManager>.instance.unitToEquip.unitName.ToUpper());
			AnimateLabel(rusherLabel, mRusPos);
		}
		if (!shooterShadow.activeSelf)
		{
			shooterLabel.text = Localization.LocalizeFormat("ID_ACTIVATEINSTEADOF", Singleton<ActiveUnitsManager>.instance.unitToEquip.unitName.ToUpper());
			AnimateLabel(shooterLabel, mShoPos);
		}
		if (!explosiveShadow.activeSelf)
		{
			explosiveLabel.text = Localization.LocalizeFormat("ID_ACTIVATEINSTEADOF", Singleton<ActiveUnitsManager>.instance.unitToEquip.unitName.ToUpper());
			AnimateLabel(explosiveLabel, mExpPos);
		}
	}

	private void AnimateLabel(UILabel shadowLabel, Vector3 startPos)
	{
		TweenAlpha.Begin(shadowLabel.gameObject, 0.3f, 0f, 1f);
		TweenPosition tweenPosition = TweenPosition.Begin(shadowLabel.gameObject, 0.3f, startPos - new Vector3(0f, 26f, 0f), startPos + new Vector3(0f, 16f, 0f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, (UITweener.OnFinished)delegate
		{
			TweenPosition.Begin(shadowLabel.gameObject, 0.2f, startPos).method = UITweener.Method.EaseOut;
		});
	}

	private void HideLabel(UILabel shadowLabel, Vector3 localPos)
	{
		shadowLabel.alpha = 0f;
		shadowLabel.transform.localPosition = localPos;
		TweenAlpha component = shadowLabel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenPosition component2 = shadowLabel.GetComponent<TweenPosition>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
	}

	private void AnimateBottomNotEnoughSelected()
	{
		AnimateBottomSelect(3);
		ChooseUnitsBeforeClosingMiddleAnimation();
	}

	private void ChooseUnitsBeforeClosingMiddleAnimation()
	{
		int selectableDefenders = Singleton<ActiveUnitsManager>.instance.selectableDefenders;
		if (selectableDefenders == 1 && Singleton<ActiveUnitsManager>.instance.firstDefender == null)
		{
			defenseSelectLabel.text = Localization.LocalizeFormat("ID_SELECTONEUNIT", Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.Defender].Value1));
			AnimateLabel(defenseSelectLabel, mDefPos);
		}
		else if (selectableDefenders > 1 && Singleton<ActiveUnitsManager>.instance.secondDefender == null)
		{
			defenseSelectLabel.text = Localization.LocalizeFormat("ID_SELECTTWOUNITS", Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.Defender].Value1));
			AnimateLabel(defenseSelectLabel, mDefPos);
		}
		int selectableRusher = Singleton<ActiveUnitsManager>.instance.selectableRusher;
		if (selectableRusher == 1 && Singleton<ActiveUnitsManager>.instance.firstRusher == null)
		{
			rusherSelectLabel.text = Localization.LocalizeFormat("ID_SELECTONEUNIT", Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.AttackerRusher].Value1));
			AnimateLabel(rusherSelectLabel, mRusPos);
		}
		else if (selectableRusher > 1 && Singleton<ActiveUnitsManager>.instance.secondRusher == null)
		{
			rusherSelectLabel.text = Localization.LocalizeFormat("ID_SELECTTWOUNITS", Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.AttackerRusher].Value1));
			AnimateLabel(rusherSelectLabel, mRusPos);
		}
		int selectableShooter = Singleton<ActiveUnitsManager>.instance.selectableShooter;
		if (selectableShooter == 1 && Singleton<ActiveUnitsManager>.instance.firstShooter == null)
		{
			shooterSelectLabel.text = Localization.LocalizeFormat("ID_SELECTONEUNIT", Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.AttackerShooter].Value1));
			AnimateLabel(shooterSelectLabel, mShoPos);
		}
		else if (selectableShooter > 1 && Singleton<ActiveUnitsManager>.instance.secondShooter == null)
		{
			shooterSelectLabel.text = Localization.LocalizeFormat("ID_SELECTTWOUNITS", Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.AttackerShooter].Value1));
			AnimateLabel(shooterSelectLabel, mShoPos);
		}
		int selectableExplosive = Singleton<ActiveUnitsManager>.instance.selectableExplosive;
		if (selectableExplosive == 1 && Singleton<ActiveUnitsManager>.instance.firstExplosive == null)
		{
			explosiveSelectLabel.text = Localization.LocalizeFormat("ID_SELECTONEUNIT", Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.AttackerExplosive].Value1));
			AnimateLabel(explosiveSelectLabel, mExpPos);
		}
		else if (selectableExplosive > 1 && Singleton<ActiveUnitsManager>.instance.secondExplosive == null)
		{
			explosiveSelectLabel.text = Localization.LocalizeFormat("ID_SELECTTWOUNITS", Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.AttackerExplosive].Value1));
			AnimateLabel(explosiveSelectLabel, mExpPos);
		}
	}

	private void UpdateGuiSelectUnit(LevelBehaviour unit)
	{
		int selectableDefenders = Singleton<ActiveUnitsManager>.instance.selectableDefenders;
		if ((selectableDefenders == 1 && Singleton<ActiveUnitsManager>.instance.firstDefender != null) || (selectableDefenders > 1 && Singleton<ActiveUnitsManager>.instance.secondDefender != null))
		{
			HideLabel(defenseSelectLabel, mDefPos);
		}
		int selectableRusher = Singleton<ActiveUnitsManager>.instance.selectableRusher;
		if ((selectableRusher == 1 && Singleton<ActiveUnitsManager>.instance.firstRusher != null) || (selectableRusher > 1 && Singleton<ActiveUnitsManager>.instance.secondRusher != null))
		{
			HideLabel(rusherSelectLabel, mRusPos);
		}
		int selectableShooter = Singleton<ActiveUnitsManager>.instance.selectableShooter;
		if ((selectableShooter == 1 && Singleton<ActiveUnitsManager>.instance.firstShooter != null) || (selectableShooter > 1 && Singleton<ActiveUnitsManager>.instance.secondShooter != null))
		{
			HideLabel(shooterSelectLabel, mShoPos);
		}
		int selectableExplosive = Singleton<ActiveUnitsManager>.instance.selectableExplosive;
		if ((selectableExplosive == 1 && Singleton<ActiveUnitsManager>.instance.firstExplosive != null) || (selectableExplosive > 1 && Singleton<ActiveUnitsManager>.instance.secondExplosive != null))
		{
			HideLabel(explosiveSelectLabel, mExpPos);
		}
	}

	private void HideSelectUnits()
	{
		HideLabel(defenseSelectLabel, mDefPos);
		HideLabel(rusherSelectLabel, mRusPos);
		HideLabel(shooterSelectLabel, mShoPos);
		HideLabel(explosiveSelectLabel, mExpPos);
	}

	private void AnimateBottomSelect(int count)
	{
		if (count < 1)
		{
			return;
		}
		float delay = 0.05f;
		float dur = 0.05f;
		TweenColor tweenColor = TweenColor.Begin(selectUnitsLabel.gameObject, dur, Color.red, Color.white);
		tweenColor.delay = delay;
		tweenColor.onFinished = delegate
		{
			TweenColor tweenColor2 = TweenColor.Begin(selectUnitsLabel.gameObject, dur, Color.red);
			tweenColor2.delay = delay;
			tweenColor2.onFinished = delegate
			{
				AnimateBottomSelect(count - 1);
			};
		};
	}

	private void AnimateBottomMechanicalCannotBeChosen()
	{
		AnimateBottomMechanical(3);
	}

	private void AnimateBottomMechanical(int count)
	{
		if (count < 1)
		{
			return;
		}
		float delay = 0.05f;
		float dur = 0.05f;
		TweenColor.Begin(centerIcon.gameObject, dur, Color.white, Color.red).delay = delay;
		TweenColor.Begin(rightText.gameObject, dur, Color.white, Color.red).delay = delay;
		TweenColor tweenColor = TweenColor.Begin(leftText.gameObject, dur, Color.white, Color.red);
		tweenColor.delay = delay;
		tweenColor.onFinished = delegate
		{
			TweenColor.Begin(centerIcon.gameObject, dur, Color.white).delay = delay;
			TweenColor.Begin(rightText.gameObject, dur, Color.white).delay = delay;
			TweenColor tweenColor2 = TweenColor.Begin(leftText.gameObject, dur, Color.white);
			tweenColor2.delay = delay;
			tweenColor2.onFinished = delegate
			{
				AnimateBottomMechanical(count - 1);
			};
		};
	}

	private void SelectedUnitsWarning(bool allOk)
	{
		selectUnitsCheck.SetActive(allOk);
		selectUnitsCross.SetActive(!allOk);
		selectUnitsLabel.color = ((!allOk) ? Colours.red : Color.white);
	}

	private void SelectedMechanical(bool allOk)
	{
		mechanicalCheck.SetActive(allOk);
		mechanicalCross.SetActive(!allOk);
		leftText.color = ((!allOk) ? Colours.red : Color.white);
		centerIcon.color = ((!allOk) ? Colours.red : Color.white);
		rightText.color = ((!allOk) ? Colours.red : Color.white);
	}

	private void SavedCombinationWarning(bool allOk)
	{
		savedCombinationCheck.SetActive(allOk);
		savedCombinationCross.SetActive(!allOk);
		savedCombinationLabel.color = ((!allOk) ? Colours.red : Color.white);
		savedCombinationLabel.text = Localization.Localize((!allOk) ? "ID_UNITCOMBINATIONNOTSAVED" : "ID_UNITCOMBINATIONSAVED");
	}
}
