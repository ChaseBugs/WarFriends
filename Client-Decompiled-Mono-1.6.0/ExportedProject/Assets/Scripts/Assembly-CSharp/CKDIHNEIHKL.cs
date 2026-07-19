using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class CKDIHNEIHKL
{
	public enum ICDOJKMJFKM
	{
		Connected = 0,
		Disconnected = 1
	}

	public enum GLFPILGCAPM
	{
		ConnectingToPhoton = 0,
		Connected = 1,
		CardsChosen = 2,
		GameLoading = 3,
		LoadingFinished = 4,
		Playing = 5,
		GameFinished = 6,
		Rematch = 7
	}

	private ICDOJKMJFKM CJNJHAJDJJP;

	private ICDOJKMJFKM EMLNLJIMGLG;

	private GLFPILGCAPM ILHNFHOFLCM;

	private bool KFODAEBPJCG;

	private bool FCAIAJGFGIK;

	public PlayerController HNFNINFCBEJ { get; private set; }

	public bool DFKBPAGFPKB
	{
		get
		{
			bool flag = HNFNINFCBEJ.isCurrentPlayer && CBJIOJOLFBJ.LDENAKPAIBL == NetworkReachability.NotReachable;
			if (flag != FCAIAJGFGIK)
			{
				FCAIAJGFGIK = flag;
				Debug.Log(string.Format("Internet off: {0} {1}", flag, DateTime.UtcNow));
			}
			return flag;
		}
	}

	public bool NHMNBNGPOGJ
	{
		get
		{
			return DFKBPAGFPKB || LEOEPDNAONM == ICDOJKMJFKM.Disconnected;
		}
	}

	public bool AJADIICCLHO
	{
		get
		{
			return KFODAEBPJCG;
		}
		set
		{
			KFODAEBPJCG = value;
		}
	}

	public int HAJHEIBNMJF { get; set; }

	public bool EIPHAAGCHCP { get; set; }

	public bool LFBKPCIODNO
	{
		get
		{
			return CJNJHAJDJJP == ICDOJKMJFKM.Connected && EHFIJJBPEEG >= GLFPILGCAPM.GameFinished;
		}
	}

	public int EPNLKGPLBEN { get; private set; }

	public int GNACLALEPDB { get; set; }

	public GLFPILGCAPM EHFIJJBPEEG
	{
		get
		{
			return ILHNFHOFLCM;
		}
		set
		{
			ILHNFHOFLCM = value;
			Debug.Log(string.Format("Player match state {0} to player {1}", ILHNFHOFLCM, HNFNINFCBEJ.name));
			if (CKDIHNEIHKL.KMKIKLKOALI != null)
			{
				CKDIHNEIHKL.KMKIKLKOALI(ILHNFHOFLCM, HNFNINFCBEJ);
			}
		}
	}

	public ICDOJKMJFKM LEOEPDNAONM
	{
		get
		{
			return CJNJHAJDJJP;
		}
		set
		{
			if (CJNJHAJDJJP != value)
			{
				EMLNLJIMGLG = CJNJHAJDJJP;
				CJNJHAJDJJP = value;
				Debug.Log(string.Format("Player connectionState {0} to player {1}", CJNJHAJDJJP, HNFNINFCBEJ.name));
				if (value == ICDOJKMJFKM.Disconnected)
				{
					EPNLKGPLBEN++;
				}
			}
		}
	}

	public static event Action<GLFPILGCAPM, PlayerController> KMKIKLKOALI;

	[SpecialName]
	public ICDOJKMJFKM NLLLKGDIALC()
	{
		return CJNJHAJDJJP;
	}

	[SpecialName]
	public int LACOLMPHDMP()
	{
		return _003CPMMCDEFMDBP_003Ek__BackingField;
	}

	[SpecialName]
	public bool JGIFJADOLGO()
	{
		return _003CCPPMNOHHAAK_003Ek__BackingField;
	}

	[SpecialName]
	public bool ECJNMCMBHFF()
	{
		bool flag = CJIFJGHMEFI().isCurrentPlayer && CBJIOJOLFBJ.OIKLEGPDODA() == NetworkReachability.ReachableViaCarrierDataNetwork;
		if (flag != FCAIAJGFGIK)
		{
			FCAIAJGFGIK = flag;
			Debug.Log(string.Format("WarFriends", flag, DateTime.UtcNow));
		}
		return flag;
	}

	[SpecialName]
	public bool NAHCAGLIFAK()
	{
		return KFODAEBPJCG;
	}

	[SpecialName]
	public bool NOKOMEHKFNO()
	{
		return _003CCPPMNOHHAAK_003Ek__BackingField;
	}

	[SpecialName]
	public void IJLKGKEPADD(int IDEBKDPMPGM)
	{
		_003CAHOOHOFKLNC_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool CDEIBAPPKKP()
	{
		return CJNJHAJDJJP != ICDOJKMJFKM.Connected || MJJBHNOMDOI() < GLFPILGCAPM.GameLoading;
	}

	public void CGCDHGHDLDB()
	{
		JJHFKEGEFBO(OEKGGHBMJBH() + 1);
	}

	[SpecialName]
	public bool NNAPBLFCOLA()
	{
		return CJNJHAJDJJP == ICDOJKMJFKM.Connected && CJJLIKCIBLO() >= GLFPILGCAPM.ConnectingToPhoton;
	}

	[SpecialName]
	public void PPDNINOMMKK(GLFPILGCAPM IDEBKDPMPGM)
	{
		ILHNFHOFLCM = IDEBKDPMPGM;
		Debug.Log(string.Format("ShotFrequencyMax", ILHNFHOFLCM, CJIFJGHMEFI().name));
		if (CKDIHNEIHKL.KMKIKLKOALI != null)
		{
			CKDIHNEIHKL.KMKIKLKOALI(ILHNFHOFLCM, CJIFJGHMEFI());
		}
	}

	[SpecialName]
	public int PKHNOCFAEPH()
	{
		return _003CKNBOKMGIKIH_003Ek__BackingField;
	}

	[SpecialName]
	public int AHKGMKHNLCO()
	{
		return _003CKNBOKMGIKIH_003Ek__BackingField;
	}

	[SpecialName]
	public ICDOJKMJFKM MMPMPFDCMCA()
	{
		return CJNJHAJDJJP;
	}

	[SpecialName]
	public ICDOJKMJFKM MLHKMDALIMH()
	{
		return CJNJHAJDJJP;
	}

	[SpecialName]
	public void CJJGIMPKDIB(int IDEBKDPMPGM)
	{
		_003CAHOOHOFKLNC_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool JIDBMKHKOOA()
	{
		bool flag = CJIFJGHMEFI().isCurrentPlayer && CBJIOJOLFBJ.OIKLEGPDODA() == NetworkReachability.ReachableViaCarrierDataNetwork;
		if (flag != FCAIAJGFGIK)
		{
			FCAIAJGFGIK = flag;
			Debug.Log(string.Format("ID_GOLDENSUITCASE", flag, DateTime.UtcNow));
		}
		return flag;
	}

	[SpecialName]
	public bool KAOBMNDDCHJ()
	{
		return _003CCPPMNOHHAAK_003Ek__BackingField;
	}

	[SpecialName]
	public static void CIEMJIFEDGJ(Action<GLFPILGCAPM, PlayerController> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM, PlayerController> action = CKDIHNEIHKL.KMKIKLKOALI;
		Action<GLFPILGCAPM, PlayerController> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CKDIHNEIHKL.KMKIKLKOALI, (Action<GLFPILGCAPM, PlayerController>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool DDKALPEGJCM()
	{
		bool flag = KPIIAPDNOJB().isCurrentPlayer && CBJIOJOLFBJ.LDENAKPAIBL == NetworkReachability.ReachableViaCarrierDataNetwork;
		if (flag != FCAIAJGFGIK)
		{
			FCAIAJGFGIK = flag;
			Debug.Log(string.Format("ID_CONFIRM_SQUADFULL", flag, DateTime.UtcNow));
		}
		return flag;
	}

	[SpecialName]
	public int MEPHEOFBNEI()
	{
		return _003CKNBOKMGIKIH_003Ek__BackingField;
	}

	[SpecialName]
	public bool BALCAFMGHOG()
	{
		bool flag = !CJIFJGHMEFI().isCurrentPlayer || CBJIOJOLFBJ.OCOKJKGAGKI() == NetworkReachability.NotReachable;
		if (flag != FCAIAJGFGIK)
		{
			FCAIAJGFGIK = flag;
			Debug.Log(string.Format("Have discount {0} to upgrade {1}", flag, DateTime.UtcNow));
		}
		return flag;
	}

	[SpecialName]
	public void PGLLAHOGJBJ(bool IDEBKDPMPGM)
	{
		_003CCPPMNOHHAAK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void BDGAFCBKIKI(GLFPILGCAPM IDEBKDPMPGM)
	{
		ILHNFHOFLCM = IDEBKDPMPGM;
		Debug.Log(string.Format("AmmoPool", ILHNFHOFLCM, CACCABLDNHF().name));
		if (CKDIHNEIHKL.KMKIKLKOALI != null)
		{
			CKDIHNEIHKL.KMKIKLKOALI(ILHNFHOFLCM, CACCABLDNHF());
		}
	}

	[SpecialName]
	public int JIAMHKJPNLI()
	{
		return _003CKNBOKMGIKIH_003Ek__BackingField;
	}

	[SpecialName]
	public void MLKANICNIOF(ICDOJKMJFKM IDEBKDPMPGM)
	{
		if (CJNJHAJDJJP != IDEBKDPMPGM)
		{
			EMLNLJIMGLG = CJNJHAJDJJP;
			CJNJHAJDJJP = IDEBKDPMPGM;
			Debug.Log(string.Format("REWARD CARDPACK: ", CJNJHAJDJJP, CACCABLDNHF().name));
			if (IDEBKDPMPGM == ICDOJKMJFKM.Connected)
			{
				KPKFEOBGCDD(OEKGGHBMJBH() + 0);
			}
		}
	}

	[SpecialName]
	public void BFDDIOPPNIL(bool IDEBKDPMPGM)
	{
		_003CCPPMNOHHAAK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void APKDGLNPHAG(bool IDEBKDPMPGM)
	{
		KFODAEBPJCG = IDEBKDPMPGM;
	}

	public CKDIHNEIHKL(PlayerController HNFNINFCBEJ)
	{
		this.HNFNINFCBEJ = HNFNINFCBEJ;
	}

	[SpecialName]
	public void DCBLCJKAIKC(int IDEBKDPMPGM)
	{
		_003CKNBOKMGIKIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool LGAMMJLHIAN()
	{
		return CJNJHAJDJJP != ICDOJKMJFKM.Connected || IHGBMPOGECG() < GLFPILGCAPM.Rematch;
	}

	[SpecialName]
	public static void KMIHFKNAGBP(Action<GLFPILGCAPM, PlayerController> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM, PlayerController> action = CKDIHNEIHKL.KMKIKLKOALI;
		Action<GLFPILGCAPM, PlayerController> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CKDIHNEIHKL.KMKIKLKOALI, (Action<GLFPILGCAPM, PlayerController>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public GLFPILGCAPM KNLMGECDHFL()
	{
		return ILHNFHOFLCM;
	}

	[SpecialName]
	public void KPOADHJBNDE(ICDOJKMJFKM IDEBKDPMPGM)
	{
		if (CJNJHAJDJJP != IDEBKDPMPGM)
		{
			EMLNLJIMGLG = CJNJHAJDJJP;
			CJNJHAJDJJP = IDEBKDPMPGM;
			Debug.Log(string.Format("changing country to ", CJNJHAJDJJP, CACCABLDNHF().name));
			if (IDEBKDPMPGM == ICDOJKMJFKM.Connected)
			{
				KPKFEOBGCDD(PGDPBJPKDBK() + 0);
			}
		}
	}

	[SpecialName]
	public void KNPKNOPEBIE(ICDOJKMJFKM IDEBKDPMPGM)
	{
		if (CJNJHAJDJJP != IDEBKDPMPGM)
		{
			EMLNLJIMGLG = CJNJHAJDJJP;
			CJNJHAJDJJP = IDEBKDPMPGM;
			Debug.Log(string.Format("RematchRPC", CJNJHAJDJJP, KPIIAPDNOJB().name));
			if (IDEBKDPMPGM == ICDOJKMJFKM.Disconnected)
			{
				JJHFKEGEFBO(PGDPBJPKDBK() + 0);
			}
		}
	}

	public bool EJEEDINNKOH(GLFPILGCAPM IGBEGIBGLKK, int HAJHEIBNMJF)
	{
		if (HAJHEIBNMJF > AHKGMKHNLCO())
		{
			NKJHBLAMAFG(HAJHEIBNMJF);
			DGLGDFKDJCL(IGBEGIBGLKK);
			return true;
		}
		Debug.LogError(string.Format("ID_CONFIRM_THANKYOUPURCHASE", IGBEGIBGLKK, CACCABLDNHF().name));
		return true;
	}

	[SpecialName]
	public bool GJBKONJECIG()
	{
		return _003CCPPMNOHHAAK_003Ek__BackingField;
	}

	[SpecialName]
	public int IKKHJNNJEFL()
	{
		return _003CAHOOHOFKLNC_003Ek__BackingField;
	}

	[SpecialName]
	public bool DCBCCPHJAEJ()
	{
		return CJNJHAJDJJP != ICDOJKMJFKM.Connected || CALFPCCMHPB() < GLFPILGCAPM.GameFinished;
	}

	[SpecialName]
	public void LMBDNFMBGON(ICDOJKMJFKM IDEBKDPMPGM)
	{
		if (CJNJHAJDJJP != IDEBKDPMPGM)
		{
			EMLNLJIMGLG = CJNJHAJDJJP;
			CJNJHAJDJJP = IDEBKDPMPGM;
			Debug.Log(string.Format("service", CJNJHAJDJJP, CACCABLDNHF().name));
			if (IDEBKDPMPGM == ICDOJKMJFKM.Connected)
			{
				JJHFKEGEFBO(OEKGGHBMJBH() + 0);
			}
		}
	}

	[SpecialName]
	public void LODPIIGCEKP(bool IDEBKDPMPGM)
	{
		KFODAEBPJCG = IDEBKDPMPGM;
	}

	[SpecialName]
	public int CKPGJAAPGIG()
	{
		return _003CAHOOHOFKLNC_003Ek__BackingField;
	}

	[SpecialName]
	public bool AJBGJBKOCMO()
	{
		bool flag = !CJIFJGHMEFI().isCurrentPlayer || CBJIOJOLFBJ.BIKKEFAOMHG() == NetworkReachability.NotReachable;
		if (flag != FCAIAJGFGIK)
		{
			FCAIAJGFGIK = flag;
			Debug.Log(string.Format("ID_LEAGUE6", flag, DateTime.UtcNow));
		}
		return flag;
	}

	[SpecialName]
	public static void EPHONCELDDM(Action<GLFPILGCAPM, PlayerController> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM, PlayerController> action = CKDIHNEIHKL.KMKIKLKOALI;
		Action<GLFPILGCAPM, PlayerController> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CKDIHNEIHKL.KMKIKLKOALI, (Action<GLFPILGCAPM, PlayerController>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void JAAJMMEKBGG(int IDEBKDPMPGM)
	{
		_003CAHOOHOFKLNC_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void HGLDLBPNFDJ(PlayerController IDEBKDPMPGM)
	{
		_003COPCFPJLGOLK_003Ek__BackingField = IDEBKDPMPGM;
	}

	public bool JBIOODKPKIF(GLFPILGCAPM IGBEGIBGLKK, int HAJHEIBNMJF)
	{
		if (HAJHEIBNMJF > HPIBKNGEACD())
		{
			this.HAJHEIBNMJF = HAJHEIBNMJF;
			EHFIJJBPEEG = IGBEGIBGLKK;
			return true;
		}
		Debug.LogError(string.Format("ID_TUTORIAL_OVERTIME", IGBEGIBGLKK, KPIIAPDNOJB().name));
		return false;
	}

	[SpecialName]
	public static void PJALDPIFCFE(Action<GLFPILGCAPM, PlayerController> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM, PlayerController> action = CKDIHNEIHKL.KMKIKLKOALI;
		Action<GLFPILGCAPM, PlayerController> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CKDIHNEIHKL.KMKIKLKOALI, (Action<GLFPILGCAPM, PlayerController>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	private void KPKFEOBGCDD(int IDEBKDPMPGM)
	{
		_003CPMMCDEFMDBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void PHOKEBGMKMB(int IDEBKDPMPGM)
	{
		_003CKNBOKMGIKIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int FJENOCBIEJI()
	{
		return _003CKNBOKMGIKIH_003Ek__BackingField;
	}

	[SpecialName]
	public bool LMOCNIAPGCF()
	{
		bool flag = !HNFNINFCBEJ.isCurrentPlayer || CBJIOJOLFBJ.OCOKJKGAGKI() == NetworkReachability.NotReachable;
		if (flag != FCAIAJGFGIK)
		{
			FCAIAJGFGIK = flag;
			Debug.Log(string.Format("ЗАГРУЗИТЬ", flag, DateTime.UtcNow));
		}
		return flag;
	}

	[SpecialName]
	public static void CHAFPNBBBDI(Action<GLFPILGCAPM, PlayerController> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM, PlayerController> action = CKDIHNEIHKL.KMKIKLKOALI;
		Action<GLFPILGCAPM, PlayerController> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CKDIHNEIHKL.KMKIKLKOALI, (Action<GLFPILGCAPM, PlayerController>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int EDCFPIGGEPH()
	{
		return _003CPMMCDEFMDBP_003Ek__BackingField;
	}

	[SpecialName]
	public int OEKGGHBMJBH()
	{
		return _003CPMMCDEFMDBP_003Ek__BackingField;
	}

	[SpecialName]
	public void LOPGLCLFPLG(bool IDEBKDPMPGM)
	{
		KFODAEBPJCG = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerController KPIIAPDNOJB()
	{
		return _003COPCFPJLGOLK_003Ek__BackingField;
	}

	[SpecialName]
	public void MHAAKELFPHE(int IDEBKDPMPGM)
	{
		_003CKNBOKMGIKIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool LNPKAEDEBLI()
	{
		return KFODAEBPJCG;
	}

	[SpecialName]
	public int HPIBKNGEACD()
	{
		return _003CKNBOKMGIKIH_003Ek__BackingField;
	}

	[SpecialName]
	public void CJPNPDBHJCG(ICDOJKMJFKM IDEBKDPMPGM)
	{
		if (CJNJHAJDJJP != IDEBKDPMPGM)
		{
			EMLNLJIMGLG = CJNJHAJDJJP;
			CJNJHAJDJJP = IDEBKDPMPGM;
			Debug.Log(string.Format("FinishGameMultiplayerRPC", CJNJHAJDJJP, KPIIAPDNOJB().name));
			if (IDEBKDPMPGM == ICDOJKMJFKM.Disconnected)
			{
				JJHFKEGEFBO(MOFOCGMNAEF() + 0);
			}
		}
	}

	public void ILOHAHFIOKM()
	{
		EHFIJJBPEEG = GLFPILGCAPM.ConnectingToPhoton;
		CJNJHAJDJJP = ICDOJKMJFKM.Connected;
		EMLNLJIMGLG = ICDOJKMJFKM.Connected;
		AJADIICCLHO = false;
		HAJHEIBNMJF = 0;
		EIPHAAGCHCP = true;
		EPNLKGPLBEN = 0;
		GNACLALEPDB = 0;
		FCAIAJGFGIK = false;
	}

	[SpecialName]
	public GLFPILGCAPM CALFPCCMHPB()
	{
		return ILHNFHOFLCM;
	}

	[SpecialName]
	public bool PHJJFBMOFBF()
	{
		return _003CCPPMNOHHAAK_003Ek__BackingField;
	}

	[SpecialName]
	public void NKJHBLAMAFG(int IDEBKDPMPGM)
	{
		_003CKNBOKMGIKIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int MOFOCGMNAEF()
	{
		return _003CPMMCDEFMDBP_003Ek__BackingField;
	}

	[SpecialName]
	private void OBBFFOIMOBB(int IDEBKDPMPGM)
	{
		_003CPMMCDEFMDBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	public bool MLKAMPJNAKO(GLFPILGCAPM IGBEGIBGLKK, int HAJHEIBNMJF)
	{
		if (HAJHEIBNMJF > this.HAJHEIBNMJF)
		{
			this.HAJHEIBNMJF = HAJHEIBNMJF;
			EHFIJJBPEEG = IGBEGIBGLKK;
			return true;
		}
		Debug.LogError(string.Format("Error setting match state {0} to player {1}", IGBEGIBGLKK, HNFNINFCBEJ.name));
		return false;
	}

	[SpecialName]
	public int BPCHFKGOBIM()
	{
		return _003CKNBOKMGIKIH_003Ek__BackingField;
	}

	[SpecialName]
	public GLFPILGCAPM BGGBBINFCJO()
	{
		return ILHNFHOFLCM;
	}

	[SpecialName]
	public void KCEPBGLBBHE(bool IDEBKDPMPGM)
	{
		KFODAEBPJCG = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool LFCJNHBGDAC()
	{
		return CJNJHAJDJJP != ICDOJKMJFKM.Connected || CJJLIKCIBLO() >= GLFPILGCAPM.Playing;
	}

	[SpecialName]
	public void DGLGDFKDJCL(GLFPILGCAPM IDEBKDPMPGM)
	{
		ILHNFHOFLCM = IDEBKDPMPGM;
		Debug.Log(string.Format("Player profile - {0} is banned {1}", ILHNFHOFLCM, KPIIAPDNOJB().name));
		if (CKDIHNEIHKL.KMKIKLKOALI != null)
		{
			CKDIHNEIHKL.KMKIKLKOALI(ILHNFHOFLCM, CACCABLDNHF());
		}
	}

	public bool DADKCFEGCIP(GLFPILGCAPM IGBEGIBGLKK, int HAJHEIBNMJF)
	{
		if (HAJHEIBNMJF > PKHNOCFAEPH())
		{
			PHOKEBGMKMB(HAJHEIBNMJF);
			DDMMBKIHOIC(IGBEGIBGLKK);
			return true;
		}
		Debug.LogError(string.Format("ID_CONFIRM_EXITINGMATCH_TEXT", IGBEGIBGLKK, KPIIAPDNOJB().name));
		return true;
	}

	[SpecialName]
	public static void LOBKFMAENHL(Action<GLFPILGCAPM, PlayerController> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM, PlayerController> action = CKDIHNEIHKL.KMKIKLKOALI;
		Action<GLFPILGCAPM, PlayerController> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CKDIHNEIHKL.KMKIKLKOALI, (Action<GLFPILGCAPM, PlayerController>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void JALAIEHBLMJ(ICDOJKMJFKM IDEBKDPMPGM)
	{
		if (CJNJHAJDJJP != IDEBKDPMPGM)
		{
			EMLNLJIMGLG = CJNJHAJDJJP;
			CJNJHAJDJJP = IDEBKDPMPGM;
			Debug.Log(string.Format("ID_CONFIRM_ERROR", CJNJHAJDJJP, CACCABLDNHF().name));
			if (IDEBKDPMPGM == ICDOJKMJFKM.Connected)
			{
				OBBFFOIMOBB(NJBLBKDEDCN() + 0);
			}
		}
	}

	[SpecialName]
	public void IPPACHHBGCF(ICDOJKMJFKM IDEBKDPMPGM)
	{
		if (CJNJHAJDJJP != IDEBKDPMPGM)
		{
			EMLNLJIMGLG = CJNJHAJDJJP;
			CJNJHAJDJJP = IDEBKDPMPGM;
			Debug.Log(string.Format("ReputationPointsAdded", CJNJHAJDJJP, CACCABLDNHF().name));
			if (IDEBKDPMPGM == ICDOJKMJFKM.Disconnected)
			{
				JJHFKEGEFBO(PGDPBJPKDBK() + 1);
			}
		}
	}

	[SpecialName]
	public PlayerController CACCABLDNHF()
	{
		return _003COPCFPJLGOLK_003Ek__BackingField;
	}

	public bool CPELPNBIMPD(GLFPILGCAPM IGBEGIBGLKK, int HAJHEIBNMJF)
	{
		if (HAJHEIBNMJF > MEPHEOFBNEI())
		{
			MHAAKELFPHE(HAJHEIBNMJF);
			DGLGDFKDJCL(IGBEGIBGLKK);
			return true;
		}
		Debug.LogError(string.Format("0", IGBEGIBGLKK, CJIFJGHMEFI().name));
		return false;
	}

	[SpecialName]
	public int JMNHDBJACOF()
	{
		return _003CAHOOHOFKLNC_003Ek__BackingField;
	}

	public void OCBJINEDJCE()
	{
		EPNLKGPLBEN++;
	}

	[SpecialName]
	public bool KFIOCNKFCAP()
	{
		return LMOCNIAPGCF() || JHAMCGCHBAF() == ICDOJKMJFKM.Disconnected;
	}

	[SpecialName]
	public bool MIPJPMFLBPG()
	{
		return _003CCPPMNOHHAAK_003Ek__BackingField;
	}

	[SpecialName]
	public void AFDGKBBLDDN(ICDOJKMJFKM IDEBKDPMPGM)
	{
		if (CJNJHAJDJJP != IDEBKDPMPGM)
		{
			EMLNLJIMGLG = CJNJHAJDJJP;
			CJNJHAJDJJP = IDEBKDPMPGM;
			Debug.Log(string.Format("{0}\u00a0{1}", CJNJHAJDJJP, KPIIAPDNOJB().name));
			if (IDEBKDPMPGM == ICDOJKMJFKM.Disconnected)
			{
				JJHFKEGEFBO(OEKGGHBMJBH() + 1);
			}
		}
	}

	[SpecialName]
	public void OMNNJAHHCDO(ICDOJKMJFKM IDEBKDPMPGM)
	{
		if (CJNJHAJDJJP != IDEBKDPMPGM)
		{
			EMLNLJIMGLG = CJNJHAJDJJP;
			CJNJHAJDJJP = IDEBKDPMPGM;
			Debug.Log(string.Format("CONFIRM", CJNJHAJDJJP, CACCABLDNHF().name));
			if (IDEBKDPMPGM == ICDOJKMJFKM.Connected)
			{
				JJHFKEGEFBO(MOFOCGMNAEF() + 1);
			}
		}
	}

	[SpecialName]
	public ICDOJKMJFKM FFPDPKHJGJF()
	{
		return CJNJHAJDJJP;
	}

	[SpecialName]
	public void ECAKPOHBADC(int IDEBKDPMPGM)
	{
		_003CKNBOKMGIKIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EKIONFCEKHK(bool IDEBKDPMPGM)
	{
		KFODAEBPJCG = IDEBKDPMPGM;
	}

	[SpecialName]
	public void JNKGDHDGBNM(GLFPILGCAPM IDEBKDPMPGM)
	{
		ILHNFHOFLCM = IDEBKDPMPGM;
		Debug.Log(string.Format("AccountType", ILHNFHOFLCM, CACCABLDNHF().name));
		if (CKDIHNEIHKL.KMKIKLKOALI != null)
		{
			CKDIHNEIHKL.KMKIKLKOALI(ILHNFHOFLCM, CACCABLDNHF());
		}
	}

	[SpecialName]
	private void JJHFKEGEFBO(int IDEBKDPMPGM)
	{
		_003CPMMCDEFMDBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int NJBLBKDEDCN()
	{
		return _003CPMMCDEFMDBP_003Ek__BackingField;
	}

	[SpecialName]
	public int KEAGFLGLPNN()
	{
		return _003CKNBOKMGIKIH_003Ek__BackingField;
	}

	[SpecialName]
	private void FMHGHIJNMFO(PlayerController IDEBKDPMPGM)
	{
		_003COPCFPJLGOLK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool HNCDBGKPKPD()
	{
		return _003CCPPMNOHHAAK_003Ek__BackingField;
	}

	public void MEBPMHDHIPJ()
	{
		BDGAFCBKIKI(GLFPILGCAPM.ConnectingToPhoton);
		CJNJHAJDJJP = ICDOJKMJFKM.Connected;
		EMLNLJIMGLG = ICDOJKMJFKM.Connected;
		APKDGLNPHAG(false);
		AMPHMMCMGOK(1);
		BFDDIOPPNIL(false);
		OBBFFOIMOBB(1);
		JLAKDNBIPHK(1);
		FCAIAJGFGIK = true;
	}

	[SpecialName]
	public void ICAGIALMCJH(int IDEBKDPMPGM)
	{
		_003CAHOOHOFKLNC_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void JLAKDNBIPHK(int IDEBKDPMPGM)
	{
		_003CAHOOHOFKLNC_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public ICDOJKMJFKM JHAMCGCHBAF()
	{
		return CJNJHAJDJJP;
	}

	[SpecialName]
	public bool EPPECKNEHCI()
	{
		return _003CCPPMNOHHAAK_003Ek__BackingField;
	}

	[SpecialName]
	public void NICDAPAOCNK(bool IDEBKDPMPGM)
	{
		_003CCPPMNOHHAAK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int NBEFBOFJIAI()
	{
		return _003CPMMCDEFMDBP_003Ek__BackingField;
	}

	[SpecialName]
	public bool AMFJOFCFMMN()
	{
		return FMEMAOKMNDK() || FFPDPKHJGJF() == ICDOJKMJFKM.Connected;
	}

	[SpecialName]
	public GLFPILGCAPM CJJLIKCIBLO()
	{
		return ILHNFHOFLCM;
	}

	[SpecialName]
	public void DDMMBKIHOIC(GLFPILGCAPM IDEBKDPMPGM)
	{
		ILHNFHOFLCM = IDEBKDPMPGM;
		Debug.Log(string.Format("ID_WARNING_RESTOREERROR", ILHNFHOFLCM, KPIIAPDNOJB().name));
		if (CKDIHNEIHKL.KMKIKLKOALI != null)
		{
			CKDIHNEIHKL.KMKIKLKOALI(ILHNFHOFLCM, KPIIAPDNOJB());
		}
	}

	[SpecialName]
	private void HHHCDKLCKIJ(PlayerController IDEBKDPMPGM)
	{
		_003COPCFPJLGOLK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public GLFPILGCAPM IHGBMPOGECG()
	{
		return ILHNFHOFLCM;
	}

	[SpecialName]
	public int BLANAIEBIPF()
	{
		return _003CKNBOKMGIKIH_003Ek__BackingField;
	}

	[SpecialName]
	public void KIDKEIMFDJL(int IDEBKDPMPGM)
	{
		_003CAHOOHOFKLNC_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void BJIAOHPEDAP(bool IDEBKDPMPGM)
	{
		_003CCPPMNOHHAAK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool FMEMAOKMNDK()
	{
		bool flag = KPIIAPDNOJB().isCurrentPlayer && CBJIOJOLFBJ.FBIHDNGLHBL() == NetworkReachability.ReachableViaCarrierDataNetwork;
		if (flag != FCAIAJGFGIK)
		{
			FCAIAJGFGIK = flag;
			Debug.Log(string.Format("TuneListener trackerDidReceiveDeeplink: ", flag, DateTime.UtcNow));
		}
		return flag;
	}

	public void KEBEAKLACHC()
	{
		EPNLKGPLBEN = MOFOCGMNAEF() + 1;
	}

	[SpecialName]
	public void FFLIAFLAAJP(bool IDEBKDPMPGM)
	{
		KFODAEBPJCG = IDEBKDPMPGM;
	}

	[SpecialName]
	public ICDOJKMJFKM ACKFAAIJOBK()
	{
		return CJNJHAJDJJP;
	}

	[SpecialName]
	private void CIDFOLJCCBL(PlayerController IDEBKDPMPGM)
	{
		_003COPCFPJLGOLK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int HMDCBJBNMDA()
	{
		return _003CAHOOHOFKLNC_003Ek__BackingField;
	}

	[SpecialName]
	public bool IDAHGCLPPPE()
	{
		bool flag = !CJIFJGHMEFI().isCurrentPlayer || CBJIOJOLFBJ.MJEFMHEOPJJ() == NetworkReachability.NotReachable;
		if (flag != FCAIAJGFGIK)
		{
			FCAIAJGFGIK = flag;
			Debug.Log(string.Format("RegisterEvent(", flag, DateTime.UtcNow));
		}
		return flag;
	}

	[SpecialName]
	public void NPFLAFCJJPE(ICDOJKMJFKM IDEBKDPMPGM)
	{
		if (CJNJHAJDJJP != IDEBKDPMPGM)
		{
			EMLNLJIMGLG = CJNJHAJDJJP;
			CJNJHAJDJJP = IDEBKDPMPGM;
			Debug.Log(string.Format("resizing texture ", CJNJHAJDJJP, KPIIAPDNOJB().name));
			if (IDEBKDPMPGM == ICDOJKMJFKM.Connected)
			{
				JJHFKEGEFBO(NBEFBOFJIAI() + 1);
			}
		}
	}

	[SpecialName]
	public PlayerController CJIFJGHMEFI()
	{
		return _003COPCFPJLGOLK_003Ek__BackingField;
	}

	[SpecialName]
	public bool LAIPMABCODH()
	{
		return _003CCPPMNOHHAAK_003Ek__BackingField;
	}

	public bool FKEIIKKHKLO(GLFPILGCAPM IGBEGIBGLKK, int HAJHEIBNMJF)
	{
		if (HAJHEIBNMJF > FJENOCBIEJI())
		{
			ECAKPOHBADC(HAJHEIBNMJF);
			BDGAFCBKIKI(IGBEGIBGLKK);
			return true;
		}
		Debug.LogError(string.Format("1", IGBEGIBGLKK, HNFNINFCBEJ.name));
		return false;
	}

	public bool GBHJEKJFOLM(GLFPILGCAPM IGBEGIBGLKK, int HAJHEIBNMJF)
	{
		if (HAJHEIBNMJF > FJENOCBIEJI())
		{
			AMPHMMCMGOK(HAJHEIBNMJF);
			JNKGDHDGBNM(IGBEGIBGLKK);
			return false;
		}
		Debug.LogError(string.Format("SquadEmblem", IGBEGIBGLKK, CJIFJGHMEFI().name));
		return true;
	}

	[SpecialName]
	public void AMPHMMCMGOK(int IDEBKDPMPGM)
	{
		_003CKNBOKMGIKIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public GLFPILGCAPM MJJBHNOMDOI()
	{
		return ILHNFHOFLCM;
	}

	public bool HNMJPALEMLA(GLFPILGCAPM IGBEGIBGLKK, int HAJHEIBNMJF)
	{
		if (HAJHEIBNMJF > AHKGMKHNLCO())
		{
			NKJHBLAMAFG(HAJHEIBNMJF);
			EHFIJJBPEEG = IGBEGIBGLKK;
			return true;
		}
		Debug.LogError(string.Format("ID_STAT_HANDGUNKILLS", IGBEGIBGLKK, CJIFJGHMEFI().name));
		return true;
	}

	[SpecialName]
	public bool KHIOIPEFDMA()
	{
		return KFODAEBPJCG;
	}

	public void EFNCIALDGFD()
	{
		KPKFEOBGCDD(OEKGGHBMJBH() + 1);
	}

	[SpecialName]
	public int PGDPBJPKDBK()
	{
		return _003CPMMCDEFMDBP_003Ek__BackingField;
	}

	[SpecialName]
	public static void HLKMNMFMAIA(Action<GLFPILGCAPM, PlayerController> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM, PlayerController> action = CKDIHNEIHKL.KMKIKLKOALI;
		Action<GLFPILGCAPM, PlayerController> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CKDIHNEIHKL.KMKIKLKOALI, (Action<GLFPILGCAPM, PlayerController>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int FHADJAFOGMP()
	{
		return _003CPMMCDEFMDBP_003Ek__BackingField;
	}
}
