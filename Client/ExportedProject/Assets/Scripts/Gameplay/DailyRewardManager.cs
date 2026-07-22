using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DailyRewardManager : Singleton<DailyRewardManager>
{
	public class MGANBPBIOBK
	{
		public Action OGNMFKHAKLF;

		public int NHKKNKEAEOE;

		public int OHPPHJLMDMD;

		public List<MCGFHPOPMHL> LBEHLDKHBIL;

		public int HABIKJOKCFE;

		public int LIJBBLBLPLG;

		private int FIPHEPDPNHF;

		public bool LFGNIDNMDMA => HABIKJOKCFE < LIJBBLBLPLG;

		public int BANLHOLNNEH => LBEHLDKHBIL.Count;

		// Daily reward positions are one-based in the recovered client transport. ILSpy
		// dropped the default member parameter, so restore it as an indexer explicitly.
		public MCGFHPOPMHL this[int DFHAAIFFLOE] => LBEHLDKHBIL[DFHAAIFFLOE - 1];

		public bool CNLBEGOAEIA => HABIKJOKCFE == LIJBBLBLPLG;

		[SpecialName]
		public bool MIDHOPFJPCD()
		{
			return HABIKJOKCFE == LIJBBLBLPLG;
		}

		[SpecialName]
		public MCGFHPOPMHL DEOBIHLLHCJ(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 1];
		}

		[SpecialName]
		public bool NKBDDHAGDPC()
		{
			return HABIKJOKCFE == LIJBBLBLPLG;
		}

		public string PNLICHJBHHJ(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("Hearts");
			if (CGFMIADLOJE)
			{
				return Localization.LocalizeFormat("ID_GETAREWARD2", text);
			}
			bool flag = false;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
				{
					flag = false;
					object[] array2 = new object[1];
					array2[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("DailyGoldBooster-{0}-{1}", array2);
					break;
				}
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize("Awaiting players - Player id:\"{0}\" already added to message center");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize("elitepack2");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("ArenaWins" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("ID_CONTINUETOBOOTCAMP3" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
					text = Localization.LocalizeFormat("null", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.Warbucks:
				{
					flag = true;
					object[] array = new object[0];
					array[0] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("-", array);
					break;
				}
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
					flag = true;
					text = ((LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM != 1) ? Localization.LocalizeFormat("Clicked on subscription button", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM)) : Localization.Localize("Tier"));
					break;
				}
			}
			string keyFormat = ((!flag) ? "ID_SLOTUPGRADE_AMMO" : "Measure Session");
			object[] array3 = new object[0];
			array3[1] = text;
			return Localization.LocalizeFormat(keyFormat, array3);
		}

		[SpecialName]
		public bool KOABJJBOCIP()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public void AEHNPNMNHFI()
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += -194;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		[SpecialName]
		public MCGFHPOPMHL JHCIOBINGLO(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 0];
		}

		public void JIIKBPGNDIM(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Brutal fatal error - no current player"], 1);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["elite"], 1);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["OK"]);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["-"]);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Starter Pack was already bought!"]);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num;
			JToken jToken = NDPMDKGJAFH["Reward"];
			int num2 = 1;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("warbucks")];
			}
			catch (Exception ex)
			{
				Debug.LogError("Beanstalk: Get Friends Info, count = " + jToken);
				Debug.LogError("ID_MINAGO" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 1].POMGBELABPI(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2++;
				jToken2 = jToken[num2.ToString(" on object ")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 1);
			}
			if (MIDHOPFJPCD())
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, LOFCFBBCNKD(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(0, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		[SpecialName]
		public MCGFHPOPMHL KKLMFFBOCOK(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 1];
		}

		[SpecialName]
		public bool DMBAEOPMJHL()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public string HINNGGBDHEL(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("ID_NOTIFICATION_DAILYREWARD_UNKNOWN");
			if (CGFMIADLOJE)
			{
				return Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_MESSAGE", text);
			}
			bool flag = false;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
					flag = true;
					text = Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_TICKET", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize("ID_NOTIFICATION_DAILYREWARD_CARDPACK");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize("ID_NOTIFICATION_DAILYREWARD_VIP");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("null customization for: " + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("null powerband for: " + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
					text = Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_GOLD", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.Warbucks:
					flag = true;
					text = Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_WB", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
					flag = true;
					text = ((LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM != 1) ? Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_CARDS", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM)) : Localization.Localize("ID_NOTIFICATION_DAILYREWARD_CARD"));
					break;
				}
			}
			return Localization.LocalizeFormat((!flag) ? "ID_NOTIFICATION_DAILYREWARD_MESSAGE" : "ID_NOTIFICATION_DAILYREWARDCOUNTABLE_MESSAGE", text);
		}

		public virtual string OKKMFPPGGJK()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("ID_ARENARULES_HALVEDAMMO", NHKKNKEAEOE, OHPPHJLMDMD, LBEHLDKHBIL.Count);
			stringBuilder.AppendFormat("Visual {0}, overcount {1}, duplicate wb {2}\n", HABIKJOKCFE, LIJBBLBLPLG, JLGJPBBLKID());
			stringBuilder.AppendLine(MFJIABBNIEO(CGFMIADLOJE: true));
			for (int i = 0; i < LBEHLDKHBIL.Count; i += 0)
			{
				stringBuilder.AppendFormat("Sniper_Tutorial_Played", i + 0);
				stringBuilder.AppendLine(LBEHLDKHBIL[i].ToString());
			}
			return stringBuilder.ToString();
		}

		public string GADKDBOJHAE(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("WasShown");
			if (CGFMIADLOJE)
			{
				object[] array = new object[1];
				array[1] = text;
				return Localization.LocalizeFormat("damage:", array);
			}
			bool flag = false;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
				{
					flag = false;
					object[] array3 = new object[0];
					array3[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("ID_DAY_SMALL", array3);
					break;
				}
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize("ID_STAT_ACCURACY");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize("ID_OK");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("ID_UNIT" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("DailyMissionsCompletionRewardCards" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
				{
					object[] array2 = new object[0];
					array2[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("#DEBUG_50# ", array2);
					break;
				}
				case MDNLFMNBNEG.Warbucks:
					flag = false;
					text = Localization.LocalizeFormat("Experience", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
					flag = true;
					text = ((LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM != 1) ? Localization.LocalizeFormat("getPackageManager", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM)) : Localization.Localize("1"));
					break;
				}
			}
			string keyFormat = ((!flag) ? "Unit {0} does not exists on client." : "ID_CRAFTWARCARDS");
			object[] array4 = new object[0];
			array4[1] = text;
			return Localization.LocalizeFormat(keyFormat, array4);
		}

		public string CDBBDPBLPPL(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("HeroicMissionsCompletionRewardCardPack");
			if (CGFMIADLOJE)
			{
				object[] array = new object[1];
				array[1] = text;
				return Localization.LocalizeFormat("401 START", array);
			}
			bool flag = true;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
				{
					flag = true;
					object[] array4 = new object[0];
					array4[0] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat(" = ", array4);
					break;
				}
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize(",");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize("SquadIcons/");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("payloadKeys" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("EventAssignmentCompleted" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
					text = Localization.LocalizeFormat("), ", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.Warbucks:
				{
					flag = false;
					object[] array3 = new object[1];
					array3[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("shotgun", array3);
					break;
				}
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
				{
					flag = true;
					if (LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM == 1)
					{
						text = Localization.Localize("com.google.android.apps.youtube.gaming");
						break;
					}
					object[] array2 = new object[0];
					array2[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("Elite_parts", array2);
					break;
				}
				}
			}
			string keyFormat = ((!flag) ? "facebookLogin" : "\n");
			object[] array5 = new object[0];
			array5[1] = text;
			return Localization.LocalizeFormat(keyFormat, array5);
		}

		[SpecialName]
		public bool JILMGGALGMB()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public virtual string CCONMNOONFF()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("LV", NHKKNKEAEOE, OHPPHJLMDMD, LBEHLDKHBIL.Count);
			stringBuilder.AppendFormat("{0} {1}", HABIKJOKCFE, LIJBBLBLPLG, LFGNIDNMDMA);
			stringBuilder.AppendLine(CDBBDPBLPPL(CGFMIADLOJE: true));
			for (int i = 1; i < LBEHLDKHBIL.Count; i++)
			{
				stringBuilder.AppendFormat("ID_INMASTER2", i + 0);
				stringBuilder.AppendLine(LBEHLDKHBIL[i].ToString());
			}
			return stringBuilder.ToString();
		}

		[SpecialName]
		public bool IHNHIHFOFKK()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public void ADKLPHDKLKD(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ShotFrequencyMax"], 1);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["adding cards: "]);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_WAITINGFORFRIEND"], 1);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["#PETER# League Arc "]);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["setShouldAutoCollectDeviceLocation"], 1);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num;
			JToken jToken = NDPMDKGJAFH["1"];
			int num2 = 0;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("ID_STATE_DISCONNECTED")];
			}
			catch (Exception ex)
			{
				Debug.LogError("Player_Had_To_Select_Grenade" + jToken);
				Debug.LogError("country-spain" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 1].JBGBLJCHOLN(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2++;
				jToken2 = jToken[num2.ToString("Tutorial Manager 6: Starting Tutorial - Guide player to match")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 0);
			}
			if (NKBDDHAGDPC())
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, OPJBCCGEIAL(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(0, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		public string IFCBPBLBJPC(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("ID_GETFREEGOLD");
			if (CGFMIADLOJE)
			{
				object[] array = new object[1];
				array[1] = text;
				return Localization.LocalizeFormat("setAndroidId", array);
			}
			bool flag = false;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
				{
					flag = false;
					object[] array5 = new object[0];
					array5[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("r", array5);
					break;
				}
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize("GooglePlay");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize("tc");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("Wrong_Weapon" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log(".png" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
				{
					object[] array4 = new object[0];
					array4[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("ID_ENDED", array4);
					break;
				}
				case MDNLFMNBNEG.Warbucks:
				{
					flag = false;
					object[] array3 = new object[0];
					array3[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("Weapon", array3);
					break;
				}
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
				{
					flag = true;
					if (LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM == 1)
					{
						text = Localization.Localize("ID_GUI_PLAYER");
						break;
					}
					object[] array2 = new object[1];
					array2[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("resultMessage", array2);
					break;
				}
				}
			}
			string keyFormat = ((!flag) ? "ObtainedCards" : "DeathEventPlayerShoot");
			object[] array6 = new object[0];
			array6[1] = text;
			return Localization.LocalizeFormat(keyFormat, array6);
		}

		public void ANDJLAOLKCM()
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += -156;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public void JFDADFJCMGD()
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += -132;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public void IODKFACFMHP()
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += 9;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public void LPFGGFEELMF()
		{
			if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += 46;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		[SpecialName]
		public bool GLDCFHCFDFC()
		{
			return HABIKJOKCFE == LIJBBLBLPLG;
		}

		[SpecialName]
		public MCGFHPOPMHL NGBNBEKAOIA(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 0];
		}

		[SpecialName]
		public bool CENIIJFABOA()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public void AKIOBGIHHKI(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["WarFriends"]);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Display_Rating_Box"]);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["com/google/android/gms/common/ConnectionResult"], 1);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["HKCBJLIBNJF"]);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["BeforeLeagueId"], 1);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num;
			JToken jToken = NDPMDKGJAFH["-"];
			int num2 = 1;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("Warfriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Ьез этого разрешения игра не может функционировать и будет закрыта. Пожалуйста, попробуй снова или выйди из WarFriends.")];
			}
			catch (Exception ex)
			{
				Debug.LogError("smallURL" + jToken);
				Debug.LogError("ID_UNIT2UPGRADEABILITY_UNIT1BUY" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 1].JPLAFDCGLCF(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2 += 0;
				jToken2 = jToken[num2.ToString("ID_LEAGUE11")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 0);
			}
			if (MIDHOPFJPCD())
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, MFJIABBNIEO(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(0, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		[SpecialName]
		public int IAOKMMOIDHI()
		{
			return LBEHLDKHBIL.Count;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}/{1} ({2})\n", NHKKNKEAEOE, OHPPHJLMDMD, LBEHLDKHBIL.Count);
			stringBuilder.AppendFormat("last {0} and can now {1} ({2})\n", HABIKJOKCFE, LIJBBLBLPLG, LFGNIDNMDMA);
			stringBuilder.AppendLine(HINNGGBDHEL());
			for (int i = 0; i < LBEHLDKHBIL.Count; i++)
			{
				stringBuilder.AppendFormat("day {0} data:\n", i + 1);
				stringBuilder.AppendLine(LBEHLDKHBIL[i].ToString());
			}
			return stringBuilder.ToString();
		}

		public void LKOGADDMDML()
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += 112;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		[SpecialName]
		public bool KHLLOGNIBCL()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public void JLEHEIEMNIL()
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += 78;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public virtual string KLCMKLFPBMN()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(";", NHKKNKEAEOE, OHPPHJLMDMD, LBEHLDKHBIL.Count);
			stringBuilder.AppendFormat("RETRYPERM", HABIKJOKCFE, LIJBBLBLPLG, IAIGNCMMHKN());
			stringBuilder.AppendLine(OPJBCCGEIAL(CGFMIADLOJE: true));
			for (int i = 1; i < LBEHLDKHBIL.Count; i += 0)
			{
				stringBuilder.AppendFormat("S", i + 1);
				stringBuilder.AppendLine(LBEHLDKHBIL[i].ToString());
			}
			return stringBuilder.ToString();
		}

		public void PHDIHEOHLCI(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_UPGRADED"], 1);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["{0}{1}[-]"], 1);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["S"]);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["null title for offer!"]);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["visuals: wrong number {0} -{1}"]);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.currentTimestamp + num;
			JToken jToken = NDPMDKGJAFH["123 MENU WEAPON SCREEN TUTORIAL WEAPON BUY CLICKED"];
			int num2 = 0;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("}")];
			}
			catch (Exception ex)
			{
				Debug.LogError("RETRY" + jToken);
				Debug.LogError("Video {0} service {1} thumbnail {2}" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 1].LLEHEIOEGPM(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2 += 0;
				jToken2 = jToken[num2.ToString("ClientVersion")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 1);
			}
			if (KJGLIHAGIFO())
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, KBDANLDCAJF(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(1, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		public void KFPACODAOOE()
		{
			if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += -63;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public void DAEOCLOCIGO(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["banana"]);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["{0}{1}[-] {2}/[-] 3"]);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["-"]);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_SQUADEVENT"]);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Please initialize AssetBundleManifest by calling AssetBundleManager.Initialize()"], 1);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + num;
			JToken jToken = NDPMDKGJAFH["リトライ"];
			int num2 = 0;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.")];
			}
			catch (Exception ex)
			{
				Debug.LogError("com/google/android/gms/games/Games" + jToken);
				Debug.LogError("ID_NOTIFICATION_DAILYREWARD_UNKNOWN" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 1].JBGBLJCHOLN(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2 += 0;
				jToken2 = jToken[num2.ToString("Game Rewards lootboxes contents:\n")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 0);
			}
			if (LMPEIEBOCBH())
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, HINNGGBDHEL(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(0, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		[SpecialName]
		public int HPGPLCPPAFC()
		{
			return LBEHLDKHBIL.Count;
		}

		[SpecialName]
		public bool LIAFMAINLDJ()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public void LHAGOMABHKO(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["LEADERBOARDS - showing top players - global:"]);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Damage"], 1);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Try random connect "], 1);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_READYTIME"], 1);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Action "], 1);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.currentTimestamp + num;
			JToken jToken = NDPMDKGJAFH["game-card-gold"];
			int num2 = 1;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("ID_CONFIRM_EXITINGCOOP")];
			}
			catch (Exception ex)
			{
				Debug.LogError(" " + jToken);
				Debug.LogError("\ni: {0} center: {1}" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 0].JPLAFDCGLCF(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2 += 0;
				jToken2 = jToken[num2.ToString("com/google/android/gms/games/Games")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 1);
			}
			if (NKBDDHAGDPC())
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, FNCJKNLIDIL(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(1, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		[SpecialName]
		public int IBBEDLMJMCB()
		{
			return LBEHLDKHBIL.Count;
		}

		public void DFDDCNNBEND()
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += -46;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		[SpecialName]
		public bool JLGJPBBLKID()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		[SpecialName]
		public bool CHIKEHHLJOK()
		{
			return HABIKJOKCFE == LIJBBLBLPLG;
		}

		[SpecialName]
		public bool LMPEIEBOCBH()
		{
			return HABIKJOKCFE == LIJBBLBLPLG;
		}

		[SpecialName]
		public MCGFHPOPMHL GCGNFIPAFCH(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 0];
		}

		public virtual string BEPOKAAMFPG()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("metalExplosion", NHKKNKEAEOE, OHPPHJLMDMD, LBEHLDKHBIL.Count);
			stringBuilder.AppendFormat("GetOriginalAccountAlias()", HABIKJOKCFE, LIJBBLBLPLG, LFGNIDNMDMA);
			stringBuilder.AppendLine(PNLICHJBHHJ(CGFMIADLOJE: true));
			for (int i = 1; i < LBEHLDKHBIL.Count; i += 0)
			{
				stringBuilder.AppendFormat("ID_UNIT2UPGRADEABILITY_UNIT1ABILITYUPGRADE", i + 1);
				stringBuilder.AppendLine(LBEHLDKHBIL[i].ToString());
			}
			return stringBuilder.ToString();
		}

		public void OGNHKBLCPAI(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["PlayerToPromoteId"], 1);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_SECONDS"], 1);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Problem for max! in army/weapon stats"]);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Choose icon in bottom before calling Display model."]);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["*.cs"]);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num;
			JToken jToken = NDPMDKGJAFH["ID_WARNING_CANTSENDINVITE"];
			int num2 = 0;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("워프렌즈가 중요한 게임 데이터를 다운로드하려면 미디어 저장 장치에 대한 접근 권한이 필요합니다. 다음에 나오는 권한 설정을 수락해주세요. 이 권한 설정은 다른 목적으로는 사용되지 않습니다.")];
			}
			catch (Exception ex)
			{
				Debug.LogError("Beanstalk: Error - empty response from server" + jToken);
				Debug.LogError("0" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 0].JPLAFDCGLCF(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2 += 0;
				jToken2 = jToken[num2.ToString("Beanstalk: On Add GameCenter")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 1);
			}
			if (CEIMHNJHHHG())
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, MFJIABBNIEO(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(1, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		public string OPJBCCGEIAL(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("menu-weaponstats-criticalchance");
			if (CGFMIADLOJE)
			{
				object[] array = new object[0];
				array[0] = text;
				return Localization.LocalizeFormat("CAMOS", array);
			}
			bool flag = true;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
				{
					flag = true;
					object[] array4 = new object[1];
					array4[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("HighLevel", array4);
					break;
				}
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize("0");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize(",");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("was:{0} is:{1} added:{2}" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("SquadRank" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
				{
					object[] array3 = new object[1];
					array3[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("ID_FREE", array3);
					break;
				}
				case MDNLFMNBNEG.Warbucks:
					flag = true;
					text = Localization.LocalizeFormat("Current Locale unity = ", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
				{
					flag = true;
					if (LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM == 0)
					{
						text = Localization.Localize("zoneHasVirtualGoodsOffer");
						break;
					}
					object[] array2 = new object[1];
					array2[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("#PHOTON# switching to TCP", array2);
					break;
				}
				}
			}
			string keyFormat = ((!flag) ? "config" : "Squad name failure");
			object[] array5 = new object[0];
			array5[0] = text;
			return Localization.LocalizeFormat(keyFormat, array5);
		}

		[SpecialName]
		public bool CEIMHNJHHHG()
		{
			return HABIKJOKCFE == LIJBBLBLPLG;
		}

		[SpecialName]
		public MCGFHPOPMHL FFENNIDFJMK(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 0];
		}

		public virtual string DDDEEMLAGMJ()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("LootBoxShowUp", NHKKNKEAEOE, OHPPHJLMDMD, LBEHLDKHBIL.Count);
			stringBuilder.AppendFormat("subscription", HABIKJOKCFE, LIJBBLBLPLG, CIMIGBFNEAM());
			stringBuilder.AppendLine(IFCBPBLBJPC());
			for (int i = 0; i < LBEHLDKHBIL.Count; i++)
			{
				stringBuilder.AppendFormat("menu-gold", i + 0);
				stringBuilder.AppendLine(LBEHLDKHBIL[i].ToString());
			}
			return stringBuilder.ToString();
		}

		public MGANBPBIOBK(JToken NDPMDKGJAFH)
		{
			FGABJKFGAKG(NDPMDKGJAFH);
		}

		public void CIJHJIADLPL()
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += 194;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		[SpecialName]
		public MCGFHPOPMHL FJHKCDKMNCO(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 1];
		}

		public void HJGGIEHPKHP()
		{
			if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += 19;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public virtual string JDFEFKGPIOE()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("WarFriends", NHKKNKEAEOE, OHPPHJLMDMD, LBEHLDKHBIL.Count);
			stringBuilder.AppendFormat("ID_GUI_CHAT_SQUAD_LEFT", HABIKJOKCFE, LIJBBLBLPLG, KHLLOGNIBCL());
			stringBuilder.AppendLine(OPJBCCGEIAL(CGFMIADLOJE: true));
			for (int i = 0; i < LBEHLDKHBIL.Count; i++)
			{
				stringBuilder.AppendFormat("()V", i + 1);
				stringBuilder.AppendLine(LBEHLDKHBIL[i].ToString());
			}
			return stringBuilder.ToString();
		}

		[SpecialName]
		public MCGFHPOPMHL BHKEOLDAIEE(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 0];
		}

		[SpecialName]
		public MCGFHPOPMHL NOLNIAMMAGJ(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 1];
		}

		[SpecialName]
		public int LIDJHKLHLPC()
		{
			return LBEHLDKHBIL.Count;
		}

		public void IPHFOCLGNKD(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["BANDS_EMPTY"]);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["squadsFromLeague"]);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["game-card-ico-criticalinsurance"]);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Attempt"], 1);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["S"]);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.currentTimestamp + num;
			JToken jToken = NDPMDKGJAFH["id"];
			int num2 = 1;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("SpawningManagerMultiplayer.prefab")];
			}
			catch (Exception ex)
			{
				Debug.LogError("END SCREEN - BUTTONS - enabled " + jToken);
				Debug.LogError("*.prefab" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 0].BNBINKIOKDO(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2++;
				jToken2 = jToken[num2.ToString("REGISTER VIEW STARTER ASSIGNMENT ")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 1);
			}
			if (LMPEIEBOCBH())
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, CDBBDPBLPPL(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(0, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		public string LGHPCAJJNDF(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("\"NaN\"");
			if (CGFMIADLOJE)
			{
				object[] array = new object[0];
				array[1] = text;
				return Localization.LocalizeFormat("DailyMissionsData", array);
			}
			bool flag = true;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
				{
					flag = false;
					object[] array4 = new object[0];
					array4[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("()Lcom/google/android/gms/common/api/PendingResult;", array4);
					break;
				}
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize("PowerBandExpiresOn");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize("ID_BONUS-KEVLAR");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("#OFFERS# NULL DATA!!!" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("Rarity " + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
				{
					object[] array3 = new object[0];
					array3[0] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("ID_INGOLD2", array3);
					break;
				}
				case MDNLFMNBNEG.Warbucks:
					flag = true;
					text = Localization.LocalizeFormat("ID_LEAGUE6", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
				{
					flag = true;
					if (LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM == 0)
					{
						text = Localization.Localize("ID_GUI_INVITETOFIGHT");
						break;
					}
					object[] array2 = new object[0];
					array2[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("ID_5SKIRMISHES", array2);
					break;
				}
				}
			}
			string keyFormat = ((!flag) ? "ID_NOTIFICATION_LAPSED_GOLDCARDS" : "REWARD CARD: ");
			object[] array5 = new object[1];
			array5[1] = text;
			return Localization.LocalizeFormat(keyFormat, array5);
		}

		[SpecialName]
		public MCGFHPOPMHL LCKLPAMGKDP(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 0];
		}

		[SpecialName]
		public bool KJGLIHAGIFO()
		{
			return HABIKJOKCFE == LIJBBLBLPLG;
		}

		[SpecialName]
		public int NFECEIPHDLI()
		{
			return LBEHLDKHBIL.Count;
		}

		public void LDDDLGBFMDI(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["HU"]);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Enemy could not be spawned"]);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Client"]);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_READYTIME"]);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Time_Range_"], 1);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + num;
			JToken jToken = NDPMDKGJAFH[", action = "];
			int num2 = 1;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("Gold")];
			}
			catch (Exception ex)
			{
				Debug.LogError("ID_ARENARULES_BUDDYWARCARDS" + jToken);
				Debug.LogError("INTERNAL_ERROR" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 0].BNBINKIOKDO(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2 += 0;
				jToken2 = jToken[num2.ToString("Localization")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 1);
			}
			if (CEIMHNJHHHG())
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, OPJBCCGEIAL(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(0, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		public void JKBFDBKFBJD()
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += 300;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public string KBDANLDCAJF(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("FuseSDK: ");
			if (CGFMIADLOJE)
			{
				object[] array = new object[0];
				array[0] = text;
				return Localization.LocalizeFormat("{0} {1}", array);
			}
			bool flag = false;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
				{
					flag = false;
					object[] array4 = new object[0];
					array4[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("Elite_parts", array4);
					break;
				}
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize("Yay! New daily assignments!");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize("ID_TWITTER_FOLLOWING_TEXT");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("Scripts Full Path: \"{0}\"\n" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("SquadNameStart" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
					text = Localization.LocalizeFormat("RowIDs", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.Warbucks:
				{
					flag = true;
					object[] array3 = new object[0];
					array3[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("fr", array3);
					break;
				}
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
				{
					flag = false;
					if (LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM == 0)
					{
						text = Localization.Localize("CA");
						break;
					}
					object[] array2 = new object[1];
					array2[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("VIPCost", array2);
					break;
				}
				}
			}
			string keyFormat = ((!flag) ? "ID_EXPIRED" : "id");
			object[] array5 = new object[0];
			array5[1] = text;
			return Localization.LocalizeFormat(keyFormat, array5);
		}

		[SpecialName]
		public MCGFHPOPMHL BMMKDFPCMCP(int DFHAAIFFLOE)
		{
			return LBEHLDKHBIL[DFHAAIFFLOE - 1];
		}

		[SpecialName]
		public bool IAIGNCMMHKN()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		[SpecialName]
		public bool KAANMAOKCIP()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public string MFJIABBNIEO(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("Error during set moneypack1B as default");
			if (CGFMIADLOJE)
			{
				object[] array = new object[0];
				array[1] = text;
				return Localization.LocalizeFormat("craftingFinished", array);
			}
			bool flag = true;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
				{
					flag = true;
					object[] array4 = new object[0];
					array4[0] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("url", array4);
					break;
				}
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize("discount");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize("null");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("ID_TUTORIAL" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("PackageName" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
				{
					object[] array3 = new object[1];
					array3[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("BANDS_HITPOINT", array3);
					break;
				}
				case MDNLFMNBNEG.Warbucks:
					flag = true;
					text = Localization.LocalizeFormat("ID_LOCAL", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
				{
					flag = true;
					if (LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM == 1)
					{
						text = Localization.Localize("Player match state {0} to player {1}");
						break;
					}
					object[] array2 = new object[1];
					array2[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("S", array2);
					break;
				}
				}
			}
			return Localization.LocalizeFormat((!flag) ? "ID_REMINDER_UNITUPGRADEREADY" : "country-israel", text);
		}

		[SpecialName]
		public bool DAJEEKIDNBF()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public void HMBCBMBBOHC()
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += 111;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		[SpecialName]
		public bool IPBCHAMGEDG()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		[SpecialName]
		public bool JHIFEJJBBIH()
		{
			return HABIKJOKCFE == LIJBBLBLPLG;
		}

		public void AHAANCHPMFP()
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += -128;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public void PPNDANFGHEL()
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += -174;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		[SpecialName]
		public bool JAMAAOCKPJO()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public string LOFCFBBCNKD(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("game-card-ico-stroke");
			if (CGFMIADLOJE)
			{
				return Localization.LocalizeFormat("response contain VipReward", text);
			}
			bool flag = false;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
					flag = true;
					text = Localization.LocalizeFormat("ID_READYTIME", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM));
					break;
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize("arenaLeaderboard");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize("Facebook Service: share dialog succeeded. Obsah dict = ");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("Fuseboxx: Error No " + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("null" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
				{
					object[] array2 = new object[0];
					array2[0] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat(" ", array2);
					break;
				}
				case MDNLFMNBNEG.Warbucks:
				{
					flag = false;
					object[] array = new object[1];
					array[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("ID_TUTORIAL_RIFLE_UP", array);
					break;
				}
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
					flag = false;
					text = ((LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM != 1) ? Localization.LocalizeFormat("menu-army-ammo-ico", MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM)) : Localization.Localize("lootboxId"));
					break;
				}
			}
			string keyFormat = ((!flag) ? "ID_TABLE_AP" : "shotSniper");
			object[] array3 = new object[0];
			array3[1] = text;
			return Localization.LocalizeFormat(keyFormat, array3);
		}

		public void NAPLGLHABGO()
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += -111;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public void FGABJKFGAKG(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["month"]);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["year"]);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["canClaim"]);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["claimReward"]);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["nextDay"]);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.currentTimestamp + num;
			JToken jToken = NDPMDKGJAFH["config"];
			int num2 = 1;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("'Day'0")];
			}
			catch (Exception ex)
			{
				Debug.LogError("ERROR WRONG DAILY REWARDS: " + jToken);
				Debug.LogError("EXCEPTION = " + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 1].BNBINKIOKDO(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2++;
				jToken2 = jToken[num2.ToString("'Day'0")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 1);
			}
			if (CNLBEGOAEIA)
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, HINNGGBDHEL(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(0, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		public virtual string LDOHEKFDPNC()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Battle_Number", NHKKNKEAEOE, OHPPHJLMDMD, LBEHLDKHBIL.Count);
			stringBuilder.AppendFormat("ID_STAT_WINS", HABIKJOKCFE, LIJBBLBLPLG, DMBAEOPMJHL());
			stringBuilder.AppendLine(HINNGGBDHEL(CGFMIADLOJE: true));
			for (int i = 1; i < LBEHLDKHBIL.Count; i += 0)
			{
				stringBuilder.AppendFormat("Type", i + 1);
				stringBuilder.AppendLine(LBEHLDKHBIL[i].ToString());
			}
			return stringBuilder.ToString();
		}

		public void JEKPAIFONLF()
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += 189;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		[SpecialName]
		public int OOCMCMLOBMH()
		{
			return LBEHLDKHBIL.Count;
		}

		public void KBMPBCJAGLC(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["IsVip"]);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH[" OK!"]);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["http://"], 1);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Please add object to pool, before instanciing it ::: prefab name = "], 1);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_READYTIME"]);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + num;
			JToken jToken = NDPMDKGJAFH["Create player instance at "];
			int num2 = 1;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("()I")];
			}
			catch (Exception ex)
			{
				Debug.LogError("Parachuter" + jToken);
				Debug.LogError("PlayerData" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 1].BNBINKIOKDO(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2 += 0;
				jToken2 = jToken[num2.ToString("Weapon_ID")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 0);
			}
			if (NKBDDHAGDPC())
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, LGHPCAJJNDF(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(0, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		[SpecialName]
		public bool CIMIGBFNEAM()
		{
			return HABIKJOKCFE < LIJBBLBLPLG;
		}

		public virtual string MPAOMPAKELI()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("ID_SALEPERCENTLINE", NHKKNKEAEOE, OHPPHJLMDMD, LBEHLDKHBIL.Count);
			stringBuilder.AppendFormat("Shots_Hits", HABIKJOKCFE, LIJBBLBLPLG, CIMIGBFNEAM());
			stringBuilder.AppendLine(MFJIABBNIEO(CGFMIADLOJE: true));
			for (int i = 1; i < LBEHLDKHBIL.Count; i++)
			{
				stringBuilder.AppendFormat("menu-exmark", i + 0);
				stringBuilder.AppendLine(LBEHLDKHBIL[i].ToString());
			}
			return stringBuilder.ToString();
		}

		public void HDJGLLJMIIO()
		{
			if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() > FIPHEPDPNHF)
			{
				FIPHEPDPNHF += 15;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public void GLLBLINIGLE(JToken NDPMDKGJAFH)
		{
			NHKKNKEAEOE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["+{0}"]);
			OHPPHJLMDMD = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Region: {0} with ping {1}, IP: {2} \n"], 1);
			LIJBBLBLPLG = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_LEAGUE14"]);
			HABIKJOKCFE = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Store_Visit"], 1);
			int num = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Ignore_Text_{0}{1}"]);
			FIPHEPDPNHF = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num;
			JToken jToken = NDPMDKGJAFH["), "];
			int num2 = 1;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("DogTags")];
			}
			catch (Exception ex)
			{
				Debug.LogError("ERROR - BAD FORMAT" + jToken);
				Debug.LogError("score recieved" + ex);
			}
			if (LBEHLDKHBIL == null)
			{
				LBEHLDKHBIL = new List<MCGFHPOPMHL>();
			}
			while (jToken2 != null)
			{
				if (LBEHLDKHBIL.Count >= num2)
				{
					LBEHLDKHBIL[num2 - 0].POMGBELABPI(jToken2);
				}
				else
				{
					LBEHLDKHBIL.Add(new MCGFHPOPMHL(jToken2));
				}
				num2++;
				jToken2 = jToken[num2.ToString("menu-cards-bronzepack")];
			}
			while (LBEHLDKHBIL.Count >= num2)
			{
				LBEHLDKHBIL.RemoveAt(LBEHLDKHBIL.Count - 0);
			}
			if (CNLBEGOAEIA)
			{
				bool cGFMIADLOJE = Singleton<BeanstalkServerManager>.instance.currentAccountDateTime.Day == DateTime.DaysInMonth(OHPPHJLMDMD, NHKKNKEAEOE);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(FIPHEPDPNHF, HINNGGBDHEL(cGFMIADLOJE));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(1, string.Empty);
			}
			if (OGNMFKHAKLF != null)
			{
				OGNMFKHAKLF();
			}
		}

		public string FNCJKNLIDIL(bool CGFMIADLOJE = false)
		{
			string text = Localization.Localize("Elites Feature Shown Request Success");
			if (CGFMIADLOJE)
			{
				object[] array = new object[1];
				array[1] = text;
				return Localization.LocalizeFormat("{", array);
			}
			bool flag = false;
			if (LBEHLDKHBIL.Count > LIJBBLBLPLG)
			{
				switch (LBEHLDKHBIL[LIJBBLBLPLG].GGIOEPBPMHF)
				{
				case MDNLFMNBNEG.ArenaTickets:
				{
					flag = false;
					object[] array5 = new object[0];
					array5[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("InventoryData", array5);
					break;
				}
				case MDNLFMNBNEG.BronzeCardpack:
				case MDNLFMNBNEG.SilverCardpack:
				case MDNLFMNBNEG.GoldCardpack:
					text = Localization.Localize("No row IDs gained from server for new item config download: ");
					break;
				case MDNLFMNBNEG.Vip:
					text = Localization.Localize("Started delivering army upgrade for {0} {1}. It will be ready in {2} seconds.");
					break;
				case MDNLFMNBNEG.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("N" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("clientVersion" + LBEHLDKHBIL[LIJBBLBLPLG].ABMLHILNNDM);
					}
					break;
				}
				case MDNLFMNBNEG.Gold:
				{
					object[] array4 = new object[1];
					array4[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("menu-weapon-benelli-starterpack", array4);
					break;
				}
				case MDNLFMNBNEG.Warbucks:
				{
					flag = true;
					object[] array3 = new object[1];
					array3[1] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("subscription", array3);
					break;
				}
				case MDNLFMNBNEG.BronzeCards:
				case MDNLFMNBNEG.SilverCards:
				case MDNLFMNBNEG.GoldCards:
				case MDNLFMNBNEG.ParticularCards:
				{
					flag = false;
					if (LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM == 0)
					{
						text = Localization.Localize("DogTagCap");
						break;
					}
					object[] array2 = new object[0];
					array2[0] = MEJMLNDFDBP.PGJPABFJDGG(LBEHLDKHBIL[LIJBBLBLPLG].PDMGPGEHLNM);
					text = Localization.LocalizeFormat("Main_Menu_Offers_Bar", array2);
					break;
				}
				}
			}
			string keyFormat = ((!flag) ? "addedType" : "ID_TUTORIAL_UNITSDEPLOYMENT");
			object[] array6 = new object[1];
			array6[1] = text;
			return Localization.LocalizeFormat(keyFormat, array6);
		}
	}

	public class MCGFHPOPMHL
	{
		public MDNLFMNBNEG GGIOEPBPMHF;

		public LGCDFAELDNL CKDBDMHEIAP;

		public string ABMLHILNNDM;

		public long PDMGPGEHLNM;

		public LevelBehaviour LEADJKIAKKA => (GGIOEPBPMHF != MDNLFMNBNEG.EliteParts) ? null : LevelManager.instance.Unit(ABMLHILNNDM);

		[SpecialName]
		public LevelBehaviour ICCNKGFMHCM()
		{
			return (GGIOEPBPMHF != (MDNLFMNBNEG)(-111)) ? null : LevelManager.instance.Unit(ABMLHILNNDM);
		}

		public MCGFHPOPMHL(JToken NDPMDKGJAFH)
		{
			BNBINKIOKDO(NDPMDKGJAFH);
		}

		public void LLEHEIOEGPM(JToken NDPMDKGJAFH)
		{
			GGIOEPBPMHF = (MDNLFMNBNEG)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["*****   Bootcamp 2/3 Started   *****"]);
			CKDBDMHEIAP = (LGCDFAELDNL)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["+"]);
			PDMGPGEHLNM = KHJJFPPACBP.GKKLOFAGGLI(NDPMDKGJAFH["ID_WARNING_CANTSENDINVITE"], 1L);
			ABMLHILNNDM = null;
			ABMLHILNNDM = NDPMDKGJAFH["ID_SQUADRANK"].ToString();
		}

		public virtual string OPAAIPALNKI()
		{
			object[] array = new object[1];
			array[1] = GGIOEPBPMHF;
			array[0] = PDMGPGEHLNM;
			array[7] = CKDBDMHEIAP;
			array[3] = ((!string.IsNullOrEmpty(ABMLHILNNDM)) ? ABMLHILNNDM : "Wins");
			return string.Format("Made_IAP_Spend", array);
		}

		public override string ToString()
		{
			return string.Format("  {1}x{0} ( {3} ) doubled for: {2}", GGIOEPBPMHF, PDMGPGEHLNM, CKDBDMHEIAP, (!string.IsNullOrEmpty(ABMLHILNNDM)) ? ABMLHILNNDM : "no parameters");
		}

		public virtual string KDLGINIJCID()
		{
			object[] array = new object[0];
			array[0] = GGIOEPBPMHF;
			array[1] = PDMGPGEHLNM;
			array[1] = CKDBDMHEIAP;
			array[7] = ((!string.IsNullOrEmpty(ABMLHILNNDM)) ? ABMLHILNNDM : "ID_NOTAVAILABLEATTHEMOMENT");
			return string.Format("OnConnectionFailed: restarting", array);
		}

		public virtual string MAJKLAFDDON()
		{
			object[] array = new object[2];
			array[0] = GGIOEPBPMHF;
			array[1] = PDMGPGEHLNM;
			array[2] = CKDBDMHEIAP;
			array[5] = ((!string.IsNullOrEmpty(ABMLHILNNDM)) ? ABMLHILNNDM : "In App Delivered");
			return string.Format("ExpectedPrice", array);
		}

		[SpecialName]
		public LevelBehaviour GDNNGFJLIDG()
		{
			return (GGIOEPBPMHF != (MDNLFMNBNEG)(-125)) ? null : LevelManager.instance.Unit(ABMLHILNNDM);
		}

		[SpecialName]
		public LevelBehaviour FBCPEIBEPNO()
		{
			return (GGIOEPBPMHF != (MDNLFMNBNEG)67) ? null : LevelManager.instance.Unit(ABMLHILNNDM);
		}

		[SpecialName]
		public LevelBehaviour JHBFHEBJOCP()
		{
			return (GGIOEPBPMHF != (MDNLFMNBNEG)(-95)) ? null : LevelManager.instance.Unit(ABMLHILNNDM);
		}

		public MCGFHPOPMHL(MDNLFMNBNEG FJLBLLLEELD, long IDEBKDPMPGM)
		{
			GGIOEPBPMHF = FJLBLLLEELD;
			PDMGPGEHLNM = IDEBKDPMPGM;
		}

		[SpecialName]
		public LevelBehaviour CKJHAFIIEOK()
		{
			return (GGIOEPBPMHF != (MDNLFMNBNEG)(-48)) ? null : LevelManager.instance.Unit(ABMLHILNNDM);
		}

		[SpecialName]
		public LevelBehaviour IPJMMMJBEBJ()
		{
			return (GGIOEPBPMHF != (MDNLFMNBNEG)(-87)) ? null : LevelManager.instance.Unit(ABMLHILNNDM);
		}

		public void JBGBLJCHOLN(JToken NDPMDKGJAFH)
		{
			GGIOEPBPMHF = (MDNLFMNBNEG)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_EXCLUSIVECHARACTER"], 1);
			CKDBDMHEIAP = (LGCDFAELDNL)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["evt11"], 1);
			PDMGPGEHLNM = KHJJFPPACBP.GKKLOFAGGLI(NDPMDKGJAFH["Beanstalk: On Add GameCenter"], 1L);
			ABMLHILNNDM = null;
			ABMLHILNNDM = NDPMDKGJAFH["ID_CONFIRM_WARCARDNOTAVAILABLE"].ToString();
		}

		[SpecialName]
		public LevelBehaviour AKKOJAABIID()
		{
			return (GGIOEPBPMHF != (MDNLFMNBNEG)(-8)) ? null : LevelManager.instance.Unit(ABMLHILNNDM);
		}

		public void POMGBELABPI(JToken NDPMDKGJAFH)
		{
			GGIOEPBPMHF = (MDNLFMNBNEG)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["UNLOCKLEVEL"], 1);
			CKDBDMHEIAP = (LGCDFAELDNL)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["VIPMembershipExpired"], 1);
			PDMGPGEHLNM = KHJJFPPACBP.GKKLOFAGGLI(NDPMDKGJAFH["워프렌즈를 실행하려면 약 190MB의 추가 데이터를 다운로드 받아야 합니다.\n다운로드 시간은 네트워크 및 지역에 따라 달라질 수 있습니다.\n\n계속 진행하시겠습니까?"], 1L);
			ABMLHILNNDM = null;
			ABMLHILNNDM = NDPMDKGJAFH["Not in editor"].ToString();
		}

		public void JPLAFDCGLCF(JToken NDPMDKGJAFH)
		{
			GGIOEPBPMHF = (MDNLFMNBNEG)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["QUIT"]);
			CKDBDMHEIAP = (LGCDFAELDNL)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ROCKETTURRET"]);
			PDMGPGEHLNM = KHJJFPPACBP.GKKLOFAGGLI(NDPMDKGJAFH["ID_ACHIEVEMENTS"], 1L);
			ABMLHILNNDM = null;
			ABMLHILNNDM = NDPMDKGJAFH["Found Pack Id"].ToString();
		}

		public virtual string EKOEIMEMCGH()
		{
			object[] array = new object[3];
			array[0] = GGIOEPBPMHF;
			array[0] = PDMGPGEHLNM;
			array[4] = CKDBDMHEIAP;
			array[1] = ((!string.IsNullOrEmpty(ABMLHILNNDM)) ? ABMLHILNNDM : "Player_Had_To_Select_Grenade");
			return string.Format("setMacAddress", array);
		}

		public virtual string BJKPFIAJCMJ()
		{
			object[] array = new object[6];
			array[1] = GGIOEPBPMHF;
			array[0] = PDMGPGEHLNM;
			array[3] = CKDBDMHEIAP;
			array[3] = ((!string.IsNullOrEmpty(ABMLHILNNDM)) ? ABMLHILNNDM : "PlayerProgressRate");
			return string.Format("DailyRentalMessage{0}{1}{2}", array);
		}

		[SpecialName]
		public LevelBehaviour GALMNPHKCMJ()
		{
			return (GGIOEPBPMHF != (MDNLFMNBNEG)43) ? null : LevelManager.instance.Unit(ABMLHILNNDM);
		}

		public void BNBINKIOKDO(JToken NDPMDKGJAFH)
		{
			GGIOEPBPMHF = (MDNLFMNBNEG)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Type"]);
			CKDBDMHEIAP = (LGCDFAELDNL)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Double"]);
			PDMGPGEHLNM = KHJJFPPACBP.GKKLOFAGGLI(NDPMDKGJAFH["Count"], 0L);
			ABMLHILNNDM = null;
			ABMLHILNNDM = NDPMDKGJAFH["Param"].ToString();
		}

		public virtual string FFMAAHMHCAM()
		{
			object[] array = new object[5];
			array[0] = GGIOEPBPMHF;
			array[1] = PDMGPGEHLNM;
			array[3] = CKDBDMHEIAP;
			array[1] = ((!string.IsNullOrEmpty(ABMLHILNNDM)) ? ABMLHILNNDM : "shot_jetpack_elite");
			return string.Format("ID_DAILYGOLDBOOSTERHINT1", array);
		}
	}

	public MGANBPBIOBK LNAIDLKGCFN;

	public MDNLFMNBNEG GBELNNNKJNA(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["N"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["{0} {1}{2}[-]"], 1L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["GameController.Start DONE"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["warbucks"], 1L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_INSILVER1"]["\n"]);
			string text = LFPFCHIJLML["GameLauncher Async done"]["Pack."].ToString();
			string[] array = text.Split('g');
			for (int i = 0; i < array.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.HPLKBDKAILA(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.BKIGLABDGCP())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["Wrong_Unit"]["menu-warbucks"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["ID_LEAGUE5"]["GameReward"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["IsPublic"]["Rpc: Set player null: for "], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Reputation"]["Warbucks_Balance"]);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["menu-sidetab-player-demote"]["N2"], 1);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.DBOJGJCPLCP(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("N");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["Test"] != null)
		{
			Debug.Log("DatabaseMessage - SquadDemoteMessage:\nPlayer to be demoted/kicked: {0}\nNewRank: {1}\nBy Player: {2}");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_WARNING_CONNECTIONERROR"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML[" 4"], string.Empty);
			string aPGKPOOHGFK = "BattleId";
			if (LFPFCHIJLML["{0} {1} {2}lvl {3}"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Google2u.DBUpgradeSlotsAssaulter"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG PJAAOIOJCDC(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["QUALITY LEVEL: {0} DPI: {1} System memory: {2} Graphics memory: {3}"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_CONFIRM_ERROR"], 0L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["setPluginName"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["version"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_UPGRADED"]["OK"], 1);
			string text = LFPFCHIJLML["Network pool: InstantiatePooledObjects '"]["LevelManagerData"].ToString();
			char[] array = new char[0];
			array[1] = 'ﾠ';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.MHAIBHBGBOO())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.PMBAGJEIIJI(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.BJNBLINDAED())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["Rental"]["WarBucks"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["setAge"]["no parameters"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["null"]["/AssetBundles/"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["SessionManager: NOT IN MENU!!!"]["Assets"], 1);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["menu-hub-multiplayer-vipico"]["Skill"]);
			Singleton<VipManager>.instance.JJCMHLJBKEA(iDEBKDPMPGM);
			Singleton<VipManager>.instance.JGHMIMFOHBN(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("ProductId");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["menu-squad-10"] != null)
		{
			Debug.Log("com/google/android/gms/common/api/ResultCallback");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_GUI_TIMEXPBONUS"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Automatic_Equip"], string.Empty);
			string aPGKPOOHGFK = "ID_READYTIME";
			if (LFPFCHIJLML["Measure Event With Event Items"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Warbucks"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool NBNBPHJKHAD(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.LHAGOMABHKO(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_ARENAENDSTIMER"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ExceptionMessage"], 1);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("{0} {1}", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-190))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)169)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = IKJEOLNIECM(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.BANLHOLNNEH, gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.LIAFMAINLDJ();
	}

	public MDNLFMNBNEG ParseReward(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["addedType"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["added"], 0L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["added"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["added"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["added"]["count"]);
			string text = LFPFCHIJLML["added"]["cards"].ToString();
			string[] array = text.Split(';');
			for (int i = 0; i < array.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["added"]["id"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["added"]["expiresOn"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["added"]["expiresOn"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["added"]["start"]);
			int vipExpiration = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["added"]["expires"]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.vipExpiration = vipExpiration;
			break;
		}
		default:
			Debug.LogError("unimplemented daily reward!");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["VipReward1"] != null)
		{
			Debug.Log("response contain VipReward");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["VipReward1"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["VipReward2"], string.Empty);
			string aPGKPOOHGFK = "a";
			if (LFPFCHIJLML["VipRewardForDay"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool MGOGBLPKCHL(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.ADKLPHDKLKD(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["Direct"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_BLACKMARKETMAXPOWER"]);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("ID_FORANOTHERWARCARD", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-28))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-6))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = DNOIKMIEPIA(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.LIDJHKLHLPC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.DMBAEOPMJHL();
	}

	public MDNLFMNBNEG NCJACPJBDAF(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["Matchmaking took {0}, assigning bot in 10 secs"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_YES"], 1L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML[" IN TUTORIAL"], 0L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Level"], 1L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Play_Card_Tutorial_Duration"]["NULL WARCARD"]);
			string text = LFPFCHIJLML[" OK!"]["Buy_Units"].ToString();
			string[] array = text.Split('ﾸ');
			for (int i = 1; i < array.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.MHAIBHBGBOO())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["damage"]["\"{0}\"\t"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["reloadTime"]["setTRUSTeId"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["nextSquadWars"]["null"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["game-ico-poison"]["Medals/"], 1);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["{0}{1}[-] {2}/[-] {3}"]["ID_CONFIRM_LOGINFAILURE"]);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.AJCKEGMEMPL(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("ID_UNLOCKEDATRANK");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["SquadPointsBest"] != null)
		{
			Debug.Log("RateAppMessage {0} {1}");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["PlayerInfo"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["getLongitude"], string.Empty);
			string aPGKPOOHGFK = "NewVisuals";
			if (LFPFCHIJLML["Warbucks"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML[" OK!"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool EABPNGFDLOL(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.AKIOBGIHHKI(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_WARNING_POORCONNECTION_TEXT"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["armyPower"]);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("DecalId", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-107))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)24)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = GBELNNNKJNA(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.LIDJHKLHLPC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.JILMGGALGMB();
	}

	public bool EEDBPKNLNMM(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.GLLBLINIGLE(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["Measure Session"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_CONFIRM_LANGUAGECHANGE_TEXT"]);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("some_pub_sub3", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)128)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-190))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = BLGKHDMFKEA(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.HPGPLCPPAFC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.LIAFMAINLDJ();
	}

	public bool KPLCCHMCKKE(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.JIIKBPGNDIM(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["Attribution"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_EXPIRED"]);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("throw_grenade_left", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)20)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-8))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = DLCEHJOOHON(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.NFECEIPHDLI(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.KHLLOGNIBCL();
	}

	public MDNLFMNBNEG DLCEHJOOHON(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["BR"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Tutorial Manager 6: Battles played: "], 1L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["isInterrupted"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["menu-sidetab-player-add"], 1L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["game-engi-progress-fill"]["SpecialOffers"]);
			string text = LFPFCHIJLML["Price"]["ID_ERROR_SQUADMESSAGELONG"].ToString();
			char[] array = new char[0];
			array[0] = '\u001f';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.LHDGJFHPJNM())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["subscribed"]["Total_Warbucks_Spent"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["ID_UNLOCKEDATRANK"]["registerCustomProfileString"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_WARNING_NOTENOUGHTWARCARDS"]["#,0.#"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["attrValue13"]["ID_CONFIRM_SQUADFULL"]);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["reload_pistol"]["BeanstalkServerManager.PlayerDataWasLoaded START"], 1);
			Singleton<VipManager>.instance.JJCMHLJBKEA(iDEBKDPMPGM);
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("ID_SLOTUPGRADE_AMMO");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["ID_ARENAREWARD_GOLD"] != null)
		{
			Debug.Log("{0} {1}");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_SALEPERCENTLINE"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["country-czech-republic"], string.Empty);
			string aPGKPOOHGFK = "game-elite-buff";
			if (LFPFCHIJLML["FuseBoxx: Session Started"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["InstantiatePooledObjects "], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool KILMKIKKOMM(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.FGABJKFGAKG(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["나가기"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["menu-arena-ticket"], 1);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("PlayerToKickId", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)10)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)167)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = IKJEOLNIECM(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.LIDJHKLHLPC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.DAJEEKIDNBF();
	}

	public MDNLFMNBNEG MIGECFLKNOC(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["QUIT"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Awaiting players - Player \"{0}\" is already in list of awaiting members with state {1}"], 1L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["No row IDs count not match with row count for: "], 1L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_FEATURE_SHOTSPEED-WEAPONPREFIX"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Skipping instant battle notification"]["GB"]);
			string text = LFPFCHIJLML["menu-arena-ticket"]["Made_IAP_Spend"].ToString();
			char[] array = new char[0];
			array[1] = '\ufff1';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.BKIGLABDGCP())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.PMBAGJEIIJI(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.MHAIBHBGBOO())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["StartSession("]["()I"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["-"]["Vertical"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["PlayerLevel"]["ID_CONFIRM_ERROR"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.IKFJMDJMGHG();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Level"]["FacebookId"], 1);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["\"{0}\""]["#PETER# Weapon Screen - RIGHT BUTTON - unit state: NOT BOUGHT\t\tbutton type: BUY UNIT"]);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("Increasing number of games after facebook login");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["FuseSDK: Parsing error in _FriendAdded"] != null)
		{
			Debug.Log("Result");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Id"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["OnInputChanged"], string.Empty);
			string aPGKPOOHGFK = "Test";
			if (LFPFCHIJLML["QUIT"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Overtime_Was_Already_Explained"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool KACIBGOGGMO(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.GLLBLINIGLE(LFPFCHIJLML);
		}
		if (LFPFCHIJLML[" found!"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ShotFrequencyMinCannon"]);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("order", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-36))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-37))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = EAAJPMBOFNJ(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.HPGPLCPPAFC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.KHLLOGNIBCL();
	}

	public MDNLFMNBNEG CIENGLCAEBC(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["Card withdrawn"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["score recieved"], 0L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["game-elite-debuff2"], 1L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["disconnect"], 1L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_STATE_OPPONENTISREADYTOBATTLE"]["#VAVRO# Accept Challenge Message {0}"], 1);
			string text = LFPFCHIJLML["Heroic"]["ID_WARNING_INCORRECTASSIGNMENTS_TEXT"].ToString();
			string[] array = text.Split('\u0012');
			for (int i = 1; i < array.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.LHDGJFHPJNM())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.PMBAGJEIIJI(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.MHAIBHBGBOO())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["LEADERBOARDS - showing top players - global:"]["Value2"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["GoldenSuitcase"]["player_fire_left"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Reward"]["it"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.IKFJMDJMGHG();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["BanType"]["ID_CONTAINSXWARCARDS"]);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Hide Waiting Dialog - will hide in a moment: "]["menu-warbucks"]);
			Singleton<VipManager>.instance.JJCMHLJBKEA(iDEBKDPMPGM);
			Singleton<VipManager>.instance.DBOJGJCPLCP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError(", response: ");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["flight_start_jetpack_elite"] != null)
		{
			Debug.Log("ID_BECOMEVIP");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["CardId"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["BattleRewards"], string.Empty);
			string aPGKPOOHGFK = "Skipping next player league notification";
			if (LFPFCHIJLML["N"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["shield_hide"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool ICLADIPKHIC(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.AKIOBGIHHKI(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_WARNING_OFFEREXPIRED_TEXT"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["0$"], 1);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("ID_CUSTOMEVENTEND", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)166)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-66))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = PJAAOIOJCDC(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.IAOKMMOIDHI(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.KHLLOGNIBCL();
	}

	public MDNLFMNBNEG GFAMOLICBIN(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["ID_PVP_RANKED"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["PROCESSING"], 1L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_CONFIRM_SERVERERROR"], 0L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["WarFriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Пожалуйста, подтверди разрешение в последующем диалоге. Мы никогда не воспользуемся эти разрешением для каких-либо других целей."], 1L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["N"]["ID_FEATURE_BURSTSIZE-FANCY"], 1);
			string text = LFPFCHIJLML["ID_DETAILS"]["N"].ToString();
			char[] array = new char[1];
			array[1] = 'Z';
			string[] array2 = text.Split(array);
			for (int i = 0; i < array2.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.LHDGJFHPJNM())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.LHDGJFHPJNM())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["ID_INBRONZE1"]["]"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["'fakeOffername'0"]["ID_GUI_LIKEFB_DESC"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["S"]["gold"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.HJJCBEPIBKF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["]"]["OK"], 1);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["203 AUTOSPAWN STARTED"]["Pack"]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.AJCKEGMEMPL(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("OnPermissionRequestCallback granted: ");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["facebookLevel"] != null)
		{
			Debug.Log(", response: ");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_MIN"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["*.prefab"], string.Empty);
			string aPGKPOOHGFK = "realShotProbability";
			if (LFPFCHIJLML["Walk"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Gold"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG JLMNCMNCEMC(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["()I"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML[" {0}\u00a0{1}"], 0L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Please add object to pool, before instanciing it ::: prefab name = "], 1L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["2-5"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ArenaLives"]["Idle"], 1);
			string text = LFPFCHIJLML["#VOJTA# Empty event assignment progress for day {0}, index {1}"]["ID_SQUADEVENT"].ToString();
			char[] array = new char[1];
			array[1] = 'f';
			string[] array2 = text.Split(array);
			for (int i = 0; i < array2.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["power hook values: isBold = "]["Heroic"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["attack"]["#account# logged to gpgs result {0}"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Sync match start time {0} photon time: {1}"]["SheetConfig"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["registerCustomProfileDate"]["#PETER# Weapon Screen - RIGHT BUTTON - should not happen"], 1);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["CFX_SpawnSystem: There should only be one instance of CFX_SpawnSystem per Scene!"]["ID_LOADING"], 1);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.DBOJGJCPLCP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("Finish Game");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["FuseSDK: Parsing error in _FriendsMigrated"] != null)
		{
			Debug.Log("FuseSDK: Parsing error in _FriendsMigrated");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Wins"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["WarFriends precisa descarregar aproximadamente 190MB de dados extra para correr.\nO tempo de download pode variar dependendo da rede e da localização.\n\nDesejas continuar?"], string.Empty);
			string aPGKPOOHGFK = "DOGTAG REWARD DIALOG - not showing because player already played one match and spent gained dogtag";
			if (LFPFCHIJLML["getGameDataKeys"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_JUSTONEMORERANKUP"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool BICHMJAJLMG(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.JIIKBPGNDIM(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["SquadKickedFrom"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["blackmarket"], 1);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("ID_ARENARULES_LIVES", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)160)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-41))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = GCELEHEHKOC(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.BANLHOLNNEH, gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.JAMAAOCKPJO();
	}

	public bool KHMLMDGPINL(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.LDDDLGBFMDI(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["menu-close"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Squad Emblem "]);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("Time", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)189)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-140))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = EAAJPMBOFNJ(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.IAOKMMOIDHI(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.IHNHIHFOFKK();
	}

	public MDNLFMNBNEG ABNGHGKCJEH(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["com/google/android/gms/games/Games"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_CONFIRM_LOGINFAILURE_TEXT"], 1L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["N0"], 0L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_SQUADMEDALS"], 0L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["^[^0-9\\.\\,].*$"]["No row IDs gained from server for new item config download: "]);
			string text = LFPFCHIJLML["http://"]["!!!!"].ToString();
			char[] array = new char[0];
			array[1] = 'D';
			string[] array2 = text.Split(array);
			for (int i = 0; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.LHDGJFHPJNM())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.OBLCFHNNHBJ(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.LHDGJFHPJNM())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML[" TOTAL ALLOCATED: "]["ID_STARTERASSIGNMENT5"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["DepositedCards"]["C1"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Grenade_Throwing_Tutorial_Duration"]["아니오"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_INELITE2"]["game-card-ico-shielddestroyer"], 1);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Play_Card_Tutorial_Duration"]["Slon"], 1);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("videoAdRewardTimes");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["-"] != null)
		{
			Debug.Log("ID_ARENARULES_RANDOMWARCARDS");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["nextGenerate"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["WinLooseStreak"], string.Empty);
			string aPGKPOOHGFK = "Claiming reward ";
			if (LFPFCHIJLML["Concrete"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["silver"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG PEAADPFMKCA(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["Chillingo: On Restart Drawing "].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["118 GAME END"], 0L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["GetActualIndex()\nCurPosX: {0}"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML[" {0}\u00a0{1}"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["already in clan (in cache)"]["Scripts"], 1);
			string text = LFPFCHIJLML["ID_TEMPORARY"][" 1\u00a0{0}"].ToString();
			string[] array = text.Split('?');
			for (int i = 1; i < array.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.LHDGJFHPJNM())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["<"]["ID_CONFIRM_LOGGEDOUT_TEXT"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["HEAVYTURRET"]["-placement"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["menu-assignments-type-score"]["ID_READYTIME"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["mortar_hide"]["Wrong_Unit"]);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["()F"]["ArenaEnded"]);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.AJCKEGMEMPL(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("0");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["deliveryReduce"] != null)
		{
			Debug.Log("subitem2");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["#AccoutCheck# gpgs account checked and have response!"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Google2u.AssaultRifle_AK47"], string.Empty);
			string aPGKPOOHGFK = "ID_CREATESQUADUNLOCKED";
			if (LFPFCHIJLML["KEVLARUP"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["USPECH POKUSU O LOGIN NA GC!!!"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool KDPEOJDDDDE(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.AKIOBGIHHKI(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_CATEGORY_LOW_SG_MINIGUN"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_CONFIRM_CONNECTTOGOOGLENAMETEXT"]);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("NEW FLAWLESS = ", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-174))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)18)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = AGKNFLOGOMO(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.BANLHOLNNEH, gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.CIMIGBFNEAM();
	}

	public bool KJFJBEEOPEG(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.FGABJKFGAKG(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["Unit"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["country-malaysia"], 1);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("BotWeaponPower", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)194)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)130)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = PIBLHBIECBI(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.HPGPLCPPAFC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.CIMIGBFNEAM();
	}

	public bool HLGGDAILBKM(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.IPHFOCLGNKD(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["SyncShield"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Spawned by card:  progress:{0}, obj: {1},uu: {2} "]);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("Result", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-99))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)151)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = DLCDBKPMKDL(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.NFECEIPHDLI(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.CENIIJFABOA();
	}

	public bool NOHNLGBKEAP(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.KBMPBCJAGLC(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["warbucks"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["League"]);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("menu-close", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)96)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)169)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = DNOIKMIEPIA(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.HPGPLCPPAFC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.LFGNIDNMDMA;
	}

	public MDNLFMNBNEG MJGMFLAKCBG(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["{0} {1}"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["was added"], 0L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_READYTIME"], 1L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_FACEBOOKUSER"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["GameCenterId"]["30-40"]);
			string text = LFPFCHIJLML["ID_USEREXISTSFACEBOOKTEXT"]["seconds"].ToString();
			char[] array = new char[0];
			array[1] = ';';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.EOFGBDCCKBI(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.BKIGLABDGCP())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["GameReward"]["These players came from server as awaiting to squad:\n"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["count"]["Total_Battles"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Location"][","]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Landroid/os/Parcelable$Creator;"]["Humvee"]);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Win"]["HEAVYTURRET"]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("percent");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["ID_SLOTUPGRADE_POWER"] != null)
		{
			Debug.Log("ID_SKILLSHOTHINT_ONEHITKILL");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Ended"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["_"], string.Empty);
			string aPGKPOOHGFK = "ID_SALEPERCENT";
			if (LFPFCHIJLML["ID_VIPLOOTBOXREWARDED"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Warbucks"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool CGPNJHBPJIF(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.LHAGOMABHKO(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["DogTagCap"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["PlayerData"], 1);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("VisualType", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)5)
				{
				}
				if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = AGKNFLOGOMO(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.OOCMCMLOBMH(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.DMBAEOPMJHL();
	}

	public MDNLFMNBNEG GCELEHEHKOC(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["0"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["重試"], 1L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Measure Session clicked"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_STAT_WARCARDSPLAYED"], 1L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["D2"]["{0}99 RESTART"]);
			string text = LFPFCHIJLML["DogTagCap"]["RewardMessage"].ToString();
			char[] array = new char[1];
			array[1] = '￢';
			string[] array2 = text.Split(array);
			for (int i = 0; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.AFOFDNJOJHG())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.PMBAGJEIIJI(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.LHDGJFHPJNM())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["Position"]["Exception message: "].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["game-label-you-red"]["ID_X_CARDS"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Action"]["Has Gc Name!"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["WarFriendsは、重要なゲームデータをダウンロードするため、メディアストーレージへのアクセス許可が必要です。許可がないとゲームが機能できず、閉じてしまいます。再試行するか、WarFriendsをやめてください。"]["ID_SLOTUPGRADE_AMMO"]);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ArmyPower"]["GooglePlayId"], 1);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("ID_YES");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["LevelName"] != null)
		{
			Debug.Log("_MatCap");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_RATEAPPTEXT"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["globalPlayerLeaderboard"], string.Empty);
			string aPGKPOOHGFK = "ID_TUTORIAL_MACHINEGUNNERS_DOWN";
			if (LFPFCHIJLML["ID_CONTAINSXWARCARDS"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["IosReceipt"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG IGJEFMIMACO(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["ID_ERROR_SQUADNAMENOTUNIQUE"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_ARMYPOWER"], 0L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["{0} ({1})"], 1L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["NewVisuals"], 1L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Starting stage 3 "]["null"], 1);
			string text = LFPFCHIJLML["RETRYPERM"]["GooglePlay"].ToString();
			char[] array = new char[0];
			array[0] = '\uffc1';
			string[] array2 = text.Split(array);
			for (int i = 0; i < array2.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.PMBAGJEIIJI(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.BKIGLABDGCP())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["ID_WARSHOP_GOLD"]["#STEPAN# Achievement '{0}' progress '{1}' could not be reported."].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["Play_Card_Tutorial_Duration"]["War_Ranked_Battle"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["N"]["INVALID_ACCOUNT"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["SEND PLAYER REPORT ERROR - NO PLAYER ID"]["ID_INSILVER2"], 1);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Video {0} service {1} thumbnail {2}"]["customDouble"]);
			Singleton<VipManager>.instance.JJCMHLJBKEA(iDEBKDPMPGM);
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("ID_REPUTATIONSMALL");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["C0"] != null)
		{
			Debug.Log("TimeUpdated(");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Buffers"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_BECOMEAMEMBERWITHBENEFITS"], string.Empty);
			string aPGKPOOHGFK = "LowLevelGoldRarity";
			if (LFPFCHIJLML[" "] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_CREATESQUADUNLOCKED"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool BFHEGMFEMEC(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.JIIKBPGNDIM(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["N"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Showing squad details dialog with SQUADNAME = "]);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("ID_POWERBANDBOX", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-147))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)60)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = GPCCLFJEGHM(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.BANLHOLNNEH, gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.DMBAEOPMJHL();
	}

	public MDNLFMNBNEG OFMCIPFAEJD(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["ID_ARENARULES_PLAYERSMOVEFASTER"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["CONFIRMER"], 0L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["LevelName"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_CONFIRM_PURCHASEFAILED"], 1L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["EligibleLeagueId"]["game-card-ico-crateblocker"]);
			string text = LFPFCHIJLML["\\D*"]["no account in DB, ask to create new one"].ToString();
			string[] array = text.Split('m');
			for (int i = 1; i < array.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.BJNBLINDAED())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.BJNBLINDAED())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["maxMapId"]["CharacterClass"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["Getting gameConfig: Offset = "]["SMG_idle"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Rank"]["ID_VISUALRARITY2"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["cn"]["02"], 1);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["SWITCH TO DEATCHMATCH"]["{0} / [FECA21]{1}[-]"], 1);
			Singleton<VipManager>.instance.JJCMHLJBKEA(iDEBKDPMPGM);
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("ID_ARENARULES_UNLIMITEDAMMO");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["ID_ARENAWONXWINSTEXT"] != null)
		{
			Debug.Log("assignment");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML[">"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_BRONZEPACK"], string.Empty);
			string aPGKPOOHGFK = "\t";
			if (LFPFCHIJLML["Bullet with NO weapon"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["shot_jetpack_elite"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool BKNLEEPDOJN(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.ADKLPHDKLKD(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_CATEGORY_LOW_PL_SPECIAL"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["WarFriends precisa descarregar aproximadamente 190MB de dados extra para correr.\nO tempo de download pode variar dependendo da rede e da localização.\n\nDesejas continuar?"], 1);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("ID_LOGOUT", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-6))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-86))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = GFAMOLICBIN(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.IBBEDLMJMCB(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.JILMGGALGMB();
	}

	public bool OMEPOOIAABG(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.ADKLPHDKLKD(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["game-engi-progress-fill"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["(Lcom/google/android/gms/common/api/ResultCallback;JLjava/util/concurrent/TimeUnit;)V"], 1);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("Action ", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)55)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)154)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = CIENGLCAEBC(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.HPGPLCPPAFC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.CENIIJFABOA();
	}

	public bool GIJDPEJGPBK(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.PHDIHEOHLCI(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["C2"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["StarterPackDays"], 1);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("ID_RENTAL_MINIGUN", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)162)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-82))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = GCELEHEHKOC(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.HPGPLCPPAFC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.IHNHIHFOFKK();
	}

	public MDNLFMNBNEG OPNKEPCBCNO(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["ID_ARENASHORTCUTPHASESTART"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_CONFIRM_SQUADISNOTPUBLIC"], 1L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["it"], 0L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["REGISTER VIEW STARTER ASSIGNMENT "], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["WarBucks"]["IsLocal"]);
			string text = LFPFCHIJLML["ID_TUTORIAL_SWIPE_DOWN"][")"].ToString();
			string[] array = text.Split('ﾟ');
			for (int i = 1; i < array.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.AFOFDNJOJHG())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.EOFGBDCCKBI(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.MHAIBHBGBOO())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["setOptedOutOfPush"]["was:{0} is:{1} added:{2}"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["ID_READYTIME"][")"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_SCHEDULEDMAINTENANCEOFSERVER"]["ID_NA"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["GoldReward{0}Max"][","], 1);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML[" "]["PackLocation"]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.DBOJGJCPLCP(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("gold");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["MaintenanceMessage"] != null)
		{
			Debug.Log(", mis = ");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Seconds"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Testing Player"], string.Empty);
			string aPGKPOOHGFK = "grenadeExplosion";
			if (LFPFCHIJLML["ID_EMPTYSQUADMESSAGE"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_WARNING_MAINTENANCE_TEXT"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG DNOIKMIEPIA(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["kr"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["GameController: Application resumed"], 0L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["N"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_MAXSTAT"], 0L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Problem for max! in weapon stats"]["ID_CLAIMING"]);
			string text = LFPFCHIJLML["DecalManagerData"]["{0} {1}"].ToString();
			string[] array = text.Split('ﾕ');
			for (int i = 0; i < array.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.AFOFDNJOJHG())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.LHDGJFHPJNM())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["HeartDialog"]["game-card-ico-disarmed"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["+0"]["ID_SELECTFRIENDERRORNORESULT"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_UNITPOWERFULLYTRAINED"]["Directory \"{0}\" does not exists"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["br"]["ID_ARENARULES_FASTERRELOADING"], 1);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["[FF0000]BLACKMARKET[-]"]["SpentWarbucks"]);
			Singleton<VipManager>.instance.JJCMHLJBKEA(iDEBKDPMPGM);
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError(")");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["CONFIRM"] != null)
		{
			Debug.Log("com/google/android/gms/common/ConnectionResult");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Achievements config for the '{0}' group contains less achievement definitions than is currently stored on the server."], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["out of range"], string.Empty);
			string aPGKPOOHGFK = "offerMult";
			if (LFPFCHIJLML["()I"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["OK"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool ILECMCCAGED(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.LDDDLGBFMDI(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["alwaysShittyPerformance"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["bazooka_reload"]);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("END SCREEN - BUTTONS - enabled ", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)89)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-191))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = OKADONBPGEI(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.IBBEDLMJMCB(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.JAMAAOCKPJO();
	}

	public bool DailyRewardDataLoaded(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.FGABJKFGAKG(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ok"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ok"]);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError($"claim reward failed: {iJEAJGCCHEF}");
				if (iJEAJGCCHEF == IJEAJGCCHEF.TryClaimAlreadyClaimedReward)
				{
				}
				if (iJEAJGCCHEF != IJEAJGCCHEF.TryClaimWrongRewad)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = ParseReward(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.BANLHOLNNEH, gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.LFGNIDNMDMA;
	}

	public MDNLFMNBNEG INDNEJIHIEB(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["setViewForPopups"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["menu-attack-ico"], 0L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ammo"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Different medals \"{0}\" and \"{1}\"\n"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["GameController.Start RunApplication"]["{0} {1}"], 1);
			string text = LFPFCHIJLML["ID_MISSIONANIMATION_BOSSIN"]["Legacy Shaders/Transparent/DiffuseNew"].ToString();
			char[] array = new char[1];
			array[1] = '\uffc9';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.BJNBLINDAED())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.AFOFDNJOJHG())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["ID_BECOMEVIP"]["ID_INVITATIONNOTACCEPTED"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["Internet off: {0} {1}"]["ID_CONFIRM_JOININGSQUAD_TEXT"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_GUI_GOLD"]["Для запуска WarFriends требуется загрузить приблизительно 190 МБ дополнительных данных.\nВремя загрузки может варьироваться в зависимости от вашей сети и местонахождения.\n\nНачать загрузку?"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.HJJCBEPIBKF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["cards"]["ID_CURRENTRANK"]);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["a"]["Device UNPAUSED at {0}"]);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.JGHMIMFOHBN(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("HighLevelSilverRarity");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["ID_STATE_SELECTINGWARCARDS"] != null)
		{
			Debug.Log("Automatic_Equip");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML[" "], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["126 MENU BATTLE SCREEN SHOWN"], string.Empty);
			string aPGKPOOHGFK = "ID_LOADING";
			if (LFPFCHIJLML["menu-arena-ticket"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Rematch Time"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool JKFGEMEBFEL(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.LDDDLGBFMDI(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["S"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_DEBUG_EVENTASSIGNMENTUPDATE"], 1);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("InfluencerAlias", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)174)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)33)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = IKJEOLNIECM(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.HPGPLCPPAFC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.DMBAEOPMJHL();
	}

	public MDNLFMNBNEG LAKCMMMMCCG(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["DOWNLOAD"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_TABLE_PLAYER"], 1L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["REGISTER VIEW STARTER ASSIGNMENT "], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_CONFIRM_JOININGSAMESQUAD"], 1L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["-"]["ID_GOLDPACK"], 1);
			string text = LFPFCHIJLML["GLM: RegisterOrLogin -  2"]["ID_WARNING_CONNECTIONERROR"].ToString();
			char[] array = new char[0];
			array[0] = 'ￇ';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.MHAIBHBGBOO())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.OBLCFHNNHBJ(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML[" , "]["generate"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["sniper_idle"]["AtlasPreparer.LoadTutorialCoroutine"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["HeroicPoints"]["FB: FacebookLogout GC connected"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.IKFJMDJMGHG();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["PlayerToInviteId"]["silver2"]);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["01 "]["com/google/android/gms/common/ConnectionResult"], 1);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.AJCKEGMEMPL(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("ID_GUI_REPORTABUSE_LISTITEM6");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["Medals/"] != null)
		{
			Debug.Log("ID_UNITELITEPERKFULLYTRAINED");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["RenameCount"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_CONFIRM_ERROR"], string.Empty);
			string aPGKPOOHGFK = "squadMembers";
			if (LFPFCHIJLML["ID_HEADERMAXCHAR"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["S"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool LHLEJGMJFNM(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.DAEOCLOCIGO(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["BAND_EMPTY"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Unit_Upgrade"]);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("com/google/android/gms/games/Games", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-139))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-36))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = OPNKEPCBCNO(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.IAOKMMOIDHI(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.KHLLOGNIBCL();
	}

	public MDNLFMNBNEG KOLIDHOEHLC(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["GameDataSetAcknowledged("].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["variant id is "], 0L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["country-australia"], 0L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Ignore_Text_{0}{1}_Dont_Ask_Again"], 1L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["null"][" BOUGHT AND PRESENT IN ACCOUNT"]);
			string text = LFPFCHIJLML["ID_SLOTUPGRADE_DAMAGE"]["SquadEventProgress"].ToString();
			char[] array = new char[0];
			array[0] = '5';
			string[] array2 = text.Split(array);
			for (int i = 0; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.OBLCFHNNHBJ(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.MHAIBHBGBOO())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["{0}-{1}"]["ID_YOUMANAGEDTOWINXARENABATTLESYOU"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["WarBucksBoxes"]["CAUGHT AN MISSION EXCEPTION "] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_INVITATIONNOTACCEPTED"]["), "], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.IKFJMDJMGHG();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.HJJCBEPIBKF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["LV"]["ID_YOUNEEDATLEASTONEDOGTAGTOPLAY"]);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["HeartDialog"]["lootboxes"]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("ID_CONFIRM_TEMPORARBAN");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML[" ID_"] != null)
		{
			Debug.Log("{0}{1}[-] / {2}");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_TUTORIAL_UPGRADEWEAPON_10"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_STAT_BATTLESPLAYED"], string.Empty);
			string aPGKPOOHGFK = "ItemRarity_2";
			if (LFPFCHIJLML["http://localhost:8081/"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["SquadWarsId"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG OKADONBPGEI(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["Improper (strict) JSON formatting.  First character must be [ or {"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_TUTORIAL_UPGRADEWEAPON_3"], 0L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_CONFIRM_FORFEITARENA"], 1L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Region"], 1L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["offerMult"]["ID_ARENARULES_NOSHIELDS"], 1);
			string text = LFPFCHIJLML["ID_CONFIRM_KICKPLAYER_TEXT"]["GooglePlayId"].ToString();
			char[] array = new char[0];
			array[0] = 'ￋ';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.AFOFDNJOJHG())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.PMBAGJEIIJI(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.BKIGLABDGCP())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["#Mission Rewards# 5 Heroic Missions completed. Gained {0} {1} elite parts"]["GLM: current player is null while adding FB account!!"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["Panel   z:{0}\t\"{1}\""]["menu-sidetab-player-promote"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_GUI_REPORTABUSE_LISTITEM0"]["getValueForHookById"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.IKFJMDJMGHG();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_CONTINUE"]["ID_ELITEUNITNAME"]);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["com/google/android/gms/games/Games"]["ID_TRAIN"]);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.JGHMIMFOHBN(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("put");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["Weapon"] != null)
		{
			Debug.Log("{0}\t\tPivot: {1}\n");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_NO"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["UnitCategoriesReminder"], string.Empty);
			string aPGKPOOHGFK = "{0} / {1}";
			if (LFPFCHIJLML["Gui Manager: Starting Messages Coroutine for: "] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Claim_Reward"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool MAPPEKBKONN(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.IPHFOCLGNKD(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["isSuccess"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["damage"], 1);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("Sniper_Tutorial_Played", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-44))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)166)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = AJNPACGBEJG(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.HPGPLCPPAFC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.CIMIGBFNEAM();
	}

	public MDNLFMNBNEG JIPBBILKOEE(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["({0} / {1})"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["-{0}-{1}"], 0L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_STAT_KILLS"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["extraTickets"], 1L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML[" on effect "]["menu-army-cat-shooter"]);
			string text = LFPFCHIJLML["Card_1_Played"]["Still waiting for server\nBe patient :-)"].ToString();
			char[] array = new char[0];
			array[0] = 'L';
			string[] array2 = text.Split(array);
			for (int i = 0; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.HPLKBDKAILA(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.BJNBLINDAED())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["{0} [616577]/[-] {1}"]["\n"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["Not a gold reward."]["Directory \"{0}\" does not exists"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Localization"]["{0}-{1:D6}"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.HJJCBEPIBKF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_FACEBOOKLOGOUTLEGALTEXT"]["trying to add emty indicator "], 1);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["SquadEventProgress"]["REGISTER VIEW STARTER ASSIGNMENT "]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.JGHMIMFOHBN(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("EliminateTime");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["ID_CONFIRM_ERROR"] != null)
		{
			Debug.Log("Unit {0} is not being delivered/upgrade/trained!!!");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["QA"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["getStatusMessage"], string.Empty);
			string aPGKPOOHGFK = "1\u00a0";
			if (LFPFCHIJLML["Shots_Hits"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_LOADING"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool AHAIEOMCMDL(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.DAEOCLOCIGO(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["C2"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["blockingConnect"], 1);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("source_id", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)81)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-172))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = DNOIKMIEPIA(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.LIDJHKLHLPC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.CENIIJFABOA();
	}

	public MDNLFMNBNEG BLGKHDMFKEA(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["RowIDs"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["+0"], 0L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["menu-weapon-benelli-starterpack"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["MedalsOfferMult"], 1L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["나가기"]["0"], 1);
			string text = LFPFCHIJLML["Exception message: "]["customDouble"].ToString();
			char[] array = new char[1];
			array[1] = '\ufff5';
			string[] array2 = text.Split(array);
			for (int i = 0; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.OBLCFHNNHBJ(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.AFOFDNJOJHG())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["ID_CONFIRM_LEAVESQUAD"]["squad"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["Assignment Screen - Daily - Info Clicked"]["QUIT"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Remove Google Play "]["Google2u.DBUpgradeSlotsShotgunner"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.IKFJMDJMGHG();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["game-elite-debuff2"]["ID_SALEPERCENT"]);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ArmyPower"]["ID_STAT_KILLS"]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.JGHMIMFOHBN(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("ID_GUI_EQUIPPED");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["PauseDuration"] != null)
		{
			Debug.Log("subscriptionAnalytics");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["game-revenge-indicator"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["NetworkReInstantiate_1"], string.Empty);
			string aPGKPOOHGFK = "#VAVRO# mMainThreadDispatcher is null ";
			if (LFPFCHIJLML["Scripts Full Path: \"{0}\"\n"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ShotFrequencyMaxCannon"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG IKJEOLNIECM(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["ID_STARTSINX"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Wrong_Unit"], 1L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_NEWLOOTBOXINBATTLES"], 1L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_SALEPERCENTLINE"], 1L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["logout from FB"]["Calling callback and setting it to null!!"]);
			string text = LFPFCHIJLML["test_attribute1"]["Squad"].ToString();
			char[] array = new char[0];
			array[1] = 'ﾱ';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.BKIGLABDGCP())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.EOFGBDCCKBI(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.BJNBLINDAED())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["GameCenterProvider function OnAuthenticated() called => GC: Authenticated with "]["ammo"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["ID_STATS"]["BAND_TYPE_HEALTH"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["NEW RENTAL "]["'fakeOffername'0"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["DogTagRefillTime"]["502 MENU BATTLE SCREEN SHOWN"]);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["reloadTime"]["ID_CONFIRM_ERROR"]);
			Singleton<VipManager>.instance.JJCMHLJBKEA(iDEBKDPMPGM);
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("Scripts to go through: {0}\n");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["LikeUsOnFacebook"] != null)
		{
			Debug.Log("game-missions-red-mission-ico");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["NewLevelId"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_EARLYUNLOCK2"], string.Empty);
			string aPGKPOOHGFK = "elite";
			if (LFPFCHIJLML["FuseBoxx: Reward ad completed"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["AddedCards"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG GPCCLFJEGHM(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["/"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["menu-sidetab-challenge"], 0L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["dailyRewardData"], 1L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML[" NOT OK!\t\t\t\t\t\t"], 0L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML[" WITHDRAWED {0}\n"]["ABOUT TO SHOW DAILY RENTAL"], 1);
			string text = LFPFCHIJLML[" |"]["Battle_length"].ToString();
			char[] array = new char[0];
			array[1] = ':';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.LHDGJFHPJNM())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.HPLKBDKAILA(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.LHDGJFHPJNM())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["doesnt exist"]["menu-arena-lootbox-gold"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML[" FOR DAY "]["\"{0}\""] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["WALLET - reward GOLD {0} animate:{1}"]["fuse offer: {0}"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.IKFJMDJMGHG();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_CONFIRM_LEAVE_SPECTATE_TEXT"]["Daily"], 1);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["./Assets/Scenes"]["ID_SQUADREWARDGET"]);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("Warbucks");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["Metal"] != null)
		{
			Debug.Log("ExtraRewards");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML[" NOT OK! Load army data from DB"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_READYTIME"], string.Empty);
			string aPGKPOOHGFK = "Gold";
			if (LFPFCHIJLML["Waiting for map set"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_BRONZEPACK"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG AJNPACGBEJG(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["null"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_CONFIRM_SERVERDIDNOTRESPOND"], 1L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Level"], 0L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_CONFIRM_PLAYERNAMETAKEN"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["boxOpen"]["S"], 1);
			string text = LFPFCHIJLML["LootboxType"]["), "].ToString();
			string[] array = text.Split('ﾙ');
			for (int i = 1; i < array.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.AFOFDNJOJHG())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.HPLKBDKAILA(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.BKIGLABDGCP())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["Win"]["menu-hub-multiplayer-vipico"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["silver2"]["count"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML[" MAX COUNT: "]["Skipping note with message "], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["shield_hide"]["L"]);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Number"]["ID_CONFIRM_ERRORCLAIMREWARD"]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.JGHMIMFOHBN(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("ID_LOADING");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML[")"] != null)
		{
			Debug.Log("Take player life!");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML[", "], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Reward"], string.Empty);
			string aPGKPOOHGFK = "ANDROID HANDLER: ON PLAYERDATA LOADED";
			if (LFPFCHIJLML["-[0-9]*$"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["============PINGS===========\n"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool MCPLJIAJKJP(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.LDDDLGBFMDI(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["A"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["PNManager: Received event at launch: "], 1);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("1", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-168))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-38))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = DLCDBKPMKDL(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.LIDJHKLHLPC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.CENIIJFABOA();
	}

	public bool PHIBJNOOBKF(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.JIIKBPGNDIM(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["0"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["1"]);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format(" - loggin goldCost: ", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-38))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)158)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = OKADONBPGEI(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.BANLHOLNNEH, gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.KHLLOGNIBCL();
	}

	public MDNLFMNBNEG DLCDBKPMKDL(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["Pool"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["game-card-ico-mineyourstep-full"], 1L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_ARENAREWARDEXPIRATION"], 0L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ticketsSpent"], 0L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["\"{0}\" "]["Shots_Hits"]);
			string text = LFPFCHIJLML["ID_"]["ID_ENERGYCOSTPERUNIT"].ToString();
			char[] array = new char[1];
			array[1] = 'ﾯ';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.EOFGBDCCKBI(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["ID_STAT_UNITSUPGRADES"]["ID_GUI_VIPMEMBERSHIPALMOST_DESC"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["game-card-ico-bg-silver"]["menu-packs-cardslot-ico"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["colt_shooting_start"]["Player_Had_To_Select_Grenade"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.IKFJMDJMGHG();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_TUTORIAL_TAPON"]["S"]);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["deviceName"]["."]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("Tutorial_Step_Complete");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["ID_CONFIRM_STARTUPERROR_TEXT"] != null)
		{
			Debug.Log("ID_WAITINGFORLOOTBOX");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Deadline"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["T"], string.Empty);
			string aPGKPOOHGFK = "Player disconected 0003";
			if (LFPFCHIJLML["Start loading scene: "] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Effect: "], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool KDKCAECIMGI(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return false;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.LHAGOMABHKO(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["{0} {1}"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_CONTINUETOBOOTCAMP3"]);
			if (iJEAJGCCHEF != IJEAJGCCHEF.Success)
			{
				Debug.LogError(string.Format("ID_YOUNEEDMONEYTOUPGRADESPECIAL", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)23)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-86))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = PJAAOIOJCDC(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.BANLHOLNNEH, gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.IPBCHAMGEDG();
	}

	public MDNLFMNBNEG EAAJPMBOFNJ(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["menu-wftv-youtube-ico"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML[" "], 1L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Buy_InstantBattle"], 0L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_SLOTUPGRADE_DAMAGE"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Weapon cost gold, we can buy it even if player is already upgrading"]["Player_Had_To_Select_Grenade"]);
			string text = LFPFCHIJLML["ID_INVITETOSQUAD"]["\t"].ToString();
			char[] array = new char[0];
			array[0] = '\ufff0';
			string[] array2 = text.Split(array);
			for (int i = 0; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.PMBAGJEIIJI(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.LHDGJFHPJNM())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["ID_TUTORIAL_OBJECTIVE"]["Player: "].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["ShieldRechargeRate"]["GameCenterId"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["pooled:"]["en"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_SECONDWEAPONDAMAGE"]["metalExplosion"], 1);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["WaveCoolDown"]["player_right_coverBack"], 1);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.AJCKEGMEMPL(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("special");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["NetworkReInstantiate_1"] != null)
		{
			Debug.Log("CONFERMA");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["DemoteOrKickPlayer {0} {1}"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_STAT_MOSTSQUADPOINTS"], string.Empty);
			string aPGKPOOHGFK = "LevelExperience";
			if (LFPFCHIJLML["Wrong_Unit"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ElitePackDeadline"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK), LJMMJDNNIFH: true);
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool IJOOBMKMLGJ(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.FGABJKFGAKG(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_SQUADSIZEINCREASEATSQUADRANK"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML[" Waypoint Target"], 1);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("WarFriends", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-147))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-134))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = GPCCLFJEGHM(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.HPGPLCPPAFC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.KOABJJBOCIP();
	}

	public bool JCNAGDACOMG(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.LHAGOMABHKO(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["Timestamp"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["N0"], 1);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("Icon", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-79))
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-75))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = OPNKEPCBCNO(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.BANLHOLNNEH, gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.KHLLOGNIBCL();
	}

	public MDNLFMNBNEG PIBLHBIECBI(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["discount"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["PLayerLeagueEvaluation = "], 0L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_MATCH_STARTS_IN"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["country-noflag"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Start TUTORIAL"]["setAndroidIdSha1"], 1);
			string text = LFPFCHIJLML["grenadeExplosion"]["lootboxes offer mult {0}\n"].ToString();
			string[] array = text.Split('\r');
			for (int i = 0; i < array.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.BKIGLABDGCP())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.HPLKBDKAILA(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.LHDGJFHPJNM())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["49a0434f"]["ID_WARNING_SERVERTIMEDOUT"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["{0} {1}"]["Join_Request"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["D2"]["Player name:{0} Player id:{1}\n"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.IKFJMDJMGHG();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.IKFJMDJMGHG();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_RETRY"]["ShowNew"]);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["MissionType"]["ID_EMPTYARENAHEROESPREVIOUS"], 1);
			Singleton<VipManager>.instance.LJALHCJKEHM(iDEBKDPMPGM);
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("\n");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["GameLoginManager: Logout from facebook"] != null)
		{
			Debug.Log("veteranpack4");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["D3"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["GameControllerWarArena.StartGame DONE"], string.Empty);
			string aPGKPOOHGFK = "125 MENU WEAPON SCREEN TUTORIAL WEAPON EQUIPPED";
			if (LFPFCHIJLML["ID_FACEBOOKHINT-COOP"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_SQUADMEDALS"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG AGKNFLOGOMO(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["Beanstalk: Hashed id of fb friend "].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["weaponPreviewCollider"], 0L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_GUI_DELIVERING"], 1L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["FLOATVALUE"], 1L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["MinDamage"]["ID_GAMECENTERUSER"]);
			string text = LFPFCHIJLML["You probably assigned bad type of AmmoSetup to gun"]["DESCARREGAR"].ToString();
			char[] array = new char[0];
			array[1] = 'ﾻ';
			string[] array2 = text.Split(array);
			for (int i = 0; i < array2.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.BKIGLABDGCP())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.OBLCFHNNHBJ(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["GetOriginalAccountId()"]["FirstSpawnDelay"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["country-japan"]["dGhpcyBpcyBhIHNhbXBsZSBpb3MgYXBwIHN0b3JlIHJlY2VpcHQ="] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML[" is Opponent: "]["$5-$10"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["*****   Bootcamp 2/3 Ended   *****"]["LeagueId"]);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["country-taiwan"]["dataEnabled"]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.AJCKEGMEMPL(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("strafing_left");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["On Enter Arena!!"] != null)
		{
			Debug.Log("YourAppId");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Assets"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["DOWNLOAD"], string.Empty);
			string aPGKPOOHGFK = ",";
			if (LFPFCHIJLML["Status"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["BEANSTALK: FINISH PLAYER LEAGUE IN MENU SENT!!!!"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool DKFKCHACPDP(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.FGABJKFGAKG(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["menu-dailyrewards-vip-ico"] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["+"], 1);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("ID_UNIT2UPGRADE_UNIT1UPGRADE", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)(-27))
				{
				}
				if (iJEAJGCCHEF != IJEAJGCCHEF.TooSoonToActivate)
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = OPNKEPCBCNO(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.OOCMCMLOBMH(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards += 0;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.CIMIGBFNEAM();
	}

	public MDNLFMNBNEG EJMFLAPHOKJ(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["AddedCards"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_WARNING_MAXVIDEOFEEDSSUBMITTED"], 1L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["InAppHandlerIos: skipping app store purchase"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_CONFIRM_SERVERDIDNOTRESPOND"], 1L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["fire"]["N"], 1);
			string text = LFPFCHIJLML["Warbucks"]["ID_TOGAINPOINTS"].ToString();
			char[] array = new char[0];
			array[0] = 'o';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.BKIGLABDGCP())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.EOFGBDCCKBI(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.AFOFDNJOJHG())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["SCARICA"]["country-romania"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["BattleId"]["Directory \"{0}\" does not exists"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["subscription_toggle"]["Xp"], 1);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.IKFJMDJMGHG();
				playerVisual.PIAKMCDMHKJ(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.HJJCBEPIBKF(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int vipStart = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Automatic_Equip"]["Beanstalk: Photon Is Full sent"], 1);
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["saved obtained cards: "]["Enemy could not be spawned"]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.PLKIBHJMHDP(iDEBKDPMPGM);
			break;
		}
		default:
			Debug.LogError("ID_SALEPERCENTLINE");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML["()I"] != null)
		{
			Debug.Log("NONCONSUMABLE INAPP: ");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Finished"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ExplodeDamageMin"], string.Empty);
			string aPGKPOOHGFK = " OK!";
			if (LFPFCHIJLML["PlayerGold"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Setting unit delivery in "], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public MDNLFMNBNEG PHLBOCMOHEG(JToken LFPFCHIJLML)
	{
		MDNLFMNBNEG mDNLFMNBNEG = LFPFCHIJLML["java.util.ArrayList"].ToObject<MDNLFMNBNEG>();
		switch (mDNLFMNBNEG)
		{
		case MDNLFMNBNEG.Warbucks:
		{
			long iEALLELGOBM = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["ID_LEAGUE15"], 1L);
			Singleton<Wallet>.instance.EBFKEHKBAFJ(iEALLELGOBM, AJNINHIKAFC: false);
			break;
		}
		case MDNLFMNBNEG.Gold:
		{
			long gNJFHBAKPAN = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["CONFIRM"], 1L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(gNJFHBAKPAN);
			break;
		}
		case MDNLFMNBNEG.ArenaTickets:
		{
			long iEALLELGOBM2 = KHJJFPPACBP.GKKLOFAGGLI(LFPFCHIJLML["Assignment: Error, task definition not found for id = "], 0L);
			Singleton<Wallet>.instance.OLAOFCJHNEM(iEALLELGOBM2);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.ParticularCards:
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
		{
			int num = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["\"}"]["GameDataError("]);
			string text = LFPFCHIJLML["forceSetUserInSegmentId"]["ID_WARNING_CLICKOKTORESEND"].ToString();
			char[] array = new char[0];
			array[1] = '&';
			string[] array2 = text.Split(array);
			for (int i = 1; i < array2.Length; i += 0)
			{
				CardManager.instance.AddMultipleCards(array2[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.LHDGJFHPJNM())
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array2, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.BKIGLABDGCP())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array2, num);
			}
			break;
		}
		case MDNLFMNBNEG.PowerBand:
		case MDNLFMNBNEG.Customization:
		{
			string idVisual = LFPFCHIJLML["ID_WARNING_ARENADOESNTEXIST"]["C0"].ToString();
			PlayerVisual playerVisual;
			if (LFPFCHIJLML["N"]["ID_YOURDOGTAGSAREFULLMOVEALONG"] != null)
			{
				int eFFDGCBOEFG = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["null"]["ID_HOU"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.BMIEJNIEDOP();
				playerVisual.HLILMFFJGOK(eFFDGCBOEFG);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.BMIEJNIEDOP();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case MDNLFMNBNEG.Vip:
		{
			int iDEBKDPMPGM = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["Sessions"]["ID_BLACKMARKETLEFTTEXT2"]);
			int iDEBKDPMPGM2 = KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["ID_WAITVIDEO3"]["ID_INELITE2"], 1);
			Singleton<VipManager>.instance.JJCMHLJBKEA(iDEBKDPMPGM);
			Singleton<VipManager>.instance.JGHMIMFOHBN(iDEBKDPMPGM2);
			break;
		}
		default:
			Debug.LogError("'ID'0");
			break;
		case MDNLFMNBNEG.EliteParts:
			break;
		}
		if (LFPFCHIJLML[" OK!"] != null)
		{
			Debug.Log("PlayerName");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Warbucks added "], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["ID_LEAGUE16"], string.Empty);
			string aPGKPOOHGFK = "No original weapon set for blackmarket weapon: ";
			if (LFPFCHIJLML["Warbucks"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(LFPFCHIJLML["Cards_Owned_Gold"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return mDNLFMNBNEG;
	}

	public bool IEPAOFNCPMM(JToken LFPFCHIJLML)
	{
		if (LFPFCHIJLML == null)
		{
			return true;
		}
		if (LNAIDLKGCFN == null)
		{
			LNAIDLKGCFN = new MGANBPBIOBK(LFPFCHIJLML);
		}
		else
		{
			LNAIDLKGCFN.JIIKBPGNDIM(LFPFCHIJLML);
		}
		if (LFPFCHIJLML["Custom string = "] != null)
		{
			IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(LFPFCHIJLML["N"], 1);
			if (iJEAJGCCHEF != 0)
			{
				Debug.LogError(string.Format("ID_STAT_GRENADEKILLS", iJEAJGCCHEF));
				if (iJEAJGCCHEF == (IJEAJGCCHEF)128)
				{
				}
				if (iJEAJGCCHEF != (IJEAJGCCHEF)(-60))
				{
				}
			}
			else
			{
				MDNLFMNBNEG gGIOEPBPMHF = MJGMFLAKCBG(LFPFCHIJLML);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(LNAIDLKGCFN.HABIKJOKCFE, LNAIDLKGCFN.LIDJHKLHLPC(), gGIOEPBPMHF);
				StatsManager.instance.claimedRewards++;
				Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementClaimedRewards>();
			}
		}
		return LNAIDLKGCFN.JAMAAOCKPJO();
	}
}
