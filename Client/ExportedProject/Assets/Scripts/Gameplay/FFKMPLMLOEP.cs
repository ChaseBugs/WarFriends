using System.Runtime.CompilerServices;
using UnityEngine;

public class FFKMPLMLOEP : HHFHFANGCEJ
{
	private LevelBehaviour EKJIFCIENBJ;

	private void GCAGLKMOCHH()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void NNMIBNEJDCF()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void GONPOAPHNPD()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void BOCFPBIHNLI()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void FPOIGOFDIPF()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, BOCFPBIHNLI);
	}

	private void GJHKFCIJLIN()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void GKAOMCGCDGE()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, NKAAGPPLFGB);
	}

	public virtual void EKNDHCNIJFG()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, PGFKGCBBAIF);
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, delegate
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}

	public virtual void BELBLFGCCLJ()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, OIGAMNOODOI);
	}

	private void PGFKGCBBAIF()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public override void LOFMDBHAFAO()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, HHMEDBNHLDE);
	}

	public virtual void PEBHGOMEKME()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, GCAGLKMOCHH);
	}

	public virtual void PCJHCBIHFNF()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, DGGMLOIAPHF);
	}

	public virtual void ALKFOHIAKOM()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, EJCPGCEAIFM);
	}

	private void NFHFHOLDFAM()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void GCLFBCIKNAH()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, MJGLCADCMDG);
	}

	private void COFECDOBJJD()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void GGHDIAFACAH()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, GJHKFCIJLIN);
	}

	private void IKPOJPGJCME()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void KGEEDMONDMK()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, PGFKGCBBAIF);
	}

	public virtual void MIGAJINCHAH()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, EJCPGCEAIFM);
	}

	private void IHMIOHEHMPG()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void DLLIMFKIPFE()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void ONCKKJFAMKF()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, MBAKHHIIJKD);
	}

	private void JBCPJBHIOJN()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void DGGMLOIAPHF()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void AMFEDOOPGCL()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, DGGMLOIAPHF);
	}

	private void HHMEDBNHLDE()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void HONPFADFFDP()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, FOKHBNODKHD);
	}

	private void HLGCBEGJBNI()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void FFMLINMFADM()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, NGNEJEPJLBH);
	}

	public virtual void HDKCFAMJBBO()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, MJGLCADCMDG);
	}

	public virtual void DLCFAJEFLHO()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, NGNEJEPJLBH);
	}

	private void NKAAGPPLFGB()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void LIEAKPFPAJD()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, COFECDOBJJD);
	}

	public virtual void EHPIMALJLPB()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, IHMIOHEHMPG);
	}

	private void HHFPGHGKLEG()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void OIGAMNOODOI()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void GLMKGLKCDAL()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, IKPOJPGJCME);
	}

	private void JIGLHDFPGNN()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void IECHFELOIIO()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, HLGCBEGJBNI);
	}

	private void APGNAMNHNHB()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void DLNGGGOEDLL()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, JIGLHDFPGNN);
	}

	public virtual void AHHCFAIJCAE()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, HGFAACGJEDJ);
	}

	public virtual void DONHNAIKMCB()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, BOKIAHEOBDA);
	}

	public virtual void NBBAANHAAKK()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, NGNEJEPJLBH);
	}

	public virtual void CFNILANPGBC()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, PGFKGCBBAIF);
	}

	private void HGFAACGJEDJ()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void EEBNPGOCKFD()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, NKAAGPPLFGB);
	}

	public virtual void DAOFPMOAIPI()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, JIGLHDFPGNN);
	}

	public override void OEAJBFLGJCA()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, NNMIBNEJDCF);
	}

	private void NGNEJEPJLBH()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public FFKMPLMLOEP(LevelBehaviour IOIKKIIFOCB)
		: base($"UpgradeUnitReminder {IOIKKIIFOCB.unitName} {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", NKHJBLBAAEB.UpgradeUnitReminder)
	{
		EKJIFCIENBJ = IOIKKIIFOCB;
		Debug.Log("About to show Upgrade Unit Reminder: " + EKJIFCIENBJ.unitName);
	}

	private void EEMPBBKNGOP()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void FAFEGBECEEM()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, NKAAGPPLFGB);
	}

	public virtual void GBEBFIDEOHH()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, JBCPJBHIOJN);
	}

	private void MJGLCADCMDG()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void BJGDGMDOKLH()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, delegate
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}

	private void PNPMKCPAPNL()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public override void JPGMEFJGNNA()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, EEMPBBKNGOP);
	}

	public virtual void CALBGDIEDGA()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, IKPOJPGJCME);
	}

	private void EJCPGCEAIFM()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void LDGKPCDJPLA()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, MJGLCADCMDG);
	}

	public virtual void BHGDOHCBGEC()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, NFHFHOLDFAM);
	}

	private void FGFMFHGGADH()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void DEMHFGKGCHL()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void OIFHEIPBAKO()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	private void MBAKHHIIJKD()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void BOKIAHEOBDA()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void CBBLGFEBJID()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, GJHKFCIJLIN);
	}

	public virtual void JEDGCOMDEKM()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, EEMPBBKNGOP);
	}

	public virtual void LEOMLFCGIHK()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, HHMEDBNHLDE);
	}

	public virtual void LCCEEAMLHDD()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, DEMHFGKGCHL);
	}

	[CompilerGenerated]
	private void KIGFNOMALGA()
	{
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void FPLCMPHNNHK()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, NGNEJEPJLBH);
	}

	public virtual void BBJADAJPJHH()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, BOCFPBIHNLI);
	}

	public virtual void OFPAGLLFPPK()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, MBAKHHIIJKD);
	}

	public virtual void FPGMPPJCIJJ()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, HHFPGHGKLEG);
	}

	public virtual void BFOPAOLPODG()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, FOKHBNODKHD);
	}

	private void FOKHBNODKHD()
	{
		GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(EKJIFCIENBJ);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		GuiScreenSingle<ArmyScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void LBHAHNFALLB()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.KFBGMCKDNBD(EKJIFCIENBJ, IKPOJPGJCME);
	}

	public virtual void AEHBKBBILPB()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(EKJIFCIENBJ, DGGMLOIAPHF);
	}
}
