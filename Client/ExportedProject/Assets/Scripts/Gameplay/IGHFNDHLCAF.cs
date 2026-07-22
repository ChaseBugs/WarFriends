public class IGHFNDHLCAF : HHFHFANGCEJ
{
	private int AFBBPCBCOLC;

	public virtual void LIEAKPFPAJD()
	{
		base.GEKIMGFKNHC();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.LKNNPBOGFCI();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.DOMHIPCOOCC();
		}
	}

	public virtual void IFDIKMKGDPG()
	{
		base.OLECKGKLHCE();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BJCKNPHAKPO();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.BJCKNPHAKPO();
		}
	}

	public virtual void FPOIGOFDIPF()
	{
		base.LEJEDFACEGP();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.KCDCLMGOOGF();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.KCDCLMGOOGF();
		}
	}

	public override void LEJEDFACEGP()
	{
		base.MGKMBCBBOHK();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 4)
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.KIFFMLHFMEE();
		}
	}

	public virtual void PEBHGOMEKME()
	{
		base.LOFMDBHAFAO();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 3)
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.DOMHIPCOOCC();
		}
	}

	public virtual void EKGIMBEJLFH()
	{
		base.MGKMBCBBOHK();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (AFBBPCBCOLC == 7)
		{
			GuiElementSingle<AssignmentsDialog>.instance.LKNNPBOGFCI();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.KIFFMLHFMEE();
		}
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 2)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowDaily();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowDaily();
		}
	}

	public virtual void FPGMPPJCIJJ()
	{
		base.MGKMBCBBOHK();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (AFBBPCBCOLC == 3)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BALGBNGMDBF();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.KIFFMLHFMEE();
		}
	}

	public virtual void PCJHCBIHFNF()
	{
		base.OLECKGKLHCE();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (AFBBPCBCOLC == 6)
		{
			GuiElementSingle<AssignmentsDialog>.instance.KCDCLMGOOGF();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowDaily();
		}
	}

	public IGHFNDHLCAF()
		: base("DailyAssignmentsReminder", NKHJBLBAAEB.SquadLeft)
	{
		NHHGDIDEIMM += Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	public virtual void MNLAIHAPJOA()
	{
		base.JPGMEFJGNNA();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else if (AFBBPCBCOLC == 7)
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.KCDCLMGOOGF();
		}
	}

	public virtual void FJEEHGCABFM()
	{
		base.OLECKGKLHCE();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.KCDCLMGOOGF();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.LKNNPBOGFCI();
		}
	}

	public virtual void GBEBFIDEOHH()
	{
		base.GEKIMGFKNHC();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (AFBBPCBCOLC == 3)
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.BALGBNGMDBF();
		}
	}

	public virtual void NBBAANHAAKK()
	{
		base.OEAJBFLGJCA();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 5)
		{
			GuiElementSingle<AssignmentsDialog>.instance.KCDCLMGOOGF();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
	}

	public virtual void FAFEGBECEEM()
	{
		base.LEJEDFACEGP();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.KCDCLMGOOGF();
		}
	}

	public virtual void CBBLGFEBJID()
	{
		base.MGKMBCBBOHK();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (AFBBPCBCOLC == 4)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BALGBNGMDBF();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.KIFFMLHFMEE();
		}
	}

	public virtual void BHGDOHCBGEC()
	{
		base.OLECKGKLHCE();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else if (AFBBPCBCOLC == 4)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowDaily();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.LKNNPBOGFCI();
		}
	}

	public virtual void OHJAAIJDAAG()
	{
		base.KPANLOMNEIG();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else if (AFBBPCBCOLC == 4)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BJCKNPHAKPO();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.BALGBNGMDBF();
		}
	}

	public virtual void EEOKJCKNEAL()
	{
		base.OBJEMJHBJFO();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 2)
		{
			GuiElementSingle<AssignmentsDialog>.instance.EBNAAOOHAIH();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.EBNAAOOHAIH();
		}
	}

	public virtual void GGHDIAFACAH()
	{
		base.JPGMEFJGNNA();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.LKNNPBOGFCI();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.BJCKNPHAKPO();
		}
	}

	public virtual void EKNDHCNIJFG()
	{
		base.JPGMEFJGNNA();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.LKNNPBOGFCI();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.EBNAAOOHAIH();
		}
	}

	public override void LOFMDBHAFAO()
	{
		base.JPGMEFJGNNA();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (AFBBPCBCOLC == 4)
		{
			GuiElementSingle<AssignmentsDialog>.instance.EBNAAOOHAIH();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.LKNNPBOGFCI();
		}
	}

	public override void OLECKGKLHCE()
	{
		base.OBJEMJHBJFO();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else if (AFBBPCBCOLC == 6)
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowDaily();
		}
	}

	public virtual void HONPFADFFDP()
	{
		base.MGKMBCBBOHK();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 4)
		{
			GuiElementSingle<AssignmentsDialog>.instance.EBNAAOOHAIH();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.KCDCLMGOOGF();
		}
	}

	public virtual void JOGFDHFOOBC()
	{
		base.OEAJBFLGJCA();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 8)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BJCKNPHAKPO();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
	}

	public virtual void IECHFELOIIO()
	{
		base.OEAJBFLGJCA();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 4)
		{
			GuiElementSingle<AssignmentsDialog>.instance.KCDCLMGOOGF();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.KCDCLMGOOGF();
		}
	}

	public IGHFNDHLCAF(int IKMAPEMAILA)
		: base("DailyAssignmentsReminder", NKHJBLBAAEB.SquadLeft)
	{
		NHHGDIDEIMM += Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		AFBBPCBCOLC = IKMAPEMAILA;
	}

	public virtual void KHCIMEFCJFC()
	{
		base.JPGMEFJGNNA();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else if (AFBBPCBCOLC == 7)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowDaily();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
	}

	public virtual void OCHDOJMAGHA()
	{
		base.JPGMEFJGNNA();
		if (AFBBPCBCOLC == 0)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowDaily();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.HCBNJOLCKDM();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.DOMHIPCOOCC();
		}
	}

	public virtual void LCCEEAMLHDD()
	{
		base.KPANLOMNEIG();
		if (AFBBPCBCOLC == 1)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (AFBBPCBCOLC == 4)
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			GuiElementSingle<AssignmentsDialog>.instance.OFFMLIFJFGB();
		}
	}
}
