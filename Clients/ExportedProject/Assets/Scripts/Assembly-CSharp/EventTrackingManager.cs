using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using CodeStage.AdvancedFPSCounter;
using FuseMisc;
using Google2u;
using Newtonsoft.Json.Linq;
using Prime31;
using UnityEngine;

public class EventTrackingManager : Singleton<EventTrackingManager>
{
	public class AdLimitHolder
	{
		public LinkedList<int> lastTimesToShowWarcardAds;

		public LinkedList<int> lastTimesToShowDoctagAds;

		public LinkedList<int> lastTimesToShowGoldenSuitcaseAds;

		public LinkedList<int> lastTimesToShowLootboxAds;

		public bool sendingToServer;

		public bool canShowLootboxAd
		{
			get
			{
				int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Google2u.Constants.rowIds.LootboxesAdCount).FLOATVALUE;
				int num2 = 3600 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Google2u.Constants.rowIds.LootboxesAdInterval).FLOATVALUE;
				int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
				while (lastTimesToShowLootboxAds.First != null && lastTimesToShowLootboxAds.First.Value < num3)
				{
					lastTimesToShowLootboxAds.RemoveFirst();
				}
				return lastTimesToShowLootboxAds.Count < num;
			}
		}

		public bool canShowWarcardAd
		{
			get
			{
				int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Google2u.Constants.rowIds.WarcardAdCount).FLOATVALUE;
				int num2 = 3600 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Google2u.Constants.rowIds.WarcardAdInterval).FLOATVALUE;
				int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
				while (lastTimesToShowWarcardAds.First != null && lastTimesToShowWarcardAds.First.Value < num3)
				{
					lastTimesToShowWarcardAds.RemoveFirst();
				}
				return lastTimesToShowWarcardAds.Count < num;
			}
		}

		public bool canShowDogtagAd
		{
			get
			{
				int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Google2u.Constants.rowIds.DogtagAdCount).FLOATVALUE;
				int num2 = 3600 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Google2u.Constants.rowIds.DogtagAdInterval).FLOATVALUE;
				int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
				while (lastTimesToShowDoctagAds.First != null && lastTimesToShowDoctagAds.First.Value < num3)
				{
					lastTimesToShowDoctagAds.RemoveFirst();
				}
				return lastTimesToShowDoctagAds.Count < num;
			}
		}

		public int timeWhenCanNextGoldenSuitcase
		{
			get
			{
				int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Google2u.Constants.rowIds.GoldenSuitcaseAdCount).Get_FLOATVALUE;
				int num2 = 3600 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Google2u.Constants.rowIds.GoldenSuitcaseAdInterval).FLOATVALUE;
				int num3 = 60 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Google2u.Constants.rowIds.GoldenSuitcaseAdTimeBetweenMinutes).FLOATVALUE;
				int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				int num4 = currentTimestamp - num2;
				while (lastTimesToShowGoldenSuitcaseAds.First != null && (lastTimesToShowGoldenSuitcaseAds.First.Value < num4 || lastTimesToShowGoldenSuitcaseAds.Count > num))
				{
					lastTimesToShowGoldenSuitcaseAds.RemoveFirst();
				}
				if (lastTimesToShowGoldenSuitcaseAds.Count > 0)
				{
					int num5 = lastTimesToShowGoldenSuitcaseAds.Last.Value + num3;
					if (lastTimesToShowGoldenSuitcaseAds.Count >= num)
					{
						int num6 = lastTimesToShowGoldenSuitcaseAds.First.Value + num2;
						if (num6 > num5)
						{
							num5 = num6;
						}
					}
					if (num5 <= currentTimestamp)
					{
						return -1;
					}
					return num5;
				}
				return -1;
			}
		}

		public AdLimitHolder()
		{
			lastTimesToShowWarcardAds = new LinkedList<int>();
			lastTimesToShowDoctagAds = new LinkedList<int>();
			lastTimesToShowGoldenSuitcaseAds = new LinkedList<int>();
			lastTimesToShowLootboxAds = new LinkedList<int>();
			sendingToServer = false;
		}

		public void ImportFromServer(JToken items)
		{
			sendingToServer = false;
			lastTimesToShowWarcardAds.Clear();
			if (items["warcards"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)items["warcards"])
				{
					int num = StringParser.ParseIntToken(item);
					if (num == 0)
					{
						Debug.Log("something is wrong - time == 0");
					}
					else
					{
						lastTimesToShowWarcardAds.AddLast(num);
					}
				}
			}
			lastTimesToShowDoctagAds.Clear();
			if (items["dogtags"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)items["dogtags"])
				{
					int num2 = StringParser.ParseIntToken(item2);
					if (num2 == 0)
					{
						Debug.Log("something is wrong - time == 0");
					}
					else
					{
						lastTimesToShowDoctagAds.AddLast(num2);
					}
				}
			}
			lastTimesToShowGoldenSuitcaseAds.Clear();
			if (items["goldenSuitcase"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)items["goldenSuitcase"])
				{
					int num3 = StringParser.ParseIntToken(item3);
					if (num3 == 0)
					{
						Debug.Log("something is wrong - time == 0");
					}
					else
					{
						lastTimesToShowGoldenSuitcaseAds.AddLast(num3);
					}
				}
			}
			lastTimesToShowLootboxAds.Clear();
			if (items["lootboxes"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)items["lootboxes"])
			{
				int num4 = StringParser.ParseIntToken(item4);
				if (num4 == 0)
				{
					Debug.Log("something is wrong - time == 0");
				}
				else
				{
					lastTimesToShowLootboxAds.AddLast(num4);
				}
			}
		}
	}

	private FlurryService mFlurryService;

	private AwsEvents mAwsEvents;

	private string mIdfa;

	private string mAdZone;

	private int mRetries;

	private AdLimitHolder adLimits;

	public FuseboxxService fuseboxxService { get; private set; }

	public bool isAdVideoPlaying => fuseboxxService != null && fuseboxxService.isVideoPlaying;

	public int timeToNextShowGoldenSuitcase
	{
		get
		{
			if (adLimits == null)
			{
				adLimits = new AdLimitHolder();
			}
			return adLimits.timeWhenCanNextGoldenSuitcase;
		}
	}

	public event Action RewardVideoPreloaded;

	public event Action AdvertisementVideoRewardError;

	public event Action AdLimitsChanged;

	protected override void Awake()
	{
		base.Awake();
		if (ObjectHolderOnSceneChange.instance != null && ObjectHolderOnSceneChange.instance.fuseboxxService != null)
		{
			fuseboxxService = ObjectHolderOnSceneChange.instance.fuseboxxService;
		}
		else
		{
			fuseboxxService = new FuseboxxService(GetComponentInChildren<FuseSDK>());
		}
		fuseboxxService.SceneLoadedAndPreset();
		mFlurryService = new FlurryService();
		LevelManager.LevelUp += OnLevelUp;
		fuseboxxService.RewardVideoPreloaded += OnRewardVideoPreloaded;
		fuseboxxService.AdvertisementVideoRewardError += OnAdvertisementVideoRewardError;
		adLimits = new AdLimitHolder();
	}

	public void getAdlimits(JToken item)
	{
		Debug.Log(item.ToString());
		if (adLimits == null)
		{
			adLimits = new AdLimitHolder();
		}
		adLimits.ImportFromServer(item);
		if (this.AdLimitsChanged != null)
		{
			this.AdLimitsChanged();
		}
	}

	public void SetSendingAdrewardGainedToServer()
	{
		adLimits.sendingToServer = true;
	}

	private void OnRewardVideoPreloaded()
	{
		if (this.RewardVideoPreloaded != null)
		{
			this.RewardVideoPreloaded();
		}
	}

	private void OnAdvertisementVideoRewardError()
	{
		if (this.AdvertisementVideoRewardError != null)
		{
			this.AdvertisementVideoRewardError();
		}
	}

	public void RegisterAwsAnalyticsInApp(string produktId, double price, string formatedPrice, string transactionId, string currencyCode)
	{
		if (mAwsEvents != null)
		{
			mAwsEvents.RegisterInApp(produktId, price, formatedPrice, transactionId, currencyCode);
		}
	}

	public void RegisterKochavaInApp(string packId, float price, string type, string currency)
	{
		FireEventParameters fireEventParameters = new FireEventParameters(FireEventType.Purchase);
		fireEventParameters.currency = currency;
		fireEventParameters.price = price;
		fireEventParameters.name = packId;
		fireEventParameters.contentType = type;
		Kochava.FireEventStandard(fireEventParameters);
	}

	public void RegisterFacebookInApp(string packId, float price, string type, string currency)
	{
		FacebookAndroid.logPurchaseEvent(price, currency);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("PackId", packId);
		dictionary.Add("Price", price);
		dictionary.Add("Type", type);
		dictionary.Add("Currency", currency);
		Dictionary<string, object> parameters = dictionary;
		FacebookAndroid.logEvent("InApp", parameters);
	}

	protected override void Start()
	{
		base.Start();
		mFlurryService.Init();
		mAwsEvents = new AwsEvents(base.gameObject);
	}

	private void RegisterEvent(string eventName, string parameterName, string parameterValue, Hashtable table)
	{
		fuseboxxService.RegisterEvent(eventName, parameterName, parameterValue, table);
		mFlurryService.RegisterEvent(eventName, parameterName, parameterValue);
		if (mAwsEvents != null)
		{
			mAwsEvents.RegisterEvent(eventName, parameterName, parameterValue, table);
		}
	}

	private void OnLevelUp()
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Wallet wallet = Singleton<Wallet>.instance;
		Debug.Log($"FuseBox Event Level Up for level {data.GetPlayerLevel()}");
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Total_Sessions", data.numberOfSessions);
		hashtable.Add("Total_Battles", PlayerAnalytics.instance.data.totalBattles);
		hashtable.Add("Days_Since_Install", data.GetDaysSinceInstall());
		hashtable.Add("Total_Warbucks_Earned", data.warbucksSpent + wallet.warBucks);
		hashtable.Add("Total_Warbucks_Spent", data.warbucksSpent);
		hashtable.Add("Warbucks_Balance", wallet.warBucks);
		hashtable.Add("Total_Gold_Earned", data.goldSpent + wallet.gold);
		hashtable.Add("Total_Gold_Spent", data.goldSpent);
		hashtable.Add("Gold_Balance", wallet.gold);
		hashtable.Add("Made_IAP_Spend", data.MadeInApp());
		Hashtable table = hashtable;
		RegisterEvent("Player_Level_Up", "Level_Number", data.GetPlayerLevel().ToString("D3"), table);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Total_Sessions", data.numberOfSessions);
		dictionary.Add("Total_Battles", PlayerAnalytics.instance.data.totalBattles);
		dictionary.Add("Level", data.GetPlayerLevel());
		dictionary.Add("Days_Since_Install", data.GetDaysSinceInstall());
		dictionary.Add("Gold_Balance", wallet.gold);
		dictionary.Add("Made_IAP_Spend", data.MadeInApp());
		Dictionary<string, object> parameters = dictionary;
		FacebookAndroid.logEvent("Player_Level_Up", parameters);
		FireEventParameters fireEventParameters = new FireEventParameters(FireEventType.LevelComplete);
		fireEventParameters.level = data.GetPlayerLevel().ToString("D3");
		fireEventParameters.date = DateTime.Now;
		fireEventParameters.duration = data.GetDaysSinceInstall();
		Kochava.FireEventStandard(fireEventParameters);
	}

	internal void RegisterLeagueLeaderboardShown(League league)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Debug.Log($"FuseBox Event Level Up for level {data.GetPlayerLevel()}");
		int num = (int)league;
		string parameterValue = num.ToString("D2");
		RegisterEvent("First_Time_Check_Leagues", "League", parameterValue, new Hashtable
		{
			{ "Total_Sessions", data.numberOfSessions },
			{
				"Total_Battles",
				PlayerAnalytics.instance.data.totalBattles
			},
			{
				"Days_Since_Install",
				data.GetDaysSinceInstall()
			},
			{
				"Player_Rank",
				data.GetPlayerLevel()
			}
		});
	}

	internal void TestVideoPreloaded()
	{
		this.RewardVideoPreloaded();
	}

	public void TestFuseboxx()
	{
		VGOfferInfo offerInfo = new VGOfferInfo
		{
			EndTime = FuseExtensions.ToDateTime(Singleton<BeanstalkServerManager>.instance.currentTimestamp + 600),
			ItemName = "Time-limited Offers",
			Metadata = "AttakUnits",
			PurchasePrice = 75f
		};
		Debug.Log("TEST FUSEBOX - fake offer:\n" + offerInfo.ToString());
		Singleton<OfferManager>.instance.HaveOfferFormFusebox(offerInfo);
	}

	private void onDestroy()
	{
		LevelManager.LevelUp -= OnLevelUp;
	}

	public void CampaignLevelAttempt(Mission currentMission, bool isCoop)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Wallet wallet = Singleton<Wallet>.instance;
		int num = currentMission.savedData.attemptCoop + currentMission.savedData.attemptCount + currentMission.savedData.attemptHero + currentMission.savedData.attemptHeroCoop;
		if (num == 1)
		{
			RegisterEvent("First_Time_Campaign_Level_Attempt", "Campaign_Level_Number", currentMission.index.ToString("D3"), new Hashtable
			{
				{ "Premium_Spend", data.goldSpent },
				{ "Grind_Spend", data.warbucksSpent },
				{ "Premium_Balance", wallet.gold },
				{ "Grind_Balance", wallet.warBucks },
				{ "Spenders", data.boughtInApp },
				{
					"Days_Since_Install",
					data.GetDaysSinceInstall()
				},
				{
					"Overtime",
					Singleton<MatchManager>.instance.isOverTime ? 1 : 0
				},
				{
					"BattleLength",
					Singleton<MatchManager>.instance.matchTime
				},
				{
					"IsCoop",
					isCoop ? 1 : 0
				}
			});
		}
		else
		{
			RegisterEvent("Campaign_Level_Attempt", "Campaign_Level_Number", currentMission.index.ToString("D3"), new Hashtable
			{
				{
					"Overtime",
					Singleton<MatchManager>.instance.isOverTime ? 1 : 0
				},
				{
					"BattleLength",
					Singleton<MatchManager>.instance.matchTime
				}
			});
		}
	}

	public void RegisterDailyVisit()
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		RegisterEvent("Daily_Visit_Main_Menu", "Total_Lifetime_Spend", data.GetCohort(), new Hashtable
		{
			{ "Premium_Spend", data.goldSpent },
			{
				"Total_Transactions",
				data.TotalTransactions()
			},
			{
				"Facebook_Activated",
				data.HasFacebook()
			},
			{
				"Average_Player_Level",
				data.GetPlayerLevel()
			},
			{ "Total_Sessions", data.numberOfSessions },
			{
				"Days_Since_Install",
				data.GetDaysSinceInstall()
			}
		});
	}

	internal bool IsRewardVideoPreloaded(RewardType forreward)
	{
		if (adLimits == null)
		{
			new AdLimitHolder();
		}
		if (adLimits.sendingToServer)
		{
			return false;
		}
		switch (forreward)
		{
		case RewardType.Dogtag:
			if (!adLimits.canShowDogtagAd)
			{
				return false;
			}
			break;
		case RewardType.RandomCard:
			if (!adLimits.canShowWarcardAd)
			{
				return false;
			}
			break;
		case RewardType.GoldenSuitcase:
			if (adLimits.timeWhenCanNextGoldenSuitcase > 0)
			{
				return false;
			}
			break;
		case RewardType.LootBox:
			if (!adLimits.canShowLootboxAd)
			{
				return false;
			}
			break;
		}
		return fuseboxxService.IsRewardVideoPreloaded();
	}

	internal void RegisterStarRating(string parameter, int shownBeforeTimes)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		RegisterEvent("Display_Rating_Box", "Result", parameter, new Hashtable
		{
			{ "Total_Sessions", data.numberOfSessions },
			{
				"Total_Battles",
				PlayerAnalytics.instance.data.totalBattles
			},
			{ "Shown_Before_Times", shownBeforeTimes }
		});
	}

	internal void RegisterPurchaseAttempt(string productId, bool isSuccess)
	{
		RegisterEvent("Purchase_Attempt", "InApp_ID", productId, new Hashtable { 
		{
			"Connection_Fail",
			(!isSuccess) ? "1" : "0"
		} });
	}

	internal void Claim7DayInApp(int day)
	{
		RegisterEvent("7DIAppClaim", "Day", "Day" + day, new Hashtable { 
		{
			"Days_Since_Install",
			PlayerAnalytics.instance.data.GetDaysSinceInstall()
		} });
	}

	internal void MatchMaking(float seconds)
	{
		int num = (int)Mathf.Ceil(seconds / 10f);
		RegisterEvent("JoinMatch_ServerConnect", "Time_Range", "Time_Range_" + num, new Hashtable { { "Seconds_to_connect", seconds } });
	}

	public void RegisterPowerBandEvent(string decalName, int transactionAmount, bool isGold)
	{
		if (isGold)
		{
			RegisterEvent("Spend_Gold_On_Power_Bands", "Decal_Type", decalName, new Hashtable
			{
				{ "Average_Transaction_Amount", transactionAmount },
				{
					"Days_Since_Install",
					PlayerAnalytics.instance.data.GetDaysSinceInstall()
				}
			});
			RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchasePowerband);
		}
	}

	public void RegisterTutorialEvent(string stageName)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			},
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			}
		});
	}

	internal void RegisterAssignmentDailyCompletion(int completedDays, int totalDays)
	{
		RegisterEvent("Assignment_Daily_Completion", "CompletedDays", completedDays.ToString(CultureInfo.InvariantCulture), new Hashtable { { "Total_Days", totalDays } });
	}

	internal void RegisterViewStarterAssignmentTab(StarterAssignment assignment)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		StatsManager.StatisticsData data2 = StatsManager.instance.data;
		int num = (int)Math.Round((double)data2.secondsPlayed / 60.0);
		Debug.Log("REGISTER VIEW STARTER ASSIGNMENT " + assignment.order.ToString("D2") + " TAB " + num + ", mis = " + data2.missionsPlayed);
		RegisterEvent("View_StarterAssignmentTab", "Id", assignment.order.ToString("D2"), new Hashtable
		{
			{
				"Player_Level",
				data.GetPlayerLevel()
			},
			{ "Total_Matchmaking_Battles", data2.mmmGames },
			{ "Total_Warpath_Attempts", data2.missionsPlayed },
			{ "Mins_Played", num }
		});
	}

	internal void RegisterStarterAssignmentCompleted(StarterAssignment starterAssignment, bool uncompleteAssignmentExists)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Debug.Log("Starter assignment completed " + starterAssignment.id);
		RegisterEvent("Starter_Assignment_Completed", "Id", starterAssignment.id, new Hashtable
		{
			{ "Total_Sessions", data.numberOfSessions },
			{
				"Days_Since_Install",
				data.GetDaysSinceInstall()
			},
			{ "Total_Batles", data.totalBattles },
			{
				"Already_Completed",
				(!uncompleteAssignmentExists) ? "0" : "1"
			}
		});
	}

	internal void RegisterAssignmentCompletion(AssignmentsManager.DatabaseAssignment assignment, int completed)
	{
		if (assignment.tutorialId > 0)
		{
			Debug.Log("REGISTER PREDEFINED ASSIGNMENT EVENT COMPLETED" + assignment.tutorialId.ToString("D3"));
			RegisterEvent("Predefined_Assignment_Completed", "AssignemntId", assignment.tutorialId.ToString("D3"), new Hashtable { { "Total_Assignment_Completed", completed } });
			return;
		}
		string text = "Assignment_" + assignment.id;
		string secondTargetAsString = assignment.GetSecondTargetAsString();
		if (!string.IsNullOrEmpty(secondTargetAsString))
		{
			text = text + "_" + secondTargetAsString;
		}
		RegisterEvent("Assignment_Completed", "AssignemntId", text, new Hashtable { { "Total_Assignment_Completed", completed } });
	}

	public void RegisterTutorialGameEnded(string stageName)
	{
		Debug.Log($"Event Tracking Manager - Tutorial Game Ended, Deploy clicks: {StatsManager.instance.matchStats.deployClicks}, Deployed units: {StatsManager.instance.matchStats.unitsDeployed}");
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{
				"Shots_Fired",
				StatsManager.instance.matchStats.shotsFired
			},
			{
				"Shots_Hits",
				StatsManager.instance.matchStats.hits
			},
			{
				"Deploys_Count",
				StatsManager.instance.matchStats.unitsDeployed
			},
			{
				"Manual_Unit_Spawn",
				StatsManager.instance.matchStats.deployClicks
			},
			{
				"Card_1_Played",
				CardManager.instance.TutorialWarcardPlayed(0) ? 1 : 0
			},
			{
				"Card_2_Played",
				CardManager.instance.TutorialWarcardPlayed(1) ? 1 : 0
			},
			{
				"Card_3_Played",
				CardManager.instance.TutorialWarcardPlayed(2) ? 1 : 0
			},
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	internal void RegisterClaimCraftedCard(string cardId, int timeSinceDelivery)
	{
		RegisterEvent("CardCraft_Collect", "CardId", cardId, new Hashtable { { "Time_Since_Delivery_Finished", timeSinceDelivery } });
		Card cardInstance = CardManager.instance.GetCardInstance(cardId);
		if (cardInstance != null)
		{
			RegisterFuseboxxCustomEvent((cardInstance.rarity != CardManager.CardType.Gold) ? WarfriendsCustomEvent.ForgeSilverCard : WarfriendsCustomEvent.ForgeGoldCard);
		}
	}

	public void RegisterTutorialCoverEvent(string stageName, bool avoidedGrenade)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{
				"Player_Avoided_Grenade_On_First_Try",
				avoidedGrenade ? 1 : 0
			},
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	internal void RegisterDepositCard(string cardId, int[] rarityCounts)
	{
		RegisterEvent("CardTrade_Deposit", "CardId", cardId, new Hashtable
		{
			{
				"Cards_Owned_Bronze",
				rarityCounts[0]
			},
			{
				"Cards_Owned_Silver",
				rarityCounts[1]
			},
			{
				"Cards_Owned_Gold",
				rarityCounts[2]
			}
		});
	}

	internal void RegisterCardCraftingStarted(string cardId, int[] rarityCounts)
	{
		RegisterEvent("CardCraft_Start", "CardId", cardId, new Hashtable
		{
			{
				"Cards_Owned_Bronze",
				rarityCounts[0]
			},
			{
				"Cards_Owned_Silver",
				rarityCounts[1]
			},
			{
				"Cards_Owned_Gold",
				rarityCounts[2]
			}
		});
	}

	public void RegisterTutorialWeaponSelectedEvent(string stageName, bool wrongCategory, bool wrongWeapon)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{
				"Wrong_Category",
				wrongCategory ? 1 : 0
			},
			{
				"Wrong_Weapon",
				wrongWeapon ? 1 : 0
			},
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	internal void RegisterWithdrawCard(string cardId, int[] rarityCounts)
	{
		RegisterEvent("CardTrade_Withdraw", "CardId", cardId, new Hashtable
		{
			{
				"Cards_Owned_Bronze",
				rarityCounts[0]
			},
			{
				"Cards_Owned_Silver",
				rarityCounts[1]
			},
			{
				"Cards_Owned_Gold",
				rarityCounts[2]
			}
		});
	}

	public void RegisterTutorialDeliveredEvent(string stageName, bool waitedTillDelivered)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{
				"Player_Waited_Till_Delivery_Ends",
				waitedTillDelivered ? 1 : 0
			},
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	public void RegisterTutorialWeaponEquippedEvent(string stageName, bool automaticEquip)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{
				"Automatic_Equip",
				automaticEquip ? 1 : 0
			},
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	public void RegisterTutorialSniperShootEvent(string stageName, bool tutorialPlayed, int timeDuration)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{
				"Sniper_Tutorial_Played",
				tutorialPlayed ? 1 : 0
			},
			{ "Sniper_Tutorial_Duration", timeDuration },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	public void RegisterTutorialGrenadeThrowEvent(string stageName, bool playerHadToSelectGrenade)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{
				"Player_Had_To_Select_Grenade",
				playerHadToSelectGrenade ? 1 : 0
			},
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	public void RegisterTutorialGrenadeThrowingEvent(string stageName, int timeDuration)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", timeDuration },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	internal void ShowRewardedVideo(RewardType reward)
	{
		Debug.Log("ETM: Show Rewarded Video");
		fuseboxxService.ShowRewardedVideo(reward);
	}

	public void SetLastShowedTimeForAdtype(RewardType reward)
	{
		switch (reward)
		{
		case RewardType.RandomCard:
			adLimits.lastTimesToShowWarcardAds.AddLast(Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			break;
		case RewardType.Dogtag:
			adLimits.lastTimesToShowDoctagAds.AddLast(Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			break;
		case RewardType.GoldenSuitcase:
			adLimits.lastTimesToShowGoldenSuitcaseAds.AddLast(Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			break;
		case RewardType.LootBox:
			adLimits.lastTimesToShowLootboxAds.AddLast(Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			break;
		}
	}

	public void RegisterTutorialUnitSelectedEvent(string stageName, bool wrongUnit)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{
				"Wrong_Unit",
				wrongUnit ? 1 : 0
			},
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	public void RegisterTutorialPlayCardEvent(string stageName, bool tutorialPlayed, int timeDuration)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{
				"Play_Card_Tutorial",
				tutorialPlayed ? 1 : 0
			},
			{ "Play_Card_Tutorial_Duration", timeDuration },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	public void RegisterTutorialOvertimeExplainedEvent(string stageName, bool wasAlreadyExplained)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{
				"Overtime_Was_Already_Explained",
				wasAlreadyExplained ? 1 : 0
			},
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	public void RegisterTutorialDialogEvent(string stageName, bool clickedYes)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{
				"Yes_Clicked",
				clickedYes ? 1 : 0
			},
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	public void RegisterTutorialMenuTutorialEvent(string stageName)
	{
		RegisterEvent("Tutorial_Step_Complete", "StepId", stageName, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "Play_Card_Tutorial", 0 },
			{ "Play_Card_Tutorial_Duration", 0 },
			{ "Wrong_Category", 0 },
			{ "Wrong_Weapon", 0 },
			{ "Overtime_Was_Already_Explained", 0 },
			{ "Player_Avoided_Grenade_On_First_Try", 0 },
			{ "Yes_Clicked", 0 },
			{ "Shots_Fired", 0 },
			{ "Shots_Hits", 0 },
			{ "Deploys_Count", 0 },
			{ "Manual_Unit_Spawn", 0 },
			{ "Card_1_Played", 0 },
			{ "Card_2_Played", 0 },
			{ "Card_3_Played", 0 },
			{
				"Sessions",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"Time",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	public void RegisterEconomyEvent(string eventName, int transactionAmount)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		RegisterEvent(eventName, "PlayerLevel", data.GetPlayerLevel().ToString("D3"), new Hashtable
		{
			{ "Average_Transaction_Amount", transactionAmount },
			{
				"Days_Since_Install",
				PlayerAnalytics.instance.data.GetDaysSinceInstall()
			}
		});
	}

	public void RegisterRewardClaimedEvent(int day, int allDays, DailyReward rewardType)
	{
		RegisterEvent("Daily_Reward_Claimed", "forDay", day.ToString(), new Hashtable
		{
			{ "monthLenght", allDays },
			{
				"RewardType",
				(int)rewardType
			}
		});
	}

	public void RegisterGameItemBoughtEvent(string eventName, string parameterName, string parameterValue, int transactionAmount)
	{
		RegisterEvent(eventName, parameterName, parameterValue, new Hashtable { { "Transaction_Amount", transactionAmount } });
	}

	public void RegisterAutodeployOn()
	{
		RegisterEvent("Autodeploy_On", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString(), new Hashtable { 
		{
			"Total_Battles",
			PlayerAnalytics.instance.data.totalBattles
		} });
	}

	public void RegisterAutodeployOff()
	{
		RegisterEvent("Autodeploy_Off", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString(), new Hashtable { 
		{
			"Total_Battles",
			PlayerAnalytics.instance.data.totalBattles
		} });
	}

	public void RegisterBroadcastEnd(float duration, int battles)
	{
		RegisterEvent("Broadcast_End", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString(), new Hashtable
		{
			{ "Battles_Played", battles },
			{
				"Broadcast_Duration",
				(long)duration
			}
		});
	}

	public void RegisterWatchAd(string parameterValue, bool completed)
	{
		RegisterEvent("Watch_Ad", "AdZone", parameterValue, new Hashtable { 
		{
			"View_Completed",
			completed ? 1 : 0
		} });
	}

	public void RegisterSocialBehaviour(string parameterValue)
	{
		RegisterEvent("Social_Behaviour", "ActivityType", parameterValue, new Hashtable { 
		{
			"Days_Since_Install",
			PlayerAnalytics.instance.data.GetDaysSinceInstall()
		} });
	}

	public void RegisterPlayerLevelUp(string parameterValue, bool isEnabled)
	{
		RegisterEvent("Player_Level_Up", "NotificationsEnabled", parameterValue, new Hashtable { 
		{
			"Is_Enabled",
			isEnabled ? 1 : 0
		} });
	}

	public void RegisterStoreVisitComplete(string route, bool conversion)
	{
		if (!string.IsNullOrEmpty(route))
		{
			RegisterEvent("Store_Visit", "StoreEntryRoute", route, new Hashtable { 
			{
				"Conversion",
				conversion ? 1 : 0
			} });
		}
	}

	public void RegisterVisitLeagueTable()
	{
		RegisterEvent("Visit_League_Table", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString(), new Hashtable { 
		{
			"Total_Battles",
			PlayerAnalytics.instance.data.totalBattles
		} });
	}

	public void RegisterSquadActivity(string activity)
	{
		bool flag = string.Compare("Create_Squad", activity) == 0;
		RegisterEvent("Squad_Activity", "ActivityType", activity, new Hashtable { 
		{
			(!flag) ? "Total_Battles" : "Days_Since_Install",
			(!flag) ? PlayerAnalytics.instance.data.totalBattles : PlayerAnalytics.instance.data.GetDaysSinceInstall()
		} });
	}

	public void RegisterWBOut(string parameterValue, int amount)
	{
		RegisterEvent("WB_Out_Flow", "Area", parameterValue, new Hashtable { { "Amount", amount } });
	}

	public void RegisterWBIn(string parameterValue, int amount)
	{
		RegisterEvent("WB_In_Flow", "Area", parameterValue, new Hashtable { { "Amount", amount } });
	}

	public void RegisterGoldOut(string parameterValue, int amount)
	{
		RegisterEvent("Gold_Out_Flow", "Area", parameterValue, new Hashtable { { "Amount", amount } });
	}

	public void RegisterGoldAndWBAfterMatch(bool isLevelUp)
	{
		int num = 0;
		int num2 = 0;
		if (isLevelUp)
		{
			num = LevelManager.instance.currentLevel.golds;
			num2 = LevelManager.instance.currentLevel.warbucks;
			RegisterGoldIn("Rank_Up", num);
			RegisterGoldIn("Rank_Up", num2);
		}
		string text = (Singleton<GameController>.instance.isPVP ? "Battle" : ((!Singleton<GameController>.instance.isMission) ? string.Empty : ((!MissionsManager.instance.currentMission.playingInHeroicMode) ? "Warpath" : "Heroic")));
		int goldTotal = Singleton<ServerResultsCache>.instance.lastGameReward.goldTotal;
		int warbucksTotal = Singleton<ServerResultsCache>.instance.lastGameReward.warbucksTotal;
		if (!string.IsNullOrEmpty(text))
		{
			if (goldTotal > 0)
			{
				RegisterGoldIn(text, goldTotal - num);
			}
			if (warbucksTotal > 0)
			{
				RegisterWBIn(text, warbucksTotal - num2);
			}
		}
	}

	public void RegisterGoldIn(string parameterValue, int amount)
	{
		RegisterEvent("Gold_In_Flow", "Area", parameterValue, new Hashtable { { "Amount", amount } });
	}

	public void RegisterGameItemDeliverEvent(string eventName, string parameterName, string parameterValue, int transactionAmount, double remainingTime)
	{
		RegisterEvent(eventName, parameterName, parameterValue, new Hashtable
		{
			{ "Transaction_Amount", transactionAmount },
			{ "Remaining_Time", remainingTime }
		});
	}

	public void RegisterBuyLootboxes(string lootboxID, List<LootboxContent> lootboxes)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Debug.Log($"FuseBox Event BuyLootboxes for id {lootboxID}");
		string parameterValue = data.GetPlayerLevel() + "_" + lootboxID;
		Dictionary<PlayerVisual.Rarity, int> itemsCountByRarity = CamosManager.instance.GetItemsCountByRarity(lootboxes);
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Days_Since_Install", data.GetDaysSinceInstall());
		hashtable.Add("MadeIApp", data.MadeInApp());
		hashtable.Add("Gold_Balance", Singleton<Wallet>.instance.gold);
		hashtable.Add("ItemsOwned_Rarity_0", itemsCountByRarity[PlayerVisual.Rarity.Common]);
		hashtable.Add("ItemsOwned_Rarity_1", itemsCountByRarity[PlayerVisual.Rarity.Uncommon]);
		hashtable.Add("ItemsOwned_Rarity_2", itemsCountByRarity[PlayerVisual.Rarity.Rare]);
		hashtable.Add("ItemsOwned_Rarity_3", itemsCountByRarity[PlayerVisual.Rarity.Epic]);
		hashtable.Add("ItemsOwned_Rarity_4", itemsCountByRarity[PlayerVisual.Rarity.Legendary]);
		Hashtable table = hashtable;
		RegisterEvent("LootBox_Purchase", "PlayerRank_BoxID", parameterValue, table);
	}

	public void RegisterOpenLootbox(int rarity)
	{
		Debug.Log($"FuseBox Event OpenLootbox for rarity {rarity}");
		RegisterEvent("LootBox_Open", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString("D3"), new Hashtable
		{
			{
				"ItemRarity_0",
				(rarity == 0) ? 1 : 0
			},
			{
				"ItemRarity_1",
				(rarity == 1) ? 1 : 0
			},
			{
				"ItemRarity_2",
				(rarity == 2) ? 1 : 0
			},
			{
				"ItemRarity_3",
				(rarity == 3) ? 1 : 0
			},
			{
				"ItemRarity_4",
				(rarity == 4) ? 1 : 0
			}
		});
	}

	public void RegisterDuplicateLootbox(int gainedWB)
	{
		Debug.Log($"FuseBox Event DuplicateLootbox for {gainedWB}");
		RegisterEvent("LootBox_Duplicate", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString("D3"), new Hashtable { { "Gained_WB", gainedWB } });
	}

	public void RegisterVisualGained(int rarity)
	{
		Debug.Log($"FuseBox Event VisualGained for rarity {rarity}");
		RegisterEvent("PlayerVisual_Gained", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString("D3"), new Hashtable
		{
			{
				"ItemRarity_0",
				(rarity == 0) ? 1 : 0
			},
			{
				"ItemRarity_1",
				(rarity == 1) ? 1 : 0
			},
			{
				"ItemRarity_2",
				(rarity == 2) ? 1 : 0
			},
			{
				"ItemRarity_3",
				(rarity == 3) ? 1 : 0
			},
			{
				"ItemRarity_4",
				(rarity == 4) ? 1 : 0
			}
		});
	}

	public void RegisterBuyCardPackEvent(string packId, int transactionAmount, bool isGold)
	{
		if (isGold)
		{
			RegisterEvent("Spend_Gold_On_Card_Packs", "Pack_Type", packId, new Hashtable
			{
				{ "Average_Transaction_Amount", transactionAmount },
				{
					"Days_Since_Install",
					PlayerAnalytics.instance.data.GetDaysSinceInstall()
				}
			});
		}
	}

	public void RegisterBuyVipEvent(string vipPackId, int transactionAmount)
	{
		RegisterEconomyEvent("Buy_VIP_Pack_With_Gold", transactionAmount);
		Debug.Log("Bought VIP - " + vipPackId + " - loggin goldCost: " + transactionAmount);
		RegisterEvent("Buy_VIP_Pack_With_Gold", "Pack_Type", vipPackId, new Hashtable
		{
			{ "Average_Transaction_Amount", transactionAmount },
			{
				"Days_Since_Install",
				PlayerAnalytics.instance.data.GetDaysSinceInstall()
			}
		});
	}

	internal void RegisterAssignmentIssued(AssignmentsManager.DatabaseAssignment assignment, int issued)
	{
		int id = assignment.id;
		string secondTargetAsString = assignment.GetSecondTargetAsString();
		string text = ((assignment.tutorialId <= 0) ? ("Assignment_" + id) : assignment.tutorialId.ToString("D3"));
		if (!string.IsNullOrEmpty(secondTargetAsString))
		{
			text = text + "_" + secondTargetAsString;
		}
		Debug.Log("Register Assignment Issued " + id.ToString("D3"));
		RegisterEvent("Assignment_Issued", "AssignemntId", text, new Hashtable { { "Total_Assignment_Issued", issued } });
	}

	public void RegisterInapp(string packId, bool isFirstTime, string type)
	{
		RegisterEvent("Confirmed_In_App", "Pack_Id", type + "_Packs", new Hashtable { 
		{
			"Player_Level",
			PlayerAnalytics.instance.data.GetPlayerLevel()
		} });
		if (isFirstTime)
		{
			RegisterEvent("First_Time_Buy_" + type, "Pack_Id", packId, new Hashtable { 
			{
				"Days_Since_Install",
				PlayerAnalytics.instance.data.GetDaysSinceInstall()
			} });
		}
		else
		{
			RegisterEvent("Buy_" + type, "Pack_Id", packId, new Hashtable { 
			{
				"Player_Level",
				PlayerAnalytics.instance.data.GetPlayerLevel()
			} });
		}
	}

	public void RegisterBattleEndedEvent(bool isAgainstBot, bool isOverTime, int cardsOwned, int cardsChosen, int cardsPlayed)
	{
		PlayerAnalytics.instance.data.totalBattles++;
		int num = ((PlayerAnalytics.instance.data.totalBattles <= 1000) ? PlayerAnalytics.instance.data.totalBattles : 1000);
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Wallet wallet = Singleton<Wallet>.instance;
		int num2 = CardManager.instance.BuddyCardChosen();
		int num3 = CardManager.instance.BuddyCardsOwned();
		int num4 = CardManager.instance.BuddyCardPlayed();
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Total_Sessions", data.numberOfSessions);
		hashtable.Add("Days_Since_Install", data.GetDaysSinceInstall());
		hashtable.Add("Total_Warbucks_Earned", data.warbucksSpent + wallet.warBucks);
		hashtable.Add("Total_Warbucks_Spent", data.warbucksSpent);
		hashtable.Add("Warbucks_Balance", wallet.warBucks);
		hashtable.Add("Total_Gold_Earned", data.goldSpent + wallet.gold);
		hashtable.Add("Total_Gold_Spent", data.goldSpent);
		hashtable.Add("Gold_Balance", wallet.gold);
		hashtable.Add("Made_IAP_Spend", data.MadeInApp());
		hashtable.Add("Is_Against_Bot", isAgainstBot ? 1 : 0);
		hashtable.Add("Is_Overtime", isOverTime ? 1 : 0);
		hashtable.Add("Cards_Owned", cardsOwned);
		hashtable.Add("Cards_Chosen", cardsChosen);
		hashtable.Add("Cards_Played", cardsPlayed);
		hashtable.Add("Cards_Buddy_Owned", num3);
		hashtable.Add("Cards_Buddy_Chosen", num2);
		hashtable.Add("Cards_Buddy_Played", num4);
		hashtable.Add("Ranked_Battle", Singleton<GameController>.instance.isRandomMatchMaking ? 1 : 0);
		hashtable.Add("Win", Singleton<GameController>.instance.wonLastGame ? 1 : 0);
		hashtable.Add("Connection_Dropped", MatchManager.isReconnect ? 1 : 0);
		hashtable.Add("BattleLength", Singleton<MatchManager>.instance.matchTime);
		hashtable.Add("AgainstOtherPlatform", Singleton<GameController>.instance.isDeathMatch ? 1 : 0);
		Hashtable table = hashtable;
		RegisterEvent("War_Battle_End", "Battle_Number", num.ToString("D3"), table);
		if (!Singleton<GameController>.instance.isMission)
		{
			RegisterEvent("War_Battle_Mode", "Game_Type", (!Singleton<GameController>.instance.isRandomMatchMaking) ? "Unranked" : "Ranked", new Hashtable());
		}
		if (Singleton<GameController>.instance.isRandomMatchMaking && Singleton<GameController>.instance.isDeathMatch)
		{
			PlayerProperties playerProperties = PlayerController.currentPlayer.playerProperties;
			PlayerProperties playerProperties2 = Singleton<GameController>.instance.opponent.playerProperties;
			RegisterEvent("War_Ranked_Battle", "Region", PhotonConnectionManager.bestRegion.ToString(), new Hashtable
			{
				{
					"Ping",
					PhotonConnectionManager.pingToBestRegion
				},
				{
					"leagueDiff",
					playerProperties.league - playerProperties2.league
				},
				{
					"leagueMedalsDiff",
					playerProperties.leagueMedals - playerProperties2.leagueMedals
				},
				{
					"rankDiff",
					playerProperties.level - playerProperties2.level
				}
			});
		}
		string deviceModel = SystemInfo.deviceModel;
		deviceModel = "Android";
		if (Singleton<GameController>.instance.isDeathMatch)
		{
			RegisterEvent("War_Battle_End_Performance", "Map_device_levelGroup", Singleton<MapManager>.instance.currentMap.name + "_" + deviceModel + "_" + (int)((float)LevelManager.instance.currentLevel.displayNumber / 5f), new Hashtable
			{
				{
					"Min_fps",
					AFPSCounter.Instance.fpsCounter.lastMinimumValue.ToString()
				},
				{
					"Avg_fps",
					AFPSCounter.Instance.fpsCounter.lastAverageValue.ToString()
				},
				{
					"Memory_warnings",
					Singleton<PerformanceLoggerManager>.instance.memoryWarningDuringGame
				}
			});
			int num5 = 1;
			if (Screen.height > 600)
			{
				num5 = 2;
			}
			if (Screen.height > 800)
			{
				num5 = 3;
			}
			RegisterEvent("War_Battle_End_Android_Performance", "Tier", $"{Singleton<MapManager>.instance.currentMap.name}_processorT{SystemInfo.processorCount}_resT{num5}", new Hashtable
			{
				{
					"Min_fps",
					AFPSCounter.Instance.fpsCounter.lastMinimumValue.ToString()
				},
				{
					"Avg_fps",
					AFPSCounter.Instance.fpsCounter.lastAverageValue.ToString()
				},
				{
					"Memory_warnings",
					Singleton<PerformanceLoggerManager>.instance.memoryWarningDuringGame
				}
			});
		}
		RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PlayBattle);
	}

	public void RegisterBuyPackEvent(string packId)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Debug.Log("REGISTER BUY PACK EVENT with " + packId);
		RegisterEvent("Buy_Pack", "Pack_Type", packId, new Hashtable
		{
			{
				"Average_Player_Level",
				data.GetPlayerLevel()
			},
			{
				"Days_Since_Install",
				data.GetDaysSinceInstall()
			}
		});
	}

	internal void RegisterBuyOfferEventLocation(string packLocation, string packId)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Debug.Log("REGISTERING PACK LOCATION " + packLocation);
		RegisterEvent("Purchase_Special_Offer", "PackLocation", packId + "_" + packLocation, new Hashtable
		{
			{
				"Average_Player_Level",
				data.GetPlayerLevel()
			},
			{ "Total_Battles", data.totalBattles },
			{ "Total_Sessions", data.numberOfSessions }
		});
	}

	public void RegisterHonestyBoxShowedEvent(bool result)
	{
	}

	internal void RegisterCampaignCoopCompleted(Mission currentMission, MissionsManager.MissionData missionData, int partnerLevel)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		string eventName = ((!currentMission.playingInHeroicMode) ? "Campaign_Level_Coop_Completed" : "Campaign_Level_Heroic_Coop_Completed");
		int num = ((!currentMission.playingInHeroicMode) ? missionData.attemptCoop : missionData.attemptHeroCoop);
		Debug.LogError("REGISTERING CAMPAIGN COOP COMPLETED attempts = " + num + ", stars = " + missionData.numberOfStars + ", missionId = " + currentMission.index + ", partner level = " + partnerLevel);
		RegisterEvent(eventName, "Campaign_Level_Number", currentMission.index.ToString("D3"), new Hashtable
		{
			{
				"Rank",
				data.GetPlayerLevel()
			},
			{ "PartnerRank", partnerLevel },
			{ "Attempts_Count", num },
			{ "Stars_Gained", missionData.numberOfStars }
		});
	}

	internal void RegisterCampaignCompleted(Mission currentMission, MissionsManager.MissionData missionData)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		string eventName = ((!currentMission.playingInHeroicMode) ? "Campaign_Level_Completed" : "Campaign_Level_Heroic_Completed");
		int num = ((!currentMission.playingInHeroicMode) ? missionData.attemptCount : missionData.attemptHero);
		Debug.LogError("REGISTERING CAMPAIGN COMPLETED attempts = " + num + ", stars = " + missionData.numberOfStars + ", missionId = " + currentMission.index);
		RegisterEvent(eventName, "Campaign_Level_Number", currentMission.index.ToString("D3"), new Hashtable
		{
			{
				"Rank",
				data.GetPlayerLevel()
			},
			{ "Attempts_Count", num },
			{ "Stars_Gained", missionData.numberOfStars }
		});
	}

	public void RegisterRentalEvent(string eventType, string itemId, int wbSpend, int goldSpend)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Hashtable hashtable = new Hashtable();
		hashtable.Add("GoldBalance", Singleton<Wallet>.instance.gold);
		hashtable.Add("WarbucksBalance", Singleton<Wallet>.instance.warBucks);
		hashtable.Add("PlayerLevel", data.GetPlayerLevel());
		Hashtable hashtable2 = hashtable;
		if (wbSpend >= 0)
		{
			hashtable2.Add("WBTransactionAmount", wbSpend);
		}
		if (goldSpend >= 0)
		{
			hashtable2.Add("GoldTransactionAmount", goldSpend);
		}
		RegisterEvent(eventType, "ItemID", itemId, hashtable2);
	}

	internal void RegisterFuseboxxCustomEvent(WarfriendsCustomEvent eventId)
	{
		if (eventId > WarfriendsCustomEvent.DeliverUnitUpgrade)
		{
			fuseboxxService.RegisterCustomEvent((int)eventId, "1");
		}
		else
		{
			fuseboxxService.RegisterCustomEvent((int)eventId, 1);
		}
	}

	public void FinishLeague(League previousLeague, League newLeague, int finishedNumber)
	{
		League bestLeague = StatsManager.instance.bestLeague;
		bool flag = previousLeague != newLeague;
		string eventName = ((newLeague <= previousLeague) ? "Player_relegated" : ((newLeague <= bestLeague) ? "Player_promoted" : "Player_promoted_first_time"));
		if (flag)
		{
			int num = (int)newLeague;
			RegisterEvent(eventName, "League_Number", num.ToString(), new Hashtable
			{
				{
					"Days_Since_Install",
					PlayerAnalytics.instance.data.GetDaysSinceInstall()
				},
				{
					"Total_Battles",
					PlayerAnalytics.instance.data.totalBattles
				}
			});
		}
	}

	public void RegisterInstatntBattle(int wbAmmount, int gdAmmount, int xpAmmount, List<Card> warcards, int count)
	{
		RegisterEvent("Play_Skirmish", "count", count.ToString(), new Hashtable
		{
			{ "Warbucks", wbAmmount },
			{ "Gold", gdAmmount },
			{ "XP", xpAmmount },
			{ "Cards", warcards.Count }
		});
	}

	public void RefreshInstantBattle(int goldCost, int paidInstantBattles)
	{
		RegisterEvent("Refresh_Skirmish", "Refresh_Level", Mathf.Clamp(paidInstantBattles, 0, 11).ToString(), new Hashtable { { "Gold", goldCost } });
	}

	public void EnterWarArena(int tickets, int gold, int attemt)
	{
		RegisterEvent("EnterArena", "Attempt", Mathf.Clamp(attemt, 0, 50).ToString(), new Hashtable
		{
			{ "Gold", gold },
			{ "Tickets", tickets }
		});
	}

	public void BuyHeart(int tickets, int gold, int wins)
	{
		RegisterEvent("BuyHeart", "Attempt", wins.ToString(), new Hashtable
		{
			{ "Gold", gold },
			{ "Tickets", tickets }
		});
	}

	public void ArenaBattleStart(int wins, int lives)
	{
		RegisterEvent("ArenaBattleStart", "Wins", wins.ToString(), new Hashtable { { "Hearts", lives } });
	}

	public void ArenaFinished(int wins, int runs)
	{
		RegisterEvent("ArenaFinished", "Wins", wins.ToString(), new Hashtable { { "Attempts", runs } });
	}

	public void ArenaLootbox(int wins, WararenaLootboxReward lootBox)
	{
		RegisterEvent("ArenaLootbox", "Unit_Id", lootBox.unitId, new Hashtable
		{
			{ "EliteParts", lootBox.eliteParts },
			{ "Tickets", lootBox.tickets },
			{ "Scraps", lootBox.scraps },
			{ "Gold", lootBox.gold },
			{ "Warbucks", lootBox.warbucks },
			{ "Wins", wins }
		});
		if (lootBox.eliteParts > 0)
		{
			RegisterEvent("PartsGainedLootbox", "UnitID", lootBox.unitId, new Hashtable { { "Parts", lootBox.eliteParts } });
		}
	}

	public void ArenaExpired(int wins, int lives, bool extraHeart)
	{
		RegisterEvent("ArenaFinished", "Wins", wins.ToString(), new Hashtable
		{
			{ "Hearts", lives },
			{
				"ExtraHeart",
				extraHeart ? 1 : 0
			}
		});
	}

	public void ArenaPoorConnection()
	{
		RegisterEvent("ArenaPoorConnection", "Show", "1", new Hashtable());
	}

	public void TicketsGained(string location, int tickets)
	{
		RegisterEvent("TicketsGained", "Location", location, new Hashtable { { "Tickets", tickets } });
	}

	public void ScrapsGained(string location, int scraps)
	{
		RegisterEvent("ScrapsGained", "Location", location, new Hashtable { { "Tickets", scraps } });
	}

	public void RegisterGameItemBoughtElite(string parameterValue, int parts, int warbucks)
	{
		RegisterEvent("Buy_Upgrade_For_Army_Unit_Elite", "Army_Unit_ID", parameterValue, new Hashtable
		{
			{ "Parts", parts },
			{ "Warbucks", warbucks }
		});
	}

	public void RegisterScrappingParts(string unit, int parts, int scraps)
	{
		RegisterEvent("ScrappingParts", "Army_Unit_ID", unit, new Hashtable
		{
			{ "Parts", parts },
			{ "Scraps", scraps }
		});
	}

	public void RegisterPartsGainedFromScraps(string unitId, int parts)
	{
		RegisterEvent("PartssGainedScraps", "UnitID", unitId, new Hashtable { { "Parts", parts } });
	}

	private void OnApplicationFocus(bool focus)
	{
		Debug.LogFormat("Application focus changed to {0} and have created AWS mobile analytics {1}", focus, mAwsEvents != null);
		if (mAwsEvents != null)
		{
			mAwsEvents.ChangeFocuse(focus);
		}
	}

	public void LoginToFacebook()
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		RegisterEvent("Fb_login", "PlayerLevel", LevelManager.instance.currentLevel.displayNumber.ToString(CultureInfo.InvariantCulture), new Hashtable { 
		{
			"Days_Since_Install",
			data.GetDaysSinceInstall()
		} });
	}

	public void RegisterInApp(string poducId, float value1, string value2, string getTransactionId, string currencyCode)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		RegisterEvent("Purchase_Validated", "InApp_ID", poducId, new Hashtable { 
		{
			"Days_Since_Install",
			data.GetDaysSinceInstall()
		} });
	}

	public void SpecialOffer(string actionValue)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		RegisterEvent("Special_Sale", "Action", actionValue, new Hashtable { 
		{
			"Days_Since_Install",
			data.GetDaysSinceInstall()
		} });
	}
}
