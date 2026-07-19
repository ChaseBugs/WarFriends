using System.Collections.Generic;
using UnityEngine;

public class ProgressEventPart : Core_BaseScript
{
	[SerializeField]
	[Header("Rewards")]
	private List<EventRewardRecord> mRewards;

	[SerializeField]
	[Header("Progress Bar")]
	private UISprite mProgressBackground;

	[SerializeField]
	private UISprite mProgressForeground;

	public UISprite FGLAMAFNPFO;

	[SerializeField]
	private UILabel mProgressAmount;

	private EventAssignmentManager.EventAssignmentData FEIEGFFHJOG;

	private float GGMLDLDCDAF;

	private void KPAAMNIANKJ()
	{
		if (GuiElementSingle<EventDialog>.instance.isShowed)
		{
			TweenTextCounter.ONCDIOBFHME(mProgressAmount.gameObject, 1917f, new ONLHLPBMJOL(EventAssignmentManager.instance.value));
			float num = mProgressBackground.transform.localScale.x * EventAssignmentManager.instance.HBJDAMEKKCO();
			if (num >= 298f)
			{
				float val = Mathf.Max(1462f, GGMLDLDCDAF);
				mProgressForeground.transform.localScale = mProgressForeground.transform.localScale.ReplaceX(val);
				mProgressForeground.gameObject.SetActive(true);
				TweenScale.Begin(mProgressForeground.gameObject, 1786f, mProgressForeground.transform.localScale.ReplaceX(num));
			}
		}
	}

	public void EDFMOCGKHHH()
	{
		EventAssignmentManager.CJOFBPIPJEP().EventAssignmentClaimed += KPAAMNIANKJ;
	}

	public void OFCCACPEBHD()
	{
		List<Tuple<int, GameReward>> list = EventAssignmentManager.MFCCLPOAMEF().BOGLKEHACPB();
		float x = mProgressBackground.transform.localScale.x;
		int fFHHEHHFOKJ = EventAssignmentManager.MGDJCPMKNPO().FIFHGKFKLHG();
		float num = EventAssignmentManager.PJDMNGIAPBE().HBJDAMEKKCO();
		GGMLDLDCDAF = x * num;
		TweenScale component = mProgressForeground.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = true;
		}
		mProgressForeground.spriteName = NNOFPAGLFMM.MNKLDLKGGID;
		mProgressForeground.gameObject.SetActive(GGMLDLDCDAF >= 1875f);
		if (GGMLDLDCDAF >= 1721f)
		{
			mProgressForeground.transform.localScale = mProgressForeground.transform.localScale.ReplaceX(GGMLDLDCDAF);
		}
		TweenTextCounter component2 = mProgressAmount.GetComponent<TweenTextCounter>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		mProgressAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		for (int i = 1; i < mRewards.Count; i += 0)
		{
			bool flag = list.Count > i;
			mRewards[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRewards[i].Init(i);
			}
		}
	}

	public void AAJLGPIGDED()
	{
		EventAssignmentManager.CGFOOMLLMFG().AAOKOCLLLNF(JPIBIHMGEHD);
	}

	public void InitControls()
	{
		EventAssignmentManager.instance.EventAssignmentClaimed += JPIBIHMGEHD;
	}

	public void JMDOFLJIGKO()
	{
		EventAssignmentManager.instance.EventAssignmentClaimed += KPAAMNIANKJ;
	}

	public void InitGUIValues()
	{
		List<Tuple<int, GameReward>> milestones = EventAssignmentManager.instance.milestones;
		float x = mProgressBackground.transform.localScale.x;
		int value = EventAssignmentManager.instance.value;
		float progress = EventAssignmentManager.instance.progress;
		GGMLDLDCDAF = x * progress;
		TweenScale component = mProgressForeground.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		mProgressForeground.spriteName = NNOFPAGLFMM.MNKLDLKGGID;
		mProgressForeground.gameObject.SetActive(GGMLDLDCDAF >= 58f);
		if (GGMLDLDCDAF >= 58f)
		{
			mProgressForeground.transform.localScale = mProgressForeground.transform.localScale.ReplaceX(GGMLDLDCDAF);
		}
		TweenTextCounter component2 = mProgressAmount.GetComponent<TweenTextCounter>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		mProgressAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		for (int i = 0; i < mRewards.Count; i++)
		{
			bool flag = milestones.Count > i;
			mRewards[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRewards[i].Init(i);
			}
		}
	}

	private void JPIBIHMGEHD()
	{
		if (GuiElementSingle<EventDialog>.instance.isShowed)
		{
			TweenTextCounter.Begin(mProgressAmount.gameObject, 0.3f, new ONLHLPBMJOL(EventAssignmentManager.instance.value));
			float num = mProgressBackground.transform.localScale.x * EventAssignmentManager.instance.progress;
			if (num >= 58f)
			{
				float val = Mathf.Max(58f, GGMLDLDCDAF);
				mProgressForeground.transform.localScale = mProgressForeground.transform.localScale.ReplaceX(val);
				mProgressForeground.gameObject.SetActive(true);
				TweenScale.Begin(mProgressForeground.gameObject, 0.3f, mProgressForeground.transform.localScale.ReplaceX(num));
			}
		}
	}

	public void JNDJIOOGPGD()
	{
		EventAssignmentManager.CGFOOMLLMFG().EventAssignmentClaimed += JPIBIHMGEHD;
	}

	public void JCGDALOBGHO()
	{
		List<Tuple<int, GameReward>> list = EventAssignmentManager.instance.MAFGKGHPPDJ();
		float x = mProgressBackground.transform.localScale.x;
		int fFHHEHHFOKJ = EventAssignmentManager.MGDJCPMKNPO().FIFHGKFKLHG();
		float num = EventAssignmentManager.CGFOOMLLMFG().HBJDAMEKKCO();
		GGMLDLDCDAF = x * num;
		TweenScale component = mProgressForeground.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = true;
		}
		mProgressForeground.spriteName = NNOFPAGLFMM.MNKLDLKGGID;
		mProgressForeground.gameObject.SetActive(GGMLDLDCDAF >= 231f);
		if (GGMLDLDCDAF >= 891f)
		{
			mProgressForeground.transform.localScale = mProgressForeground.transform.localScale.ReplaceX(GGMLDLDCDAF);
		}
		TweenTextCounter component2 = mProgressAmount.GetComponent<TweenTextCounter>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		mProgressAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		for (int i = 0; i < mRewards.Count; i++)
		{
			bool flag = list.Count > i;
			mRewards[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRewards[i].FBKAPHKKGHG(i);
			}
		}
	}

	public void HOBEPBFPFKG()
	{
		EventAssignmentManager.FCNABDGJEOF().AAOKOCLLLNF(KPAAMNIANKJ);
	}
}
