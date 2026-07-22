using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.Detectors;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;
using UnityEngine.Serialization;

public class AntiCheatDetector : Singleton<AntiCheatDetector>
{
	public enum OBEEBMKOOMK
	{
		MemoryHack,
		SpeedHack,
		PlayerPrefsHack,
		JailBreak
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _003CGDBMKMLHANB_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private OBEEBMKOOMK _003CFIIBIDBKFOL_003Ek__BackingField;

	[FormerlySerializedAs("CCKCIIDFCJN")]
	public string CGGLPHIEGKE;

	[FormerlySerializedAs("EFLINGNEHNJ")]
	public string PIFHKHMMECK;

	public bool playerCheated
	{
		[CompilerGenerated]
		get
		{
			return _003CGDBMKMLHANB_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CGDBMKMLHANB_003Ek__BackingField = value;
		}
	}

	public OBEEBMKOOMK cheatType
	{
		[CompilerGenerated]
		get
		{
			return _003CFIIBIDBKFOL_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CFIIBIDBKFOL_003Ek__BackingField = value;
		}
	}

	private void LALKDPKKKCP()
	{
		UnityEngine.Debug.LogError("OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}");
		BOPBLLBFJLN(IDEBKDPMPGM: false);
		EIPPBNLAKNL(OBEEBMKOOMK.SpeedHack);
	}

	private void IDLAOMLCCBJ()
	{
		UnityEngine.Debug.LogError("ID_SEC");
		BOPBLLBFJLN(IDEBKDPMPGM: true);
		NLKEMIGJDND(OBEEBMKOOMK.MemoryHack);
	}

	public void OAHODCPEAEC()
	{
		AHCCENCALNG(IDEBKDPMPGM: true);
	}

	private void AOCMGMBIALI()
	{
		UnityEngine.Debug.LogError("zoneHasVirtualGoodsOffer");
		PDDKMPBNEOG(IDEBKDPMPGM: false);
		NLKEMIGJDND(OBEEBMKOOMK.MemoryHack);
	}

	private void IDEJDIEBLDM()
	{
		UnityEngine.Debug.LogError("file://");
		HFKLMMMEHHL(IDEBKDPMPGM: true);
		MFDGPLNMJGD(OBEEBMKOOMK.SpeedHack);
	}

	public void IKACMMFFCMN()
	{
		ALLCFDGIFGH();
	}

	[SpecialName]
	public bool ECFMPOKNNFK()
	{
		return _003CGDBMKMLHANB_003Ek__BackingField;
	}

	[SpecialName]
	public bool KBNHJICMJCO()
	{
		return _003CGDBMKMLHANB_003Ek__BackingField;
	}

	private void PEJINDEIPPE()
	{
		if (BundleVersionBindings.IsJailBreak())
		{
			BOPBLLBFJLN(IDEBKDPMPGM: true);
			EIPPBNLAKNL(OBEEBMKOOMK.JailBreak);
			UnityEngine.Debug.LogError("_Color");
		}
	}

