using System.Collections.Generic;

public class KIMBLKJPMDC : global::LAHOBMBEDKE<DailyMissionBoss>
{
	private int AFBBPCBCOLC;

	private List<DHELGFIFMEH> ENALKJGICEK;

	protected virtual void PNEGKBMBDNH()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void JFKJNKKMIPK()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 5) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 8 : 5));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	public virtual void EGGOJOJDCEP()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(388f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(634f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(46f);
	}

	private void POGBMKDNFAN()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	public virtual void IPAMHNHPNFE()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: false, HKLGEPGEFIK: true, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(646f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(221f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(882f);
	}

	protected virtual void OMOIGOLMFGC()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	protected virtual void JKFJBFHKHDA()
	{
		CHCDNCEACNF();
		FLMMIJKBBIE();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected virtual void KGDDDGDLKHD()
	{
		MFIMEFACLLM();
		LNKOJCMLBJK();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected virtual void GKCLIAHOLPP()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	protected virtual void BBNFOOHIPIP()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void MHAKMJNAFNO()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	private void LNGGIEHCJKF()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 2) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 4 : 4));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void CNJDOHHADNO()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 3) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 4 : 4));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	public virtual void DCLLIDFLPOJ()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: false, HKLGEPGEFIK: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.PLKGKCCMFGC(630f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1313f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(910f);
	}

	protected virtual void INJNAMGNJBP()
	{
		BOLFBBKKNFB();
		MNMHLAJAPPE();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	private void MPGKENMDCCE()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 1) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime == DPGPOMCNMNF.bossWaitForSpawnTime || DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time) ? 1 : 4));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	protected virtual void FGIECKJFBAC()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	public virtual void PFCGBOHJIME()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: false, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.PLKGKCCMFGC(270f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(96f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(1818f);
	}

	private void MNJGBGDBMHJ()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 8) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 2 : 0));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	protected virtual void PFOIIACJLPF()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void CHCDNCEACNF()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void JKOCABOMCNC()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	public override void BFENONOEFBF()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(0f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(-24f);
	}

	protected virtual void PJFAKJJPGCG()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	protected virtual void IADFPPCOPMB()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void NGHKBLJOAFL()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	private void OFEOKCIBCMC()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 2) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 1 : 8));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void MNMHLAJAPPE()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 0) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 4 : 0));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void LNKOJCMLBJK()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 6) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 1 : 2));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void MOPNPILPKFA()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	public virtual void APPOMINOLEE()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(314f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1955f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(479f);
	}

	protected virtual void PGJIFCBEPHH()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	public virtual void ABECIOMGDPA()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: true, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(180f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1525f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(830f);
	}

	protected virtual void DOFKCGDAPHG()
	{
		IBHICGKBGPE();
		DMEMIDEAHJL();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected virtual void JOOOEIDPEEA()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void FPCLNNIEOAN()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 6) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 3 : 6));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void NAELPJCOOKC()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void IGJKAPDLOLP()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void DGGHKJKDLCF()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 5) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 6 : 2));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void FLMMIJKBBIE()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 2) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 7 : 6));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	protected virtual void NIAOCDBAHIJ()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	public virtual void BOOPCOJGEJA()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: true, HKLGEPGEFIK: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.PLKGKCCMFGC(552f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(819f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(1750f);
	}

	private void ENCCJKAINPN()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 4) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 3 : 2));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	public virtual void CEOFCEMHMBE()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(928f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1876f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(1177f);
	}

	protected virtual void AALJGPBEMHH()
	{
		NDMIBGMBHOP();
		LNGGIEHCJKF();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	private void IJHNIAHLOHG()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 1) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 6 : 8));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void BPCOAKNMIEJ()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	private void PLDHNDDHMCK()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	public virtual void HCBDBOCLAOF()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(1365f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1174f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(281f);
	}

	public virtual void HEPKPHKHJKK()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: true, HKLGEPGEFIK: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(1478f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(418f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(1197f);
	}

	protected virtual void COMFCOPOICH()
	{
		IBHICGKBGPE();
		MPGKENMDCCE();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	public virtual void GPDFLGLLLHH()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: false, HKLGEPGEFIK: true, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(896f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(876f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(619f);
	}

	public virtual void JCBEMIMEPFJ()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.PLKGKCCMFGC(1001f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(333f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(1333f);
	}

	protected virtual void EKKLIDBJGKN()
	{
		IBHICGKBGPE();
		LNKOJCMLBJK();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected virtual void NGNCMJPANFH()
	{
		CHCDNCEACNF();
		ECMFPLEDHOA();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	public virtual void EPIHIKKLDMD()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: false, HKLGEPGEFIK: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(867f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(1201f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(1381f);
	}

	private void ALCGNBFCACB()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void LFMJHPDHKGF()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void PBPOJLKNFMC()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 4) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 3 : 7));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void GLBHEOAOOKM()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void HMHAGJEPILC()
	{
		GLBHEOAOOKM();
		PBPOJLKNFMC();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	private void PEGAMOEJGMM()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void INAHIAPJMGH()
	{
		GOIDIIOBKGO();
		JJKFLONLKKA();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected virtual void LCIJBKEMFBF()
	{
		BPCOAKNMIEJ();
		MPGKENMDCCE();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected virtual void OMHFOFLHLDC()
	{
		MLMHDBHCMJJ();
		PBPOJLKNFMC();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	public virtual void GICFJNKFEDD()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(898f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(1603f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(1481f);
	}

	private void NDMIBGMBHOP()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void LBKBJBAOACF()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void ADBFIEKEDOE()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 7) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 1 : 6));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	public virtual void OKCJHHELDGE()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: false, HKLGEPGEFIK: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(926f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1258f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(55f);
	}

	private void DNLLKMKOPCO()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	private void NKLLCKJILHM()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void NBDJAHJKOCJ()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	protected virtual void OIOBOHEHMLH()
	{
		DFADCKFODNK();
		MPGKENMDCCE();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected override void LHMJNPCNNCO()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void MLMHDBHCMJJ()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void HFKJPFHNMMM()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void ONCCFGGDFCB()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	private void DMEMIDEAHJL()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 6) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 8 : 0));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void PHJANDGBHEO()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void LNIDFBPCCEI()
	{
		POGBMKDNFAN();
		DGGHKJKDLCF();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected virtual void GHBDDDGDGGE()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void BOLFBBKKNFB()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	public virtual void DHEMMCBKCGB()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(251f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1807f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(1456f);
	}

	protected virtual void GOLBBPEJNFB()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void AEDLFBGIFMG()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 4) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 3 : 4));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void CGBAFKEFGJN()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 3) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 7 : 2));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void KMJDIICOKKB()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 6) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 7 : 3));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	public virtual void FNNIHFLOLPL()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: true, HKLGEPGEFIK: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(316f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(1430f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(164f);
	}

	protected virtual void EMBCPOCJNNB()
	{
		DNLLKMKOPCO();
		KMJDIICOKKB();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	private void JAJKEGPFNNK()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	public virtual void EOCOFKMONFB()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(705f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1600f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(347f);
	}

	public virtual void BHLKOAGPGFC()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: false, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(1229f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(459f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(1263f);
	}

	private void DFADCKFODNK()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void DFLIFDNKPED()
	{
		MFIMEFACLLM();
		AEDLFBGIFMG();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	private void JJKFLONLKKA()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 0) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime == DPGPOMCNMNF.bossWaitForSpawnTime || DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time) ? 1 : 5));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	protected virtual void LFDINPOLHPI()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void CJAOEHHGDLJ()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 3) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 3 : 2));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	public virtual void OBOKHKCNAGL()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: true, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(92f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1972f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(1478f);
	}

	protected virtual void ACDGJOHEOCO()
	{
		GLBHEOAOOKM();
		IJHNIAHLOHG();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected virtual void DAFMKFLEPPD()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void PKKNJBIBNBJ()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 4) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime == DPGPOMCNMNF.bossWaitForSpawnTime || DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time) ? 8 : 0));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	protected override void NFNGHLBEOJO()
	{
		NDMIBGMBHOP();
		CJAOEHHGDLJ();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	public virtual void MIIJHEHMBJB()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(1472f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(413f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(1066f);
	}

	protected virtual void EHBIEGFLHCD()
	{
		BOLFBBKKNFB();
		DGGHKJKDLCF();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected virtual void IJFIAPGLBLB()
	{
		POGBMKDNFAN();
		ADBFIEKEDOE();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	public virtual void AFHHDGGJDHN()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: true, HKLGEPGEFIK: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.PLKGKCCMFGC(181f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(856f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(1950f);
	}

	protected virtual void PIFAMKPKHBI()
	{
		MHAKMJNAFNO();
		ENCCJKAINPN();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	public virtual void DDOKECFIINA()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: false, HKLGEPGEFIK: true, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(539f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(429f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(830f);
	}

	protected virtual void KJKODDODFBB()
	{
		MHAKMJNAFNO();
		FLMMIJKBBIE();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	private void JEBDHKBMDOD()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 1) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 5 : 7));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	public virtual void POHNAOBNELK()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: false, HKLGEPGEFIK: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(569f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1244f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(890f);
	}

	public virtual void PGNFPACBLGA()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: false, HKLGEPGEFIK: true, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(419f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(1853f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(1300f);
	}

	protected virtual void NGFIOKHMHBN()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void MFIMEFACLLM()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	private void ECMFPLEDHOA()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 4) ? (DPGPOMCNMNF.currentWaveNumber - 1) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 1 : 0));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	private void GOIDIIOBKGO()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	protected virtual void LJLJFADBNFE()
	{
		NDMIBGMBHOP();
		CJAOEHHGDLJ();
		ENALKJGICEK[AFBBPCBCOLC].NFNGHLBEOJO();
	}

	protected virtual void BLKLHJCKDFL()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	public virtual void BADFMALMHEM()
	{
		base.BFENONOEFBF();
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: false, HKLGEPGEFIK: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(1351f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1839f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(1953f);
	}

	private void IBHICGKBGPE()
	{
		if (ENALKJGICEK == null)
		{
			ENALKJGICEK = new List<DHELGFIFMEH>();
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new PBMNFCPCGIE(DPGPOMCNMNF));
			ENALKJGICEK.Add(new KGAJOCCBIDL(DPGPOMCNMNF));
			ENALKJGICEK.Add(new EBELGBMPHGM(DPGPOMCNMNF));
		}
	}

	private void BDMDFIFJGGH()
	{
		int num = 0;
		num = ((DPGPOMCNMNF.currentWaveNumber < 6) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 2 : 3));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}

	protected virtual void LPFHFNLMFJA()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	protected virtual void NOANFINIFEJ()
	{
		ENALKJGICEK[AFBBPCBCOLC].LHMJNPCNNCO();
	}

	private void KGIENINDLEB()
	{
		int num = 1;
		num = ((DPGPOMCNMNF.currentWaveNumber < 5) ? (DPGPOMCNMNF.currentWaveNumber - 0) : ((DPGPOMCNMNF.bossSpawnTime != DPGPOMCNMNF.bossWaitForSpawnTime && !(DPGPOMCNMNF.bossSpawnTime > DPGPOMCNMNF.time)) ? 2 : 6));
		if (AFBBPCBCOLC != num)
		{
			ENALKJGICEK[num].ADDPJHEAPBP();
		}
		AFBBPCBCOLC = num;
	}
}
