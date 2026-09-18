using System.Collections.Generic;
using UnityEngine;

public class CardIconIndicator : Core_BaseScript
{
	public class HudIcoInfo
	{
		private string icoName;

		private float duration;

		private float timeToFinish;

		private bool anim;

		public HudIcoInfo(string name, float time, bool animate, float fullTime)
		{
			icoName = name;
			duration = fullTime;
			timeToFinish = time;
			anim = animate;
		}

		public bool Update(HudObjectIndicator hudObjectIndicator, float deltaTime)
		{
			timeToFinish -= deltaTime;
			bool flag = timeToFinish <= 0f;
			if (flag)
			{
				hudObjectIndicator.Show(icoName, value: false, HudObjectIndicator.IndicatorAnimation.CardIco);
			}
			else if (anim)
			{
				hudObjectIndicator.SetProgress(icoName, timeToFinish / duration);
			}
			return flag;
		}
	}

	public HudObjectIndicator hudObjectIndicator;

	private PhotonView mPhotonView;

	private List<HudIcoInfo> hudIcons = new List<HudIcoInfo>();

	private int mSyncTime;

	private void OnEnable()
	{
		hudIcons.Clear();
	}

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
	}

	protected void Update()
	{
		int num = 0;
		while (num < hudIcons.Count)
		{
			if (hudIcons[num].Update(hudObjectIndicator, Time.deltaTime))
			{
				if (num != hudIcons.Count - 1)
				{
					HudIcoInfo value = hudIcons[hudIcons.Count - 1];
					hudIcons[hudIcons.Count - 1] = hudIcons[num];
					hudIcons[num] = value;
				}
				hudIcons.RemoveAt(hudIcons.Count - 1);
			}
			else
			{
				num++;
			}
		}
	}

	public void UpdateIndicator(string iconName, float fract)
	{
		if (!(hudObjectIndicator == null))
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (mSyncTime != (int)realtimeSinceStartup)
			{
				mSyncTime = (int)realtimeSinceStartup;
				int num = hudObjectIndicator.SetProgress(iconName, fract);
				mPhotonView.RPC("UpdateIndicatorRPC", PhotonTargets.Others, num, fract);
			}
		}
	}

	[PunRPC]
	public void UpdateIndicatorRPC(int iconId, float fract)
	{
		hudObjectIndicator.SetProgress(hudObjectIndicator.ConvertSpriteIDtoSpriteName(iconId), fract);
	}

	public void Show(string iconName, bool show, bool local = false)
	{
		if (!(hudObjectIndicator == null))
		{
			int num = hudObjectIndicator.Show(iconName, show, HudObjectIndicator.IndicatorAnimation.CardIco);
			if (!local)
			{
				mPhotonView.RPC("Show2RPC", PhotonTargets.Others, num, show);
			}
		}
	}

	[PunRPC]
	public void Show2RPC(int iconId, bool show)
	{
		hudObjectIndicator.Show(hudObjectIndicator.ConvertSpriteIDtoSpriteName(iconId), show, HudObjectIndicator.IndicatorAnimation.CardIco);
	}

	public void Show(string iconName, float duration, float fullDuration, bool animated)
	{
		if (!(hudObjectIndicator == null))
		{
			int num = hudObjectIndicator.Show(iconName, value: true, HudObjectIndicator.IndicatorAnimation.CardIco);
			hudIcons.Add(new HudIcoInfo(iconName, duration, animated, fullDuration));
			mPhotonView.RPC("ShowRPC", PhotonTargets.Others, num, duration, fullDuration, animated);
		}
	}

	[PunRPC]
	public void ShowRPC(int iconId, float duration, float fullDuration, bool animated)
	{
		string spriteName = hudObjectIndicator.ConvertSpriteIDtoSpriteName(iconId);
		hudObjectIndicator.Show(spriteName, value: true, HudObjectIndicator.IndicatorAnimation.CardIco);
		hudIcons.Add(new HudIcoInfo(spriteName, duration, animated, fullDuration));
	}
}
