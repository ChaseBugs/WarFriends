using UnityEngine;

public class PingShower : MonoBehaviour
{
	private const int mLimitGood = 100;

	private const int mLimitMiddle = 300;

	[Header("Bad Ping Icon")]
	public GameObject badPingIndicator;

	[Header("Ping Color Rectangle")]
	public UIWidget item;

	public Color goodColor;

	public Color middleColor;

	public Color badColor;

	private TweenAlpha badPingIndicatorAlphaTween;

	private bool mLastIsBad;

	private int mPing;

	private void OnEnable()
	{
		mLastIsBad = false;
		badPingIndicator.SetActive(value: false);
		mPing = 100;
	}

	private void Update()
	{
		bool flag = false;
		int ping = PhotonNetwork.GetPing();
		if (Singleton<GameController>.instance.isTutorial || Singleton<GameController>.instance.isCampaign || Singleton<GameController>.instance.isCampaignBot)
		{
			item.color = Colours.whiteTransparent;
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			mPing = Random.Range(-2, 2);
			mPing = Mathf.Clamp(mPing, 50, 150);
			ping = mPing;
		}
		if (ping < 100)
		{
			item.color = goodColor;
		}
		else if (ping < 300)
		{
			item.color = middleColor;
		}
		else
		{
			item.color = badColor;
			flag = true;
		}
		if (mLastIsBad != flag)
		{
			badPingIndicator.SetActive(flag);
			if (flag)
			{
				badPingIndicatorAlphaTween = TweenAlpha.Begin(badPingIndicator, 1f, 0f, 1f);
				badPingIndicatorAlphaTween.style = UITweener.Style.PingPong;
				badPingIndicatorAlphaTween.method = UITweener.Method.EaseOut;
				badPingIndicatorAlphaTween.alpha = 0f;
			}
		}
		mLastIsBad = flag;
	}
}
