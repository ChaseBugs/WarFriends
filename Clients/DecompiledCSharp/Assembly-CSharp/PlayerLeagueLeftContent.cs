using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeagueLeftContent : Core_BaseScript
{
	public enum InfoType
	{
		Positive,
		Negative,
		None,
		Beginners,
		Current
	}

	public class InternalLeague
	{
		public bool isBeginners;

		public int beginners;

		public League league;

		public string name => (!isBeginners) ? $"{(int)(200 + league)} {league.ToString()}" : $"{100 + beginners} Rookie {beginners}";

		public InternalLeague(int beginnersLeague)
		{
			isBeginners = true;
			beginners = beginnersLeague;
		}

		public InternalLeague(League normalLeague)
		{
			isBeginners = false;
			league = normalLeague;
		}

		public bool CompareToData(bool isBeg, int beg, League leag)
		{
			if (isBeg != isBeginners)
			{
				return false;
			}
			return (!isBeg) ? (leag == league) : (beg == beginners);
		}
	}

	[Header("League Info")]
	public UILabel leagueName;

	public UILabel winWarbucksBonus;

	public UILabel winSquadPointsBonus;

	[Header("-League Icons")]
	public PlayerLeagueIcon playerLeagueIconPrefab;

	public UIPanel leagueIconsPanel;

	public UIDraggablePanel leagueIconsDraggablePanel;

	public UIPooledGrid leagueIconsGrid;

	[Header("Motivating Info")]
	public GameObject infoPart;

	public UISprite background;

	public UITable titleTable;

	public UILabel firstPartOfTitle;

	public UISprite iconInTitle;

	public UILabel lastPartOfTitle;

	public UILabel riseVsFallInfoLabel;

	public UILabel infoWarbucksReward;

	public UILabel infoSquadPointsReward;

	private List<InternalLeague> mLeaguesForShow = new List<InternalLeague>();

	private bool mIsBeginnersLeague;

	private League mLeague;

	private int mBeginnersLeague;

	private int mPositivePromotion = 1;

	private InfoType mSavedInfoType = InfoType.None;

	private static Dictionary<League, Tuple<string, string>> mTitleLeague = new Dictionary<League, Tuple<string, string>>
	{
		{
			League.NoLeague,
			new Tuple<string, string>("ID_INBRONZE1", "ID_INBRONZE2")
		},
		{
			League.Bronze3,
			new Tuple<string, string>("ID_INBRONZE1", "ID_INBRONZE2")
		},
		{
			League.Bronze2,
			new Tuple<string, string>("ID_INBRONZE1", "ID_INBRONZE2")
		},
		{
			League.Bronze1,
			new Tuple<string, string>("ID_INBRONZE1", "ID_INBRONZE2")
		},
		{
			League.Silver3,
			new Tuple<string, string>("ID_INSILVER1", "ID_INSILVER2")
		},
		{
			League.Silver2,
			new Tuple<string, string>("ID_INSILVER1", "ID_INSILVER2")
		},
		{
			League.Silver1,
			new Tuple<string, string>("ID_INSILVER1", "ID_INSILVER2")
		},
		{
			League.Gold3,
			new Tuple<string, string>("ID_INGOLD1", "ID_INGOLD2")
		},
		{
			League.Gold2,
			new Tuple<string, string>("ID_INGOLD1", "ID_INGOLD2")
		},
		{
			League.Gold1,
			new Tuple<string, string>("ID_INGOLD1", "ID_INGOLD2")
		},
		{
			League.Elite3,
			new Tuple<string, string>("ID_INELITE1", "ID_INELITE2")
		},
		{
			League.Elite2,
			new Tuple<string, string>("ID_INELITE1", "ID_INELITE2")
		},
		{
			League.Elite1,
			new Tuple<string, string>("ID_INELITE1", "ID_INELITE2")
		},
		{
			League.Master3,
			new Tuple<string, string>("ID_INMASTER1", "ID_INMASTER2")
		},
		{
			League.Master2,
			new Tuple<string, string>("ID_INMASTER1", "ID_INMASTER2")
		},
		{
			League.Master1,
			new Tuple<string, string>("ID_INMASTER1", "ID_INMASTER2")
		},
		{
			League.Champion,
			new Tuple<string, string>("ID_INCHAMPION1", "ID_INCHAMPION2")
		}
	};

	private static Dictionary<League, Tuple<League, League>> mAroundLeagues = new Dictionary<League, Tuple<League, League>>
	{
		{
			League.NoLeague,
			new Tuple<League, League>(League.Bronze3, League.Silver3)
		},
		{
			League.Bronze3,
			new Tuple<League, League>(League.Bronze3, League.Silver3)
		},
		{
			League.Bronze2,
			new Tuple<League, League>(League.Bronze3, League.Silver3)
		},
		{
			League.Bronze1,
			new Tuple<League, League>(League.Bronze2, League.Silver3)
		},
		{
			League.Silver3,
			new Tuple<League, League>(League.Bronze1, League.Gold3)
		},
		{
			League.Silver2,
			new Tuple<League, League>(League.Silver3, League.Gold3)
		},
		{
			League.Silver1,
			new Tuple<League, League>(League.Silver2, League.Gold3)
		},
		{
			League.Gold3,
			new Tuple<League, League>(League.Silver1, League.Elite3)
		},
		{
			League.Gold2,
			new Tuple<League, League>(League.Gold3, League.Elite3)
		},
		{
			League.Gold1,
			new Tuple<League, League>(League.Gold2, League.Elite3)
		},
		{
			League.Elite3,
			new Tuple<League, League>(League.Gold1, League.Master3)
		},
		{
			League.Elite2,
			new Tuple<League, League>(League.Elite3, League.Master3)
		},
		{
			League.Elite1,
			new Tuple<League, League>(League.Elite2, League.Master3)
		},
		{
			League.Master3,
			new Tuple<League, League>(League.Elite1, League.Champion)
		},
		{
			League.Master2,
			new Tuple<League, League>(League.Master3, League.Champion)
		},
		{
			League.Master1,
			new Tuple<League, League>(League.Master2, League.Champion)
		},
		{
			League.Champion,
			new Tuple<League, League>(League.Master1, League.Champion)
		}
	};

	public void SelectIcon(bool isBeginners, int beginners, League league, bool align = false)
	{
		mIsBeginnersLeague = isBeginners;
		mBeginnersLeague = beginners;
		mLeague = league;
		DeselectIcon();
		ShowTopInfoFor();
		SetPromotedPart(InfoType.Current);
		if (align)
		{
			CenterIcon(instant: false);
		}
	}

	public void ShowTopInfoFor()
	{
		if (mIsBeginnersLeague)
		{
			leagueName.text = Localization.LocalizeFormat("ID_LEAGUENAME", Singleton<GameVariables>.instance.BeginnersLeagueName(mBeginnersLeague));
			winWarbucksBonus.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.BeginnersLeagueRewards(mBeginnersLeague, squadPoints: false));
			winSquadPointsBonus.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.BeginnersLeagueRewards(mBeginnersLeague));
		}
		else
		{
			leagueName.text = Localization.LocalizeFormat("ID_LEAGUENAME", GameVariables.leagueNames[mLeague].Value1);
			winWarbucksBonus.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(mLeague));
			winSquadPointsBonus.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(mLeague));
		}
	}

	private void LeagueIconFree(Transform objectTransform)
	{
		if (objectTransform != null)
		{
			PlayerLeagueIcon component = objectTransform.GetComponent<PlayerLeagueIcon>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private Transform LeagueIconInstantiate(int index)
	{
		if (index >= 0 && index < mLeaguesForShow.Count)
		{
			PlayerLeagueIcon playerLeagueIcon = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(playerLeagueIconPrefab, leagueIconsGrid.gameObject, mLeaguesForShow[index].name) as PlayerLeagueIcon;
			if (playerLeagueIcon != null)
			{
				bool highlight = mLeaguesForShow[index].CompareToData(mIsBeginnersLeague, mBeginnersLeague, mLeague);
				if (mLeaguesForShow[index].isBeginners)
				{
					playerLeagueIcon.InitializeBeginners(mLeaguesForShow[index].beginners, highlight);
				}
				else
				{
					playerLeagueIcon.InitializeLeague(mLeaguesForShow[index].league, highlight);
				}
				return playerLeagueIcon.transform;
			}
		}
		return null;
	}

	private void DeselectIcon()
	{
		for (int i = 0; i < leagueIconsGrid.containItems; i++)
		{
			Transform itemOnIndex = leagueIconsGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				PlayerLeagueIcon component = itemOnIndex.GetComponent<PlayerLeagueIcon>();
				if (component != null)
				{
					component.Highlight(highlight: false, animate: true);
				}
			}
		}
	}

	private void CenterIcon(bool instant)
	{
		int num = 0;
		num = ((!GameLoginManager.currentPlayer.isInBeginnersLeague) ? ((int)(mLeague - 1)) : ((!mIsBeginnersLeague) ? 3 : (mBeginnersLeague - 1)));
		Vector3 positionForIndex = leagueIconsGrid.getPositionForIndex(num);
		leagueIconsDraggablePanel.AlignToCenter(leagueIconsGrid.transform.localPosition + positionForIndex, instant);
		leagueIconsGrid.PositionChanged();
	}

	public void InitControls()
	{
		UITable uITable = titleTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, (UITable.OnReposition)delegate
		{
			float val = 0f - titleTable.padding.x - (lastPartOfTitle.transform.parent.localPosition.x - titleTable.padding.x) / 2f;
			titleTable.transform.localPosition = titleTable.transform.localPosition.ReplaceX(val);
		});
	}

	public void InitGUIValues()
	{
		SetPromotedPart((!GameLoginManager.currentPlayer.isInBeginnersLeague) ? InfoType.None : InfoType.Beginners, saveType: true);
		SelectIcon(GameLoginManager.currentPlayer.isInBeginnersLeague, GameLoginManager.currentPlayer.beginnersLeague, GameLoginManager.currentPlayer.leagueTier);
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			mLeaguesForShow.Clear();
			mLeaguesForShow.Add(new InternalLeague(1));
			mLeaguesForShow.Add(new InternalLeague(2));
			mLeaguesForShow.Add(new InternalLeague(3));
			mLeaguesForShow.Add(new InternalLeague(League.Bronze3));
		}
		else
		{
			mLeaguesForShow.Clear();
			mLeaguesForShow.Add(new InternalLeague(League.Bronze3));
			mLeaguesForShow.Add(new InternalLeague(League.Bronze2));
			mLeaguesForShow.Add(new InternalLeague(League.Bronze1));
			mLeaguesForShow.Add(new InternalLeague(League.Silver3));
			mLeaguesForShow.Add(new InternalLeague(League.Silver2));
			mLeaguesForShow.Add(new InternalLeague(League.Silver1));
			mLeaguesForShow.Add(new InternalLeague(League.Gold3));
			mLeaguesForShow.Add(new InternalLeague(League.Gold2));
			mLeaguesForShow.Add(new InternalLeague(League.Gold1));
			mLeaguesForShow.Add(new InternalLeague(League.Elite3));
			mLeaguesForShow.Add(new InternalLeague(League.Elite2));
			mLeaguesForShow.Add(new InternalLeague(League.Elite1));
			mLeaguesForShow.Add(new InternalLeague(League.Master3));
			mLeaguesForShow.Add(new InternalLeague(League.Master2));
			mLeaguesForShow.Add(new InternalLeague(League.Master1));
			mLeaguesForShow.Add(new InternalLeague(League.Champion));
		}
		leagueIconsGrid.MakeEmpty();
		leagueIconsGrid.init(mLeaguesForShow.Count, LeagueIconInstantiate, LeagueIconFree, leagueIconsDraggablePanel);
		CenterIcon(instant: true);
	}

	public void DoAfterHide()
	{
		leagueIconsGrid.MakeEmpty();
	}

	public void SetPositiveNumber(int positivePromotion)
	{
		mPositivePromotion = positivePromotion;
	}

	public void SetPromotedPart(InfoType infoType, bool saveType = false)
	{
		bool flag = SelectedCurrentLeague();
		if (saveType)
		{
			mSavedInfoType = infoType;
		}
		if (infoType != InfoType.Current && !flag)
		{
			infoType = InfoType.Current;
		}
		if (infoType == InfoType.Current && flag)
		{
			infoType = mSavedInfoType;
		}
		infoPart.SetActive(infoType != InfoType.None);
		switch (infoType)
		{
		case InfoType.Current:
			background.color = Colours.blue.ReplaceA(0.1f);
			firstPartOfTitle.color = Colours.blue;
			lastPartOfTitle.color = Colours.blue;
			riseVsFallInfoLabel.text = Localization.Localize("ID_BATTLEWINBONUS");
			if (GameLoginManager.currentPlayer.isInBeginnersLeague)
			{
				int beginnersLeague2 = GameLoginManager.currentPlayer.beginnersLeague;
				firstPartOfTitle.text = Localization.Localize("ID_INROOKIE1");
				lastPartOfTitle.text = Localization.Localize("ID_INROOKIE2");
				iconInTitle.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague2);
				infoWarbucksReward.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.BeginnersLeagueRewards(beginnersLeague2, squadPoints: false));
				infoSquadPointsReward.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.BeginnersLeagueRewards(beginnersLeague2));
			}
			else
			{
				League leagueTier2 = GameLoginManager.currentPlayer.leagueTier;
				firstPartOfTitle.text = Localization.Localize(mTitleLeague[leagueTier2].Value1);
				lastPartOfTitle.text = Localization.Localize(mTitleLeague[leagueTier2].Value2);
				iconInTitle.spriteName = GameVariables.leagueNames[leagueTier2].Value2;
				infoWarbucksReward.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(leagueTier2));
				infoSquadPointsReward.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(leagueTier2));
			}
			break;
		case InfoType.Beginners:
		{
			int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			riseVsFallInfoLabel.text = Localization.Localize("ID_BATTLEWINBONUSRISESTO");
			if (beginnersLeague == 3)
			{
				League league2 = League.Bronze3;
				background.alpha = 0f;
				firstPartOfTitle.color = Colours.blue;
				lastPartOfTitle.color = Colours.blue;
				firstPartOfTitle.text = Localization.Localize(mTitleLeague[league2].Value1);
				lastPartOfTitle.text = Localization.Localize(mTitleLeague[league2].Value2);
				iconInTitle.spriteName = GameVariables.leagueNames[league2].Value2;
				infoWarbucksReward.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(league2));
				infoSquadPointsReward.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(league2));
			}
			else
			{
				beginnersLeague++;
				background.alpha = 0f;
				firstPartOfTitle.color = Colours.blue;
				lastPartOfTitle.color = Colours.blue;
				firstPartOfTitle.text = Localization.Localize("ID_INROOKIE1");
				lastPartOfTitle.text = Localization.Localize("ID_INROOKIE2");
				iconInTitle.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
				infoWarbucksReward.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.BeginnersLeagueRewards(beginnersLeague, squadPoints: false));
				infoSquadPointsReward.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.BeginnersLeagueRewards(beginnersLeague));
			}
			break;
		}
		default:
		{
			bool flag2 = infoType == InfoType.Positive;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			int value = (int)(leagueTier + ((!flag2) ? (-1) : mPositivePromotion));
			League league = (League)Mathf.Clamp(value, 1, 16);
			background.color = ((!flag2) ? Colours.redLeague : Colours.greenLeague).ReplaceA(0.1f);
			firstPartOfTitle.color = ((!flag2) ? Colours.redLeague : Colours.greenLeague);
			lastPartOfTitle.color = ((!flag2) ? Colours.redLeague : Colours.greenLeague);
			firstPartOfTitle.text = Localization.Localize(mTitleLeague[league].Value1);
			lastPartOfTitle.text = Localization.Localize(mTitleLeague[league].Value2);
			iconInTitle.spriteName = GameVariables.leagueNames[league].Value2;
			riseVsFallInfoLabel.text = Localization.Localize((infoType != InfoType.Negative) ? "ID_BATTLEWINBONUSRISESTO" : "ID_BATTLEWINBONUSFALLSTO");
			infoWarbucksReward.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(league));
			infoSquadPointsReward.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(league));
			break;
		}
		case InfoType.None:
			return;
		}
		titleTable.repositionNow = true;
	}

	private bool SelectedCurrentLeague()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (mIsBeginnersLeague != currentPlayer.isInBeginnersLeague)
		{
			return false;
		}
		return (!mIsBeginnersLeague) ? (mLeague == currentPlayer.leagueTier) : (mBeginnersLeague == currentPlayer.beginnersLeague);
	}
}
