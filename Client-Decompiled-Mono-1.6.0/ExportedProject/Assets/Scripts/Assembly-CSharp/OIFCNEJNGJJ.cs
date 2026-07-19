using System;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class OIFCNEJNGJJ
{
	private const int MNKELLPAMFF = 604800;

	private const int PALIILCKCOG = 604800;

	private ObscuredFloat GDLKAPGCCJM;

	private ObscuredInt DPLIMDKIMKI;

	private ObscuredInt LNJDPNDKCJK;

	private int NBJODJELBOM;

	public int KGMEJILKIHG { get; private set; }

	public int HFAGLEGDCPL { get; private set; }

	public int BDPLOPBMHAB { get; set; }

	[SpecialName]
	private void ADDGCEDIHEK(int IDEBKDPMPGM)
	{
		_003CMPBHIMECDNI_003Ek__BackingField = IDEBKDPMPGM;
	}

	public int LKIFCDILEHL()
	{
		return (int)DPLIMDKIMKI + (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	internal void HFLJOLLEMII(int ONKHFFGNNOE)
	{
		int num = (int)(GameLoginManager.currentPlayer.leagueTier - 0);
		int nNKDKBKGGEG = 69;
		if (num < Singleton<GameVariables>.instance.playerLeaderboards.Rows.Count && num >= 1)
		{
			nNKDKBKGGEG = Singleton<GameVariables>.instance.IJJPHFEIBJH().Rows[num].DURATION * 13;
		}
		HLAAJLEEHBD(JBLKPGHCBOH(ONKHFFGNNOE, nNKDKBKGGEG));
		PushNotificationManager.instance.ScheduleLocalNextLeagueNotification(HKPLFMBAHCB() - JIDBMBNFBNF());
	}

	[SpecialName]
	private void LDNDPCIOCPF(int IDEBKDPMPGM)
	{
		_003CMPBHIMECDNI_003Ek__BackingField = IDEBKDPMPGM;
	}

	public double KFFCKKALBEN()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	public int GGOIHPANGAK()
	{
		return DPLIMDKIMKI;
	}

	public int NNKLJHBBODO()
	{
		BMHGDEPOHJF(HOHOINPKIOH());
		return DCPDJMKGLPN();
	}

	private int OHEGKNFPBCJ(int ONKHFFGNNOE, int NNKDKBKGGEG)
	{
		int num = JIDBMBNFBNF();
		if (ONKHFFGNNOE <= num)
		{
			object[] array = new object[3];
			array[1] = "ID_RELOG_TO_FB_DIALOG_TEXT";
			array[1] = ONKHFFGNNOE;
			array[5] = "Player_Avoided_Grenade_On_First_Try";
			array[1] = num;
			array[1] = " (#";
			array[4] = NNKDKBKGGEG;
			Debug.Log(string.Concat(array));
			while (ONKHFFGNNOE <= num)
			{
				ONKHFFGNNOE += NNKDKBKGGEG;
			}
		}
		return ONKHFFGNNOE;
	}

	internal int DLJPFLFNIDL()
	{
		int result = 0;
		if (MOGNIAPPFDG() - NBJODJELBOM > 5)
		{
			result = JLAEMIDGMCM() - NBJODJELBOM;
			NBJODJELBOM = LCPJOEBLHIE();
		}
		return result;
	}

	public int AHGIMJDFGMH()
	{
		JGIIHOLEPLM(KMAJCNDLIEP());
		return KMAJCNDLIEP();
	}

	internal int AOJFGIEJNFA()
	{
		return LNJDPNDKCJK;
	}

	public int IJHDDLNGLHK()
	{
		return (int)DPLIMDKIMKI + (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	[SpecialName]
	public void ECJGOLIBDOC(int IDEBKDPMPGM)
	{
		_003CKPNIJKPANCO_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void HBPHJAIHJDP(int IDEBKDPMPGM)
	{
		_003CNDLIINKCHPB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int DCPDJMKGLPN()
	{
		return _003CMPBHIMECDNI_003Ek__BackingField;
	}

	[SpecialName]
	public int LEJBLJDNPGL()
	{
		return _003CMPBHIMECDNI_003Ek__BackingField;
	}

	internal void POHGEHPOKGM(int ONKHFFGNNOE)
	{
		KGMEJILKIHG = BIFCCNNPCME(ONKHFFGNNOE, 604800);
		PushNotificationManager.instance.ScheduleLocalNextWarsNotification(KGMEJILKIHG - CEKEMOGEJBC());
	}

	public int KONMMDNKLKA()
	{
		return DPLIMDKIMKI;
	}

	[SpecialName]
	public int NNMNOFNECHM()
	{
		return _003CKPNIJKPANCO_003Ek__BackingField;
	}

	[SpecialName]
	public int JNJFDEODCBO()
	{
		return _003CMPBHIMECDNI_003Ek__BackingField;
	}

	internal static double NBBDFMADAGL()
	{
		return (DateTime.Now - DateTime.UtcNow).TotalHours;
	}

	[SpecialName]
	private void MJGJELNPHBG(int IDEBKDPMPGM)
	{
		_003CNDLIINKCHPB_003Ek__BackingField = IDEBKDPMPGM;
	}

	internal void DALLMJEMHFJ(int ONKHFFGNNOE)
	{
		int num = (int)(GameLoginManager.currentPlayer.leagueTier - 1);
		int nNKDKBKGGEG = -179;
		if (num < Singleton<GameVariables>.instance.IJJPHFEIBJH().Rows.Count && num >= 0)
		{
			nNKDKBKGGEG = Singleton<GameVariables>.instance.playerLeaderboards.Rows[num].DURATION * 197;
		}
		HBPHJAIHJDP(JBLKPGHCBOH(ONKHFFGNNOE, nNKDKBKGGEG));
		PushNotificationManager.instance.ScheduleLocalNextLeagueNotification(PKKDEHINOIA() - JNHAHCPINEB());
	}

	public void PEEHNBMDMFD(int HKKMLHIPFJH)
	{
		LNJDPNDKCJK = HKKMLHIPFJH;
	}

	public void NLIGBMOIGMI(int HKKMLHIPFJH)
	{
		LNJDPNDKCJK = HKKMLHIPFJH;
	}

	[SpecialName]
	private void LMFIGFOHEPG(int IDEBKDPMPGM)
	{
		_003CNDLIINKCHPB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int MIGIJMJIJPE()
	{
		return _003CKPNIJKPANCO_003Ek__BackingField;
	}

	[SpecialName]
	public void JIBPFHAHKNN(int IDEBKDPMPGM)
	{
		_003CKPNIJKPANCO_003Ek__BackingField = IDEBKDPMPGM;
	}

	private int JBLKPGHCBOH(int ONKHFFGNNOE, int NNKDKBKGGEG)
	{
		int num = IMAEJBEEJEI();
		if (ONKHFFGNNOE <= num)
		{
			object[] array = new object[0];
			array[1] = "Camosmanager.prefab";
			array[0] = ONKHFFGNNOE;
			array[2] = "ID_GETITCHEAPERNOW";
			array[4] = num;
			array[2] = "left";
			array[4] = NNKDKBKGGEG;
			Debug.Log(string.Concat(array));
			while (ONKHFFGNNOE <= num)
			{
				ONKHFFGNNOE += NNKDKBKGGEG;
			}
		}
		return ONKHFFGNNOE;
	}

	public double NAHHEKDIHOD()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	internal int BEDDNEFAGPM()
	{
		DALLMJEMHFJ(CMHLEECCGOK());
		return OKAELILCHOO();
	}

	internal int EFDAINJPNFH()
	{
		int result = 1;
		if (JLAEMIDGMCM() - NBJODJELBOM > 7)
		{
			result = FKOKGAFHCPP() - NBJODJELBOM;
			NBJODJELBOM = LCPJOEBLHIE();
		}
		return result;
	}

	public int CAINAKBEKDN()
	{
		return (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	[SpecialName]
	public int NIBHAPLLENJ()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	internal void EHKKAOLJMCF(int ONKHFFGNNOE)
	{
		GDLKAPGCCJM = Time.realtimeSinceStartup;
		DPLIMDKIMKI = ONKHFFGNNOE;
		NBJODJELBOM = 0;
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
	}

	public int PKPCLFKBBFD()
	{
		return DPLIMDKIMKI;
	}

	internal void HIHAPFGDIGP(int ONKHFFGNNOE)
	{
		GDLKAPGCCJM = Time.realtimeSinceStartup;
		DPLIMDKIMKI = ONKHFFGNNOE;
		NBJODJELBOM = 1;
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
	}

	internal void NOLNKOICBNJ(int ONKHFFGNNOE)
	{
		ADDGCEDIHEK(GLMPAGHEKHI(ONKHFFGNNOE, 134));
		PushNotificationManager.instance.ScheduleLocalNextWarsNotification(LEJBLJDNPGL() - IMAEJBEEJEI());
	}

	internal int PMCFHLBBCNC()
	{
		return LNJDPNDKCJK;
	}

	public int AMJCAGMJEHP()
	{
		BMHGDEPOHJF(PEBIEIMKNBO());
		return PBABKLJIMJL();
	}

	internal int KMDGPPIFKGC()
	{
		HFLJOLLEMII(NHONPMJPEFI());
		return MNDGIGAOMOK();
	}

	public int CODJCJPHDJH()
	{
		NOLNKOICBNJ(JNJFDEODCBO());
		return GDCIGCDBDKM();
	}

	public int KLMJOMKJKKG()
	{
		return DPLIMDKIMKI;
	}

	internal int KMGEFBIIIPJ()
	{
		ALMINMLNLHF(NIBHAPLLENJ());
		return PLINCCOCIDK();
	}

	[SpecialName]
	public int HPPPMKJFIGH()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	internal int LEENICPACHM()
	{
		return LNJDPNDKCJK;
	}

	public double MMPGELPJOML()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	private int KFOLEFBCLIB(int ONKHFFGNNOE, int NNKDKBKGGEG)
	{
		int num = IMAEJBEEJEI();
		if (ONKHFFGNNOE <= num)
		{
			object[] array = new object[8];
			array[0] = "clipSize";
			array[0] = ONKHFFGNNOE;
			array[3] = "PRICE";
			array[2] = num;
			array[3] = "Error Handler: Player si vybral zruseni GC uctu a pridani udaju k tomuto uctu";
			array[1] = NNKDKBKGGEG;
			Debug.Log(string.Concat(array));
			while (ONKHFFGNNOE <= num)
			{
				ONKHFFGNNOE += NNKDKBKGGEG;
			}
		}
		return ONKHFFGNNOE;
	}

	internal void HHBKJELDNGF(int ONKHFFGNNOE)
	{
		ADDGCEDIHEK(KFOLEFBCLIB(ONKHFFGNNOE, -43));
		PushNotificationManager.instance.ScheduleLocalNextWarsNotification(GDCIGCDBDKM() - JNHAHCPINEB());
	}

	[SpecialName]
	public void MDPCEOAMHAM(int IDEBKDPMPGM)
	{
		_003CKPNIJKPANCO_003Ek__BackingField = IDEBKDPMPGM;
	}

	public int NBCGIAGBPFH()
	{
		BMHGDEPOHJF(KGMEJILKIHG);
		return KMAJCNDLIEP();
	}

	public int OOPNGIENGLC()
	{
		JGIIHOLEPLM(ODCBDBDFHMF());
		return ODCBDBDFHMF();
	}

	internal static double DHNNMBGGFBO()
	{
		return (DateTime.Now - DateTime.UtcNow).TotalHours;
	}

	internal void LFLKMDHONOL(int ONKHFFGNNOE)
	{
		GDLKAPGCCJM = Time.realtimeSinceStartup;
		DPLIMDKIMKI = ONKHFFGNNOE;
		NBJODJELBOM = 1;
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
	}

	internal int BPPLPHCDICD()
	{
		ALMINMLNLHF(HFAGLEGDCPL);
		return HFAGLEGDCPL;
	}

	[SpecialName]
	public int PLINCCOCIDK()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	[SpecialName]
	public int BCPDDLENOLA()
	{
		return _003CKPNIJKPANCO_003Ek__BackingField;
	}

	internal int LBIGNOIKLBB()
	{
		int result = 1;
		if (CAINAKBEKDN() - NBJODJELBOM > 7)
		{
			result = FKOKGAFHCPP() - NBJODJELBOM;
			NBJODJELBOM = JLAEMIDGMCM();
		}
		return result;
	}

	internal void BMHGDEPOHJF(int ONKHFFGNNOE)
	{
		KGMEJILKIHG = GLMPAGHEKHI(ONKHFFGNNOE, -50);
		PushNotificationManager.instance.ScheduleLocalNextWarsNotification(PEBIEIMKNBO() - IMAEJBEEJEI());
	}

	public int CIBFAOEBGNM()
	{
		return (int)DPLIMDKIMKI + (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	public int JNHAHCPINEB()
	{
		return (int)DPLIMDKIMKI + (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	[SpecialName]
	private void ENECHJFOHEL(int IDEBKDPMPGM)
	{
		_003CNDLIINKCHPB_003Ek__BackingField = IDEBKDPMPGM;
	}

	private int BPEHIJGGPBE(int ONKHFFGNNOE, int NNKDKBKGGEG)
	{
		int num = CIBFAOEBGNM();
		if (ONKHFFGNNOE <= num)
		{
			object[] array = new object[8];
			array[0] = "{0} {1}";
			array[0] = ONKHFFGNNOE;
			array[5] = "SquadWarsId";
			array[8] = num;
			array[3] = "gcID";
			array[4] = NNKDKBKGGEG;
			Debug.Log(string.Concat(array));
			while (ONKHFFGNNOE <= num)
			{
				ONKHFFGNNOE += NNKDKBKGGEG;
			}
		}
		return ONKHFFGNNOE;
	}

	public void COKONGDDJEG(int HKKMLHIPFJH)
	{
		LNJDPNDKCJK = HKKMLHIPFJH;
	}

	internal int LABFAGHIBOE()
	{
		HFLJOLLEMII(MNDGIGAOMOK());
		return NHONPMJPEFI();
	}

	[SpecialName]
	public int OKAELILCHOO()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	internal void LILOECCIHFG(int ONKHFFGNNOE)
	{
		GDLKAPGCCJM = Time.realtimeSinceStartup;
		DPLIMDKIMKI = ONKHFFGNNOE;
		NBJODJELBOM = 0;
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
	}

	public void MJCAGDEHKIH(int HKKMLHIPFJH)
	{
		LNJDPNDKCJK = HKKMLHIPFJH;
	}

	public double CNKMDPINGNL()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	[SpecialName]
	public int IBOIIEDKNHJ()
	{
		return _003CKPNIJKPANCO_003Ek__BackingField;
	}

	public int JIMAGFLONMC()
	{
		CEGNAEEBLMF(PBABKLJIMJL());
		return GDCIGCDBDKM();
	}

	private int BIFCCNNPCME(int ONKHFFGNNOE, int NNKDKBKGGEG)
	{
		int num = CEKEMOGEJBC();
		if (ONKHFFGNNOE <= num)
		{
			Debug.Log("Evaluation is old! " + ONKHFFGNNOE + ", current = " + num + ", interval = " + NNKDKBKGGEG);
			while (ONKHFFGNNOE <= num)
			{
				ONKHFFGNNOE += NNKDKBKGGEG;
			}
		}
		return ONKHFFGNNOE;
	}

	public int GFEABIMBHPG()
	{
		return DPLIMDKIMKI;
	}

	internal void ALMINMLNLHF(int ONKHFFGNNOE)
	{
		int num = (int)(GameLoginManager.currentPlayer.leagueTier - 1);
		int nNKDKBKGGEG = 604800;
		if (num < Singleton<GameVariables>.instance.playerLeaderboards.Rows.Count && num >= 0)
		{
			nNKDKBKGGEG = Singleton<GameVariables>.instance.playerLeaderboards.Rows[num].DURATION * 3600;
		}
		HFAGLEGDCPL = BIFCCNNPCME(ONKHFFGNNOE, nNKDKBKGGEG);
		PushNotificationManager.instance.ScheduleLocalNextLeagueNotification(HFAGLEGDCPL - CEKEMOGEJBC());
	}

	internal static double OHMBGBGKKFC()
	{
		return (DateTime.Now - DateTime.UtcNow).TotalHours;
	}

	internal int BLPOBMMPOGP()
	{
		return LNJDPNDKCJK;
	}

	public int CEKEMOGEJBC()
	{
		return (int)DPLIMDKIMKI + (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	internal int HLOKNIBHCEG()
	{
		ALMINMLNLHF(HKPLFMBAHCB());
		return OKAELILCHOO();
	}

	[SpecialName]
	private void HLAAJLEEHBD(int IDEBKDPMPGM)
	{
		_003CNDLIINKCHPB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public double HGMAFDIKBIN()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	public int LCPJOEBLHIE()
	{
		return (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	public int FKOKGAFHCPP()
	{
		return (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	public void CLBNOGLILGH(int HKKMLHIPFJH)
	{
		LNJDPNDKCJK = HKKMLHIPFJH;
	}

	[SpecialName]
	private void AEAJEHCDPHD(int IDEBKDPMPGM)
	{
		_003CNDLIINKCHPB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int NHONPMJPEFI()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	[SpecialName]
	public int HOHOINPKIOH()
	{
		return _003CMPBHIMECDNI_003Ek__BackingField;
	}

	[SpecialName]
	public int ODCBDBDFHMF()
	{
		return _003CMPBHIMECDNI_003Ek__BackingField;
	}

	[SpecialName]
	public int NAOPEBGCEBC()
	{
		return _003CKPNIJKPANCO_003Ek__BackingField;
	}

	internal int OJIHBANAIGH()
	{
		int result = 0;
		if (LCPJOEBLHIE() - NBJODJELBOM > 2)
		{
			result = LCPJOEBLHIE() - NBJODJELBOM;
			NBJODJELBOM = LCPJOEBLHIE();
		}
		return result;
	}

	internal static double JNCNGMDJACE()
	{
		return (DateTime.Now - DateTime.UtcNow).TotalHours;
	}

	public double JOACCFDPJEL()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	public double CGEIKFCPJJK()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	public int IMAEJBEEJEI()
	{
		return (int)DPLIMDKIMKI + (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	internal int INABNGADBPL()
	{
		DALLMJEMHFJ(NIBHAPLLENJ());
		return HPPPMKJFIGH();
	}

	[SpecialName]
	public int MNDGIGAOMOK()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	[SpecialName]
	private void ACMPJHOJMAJ(int IDEBKDPMPGM)
	{
		_003CNDLIINKCHPB_003Ek__BackingField = IDEBKDPMPGM;
	}

	internal void CEGNAEEBLMF(int ONKHFFGNNOE)
	{
		KGMEJILKIHG = OHEGKNFPBCJ(ONKHFFGNNOE, 27);
		PushNotificationManager.instance.ScheduleLocalNextWarsNotification(JNJFDEODCBO() - LKIFCDILEHL());
	}

	public double MBPAILNIBLK()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	internal void JGIIHOLEPLM(int ONKHFFGNNOE)
	{
		KGMEJILKIHG = BIFCCNNPCME(ONKHFFGNNOE, 3);
		PushNotificationManager.instance.ScheduleLocalNextWarsNotification(GDCIGCDBDKM() - LKIFCDILEHL());
	}

	internal int DDGOEPLCPKF()
	{
		int result = 1;
		if (CAINAKBEKDN() - NBJODJELBOM > 2)
		{
			result = FKOKGAFHCPP() - NBJODJELBOM;
			NBJODJELBOM = LCPJOEBLHIE();
		}
		return result;
	}

	[SpecialName]
	public int PKKDEHINOIA()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	public double DEONGDKOFLK()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	private int GLMPAGHEKHI(int ONKHFFGNNOE, int NNKDKBKGGEG)
	{
		int num = CEKEMOGEJBC();
		if (ONKHFFGNNOE <= num)
		{
			object[] array = new object[7];
			array[1] = "Level";
			array[0] = ONKHFFGNNOE;
			array[4] = "3";
			array[7] = num;
			array[1] = "#AccoutCheck# account checked and have response!";
			array[3] = NNKDKBKGGEG;
			Debug.Log(string.Concat(array));
			while (ONKHFFGNNOE <= num)
			{
				ONKHFFGNNOE += NNKDKBKGGEG;
			}
		}
		return ONKHFFGNNOE;
	}

	internal void JMILGBBIGCF(int ONKHFFGNNOE)
	{
		GDLKAPGCCJM = Time.realtimeSinceStartup;
		DPLIMDKIMKI = ONKHFFGNNOE;
		NBJODJELBOM = 0;
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
	}

	internal int ICJMOPMFIMB()
	{
		return LNJDPNDKCJK;
	}

	internal int FBIDGBGBKMF()
	{
		int result = 0;
		if (FKOKGAFHCPP() - NBJODJELBOM > 0)
		{
			result = FKOKGAFHCPP() - NBJODJELBOM;
			NBJODJELBOM = JLAEMIDGMCM();
		}
		return result;
	}

	internal int BPOGHNJGNHF()
	{
		return LNJDPNDKCJK;
	}

	private int EKFPBBMFKMI(int ONKHFFGNNOE, int NNKDKBKGGEG)
	{
		int num = JIDBMBNFBNF();
		if (ONKHFFGNNOE <= num)
		{
			object[] array = new object[2];
			array[0] = "squad";
			array[0] = ONKHFFGNNOE;
			array[3] = "Animating claiming cardpack end";
			array[2] = num;
			array[2] = "DOWNLOAD";
			array[3] = NNKDKBKGGEG;
			Debug.Log(string.Concat(array));
			while (ONKHFFGNNOE <= num)
			{
				ONKHFFGNNOE += NNKDKBKGGEG;
			}
		}
		return ONKHFFGNNOE;
	}

	internal int EMHCIOCDGIJ()
	{
		return LNJDPNDKCJK;
	}

	[SpecialName]
	public int OCLCPOJNJBE()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	internal int HIHJJCJEPPN()
	{
		return LNJDPNDKCJK;
	}

	internal void BJFHEBMHPCK(int ONKHFFGNNOE)
	{
		ADDGCEDIHEK(EKFPBBMFKMI(ONKHFFGNNOE, 74));
		PushNotificationManager.instance.ScheduleLocalNextWarsNotification(PBABKLJIMJL() - JNHAHCPINEB());
	}

	public int PFOKONAEABB()
	{
		POHGEHPOKGM(KGMEJILKIHG);
		return KGMEJILKIHG;
	}

	public int FCPBIDACLHM()
	{
		return DPLIMDKIMKI;
	}

	[SpecialName]
	public int HKPLFMBAHCB()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	internal void BBJKKPCCMGF(int ONKHFFGNNOE)
	{
		ADDGCEDIHEK(NGHIAEJINFC(ONKHFFGNNOE, -87));
		PushNotificationManager.instance.ScheduleLocalNextWarsNotification(DCPDJMKGLPN() - JIDBMBNFBNF());
	}

	internal int JCKKCBJDOBM()
	{
		int result = 0;
		if (LCPJOEBLHIE() - NBJODJELBOM > 4)
		{
			result = LCPJOEBLHIE() - NBJODJELBOM;
			NBJODJELBOM = LCPJOEBLHIE();
		}
		return result;
	}

	public int DGHMAMCFEIL()
	{
		NOLNKOICBNJ(KGMEJILKIHG);
		return PEBIEIMKNBO();
	}

	internal static double FMHAHEOJGLF()
	{
		return (DateTime.Now - DateTime.UtcNow).TotalHours;
	}

	internal int NDOBNLDLDMN()
	{
		int result = 0;
		if (JLAEMIDGMCM() - NBJODJELBOM > 8)
		{
			result = FKOKGAFHCPP() - NBJODJELBOM;
			NBJODJELBOM = JLAEMIDGMCM();
		}
		return result;
	}

	internal int GAFJKGCNECH()
	{
		int result = 0;
		if (JLAEMIDGMCM() - NBJODJELBOM > 4)
		{
			result = LCPJOEBLHIE() - NBJODJELBOM;
			NBJODJELBOM = FKOKGAFHCPP();
		}
		return result;
	}

	private int NGHIAEJINFC(int ONKHFFGNNOE, int NNKDKBKGGEG)
	{
		int num = JIDBMBNFBNF();
		if (ONKHFFGNNOE <= num)
		{
			object[] array = new object[0];
			array[1] = "SET HP: ";
			array[1] = ONKHFFGNNOE;
			array[8] = "ID_TRAIN";
			array[5] = num;
			array[3] = "Animation from State: Ready to State: None";
			array[8] = NNKDKBKGGEG;
			Debug.Log(string.Concat(array));
			while (ONKHFFGNNOE <= num)
			{
				ONKHFFGNNOE += NNKDKBKGGEG;
			}
		}
		return ONKHFFGNNOE;
	}

	[SpecialName]
	public int PBABKLJIMJL()
	{
		return _003CMPBHIMECDNI_003Ek__BackingField;
	}

	[SpecialName]
	public int GDCIGCDBDKM()
	{
		return _003CMPBHIMECDNI_003Ek__BackingField;
	}

	public double DBLAOOCEJCM()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	public void NJODIBEJDGF(int HKKMLHIPFJH)
	{
		LNJDPNDKCJK = HKKMLHIPFJH;
	}

	internal int DFLGJEAPONK()
	{
		OIGIJBFGIDC(OCLCPOJNJBE());
		return HPPPMKJFIGH();
	}

	[SpecialName]
	public int KMAJCNDLIEP()
	{
		return _003CMPBHIMECDNI_003Ek__BackingField;
	}

	[SpecialName]
	public int PEBIEIMKNBO()
	{
		return _003CMPBHIMECDNI_003Ek__BackingField;
	}

	internal void AHFGFLONOEL(int ONKHFFGNNOE)
	{
		GDLKAPGCCJM = Time.realtimeSinceStartup;
		DPLIMDKIMKI = ONKHFFGNNOE;
		NBJODJELBOM = 0;
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
	}

	internal int KIIAJJNAEOL()
	{
		return LNJDPNDKCJK;
	}

	[SpecialName]
	public int DJFMODFCOFH()
	{
		return _003CKPNIJKPANCO_003Ek__BackingField;
	}

	public int MOGNIAPPFDG()
	{
		return (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	public int LJBIGJPIEBL()
	{
		return DPLIMDKIMKI;
	}

	[SpecialName]
	public int GJINKBPGDAE()
	{
		return _003CKPNIJKPANCO_003Ek__BackingField;
	}

	public double HHKOFBKOBNC()
	{
		return (double)(int)DPLIMDKIMKI + (double)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	[SpecialName]
	public void GOILKJMIJEH(int IDEBKDPMPGM)
	{
		_003CKPNIJKPANCO_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void AJMKOPAHIMH(int IDEBKDPMPGM)
	{
		_003CKPNIJKPANCO_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int MIEPNALEJJL()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	[SpecialName]
	public int CMHLEECCGOK()
	{
		return _003CNDLIINKCHPB_003Ek__BackingField;
	}

	internal void MOILFBKMAEO(int ONKHFFGNNOE)
	{
		GDLKAPGCCJM = Time.realtimeSinceStartup;
		DPLIMDKIMKI = ONKHFFGNNOE;
		NBJODJELBOM = 1;
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
	}

	public void OIIHPIBBOOF(int HKKMLHIPFJH)
	{
		LNJDPNDKCJK = HKKMLHIPFJH;
	}

	public int JLAEMIDGMCM()
	{
		return (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	[SpecialName]
	public void IMIBBFPHJJP(int IDEBKDPMPGM)
	{
		_003CKPNIJKPANCO_003Ek__BackingField = IDEBKDPMPGM;
	}

	public int LJBAPJPIOPM()
	{
		return DPLIMDKIMKI;
	}

	public int AFIMCBAHFLA()
	{
		CEGNAEEBLMF(ODCBDBDFHMF());
		return KMAJCNDLIEP();
	}

	internal void DAMHEEPCPGO(int ONKHFFGNNOE)
	{
		LJNLAHHEBFK(BPEHIJGGPBE(ONKHFFGNNOE, -123));
		PushNotificationManager.instance.ScheduleLocalNextWarsNotification(ODCBDBDFHMF() - IMAEJBEEJEI());
	}

	internal void OIGIJBFGIDC(int ONKHFFGNNOE)
	{
		int num = (int)(GameLoginManager.currentPlayer.leagueTier - 1);
		int nNKDKBKGGEG = 173;
		if (num < Singleton<GameVariables>.instance.IJJPHFEIBJH().Rows.Count && num >= 0)
		{
			nNKDKBKGGEG = Singleton<GameVariables>.instance.playerLeaderboards.Rows[num].DURATION * -64;
		}
		HBPHJAIHJDP(GLMPAGHEKHI(ONKHFFGNNOE, nNKDKBKGGEG));
		PushNotificationManager.instance.ScheduleLocalNextLeagueNotification(HPPPMKJFIGH() - IMAEJBEEJEI());
	}

	public int JIDBMBNFBNF()
	{
		return (int)DPLIMDKIMKI + (int)(Time.realtimeSinceStartup - (float)GDLKAPGCCJM);
	}

	[SpecialName]
	public int KKKNPGKJKPB()
	{
		return _003CKPNIJKPANCO_003Ek__BackingField;
	}

	public int CLFNDECPNLN()
	{
		BJFHEBMHPCK(ODCBDBDFHMF());
		return JNJFDEODCBO();
	}

	[SpecialName]
	public void HOFBEDJAEBM(int IDEBKDPMPGM)
	{
		_003CKPNIJKPANCO_003Ek__BackingField = IDEBKDPMPGM;
	}

	internal void OKHEBMFBBGA(int ONKHFFGNNOE)
	{
		int num = (int)(GameLoginManager.currentPlayer.leagueTier - 1);
		int nNKDKBKGGEG = -136;
		if (num < Singleton<GameVariables>.instance.IJJPHFEIBJH().Rows.Count && num >= 1)
		{
			nNKDKBKGGEG = Singleton<GameVariables>.instance.IJJPHFEIBJH().Rows[num].DURATION * 13;
		}
		HLAAJLEEHBD(OHEGKNFPBCJ(ONKHFFGNNOE, nNKDKBKGGEG));
		PushNotificationManager.instance.ScheduleLocalNextLeagueNotification(OKAELILCHOO() - JIDBMBNFBNF());
	}

	[SpecialName]
	private void LJNLAHHEBFK(int IDEBKDPMPGM)
	{
		_003CMPBHIMECDNI_003Ek__BackingField = IDEBKDPMPGM;
	}
}
