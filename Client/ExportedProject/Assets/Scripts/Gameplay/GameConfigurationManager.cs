using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using WarFriends.Legacy;

public class GameConfigurationManager : InGameSerializedObjectGeneric<GameConfigurationManager.ConfigurationData>
{
	public class ConfigurationData
	{
		public List<string> classesNames = new List<string>();

		public string clientVersion = string.Empty;

		public DatabaseEnvironment enviroment = DatabaseEnvironment.Production;

		public string sheetConfiguration = "0";

		public Dictionary<string, string> sheetVersions;
	}

	[Serializable]
	public class SheetData
	{
		public string id;

		public string version;
	}

	private sealed class MHEHPMDHECH : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Dictionary<string, bool> PANPMOCGAEE;

		internal string KHNMAPDAFFF;

		internal GameConfigurationManager BJGCPDNMHDH;

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

		public void OOKJPJJMPKM()
		{
			throw new NotSupportedException();
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "CONFIRM";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -36 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != ',')
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("{0} {1}" + stringBuilder);
								if (!"ID_BUYSTARTERPACK".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("ID_GUI_CHAT_SQUAD_JOINED");
									break;
								}
							}
							else if (num == 5)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[4];
								array[1] = Singleton<CurrentBundleVersion>.instance.IJHKMCKDOLL();
								array[1] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("BoughtIndex", array);
							}
							else if (num == 8)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 1)
								{
									LoadingDialog.ShowLoading(Localization.Localize("Region"), DMDICGADGCG: true, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["예"] != null)
								{
									Singleton<OfferManager>.instance.SetPacknames(jToken2["EventAssignmentUpdate"]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2["StartFlying"]["getLongitude"] == null || jToken2["Play_Card_Tutorial"] == null || jToken2["withContentId"]["War_Ranked_Battle"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["monthLenght"][" ENTRIES: "];
								text2 = text2.Replace("account", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["Card "] != null)
									{
										text3 = jToken3["ID_CRAFTING"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["S"]["de"];
								List<string> list = null;
								if (jToken2["to "] != null && jToken2["Tutorial_completed"]["SpritesWorkaround"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["PauseGameRPC: Focus lost {0} setTIme {1}"]["OnInputChanged"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["GameGold"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["OnConnectionFailed: restarting"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = true;
								if (jToken2["D3"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["Loading:  mAsync.allowSceneActivation = true"]["ID_PARSING_CONFIGURATIONS"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("commando_shooting" + className + "IA: purchase product, productId = ");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "#VAVRO# Trying to finish Tutorial, which is not currently running ";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[4];
							array2[0] = text5;
							array2[0] = item3.Key;
							array2[8] = "Buy_Dogtags_With_Gold";
							array2[1] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[0] = "BuddyCardData";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("N" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("Is Public = ");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "CardpoolTutorialMessage";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("elite" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public void GHILCKCFAFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CBPDLFGDOHJ()
		{
			throw new NotSupportedException();
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DAAINALAFOJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = ":";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == '9' || i == BJGCPDNMHDH.mResponseString.Length - 0)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != 'z')
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("N" + stringBuilder);
								if (!"Warbucks".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("DB_enviroment");
									break;
								}
							}
							else if (num == 4)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								UnityEngine.Debug.LogWarningFormat("ID_BECOMEVIP", Singleton<CurrentBundleVersion>.instance.PKCHMIAOGJC(), BJGCPDNMHDH.data.sheetConfiguration, null, null, null, null, null);
							}
							else if (num == 5)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 8)
								{
									LoadingDialog.ShowLoading(Localization.Localize("SETTING AFTER PLAYER DATA LOADED -> WAITING FOR "), DMDICGADGCG: true, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["testingidsquadwarsend"] != null)
								{
									Singleton<OfferManager>.instance.SetPacknames(jToken2["\t"]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2["ID_SLOTUPGRADE_HEAT"]["menu-everyplay-ico"] == null || jToken2["Different squads \"{0}\" and \"{1}\"\n"] == null || jToken2["DamageEventPlayer damage: {0} to {1} new HP {2}"]["payloadKeys"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["Warfriends"]["-{0}-{1}"];
								text2 = text2.Replace("DemoteOrKickPlayer {0} {1}", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["ammo"] != null)
									{
										text3 = jToken3["ID_CRAFTWARCARDS"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["{0} Squad Member {1}"]["elitepack5"];
								List<string> list = null;
								if (jToken2["HELMETS_CROWNSILVER"] != null && jToken2["-"]["You probably assigned bad type of AmmoSetup to gun"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["Yes_Clicked"]["ArenaWins"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["Level"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["playerId"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["count: "] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["Facebook Service: share dialog succeeded. Obsah dict = "]["1"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("ID_INSILVER1" + className + "measureSession");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "N";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array = new string[3];
							array[0] = text5;
							array[0] = item3.Key;
							array[2] = "REGISTER VIEW STARTER ASSIGNMENT ";
							array[6] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array[5] = "ID_LOADING";
							text4 = string.Concat(array);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("PurchaseCurrency" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("ID_VISUALCATEGORY2");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "Idle";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("Wrong_Unit" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		public bool PMCFLKAJNHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "TÉLÉCHARGER";
					for (int i = 0; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == 'n' || i == BJGCPDNMHDH.mResponseString.Length - 0)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != -92)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("Amazon Mobile Analytics Operations" + stringBuilder);
								if (!"GoldTransactionAmount".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("Set time to: ");
									break;
								}
							}
							else if (num == 1)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[6];
								array[0] = Singleton<CurrentBundleVersion>.instance.NAMACDKMMFK();
								array[0] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat(" NOT OK!\t\t\t\t\t\t", array);
							}
							else if (num == 7)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 4)
								{
									LoadingDialog.ShowLoading(Localization.Localize("\"}"), DMDICGADGCG: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["warbucks"] != null)
								{
									Singleton<OfferManager>.instance.SetPacknames(jToken2["ID_TUTORIAL_KILLING_SCOPE"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["Confirmed_In_App"]["GetGameConfigurationValue("] == null || jToken2["ID_STATE_OPPONENTDOESNTWANTREMATCH"] == null || jToken2["-"]["ID_CONFIRM_DELETESQUAD_TEXT"] == null)
								{
									stringBuilder.Length = 1;
									continue;
								}
								string text2 = (string)jToken2["ID_NOTIFICATION_DAILYREWARD_WB"]["PACK"];
								text2 = text2.Replace("Scenes to go through: {0}", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["menu-gold"] != null)
									{
										text3 = jToken3["{0}\t\tPivot: {1}\n"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["SI"]["DogTagRefillTime"];
								List<string> list = null;
								if (jToken2["registerPowerHook"] != null && jToken2["Player_Waited_Till_Delivery_Ends"]["Cancel - Disconnect, clicked in dialog !!!"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["PlayerId"]["SquadId"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["setExistingUser"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["gold"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["ID_CONFIRM_FBLOGINCANCELLED_TEXT"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["generate"]["124 MENU WEAPON SCREEN TUTORIAL WEAPON ACTIVATED"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError(":" + className + "{0} / 8");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "ID_CONFIRM_THANKYOUPURCHASE";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[3];
							array2[1] = text5;
							array2[1] = item3.Key;
							array2[8] = "ID_DEBUG_STACKTRACEINCONSOLE";
							array2[8] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[6] = "\t\"FALSE\"";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("DecalManagerData" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("ID_CLAIM");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k++)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "accepted";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("RemoveRewards" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public void GFLFJHIPBNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "metalExplosion";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == 'O' || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != -94)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("SquadWarsId" + stringBuilder);
								if (!"isRandomMap".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("vip");
									break;
								}
							}
							else if (num == 0)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								UnityEngine.Debug.LogWarningFormat("T", Singleton<CurrentBundleVersion>.instance.EDOHDPGGNOE(), BJGCPDNMHDH.data.sheetConfiguration, null);
							}
							else if (num == 4)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 1)
								{
									LoadingDialog.FDBHFJFKALH(Localization.Localize("Scraps"), DMDICGADGCG: false, BGOHKCCLDJP: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["TransactionId123"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["RegisterLevel()"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["DailyGoldDay"]["clipSize"] == null || jToken2["menu-attack-ico"] == null || jToken2["{0}"]["ID_CONFIRM_LEAVE_SPECTATE_TEXT"] == null)
								{
									stringBuilder.Length = 1;
									continue;
								}
								string text2 = (string)jToken2["{0}{1}{2}"]["Sessions"];
								text2 = text2.Replace("Click on the ground to spawn the selected effect", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["AccountType"] != null)
									{
										text3 = jToken3["Sniper"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["215 MENU ARMY SCREEN TUTORIAL UNIT BUY CLICKED"]["PlayerVisual_Gained"];
								List<string> list = null;
								if (jToken2["menu-cards-bronzepack"] != null && jToken2["ID_NOTAVAILABLEATTHEMOMENT"]["LogId"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["GameControllerPVP.StartGame DONE"]["206 STAGE 6 GRENADE THROWING"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["Beanstalk: On Update device token"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["."]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = true;
								if (jToken2["WarFriends"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["weapon"]["Buy_Weapon_Upgrade"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("ID_STARTERASSIGNMENTSEXPIRED" + className + "PLayerLeagueEvaluation = ");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "Xp";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array = new string[0];
							array[0] = text5;
							array[0] = item3.Key;
							array[7] = "ID_INVITEISINACTIVE";
							array[6] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array[6] = "ALL PLAYERS CONNECTED";
							text4 = string.Concat(array);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("Gold" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("MessageId");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "{0}";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("StepId" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object BIGMAMMHKFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public bool FJKEEKBNKPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "ID_HOURS";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -88 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != '\'')
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("DemotedPlayer" + stringBuilder);
								if (!"ID_EMBLEM".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("ID_WARNING_OFFEREXPIRED");
									break;
								}
							}
							else if (num == 6)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[0];
								array[0] = Singleton<CurrentBundleVersion>.instance.EGGMGFFNGLG();
								array[1] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("WarFriends precisa da sua permissão para acessar sua mídia para carregar informações adicionais.Favor aceitar o diálogo de permissão a seguir, saiba que não será utilizada para nenhum outro propósito.", array);
							}
							else if (num == 7)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 3)
								{
									LoadingDialog.ShowLoading(Localization.Localize("SquadRank"), DMDICGADGCG: true, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["Play_Card_Tutorial_Duration"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["warbucks"]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2["timestamp"]["hiding dialog............"] == null || jToken2["menu-gold"] == null || jToken2["Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}."][" NOT OK!\t\t\t\t\t\t"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["Enemy could not be spawned"]["GO TO OFFER"];
								text2 = text2.Replace("Average_Transaction_Amount", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["OK"] != null)
									{
										text3 = jToken3["PlayerName"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["Z "]["Claim Assignment success!"];
								List<string> list = null;
								if (jToken2["You probably assigned bad type of AmmoSetup to gun"] != null && jToken2["UnitsDeployed"]["\n"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["ID_GUI_GOLD"]["withReceipt"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["Problem for max! in army/weapon stats"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["Player profile - Null or empty player id in player profile dialog."]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["ID_STATE_OPPONENTDOESNTWANTREMATCH"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["BoobyTrapSetRPC"]["Card_1_Played"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("{0} {1} {2}/ {3}[-]" + className + "-1");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "ID_STATE_SEARCHINGFOROPPONENT";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[8];
							array2[0] = text5;
							array2[0] = item3.Key;
							array2[3] = "201 LOADING MAP";
							array2[8] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[6] = "\t";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("_pistol" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("ID_CREATESQUADUNLOCKED");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					foreach (Google2uComponentBase google2uComponentBase in sheets)
					{
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "JP";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("DogTagCap" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void CALPCMFJHMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMGAHAGANGP()
		{
			return PHDOCKCBJOF;
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public void JCDBOCPAKEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void EOPANOJJFLC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPFFPONIFOM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CIHKIABJBGJ()
		{
			return PHDOCKCBJOF;
		}

		public void NIEPBMPJEAE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		public void IFBOOBLACGK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		public bool BLHOCNMMPNP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "Show arena golden shield tutorial - pop-up";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -116 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != -72)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log(")" + stringBuilder);
								if (!"-".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("{0}{1}");
									break;
								}
							}
							else if (num == 7)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								UnityEngine.Debug.LogWarningFormat("VideoFeed", Singleton<CurrentBundleVersion>.instance.EGGMGFFNGLG(), BJGCPDNMHDH.data.sheetConfiguration, null, null, null, null, null);
							}
							else if (num == 1)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 4)
								{
									LoadingDialog.FDBHFJFKALH(Localization.Localize("ID_CONFIRM_ERROR"), DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["1"] != null)
								{
									Singleton<OfferManager>.instance.SetPacknames(jToken2["com/google/android/gms/common/api/Status"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["VipRewardForDay"]["Game Login Manager: Google logged in "] == null || jToken2["MyArmyPower"] == null || jToken2["\""]["GameReward"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["KickedPlayerDepositedCards"]["N"];
								text2 = text2.Replace("Hide Waiting Dialog - will hide in a moment: ", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["WEAPON IS NULL"] != null)
									{
										text3 = jToken3["silver2"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["ChangeWeightForDestroyablePartRPC"]["ID_ARENATICKETSSMALL"];
								List<string> list = null;
								if (jToken2["squadName"] != null && jToken2["워프렌즈는 이 추가 데이터를 다운로드 받지 않으면 실행할 수 없습니다. 정말 종료하시겠습니까? 아니면 데이터를 다운로드 받으시겠습니까?"]["THANK YOU"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["Day = "]["ID_GUI_ALLCARDS"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["0"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["trying to add emty indicator "]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["PlayerId"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["MessageId"]["SetPlayer"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("LeagueId" + className + "ID_WARNING_OFFEREXPIRED_TEXT");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "{0} {1}";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array = new string[2];
							array[1] = text5;
							array[0] = item3.Key;
							array[8] = "_Alpha";
							array[1] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array[4] = "DOWNLOAD";
							text4 = string.Concat(array);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("1" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("unlock level for: ");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k++)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + ".";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log(")" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "KCOPCEKOCHL";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -93 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != -58)
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("ID_LEAGUETOPPOSITIONHINT" + stringBuilder);
								if (!"RE-CONNECTING CALLED ".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("Card_1_Played");
									break;
								}
							}
							else
							{
								switch (num)
								{
								case 3:
								{
									text = stringBuilder.ToString();
									BJGCPDNMHDH.data.sheetConfiguration = text;
									object[] array = new object[2];
									array[1] = Singleton<CurrentBundleVersion>.instance.PKCHMIAOGJC();
									array[1] = BJGCPDNMHDH.data.sheetConfiguration;
									UnityEngine.Debug.LogWarningFormat("-", array);
									break;
								}
								case 0:
									jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									break;
								default:
								{
									if (num == 0)
									{
										LoadingDialog.FDBHFJFKALH(Localization.Localize("VIPMemeberShipAlmostEnded"), DMDICGADGCG: false, BGOHKCCLDJP: true);
									}
									JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									if (jToken2 is JObject && jToken2["Total_Battles"] != null)
									{
										Singleton<OfferManager>.instance.SetPacknames(jToken2["LeagueId"]);
										stringBuilder.Length = 1;
										continue;
									}
									if (jToken2 is JArray || jToken2["'lapsedNot'0"]["): "] == null || jToken2["fuseData"] == null || jToken2["DOWNLOAD"]["GetCurrentMapDefinition"] == null)
									{
										stringBuilder.Length = 0;
										continue;
									}
									string text2 = (string)jToken2["()F"]["9 VIP REMINDER\tIs vip {0}"];
									text2 = text2.Replace("ID_DEMOTETODIVISION", string.Empty);
									string text3 = string.Empty;
									if (jToken[text2] != null)
									{
										JToken jToken3 = jToken[text2];
										if (jToken3["null"] != null)
										{
											text3 = jToken3["CX6896566GD"].ToString();
											BJGCPDNMHDH.data.sheetVersions[text2] = text3;
										}
									}
									JToken jToken4 = jToken2["0"]["menu-button-oneside-white"];
									List<string> list = null;
									if (jToken2["InstantBattleEnded: REWARD WARBUCKS: "] != null && jToken2[" - "]["Total_Assignment_Issued"] != null)
									{
										list = new List<string>();
										JToken jToken5 = jToken2["): "]["Level"];
										foreach (JToken item in jToken5.Children())
										{
											list.Add((string)item["ShowRope"]);
										}
									}
									foreach (JToken item2 in jToken4.Children())
									{
										mSheetBuffer.Add((string)item2["ID_ARENARULES_BATTLES"]);
									}
									string className = BJGCPDNMHDH.GetClassName(text2);
									PANPMOCGAEE[className] = false;
									if (jToken2["Status"] != null)
									{
										BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["menu-army-cat-explosive"]["ID_EMPTYUNITTRAIN"], list, text3, text);
									}
									else
									{
										UnityEngine.Debug.LogError("HeroicMissionsCompletionRewardTickets" + className + "\" which is not subscribed");
									}
									mSheetBuffer.Clear();
									break;
								}
								}
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "ID_GUI_FOLLOWTWITTER_DESC";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[1];
							array2[0] = text5;
							array2[0] = item3.Key;
							array2[7] = "ID_PHASEXOFY";
							array2[0] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[3] = "(Lcom/google/android/gms/common/api/GoogleApiClient;I)V";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("ID_CONFIRM_INAPP_FAILED" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("gold");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 0; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "Facebook Service: share dialog succeeded. Obsah dict = ";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("ID_MONEYPACK" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GFBODCHPCLP()
		{
			return PHDOCKCBJOF;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool NAMPBIHOFGI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "Warbucks";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -5 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != -87)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("FuseSDK: Parsing error in _PurchaseVerification" + stringBuilder);
								if (!"Silver".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("discount");
									break;
								}
							}
							else if (num == 3)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[2];
								array[1] = Singleton<CurrentBundleVersion>.instance.AMCKNJHABPO();
								array[0] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("SquadPoints", array);
							}
							else if (num == 1)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 6)
								{
									LoadingDialog.PGFBMJFLHPC(Localization.Localize("[Singleton] An instance of "), DMDICGADGCG: false, BGOHKCCLDJP: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["ID_FEATURE_SHOTSPEED-FANCY"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["country-sweden"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["setPackageName"]["S"] == null || jToken2[","] == null || jToken2["ID_PROMOTEDTODIVISION"]["ID_DOGTAGSREFILLINGFASTERSUBSCRIPTION"] == null)
								{
									stringBuilder.Length = 1;
									continue;
								}
								string text2 = (string)jToken2["N"]["{0} : {1} - {2}"];
								text2 = text2.Replace("ID_VIP_DAYS", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["QUIT"] != null)
									{
										text3 = jToken3["Grenade_Throwing_Tutorial_Duration"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["ID_STARTERASSIGNMENT"]["Overtime_Was_Already_Explained"];
								List<string> list = null;
								if (jToken2["ID_FEATURE_DAMAGE"] != null && jToken2["ID_CONFIRM_FORFEITARENA"]["button"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["ObtainedCards"]["menu-gold"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["Pool"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["warbucks"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = true;
								if (jToken2["Total_Sessions"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["Walk"]["version"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("ID_HOURS" + className + "game-card-ico-bg-silver");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "Player_Waited_Till_Delivery_Ends";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[5];
							array2[1] = text5;
							array2[0] = item3.Key;
							array2[3] = "ID_CONFIRM_TEMPORARBAN";
							array2[7] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[6] = "ExceptionStacktrace";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("hashCode" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("AssignemntId");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k++)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "jp";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("PostParameters" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "({0}\u00a0/\u00a0{1})";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == 'Z' || i == BJGCPDNMHDH.mResponseString.Length - 0)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != -21)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("UA" + stringBuilder);
								if (!"null".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("dailyRewardData");
									break;
								}
							}
							else if (num == 6)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[2];
								array[1] = Singleton<CurrentBundleVersion>.instance.IPNNNPMMLBA();
								array[0] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("{0} {1}", array);
							}
							else if (num == 0)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 5)
								{
									LoadingDialog.ShowLoading(Localization.Localize("GameControllerCoop.StartGame START"), DMDICGADGCG: true, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["Apple"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["Amount"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["Pool"]["com/google/android/gms/games/Games"] == null || jToken2["ID_ZEROSECONDS"] == null || jToken2["Test Getter Methods"]["ID_RANK"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["PlayerLevel"]["realShotProbability"];
								text2 = text2.Replace("WaitTime", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["InventoryData"] != null)
									{
										text3 = jToken3["Buffers"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["gold"]["ID_OPPONENTWASDISCONNECTED"];
								List<string> list = null;
								if (jToken2["OnFetchDeferredAppLinkSucceededEvent"] != null && jToken2["ID_CONFIRM_ACCOUNTBANNED"]["Card_3_Played"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["Player_Waited_Till_Delivery_Ends"]["\""];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["count: "]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["S"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["Error: Crafted card not ready!"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["Daily_Reward_Claimed"]["KochavaDeviceID"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("ID_ARENAENDSENTERTIMER" + className + "SEND PLAYER REPORT ERROR - NO PLAYER ID");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "S";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[3];
							array2[1] = text5;
							array2[0] = item3.Key;
							array2[0] = "SquadId";
							array2[4] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[8] = "DOWNLOADBTN";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("gold3" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/common/api/PendingResult;");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k++)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "Daily_Reward_Claimed";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("#Mission Rewards# 5 Heroic Missions completed. Unit {0} does not exists!" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "ID_GUI_BRONZE";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -75 || i == BJGCPDNMHDH.mResponseString.Length - 0)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != '\u000f')
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("Stacktrace " + stringBuilder);
								if (!"ID_CONFIRM_SUBSCRIPTION_TITLE".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("null");
									break;
								}
							}
							else if (num == 4)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[0];
								array[1] = Singleton<CurrentBundleVersion>.instance.IJHKMCKDOLL();
								array[0] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("ID_CATEGORY_LOW_SG_SHOTGUN", array);
							}
							else if (num == 2)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 8)
								{
									LoadingDialog.ShowLoading(Localization.Localize(" was not found in Notification Center to remove"), DMDICGADGCG: false, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["Indicator {0}"] != null)
								{
									Singleton<OfferManager>.instance.SetPacknames(jToken2["Bad player visuals, data= "]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2[":"]["ID_CONFIRM_SERVERERROR"] == null || jToken2["ID_REFILLED"] == null || jToken2["UnitsDeployed"]["HP"] == null)
								{
									stringBuilder.Length = 1;
									continue;
								}
								string text2 = (string)jToken2["ID_GETAREWARD2"]["StatisticsData"];
								text2 = text2.Replace("PlayerName", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["added"] != null)
									{
										text3 = jToken3["Mouse X"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["AdminPlayerId"]["WarbuckRewardWin"];
								List<string> list = null;
								if (jToken2["1"] != null && jToken2["N"]["Reward {0:D2}"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["audio/menu"]["App installed"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["LostGameInRow"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["MissionReward"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = true;
								if (jToken2["null"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["Leaderboards - Squad Wars - NO INFO ABOUT SQUAD WAR!!!!"]["116 STAGE 5 CONTINUE"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("Saved_data.csv" + className + "#AccoutCheck# GoogleLoggedIn tutorial - wrong situation -> do nothing");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "roomName";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[8];
							array2[0] = text5;
							array2[0] = item3.Key;
							array2[6] = "null";
							array2[4] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[0] = "NO";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("Reward" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("Automatic_Equip");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					foreach (Google2uComponentBase google2uComponentBase in sheets)
					{
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "ID_STARTERASSIGNMENT";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("Gold" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "ID_ARENACROWN_DURATION";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == '{' || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != '\u0016')
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("throw_grenade_left" + stringBuilder);
								if (!"ID_ACTIVATEXVIPFORYGOLD".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("discount");
									break;
								}
							}
							else
							{
								switch (num)
								{
								case 3:
								{
									text = stringBuilder.ToString();
									BJGCPDNMHDH.data.sheetConfiguration = text;
									object[] array = new object[1];
									array[0] = Singleton<CurrentBundleVersion>.instance.APCNNFNJFOL();
									array[1] = BJGCPDNMHDH.data.sheetConfiguration;
									UnityEngine.Debug.LogWarningFormat(" abilityIcon:", array);
									break;
								}
								case 2:
									jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									break;
								default:
								{
									if (num == 3)
									{
										LoadingDialog.ShowLoading(Localization.Localize("reloadTime"), DMDICGADGCG: false, BGOHKCCLDJP: true);
									}
									JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									if (jToken2 is JObject && jToken2["FB: FacebookLogout - RemoveFacebook - 2"] != null)
									{
										Singleton<OfferManager>.instance.SetPacknames(jToken2["{0} / {1}"]);
										stringBuilder.Length = 1;
										continue;
									}
									if (jToken2 is JArray || jToken2["HEAVYTURRET"]["SquadIcons/"] == null || jToken2["//"] == null || jToken2["CreationTime"]["discount"] == null)
									{
										stringBuilder.Length = 1;
										continue;
									}
									string text2 = (string)jToken2["ID_COLLECTONECHRISTMASCRATE"]["ID_WATCHVIDEO"];
									text2 = text2.Replace("Leaderboard removed succesfully", string.Empty);
									string text3 = string.Empty;
									if (jToken[text2] != null)
									{
										JToken jToken3 = jToken[text2];
										if (jToken3["connected"] != null)
										{
											text3 = jToken3["ArenaPoorConnection"].ToString();
											BJGCPDNMHDH.data.sheetVersions[text2] = text3;
										}
									}
									JToken jToken4 = jToken2["ID_CONFIRM_ERRORCLAIMREWARD"]["ID_COMEBACKTOMORROW"];
									List<string> list = null;
									if (jToken2["ID_WARNING_SERVERDATA"] != null && jToken2["ShotFrequencyMax"]["Lcom/google/android/gms/games/event/Events;"] != null)
									{
										list = new List<string>();
										JToken jToken5 = jToken2["ID_SIGNOUT"]["ID_TUTORIAL_GO_TO_ARMORY_3_DOWN"];
										foreach (JToken item in jToken5.Children())
										{
											list.Add((string)item["PlayerLeagueFinished - Player joined {0}, leave {1}, finish on position {2}, with medals {3}"]);
										}
									}
									foreach (JToken item2 in jToken4.Children())
									{
										mSheetBuffer.Add((string)item2["discount"]);
									}
									string className = BJGCPDNMHDH.GetClassName(text2);
									PANPMOCGAEE[className] = false;
									if (jToken2["Double"] != null)
									{
										BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["ID_NOW"]["smallThumbnailLittle"], list, text3, text);
									}
									else
									{
										UnityEngine.Debug.LogError("(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/view/View;)V" + className + "ID_CONFIRM_PURCHASEFAILED");
									}
									mSheetBuffer.Clear();
									break;
								}
								}
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "LevelName";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[1];
							array2[1] = text5;
							array2[1] = item3.Key;
							array2[3] = "SyncShield";
							array2[7] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[3] = "C3";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("ID_CRAFTING" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("[CardHealthChangeUnit] start new spawning before used spawning finish");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					foreach (Google2uComponentBase google2uComponentBase in sheets)
					{
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "Gold";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("BattleLength" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		public void GGDBAJJAHNO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IGKACECJBEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "ID_WATCHVIDEO";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -124 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != -7)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("_MatCap" + stringBuilder);
								if (!"bd18592b-6778-40f5-9327-0aba2d2f1e64".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("ID_NOW");
									break;
								}
							}
							else if (num == 5)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[5];
								array[1] = Singleton<CurrentBundleVersion>.instance.PBKOEBJNGBJ();
								array[0] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("Player disconected 0001", array);
							}
							else if (num == 1)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 2)
								{
									LoadingDialog.FDBHFJFKALH(Localization.Localize("[CFX_SpawnSystem.removeObjectsFromPool()] There aren't any preloaded object for: "), DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["DeathEventPlayer"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["ID_YOUCANWITHDRAWANYWARCARD"]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2["NÃO"]["DeathEvent"] == null || jToken2["Prefabs to go through: {0} + {1}"] == null || jToken2["Changing label \"{0}\" with pivot \"{1}\". New size {2} and yDown {3}."]["N"] == null)
								{
									stringBuilder.Length = 1;
									continue;
								}
								string text2 = (string)jToken2["ID_LOADING"]["RealTimeMultiplayer"];
								text2 = text2.Replace("titleFontBold", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["{0} - {1}\n"] != null)
									{
										text3 = jToken3[": G:"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["idle"]["+"];
								List<string> list = null;
								if (jToken2["{0} {1}{2}[-]"] != null && jToken2["_N"]["FLOATVALUE"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["LeagueEvaluation"]["CheckLabelDynamic - Done"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["ID_MINUTE"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["Card_3_Played"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = true;
								if (jToken2["menu-weapon-mp5-elite"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["ID_SENDINGINVITE"]["ID_BUY"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("ActiveTier" + className + "ID_GUI_BEADVISED_JORCSQUAD");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "$#";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[4];
							array2[1] = text5;
							array2[1] = item3.Key;
							array2[0] = "Per funzionare, WarFriends deve scaricare circa 190MB di dati extra.\nIl tempo di download può variare in base alla tua rete e posizione.\n\nVuoi proseguire?";
							array2[0] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[6] = "{0} {1}{2}";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("Arena Opened Message - skipping showing dialog because player is already in arena screen." + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("Wrong_Category");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					foreach (Google2uComponentBase google2uComponentBase in sheets)
					{
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "UpdateHeadScaleRPC";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log(" " + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "ID_TUTORIAL_GO_BUY_ARMY_4";
					for (int i = 0; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -1 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != -10)
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log(", " + stringBuilder);
								if (!"Buy_Unit_Upgrade".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("Attempts");
									break;
								}
							}
							else if (num == 2)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[0];
								array[0] = Singleton<CurrentBundleVersion>.instance.IHMIAMLDEJO();
								array[1] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("stand_up_crawl", array);
							}
							else if (num == 5)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 6)
								{
									LoadingDialog.ShowLoading(Localization.Localize("Wrong_Weapon"), DMDICGADGCG: true, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["com/google/android/gms/common/api/Status"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2[")"]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2["LevelManager: Init"]["batchSizeMax"] == null || jToken2["com/google/android/gms/games/Games"] == null || jToken2["\n"]["Weapons/"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["Lost"]["S"];
								text2 = text2.Replace("SERVICE_MISSING_PERMISSION", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["discount"] != null)
									{
										text3 = jToken3["can not avoid"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["6 LOGIN FB REMINDER\tConnected to fb: {0}"]["AddFacebookToCustomAccount ID: {0} Name: {1} PSWD: {2}"];
								List<string> list = null;
								if (jToken2["PlayerGold"] != null && jToken2["Null photon view in PhotonLevelIDChanger"]["Fuseboxx Custom Event with params: "] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["MaintenanceMessage"]["CheckDisable"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["AtlasPreparer.LoadMenuCoroutine"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["Panel   z:{0}\t\"{1}\""]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["Manual_Unit_Spawn"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["damage"]["SyncKevlar"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("ID_HOUR_SMALL" + className + " ID_");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "D2";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[7];
							array2[0] = text5;
							array2[1] = item3.Key;
							array2[4] = "isRandomMap";
							array2[1] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[7] = "()F";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("SquadRank" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("No power band to show in reminder!!!");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 0; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "Load assignments:\n";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("elitepack5" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		public void LDBAMIKAGHC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NEGMMIBLJLP()
		{
			return PHDOCKCBJOF;
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}

		public bool LHBPPCGLHDI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "N";
					for (int i = 0; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -11 || i == BJGCPDNMHDH.mResponseString.Length - 0)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != -117)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("getDaysSinceLastPlayed" + stringBuilder);
								if (!"android.os.Build$VERSION".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("Ended");
									break;
								}
							}
							else if (num == 4)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								UnityEngine.Debug.LogWarningFormat("menu-crown-gold", Singleton<CurrentBundleVersion>.instance.AMCKNJHABPO(), BJGCPDNMHDH.data.sheetConfiguration, null, null, null, null);
							}
							else if (num == 6)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 0)
								{
									LoadingDialog.FDBHFJFKALH(Localization.Localize("Buy_Upgrade_For_Army_Unit_At_Rank"), DMDICGADGCG: true, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["ChatClient: "] != null)
								{
									Singleton<OfferManager>.instance.SetPacknames(jToken2["null"]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2["grenadeExplosion"]["ID_GOLDENSHIELDS"] == null || jToken2["This labels must be done manualy (add sprite spacer arround):\n"] == null || jToken2["ID_MAXSTAT"]["JKoZIhvcNAQkBFhN2b2p0YXNpdnJAZ"] == null)
								{
									stringBuilder.Length = 1;
									continue;
								}
								string text2 = (string)jToken2["Position"]["Army upgrade for "];
								text2 = text2.Replace("Buy_Rental_Weapon_Gold", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["ID_TUTORIAL_TAPON"] != null)
									{
										text3 = jToken3["DelayMax"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["DOWNLOAD"]["ID_GUI_SQUADWARSENDREWARD"];
								List<string> list = null;
								if (jToken2["RoundId"] != null && jToken2["Found starting gold currency = "]["InstantBattleTime"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["withReceipt"]["Min_fps"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["No row IDs gained from server for new item config download: "]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["API_UNAVAILABLE"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["ID_GETFORREWARD1"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["Have discount {0} to buy {1}"]["League"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("UpgradeUnitReminder {0} {1}" + className + "ID_YOURBEST");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "FB: Calling On SessionOpenedEvent Manually";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array = new string[4];
							array[1] = text5;
							array[0] = item3.Key;
							array[5] = "ID_STATE_OPPONENTDISCONECTED";
							array[1] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array[2] = "ID_CONFIRM_GAMECENTERNAMETEXT";
							text4 = string.Concat(array);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("S" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log(", databaseType= ");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					foreach (Google2uComponentBase google2uComponentBase in sheets)
					{
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "ID_CONFIRM_ERROR";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("Recording: CheckModel version {0}" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		public void OEMOMDILPEE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "UnitID";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -56 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != '\u0004')
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("ID_DAY_SMALL" + stringBuilder);
								if (!"ID_NOTINLEAGUETEXTANDHINT".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("Password");
									break;
								}
							}
							else if (num == 7)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[3];
								array[0] = Singleton<CurrentBundleVersion>.instance.shortVersion;
								array[0] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("BattleRewards", array);
							}
							else if (num == 7)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 7)
								{
									LoadingDialog.ShowLoading(Localization.Localize("#Mission Rewards# Mission Game Rewards Came"), DMDICGADGCG: false, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2[" "] != null)
								{
									Singleton<OfferManager>.instance.SetPacknames(jToken2["getFriendsList"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["SquadId"]["InAppHandlerIos: On restore finished"] == null || jToken2["ArenaUnlockedMessage"] == null || jToken2["VipStart"]["ID_GETFREEGOLD"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["100+."]["Has Gc Name!"];
								text2 = text2.Replace("ID_CONFIRM_SQUADJOINREQUESTNOTEXISTS", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["VipReward1"] != null)
									{
										text3 = jToken3["Player disconected 0002"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["v"]["primary"];
								List<string> list = null;
								if (jToken2["Card_3_Played"] != null && jToken2["Twitter"]["ID_OFFERACTIVE"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["Yes_Clicked"]["Game shoootable entitiy without owner"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["ID_LEAGUEPROMOTEHINT"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["ID_INGOLD1"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = true;
								if (jToken2["hookId"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["gold"]["withPublisherSubSite"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("Player_Had_To_Select_Grenade" + className + "ID_CONFIRM_ALREADYLEADER");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "BANDS_EMPTY";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[0];
							array2[1] = text5;
							array2[1] = item3.Key;
							array2[5] = "ID_VISUALCATEGORYPARTS0";
							array2[7] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[4] = "SquadId";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("tierCount" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("Medals/");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "ID_DELIVERNOW";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("ID_GUI_TIERREWARD" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AOIEEEHJNLN()
		{
			return PHDOCKCBJOF;
		}

		public void BJHCLGCKJBB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MCLBPLOHNON()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public bool ACHIHMMCDNF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "assaultrifle";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -106 || i == BJGCPDNMHDH.mResponseString.Length - 0)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != '}')
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("Area" + stringBuilder);
								if (!"ID_GUI_TIMEXPBONUS".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("squad name");
									break;
								}
							}
							else if (num == 0)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[1];
								array[1] = Singleton<CurrentBundleVersion>.instance.EGGMGFFNGLG();
								array[1] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("-", array);
							}
							else if (num == 5)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 2)
								{
									LoadingDialog.FDBHFJFKALH(Localization.Localize("ID_PVP_BATTLE"), DMDICGADGCG: true, BGOHKCCLDJP: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["UNSET_VALUE"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["ID_LOADING"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["Recieved {0} messages:"]["RETRY"] == null || jToken2["BlackMarketOffer"] == null || jToken2["Token"]["VipRewardForDay"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["NÃO"]["DemotedPlayer"];
								text2 = text2.Replace("ID_TUTORIAL_UPGRADEWEAPON_4", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["$100-$200"] != null)
									{
										text3 = jToken3["PA: transactions NULL"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["0"]["EligibleLeagueId"];
								List<string> list = null;
								if (jToken2["StopShoot"] != null && jToken2["D2"]["\"NaN\""] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["I"]["ID_LOOTBOXREWARDED"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["PlayerLevel"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["CL"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = true;
								if (jToken2["Daily"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["Message {0}"]["GameDataSetAcknowledged("], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("Going to enable notifications" + className + "{0}{1}");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "ID_SKIRMISHRESULT";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[6];
							array2[1] = text5;
							array2[1] = item3.Key;
							array2[1] = "Server send power band reward id {0} which is null setting random {1}";
							array2[5] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[5] = "N";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("ID_LEAGUE15" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("Visual");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 0; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "Score";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("Gold" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DFKJEOAPBGP()
		{
			return PHDOCKCBJOF;
		}

		public bool BEIABOJAIFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "com/google/android/gms/games/Games";
					for (int i = 0; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -70 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != -81)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("game-card-ico-crateblocker" + stringBuilder);
								if (!"N".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("CONFIRM");
									break;
								}
							}
							else if (num == 1)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[3];
								array[0] = Singleton<CurrentBundleVersion>.instance.DGAOOHPNLMO();
								array[0] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("TopRun", array);
							}
							else if (num == 6)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 7)
								{
									LoadingDialog.ShowLoading(Localization.Localize("Action "), DMDICGADGCG: true, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["http://localhost:8081/"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["ID_VIDEOREADY1"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["ID_SALEPERCENT"]["D2"] == null || jToken2["Gold"] == null || jToken2[", val = "][" in dictionary conversion"] == null)
								{
									stringBuilder.Length = 1;
									continue;
								}
								string text2 = (string)jToken2["BotArmyPower"]["Play_Card_Tutorial_Duration"];
								text2 = text2.Replace("Player_Avoided_Grenade_On_First_Try", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["ItemRarity_2"] != null)
									{
										text3 = jToken3[" 1\u00a0{0}"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["Engineer"]["01"];
								List<string> list = null;
								if (jToken2["{0}/{1}"] != null && jToken2[" arena id"]["http://www.about-fun.com/img/game-war-third-bg.jpg"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["OK"]["ID_TRIPPLEGOLD"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["isSuccess"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["SquadWarsId"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["SetPower"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["SetHitByPlayerRPC "]["Claim_Reward"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("menu-startervalue" + className + "Cards");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "Drone";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[6];
							array2[0] = text5;
							array2[0] = item3.Key;
							array2[4] = "OnPauseDrawing";
							array2[1] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[6] = ")";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("country-canada" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("=== Choosing bot for me in league {0} and balance {1}. Chosen bot in league {2} ===");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k++)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + ")";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("ID_STATE_CONNECTINGTOSERVER" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public bool FOKKNCCLABE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "Scraps";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == 'k' || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != '>')
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("TranslationIdFinder.cs" + stringBuilder);
								if (!"PromotedPlayer".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("game-label-lose");
									break;
								}
							}
							else if (num == 4)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[0];
								array[0] = Singleton<CurrentBundleVersion>.instance.PKCHMIAOGJC();
								array[1] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("ID_VIPTIME", array);
							}
							else if (num == 5)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 0)
								{
									LoadingDialog.PGFBMJFLHPC(Localization.Localize("withOfferId"), DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2[" {0}/{1} "] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2[","]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["SquadId"][","] == null || jToken2["OnDeath Freeze enemy"] == null || jToken2["New Arena"]["category"] == null)
								{
									stringBuilder.Length = 1;
									continue;
								}
								string text2 = (string)jToken2["Mobcrush"]["AFLODScrpt"];
								text2 = text2.Replace("Update of experience\t\t{0} -> {1}\t\t diff {2}, game rewards XP total {3}", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["FinishGameCoopClient"] != null)
									{
										text3 = jToken3["ID_ENDED"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2[" AND "]["NOT SHOWING MAINTENANCE BECAUSE IT IS TOO LATE"];
								List<string> list = null;
								if (jToken2["billingSupportedEvent - is subscription allowed? "] != null && jToken2["ID_VISUALCOMPLETED"]["ID_WARNING_BUDDYCARDNOTREADY"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["WarCards"]["FuseSDK: Parsing error in _AdAvailabilityResponse"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["true"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["percent"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = true;
								if (jToken2["ID_CATEGORY_ASSAULTRIFLE"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["Tier"]["SoldierHP"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("bronze3" + className + "ID_LOADING");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "game-tutorial-grenadier";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[6];
							array2[0] = text5;
							array2[1] = item3.Key;
							array2[2] = "On War arena Shown endeeeed!!";
							array2[7] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[5] = "+0";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("damage" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("LootboxType");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "Level";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("============SHEETS RECIEVED===========\n" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object LNAPDCBIFIJ()
		{
			return PHDOCKCBJOF;
		}

		public void MJIEDEKLIAP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool EJKHEELJJFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "checkForDeferredDeeplink";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -29 || i == BJGCPDNMHDH.mResponseString.Length - 0)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != -65)
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("Card_2_Played" + stringBuilder);
								if (!"SetAutoRepairRPC".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError(": sending via Beanstalk(request count =");
									break;
								}
							}
							else if (num == 2)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[6];
								array[1] = Singleton<CurrentBundleVersion>.instance.IJHKMCKDOLL();
								array[1] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("GameReward", array);
							}
							else if (num == 1)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 0)
								{
									LoadingDialog.PGFBMJFLHPC(Localization.Localize("いいえ"), DMDICGADGCG: true, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["MapDefinition"] != null)
								{
									Singleton<OfferManager>.instance.SetPacknames(jToken2["veteranpack1"]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2["FontSize"][" & "] == null || jToken2["Action "] == null || jToken2["VideoFeed"]["CONFIRM"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["px :\n "]["\n"];
								text2 = text2.Replace(" doesnt contain ", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["undefined"] != null)
									{
										text3 = jToken3["0"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["menu-assignments-bar-red"]["\nCPAPI:{\"cmd\":\"Watch\" \"name\":\""];
								List<string> list = null;
								if (jToken2["\n"] != null && jToken2["MissileExplodeRPC"]["Winstreak"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["get"]["Beanstalk: On Change Name"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["WarBucks"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["Connect to room "]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["ID_DECLINE"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["{0} -> {1}"]["Equipping visual \"{0}\" from rental"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("I Got New Squad Messages" + className + "ID_CONFIRM_ERROR");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "EliminateTime";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[4];
							array2[1] = text5;
							array2[1] = item3.Key;
							array2[4] = "ID_MEMBERS";
							array2[5] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[2] = "100+.";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("Button \"{0}\" has no assigned box collider." + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("Physical ammo is null !!!");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "Enemy could not be spawned";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("ID_UNITTYPE1-DESCRIPTION" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FIBKLKNDFDO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "http://aboutfun.cust.n2n.cz/soldierz_hardware_stats.php";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -10 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != -46)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("getOpenLogId" + stringBuilder);
								if (!"SquadIcons/".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("ID_CONFIRM_NOSQUADACTIONS_TEXT");
									break;
								}
							}
							else
							{
								switch (num)
								{
								case 3:
								{
									text = stringBuilder.ToString();
									BJGCPDNMHDH.data.sheetConfiguration = text;
									object[] array = new object[2];
									array[1] = Singleton<CurrentBundleVersion>.instance.FLCLEDEDLOM();
									array[0] = BJGCPDNMHDH.data.sheetConfiguration;
									UnityEngine.Debug.LogWarningFormat(" friends - global:", array);
									break;
								}
								case 0:
									jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									break;
								default:
								{
									if (num == 0)
									{
										LoadingDialog.FDBHFJFKALH(Localization.Localize("============PINGS===========\n"), DMDICGADGCG: true, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
									}
									JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									if (jToken2 is JObject && jToken2[", "] != null)
									{
										Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["Matchmaking took {0}, assigning bot in 10 secs"]);
										stringBuilder.Length = 1;
										continue;
									}
									if (jToken2 is JArray || jToken2["description"]["WFX_Explosion"] == null || jToken2["#DEBUG_50# "] == null || jToken2["Cards_Owned_Gold"]["ID_FACEBOOKUSER"] == null)
									{
										stringBuilder.Length = 0;
										continue;
									}
									string text2 = (string)jToken2["#AccoutCheck# GoogleLoggedIn tutorial - Check current gpgs on server : {0}"]["getExperimentType"];
									text2 = text2.Replace("ID_GUI_CHAT_SQUAD_JOINED", string.Empty);
									string text3 = string.Empty;
									if (jToken[text2] != null)
									{
										JToken jToken3 = jToken[text2];
										if (jToken3["id"] != null)
										{
											text3 = jToken3["grenadeExplosion"].ToString();
											BJGCPDNMHDH.data.sheetVersions[text2] = text3;
										}
									}
									JToken jToken4 = jToken2["Daily"]["com.tune.TuneGender"];
									List<string> list = null;
									if (jToken2["Skillshot {0}"] != null && jToken2["ID_ERROR_SHORTINPUT"]["Items"] != null)
									{
										list = new List<string>();
										JToken jToken5 = jToken2["ID_UNITTYPE3-DESCRIPTION"]["{0} x {1}{2}[-]"];
										foreach (JToken item in jToken5.Children())
										{
											list.Add((string)item[" was activated (through fast activation)."]);
										}
									}
									foreach (JToken item2 in jToken4.Children())
									{
										mSheetBuffer.Add((string)item2["Quitting WarArena - Time window ended"]);
									}
									string className = BJGCPDNMHDH.GetClassName(text2);
									PANPMOCGAEE[className] = true;
									if (jToken2["WALLET - initialization - GOLD {0} WB {1}"] != null)
									{
										BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["FuseSDK_Prime31_IAB: GoogleIAB.queryInventory failed with message: "]["ID_SECOND"], list, text3, text);
									}
									else
									{
										UnityEngine.Debug.LogError("http://tos.ea.com/legalapp/WEBTERMS/US/" + className + "_CameraWS");
									}
									mSheetBuffer.Clear();
									break;
								}
								}
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "Rental";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[3];
							array2[1] = text5;
							array2[1] = item3.Key;
							array2[2] = "WarFriendsは、この追加データのダウンロードなしでは動作しません。やめてもよいですか？またはデータをダウンロードしますか？";
							array2[5] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[1] = "Sync match start time {0} photon time: {1}";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("buyRentalDiscounted" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("N2");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					foreach (Google2uComponentBase google2uComponentBase in sheets)
					{
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "Assignment: Destroy Crates Constructor";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("bazooka_idle" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public bool DNDHHHDOLMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "COUNT";
					for (int i = 0; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -26 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != '-')
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("Start TUNE SDK clicked" + stringBuilder);
								if (!"extraTickets".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("UNSET_VALUE");
									break;
								}
							}
							else
							{
								switch (num)
								{
								case 8:
								{
									text = stringBuilder.ToString();
									BJGCPDNMHDH.data.sheetConfiguration = text;
									object[] array = new object[4];
									array[0] = Singleton<CurrentBundleVersion>.instance.BDOMELCIMJJ();
									array[0] = BJGCPDNMHDH.data.sheetConfiguration;
									UnityEngine.Debug.LogWarningFormat("Player disconected 000122", array);
									break;
								}
								case 4:
									jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									break;
								default:
								{
									if (num == 8)
									{
										LoadingDialog.FDBHFJFKALH(Localization.Localize("ID_WARCARDSARESPECIALBONUSES"), DMDICGADGCG: false, BGOHKCCLDJP: true);
									}
									JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									if (jToken2 is JObject && jToken2["ID_WARCARDSUNLOCKED"] != null)
									{
										Singleton<OfferManager>.instance.SetPacknames(jToken2["menu-arena-scrap-ico"]);
										stringBuilder.Length = 0;
										continue;
									}
									if (jToken2 is JArray || jToken2["Friend"]["ID_CLAIMING"] == null || jToken2["0"] == null || jToken2["Setting performance to: "][" , "] == null)
									{
										stringBuilder.Length = 1;
										continue;
									}
									string text2 = (string)jToken2["ID_NOHEROESINCURRENTARENA"]["ArmyPower"];
									text2 = text2.Replace("menu-info-close-ico", string.Empty);
									string text3 = string.Empty;
									if (jToken[text2] != null)
									{
										JToken jToken3 = jToken[text2];
										if (jToken3["extraWarBucks"] != null)
										{
											text3 = jToken3["Action "].ToString();
											BJGCPDNMHDH.data.sheetVersions[text2] = text3;
										}
									}
									JToken jToken4 = jToken2["OK"]["Time"];
									List<string> list = null;
									if (jToken2["ID_DOWNLOADINGFILES"] != null && jToken2["Production"]["CONFIRM"] != null)
									{
										list = new List<string>();
										JToken jToken5 = jToken2["\t\"TRUE\""]["N"];
										foreach (JToken item in jToken5.Children())
										{
											list.Add((string)item["ID_STAT_SQUADWARSWINS"]);
										}
									}
									foreach (JToken item2 in jToken4.Children())
									{
										mSheetBuffer.Add((string)item2["S"]);
									}
									string className = BJGCPDNMHDH.GetClassName(text2);
									PANPMOCGAEE[className] = false;
									if (jToken2["warbucks"] != null)
									{
										BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["setOptedOutOfPush"]["#Mission Rewards# Heroic was opened"], list, text3, text);
									}
									else
									{
										UnityEngine.Debug.LogError("This labels must be done manualy (add sprite spacer arround):\n" + className + "+{0}");
									}
									mSheetBuffer.Clear();
									break;
								}
								}
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "S";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[8];
							array2[0] = text5;
							array2[1] = item3.Key;
							array2[0] = "ID_OFFERACTIVE";
							array2[4] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[0] = " {0}\u00a0{1}";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("Should not happen - unit icon is not instantiated in bottom section." + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("WarBucks");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 0; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "ID_ZEROSECONDS";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("ID_ASSIGNMENTHINTWARPATH" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public bool HOJKAHEGFEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "dogtag";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == 't' || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != -98)
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("YES" + stringBuilder);
								if (!"FacebookPassword".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("ID_PHASEXOFY");
									break;
								}
							}
							else if (num == 4)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[5];
								array[1] = Singleton<CurrentBundleVersion>.instance.DGAOOHPNLMO();
								array[0] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("워프렌즈가 중요한 게임 데이터를 다운로드 받으려면 미디어 저장소에 대한 접근 권한이 필요합니다. 이 권한이 없으면, 게임이 정상적으로 작동되지 않고 종료됩니다. 다시 시도하거나 워프렌즈를 종료해주세요.", array);
							}
							else if (num == 5)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 8)
								{
									LoadingDialog.ShowLoading(Localization.Localize("SquadMessages"), DMDICGADGCG: true, BGOHKCCLDJP: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["-[^-]*$"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["weapon doesnt have ammo setup"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["ID_CONFIRM_FRIENDINSQUAD_TEXT"]["ShotFrequencyMax"] == null || jToken2["Buy_Upgrade_For_Army_Unit_At_Rank"] == null || jToken2["minigun_run"]["ID_GUI_BEADVISED_JORCSQUAD"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["MoneyPackDeadline"]["ID_ERROR_SQUADSKILLNOTANUMBER"];
								text2 = text2.Replace("{0} {1}", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["Session: Update GC authenticated! session update = "] != null)
									{
										text3 = jToken3["CZ"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["test_searchString"]["FuseSDK: Parsing error in _GameDataSetAcknowledged"];
								List<string> list = null;
								if (jToken2["Metal"] != null && jToken2["#account# logged to gpgs result {0}"]["Shots_Hits"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["81cb29735bbd4830b860f8d13ebeb48b"]["-"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["GLM: RegisterOrLogin -  10"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2[". Loading default..."]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["height"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["Error setting match state {0} to player {1}"]["ID_TRAINED"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError(" 1\u00a0{0}" + className + " Button Clicked in InAppPurchase");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = " OK!";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[7];
							array2[0] = text5;
							array2[1] = item3.Key;
							array2[6] = "league";
							array2[0] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[4] = "{0} {1}/ {2}{3}";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("SendLogs" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("ID_ARENARULES_NOOVERTIME");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "N";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("ChangeCamoRPC" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "ID_WARNING_PROMOTEERROR";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -49 || i == BJGCPDNMHDH.mResponseString.Length - 0)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != -27)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("OnAgeVerificationCriteriaMet" + stringBuilder);
								if (!"Button \"{0}\" has no assigned box collider.".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("LootboxType");
									break;
								}
							}
							else
							{
								switch (num)
								{
								case 2:
								{
									text = stringBuilder.ToString();
									BJGCPDNMHDH.data.sheetConfiguration = text;
									object[] array = new object[2];
									array[0] = Singleton<CurrentBundleVersion>.instance.IPNNNPMMLBA();
									array[0] = BJGCPDNMHDH.data.sheetConfiguration;
									UnityEngine.Debug.LogWarningFormat("FLOATVALUE", array);
									break;
								}
								case 5:
									jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									break;
								default:
								{
									if (num == 5)
									{
										LoadingDialog.ShowLoading(Localization.Localize("S"), DMDICGADGCG: true, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
									}
									JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									if (jToken2 is JObject && jToken2["ID_STARTERASSIGNMENTX"] != null)
									{
										Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["Skipping next withdraw basecause player left squad"]);
										stringBuilder.Length = 0;
										continue;
									}
									if (jToken2 is JArray || jToken2["{0}{1}[-] {2}/[-] 3"]["Assignment: Error, task definition not found for id = "] == null || jToken2["\t"] == null || jToken2["FB: FacebookLogout - DeletePlayerAccount - 1"]["LootBoxOpen"] == null)
									{
										stringBuilder.Length = 1;
										continue;
									}
									string text2 = (string)jToken2["ID_ZEROSECONDS"]["ID_PURCHASED"];
									text2 = text2.Replace("ID_BUFF", string.Empty);
									string text3 = string.Empty;
									if (jToken[text2] != null)
									{
										JToken jToken3 = jToken[text2];
										if (jToken3["kr"] != null)
										{
											text3 = jToken3["{0}{1}[-]"].ToString();
											BJGCPDNMHDH.data.sheetVersions[text2] = text3;
										}
									}
									JToken jToken4 = jToken2["ID_MISSIONANIMATION_WAVESTARTED"]["game-card-ico-disarmed"];
									List<string> list = null;
									if (jToken2["nextDay"] != null && jToken2["ID_SUBSCRIPTIODETAILS_HINT5"]["Start"] != null)
									{
										list = new List<string>();
										JToken jToken5 = jToken2["ID_GUI_ACCEPT_PLAYER_CANTJOIN"]["#DOMINIK# out of time"];
										foreach (JToken item in jToken5.Children())
										{
											list.Add((string)item["trial"]);
										}
									}
									foreach (JToken item2 in jToken4.Children())
									{
										mSheetBuffer.Add((string)item2["pack"]);
									}
									string className = BJGCPDNMHDH.GetClassName(text2);
									PANPMOCGAEE[className] = false;
									if (jToken2["armyPreviewCollider"] != null)
									{
										BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["bazooka_idle"]["Days_Since_Install"], list, text3, text);
									}
									else
									{
										UnityEngine.Debug.LogError("ID_CONFIRM_FORFEITARENA_TEXT" + className + "Player_Avoided_Grenade_On_First_Try");
									}
									mSheetBuffer.Clear();
									break;
								}
								}
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "BattleId";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[6];
							array2[1] = text5;
							array2[0] = item3.Key;
							array2[1] = "customDouble";
							array2[2] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[7] = ")";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("ID_DEBUG_GUIERROR" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("NewVisuals");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "localSquadLeaderboard";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("shield_unhide" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		public void DECFCNMMOAG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		public bool NHLBGCIDHDE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "DOWNLOAD";
					for (int i = 0; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == '\u0003' || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != -53)
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("game-label-lose" + stringBuilder);
								if (!"ID_LOADING".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("ВЫХОД");
									break;
								}
							}
							else if (num == 2)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[5];
								array[1] = Singleton<CurrentBundleVersion>.instance.AMCKNJHABPO();
								array[1] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("OnConnectedToMaster", array);
							}
							else if (num == 8)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 7)
								{
									LoadingDialog.PGFBMJFLHPC(Localization.Localize("spriteCollectionTextureCompressed"), DMDICGADGCG: true, BGOHKCCLDJP: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["1"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["PRICE"]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2["Buy_Upgrade_For_Army_Unit_Elite"]["antialiasing"] == null || jToken2["/Player_"] == null || jToken2["ID_SILVERPACK"]["Play_Card_Tutorial_Duration"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["BattleRewards"]["ID_CARD_DESC_BUDDY"];
								text2 = text2.Replace("Beanstalk: On Send Settings", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["102 GAME STARTED"] != null)
									{
										text3 = jToken3["TIMEOUT"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["ID_CONTINUETOBOOTCAMP3"]["ID_COLLECTXELITEPARTSX"];
								List<string> list = null;
								if (jToken2["ID_TUTORIAL_TAPON"] != null && jToken2["A"]["ID_FACEBOOKINVITEFRIENDSTEXT-FIGHT"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["["]["WarBucks"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["Pack_Id"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["{0}{1} / {2}"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} gold"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["ID_UNITMAXUPGRADED"]["timeToGetDogtag: "], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("Level" + className + "DogTagSeconds");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "ID_WARSHOP_LOOTBOXES";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[2];
							array2[1] = text5;
							array2[1] = item3.Key;
							array2[8] = "{0} {1}";
							array2[0] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[6] = "ID_INVITETOSQUAD";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("CustomizationTutorialMessage" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("elitepack5");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 0; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "TEST FUSEBOX - fake offer:\n";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("ID_LOADING" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		public bool KAIHNOCLNHK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = ".";
					for (int i = 0; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -59 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != -11)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("BattleRewards" + stringBuilder);
								if (!"NAME".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError(" & ");
									break;
								}
							}
							else if (num == 8)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[0];
								array[1] = Singleton<CurrentBundleVersion>.instance.BDOMELCIMJJ();
								array[1] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("service", array);
							}
							else if (num == 6)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 3)
								{
									LoadingDialog.PGFBMJFLHPC(Localization.Localize("ID_LEAGUE0"), DMDICGADGCG: false, BGOHKCCLDJP: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["WarFriends precisa descarregar aproximadamente 190MB de dados extra para correr.\nO tempo de download pode variar dependendo da rede e da localização.\n\nDesejas continuar?"] != null)
								{
									Singleton<OfferManager>.instance.SetPacknames(jToken2["[^\\d]"]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2["Army_Unit_ID"]["ID_CONFIRM_SERVERDIDNTRESPONDAFTER"] == null || jToken2["TUNE Unity Test App"] == null || jToken2["unsubscribed."][" with error code: "] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["ID_ARENARULES_NORELOADING"]["N"];
								text2 = text2.Replace("Cards on saved data: ", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["{0} {1}"] != null)
									{
										text3 = jToken3["\"{0}\""].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["Error setting match state {0} to player {1}"]["ID_MISSIONANIMATION_BOSSINCOMING"];
								List<string> list = null;
								if (jToken2["ID_CONFIRM_NOSQUADACTIONS_TEXT"] != null && jToken2["Play_Card_Tutorial"]["IsMaster"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["localSquadLeaderboard"]["    "];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["StatisticsData"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["MainScene.unity"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["Look vector is small! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} rotatedLookVector: {5}"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["ID_CONFIRM_NOTACTIVEEVENT"]["file://"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("ID_OFFERACTIVE" + className + "Vip");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "url";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[5];
							array2[0] = text5;
							array2[1] = item3.Key;
							array2[6] = "C1";
							array2[2] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[1] = "menu-gold";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("exception message" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("menu-startervalue");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 0; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "First_Time_Buy_";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("IsLocal" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public void APFFCILMOII()
		{
			throw new NotSupportedException();
		}

		public bool CKOILCFEDGJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "ammo";
					for (int i = 0; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -23 || i == BJGCPDNMHDH.mResponseString.Length - 0)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != '/')
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("\n" + stringBuilder);
								if (!"menu-hub-multiplayer-vipico".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("ID_SALEPERCENTLINE");
									break;
								}
							}
							else if (num == 2)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[4];
								array[1] = Singleton<CurrentBundleVersion>.instance.IPNNNPMMLBA();
								array[0] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("canClaim", array);
							}
							else if (num == 3)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 8)
								{
									LoadingDialog.FDBHFJFKALH(Localization.Localize("ID_RESTART"));
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["ID_STAT_FLAWLESSHERO"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["ID_WARNING_CRAFTINGCLAIMNOTREADY"]);
									stringBuilder.Length = 1;
									continue;
								}
								if (jToken2 is JArray || jToken2["ID_ARMYPOWER"]["dataEnabled"] == null || jToken2["[-]"] == null || jToken2["ID_READYTIME"]["+"] == null)
								{
									stringBuilder.Length = 1;
									continue;
								}
								string text2 = (string)jToken2[".png"]["dailyRewardData"];
								text2 = text2.Replace("ID_DOGTAGS", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["0"] != null)
									{
										text3 = jToken3["ID_HEROIC"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["{0} - {1}\n"]["BG"];
								List<string> list = null;
								if (jToken2["Battle_Number"] != null && jToken2["ID_YOUARENUMBERONE"]["ID_SALEPERCENTLINE"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["#VOJTA# ERROR CLAIMING EVENT ASSIGNMENT / MILESTONE!!"]["VipReward2"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["menu-squad-{0}"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["D3"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = true;
								if (jToken2["Claiming reward ..."] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["PlayerName"]["SetIsImmortalRPC"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("Bad object with NavigationHelperCapsule LAYER" + className + "ID_CONFIRM_ONLYLEADERSCANINVITE");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "iCloud: Save Player!";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[3];
							array2[1] = text5;
							array2[0] = item3.Key;
							array2[3] = "ID_NA";
							array2[8] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[7] = "init";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("BeginnersLeague" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("Error while parsing response from GetConfigurations, will try again next run");
				for (int j = 1; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 1; k < sheets.Length; k++)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "ID_CHATCANNOTSENDMESSAGESRECONNECTING";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: true);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("MainScene.unity" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		public void PECKOCOJICO()
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
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = false;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "0";
					for (int i = 0; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == ';' || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num++;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != ';')
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("Checking success string: " + stringBuilder);
								if (!"success".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("Error while parsing response from GetConfigurations, will try again next run");
									break;
								}
							}
							else
							{
								switch (num)
								{
								case 2:
									text = stringBuilder.ToString();
									BJGCPDNMHDH.data.sheetConfiguration = text;
									UnityEngine.Debug.LogWarningFormat("Recieved from server CONFIGURATIONS: {0}-{1}", Singleton<CurrentBundleVersion>.instance.shortVersion, BJGCPDNMHDH.data.sheetConfiguration);
									break;
								case 3:
									jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									break;
								default:
								{
									if (num == 3)
									{
										LoadingDialog.ShowLoading(Localization.Localize("ID_PARSING_CONFIGURATIONS"));
									}
									JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
									if (jToken2 is JObject && jToken2["Localization"] != null)
									{
										Singleton<OfferManager>.instance.SetPacknames(jToken2["Localization"]);
										stringBuilder.Length = 0;
										continue;
									}
									if (jToken2 is JArray || jToken2["Id"]["S"] == null || jToken2["Data"] == null || jToken2["Data"]["L"] == null)
									{
										stringBuilder.Length = 0;
										continue;
									}
									string text2 = (string)jToken2["Id"]["S"];
									text2 = text2.Replace("Client_", string.Empty);
									string text3 = string.Empty;
									if (jToken[text2] != null)
									{
										JToken jToken3 = jToken[text2];
										if (jToken3["N"] != null)
										{
											text3 = jToken3["N"].ToString();
											BJGCPDNMHDH.data.sheetVersions[text2] = text3;
										}
									}
									JToken jToken4 = jToken2["Data"]["L"];
									List<string> list = null;
									if (jToken2["RowIDs"] != null && jToken2["RowIDs"]["L"] != null)
									{
										list = new List<string>();
										JToken jToken5 = jToken2["RowIDs"]["L"];
										foreach (JToken item in jToken5.Children())
										{
											list.Add((string)item["S"]);
										}
									}
									foreach (JToken item2 in jToken4.Children())
									{
										mSheetBuffer.Add((string)item2["S"]);
									}
									string className = BJGCPDNMHDH.GetClassName(text2);
									PANPMOCGAEE[className] = true;
									if (jToken2["ColumnNames"] != null)
									{
										BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["ColumnNames"]["S"], list, text3, text);
									}
									else
									{
										UnityEngine.Debug.LogError("Configuration Error: sheet " + className + " error (no ColumnNames)");
									}
									mSheetBuffer.Clear();
									break;
								}
								}
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "============SHEETS RECIEVED===========\n";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							text4 = text5 + item3.Key + ";" + BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)] + "\n";
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("Exception while processing received sheets: " + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("NEW CONFIG WILL BE LOADED FROM PREFS:");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					foreach (Google2uComponentBase google2uComponentBase in sheets)
					{
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "\n";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("Loaded from prefs: " + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object CFCIACEHFHE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AAIGGFHFBIC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LJNKKNHFIMG()
		{
			return PHDOCKCBJOF;
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BCIDICEAAEN()
		{
			return PHDOCKCBJOF;
		}

		public bool KIFNNJFJJCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 0;
					string text = "facebookFriends";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i += 0)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -46 || i == BJGCPDNMHDH.mResponseString.Length - 0)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 1 && c != -26)
							{
								stringBuilder.Append(c);
							}
							if (num == 1)
							{
								UnityEngine.Debug.Log("ID_DAYS" + stringBuilder);
								if (!")".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("ID_HOU");
									break;
								}
							}
							else if (num == 7)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								UnityEngine.Debug.LogWarningFormat("ID_STAT_GRENADEKILLS", Singleton<CurrentBundleVersion>.instance.FLCLEDEDLOM(), BJGCPDNMHDH.data.sheetConfiguration);
							}
							else if (num == 3)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 0)
								{
									LoadingDialog.FDBHFJFKALH(Localization.Localize("BattleId"));
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["DogtagsRefillRankUp"] != null)
								{
									Singleton<OfferManager>.instance.CNLEMOAHJBA(jToken2["game-ico-poison"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["ID_ARENALOSSREWARD"]["WarFriendsは追加データを実行するため、約190MBをダウンロードする必要があります。\nダウンロード時間はネットワークと現在位置によって異なります。\n\n続行してもよいですか？"] == null || jToken2["ServerErrorHandler: squadCreationsCount = "] == null || jToken2["http://www.about-fun.com/warfriends-mobcrush"]["Deposited warcards DID NOT change"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["ID_LEAGUE7"]["ID_BLACKMARKET"];
								text2 = text2.Replace("category", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["__"] != null)
									{
										text3 = jToken3["ID_GUI_LIKEFB_NOW"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["Location"]["{0} {1} {2} {3}"];
								List<string> list = null;
								if (jToken2["withAdvertiserSubAdgroup"] != null && jToken2["GoldReward{0}Min"]["GLM: RegisterOrLogin - 6.5: no GC response, use stored values"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["ID_WARNING_BLACKMARKETDOESNTEXIST"]["twitter"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["ID_POSTPONE"]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/view/View;)V"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = true;
								if (jToken2["DebugLog"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["weapon doesnt have ammo setup"]["OK"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("IsVip" + className + "Starting stage 2 ");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 1;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "DEPOSIT WARCARDS MESSAGE!!!";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array = new string[8];
							array[1] = text5;
							array[1] = item3.Key;
							array[1] = "bad enemy point";
							array[8] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array[1] = "{0} {1}{2}";
							text4 = string.Concat(array);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("Card_3_Played" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("Vip");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j += 0)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 0; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "ID_MONEYPACKINFORMATIONS";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("Dictionary created/cleared.\n" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public void KBKIDOJFMHC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ObscuredPrefs.onAlterationDetected += BJGCPDNMHDH.OnPlayerPrefsHack;
				goto case 1u;
			case 1u:
			{
				if (!BJGCPDNMHDH.mConfigsRecived)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mConfigsRecived = true;
				PANPMOCGAEE = new Dictionary<string, bool>();
				if (BJGCPDNMHDH.mResponseString != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					JToken jToken = new JObject();
					int num = 1;
					string text = "ID_ARENAREWARD_SCRAP";
					for (int i = 1; i < BJGCPDNMHDH.mResponseString.Length; i++)
					{
						char c = BJGCPDNMHDH.mResponseString[i];
						if (c == -17 || i == BJGCPDNMHDH.mResponseString.Length - 1)
						{
							num += 0;
							if (i == BJGCPDNMHDH.mResponseString.Length - 0 && c != '\\')
							{
								stringBuilder.Append(c);
							}
							if (num == 0)
							{
								UnityEngine.Debug.Log("Still waiting for server\nBe patient :-)" + stringBuilder);
								if (!"Shots_Hits".Equals(stringBuilder.ToString()))
								{
									UnityEngine.Debug.LogError("LeagueId");
									break;
								}
							}
							else if (num == 5)
							{
								text = stringBuilder.ToString();
								BJGCPDNMHDH.data.sheetConfiguration = text;
								object[] array = new object[5];
								array[1] = Singleton<CurrentBundleVersion>.instance.IJHKMCKDOLL();
								array[0] = BJGCPDNMHDH.data.sheetConfiguration;
								UnityEngine.Debug.LogWarningFormat("Army upgrade for ", array);
							}
							else if (num == 3)
							{
								jToken = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
							}
							else
							{
								if (num == 4)
								{
									LoadingDialog.FDBHFJFKALH(Localization.Localize("Start TUNE SDK"), DMDICGADGCG: true, BGOHKCCLDJP: true);
								}
								JToken jToken2 = JsonConvert.DeserializeObject<JToken>(stringBuilder.ToString());
								if (jToken2 is JObject && jToken2["Gold"] != null)
								{
									Singleton<OfferManager>.instance.SetPacknames(jToken2["speed"]);
									stringBuilder.Length = 0;
									continue;
								}
								if (jToken2 is JArray || jToken2["medals"]["IsUnique"] == null || jToken2["Rental Dialog called: type: \"{0}, \"ID: \"{1}\", discount: \"{2}%\", is sale: \"{3}\""] == null || jToken2["MissionType"]["Made_IAP_Spend"] == null)
								{
									stringBuilder.Length = 0;
									continue;
								}
								string text2 = (string)jToken2["Data"]["roomName"];
								text2 = text2.Replace("fire", string.Empty);
								string text3 = string.Empty;
								if (jToken[text2] != null)
								{
									JToken jToken3 = jToken[text2];
									if (jToken3["Player_level"] != null)
									{
										text3 = jToken3["Card_3_Played"].ToString();
										BJGCPDNMHDH.data.sheetVersions[text2] = text3;
									}
								}
								JToken jToken4 = jToken2["1"]["ID_CONFIRM_WARCARDNOTAVAILABLE"];
								List<string> list = null;
								if (jToken2["Directory \"{0}\" does not exists"] != null && jToken2["Time"]["ID_PURCHASINGPACK"] != null)
								{
									list = new List<string>();
									JToken jToken5 = jToken2["ID_INPROGRESS"]["ID_REMINDER_YOURVIPMEMBERSHIP"];
									foreach (JToken item in jToken5.Children())
									{
										list.Add((string)item["), "]);
									}
								}
								foreach (JToken item2 in jToken4.Children())
								{
									mSheetBuffer.Add((string)item2["ID_OK"]);
								}
								string className = BJGCPDNMHDH.GetClassName(text2);
								PANPMOCGAEE[className] = false;
								if (jToken2["MainScene"] != null)
								{
									BJGCPDNMHDH.UpdateSheetInGame(className, mSheetBuffer, (string)jToken2["ID_READYTIME"]["ID_STAT_MOSTSQUADPOINTS"], list, text3, text);
								}
								else
								{
									UnityEngine.Debug.LogError("IsGlobal" + className + "PlayerId");
								}
								mSheetBuffer.Clear();
							}
							stringBuilder.Length = 0;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					try
					{
						string text4 = "ID_PERMANENTUNLOCK";
						foreach (KeyValuePair<string, bool> item3 in PANPMOCGAEE)
						{
							string text5 = text4;
							string[] array2 = new string[6];
							array2[0] = text5;
							array2[0] = item3.Key;
							array2[4] = "Army_Unit_ID";
							array2[4] = BJGCPDNMHDH.data.sheetVersions[BJGCPDNMHDH.StripGoogleFu(item3.Key)];
							array2[6] = "ID_SALEPERCENTLINE";
							text4 = string.Concat(array2);
						}
						UnityEngine.Debug.Log(text4);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("ID_COMPLETEDAILYSOLOMISSIONS" + ex.Message);
					}
				}
				BJGCPDNMHDH.mResponseString = null;
				BJGCPDNMHDH.Save();
				KHNMAPDAFFF = string.Empty;
				UnityEngine.Debug.Log("IosTransactionId");
				for (int j = 0; j < BJGCPDNMHDH.data.classesNames.Count; j++)
				{
					string text6 = BJGCPDNMHDH.data.classesNames[j];
					if (PANPMOCGAEE.ContainsKey(text6))
					{
						continue;
					}
					Google2uComponentBase[] sheets = BJGCPDNMHDH.sheets;
					for (int k = 0; k < sheets.Length; k += 0)
					{
						Google2uComponentBase google2uComponentBase = sheets[k];
						string text7 = google2uComponentBase.GetType().ToString();
						if (text7 == text6)
						{
							KHNMAPDAFFF = KHNMAPDAFFF + text6 + "VIPMemeberShipAlmostEnded";
							string value = string.Empty;
							string key = BJGCPDNMHDH.StripGoogleFu(text7);
							BJGCPDNMHDH.data.sheetVersions.TryGetValue(key, out value);
							if (!ConfigurationSaver.LoadConfigFromFile(text6, google2uComponentBase, value))
							{
								instance.ReDownload(forceDownloadAll: false);
							}
							break;
						}
					}
				}
				UnityEngine.Debug.Log("ID_CONFIRM_ERROR" + KHNMAPDAFFF);
				ObscuredPrefs.onAlterationDetected -= BJGCPDNMHDH.OnPlayerPrefsHack;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		public void KINGACOICNF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FMINPCPGBBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public MHEHPMDHECH()
		{
		}

		public void OOOLABBEKDF()
		{
			throw new NotSupportedException();
		}
	}

	private static readonly List<string> mSheetBuffer = new List<string>();

	public string initClientVersion;

	public DatabaseEnvironment initDatabaseEnvironment;

	public string initSheetConfiguration;

	public List<SheetData> initSheetVersions;

	private Google2uComponentBase[] mAllSheets;

	private bool mConfigsRecived;

	private string mResponseString;

	private readonly string mSheetPrefix = "Google2u.";

	public Dictionary<string, Google2uComponentBase> sheetsDictionary = new Dictionary<string, Google2uComponentBase>();

	private static GameConfigurationManager mInstance;

	public Google2uComponentBase[] sheets
	{
		get
		{
			if (mAllSheets == null || mAllSheets.Length == 0)
			{
				mAllSheets = UnityEngine.Object.FindObjectsOfType<Google2uComponentBase>();
				Dictionary<Type, int> dictionary = new Dictionary<Type, int>();
				Google2uComponentBase[] array = mAllSheets;
				foreach (Google2uComponentBase google2uComponentBase in array)
				{
					Type type = google2uComponentBase.GetType();
					if (!dictionary.ContainsKey(type))
					{
						dictionary[type] = 1;
						sheetsDictionary[type.ToString()] = google2uComponentBase;
					}
					else
					{
						dictionary[type]++;
					}
				}
				foreach (KeyValuePair<Type, int> item in dictionary)
				{
					if (item.Value != 1)
					{
						UnityEngine.Debug.LogError($"Configurations error, there is {item.Value} configurations of type {item.Key}");
					}
				}
			}
			return mAllSheets;
		}
	}

	private bool isInitEnviromentSame
	{
		get
		{
			if (initDatabaseEnvironment == DatabaseEnvironment.DevelopmentSvk && Singleton<BeanstalkServerManager>.instance.environment == initDatabaseEnvironment)
			{
				return true;
			}
			if (Singleton<BeanstalkServerManager>.instance.environment == DatabaseEnvironment.DevelopmentSvk)
			{
				return false;
			}
			return true;
		}
	}

	public static GameConfigurationManager instance
	{
		get
		{
			mInstance = mInstance ?? ((GameConfigurationManager)SingletonSupport.FindOrCreate(typeof(GameConfigurationManager)));
			return mInstance;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Google2uComponentBase[] array = sheets;
		foreach (Google2uComponentBase google2uComponentBase in array)
		{
			string className = google2uComponentBase.GetType().ToString();
			ConfigurationSaver.DeleteOldFromPrefs(className, google2uComponentBase.columnNames);
		}
		if (data != null && data.classesNames != null && data.classesNames.Count > 0)
		{
			for (int num = data.classesNames.Count - 1; num >= 0; num--)
			{
				string className2 = data.classesNames[num];
				if (!ConfigurationSaver.IsFileExist(className2))
				{
					data.sheetVersions = null;
					break;
				}
			}
		}
		if (data.sheetVersions != null && data.enviroment != Singleton<BeanstalkServerManager>.instance.environment)
		{
			UnityEngine.Debug.Log($"Configarations enviromend changed, saved: {data.enviroment}, current {Singleton<BeanstalkServerManager>.instance.environment}");
			InitSheetVersions(forceDownload: true);
		}
		if (data.sheetVersions != null)
		{
			CheckNewConfigsInClient();
		}
		else
		{
			InitSheetVersions();
			Save();
		}
		Google2uComponentBase[] array2 = sheets;
	}

	private void CheckNewConfigsInClient()
	{
		Google2uComponentBase[] array = sheets;
		foreach (Google2uComponentBase google2uComponentBase in array)
		{
			string text = StripGoogleFu(google2uComponentBase.GetType().ToString());
			if (!data.sheetVersions.ContainsKey(text))
			{
				data.sheetVersions[text] = ((!isInitEnviromentSame) ? "-1" : GetInitSheetVersion(text).ToString());
				UnityEngine.Debug.Log($"Client has new config for: {text} with version {data.sheetVersions[text]}");
			}
		}
		if (!isInitEnviromentSame)
		{
			return;
		}
		bool flag = false;
		if (Singleton<CurrentBundleVersion>.instance.shortVersion == initClientVersion)
		{
			if (data.clientVersion != initClientVersion)
			{
				UnityEngine.Debug.Log($"Client is newer, configs stored for: {data.clientVersion} and new version is {initClientVersion} init sheet config {initSheetConfiguration}, current bundle version {Singleton<CurrentBundleVersion>.instance.shortVersion}");
				data.clientVersion = initClientVersion;
				data.sheetConfiguration = initSheetConfiguration;
				flag = true;
			}
		}
		else if (data.clientVersion != Singleton<CurrentBundleVersion>.instance.shortVersion)
		{
			UnityEngine.Debug.Log($"Client has no suitable init configs, RESETING, configs stored for: {data.clientVersion} and new version is {initClientVersion} init sheet config {initSheetConfiguration}, curent bundle version {Singleton<CurrentBundleVersion>.instance.shortVersion}");
			flag = true;
			data.clientVersion = Singleton<CurrentBundleVersion>.instance.shortVersion;
			data.sheetConfiguration = "0";
		}
		List<string> list = new List<string>(data.sheetVersions.Keys);
		foreach (string item in list)
		{
			int num = int.Parse(data.sheetVersions[item]);
			int initSheetVersion = GetInitSheetVersion(item);
			if (initSheetVersion >= num)
			{
				if (initSheetVersion > num)
				{
					UnityEngine.Debug.Log($"Client has newer config for: {item} Saved version {num} Client version {initSheetVersion}");
				}
				data.sheetVersions[item] = initSheetVersion.ToString();
			}
			if (flag)
			{
				ConfigurationSaver.DeleteFile(GetClassName(item));
			}
		}
		Save();
	}

	private int GetInitSheetVersion(string sheetName)
	{
		if (initSheetVersions != null)
		{
			foreach (SheetData initSheetVersion in initSheetVersions)
			{
				if (initSheetVersion.id == sheetName)
				{
					return int.Parse(initSheetVersion.version);
				}
			}
		}
		return -1;
	}

	private void InitSheetVersions(bool forceDownload = false)
	{
		data.sheetVersions = new Dictionary<string, string>();
		data.enviroment = Singleton<BeanstalkServerManager>.instance.environment;
		data.sheetConfiguration = ((!forceDownload && isInitEnviromentSame) ? initSheetConfiguration : "0");
		data.clientVersion = Singleton<CurrentBundleVersion>.instance.shortVersion;
		data.classesNames = new List<string>();
		Google2uComponentBase[] array = sheets;
		foreach (Google2uComponentBase google2uComponentBase in array)
		{
			string text = StripGoogleFu(google2uComponentBase.GetType().ToString());
			data.sheetVersions[text] = "-1";
			if (!forceDownload && isInitEnviromentSame)
			{
				data.sheetVersions[text] = GetInitSheetVersion(text).ToString();
			}
		}
		Save();
	}

	internal void UpdateConfigurationsNew(string response)
	{
		mResponseString = response;
		mConfigsRecived = true;
	}

	private string StripGoogleFu(string input)
	{
		return (!input.StartsWith(mSheetPrefix)) ? input : input.Substring(mSheetPrefix.Length);
	}

	private void OnPlayerPrefsHack()
	{
		UnityEngine.Debug.LogError("Configurations hacked");
		ReDownload(forceDownloadAll: true);
	}

	[DebuggerHidden]
	public IEnumerator PrepareConfigurations()
	{
		MHEHPMDHECH mHEHPMDHECH = new MHEHPMDHECH();
		mHEHPMDHECH.BJGCPDNMHDH = this;
		return mHEHPMDHECH;
	}

	private void ReDownload(bool forceDownloadAll)
	{
		mResponseString = null;
		ObscuredPrefs.onAlterationDetected -= OnPlayerPrefsHack;
		InitSheetVersions(forceDownloadAll);
		StopAllCoroutines();
		Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
		GameLoginManager.Relog();
	}

	private Dictionary<string, bool> ParseSheetColumnNames(string columnString)
	{
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < columnString.Length; i++)
		{
			char c = columnString[i];
			if (c == '/' || i == columnString.Length - 1)
			{
				if (i == columnString.Length - 1 && c != '/')
				{
					stringBuilder.Append(c);
				}
				dictionary[stringBuilder.ToString()] = true;
				stringBuilder.Length = 0;
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return dictionary;
	}

	private List<string> ParseRowValues(string rowString)
	{
		List<string> list = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < rowString.Length; i++)
		{
			char c = rowString[i];
			if (c == '/' || i == rowString.Length - 1)
			{
				if (i == rowString.Length - 1 && c != '/')
				{
					stringBuilder.Append(c);
				}
				list.Add(stringBuilder.ToString());
				stringBuilder.Length = 0;
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		if (rowString[rowString.Length - 1] == '/')
		{
			list.Add(string.Empty);
		}
		return list;
	}

	private Google2uComponentBase GetSheet(string className)
	{
		Google2uComponentBase[] array = sheets;
		foreach (Google2uComponentBase google2uComponentBase in array)
		{
			string text = google2uComponentBase.GetType().ToString();
			if (text == className)
			{
				return google2uComponentBase;
			}
		}
		return null;
	}

	private void UpdateSheetInGame(string className, List<string> rows, string columnNamesString, List<string> rowIDs, string sheetVersion, string configurationsVersion)
	{
		Dictionary<string, bool> dictionary = ParseSheetColumnNames(columnNamesString);
		className = className.Replace("Client_", string.Empty);
		Google2uComponentBase sheet = GetSheet(className);
		List<List<string>> list = new List<List<string>>();
		if (sheet != null && sheet.haveDictionary)
		{
			if (rowIDs == null)
			{
				UnityEngine.Debug.LogError("No row IDs gained from server for new item config download: " + className);
				return;
			}
			if (rows.Count != rowIDs.Count)
			{
				UnityEngine.Debug.LogError("No row IDs count not match with row count for: " + className);
				return;
			}
			for (int i = 0; i < rows.Count; i++)
			{
				List<string> list2 = ParseRowValues(rows[i]);
				list.Add(list2);
				int rowIndex = sheet.GetRowIndex(rowIDs[i]);
				if (list2.Count == dictionary.Count)
				{
					if (rowIndex < 0)
					{
						List<string> list3 = new List<string>();
						list3.Add(rowIDs[i]);
						for (int j = 0; j < list2.Count; j++)
						{
							list3.Add(list2[j]);
						}
						int num = sheet.AddRowGenericRealyAdd(list3);
						if (num < 0)
						{
							UnityEngine.Debug.LogError("error in creating new row in: " + className + " with error code: " + num);
							break;
						}
						continue;
					}
					int num2 = 0;
					foreach (KeyValuePair<string, bool> item in dictionary)
					{
						string text = list2[num2++];
						if (sheet.HasColumn(item.Key))
						{
							object value = sheet.GetValue(rowIndex, item.Key);
							if (value == null || value.ToString() != text)
							{
								sheet.SetValue(rowIndex, item.Key, text);
							}
						}
						else
						{
							UnityEngine.Debug.LogWarning($"Error - sheet {className} doesnt have column {item.Key}");
						}
					}
				}
				else
				{
					UnityEngine.Debug.LogError($"Error - wrong column names and values count ({dictionary.Count} != {list2.Count}) for sheet {className}");
					UnityEngine.Debug.LogError(columnNamesString);
					UnityEngine.Debug.LogError(rows[i]);
				}
			}
		}
		SaveSheetToPrefs(className, rowIDs, sheetVersion, dictionary, list);
	}

	private void SaveSheetToPrefs(string className, List<string> rowIDs, string sheetVersion, Dictionary<string, bool> columnNames, List<List<string>> preparedRows)
	{
		ConfigurationSaver.SaveSheetToFile(className, rowIDs, sheetVersion, columnNames, preparedRows);
		if (!data.classesNames.Contains(className))
		{
			data.classesNames.Add(className);
		}
	}

	public void UpdateSheet(string className, List<Dictionary<string, string>> rows, bool save = false)
	{
		Google2uComponentBase[] array = sheets;
		foreach (Google2uComponentBase google2uComponentBase in array)
		{
			string text = google2uComponentBase.GetType().ToString();
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			if (!(text == className))
			{
				continue;
			}
			for (int j = 0; j < rows.Count; j++)
			{
				if (j < google2uComponentBase.RowsGeneric.Count)
				{
					Dictionary<string, string> dictionary2 = rows[j];
					foreach (KeyValuePair<string, string> item in dictionary2)
					{
						if (google2uComponentBase.HasColumn(item.Key))
						{
							string text2 = google2uComponentBase.GetValue(j, item.Key).ToString();
							if (text2 != item.Value)
							{
								google2uComponentBase.SetValue(j, item.Key, item.Value);
							}
						}
						if (!google2uComponentBase.HasColumn(item.Key))
						{
							UnityEngine.Debug.LogError($"Error - sheet {text} doesnt have column {item.Key}");
						}
						dictionary[item.Key] = true;
					}
					continue;
				}
				UnityEngine.Debug.LogError(string.Concat("Error in loading configuration for ", google2uComponentBase.GetType(), ", there is more records on server than on client (records missing = ", rows.Count - j, ")"));
				break;
			}
		}
	}

	private string GetClassName(string sheetId)
	{
		return mSheetPrefix + sheetId;
	}

	internal void GetConfigurations(string configVariant)
	{
		LoadingDialog.ShowLoading(Localization.Localize("ID_DOWNLOADING_CONFIGURATIONS"));
		Singleton<BeanstalkServerManager>.instance.OLEBMHEAKEA(data.sheetConfiguration, configVariant);
	}

	public static string GetAllConfigsJson()
	{
		Google2uComponentBase[] array = UnityEngine.Object.FindObjectsOfType<Google2uComponentBase>();
		List<string> list = new List<string>();
		if (array != null)
		{
			Google2uComponentBase[] array2 = array;
			foreach (Google2uComponentBase google2uComponentBase in array2)
			{
				list.Add(google2uComponentBase.GetType().ToString());
			}
		}
		return JsonConvert.SerializeObject(list);
	}

	public void OnDestroy()
	{
		mInstance = null;
	}
}
