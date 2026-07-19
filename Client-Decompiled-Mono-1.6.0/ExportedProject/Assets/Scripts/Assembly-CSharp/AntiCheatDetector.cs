using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.Detectors;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class AntiCheatDetector : Singleton<AntiCheatDetector>
{
	public enum OBEEBMKOOMK
	{
		MemoryHack = 0,
		SpeedHack = 1,
		PlayerPrefsHack = 2,
		JailBreak = 3
	}

	public string CGGLPHIEGKE;

	public string PIFHKHMMECK;

	public bool playerCheated { get; private set; }

	public OBEEBMKOOMK cheatType { get; private set; }

	private void LALKDPKKKCP()
	{
		Debug.LogError("OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}");
		BOPBLLBFJLN(false);
		EIPPBNLAKNL(OBEEBMKOOMK.SpeedHack);
	}

	private void IDLAOMLCCBJ()
	{
		Debug.LogError("ID_SEC");
		BOPBLLBFJLN(true);
		NLKEMIGJDND(OBEEBMKOOMK.MemoryHack);
	}

	public void OAHODCPEAEC()
	{
		AHCCENCALNG(true);
	}

	private void AOCMGMBIALI()
	{
		Debug.LogError("zoneHasVirtualGoodsOffer");
		PDDKMPBNEOG(false);
		NLKEMIGJDND(OBEEBMKOOMK.MemoryHack);
	}

	private void IDEJDIEBLDM()
	{
		Debug.LogError("file://");
		HFKLMMMEHHL(true);
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
			BOPBLLBFJLN(true);
			EIPPBNLAKNL(OBEEBMKOOMK.JailBreak);
			Debug.LogError("_Color");
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
		Debug.LogError("PromotedPlayer");
		PDDKMPBNEOG(false);
		cheatType = OBEEBMKOOMK.MemoryHack;
	}

	private void AJKDJGIKMFP()
	{
		Debug.LogError("OtherPlayerId");
		BOPBLLBFJLN(false);
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
			PDDKMPBNEOG(true);
			NLKEMIGJDND(OBEEBMKOOMK.PlayerPrefsHack);
			Debug.LogError("ID_CONFIRM_LOGINFAILURE_TEXT");
		}
	}

	[SpecialName]
	private void HFKLMMMEHHL(bool IDEBKDPMPGM)
	{
		_003CGDBMKMLHANB_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void KBDMHJADAID()
	{
		Debug.LogError("ACD: Memory was tampered, cheater detected!");
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
			AHCCENCALNG(true);
			GFBHKMMJDML((OBEEBMKOOMK)5);
			Debug.LogError("Player_Avoided_Grenade_On_First_Try");
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
		Debug.LogError("ACD: Player prefs were hacked!");
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
		BOPBLLBFJLN(true);
	}

	public void CGDKBPJGNNA()
	{
		BOPBLLBFJLN(true);
	}

	private void MKNLPENPDDH()
	{
		Debug.LogError("menu-wftv-twitch-ico");
		BOPBLLBFJLN(true);
		cheatType = OBEEBMKOOMK.MemoryHack;
	}

	private void NPCGCPEPCFM()
	{
		Debug.LogError("Starting LocalPersistenceManager!");
		HFKLMMMEHHL(false);
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
		Debug.LogError("NO Video Feed found!");
		BOPBLLBFJLN(false);
		GFBHKMMJDML(OBEEBMKOOMK.MemoryHack);
	}

	public void EPKINIMJGJH()
	{
		IDEJDIEBLDM();
	}

	private void NKFJGODEHEM()
	{
		Debug.LogError("Wood");
		BOPBLLBFJLN(false);
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
		Debug.LogError("game-card-ico-backstab");
		PDDKMPBNEOG(false);
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
		BOPBLLBFJLN(true);
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
		Debug.LogError("RegisterGender()");
		HFKLMMMEHHL(false);
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
		Debug.LogError("ID_CONFIRM_ERROR");
		PDDKMPBNEOG(false);
		MFDGPLNMJGD(OBEEBMKOOMK.JailBreak);
	}

	[SpecialName]
	private void EIPPBNLAKNL(OBEEBMKOOMK IDEBKDPMPGM)
	{
		_003CFIIBIDBKFOL_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void BHOJBMOIJKH()
	{
		Debug.LogError("menu-squad-{0}");
		BOPBLLBFJLN(true);
		NLKEMIGJDND((OBEEBMKOOMK)7);
	}

	public void MEMNLHNOLKM()
	{
		BOPBLLBFJLN(false);
	}

	private void PHNDCDEFFCF()
	{
		Debug.LogError("NO Fuseboxx Config Value during GETPLAYERDATA!");
		AHCCENCALNG(false);
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
		Debug.LogError("CardCraft_Start");
		PDDKMPBNEOG(false);
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
		BOPBLLBFJLN(true);
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
		Debug.LogError("EventId");
		BOPBLLBFJLN(true);
		MFDGPLNMJGD(OBEEBMKOOMK.SpeedHack);
	}

	public void AOEICFAKIDM()
	{
		AHCCENCALNG(true);
	}

	public void EPIDAGNGLAH()
	{
		ALLCFDGIFGH();
	}

	private void CJPGJDMKBKC()
	{
		Debug.LogError("ACD: Speedhack detected!");
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
			Debug.LogError("ACD: Phone jail braked");
		}
	}

	private void OEJEBFLGGFM()
	{
		if (BundleVersionBindings.IsJailBreak())
		{
			HFKLMMMEHHL(false);
			cheatType = OBEEBMKOOMK.MemoryHack;
			Debug.LogError("Re checking product IDs");
		}
	}
}
