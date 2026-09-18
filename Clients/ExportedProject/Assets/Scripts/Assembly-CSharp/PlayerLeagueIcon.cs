using UnityEngine;

public class PlayerLeagueIcon : PoolableObject
{
	[Header("Core")]
	public UITexture leagueTexture;

	public UISprite[] arrows;

	private bool mIsBeginners;

	private int mBeginners;

	private League mLeague;

	public void InitializeLeague(League league, bool highlight)
	{
		mIsBeginners = false;
		mLeague = league;
		leagueTexture.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.leagueNames[league].Value2);
		SetArrows();
		Highlight(highlight);
	}

	public void InitializeBeginners(int beginners, bool highlight)
	{
		mIsBeginners = true;
		mBeginners = beginners;
		leagueTexture.mainTexture = Resources.Load<Texture>("Medals/" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginners));
		SetArrows();
		Highlight(highlight);
	}

	public void OnClick()
	{
		GuiScreenSingle<LeaguesScreen>.instance.league.leftContent.SelectIcon(mIsBeginners, mBeginners, mLeague, align: true);
		Highlight(highlight: true, animate: true);
	}

	public void Highlight(bool highlight, bool animate = false)
	{
		float x = leagueTexture.transform.localScale.x;
		float num = ((!highlight) ? 156f : 196f);
		if (animate && x != num)
		{
			TweenColor.Begin(leagueTexture.gameObject, 0.2f, (!highlight) ? Color.white.ReplaceA(0.7f) : Color.white);
			TweenScale.Begin(leagueTexture.gameObject, 0.2f, leagueTexture.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = leagueTexture.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = leagueTexture.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		leagueTexture.color = ((!highlight) ? Color.white.ReplaceA(0.7f) : Color.white);
		leagueTexture.transform.localScale = leagueTexture.transform.localScale.ReplaceXY(num, num);
	}

	private void SetArrows()
	{
		int num = 0;
		num = (mIsBeginners ? ((mBeginners != 3) ? 1 : 2) : ((mLeague == League.Bronze3) ? ((!GameLoginManager.currentPlayer.isInBeginnersLeague) ? 1 : 0) : ((mLeague != League.Champion) ? ((mLeague != League.Bronze1 && mLeague != League.Silver1 && mLeague != League.Gold1 && mLeague != League.Elite1 && mLeague != League.Master1) ? 1 : 2) : 0)));
		arrows[0].gameObject.SetActive(num > 0);
		arrows[0].transform.localPosition = arrows[0].transform.localPosition.ReplaceX((num <= 1) ? 86f : 81f);
		arrows[1].gameObject.SetActive(num > 1);
	}

	public override void DestroyPooled()
	{
		leagueTexture.mainTexture = null;
		base.DestroyPooled();
	}
}
