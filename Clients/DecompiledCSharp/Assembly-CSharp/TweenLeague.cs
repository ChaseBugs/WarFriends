using UnityEngine;

public class TweenLeague : UITweener
{
	public LeagueArcData from;

	public LeagueArcData to;

	private LeagueArcGuiElement mLeagueArc;

	private void Awake()
	{
		if (mLeagueArc == null)
		{
			mLeagueArc = GetComponent<LeagueArcGuiElement>();
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		int playerPosition = (int)Mathf.Lerp(from.position, to.position, factor);
		int num = (int)Mathf.Lerp(from.leagueMedals, to.leagueMedals, factor);
		mLeagueArc.SetArrow(playerPosition, from.numberOfPlayers, from.league);
		mLeagueArc.SetGlow(playerPosition, from.numberOfPlayers, from.league, animate: true);
		mLeagueArc.currentMedals.text = MiscTools.FormatBigNumber(num);
		if (isFinished)
		{
			mLeagueArc.medalsTable.repositionNow = true;
		}
		if (from.hasPromote)
		{
			int num2 = (int)Mathf.Lerp(from.promoteMedals, to.promoteMedals, factor);
			mLeagueArc.promoteMedals.text = MiscTools.FormatBigNumber(num2);
		}
		if (from.hasDemote)
		{
			int num3 = (int)Mathf.Lerp(from.demoteMedals, to.demoteMedals, factor);
			mLeagueArc.promoteMedals.text = MiscTools.FormatBigNumber(num3);
		}
	}

	public static TweenLeague Begin(LeagueArcGuiElement leagueArc, float duration, LeagueArcData fromData, LeagueArcData toData)
	{
		TweenLeague tweenLeague = UITweener.Begin<TweenLeague>(leagueArc.gameObject, duration);
		tweenLeague.from = fromData;
		tweenLeague.to = toData;
		tweenLeague.mLeagueArc = leagueArc;
		if (duration <= 0f)
		{
			tweenLeague.Sample(1f, isFinished: true);
			tweenLeague.enabled = false;
		}
		return tweenLeague;
	}
}
