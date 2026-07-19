using System.Runtime.CompilerServices;
using UnityEngine;

public class MAPKPFJHHEO : HHFHFANGCEJ
{
	private WeaponLevelsSetup MJPDHACGJNM;

	private void LGGNFBHKLDF()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	private void IGNPEFDJBLL()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void PHEFLAHPMDH()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.DGJNCNFFGIK(MJPDHACGJNM, DJFPIHFNBBM);
	}

	private void DBCDBLNFNDF()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void NNPILDOKNJO()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, COFECDOBJJD);
	}

	public virtual void GKKFPJHEEDG()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ReminderDialog>.instance.CPMBBENIBCG(MJPDHACGJNM, INAFHGJGJJL);
	}

	public MAPKPFJHHEO(WeaponLevelsSetup JMMJHCOKCGG)
		: base(string.Format("UpgradeWeaponReminder {0} {1}", JMMJHCOKCGG.weaponName, Singleton<BeanstalkServerManager>.instance.currentTimestamp), NKHJBLBAAEB.UpgradeWeaponReminder)
	{
		MJPDHACGJNM = JMMJHCOKCGG;
		Debug.Log("About to show Upgrade Weapon Reminder: " + MJPDHACGJNM.weaponName);
	}

	public virtual void DLNGGGOEDLL()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, NFHFHOLDFAM);
	}

	public virtual void BLFNIFFFAIJ()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ReminderDialog>.instance.CPMBBENIBCG(MJPDHACGJNM, NFHFHOLDFAM);
	}

	public virtual void HONPFADFFDP()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.ShowWeaponDialog(MJPDHACGJNM, PNPMKCPAPNL);
	}

	public override void MGKMBCBBOHK()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.DGJNCNFFGIK(MJPDHACGJNM, GADPAPKEJHJ);
	}

	public virtual void GBEBFIDEOHH()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.DGJNCNFFGIK(MJPDHACGJNM, KDKCHJGEBIJ);
	}

	private void MJGLCADCMDG()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	private void COFECDOBJJD()
	{
		GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void PNPMKCPAPNL()
	{
		GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void GLMKGLKCDAL()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, MJGLCADCMDG);
	}

	public virtual void LCCEEAMLHDD()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.CPMBBENIBCG(MJPDHACGJNM, IGNPEFDJBLL);
	}

	public virtual void JOGFDHFOOBC()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, HJAFJJKLPLE);
	}

	private void DNLNAOMNBNH()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void IKPOJPGJCME()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public override void LEJEDFACEGP()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ReminderDialog>.instance.ShowWeaponDialog(MJPDHACGJNM, HJAFJJKLPLE);
	}

	public virtual void IFDIKMKGDPG()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.ShowWeaponDialog(MJPDHACGJNM, DJFPIHFNBBM);
	}

	public virtual void BELBLFGCCLJ()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, LGGNFBHKLDF);
	}

	private void FDGDLNMICLP()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void EMHGOECGAFL()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ReminderDialog>.instance.DGJNCNFFGIK(MJPDHACGJNM, MJGLCADCMDG);
	}

	public virtual void IECHFELOIIO()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, OPKFAMHCFPM);
	}

	public virtual void GGHDIAFACAH()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.ShowWeaponDialog(MJPDHACGJNM, HJAFJJKLPLE);
	}

	private void OPKFAMHCFPM()
	{
		GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void OFPAGLLFPPK()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.DGJNCNFFGIK(MJPDHACGJNM, IKPOJPGJCME);
	}

	public virtual void EPHMECKBGAA()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ReminderDialog>.instance.DGJNCNFFGIK(MJPDHACGJNM, HJAFJJKLPLE);
	}

	private void DJFPIHFNBBM()
	{
		GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void HDKCFAMJBBO()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, DNLNAOMNBNH);
	}

	private void NFHFHOLDFAM()
	{
		GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void EJCPGCEAIFM()
	{
		GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void DMLDBKFCACB()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ReminderDialog>.instance.DGJNCNFFGIK(MJPDHACGJNM, LGGNFBHKLDF);
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.ShowWeaponDialog(MJPDHACGJNM, delegate
		{
			GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
			GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}

	private void OHJEKJMIPCA()
	{
		GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	[CompilerGenerated]
	private void KIGFNOMALGA()
	{
		GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void KHCIMEFCJFC()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, DJFPIHFNBBM);
	}

	private void GCAGLKMOCHH()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void MIGAJINCHAH()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ReminderDialog>.instance.DGJNCNFFGIK(MJPDHACGJNM, PNPMKCPAPNL);
	}

	private void KDKCHJGEBIJ()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void GADPAPKEJHJ()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void DIBLFOPCCPL()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ReminderDialog>.instance.DGJNCNFFGIK(MJPDHACGJNM, delegate
		{
			GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
			GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}

	public override void OEAJBFLGJCA()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, IGNPEFDJBLL);
	}

	public virtual void BHGDOHCBGEC()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, OHJEKJMIPCA);
	}

	public virtual void GKAOMCGCDGE()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, OHJEKJMIPCA);
	}

	private void HJAFJJKLPLE()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void BOCFPBIHNLI()
	{
		GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void NFEADFKKCOG()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ReminderDialog>.instance.CPMBBENIBCG(MJPDHACGJNM, MJGLCADCMDG);
	}

	public virtual void LIEAKPFPAJD()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ReminderDialog>.instance.DGJNCNFFGIK(MJPDHACGJNM, IKPOJPGJCME);
	}

	public virtual void JCJFMHGNIOF()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, FDGDLNMICLP);
	}

	private void INAFHGJGJJL()
	{
		GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(MJPDHACGJNM);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		GuiScreenSingle<WeaponScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void EHPIMALJLPB()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ReminderDialog>.instance.ShowWeaponDialog(MJPDHACGJNM, GCAGLKMOCHH);
	}

	public virtual void MNLAIHAPJOA()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ReminderDialog>.instance.JBBIHJGIKPL(MJPDHACGJNM, IKPOJPGJCME);
	}

	public virtual void DPDNJFAKNCM()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.ShowWeaponDialog(MJPDHACGJNM, EJCPGCEAIFM);
	}
}
