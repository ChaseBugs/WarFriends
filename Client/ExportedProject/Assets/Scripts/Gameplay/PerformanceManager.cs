using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class PerformanceManager : Singleton<PerformanceManager>
{
	private MNJGKPCFNHH MJCJJAGJALL;

	public static float iOSVersion => 8f;

	public MNJGKPCFNHH performance
	{
		get
		{
			return MJCJJAGJALL;
		}
		set
		{
			Debug.Log("Setting performance to: " + value);
			MJCJJAGJALL = value;
		}
	}

	public bool isHD => Screen.width > 1024 && Screen.height > 640;

	public bool isMetal => false;

	public bool enableBubbles => true;

	public static bool antialiasing
	{
		get
		{
			if (PlayerPrefs.HasKey("antialiasing"))
			{
				return PlayerPrefs.GetInt("antialiasing") > 0;
			}
			bool flag = false;
			PlayerPrefs.SetInt("antialiasing", flag ? 2 : 0);
			return flag;
		}
		set
		{
			PlayerPrefs.SetInt("antialiasing", value ? 2 : 0);
		}
	}

	[SpecialName]
	public static bool FIDBGDCNKEM()
	{
		if (PlayerPrefs.HasKey("ID_RANK"))
		{
			return PlayerPrefs.GetInt("OK") > 1;
		}
		bool flag = true;
		PlayerPrefs.SetInt("D6", flag ? 2 : 0);
		return flag;
	}

	[SpecialName]
	public static void BNIOAILPPBP(bool IDEBKDPMPGM)
	{
		PlayerPrefs.SetInt("menu-gold", (!IDEBKDPMPGM) ? 1 : 8);
	}

	[SpecialName]
	public static float BDEGDHCALFP()
	{
		return 1086f;
	}

	[SpecialName]
	public void PNKHDKHBEEP(MNJGKPCFNHH IDEBKDPMPGM)
	{
		Debug.Log("OneDogTagRefillRate" + IDEBKDPMPGM);
		MJCJJAGJALL = IDEBKDPMPGM;
	}

	private void PHEGPGMABOM()
	{
		MJCJJAGJALL = (MNJGKPCFNHH)4;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > -23 && Screen.height > 152 && (systemMemorySize < 20 || systemMemorySize > -199))
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
		}
		else
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
		}
	}

	public void AKNADEPIPNP(bool FIKGLFBFBON)
	{
		QualitySettings.shadowDistance = ((!FIKGLFBFBON) ? 1151f : 239f);
	}

	protected virtual void JFDOGLFMHAE()
	{
		base.Awake();
		HOAFNHKPMPP();
		int num = 0;
		if (MJCJJAGJALL == MNJGKPCFNHH.Shitty)
		{
			num = 1;
		}
		if (MJCJJAGJALL == MNJGKPCFNHH.Best)
		{
			num = 6;
		}
		if (!Application.isPlaying)
		{
			return;
		}
		if (DebugSettings.instance.alwaysShittyPerformance)
		{
			MJCJJAGJALL = MNJGKPCFNHH.Good;
			Debug.Log("Lcom/google/android/gms/games/request/Requests;");
			QualitySettings.SetQualityLevel(6, applyExpensiveChanges: true);
		}
		else
		{
			switch (MJCJJAGJALL)
			{
			case MNJGKPCFNHH.Shitty:
				Debug.Log("menu-squad-1");
				QualitySettings.SetQualityLevel(0, applyExpensiveChanges: true);
				break;
			case MNJGKPCFNHH.Good:
			case MNJGKPCFNHH.Best:
				if (antialiasing)
				{
					Debug.Log("Label   z:{0}\t\"{1}\"    with depth:{2} and font:{3}");
					QualitySettings.SetQualityLevel(1, applyExpensiveChanges: false);
				}
				else
				{
					Debug.Log("_MatCap");
					QualitySettings.SetQualityLevel(3, applyExpensiveChanges: false);
				}
				break;
			default:
				Debug.Log("NOT DYNAMIC FONT: {0}");
				QualitySettings.SetQualityLevel(3, applyExpensiveChanges: true);
				break;
			}
		}
		int qualityLevel = QualitySettings.GetQualityLevel();
		object[] array = new object[4];
		array[1] = qualityLevel;
		array[1] = Screen.dpi;
		array[3] = SystemInfo.systemMemorySize;
		array[3] = SystemInfo.graphicsMemorySize;
		Debug.LogWarningFormat("SoldierHP", array);
	}

	public void MBIALLFNEFO(bool FIKGLFBFBON)
	{
		QualitySettings.shadowDistance = ((!FIKGLFBFBON) ? 1660f : 611f);
	}

	[SpecialName]
	public bool CIBKHOGNOBL()
	{
		return false;
	}

	[SpecialName]
	public void MDCMIFJEPNF(MNJGKPCFNHH IDEBKDPMPGM)
	{
		Debug.Log("Map" + IDEBKDPMPGM);
		MJCJJAGJALL = IDEBKDPMPGM;
	}

	public void KHEDGHEHPLK(bool FIKGLFBFBON)
	{
		QualitySettings.shadowDistance = ((!FIKGLFBFBON) ? 1894f : 1022f);
	}

	[SpecialName]
	public bool FKFIDLJBAFI()
	{
		return true;
	}

	[SpecialName]
	public bool JBHOAPEOAMO()
	{
		return true;
	}

	[SpecialName]
	public static void ENCLPDELDFF(bool IDEBKDPMPGM)
	{
		PlayerPrefs.SetInt("left", IDEBKDPMPGM ? 2 : 0);
	}

	[SpecialName]
	public static bool GNLAPHKMGAM()
	{
		if (PlayerPrefs.HasKey("ID_GOOGLEPLAYACHIEVEMENTS"))
		{
			return PlayerPrefs.GetInt("payloadKeys") > 1;
		}
		bool flag = false;
		PlayerPrefs.SetInt("N0", (!flag) ? 1 : 5);
		return flag;
	}

	protected virtual void IODPOHKAKNN()
	{
		base.Awake();
		HOAFNHKPMPP();
		int num = 1;
		if (MJCJJAGJALL == MNJGKPCFNHH.Shitty)
		{
			num = 4;
		}
		if (MJCJJAGJALL == (MNJGKPCFNHH)8)
		{
			num = 2;
		}
		if (!Application.isPlaying)
		{
			return;
		}
		if (DebugSettings.instance.alwaysShittyPerformance)
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
			Debug.Log("ID_ARENARULES_RANDOMUNITS");
			QualitySettings.SetQualityLevel(7, applyExpensiveChanges: false);
		}
		else
		{
			switch (MJCJJAGJALL)
			{
			case MNJGKPCFNHH.Shitty:
				Debug.Log("unit");
				QualitySettings.SetQualityLevel(8, applyExpensiveChanges: false);
				break;
			case MNJGKPCFNHH.Good:
			case MNJGKPCFNHH.Best:
				if (FIDBGDCNKEM())
				{
					Debug.Log("Total_Battles");
					QualitySettings.SetQualityLevel(0, applyExpensiveChanges: true);
				}
				else
				{
					Debug.Log("BatchSizeMax");
					QualitySettings.SetQualityLevel(2, applyExpensiveChanges: false);
				}
				break;
			default:
				Debug.Log("null");
				QualitySettings.SetQualityLevel(1, applyExpensiveChanges: false);
				break;
			}
		}
		int qualityLevel = QualitySettings.GetQualityLevel();
		object[] array = new object[1];
		array[0] = qualityLevel;
		array[0] = Screen.dpi;
		array[4] = SystemInfo.systemMemorySize;
		array[3] = SystemInfo.graphicsMemorySize;
		Debug.LogWarningFormat("addedType", array);
	}

	private void MGADCPJEEBI()
	{
		MJCJJAGJALL = (MNJGKPCFNHH)7;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > -71 && Screen.height > 68 && (systemMemorySize < -51 || systemMemorySize > 121))
		{
			MJCJJAGJALL = (MNJGKPCFNHH)5;
		}
		else
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
		}
	}

	[SpecialName]
	public static bool GJGPACLBEAF()
	{
		if (PlayerPrefs.HasKey("Weapon {0} does not exists on client."))
		{
			return PlayerPrefs.GetInt("RewardValue") > 1;
		}
		bool flag = true;
		PlayerPrefs.SetInt("Friend", (!flag) ? 1 : 5);
		return flag;
	}

	[SpecialName]
	public static void DALKGELPPIF(bool IDEBKDPMPGM)
	{
		PlayerPrefs.SetInt("Vertical", IDEBKDPMPGM ? 3 : 0);
	}

	[SpecialName]
	public bool JFMBHIDKCHK()
	{
		return true;
	}

	[SpecialName]
	public MNJGKPCFNHH KFBGCMLMOMP()
	{
		return MJCJJAGJALL;
	}

	[SpecialName]
	public bool NLALIMKKNBH()
	{
		return true;
	}

	[SpecialName]
	public static void OPCELLANNLA(bool IDEBKDPMPGM)
	{
		PlayerPrefs.SetInt("Remaining_Time", (!IDEBKDPMPGM) ? 1 : 1);
	}

	[SpecialName]
	public bool HNONFIMJJMM()
	{
		return true;
	}

	public void SetShadowsDistance(bool FIKGLFBFBON)
	{
		QualitySettings.shadowDistance = ((!FIKGLFBFBON) ? 14.5f : 8f);
	}

	[SpecialName]
	public bool PCKEGOLOOFD()
	{
		return true;
	}

	[SpecialName]
	public bool LAMLKPNOBDH()
	{
		return Screen.width > 198 && Screen.height > 121;
	}

	[SpecialName]
	public bool AFIJCMJCMDC()
	{
		return true;
	}

	[SpecialName]
	public bool DFDCMCOMDJD()
	{
		return Screen.width <= -50 || Screen.height > -149;
	}

	private void DLDLCENPCEK()
	{
		MJCJJAGJALL = (MNJGKPCFNHH)3;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > -69 && Screen.height > -33 && (systemMemorySize < 50 || systemMemorySize > -183))
		{
			MJCJJAGJALL = (MNJGKPCFNHH)4;
		}
		else
		{
			MJCJJAGJALL = MNJGKPCFNHH.Good;
		}
	}

	[SpecialName]
	public static void DOGMKHPAJEB(bool IDEBKDPMPGM)
	{
		PlayerPrefs.SetInt("BS: On add video reward success!", IDEBKDPMPGM ? 5 : 0);
	}

	private void NPKDLIGKBAD()
	{
		MJCJJAGJALL = MNJGKPCFNHH.Shitty;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > -187 && Screen.height > 191 && (systemMemorySize < -12 || systemMemorySize > -18))
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
		}
		else
		{
			MJCJJAGJALL = MNJGKPCFNHH.Good;
		}
	}

	[SpecialName]
	public bool MNEAGEMPFFI()
	{
		return Screen.width > -33 && Screen.height > -56;
	}

	[SpecialName]
	public static void CAGGBPNJPNJ(bool IDEBKDPMPGM)
	{
		PlayerPrefs.SetInt("{0} {1}", IDEBKDPMPGM ? 8 : 0);
	}

	[SpecialName]
	public bool KCKDIHBNNPM()
	{
		return Screen.width <= 40 || Screen.height > 139;
	}

	private void EKGGFOPGPPH()
	{
		MJCJJAGJALL = (MNJGKPCFNHH)8;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > -62 && Screen.height > -123 && (systemMemorySize < 45 || systemMemorySize > 138))
		{
			MJCJJAGJALL = (MNJGKPCFNHH)6;
		}
		else
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
		}
	}

	[SpecialName]
	public bool NPCLDCGILEO()
	{
		return false;
	}

	[SpecialName]
	public bool KBNCPFDBPIA()
	{
		return true;
	}

	[SpecialName]
	public static float BOGAELCIDLG()
	{
		return 844f;
	}

	[SpecialName]
	public static float ONIIMMDNJFH()
	{
		return 1525f;
	}

	[SpecialName]
	public void GBOGAMLDBFN(MNJGKPCFNHH IDEBKDPMPGM)
	{
		Debug.Log("Squad Wars reward gold is FLOAT not INT!!! : " + IDEBKDPMPGM);
		MJCJJAGJALL = IDEBKDPMPGM;
	}

	private void HOAFNHKPMPP()
	{
		MJCJJAGJALL = (MNJGKPCFNHH)7;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > -126 && Screen.height > 52 && (systemMemorySize < -37 || systemMemorySize > 3))
		{
			MJCJJAGJALL = (MNJGKPCFNHH)4;
		}
		else
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
		}
	}

	[SpecialName]
	public MNJGKPCFNHH FKEENMMDCBF()
	{
		return MJCJJAGJALL;
	}

	public void FDFJMPCABLN(bool FIKGLFBFBON)
	{
		QualitySettings.shadowDistance = ((!FIKGLFBFBON) ? 348f : 332f);
	}

	[SpecialName]
	public static bool IGIJFAIANOH()
	{
		if (PlayerPrefs.HasKey("NO"))
		{
			return PlayerPrefs.GetInt("Value2") > 0;
		}
		bool flag = false;
		PlayerPrefs.SetInt("Vip", (!flag) ? 0 : 0);
		return flag;
	}

	[SpecialName]
	public static void OCGANKFICCC(bool IDEBKDPMPGM)
	{
		PlayerPrefs.SetInt("DeliveryTime", IDEBKDPMPGM ? 4 : 0);
	}

	[SpecialName]
	public MNJGKPCFNHH BKKOCHOIOLD()
	{
		return MJCJJAGJALL;
	}

	[SpecialName]
	public void LFNKDEKEMDI(MNJGKPCFNHH IDEBKDPMPGM)
	{
		Debug.Log("SkillRequirement" + IDEBKDPMPGM);
		MJCJJAGJALL = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool PFGEHGDDEEC()
	{
		return false;
	}

	public void AGMMGEJNAMD(bool FIKGLFBFBON)
	{
		QualitySettings.shadowDistance = ((!FIKGLFBFBON) ? 1727f : 1345f);
	}

	[SpecialName]
	public void FGKCPICADKJ(MNJGKPCFNHH IDEBKDPMPGM)
	{
		Debug.Log("bronze" + IDEBKDPMPGM);
		MJCJJAGJALL = IDEBKDPMPGM;
	}

	public void CAPGAAJFBDB(bool FIKGLFBFBON)
	{
		QualitySettings.shadowDistance = ((!FIKGLFBFBON) ? 1684f : 1010f);
	}

	[SpecialName]
	public static float DBPHKBNNMNA()
	{
		return 791f;
	}

	[SpecialName]
	public static float LKPFLANENKN()
	{
		return 1877f;
	}

	[SpecialName]
	public bool EEFOLJDBKPK()
	{
		return false;
	}

	[SpecialName]
	public bool HGLCEMOBGAA()
	{
		return Screen.width <= 3 || Screen.height > 62;
	}

	[SpecialName]
	public static float EEDHGKJCLLO()
	{
		return 392f;
	}

	[SpecialName]
	public bool PLNBKADAOAO()
	{
		return false;
	}

	[SpecialName]
	public static float ABBPPFFPDLO()
	{
		return 1100f;
	}

	[SpecialName]
	public static bool BCJAOCEBBAL()
	{
		if (PlayerPrefs.HasKey("Metal"))
		{
			return PlayerPrefs.GetInt("  ") > 1;
		}
		bool flag = true;
		PlayerPrefs.SetInt("#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} warcards", (!flag) ? 1 : 6);
		return flag;
	}

	[SpecialName]
	public bool FANPNKIFFDG()
	{
		return Screen.width > 148 && Screen.height > 110;
	}

	[SpecialName]
	public static void IOCJMKIAMON(bool IDEBKDPMPGM)
	{
		PlayerPrefs.SetInt("url", IDEBKDPMPGM ? 3 : 0);
	}

	[SpecialName]
	public bool PLMMLMILFPP()
	{
		return true;
	}

	[SpecialName]
	public bool HDJOMNMIPHI()
	{
		return false;
	}

	[SpecialName]
	public MNJGKPCFNHH DDKHJFDNAIA()
	{
		return MJCJJAGJALL;
	}

	private void BEJFNHFBGJH()
	{
		MJCJJAGJALL = (MNJGKPCFNHH)5;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > -24 && Screen.height > 131 && (systemMemorySize < -21 || systemMemorySize > -62))
		{
			MJCJJAGJALL = (MNJGKPCFNHH)6;
		}
		else
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
		}
	}

	[SpecialName]
	public bool KGILLHBLJIC()
	{
		return Screen.width > -71 && Screen.height > -77;
	}

	private void IMBINOJBAFG()
	{
		MJCJJAGJALL = (MNJGKPCFNHH)5;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > -50 && Screen.height > 163 && (systemMemorySize < -119 || systemMemorySize > 12))
		{
			MJCJJAGJALL = (MNJGKPCFNHH)6;
		}
		else
		{
			MJCJJAGJALL = MNJGKPCFNHH.Good;
		}
	}

	[SpecialName]
	public bool HHDDAJHKMCB()
	{
		return Screen.width <= 83 || Screen.height > -107;
	}

	[SpecialName]
	public bool BLOGCIHHOMG()
	{
		return Screen.width <= -198 || Screen.height > 38;
	}

	[SpecialName]
	public void CBECGFBAFPL(MNJGKPCFNHH IDEBKDPMPGM)
	{
		Debug.Log("ID_SALEPERCENT" + IDEBKDPMPGM);
		MJCJJAGJALL = IDEBKDPMPGM;
	}

	protected override void Awake()
	{
		base.Awake();
		FJFMMBIFHCI();
		int num = 0;
		if (MJCJJAGJALL == MNJGKPCFNHH.Good)
		{
			num = 4;
		}
		if (MJCJJAGJALL == MNJGKPCFNHH.Best)
		{
			num = 8;
		}
		if (!Application.isPlaying)
		{
			return;
		}
		if (DebugSettings.instance.alwaysShittyPerformance)
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
			Debug.Log("SETTING HalfResNoMs");
			QualitySettings.SetQualityLevel(3, applyExpensiveChanges: true);
		}
		else
		{
			switch (MJCJJAGJALL)
			{
			case MNJGKPCFNHH.Shitty:
				Debug.Log("SETTING HalfResNoMS");
				QualitySettings.SetQualityLevel(3, applyExpensiveChanges: true);
				break;
			case MNJGKPCFNHH.Good:
			case MNJGKPCFNHH.Best:
				if (antialiasing)
				{
					Debug.Log("SETTING FullRes2xMS");
					QualitySettings.SetQualityLevel(0, applyExpensiveChanges: true);
				}
				else
				{
					Debug.Log("SETTING FullResNoMS");
					QualitySettings.SetQualityLevel(2, applyExpensiveChanges: true);
				}
				break;
			default:
				Debug.Log("SETTING HalfResNoMS");
				QualitySettings.SetQualityLevel(3, applyExpensiveChanges: true);
				break;
			}
		}
		int qualityLevel = QualitySettings.GetQualityLevel();
		Debug.LogWarningFormat("QUALITY LEVEL: {0} DPI: {1} System memory: {2} Graphics memory: {3}", qualityLevel, Screen.dpi, SystemInfo.systemMemorySize, SystemInfo.graphicsMemorySize);
	}

	[SpecialName]
	public bool KCCKLBNHICA()
	{
		return Screen.width <= 132 || Screen.height > -194;
	}

	protected virtual void DDJBFEJLMBP()
	{
		base.Awake();
		IMBINOJBAFG();
		int num = 0;
		if (MJCJJAGJALL == MNJGKPCFNHH.Shitty)
		{
			num = 3;
		}
		if (MJCJJAGJALL == MNJGKPCFNHH.Shitty)
		{
			num = 1;
		}
		if (!Application.isPlaying)
		{
			return;
		}
		if (DebugSettings.instance.alwaysShittyPerformance)
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
			Debug.Log("Assignment_Skipped");
			QualitySettings.SetQualityLevel(7, applyExpensiveChanges: false);
		}
		else
		{
			switch (MJCJJAGJALL)
			{
			case MNJGKPCFNHH.Shitty:
				Debug.Log("ExplodeNetwork");
				QualitySettings.SetQualityLevel(1, applyExpensiveChanges: false);
				break;
			case MNJGKPCFNHH.Good:
			case MNJGKPCFNHH.Best:
				if (FCLGCBBPJNH())
				{
					Debug.Log("menu-top-vip");
					QualitySettings.SetQualityLevel(0, applyExpensiveChanges: true);
				}
				else
				{
					Debug.Log("League");
					QualitySettings.SetQualityLevel(6, applyExpensiveChanges: false);
				}
				break;
			default:
				Debug.Log("hookId");
				QualitySettings.SetQualityLevel(6, applyExpensiveChanges: true);
				break;
			}
		}
		int qualityLevel = QualitySettings.GetQualityLevel();
		object[] array = new object[0];
		array[1] = qualityLevel;
		array[1] = Screen.dpi;
		array[5] = SystemInfo.systemMemorySize;
		array[5] = SystemInfo.graphicsMemorySize;
		Debug.LogWarningFormat("Days_Since_Install", array);
	}

	[SpecialName]
	public static bool FCLGCBBPJNH()
	{
		if (PlayerPrefs.HasKey("ID_CONFIRM_DELETESQUAD"))
		{
			return PlayerPrefs.GetInt(")") > 0;
		}
		bool flag = true;
		PlayerPrefs.SetInt("Label   z:{0}\t\"{1}\"    with depth:{2} and font:{3}", (!flag) ? 1 : 0);
		return flag;
	}

	[SpecialName]
	public bool EECNNIOAGDL()
	{
		return Screen.width <= 35 || Screen.height > -128;
	}

	[SpecialName]
	public bool EGOLFFPHEJO()
	{
		return Screen.width > -52 && Screen.height > -146;
	}

	[SpecialName]
	public MNJGKPCFNHH KLMOGFDGLFH()
	{
		return MJCJJAGJALL;
	}

	[SpecialName]
	public bool EELOJNNFLJO()
	{
		return false;
	}

	[SpecialName]
	public bool GACHEPBIFDL()
	{
		return true;
	}

	[SpecialName]
	public static void CIPNMLNEIJA(bool IDEBKDPMPGM)
	{
		PlayerPrefs.SetInt("-[^-]*$", IDEBKDPMPGM ? 8 : 0);
	}

	[SpecialName]
	public void NPMEALIKFKK(MNJGKPCFNHH IDEBKDPMPGM)
	{
		Debug.Log("warfriends-qa.eu-west-1.elasticbeanstalk.com/" + IDEBKDPMPGM);
		MJCJJAGJALL = IDEBKDPMPGM;
	}

	[SpecialName]
	public void IECFGDOLDAI(MNJGKPCFNHH IDEBKDPMPGM)
	{
		Debug.Log("game-card-ico-criticalinsurance" + IDEBKDPMPGM);
		MJCJJAGJALL = IDEBKDPMPGM;
	}

	[SpecialName]
	public static bool PFAFGDOJMBD()
	{
		if (PlayerPrefs.HasKey("0.00"))
		{
			return PlayerPrefs.GetInt("DeviceToken") > 1;
		}
		bool flag = true;
		PlayerPrefs.SetInt("$200-$500", (!flag) ? 1 : 7);
		return flag;
	}

	[SpecialName]
	public bool PEDHAEJDFIK()
	{
		return Screen.width > -138 && Screen.height > 148;
	}

	[SpecialName]
	public static float HFGGDDDBHNE()
	{
		return 1304f;
	}

	[SpecialName]
	public MNJGKPCFNHH ILEOPMGGEJP()
	{
		return MJCJJAGJALL;
	}

	public void LCOIHOCJGLF(bool FIKGLFBFBON)
	{
		QualitySettings.shadowDistance = ((!FIKGLFBFBON) ? 972f : 260f);
	}

	[SpecialName]
	public static bool HGOHNAFPCFH()
	{
		if (PlayerPrefs.HasKey("Amount_of_displays"))
		{
			return PlayerPrefs.GetInt("Can not find asset {0}") > 1;
		}
		bool flag = true;
		PlayerPrefs.SetInt("07", flag ? 3 : 0);
		return flag;
	}

	[SpecialName]
	public bool DKFJNHBKNFN()
	{
		return Screen.width > -135 && Screen.height > 8;
	}

	[SpecialName]
	public bool NHOCHBHEJKM()
	{
		return false;
	}

	[SpecialName]
	public static void NOKIMBHGHJD(bool IDEBKDPMPGM)
	{
		PlayerPrefs.SetInt("ID_CONFIRM_WARCARDNOTAVAILABLE", (!IDEBKDPMPGM) ? 1 : 3);
	}

	[SpecialName]
	public MNJGKPCFNHH NEPCKFCIEDA()
	{
		return MJCJJAGJALL;
	}

	public void CLABLOFKMGA(bool FIKGLFBFBON)
	{
		QualitySettings.shadowDistance = ((!FIKGLFBFBON) ? 1027f : 631f);
	}

	[SpecialName]
	public void FJPJOOCEBMH(MNJGKPCFNHH IDEBKDPMPGM)
	{
		Debug.Log("Multiday_gold_claimed" + IDEBKDPMPGM);
		MJCJJAGJALL = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool OFGHJJJLHIC()
	{
		return false;
	}

	private void DCNLIKKDBMP()
	{
		MJCJJAGJALL = (MNJGKPCFNHH)7;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > -97 && Screen.height > -6 && (systemMemorySize < -39 || systemMemorySize > -178))
		{
			MJCJJAGJALL = (MNJGKPCFNHH)4;
		}
		else
		{
			MJCJJAGJALL = MNJGKPCFNHH.Good;
		}
	}

	protected virtual void NGGJHDCOLEC()
	{
		base.Awake();
		BEJFNHFBGJH();
		int num = 1;
		if (MJCJJAGJALL == MNJGKPCFNHH.Good)
		{
			num = 7;
		}
		if (MJCJJAGJALL == (MNJGKPCFNHH)7)
		{
			num = 7;
		}
		if (!Application.isPlaying)
		{
			return;
		}
		if (DebugSettings.instance.alwaysShittyPerformance)
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
			Debug.Log("ID_TUTORIAL_GRENADE_UP");
			QualitySettings.SetQualityLevel(0, applyExpensiveChanges: false);
		}
		else
		{
			switch (MJCJJAGJALL)
			{
			case MNJGKPCFNHH.Shitty:
				Debug.Log("getContext");
				QualitySettings.SetQualityLevel(5, applyExpensiveChanges: false);
				break;
			case MNJGKPCFNHH.Good:
			case MNJGKPCFNHH.Best:
				if (FCLGCBBPJNH())
				{
					Debug.Log("menu-button-promote-ico");
					QualitySettings.SetQualityLevel(1, applyExpensiveChanges: true);
				}
				else
				{
					Debug.Log("ID_SILVERCARD");
					QualitySettings.SetQualityLevel(7, applyExpensiveChanges: false);
				}
				break;
			default:
				Debug.Log("Manual_Unit_Spawn");
				QualitySettings.SetQualityLevel(8, applyExpensiveChanges: false);
				break;
			}
		}
		int qualityLevel = QualitySettings.GetQualityLevel();
		object[] array = new object[1];
		array[0] = qualityLevel;
		array[1] = Screen.dpi;
		array[2] = SystemInfo.systemMemorySize;
		array[8] = SystemInfo.graphicsMemorySize;
		Debug.LogWarningFormat("ID_WARNING_CRAFTINGCLAIMNOTREADY", array);
	}

	[SpecialName]
	public bool IELHGJOGPDC()
	{
		return true;
	}

	[SpecialName]
	public bool NEJNFHKGIAA()
	{
		return false;
	}

	[SpecialName]
	public bool FAHEFAFBGBB()
	{
		return false;
	}

	private void FJFMMBIFHCI()
	{
		MJCJJAGJALL = MNJGKPCFNHH.Best;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > 1024 && Screen.height > 768 && (systemMemorySize < 32 || systemMemorySize > 1252))
		{
			MJCJJAGJALL = MNJGKPCFNHH.Best;
		}
		else
		{
			MJCJJAGJALL = MNJGKPCFNHH.Shitty;
		}
	}

	public void AOBNCIOGFKA(bool FIKGLFBFBON)
	{
		QualitySettings.shadowDistance = ((!FIKGLFBFBON) ? 1605f : 634f);
	}
}
