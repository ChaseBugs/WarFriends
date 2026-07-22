using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class IGAAGFOBKMO : HHFHFANGCEJ
{
	public override bool JLCLGAKDIMG => true;

	[SpecialName]
	public virtual bool FPPOAPEOFCE()
	{
		return false;
	}

	[SpecialName]
	public virtual bool OLOHGBBGGFF()
	{
		return false;
	}

	public IGAAGFOBKMO(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("Message: squad player ended game -> get squad details to sync exp and stats");
		}
	}

	[SpecialName]
	public override bool MDIDMLHIFPH()
	{
		return false;
	}

	public virtual void FLMALOGGOBN()
	{
		base.OEAJBFLGJCA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 79 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		CALACCCGMGD();
	}

	public virtual void DMLDBKFCACB()
	{
		base.JPGMEFJGNNA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 90 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		BCIOBLLBLLC();
	}

	[SpecialName]
	public virtual bool KFOBCAJOMBP()
	{
		return true;
	}

	public virtual void DAOFPMOAIPI()
	{
		base.GEKIMGFKNHC();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -4 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		CALACCCGMGD();
	}

	public virtual void KHLDOFCPOED()
	{
		base.KPANLOMNEIG();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -10 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		OJFJOJONNJK();
	}

	public virtual void BIIHCAEKCOD()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -5 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		OJFJOJONNJK();
	}

	public virtual void DANAMJKOPBO()
	{
		base.JPGMEFJGNNA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 103 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		CALACCCGMGD();
	}

	public override void JPGMEFJGNNA()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -3 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		JFDENNGOGJC();
	}

	public virtual void DONHNAIKMCB()
	{
		base.OBJEMJHBJFO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 16 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		BCIOBLLBLLC();
	}

	public virtual void GCLFBCIKNAH()
	{
		base.GEKIMGFKNHC();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -29 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool KEDNCHMBHGP()
	{
		return false;
	}

	public virtual void AHHCFAIJCAE()
	{
		base.OBJEMJHBJFO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 4 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool NLKIOKAOCIN()
	{
		return true;
	}

	[SpecialName]
	public virtual bool PJMLLGJDFOO()
	{
		return true;
	}

	[SpecialName]
	public virtual bool NEKCMEGLOAC()
	{
		return true;
	}

	[SpecialName]
	public virtual bool EIJLNLGHKGJ()
	{
		return false;
	}

	[SpecialName]
	public virtual bool EEAMNNOMNFN()
	{
		return true;
	}

	public virtual void CALBGDIEDGA()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -61 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		CALACCCGMGD();
	}

	public override void MGKMBCBBOHK()
	{
		base.OBJEMJHBJFO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 97 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		OJFJOJONNJK();
	}

	public virtual void BBOHJOFMLDI()
	{
		base.OEAJBFLGJCA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 126 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		IFFBCOLBDOP();
	}

	public virtual void OCHDOJMAGHA()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -57 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool IGDONKCHDHP()
	{
		return false;
	}

	public virtual void DJNMPLKPENF()
	{
		base.MGKMBCBBOHK();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 85 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		JFDENNGOGJC();
	}

	[SpecialName]
	public virtual bool PGDNINHCMPP()
	{
		return false;
	}

	public virtual void PAFPBIGHJCI()
	{
		base.LOFMDBHAFAO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 85 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		IFFBCOLBDOP();
	}

	public virtual void MIGAJINCHAH()
	{
		base.GEKIMGFKNHC();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 43 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		BCIOBLLBLLC();
	}

	public virtual void FCANLIOLJNH()
	{
		base.MGKMBCBBOHK();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -39 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		CALACCCGMGD();
	}

	public virtual void ONPCIKIOBIG()
	{
		base.OLECKGKLHCE();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -19 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		IFFBCOLBDOP();
	}

	public virtual void EHPIMALJLPB()
	{
		base.OBJEMJHBJFO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -95 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		BCIOBLLBLLC();
	}

	public virtual void JBMCFEMBPKE()
	{
		base.OBJEMJHBJFO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -7 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		CALACCCGMGD();
	}

	public virtual void DFJBBKKIPAD()
	{
		base.OBJEMJHBJFO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 85 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		IFFBCOLBDOP();
	}

	[SpecialName]
	public virtual bool NCKCCIHPKEN()
	{
		return false;
	}

	public virtual void KHCIMEFCJFC()
	{
		base.KPANLOMNEIG();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -79 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		IFFBCOLBDOP();
	}

	[SpecialName]
	public virtual bool GGMLPGENPFJ()
	{
		return true;
	}

	public virtual void JLJMIOLJPNL()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 81 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		JFDENNGOGJC();
	}

	public virtual void NBBAANHAAKK()
	{
		base.OEAJBFLGJCA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 42 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		OJFJOJONNJK();
	}

	public override void OEAJBFLGJCA()
	{
		base.JPGMEFJGNNA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -57 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		BCIOBLLBLLC();
	}

	public virtual void KGEEDMONDMK()
	{
		base.MGKMBCBBOHK();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 97 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		BCIOBLLBLLC();
	}

	[SpecialName]
	public override bool KILOAOCGEGC()
	{
		return true;
	}

	public virtual void FONKGJCBLPJ()
	{
		base.LOFMDBHAFAO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 95 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		JFDENNGOGJC();
	}

	[SpecialName]
	public virtual bool IHMKFJKKPFB()
	{
		return true;
	}

	public virtual void DLCFAJEFLHO()
	{
		base.OBJEMJHBJFO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 88 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		OJFJOJONNJK();
	}

	public virtual void NBGFNLOCPAD()
	{
		base.JPGMEFJGNNA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -45 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool LFIMOJLHHAL()
	{
		return true;
	}

	public virtual void EEBNPGOCKFD()
	{
		base.KPANLOMNEIG();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -114 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		CALACCCGMGD();
	}

	public virtual void NFEADFKKCOG()
	{
		base.JPGMEFJGNNA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 115 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		BCIOBLLBLLC();
	}

	[SpecialName]
	public virtual bool IBFOIGAJCHD()
	{
		return true;
	}

	[SpecialName]
	public virtual bool DCANLMHPNCC()
	{
		return true;
	}

	public virtual void GNKIMPLPOPA()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 11 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool FNMABKHBPFK()
	{
		return true;
	}

	public virtual void ODDNDGAAOCH()
	{
		base.MGKMBCBBOHK();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 94 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		OJFJOJONNJK();
	}

	public virtual void CFNILANPGBC()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -73 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		BCIOBLLBLLC();
	}

	[SpecialName]
	public virtual bool EGGJHNGCCIE()
	{
		return true;
	}

	public virtual void BELBLFGCCLJ()
	{
		base.LOFMDBHAFAO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -56 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		IFFBCOLBDOP();
	}

	public virtual void BFOPAOLPODG()
	{
		base.LOFMDBHAFAO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 5 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		IFFBCOLBDOP();
	}

	public virtual void EFBEJJEIPEG()
	{
		base.KPANLOMNEIG();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 121 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		BCIOBLLBLLC();
	}

	[SpecialName]
	public virtual bool LMKIHMKMJKD()
	{
		return false;
	}

	public virtual void PEBHGOMEKME()
	{
		base.OEAJBFLGJCA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 81 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		JFDENNGOGJC();
	}

	[SpecialName]
	public virtual bool DHEIBBNLKGJ()
	{
		return true;
	}

	[SpecialName]
	public virtual bool PKGNKCHHCGE()
	{
		return true;
	}

	[SpecialName]
	public virtual bool GGMLNLADMID()
	{
		return false;
	}

	[SpecialName]
	public virtual bool KBPELCOEFKI()
	{
		return true;
	}

	[SpecialName]
	public virtual bool NJBGFDDLBFD()
	{
		return false;
	}

	[SpecialName]
	public virtual bool BLJCOALKNBK()
	{
		return false;
	}

	public virtual void GLMKGLKCDAL()
	{
		base.OEAJBFLGJCA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 33 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		BCIOBLLBLLC();
	}

	[SpecialName]
	public override bool KJJKDDDEIJD()
	{
		return true;
	}

	[SpecialName]
	public virtual bool HMILIHOLIFN()
	{
		return true;
	}

	[SpecialName]
	public virtual bool GGMFNDNKJMH()
	{
		return false;
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		OJFJOJONNJK();
	}

	public virtual void DIBLFOPCCPL()
	{
		base.GEKIMGFKNHC();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -87 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		JFDENNGOGJC();
	}

	[SpecialName]
	public virtual bool IFAAKLECIMN()
	{
		return true;
	}

	[SpecialName]
	public virtual bool ICPDFFMNKLF()
	{
		return true;
	}

	[SpecialName]
	public virtual bool JNDKJFKEENA()
	{
		return true;
	}

	public virtual void ECCAFEHCIFM()
	{
		base.JPGMEFJGNNA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -58 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		OJFJOJONNJK();
	}

	[SpecialName]
	public virtual bool HKHHKNIODOA()
	{
		return false;
	}

	[SpecialName]
	public virtual bool BLABCPKIMCH()
	{
		return true;
	}

	[SpecialName]
	public virtual bool EFODPAKMGJP()
	{
		return true;
	}

	public virtual void GKAOMCGCDGE()
	{
		base.JPGMEFJGNNA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 80 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		OJFJOJONNJK();
	}

	public virtual void MJAAGDHAHEM()
	{
		base.GEKIMGFKNHC();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -36 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		CALACCCGMGD();
	}

	public virtual void PCJHCBIHFNF()
	{
		base.LOFMDBHAFAO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -37 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		OJFJOJONNJK();
	}

	[SpecialName]
	public virtual bool BPGBGBHDICA()
	{
		return false;
	}

	public virtual void HDKCFAMJBBO()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 101 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		BCIOBLLBLLC();
	}

	public virtual void EMHGOECGAFL()
	{
		base.JPGMEFJGNNA();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 104 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName);
		}
		CALACCCGMGD();
	}

	[SpecialName]
	public override bool IJELOOFLPCK()
	{
		return true;
	}

	[SpecialName]
	public virtual bool HKPFPJMPAHN()
	{
		return true;
	}

	[SpecialName]
	public virtual bool COKCGHJKIPN()
	{
		return false;
	}

	public virtual void GCJGIELEEML()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -96 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(squadName, NMFKCMDIPCO: false);
		}
		IFFBCOLBDOP();
	}

	[SpecialName]
	public virtual bool ODNMJAJNOMG()
	{
		return true;
	}
}
