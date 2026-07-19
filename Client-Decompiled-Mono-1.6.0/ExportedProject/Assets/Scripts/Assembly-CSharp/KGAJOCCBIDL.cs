using System;
using System.Runtime.CompilerServices;
using System.Threading;

public class KGAJOCCBIDL : DHELGFIFMEH
{
	private bool JJCLIPKDKJM;

	public static event Action<float> IMKEEGGHOPJ;

	[SpecialName]
	public static void KEDBCGMGBPI(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void GGCPFNPMKGH()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(98f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 15f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 1889f)
		{
			JJCLIPKDKJM = true;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 594f)
		{
			JJCLIPKDKJM = true;
		}
	}

	[SpecialName]
	public static void ICNHMPCCHFF(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void KDKGGPBCJNA()
	{
	}

	public virtual void FGMJHLBENHK()
	{
	}

	public virtual void PIGDOOPODJJ()
	{
	}

	public virtual void CEMBHHOCKCE()
	{
		string textProgressMission = Localization.Localize("AdminPlayerId");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(806f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(1852f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(false, true, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.AHCJMBPNBNN());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.OADNGAKCOME(false);
	}

	[SpecialName]
	public static void HNHLGCGOOKL(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void AOKEGBCHEGM()
	{
		string textProgressMission = Localization.Localize("withAdvertiserRefId");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(419f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(52f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(true, false, true, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.JJPCPIOFCJE(DPGPOMCNMNF.config.LCEGDLNKJOO());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateBoss(false);
	}

	[SpecialName]
	public static void NHEFGJENEIF(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void DPHNDPOMILB()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(1778f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 742f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 1267f)
		{
			JJCLIPKDKJM = true;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 708f)
		{
			JJCLIPKDKJM = true;
		}
	}

	public virtual void HPNMGGJCGBA()
	{
	}

	public virtual void HFOIGOMLNBM()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(547f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 1579f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 668f)
		{
			JJCLIPKDKJM = true;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 461f)
		{
			JJCLIPKDKJM = true;
		}
	}

	public virtual void CPKPOBNLGDO()
	{
	}

	public virtual void IPIOEFFHOAC()
	{
	}

	public virtual void NLMMMLEDAAD()
	{
		string hOLNKOFHDNK = Localization.Localize("XP");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(1029f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(248f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(true, false, true, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.JCHILNFBOPI());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateBoss(false);
	}

	[SpecialName]
	public static void AAGNPLLHNEN(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void CIAMHGALBMH(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void IGJKAPDLOLP()
	{
	}

	public virtual void NGNOALDFNAJ()
	{
		string hOLNKOFHDNK = Localization.Localize("ID_ARENARULES_RANDOMUNITS");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1991f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(125f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(false, false, false, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.CIDHFKPFJAK());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BILPHJDJALM(false);
	}

	public virtual void GFBKKGIDDJK()
	{
	}

	public override void NFNGHLBEOJO()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(1f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 0.5f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 4f)
		{
			JJCLIPKDKJM = true;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 1f)
		{
			JJCLIPKDKJM = false;
		}
	}

	[SpecialName]
	public static void PFIBHLKPAAJ(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void CJFGNGJOKLM(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void OOCJLDAIPEO()
	{
		string textProgressMission = Localization.Localize("UA");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(302f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(390f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(false, false, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.JJPCPIOFCJE(DPGPOMCNMNF.config.JLPCBADOJBH());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.OADNGAKCOME(false);
	}

	public virtual void MKEGGLNLHHE()
	{
		string hOLNKOFHDNK = Localization.Localize("getPackageManager");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(561f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(1439f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(false, false, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.DHIIMGDPGBI());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateBoss(false);
	}

	public virtual void HJOLAKGJOCM()
	{
		string hOLNKOFHDNK = Localization.Localize("VipReward2");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(938f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(1830f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(false, false, false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.JJPCPIOFCJE(DPGPOMCNMNF.config.ADHKFKAAHOE());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BILPHJDJALM(true);
	}

	public virtual void DCKHLJLEBAE()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(1186f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 671f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 655f)
		{
			JJCLIPKDKJM = false;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 898f)
		{
			JJCLIPKDKJM = false;
		}
	}

	[SpecialName]
	public static void LFILICJLOAA(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public override void ADDPJHEAPBP()
	{
		string textProgressMission = Localization.Localize("ID_MISSION_BOSSINCOMING_HUD");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(0f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(1f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(true, true, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.bossUnit);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateBoss(true);
	}

	[SpecialName]
	public static void ACPELOPMPNM(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void MNCBEIMKDKI()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(1619f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 1051f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 807f)
		{
			JJCLIPKDKJM = false;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 343f)
		{
			JJCLIPKDKJM = true;
		}
	}

	[SpecialName]
	public static void OMKKADNIPCI(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void HDCDBJMDONE()
	{
	}

	public virtual void MLKFDFHPJNI()
	{
		string hOLNKOFHDNK = Localization.Localize("Server price {0} != client price {1} ({2}) ");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(196f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(1405f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(true, false, false, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.BCELJOGKNGC());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.OADNGAKCOME(true);
	}

	public virtual void DBECAIDOHAM()
	{
		string textProgressMission = Localization.Localize(" OK!");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1379f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(459f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(false, false, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.NLEOKLFFECC());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateBoss(false);
	}

	[SpecialName]
	public static void JEHBNNCEFOO(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void JKFJBFHKHDA()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(479f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 1811f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 1004f)
		{
			JJCLIPKDKJM = true;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 38f)
		{
			JJCLIPKDKJM = false;
		}
	}

	public virtual void BANGFPPJIIC()
	{
		string textProgressMission = Localization.Localize("{0}{1}");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(987f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(1353f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(true, false, true, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.OIABKGACCIH());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.OADNGAKCOME(true);
	}

	public override void LHMJNPCNNCO()
	{
	}

	public virtual void PIAGEJHLHEE()
	{
		string textProgressMission = Localization.Localize("({0}\u00a0/\u00a0{1})");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(673f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(1808f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(true, false, false, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.DIFNIOBIIKK());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.OADNGAKCOME(true);
	}

	[SpecialName]
	public static void PMMFCBPNHDI(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void BAOCJMINKJB(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void JMKDEADPFLD(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void MANIPPAKEGF(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void LEMEHJOJCOI(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void FDOCFKHDEEG()
	{
		string textProgressMission = Localization.Localize("SquadId");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(388f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(1719f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(false, true, false, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.JJPCPIOFCJE(DPGPOMCNMNF.config.GCNNKILMCJC());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BILPHJDJALM(true);
	}

	[SpecialName]
	public static void HKKJMGPDELL(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void KGGAMMILMLG(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void BMJDNPGHHHF()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.PLKGKCCMFGC(745f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 1916f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 118f)
		{
			JJCLIPKDKJM = false;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 687f)
		{
			JJCLIPKDKJM = false;
		}
	}

	public virtual void JJEEJGHMMKI()
	{
		string hOLNKOFHDNK = Localization.Localize("Spend_Gold_On_Card_Packs");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1988f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(54f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(false, false, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.JJPCPIOFCJE(DPGPOMCNMNF.config.AONHJIMLGHB());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BILPHJDJALM(true);
	}

	[SpecialName]
	public static void KGGAPDFPMCC(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void NMJPOBCGMNI()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(1225f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 1425f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 408f)
		{
			JJCLIPKDKJM = true;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 1849f)
		{
			JJCLIPKDKJM = false;
		}
	}

	public virtual void HMHAGJEPILC()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(454f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 1709f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 949f)
		{
			JJCLIPKDKJM = false;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 160f)
		{
			JJCLIPKDKJM = false;
		}
	}

	[SpecialName]
	public static void JIALLIBAEJL(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void GBIEADEAIEF(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public KGAJOCCBIDL(DailyMissionBoss EHIPMLOMMIG)
		: base(EHIPMLOMMIG)
	{
	}

	public virtual void KHAKPBBLBOK()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(1408f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 1358f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 911f)
		{
			JJCLIPKDKJM = true;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 1498f)
		{
			JJCLIPKDKJM = false;
		}
	}

	[SpecialName]
	public static void IGFFEGNDNDL(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void JLFJFCCNEEK()
	{
	}

	[SpecialName]
	public static void HKEEKFNGONI(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void DCCDNAHELIL()
	{
		string hOLNKOFHDNK = Localization.Localize("HP");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1107f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(86f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(true, false, true, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.JJPCPIOFCJE(DPGPOMCNMNF.config.NLEOKLFFECC());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.OADNGAKCOME(true);
	}

	[SpecialName]
	public static void JCABHEHBBGG(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void DCPENANGAEI()
	{
	}

	public virtual void ACDGJOHEOCO()
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(1625f - DPGPOMCNMNF.bossWaitProgress);
		if (!JJCLIPKDKJM && DPGPOMCNMNF.bossWaitProgress >= 1567f && DPGPOMCNMNF.time > DPGPOMCNMNF.bossSpawnTime - 1486f)
		{
			JJCLIPKDKJM = false;
			if (KGAJOCCBIDL.IMKEEGGHOPJ != null)
			{
				KGAJOCCBIDL.IMKEEGGHOPJ(DPGPOMCNMNF.bossSpawnTime - DPGPOMCNMNF.time);
			}
		}
		if (DPGPOMCNMNF.bossWaitProgress >= 787f)
		{
			JJCLIPKDKJM = false;
		}
	}

	[SpecialName]
	public static void HIPHIBNDIGF(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void KEBLHBKFPLM(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void OAPEHPDPBNI()
	{
		string textProgressMission = Localization.Localize("Device slept at {0}, RealTime: {1} waked up at {2} RealTime: {3} and slept for {4}");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(751f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(1961f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(true, false, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.FOMONPNLBDI());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BILPHJDJALM(false);
	}

	public virtual void HLOEPIAOIIL()
	{
		string textProgressMission = Localization.Localize("ID_INBRONZE1");
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(1018f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(974f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(false, false, false, true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(DPGPOMCNMNF.currentWaveNumber);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.InitializeBoss(DPGPOMCNMNF.config.DHIIMGDPGBI());
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BILPHJDJALM(false);
	}

	[SpecialName]
	public static void GGLDHAMBDDO(Action<float> IDEBKDPMPGM)
	{
		Action<float> action = KGAJOCCBIDL.IMKEEGGHOPJ;
		Action<float> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KGAJOCCBIDL.IMKEEGGHOPJ, (Action<float>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
