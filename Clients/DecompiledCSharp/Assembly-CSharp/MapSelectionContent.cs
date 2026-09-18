using System;
using UnityEngine;

public class MapSelectionContent : Core_BaseScript
{
	public float duration = 0.6f;

	[Header("Selected Map")]
	public BoxCollider selectCollider;

	public UISprite selectedMapIcon;

	public GameObject selectedMapRandom;

	public UILabel selectedMapLabel;

	public UISprite rollOutList;

	public GameObject hideList;

	public UISprite[] hideListSprites;

	public UISprite selectedOverlay;

	[Header("List")]
	public UISprite listBackground;

	public MapSelectionRecord[] records;

	private MapSelectionRecord mSelectedMap;

	private bool mOpened;

	private bool mAnimating;

	private float mBackgroundAlpha = 0.3f;

	public bool isOpened => mOpened;

	public bool isAnimating => mAnimating;

	public void InitControls()
	{
		for (int i = 0; i < records.Length; i++)
		{
			bool flag = i == 0 || i > Singleton<MapManager>.instance.mapEntries.Count;
			records[i].InitializeMap((!flag) ? Singleton<MapManager>.instance.mapEntries[i - 1] : null);
			records[i].Selected(selected: false);
			UIEventListener uIEventListener = UIEventListener.Get(records[i].mapCollider.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MapClick));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(selectCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(SelectFromMapsClick));
	}

