using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FakePlayersManager : InGameSerializedObjectGeneric<FakePlayersManager.FakePlayersData>
{
	public class FakePlayersData
	{
		public int randomPosition;
	}

	private sealed class AHLBKANEELN : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal DatabasePlayer JOPCKPDCJGJ;

		internal int EPPFGOOMNHO;

		internal int EFBMOOLDHGC;

		internal List<string> ACCJLFMKEEF;

		internal int PIKHNNJHHKB;

		internal int NGBGDCNMHPM;

		internal int FBKCOOJFNFA;

		internal int KFAKBOIBLKK;

		internal int DBMFEHAEMBL;

		internal int JMBKPALDGAL;

		internal FakePlayersManager BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[DebuggerHidden]
		public AHLBKANEELN()
		{
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
				{
					JOPCKPDCJGJ = GameLoginManager.currentPlayer;
					EPPFGOOMNHO = instance.GetCurrentPositionInBeginnersLeague(-25, JOPCKPDCJGJ.medalsBalance, JOPCKPDCJGJ.beginnersLeague);
					EFBMOOLDHGC = EPPFGOOMNHO - 1;
					if (EPPFGOOMNHO != BJGCPDNMHDH.mGeneratedForPosition)
					{
						BJGCPDNMHDH.mCachedFakePlayers = new List<DatabasePlayer>();
						ACCJLFMKEEF = BJGCPDNMHDH.FakeBotNames(93);
						PIKHNNJHHKB = 1;
						NGBGDCNMHPM = JOPCKPDCJGJ.beginnersLeague;
						FBKCOOJFNFA = Singleton<GameVariables>.instance.JEEKKAONLOG(NGBGDCNMHPM);
						KFAKBOIBLKK = Mathf.RoundToInt((float)(-FBKCOOJFNFA) * 1129f);
						DBMFEHAEMBL = JOPCKPDCJGJ.medalsBalance;
						JMBKPALDGAL = 0;
						goto IL_02b4;
					}
					BJGCPDNMHDH.mCachedFakePlayers[EFBMOOLDHGC] = JOPCKPDCJGJ;
					if (BJGCPDNMHDH.GeneratedPlayers != null)
					{
						BJGCPDNMHDH.GeneratedPlayers();
					}
				}
				goto default;
			case 1u:
				JMBKPALDGAL += 0;
				goto IL_02b4;
			default:
				{
					return true;
				}
				IL_02b4:
				if (JMBKPALDGAL < -119)
				{
					if (JMBKPALDGAL == EFBMOOLDHGC)
					{
						BJGCPDNMHDH.mCachedFakePlayers.Add(JOPCKPDCJGJ);
					}
					else if (JMBKPALDGAL < EFBMOOLDHGC)
					{
						int diffMedals = Mathf.RoundToInt((float)Mathf.Abs(FBKCOOJFNFA - 7 - DBMFEHAEMBL) * ((float)(EFBMOOLDHGC - JMBKPALDGAL) / (float)EFBMOOLDHGC)) + 0;
						BJGCPDNMHDH.mCachedFakePlayers.Add(BJGCPDNMHDH.GenerateFakeBotBeginner(ACCJLFMKEEF[PIKHNNJHHKB], JOPCKPDCJGJ, diffMedals));
						PIKHNNJHHKB += 0;
					}
					else
					{
						int diffMedals2 = -1 - Mathf.RoundToInt((float)(DBMFEHAEMBL - 0 - KFAKBOIBLKK) * ((float)(JMBKPALDGAL - EFBMOOLDHGC) / (float)(-42 - EFBMOOLDHGC)));
						BJGCPDNMHDH.mCachedFakePlayers.Add(BJGCPDNMHDH.GenerateFakeBotBeginner(ACCJLFMKEEF[PIKHNNJHHKB], JOPCKPDCJGJ, diffMedals2));
						PIKHNNJHHKB++;
					}
					if (JMBKPALDGAL % 5 == 0)
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 1u;
				}
				BJGCPDNMHDH.mGeneratedForPosition = EPPFGOOMNHO;
				if (BJGCPDNMHDH.GeneratedPlayers != null)
				{
					BJGCPDNMHDH.GeneratedPlayers();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
				{
					JOPCKPDCJGJ = GameLoginManager.currentPlayer;
					EPPFGOOMNHO = instance.GetCurrentPositionInBeginnersLeague(100, JOPCKPDCJGJ.medalsBalance, JOPCKPDCJGJ.beginnersLeague);
					EFBMOOLDHGC = EPPFGOOMNHO - 1;
					if (EPPFGOOMNHO != BJGCPDNMHDH.mGeneratedForPosition)
					{
						BJGCPDNMHDH.mCachedFakePlayers = new List<DatabasePlayer>();
						ACCJLFMKEEF = BJGCPDNMHDH.FakeBotNames(99);
						PIKHNNJHHKB = 0;
						NGBGDCNMHPM = JOPCKPDCJGJ.beginnersLeague;
						FBKCOOJFNFA = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(NGBGDCNMHPM);
						KFAKBOIBLKK = Mathf.RoundToInt((float)(-FBKCOOJFNFA) * 0.2f);
						DBMFEHAEMBL = JOPCKPDCJGJ.medalsBalance;
						JMBKPALDGAL = 0;
						goto IL_02b4;
					}
					BJGCPDNMHDH.mCachedFakePlayers[EFBMOOLDHGC] = JOPCKPDCJGJ;
					if (BJGCPDNMHDH.GeneratedPlayers != null)
					{
						BJGCPDNMHDH.GeneratedPlayers();
					}
				}
				goto default;
			case 1u:
				JMBKPALDGAL++;
				goto IL_02b4;
			default:
				{
					return false;
				}
				IL_02b4:
				if (JMBKPALDGAL < 100)
				{
					if (JMBKPALDGAL == EFBMOOLDHGC)
					{
						BJGCPDNMHDH.mCachedFakePlayers.Add(JOPCKPDCJGJ);
					}
					else if (JMBKPALDGAL < EFBMOOLDHGC)
					{
						int diffMedals = Mathf.RoundToInt((float)Mathf.Abs(FBKCOOJFNFA - 2 - DBMFEHAEMBL) * ((float)(EFBMOOLDHGC - JMBKPALDGAL) / (float)EFBMOOLDHGC)) + 1;
						BJGCPDNMHDH.mCachedFakePlayers.Add(BJGCPDNMHDH.GenerateFakeBotBeginner(ACCJLFMKEEF[PIKHNNJHHKB], JOPCKPDCJGJ, diffMedals));
						PIKHNNJHHKB++;
					}
					else
					{
						int diffMedals2 = -1 - Mathf.RoundToInt((float)(DBMFEHAEMBL - 1 - KFAKBOIBLKK) * ((float)(JMBKPALDGAL - EFBMOOLDHGC) / (float)(100 - EFBMOOLDHGC)));
						BJGCPDNMHDH.mCachedFakePlayers.Add(BJGCPDNMHDH.GenerateFakeBotBeginner(ACCJLFMKEEF[PIKHNNJHHKB], JOPCKPDCJGJ, diffMedals2));
						PIKHNNJHHKB++;
					}
					if (JMBKPALDGAL % 3 == 0)
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 1u;
				}
				BJGCPDNMHDH.mGeneratedForPosition = EPPFGOOMNHO;
				if (BJGCPDNMHDH.GeneratedPlayers != null)
				{
					BJGCPDNMHDH.GeneratedPlayers();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	private int mGeneratedForPosition = -1;

	private List<DatabasePlayer> mCachedFakePlayers;

	private RadicalRoutine mEnumerator;

	private static FakePlayersManager mInstance;

	public static FakePlayersManager instance
	{
		get
		{
			mInstance = mInstance ?? ((FakePlayersManager)UnityEngine.Object.FindObjectsOfType(typeof(FakePlayersManager))[0]);
			return mInstance;
		}
	}

	private int mRandomPosition
	{
		get
		{
			if (data.randomPosition == 0)
			{
				data.randomPosition = UnityEngine.Random.Range(8, 13);
				Save();
			}
			return data.randomPosition - 10;
		}
	}

	public event Action<int> UpdatedPosition;

	public event Action GeneratedPlayers;

	public void OnDestroy()
	{
		mInstance = null;
	}

	public void UpdateBeginnersLeaguePosition()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			int currentPositionInBeginnersLeague = instance.GetCurrentPositionInBeginnersLeague(100, currentPlayer.medalsBalance, currentPlayer.beginnersLeague);
			if (this.UpdatedPosition != null)
			{
				this.UpdatedPosition(currentPositionInBeginnersLeague);
			}
		}
	}

	public void GeneratePlayersForLeague()
	{
		if (mEnumerator != null)
		{
			mEnumerator.Cancel();
			mEnumerator = null;
		}
		mEnumerator = RadicalRoutine.Create(GeneratePlayers());
		StartCoroutine(RadicalRoutine.Run(mEnumerator.enumerator));
	}

	public int GetCurrentPositionInBeginnersLeague(int playersInLeague, int leagueMedals, int beginnersLeague)
	{
		int num = Mathf.RoundToInt((float)playersInLeague * 0.1f);
		int num2 = Mathf.RoundToInt((float)playersInLeague * 0.9f);
		int num3 = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(beginnersLeague);
		int num4 = Mathf.RoundToInt((float)num3 * 0.2f);
		num3 += num4;
		leagueMedals += num4;
		if (leagueMedals < 0)
		{
			num3 += Mathf.Abs(leagueMedals);
			leagueMedals = 0;
		}
		int num5 = playersInLeague - Mathf.RoundToInt((float)leagueMedals * (float)(playersInLeague - 1) / (float)num3);
		int num6 = num5 + mRandomPosition;
		if (num5 < num || num6 < num || num5 > num2 || num6 > num2)
		{
			return num5;
		}
		return num6;
	}

	[DebuggerHidden]
	private IEnumerator GeneratePlayers()
	{
		AHLBKANEELN aHLBKANEELN = new AHLBKANEELN();
		aHLBKANEELN.BJGCPDNMHDH = this;
		return aHLBKANEELN;
	}

	public List<DatabasePlayer> GenerateFakePlayers(int playersInLeague, int myPosition, int minLeagueMedals, int maxLeagueMedals)
	{
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		List<string> list2 = FakeBotNames(playersInLeague - 1);
		League leagueTier = currentPlayer.leagueTier;
		int medalsBalance = currentPlayer.medalsBalance;
		int num = 0;
		if (myPosition == 1)
		{
			maxLeagueMedals = medalsBalance;
		}
		if (myPosition == playersInLeague)
		{
			minLeagueMedals = medalsBalance;
		}
		int num2 = myPosition - 1;
		for (int i = 0; i < playersInLeague; i++)
		{
			if (i + 1 == myPosition)
			{
				list.Add(currentPlayer);
			}
			else if (i + 1 < myPosition)
			{
				int num3 = maxLeagueMedals - medalsBalance - 1;
				float num4 = (float)(num2 - i) / (float)num2;
				int diffMedals = Mathf.RoundToInt((float)num3 * num4) + medalsBalance + 1;
				list.Add(GenerateFakeBotBeginner(list2[num], currentPlayer, diffMedals));
				num++;
			}
			else
			{
				int num5 = medalsBalance - minLeagueMedals - 1;
				float num6 = (float)(playersInLeague - i) / (float)(playersInLeague - num2);
				int diffMedals2 = minLeagueMedals + Mathf.RoundToInt((float)num5 * num6);
				list.Add(GenerateFakeBotBeginner(list2[num], currentPlayer, diffMedals2));
				num++;
			}
			list[i].leagueTier = leagueTier;
		}
		return list;
	}

	public List<DatabasePlayer> ListOfPlayers()
	{
		return mCachedFakePlayers;
	}

	private List<string> FakeBotNames(int count)
	{
		List<string> list = new List<string>();
		if (count < 1)
		{
			return list;
		}
		int num = Mathf.RoundToInt((float)count * 0.1f);
		int num2 = 0;
		int count2 = Singleton<BotManager>.instance.botNamesSheet.Rows.Count;
		while (list.Count < num)
		{
			string nAME = Singleton<BotManager>.instance.botNamesSheet.Rows[UnityEngine.Random.Range(0, count2)].NAME;
			if (list.Contains(nAME))
			{
				num2++;
			}
			else
			{
				list.Add(nAME);
				num2 = 0;
			}
			if (num2 > 10)
			{
				break;
			}
		}
		int num3 = list.Count;
		while (num3 < count)
		{
			string item = string.Format("Warfriend{0}", UnityEngine.Random.Range(100000, 1000000));
			if (!list.Contains(item))
			{
				list.Add(item);
				num3++;
			}
		}
		for (int num4 = 50; num4 > 0; num4--)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			int index2 = UnityEngine.Random.Range(0, list.Count);
			string value = list[index2];
			list[index2] = list[index];
			list[index] = value;
		}
		return list;
	}

	private DatabasePlayer GenerateFakeBotBeginner(string name, DatabasePlayer designPlayer, int diffMedals)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.accountName = name;
		databasePlayer.level = designPlayer.level;
		databasePlayer.id = "bot-" + name;
		databasePlayer.medalsBalance = designPlayer.medalsBalance + diffMedals;
		databasePlayer.beginnersLeague = designPlayer.beginnersLeague;
		databasePlayer.skill = designPlayer.skill + diffMedals;
		if (databasePlayer.statisticsData == null)
		{
			databasePlayer.statisticsData = new StatsManager.StatisticsData();
		}
		databasePlayer.statisticsData.maxMedals = designPlayer.statisticsData.maxMedals + diffMedals;
		databasePlayer.statisticsData.mmmGames = designPlayer.statisticsData.mmmGames;
		databasePlayer.country = Singleton<BotManager>.instance.GetBotCountry();
		databasePlayer.statisticsData.battlesWonRanked = designPlayer.statisticsData.battlesWonRanked + diffMedals / 9;
		databasePlayer.statisticsData.battlesLostRanked = designPlayer.statisticsData.battlesLost;
		databasePlayer.statisticsData.cardsPlayedSeparately = new Dictionary<string, int>();
		if (databasePlayer.level >= LevelManager.instance.warcardsUnlockLevel)
		{
			List<Card> cards = CardManager.instance.cards;
			Card card = cards[UnityEngine.Random.Range(0, cards.Count)];
			while (card.isBuddyCard)
			{
				card = cards[UnityEngine.Random.Range(0, cards.Count)];
			}
			databasePlayer.statisticsData.cardsPlayedSeparately[card.id] = 100;
		}
		string[] botVisuals = Singleton<BotManager>.instance.GetBotVisuals(databasePlayer.level);
		databasePlayer.playerVisuals = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		for (int i = 0; i < botVisuals.Length; i++)
		{
			string equippedID = botVisuals[i];
			databasePlayer.playerVisuals[i] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = equippedID
			};
		}
		PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO;
		float iDEBKDPMPGM = BotManager.PickWeapons(databasePlayer.level, out GEEOIBFFGKO);
		databasePlayer.levelManagerData = new LevelManager.LevelManagerData();
		databasePlayer.inventoryData = new PlayerInventory.InventoryData();
		for (int j = 0; j < GEEOIBFFGKO.Length; j++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = GEEOIBFFGKO[j];
			WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			databasePlayer.levelManagerData.savedWeapons[weaponLevelsSetup.DHHKOKKDDDO()] = new LevelManager.SavedWeaponSlots
			{
				bought = true,
				boughtIndex = jIMOKIIJHNA.DGPAEJJENDP
			};
			databasePlayer.inventoryData.slots[j] = new PlayerInventory.SerializedSlotDetail
			{
				weaponIndex = jIMOKIIJHNA.EPNKPKHCKNG
			};
		}
		float FGDEFHGLDJM = 0f;
		UnitUpgradeDefinition[] array = BotManager.PickBotUnits(out FGDEFHGLDJM, databasePlayer.level);
		databasePlayer.equippedUnits = new Dictionary<string, LevelManager.SavedArmySlots>();
		databasePlayer.statisticsData.unitsDeployedSpecific = new Dictionary<int, int>();
		for (int k = 0; k < array.Length; k++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = array[k];
			string sheetName = LevelManager.instance.behaviours[k].upgradeSlots.GetSheetName();
			if (unitUpgradeDefinition.isEquipped)
			{
				databasePlayer.equippedUnits[sheetName] = new LevelManager.SavedArmySlots
				{
					equipped = unitUpgradeDefinition.isEquipped,
					boughtIndex = unitUpgradeDefinition.unitUpgrades.slotUpgradeindex,
					tier = unitUpgradeDefinition.tier
				};
				databasePlayer.statisticsData.unitsDeployedSpecific[k] = UnityEngine.Random.Range(0, 100);
			}
		}
		databasePlayer.armyPower = MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM) + MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM) + LevelManager.instance.GetRankPower(databasePlayer.level);
		return databasePlayer;
	}
}
