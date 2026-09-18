using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionDealsItem : MonoBehaviour
{
	[Serializable]
	public class WidgetAlpha
	{
		public GameObject element;

		public float alpha = 1f;
	}

	[Header("Core")]
	public List<WidgetAlpha> widgets;

	public float showTime = 3f;

	public Color topBackgroundColor;

	public float backgroundAlpha = 0.5f;

	protected float mShowTimeEnd;

	public virtual bool hasMoreLooks => false;

	public virtual bool isLastLook => true;

	public virtual void InitEvents()
	{
	}

	public virtual void InitControls()
	{
	}

	public virtual void InitGuiValues()
	{
	}

	public virtual bool IsAvailable()
	{
		return true;
	}

	public virtual IEnumerator Hide(float time)
	{
		foreach (WidgetAlpha widget in widgets)
		{
			TweenAlpha.Begin(widget.element, time, 0f);
		}
		yield return new WaitForSeconds(time);
	}

	public virtual IEnumerator Show(float time)
	{
		foreach (WidgetAlpha widget in widgets)
		{
			TweenAlpha.Begin(widget.element, time, widget.alpha);
		}
		TweenColorSpecial.Begin(GuiScreenSingle<MainScreen>.instance.dealsOnRight.headerBackground.gameObject, time, topBackgroundColor);
		TweenColorSpecial.Begin(GuiScreenSingle<MainScreen>.instance.dealsOnRight.headerCorner.gameObject, time, topBackgroundColor);
		TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.dealsOnRight.background.gameObject, time, backgroundAlpha);
		yield return new WaitForSeconds(time);
		mShowTimeEnd = TimeManager.realTimeWithoutPauses + showTime;
	}

	public bool IsShowTime()
	{
		return TimeManager.realTimeWithoutPauses < mShowTimeEnd;
	}

	protected void SetShowTimeEnd(float endIn)
	{
		mShowTimeEnd = TimeManager.realTimeWithoutPauses + endIn;
	}

	public virtual IEnumerator Change(float time)
	{
		mShowTimeEnd = TimeManager.realTimeWithoutPauses + time * 2f;
		yield return StartCoroutine(Hide(time));
		yield return StartCoroutine(Show(time));
	}
}
