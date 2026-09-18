using System.Collections.Generic;
using UnityEngine;

public class TutorialProgressShower : Singleton<TutorialProgressShower>
{
	public List<TutorialCheckBox> checkBoxes;

	public UILabel title;

	public UISprite titleBG;

	private UIPanel panel;

	private float bigStepX = 115f;

	private float bigY = -160f;

	private float smallStepX = 35f;

	private float smallY = -80f;

	private bool mShowed;

	protected override void Awake()
	{
		base.Awake();
		base.gameObject.SetActive(value: false);
		panel = GetComponent<UIPanel>();
	}

	public void Show(string titleText, int numCheckBoxes)
	{
		title.text = titleText;
		Vector3 localScale = titleBG.cachedTransform.localScale;
		localScale.x = title.relativeSize.x * title.cachedTransform.localScale.x + 100f;
		titleBG.cachedTransform.localScale = localScale;
		while (checkBoxes.Count < numCheckBoxes)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(checkBoxes[0]);
			tutorialCheckBox.transform.parent = checkBoxes[0].transform.parent;
			checkBoxes.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((numCheckBoxes >= 4) ? new Vector3((0f - smallStepX) * (float)(numCheckBoxes - 1), smallY, 0f) : new Vector3((0f - bigStepX) * (float)(numCheckBoxes - 1), bigY, 0f));
		for (int i = 0; i < checkBoxes.Count; i++)
		{
			if (i < numCheckBoxes)
			{
				checkBoxes[i].Clear();
				checkBoxes[i].transform.localPosition = localPosition;
				if (numCheckBoxes < 4)
				{
					checkBoxes[i].ShowBig();
					localPosition.x += bigStepX * 2f;
				}
				else
				{
					checkBoxes[i].ShowSmall();
					localPosition.x += smallStepX * 2f;
				}
			}
			else
			{
				checkBoxes[i].Hide();
			}
		}
		panel.alpha1 = 0f;
		TweenAlpha.Begin(base.gameObject, 0.5f, 1f);
		base.gameObject.SetActive(value: true);
		mShowed = true;
	}

	protected void Update()
	{
		if (mShowed)
		{
			panel.alpha1 = ((!Singleton<SniperScope>.instance.showed) ? 1f : 0.3f);
		}
	}

	public void CheckNum(int index, bool playSound = true)
	{
		if (playSound)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampObjectiveComplete);
		}
		checkBoxes[index].SetChecked();
	}

	public void Hide()
	{
		TweenAlpha.Begin(base.gameObject, 0.25f, 0f).onFinished = delegate
		{
			base.gameObject.SetActive(value: false);
			mShowed = false;
		};
	}

	public void Disable()
	{
		base.gameObject.SetActive(value: false);
		mShowed = false;
	}
}
