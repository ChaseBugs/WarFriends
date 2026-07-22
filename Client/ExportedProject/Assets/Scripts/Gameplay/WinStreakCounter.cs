using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WinStreakCounter : Core_BaseScript
{
	[Header("Core")]
	[FormerlySerializedAs("MBFFDJNPPPA")]
	public UILabel KGNGFHMBHMJ;

	[FormerlySerializedAs("FLOCNENJEPP")]
	[Header("Only for DogTag Dialog")]
	public UISprite LCIBNKDHAOL;

	[FormerlySerializedAs("JPJAPOABOFI")]
	public Action JEMKCLKCOMI;

	[FormerlySerializedAs("CLKEEJALIED")]
	public Action FINAFBAHMLD;

	private bool AHPPKNAFMJN;

	private int CLEGBKAFDFF;

	private int HHOALPDIHOA;

	private int DKHAPGCCCBE;

	internal void GKEIBNNJAEH()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(EJNIGEEPCMA));
	}

	private void JGOBMLDJBHJ()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF).ToLower();
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void LBDLFOKEEHH()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(KHCHJBBAHHP));
	}

	private void BPLKLKHMPKH()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (num > DKHAPGCCCBE)
		{
			PEHBGMEHFEM();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "ID_PLAYERLEAGUEPROCESSINGHINT", string.Empty);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	private void HIMJDHMPKCC()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (num > DKHAPGCCCBE)
		{
			KEIIENDMKLN();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "ID_VIDEOSERVICE", string.Empty);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	private void INDIOEPHDBG()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	private void FLDEAGICEHF()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (num > DKHAPGCCCBE)
		{
			PEHBGMEHFEM();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "ShieldRechargeRate", string.Empty, IEJMLKBCDJB: false);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void JCMHGOGNMFO()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(OBANDAMGPBA));
	}

	public virtual string MAJKLAFDDON()
	{
		return MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "OK", string.Empty, IEJMLKBCDJB: false);
	}

	private void OBANDAMGPBA()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (currentTimestamp > DKHAPGCCCBE)
		{
			JCMHGOGNMFO();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - currentTimestamp;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "ID_READYTIME", string.Empty);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void GGKCMHOGFPF()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(CMFPPJLKNBJ));
	}

	public override string ToString()
	{
		return MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "ID_READYTIME", string.Empty);
	}

	internal void HBMOHJGIKHI(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(JKHKNOIFFFC));
		}
	}

	internal void BEGPPFLPAEJ(int DEHFFJNPFGA)
	{
		HHOALPDIHOA = DEHFFJNPFGA;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(FJLHIEAMOGK));
		}
		NIPAMELCCAK();
	}

	internal void HIAAPAJJMKC()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(AEEIMKAPPEJ));
	}

	private void NIPAMELCCAK()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.currentTimestamp - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF).ToLower();
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void CPJNFNIJEFM()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(FJLHIEAMOGK));
	}

	internal void BIIIPBJDPNJ()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(INDIOEPHDBG));
	}

	internal void PDALGKPNBMC()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(IMFKIFKKNKI));
	}

	public virtual string ONLNILBHKJJ()
	{
		return MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "YourIdentityPoolId", string.Empty);
	}

	private void BPKEJPGJOLN()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (num > DKHAPGCCCBE)
		{
			IOKMGDJGLMK();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "ChangeWeaponsRPC", string.Empty, IEJMLKBCDJB: false);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
			if (LCIBNKDHAOL != null)
			{
				LCIBNKDHAOL.fillAmount = Singleton<DogTagManager>.instance.DIHEMPNCPBP();
			}
		}
	}

	private void CMFPPJLKNBJ()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (num > DKHAPGCCCBE)
		{
			KEIIENDMKLN();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "unlockLevel", string.Empty, IEJMLKBCDJB: false);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	private void PLOJBNKCOGO()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (num > DKHAPGCCCBE)
		{
			FHPIJEDMPMK();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "ID_INVITATIONDENIED", string.Empty, IEJMLKBCDJB: false);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
			if (LCIBNKDHAOL != null)
			{
				LCIBNKDHAOL.fillAmount = Singleton<DogTagManager>.instance.DIHEMPNCPBP();
			}
		}
	}

	internal void APFDDFPMACA(int CJJHPGFOHCH)
	{
		DKHAPGCCCBE = CJJHPGFOHCH;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(DGMFMCDPGAN));
		}
		HIMJDHMPKCC();
	}

	internal void FAOHPOJPAIM()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(KNOFLKEKBIJ));
	}

	internal void DHNCPJKEFDF(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.currentTimestamp + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(NJPAJGCCCKJ));
		}
	}

	internal void IANIKLCCOOG(int DEHFFJNPFGA)
	{
		HHOALPDIHOA = DEHFFJNPFGA;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(DCGIBAOHMHG));
		}
		DCGIBAOHMHG();
	}

	internal void NDGMJPDLPJL()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(DCGIBAOHMHG));
	}

	private void FJLHIEAMOGK()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.currentTimestamp - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF).ToLower();
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	private void EJNIGEEPCMA()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.currentTimestamp - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	public virtual string PIIFABFBKLM()
	{
		return MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "Loading assignment data after GAME!!", string.Empty);
	}

	private void KALCAILBPCF()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void OANDDHKJDOB(int CJJHPGFOHCH)
	{
		DKHAPGCCCBE = CJJHPGFOHCH;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(LFHPGHOHMGK));
		}
		OBANDAMGPBA();
	}

	internal void GCMANNCPADK(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(PLOJBNKCOGO));
		}
	}

	internal void EEJODEKFIOP(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.currentTimestamp + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(KDJGFOOLOLI));
		}
	}

	internal void CADEIHGOCJJ()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(INDIOEPHDBG));
	}

	private void CBDOMKEGAGB()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.currentTimestamp - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF).ToLower();
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void FHPIJEDMPMK()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(KDJGFOOLOLI));
	}

	private void KNOFLKEKBIJ()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (num > DKHAPGCCCBE)
		{
			FAOHPOJPAIM();
			KGNGFHMBHMJ.text = Localization.Localize("ID_POISONDAMAGE");
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = string.Format("SpawnAIObjectRPC", Localization.Localize("GameReward"), Colours.stringBlue, MEJMLNDFDBP.ABKAOAODKGC(CLEGBKAFDFF));
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void KBMDABJMLLK()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(OJDLGNIEBBD));
	}

	internal void IOKMGDJGLMK()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(JKHKNOIFFFC));
	}

	internal void FCGPLOBEHDL()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(OBANDAMGPBA));
	}

	internal void OLEBFAOENPK()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(PHEHOEHHBGN));
	}

	internal void PIJABEKKJCJ()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(ANLLKPFIGBI));
	}

	private void AEEIMKAPPEJ()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void KEIIENDMKLN()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(CMFPPJLKNBJ));
	}

	internal void NGAGEBGHCKL(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.currentTimestamp + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(IMFKIFKKNKI));
		}
	}

	private void OJDLGNIEBBD()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (num > DKHAPGCCCBE)
		{
			FAOHPOJPAIM();
			KGNGFHMBHMJ.text = Localization.Localize("Card_3_Played");
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = string.Format("#Mission Rewards# 5 Heroic Missions completed. Gained {0} scraps", Localization.Localize("END SCREEN - BUTTONS - enabled "), Colours.stringBlue, MEJMLNDFDBP.ABKAOAODKGC(CLEGBKAFDFF));
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void ENOEHMMJFEM(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(BPKEJPGJOLN));
		}
	}

	internal void BGHNMCPLIPE()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(EMOJOODPACG));
	}

	private void KDJGFOOLOLI()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (currentTimestamp > DKHAPGCCCBE)
		{
			FHPIJEDMPMK();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - currentTimestamp;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "ID_READYTIME", string.Empty);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
			if (LCIBNKDHAOL != null)
			{
				LCIBNKDHAOL.fillAmount = Singleton<DogTagManager>.instance.progressToNextDogtag;
			}
		}
	}

	internal void FLIBLFBLOEL()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(PHEHOEHHBGN));
	}

	private void NJPAJGCCCKJ()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (num > DKHAPGCCCBE)
		{
			FCCMIGMMDEG();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "resizing texture ", string.Empty);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
			if (LCIBNKDHAOL != null)
			{
				LCIBNKDHAOL.fillAmount = Singleton<DogTagManager>.instance.NKJKAFCELIP();
			}
		}
	}

	internal void HBHJHDENFKL(int DEHFFJNPFGA)
	{
		HHOALPDIHOA = DEHFFJNPFGA;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(FJLHIEAMOGK));
		}
		DCGIBAOHMHG();
	}

	internal void LEBHLKNHMJP()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(DCGIBAOHMHG));
	}

	private void ANLLKPFIGBI()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (num > DKHAPGCCCBE)
		{
			PIJABEKKJCJ();
			KGNGFHMBHMJ.text = Localization.Localize("game-engi-progress-fill");
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = string.Format("Quit called for game controller.", Localization.Localize("no player Id found"), Colours.stringBlue, MEJMLNDFDBP.ABKAOAODKGC(CLEGBKAFDFF));
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void ONLMEDMBBBE(int DEHFFJNPFGA)
	{
		HHOALPDIHOA = DEHFFJNPFGA;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(FJLHIEAMOGK));
		}
		CBDOMKEGAGB();
	}

	internal void HKOILGFPDFI(int KJCKFGCLGLG)
	{
		HHOALPDIHOA = KJCKFGCLGLG;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(PHEHOEHHBGN));
		}
		INDIOEPHDBG();
	}

	internal void PEHBGMEHFEM()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(LFHPGHOHMGK));
	}

	internal void CFMAJBLPNII()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(DCGIBAOHMHG));
	}

	internal void OHMPLNIBFCL(int DEHFFJNPFGA)
	{
		HHOALPDIHOA = DEHFFJNPFGA;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(NIPAMELCCAK));
		}
		JGOBMLDJBHJ();
	}

	internal void NLLOFLEJHHD(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.currentTimestamp + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(KDJGFOOLOLI));
		}
	}

	public virtual string CIJPPHFEBNI()
	{
		return MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, ".", string.Empty);
	}

	internal void MIOOAOFMLIE(int CJJHPGFOHCH)
	{
		DKHAPGCCCBE = CJJHPGFOHCH;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(BPLKLKHMPKH));
		}
		LFHPGHOHMGK();
	}

	internal void KFNPIDADLAN()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(INDIOEPHDBG));
	}

	internal void ADCEKPMAECL(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(IMFKIFKKNKI));
		}
	}

	private void IMFKIFKKNKI()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (currentTimestamp > DKHAPGCCCBE)
		{
			PDALGKPNBMC();
			KGNGFHMBHMJ.text = Localization.Localize("ID_EXPIRED");
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - currentTimestamp;
			KGNGFHMBHMJ.text = string.Format("{0} {1}{2}", Localization.Localize("ID_EXPIRESIN"), Colours.stringBlue, MEJMLNDFDBP.ABKAOAODKGC(CLEGBKAFDFF));
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void DABFLOCDIDF(int KJCKFGCLGLG)
	{
		HHOALPDIHOA = KJCKFGCLGLG;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(PHEHOEHHBGN));
		}
		AEEIMKAPPEJ();
	}

	private void LFHPGHOHMGK()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (currentTimestamp > DKHAPGCCCBE)
		{
			FCGPLOBEHDL();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - currentTimestamp;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "GameLauncher.Async done", string.Empty, IEJMLKBCDJB: false);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void NMIOIBNFEEG(int DEHFFJNPFGA)
	{
		HHOALPDIHOA = DEHFFJNPFGA;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(NIPAMELCCAK));
		}
		NIPAMELCCAK();
	}

	internal void MAIGOCFPIMN(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.currentTimestamp + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(ANLLKPFIGBI));
		}
	}

	private void PHEHOEHHBGN()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.currentTimestamp - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	private void DGMFMCDPGAN()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (num > DKHAPGCCCBE)
		{
			KEIIENDMKLN();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "ID_SALEPERCENTLINE", string.Empty);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	private void JKHKNOIFFFC()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (currentTimestamp > DKHAPGCCCBE)
		{
			FHPIJEDMPMK();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - currentTimestamp;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "-[0-9]*$", string.Empty, IEJMLKBCDJB: false);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
			if (LCIBNKDHAOL != null)
			{
				LCIBNKDHAOL.fillAmount = Singleton<DogTagManager>.instance.progressToNextDogtag;
			}
		}
	}

	internal void FCCMIGMMDEG()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(BPKEJPGJOLN));
	}

	internal void MHLJHMOPDAO(int CJJHPGFOHCH)
	{
		DKHAPGCCCBE = CJJHPGFOHCH;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(OBANDAMGPBA));
		}
		OBANDAMGPBA();
	}

	internal void GMOBMDEGDPG(int KJCKFGCLGLG)
	{
		HHOALPDIHOA = KJCKFGCLGLG;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(INDIOEPHDBG));
		}
		PHEHOEHHBGN();
	}

	internal void GBODNLMPDIA(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(KNOFLKEKBIJ));
		}
	}

	private void DCGIBAOHMHG()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.currentTimestamp - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF).ToLower();
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void DNDFBJDJEOF(int KJCKFGCLGLG)
	{
		HHOALPDIHOA = KJCKFGCLGLG;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(AEEIMKAPPEJ));
		}
		AEEIMKAPPEJ();
	}

	internal void EAGAONNPFJB(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.currentTimestamp + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(IMFKIFKKNKI));
		}
	}

	private void EMOJOODPACG()
	{
		if (!AHPPKNAFMJN)
		{
			return;
		}
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (num > DKHAPGCCCBE)
		{
			KEIIENDMKLN();
			if (JEMKCLKCOMI != null)
			{
				JEMKCLKCOMI();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = DKHAPGCCCBE - num;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "1", string.Empty);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}

	internal void KOCFBGNLJMM()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(AEEIMKAPPEJ));
	}

	public virtual string KLCMKLFPBMN()
	{
		return MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "Daily Mission Record {0:D2}", string.Empty);
	}

	internal void PJKAPMCPNJD()
	{
		AHPPKNAFMJN = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.KBBAJKEFIOI = (Action)Delegate.Remove(instance.KBBAJKEFIOI, new Action(PHEHOEHHBGN));
	}

	internal void MNJBACJEGGK(int KJCKFGCLGLG)
	{
		HHOALPDIHOA = KJCKFGCLGLG;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.KBBAJKEFIOI = (Action)Delegate.Combine(instance.KBBAJKEFIOI, new Action(EJNIGEEPCMA));
		}
		EJNIGEEPCMA();
	}

	internal void JOEBIBMJEAF(int HNDGIJBHMOD)
	{
		DKHAPGCCCBE = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + HNDGIJBHMOD;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(JKHKNOIFFFC));
		}
	}

	public virtual string FOOMIBECINC()
	{
		return MEJMLNDFDBP.CJCFPDLDMEK(CLEGBKAFDFF, "#AccoutCheck# GPGS login during tutorial", string.Empty, IEJMLKBCDJB: false);
	}

	internal void LOINIDOGNCO()
	{
		AHPPKNAFMJN = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(FLDEAGICEHF));
	}

	internal void FPNEIICLJFG(int CJJHPGFOHCH)
	{
		DKHAPGCCCBE = CJJHPGFOHCH;
		if (!AHPPKNAFMJN)
		{
			AHPPKNAFMJN = false;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Combine(instance.MPCAACLAGOA, new Action(BPLKLKHMPKH));
		}
		CMFPPJLKNBJ();
	}

	private void KHCHJBBAHHP()
	{
		if (AHPPKNAFMJN && base.gameObject.activeInHierarchy)
		{
			CLEGBKAFDFF = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - HHOALPDIHOA;
			KGNGFHMBHMJ.text = MEJMLNDFDBP.AIDNACCDDLF(CLEGBKAFDFF);
			if (FINAFBAHMLD != null)
			{
				FINAFBAHMLD();
			}
		}
	}
}
