using UnityEngine;

public class ArenaPhaseContent : Core_BaseScript
{
	public UISprite[] phases;

	public UISprite phaseArrow;

	public UILabel phaseLabel;

	private float mPhaseLength;

	private float mInterval;

	private float mBackgroundWidth => 720f;

	public void SetPhases(int count)
	{
		switch (count)
		{
		case 1:
			phases[0].gameObject.SetActive(value: true);
			phases[0].transform.localScale = phases[0].transform.localScale.ReplaceX(mBackgroundWidth);
			mPhaseLength = mBackgroundWidth;
			return;
		case 0:
			return;
		}
		mPhaseLength = mBackgroundWidth / ((float)count + (float)(count - 1) * 0.75f);
		mInterval = (mBackgroundWidth - mPhaseLength) / (float)(count - 1);
		for (int i = 0; i < count; i++)
		{
			phases[i].gameObject.SetActive(value: true);
			phases[i].transform.localPosition = phases[i].transform.localPosition.ReplaceX(mInterval * (float)i);
			phases[i].transform.localScale = phases[i].transform.localScale.ReplaceX(mPhaseLength);
		}
	}

	public void ResetPhases()
	{
		phaseLabel.gameObject.SetActive(value: true);
		phaseArrow.gameObject.SetActive(value: true);
		UISprite[] array = phases;
		foreach (UISprite uISprite in array)
		{
			uISprite.gameObject.SetActive(value: false);
			uISprite.color = new Color(0.7f, 0.7f, 0.7f, 0.5f);
		}
	}

	public void ActivePhase(int index)
	{
		UISprite[] array = phases;
		foreach (UISprite uISprite in array)
		{
			uISprite.color = new Color(0.7f, 0.7f, 0.7f, 0.5f);
		}
		if (index > 0)
		{
			phaseLabel.text = Localization.LocalizeFormat("ID_PHASEX", index);
			float num = ((!WarArena.instance.warArenaConfig.currentWindow.isActive) ? (mInterval * 0.5f) : 0f);
			float val = mInterval * (float)(index - 1) + mPhaseLength * 0.5f + num;
			phaseLabel.transform.localPosition = phaseLabel.transform.localPosition.ReplaceX(val);
			phaseArrow.transform.localPosition = phaseArrow.transform.localPosition.ReplaceX(val);
			phaseLabel.gameObject.SetActive(WarArena.instance.warArenaConfig.currentWindow.isActive);
			if (WarArena.instance.warArenaConfig.currentWindow.isActive)
			{
				phases[index - 1].color = new Color(1f, 1f, 1f, 1f);
			}
		}
		else
		{
			phaseLabel.gameObject.SetActive(value: false);
			phaseArrow.gameObject.SetActive(value: false);
		}
	}
}