	private void MapClick(GameObject go)
	{
		MapSelectionRecord component = go.transform.parent.parent.GetComponent<MapSelectionRecord>();
		if (!(component != null))
		{
			return;
		}
		MapManager.MapEntry map = component.GetMap();
		if (map == null || map.unlockLevel <= LevelManager.instance.currentLevel.displayNumber || DebugSettings.debugEnabled)
		{
			if (mSelectedMap != null)
			{
				mSelectedMap.Selected(selected: false, animating: true);
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			mSelectedMap = component;
			SelectMap(map);
			mSelectedMap.Selected(selected: true, animating: true);
		}
	}

	private void SelectFromMapsClick(GameObject go)
	{
		if (mAnimating)
		{
			return;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mOpened)
		{
			AnimateHide();
		}
		else if (GuiScreenSingle<BattlePreparationScreen>.instance.gameModeContent.shownModes)
		{
			if (!GuiScreenSingle<BattlePreparationScreen>.instance.gameModeContent.isAnimating)
			{
				GuiScreenSingle<BattlePreparationScreen>.instance.gameModeContent.CloseModeSelection(go);
				AnimateOpen();
			}
		}
		else
		{
			AnimateOpen();
		}
	}

	public void InitGuiValues()
	{
		if (mSelectedMap == null)
		{
			for (int i = 0; i < records.Length; i++)
			{
				if (records[i].GetMap() == null)
				{
					mSelectedMap = records[i];
					break;
				}
			}
		}
		MapManager.MapEntry map = mSelectedMap.GetMap();
		SelectMap(map);
		for (int j = 0; j < records.Length; j++)
		{
			records[j].UpdateGui();
			records[j].Selected(map == records[j].GetMap());
		}
		InstaHide();
	}

	private void SelectMap(MapManager.MapEntry map)
	{
		bool flag = map == null;
		if (flag)
		{
			Singleton<MapManager>.instance.SetRandomMap();
		}
		else
		{
			Singleton<MapManager>.instance.currentMap = map;
		}
		selectedMapIcon.gameObject.SetActive(!flag);
		selectedMapRandom.SetActive(flag);
		if (!flag)
		{
			selectedMapIcon.spriteName = map.iconName;
		}
		selectedMapLabel.text = ((!flag) ? map.guiName : Localization.Localize("ID_RANDOMMAP"));
		selectedOverlay.alpha = ((!flag) ? 0.55f : 0.21f);
	}

	private void AnimateOpen()
	{
		mOpened = true;
		mAnimating = true;
		float val = 108f + (float)records.Length * 142f + 2f;
		listBackground.gameObject.SetActive(value: true);
		listBackground.alpha = 0f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(listBackground.gameObject, 0.15f, 0f, mBackgroundAlpha);
		tweenAlpha.delay = 0f;
		listBackground.transform.localScale = listBackground.transform.localScale.ReplaceY(108f);
		TweenScale tweenScale = TweenScale.Begin(listBackground.gameObject, duration, listBackground.transform.localScale.ReplaceY(108f), listBackground.transform.localScale.ReplaceY(val));
		tweenScale.onFinished = delegate
		{
			mAnimating = false;
			for (int i = 0; i < records.Length; i++)
			{
				records[i].SetOpened();
			}
		};
		rollOutList.alpha = 1f;
		tweenAlpha = TweenAlpha.Begin(rollOutList.gameObject, 0.3f, 1f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha.onFinished = delegate
		{
			rollOutList.gameObject.SetActive(value: false);
		};
		hideList.SetActive(value: true);
		hideList.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.Begin(hideList, 0f, Vector3.forward, 0f, 0f);
		hideListSprites[0].alpha = 0f;
		hideListSprites[1].alpha = 0f;
		tweenAlpha = TweenAlpha.Begin(hideListSprites[0].gameObject, 0.3f, 0f, 1f);
		tweenAlpha.delay = duration - 0.3f;
		tweenAlpha.onFinished = null;
		tweenAlpha = TweenAlpha.Begin(hideListSprites[1].gameObject, 0.3f, 0f, 1f);
		tweenAlpha.delay = duration - 0.3f;
		for (int num = 0; num < records.Length; num++)
		{
			records[num].SetHide();
		}
	}

	public void AnimateHide()
	{
		mOpened = false;
		mAnimating = true;
		float val = 108f + (float)records.Length * 142f + 2f;
		listBackground.alpha = mBackgroundAlpha;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(listBackground.gameObject, 0.15f, mBackgroundAlpha, 0f);
		tweenAlpha.delay = duration - 0.15f;
		listBackground.transform.localScale = listBackground.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(listBackground.gameObject, duration, listBackground.transform.localScale.ReplaceY(val), listBackground.transform.localScale.ReplaceY(108f));
		tweenScale.onFinished = delegate
		{
			mAnimating = false;
			for (int i = 0; i < records.Length; i++)
			{
				records[i].SetHide();
			}
			listBackground.gameObject.SetActive(value: false);
		};
		rollOutList.gameObject.SetActive(value: true);
		rollOutList.alpha = 0f;
		tweenAlpha = TweenAlpha.Begin(rollOutList.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.delay = duration - 0.3f;
		tweenAlpha.onFinished = null;
		hideList.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.Begin(hideList, 0.3f, Vector3.forward, 0f, 360f);
		hideListSprites[0].alpha = 1f;
		hideListSprites[1].alpha = 1f;
		tweenAlpha = TweenAlpha.Begin(hideListSprites[0].gameObject, 0.3f, 1f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha.onFinished = delegate
		{
			hideList.SetActive(value: false);
		};
		tweenAlpha = TweenAlpha.Begin(hideListSprites[1].gameObject, 0.3f, 1f, 0f);
		tweenAlpha.delay = 0f;
		for (int num = 0; num < records.Length; num++)
		{
			records[num].SetOpened();
		}
	}

	private void InstaHide()
	{
		mOpened = false;
		mAnimating = false;
		TweenAlpha component = listBackground.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = listBackground.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		listBackground.gameObject.SetActive(value: false);
		component = rollOutList.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		rollOutList.gameObject.SetActive(value: true);
		rollOutList.alpha = 1f;
		component = hideListSprites[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = hideListSprites[1].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenRotationSpecial component3 = hideList.GetComponent<TweenRotationSpecial>();
		if (component3 != null)
		{
			component3.enabled = false;
		}
		hideList.transform.localRotation = default(Quaternion);
		hideListSprites[0].alpha = 0f;
		hideListSprites[1].alpha = 0f;
		hideList.SetActive(value: false);
		for (int i = 0; i < records.Length; i++)
		{
			records[i].SetHide();
		}
	}

	protected void Update()
	{
		if (mAnimating)
		{
			float y = listBackground.transform.localScale.y;
			for (int i = 0; i < records.Length; i++)
			{
				float num = 108f + (float)i * 142f;
				float max = num + 134f;
				float num2 = Mathf.Clamp(y, num, max);
				records[i].SetPosition(134f - (num2 - num));
			}
		}
	}
}
