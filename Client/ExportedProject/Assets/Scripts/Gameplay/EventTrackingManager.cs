using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using CodeStage.AdvancedFPSCounter;
using FuseMisc;
using Google2u;
using Newtonsoft.Json.Linq;
using Prime31;
using UnityEngine;

public class EventTrackingManager : Singleton<EventTrackingManager>
{
	public class KHHOMCIOKAO
	{
		public LinkedList<int> GACNCMKFLAK;

		public LinkedList<int> LEDOBPEHKKF;

		public LinkedList<int> KMKOKFINGBH;

		public LinkedList<int> DOELMJFBICE;

		public bool OMKCLHMDMIO;

		public bool MJPCENBJKAO
		{
			get
			{
				int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxesAdCount).FLOATVALUE;
				int num2 = 3600 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxesAdInterval).FLOATVALUE;
				int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
				while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
				{
					DOELMJFBICE.RemoveFirst();
				}
				return DOELMJFBICE.Count < num;
			}
		}

		public bool MAAHGMHKANN
		{
			get
			{
				int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WarcardAdCount).FLOATVALUE;
				int num2 = 3600 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WarcardAdInterval).FLOATVALUE;
				int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
				while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
				{
					GACNCMKFLAK.RemoveFirst();
				}
				return GACNCMKFLAK.Count < num;
			}
		}

		public bool NDMDHENBNMA
		{
			get
			{
				int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogtagAdCount).FLOATVALUE;
				int num2 = 3600 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogtagAdInterval).FLOATVALUE;
				int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
				while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
				{
					LEDOBPEHKKF.RemoveFirst();
				}
				return LEDOBPEHKKF.Count < num;
			}
		}

		public int NDBEFFKLOPA
		{
			get
			{
				int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcaseAdCount).Get_FLOATVALUE;
				int num2 = 3600 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcaseAdInterval).FLOATVALUE;
				int num3 = 60 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcaseAdTimeBetweenMinutes).FLOATVALUE;
				int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				int num4 = currentTimestamp - num2;
				while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
				{
					KMKOKFINGBH.RemoveFirst();
				}
				if (KMKOKFINGBH.Count > 0)
				{
					int num5 = KMKOKFINGBH.Last.Value + num3;
					if (KMKOKFINGBH.Count >= num)
					{
						int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public bool BLGOBPFMCGF()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-14)).FLOATVALUE;
			int num2 = -185 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.EasyBotHpCoeficient).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public int CPCJOBKFDFL()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.DogtagAdInterval).Get_FLOATVALUE;
			int num2 = 193 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-18)).FLOATVALUE;
			int num3 = -8 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-125)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public bool IAODMBKIFDN()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-75)).FLOATVALUE;
			int num2 = 27 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-57)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		public void BOFPPPBHJEN(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["Wrong_Category"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI[" "])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item, 1);
					if (num == 0)
					{
						UnityEngine.Debug.Log("Caught Exception at startup ");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["ID_ARENARULES_DEFENDERSPROHIBITED"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["Finish game network"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2, 1);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("Brutal fatal error - no current player");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["cardPack"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Directory \"{0}\" does not exists"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("WarBucks");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["ID_STATE_DISCONNECTED"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_COMPLETETIER"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("ID_CURRENTRANK");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool ODLAMPHODKC()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-113)).FLOATVALUE;
			int num2 = 195 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-75)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool DMEIDFMABPA()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE;
			int num2 = 61 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward9).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool BPINMCIMCON()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalPowerbandDelayMin).FLOATVALUE;
			int num2 = -162 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-7)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		public void ODLOEGIADPI(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["{0} {1}/[-] {2}"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["Scripts"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item, 1);
					if (num == 0)
					{
						UnityEngine.Debug.Log("Start TimeLock: ");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI[" {0}\u00a0{1}"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_SALEPERCENTLINE"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("Total_Gold_Spent");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["_FrustumCornersWS"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Input turned OFF completely: "])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("CustomizationTutorialMessage");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["#PETER# Weapon Screen - LEFT BUTTON - weapon is rented - do nothing"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["AdFailedToDisplay()"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("InAppHandlerIos: ProductID is null, not proceding ...");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool HLMHFBPJPNE()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WarcardAdInterval).FLOATVALUE;
			int num2 = 74 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-50)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public int DLMOECGIPPN()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.UnitCategoriesReminderAfterGames).Get_FLOATVALUE;
			int num2 = -90 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-101)).FLOATVALUE;
			int num3 = 73 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-47)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public int HDOMCBKCODM()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-13)).Get_FLOATVALUE;
			int num2 = 192 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcaseAdInterval).FLOATVALUE;
			int num3 = 72 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-73)).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public int MKCHIEHEOFI()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-49)).Get_FLOATVALUE;
			int num2 = 40 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
			int num3 = -43 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-80)).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public int DPDPKFCEOBN()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-61)).Get_FLOATVALUE;
			int num2 = 43 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-56)).FLOATVALUE;
			int num3 = -72 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-85)).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public bool LLHGJDLJLEE()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GooglePlayLoginReward).FLOATVALUE;
			int num2 = 47 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-47)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		public void DKANICPHBKI(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["Skillshot {0}"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["hasResolution"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("ID_BRONZEPACK");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["IMMORTAL"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["Gold"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("game-card-silver-big");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["lapsed_player_2"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Selected "])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("ID_GETSP");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["game-elite-debuff1"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["response for {0}"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("Shown_Before_Times");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool EECLHBJIMGO()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipWarbucksMultiplier).FLOATVALUE;
			int num2 = -167 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-68)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool EJNCACEFPCD()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-174)).FLOATVALUE;
			int num2 = 172 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-183)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		public void ANFJMAGNHBI(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["videoAdRewardTimes"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["ExpireTime"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item, 1);
					if (num == 0)
					{
						UnityEngine.Debug.Log("EventDefinition");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["{0} {1}"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_STAT_UNITSDEPLOYED"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("FacebookName");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI[" bonusIcon:"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Setting performance to: "])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("Bad player statistics, data= ");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["Weapon upgrade for "] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["WarFriends"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("-----BEGIN CERTIFICATE-----MIIDwDCCAqgCCQCAhUcHjX7uoDANBgkqhkiG9w0BAQUFADCBoTELMAkGA1UEBhMCQ1oxDzANBgNVBAgMBlByYWd1ZTEPMA0GA1UEBwwGUHJhZ3VlMRIwEAYDVQQKDAlBYm91dCBGdW4xCzAJBgNVBAsMAklUMSswKQYDVQQDDCJ3YXJmcmllbmRzLWV1LmVsYXN0aWNiZWFuc3RhbGsuY29tMSIwIAY");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public int DAGFIJLMENH()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalMaxLockedForWeapon).Get_FLOATVALUE;
			int num2 = 71 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-66)).FLOATVALUE;
			int num3 = -103 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-34)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public int NLEKHHLENJF()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).Get_FLOATVALUE;
			int num2 = -41 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-63)).FLOATVALUE;
			int num3 = 51 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-78)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public bool IGMGIDAGAID()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmyPowerWeaponConstant).FLOATVALUE;
			int num2 = 92 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcaseAdInterval).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public int BKDNCONPIBM()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TimeBetweenVIPreminderShown).Get_FLOATVALUE;
			int num2 = 148 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CreateSquadUnlockLevel).FLOATVALUE;
			int num3 = 91 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SilverCardRarity).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public bool AKFBPLNMIIG()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-99)).FLOATVALUE;
			int num2 = 181 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-19)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public int CLHBKLHIPGA()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.BronzePackMaxRarityCardsType).Get_FLOATVALUE;
			int num2 = -178 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalWoUDelayMax).FLOATVALUE;
			int num3 = 102 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		public void BALLBFFNMAH(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["ID_SQUADREQUIREDMEDALS"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["N"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item, 1);
					if (num == 0)
					{
						UnityEngine.Debug.Log("OK");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["PrepareBotForDeathMatch 7"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["animationEnd"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("Conversion");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["qbz_idle"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Vip"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("ID_GUI_LEAGUEBONUS");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["-VIP"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_READYTIME"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("ArenaLives");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool MANJFLOEGMB()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-2)).FLOATVALUE;
			int num2 = -98 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-72)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		public void JBBHHBGKGHJ(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["Cards on saved data: "] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["clipSize"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("{0}98 FORGOT SPAWN");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["HKCBJLIBNJF"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["id"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("ID_STAT_ALLTIMESQUADPOINTS");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["MissionData"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["DogTagLastUpdate"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("ID_CONFIRM_WRONGPLAYERDATA");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["ID_CONFIRM_ERROR"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["{0}{1}[-] / {2}"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("ID_RETRY");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool KMKALIPBFMD()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.TimeBetweenUnitUpgradeReminderShown).FLOATVALUE;
			int num2 = -173 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SilverPackGuaranteedCardsType).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool OAFABIPGJOO()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadMedalWeight2).FLOATVALUE;
			int num2 = 184 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.EasyBotHpCoeficient).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool BFKDLNNOACA()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-9)).FLOATVALUE;
			int num2 = 118 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalMaxWeapons).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public int NNDFELIFEFJ()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-85)).Get_FLOATVALUE;
			int num2 = 95 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MinLevelForCardsReminder).FLOATVALUE;
			int num3 = 31 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadMedalWeight1).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		public void DLECJOCMCDO(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI[" ID_"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["_MIN_"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("GooglePlay");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["ID_COLLECTXELITEPARTSANDUPGRADETOELITE"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["RENTAL OFFER"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("OBB: Read Test - No data to read!");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["ID_BRONZEPACK"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["LEAVING ARENA BATTLE"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("Error parsing Fuseboxx configuration. Key = ");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["ManualRegisterForPushNotifications("] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["Chillingo: On Age Verification Pending Dialog Display "])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("ID_TOGETTOTHECOMPETITIVE");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool CGELIGAKABE()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-121)).FLOATVALUE;
			int num2 = 45 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-71)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool MIPADIPJJPD()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-11)).FLOATVALUE;
			int num2 = 52 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.UnitToShieldCoef).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		public void FJDJBOOILHK(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["FORCE DEBUG CONFIG VERSION "] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["can not find currency for: "])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item, 1);
					if (num == 0)
					{
						UnityEngine.Debug.Log("Days_Since_Install");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["S"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["There is no definition for card {0}"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2, 1);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("ID_DAYNUMBER");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["Wave"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["SquadWarsProcessing"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("ID_CLOSE");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["ChatClient: "] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["global"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("NumberOfMission");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		public KHHOMCIOKAO()
		{
			GACNCMKFLAK = new LinkedList<int>();
			LEDOBPEHKKF = new LinkedList<int>();
			KMKOKFINGBH = new LinkedList<int>();
			DOELMJFBICE = new LinkedList<int>();
			OMKCLHMDMIO = false;
		}

		[SpecialName]
		public int JMDNFEJJDMH()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-122)).Get_FLOATVALUE;
			int num2 = -50 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldPackMaxRarityCardsType).FLOATVALUE;
			int num3 = 97 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TimeBetweenVIPreminderShown).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		public void CHNNNOMCKCN(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["ID_TUTORIAL_PLAY_CARD_UP"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["#AccoutCheck# Facebook accoun found - invalid ID"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log(")");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["ID_SALEPERCENTLINE"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["{0} {1}{2} {3}"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("Gold");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["Value"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Automatic_Equip"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("Gold");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["{0}:\t{1}\n"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["tierCount"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("ID_ARENARULES_NOSHIELDS");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public int CBALNGPOBGJ()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseAdInterval).Get_FLOATVALUE;
			int num2 = 116 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-59)).FLOATVALUE;
			int num3 = -123 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-85)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		public void MENAHKIIFOC(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["warcards"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["warcards"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("something is wrong - time == 0");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["dogtags"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["dogtags"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("something is wrong - time == 0");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["goldenSuitcase"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["goldenSuitcase"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("something is wrong - time == 0");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["lootboxes"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["lootboxes"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("something is wrong - time == 0");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool KPKPELIEOOB()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalWeaponCanLockedCount).FLOATVALUE;
			int num2 = 138 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-75)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool GAACDNDKHIJ()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppMaxShow).FLOATVALUE;
			int num2 = -31 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-21)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool IBPHJFLBFKL()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-43)).FLOATVALUE;
			int num2 = 103 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-167)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public int ENNGKFMAJPH()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-62)).Get_FLOATVALUE;
			int num2 = -135 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-104)).FLOATVALUE;
			int num3 = 100 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-78)).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public bool LBCFJNMDOAH()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-49)).FLOATVALUE;
			int num2 = 98 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WarcardAdInterval).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool LBOHFHINNIF()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackGuaranteedCardsType).FLOATVALUE;
			int num2 = -190 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SquadWarsLowSquadsTier5Reward).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool MFKGFMHKLMJ()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-75)).FLOATVALUE;
			int num2 = 69 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-42)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool BBALPLJGCBL()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.MinTimeSinceLastUnitUpgrade).FLOATVALUE;
			int num2 = -122 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-188)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public int ONGOPGKBAPO()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-11)).Get_FLOATVALUE;
			int num2 = 1 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-16)).FLOATVALUE;
			int num3 = 8 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalPowerbandDelayMax).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		public void NCIBIPDCPLI(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["testingPlayerId"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["height"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("SquadMates");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["testingideventended"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_CONFIRM_ERROR"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2, 1);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("ID_WARNING_ACCOUNTALREADYCREATED");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["BlackMarketOffer"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_STAYINDIVISION"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("ID_WARNING_OFFEREXPIRED_TEXT");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["213 MENU ARMY SCREEN SHOWN"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["game-elite-debuff1"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("GrenadeExplodeDamage");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool GKIEPOLAILH()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinTimeSinceLastUnitUpgrade).FLOATVALUE;
			int num2 = -134 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-140)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool FKLDLMPMLOB()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-89)).FLOATVALUE;
			int num2 = -21 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalWoUDelayMin).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool PBMODEDFDHC()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-115)).FLOATVALUE;
			int num2 = -108 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxesAdCount).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool AIKKDDCEHGK()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldPackMaxRarityCardsType).FLOATVALUE;
			int num2 = -48 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.NotificationAllowHoursBetween).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool IANAAOGOPPC()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-124)).FLOATVALUE;
			int num2 = 177 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SilverPackSilverCards).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool IBCDGFGDHOH()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-81)).FLOATVALUE;
			int num2 = 128 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward4).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public int BHFNOMPKPAI()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MinLevelForCardsReminder).Get_FLOATVALUE;
			int num2 = 183 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-92)).FLOATVALUE;
			int num3 = 44 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.RateAppMaxShow).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		public void AEJGOEDKMLJ(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["Warbucks"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["DecalManagerData"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("Broadcast_End");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["ID_ERROR_SHORTINPUT"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["#AccoutCheck# Facebook accoun found - invalid ID"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2, 1);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("damage");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["ID_TONORMALLEAGUEHINT2"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["IsPublic"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("changing moneypack to B variant withoud data from fuseboxx");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["PlayerId"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["SkillRequirement"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("ID_MAXSTAT");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		public void JKBEJHMFDAI(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["squad"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["(Landroid/app/Activity;I)V"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("ID_READYTIME");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["ID_STAT_UNITSPURCHASED"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["Wrong_Category"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("\"INFINITY\"");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["WasAdded"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["N"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("{0} {1}");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["gold"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["Skillshot {0}"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("ID_WARNING_ACHIEVEMENTALREADYCLAIMED");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public int IMBEJJLEBLF()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-31)).Get_FLOATVALUE;
			int num2 = -67 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldPackGuaranteedCardsType).FLOATVALUE;
			int num3 = 105 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-88)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public int IPJPIIMLLBM()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-123)).Get_FLOATVALUE;
			int num2 = -21 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-52)).FLOATVALUE;
			int num3 = -45 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-68)).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public bool JFNIGDEGDDP()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.NotificationAllowMaxShow).FLOATVALUE;
			int num2 = 23 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-75)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool HBOCNGAPBDG()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-176)).FLOATVALUE;
			int num2 = -62 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcase_LootboxRewardChance).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool KKCBHJOFHAL()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-127)).FLOATVALUE;
			int num2 = 148 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-52)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool CBEDCICBPNB()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.LapsedPlayerInterval1).FLOATVALUE;
			int num2 = 158 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-163)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool ECHDFDIKMDC()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldPackGuaranteedCardsType).FLOATVALUE;
			int num2 = -113 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcaseAdTimeBetweenMinutes).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool JPNMLFAHEKN()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcaseAdTimeBetweenMinutes).FLOATVALUE;
			int num2 = -130 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-2)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public int LKBPHLBCOHD()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-59)).Get_FLOATVALUE;
			int num2 = -35 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalSaleMax).FLOATVALUE;
			int num3 = 47 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-75)).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		public void EFGIDJOEGGG(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["testingideventtierreward"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["Bad player regiones, data= "])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("Null photon view in PhotonLevelIDChanger");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["Skirmish"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["unregisterConnectionFailedListener"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("shotgun_reload");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["Visual {0}, overcount {1}, added warbucks {2}"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["#PHOTON# switching to TCP"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("Get Experiment Details");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["ID_YES"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["Vip days = "])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("AtlasPreparer.LoadGameCoroutine");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		public void NKEHJIIKLGJ(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["ID_EXPIRED"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["Step"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("ID_BANNEDFROMCHAT");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["ID_GUI_INVITETOFIGHT"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_RENTAL_MINIGUN"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2, 1);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("ID_STARTSINX");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["[CardSoldierOnSteroids] - used agan after spawning start, but before finish!!!"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_NUMMEMBERS"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("ID_SILVERCARDS");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["slotUpgradeindex: {0}, slotUpgradeIndexElite: {0}, slotUpgradeIndexSpecial {1},  isSpecial {2},  scaleDamage {3},  scaleHP {4}"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["Directory \"{0}\" does not exists"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log(", it was ");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public int NANKHPFINHN()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-88)).Get_FLOATVALUE;
			int num2 = -193 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.TwitterFollow).FLOATVALUE;
			int num3 = 85 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-72)).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public bool MJJPPOJINGC()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-124)).FLOATVALUE;
			int num2 = 12 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool KGJGLKBEBDE()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-117)).FLOATVALUE;
			int num2 = 62 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.TimeBetweenWeaponUpgradeReminderShown).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		public void NBLBDJKIMID(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["StartMovementAtTimeRPC"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["DogTagRefillTime"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("shotSniper");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["101 LOADING MAP"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["VisualType"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2, 1);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("DPS");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["ticketsSpent"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["fuse offer: {0}"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("\n{0}");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["ID_CONFIRM_SQUADNAMETAKEN"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["Result"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("rateAppClientVersion");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public int NHPBMCFEIAE()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-19)).Get_FLOATVALUE;
			int num2 = -35 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward1).FLOATVALUE;
			int num3 = -42 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ShieldRespawnRatePerSec).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public int BGOMLMAHACM()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldCardRarityEarly).Get_FLOATVALUE;
			int num2 = 29 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SilverPackSilverCards).FLOATVALUE;
			int num3 = -32 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.FacebookLike).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public bool PHIBEOCDNGC()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-45)).FLOATVALUE;
			int num2 = -145 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-81)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		public void IKKHDEBCGIL(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["menu-arena-ticket"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["ID_CANCEL"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("ID_GOODJOBYOUVEBEENPROMOTED");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["Reward"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["ABOUT TO SHOW DAILY RENTAL"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("Different squads \"{0}\" and \"{1}\"\n");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["ID_WARNING_CANTSENDINVITE_TEXT"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["NAME"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("Name");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["{0} {1}"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["Lcom/google/android/gms/games/quest/Quests;"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("DamageEventPlayerShoot damage: {0} to {1} new HP {2}");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		public void FCKGGHLPIJH(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["S"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["BUY: "])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("DESISTIR");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["#Notifications# registering {0} with name {1}\n{2}"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_READYTIME"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("Action ");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["response for {0}"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Beanstalk Error: "])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("menu-army-reload-ico");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["ID_YOUCANTYPEHERE"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["android"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("HeroicReward");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public int CLNFNDDBAMP()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.JoinSquadUnlockLevel).Get_FLOATVALUE;
			int num2 = 142 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipRunningOutSeconds).FLOATVALUE;
			int num3 = -43 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-4)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public bool OLBFKENKJKK()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-34)).FLOATVALUE;
			int num2 = -192 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-127)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool MKHLKGEKGLG()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-1)).FLOATVALUE;
			int num2 = 135 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-38)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool CNOGIEKBOMH()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-182)).FLOATVALUE;
			int num2 = 125 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-59)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public int HOFADIGHOEN()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalPowerbandDelayMin).Get_FLOATVALUE;
			int num2 = -66 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-6)).FLOATVALUE;
			int num3 = -3 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-42)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		public void PMHOGGAFEKM(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["MMICMBJKHFO"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["Skipping wararena notification"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("GoldCoefficient");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["registerBirthday"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["GoldTransactionAmount"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("ID_NOTIFICATION_DAILYREWARD_CARD");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["ID_READYTIME"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["BattleId"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("idle");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["ID_READYTIME"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["LevelName"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("SetDepositedCards ");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool ENDNNOKNLGO()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-55)).FLOATVALUE;
			int num2 = 35 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-84)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public int PEHDNJMNMBI()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-124)).Get_FLOATVALUE;
			int num2 = 99 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseAdTimeBetweenMinutes).FLOATVALUE;
			int num3 = -49 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-34)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		public void JLLNFIBIPCF(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["gold"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["menu-assignments-type-cards"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item, 1);
					if (num == 0)
					{
						UnityEngine.Debug.Log("Wrong_Weapon");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["tc"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["ArenaLives"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2, 1);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log(" Desc = ");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["Claim_Reward"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Total_Battles"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("+{0}");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["Checker"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_RANDOMMAP"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("+");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public int IPGKIDGJDBA()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SilverCardRarity).Get_FLOATVALUE;
			int num2 = -44 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-81)).FLOATVALUE;
			int num3 = 98 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalMaxLockedForWeapon).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public int JPIENJGLJDI()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcase_GoldRewardMin).Get_FLOATVALUE;
			int num2 = -130 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio).FLOATVALUE;
			int num3 = -100 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-52)).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public int FNEMPEPKBMN()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-17)).Get_FLOATVALUE;
			int num2 = -171 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalVisualProbability).FLOATVALUE;
			int num3 = 124 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-99)).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public bool FIOLIPBLBKO()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-75)).FLOATVALUE;
			int num2 = 99 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-67)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		public void AGDJDDEIIOB(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["Mine ammo null"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI[", "])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item, 1);
					if (num == 0)
					{
						UnityEngine.Debug.Log("Total_Gold_Spent");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["DESISTIR"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["Gold"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log(" OK!");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["Arena Expired - you gain scraps. You have {0} lives."] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["fr"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("Daily");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["VisualTimestamp"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["response contain VipReward"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("com/google/android/gms/games/Games");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool DFAPFCCADNC()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalWeaponCanLockedCount).FLOATVALUE;
			int num2 = -184 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-125)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool EOLEDAGJFHM()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-149)).FLOATVALUE;
			int num2 = -13 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-195)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool MLJCJIGNKFI()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.DogtagAdInterval).FLOATVALUE;
			int num2 = -124 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalVisualProbability).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool LKOFJNCJHKC()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-18)).FLOATVALUE;
			int num2 = 161 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_PowerbandRewardDuration).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool GHKFOCFGLJA()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-59)).FLOATVALUE;
			int num2 = 192 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-20)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool IICKHBJNGDO()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackMaxRarityCardsType).FLOATVALUE;
			int num2 = 150 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldPackMaxRarityCardsType).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool PBFOLJDIDEM()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-17)).FLOATVALUE;
			int num2 = -27 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-50)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		public void HLCAPMHBEFM(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["Sniper_Tutorial_Duration"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI[" "])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item, 1);
					if (num == 0)
					{
						UnityEngine.Debug.Log("RewardGold");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["123 MENU WEAPON SCREEN TUTORIAL WEAPON BUY CLICKED"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_XTICKETS"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("ID_YES");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["ID_CONFIRMTOBUYWEAPON"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Chat Tab: added time to top."])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log(" NOT OK!\t\t\t\t\t\t");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["0.5"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["Assaulter"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4, 1);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("ID_INVITATIONNOTACCEPTED");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool EKPOAAEIDAD()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-131)).FLOATVALUE;
			int num2 = -200 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCrateLowLevelProbability).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool CLEJHOJIGMH()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-54)).FLOATVALUE;
			int num2 = 129 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LapsedPlayerInterval3).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool KDIOHCBNEAH()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldCardRarityEarly).FLOATVALUE;
			int num2 = -28 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-6)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		public void JDGLHOPPLKE(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = true;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["ID_SILVERCARDS"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["ID_CONFIRM_ERROR"])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item, 1);
					if (num == 0)
					{
						UnityEngine.Debug.Log("Current player squadRank:{0} and info in all members squadRank:{1}");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["ID_ARENAISOPEN"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["Manual_Unit_Spawn"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("GLM: RegisterOrLogin -  10");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["ID_WARNING_OFFEREXPIRED"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Recieved {0} memory warnings in last 10 seconds"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("ID_SLOTUPGRADE_AMMO");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["myapp://myval1/myval2"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_ARENARULES_RANDOMWARCARDS"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("ROOT:\n");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public bool PDILGNIACGO()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalUnitCanLockedCount).FLOATVALUE;
			int num2 = -136 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-67)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool ILCDHLCNAND()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-43)).FLOATVALUE;
			int num2 = -3 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-50)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool FHNCNGPGNJK()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.CreateSquadUnlockLevel).FLOATVALUE;
			int num2 = -98 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward1).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public bool FGNKLGMONHD()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-38)).FLOATVALUE;
			int num2 = 106 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-63)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public int OAJBIHNLIEF()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_WBRewardChance).Get_FLOATVALUE;
			int num2 = -5 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WinstreakReward5).FLOATVALUE;
			int num3 = -97 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-14)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		public void NIELLHCJMJG(JToken PPFFOOLKNPI)
		{
			OMKCLHMDMIO = false;
			GACNCMKFLAK.Clear();
			if (PPFFOOLKNPI["S"] != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)PPFFOOLKNPI["to "])
				{
					int num = KHJJFPPACBP.HNMDPGKPLNK(item);
					if (num == 0)
					{
						UnityEngine.Debug.Log("Button \"{0}\" has no assigned box collider.");
					}
					else
					{
						GACNCMKFLAK.AddLast(num);
					}
				}
			}
			LEDOBPEHKKF.Clear();
			if (PPFFOOLKNPI["Rate_Text_{0}{1}"] != null)
			{
				foreach (JToken item2 in (IEnumerable<JToken>)PPFFOOLKNPI["menu-weapon-benelli-starterpack"])
				{
					int num2 = KHJJFPPACBP.HNMDPGKPLNK(item2);
					if (num2 == 0)
					{
						UnityEngine.Debug.Log("PlayerData");
					}
					else
					{
						LEDOBPEHKKF.AddLast(num2);
					}
				}
			}
			KMKOKFINGBH.Clear();
			if (PPFFOOLKNPI["WarBucks"] != null)
			{
				foreach (JToken item3 in (IEnumerable<JToken>)PPFFOOLKNPI["Index"])
				{
					int num3 = KHJJFPPACBP.HNMDPGKPLNK(item3, 1);
					if (num3 == 0)
					{
						UnityEngine.Debug.Log("MegaReward");
					}
					else
					{
						KMKOKFINGBH.AddLast(num3);
					}
				}
			}
			DOELMJFBICE.Clear();
			if (PPFFOOLKNPI["Shotgunner spawned"] == null)
			{
				return;
			}
			foreach (JToken item4 in (IEnumerable<JToken>)PPFFOOLKNPI["ID_GUI_RATEWFNOW_DESC"])
			{
				int num4 = KHJJFPPACBP.HNMDPGKPLNK(item4);
				if (num4 == 0)
				{
					UnityEngine.Debug.Log("BotLevel");
				}
				else
				{
					DOELMJFBICE.AddLast(num4);
				}
			}
		}

		[SpecialName]
		public int JJENIKDKFHM()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.RepairShields).Get_FLOATVALUE;
			int num2 = 150 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-8)).FLOATVALUE;
			int num3 = 86 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-14)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public int EOCECPJDKLG()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-72)).Get_FLOATVALUE;
			int num2 = 43 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LapsedPlayerInterval2).FLOATVALUE;
			int num3 = -87 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-106)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public int JEBEPFKBOFK()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-80)).Get_FLOATVALUE;
			int num2 = 124 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldCardRarityEarly).FLOATVALUE;
			int num3 = 38 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public bool ALFGAHDLLPN()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-64)).FLOATVALUE;
			int num2 = 192 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-13)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool LENOJMNAIEI()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE;
			int num2 = -123 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcase_WBRewardMax).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public bool EFFJOINBNEG()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-127)).FLOATVALUE;
			int num2 = -8 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.PlayerExplosiveOvertimeCoef).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - num2;
			while (LEDOBPEHKKF.First != null && LEDOBPEHKKF.First.Value < num3)
			{
				LEDOBPEHKKF.RemoveFirst();
			}
			return LEDOBPEHKKF.Count < num;
		}

		[SpecialName]
		public int ADLDDNMCDDD()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-111)).Get_FLOATVALUE;
			int num2 = 24 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.VipGoldCardRewardChance).FLOATVALUE;
			int num3 = 73 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-20)).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public int LCDFKDGPEHK()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-22)).Get_FLOATVALUE;
			int num2 = -190 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-52)).FLOATVALUE;
			int num3 = 87 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward9).FLOATVALUE;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num4 = currentTimestamp - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num4 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num5 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num6 = KMKOKFINGBH.First.Value + num2;
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

		[SpecialName]
		public bool CHDCJODCGLK()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-112)).FLOATVALUE;
			int num2 = 130 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-94)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (DOELMJFBICE.First != null && DOELMJFBICE.First.Value < num3)
			{
				DOELMJFBICE.RemoveFirst();
			}
			return DOELMJFBICE.Count < num;
		}

		[SpecialName]
		public bool NLALKGENHGI()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-114)).FLOATVALUE;
			int num2 = -173 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-29)).FLOATVALUE;
			int num3 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - num2;
			while (GACNCMKFLAK.First != null && GACNCMKFLAK.First.Value < num3)
			{
				GACNCMKFLAK.RemoveFirst();
			}
			return GACNCMKFLAK.Count < num;
		}

		[SpecialName]
		public int DKCGMDLDOMB()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-95)).Get_FLOATVALUE;
			int num2 = 93 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-29)).FLOATVALUE;
			int num3 = -90 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-64)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 1)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}

		[SpecialName]
		public int GBOGAJCEDPI()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-38)).Get_FLOATVALUE;
			int num2 = -78 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.FriendDamageCoeficient).FLOATVALUE;
			int num3 = -122 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-15)).FLOATVALUE;
			int num4 = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num5 = num4 - num2;
			while (KMKOKFINGBH.First != null && (KMKOKFINGBH.First.Value < num5 || KMKOKFINGBH.Count > num))
			{
				KMKOKFINGBH.RemoveFirst();
			}
			if (KMKOKFINGBH.Count > 0)
			{
				int num6 = KMKOKFINGBH.Last.Value + num3;
				if (KMKOKFINGBH.Count >= num)
				{
					int num7 = KMKOKFINGBH.First.Value + num2;
					if (num7 > num6)
					{
						num6 = num7;
					}
				}
				if (num6 <= num4)
				{
					return -1;
				}
				return num6;
			}
			return -1;
		}
	}

	public static bool EOFCINIDOLL;

	private MFBHBFKKLFL GCIKLMJEFHP;

	private MDPPHKCKBGH EMLMEPDGPCC;

	private string BGFEFHCGMDO;

	private string CPOJHCBILNK;

	private int PAOCINCLHBK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action CMPJNGHILJC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action HCOHLFLJHOM;

	private bool FFBAICEPJPL;

	private KHHOMCIOKAO KEFINGEDLKO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action AANBNJHELAI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LPDEOBOCICH _003CCAEFPLBJEEK_003Ek__BackingField;

	public LPDEOBOCICH fuseboxxService
	{
		[CompilerGenerated]
		get
		{
			return _003CCAEFPLBJEEK_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CCAEFPLBJEEK_003Ek__BackingField = value;
		}
	}

	public bool isAdVideoPlaying => fuseboxxService != null && fuseboxxService.MBLILPODHPD;

	public int timeToNextShowGoldenSuitcase
	{
		get
		{
			if (KEFINGEDLKO == null)
			{
				KEFINGEDLKO = new KHHOMCIOKAO();
			}
			return KEFINGEDLKO.NDBEFFKLOPA;
		}
	}

	public event Action RewardVideoPreloaded
	{
		add
		{
			Action action = CMPJNGHILJC;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref CMPJNGHILJC, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = CMPJNGHILJC;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref CMPJNGHILJC, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action AdvertisementVideoRewardError
	{
		add
		{
			Action action = HCOHLFLJHOM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HCOHLFLJHOM, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = HCOHLFLJHOM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HCOHLFLJHOM, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action AdLimitsChanged
	{
		add
		{
			Action action = AANBNJHELAI;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref AANBNJHELAI, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = AANBNJHELAI;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref AANBNJHELAI, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void CompleteEventAssignment(int DHMHOEGPDAP)
	{
		DAAFBKMOHFE("EventAssignmentCompleted", string.Empty, string.Empty, new Hashtable
		{
			{ "assignment", DHMHOEGPDAP },
			{
				"player_level",
				LevelManager.instance.currentLevel.displayNumber
			}
		});
	}

	public void RegisterTutorialMenuTutorialEvent(string BOCEKNFGLPC)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
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

	public void TestFuseboxx()
	{
		KIDFEANMAKJ iKDLNDPLKIM = new KIDFEANMAKJ
		{
			CNGDKFPFCDC = LEMPAEKOLNH.JHHJCIOHPAD(Singleton<BeanstalkServerManager>.instance.currentTimestamp + 600),
			EJAOIMDLKDO = "Time-limited Offers",
			IFFJPCHLIDG = "AttakUnits",
			FNPCHNALNPL = 75f
		};
		UnityEngine.Debug.Log("TEST FUSEBOX - fake offer:\n" + iKDLNDPLKIM.ToString());
		Singleton<OfferManager>.instance.HaveOfferFormFusebox(iKDLNDPLKIM);
	}

	public void TwiterLike()
	{
		DAAFBKMOHFE("Twitter_Like", "Twitter", "twitter", new Hashtable());
	}

	internal bool MMNPIBNEDFA(MHNMOFPPKBN IFMKFKPFILH)
	{
		if (KEFINGEDLKO == null)
		{
			new KHHOMCIOKAO();
		}
		if (KEFINGEDLKO.OMKCLHMDMIO)
		{
			return false;
		}
		switch (IFMKFKPFILH)
		{
		case MHNMOFPPKBN.Dogtag:
			if (!KEFINGEDLKO.NDMDHENBNMA)
			{
				return false;
			}
			break;
		case MHNMOFPPKBN.RandomCard:
			if (!KEFINGEDLKO.MAAHGMHKANN)
			{
				return false;
			}
			break;
		case MHNMOFPPKBN.GoldenSuitcase:
			if (KEFINGEDLKO.NDBEFFKLOPA > 0)
			{
				return false;
			}
			break;
		case MHNMOFPPKBN.LootBox:
			if (!KEFINGEDLKO.MJPCENBJKAO)
			{
				return false;
			}
			break;
		}
		return fuseboxxService.MMNPIBNEDFA();
	}

	internal void GODFLDFJNGA()
	{
		DAAFBKMOHFE("subscription_tab_displayed", string.Empty, string.Empty, null);
	}

	protected override void Awake()
	{
		base.Awake();
		if (ObjectHolderOnSceneChange.MFDCIFEBHHF != null && ObjectHolderOnSceneChange.MFDCIFEBHHF.fuseboxxService != null)
		{
			fuseboxxService = ObjectHolderOnSceneChange.MFDCIFEBHHF.fuseboxxService;
		}
		else
		{
			fuseboxxService = new LPDEOBOCICH(GetComponentInChildren<FuseSDK>());
		}
		fuseboxxService.EPCOFNHOOKD();
		GCIKLMJEFHP = new MFBHBFKKLFL();
		LevelManager.LevelUp += AFBHOJNGDAC;
		fuseboxxService.CMPJNGHILJC += NFLBCCJNNKB;
		fuseboxxService.HCOHLFLJHOM += HIGFKPFIPAN;
		KEFINGEDLKO = new KHHOMCIOKAO();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		Singleton<GameController>.instance.BeforeGameStarted += HGIOAIPCMDJ;
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
	}

	public void RegisterTutorialPlayCardEvent(string BOCEKNFGLPC, bool MKCGMALLBNC, int HONDKPBMKPA)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
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
				MKCGMALLBNC ? 1 : 0
			},
			{ "Play_Card_Tutorial_Duration", HONDKPBMKPA },
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

	public void RegisterGameItemDeliverEvent(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, int LDJNLDKEBIG, double EJEDANLAMBI)
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Transaction_Amount", LDJNLDKEBIG);
		hashtable.Add("Remaining_Time", EJEDANLAMBI);
		Hashtable cCODGCEOMOP = hashtable;
		DAAFBKMOHFE(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, cCODGCEOMOP);
		FEBJFEEMMKO(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, cCODGCEOMOP);
	}

	private void DAAFBKMOHFE(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		fuseboxxService.DAAFBKMOHFE(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, CCODGCEOMOP);
		GCIKLMJEFHP.DAAFBKMOHFE(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA);
		if (EMLMEPDGPCC != null)
		{
			EMLMEPDGPCC.DAAFBKMOHFE(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, CCODGCEOMOP);
		}
	}

	public void RegisterGoldOut(string FKBHNLOAPAA, int IEALLELGOBM)
	{
		DAAFBKMOHFE("Gold_Out_Flow", "Area", FKBHNLOAPAA, new Hashtable { { "Amount", IEALLELGOBM } });
	}

	public void RegisterTutorialGrenadeThrowingEvent(string BOCEKNFGLPC, int HONDKPBMKPA)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", HONDKPBMKPA },
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

	public void RegisterInapp(string KJBPJOMHNKB, bool KCBGHGFELIA, string FJLBLLLEELD)
	{
		DAAFBKMOHFE("Confirmed_In_App", "Pack_Id", FJLBLLLEELD + "_Packs", new Hashtable { 
		{
			"Player_Level",
			PlayerAnalytics.instance.data.GetPlayerLevel()
		} });
		if (KCBGHGFELIA)
		{
			DAAFBKMOHFE("First_Time_Buy_" + FJLBLLLEELD, "Pack_Id", KJBPJOMHNKB, new Hashtable { 
			{
				"Days_Since_Install",
				PlayerAnalytics.instance.data.GetDaysSinceInstall()
			} });
			Kochava.FireEvent("first_purchase", string.Empty);
		}
		else
		{
			DAAFBKMOHFE("Buy_" + FJLBLLLEELD, "Pack_Id", KJBPJOMHNKB, new Hashtable { 
			{
				"Player_Level",
				PlayerAnalytics.instance.data.GetPlayerLevel()
			} });
		}
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		if (EMLMEPDGPCC != null)
		{
			EMLMEPDGPCC.BKELCKJEFOF();
		}
	}

	[SpecialName]
	private void FNMCIGKIOGJ(LPDEOBOCICH IDEBKDPMPGM)
	{
		_003CCAEFPLBJEEK_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void NFLBCCJNNKB()
	{
		if (CMPJNGHILJC != null)
		{
			CMPJNGHILJC();
		}
	}

	internal void FPHNMABAJHN(string ICDKHLOBKIE, int[] LEIKKCNNNIO)
	{
		DAAFBKMOHFE("CardCraft_Start", "CardId", ICDKHLOBKIE, new Hashtable
		{
			{
				"Cards_Owned_Bronze",
				LEIKKCNNNIO[0]
			},
			{
				"Cards_Owned_Silver",
				LEIKKCNNNIO[1]
			},
			{
				"Cards_Owned_Gold",
				LEIKKCNNNIO[2]
			}
		});
	}

	public void RegisterGoldIn(string FKBHNLOAPAA, int IEALLELGOBM)
	{
		DAAFBKMOHFE("Gold_In_Flow", "Area", FKBHNLOAPAA, new Hashtable { { "Amount", IEALLELGOBM } });
	}

	internal void CDILJKJLJNB(KKFOLKGHOJE FNAHDAKNLJP)
	{
		if (FNAHDAKNLJP > (KKFOLKGHOJE)(-100))
		{
			fuseboxxService.HBBLENEMHNL((int)FNAHDAKNLJP, "-elite");
		}
		else
		{
			fuseboxxService.APLFJDMGKPJ((int)FNAHDAKNLJP, 0);
		}
	}

	public void GNALOBEKLDJ(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, int LDJNLDKEBIG)
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("ADDED WEAPON = NULL", LDJNLDKEBIG);
		Hashtable cCODGCEOMOP = hashtable;
		JFNGNNCOKII(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, cCODGCEOMOP);
		FEBJFEEMMKO(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, cCODGCEOMOP);
	}

	public void RegisterScrappingParts(string IOIKKIIFOCB, int AMEELJHHGKP, int MDOHMDGAHDD)
	{
		DAAFBKMOHFE("ScrappingParts", "Army_Unit_ID", IOIKKIIFOCB, new Hashtable
		{
			{ "Parts", AMEELJHHGKP },
			{ "Scraps", MDOHMDGAHDD }
		});
	}

	public void AFPPIFHEFGD(string IJLLICNFGEA, int AMEELJHHGKP)
	{
		DAAFBKMOHFE("groundBoxHit", "CONFIRM", IJLLICNFGEA, new Hashtable { { "Show buy hearth dialog", AMEELJHHGKP } });
	}

	public void ClaimEventAssignment(int DHMHOEGPDAP)
	{
		DAAFBKMOHFE("EventAssignmentClaimed", string.Empty, string.Empty, new Hashtable
		{
			{ "assignment", DHMHOEGPDAP },
			{
				"player_level",
				LevelManager.instance.currentLevel.displayNumber
			}
		});
	}

	public void NEPAMFBPPHB(string BOCEKNFGLPC, bool DLCOBIBGNOB, bool HGJDJDPDDDI)
	{
		JFNGNNCOKII("BeginnersLeague", "ID_SQUADEVENT", BOCEKNFGLPC, new Hashtable
		{
			{ "Card ", 0 },
			{ "You probably assigned bad type of AmmoSetup to gun", 1 },
			{ "menu-elitepack-buybutton", 0 },
			{ "Weapon upgrade for ", 0 },
			{ "Player_Waited_Till_Delivery_Ends", 0 },
			{ "pt", 1 },
			{ ",", 1 },
			{ "Play_Card_Tutorial", 0 },
			{ "ID_FEATURE_RATE", 0 },
			{
				"ID_NOTBADYOUVEHOLDYOURGROUND",
				(!DLCOBIBGNOB) ? 1 : 0
			},
			{
				"ID_SLOTUPGRADE_CLIP_SIZE",
				(!HGJDJDPDDDI) ? 1 : 0
			},
			{ "DeliveryTime", 0 },
			{ "CONFIRM", 1 },
			{ "-elite", 0 },
			{ "UpgradeUnitReminder {0} {1}", 0 },
			{ "Per funzionare, WarFriends deve scaricare circa 190MB di dati extra.\nIl tempo di download può variare in base alla tua rete e posizione.\n\nVuoi proseguire?", 1 },
			{ "RegisterGender()", 0 },
			{ "menu-cards-bronzepack", 0 },
			{ "roomName", 0 },
			{ "Battle_length", 0 },
			{ "\tTime since last show: {0}\tFb login counter: {1}/3", 0 },
			{
				"menu-gold",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"ID_CONTINUE",
				TimeManager.CEAFAMFNGCC()
			}
		});
	}

	public void RegisterVisualGained(int PDEDEOKMDJD)
	{
		UnityEngine.Debug.Log($"FuseBox Event VisualGained for rarity {PDEDEOKMDJD}");
		DAAFBKMOHFE("PlayerVisual_Gained", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString("D3"), new Hashtable
		{
			{
				"ItemRarity_0",
				(PDEDEOKMDJD == 0) ? 1 : 0
			},
			{
				"ItemRarity_1",
				(PDEDEOKMDJD == 1) ? 1 : 0
			},
			{
				"ItemRarity_2",
				(PDEDEOKMDJD == 2) ? 1 : 0
			},
			{
				"ItemRarity_3",
				(PDEDEOKMDJD == 3) ? 1 : 0
			},
			{
				"ItemRarity_4",
				(PDEDEOKMDJD == 4) ? 1 : 0
			}
		});
	}

	internal void AELIOGBDIDJ(string ICDKHLOBKIE, int[] LEIKKCNNNIO)
	{
		DAAFBKMOHFE("CardTrade_Withdraw", "CardId", ICDKHLOBKIE, new Hashtable
		{
			{
				"Cards_Owned_Bronze",
				LEIKKCNNNIO[0]
			},
			{
				"Cards_Owned_Silver",
				LEIKKCNNNIO[1]
			},
			{
				"Cards_Owned_Gold",
				LEIKKCNNNIO[2]
			}
		});
	}

	public void RegisterInApp(string PIKHAFPHDFN, float EBFFNMFHHDN, string GFDJPIEEDAD, string IAGICGFALCK, string ADNDMABPHOH)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		DAAFBKMOHFE("Purchase_Validated", "InApp_ID", PIKHAFPHDFN, new Hashtable { 
		{
			"Days_Since_Install",
			data.GetDaysSinceInstall()
		} });
	}

	public void KEKPOIPDIGK(string BOCEKNFGLPC, bool LOEOJKCKOLI)
	{
		JFNGNNCOKII("Current unit is not delivered at the moment!!!", "Total_Warbucks_Earned", BOCEKNFGLPC, new Hashtable
		{
			{ "KEYBOARD DONNNEEEE, was canceled: ", 0 },
			{ "Going to enable notifications", 1 },
			{ "GLM: RegisterOrLogin -  2", 0 },
			{ "S", 1 },
			{ "DogTagRefillTime", 1 },
			{
				", waiting for GC",
				(!LOEOJKCKOLI) ? 1 : 0
			},
			{ "OrderId", 1 },
			{ "menu-assignments-type-crate", 1 },
			{ "{0} {1}", 1 },
			{ "menu-cards-goldpack", 0 },
			{ "ID_NUMMEMBERS", 0 },
			{ "Scripts Full Path: \"{0}\"\n", 0 },
			{ "warbucks", 0 },
			{ "ID_GUI_SQUADDEMOTION", 0 },
			{ "ID_RECRUITUNITTOARMYTOPROMOTE", 1 },
			{ "-[^-]*$", 1 },
			{ "ID_SILVERWARCARDS", 0 },
			{ "YES", 1 },
			{ "ID_CONFIRM_SERVERDIDNOTRESPOND", 1 },
			{ "Lcom/google/android/gms/games/stats/Stats;", 1 },
			{ " DEPOSIT {0}\n", 0 },
			{
				"RETRYPERM",
				PlayerAnalytics.instance.data.numberOfSessions
			},
			{
				"\"",
				TimeManager.realTimeWithoutPauses
			}
		});
	}

	public void RegisterTutorialSniperShootEvent(string BOCEKNFGLPC, bool MKCGMALLBNC, int HONDKPBMKPA)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
		{
			{
				"Sniper_Tutorial_Played",
				MKCGMALLBNC ? 1 : 0
			},
			{ "Sniper_Tutorial_Duration", HONDKPBMKPA },
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

	public void RegisterBuyVipEvent(string JHNNFNGCHMM, int LDJNLDKEBIG)
	{
		RegisterEconomyEvent("Buy_VIP_Pack_With_Gold", LDJNLDKEBIG);
		UnityEngine.Debug.Log("Bought VIP - " + JHNNFNGCHMM + " - loggin goldCost: " + LDJNLDKEBIG);
		DAAFBKMOHFE("Buy_VIP_Pack_With_Gold", "Pack_Type", JHNNFNGCHMM, new Hashtable
		{
			{ "Average_Transaction_Amount", LDJNLDKEBIG },
			{
				"Days_Since_Install",
				PlayerAnalytics.instance.data.GetDaysSinceInstall()
			}
		});
	}

	public void RegisterAwsAnalyticsInApp(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		if (EMLMEPDGPCC != null)
		{
			EMLMEPDGPCC.LMCGFJDGEFI(DLCHBBJNBKP, OPEICELHNLI, GGKHBILEAGB, DFHEDJIGLKD, ADNDMABPHOH);
		}
	}

	internal void ALEEKCLMJLA(bool DNFOLCJEEDP, bool KNIBODJCBCE, bool FHMNEEENOIE)
	{
		DAAFBKMOHFE("subscription_toggle", "subscribed", (!DNFOLCJEEDP) ? "0" : "1", new Hashtable
		{
			{
				"trial",
				(!KNIBODJCBCE) ? "0" : "1"
			},
			{
				"auto",
				(!FHMNEEENOIE) ? "0" : "1"
			},
			{
				"player_level",
				LevelManager.instance.currentLevel.displayNumber
			}
		});
	}

	internal void CGGKIOLOKLO(int DHMHOEGPDAP, string KJBPJOMHNKB, int HAFMGCFMCPC)
	{
		DAAFBKMOHFE("Multiday_gold_claimed", "Pack_Id", KJBPJOMHNKB, new Hashtable
		{
			{
				"Days_Since_Install",
				PlayerAnalytics.instance.data.GetDaysSinceInstall()
			},
			{ "Claim_Day", DHMHOEGPDAP },
			{ "Transaction_Amount", HAFMGCFMCPC }
		});
	}

	protected override void Start()
	{
		base.Start();
		GCIKLMJEFHP.EHKKAOLJMCF();
		// The retired AWS Mobile Analytics client emits forbidden UnityWebRequest headers and
		// is not gameplay authority. Leave it disabled; every caller already treats it as optional.
		EMLMEPDGPCC = null;
	}

	internal void KBJBMDDDDNF()
	{
		DAAFBKMOHFE("Assignments_Mega_Reward_claim", "Player_level", LevelManager.instance.currentLevel.displayNumber.ToString(), new Hashtable());
	}

	public void RegisterOpenLootbox(int PDEDEOKMDJD)
	{
		UnityEngine.Debug.Log($"FuseBox Event OpenLootbox for rarity {PDEDEOKMDJD}");
		DAAFBKMOHFE("LootBox_Open", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString("D3"), new Hashtable
		{
			{
				"ItemRarity_0",
				(PDEDEOKMDJD == 0) ? 1 : 0
			},
			{
				"ItemRarity_1",
				(PDEDEOKMDJD == 1) ? 1 : 0
			},
			{
				"ItemRarity_2",
				(PDEDEOKMDJD == 2) ? 1 : 0
			},
			{
				"ItemRarity_3",
				(PDEDEOKMDJD == 3) ? 1 : 0
			},
			{
				"ItemRarity_4",
				(PDEDEOKMDJD == 4) ? 1 : 0
			}
		});
	}

	public void ElitePartsGained(string CBMKJAFIBKH, int AMEELJHHGKP)
	{
		DAAFBKMOHFE("ElitePartsGained", "Location", CBMKJAFIBKH, new Hashtable { { "Elite_parts", AMEELJHHGKP } });
	}

	internal void GKDGINEBLFD(StarterAssignment MFEHGADGJNP, bool NPJDIMACCIL)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		UnityEngine.Debug.Log("Starter assignment completed " + MFEHGADGJNP.id);
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Total_Sessions", data.numberOfSessions);
		hashtable.Add("Days_Since_Install", data.GetDaysSinceInstall());
		hashtable.Add("Total_Batles", data.totalBattles);
		hashtable.Add("Already_Completed", (!NPJDIMACCIL) ? "0" : "1");
		Hashtable cCODGCEOMOP = hashtable;
		DAAFBKMOHFE("Starter_Assignment_Completed", "Id", MFEHGADGJNP.id, cCODGCEOMOP);
		FEBJFEEMMKO("Starter_Assignment_Completed", "Id", MFEHGADGJNP.id, cCODGCEOMOP);
	}

	public void RegisterTutorialDeliveredEvent(string BOCEKNFGLPC, bool HIKKIELBFAP)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{ "Wrong_Unit", 0 },
			{
				"Player_Waited_Till_Delivery_Ends",
				HIKKIELBFAP ? 1 : 0
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

	public void StartMission(DailyMission PFFMGHJAJDB)
	{
		string fKBHNLOAPAA = PFFMGHJAJDB.GetType().ToString();
		DAAFBKMOHFE((PFFMGHJAJDB.missionType != GEIKAIJBCPE.Heroic) ? "Daily_mission_start" : "Daily_mission_start_heroic", "Mission_Type", fKBHNLOAPAA, new Hashtable
		{
			{ "Number", PFFMGHJAJDB.number },
			{
				"Level",
				LevelManager.instance.currentLevel.displayNumber
			},
			{
				"Coop",
				(PFFMGHJAJDB.missionType != GEIKAIJBCPE.Coop) ? "0" : "1"
			}
		});
	}

	private void AFBHOJNGDAC()
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Wallet wallet = Singleton<Wallet>.instance;
		UnityEngine.Debug.Log($"FuseBox Event Level Up for level {data.GetPlayerLevel()}");
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
		Hashtable cCODGCEOMOP = hashtable;
		DAAFBKMOHFE("Player_Level_Up", "Level_Number", data.GetPlayerLevel().ToString("D3"), cCODGCEOMOP);
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
		if (data.GetPlayerLevel() == 4)
		{
			Kochava.FireEvent("Rank_up_4", string.Empty);
		}
	}

	public void RegisterWBIn(string FKBHNLOAPAA, int IEALLELGOBM)
	{
		DAAFBKMOHFE("WB_In_Flow", "Area", FKBHNLOAPAA, new Hashtable { { "Amount", IEALLELGOBM } });
	}

	public void EndMission(DailyMission PFFMGHJAJDB, bool IFMPGFLANHM)
	{
		string fKBHNLOAPAA = PFFMGHJAJDB.GetType().ToString();
		DailyMissionsManager.DailyMissionsData data = DailyMissionsManager.instance.data;
		DAAFBKMOHFE((PFFMGHJAJDB.missionType != GEIKAIJBCPE.Heroic) ? "Daily_mission_end" : "Daily_mission_end_heroic", "Mission_Type", fKBHNLOAPAA, new Hashtable
		{
			{ "Number", PFFMGHJAJDB.number },
			{
				"Level",
				LevelManager.instance.currentLevel.displayNumber
			},
			{
				"Coop",
				(PFFMGHJAJDB.missionType != GEIKAIJBCPE.Coop) ? "0" : "1"
			},
			{
				"Completed",
				(!IFMPGFLANHM) ? "0" : "1"
			},
			{ "HeroicPoints", data.heroicPoints }
		});
	}

	public void BlackMarketTriger(string MPHGIDMPPPK, int AIBLJGHAHEB)
	{
		DAAFBKMOHFE("Black_market_triggered", "Area", MPHGIDMPPPK, new Hashtable { { "Amount_of_displays", AIBLJGHAHEB } });
	}

	public void ArenaFinished(int LONFCMDPPPL, int GGOIBCKBPDM)
	{
		DAAFBKMOHFE("ArenaFinished", "Wins", LONFCMDPPPL.ToString(), new Hashtable { { "Attempts", GGOIBCKBPDM } });
	}

	public void RegisterDailyVisit()
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		DAAFBKMOHFE("Daily_Visit_Main_Menu", "Total_Lifetime_Spend", data.GetCohort(), new Hashtable
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

	public void TicketsGained(string CBMKJAFIBKH, int FMCANDNKEKC)
	{
		DAAFBKMOHFE("TicketsGained", "Location", CBMKJAFIBKH, new Hashtable { { "Tickets", FMCANDNKEKC } });
	}

	internal void ICDALIJKFMH(MHNMOFPPKBN MOEMPHPNBLM)
	{
		UnityEngine.Debug.Log("ETM: Show Rewarded Video");
		fuseboxxService.ICDALIJKFMH(MOEMPHPNBLM);
	}

	internal void PJJLDKJFCKL()
	{
		CMPJNGHILJC();
	}

	public void BKKABOFEMOJ(string LHLNOICCHLH)
	{
		bool flag = string.Compare("NetworkReInstantiate", LHLNOICCHLH) == 0;
		JFNGNNCOKII("HEAVYTURRET", "DeathEventPlayerShoot", LHLNOICCHLH, new Hashtable { 
		{
			(!flag) ? " (#" : "Wrong_Unit",
			(!flag) ? PlayerAnalytics.instance.data.totalBattles : PlayerAnalytics.instance.data.GetDaysSinceInstall()
		} });
	}

	private void PHGFBJFFFPH()
	{
		if (!FFBAICEPJPL)
		{
			FFBAICEPJPL = true;
			PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
			StatsManager.StatisticsData data2 = StatsManager.instance.data;
			Wallet wallet = Singleton<Wallet>.instance;
			Hashtable hashtable = new Hashtable();
			hashtable.Add("Total_Sessions", data.numberOfSessions);
			hashtable.Add("Total_Battles", data2.mmmGames);
			hashtable.Add("Won_Battles", data2.battlesWon);
			hashtable.Add("Days_Since_Install", data.GetDaysSinceInstall());
			hashtable.Add("Player_Rank", data.GetPlayerLevel());
			hashtable.Add("Xp", LevelManager.instance.experience);
			hashtable.Add("RealMoney", data.realMoneySpent);
			hashtable.Add("Total_Warbucks_Earned", data.warbucksSpent + wallet.warBucks);
			hashtable.Add("Total_Warbucks_Spent", data.warbucksSpent);
			hashtable.Add("Warbucks_Balance", wallet.warBucks);
			hashtable.Add("Total_Gold_Earned", data.goldSpent + wallet.gold);
			hashtable.Add("Total_Gold_Spent", data.goldSpent);
			hashtable.Add("Gold_Balance", wallet.gold);
			hashtable.Add("subscriber_since", SubscriptionManager.instance.subscribeStart);
			Hashtable cCODGCEOMOP = hashtable;
			DAAFBKMOHFE("Session_start", "Action", "Start", cCODGCEOMOP);
			FEBJFEEMMKO("Session_start", "Action", "Start", cCODGCEOMOP);
		}
		if (!string.IsNullOrEmpty(KochavaManager.PAFGHABDNCN))
		{
			RegisterAttribution(KochavaManager.PAFGHABDNCN);
		}
		EOFCINIDOLL = true;
	}

	public void RegisterBuyPackEvent(string KJBPJOMHNKB)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		UnityEngine.Debug.Log("REGISTER BUY PACK EVENT with " + KJBPJOMHNKB);
		DAAFBKMOHFE("Buy_Pack", "Pack_Type", KJBPJOMHNKB, new Hashtable
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

	public void ArenaLootbox(int LONFCMDPPPL, IKGCOGIODMO DHLDKAHCEFB)
	{
		DAAFBKMOHFE("ArenaLootbox", "Unit_Id", DHLDKAHCEFB.IJLLICNFGEA, new Hashtable
		{
			{ "EliteParts", DHLDKAHCEFB.KCAAMHIMKMM },
			{ "Tickets", DHLDKAHCEFB.FMCANDNKEKC },
			{ "Scraps", DHLDKAHCEFB.MDOHMDGAHDD },
			{ "Gold", DHLDKAHCEFB.HAFMGCFMCPC },
			{ "Warbucks", DHLDKAHCEFB.FPMJEDOCJKE },
			{ "Wins", LONFCMDPPPL }
		});
		if (DHLDKAHCEFB.KCAAMHIMKMM > 0)
		{
			DAAFBKMOHFE("PartsGainedLootbox", "UnitID", DHLDKAHCEFB.IJLLICNFGEA, new Hashtable { { "Parts", DHLDKAHCEFB.KCAAMHIMKMM } });
			ElitePartsGained("ArenaLootBox", DHLDKAHCEFB.KCAAMHIMKMM);
		}
		if (DHLDKAHCEFB.MDOHMDGAHDD > 0)
		{
			ScrapsGained("ArenaLootBox", DHLDKAHCEFB.MDOHMDGAHDD);
		}
		if (DHLDKAHCEFB.FMCANDNKEKC > 0)
		{
			TicketsGained("ArenaLootBox", DHLDKAHCEFB.FMCANDNKEKC);
		}
	}

	public void VideoFeedAccesed()
	{
		DAAFBKMOHFE("Video_feed_accessed", string.Empty, string.Empty, new Hashtable());
	}

	public void RegisterPartsGainedFromScraps(string IJLLICNFGEA, int AMEELJHHGKP)
	{
		DAAFBKMOHFE("PartssGainedScraps", "UnitID", IJLLICNFGEA, new Hashtable { { "Parts", AMEELJHHGKP } });
	}

	private void JFNGNNCOKII(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		fuseboxxService.DAAFBKMOHFE(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, CCODGCEOMOP);
		GCIKLMJEFHP.NLOPMDFLHBD(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA);
		if (EMLMEPDGPCC != null)
		{
			EMLMEPDGPCC.EPDMPAIJPBP(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, CCODGCEOMOP);
		}
	}

	public void RegisterTutorialOvertimeExplainedEvent(string BOCEKNFGLPC, bool PIAMCMAOPON)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
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
				PIAMCMAOPON ? 1 : 0
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

	public void RegisterVisitLeagueTable()
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Total_Battles", PlayerAnalytics.instance.data.totalBattles);
		Hashtable cCODGCEOMOP = hashtable;
		DAAFBKMOHFE("Visit_League_Table", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString(), cCODGCEOMOP);
		FEBJFEEMMKO("Visit_League_Table", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString(), cCODGCEOMOP);
	}

	private void FEBJFEEMMKO(string DDLNDBANBHK, Dictionary<string, object> CCODGCEOMOP)
	{
		FacebookAndroid.logEvent(DDLNDBANBHK, CCODGCEOMOP);
	}

	internal void HFFGGKNEJJD(string ICDKHLOBKIE, int NMIJMHLENMM)
	{
		DAAFBKMOHFE("CardCraft_Collect", "CardId", ICDKHLOBKIE, new Hashtable { { "Time_Since_Delivery_Finished", NMIJMHLENMM } });
		Card cardInstance = CardManager.instance.GetCardInstance(ICDKHLOBKIE);
		if (cardInstance != null)
		{
			DDIEAJKJMFL((cardInstance.rarity != CardManager.CardType.Gold) ? KKFOLKGHOJE.ForgeSilverCard : KKFOLKGHOJE.ForgeGoldCard);
		}
	}

	internal void LCPLAKMLCGH(string ICLNCDGCCJN, int OGOOFMGKBKM)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		DAAFBKMOHFE("Display_Rating_Box", "Result", ICLNCDGCCJN, new Hashtable
		{
			{ "Total_Sessions", data.numberOfSessions },
			{
				"Total_Battles",
				PlayerAnalytics.instance.data.totalBattles
			},
			{ "Shown_Before_Times", OGOOFMGKBKM }
		});
	}

	public void MELADDBCBLK()
	{
		KEFINGEDLKO.OMKCLHMDMIO = false;
	}

	public void RegisterGoldAndWBAfterMatch(bool PHMELCOOBJL)
	{
		int num = 0;
		int num2 = 0;
		if (PHMELCOOBJL)
		{
			num = LevelManager.instance.currentLevel.golds;
			num2 = 0;
			RegisterGoldIn("Rank_Up", num);
			RegisterWBIn("Rank_Up", num2);
		}
		string text = (Singleton<GameController>.instance.isPVP ? "Battle" : ((!Singleton<GameController>.instance.isMission) ? string.Empty : "Mission"));
		int num3 = ((!Singleton<GameController>.instance.isMission) ? Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.LLOFEOGFBAA : Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.HAFMGCFMCPC);
		int num4 = ((!Singleton<GameController>.instance.isMission) ? Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.CNLNJKDJBBJ : Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.FPMJEDOCJKE);
		if (!string.IsNullOrEmpty(text))
		{
			if (num3 > 0)
			{
				RegisterGoldIn(text, num3 - num);
			}
			if (num4 > 0)
			{
				RegisterWBIn(text, num4 - num2);
			}
		}
	}

	public void RegisterPowerBandEvent(string NMKAELCNJCN, int LDJNLDKEBIG, bool BFCEIPLLLAJ)
	{
		if (BFCEIPLLLAJ)
		{
			DAAFBKMOHFE("Spend_Gold_On_Power_Bands", "Decal_Type", NMKAELCNJCN, new Hashtable
			{
				{ "Average_Transaction_Amount", LDJNLDKEBIG },
				{
					"Days_Since_Install",
					PlayerAnalytics.instance.data.GetDaysSinceInstall()
				}
			});
			DDIEAJKJMFL(KKFOLKGHOJE.PurchasePowerband);
		}
	}

	public void RegisterFacebookInApp(string KJBPJOMHNKB, float OPEICELHNLI, string FJLBLLLEELD, string JAJLHFNHGOE)
	{
		FacebookAndroid.logPurchaseEvent(OPEICELHNLI, JAJLHFNHGOE);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("PackId", KJBPJOMHNKB);
		dictionary.Add("Price", OPEICELHNLI);
		dictionary.Add("Type", FJLBLLLEELD);
		dictionary.Add("Currency", JAJLHFNHGOE);
		Dictionary<string, object> parameters = dictionary;
		FacebookAndroid.logEvent("InApp", parameters);
	}

	public void SetSendingAdrewardGainedToServer()
	{
		KEFINGEDLKO.OMKCLHMDMIO = true;
	}

	public void RegisterBattleEndedEvent(bool CFLLLHDNHEN, bool EGEMJPLEKOC, int IOMFMJOBEOI, int EHCGJPCDPJJ, int MNCBMEGPIJE)
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
		hashtable.Add("Is_Against_Bot", CFLLLHDNHEN ? 1 : 0);
		hashtable.Add("Is_Overtime", EGEMJPLEKOC ? 1 : 0);
		hashtable.Add("Cards_Owned", IOMFMJOBEOI);
		hashtable.Add("Cards_Chosen", EHCGJPCDPJJ);
		hashtable.Add("Cards_Played", MNCBMEGPIJE);
		hashtable.Add("Cards_Buddy_Owned", num3);
		hashtable.Add("Cards_Buddy_Chosen", num2);
		hashtable.Add("Cards_Buddy_Played", num4);
		hashtable.Add("Ranked_Battle", Singleton<GameController>.instance.isRandomMatchMaking ? 1 : 0);
		hashtable.Add("Win", Singleton<GameController>.instance.wonLastGame ? 1 : 0);
		hashtable.Add("Connection_Dropped", MatchManager.isReconnect ? 1 : 0);
		hashtable.Add("BattleLength", Singleton<MatchManager>.instance.matchTime);
		hashtable.Add("AgainstOtherPlatform", Singleton<GameController>.instance.isDeathMatch ? 1 : 0);
		hashtable.Add("Game_type", (int)Singleton<GameController>.instance.gameType);
		Hashtable cCODGCEOMOP = hashtable;
		DAAFBKMOHFE("War_Battle_End", "Battle_Number", num.ToString("D3"), cCODGCEOMOP);
		if (!Singleton<GameController>.instance.isMission)
		{
			DAAFBKMOHFE("War_Battle_Mode", "Game_Type", (!Singleton<GameController>.instance.isRandomMatchMaking) ? "Unranked" : "Ranked", new Hashtable());
		}
		if (Singleton<GameController>.instance.isRandomMatchMaking && Singleton<GameController>.instance.isDeathMatch)
		{
			CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
			CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
			hashtable = new Hashtable();
			hashtable.Add("Ping", PhotonConnectionManager.pingToBestRegion);
			hashtable.Add("leagueDiff", eHHHBEMKGOE.BMNDININJCE - eHHHBEMKGOE2.BMNDININJCE);
			hashtable.Add("leagueMedalsDiff", eHHHBEMKGOE.GEIONCLKAGF - eHHHBEMKGOE2.GEIONCLKAGF);
			hashtable.Add("rankDiff", eHHHBEMKGOE.BCCDDJMPBLL - eHHHBEMKGOE2.BCCDDJMPBLL);
			Hashtable cCODGCEOMOP2 = hashtable;
			DAAFBKMOHFE("War_Ranked_Battle", "Region", PhotonConnectionManager.bestRegion.ToString(), cCODGCEOMOP2);
			FEBJFEEMMKO("War_Ranked_Battle", "Region", PhotonConnectionManager.bestRegion.ToString(), cCODGCEOMOP2);
		}
		string deviceModel = SystemInfo.deviceModel;
		deviceModel = "Android";
		if (Singleton<GameController>.instance.isDeathMatch)
		{
			DAAFBKMOHFE("War_Battle_End_Performance", "Map_device_levelGroup", Singleton<MapManager>.instance.currentMap.name + "_" + deviceModel + "_" + (int)((float)LevelManager.instance.currentLevel.displayNumber / 5f), new Hashtable
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
			DAAFBKMOHFE("War_Battle_End_Android_Performance", "Tier", $"{Singleton<MapManager>.instance.currentMap.name}_processorT{SystemInfo.processorCount}_resT{num5}", new Hashtable
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
		hashtable = new Hashtable();
		hashtable.Add("Map", Singleton<MapManager>.instance.currentMap.name);
		hashtable.Add("Mode", Singleton<GameController>.instance.gameType.ToString());
		hashtable.Add("Min_fps", AFPSCounter.Instance.fpsCounter.lastMinimumValue.ToString());
		hashtable.Add("Avg_fps", AFPSCounter.Instance.fpsCounter.lastAverageValue.ToString());
		hashtable.Add("Memory_warnings", Singleton<PerformanceLoggerManager>.instance.memoryWarningDuringGame);
		hashtable.Add("Metal", Singleton<PerformanceManager>.instance.isMetal);
		Hashtable cCODGCEOMOP3 = hashtable;
		if (EMLMEPDGPCC != null)
		{
			EMLMEPDGPCC.DAAFBKMOHFE("Battle_Performance", "device", SystemInfo.deviceModel, cCODGCEOMOP3);
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			WarArena.WarArenaData data2 = WarArena.instance.data;
			bool wonLastGame = Singleton<GameController>.instance.wonLastGame;
			ArenaBattleEnd(data2.wins, data2.lives, wonLastGame, Singleton<MatchManager>.instance.matchTime);
		}
		DDIEAJKJMFL(KKFOLKGHOJE.PlayBattle);
	}

	public void RegisterTutorialUnitSelectedEvent(string BOCEKNFGLPC, bool LOEOJKCKOLI)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{ "Automatic_Equip", 0 },
			{
				"Wrong_Unit",
				LOEOJKCKOLI ? 1 : 0
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

	internal void MLAMBLBINMK(string HOILIFMFLGG, bool DFJLFELEFEB)
	{
		DAAFBKMOHFE("Purchase_Attempt", "InApp_ID", HOILIFMFLGG, new Hashtable { 
		{
			"Connection_Fail",
			(!DFJLFELEFEB) ? "1" : "0"
		} });
	}

	internal void DDIEAJKJMFL(KKFOLKGHOJE FNAHDAKNLJP)
	{
		if (FNAHDAKNLJP > KKFOLKGHOJE.DeliverUnitUpgrade)
		{
			fuseboxxService.APLFJDMGKPJ((int)FNAHDAKNLJP, "1");
		}
		else
		{
			fuseboxxService.APLFJDMGKPJ((int)FNAHDAKNLJP, 1);
		}
	}

	public void RegisterHonestyBoxShowedEvent(bool FBFJNHLKJEC)
	{
	}

	public void BINALALDGID()
	{
		KEFINGEDLKO.OMKCLHMDMIO = false;
	}

	public void SpecialOffer(string CFAANFGEOIE)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		DAAFBKMOHFE("Special_Sale", "Action", CFAANFGEOIE, new Hashtable { 
		{
			"Days_Since_Install",
			data.GetDaysSinceInstall()
		} });
	}

	public void RegisterTutorialGrenadeThrowEvent(string BOCEKNFGLPC, bool JHIGDPHAPMN)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{
				"Player_Had_To_Select_Grenade",
				JHIGDPHAPMN ? 1 : 0
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

	private void OnApplicationFocus(bool MOPBHNIHFAC)
	{
		UnityEngine.Debug.LogFormat("Application focus changed to {0} and have created AWS mobile analytics {1}", MOPBHNIHFAC, EMLMEPDGPCC != null);
		if (EMLMEPDGPCC != null)
		{
			EMLMEPDGPCC.JOLGBEMAAPH(MOPBHNIHFAC);
		}
	}

	public void SetLastShowedTimeForAdtype(MHNMOFPPKBN MOEMPHPNBLM)
	{
		switch (MOEMPHPNBLM)
		{
		case MHNMOFPPKBN.RandomCard:
			KEFINGEDLKO.GACNCMKFLAK.AddLast(Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			break;
		case MHNMOFPPKBN.Dogtag:
			KEFINGEDLKO.LEDOBPEHKKF.AddLast(Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			break;
		case MHNMOFPPKBN.GoldenSuitcase:
			KEFINGEDLKO.KMKOKFINGBH.AddLast(Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			break;
		case MHNMOFPPKBN.LootBox:
			KEFINGEDLKO.DOELMJFBICE.AddLast(Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			break;
		}
	}

	public void RegisterGameItemBoughtElite(string FKBHNLOAPAA, int AMEELJHHGKP, int FPMJEDOCJKE)
	{
		DAAFBKMOHFE("Buy_Upgrade_For_Army_Unit_Elite", "Army_Unit_ID", FKBHNLOAPAA, new Hashtable
		{
			{ "Parts", AMEELJHHGKP },
			{ "Warbucks", FPMJEDOCJKE }
		});
	}

	private void HGIOAIPCMDJ()
	{
		if (EMLMEPDGPCC != null)
		{
			EMLMEPDGPCC.GIACEBJECPL();
		}
	}

	internal void AEMDPAAABAO(League BMNDININJCE)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		UnityEngine.Debug.Log($"FuseBox Event Level Up for level {data.GetPlayerLevel()}");
		int num = (int)BMNDININJCE;
		string fKBHNLOAPAA = num.ToString("D2");
		DAAFBKMOHFE("First_Time_Check_Leagues", "League", fKBHNLOAPAA, new Hashtable
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

	public void RegisterGameItemBoughtEvent(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, int LDJNLDKEBIG)
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Transaction_Amount", LDJNLDKEBIG);
		Hashtable cCODGCEOMOP = hashtable;
		DAAFBKMOHFE(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, cCODGCEOMOP);
		FEBJFEEMMKO(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, cCODGCEOMOP);
	}

	internal void CGAJBFNDLOE(AssignmentsManager.DatabaseAssignment EFEIDBFDDBE)
	{
		AssignmentsManager.AssignmentData data = AssignmentsManager.instance.data;
		string text = "Assignment_" + EFEIDBFDDBE.id;
		string secondTargetAsString = EFEIDBFDDBE.GetSecondTargetAsString();
		if (!string.IsNullOrEmpty(secondTargetAsString))
		{
			text = text + "_" + secondTargetAsString;
		}
		DAAFBKMOHFE("Assignment_Skipped", "AssignmentId", text, new Hashtable { { "Mega_Reward", data.megaRewardPointsProgress } });
	}

	internal void DNKPEPIPDPH(string HFMHEKAJGKE, string KJBPJOMHNKB)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		UnityEngine.Debug.Log("REGISTERING PACK LOCATION " + HFMHEKAJGKE);
		DAAFBKMOHFE("Purchase_Special_Offer", "PackLocation", KJBPJOMHNKB + "_" + HFMHEKAJGKE, new Hashtable
		{
			{
				"Average_Player_Level",
				data.GetPlayerLevel()
			},
			{ "Total_Battles", data.totalBattles },
			{ "Total_Sessions", data.numberOfSessions }
		});
	}

	private void HIGFKPFIPAN()
	{
		if (HCOHLFLJHOM != null)
		{
			HCOHLFLJHOM();
		}
	}

	public void VideoWatched(string HKODIHDPOGE)
	{
		DAAFBKMOHFE("Video_feed_watched", "url", HKODIHDPOGE, new Hashtable());
	}

	public void CFGJLAHDDAO(bool PHMELCOOBJL)
	{
		int num = 1;
		int num2 = 0;
		if (PHMELCOOBJL)
		{
			num = LevelManager.instance.currentLevel.HGNPGJDCDHF();
			num2 = 1;
			RegisterGoldIn("WarBucks", num);
			RegisterWBIn("DELIVERYTIME", num2);
		}
		string text = (Singleton<GameController>.instance.isPVP ? "Directory \"{0}\" does not exists" : ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? string.Empty : "ID_TUTORIAL"));
		int num3 = ((!Singleton<GameController>.instance.isMission) ? Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.FFFNCBIJDPM() : Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.PIGHNCHDOOJ());
		int num4 = ((!Singleton<GameController>.instance.isMission) ? Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.CNLNJKDJBBJ : Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.IEFGHIOKCPN());
		if (!string.IsNullOrEmpty(text))
		{
			if (num3 > 1)
			{
				RegisterGoldIn(text, num3 - num);
			}
			if (num4 > 0)
			{
				RegisterWBIn(text, num4 - num2);
			}
		}
	}

	public void FinishLeague(League ELCGHEGDBEK, League NJFHKOHJNAG, int BOMMOMLJGLI)
	{
		League bestLeague = StatsManager.instance.bestLeague;
		bool flag = ELCGHEGDBEK != NJFHKOHJNAG;
		string dDLNDBANBHK = ((NJFHKOHJNAG <= ELCGHEGDBEK) ? "Player_relegated" : ((NJFHKOHJNAG <= bestLeague) ? "Player_promoted" : "Player_promoted_first_time"));
		if (flag)
		{
			int num = (int)NJFHKOHJNAG;
			DAAFBKMOHFE(dDLNDBANBHK, "League_Number", num.ToString(), new Hashtable
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

	public void RegisterBuyCardPackEvent(string KJBPJOMHNKB, int LDJNLDKEBIG, bool BFCEIPLLLAJ)
	{
		if (BFCEIPLLLAJ)
		{
			DAAFBKMOHFE("Spend_Gold_On_Card_Packs", "Pack_Type", KJBPJOMHNKB, new Hashtable
			{
				{ "Average_Transaction_Amount", LDJNLDKEBIG },
				{
					"Days_Since_Install",
					PlayerAnalytics.instance.data.GetDaysSinceInstall()
				}
			});
		}
	}

	public void RegisterAttribution(string NDPMDKGJAFH)
	{
		DAAFBKMOHFE("Attribution", "AttributionData", NDPMDKGJAFH, new Hashtable());
	}

	internal void HDAEIPHKKMK(StarterAssignment EFEIDBFDDBE)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		StatsManager.StatisticsData data2 = StatsManager.instance.data;
		int num = (int)Math.Round((double)data2.secondsPlayed / 60.0);
		UnityEngine.Debug.Log("REGISTER VIEW STARTER ASSIGNMENT " + EFEIDBFDDBE.order.ToString("D2") + " TAB " + num + ", mis = " + data2.missionsPlayed);
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Player_Level", data.GetPlayerLevel());
		hashtable.Add("Total_Matchmaking_Battles", data2.mmmGames);
		hashtable.Add("Total_Warpath_Attempts", data2.missionsPlayed);
		hashtable.Add("Mins_Played", num);
		Hashtable cCODGCEOMOP = hashtable;
		DAAFBKMOHFE("View_StarterAssignmentTab", "Id", EFEIDBFDDBE.order.ToString("D2"), cCODGCEOMOP);
		FEBJFEEMMKO("View_StarterAssignmentTab", "Id", EFEIDBFDDBE.order.ToString("D2"), cCODGCEOMOP);
	}

	public void ArenaBattleEnd(int OPCIFLNBJLI, int EHMEFHBAJIH, bool EOGKEIFLIIJ, float ONEAJNDIGKC)
	{
		DAAFBKMOHFE("ArenaBattleEnd", string.Empty, string.Empty, new Hashtable
		{
			{ "Win", EOGKEIFLIIJ },
			{ "Node", OPCIFLNBJLI },
			{ "Hearts", EHMEFHBAJIH },
			{ "Battle_length", ONEAJNDIGKC }
		});
	}

	public void RegisterStoreVisitComplete(string GPJPGBIAMON, bool PPAINICHFOB)
	{
		if (!string.IsNullOrEmpty(GPJPGBIAMON))
		{
			DAAFBKMOHFE("Store_Visit", "StoreEntryRoute", GPJPGBIAMON, new Hashtable { 
			{
				"Conversion",
				PPAINICHFOB ? 1 : 0
			} });
		}
	}

	public void AKBLKHDLFMF()
	{
		DAAFBKMOHFE("left", "weapon1", "Cards_Owned_Bronze", new Hashtable());
	}

	public void ClaimAchievement(AchievementProgress NAFGJOOCPBO)
	{
		AchievementsManager.CHIDHGCKCIK achievementDefinition = NAFGJOOCPBO.achievementDefinition;
		int num = 0;
		switch (NAFGJOOCPBO.achievementRewardType)
		{
		case PLGIEHJKMNP.Gold:
			num = achievementDefinition.FKIGMDIHKAA;
			break;
		case PLGIEHJKMNP.Tickets:
			num = achievementDefinition.ELCDCFHKGHC;
			break;
		case PLGIEHJKMNP.Scraps:
			num = achievementDefinition.KMCEFANOLKM;
			break;
		case PLGIEHJKMNP.WarBucks:
			num = achievementDefinition.BJFGHKNAIIE;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		DAAFBKMOHFE("AchievementClaimed", string.Empty, string.Empty, new Hashtable { 
		{
			NAFGJOOCPBO.achievementRewardType.ToString(),
			num
		} });
	}

	public void RegisterTutorialCoverEvent(string BOCEKNFGLPC, bool HFJIKFGLOGO)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
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
				HFJIKFGLOGO ? 1 : 0
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

	public void ArenaHeart()
	{
		DAAFBKMOHFE("ArenaHeartDialog", "Show", "1", new Hashtable { 
		{
			"Wins",
			WarArena.instance.data.wins
		} });
	}

	internal void MDMNFIABCHN(float HNDGIJBHMOD)
	{
		int num = (int)Mathf.Ceil(HNDGIJBHMOD / 10f);
		DAAFBKMOHFE("JoinMatch_ServerConnect", "Time_Range", "Time_Range_" + num, new Hashtable { { "Seconds_to_connect", HNDGIJBHMOD } });
	}

	public void RegisterAutodeployOff()
	{
		DAAFBKMOHFE("Autodeploy_Off", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString(), new Hashtable { 
		{
			"Total_Battles",
			PlayerAnalytics.instance.data.totalBattles
		} });
	}

	public void RegisterEconomyEvent(string DDLNDBANBHK, int LDJNLDKEBIG)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		DAAFBKMOHFE(DDLNDBANBHK, "PlayerLevel", data.GetPlayerLevel().ToString("D3"), new Hashtable
		{
			{ "Average_Transaction_Amount", LDJNLDKEBIG },
			{
				"Days_Since_Install",
				PlayerAnalytics.instance.data.GetDaysSinceInstall()
			}
		});
	}

	public void RegisterWatchAd(string FKBHNLOAPAA, bool AJEJIGJKPAP)
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("View_Completed", AJEJIGJKPAP ? 1 : 0);
		Hashtable cCODGCEOMOP = hashtable;
		DAAFBKMOHFE("Watch_Ad", "AdZone", FKBHNLOAPAA, cCODGCEOMOP);
		FEBJFEEMMKO("Watch_Ad", "AdZone", FKBHNLOAPAA, cCODGCEOMOP);
	}

	public void RegisterWBOut(string FKBHNLOAPAA, int IEALLELGOBM)
	{
		DAAFBKMOHFE("WB_Out_Flow", "Area", FKBHNLOAPAA, new Hashtable { { "Amount", IEALLELGOBM } });
	}

	public void RegisterKochavaInApp(string KJBPJOMHNKB, float OPEICELHNLI, string FJLBLLLEELD, string JAJLHFNHGOE)
	{
		FireEventParameters fireEventParameters = new FireEventParameters(FireEventType.Purchase);
		fireEventParameters.currency = JAJLHFNHGOE;
		fireEventParameters.price = OPEICELHNLI;
		fireEventParameters.name = KJBPJOMHNKB;
		fireEventParameters.contentType = FJLBLLLEELD;
		Kochava.FireEventStandard(fireEventParameters);
	}

	public void ArenaPoorConnection()
	{
		DAAFBKMOHFE("ArenaPoorConnection", "Show", "1", new Hashtable());
	}

	public void RefreshInstantBattle(int OCLBKLOCFKL, int MLLHIOKDAFN)
	{
		DAAFBKMOHFE("Refresh_Skirmish", "Refresh_Level", Mathf.Clamp(MLLHIOKDAFN, 0, 11).ToString(), new Hashtable { { "Gold", OCLBKLOCFKL } });
	}

	public void RegisterAutodeployOn()
	{
		DAAFBKMOHFE("Autodeploy_On", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString(), new Hashtable { 
		{
			"Total_Battles",
			PlayerAnalytics.instance.data.totalBattles
		} });
	}

	private void LBGLHBGEJFG()
	{
		LevelManager.LevelUp -= AFBHOJNGDAC;
	}

	public void CompleteAchievement(AchievementProgress FNDCLJPMFHP)
	{
		int num = FNDCLJPMFHP.group.id * 3 + FNDCLJPMFHP.id;
		DAAFBKMOHFE("AchievementCompleted", string.Empty, string.Empty, new Hashtable { { "id", num } });
	}

	public void AchievementPageOpened()
	{
		DAAFBKMOHFE("Achievement_page_accessed", "open", "1", new Hashtable());
	}

	public void RegisterTutorialGameEnded(int HLGMHEEJGOC, string BOCEKNFGLPC)
	{
		UnityEngine.Debug.Log($"Event Tracking Manager - Tutorial Game Ended, Deploy clicks: {StatsManager.instance.matchStats.deployClicks}, Deployed units: {StatsManager.instance.matchStats.unitsDeployed}");
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
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
		FEBJFEEMMKO("Tutorial_Step_Complete", new Dictionary<string, object> { { "Step", HLGMHEEJGOC } });
		if (HLGMHEEJGOC == 3)
		{
			Kochava.FireEvent("Tutorial_completed", string.Empty);
		}
	}

	public void VideoUploaded(bool NOCIMJBMOCB, string HKODIHDPOGE)
	{
		DAAFBKMOHFE("Video_feed_upload", "url", HKODIHDPOGE, new Hashtable { 
		{
			"accepted",
			NOCIMJBMOCB ? 1 : 0
		} });
	}

	public void BuyHeart(int FMCANDNKEKC, int HAFMGCFMCPC, int LONFCMDPPPL)
	{
		DAAFBKMOHFE("BuyHeart", "Attempt", LONFCMDPPPL.ToString(), new Hashtable
		{
			{ "Gold", HAFMGCFMCPC },
			{ "Tickets", FMCANDNKEKC }
		});
	}

	public void RegisterDuplicateLootbox(int DADJEBGBFMK)
	{
		UnityEngine.Debug.Log($"FuseBox Event DuplicateLootbox for {DADJEBGBFMK}");
		DAAFBKMOHFE("LootBox_Duplicate", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString("D3"), new Hashtable { { "Gained_WB", DADJEBGBFMK } });
	}

	public void LoginToFacebook()
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		DAAFBKMOHFE("Fb_login", "PlayerLevel", LevelManager.instance.currentLevel.displayNumber.ToString(CultureInfo.InvariantCulture), new Hashtable { 
		{
			"Days_Since_Install",
			data.GetDaysSinceInstall()
		} });
	}

	public void RegisterPlayerLevelUp(string FKBHNLOAPAA, bool GOAKDPJHAHK)
	{
		DAAFBKMOHFE("Player_Level_Up", "NotificationsEnabled", FKBHNLOAPAA, new Hashtable { 
		{
			"Is_Enabled",
			GOAKDPJHAHK ? 1 : 0
		} });
	}

	internal void MINMHKPKOMN(AssignmentsManager.DatabaseAssignment EFEIDBFDDBE, int DBMCPFLKGLH, bool LHKNKPDMNJH)
	{
		int id = EFEIDBFDDBE.id;
		string secondTargetAsString = EFEIDBFDDBE.GetSecondTargetAsString();
		string text = ((EFEIDBFDDBE.tutorialId <= 0) ? ("Assignment_" + id) : EFEIDBFDDBE.tutorialId.ToString("D3"));
		if (!string.IsNullOrEmpty(secondTargetAsString))
		{
			text = text + "_" + secondTargetAsString;
		}
		UnityEngine.Debug.Log("Register Assignment Issued " + id.ToString("D3"));
		DAAFBKMOHFE("Assignment_Issued", "AssignemntId", text, new Hashtable
		{
			{ "Total_Assignment_Issued", DBMCPFLKGLH },
			{
				"From_queue",
				(!LHKNKPDMNJH) ? "0" : "1"
			}
		});
	}

	public void BlackMarketWeapon(string JMMJHCOKCGG, int HAFMGCFMCPC, int KBBDGCLPOCJ)
	{
		DAAFBKMOHFE("Black_market_weapon", "Weapon", JMMJHCOKCGG, new Hashtable
		{
			{ "Gold", HAFMGCFMCPC },
			{ "Upgrades", KBBDGCLPOCJ }
		});
	}

	public void RegisterSquadActivity(string LHLNOICCHLH)
	{
		bool flag = string.Compare("Create_Squad", LHLNOICCHLH) == 0;
		DAAFBKMOHFE("Squad_Activity", "ActivityType", LHLNOICCHLH, new Hashtable { 
		{
			(!flag) ? "Total_Battles" : "Days_Since_Install",
			(!flag) ? PlayerAnalytics.instance.data.totalBattles : PlayerAnalytics.instance.data.GetDaysSinceInstall()
		} });
	}

	public void ScrapsGained(string CBMKJAFIBKH, int MDOHMDGAHDD)
	{
		DAAFBKMOHFE("ScrapsGained", "Location", CBMKJAFIBKH, new Hashtable { { "Tickets", MDOHMDGAHDD } });
	}

	internal void ENALKGDOHDD(AssignmentsManager.DatabaseAssignment EFEIDBFDDBE, int AJEJIGJKPAP)
	{
		AssignmentsManager.AssignmentData data = AssignmentsManager.instance.data;
		if (EFEIDBFDDBE.tutorialId > 0)
		{
			UnityEngine.Debug.Log("REGISTER PREDEFINED ASSIGNMENT EVENT COMPLETED" + EFEIDBFDDBE.tutorialId.ToString("D3"));
			DAAFBKMOHFE("Predefined_Assignment_Completed", "AssignemntId", EFEIDBFDDBE.tutorialId.ToString("D3"), new Hashtable
			{
				{ "Total_Assignment_Completed", AJEJIGJKPAP },
				{ "Mega_Reward", data.megaRewardPointsProgress }
			});
			return;
		}
		string text = "Assignment_" + EFEIDBFDDBE.id;
		string secondTargetAsString = EFEIDBFDDBE.GetSecondTargetAsString();
		if (!string.IsNullOrEmpty(secondTargetAsString))
		{
			text = text + "_" + secondTargetAsString;
		}
		DAAFBKMOHFE("Assignment_Completed", "AssignemntId", text, new Hashtable
		{
			{ "Total_Assignment_Completed", AJEJIGJKPAP },
			{ "Mega_Reward", data.megaRewardPointsProgress }
		});
	}

	public void ArenaBattleStart(int LONFCMDPPPL, int EHMEFHBAJIH, float KBJEOEEOEFG)
	{
		DAAFBKMOHFE("ArenaBattleStart", "Wins", LONFCMDPPPL.ToString(), new Hashtable
		{
			{ "Hearts", EHMEFHBAJIH },
			{ "WaitTime", KBJEOEEOEFG }
		});
	}

	private void FEBJFEEMMKO(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		Dictionary<string, object> dictionary = CCODGCEOMOP.toDictionary();
		dictionary[ICCBMABGOCP] = FKBHNLOAPAA;
		FacebookAndroid.logEvent(DDLNDBANBHK, dictionary);
	}

	public void ArenaExpired(int LONFCMDPPPL, int EHMEFHBAJIH, bool PHMCGDOECOH)
	{
		DAAFBKMOHFE("ArenaFinished", "Wins", LONFCMDPPPL.ToString(), new Hashtable
		{
			{ "Hearts", EHMEFHBAJIH },
			{
				"ExtraHeart",
				PHMCGDOECOH ? 1 : 0
			}
		});
	}

	public void RegisterSocialBehaviour(string FKBHNLOAPAA)
	{
		DAAFBKMOHFE("Social_Behaviour", "ActivityType", FKBHNLOAPAA, new Hashtable { 
		{
			"Days_Since_Install",
			PlayerAnalytics.instance.data.GetDaysSinceInstall()
		} });
	}

	public void getAdlimits(JToken LFPFCHIJLML)
	{
		UnityEngine.Debug.Log(LFPFCHIJLML.ToString());
		if (KEFINGEDLKO == null)
		{
			KEFINGEDLKO = new KHHOMCIOKAO();
		}
		KEFINGEDLKO.MENAHKIIFOC(LFPFCHIJLML);
		if (AANBNJHELAI != null)
		{
			AANBNJHELAI();
		}
	}

	public void RegisterRewardClaimedEvent(int DHMHOEGPDAP, int IDDFHCAMPIJ, MDNLFMNBNEG GGIOEPBPMHF)
	{
		DAAFBKMOHFE("Daily_Reward_Claimed", "forDay", DHMHOEGPDAP.ToString(), new Hashtable
		{
			{ "monthLenght", IDDFHCAMPIJ },
			{
				"RewardType",
				(int)GGIOEPBPMHF
			}
		});
	}

	public void RegisterTutorialEvent(string BOCEKNFGLPC)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
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

	internal void AELDEBEBIJO(string ICDKHLOBKIE, int[] LEIKKCNNNIO)
	{
		DAAFBKMOHFE("CardTrade_Deposit", "CardId", ICDKHLOBKIE, new Hashtable
		{
			{
				"Cards_Owned_Bronze",
				LEIKKCNNNIO[0]
			},
			{
				"Cards_Owned_Silver",
				LEIKKCNNNIO[1]
			},
			{
				"Cards_Owned_Gold",
				LEIKKCNNNIO[2]
			}
		});
	}

	public void EnterWarArena(int FMCANDNKEKC, int HAFMGCFMCPC, int DKHDNINDEKD)
	{
		DAAFBKMOHFE("EnterArena", "Attempt", Mathf.Clamp(DKHDNINDEKD, 0, 50).ToString(), new Hashtable
		{
			{ "Gold", HAFMGCFMCPC },
			{ "Tickets", FMCANDNKEKC }
		});
	}

	public void RegisterBuyLootboxes(string FNGFKECJEGL, List<CCNAEIGGMNK> NMJKMJBFFFJ)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		UnityEngine.Debug.Log($"FuseBox Event BuyLootboxes for id {FNGFKECJEGL}");
		string fKBHNLOAPAA = data.GetPlayerLevel() + "_" + FNGFKECJEGL;
		Dictionary<PlayerVisual.EJHADIHBCBK, int> itemsCountByRarity = CamosManager.instance.GetItemsCountByRarity(NMJKMJBFFFJ);
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Days_Since_Install", data.GetDaysSinceInstall());
		hashtable.Add("MadeIApp", data.MadeInApp());
		hashtable.Add("Gold_Balance", Singleton<Wallet>.instance.gold);
		hashtable.Add("ItemsOwned_Rarity_0", itemsCountByRarity[PlayerVisual.EJHADIHBCBK.Common]);
		hashtable.Add("ItemsOwned_Rarity_1", itemsCountByRarity[PlayerVisual.EJHADIHBCBK.Uncommon]);
		hashtable.Add("ItemsOwned_Rarity_2", itemsCountByRarity[PlayerVisual.EJHADIHBCBK.Rare]);
		hashtable.Add("ItemsOwned_Rarity_3", itemsCountByRarity[PlayerVisual.EJHADIHBCBK.Epic]);
		hashtable.Add("ItemsOwned_Rarity_4", itemsCountByRarity[PlayerVisual.EJHADIHBCBK.Legendary]);
		Hashtable cCODGCEOMOP = hashtable;
		DAAFBKMOHFE("LootBox_Purchase", "PlayerRank_BoxID", fKBHNLOAPAA, cCODGCEOMOP);
	}

	public void RegisterTutorialWeaponEquippedEvent(string BOCEKNFGLPC, bool FKGMHJCKAEK)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
		{
			{ "Sniper_Tutorial_Played", 0 },
			{ "Sniper_Tutorial_Duration", 0 },
			{ "Player_Had_To_Select_Grenade", 0 },
			{ "Grenade_Throwing_Tutorial_Duration", 0 },
			{
				"Automatic_Equip",
				FKGMHJCKAEK ? 1 : 0
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

	public void RegisterRentalEvent(string NAOKOECMJNA, string DDLOAFGAEAC, int ALOAKBMELMH, int BALDIENIGEP)
	{
		PlayerAnalytics.PlayerAnalyticsData data = PlayerAnalytics.instance.data;
		Hashtable hashtable = new Hashtable();
		hashtable.Add("GoldBalance", Singleton<Wallet>.instance.gold);
		hashtable.Add("WarbucksBalance", Singleton<Wallet>.instance.warBucks);
		hashtable.Add("PlayerLevel", data.GetPlayerLevel());
		Hashtable hashtable2 = hashtable;
		if (ALOAKBMELMH >= 0)
		{
			hashtable2.Add("WBTransactionAmount", ALOAKBMELMH);
		}
		if (BALDIENIGEP >= 0)
		{
			hashtable2.Add("GoldTransactionAmount", BALDIENIGEP);
		}
		DAAFBKMOHFE(NAOKOECMJNA, "ItemID", DDLOAFGAEAC, hashtable2);
	}

	public void RegisterInstatntBattle(int DBICDFBNEIO, int KECMCAKIBNL, int GHIANIACEHK, List<Card> ACIOBAPMPMD, int PDMGPGEHLNM)
	{
		DAAFBKMOHFE("Play_Skirmish", "count", PDMGPGEHLNM.ToString(), new Hashtable
		{
			{ "Warbucks", DBICDFBNEIO },
			{ "Gold", KECMCAKIBNL },
			{ "XP", GHIANIACEHK },
			{ "Cards", ACIOBAPMPMD.Count }
		});
	}

	public void RegisterTutorialDialogEvent(string BOCEKNFGLPC, bool LNFHFHCDENM)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
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
				LNFHFHCDENM ? 1 : 0
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

	public void RegisterTutorialWeaponSelectedEvent(string BOCEKNFGLPC, bool DLCOBIBGNOB, bool HGJDJDPDDDI)
	{
		DAAFBKMOHFE("Tutorial_Step_Complete", "StepId", BOCEKNFGLPC, new Hashtable
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
				DLCOBIBGNOB ? 1 : 0
			},
			{
				"Wrong_Weapon",
				HGJDJDPDDDI ? 1 : 0
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

	public void RegisterBroadcastEnd(float DNDHIFENDPJ, int FCDIFINLKIA)
	{
		DAAFBKMOHFE("Broadcast_End", "PlayerLevel", PlayerAnalytics.instance.data.GetPlayerLevel().ToString(), new Hashtable
		{
			{ "Battles_Played", FCDIFINLKIA },
			{
				"Broadcast_Duration",
				(long)DNDHIFENDPJ
			}
		});
	}
}
