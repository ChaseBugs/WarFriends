using System;
using System.Collections.Generic;
using Google2u;
using Prime31;
using UnityEngine;

public class Tweetmanager : Singleton<Tweetmanager>
{
	public const int followGold = 10;

	public const int likeGold = 10;

	private string connectionError = "Some error occurred. Please, try again later.";

	private string followingTitle = "OOOOPS";

	private string followingText = "You are already our follower, thank you! That's great, isn’t it?";

	private string followingButton = "IT IS";

	private string gainCreditsTitle = "HAVE A NICE DAY";

	private string gainCreditsText = "Thanks you for the following. Here are those well deserved {0} gold bars.";

	private string gainCreditsButton = "THANK YOU";

	private string rewardedBeforeTitle = "OOOOPS";

	private string rewardedBeforeText = "Thank you for the following. Once again.";

	private string rewardedBeforeButton = "OK";

	public string consumerKey = "aYxLQ40XpBYemQhnRYMJg3VBd";

	public string consumerSecret = "nR8WfJlIwkkqu9mTB81EUGaldBpyX3eE4ErTYxs41gs6uXM51v";

	public long ownerID = 494445715L;

	private string mStatus;

	private bool mSendStatus;

	private bool tryTweet;

	private Dictionary<string, string> twParam = new Dictionary<string, string>();

	public bool isLogedIn => true;

	public static event Action TweetFinished;

	public static event Action RequestFinish;

	private new void Start()
	{
		followingTitle = Localization.Localize("ID_TWITTER_FOLLOWING_TITLE");
		followingText = Localization.Localize("ID_TWITTER_FOLLOWING_TEXT");
		followingButton = Localization.Localize("ID_TWITTER_FOLLOWING_BUTTON");
		gainCreditsTitle = Localization.Localize("ID_TWITTER_GAIN_TITLE");
		gainCreditsText = Localization.Localize("ID_TWITTER_GAIN_TEXT");
		gainCreditsButton = Localization.Localize("ID_TWITTER_GAIN_BUTTON");
		rewardedBeforeTitle = Localization.Localize("ID_TWITTER_GAIN_AGAIN_TITLE");
		rewardedBeforeText = Localization.Localize("ID_TWITTER_GAIN_AGAIN_TEXT");
		rewardedBeforeButton = Localization.Localize("ID_OK");
		TwitterManager.requestDidFinishEvent += OnRequestFinish;
	}

	private void OnRequestFinish(object obj)
	{
		if (Tweetmanager.RequestFinish != null)
		{
			Tweetmanager.RequestFinish();
		}
	}

	private void checkFollow()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("target_id", ownerID.ToString());
		dictionary.Add("source_id", string.Empty);
	}

	public void likeUsOnFacebook()
	{
		Application.OpenURL("https://www.facebook.com/warfriendsgame/");
	}

	public void FollowAs()
	{
		Application.OpenURL("https://twitter.com/WarFriendsGame");
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).DBKEY;
		Singleton<BeanstalkServerManager>.instance.AddOneTimeReward(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
	}

	private bool TwitterRewarded()
	{
		return PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.TwitterFollow);
	}

	private void RewardTwitter()
	{
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).DBKEY;
		Singleton<BeanstalkServerManager>.instance.AddOneTimeReward(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
	}
}
