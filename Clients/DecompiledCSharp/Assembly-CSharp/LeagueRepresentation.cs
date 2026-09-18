using System.Collections.Generic;
using UnityEngine;

public class LeagueRepresentation : Core_BaseScript
{
	[Header("Core")]
	public UISprite background;

	[Header("Top Part")]
	public GameObject topAnchor;

	public UITexture leagueIcon;

	public GameObject leagueInfo;

	public UILabel leagueName;

	public UILabel leagueMinMedals;

	[Header("Bottom Part")]
	public UISprite border;

	public UIGrid bottomGrid;

	public GameObject warbucksRewardPart;

	public UILabel warbucksRewardLabel;

	public GameObject squadPointsRewardPart;

	public UILabel squadPointsRewardLabel;

	private float mMinHeight = 476f;

	public static Dictionary<League, Color> leagueColours = new Dictionary<League, Color>
	{
		{
			League.NoLeague,
			Colours.whiteTransparent
		},
		{
			League.Bronze3,
			Colours.bronzeLeague
		},
		{
			League.Bronze2,
			Colours.bronzeLeague
		},
		{
			League.Bronze1,
			Colours.bronzeLeague
		},
		{
			League.Silver3,
			Colours.silverLeague
		},
		{
			League.Silver2,
			Colours.silverLeague
		},
		{
			League.Silver1,
			Colours.silverLeague
		},
		{
			League.Gold3,
			Colours.goldLeague
		},
		{
			League.Gold2,
			Colours.goldLeague
		},
		{
			League.Gold1,
			Colours.goldLeague
		},
		{
			League.Elite3,
			Colours.eliteLeague
		},
		{
			League.Elite2,
			Colours.eliteLeague
		},
		{
			League.Elite1,
			Colours.eliteLeague
		},
		{
			League.Master3,
			Colours.masterLeague
		},
		{
			League.Master2,
			Colours.masterLeague
		},
		{
			League.Master1,
			Colours.masterLeague
		},
		{
			League.Champion,
			Colours.championLeague
		}
	};

	public static Dictionary<League, Tuple<Vector3, Vector3, float>> leaguePositions = new Dictionary<League, Tuple<Vector3, Vector3, float>>
	{
		{
			League.NoLeague,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 0f)
		},
		{
			League.Bronze3,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 0f)
		},
		{
			League.Bronze2,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 0f)
		},
		{
			League.Bronze1,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 0f)
		},
		{
			League.Silver3,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 10f)
		},
		{
			League.Silver2,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 10f)
		},
		{
			League.Silver1,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 10f)
		},
		{
			League.Gold3,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 27f)
		},
		{
			League.Gold2,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 27f)
		},
		{
			League.Gold1,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 27f)
		},
		{
			League.Elite3,
			new Tuple<Vector3, Vector3, float>(new Vector3(320f, 320f, 1f), new Vector3(0f, -174f, 0f), 29f)
		},
		{
			League.Elite2,
			new Tuple<Vector3, Vector3, float>(new Vector3(320f, 320f, 1f), new Vector3(0f, -174f, 0f), 29f)
		},
		{
			League.Elite1,
			new Tuple<Vector3, Vector3, float>(new Vector3(320f, 320f, 1f), new Vector3(0f, -174f, 0f), 29f)
		},
		{
			League.Master3,
			new Tuple<Vector3, Vector3, float>(new Vector3(316f, 316f, 1f), new Vector3(0f, -178f, 0f), 35f)
		},
		{
			League.Master2,
			new Tuple<Vector3, Vector3, float>(new Vector3(316f, 316f, 1f), new Vector3(0f, -178f, 0f), 35f)
		},
		{
			League.Master1,
			new Tuple<Vector3, Vector3, float>(new Vector3(316f, 316f, 1f), new Vector3(0f, -178f, 0f), 35f)
		},
		{
			League.Champion,
			new Tuple<Vector3, Vector3, float>(new Vector3(361f, 361f, 1f), new Vector3(0f, -178f, 0f), 41f)
		}
	};

	public void Initialization(League league, float maxHeight)
	{
		if (maxHeight < mMinHeight)
		{
			maxHeight = mMinHeight;
		}
		float num = mMinHeight + (maxHeight - mMinHeight) * Singleton<GameVariables>.instance.LeagueProgress(league);
		background.transform.localScale = new Vector3(background.transform.localScale.x, num, 1f);
		topAnchor.transform.localPosition = new Vector3(topAnchor.transform.localScale.x, num - leaguePositions[league].Value3, topAnchor.transform.localScale.z);
		background.color = leagueColours[league];
		leagueInfo.transform.localPosition = leaguePositions[league].Value2;
		leagueIcon.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.leagueNames[league].Value2);
		leagueIcon.transform.localScale = leaguePositions[league].Value1;
		leagueName.text = GameVariables.leagueNames[league].Value1;
		leagueMinMedals.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(league);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(league);
		int num4 = MiscTools.Sign(num2) + MiscTools.Sign(num3);
		float num5 = (float)num4 * 60f;
		float y = num5 + 48f;
		float y2 = num5 + 78f;
		border.transform.localScale = new Vector3(border.transform.localScale.x, y2, 1f);
		border.color = ((league != League.Champion) ? Colours.whiteGray : Colours.goldChampion);
		bottomGrid.transform.localPosition = new Vector3(bottomGrid.transform.localPosition.x, y, bottomGrid.transform.localPosition.z);
		bottomGrid.repositionNow = true;
		warbucksRewardPart.SetActive(num2 > 0);
		warbucksRewardLabel.text = $"+{MiscTools.FormatBigNumber(num2)}";
		squadPointsRewardPart.SetActive(num3 > 0);
		squadPointsRewardLabel.text = $"+{MiscTools.FormatBigNumber(num3)}";
	}
}
