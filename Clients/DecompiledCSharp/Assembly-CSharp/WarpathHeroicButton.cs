using System;
using UnityEngine;

public class WarpathHeroicButton : Core_BaseScript
{
	public enum Type
	{
		Locked,
		Normal,
		Heroic,
		HeroicCompleted
	}

	[Header("Core")]
	public BoxCollider warpathCollider;

	public UISprite warpathBorder;

	public UILabel warpathLabel;

	public UIPanel heroicPanel;

	[Header("Locked Warpath")]
	public GameObject lockedWarpathPart;

	public UILabel lockedWarpathLabel;

	[Header("Locked Heroic")]
	public GameObject lockedHeroicPart;

	[Header("Heroic In Progress")]
	public UITable heroicTable;

	public UILabel heroicFirstLabel;

	public UILabel heroicSecondLabel;

	public UISprite heroicGoldIcon;

	public UISprite heroicWarbucksIcon;

	[Header("Heroic Done")]
	public GameObject heroicCompletedPart;

	[Header("Unlocked Part")]
	public GameObject warpathNotification;

	public bool isColliderEnabled => mCurrentType != Type.Locked;

	private Type mCurrentType
	{
		get
		{
			if (LevelManager.instance.isWarpathLocked)
			{
				return Type.Locked;
			}
			if (MissionsManager.instance.isHeroicLocked)
			{
				return Type.Normal;
			}
			if (MissionsManager.instance.isHeroicMissionCompleted)
			{
				return Type.HeroicCompleted;
			}
			return Type.Heroic;
		}
	}

	public bool showNotification => mCurrentType != Type.Locked && Singleton<NotificationManager>.instance.NotificationWarpath();

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(warpathCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(WarpathClick));
		warpathLabel.text = Localization.Localize("ID_WARPATH");
	}

	private void WarpathClick(GameObject go)
	{
		Singleton<GameController>.instance.SwitchToSinglePlayer();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MissionScreen>.instance);
	}

	public void InitGuiValues()
	{
		Type type = mCurrentType;
		warpathCollider.enabled = isColliderEnabled;
		warpathBorder.alpha = ((type != Type.Locked) ? 1f : 0.2f);
		warpathLabel.transform.localPosition = warpathLabel.transform.localPosition.ReplaceY((type != Type.Locked) ? 25f : 22f);
		warpathLabel.transform.localScale = ((type != Type.Locked) ? new Vector3(52f, 52f, 1f) : new Vector3(37f, 37f, 1f));
		MiscTools.SetUILabelRescale(warpathLabel, (type != Type.Locked) ? 52f : 37f, 20f, (type != Type.Locked) ? 370 : 260);
		lockedWarpathPart.SetActive(type == Type.Locked);
		heroicPanel.gameObject.SetActive(type != Type.Locked);
		lockedHeroicPart.SetActive(type == Type.Normal);
		heroicTable.gameObject.SetActive(type == Type.Heroic);
		heroicCompletedPart.SetActive(type == Type.HeroicCompleted);
		if (type == Type.Locked)
		{
			lockedWarpathLabel.text = Localization.LocalizeFormat("ID_UNLOCKEDATRANKX", LevelManager.instance.warpathUnlockLevel);
			MiscTools.SetUILabelRescale(lockedWarpathLabel, 30f, 20f, 260);
		}
		if (type == Type.Heroic)
		{
			int num = 104;
			int num2 = 58;
			heroicFirstLabel.text = Localization.Localize("ID_HEROIC");
			heroicSecondLabel.text = Localization.Localize("ID_GET");
			float value = Mathf.Min((float)num / heroicFirstLabel.relativeSize.x, (float)num2 / heroicSecondLabel.relativeSize.x);
			value = Mathf.Clamp(value, 20f, 30f);
			MiscTools.SetUILabelRescale(heroicFirstLabel, value, 20f, num);
			MiscTools.SetUILabelRescale(heroicSecondLabel, value, 20f, num2);
			heroicWarbucksIcon.gameObject.SetActive(MissionsManager.instance.heroicMission.heroicRewardGold <= 0);
			heroicGoldIcon.gameObject.SetActive(MissionsManager.instance.heroicMission.heroicRewardGold > 0);
			heroicTable.repositionNow = true;
		}
		InitializeNotification();
	}

	private void InitializeNotification()
	{
		warpathNotification.SetActive(showNotification);
	}
}
