using System.Collections.Generic;
using UnityEngine;

public class MissionRecord : PoolableObject
{
	[Header("Both")]
	public UIButtonScale buttonScale;

	public UILabel missionLabel;

	public UISprite labelBg;

	[Header("-Locked")]
	public GameObject lockedGraphics;

	public UISprite lockIcon;

	public UISprite lockedBackground;

	[Header("-Unlocked")]
	public GameObject unlockedGraphics;

	public UISprite shadowBg;

	[Header("--Stars")]
	public UISprite star1Sprite;

	public UISprite star2Sprite;

	public UISprite star3Sprite;

	public List<UISprite> starShadows;

	[Header("--Completed")]
	public GameObject completedInCoop;

	public GameObject completedAlone;

	[Header("Heroic")]
	public GameObject heroicPart;

	public GameObject heroicSingle;

	public GameObject heroicCoop;

	[Header("Setting")]
	public int missionNumber;

	[HideInInspector]
	public static Vector3 lockedScale = new Vector3(172f, 135f, 0f);

	[HideInInspector]
	public static Vector3 unlockedScale = new Vector3(338f, 135f, 0f);

	[HideInInspector]
	public static Vector3 lockIconScale = new Vector3(115f, 135f, 0f);

	[HideInInspector]
	public static Vector3 lockedBgPos = new Vector3(120f, 14.5f, 0f);

	[HideInInspector]
	public static Vector3 unlockedBgPos = new Vector3(205f, 14.5f, 0f);

	private Mission mMission;

	public Mission GetMission()
	{
		return mMission;
	}

	public void SetUnlocked()
	{
		lockedGraphics.SetActive(value: false);
		unlockedGraphics.SetActive(value: true);
		SetButtonScale(activeScale: true);
		if (mMission.numberOfStars == 3)
		{
			labelBg.color = Colours.orange;
			missionLabel.color = Color.white;
		}
		else
		{
			labelBg.color = Color.white;
			missionLabel.color = Color.black;
		}
		InitializeToDefault();
		completedAlone.SetActive(mMission.completedAlone);
		completedInCoop.SetActive(mMission.completedInCoop);
	}

	public void SetLocked(bool disableScale = true)
	{
		lockedGraphics.SetActive(value: true);
		unlockedGraphics.SetActive(value: false);
		SetButtonScale(!disableScale);
		labelBg.color = Color.black;
		missionLabel.color = Color.white;
		InitializeToDefault();
		completedAlone.SetActive(value: false);
		completedInCoop.SetActive(value: false);
	}

	public void SetActual(bool overrideCompleted = false)
	{
		if (overrideCompleted || !(mMission != null) || !mMission.completed)
		{
			SetButtonScale(activeScale: true);
			missionLabel.color = Color.white;
			shadowBg.color = Colours.blueShadow;
			labelBg.color = Colours.blueMission;
			TweenColor.Begin(missionLabel.gameObject, 0.01f, Color.white);
			TweenColor.Begin(shadowBg.gameObject, 0.01f, Colours.blueShadow);
			TweenColor.Begin(labelBg.gameObject, 0.01f, Colours.blueMission);
		}
	}

	private void InitializeToDefault()
	{
		shadowBg.color = Colours.blackShadow;
		lockedBackground.color = Colours.blackShadow;
		TweenAlpha.Begin(lockIcon.gameObject, 0f, 1f);
		TweenScale.Begin(shadowBg.gameObject, 0f, unlockedScale);
		TweenScale.Begin(lockedBackground.gameObject, 0f, lockedScale);
		TweenScale.Begin(lockIcon.gameObject, 0f, lockIconScale);
		foreach (UISprite starShadow in starShadows)
		{
			Vector3 localPosition = starShadow.transform.localPosition;
			localPosition.y = 0f;
			TweenPosition.Begin(starShadow.gameObject, 0f, localPosition);
		}
		TweenPosition.Begin(lockedBackground.gameObject, 0f, lockedBgPos);
		TweenPosition.Begin(shadowBg.gameObject, 0f, unlockedBgPos);
	}

	internal void Init(Mission missionReference)
	{
		if (missionReference == null)
		{
			SetLocked();
			Debug.LogError("Missing mission reference in mission screen button initialization. Mission number: " + missionNumber + ". Mission index: " + (missionNumber - 1));
			return;
		}
		mMission = missionReference;
		if (mMission.opened)
		{
			SetUnlocked();
		}
		else
		{
			SetLocked();
		}
		missionLabel.text = missionNumber.ToString();
		int numberOfStars = mMission.numberOfStars;
		star1Sprite.gameObject.SetActive(numberOfStars > 0);
		star2Sprite.gameObject.SetActive(numberOfStars > 1);
		star3Sprite.gameObject.SetActive(numberOfStars > 2);
		if (MissionsManager.instance.isHeroicLocked)
		{
			heroicPart.SetActive(value: false);
			return;
		}
		heroicPart.SetActive(mMission.isHeroic);
		heroicSingle.SetActive(mMission.heroicType == MissionsManager.HeroicType.Single);
		heroicCoop.SetActive(mMission.heroicType == MissionsManager.HeroicType.Coop);
	}

	private void SetButtonScale(bool activeScale)
	{
		buttonScale.hover = ((!activeScale) ? Vector3.one : new Vector3(1.1f, 1.1f, 1f));
		buttonScale.pressed = ((!activeScale) ? Vector3.one : new Vector3(1.05f, 1.05f, 1f));
	}
}
