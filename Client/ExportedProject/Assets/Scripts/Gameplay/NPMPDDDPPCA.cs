using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class NPMPDDDPPCA : HHFHFANGCEJ
{
	public DateTime AMPKDOIKPAB;

	private string KGPAGNONACC;

	private string NOFEFEOMGFN;

	private int DPGIJIGIPAD;

	private void GEEKIKMPIOB()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.IIPMPFILDMG(KGPAGNONACC, NOFEFEOMGFN);
	}

	internal virtual Action BKLBFKCBFPP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SystemMessage(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return OBHPOPMOCLN;
	}

	internal virtual Action HKAPIMJJIML(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LJOIBIICONE(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return ADNPHLPCIJP;
	}

	internal virtual Action DBEMJDBHDIM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SystemMessage(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return KAHGGAACJIB;
	}

	internal virtual Action AKOIJGNDJJH(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LJOIBIICONE(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return OBHPOPMOCLN;
	}

	public virtual void NLMKCDMBPPC()
	{
		base.OEAJBFLGJCA();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.IIPMPFILDMG(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("Snapshots");
		}
		BCIOBLLBLLC();
	}

	public virtual void JEDGCOMDEKM()
	{
		base.LEJEDFACEGP();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.IIPMPFILDMG(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("PNManager: Received event: ");
		}
		JFDENNGOGJC();
	}

	private void HFMKFBGGKNO()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.EFADIDPEAAD(KGPAGNONACC, NOFEFEOMGFN);
	}

	internal virtual Action CEBACDKLHDG(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LJOIBIICONE(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return DJECJGEAHPM;
	}

	private void AJPLMHKHINO()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.CBCMELNOMIO(KGPAGNONACC, NOFEFEOMGFN);
	}

	internal virtual Action BDKMGBLJKLJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LJOIBIICONE(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return JHKDMDCJHJJ;
	}

	private void CKAEFBDMIID()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.AIAMABGEOCI(KGPAGNONACC, NOFEFEOMGFN);
	}

	public virtual void IECHFELOIIO()
	{
		base.OLECKGKLHCE();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.ShowSystemMaintenance(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("fuseData");
		}
		IFFBCOLBDOP();
	}

	public virtual void OHJAAIJDAAG()
	{
		base.OBJEMJHBJFO();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.IIPMPFILDMG(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("********** DEBUG GAINED CARDS **********\n");
		}
		JFDENNGOGJC();
	}

	private void KAHGGAACJIB()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.IIPMPFILDMG(KGPAGNONACC, NOFEFEOMGFN);
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.ShowSystemMaintenance(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("NOT SHOWING MAINTENANCE BECAUSE IT IS TOO LATE");
		}
		OJFJOJONNJK();
	}

	public virtual void FCANLIOLJNH()
	{
		base.KPANLOMNEIG();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.CBCMELNOMIO(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("()Z");
		}
		OJFJOJONNJK();
	}

	public NPMPDDDPPCA(DateTime LPPOJMGOEFN)
		: base("SystemMessage", NKHJBLBAAEB.SystemMessage)
	{
		AMPKDOIKPAB = LPPOJMGOEFN;
		KGPAGNONACC = AMPKDOIKPAB.ToString("D");
		NOFEFEOMGFN = AMPKDOIKPAB.ToString("HH:mm");
		NHHGDIDEIMM += KGPAGNONACC.ToString();
	}

	public virtual void NNPILDOKNJO()
	{
		base.LOFMDBHAFAO();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.CBCMELNOMIO(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("HKCBJLIBNJF");
		}
		BCIOBLLBLLC();
	}

	internal virtual Action JPAFAKBJNNP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SystemMessage(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return CKAEFBDMIID;
	}

	public virtual void EKNDHCNIJFG()
	{
		base.KPANLOMNEIG();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.AIAMABGEOCI(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log(" {0}\u00a0{1}");
		}
		BCIOBLLBLLC();
	}

	public virtual void DFJBBKKIPAD()
	{
		base.GEKIMGFKNHC();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.EFADIDPEAAD(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("Used warcards and rewards from last match wre removed");
		}
		OJFJOJONNJK();
	}

	internal virtual Action FAKMLJMJCKF(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SystemMessage(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return ADNPHLPCIJP;
	}

	private void FOKGBDDBJFM()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.AIAMABGEOCI(KGPAGNONACC, NOFEFEOMGFN);
	}

	internal virtual Action BFDIJGGPNCO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LJOIBIICONE(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return CCPPBMANOGC;
	}

	[CompilerGenerated]
	private void JKIAEOLFEGC()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.ShowSystemMaintenance(KGPAGNONACC, NOFEFEOMGFN);
	}

	private void FHHADMEGKKL()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.AIAMABGEOCI(KGPAGNONACC, NOFEFEOMGFN);
	}

	public virtual void JBMCFEMBPKE()
	{
		base.LEJEDFACEGP();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.CPONPDNLALC(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("Buggy");
		}
		JFDENNGOGJC();
	}

	public virtual void DANAMJKOPBO()
	{
		base.LOFMDBHAFAO();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.CBCMELNOMIO(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("ADDING VISUAL ON CLIENT ");
		}
		OJFJOJONNJK();
	}

	private void OBHPOPMOCLN()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.EFADIDPEAAD(KGPAGNONACC, NOFEFEOMGFN);
	}

	internal virtual Action OGPPKOPMIOJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LJOIBIICONE(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return DJECJGEAHPM;
	}

	private void JHKDMDCJHJJ()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.EFADIDPEAAD(KGPAGNONACC, NOFEFEOMGFN);
	}

	internal virtual Action PKGCMKFOOOA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LJOIBIICONE(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return KAHGGAACJIB;
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SystemMessage(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return delegate
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.ShowSystemMaintenance(KGPAGNONACC, NOFEFEOMGFN);
		};
	}

	public NPMPDDDPPCA(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		DPGIJIGIPAD = OGNGMBLDAOP["Time"]["N"].ToObject<int>();
		AMPKDOIKPAB = MEJMLNDFDBP.LAEDFBJFGBP(DPGIJIGIPAD).ToLocalTime();
		KGPAGNONACC = AMPKDOIKPAB.ToString("D");
		NOFEFEOMGFN = AMPKDOIKPAB.ToString("HH:mm");
	}

	public virtual void BLFNIFFFAIJ()
	{
		base.KPANLOMNEIG();
		if (DPGIJIGIPAD > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.NMGLGFCIDLN(KGPAGNONACC, NOFEFEOMGFN);
		}
		else
		{
			Debug.Log("GPGS: Logged Out, Logged: ");
		}
		BCIOBLLBLLC();
	}

	private void ADNPHLPCIJP()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.CBCMELNOMIO(KGPAGNONACC, NOFEFEOMGFN);
	}

	private void CCPPBMANOGC()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.EFADIDPEAAD(KGPAGNONACC, NOFEFEOMGFN);
	}

	private void HKFCPFCALBB()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.IIPMPFILDMG(KGPAGNONACC, NOFEFEOMGFN);
	}

	private void DJECJGEAHPM()
	{
		GuiElementSingle<SystemMaintenanceDialog>.instance.IIPMPFILDMG(KGPAGNONACC, NOFEFEOMGFN);
	}

	internal virtual Action KBEKIOGPKKD(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LJOIBIICONE(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return DJECJGEAHPM;
	}

	internal virtual Action PFIMIDPFAME(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LJOIBIICONE(HPGHHECHLAN, KJCKFGCLGLG, KGPAGNONACC);
		return HFMKFBGGKNO;
	}
}
