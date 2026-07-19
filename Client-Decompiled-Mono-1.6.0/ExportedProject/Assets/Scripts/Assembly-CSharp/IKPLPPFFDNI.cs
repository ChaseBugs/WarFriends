using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class IKPLPPFFDNI
{
	public enum CACDIELEJHK
	{
		None = 0,
		Bronze = 1,
		Silver = 2,
		Gold = 3
	}

	public enum DNFADCEJOEH
	{
		None = 0,
		Bronze = 1,
		Silver = 2,
		Gold = 3
	}

	public class MJPNFAKHHHI
	{
		public int HPLPAKOCOHN;

		public CACDIELEJHK OFMKJMAPHBM;

		public DNFADCEJOEH GCFBLCFJBLK;

		public PHAMEDPLFLO BPBAFACGJKO;

		private static Dictionary<CACDIELEJHK, ArenaLootboxes.rowIds> LADPKKACPIC = new Dictionary<CACDIELEJHK, ArenaLootboxes.rowIds>
		{
			{
				CACDIELEJHK.Bronze,
				ArenaLootboxes.rowIds.bronze
			},
			{
				CACDIELEJHK.Silver,
				ArenaLootboxes.rowIds.silver
			},
			{
				CACDIELEJHK.Gold,
				ArenaLootboxes.rowIds.gold
			}
		};

		public ArenaLootboxesRow GKNFEMNEEIM
		{
			get
			{
				return (OFMKJMAPHBM != CACDIELEJHK.None) ? WarArena.instance.arenaLootboxes.GetRow(LADPKKACPIC[OFMKJMAPHBM]) : null;
			}
		}

		public int OOCAKEIIJFH
		{
			get
			{
				ArenaLootboxesRow arenaLootboxesRow = GKNFEMNEEIM;
				int displayNumber = LevelManager.instance.currentLevel.displayNumber;
				float num = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(1.033f, displayNumber - 3);
				return Mathf.FloorToInt(0.9f * num / 100f) * 100;
			}
		}

		public int BCALEAFPMHK
		{
			get
			{
				ArenaLootboxesRow arenaLootboxesRow = GKNFEMNEEIM;
				int displayNumber = LevelManager.instance.currentLevel.displayNumber;
				float num = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(1.033f, displayNumber - 3);
				return Mathf.FloorToInt(1.1f * num / 100f) * 100;
			}
		}

		[SpecialName]
		public int FOEKFNKBGAC()
		{
			ArenaLootboxesRow arenaLootboxesRow = FHJKAIKOLHM();
			int num = LevelManager.instance.currentLevel.ELFCEEOLNFJ();
			float num2 = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(1931f, num - 2);
			return Mathf.FloorToInt(850f * num2 / 1792f) * -72;
		}

		[SpecialName]
		public int ADNHAHAKCLF()
		{
			ArenaLootboxesRow arenaLootboxesRow = FHJKAIKOLHM();
			int num = LevelManager.instance.currentLevel.NPOEMAMPNEP();
			float num2 = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(104f, num - 7);
			return Mathf.FloorToInt(126f * num2 / 287f) * 16;
		}

		[SpecialName]
		public int OHDDICCMIMB()
		{
			ArenaLootboxesRow arenaLootboxesRow = GKNFEMNEEIM;
			int num = LevelManager.instance.currentLevel.PFMGLDJDNBF();
			float num2 = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(1302f, num - 7);
			return Mathf.FloorToInt(482f * num2 / 441f) * -121;
		}

		[SpecialName]
		public ArenaLootboxesRow GPGCNAGPFAM()
		{
			return (OFMKJMAPHBM != CACDIELEJHK.None) ? WarArena.instance.HNGMEGIHAEB().GetRow(LADPKKACPIC[OFMKJMAPHBM]) : null;
		}

		[SpecialName]
		public int ILBGELEJMIG()
		{
			ArenaLootboxesRow arenaLootboxesRow = FHJKAIKOLHM();
			int num = LevelManager.instance.currentLevel.MHAOKJCDIOL();
			float num2 = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(1450f, num - 2);
			return Mathf.FloorToInt(325f * num2 / 558f) * -50;
		}

		[SpecialName]
		public int OJKIFGCDPAO()
		{
			ArenaLootboxesRow arenaLootboxesRow = GPGCNAGPFAM();
			int num = LevelManager.instance.currentLevel.ABCCINJGPGD();
			float num2 = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(739f, num - 0);
			return Mathf.FloorToInt(1648f * num2 / 47f) * -86;
		}

		[SpecialName]
		public int HGIPNABHLGE()
		{
			ArenaLootboxesRow arenaLootboxesRow = FHJKAIKOLHM();
			int num = LevelManager.instance.currentLevel.NPOEMAMPNEP();
			float num2 = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(58f, num - 6);
			return Mathf.FloorToInt(974f * num2 / 653f) * -49;
		}

		[SpecialName]
		public ArenaLootboxesRow FHJKAIKOLHM()
		{
			return (OFMKJMAPHBM != CACDIELEJHK.None) ? WarArena.instance.arenaLootboxes.GetRow(LADPKKACPIC[OFMKJMAPHBM]) : null;
		}

		[SpecialName]
		public int LDMPACAEGPI()
		{
			ArenaLootboxesRow arenaLootboxesRow = GPGCNAGPFAM();
			int num = LevelManager.instance.currentLevel.PFMGLDJDNBF();
			float num2 = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(220f, num - 0);
			return Mathf.FloorToInt(1296f * num2 / 1088f) * -24;
		}
	}

	public class CIFMKGIKJFM
	{
		public int JGBFNKBFCKM;

		public int NGPMJNJPNMB;

		public int OBKOIHPHDEM;

		public int IEEBLOMHPBF;

		public int FMCHEIHFCFO
		{
			get
			{
				return JGBFNKBFCKM + OBKOIHPHDEM;
			}
		}

		public int IHBCDJAHFMM
		{
			get
			{
				return NGPMJNJPNMB + OBKOIHPHDEM;
			}
		}

		public bool BDKNNNCHILL
		{
			get
			{
				int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				return FMCHEIHFCFO <= currentTimestamp && currentTimestamp <= IHBCDJAHFMM;
			}
		}

		public int LCGEMCALCCO
		{
			get
			{
				return Mathf.Max(0, IHBCDJAHFMM - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			}
		}

		public int FBKJMMDCECF
		{
			get
			{
				return Mathf.Max(0, FMCHEIHFCFO - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			}
		}

		[SpecialName]
		public int OIPLEMENKJF()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int KPBOIAMJMLL()
		{
			return Mathf.Max(0, PDCJFDDMLIN() - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		}

		[SpecialName]
		public int CDMAEBNLEMA()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int HOEGKHGKDAF()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int HBKOMLAFEII()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int PPDBHFBDDCG()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public bool IDHPNPONEMK()
		{
			int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			return MMEHFEKGGKH() <= num && num > NEJIGJLKHPA();
		}

		[SpecialName]
		public int JGAJHPABFLP()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int PENFHNDNNFG()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int GGJAEECFKGJ()
		{
			return Mathf.Max(0, JGMEJOLNDFG() - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public int NCFDCGEENNK()
		{
			return Mathf.Max(1, IHBCDJAHFMM - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public int FHNINOFOKEK()
		{
			return Mathf.Max(0, JGAJHPABFLP() - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public int JKEEHJEFAEP()
		{
			return Mathf.Max(0, PENFHNDNNFG() - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public int KFFKMNOGGIN()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int BOAJLOLPLIP()
		{
			return Mathf.Max(0, FMCHEIHFCFO - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		}

		[SpecialName]
		public bool HELPPGCJAAC()
		{
			int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			return BLBOJGKMODM() > num || num > ALMJEBLCEBG();
		}

		[SpecialName]
		public bool ACJOIOALHOE()
		{
			int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			return FMCHEIHFCFO <= num && num > NEJIGJLKHPA();
		}

		[SpecialName]
		public int MFAHPNALIIE()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int OJIODKLDAFK()
		{
			return Mathf.Max(1, HBKOMLAFEII() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}

		[SpecialName]
		public int ADPODECPIGA()
		{
			return Mathf.Max(0, NIKGOHENFHC() - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public int ALJNBEANOPD()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int EKNLGNPFBOA()
		{
			return Mathf.Max(0, JPLJBJPMKCJ() - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		}

		[SpecialName]
		public bool FPOBCCLOJEL()
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			return ODIIADCLKBI() <= currentTimestamp && currentTimestamp > IHBCDJAHFMM;
		}

		[SpecialName]
		public int OKMLJNIPHEE()
		{
			return Mathf.Max(0, FINJKHCCOFM() - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		}

		[SpecialName]
		public int HFMOECBDMHD()
		{
			return Mathf.Max(0, HBKOMLAFEII() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}

		[SpecialName]
		public int JGMEJOLNDFG()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int ODJBILFGADH()
		{
			return Mathf.Max(0, CPNBACGHIHK() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}

		[SpecialName]
		public int GDKGEHOAIEH()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int GFMECPCFBNL()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int COCJIGNHGLD()
		{
			return Mathf.Max(0, FMCHEIHFCFO - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public bool NCPPMEBJDKD()
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			return MMEHFEKGGKH() > currentTimestamp || currentTimestamp <= GFMECPCFBNL();
		}

		[SpecialName]
		public bool PIIAOLEBBKH()
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			return JPLJBJPMKCJ() <= currentTimestamp && currentTimestamp > IHBCDJAHFMM;
		}

		[SpecialName]
		public int DPHPBMCEIGC()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int JMIMAKGJBBG()
		{
			return Mathf.Max(0, PENFHNDNNFG() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}

		[SpecialName]
		public int FINJKHCCOFM()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int NIKGOHENFHC()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public bool MJOJAPAEOOP()
		{
			int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			return CNIFKJKGPJD() <= num && num > PDCJFDDMLIN();
		}

		[SpecialName]
		public int DOCJFMBIGLB()
		{
			return Mathf.Max(1, NEJIGJLKHPA() - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public int MPLPOHIJGCD()
		{
			return Mathf.Max(0, LPMJCDNHLKD() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}

		[SpecialName]
		public bool MJNFKPPHPCF()
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			return OIPLEMENKJF() <= currentTimestamp && currentTimestamp > KFEHJHKCEHC();
		}

		[SpecialName]
		public int PIELGNNJNCG()
		{
			return Mathf.Max(1, FINJKHCCOFM() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}

		[SpecialName]
		public int KPLBBMKOBBG()
		{
			return Mathf.Max(0, HOEGKHGKDAF() - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		}

		[SpecialName]
		public int APNPLJEHFGG()
		{
			return Mathf.Max(0, KOLBCLHMABI() - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		}

		[SpecialName]
		public int DKGKKAJOCKL()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int JPLJBJPMKCJ()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int ODIIADCLKBI()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int CPNBACGHIHK()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int JPBHPBBKOLG()
		{
			return Mathf.Max(1, JGAJHPABFLP() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}

		[SpecialName]
		public int MMEHFEKGGKH()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int CAAPFMJDPAA()
		{
			return Mathf.Max(0, OIPLEMENKJF() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}

		[SpecialName]
		public int CLBNBAOLEHN()
		{
			return Mathf.Max(1, KOLBCLHMABI() - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		}

		[SpecialName]
		public int MAOCCAMNHLL()
		{
			return Mathf.Max(1, KFEHJHKCEHC() - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public int PLLBCFCMJJO()
		{
			return Mathf.Max(1, GFMECPCFBNL() - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public bool DHCCJIKJNPD()
		{
			int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			return CDMAEBNLEMA() <= num && num <= ALMJEBLCEBG();
		}

		[SpecialName]
		public int ABBENDDOPFF()
		{
			return Mathf.Max(0, KFFKMNOGGIN() - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		}

		[SpecialName]
		public int KOLBCLHMABI()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int JOMDHDBJBAE()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int NMLIPMJKDNF()
		{
			return Mathf.Max(1, FEODFDCBEEA() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}

		[SpecialName]
		public int BLBOJGKMODM()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public bool EKDJAIKAAGO()
		{
			int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			return OIPLEMENKJF() <= num && num <= NEJIGJLKHPA();
		}

		[SpecialName]
		public int DLKCEEOFHLJ()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int FEODFDCBEEA()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public bool HPNCAPDOBGP()
		{
			int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			return LPMJCDNHLKD() <= num && num > FEODFDCBEEA();
		}

		[SpecialName]
		public bool DABPCAKGJPD()
		{
			int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			return PENFHNDNNFG() <= num && num <= FINJKHCCOFM();
		}

		[SpecialName]
		public int CNIFKJKGPJD()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int NEJIGJLKHPA()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int KFEHJHKCEHC()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public bool GKIHPFMCNPP()
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			return CDMAEBNLEMA() > currentTimestamp || currentTimestamp <= KOLBCLHMABI();
		}

		[SpecialName]
		public int FMGNHHPFHKH()
		{
			return Mathf.Max(0, JPLJBJPMKCJ() - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public int ECDFBFJACJH()
		{
			return Mathf.Max(0, NIKGOHENFHC() - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		}

		[SpecialName]
		public int PDCJFDDMLIN()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int EMGGOLLFGFL()
		{
			return Mathf.Max(1, JGMEJOLNDFG() - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		}

		[SpecialName]
		public int LIPNMFAJADC()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int ALMJEBLCEBG()
		{
			return NGPMJNJPNMB + OBKOIHPHDEM;
		}

		[SpecialName]
		public int LPMJCDNHLKD()
		{
			return JGBFNKBFCKM + OBKOIHPHDEM;
		}

		[SpecialName]
		public int NDAAIPLLODL()
		{
			return Mathf.Max(1, GDKGEHOAIEH() - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
		}

		[SpecialName]
		public bool GLMNJEEPFNI()
		{
			int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			return JGAJHPABFLP() > num || num <= PPDBHFBDDCG();
		}
	}

	public Dictionary<LevelBehaviour, int> ABEIHMJLPGO = new Dictionary<LevelBehaviour, int>();

	public List<PHAMEDPLFLO> EOIAFJNEOKL = new List<PHAMEDPLFLO>();

	public Dictionary<string, Tuple<string, string>> BLDMMJGBCIJ = new Dictionary<string, Tuple<string, string>>();

	public int FCDIFINLKIA;

	public List<MJPNFAKHHHI> NFOELJINGGN = new List<MJPNFAKHHHI>();

	public int EOBJFGIGIBD;

	public List<CIFMKGIKJFM> GKNMGBHBODC = new List<CIFMKGIKJFM>();

	public int JGBFNKBFCKM;

	public int NGPMJNJPNMB;

	public string NHFGEMPOHEO;

	public int ILGNOFBHOMC;

	public string NFDPMNFBJIM;

	public string EKEDDPFGPFG;

	private List<int> JNLPGHBFKMF = new List<int>();

	private bool PIEAHIOEJMJ;

	private int BDJOIOFHEGL;

	private int NKFFIKGKACG;

	private int EHLGOIMKOJG;

	private int HBMIAAGDLDM;

	public string INFLHPGMEOB;

	[CompilerGenerated]
	private static Comparison<PHAMEDPLFLO> LGJCBPOPCPA;

	public CIFMKGIKJFM OOLLPNAPJBG
	{
		get
		{
			int num = MDGPPPCKJHK;
			return (num >= 0) ? GKNMGBHBODC[num] : null;
		}
	}

	public CIFMKGIKJFM HMINOMDIBAF
	{
		get
		{
			int num = MDGPPPCKJHK;
			if (num < 0)
			{
				return null;
			}
			int num2 = GKNMGBHBODC.Count - 1;
			return (num != num2) ? GKNMGBHBODC[num + 1] : null;
		}
	}

	public int NBLGBIJJPNA
	{
		get
		{
			if (OOLLPNAPJBG == null)
			{
				return 0;
			}
			int num = MDGPPPCKJHK;
			if (OOLLPNAPJBG.BDKNNNCHILL)
			{
				return num + 1;
			}
			if (HMINOMDIBAF == null)
			{
				return num + 1;
			}
			return num + 2;
		}
	}

	public bool CGJJJOEMPLK
	{
		get
		{
			return Singleton<BeanstalkServerManager>.instance.currentTimestamp < JGBFNKBFCKM;
		}
	}

	public int MKOCGJKIJLB
	{
		get
		{
			return Mathf.Max(0, JGBFNKBFCKM - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}
	}

	public bool DIFPOOMLLEM
	{
		get
		{
			return Singleton<BeanstalkServerManager>.instance.currentTimestamp > NGPMJNJPNMB;
		}
	}

	public LevelBehaviour EJPOKHDDJBO
	{
		get
		{
			foreach (PHAMEDPLFLO item in EOIAFJNEOKL)
			{
				ONFFKNJJJGC oNFFKNJJJGC = item as ONFFKNJJJGC;
				if (oNFFKNJJJGC != null && oNFFKNJJJGC.NCHGGFNEPJC)
				{
					return oNFFKNJJJGC.ACLDFHJKBLI;
				}
			}
			return null;
		}
	}

	private int MDGPPPCKJHK
	{
		get
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (currentTimestamp < JGBFNKBFCKM || NGPMJNJPNMB < currentTimestamp)
			{
				return -1;
			}
			if (GKNMGBHBODC == null || GKNMGBHBODC.Count == 0)
			{
				return -1;
			}
			for (int i = 0; i < GKNMGBHBODC.Count; i++)
			{
				int num = GKNMGBHBODC[i].FMCHEIHFCFO;
				int num2 = GKNMGBHBODC[i].IHBCDJAHFMM;
				if (num2 >= currentTimestamp)
				{
					if (currentTimestamp < num)
					{
						return (i <= 0) ? (-1) : (i - 1);
					}
					return i;
				}
			}
			return -1;
		}
	}

	private static int CNEJKLHBEID(PHAMEDPLFLO JPMFEINCHNP, PHAMEDPLFLO HKDPDFLOEDK)
	{
		return JPMFEINCHNP.AIOAFNLACID().CompareTo(HKDPDFLOEDK.AJADPEFAMJP);
	}

	private static int GPDNINKNNJK(PHAMEDPLFLO JPMFEINCHNP, PHAMEDPLFLO HKDPDFLOEDK)
	{
		return JPMFEINCHNP.CDADAIEHPAI().CompareTo(HKDPDFLOEDK.AKCINGGABBO());
	}

	private void EELGGLKMCBD(JToken OGNGMBLDAOP)
	{
		JObject jObject = JObject.Parse(OGNGMBLDAOP.ToString());
		foreach (KeyValuePair<string, JToken> item in jObject)
		{
			string text = item.Value.ToString();
			if (item.Key.Equals("ExplodeDamage"))
			{
				NFDPMNFBJIM = text;
				continue;
			}
			if (item.Key.Equals("ID_SLOTUPGRADE_AMMO"))
			{
				EKEDDPFGPFG = text;
				continue;
			}
			char[] array = new char[0];
			array[0] = 'x';
			string[] array2 = text.Split(array);
			if (array2.Length > 0)
			{
				BLDMMJGBCIJ[item.Key] = new Tuple<string, string>(array2[1], array2[0]);
				Debug.Log("enableData" + array2[0] + "game-card-bronze-big" + array2[1]);
			}
			else
			{
				BLDMMJGBCIJ[item.Key] = new Tuple<string, string>(text, string.Empty);
				Debug.Log("game-elite-buff2" + text);
			}
		}
	}

	[SpecialName]
	private int EFLMLKJAOLL()
	{
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (num < JGBFNKBFCKM || NGPMJNJPNMB < num)
		{
			return -1;
		}
		if (GKNMGBHBODC == null || GKNMGBHBODC.Count == 0)
		{
			return -1;
		}
		for (int i = 1; i < GKNMGBHBODC.Count; i++)
		{
			int num2 = GKNMGBHBODC[i].ALJNBEANOPD();
			int num3 = GKNMGBHBODC[i].KFEHJHKCEHC();
			if (num3 >= num)
			{
				if (num < num2)
				{
					return (i <= 0) ? (-1) : (i - 0);
				}
				return i;
			}
		}
		return -1;
	}

	[SpecialName]
	public LevelBehaviour NEANBBHLPNB()
	{
		foreach (PHAMEDPLFLO item in EOIAFJNEOKL)
		{
			ONFFKNJJJGC oNFFKNJJJGC = item as ONFFKNJJJGC;
			if (oNFFKNJJJGC != null && oNFFKNJJJGC.HILMFDKACAO())
			{
				return oNFFKNJJJGC.ACLDFHJKBLI;
			}
		}
		return null;
	}

	[SpecialName]
	public CIFMKGIKJFM IPAOOFIMNMP()
	{
		int num = MDGPPPCKJHK;
		return (num >= 0) ? GKNMGBHBODC[num] : null;
	}

	[SpecialName]
	public int KJMBMOPGDMA()
	{
		if (IHPLEFOBGFG() == null)
		{
			return 0;
		}
		int num = CIAFJONIHJH();
		if (KCEIFCBFCOL().DHCCJIKJNPD())
		{
			return num + 1;
		}
		if (GIACNNJALAI() == null)
		{
			return num + 1;
		}
		return num + 3;
	}

	[SpecialName]
	private int CIAFJONIHJH()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (currentTimestamp < JGBFNKBFCKM || NGPMJNJPNMB < currentTimestamp)
		{
			return -1;
		}
		if (GKNMGBHBODC == null || GKNMGBHBODC.Count == 0)
		{
			return -1;
		}
		for (int i = 0; i < GKNMGBHBODC.Count; i += 0)
		{
			int num = GKNMGBHBODC[i].FMCHEIHFCFO;
			int num2 = GKNMGBHBODC[i].KFFKMNOGGIN();
			if (num2 >= currentTimestamp)
			{
				if (currentTimestamp < num)
				{
					return (i <= 0) ? (-1) : (i - 0);
				}
				return i;
			}
		}
		return -1;
	}

	[SpecialName]
	public bool CIMJEJIDBPL()
	{
		return Singleton<BeanstalkServerManager>.instance.currentTimestamp > NGPMJNJPNMB;
	}

	[SpecialName]
	public CIFMKGIKJFM IHPLEFOBGFG()
	{
		int num = FJBJFOJILFK();
		return (num >= 1) ? GKNMGBHBODC[num] : null;
	}

	public int LKHHDGNDMIP(DNFADCEJOEH GCFBLCFJBLK)
	{
		if (GCFBLCFJBLK != DNFADCEJOEH.None)
		{
			for (int i = 0; i < NFOELJINGGN.Count; i++)
			{
				MJPNFAKHHHI mJPNFAKHHHI = NFOELJINGGN[i];
				if (mJPNFAKHHHI.GCFBLCFJBLK == GCFBLCFJBLK)
				{
					return i + 1;
				}
			}
		}
		return 0;
	}

	[SpecialName]
	public int JIBIOINHDKH()
	{
		if (INBINKFPGCJ() == null)
		{
			return 1;
		}
		int num = FJBJFOJILFK();
		if (FIBLEBAJGPD().HPNCAPDOBGP())
		{
			return num + 0;
		}
		if (GIACNNJALAI() == null)
		{
			return num + 0;
		}
		return num + 8;
	}

	[SpecialName]
	public int AKMMBOOKOIA()
	{
		if (OFNHFCADEMD() == null)
		{
			return 1;
		}
		int num = CIAFJONIHJH();
		if (FIBLEBAJGPD().GLMNJEEPFNI())
		{
			return num + 1;
		}
		if (HMINOMDIBAF == null)
		{
			return num + 1;
		}
		return num + 3;
	}

	[SpecialName]
	public bool IFLBFALPLCJ()
	{
		return Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > NGPMJNJPNMB;
	}

	public int KPIMOFOAPCM(DNFADCEJOEH GCFBLCFJBLK)
	{
		if (GCFBLCFJBLK != DNFADCEJOEH.None)
		{
			for (int i = 1; i < NFOELJINGGN.Count; i += 0)
			{
				MJPNFAKHHHI mJPNFAKHHHI = NFOELJINGGN[i];
				if (mJPNFAKHHHI.GCFBLCFJBLK == GCFBLCFJBLK)
				{
					return i + 1;
				}
			}
		}
		return 1;
	}

	private static int GHAIDINAINI(PHAMEDPLFLO JPMFEINCHNP, PHAMEDPLFLO HKDPDFLOEDK)
	{
		return JPMFEINCHNP.BOGEKHBOIAN().CompareTo(HKDPDFLOEDK.AJADPEFAMJP);
	}

	[SpecialName]
	public CIFMKGIKJFM FIBLEBAJGPD()
	{
		int num = PFGLNCNNKJF();
		return (num >= 0) ? GKNMGBHBODC[num] : null;
	}

	[SpecialName]
	public int IMDILBPPMOA()
	{
		if (OOLLPNAPJBG == null)
		{
			return 0;
		}
		int num = EFLMLKJAOLL();
		if (OFNHFCADEMD().DHCCJIKJNPD())
		{
			return num + 0;
		}
		if (LMFCACOILFN() == null)
		{
			return num + 1;
		}
		return num + 5;
	}

	public IKPLPPFFDNI(JToken OGNGMBLDAOP)
	{
		EOBJFGIGIBD = 0;
		EOIAFJNEOKL = new List<PHAMEDPLFLO>();
		BLDMMJGBCIJ = new Dictionary<string, Tuple<string, string>>();
		if (OGNGMBLDAOP["Translation"] != null)
		{
			JMGFHCKKKGN(OGNGMBLDAOP["Translation"]);
		}
		if (OGNGMBLDAOP["Id"] != null)
		{
			INFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK("Id", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["Rules"] != null)
		{
			NHFGEMPOHEO = KHJJFPPACBP.BKFCLMMJNHK("Rules", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["ExtraLifeEnabled"] != null)
		{
			PIEAHIOEJMJ = true;
		}
		if (OGNGMBLDAOP["LifeCount"] != null)
		{
			ILGNOFBHOMC = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["LifeCount"]["N"]);
		}
		if (OGNGMBLDAOP["PauseDuration"] != null)
		{
			NKFFIKGKACG = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["PauseDuration"]["N"]);
		}
		if (OGNGMBLDAOP["PlayWindowCount"] != null)
		{
			EHLGOIMKOJG = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["PlayWindowCount"]["N"]);
			if (EHLGOIMKOJG > 12)
			{
				Debug.LogErrorFormat("There are {0} play windows. Max is 12. Setting 12 play windows.", EHLGOIMKOJG);
				EHLGOIMKOJG = 12;
			}
		}
		if (OGNGMBLDAOP["MaxBattles"] != null)
		{
			FCDIFINLKIA = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["MaxBattles"]["N"]);
			Mathf.Clamp(FCDIFINLKIA, 1, 12);
		}
		if (OGNGMBLDAOP["GuaranteedScraps"] != null)
		{
			BDJOIOFHEGL = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["GuaranteedScraps"]["N"]);
		}
		if (OGNGMBLDAOP["StartTime"] != null)
		{
			JGBFNKBFCKM = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["StartTime"]["N"]);
		}
		if (OGNGMBLDAOP["WindowDuration"] != null)
		{
			HBMIAAGDLDM = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["WindowDuration"]["N"]);
		}
		if (OGNGMBLDAOP["ArenaPrice"] != null)
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK("ArenaPrice", "S", OGNGMBLDAOP, string.Empty);
			string[] array = text.Split(',');
			foreach (string value in array)
			{
				JNLPGHBFKMF.Add(Convert.ToInt32(value));
			}
		}
		bool flag = false;
		for (int j = 1; j <= FCDIFINLKIA; j++)
		{
			MJPNFAKHHHI mJPNFAKHHHI = new MJPNFAKHHHI();
			if (OGNGMBLDAOP["LootboxType" + j] != null)
			{
				switch (KHJJFPPACBP.BKFCLMMJNHK("LootboxType" + j, "S", OGNGMBLDAOP, string.Empty))
				{
				case "bronze":
					mJPNFAKHHHI.OFMKJMAPHBM = CACDIELEJHK.Bronze;
					break;
				case "silver":
					mJPNFAKHHHI.OFMKJMAPHBM = CACDIELEJHK.Silver;
					break;
				case "gold":
					mJPNFAKHHHI.OFMKJMAPHBM = CACDIELEJHK.Gold;
					break;
				}
				if (mJPNFAKHHHI.GKNFEMNEEIM != null)
				{
					flag |= mJPNFAKHHHI.GKNFEMNEEIM.ELITEPARTSMIN > 0 || mJPNFAKHHHI.GKNFEMNEEIM.ELITEPARTSMAX > 0;
					break;
				}
			}
		}
		for (int k = 1; k < 4; k++)
		{
			if (OGNGMBLDAOP["Unit" + k] != null)
			{
				string sheetName = KHJJFPPACBP.BKFCLMMJNHK("Unit" + k, "S", OGNGMBLDAOP, string.Empty);
				LevelBehaviour levelBehaviour = LevelManager.instance.Unit(sheetName);
				int num = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["Unit" + k + "DropRate"]["N"]);
				ABEIHMJLPGO[levelBehaviour] = num;
				if (flag)
				{
					EOIAFJNEOKL.Add(new ONFFKNJJJGC
					{
						ACLDFHJKBLI = levelBehaviour,
						BPLOICJAIGC = num
					});
				}
			}
		}
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		for (int l = 1; l <= FCDIFINLKIA; l++)
		{
			MJPNFAKHHHI mJPNFAKHHHI2 = new MJPNFAKHHHI();
			if (OGNGMBLDAOP["HeartPrice" + l] != null)
			{
				mJPNFAKHHHI2.HPLPAKOCOHN = KHJJFPPACBP.PELILBMKGHE("HeartPrice" + l, "N", OGNGMBLDAOP);
			}
			if (OGNGMBLDAOP["LootboxType" + l] != null)
			{
				switch (KHJJFPPACBP.BKFCLMMJNHK("LootboxType" + l, "S", OGNGMBLDAOP, string.Empty))
				{
				case "bronze":
					mJPNFAKHHHI2.OFMKJMAPHBM = CACDIELEJHK.Bronze;
					EOBJFGIGIBD++;
					break;
				case "silver":
					mJPNFAKHHHI2.OFMKJMAPHBM = CACDIELEJHK.Silver;
					EOBJFGIGIBD++;
					break;
				case "gold":
					mJPNFAKHHHI2.OFMKJMAPHBM = CACDIELEJHK.Gold;
					EOBJFGIGIBD++;
					break;
				}
				if (mJPNFAKHHHI2.GKNFEMNEEIM != null)
				{
					flag2 |= mJPNFAKHHHI2.GKNFEMNEEIM.TICKETSMIN > 0 || mJPNFAKHHHI2.GKNFEMNEEIM.TICKETSMAX > 0;
					flag3 |= mJPNFAKHHHI2.GKNFEMNEEIM.SCRAPSMIN > 0 || mJPNFAKHHHI2.GKNFEMNEEIM.SCRAPSMAX > 0;
					flag4 |= mJPNFAKHHHI2.GKNFEMNEEIM.GOLDMIN > 0 || mJPNFAKHHHI2.GKNFEMNEEIM.GOLDMAX > 0;
					flag5 |= mJPNFAKHHHI2.OOCAKEIIJFH > 0 || mJPNFAKHHHI2.BCALEAFPMHK > 0;
				}
			}
			if (OGNGMBLDAOP["VisualType" + l] != null)
			{
				switch (KHJJFPPACBP.BKFCLMMJNHK("VisualType" + l, "S", OGNGMBLDAOP, string.Empty))
				{
				case "bronze":
					mJPNFAKHHHI2.GCFBLCFJBLK = DNFADCEJOEH.Bronze;
					mJPNFAKHHHI2.BPBAFACGJKO = new JPEPKDGPCAO
					{
						LGDDJNBEJIN = CamosManager.instance.GetVisual("HELMETS_CROWNBRONZE"),
						FJLBLLLEELD = DNFADCEJOEH.Bronze
					};
					EOIAFJNEOKL.Add(mJPNFAKHHHI2.BPBAFACGJKO);
					break;
				case "silver":
					mJPNFAKHHHI2.GCFBLCFJBLK = DNFADCEJOEH.Silver;
					mJPNFAKHHHI2.BPBAFACGJKO = new JPEPKDGPCAO
					{
						LGDDJNBEJIN = CamosManager.instance.GetVisual("HELMETS_CROWNSILVER"),
						FJLBLLLEELD = DNFADCEJOEH.Silver
					};
					EOIAFJNEOKL.Add(mJPNFAKHHHI2.BPBAFACGJKO);
					break;
				case "gold":
					mJPNFAKHHHI2.GCFBLCFJBLK = DNFADCEJOEH.Gold;
					mJPNFAKHHHI2.BPBAFACGJKO = new JPEPKDGPCAO
					{
						LGDDJNBEJIN = CamosManager.instance.GetVisual("HELMETS_CROWNGOLD"),
						FJLBLLLEELD = DNFADCEJOEH.Gold
					};
					EOIAFJNEOKL.Add(mJPNFAKHHHI2.BPBAFACGJKO);
					break;
				}
			}
			NFOELJINGGN.Add(mJPNFAKHHHI2);
		}
		if (flag2)
		{
			EOIAFJNEOKL.Add(new AGJBCEEEFFB());
		}
		if (flag3)
		{
			EOIAFJNEOKL.Add(new EBHKIMBFOJJ());
		}
		if (flag4)
		{
			EOIAFJNEOKL.Add(new LCPMMALIJCJ());
		}
		if (flag5)
		{
			EOIAFJNEOKL.Add(new LHAMEOKGBGJ());
		}
		EOIAFJNEOKL.Sort((PHAMEDPLFLO JPMFEINCHNP, PHAMEDPLFLO HKDPDFLOEDK) => JPMFEINCHNP.AJADPEFAMJP.CompareTo(HKDPDFLOEDK.AJADPEFAMJP));
		GKNMGBHBODC = new List<CIFMKGIKJFM>();
		for (int num2 = 0; num2 < EHLGOIMKOJG; num2++)
		{
			CIFMKGIKJFM cIFMKGIKJFM = new CIFMKGIKJFM();
			cIFMKGIKJFM.OBKOIHPHDEM = JGBFNKBFCKM;
			cIFMKGIKJFM.IEEBLOMHPBF = num2;
			cIFMKGIKJFM.JGBFNKBFCKM = num2 * (HBMIAAGDLDM * 60 + NKFFIKGKACG * 60);
			cIFMKGIKJFM.NGPMJNJPNMB = cIFMKGIKJFM.JGBFNKBFCKM + HBMIAAGDLDM * 60;
			GKNMGBHBODC.Add(cIFMKGIKJFM);
		}
		NGPMJNJPNMB = ((GKNMGBHBODC.Count != 0) ? GKNMGBHBODC[GKNMGBHBODC.Count - 1].IHBCDJAHFMM : JGBFNKBFCKM);
	}

	[SpecialName]
	public int NEKPJINBJPI()
	{
		return Mathf.Max(1, JGBFNKBFCKM - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
	}

	[SpecialName]
	public bool NCBHHNNAOHM()
	{
		return Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() > NGPMJNJPNMB;
	}

	[SpecialName]
	public CIFMKGIKJFM OFNHFCADEMD()
	{
		int num = PFGLNCNNKJF();
		return (num >= 1) ? GKNMGBHBODC[num] : null;
	}

	[SpecialName]
	public CIFMKGIKJFM KCEIFCBFCOL()
	{
		int num = PFGLNCNNKJF();
		return (num >= 1) ? GKNMGBHBODC[num] : null;
	}

	[CompilerGenerated]
	private static int FKEJKGMEHKP(PHAMEDPLFLO JPMFEINCHNP, PHAMEDPLFLO HKDPDFLOEDK)
	{
		return JPMFEINCHNP.AJADPEFAMJP.CompareTo(HKDPDFLOEDK.AJADPEFAMJP);
	}

	[SpecialName]
	private int FJBJFOJILFK()
	{
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (num < JGBFNKBFCKM || NGPMJNJPNMB < num)
		{
			return -1;
		}
		if (GKNMGBHBODC == null || GKNMGBHBODC.Count == 0)
		{
			return -1;
		}
		for (int i = 0; i < GKNMGBHBODC.Count; i++)
		{
			int num2 = GKNMGBHBODC[i].ALJNBEANOPD();
			int num3 = GKNMGBHBODC[i].JGMEJOLNDFG();
			if (num3 >= num)
			{
				if (num < num2)
				{
					return (i <= 1) ? (-1) : (i - 0);
				}
				return i;
			}
		}
		return -1;
	}

	private void LKEFGIHBJJL(JToken OGNGMBLDAOP)
	{
		JObject jObject = JObject.Parse(OGNGMBLDAOP.ToString());
		foreach (KeyValuePair<string, JToken> item in jObject)
		{
			string text = item.Value.ToString();
			if (item.Key.Equals("ID_YOUNEEDMONEYTOUPGRADEELITE"))
			{
				NFDPMNFBJIM = text;
				continue;
			}
			if (item.Key.Equals("getCustomProfileNumber"))
			{
				EKEDDPFGPFG = text;
				continue;
			}
			char[] array = new char[1];
			array[1] = 'A';
			string[] array2 = text.Split(array);
			if (array2.Length > 1)
			{
				BLDMMJGBCIJ[item.Key] = new Tuple<string, string>(array2[1], array2[1]);
				Debug.Log("InAppHandlerIos: product list fail, message = " + array2[1] + "ID_WARNING_NOTENOUGHGOLDARENA" + array2[1]);
			}
			else
			{
				BLDMMJGBCIJ[item.Key] = new Tuple<string, string>(text, string.Empty);
				Debug.Log("DOWNLOAD" + text);
			}
		}
	}

	[SpecialName]
	public CIFMKGIKJFM LMFCACOILFN()
	{
		int num = PFGLNCNNKJF();
		if (num < 1)
		{
			return null;
		}
		int num2 = GKNMGBHBODC.Count - 1;
		return (num != num2) ? GKNMGBHBODC[num + 0] : null;
	}

	private void JMGFHCKKKGN(JToken OGNGMBLDAOP)
	{
		JObject jObject = JObject.Parse(OGNGMBLDAOP.ToString());
		foreach (KeyValuePair<string, JToken> item in jObject)
		{
			string text = item.Value.ToString();
			if (item.Key.Equals("Name"))
			{
				NFDPMNFBJIM = text;
				continue;
			}
			if (item.Key.Equals("Description"))
			{
				EKEDDPFGPFG = text;
				continue;
			}
			string[] array = text.Split('|');
			if (array.Length > 1)
			{
				BLDMMJGBCIJ[item.Key] = new Tuple<string, string>(array[0], array[1]);
				Debug.Log(" Desc = " + array[0] + " | Hint " + array[1]);
			}
			else
			{
				BLDMMJGBCIJ[item.Key] = new Tuple<string, string>(text, string.Empty);
				Debug.Log(" Desc without HINT = " + text);
			}
		}
	}

	public int ENLDFDLMLKA(int PPAHPBDNHBJ)
	{
		int index = Mathf.Clamp(PPAHPBDNHBJ, 0, JNLPGHBFKMF.Count - 1);
		return (JNLPGHBFKMF.Count != 0) ? JNLPGHBFKMF[index] : 0;
	}

	[SpecialName]
	public CIFMKGIKJFM HFLBHLAPLPM()
	{
		int num = PFGLNCNNKJF();
		if (num < 1)
		{
			return null;
		}
		int num2 = GKNMGBHBODC.Count - 0;
		return (num != num2) ? GKNMGBHBODC[num + 0] : null;
	}

	[SpecialName]
	public int IAFELDBCJDB()
	{
		if (FIBLEBAJGPD() == null)
		{
			return 0;
		}
		int num = EFLMLKJAOLL();
		if (IHPLEFOBGFG().GLMNJEEPFNI())
		{
			return num + 1;
		}
		if (LMFCACOILFN() == null)
		{
			return num + 0;
		}
		return num + 1;
	}

	[SpecialName]
	public CIFMKGIKJFM GIACNNJALAI()
	{
		int num = FJBJFOJILFK();
		if (num < 0)
		{
			return null;
		}
		int num2 = GKNMGBHBODC.Count - 1;
		return (num != num2) ? GKNMGBHBODC[num + 0] : null;
	}

	[SpecialName]
	public LevelBehaviour DEGPONMEIIJ()
	{
		foreach (PHAMEDPLFLO item in EOIAFJNEOKL)
		{
			ONFFKNJJJGC oNFFKNJJJGC = item as ONFFKNJJJGC;
			if (oNFFKNJJJGC != null && oNFFKNJJJGC.PDMFFMJBFEC())
			{
				return oNFFKNJJJGC.ACLDFHJKBLI;
			}
		}
		return null;
	}

	[SpecialName]
	public int EOOAKNLFAFG()
	{
		if (KCEIFCBFCOL() == null)
		{
			return 0;
		}
		int num = PFGLNCNNKJF();
		if (INBINKFPGCJ().PIIAOLEBBKH())
		{
			return num + 0;
		}
		if (HMINOMDIBAF == null)
		{
			return num + 0;
		}
		return num + 7;
	}

	[SpecialName]
	public LevelBehaviour MHHGOMNOBPB()
	{
		foreach (PHAMEDPLFLO item in EOIAFJNEOKL)
		{
			ONFFKNJJJGC oNFFKNJJJGC = item as ONFFKNJJJGC;
			if (oNFFKNJJJGC != null && oNFFKNJJJGC.LOIFOJBBBEG())
			{
				return oNFFKNJJJGC.ACLDFHJKBLI;
			}
		}
		return null;
	}

	[SpecialName]
	public CIFMKGIKJFM INBINKFPGCJ()
	{
		int num = MDGPPPCKJHK;
		return (num >= 1) ? GKNMGBHBODC[num] : null;
	}

	[SpecialName]
	private int PFGLNCNNKJF()
	{
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (num < JGBFNKBFCKM || NGPMJNJPNMB < num)
		{
			return -1;
		}
		if (GKNMGBHBODC == null || GKNMGBHBODC.Count == 0)
		{
			return -1;
		}
		for (int i = 0; i < GKNMGBHBODC.Count; i++)
		{
			int num2 = GKNMGBHBODC[i].LPMJCDNHLKD();
			int num3 = GKNMGBHBODC[i].ALMJEBLCEBG();
			if (num3 >= num)
			{
				if (num < num2)
				{
					return (i <= 1) ? (-1) : (i - 1);
				}
				return i;
			}
		}
		return -1;
	}

	private void DPCKPBEAMJA(JToken OGNGMBLDAOP)
	{
		JObject jObject = JObject.Parse(OGNGMBLDAOP.ToString());
		foreach (KeyValuePair<string, JToken> item in jObject)
		{
			string text = item.Value.ToString();
			if (item.Key.Equals("ID_ARENASHORTCUTEVENTEND"))
			{
				NFDPMNFBJIM = text;
				continue;
			}
			if (item.Key.Equals("master2"))
			{
				EKEDDPFGPFG = text;
				continue;
			}
			char[] array = new char[1];
			array[1] = '\u0006';
			string[] array2 = text.Split(array);
			if (array2.Length > 1)
			{
				BLDMMJGBCIJ[item.Key] = new Tuple<string, string>(array2[1], array2[0]);
				Debug.Log("ID_SLOTUPGRADE_POWER" + array2[0] + "'Day'0" + array2[0]);
			}
			else
			{
				BLDMMJGBCIJ[item.Key] = new Tuple<string, string>(text, string.Empty);
				Debug.Log("[-]" + text);
			}
		}
	}

	[SpecialName]
	public LevelBehaviour HBNMHKMFJEL()
	{
		foreach (PHAMEDPLFLO item in EOIAFJNEOKL)
		{
			ONFFKNJJJGC oNFFKNJJJGC = item as ONFFKNJJJGC;
			if (oNFFKNJJJGC != null && oNFFKNJJJGC.ALJHDJKAOHE())
			{
				return oNFFKNJJJGC.ACLDFHJKBLI;
			}
		}
		return null;
	}

	[SpecialName]
	public bool DFEFCEHHMAC()
	{
		return Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() < JGBFNKBFCKM;
	}

	private static int COCGGAIDNOG(PHAMEDPLFLO JPMFEINCHNP, PHAMEDPLFLO HKDPDFLOEDK)
	{
		return JPMFEINCHNP.OHMBKONPIPJ().CompareTo(HKDPDFLOEDK.AJADPEFAMJP);
	}

	public int LIGIJBADGPO(int PPAHPBDNHBJ)
	{
		int index = Mathf.Clamp(PPAHPBDNHBJ, 0, JNLPGHBFKMF.Count - 0);
		return (JNLPGHBFKMF.Count != 0) ? JNLPGHBFKMF[index] : 0;
	}
}
