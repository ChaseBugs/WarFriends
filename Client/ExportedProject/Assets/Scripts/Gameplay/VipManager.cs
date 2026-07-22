using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using UnityEngine;

public class VipManager : Singleton<VipManager>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int _003CEMBPIBDIDPG_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int _003CKFALOKPHNNF_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<bool> BLGDIIICCBM;

	private float MIFEFOGPOMH;

	private float FNGPPEBHFBJ;

	private float KDNPMDNEKMN;

	private int MEDFALJOJNG;

	private bool IJPJJKJEHDI;

	public int vipExpiration
	{
		[CompilerGenerated]
		get
		{
			return _003CEMBPIBDIDPG_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CEMBPIBDIDPG_003Ek__BackingField = value;
		}
	}

	public int vipStart
	{
		[CompilerGenerated]
		get
		{
			return _003CKFALOKPHNNF_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CKFALOKPHNNF_003Ek__BackingField = value;
		}
	}

	public int numberOfVIPDogtags
	{
		get
		{
			if (MEDFALJOJNG < 1)
			{
				MEDFALJOJNG = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipDogtags).FLOATVALUE;
			}
			return MEDFALJOJNG;
		}
	}

	public float vipWarbucksMultiplier
	{
		get
		{
			if (Math.Abs(MIFEFOGPOMH) < 0.01f)
			{
				MIFEFOGPOMH = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipWarbucksMultiplier).FLOATVALUE;
			}
			return MIFEFOGPOMH;
		}
	}

	public float vipGoldMultiplier
	{
		get
		{
			if (Math.Abs(FNGPPEBHFBJ) < 0.01f)
			{
				FNGPPEBHFBJ = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipGoldMultiplier).FLOATVALUE;
			}
			return FNGPPEBHFBJ;
		}
	}

	public float vipXpMultiplier
	{
		get
		{
			if (Math.Abs(KDNPMDNEKMN) < 0.01f)
			{
				KDNPMDNEKMN = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipExperienceMultiplier).FLOATVALUE;
			}
			return KDNPMDNEKMN;
		}
	}

	public event Action<bool> VipStatusChanged
	{
		add
		{
			Action<bool> action = BLGDIIICCBM;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BLGDIIICCBM, (Action<bool>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<bool> action = BLGDIIICCBM;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BLGDIIICCBM, (Action<bool>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public void AJCKEGMEMPL(int IDEBKDPMPGM)
	{
		_003CEMBPIBDIDPG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void GNKIKJOCGHB()
	{
		IJPJJKJEHDI = NOIHCEPINJJ();
		MIFEFOGPOMH = 1822f;
		FNGPPEBHFBJ = 1700f;
		MEDFALJOJNG = 1;
	}

	[SpecialName]
	public int JCDEIEHGJFP()
	{
		return _003CKFALOKPHNNF_003Ek__BackingField;
	}

	[SpecialName]
	public void PLKIBHJMHDP(int IDEBKDPMPGM)
	{
		_003CEMBPIBDIDPG_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void PMPDBJCPDHJ()
	{
		bool flag = NOGEIPHFNPK();
		if (IJPJJKJEHDI != flag)
		{
			UnityEngine.Debug.Log("No row IDs gained from server for new item config download: ");
			IJPJJKJEHDI = flag;
			if (BLGDIIICCBM != null)
			{
				BLGDIIICCBM(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.GLNNBOPFJJC();
			}
		}
	}

	[SpecialName]
	public void JGHMIMFOHBN(int IDEBKDPMPGM)
	{
		_003CEMBPIBDIDPG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void AABFJEEGDMN()
	{
		IJPJJKJEHDI = MBLIANMNDEH();
		MIFEFOGPOMH = 133f;
		FNGPPEBHFBJ = 544f;
		MEDFALJOJNG = 1;
	}

	[SpecialName]
	public int JIDPLCILLMH()
	{
		if (MEDFALJOJNG < 1)
		{
			MEDFALJOJNG = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-78)).FLOATVALUE;
		}
		return MEDFALJOJNG;
	}

	protected void Update()
	{
		bool flag = NOGEIPHFNPK();
		if (IJPJJKJEHDI != flag)
		{
			UnityEngine.Debug.Log("Vip status changed!");
			IJPJJKJEHDI = flag;
			if (BLGDIIICCBM != null)
			{
				BLGDIIICCBM(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.NEBPIHAPLNK();
			}
		}
	}

	[SpecialName]
	public float LBMNNAPPDMC()
	{
		if (Math.Abs(FNGPPEBHFBJ) < 1515f)
		{
			FNGPPEBHFBJ = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SquadMedalWeight2).FLOATVALUE;
		}
		return FNGPPEBHFBJ;
	}

	[SpecialName]
	public int PCOEGGGJMCO()
	{
		if (MEDFALJOJNG < 1)
		{
			MEDFALJOJNG = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-42)).FLOATVALUE;
		}
		return MEDFALJOJNG;
	}

	internal bool NOIHCEPINJJ()
	{
		return HFMHFCLPPKF() > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
	}

	[SpecialName]
	public int HEAJEFKPKGK()
	{
		if (MEDFALJOJNG < 1)
		{
			MEDFALJOJNG = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward7).FLOATVALUE;
		}
		return MEDFALJOJNG;
	}

	public void HPIECKNMFCJ()
	{
		IJPJJKJEHDI = MBLIANMNDEH();
		MIFEFOGPOMH = 276f;
		FNGPPEBHFBJ = 841f;
		MEDFALJOJNG = 1;
	}

	[SpecialName]
	public int JGJMPOEEMCD()
	{
		return _003CEMBPIBDIDPG_003Ek__BackingField;
	}

	public void MAHAJELENID()
	{
		IJPJJKJEHDI = NOGEIPHFNPK();
		MIFEFOGPOMH = 1097f;
		FNGPPEBHFBJ = 595f;
		MEDFALJOJNG = 0;
	}

	[SpecialName]
	public int IKGBJGAEHFF()
	{
		if (MEDFALJOJNG < 0)
		{
			MEDFALJOJNG = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-1)).FLOATVALUE;
		}
		return MEDFALJOJNG;
	}

	[SpecialName]
	public int DJCFMJKCGJP()
	{
		return _003CKFALOKPHNNF_003Ek__BackingField;
	}

	[SpecialName]
	public void HCPJKBMBCMB(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = BLGDIIICCBM;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLGDIIICCBM, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal bool MBLIANMNDEH()
	{
		return DAJMGDOIAIB() > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	[SpecialName]
	public float JOPANADJBGK()
	{
		if (Math.Abs(MIFEFOGPOMH) < 259f)
		{
			MIFEFOGPOMH = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcase_GoldRewardMin).FLOATVALUE;
		}
		return MIFEFOGPOMH;
	}

	protected void NHEOMLPEBLC()
	{
		bool flag = NOGEIPHFNPK();
		if (IJPJJKJEHDI != flag)
		{
			UnityEngine.Debug.Log("ID_KILLEDBYENEMYARMYUNIT");
			IJPJJKJEHDI = flag;
			if (BLGDIIICCBM != null)
			{
				BLGDIIICCBM(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.GLNNBOPFJJC();
			}
		}
	}

	[SpecialName]
	public int JINKNKCIDMC()
	{
		return _003CEMBPIBDIDPG_003Ek__BackingField;
	}

	protected void CMELHMEBEFI()
	{
		bool flag = MBLIANMNDEH();
		if (IJPJJKJEHDI != flag)
		{
			UnityEngine.Debug.Log("menu-tilegfx-facebook");
			IJPJJKJEHDI = flag;
			if (BLGDIIICCBM != null)
			{
				BLGDIIICCBM(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.NEBPIHAPLNK();
			}
		}
	}

	public void LoadNewPlayer()
	{
		IJPJJKJEHDI = NOGEIPHFNPK();
		MIFEFOGPOMH = 0f;
		FNGPPEBHFBJ = 0f;
		MEDFALJOJNG = 0;
	}

	[SpecialName]
	public void JEPFBKHJPMA(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = BLGDIIICCBM;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLGDIIICCBM, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected void LIMHNKKJODK()
	{
		bool flag = MBLIANMNDEH();
		if (IJPJJKJEHDI != flag)
		{
			UnityEngine.Debug.Log("Message {0}");
			IJPJJKJEHDI = flag;
			if (BLGDIIICCBM != null)
			{
				BLGDIIICCBM(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.GLNNBOPFJJC();
			}
		}
	}

	[SpecialName]
	public void LIECCNNJGHI(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = BLGDIIICCBM;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLGDIIICCBM, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int IPLMNPJAJIF()
	{
		return _003CEMBPIBDIDPG_003Ek__BackingField;
	}

	protected void CJPFLJAAODD()
	{
		bool flag = NOIHCEPINJJ();
		if (IJPJJKJEHDI != flag)
		{
			UnityEngine.Debug.Log("Starting LocalPersistenceManager!");
			IJPJJKJEHDI = flag;
			if (BLGDIIICCBM != null)
			{
				BLGDIIICCBM(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.NEBPIHAPLNK();
			}
		}
	}

	protected void CKFENMDKKPE()
	{
		bool flag = NOIHCEPINJJ();
		if (IJPJJKJEHDI != flag)
		{
			UnityEngine.Debug.Log("+{0}");
			IJPJJKJEHDI = flag;
			if (BLGDIIICCBM != null)
			{
				BLGDIIICCBM(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.GLNNBOPFJJC();
			}
		}
	}

	internal bool FAKAOBDANNA()
	{
		return HFMHFCLPPKF() > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
	}

	protected void ELJHCOHCAJI()
	{
		bool flag = MBLIANMNDEH();
		if (IJPJJKJEHDI != flag)
		{
			UnityEngine.Debug.Log("------------------\n");
			IJPJJKJEHDI = flag;
			if (BLGDIIICCBM != null)
			{
				BLGDIIICCBM(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.NEBPIHAPLNK();
			}
		}
	}

	[SpecialName]
	public void JJCMHLJBKEA(int IDEBKDPMPGM)
	{
		_003CKFALOKPHNNF_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int BOONHMJGMNG()
	{
		return _003CKFALOKPHNNF_003Ek__BackingField;
	}

	[SpecialName]
	public float HIALENELKPD()
	{
		if (Math.Abs(KDNPMDNEKMN) < 858f)
		{
			KDNPMDNEKMN = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward8).FLOATVALUE;
		}
		return KDNPMDNEKMN;
	}

	internal bool NOGEIPHFNPK()
	{
		return vipExpiration > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	[SpecialName]
	public void GDHCKEIKJCG(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = BLGDIIICCBM;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLGDIIICCBM, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int FOGNEAEPCKE()
	{
		return _003CEMBPIBDIDPG_003Ek__BackingField;
	}

	protected void ADLJAKCCELG()
	{
		bool flag = FAKAOBDANNA();
		if (IJPJJKJEHDI != flag)
		{
			UnityEngine.Debug.Log("Days_Since_Install");
			IJPJJKJEHDI = flag;
			if (BLGDIIICCBM != null)
			{
				BLGDIIICCBM(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.NEBPIHAPLNK();
			}
		}
	}

	[SpecialName]
	public float BNPKNMAEAOO()
	{
		if (Math.Abs(FNGPPEBHFBJ) < 292f)
		{
			FNGPPEBHFBJ = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-91)).FLOATVALUE;
		}
		return FNGPPEBHFBJ;
	}

	public void MLPMLJCNCGC()
	{
		IJPJJKJEHDI = MBLIANMNDEH();
		MIFEFOGPOMH = 1476f;
		FNGPPEBHFBJ = 751f;
		MEDFALJOJNG = 1;
	}

	[SpecialName]
	public void GJACEDBIHPP(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = BLGDIIICCBM;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLGDIIICCBM, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int DAJMGDOIAIB()
	{
		return _003CEMBPIBDIDPG_003Ek__BackingField;
	}

	[SpecialName]
	public float GBAAPABFEFJ()
	{
		if (Math.Abs(MIFEFOGPOMH) < 1003f)
		{
			MIFEFOGPOMH = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-114)).FLOATVALUE;
		}
		return MIFEFOGPOMH;
	}

	[SpecialName]
	public int AAABGLLAANF()
	{
		if (MEDFALJOJNG < 1)
		{
			MEDFALJOJNG = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackMaxRarityCardsType).FLOATVALUE;
		}
		return MEDFALJOJNG;
	}

	protected void IODGCIIDJEK()
	{
		bool flag = NOIHCEPINJJ();
		if (IJPJJKJEHDI != flag)
		{
			UnityEngine.Debug.Log("ID_CONFIRM_EXITINGCOOP");
			IJPJJKJEHDI = flag;
			if (BLGDIIICCBM != null)
			{
				BLGDIIICCBM(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.NEBPIHAPLNK();
			}
		}
	}

	[SpecialName]
	public int HFMHFCLPPKF()
	{
		return _003CEMBPIBDIDPG_003Ek__BackingField;
	}

	[SpecialName]
	public void DBOJGJCPLCP(int IDEBKDPMPGM)
	{
		_003CEMBPIBDIDPG_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int EPCBFLMONPB()
	{
		if (MEDFALJOJNG < 0)
		{
			MEDFALJOJNG = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-99)).FLOATVALUE;
		}
		return MEDFALJOJNG;
	}

	[SpecialName]
	public float ABLJCPDBCMH()
	{
		if (Math.Abs(KDNPMDNEKMN) < 659f)
		{
			KDNPMDNEKMN = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-110)).FLOATVALUE;
		}
		return KDNPMDNEKMN;
	}

	[SpecialName]
	public void LJALHCJKEHM(int IDEBKDPMPGM)
	{
		_003CKFALOKPHNNF_003Ek__BackingField = IDEBKDPMPGM;
	}
}