	[SpecialName]
	private void PDDKMPBNEOG(bool IDEBKDPMPGM)
	{
		_003CGDBMKMLHANB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool BNMGCINKBJB()
	{
		return _003CGDBMKMLHANB_003Ek__BackingField;
	}

	public void MEFPLGKADAP()
	{
		OCGOJAJBBPK();
	}

	[SpecialName]
	public OBEEBMKOOMK MOGDJFFHMJF()
	{
		return _003CFIIBIDBKFOL_003Ek__BackingField;
	}

	private void OCGOJAJBBPK()
	{
		UnityEngine.Debug.LogError("PromotedPlayer");
		PDDKMPBNEOG(IDEBKDPMPGM: false);
		cheatType = OBEEBMKOOMK.MemoryHack;
	}

	private void AJKDJGIKMFP()
	{
		UnityEngine.Debug.LogError("OtherPlayerId");
		BOPBLLBFJLN(IDEBKDPMPGM: false);
		cheatType = OBEEBMKOOMK.MemoryHack;
	}

	public void CJDBHCMLNPC()
	{
		ALLCFDGIFGH();
	}

	private void IFILOJMBICA()
	{
		if (BundleVersionBindings.IsJailBreak())
		{
			PDDKMPBNEOG(IDEBKDPMPGM: true);
			NLKEMIGJDND(OBEEBMKOOMK.PlayerPrefsHack);
			UnityEngine.Debug.LogError("ID_CONFIRM_LOGINFAILURE_TEXT");
		}
	}

	[SpecialName]
	private void HFKLMMMEHHL(bool IDEBKDPMPGM)
	{
		_003CGDBMKMLHANB_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void KBDMHJADAID()
	{
		UnityEngine.Debug.LogError("ACD: Memory was tampered, cheater detected!");
		playerCheated = true;
		cheatType = OBEEBMKOOMK.MemoryHack;
	}

	[SpecialName]
	private void AHCCENCALNG(bool IDEBKDPMPGM)
	{
		_003CGDBMKMLHANB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void KHAANKGBHBN()
	{
		ALLCFDGIFGH();
	}

	public void OECBOHPEJMG()
	{
		AJKDJGIKMFP();
	}

	public void OOILBDJOFKO()
	{
		NPCGCPEPCFM();
	}

	public void OFPIAALKLAC()
	{
		playerCheated = false;
	}

	private void DHIOIPIHIJJ()
	{
		if (BundleVersionBindings.IsJailBreak())
		{
			AHCCENCALNG(IDEBKDPMPGM: true);
			GFBHKMMJDML((OBEEBMKOOMK)5);
			UnityEngine.Debug.LogError("Player_Avoided_Grenade_On_First_Try");
		}
	}

	protected virtual void KODJIPJGFPB()
	{
		base.Awake();
		ObscuredCheatingDetector.StartDetection(FEFOHGCPMEM);
		ObscuredPrefs.onAlterationDetected += BHOJBMOIJKH;
		SpeedHackDetector.StartDetection(MKNLPENPDDH);
		KPEBPEIFLFA();
	}

	public void TestHack()
	{
		KBDMHJADAID();
	}

	private void OANODKNANFB()
	{
		UnityEngine.Debug.LogError("ACD: Player prefs were hacked!");
		playerCheated = true;
		cheatType = OBEEBMKOOMK.PlayerPrefsHack;
	}

	[SpecialName]
	private void BOPBLLBFJLN(bool IDEBKDPMPGM)
	{
		_003CGDBMKMLHANB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void BHMJEFGGAMJ()
	{
		BOPBLLBFJLN(IDEBKDPMPGM: true);
	}

	public void CGDKBPJGNNA()
	{
		BOPBLLBFJLN(IDEBKDPMPGM: true);
	}

	private void MKNLPENPDDH()
	{
		UnityEngine.Debug.LogError("menu-wftv-twitch-ico");
		BOPBLLBFJLN(IDEBKDPMPGM: true);
		cheatType = OBEEBMKOOMK.MemoryHack;
	}

	private void NPCGCPEPCFM()
	{
		UnityEngine.Debug.LogError("Starting LocalPersistenceManager!");
		HFKLMMMEHHL(IDEBKDPMPGM: false);
		MFDGPLNMJGD(OBEEBMKOOMK.SpeedHack);
	}

	public void KMLIOODIDBA()
	{
		OCGOJAJBBPK();
	}

	[SpecialName]
	private void MFDGPLNMJGD(OBEEBMKOOMK IDEBKDPMPGM)
	{
		_003CFIIBIDBKFOL_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void FOIKLCECNBL()
	{
		base.Awake();
		ObscuredCheatingDetector.StartDetection(ALLCFDGIFGH);
		ObscuredPrefs.onAlterationDetected += MENLGJHFDIK;
		SpeedHackDetector.StartDetection(MKNLPENPDDH);
		IFILOJMBICA();
	}

	private void FEFOHGCPMEM()
	{
		UnityEngine.Debug.LogError("NO Video Feed found!");
		BOPBLLBFJLN(IDEBKDPMPGM: false);
		GFBHKMMJDML(OBEEBMKOOMK.MemoryHack);
	}

	public void EPKINIMJGJH()
	{
		IDEJDIEBLDM();
	}

	private void NKFJGODEHEM()
	{
		UnityEngine.Debug.LogError("Wood");
		BOPBLLBFJLN(IDEBKDPMPGM: false);
		MFDGPLNMJGD(OBEEBMKOOMK.MemoryHack);
	}

	public void Clear()
	{
		playerCheated = false;
	}

	protected virtual void NGGJHDCOLEC()
	{
		base.Awake();
		ObscuredCheatingDetector.StartDetection(ALLCFDGIFGH);
		ObscuredPrefs.onAlterationDetected += BHOJBMOIJKH;
		SpeedHackDetector.StartDetection(COIMNCLAFII);
		PEJINDEIPPE();
	}

	private void BKJGPGLKLMB()
	{
		UnityEngine.Debug.LogError("game-card-ico-backstab");
		PDDKMPBNEOG(IDEBKDPMPGM: false);
		MFDGPLNMJGD(OBEEBMKOOMK.MemoryHack);
	}

	public void ADKDOMAAOCO()
	{
		KBDMHJADAID();
	}

	protected virtual void AKBKAKINING()
	{
		base.Awake();
		ObscuredCheatingDetector.StartDetection(AJKDJGIKMFP);
		ObscuredPrefs.onAlterationDetected += OANODKNANFB;
		SpeedHackDetector.StartDetection(CJPGJDMKBKC);
		DHIOIPIHIJJ();
	}

	[SpecialName]
	public bool EFEKLAEKDMA()
	{
		return _003CGDBMKMLHANB_003Ek__BackingField;
	}

	public void BCNFLEAMEJH()
	{
		BOPBLLBFJLN(IDEBKDPMPGM: true);
	}

	protected override void Awake()
	{
		base.Awake();
		ObscuredCheatingDetector.StartDetection(KBDMHJADAID);
		ObscuredPrefs.onAlterationDetected += OANODKNANFB;
		SpeedHackDetector.StartDetection(CJPGJDMKBKC);
		KPEBPEIFLFA();
	}

	[SpecialName]
	public OBEEBMKOOMK FEBBCGJLKOD()
	{
		return _003CFIIBIDBKFOL_003Ek__BackingField;
	}

	[SpecialName]
	public bool EIHFLMGDKOG()
	{
		return _003CGDBMKMLHANB_003Ek__BackingField;
	}

	private void ALLCFDGIFGH()
	{
		UnityEngine.Debug.LogError("RegisterGender()");
		HFKLMMMEHHL(IDEBKDPMPGM: false);
		MFDGPLNMJGD(OBEEBMKOOMK.SpeedHack);
	}

	[SpecialName]
	private void GFBHKMMJDML(OBEEBMKOOMK IDEBKDPMPGM)
	{
		_003CFIIBIDBKFOL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public OBEEBMKOOMK ECNJIIGCJGA()
	{
		return _003CFIIBIDBKFOL_003Ek__BackingField;
	}

	[SpecialName]
	public bool EDOCJJEEDCJ()
	{
		return _003CGDBMKMLHANB_003Ek__BackingField;
	}

	private void MENLGJHFDIK()
	{
		UnityEngine.Debug.LogError("ID_CONFIRM_ERROR");
		PDDKMPBNEOG(IDEBKDPMPGM: false);
		MFDGPLNMJGD(OBEEBMKOOMK.JailBreak);
	}

	[SpecialName]
	private void EIPPBNLAKNL(OBEEBMKOOMK IDEBKDPMPGM)
	{
		_003CFIIBIDBKFOL_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void BHOJBMOIJKH()
	{
		UnityEngine.Debug.LogError("menu-squad-{0}");
		BOPBLLBFJLN(IDEBKDPMPGM: true);
		NLKEMIGJDND((OBEEBMKOOMK)7);
	}

	public void MEMNLHNOLKM()
	{
		BOPBLLBFJLN(IDEBKDPMPGM: false);
	}

	private void PHNDCDEFFCF()
	{
		UnityEngine.Debug.LogError("NO Fuseboxx Config Value during GETPLAYERDATA!");
		AHCCENCALNG(IDEBKDPMPGM: false);
		cheatType = OBEEBMKOOMK.SpeedHack;
	}

	[SpecialName]
	public bool HKEAFGLEAOO()
	{
		return _003CGDBMKMLHANB_003Ek__BackingField;
	}

	[SpecialName]
	private void NLKEMIGJDND(OBEEBMKOOMK IDEBKDPMPGM)
	{
		_003CFIIBIDBKFOL_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void COIMNCLAFII()
	{
		UnityEngine.Debug.LogError("CardCraft_Start");
		PDDKMPBNEOG(IDEBKDPMPGM: false);
		GFBHKMMJDML(OBEEBMKOOMK.MemoryHack);
	}

	[SpecialName]
	public bool KNCLJBPOAFB()
	{
		return _003CGDBMKMLHANB_003Ek__BackingField;
	}

	public void APENIKOJKON()
	{
		playerCheated = true;
	}

	public void ICKPGGFGBKM()
	{
		NKFJGODEHEM();
	}

	[SpecialName]
	public bool FJLHEMLIDAE()
	{
		return _003CGDBMKMLHANB_003Ek__BackingField;
	}

	[SpecialName]
	public bool OIDKBJDNCHM()
	{
		return _003CGDBMKMLHANB_003Ek__BackingField;
	}

	public void MCJBDMCNBIB()
	{
		BOPBLLBFJLN(IDEBKDPMPGM: true);
	}

	protected virtual void FGOAPPLNMKL()
	{
		base.Awake();
		ObscuredCheatingDetector.StartDetection(KBDMHJADAID);
		ObscuredPrefs.onAlterationDetected += MENLGJHFDIK;
		SpeedHackDetector.StartDetection(PHNDCDEFFCF);
		OEJEBFLGGFM();
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		ObscuredCheatingDetector.StartDetection(NPCGCPEPCFM);
		ObscuredPrefs.onAlterationDetected += BHOJBMOIJKH;
		SpeedHackDetector.StartDetection(PPJKLMOJLNN);
		OEJEBFLGGFM();
	}

	private void PPJKLMOJLNN()
	{
		UnityEngine.Debug.LogError("EventId");
		BOPBLLBFJLN(IDEBKDPMPGM: true);
		MFDGPLNMJGD(OBEEBMKOOMK.SpeedHack);
	}

	public void AOEICFAKIDM()
	{
		AHCCENCALNG(IDEBKDPMPGM: true);
	}

	public void EPIDAGNGLAH()
	{
		ALLCFDGIFGH();
	}

	private void CJPGJDMKBKC()
	{
		UnityEngine.Debug.LogError("ACD: Speedhack detected!");
		playerCheated = true;
		cheatType = OBEEBMKOOMK.SpeedHack;
	}

	[SpecialName]
	public OBEEBMKOOMK GDOBJJOFGED()
	{
		return _003CFIIBIDBKFOL_003Ek__BackingField;
	}

	private void KPEBPEIFLFA()
	{
		if (BundleVersionBindings.IsJailBreak())
		{
			playerCheated = true;
			cheatType = OBEEBMKOOMK.JailBreak;
			UnityEngine.Debug.LogError("ACD: Phone jail braked");
		}
	}

	private void OEJEBFLGGFM()
	{
		if (BundleVersionBindings.IsJailBreak())
		{
			HFKLMMMEHHL(IDEBKDPMPGM: false);
			cheatType = OBEEBMKOOMK.MemoryHack;
			UnityEngine.Debug.LogError("Re checking product IDs");
		}
	}
}
