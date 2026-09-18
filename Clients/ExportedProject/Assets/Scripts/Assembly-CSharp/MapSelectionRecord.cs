using UnityEngine;

public class MapSelectionRecord : Core_BaseScript
{
	[Header("Core")]
	public UIPanel panel;

	public BoxCollider mapCollider;

	public GameObject mapAnimationParent;

	[Header("Look")]
	public UISprite mapIconSprite;

	public GameObject mapRandom;

	public UILabel mapNameLabel;

	public UISprite highlight;

	[Header("Locked")]
	public GameObject lockedPart;

	public UILabel lockedLevel;

	[Header("Animation")]
	public UISprite animationHighlight;

	public UISprite animationOverlay;

	private MapManager.MapEntry mData;

	public void InitializeMap(MapManager.MapEntry mapData)
	{
		mData = mapData;
		bool flag = mapData == null;
		mapIconSprite.gameObject.SetActive(!flag);
		mapRandom.SetActive(flag);
		if (!flag)
		{
			mapIconSprite.spriteName = mapData.iconName;
		}
		mapNameLabel.text = ((!flag) ? mapData.guiName : Localization.Localize("ID_RANDOMMAP"));
		lockedLevel.text = ((!flag) ? MiscTools.FormatBigNumber(mapData.unlockLevel) : string.Empty);
	}

	public void UpdateGui()
	{
		bool active = mData != null && mData.unlockLevel > LevelManager.instance.currentLevel.displayNumber;
		lockedPart.SetActive(active);
	}

	public void Selected(bool selected, bool animating = false)
	{
		if (animating)
		{
			Vector3 vector = new Vector3(366f, 134f, 1f);
			Vector3 vector2 = new Vector3(vector.x * 1.3f, vector.y * 1.05f, vector.z);
			TweenColor.Begin(mapNameLabel.gameObject, 0.15f, (!selected) ? Color.white : Colours.blue);
			if (selected)
			{
				TweenAlpha.Begin(animationHighlight.gameObject, 0.15f, 1f);
				animationHighlight.transform.localScale = vector2;
				TweenScale tweenScale = TweenScale.Begin(animationHighlight.gameObject, 0.3f, vector2, vector);
				tweenScale.onFinished = delegate
				{
					highlight.gameObject.SetActive(value: true);
					TweenAlpha component3 = animationHighlight.GetComponent<TweenAlpha>();
					if (component3 != null)
					{
						component3.enabled = false;
					}
					animationHighlight.alpha = 0f;
				};
				TweenAlpha.Begin(animationOverlay.gameObject, 0.15f, 0.6f, 0f);
			}
			else
			{
				highlight.gameObject.SetActive(value: false);
				animationHighlight.alpha = 1f;
				animationHighlight.transform.localScale = vector;
				TweenAlpha.Begin(animationHighlight.gameObject, 0.15f, 1f, 0f);
				TweenAlpha.Begin(animationOverlay.gameObject, 0.15f, 0f);
				TweenScale tweenScale2 = TweenScale.Begin(animationHighlight.gameObject, 0.3f, vector, vector2);
				tweenScale2.onFinished = null;
			}
		}
		else
		{
			TweenColor component = mapNameLabel.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			highlight.gameObject.SetActive(selected);
			mapNameLabel.color = ((!selected) ? Color.white : Colours.blue);
			TweenAlpha component2 = animationHighlight.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			component2 = animationOverlay.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			animationHighlight.alpha = 0f;
			animationOverlay.alpha = 0f;
		}
	}

	public MapManager.MapEntry GetMap()
	{
		return mData;
	}

	public void SetHide()
	{
		mapAnimationParent.transform.localPosition = mapAnimationParent.transform.localPosition.ReplaceY(136f);
	}

	public void SetOpened()
	{
		mapAnimationParent.transform.localPosition = mapAnimationParent.transform.localPosition.ReplaceY(0f);
	}

	public void SetPosition(float posY)
	{
		posY = Mathf.Clamp(posY, 0f, 136f);
		mapAnimationParent.transform.localPosition = mapAnimationParent.transform.localPosition.ReplaceY(posY);
	}
}
