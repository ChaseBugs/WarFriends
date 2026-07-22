using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class CardConstants : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ExplosivePistolDamageMin,
			ExplosivePistolDamageMax,
			LandMineDamageMin,
			LandMineDamageMax,
			ClusterGrenadeDamageMin,
			ClusterGrenadeDamageMax,
			AmmoBoxCoef,
			AmmoThiefCoef,
			BrokenLegsTime,
			SmallMedKitCoef,
			MedKitCoef,
			BigMedKitCoefMin,
			BigMedKitCoefMax,
			BigMedKitTime,
			VehicleUpgradeCoef,
			VehicleUpgradeTime,
			SuperSoldiersCoef,
			SuperSoldiersTime,
			KevlarUpCoef,
			ShiedlsRefectionTime,
			SoldierOnSteroidsCoef,
			ShieldsUpCoef,
			BoobyTrapDamage,
			MineYourStepDamageCoef,
			DisarmedTime,
			BelovedEnemyTime,
			BelovedEnemySpeed,
			SwiftImmortalityTime,
			HeadAheadCritical,
			HeadAheadTime,
			CardsForRewardedVideo,
			CardsForVip,
			DecoyHpMin,
			DecoyHpMax,
			ChanceToGetCard1,
			ChanceToGetcard1MaxLevel,
			ChanceToGetCard2,
			ChanceToGetcard2MaxLevel,
			ChanceToGetCard3,
			BuddyDepositTimer,
			RepPointsBronzeCard,
			RepPointsSilverCard,
			RepPointsGoldCard,
			RepPointsBuddyCard,
			BuddyCardDangerCoef,
			WarcardsUnlockLevel,
			ClusterGrenadePlayerBehindShieldConstant,
			ClusterGrenadePlayerDamageConstant,
			ClusterGrenadePlayerDamageOvertimeConstant,
			ExplosivePistolPlayerBehindShieldConstant
		}

		public string[] rowNames = new string[50]
		{
			"ExplosivePistolDamageMin", "ExplosivePistolDamageMax", "LandMineDamageMin", "LandMineDamageMax", "ClusterGrenadeDamageMin", "ClusterGrenadeDamageMax", "AmmoBoxCoef", "AmmoThiefCoef", "BrokenLegsTime", "SmallMedKitCoef",
			"MedKitCoef", "BigMedKitCoefMin", "BigMedKitCoefMax", "BigMedKitTime", "VehicleUpgradeCoef", "VehicleUpgradeTime", "SuperSoldiersCoef", "SuperSoldiersTime", "KevlarUpCoef", "ShiedlsRefectionTime",
			"SoldierOnSteroidsCoef", "ShieldsUpCoef", "BoobyTrapDamage", "MineYourStepDamageCoef", "DisarmedTime", "BelovedEnemyTime", "BelovedEnemySpeed", "SwiftImmortalityTime", "HeadAheadCritical", "HeadAheadTime",
			"CardsForRewardedVideo", "CardsForVip", "DecoyHpMin", "DecoyHpMax", "ChanceToGetCard1", "ChanceToGetcard1MaxLevel", "ChanceToGetCard2", "ChanceToGetcard2MaxLevel", "ChanceToGetCard3", "BuddyDepositTimer",
			"RepPointsBronzeCard", "RepPointsSilverCard", "RepPointsGoldCard", "RepPointsBuddyCard", "BuddyCardDangerCoef", "WarcardsUnlockLevel", "ClusterGrenadePlayerBehindShieldConstant", "ClusterGrenadePlayerDamageConstant", "ClusterGrenadePlayerDamageOvertimeConstant", "ExplosivePistolPlayerBehindShieldConstant"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "ExplosivePistolDamageMin", 0 },
			{ "ExplosivePistolDamageMax", 1 },
			{ "LandMineDamageMin", 2 },
			{ "LandMineDamageMax", 3 },
			{ "ClusterGrenadeDamageMin", 4 },
			{ "ClusterGrenadeDamageMax", 5 },
			{ "AmmoBoxCoef", 6 },
			{ "AmmoThiefCoef", 7 },
			{ "BrokenLegsTime", 8 },
			{ "SmallMedKitCoef", 9 },
			{ "MedKitCoef", 10 },
			{ "BigMedKitCoefMin", 11 },
			{ "BigMedKitCoefMax", 12 },
			{ "BigMedKitTime", 13 },
			{ "VehicleUpgradeCoef", 14 },
			{ "VehicleUpgradeTime", 15 },
			{ "SuperSoldiersCoef", 16 },
			{ "SuperSoldiersTime", 17 },
			{ "KevlarUpCoef", 18 },
			{ "ShiedlsRefectionTime", 19 },
			{ "SoldierOnSteroidsCoef", 20 },
			{ "ShieldsUpCoef", 21 },
			{ "BoobyTrapDamage", 22 },
			{ "MineYourStepDamageCoef", 23 },
			{ "DisarmedTime", 24 },
			{ "BelovedEnemyTime", 25 },
			{ "BelovedEnemySpeed", 26 },
			{ "SwiftImmortalityTime", 27 },
			{ "HeadAheadCritical", 28 },
			{ "HeadAheadTime", 29 },
			{ "CardsForRewardedVideo", 30 },
			{ "CardsForVip", 31 },
			{ "DecoyHpMin", 32 },
			{ "DecoyHpMax", 33 },
			{ "ChanceToGetCard1", 34 },
			{ "ChanceToGetcard1MaxLevel", 35 },
			{ "ChanceToGetCard2", 36 },
			{ "ChanceToGetcard2MaxLevel", 37 },
			{ "ChanceToGetCard3", 38 },
			{ "BuddyDepositTimer", 39 },
			{ "RepPointsBronzeCard", 40 },
			{ "RepPointsSilverCard", 41 },
			{ "RepPointsGoldCard", 42 },
			{ "RepPointsBuddyCard", 43 },
			{ "BuddyCardDangerCoef", 44 },
			{ "WarcardsUnlockLevel", 45 },
			{ "ClusterGrenadePlayerBehindShieldConstant", 46 },
			{ "ClusterGrenadePlayerDamageConstant", 47 },
			{ "ClusterGrenadePlayerDamageOvertimeConstant", 48 },
			{ "ExplosivePistolPlayerBehindShieldConstant", 49 }
		};

		public List<CardConstantsRow> Rows = new List<CardConstantsRow>();

		public override bool haveDictionary => true;

		public override int getColumnCount => 2;

		public override int GetRowIndex(string rowID)
		{
			if (namesToIndex.ContainsKey(rowID))
			{
				return namesToIndex[rowID];
			}
			return -1;
		}

		public override void AddRowGeneric(List<string> input)
		{
			Rows.Add(new CardConstantsRow(input[0], input[1], input[2]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new CardConstantsRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 3)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new CardConstantsRow(input[0], input[1], input[2]));
			mRows = null;
			return namesToIndex[input[0]];
		}

		public override void CheckRows(List<string> rowIds)
		{
			int num = rowNames.Length;
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, int> item in namesToIndex)
			{
				if (item.Value >= num && !rowIds.Contains(item.Key))
				{
					list.Add(item.Key);
				}
			}
			foreach (string item2 in list)
			{
				int num2 = namesToIndex[item2];
				if (num2 == Rows.Count - 1)
				{
					namesToIndex.Remove(item2);
					Rows.RemoveAt(Rows.Count - 1);
					continue;
				}
				int num3 = Rows.Count - 1;
				string key = string.Empty;
				foreach (KeyValuePair<string, int> item3 in namesToIndex)
				{
					if (item3.Value == num3)
					{
						key = item3.Key;
						break;
					}
				}
				namesToIndex[key] = num2;
				Rows[num2] = Rows[num3];
				namesToIndex.Remove(item2);
				Rows.RemoveAt(Rows.Count - 1);
			}
			mRows = null;
		}

		public override void Clear()
		{
			Rows.Clear();
		}

		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow result = null;
			try
			{
				result = Rows[(int)Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch (ArgumentException)
			{
				Debug.LogError(in_RowString + " is not a member of the rowIds enumeration.");
			}
			return result;
		}

		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow result = null;
			try
			{
				result = Rows[(int)in_RowID];
			}
			catch (KeyNotFoundException ex)
			{
				Debug.LogError(string.Concat(in_RowID, " not found: ", ex.Message));
			}
			return result;
		}

		public CardConstantsRow GetRow(rowIds in_RowID)
		{
			CardConstantsRow result = null;
			try
			{
				result = Rows[(int)in_RowID];
			}
			catch (KeyNotFoundException ex)
			{
				Debug.LogError(string.Concat(in_RowID, " not found: ", ex.Message));
			}
			return result;
		}

		public CardConstantsRow GetRow(string in_RowString)
		{
			CardConstantsRow result = null;
			if (namesToIndex.ContainsKey(in_RowString))
			{
				result = Rows[namesToIndex[in_RowString]];
			}
			else
			{
				Debug.LogError(in_RowString + " is not stored in translate dictionary.");
			}
			return result;
		}
	}
}
