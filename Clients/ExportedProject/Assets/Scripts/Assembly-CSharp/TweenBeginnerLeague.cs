using UnityEngine;

public class TweenBeginnerLeague : UITweener
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
		int beginnersPosition = (int)Mathf.Lerp(from.position, to.position, factor);
		int num = (int)Mathf.Lerp(from.leagueMedals, to.leagueMedals, factor);
		mLeagueArc.SetBeginnersPosition(beginnersPosition);
		mLeagueArc.HideGlow();
		mLeagueArc.currentMedals.text = MiscTools.FormatBigNumber(num);
		if (isFinished)
		{
			mLeagueArc.medalsTable.repositionNow = true;
		}
	}

	public static TweenBeginnerLeague Begin(LeagueArcGuiElement leagueArc, float duration, LeagueArcData fromData, LeagueArcData toData)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(leagueArc.gameObject, duration);
		tweenBeginnerLeague.from = fromData;
		tweenBeginnerLeague.to = toData;
		tweenBeginnerLeague.mLeagueArc = leagueArc;
		if (duration <= 0f)
		{
			tweenBeginnerLeague.Sample(1f, isFinished: true);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}
}
